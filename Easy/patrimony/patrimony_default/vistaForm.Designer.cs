/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
namespace patrimony_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Stato Patrimoniale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable patrimony 		=> Tables["patrimony"];

	///<summary>
	///Livelli gerarchici Stato Patrimoniale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable patrimonylevel 		=> Tables["patrimonylevel"];

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
	//////////////////// PATRIMONY /////////////////////////////////
	var tpatrimony= new DataTable("patrimony");
	C= new DataColumn("idpatrimony", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("patpart", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("codepatrimony", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("paridpatrimony", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	tpatrimony.Columns.Add( new DataColumn("txt", typeof(string)));
	tpatrimony.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	tpatrimony.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tpatrimony);
	tpatrimony.PrimaryKey =  new DataColumn[]{tpatrimony.Columns["idpatrimony"]};


	//////////////////// PATRIMONYLEVEL /////////////////////////////////
	var tpatrimonylevel= new DataTable("patrimonylevel");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tpatrimonylevel.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	tpatrimonylevel.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpatrimonylevel.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpatrimonylevel.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpatrimonylevel.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpatrimonylevel.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpatrimonylevel.Columns.Add(C);
	Tables.Add(tpatrimonylevel);
	tpatrimonylevel.PrimaryKey =  new DataColumn[]{tpatrimonylevel.Columns["ayear"], tpatrimonylevel.Columns["nlevel"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{patrimonylevel.Columns["nlevel"]};
	var cChild = new []{patrimony.Columns["nlevel"]};
	Relations.Add(new DataRelation("patrimonylevelpatrimony",cPar,cChild,false));

	cPar = new []{patrimony.Columns["idpatrimony"]};
	cChild = new []{patrimony.Columns["paridpatrimony"]};
	Relations.Add(new DataRelation("patrimonypatrimony",cPar,cChild,false));

	#endregion

}
}
}
