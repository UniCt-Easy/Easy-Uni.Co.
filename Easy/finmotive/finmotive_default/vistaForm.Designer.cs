/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace finmotive_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Causali finanziarie (gerarchia)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finmotive 		=> Tables["finmotive"];

	///<summary>
	///Dettaglio causale finanziaria
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finmotivedetail 		=> Tables["finmotivedetail"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finmotivedetailview 		=> Tables["finmotivedetailview"];

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
	//////////////////// FINMOTIVE /////////////////////////////////
	var tfinmotive= new DataTable("finmotive");
	C= new DataColumn("idfinmotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive.Columns.Add(C);
	tfinmotive.Columns.Add( new DataColumn("paridfinmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinmotive.Columns.Add(C);
	tfinmotive.Columns.Add( new DataColumn("cu", typeof(string)));
	tfinmotive.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tfinmotive.Columns.Add( new DataColumn("lu", typeof(string)));
	tfinmotive.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tfinmotive.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tfinmotive);
	tfinmotive.PrimaryKey =  new DataColumn[]{tfinmotive.Columns["idfinmotive"]};


	//////////////////// FINMOTIVEDETAIL /////////////////////////////////
	var tfinmotivedetail= new DataTable("finmotivedetail");
	C= new DataColumn("idfinmotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotivedetail.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinmotivedetail.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinmotivedetail.Columns.Add(C);
	tfinmotivedetail.Columns.Add( new DataColumn("cu", typeof(string)));
	tfinmotivedetail.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tfinmotivedetail.Columns.Add( new DataColumn("lu", typeof(string)));
	tfinmotivedetail.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tfinmotivedetail.Columns.Add( new DataColumn("!codicebilancio", typeof(string)));
	tfinmotivedetail.Columns.Add( new DataColumn("!bilancio", typeof(string)));
	tfinmotivedetail.Columns.Add( new DataColumn("!E/S", typeof(string)));
	Tables.Add(tfinmotivedetail);
	tfinmotivedetail.PrimaryKey =  new DataColumn[]{tfinmotivedetail.Columns["idfinmotive"], tfinmotivedetail.Columns["idfin"], tfinmotivedetail.Columns["ayear"]};


	//////////////////// FIN /////////////////////////////////
	var tfin= new DataTable("fin");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


	//////////////////// FINMOTIVEDETAILVIEW /////////////////////////////////
	var tfinmotivedetailview= new DataTable("finmotivedetailview");
	C= new DataColumn("idfinmotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotivedetailview.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinmotivedetailview.Columns.Add(C);
	tfinmotivedetailview.Columns.Add( new DataColumn("cu", typeof(string)));
	tfinmotivedetailview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tfinmotivedetailview.Columns.Add( new DataColumn("lu", typeof(string)));
	tfinmotivedetailview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	C= new DataColumn("finpart", typeof(string));
	C.ReadOnly=true;
	tfinmotivedetailview.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinmotivedetailview.Columns.Add(C);
	C= new DataColumn("finance", typeof(string));
	C.AllowDBNull=false;
	tfinmotivedetailview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinmotivedetailview.Columns.Add(C);
	Tables.Add(tfinmotivedetailview);
	tfinmotivedetailview.PrimaryKey =  new DataColumn[]{tfinmotivedetailview.Columns["idfinmotive"], tfinmotivedetailview.Columns["idfin"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{finmotive.Columns["idfinmotive"]};
	var cChild = new []{finmotivedetail.Columns["idfinmotive"]};
	Relations.Add(new DataRelation("finmotivefinmotivedetail",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{finmotivedetail.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_finmotivedetail",cPar,cChild,false));

	cPar = new []{finmotive.Columns["idfinmotive"]};
	cChild = new []{finmotive.Columns["paridfinmotive"]};
	Relations.Add(new DataRelation("finmotivefinmotive",cPar,cChild,false));

	#endregion

}
}
}
