﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RGSMobile.SalesOrderDP;
using RGSMobile.ReservationEntry;


namespace RGSMobile
{
    public partial class frmSOscan : Form
    {
        ReservationEntry.ReservationEntry[] ResvList;
        protected List<ReservationEntry.ReservationEntry> TempResvLines = new List<ReservationEntry.ReservationEntry>();
        protected List<string> ResvLineScanIndex = new List<string>();
        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential("admin", "bingo28", "dptech");
        protected string LocationCode = String.Empty; //To use in Reg to Nav
        protected bool bScanned = false;
        protected string SONO;
        public frmSOscan()
        {
            SONO = null;
            InitializeComponent();
            txtTOScan.Focus();

        }

        private void mnuItmMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTR_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void txtBatchNo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtGRNScan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGRNScan_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
        }

        private void mnuGRNBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txtTOScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    txtTOScan.Enabled = false;

                    SalesOrderDP.Sales_Order_DP_Service poCrdSvc = new RGSMobile.SalesOrderDP.Sales_Order_DP_Service();
                    poCrdSvc.Credentials = nc;

                    List<SalesOrderDP.Sales_Order_DP_Filter> filterArray = new List<SalesOrderDP.Sales_Order_DP_Filter>();

                    SalesOrderDP.Sales_Order_DP_Filter nameFilter1 = new SalesOrderDP.Sales_Order_DP_Filter();
                    nameFilter1.Field = SalesOrderDP.Sales_Order_DP_Fields.Shipping_No;
                    nameFilter1.Criteria = txtTOScan.Text.Trim().ToString();
                    filterArray.Add(nameFilter1);

                    //SalesOrderDP.SalesOrderDP poC = poCrdSvc.Read(txtTOScan.Text.Trim().ToString());

                    SalesOrderDP.Sales_Order_DP[] poCarr = poCrdSvc.ReadMultiple(filterArray.ToArray(), null, 0);

                    if (poCarr.Length < 1)
                    {
                        MessageBox.Show("Shipping No. is not found in SO.");
                        this.Close();
                        frmSOscan newScan = new frmSOscan();
                        newScan.ShowDialog();
                       
                    }

                    SalesOrderDP.Sales_Order_DP poC = poCarr[0];
                    bScanned = true;
                    SONO = poC.No.ToString();
                    DataTable dt = new DataTable("MyTable");

                    dt.Columns.Add(new DataColumn("ItemNo"));
                    dt.Columns.Add(new DataColumn("Desc"));
                    dt.Columns.Add(new DataColumn("UOM"));
                    dt.Columns.Add(new DataColumn("Quantity"));
                    dt.Columns.Add(new DataColumn("SecUnit"));
                    dt.Columns.Add(new DataColumn("SecQtytoRec"));
                    dt.Columns.Add(new DataColumn("SecQtytoShp"));

                    for (int i = 0; i < poC.SalesLines.Length; i++)
                    {
                        if (poC.SalesLines[i].Type.ToString().ToLower().StartsWith("item"))
                        {
                            object[] array = new object[7];

                            array[0] = poC.SalesLines[i].No;
                            array[1] = poC.SalesLines[i].Description;
                            array[2] = poC.SalesLines[i].Unit_of_Measure_Code;
                            array[3] = poC.SalesLines[i].Quantity.ToString();
                            array[4] = poC.SalesLines[i].Qty_to_Ship.ToString();
                            array[5] = poC.SalesLines[i].Qty_to_Invoice.ToString();
                            array[6] = poC.SalesLines[i].Quantity_Shipped.ToString();

                            dt.Rows.Add(array);
                        }
                    }

                    lblCount.Text = "( " + dt.Rows.Count.ToString() + " )";

                    dgTOLine.DataSource = dt;
                    dgTOLine.BackColor = Color.SkyBlue;

                    dgTOLine.TableStyles.Clear();
                    dgTOLine.TableStyles.Add(DataGridStyle(dt));

                    Cursor.Current = Cursors.Default;
                    txtTOScan.SelectAll();

                    if (bScanned)
                    {
                        GetTransferRequestLines(poC.No);
                    }
                    txtTOScan.Enabled = false;
                    tbMain.SelectedIndex = 1;
                    txtTRLines.Focus();
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
            }

        }

        private void GetTransferRequestLines(string strScanVal) //Get From Reservation Entry Table
        {
            LocationCode = strScanVal;

            DataTable dt = new DataTable("MyTable");

            dt.Columns.Add(new DataColumn("ItemNo"));
            dt.Columns.Add(new DataColumn("Desc"));
            dt.Columns.Add(new DataColumn("Quantity"));
            dt.Columns.Add(new DataColumn("LotNo"));
            dt.Columns.Add(new DataColumn("LocCode"));

            ReservationEntry_Service Resv_service = new ReservationEntry_Service();
            Resv_service.Credentials = nc;

            List<ReservationEntry_Filter> filterArray = new List<ReservationEntry_Filter>();

            ReservationEntry_Filter nameFilter1 = new ReservationEntry_Filter();
            nameFilter1.Field = ReservationEntry_Fields.Source_Type;
            nameFilter1.Criteria = Reservation.SO_sourceType;
            filterArray.Add(nameFilter1);

            ReservationEntry_Filter nameFilter2 = new ReservationEntry_Filter();
            nameFilter2.Field = ReservationEntry_Fields.Source_ID;
            nameFilter2.Criteria = strScanVal;
            filterArray.Add(nameFilter2);

            ReservationEntry_Filter nameFilter3 = new ReservationEntry_Filter();
            nameFilter3.Field = ReservationEntry_Fields.Source_Subtype;
            nameFilter3.Criteria = Reservation.SO_sourceSubType;
            filterArray.Add(nameFilter3);

            ResvList = Resv_service.ReadMultiple(filterArray.ToArray(), null, 0);

            for (int i = 0; i < ResvList.Length; i++)
            {
                if (!ResvList[i].Scanned)
                {
                    object[] array = new object[5];

                    array[0] = ResvList[i].Item_No;
                    array[1] = ResvList[i].Description;
                    array[2] = Math.Abs(ResvList[i].Quantity);
                    array[3] = ResvList[i].Lot_No;
                    array[4] = ResvList[i].Location_Code;

                    dt.Rows.Add(array);
                }
            }

            lblReqLineCount.Text = "( " + dt.Rows.Count.ToString() + " )";

            dgTrReqLines.DataSource = dt;
            dgTrReqLines.BackColor = Color.SkyBlue;

            dgTrReqLines.TableStyles.Clear();
            dgTrReqLines.TableStyles.Add(DataGridStyleReqLiness(dt));

            Cursor.Current = Cursors.Default;
            txtTOScan.SelectAll();
        }

        private DataGridTableStyle DataGridStyle(DataTable dTable)
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dTable.TableName;

            DataGridColumnStyle s1 = new DataGridTextBoxColumn();
            s1.Width = 120;
            s1.MappingName = "ItemNo";
            s1.HeaderText = "Item No.";
            ts.GridColumnStyles.Add(s1);

            DataGridColumnStyle s2 = new DataGridTextBoxColumn();
            s2.Width = 80;
            s2.MappingName = "Desc";
            s2.HeaderText = "Description";
            ts.GridColumnStyles.Add(s2);

            DataGridColumnStyle s22 = new DataGridTextBoxColumn();
            s22.Width = 80;
            s22.MappingName = "UOM";
            s22.HeaderText = "UOM Code";
            ts.GridColumnStyles.Add(s22);

            DataGridColumnStyle s33 = new DataGridTextBoxColumn();
            s33.Width = 60;
            s33.MappingName = "Quantity";
            s33.HeaderText = "Quantity";
            ts.GridColumnStyles.Add(s33);

            DataGridColumnStyle s3 = new DataGridTextBoxColumn();
            s3.Width = 90;
            s3.MappingName = "SecUnit";
            s3.HeaderText = "Qty to Ship";
            ts.GridColumnStyles.Add(s3);

            DataGridColumnStyle s4 = new DataGridTextBoxColumn();
            s4.Width = 100;
            s4.MappingName = "Qty to Invoice";
            s4.HeaderText = "2nd Qty to Recv.";
            ts.GridColumnStyles.Add(s4);

            DataGridColumnStyle s5 = new DataGridTextBoxColumn();
            s5.Width = 100;
            s5.MappingName = "Qty Shipped";
            s5.HeaderText = "2nd Qty to Ship";
            ts.GridColumnStyles.Add(s5);

            return ts;
        }


        void tabPage1_Click(object sender, System.EventArgs e)
        {
        }

        private void txtTRLines_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = new DataTable("MyTable");

                dt.Columns.Add(new DataColumn("ItemNo"));
                dt.Columns.Add(new DataColumn("Desc"));
                dt.Columns.Add(new DataColumn("Quantity"));
                dt.Columns.Add(new DataColumn("LotNo"));
                dt.Columns.Add(new DataColumn("LocCode"));

                bool found = false;

                for (int i = 0; i < ResvList.Length; i++)
                {
                    if (ResvList[i].Lot_No == txtTRLines.Text.Trim())
                    {
                        if (ResvList[i].Lot_For.ToString().ToLower().StartsWith("batch"))
                        {
                            if (ResvList[i].Batch_No == txtTRLines.Text.Trim())
                            {
                                found = true;

                                if (CheckScannedOrNot(txtTRLines.Text.Trim()))
                                {
                                    MessageBox.Show("Scanned already.");
                                    break;
                                }
                                else
                                {
                                    ResvLineScanIndex.Add(i.ToString());//Get Index for Reg to Nav

                                    TempResvLines.Add(ResvList[i]);

                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("This item can be tracked only Batch No.");
                                break;
                            }
                        }
                        else if (ResvList[i].Lot_For.ToString().ToLower().StartsWith("pallet"))
                        {
                            if (ResvList[i].Pallet_No == txtTRLines.Text.Trim())
                            {
                                found = true;

                                if (CheckScannedOrNot(txtTRLines.Text.Trim()))
                                {
                                    MessageBox.Show("Saved already.");
                                    break;
                                }
                                else
                                {
                                    if (ResvList[i].Scanned)
                                    {
                                        MessageBox.Show("Scanned already.");
                                        break;
                                    }
                                    else
                                    {
                                        ResvLineScanIndex.Add(i.ToString());//Get Index for Reg to Nav
                                        TempResvLines.Add(ResvList[i]);

                                        break;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("This item can be tracked only Pallet No.");
                                break;
                            }
                        }
                        else if (ResvList[i].Lot_For.ToString().ToLower().StartsWith("packing"))
                        {
                            if (ResvList[i].Packing_No == txtTRLines.Text.Trim())
                            {
                                found = true;

                                if (CheckScannedOrNot(txtTRLines.Text.Trim()))
                                {
                                    MessageBox.Show("Scanned already.");
                                    break;
                                }
                                else
                                {
                                    ResvLineScanIndex.Add(i.ToString());//Get Index for Reg to Nav

                                    TempResvLines.Add(ResvList[i]);

                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("This item can be tracked only Packing No.");
                                break;
                            }
                        }
                        else //blank
                        {
                            found = true;

                            if (CheckScannedOrNot(txtTRLines.Text.Trim()))
                            {
                                MessageBox.Show("Scanned already.");
                                break;
                            }
                            else
                            {
                                ResvLineScanIndex.Add(i.ToString());//Get Index for Reg to Nav

                                TempResvLines.Add(ResvList[i]);

                                break;
                            }
                        }
                    }
                }
                if (!found)
                {
                    MessageBox.Show("Scanned value not found.");
                    txtTRLines.SelectAll();
                }
                else
                {
                    for (int ii = 0; ii < TempResvLines.Count; ii++)
                    {
                        object[] array = new object[5];

                        array[0] = TempResvLines[ii].Item_No;
                        array[1] = TempResvLines[ii].Description;
                        array[2] = Math.Abs(TempResvLines[ii].Quantity);
                        array[3] = TempResvLines[ii].Lot_No;
                        array[4] = TempResvLines[ii].Location_Code;

                        dt.Rows.Add(array);
                    }

                    gdScanned.DataSource = null;
                    gdScanned.DataSource = dt;

                    int iR = dt.Rows.Count;

                    gdScanned.TableStyles.Clear();
                    gdScanned.TableStyles.Add(DataGridStyleReqLiness(dt));

                    gdScanned.BackColor = Color.SkyBlue;
                    txtTRLines.Focus();

                }

                txtTRLines.SelectAll();
            }

        }

        private DataGridTableStyle DataGridStyleReqLiness(DataTable dTable)
        {

            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dTable.TableName;

            DataGridColumnStyle s1 = new DataGridTextBoxColumn();
            s1.Width = 120;
            s1.MappingName = "ItemNo";
            s1.HeaderText = "Item No.";
            ts.GridColumnStyles.Add(s1);

            DataGridColumnStyle s2 = new DataGridTextBoxColumn();
            s2.Width = 80;
            s2.MappingName = "Desc";
            s2.HeaderText = "Description";
            ts.GridColumnStyles.Add(s2);

            DataGridColumnStyle s33 = new DataGridTextBoxColumn();
            s33.Width = 60;
            s33.MappingName = "Quantity";
            s33.HeaderText = "Quantity";
            ts.GridColumnStyles.Add(s33);

            DataGridColumnStyle s3 = new DataGridTextBoxColumn();
            s3.Width = 90;
            s3.MappingName = "LotNo";
            s3.HeaderText = "Lot No.";
            ts.GridColumnStyles.Add(s3);

            DataGridColumnStyle s4 = new DataGridTextBoxColumn();
            s4.Width = 100;
            s4.MappingName = "LocCode";
            s4.HeaderText = "Location Code";
            ts.GridColumnStyles.Add(s4);

            return ts;
        }

        private bool CheckScannedOrNot(string ScannedVal)
        {

            foreach (var item in TempResvLines)
            {
                if (item.Lot_No == ScannedVal)
                {
                    return true;
                }
            }
            return false;

        }

        private void menuNewScan_Click(object sender, EventArgs e)
        {
            this.Close();
            frmSOscan frmToShip = new frmSOscan();
            frmToShip.ShowDialog();

        }

        private void mnuItmRegtoNav_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ReservationEntry_Service Resv_service = new ReservationEntry_Service();
            Resv_service.Credentials = nc;

            List<ReservationEntry_Filter> filterArray = new List<ReservationEntry_Filter>();

            ReservationEntry_Filter nameFilter1 = new ReservationEntry_Filter();
            nameFilter1.Field = ReservationEntry_Fields.Source_Type;
            nameFilter1.Criteria = Reservation.SO_sourceType;
            filterArray.Add(nameFilter1);

            ReservationEntry_Filter nameFilter2 = new ReservationEntry_Filter();
            nameFilter2.Field = ReservationEntry_Fields.Source_ID;
            //nameFilter2.Criteria = txtTOScan.Text.Trim();
            nameFilter2.Criteria = SONO.Trim();
            filterArray.Add(nameFilter2);

            ReservationEntry_Filter nameFilter3 = new ReservationEntry_Filter();
            nameFilter3.Field = ReservationEntry_Fields.Source_Subtype;
            nameFilter3.Criteria = Reservation.SO_sourceSubType;
            filterArray.Add(nameFilter3);

            ReservationEntry.ReservationEntry[] listToNav = Resv_service.ReadMultiple(filterArray.ToArray(), null, 0);

            for (int i = 0; i < ResvLineScanIndex.Count; i++)
            {
                int iVal = Convert.ToInt16(ResvLineScanIndex[i]);

                listToNav[iVal].ScannedSpecified = true;
                listToNav[iVal].Scanned = true;
            }

            bool bSuccess = false;

            try
            {
                Resv_service.UpdateMultiple(ref listToNav);
                bSuccess = true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Failed. " + ex.Message);
            }
            if (bSuccess)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Successfully registered.");
                //menuItem3_Click(null, null);
                this.Close();
                frmSOscan newScan = new frmSOscan();
                newScan.ShowDialog();
            }
        }


    }
}