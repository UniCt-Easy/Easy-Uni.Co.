
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace banktransactiondetail_default {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class vistaForm : DataSet {
        
        private banktransactiondetailDataTable tablebanktransactiondetail;
        
        public vistaForm() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected vistaForm(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["banktransactiondetail"] != null)) {
                    this.Tables.Add(new banktransactiondetailDataTable(ds.Tables["banktransactiondetail"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.InitClass();
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public banktransactiondetailDataTable banktransactiondetail {
            get {
                return this.tablebanktransactiondetail;
            }
        }
        
        public override DataSet Clone() {
            vistaForm cln = ((vistaForm)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(XmlReader reader) {
            this.Reset();
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            if ((ds.Tables["banktransactiondetail"] != null)) {
                this.Tables.Add(new banktransactiondetailDataTable(ds.Tables["banktransactiondetail"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
        }
        
        internal void InitVars() {
            this.tablebanktransactiondetail = ((banktransactiondetailDataTable)(this.Tables["banktransactiondetail"]));
            if ((this.tablebanktransactiondetail != null)) {
                this.tablebanktransactiondetail.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "vistaForm";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/dettmovimentobancariovista.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tablebanktransactiondetail = new banktransactiondetailDataTable();
            this.Tables.Add(this.tablebanktransactiondetail);
        }
        
        private bool ShouldSerializebanktransactiondetail() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void banktransactiondetailRowChangeEventHandler(object sender, banktransactiondetailRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class banktransactiondetailDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnyban;
            
            private DataColumn columnnban;
            
            private DataColumn columnnoperation;
            
            private DataColumn columnbankreference;
            
            private DataColumn columntransactiondate;
            
            private DataColumn columnvaluedate;
            
            private DataColumn columnamount;
            
            private DataColumn columncu;
            
            private DataColumn columnct;
            
            private DataColumn columnlu;
            
            private DataColumn columnlt;
            
            internal banktransactiondetailDataTable() : 
                    base("banktransactiondetail") {
                this.InitClass();
            }
            
            internal banktransactiondetailDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn ybanColumn {
                get {
                    return this.columnyban;
                }
            }
            
            internal DataColumn nbanColumn {
                get {
                    return this.columnnban;
                }
            }
            
            internal DataColumn noperationColumn {
                get {
                    return this.columnnoperation;
                }
            }
            
            internal DataColumn bankreferenceColumn {
                get {
                    return this.columnbankreference;
                }
            }
            
            internal DataColumn transactiondateColumn {
                get {
                    return this.columntransactiondate;
                }
            }
            
            internal DataColumn valuedateColumn {
                get {
                    return this.columnvaluedate;
                }
            }
            
            internal DataColumn amountColumn {
                get {
                    return this.columnamount;
                }
            }
            
            internal DataColumn cuColumn {
                get {
                    return this.columncu;
                }
            }
            
            internal DataColumn ctColumn {
                get {
                    return this.columnct;
                }
            }
            
            internal DataColumn luColumn {
                get {
                    return this.columnlu;
                }
            }
            
            internal DataColumn ltColumn {
                get {
                    return this.columnlt;
                }
            }
            
            public banktransactiondetailRow this[int index] {
                get {
                    return ((banktransactiondetailRow)(this.Rows[index]));
                }
            }
            
            public event banktransactiondetailRowChangeEventHandler banktransactiondetailRowChanged;
            
            public event banktransactiondetailRowChangeEventHandler banktransactiondetailRowChanging;
            
            public event banktransactiondetailRowChangeEventHandler banktransactiondetailRowDeleted;
            
            public event banktransactiondetailRowChangeEventHandler banktransactiondetailRowDeleting;
            
            public void AddbanktransactiondetailRow(banktransactiondetailRow row) {
                this.Rows.Add(row);
            }
            
            public banktransactiondetailRow AddbanktransactiondetailRow(short yban, int nban, int noperation, string bankreference, System.DateTime transactiondate, System.DateTime valuedate, System.Decimal amount, string cu, System.DateTime ct, string lu, System.DateTime lt) {
                banktransactiondetailRow rowbanktransactiondetailRow = ((banktransactiondetailRow)(this.NewRow()));
                rowbanktransactiondetailRow.ItemArray = new object[] {
                        yban,
                        nban,
                        noperation,
                        bankreference,
                        transactiondate,
                        valuedate,
                        amount,
                        cu,
                        ct,
                        lu,
                        lt};
                this.Rows.Add(rowbanktransactiondetailRow);
                return rowbanktransactiondetailRow;
            }
            
            public banktransactiondetailRow FindByybannbannoperation(short yban, int nban, int noperation) {
                return ((banktransactiondetailRow)(this.Rows.Find(new object[] {
                            yban,
                            nban,
                            noperation})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                banktransactiondetailDataTable cln = ((banktransactiondetailDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new banktransactiondetailDataTable();
            }
            
            internal void InitVars() {
                this.columnyban = this.Columns["yban"];
                this.columnnban = this.Columns["nban"];
                this.columnnoperation = this.Columns["noperation"];
                this.columnbankreference = this.Columns["bankreference"];
                this.columntransactiondate = this.Columns["transactiondate"];
                this.columnvaluedate = this.Columns["valuedate"];
                this.columnamount = this.Columns["amount"];
                this.columncu = this.Columns["cu"];
                this.columnct = this.Columns["ct"];
                this.columnlu = this.Columns["lu"];
                this.columnlt = this.Columns["lt"];
            }
            
            private void InitClass() {
                this.columnyban = new DataColumn("yban", typeof(short), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnyban);
                this.columnnban = new DataColumn("nban", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnban);
                this.columnnoperation = new DataColumn("noperation", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnoperation);
                this.columnbankreference = new DataColumn("bankreference", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnbankreference);
                this.columntransactiondate = new DataColumn("transactiondate", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columntransactiondate);
                this.columnvaluedate = new DataColumn("valuedate", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnvaluedate);
                this.columnamount = new DataColumn("amount", typeof(System.Decimal), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnamount);
                this.columncu = new DataColumn("cu", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columncu);
                this.columnct = new DataColumn("ct", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnct);
                this.columnlu = new DataColumn("lu", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnlu);
                this.columnlt = new DataColumn("lt", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnlt);
                this.Constraints.Add(new UniqueConstraint("vistaFormKey1", new DataColumn[] {
                                this.columnyban,
                                this.columnnban,
                                this.columnnoperation}, true));
                this.columnyban.AllowDBNull = false;
                this.columnnban.AllowDBNull = false;
                this.columnnoperation.AllowDBNull = false;
                this.columncu.AllowDBNull = false;
                this.columnct.AllowDBNull = false;
                this.columnlu.AllowDBNull = false;
                this.columnlt.AllowDBNull = false;
            }
            
            public banktransactiondetailRow NewbanktransactiondetailRow() {
                return ((banktransactiondetailRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new banktransactiondetailRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(banktransactiondetailRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.banktransactiondetailRowChanged != null)) {
                    this.banktransactiondetailRowChanged(this, new banktransactiondetailRowChangeEvent(((banktransactiondetailRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.banktransactiondetailRowChanging != null)) {
                    this.banktransactiondetailRowChanging(this, new banktransactiondetailRowChangeEvent(((banktransactiondetailRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.banktransactiondetailRowDeleted != null)) {
                    this.banktransactiondetailRowDeleted(this, new banktransactiondetailRowChangeEvent(((banktransactiondetailRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.banktransactiondetailRowDeleting != null)) {
                    this.banktransactiondetailRowDeleting(this, new banktransactiondetailRowChangeEvent(((banktransactiondetailRow)(e.Row)), e.Action));
                }
            }
            
            public void RemovebanktransactiondetailRow(banktransactiondetailRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class banktransactiondetailRow : DataRow {
            
            private banktransactiondetailDataTable tablebanktransactiondetail;
            
            internal banktransactiondetailRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tablebanktransactiondetail = ((banktransactiondetailDataTable)(this.Table));
            }
            
            public short yban {
                get {
                    return ((short)(this[this.tablebanktransactiondetail.ybanColumn]));
                }
                set {
                    this[this.tablebanktransactiondetail.ybanColumn] = value;
                }
            }
            
            public int nban {
                get {
                    return ((int)(this[this.tablebanktransactiondetail.nbanColumn]));
                }
                set {
                    this[this.tablebanktransactiondetail.nbanColumn] = value;
                }
            }
            
            public int noperation {
                get {
                    return ((int)(this[this.tablebanktransactiondetail.noperationColumn]));
                }
                set {
                    this[this.tablebanktransactiondetail.noperationColumn] = value;
                }
            }
            
            public string bankreference {
                get {
                    try {
                        return ((string)(this[this.tablebanktransactiondetail.bankreferenceColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tablebanktransactiondetail.bankreferenceColumn] = value;
                }
            }
            
            public System.DateTime transactiondate {
                get {
                    try {
                        return ((System.DateTime)(this[this.tablebanktransactiondetail.transactiondateColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tablebanktransactiondetail.transactiondateColumn] = value;
                }
            }
            
            public System.DateTime valuedate {
                get {
                    try {
                        return ((System.DateTime)(this[this.tablebanktransactiondetail.valuedateColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tablebanktransactiondetail.valuedateColumn] = value;
                }
            }
            
            public System.Decimal amount {
                get {
                    try {
                        return ((System.Decimal)(this[this.tablebanktransactiondetail.amountColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tablebanktransactiondetail.amountColumn] = value;
                }
            }
            
            public string cu {
                get {
                    return ((string)(this[this.tablebanktransactiondetail.cuColumn]));
                }
                set {
                    this[this.tablebanktransactiondetail.cuColumn] = value;
                }
            }
            
            public System.DateTime ct {
                get {
                    return ((System.DateTime)(this[this.tablebanktransactiondetail.ctColumn]));
                }
                set {
                    this[this.tablebanktransactiondetail.ctColumn] = value;
                }
            }
            
            public string lu {
                get {
                    return ((string)(this[this.tablebanktransactiondetail.luColumn]));
                }
                set {
                    this[this.tablebanktransactiondetail.luColumn] = value;
                }
            }
            
            public System.DateTime lt {
                get {
                    return ((System.DateTime)(this[this.tablebanktransactiondetail.ltColumn]));
                }
                set {
                    this[this.tablebanktransactiondetail.ltColumn] = value;
                }
            }
            
            public bool IsbankreferenceNull() {
                return this.IsNull(this.tablebanktransactiondetail.bankreferenceColumn);
            }
            
            public void SetbankreferenceNull() {
                this[this.tablebanktransactiondetail.bankreferenceColumn] = System.Convert.DBNull;
            }
            
            public bool IstransactiondateNull() {
                return this.IsNull(this.tablebanktransactiondetail.transactiondateColumn);
            }
            
            public void SettransactiondateNull() {
                this[this.tablebanktransactiondetail.transactiondateColumn] = System.Convert.DBNull;
            }
            
            public bool IsvaluedateNull() {
                return this.IsNull(this.tablebanktransactiondetail.valuedateColumn);
            }
            
            public void SetvaluedateNull() {
                this[this.tablebanktransactiondetail.valuedateColumn] = System.Convert.DBNull;
            }
            
            public bool IsamountNull() {
                return this.IsNull(this.tablebanktransactiondetail.amountColumn);
            }
            
            public void SetamountNull() {
                this[this.tablebanktransactiondetail.amountColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class banktransactiondetailRowChangeEvent : EventArgs {
            
            private banktransactiondetailRow eventRow;
            
            private DataRowAction eventAction;
            
            public banktransactiondetailRowChangeEvent(banktransactiondetailRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public banktransactiondetailRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}
