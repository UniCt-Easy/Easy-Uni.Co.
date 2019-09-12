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
namespace flussoincassi_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Incassi comunicatici dal nodo pagamenti o simili
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flussoincassi 		=> Tables["flussoincassi"];

	///<summary>
	///dettaglio flusso incassi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flussoincassidetail 		=> Tables["flussoincassidetail"];

	///<summary>
	///Partita pendente
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bill 		=> Tables["bill"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable billview 		=> Tables["billview"];

	///<summary>
	///Dettaglio flusso crediti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flussocreditidetail 		=> Tables["flussocreditidetail"];

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
	//////////////////// FLUSSOINCASSI /////////////////////////////////
	var tflussoincassi= new DataTable("flussoincassi");
	C= new DataColumn("idflusso", typeof(int));
	C.AllowDBNull=false;
	tflussoincassi.Columns.Add(C);
	tflussoincassi.Columns.Add( new DataColumn("codiceflusso", typeof(string)));
	tflussoincassi.Columns.Add( new DataColumn("trn", typeof(string)));
	tflussoincassi.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tflussoincassi.Columns.Add( new DataColumn("cu", typeof(string)));
	tflussoincassi.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tflussoincassi.Columns.Add( new DataColumn("lu", typeof(string)));
	tflussoincassi.Columns.Add( new DataColumn("ayear", typeof(short)));
	tflussoincassi.Columns.Add( new DataColumn("causale", typeof(string)));
	tflussoincassi.Columns.Add( new DataColumn("dataincasso", typeof(DateTime)));
	tflussoincassi.Columns.Add( new DataColumn("nbill", typeof(int)));
	tflussoincassi.Columns.Add( new DataColumn("importo", typeof(decimal)));
	tflussoincassi.Columns.Add( new DataColumn("to_complete", typeof(string)));
	tflussoincassi.Columns.Add( new DataColumn("elaborato", typeof(string)));
	tflussoincassi.Columns.Add( new DataColumn("active", typeof(string)));
	tflussoincassi.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tflussoincassi.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tflussoincassi.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tflussoincassi.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tflussoincassi.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tflussoincassi);
	tflussoincassi.PrimaryKey =  new DataColumn[]{tflussoincassi.Columns["idflusso"]};


	//////////////////// FLUSSOINCASSIDETAIL /////////////////////////////////
	var tflussoincassidetail= new DataTable("flussoincassidetail");
	C= new DataColumn("idflusso", typeof(int));
	C.AllowDBNull=false;
	tflussoincassidetail.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	tflussoincassidetail.Columns.Add(C);
	tflussoincassidetail.Columns.Add( new DataColumn("iduniqueformcode", typeof(string)));
	tflussoincassidetail.Columns.Add( new DataColumn("iuv", typeof(string)));
	tflussoincassidetail.Columns.Add( new DataColumn("cf", typeof(string)));
	tflussoincassidetail.Columns.Add( new DataColumn("importo", typeof(decimal)));
	tflussoincassidetail.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tflussoincassidetail.Columns.Add( new DataColumn("cu", typeof(string)));
	tflussoincassidetail.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tflussoincassidetail.Columns.Add( new DataColumn("lu", typeof(string)));
	tflussoincassidetail.Columns.Add( new DataColumn("p_iva", typeof(string)));
	Tables.Add(tflussoincassidetail);
	tflussoincassidetail.PrimaryKey =  new DataColumn[]{tflussoincassidetail.Columns["idflusso"], tflussoincassidetail.Columns["iddetail"]};


	//////////////////// BILL /////////////////////////////////
	var tbill= new DataTable("bill");
	C= new DataColumn("ybill", typeof(short));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("billkind", typeof(string));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	tbill.Columns.Add( new DataColumn("registry", typeof(string)));
	tbill.Columns.Add( new DataColumn("covered", typeof(decimal)));
	tbill.Columns.Add( new DataColumn("total", typeof(decimal)));
	tbill.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbill.Columns.Add( new DataColumn("active", typeof(string)));
	tbill.Columns.Add( new DataColumn("motive", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	tbill.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tbill.Columns.Add( new DataColumn("regularizationnote", typeof(string)));
	tbill.Columns.Add( new DataColumn("reduction", typeof(decimal)));
	tbill.Columns.Add( new DataColumn("banknum", typeof(int)));
	tbill.Columns.Add( new DataColumn("idbank", typeof(string)));
	Tables.Add(tbill);
	tbill.PrimaryKey =  new DataColumn[]{tbill.Columns["ybill"], tbill.Columns["nbill"], tbill.Columns["billkind"]};


	//////////////////// BILLVIEW /////////////////////////////////
	var tbillview= new DataTable("billview");
	C= new DataColumn("ybill", typeof(short));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	C= new DataColumn("billkind", typeof(string));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	tbillview.Columns.Add( new DataColumn("active", typeof(string)));
	tbillview.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbillview.Columns.Add( new DataColumn("registry", typeof(string)));
	tbillview.Columns.Add( new DataColumn("motive", typeof(string)));
	tbillview.Columns.Add( new DataColumn("total", typeof(decimal)));
	tbillview.Columns.Add( new DataColumn("reduction", typeof(decimal)));
	C= new DataColumn("covered", typeof(decimal));
	C.ReadOnly=true;
	tbillview.Columns.Add(C);
	C= new DataColumn("regularized", typeof(decimal));
	C.ReadOnly=true;
	tbillview.Columns.Add(C);
	C= new DataColumn("toregularize", typeof(decimal));
	C.ReadOnly=true;
	tbillview.Columns.Add(C);
	tbillview.Columns.Add( new DataColumn("regularizationnote", typeof(string)));
	tbillview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tbillview.Columns.Add( new DataColumn("treasurer", typeof(string)));
	tbillview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tbillview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tbillview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tbillview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tbillview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	Tables.Add(tbillview);
	tbillview.PrimaryKey =  new DataColumn[]{tbillview.Columns["ybill"], tbillview.Columns["nbill"], tbillview.Columns["billkind"]};


	//////////////////// FLUSSOCREDITIDETAIL /////////////////////////////////
	var tflussocreditidetail= new DataTable("flussocreditidetail");
	C= new DataColumn("idflusso", typeof(int));
	C.AllowDBNull=false;
	tflussocreditidetail.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	tflussocreditidetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tflussocreditidetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tflussocreditidetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflussocreditidetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflussocreditidetail.Columns.Add(C);
	tflussocreditidetail.Columns.Add( new DataColumn("importoversamento", typeof(decimal)));
	tflussocreditidetail.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("yestim", typeof(short)));
	tflussocreditidetail.Columns.Add( new DataColumn("nestim", typeof(int)));
	tflussocreditidetail.Columns.Add( new DataColumn("rownum", typeof(int)));
	tflussocreditidetail.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tflussocreditidetail.Columns.Add( new DataColumn("yinv", typeof(short)));
	tflussocreditidetail.Columns.Add( new DataColumn("ninv", typeof(int)));
	tflussocreditidetail.Columns.Add( new DataColumn("invrownum", typeof(int)));
	tflussocreditidetail.Columns.Add( new DataColumn("idfinmotive", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("iduniqueformcode", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("idaccmotiverevenue", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("idaccmotiveundotax", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("idaccmotiveundotaxpost", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("idreg", typeof(int)));
	tflussocreditidetail.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tflussocreditidetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tflussocreditidetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	tflussocreditidetail.Columns.Add( new DataColumn("description", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("nform", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("expirationdate", typeof(DateTime)));
	tflussocreditidetail.Columns.Add( new DataColumn("barcodevalue", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("barcodeimage", typeof(Byte[])));
	tflussocreditidetail.Columns.Add( new DataColumn("qrcodevalue", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("qrcodeimage", typeof(Byte[])));
	tflussocreditidetail.Columns.Add( new DataColumn("cf", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("iuv", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("annulment", typeof(DateTime)));
	tflussocreditidetail.Columns.Add( new DataColumn("flag", typeof(int)));
	tflussocreditidetail.Columns.Add( new DataColumn("idunivoco", typeof(long)));
	tflussocreditidetail.Columns.Add( new DataColumn("codiceavviso", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tflussocreditidetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tflussocreditidetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tflussocreditidetail.Columns.Add( new DataColumn("idivakind", typeof(int)));
	tflussocreditidetail.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tflussocreditidetail.Columns.Add( new DataColumn("number", typeof(decimal)));
	tflussocreditidetail.Columns.Add( new DataColumn("idlist", typeof(int)));
	tflussocreditidetail.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("annotations", typeof(string)));
	tflussocreditidetail.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	Tables.Add(tflussocreditidetail);
	tflussocreditidetail.PrimaryKey =  new DataColumn[]{tflussocreditidetail.Columns["idflusso"], tflussocreditidetail.Columns["iddetail"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{flussoincassi.Columns["idflusso"]};
	var cChild = new []{flussoincassidetail.Columns["idflusso"]};
	Relations.Add(new DataRelation("FK_flussoincassi_flussoincassidetail",cPar,cChild,false));

	cPar = new []{bill.Columns["nbill"], bill.Columns["ybill"]};
	cChild = new []{flussoincassi.Columns["nbill"], flussoincassi.Columns["ayear"]};
	Relations.Add(new DataRelation("FK_bill_flussoincassi",cPar,cChild,false));

	#endregion

}
}
}
