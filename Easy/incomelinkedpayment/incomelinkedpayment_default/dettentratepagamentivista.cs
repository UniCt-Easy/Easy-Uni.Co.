
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

namespace incomelinkedpayment_default {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class vistaForm : DataSet {
        
        private incomelinkedpaymentDataTable tableincomelinkedpayment;
        
        private linkedincomeDataTable tablelinkedincome;
        
        private DataRelation relationlinkedincomeincomelinkedpayment;
        
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
                if ((ds.Tables["incomelinkedpayment"] != null)) {
                    this.Tables.Add(new incomelinkedpaymentDataTable(ds.Tables["incomelinkedpayment"]));
                }
                if ((ds.Tables["linkedincome"] != null)) {
                    this.Tables.Add(new linkedincomeDataTable(ds.Tables["linkedincome"]));
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
        public incomelinkedpaymentDataTable incomelinkedpayment {
            get {
                return this.tableincomelinkedpayment;
            }
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public linkedincomeDataTable linkedincome {
            get {
                return this.tablelinkedincome;
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
            if ((ds.Tables["incomelinkedpayment"] != null)) {
                this.Tables.Add(new incomelinkedpaymentDataTable(ds.Tables["incomelinkedpayment"]));
            }
            if ((ds.Tables["linkedincome"] != null)) {
                this.Tables.Add(new linkedincomeDataTable(ds.Tables["linkedincome"]));
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
            this.tableincomelinkedpayment = ((incomelinkedpaymentDataTable)(this.Tables["incomelinkedpayment"]));
            if ((this.tableincomelinkedpayment != null)) {
                this.tableincomelinkedpayment.InitVars();
            }
            this.tablelinkedincome = ((linkedincomeDataTable)(this.Tables["linkedincome"]));
            if ((this.tablelinkedincome != null)) {
                this.tablelinkedincome.InitVars();
            }
            this.relationlinkedincomeincomelinkedpayment = this.Relations["linkedincomeincomelinkedpayment"];
        }
        
        private void InitClass() {
            this.DataSetName = "vistaForm";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/dettentratepagamentivista.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableincomelinkedpayment = new incomelinkedpaymentDataTable();
            this.Tables.Add(this.tableincomelinkedpayment);
            this.tablelinkedincome = new linkedincomeDataTable();
            this.Tables.Add(this.tablelinkedincome);
            ForeignKeyConstraint fkc;
            fkc = new ForeignKeyConstraint("vistaFormKey2", new DataColumn[] {
                        this.tablelinkedincome.idlinkedincomeColumn}, new DataColumn[] {
                        this.tableincomelinkedpayment.idlinkedincomeColumn});
            this.tableincomelinkedpayment.Constraints.Add(fkc);
            fkc.AcceptRejectRule = System.Data.AcceptRejectRule.None;
            fkc.DeleteRule = System.Data.Rule.Cascade;
            fkc.UpdateRule = System.Data.Rule.Cascade;
            this.relationlinkedincomeincomelinkedpayment = new DataRelation("linkedincomeincomelinkedpayment", new DataColumn[] {
                        this.tablelinkedincome.idlinkedincomeColumn}, new DataColumn[] {
                        this.tableincomelinkedpayment.idlinkedincomeColumn}, false);
            this.Relations.Add(this.relationlinkedincomeincomelinkedpayment);
        }
        
        private bool ShouldSerializeincomelinkedpayment() {
            return false;
        }
        
        private bool ShouldSerializelinkedincome() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void incomelinkedpaymentRowChangeEventHandler(object sender, incomelinkedpaymentRowChangeEvent e);
        
        public delegate void linkedincomeRowChangeEventHandler(object sender, linkedincomeRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class incomelinkedpaymentDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnidexp;
            
            private DataColumn columnidlinkedincome;
            
            private DataColumn columnamount;
            
            private DataColumn columncu;
            
            private DataColumn columnct;
            
            private DataColumn columnlu;
            
            private DataColumn columnlt;
            
            internal incomelinkedpaymentDataTable() : 
                    base("incomelinkedpayment") {
                this.InitClass();
            }
            
            internal incomelinkedpaymentDataTable(DataTable table) : 
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
            
            internal DataColumn idexpColumn {
                get {
                    return this.columnidexp;
                }
            }
            
            internal DataColumn idlinkedincomeColumn {
                get {
                    return this.columnidlinkedincome;
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
            
            public incomelinkedpaymentRow this[int index] {
                get {
                    return ((incomelinkedpaymentRow)(this.Rows[index]));
                }
            }
            
            public event incomelinkedpaymentRowChangeEventHandler incomelinkedpaymentRowChanged;
            
            public event incomelinkedpaymentRowChangeEventHandler incomelinkedpaymentRowChanging;
            
            public event incomelinkedpaymentRowChangeEventHandler incomelinkedpaymentRowDeleted;
            
            public event incomelinkedpaymentRowChangeEventHandler incomelinkedpaymentRowDeleting;
            
            public void AddincomelinkedpaymentRow(incomelinkedpaymentRow row) {
                this.Rows.Add(row);
            }
            
            public incomelinkedpaymentRow AddincomelinkedpaymentRow(string idexp, linkedincomeRow parentlinkedincomeRowBylinkedincomeincomelinkedpayment, System.Decimal amount, string cu, System.DateTime ct, string lu, System.DateTime lt) {
                incomelinkedpaymentRow rowincomelinkedpaymentRow = ((incomelinkedpaymentRow)(this.NewRow()));
                rowincomelinkedpaymentRow.ItemArray = new object[] {
                        idexp,
                        parentlinkedincomeRowBylinkedincomeincomelinkedpayment[0],
                        amount,
                        cu,
                        ct,
                        lu,
                        lt};
                this.Rows.Add(rowincomelinkedpaymentRow);
                return rowincomelinkedpaymentRow;
            }
            
            public incomelinkedpaymentRow FindByidexpidlinkedincome(string idexp, string idlinkedincome) {
                return ((incomelinkedpaymentRow)(this.Rows.Find(new object[] {
                            idexp,
                            idlinkedincome})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                incomelinkedpaymentDataTable cln = ((incomelinkedpaymentDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new incomelinkedpaymentDataTable();
            }
            
            internal void InitVars() {
                this.columnidexp = this.Columns["idexp"];
                this.columnidlinkedincome = this.Columns["idlinkedincome"];
                this.columnamount = this.Columns["amount"];
                this.columncu = this.Columns["cu"];
                this.columnct = this.Columns["ct"];
                this.columnlu = this.Columns["lu"];
                this.columnlt = this.Columns["lt"];
            }
            
            private void InitClass() {
                this.columnidexp = new DataColumn("idexp", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnidexp);
                this.columnidlinkedincome = new DataColumn("idlinkedincome", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnidlinkedincome);
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
                                this.columnidexp,
                                this.columnidlinkedincome}, true));
                this.columnidexp.AllowDBNull = false;
                this.columnidlinkedincome.AllowDBNull = false;
                this.columncu.AllowDBNull = false;
                this.columnct.AllowDBNull = false;
                this.columnlu.AllowDBNull = false;
                this.columnlt.AllowDBNull = false;
            }
            
            public incomelinkedpaymentRow NewincomelinkedpaymentRow() {
                return ((incomelinkedpaymentRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new incomelinkedpaymentRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(incomelinkedpaymentRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.incomelinkedpaymentRowChanged != null)) {
                    this.incomelinkedpaymentRowChanged(this, new incomelinkedpaymentRowChangeEvent(((incomelinkedpaymentRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.incomelinkedpaymentRowChanging != null)) {
                    this.incomelinkedpaymentRowChanging(this, new incomelinkedpaymentRowChangeEvent(((incomelinkedpaymentRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.incomelinkedpaymentRowDeleted != null)) {
                    this.incomelinkedpaymentRowDeleted(this, new incomelinkedpaymentRowChangeEvent(((incomelinkedpaymentRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.incomelinkedpaymentRowDeleting != null)) {
                    this.incomelinkedpaymentRowDeleting(this, new incomelinkedpaymentRowChangeEvent(((incomelinkedpaymentRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveincomelinkedpaymentRow(incomelinkedpaymentRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class incomelinkedpaymentRow : DataRow {
            
            private incomelinkedpaymentDataTable tableincomelinkedpayment;
            
            internal incomelinkedpaymentRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableincomelinkedpayment = ((incomelinkedpaymentDataTable)(this.Table));
            }
            
            public string idexp {
                get {
                    return ((string)(this[this.tableincomelinkedpayment.idexpColumn]));
                }
                set {
                    this[this.tableincomelinkedpayment.idexpColumn] = value;
                }
            }
            
            public string idlinkedincome {
                get {
                    return ((string)(this[this.tableincomelinkedpayment.idlinkedincomeColumn]));
                }
                set {
                    this[this.tableincomelinkedpayment.idlinkedincomeColumn] = value;
                }
            }
            
            public System.Decimal amount {
                get {
                    try {
                        return ((System.Decimal)(this[this.tableincomelinkedpayment.amountColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableincomelinkedpayment.amountColumn] = value;
                }
            }
            
            public string cu {
                get {
                    return ((string)(this[this.tableincomelinkedpayment.cuColumn]));
                }
                set {
                    this[this.tableincomelinkedpayment.cuColumn] = value;
                }
            }
            
            public System.DateTime ct {
                get {
                    return ((System.DateTime)(this[this.tableincomelinkedpayment.ctColumn]));
                }
                set {
                    this[this.tableincomelinkedpayment.ctColumn] = value;
                }
            }
            
            public string lu {
                get {
                    return ((string)(this[this.tableincomelinkedpayment.luColumn]));
                }
                set {
                    this[this.tableincomelinkedpayment.luColumn] = value;
                }
            }
            
            public System.DateTime lt {
                get {
                    return ((System.DateTime)(this[this.tableincomelinkedpayment.ltColumn]));
                }
                set {
                    this[this.tableincomelinkedpayment.ltColumn] = value;
                }
            }
            
            public linkedincomeRow linkedincomeRow {
                get {
                    return ((linkedincomeRow)(this.GetParentRow(this.Table.ParentRelations["linkedincomeincomelinkedpayment"])));
                }
                set {
                    this.SetParentRow(value, this.Table.ParentRelations["linkedincomeincomelinkedpayment"]);
                }
            }
            
            public bool IsamountNull() {
                return this.IsNull(this.tableincomelinkedpayment.amountColumn);
            }
            
            public void SetamountNull() {
                this[this.tableincomelinkedpayment.amountColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class incomelinkedpaymentRowChangeEvent : EventArgs {
            
            private incomelinkedpaymentRow eventRow;
            
            private DataRowAction eventAction;
            
            public incomelinkedpaymentRowChangeEvent(incomelinkedpaymentRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public incomelinkedpaymentRow Row {
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
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class linkedincomeDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnidlinkedincome;
            
            private DataColumn columndescription;
            
            private DataColumn columncu;
            
            private DataColumn columnct;
            
            private DataColumn columnlu;
            
            private DataColumn columnlt;
            
            internal linkedincomeDataTable() : 
                    base("linkedincome") {
                this.InitClass();
            }
            
            internal linkedincomeDataTable(DataTable table) : 
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
            
            internal DataColumn idlinkedincomeColumn {
                get {
                    return this.columnidlinkedincome;
                }
            }
            
            internal DataColumn descriptionColumn {
                get {
                    return this.columndescription;
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
            
            public linkedincomeRow this[int index] {
                get {
                    return ((linkedincomeRow)(this.Rows[index]));
                }
            }
            
            public event linkedincomeRowChangeEventHandler linkedincomeRowChanged;
            
            public event linkedincomeRowChangeEventHandler linkedincomeRowChanging;
            
            public event linkedincomeRowChangeEventHandler linkedincomeRowDeleted;
            
            public event linkedincomeRowChangeEventHandler linkedincomeRowDeleting;
            
            public void AddlinkedincomeRow(linkedincomeRow row) {
                this.Rows.Add(row);
            }
            
            public linkedincomeRow AddlinkedincomeRow(string idlinkedincome, string description, string cu, System.DateTime ct, string lu, System.DateTime lt) {
                linkedincomeRow rowlinkedincomeRow = ((linkedincomeRow)(this.NewRow()));
                rowlinkedincomeRow.ItemArray = new object[] {
                        idlinkedincome,
                        description,
                        cu,
                        ct,
                        lu,
                        lt};
                this.Rows.Add(rowlinkedincomeRow);
                return rowlinkedincomeRow;
            }
            
            public linkedincomeRow FindByidlinkedincome(string idlinkedincome) {
                return ((linkedincomeRow)(this.Rows.Find(new object[] {
                            idlinkedincome})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                linkedincomeDataTable cln = ((linkedincomeDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new linkedincomeDataTable();
            }
            
            internal void InitVars() {
                this.columnidlinkedincome = this.Columns["idlinkedincome"];
                this.columndescription = this.Columns["description"];
                this.columncu = this.Columns["cu"];
                this.columnct = this.Columns["ct"];
                this.columnlu = this.Columns["lu"];
                this.columnlt = this.Columns["lt"];
            }
            
            private void InitClass() {
                this.columnidlinkedincome = new DataColumn("idlinkedincome", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnidlinkedincome);
                this.columndescription = new DataColumn("description", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columndescription);
                this.columncu = new DataColumn("cu", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columncu);
                this.columnct = new DataColumn("ct", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnct);
                this.columnlu = new DataColumn("lu", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnlu);
                this.columnlt = new DataColumn("lt", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnlt);
                this.Constraints.Add(new UniqueConstraint("vistaFormKey3", new DataColumn[] {
                                this.columnidlinkedincome}, true));
                this.columnidlinkedincome.AllowDBNull = false;
                this.columnidlinkedincome.Unique = true;
                this.columndescription.AllowDBNull = false;
                this.columncu.AllowDBNull = false;
                this.columnct.AllowDBNull = false;
                this.columnlu.AllowDBNull = false;
                this.columnlt.AllowDBNull = false;
            }
            
            public linkedincomeRow NewlinkedincomeRow() {
                return ((linkedincomeRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new linkedincomeRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(linkedincomeRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.linkedincomeRowChanged != null)) {
                    this.linkedincomeRowChanged(this, new linkedincomeRowChangeEvent(((linkedincomeRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.linkedincomeRowChanging != null)) {
                    this.linkedincomeRowChanging(this, new linkedincomeRowChangeEvent(((linkedincomeRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.linkedincomeRowDeleted != null)) {
                    this.linkedincomeRowDeleted(this, new linkedincomeRowChangeEvent(((linkedincomeRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.linkedincomeRowDeleting != null)) {
                    this.linkedincomeRowDeleting(this, new linkedincomeRowChangeEvent(((linkedincomeRow)(e.Row)), e.Action));
                }
            }
            
            public void RemovelinkedincomeRow(linkedincomeRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class linkedincomeRow : DataRow {
            
            private linkedincomeDataTable tablelinkedincome;
            
            internal linkedincomeRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tablelinkedincome = ((linkedincomeDataTable)(this.Table));
            }
            
            public string idlinkedincome {
                get {
                    return ((string)(this[this.tablelinkedincome.idlinkedincomeColumn]));
                }
                set {
                    this[this.tablelinkedincome.idlinkedincomeColumn] = value;
                }
            }
            
            public string description {
                get {
                    return ((string)(this[this.tablelinkedincome.descriptionColumn]));
                }
                set {
                    this[this.tablelinkedincome.descriptionColumn] = value;
                }
            }
            
            public string cu {
                get {
                    return ((string)(this[this.tablelinkedincome.cuColumn]));
                }
                set {
                    this[this.tablelinkedincome.cuColumn] = value;
                }
            }
            
            public System.DateTime ct {
                get {
                    return ((System.DateTime)(this[this.tablelinkedincome.ctColumn]));
                }
                set {
                    this[this.tablelinkedincome.ctColumn] = value;
                }
            }
            
            public string lu {
                get {
                    return ((string)(this[this.tablelinkedincome.luColumn]));
                }
                set {
                    this[this.tablelinkedincome.luColumn] = value;
                }
            }
            
            public System.DateTime lt {
                get {
                    return ((System.DateTime)(this[this.tablelinkedincome.ltColumn]));
                }
                set {
                    this[this.tablelinkedincome.ltColumn] = value;
                }
            }
            
            public incomelinkedpaymentRow[] GetincomelinkedpaymentRows() {
                return ((incomelinkedpaymentRow[])(this.GetChildRows(this.Table.ChildRelations["linkedincomeincomelinkedpayment"])));
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class linkedincomeRowChangeEvent : EventArgs {
            
            private linkedincomeRow eventRow;
            
            private DataRowAction eventAction;
            
            public linkedincomeRowChangeEvent(linkedincomeRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public linkedincomeRow Row {
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
