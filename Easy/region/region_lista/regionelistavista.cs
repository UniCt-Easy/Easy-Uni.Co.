/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
//     Runtime Version: 1.0.3705.209
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace region_lista{//regionelista//
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class vistaForm : DataSet {
        
        private regioneDataTable tableregione;
        
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
                if ((ds.Tables["regione"] != null)) {
                    this.Tables.Add(new regioneDataTable(ds.Tables["regione"]));
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
        public regioneDataTable regione {
            get {
                return this.tableregione;
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
            if ((ds.Tables["regione"] != null)) {
                this.Tables.Add(new regioneDataTable(ds.Tables["regione"]));
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
            this.tableregione = ((regioneDataTable)(this.Tables["regione"]));
            if ((this.tableregione != null)) {
                this.tableregione.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "vistaForm";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/vistaForm.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableregione = new regioneDataTable();
            this.Tables.Add(this.tableregione);
        }
        
        private bool ShouldSerializeregione() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void regioneRowChangeEventHandler(object sender, regioneRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class regioneDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columncodiceregione;
            
            private DataColumn columndescrizione;
            
            private DataColumn columnnoupdate;
            
            private DataColumn columnnodelete;
            
            private DataColumn columncreateuser;
            
            private DataColumn columncreatetimestamp;
            
            private DataColumn columnlastmoduser;
            
            private DataColumn columnlastmodtimestamp;
            
            internal regioneDataTable() : 
                    base("regione") {
                this.InitClass();
            }
            
            internal regioneDataTable(DataTable table) : 
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
            
            internal DataColumn codiceregioneColumn {
                get {
                    return this.columncodiceregione;
                }
            }
            
            internal DataColumn descrizioneColumn {
                get {
                    return this.columndescrizione;
                }
            }
            
            internal DataColumn noupdateColumn {
                get {
                    return this.columnnoupdate;
                }
            }
            
            internal DataColumn nodeleteColumn {
                get {
                    return this.columnnodelete;
                }
            }
            
            internal DataColumn createuserColumn {
                get {
                    return this.columncreateuser;
                }
            }
            
            internal DataColumn createtimestampColumn {
                get {
                    return this.columncreatetimestamp;
                }
            }
            
            internal DataColumn lastmoduserColumn {
                get {
                    return this.columnlastmoduser;
                }
            }
            
            internal DataColumn lastmodtimestampColumn {
                get {
                    return this.columnlastmodtimestamp;
                }
            }
            
            public regioneRow this[int index] {
                get {
                    return ((regioneRow)(this.Rows[index]));
                }
            }
            
            public event regioneRowChangeEventHandler regioneRowChanged;
            
            public event regioneRowChangeEventHandler regioneRowChanging;
            
            public event regioneRowChangeEventHandler regioneRowDeleted;
            
            public event regioneRowChangeEventHandler regioneRowDeleting;
            
            public void AddregioneRow(regioneRow row) {
                this.Rows.Add(row);
            }
            
            public regioneRow AddregioneRow(string codiceregione, string descrizione, short noupdate, short nodelete, string createuser, System.DateTime createtimestamp, string lastmoduser, System.DateTime lastmodtimestamp) {
                regioneRow rowregioneRow = ((regioneRow)(this.NewRow()));
                rowregioneRow.ItemArray = new object[] {
                        codiceregione,
                        descrizione,
                        noupdate,
                        nodelete,
                        createuser,
                        createtimestamp,
                        lastmoduser,
                        lastmodtimestamp};
                this.Rows.Add(rowregioneRow);
                return rowregioneRow;
            }
            
            public regioneRow FindBycodiceregione(string codiceregione) {
                return ((regioneRow)(this.Rows.Find(new object[] {
                            codiceregione})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                regioneDataTable cln = ((regioneDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new regioneDataTable();
            }
            
            internal void InitVars() {
                this.columncodiceregione = this.Columns["codiceregione"];
                this.columndescrizione = this.Columns["descrizione"];
                this.columnnoupdate = this.Columns["noupdate"];
                this.columnnodelete = this.Columns["nodelete"];
                this.columncreateuser = this.Columns["createuser"];
                this.columncreatetimestamp = this.Columns["createtimestamp"];
                this.columnlastmoduser = this.Columns["lastmoduser"];
                this.columnlastmodtimestamp = this.Columns["lastmodtimestamp"];
            }
            
            private void InitClass() {
                this.columncodiceregione = new DataColumn("codiceregione", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columncodiceregione);
                this.columndescrizione = new DataColumn("descrizione", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columndescrizione);
                this.columnnoupdate = new DataColumn("noupdate", typeof(short), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnoupdate);
                this.columnnodelete = new DataColumn("nodelete", typeof(short), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnnodelete);
                this.columncreateuser = new DataColumn("createuser", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columncreateuser);
                this.columncreatetimestamp = new DataColumn("createtimestamp", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columncreatetimestamp);
                this.columnlastmoduser = new DataColumn("lastmoduser", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnlastmoduser);
                this.columnlastmodtimestamp = new DataColumn("lastmodtimestamp", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnlastmodtimestamp);
                this.Constraints.Add(new UniqueConstraint("vistaFormKey1", new DataColumn[] {
                                this.columncodiceregione}, true));
                this.columncodiceregione.AllowDBNull = false;
                this.columncodiceregione.Unique = true;
                this.columndescrizione.AllowDBNull = false;
                this.columncreateuser.AllowDBNull = false;
                this.columncreatetimestamp.AllowDBNull = false;
                this.columnlastmoduser.AllowDBNull = false;
                this.columnlastmodtimestamp.AllowDBNull = false;
            }
            
            public regioneRow NewregioneRow() {
                return ((regioneRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new regioneRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(regioneRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.regioneRowChanged != null)) {
                    this.regioneRowChanged(this, new regioneRowChangeEvent(((regioneRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.regioneRowChanging != null)) {
                    this.regioneRowChanging(this, new regioneRowChangeEvent(((regioneRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.regioneRowDeleted != null)) {
                    this.regioneRowDeleted(this, new regioneRowChangeEvent(((regioneRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.regioneRowDeleting != null)) {
                    this.regioneRowDeleting(this, new regioneRowChangeEvent(((regioneRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveregioneRow(regioneRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class regioneRow : DataRow {
            
            private regioneDataTable tableregione;
            
            internal regioneRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableregione = ((regioneDataTable)(this.Table));
            }
            
            public string codiceregione {
                get {
                    return ((string)(this[this.tableregione.codiceregioneColumn]));
                }
                set {
                    this[this.tableregione.codiceregioneColumn] = value;
                }
            }
            
            public string descrizione {
                get {
                    return ((string)(this[this.tableregione.descrizioneColumn]));
                }
                set {
                    this[this.tableregione.descrizioneColumn] = value;
                }
            }
            
            public short noupdate {
                get {
                    try {
                        return ((short)(this[this.tableregione.noupdateColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableregione.noupdateColumn] = value;
                }
            }
            
            public short nodelete {
                get {
                    try {
                        return ((short)(this[this.tableregione.nodeleteColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableregione.nodeleteColumn] = value;
                }
            }
            
            public string createuser {
                get {
                    return ((string)(this[this.tableregione.createuserColumn]));
                }
                set {
                    this[this.tableregione.createuserColumn] = value;
                }
            }
            
            public System.DateTime createtimestamp {
                get {
                    return ((System.DateTime)(this[this.tableregione.createtimestampColumn]));
                }
                set {
                    this[this.tableregione.createtimestampColumn] = value;
                }
            }
            
            public string lastmoduser {
                get {
                    return ((string)(this[this.tableregione.lastmoduserColumn]));
                }
                set {
                    this[this.tableregione.lastmoduserColumn] = value;
                }
            }
            
            public System.DateTime lastmodtimestamp {
                get {
                    return ((System.DateTime)(this[this.tableregione.lastmodtimestampColumn]));
                }
                set {
                    this[this.tableregione.lastmodtimestampColumn] = value;
                }
            }
            
            public bool IsnoupdateNull() {
                return this.IsNull(this.tableregione.noupdateColumn);
            }
            
            public void SetnoupdateNull() {
                this[this.tableregione.noupdateColumn] = System.Convert.DBNull;
            }
            
            public bool IsnodeleteNull() {
                return this.IsNull(this.tableregione.nodeleteColumn);
            }
            
            public void SetnodeleteNull() {
                this[this.tableregione.nodeleteColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class regioneRowChangeEvent : EventArgs {
            
            private regioneRow eventRow;
            
            private DataRowAction eventAction;
            
            public regioneRowChangeEvent(regioneRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public regioneRow Row {
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
