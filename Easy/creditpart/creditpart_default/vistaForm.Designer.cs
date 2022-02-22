
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
namespace creditpart_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Assegnazione credito al bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable creditpart 		=> Tables["creditpart"];

	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomephase 		=> Tables["incomephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finview 		=> Tables["finview"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upbunderwritingyearview 		=> Tables["upbunderwritingyearview"];

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
	EnforceConstraints = false;

	#region create DataTables
	DataColumn C;
	//////////////////// CREDITPART /////////////////////////////////
	var tcreditpart= new DataTable("creditpart");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	C= new DataColumn("ncreditpart", typeof(int));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	C= new DataColumn("ycreditpart", typeof(short));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	tcreditpart.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	tcreditpart.Columns.Add( new DataColumn("txt", typeof(string)));
	tcreditpart.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcreditpart.Columns.Add(C);
	tcreditpart.Columns.Add( new DataColumn("idupb", typeof(string)));
	Tables.Add(tcreditpart);
	tcreditpart.PrimaryKey =  new DataColumn[]{tcreditpart.Columns["idinc"], tcreditpart.Columns["ncreditpart"]};


	//////////////////// INCOMEPHASE /////////////////////////////////
	var tincomephase= new DataTable("incomephase");
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	Tables.Add(tincomephase);
	tincomephase.PrimaryKey =  new DataColumn[]{tincomephase.Columns["nphase"]};


	//////////////////// INCOMEVIEW /////////////////////////////////
	var tincomeview= new DataTable("incomeview");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	tincomeview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("finance", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("upb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("registry", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idman", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("manager", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("ypro", typeof(short)));
	tincomeview.Columns.Add( new DataColumn("npro", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("doc", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("available", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("unpartitioned", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("flag", typeof(byte)));
	C= new DataColumn("totflag", typeof(byte));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("flagarrear", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincomeview.Columns.Add( new DataColumn("autocode", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("nbill", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idpro", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	Tables.Add(tincomeview);
	tincomeview.PrimaryKey =  new DataColumn[]{tincomeview.Columns["idinc"]};


	//////////////////// FINVIEW /////////////////////////////////
	var tfinview= new DataTable("finview");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("finpart", typeof(string)));
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("paridfin", typeof(int)));
	tfinview.Columns.Add( new DataColumn("idman", typeof(int)));
	tfinview.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("prevision", typeof(decimal));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("currentprevision", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("availableprevision", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("currentsecondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("availablesecondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("flagusable", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	Tables.Add(tfinview);
	tfinview.PrimaryKey =  new DataColumn[]{tfinview.Columns["idfin"], tfinview.Columns["idupb"]};


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
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// UPBUNDERWRITINGYEARVIEW /////////////////////////////////
	var tupbunderwritingyearview= new DataTable("upbunderwritingyearview");
	C= new DataColumn("idunderwriting", typeof(int));
	C.AllowDBNull=false;
	tupbunderwritingyearview.Columns.Add(C);
	tupbunderwritingyearview.Columns.Add( new DataColumn("codeunderwriting", typeof(string)));
	C= new DataColumn("underwriting", typeof(string));
	C.AllowDBNull=false;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("fin", typeof(string));
	C.AllowDBNull=false;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("finpart", typeof(string));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("initialprevision", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("varprevision", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("actualprevision", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("initialsecondaryprev", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("varsecondaryprev", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("actualsecondaryprev", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("totcreditpart", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("totpreceedspart", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("assessment", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("appropriation", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("proceeds", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("payment", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("incomeprevavailable", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("expenseprevavailable", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("proceedsprevavailable", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("paymentprevavailable", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("creditavailable", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	C= new DataColumn("proceedsavailable", typeof(decimal));
	C.ReadOnly=true;
	tupbunderwritingyearview.Columns.Add(C);
	Tables.Add(tupbunderwritingyearview);
	tupbunderwritingyearview.PrimaryKey =  new DataColumn[]{tupbunderwritingyearview.Columns["idunderwriting"], tupbunderwritingyearview.Columns["idupb"], tupbunderwritingyearview.Columns["idfin"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{incomeview.Columns["idinc"]};
	var cChild = new []{creditpart.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeviewcreditpart",cPar,cChild,false));

	cPar = new []{finview.Columns["idfin"]};
	cChild = new []{creditpart.Columns["idfin"]};
	Relations.Add(new DataRelation("finviewcreditpart",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{creditpart.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_creditpart",cPar,cChild,false));

	#endregion

}
}
}
