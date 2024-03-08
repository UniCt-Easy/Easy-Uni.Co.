
/*
Easy
Copyright (C) 2024 Universit‡ degli Studi di Catania (www.unict.it)
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
namespace itinerationrefund_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Valuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable currency 		=> Tables["currency"];

	///<summary>
	///Spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationrefund 		=> Tables["itinerationrefund"];

	///<summary>
	///Rimborso Spese
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationrefundkind 		=> Tables["itinerationrefundkind"];

	///<summary>
	///Localit√† Estere
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable foreigncountry 		=> Tables["foreigncountry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationrefundattachment 		=> Tables["itinerationrefundattachment"];

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
	//////////////////// CURRENCY /////////////////////////////////
	var tcurrency= new DataTable("currency");
	C= new DataColumn("idcurrency", typeof(int));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("codecurrency", typeof(string));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	tcurrency.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tcurrency);
	tcurrency.PrimaryKey =  new DataColumn[]{tcurrency.Columns["idcurrency"]};


	//////////////////// ITINERATIONREFUND /////////////////////////////////
	var titinerationrefund= new DataTable("itinerationrefund");
	C= new DataColumn("nrefund", typeof(short));
	C.AllowDBNull=false;
	titinerationrefund.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefund.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefund.Columns.Add(C);
	titinerationrefund.Columns.Add( new DataColumn("description", typeof(string)));
	titinerationrefund.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefund.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefund.Columns.Add(C);
	titinerationrefund.Columns.Add( new DataColumn("extraallowance", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("advancepercentage", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("starttime", typeof(DateTime)));
	titinerationrefund.Columns.Add( new DataColumn("stoptime", typeof(DateTime)));
	titinerationrefund.Columns.Add( new DataColumn("flag_geo", typeof(string)));
	titinerationrefund.Columns.Add( new DataColumn("amount", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("iditinerationrefundkind", typeof(int)));
	titinerationrefund.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	C= new DataColumn("iditineration", typeof(int));
	C.AllowDBNull=false;
	titinerationrefund.Columns.Add(C);
	titinerationrefund.Columns.Add( new DataColumn("flagitalian", typeof(string)));
	titinerationrefund.Columns.Add( new DataColumn("flagadvancebalance", typeof(string)));
	titinerationrefund.Columns.Add( new DataColumn("doc", typeof(string)));
	titinerationrefund.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	titinerationrefund.Columns.Add( new DataColumn("requiredamount", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("docamount", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("webwarn", typeof(string)));
	titinerationrefund.Columns.Add( new DataColumn("idforeigncountry", typeof(int)));
	titinerationrefund.Columns.Add( new DataColumn("noaccount", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("amount_c", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("docamount_c", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("requiredamount_c", typeof(decimal)));
	Tables.Add(titinerationrefund);
	titinerationrefund.PrimaryKey =  new DataColumn[]{titinerationrefund.Columns["nrefund"], titinerationrefund.Columns["iditineration"]};


	//////////////////// ITINERATIONREFUNDKIND /////////////////////////////////
	var titinerationrefundkind= new DataTable("itinerationrefundkind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	titinerationrefundkind.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	titinerationrefundkind.Columns.Add( new DataColumn("iditinerationrefundkindgroup", typeof(int)));
	C= new DataColumn("codeitinerationrefundkind", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	C= new DataColumn("iditinerationrefundkind", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	titinerationrefundkind.Columns.Add( new DataColumn("active", typeof(string)));
	titinerationrefundkind.Columns.Add( new DataColumn("flagadvance", typeof(string)));
	titinerationrefundkind.Columns.Add( new DataColumn("flagbalance", typeof(string)));
	Tables.Add(titinerationrefundkind);
	titinerationrefundkind.PrimaryKey =  new DataColumn[]{titinerationrefundkind.Columns["iditinerationrefundkind"]};


	//////////////////// FOREIGNCOUNTRY /////////////////////////////////
	var tforeigncountry= new DataTable("foreigncountry");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	tforeigncountry.Columns.Add( new DataColumn("flag_ue", typeof(string)));
	C= new DataColumn("codeforeigncountry", typeof(string));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	C= new DataColumn("idforeigncountry", typeof(int));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	tforeigncountry.Columns.Add( new DataColumn("idmacroarea", typeof(int)));
	Tables.Add(tforeigncountry);
	tforeigncountry.PrimaryKey =  new DataColumn[]{tforeigncountry.Columns["idforeigncountry"]};


	//////////////////// ITINERATIONREFUNDATTACHMENT /////////////////////////////////
	var titinerationrefundattachment= new DataTable("itinerationrefundattachment");
	C= new DataColumn("idattachment", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	C= new DataColumn("iditineration", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	C= new DataColumn("nrefund", typeof(short));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	titinerationrefundattachment.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	titinerationrefundattachment.Columns.Add( new DataColumn("filename", typeof(string)));
	titinerationrefundattachment.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	C= new DataColumn("lt", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	titinerationrefundattachment.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(titinerationrefundattachment);
	titinerationrefundattachment.PrimaryKey =  new DataColumn[]{titinerationrefundattachment.Columns["idattachment"], titinerationrefundattachment.Columns["iditineration"], titinerationrefundattachment.Columns["nrefund"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{foreigncountry.Columns["idforeigncountry"]};
	var cChild = new []{itinerationrefund.Columns["idforeigncountry"]};
	Relations.Add(new DataRelation("FK_foreigncountry_itinerationrefund",cPar,cChild,false));

	cPar = new []{itinerationrefundkind.Columns["iditinerationrefundkind"]};
	cChild = new []{itinerationrefund.Columns["iditinerationrefundkind"]};
	Relations.Add(new DataRelation("itinerationrefundkind_itinerationrefund",cPar,cChild,false));

	cPar = new []{currency.Columns["idcurrency"]};
	cChild = new []{itinerationrefund.Columns["idcurrency"]};
	Relations.Add(new DataRelation("currency_itinerationrefund",cPar,cChild,false));

	cPar = new []{itinerationrefund.Columns["iditineration"], itinerationrefund.Columns["nrefund"]};
	cChild = new []{itinerationrefundattachment.Columns["iditineration"], itinerationrefundattachment.Columns["nrefund"]};
	Relations.Add(new DataRelation("itinerationrefundattachment_itinerationrefund",cPar,cChild,false));

	#endregion

}
}
}
