
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
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace colname_traduci{//colname_traduci//
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class vistaForm : DataSet {
        
        private tablenameDataTable tabletablename;
        
        private colnameDataTable tablecolname;
        
        private DataRelation relationtablenamecolname;
        
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
                if ((ds.Tables["tablename"] != null)) {
                    this.Tables.Add(new tablenameDataTable(ds.Tables["tablename"]));
                }
                if ((ds.Tables["colname"] != null)) {
                    this.Tables.Add(new colnameDataTable(ds.Tables["colname"]));
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
        public tablenameDataTable tablename {
            get {
                return this.tabletablename;
            }
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public colnameDataTable colname {
            get {
                return this.tablecolname;
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
            if ((ds.Tables["tablename"] != null)) {
                this.Tables.Add(new tablenameDataTable(ds.Tables["tablename"]));
            }
            if ((ds.Tables["colname"] != null)) {
                this.Tables.Add(new colnameDataTable(ds.Tables["colname"]));
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
            this.tabletablename = ((tablenameDataTable)(this.Tables["tablename"]));
            if ((this.tabletablename != null)) {
                this.tabletablename.InitVars();
            }
            this.tablecolname = ((colnameDataTable)(this.Tables["colname"]));
            if ((this.tablecolname != null)) {
                this.tablecolname.InitVars();
            }
            this.relationtablenamecolname = this.Relations["tablenamecolname"];
        }
        
        private void InitClass() {
            this.DataSetName = "vistaForm";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/vistaForm.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tabletablename = new tablenameDataTable();
            this.Tables.Add(this.tabletablename);
            this.tablecolname = new colnameDataTable();
            this.Tables.Add(this.tablecolname);
            ForeignKeyConstraint fkc;
            fkc = new ForeignKeyConstraint("tablenamecolname", new DataColumn[] {
                        this.tabletablename.oldtableColumn}, new DataColumn[] {
                        this.tablecolname.oldtableColumn});
            this.tablecolname.Constraints.Add(fkc);
            fkc.AcceptRejectRule = System.Data.AcceptRejectRule.None;
            fkc.DeleteRule = System.Data.Rule.Cascade;
            fkc.UpdateRule = System.Data.Rule.Cascade;
            this.relationtablenamecolname = new DataRelation("tablenamecolname", new DataColumn[] {
                        this.tabletablename.oldtableColumn}, new DataColumn[] {
                        this.tablecolname.oldtableColumn}, false);
            this.Relations.Add(this.relationtablenamecolname);
        }
        
        private bool ShouldSerializetablename() {
            return false;
        }
        
        private bool ShouldSerializecolname() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void tablenameRowChangeEventHandler(object sender, tablenameRowChangeEvent e);
        
        public delegate void colnameRowChangeEventHandler(object sender, colnameRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class tablenameDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnoldtable;
            
            private DataColumn columnnewtable;
            
            internal tablenameDataTable() : 
                    base("tablename") {
                this.InitClass();
            }
            
            internal tablenameDataTable(DataTable table) : 
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
            
            internal DataColumn oldtableColumn {
                get {
                    return this.columnoldtable;
                }
            }
            
            internal DataColumn newtableColumn {
                get {
                    return this.columnnewtable;
                }
            }
            
            public tablenameRow this[int index] {
                get {
                    return ((tablenameRow)(this.Rows[index]));
                }
            }
            
            public event tablenameRowChangeEventHandler tablenameRowChanged;
            
            public event tablenameRowChangeEventHandler tablenameRowChanging;
            
            public event tablenameRowChangeEventHandler tablenameRowDeleted;
            
            public event tablenameRowChangeEventHandler tablenameRowDeleting;
            
            public void AddtablenameRow(tablenameRow row) {
                this.Rows.Add(row);
            }
            
            public tablenameRow AddtablenameRow(string oldtable, string newtable) {
                tablenameRow rowtablenameRow = ((tablenameRow)(this.NewRow()));
                rowtablenameRow.ItemArray = new object[] {
                        oldtable,
                        newtable};
                this.Rows.Add(rowtablenameRow);
                return rowtablenameRow;
            }
            
            public tablenameRow FindByoldtable(string oldtable) {
                return ((tablenameRow)(this.Rows.Find(new object[] {
                            oldtable})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                tablenameDataTable cln = ((tablenameDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new tablenameDataTable();
            }
            
            internal void InitVars() {
                this.columnoldtable = this.Columns["oldtable"];
                this.columnnewtable = this.Columns["newtable"];
            }
            
            private void InitClass() {
                this.columnoldtable = new DataColumn("oldtable", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnoldtable);
                this.columnnewtable = new DataColumn("newtable", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnewtable);
                this.Constraints.Add(new UniqueConstraint("vistaFormKey1", new DataColumn[] {
                                this.columnoldtable}, true));
                this.columnoldtable.AllowDBNull = false;
                this.columnoldtable.Unique = true;
                this.columnnewtable.AllowDBNull = false;
            }
            
            public tablenameRow NewtablenameRow() {
                return ((tablenameRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new tablenameRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(tablenameRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.tablenameRowChanged != null)) {
                    this.tablenameRowChanged(this, new tablenameRowChangeEvent(((tablenameRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.tablenameRowChanging != null)) {
                    this.tablenameRowChanging(this, new tablenameRowChangeEvent(((tablenameRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.tablenameRowDeleted != null)) {
                    this.tablenameRowDeleted(this, new tablenameRowChangeEvent(((tablenameRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.tablenameRowDeleting != null)) {
                    this.tablenameRowDeleting(this, new tablenameRowChangeEvent(((tablenameRow)(e.Row)), e.Action));
                }
            }
            
            public void RemovetablenameRow(tablenameRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class tablenameRow : DataRow {
            
            private tablenameDataTable tabletablename;
            
            internal tablenameRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tabletablename = ((tablenameDataTable)(this.Table));
            }
            
            public string oldtable {
                get {
                    return ((string)(this[this.tabletablename.oldtableColumn]));
                }
                set {
                    this[this.tabletablename.oldtableColumn] = value;
                }
            }
            
            public string newtable {
                get {
                    return ((string)(this[this.tabletablename.newtableColumn]));
                }
                set {
                    this[this.tabletablename.newtableColumn] = value;
                }
            }
            
            public colnameRow[] GetcolnameRows() {
                return ((colnameRow[])(this.GetChildRows(this.Table.ChildRelations["tablenamecolname"])));
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class tablenameRowChangeEvent : EventArgs {
            
            private tablenameRow eventRow;
            
            private DataRowAction eventAction;
            
            public tablenameRowChangeEvent(tablenameRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public tablenameRow Row {
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
        public class colnameDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnoldtable;
            
            private DataColumn columnoldcol;
            
            private DataColumn columnnewcol;
            
            internal colnameDataTable() : 
                    base("colname") {
                this.InitClass();
            }
            
            internal colnameDataTable(DataTable table) : 
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
            
            internal DataColumn oldtableColumn {
                get {
                    return this.columnoldtable;
                }
            }
            
            internal DataColumn oldcolColumn {
                get {
                    return this.columnoldcol;
                }
            }
            
            internal DataColumn newcolColumn {
                get {
                    return this.columnnewcol;
                }
            }
            
            public colnameRow this[int index] {
                get {
                    return ((colnameRow)(this.Rows[index]));
                }
            }
            
            public event colnameRowChangeEventHandler colnameRowChanged;
            
            public event colnameRowChangeEventHandler colnameRowChanging;
            
            public event colnameRowChangeEventHandler colnameRowDeleted;
            
            public event colnameRowChangeEventHandler colnameRowDeleting;
            
            public void AddcolnameRow(colnameRow row) {
                this.Rows.Add(row);
            }
            
            public colnameRow AddcolnameRow(tablenameRow parenttablenameRowBytablenamecolname, string oldcol, string newcol) {
                colnameRow rowcolnameRow = ((colnameRow)(this.NewRow()));
                rowcolnameRow.ItemArray = new object[] {
                        parenttablenameRowBytablenamecolname[0],
                        oldcol,
                        newcol};
                this.Rows.Add(rowcolnameRow);
                return rowcolnameRow;
            }
            
            public colnameRow FindByoldtableoldcol(string oldtable, string oldcol) {
                return ((colnameRow)(this.Rows.Find(new object[] {
                            oldtable,
                            oldcol})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                colnameDataTable cln = ((colnameDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new colnameDataTable();
            }
            
            internal void InitVars() {
                this.columnoldtable = this.Columns["oldtable"];
                this.columnoldcol = this.Columns["oldcol"];
                this.columnnewcol = this.Columns["newcol"];
            }
            
            private void InitClass() {
                this.columnoldtable = new DataColumn("oldtable", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnoldtable);
                this.columnoldcol = new DataColumn("oldcol", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnoldcol);
                this.columnnewcol = new DataColumn("newcol", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnewcol);
                this.Constraints.Add(new UniqueConstraint("vistaFormKey2", new DataColumn[] {
                                this.columnoldtable,
                                this.columnoldcol}, true));
                this.columnoldtable.AllowDBNull = false;
                this.columnoldcol.AllowDBNull = false;
                this.columnnewcol.AllowDBNull = false;
            }
            
            public colnameRow NewcolnameRow() {
                return ((colnameRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new colnameRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(colnameRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.colnameRowChanged != null)) {
                    this.colnameRowChanged(this, new colnameRowChangeEvent(((colnameRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.colnameRowChanging != null)) {
                    this.colnameRowChanging(this, new colnameRowChangeEvent(((colnameRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.colnameRowDeleted != null)) {
                    this.colnameRowDeleted(this, new colnameRowChangeEvent(((colnameRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.colnameRowDeleting != null)) {
                    this.colnameRowDeleting(this, new colnameRowChangeEvent(((colnameRow)(e.Row)), e.Action));
                }
            }
            
            public void RemovecolnameRow(colnameRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class colnameRow : DataRow {
            
            private colnameDataTable tablecolname;
            
            internal colnameRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tablecolname = ((colnameDataTable)(this.Table));
            }
            
            public string oldtable {
                get {
                    return ((string)(this[this.tablecolname.oldtableColumn]));
                }
                set {
                    this[this.tablecolname.oldtableColumn] = value;
                }
            }
            
            public string oldcol {
                get {
                    return ((string)(this[this.tablecolname.oldcolColumn]));
                }
                set {
                    this[this.tablecolname.oldcolColumn] = value;
                }
            }
            
            public string newcol {
                get {
                    return ((string)(this[this.tablecolname.newcolColumn]));
                }
                set {
                    this[this.tablecolname.newcolColumn] = value;
                }
            }
            
            public tablenameRow tablenameRow {
                get {
                    return ((tablenameRow)(this.GetParentRow(this.Table.ParentRelations["tablenamecolname"])));
                }
                set {
                    this.SetParentRow(value, this.Table.ParentRelations["tablenamecolname"]);
                }
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class colnameRowChangeEvent : EventArgs {
            
            private colnameRow eventRow;
            
            private DataRowAction eventAction;
            
            public colnameRowChangeEvent(colnameRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public colnameRow Row {
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
