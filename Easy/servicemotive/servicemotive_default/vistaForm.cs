
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

namespace servicemotive_default{//cdcausaleprestazione//
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class vistaForm : DataSet {
        
        private cdcausaleprestazioneDataTable tablecdcausaleprestazione;
        
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
                if ((ds.Tables["cdcausaleprestazione"] != null)) {
                    this.Tables.Add(new cdcausaleprestazioneDataTable(ds.Tables["cdcausaleprestazione"]));
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
        public cdcausaleprestazioneDataTable cdcausaleprestazione {
            get {
                return this.tablecdcausaleprestazione;
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
            if ((ds.Tables["cdcausaleprestazione"] != null)) {
                this.Tables.Add(new cdcausaleprestazioneDataTable(ds.Tables["cdcausaleprestazione"]));
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
            this.tablecdcausaleprestazione = ((cdcausaleprestazioneDataTable)(this.Tables["cdcausaleprestazione"]));
            if ((this.tablecdcausaleprestazione != null)) {
                this.tablecdcausaleprestazione.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "vistaForm";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/vistaForm.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tablecdcausaleprestazione = new cdcausaleprestazioneDataTable();
            this.Tables.Add(this.tablecdcausaleprestazione);
        }
        
        private bool ShouldSerializecdcausaleprestazione() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void cdcausaleprestazioneRowChangeEventHandler(object sender, cdcausaleprestazioneRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class cdcausaleprestazioneDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnidcausale;
            
            private DataColumn columncodicecausale;
            
            private DataColumn columndescrizione;
            
            private DataColumn columnesercizio;
            
            private DataColumn columnlastmodtimestamp;
            
            private DataColumn columnlastmoduser;
            
            internal cdcausaleprestazioneDataTable() : 
                    base("cdcausaleprestazione") {
                this.InitClass();
            }
            
            internal cdcausaleprestazioneDataTable(DataTable table) : 
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
            
            internal DataColumn idcausaleColumn {
                get {
                    return this.columnidcausale;
                }
            }
            
            internal DataColumn codicecausaleColumn {
                get {
                    return this.columncodicecausale;
                }
            }
            
            internal DataColumn descrizioneColumn {
                get {
                    return this.columndescrizione;
                }
            }
            
            internal DataColumn esercizioColumn {
                get {
                    return this.columnesercizio;
                }
            }
            
            internal DataColumn lastmodtimestampColumn {
                get {
                    return this.columnlastmodtimestamp;
                }
            }
            
            internal DataColumn lastmoduserColumn {
                get {
                    return this.columnlastmoduser;
                }
            }
            
            public cdcausaleprestazioneRow this[int index] {
                get {
                    return ((cdcausaleprestazioneRow)(this.Rows[index]));
                }
            }
            
            public event cdcausaleprestazioneRowChangeEventHandler cdcausaleprestazioneRowChanged;
            
            public event cdcausaleprestazioneRowChangeEventHandler cdcausaleprestazioneRowChanging;
            
            public event cdcausaleprestazioneRowChangeEventHandler cdcausaleprestazioneRowDeleted;
            
            public event cdcausaleprestazioneRowChangeEventHandler cdcausaleprestazioneRowDeleting;
            
            public void AddcdcausaleprestazioneRow(cdcausaleprestazioneRow row) {
                this.Rows.Add(row);
            }
            
            public cdcausaleprestazioneRow AddcdcausaleprestazioneRow(int idcausale, string codicecausale, string descrizione, short esercizio, System.DateTime lastmodtimestamp, string lastmoduser) {
                cdcausaleprestazioneRow rowcdcausaleprestazioneRow = ((cdcausaleprestazioneRow)(this.NewRow()));
                rowcdcausaleprestazioneRow.ItemArray = new object[] {
                        idcausale,
                        codicecausale,
                        descrizione,
                        esercizio,
                        lastmodtimestamp,
                        lastmoduser};
                this.Rows.Add(rowcdcausaleprestazioneRow);
                return rowcdcausaleprestazioneRow;
            }
            
            public cdcausaleprestazioneRow FindByidcausale(int idcausale) {
                return ((cdcausaleprestazioneRow)(this.Rows.Find(new object[] {
                            idcausale})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                cdcausaleprestazioneDataTable cln = ((cdcausaleprestazioneDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new cdcausaleprestazioneDataTable();
            }
            
            internal void InitVars() {
                this.columnidcausale = this.Columns["idcausale"];
                this.columncodicecausale = this.Columns["codicecausale"];
                this.columndescrizione = this.Columns["descrizione"];
                this.columnesercizio = this.Columns["esercizio"];
                this.columnlastmodtimestamp = this.Columns["lastmodtimestamp"];
                this.columnlastmoduser = this.Columns["lastmoduser"];
            }
            
            private void InitClass() {
                this.columnidcausale = new DataColumn("idcausale", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnidcausale);
                this.columncodicecausale = new DataColumn("codicecausale", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columncodicecausale);
                this.columndescrizione = new DataColumn("descrizione", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columndescrizione);
                this.columnesercizio = new DataColumn("esercizio", typeof(short), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnesercizio);
                this.columnlastmodtimestamp = new DataColumn("lastmodtimestamp", typeof(System.DateTime), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnlastmodtimestamp);
                this.columnlastmoduser = new DataColumn("lastmoduser", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnlastmoduser);
                this.Constraints.Add(new UniqueConstraint("vistaFormKey1", new DataColumn[] {
                                this.columnidcausale}, true));
                this.columnidcausale.AllowDBNull = false;
                this.columnidcausale.Unique = true;
                this.columncodicecausale.AllowDBNull = false;
                this.columndescrizione.AllowDBNull = false;
                this.columnesercizio.AllowDBNull = false;
            }
            
            public cdcausaleprestazioneRow NewcdcausaleprestazioneRow() {
                return ((cdcausaleprestazioneRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new cdcausaleprestazioneRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(cdcausaleprestazioneRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.cdcausaleprestazioneRowChanged != null)) {
                    this.cdcausaleprestazioneRowChanged(this, new cdcausaleprestazioneRowChangeEvent(((cdcausaleprestazioneRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.cdcausaleprestazioneRowChanging != null)) {
                    this.cdcausaleprestazioneRowChanging(this, new cdcausaleprestazioneRowChangeEvent(((cdcausaleprestazioneRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.cdcausaleprestazioneRowDeleted != null)) {
                    this.cdcausaleprestazioneRowDeleted(this, new cdcausaleprestazioneRowChangeEvent(((cdcausaleprestazioneRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.cdcausaleprestazioneRowDeleting != null)) {
                    this.cdcausaleprestazioneRowDeleting(this, new cdcausaleprestazioneRowChangeEvent(((cdcausaleprestazioneRow)(e.Row)), e.Action));
                }
            }
            
            public void RemovecdcausaleprestazioneRow(cdcausaleprestazioneRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class cdcausaleprestazioneRow : DataRow {
            
            private cdcausaleprestazioneDataTable tablecdcausaleprestazione;
            
            internal cdcausaleprestazioneRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tablecdcausaleprestazione = ((cdcausaleprestazioneDataTable)(this.Table));
            }
            
            public int idcausale {
                get {
                    return ((int)(this[this.tablecdcausaleprestazione.idcausaleColumn]));
                }
                set {
                    this[this.tablecdcausaleprestazione.idcausaleColumn] = value;
                }
            }
            
            public string codicecausale {
                get {
                    return ((string)(this[this.tablecdcausaleprestazione.codicecausaleColumn]));
                }
                set {
                    this[this.tablecdcausaleprestazione.codicecausaleColumn] = value;
                }
            }
            
            public string descrizione {
                get {
                    return ((string)(this[this.tablecdcausaleprestazione.descrizioneColumn]));
                }
                set {
                    this[this.tablecdcausaleprestazione.descrizioneColumn] = value;
                }
            }
            
            public short esercizio {
                get {
                    return ((short)(this[this.tablecdcausaleprestazione.esercizioColumn]));
                }
                set {
                    this[this.tablecdcausaleprestazione.esercizioColumn] = value;
                }
            }
            
            public System.DateTime lastmodtimestamp {
                get {
                    try {
                        return ((System.DateTime)(this[this.tablecdcausaleprestazione.lastmodtimestampColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tablecdcausaleprestazione.lastmodtimestampColumn] = value;
                }
            }
            
            public string lastmoduser {
                get {
                    try {
                        return ((string)(this[this.tablecdcausaleprestazione.lastmoduserColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tablecdcausaleprestazione.lastmoduserColumn] = value;
                }
            }
            
            public bool IslastmodtimestampNull() {
                return this.IsNull(this.tablecdcausaleprestazione.lastmodtimestampColumn);
            }
            
            public void SetlastmodtimestampNull() {
                this[this.tablecdcausaleprestazione.lastmodtimestampColumn] = System.Convert.DBNull;
            }
            
            public bool IslastmoduserNull() {
                return this.IsNull(this.tablecdcausaleprestazione.lastmoduserColumn);
            }
            
            public void SetlastmoduserNull() {
                this[this.tablecdcausaleprestazione.lastmoduserColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class cdcausaleprestazioneRowChangeEvent : EventArgs {
            
            private cdcausaleprestazioneRow eventRow;
            
            private DataRowAction eventAction;
            
            public cdcausaleprestazioneRowChangeEvent(cdcausaleprestazioneRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public cdcausaleprestazioneRow Row {
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
