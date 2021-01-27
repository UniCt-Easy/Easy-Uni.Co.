
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


using System;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace registryclass_anagrafica {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Tipologie classificazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registryclass 		=> Tables["registryclass"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaForm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// REGISTRYCLASS /////////////////////////////////
	var tregistryclass= new DataTable("registryclass");
	C= new DataColumn("idregistryclass", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagtitle", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagCF", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagp_iva", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagqualification", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagextmatricula", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagbadgecode", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagmaritalstatus", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagforeigncf", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagmaritalsurname", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagothers", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagtitle_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagcf_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagp_iva_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagqualification_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagextmatricula_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagbadgecode_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagmaritalstatus_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagforeigncf_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagmaritalsurname_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagothers_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	tregistryclass.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	tregistryclass.Columns.Add( new DataColumn("flagresidence", typeof(string)));
	tregistryclass.Columns.Add( new DataColumn("flagresidence_forced", typeof(string)));
	tregistryclass.Columns.Add( new DataColumn("flagfiscalresidence", typeof(string)));
	tregistryclass.Columns.Add( new DataColumn("flagfiscalresidence_forced", typeof(string)));
	tregistryclass.Columns.Add( new DataColumn("flagcfbutton", typeof(string)));
	tregistryclass.Columns.Add( new DataColumn("flaginfofromcfbutton", typeof(string)));
	tregistryclass.Columns.Add( new DataColumn("flaghuman", typeof(string)));
	Tables.Add(tregistryclass);
	tregistryclass.PrimaryKey =  new DataColumn[]{tregistryclass.Columns["idregistryclass"]};


	#endregion

}
}
}
