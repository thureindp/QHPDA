﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4971
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.4971.
// 
namespace QHMobile.qhStockTakeWS {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="StockTakeWS_Binding", Namespace="urn:microsoft-dynamics-schemas/page/stocktakews")]
    public partial class StockTakeWS_Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public StockTakeWS_Service() {
            this.Url = "http://dpmaster.dptech.local:7045/DynamicsNAVQH/WS/Qian%20Hu/Page/StockTakeWS";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/stocktakews:Read", RequestNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", ResponseElementName="Read_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("StockTakeWS")]
        public StockTakeWS Read(string Stock_take_Code, [System.Xml.Serialization.XmlElementAttribute(DataType="date")] System.DateTime Stock_take_Date, int Line_No) {
            object[] results = this.Invoke("Read", new object[] {
                        Stock_take_Code,
                        Stock_take_Date,
                        Line_No});
            return ((StockTakeWS)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginRead(string Stock_take_Code, System.DateTime Stock_take_Date, int Line_No, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Read", new object[] {
                        Stock_take_Code,
                        Stock_take_Date,
                        Line_No}, callback, asyncState);
        }
        
        /// <remarks/>
        public StockTakeWS EndRead(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((StockTakeWS)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/stocktakews:ReadByRecId", RequestNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", ResponseElementName="ReadByRecId_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("StockTakeWS")]
        public StockTakeWS ReadByRecId(string recId) {
            object[] results = this.Invoke("ReadByRecId", new object[] {
                        recId});
            return ((StockTakeWS)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginReadByRecId(string recId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ReadByRecId", new object[] {
                        recId}, callback, asyncState);
        }
        
        /// <remarks/>
        public StockTakeWS EndReadByRecId(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((StockTakeWS)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/stocktakews:ReadMultiple", RequestNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", ResponseElementName="ReadMultiple_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("ReadMultiple_Result")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public StockTakeWS[] ReadMultiple([System.Xml.Serialization.XmlElementAttribute("filter")] StockTakeWS_Filter[] filter, string bookmarkKey, int setSize) {
            object[] results = this.Invoke("ReadMultiple", new object[] {
                        filter,
                        bookmarkKey,
                        setSize});
            return ((StockTakeWS[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginReadMultiple(StockTakeWS_Filter[] filter, string bookmarkKey, int setSize, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ReadMultiple", new object[] {
                        filter,
                        bookmarkKey,
                        setSize}, callback, asyncState);
        }
        
        /// <remarks/>
        public StockTakeWS[] EndReadMultiple(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((StockTakeWS[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/stocktakews:IsUpdated", RequestNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", ResponseElementName="IsUpdated_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("IsUpdated_Result")]
        public bool IsUpdated(string Key) {
            object[] results = this.Invoke("IsUpdated", new object[] {
                        Key});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginIsUpdated(string Key, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("IsUpdated", new object[] {
                        Key}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndIsUpdated(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/stocktakews:GetRecIdFromKey", RequestNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", ResponseElementName="GetRecIdFromKey_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("GetRecIdFromKey_Result")]
        public string GetRecIdFromKey(string Key) {
            object[] results = this.Invoke("GetRecIdFromKey", new object[] {
                        Key});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetRecIdFromKey(string Key, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetRecIdFromKey", new object[] {
                        Key}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetRecIdFromKey(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/stocktakews:Create", RequestNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", ResponseElementName="Create_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Create(ref StockTakeWS StockTakeWS) {
            object[] results = this.Invoke("Create", new object[] {
                        StockTakeWS});
            StockTakeWS = ((StockTakeWS)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCreate(StockTakeWS StockTakeWS, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Create", new object[] {
                        StockTakeWS}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndCreate(System.IAsyncResult asyncResult, out StockTakeWS StockTakeWS) {
            object[] results = this.EndInvoke(asyncResult);
            StockTakeWS = ((StockTakeWS)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/stocktakews:CreateMultiple", RequestNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", ResponseElementName="CreateMultiple_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void CreateMultiple([System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)] ref StockTakeWS[] StockTakeWS_List) {
            object[] results = this.Invoke("CreateMultiple", new object[] {
                        StockTakeWS_List});
            StockTakeWS_List = ((StockTakeWS[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCreateMultiple(StockTakeWS[] StockTakeWS_List, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CreateMultiple", new object[] {
                        StockTakeWS_List}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndCreateMultiple(System.IAsyncResult asyncResult, out StockTakeWS[] StockTakeWS_List) {
            object[] results = this.EndInvoke(asyncResult);
            StockTakeWS_List = ((StockTakeWS[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/stocktakews:Update", RequestNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", ResponseElementName="Update_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Update(ref StockTakeWS StockTakeWS) {
            object[] results = this.Invoke("Update", new object[] {
                        StockTakeWS});
            StockTakeWS = ((StockTakeWS)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpdate(StockTakeWS StockTakeWS, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Update", new object[] {
                        StockTakeWS}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndUpdate(System.IAsyncResult asyncResult, out StockTakeWS StockTakeWS) {
            object[] results = this.EndInvoke(asyncResult);
            StockTakeWS = ((StockTakeWS)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/stocktakews:UpdateMultiple", RequestNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", ResponseElementName="UpdateMultiple_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void UpdateMultiple([System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)] ref StockTakeWS[] StockTakeWS_List) {
            object[] results = this.Invoke("UpdateMultiple", new object[] {
                        StockTakeWS_List});
            StockTakeWS_List = ((StockTakeWS[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpdateMultiple(StockTakeWS[] StockTakeWS_List, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("UpdateMultiple", new object[] {
                        StockTakeWS_List}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndUpdateMultiple(System.IAsyncResult asyncResult, out StockTakeWS[] StockTakeWS_List) {
            object[] results = this.EndInvoke(asyncResult);
            StockTakeWS_List = ((StockTakeWS[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:microsoft-dynamics-schemas/page/stocktakews:Delete", RequestNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", ResponseElementName="Delete_Result", ResponseNamespace="urn:microsoft-dynamics-schemas/page/stocktakews", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("Delete_Result")]
        public bool Delete(string Key) {
            object[] results = this.Invoke("Delete", new object[] {
                        Key});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginDelete(string Key, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Delete", new object[] {
                        Key}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndDelete(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/stocktakews")]
    public partial class StockTakeWS {
        
        private string keyField;
        
        private int line_NoField;
        
        private bool line_NoFieldSpecified;
        
        private string stock_take_CodeField;
        
        private System.DateTime stock_take_DateField;
        
        private bool stock_take_DateFieldSpecified;
        
        private string location_CodeField;
        
        private string item_NoField;
        
        private decimal stock_take_QuantityField;
        
        private bool stock_take_QuantityFieldSpecified;
        
        private string unit_of_Measure_CodeField;
        
        private string serial_NoField;
        
        private string lot_NoField;
        
        private Status statusField;
        
        private bool statusFieldSpecified;
        
        private System.DateTime entry_DateField;
        
        private bool entry_DateFieldSpecified;
        
        private string entered_ByField;
        
        private string shelfField;
        
        private string messageField;
        
        private System.DateTime registered_DateField;
        
        private bool registered_DateFieldSpecified;
        
        private string registered_ByField;
        
        private string descriptionField;
        
        private string description_2Field;
        
        private string categoryField;
        
        private string variant_CodeField;
        
        private bool skip_Auto_NumberField;
        
        private bool skip_Auto_NumberFieldSpecified;
        
        private string binCodeField;
        
        private string staff_Dimension_CodeField;
        
        /// <remarks/>
        public string Key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        public int Line_No {
            get {
                return this.line_NoField;
            }
            set {
                this.line_NoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Line_NoSpecified {
            get {
                return this.line_NoFieldSpecified;
            }
            set {
                this.line_NoFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Stock_take_Code {
            get {
                return this.stock_take_CodeField;
            }
            set {
                this.stock_take_CodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime Stock_take_Date {
            get {
                return this.stock_take_DateField;
            }
            set {
                this.stock_take_DateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Stock_take_DateSpecified {
            get {
                return this.stock_take_DateFieldSpecified;
            }
            set {
                this.stock_take_DateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Location_Code {
            get {
                return this.location_CodeField;
            }
            set {
                this.location_CodeField = value;
            }
        }
        
        /// <remarks/>
        public string Item_No {
            get {
                return this.item_NoField;
            }
            set {
                this.item_NoField = value;
            }
        }
        
        /// <remarks/>
        public decimal Stock_take_Quantity {
            get {
                return this.stock_take_QuantityField;
            }
            set {
                this.stock_take_QuantityField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Stock_take_QuantitySpecified {
            get {
                return this.stock_take_QuantityFieldSpecified;
            }
            set {
                this.stock_take_QuantityFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Unit_of_Measure_Code {
            get {
                return this.unit_of_Measure_CodeField;
            }
            set {
                this.unit_of_Measure_CodeField = value;
            }
        }
        
        /// <remarks/>
        public string Serial_No {
            get {
                return this.serial_NoField;
            }
            set {
                this.serial_NoField = value;
            }
        }
        
        /// <remarks/>
        public string Lot_No {
            get {
                return this.lot_NoField;
            }
            set {
                this.lot_NoField = value;
            }
        }
        
        /// <remarks/>
        public Status Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool StatusSpecified {
            get {
                return this.statusFieldSpecified;
            }
            set {
                this.statusFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime Entry_Date {
            get {
                return this.entry_DateField;
            }
            set {
                this.entry_DateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Entry_DateSpecified {
            get {
                return this.entry_DateFieldSpecified;
            }
            set {
                this.entry_DateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Entered_By {
            get {
                return this.entered_ByField;
            }
            set {
                this.entered_ByField = value;
            }
        }
        
        /// <remarks/>
        public string Shelf {
            get {
                return this.shelfField;
            }
            set {
                this.shelfField = value;
            }
        }
        
        /// <remarks/>
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime Registered_Date {
            get {
                return this.registered_DateField;
            }
            set {
                this.registered_DateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Registered_DateSpecified {
            get {
                return this.registered_DateFieldSpecified;
            }
            set {
                this.registered_DateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string Registered_By {
            get {
                return this.registered_ByField;
            }
            set {
                this.registered_ByField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public string Description_2 {
            get {
                return this.description_2Field;
            }
            set {
                this.description_2Field = value;
            }
        }
        
        /// <remarks/>
        public string Category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
            }
        }
        
        /// <remarks/>
        public string Variant_Code {
            get {
                return this.variant_CodeField;
            }
            set {
                this.variant_CodeField = value;
            }
        }
        
        /// <remarks/>
        public bool Skip_Auto_Number {
            get {
                return this.skip_Auto_NumberField;
            }
            set {
                this.skip_Auto_NumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool Skip_Auto_NumberSpecified {
            get {
                return this.skip_Auto_NumberFieldSpecified;
            }
            set {
                this.skip_Auto_NumberFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string BinCode {
            get {
                return this.binCodeField;
            }
            set {
                this.binCodeField = value;
            }
        }
        
        /// <remarks/>
        public string Staff_Dimension_Code {
            get {
                return this.staff_Dimension_CodeField;
            }
            set {
                this.staff_Dimension_CodeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/stocktakews")]
    public enum Status {
        
        /// <remarks/>
        _blank_,
        
        /// <remarks/>
        Registered,
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/stocktakews")]
    public partial class StockTakeWS_Filter {
        
        private StockTakeWS_Fields fieldField;
        
        private string criteriaField;
        
        /// <remarks/>
        public StockTakeWS_Fields Field {
            get {
                return this.fieldField;
            }
            set {
                this.fieldField = value;
            }
        }
        
        /// <remarks/>
        public string Criteria {
            get {
                return this.criteriaField;
            }
            set {
                this.criteriaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:microsoft-dynamics-schemas/page/stocktakews")]
    public enum StockTakeWS_Fields {
        
        /// <remarks/>
        Line_No,
        
        /// <remarks/>
        Stock_take_Code,
        
        /// <remarks/>
        Stock_take_Date,
        
        /// <remarks/>
        Location_Code,
        
        /// <remarks/>
        Item_No,
        
        /// <remarks/>
        Stock_take_Quantity,
        
        /// <remarks/>
        Unit_of_Measure_Code,
        
        /// <remarks/>
        Serial_No,
        
        /// <remarks/>
        Lot_No,
        
        /// <remarks/>
        Status,
        
        /// <remarks/>
        Entry_Date,
        
        /// <remarks/>
        Entered_By,
        
        /// <remarks/>
        Shelf,
        
        /// <remarks/>
        Message,
        
        /// <remarks/>
        Registered_Date,
        
        /// <remarks/>
        Registered_By,
        
        /// <remarks/>
        Description,
        
        /// <remarks/>
        Description_2,
        
        /// <remarks/>
        Category,
        
        /// <remarks/>
        Variant_Code,
        
        /// <remarks/>
        Skip_Auto_Number,
        
        /// <remarks/>
        BinCode,
        
        /// <remarks/>
        Staff_Dimension_Code,
    }
}
