
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace csa_contract_annulment {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable csa_contract 		=> (MetaTable)Tables["csa_contract"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable csa_contractview 		=> (MetaTable)Tables["csa_contractview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable csa_contractkind 		=> (MetaTable)Tables["csa_contractkind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";

	#region create DataTables
	//////////////////// CSA_CONTRACT /////////////////////////////////
	var tcsa_contract= new MetaTable("csa_contract");
	tcsa_contract.defineColumn("idcsa_contract", typeof(int),false);
	tcsa_contract.defineColumn("ayear", typeof(short),false);
	tcsa_contract.defineColumn("ycontract", typeof(short),false);
	tcsa_contract.defineColumn("ncontract", typeof(int),false);
	tcsa_contract.defineColumn("idcsa_contractkind", typeof(int),false);
	tcsa_contract.defineColumn("description", typeof(string));
	tcsa_contract.defineColumn("title", typeof(string),false);
	tcsa_contract.defineColumn("flagkeepalive", typeof(string),false);
	tcsa_contract.defineColumn("flagrecreate", typeof(string));
	tcsa_contract.defineColumn("idupb", typeof(string));
	tcsa_contract.defineColumn("idacc_main", typeof(string));
	tcsa_contract.defineColumn("idexp_main", typeof(int));
	tcsa_contract.defineColumn("idfin_main", typeof(int));
	tcsa_contract.defineColumn("ct", typeof(DateTime),false);
	tcsa_contract.defineColumn("cu", typeof(string),false);
	tcsa_contract.defineColumn("lt", typeof(DateTime),false);
	tcsa_contract.defineColumn("lu", typeof(string),false);
	tcsa_contract.defineColumn("active", typeof(string));
	tcsa_contract.defineColumn("idsor_siope_main", typeof(int));
	tcsa_contract.defineColumn("idunderwriting", typeof(int));
	tcsa_contract.defineColumn("idepexp_main", typeof(int));
	Tables.Add(tcsa_contract);
	tcsa_contract.defineKey("idcsa_contract", "ayear");

	//////////////////// CSA_CONTRACTVIEW /////////////////////////////////
	var tcsa_contractview= new MetaTable("csa_contractview");
	tcsa_contractview.defineColumn("ayear", typeof(short),false);
	tcsa_contractview.defineColumn("idcsa_contract", typeof(int),false);
	tcsa_contractview.defineColumn("ycontract", typeof(short),false);
	tcsa_contractview.defineColumn("ncontract", typeof(int),false);
	tcsa_contractview.defineColumn("idcsa_contractkind", typeof(int));
	tcsa_contractview.defineColumn("csa_contractkindcode", typeof(string));
	tcsa_contractview.defineColumn("csa_contractkind", typeof(string));
	tcsa_contractview.defineColumn("title", typeof(string),false);
	tcsa_contractview.defineColumn("description", typeof(string));
	tcsa_contractview.defineColumn("idupb", typeof(string));
	tcsa_contractview.defineColumn("codeupb", typeof(string));
	tcsa_contractview.defineColumn("upb", typeof(string));
	tcsa_contractview.defineColumn("idupb_contractkind", typeof(string));
	tcsa_contractview.defineColumn("codeupb_contractkind", typeof(string));
	tcsa_contractview.defineColumn("upb_contractkind", typeof(string));
	tcsa_contractview.defineColumn("idacc_main", typeof(string));
	tcsa_contractview.defineColumn("codeacc_main", typeof(string));
	tcsa_contractview.defineColumn("account_main", typeof(string));
	tcsa_contractview.defineColumn("idfin_main", typeof(int));
	tcsa_contractview.defineColumn("codefin_main", typeof(string));
	tcsa_contractview.defineColumn("fin_main", typeof(string));
	tcsa_contractview.defineColumn("idexp_main", typeof(int));
	tcsa_contractview.defineColumn("nphase_main", typeof(byte));
	tcsa_contractview.defineColumn("phase_main", typeof(string));
	tcsa_contractview.defineColumn("ymov_main", typeof(short));
	tcsa_contractview.defineColumn("nmov_main", typeof(int));
	tcsa_contractview.defineColumn("flagkeepalive", typeof(string),false);
	tcsa_contractview.defineColumn("active", typeof(string));
	tcsa_contractview.defineColumn("cu", typeof(string),false);
	tcsa_contractview.defineColumn("ct", typeof(DateTime),false);
	tcsa_contractview.defineColumn("lu", typeof(string),false);
	tcsa_contractview.defineColumn("lt", typeof(DateTime),false);
	tcsa_contractview.defineColumn("idsor_siope_main", typeof(int));
	tcsa_contractview.defineColumn("sortcode_main", typeof(string));
	tcsa_contractview.defineColumn("sorting_main", typeof(string));
	tcsa_contractview.defineColumn("idunderwriting", typeof(int));
	tcsa_contractview.defineColumn("underwriting", typeof(string));
	tcsa_contractview.defineColumn("idepexp_main", typeof(int));
	Tables.Add(tcsa_contractview);
	tcsa_contractview.defineKey("ayear", "idcsa_contract");

	//////////////////// CSA_CONTRACTKIND /////////////////////////////////
	var tcsa_contractkind= new MetaTable("csa_contractkind");
	tcsa_contractkind.defineColumn("idcsa_contractkind", typeof(int),false);
	tcsa_contractkind.defineColumn("description", typeof(string),false);
	tcsa_contractkind.defineColumn("ct", typeof(DateTime),false);
	tcsa_contractkind.defineColumn("cu", typeof(string),false);
	tcsa_contractkind.defineColumn("lt", typeof(DateTime),false);
	tcsa_contractkind.defineColumn("lu", typeof(string),false);
	tcsa_contractkind.defineColumn("contractkindcode", typeof(string),false);
	tcsa_contractkind.defineColumn("flagcr", typeof(string),false);
	tcsa_contractkind.defineColumn("flagkeepalive", typeof(string));
	tcsa_contractkind.defineColumn("active", typeof(string));
	tcsa_contractkind.defineColumn("idunderwriting", typeof(int));
	Tables.Add(tcsa_contractkind);
	tcsa_contractkind.defineKey("idcsa_contractkind");

	#endregion

}
}
}
