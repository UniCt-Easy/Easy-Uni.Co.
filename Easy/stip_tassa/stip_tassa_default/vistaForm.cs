
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
namespace stip_tassa_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///elenco voci prog. esterno segr. studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stip_voce 		=> Tables["stip_voce"];

	///<summary>
	///elenco tasse  prog. esterno gestione studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stip_tassa 		=> Tables["stip_tassa"];

	///<summary>
	///elenco corsi laurea prog. esterno gestione studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stip_corsolaurea 		=> Tables["stip_corsolaurea"];

	///<summary>
	///decodifica vocie e tasse prog. esterno gestione studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stip_decodifica 		=> Tables["stip_decodifica"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

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
	//////////////////// STIP_VOCE /////////////////////////////////
	var tstip_voce= new DataTable("stip_voce");
	C= new DataColumn("idstipvoce", typeof(int));
	C.AllowDBNull=false;
	tstip_voce.Columns.Add(C);
	tstip_voce.Columns.Add( new DataColumn("codicevoce", typeof(string)));
	tstip_voce.Columns.Add( new DataColumn("descrizione", typeof(string)));
	tstip_voce.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_voce.Columns.Add(C);
	tstip_voce.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_voce.Columns.Add(C);
	Tables.Add(tstip_voce);
	tstip_voce.PrimaryKey =  new DataColumn[]{tstip_voce.Columns["idstipvoce"]};


	//////////////////// STIP_TASSA /////////////////////////////////
	var tstip_tassa= new DataTable("stip_tassa");
	C= new DataColumn("idstiptassa", typeof(int));
	C.AllowDBNull=false;
	tstip_tassa.Columns.Add(C);
	tstip_tassa.Columns.Add( new DataColumn("codicetassa", typeof(string)));
	tstip_tassa.Columns.Add( new DataColumn("descrizione", typeof(string)));
	tstip_tassa.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_tassa.Columns.Add(C);
	tstip_tassa.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_tassa.Columns.Add(C);
	Tables.Add(tstip_tassa);
	tstip_tassa.PrimaryKey =  new DataColumn[]{tstip_tassa.Columns["idstiptassa"]};


	//////////////////// STIP_CORSOLAUREA /////////////////////////////////
	var tstip_corsolaurea= new DataTable("stip_corsolaurea");
	C= new DataColumn("idstipcorsolaurea", typeof(int));
	C.AllowDBNull=false;
	tstip_corsolaurea.Columns.Add(C);
	tstip_corsolaurea.Columns.Add( new DataColumn("codicecorsolaurea", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("descrizione", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("idupb", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_corsolaurea.Columns.Add(C);
	tstip_corsolaurea.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_corsolaurea.Columns.Add(C);
	Tables.Add(tstip_corsolaurea);
	tstip_corsolaurea.PrimaryKey =  new DataColumn[]{tstip_corsolaurea.Columns["idstipcorsolaurea"]};


	//////////////////// STIP_DECODIFICA /////////////////////////////////
	var tstip_decodifica= new DataTable("stip_decodifica");
	C= new DataColumn("idstipdecodifica", typeof(int));
	C.AllowDBNull=false;
	tstip_decodifica.Columns.Add(C);
	C= new DataColumn("idstiptassa", typeof(int));
	C.AllowDBNull=false;
	tstip_decodifica.Columns.Add(C);
	C= new DataColumn("idstipvoce", typeof(int));
	C.AllowDBNull=false;
	tstip_decodifica.Columns.Add(C);
	tstip_decodifica.Columns.Add( new DataColumn("idstipcorsolaurea", typeof(int)));
	tstip_decodifica.Columns.Add( new DataColumn("idaccmotiverevenue", typeof(string)));
	tstip_decodifica.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	tstip_decodifica.Columns.Add( new DataColumn("idfinmotive", typeof(string)));
	tstip_decodifica.Columns.Add( new DataColumn("idaccmotiveundotax", typeof(string)));
	tstip_decodifica.Columns.Add( new DataColumn("idaccmotiveundotaxpost", typeof(string)));
	tstip_decodifica.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_decodifica.Columns.Add(C);
	tstip_decodifica.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_decodifica.Columns.Add(C);
	Tables.Add(tstip_decodifica);
	tstip_decodifica.PrimaryKey =  new DataColumn[]{tstip_decodifica.Columns["idstipdecodifica"]};


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("active", typeof(string)));
	tupb.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("granted", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tupb.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tupb.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	tupb.Columns.Add( new DataColumn("newcodeupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tupb.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("idepupbkind", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{stip_tassa.Columns["idstiptassa"]};
	var cChild = new []{stip_decodifica.Columns["idstiptassa"]};
	Relations.Add(new DataRelation("stip_tassa_stip_decodifica",cPar,cChild,false));

	cPar = new []{stip_voce.Columns["idstipvoce"]};
	cChild = new []{stip_decodifica.Columns["idstipvoce"]};
	Relations.Add(new DataRelation("stip_voce_stip_decodifica",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{stip_corsolaurea.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_stip_corsolaurea",cPar,cChild,false));

	#endregion

}
}
}
