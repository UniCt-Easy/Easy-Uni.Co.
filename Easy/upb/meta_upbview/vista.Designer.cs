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

using System;
using System.Data;
using System.Collections.Generic;
using metadatalibrary;
namespace meta_upbview {
public class upbviewRow: MetaRow  {
	public upbviewRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public String idupb{ 
		get {if (this["idupb"]==DBNull.Value)return null; return  (String)this["idupb"];}
		set {if (value==null) this["idupb"]= DBNull.Value; else this["idupb"]= value;}
	}
	public object idupbValue { 
		get{ return this["idupb"];}
		set {if (value==null|| value==DBNull.Value) this["idupb"]= DBNull.Value; else this["idupb"]= value;}
	}
	public String idupbOriginal { 
		get {if (this["idupb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idupb",DataRowVersion.Original];}
	}
	public String codeupb{ 
		get {if (this["codeupb"]==DBNull.Value)return null; return  (String)this["codeupb"];}
		set {if (value==null) this["codeupb"]= DBNull.Value; else this["codeupb"]= value;}
	}
	public object codeupbValue { 
		get{ return this["codeupb"];}
		set {if (value==null|| value==DBNull.Value) this["codeupb"]= DBNull.Value; else this["codeupb"]= value;}
	}
	public String codeupbOriginal { 
		get {if (this["codeupb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeupb",DataRowVersion.Original];}
	}
	public String title{ 
		get {if (this["title"]==DBNull.Value)return null; return  (String)this["title"];}
		set {if (value==null) this["title"]= DBNull.Value; else this["title"]= value;}
	}
	public object titleValue { 
		get{ return this["title"];}
		set {if (value==null|| value==DBNull.Value) this["title"]= DBNull.Value; else this["title"]= value;}
	}
	public String titleOriginal { 
		get {if (this["title",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["title",DataRowVersion.Original];}
	}
	public String paridupb{ 
		get {if (this["paridupb"]==DBNull.Value)return null; return  (String)this["paridupb"];}
		set {if (value==null) this["paridupb"]= DBNull.Value; else this["paridupb"]= value;}
	}
	public object paridupbValue { 
		get{ return this["paridupb"];}
		set {if (value==null|| value==DBNull.Value) this["paridupb"]= DBNull.Value; else this["paridupb"]= value;}
	}
	public String paridupbOriginal { 
		get {if (this["paridupb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["paridupb",DataRowVersion.Original];}
	}
	public Int32? idunderwriter{ 
		get {if (this["idunderwriter"]==DBNull.Value)return null; return  (Int32?)this["idunderwriter"];}
		set {if (value==null) this["idunderwriter"]= DBNull.Value; else this["idunderwriter"]= value;}
	}
	public object idunderwriterValue { 
		get{ return this["idunderwriter"];}
		set {if (value==null|| value==DBNull.Value) this["idunderwriter"]= DBNull.Value; else this["idunderwriter"]= value;}
	}
	public Int32? idunderwriterOriginal { 
		get {if (this["idunderwriter",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idunderwriter",DataRowVersion.Original];}
	}
	public Int32? idman{ 
		get {if (this["idman"]==DBNull.Value)return null; return  (Int32?)this["idman"];}
		set {if (value==null) this["idman"]= DBNull.Value; else this["idman"]= value;}
	}
	public object idmanValue { 
		get{ return this["idman"];}
		set {if (value==null|| value==DBNull.Value) this["idman"]= DBNull.Value; else this["idman"]= value;}
	}
	public Int32? idmanOriginal { 
		get {if (this["idman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idman",DataRowVersion.Original];}
	}
	public String manager{ 
		get {if (this["manager"]==DBNull.Value)return null; return  (String)this["manager"];}
		set {if (value==null) this["manager"]= DBNull.Value; else this["manager"]= value;}
	}
	public object managerValue { 
		get{ return this["manager"];}
		set {if (value==null|| value==DBNull.Value) this["manager"]= DBNull.Value; else this["manager"]= value;}
	}
	public String managerOriginal { 
		get {if (this["manager",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["manager",DataRowVersion.Original];}
	}
	public String underwriter{ 
		get {if (this["underwriter"]==DBNull.Value)return null; return  (String)this["underwriter"];}
		set {if (value==null) this["underwriter"]= DBNull.Value; else this["underwriter"]= value;}
	}
	public object underwriterValue { 
		get{ return this["underwriter"];}
		set {if (value==null|| value==DBNull.Value) this["underwriter"]= DBNull.Value; else this["underwriter"]= value;}
	}
	public String underwriterOriginal { 
		get {if (this["underwriter",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["underwriter",DataRowVersion.Original];}
	}
	public String printingorder{ 
		get {if (this["printingorder"]==DBNull.Value)return null; return  (String)this["printingorder"];}
		set {if (value==null) this["printingorder"]= DBNull.Value; else this["printingorder"]= value;}
	}
	public object printingorderValue { 
		get{ return this["printingorder"];}
		set {if (value==null|| value==DBNull.Value) this["printingorder"]= DBNull.Value; else this["printingorder"]= value;}
	}
	public String printingorderOriginal { 
		get {if (this["printingorder",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["printingorder",DataRowVersion.Original];}
	}
	public Decimal? requested{ 
		get {if (this["requested"]==DBNull.Value)return null; return  (Decimal?)this["requested"];}
		set {if (value==null) this["requested"]= DBNull.Value; else this["requested"]= value;}
	}
	public object requestedValue { 
		get{ return this["requested"];}
		set {if (value==null|| value==DBNull.Value) this["requested"]= DBNull.Value; else this["requested"]= value;}
	}
	public Decimal? requestedOriginal { 
		get {if (this["requested",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["requested",DataRowVersion.Original];}
	}
	public Decimal? granted{ 
		get {if (this["granted"]==DBNull.Value)return null; return  (Decimal?)this["granted"];}
		set {if (value==null) this["granted"]= DBNull.Value; else this["granted"]= value;}
	}
	public object grantedValue { 
		get{ return this["granted"];}
		set {if (value==null|| value==DBNull.Value) this["granted"]= DBNull.Value; else this["granted"]= value;}
	}
	public Decimal? grantedOriginal { 
		get {if (this["granted",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["granted",DataRowVersion.Original];}
	}
	public Decimal? previousappropriation{ 
		get {if (this["previousappropriation"]==DBNull.Value)return null; return  (Decimal?)this["previousappropriation"];}
		set {if (value==null) this["previousappropriation"]= DBNull.Value; else this["previousappropriation"]= value;}
	}
	public object previousappropriationValue { 
		get{ return this["previousappropriation"];}
		set {if (value==null|| value==DBNull.Value) this["previousappropriation"]= DBNull.Value; else this["previousappropriation"]= value;}
	}
	public Decimal? previousappropriationOriginal { 
		get {if (this["previousappropriation",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["previousappropriation",DataRowVersion.Original];}
	}
	public Decimal? previousassessment{ 
		get {if (this["previousassessment"]==DBNull.Value)return null; return  (Decimal?)this["previousassessment"];}
		set {if (value==null) this["previousassessment"]= DBNull.Value; else this["previousassessment"]= value;}
	}
	public object previousassessmentValue { 
		get{ return this["previousassessment"];}
		set {if (value==null|| value==DBNull.Value) this["previousassessment"]= DBNull.Value; else this["previousassessment"]= value;}
	}
	public Decimal? previousassessmentOriginal { 
		get {if (this["previousassessment",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["previousassessment",DataRowVersion.Original];}
	}
	public DateTime? expiration{ 
		get {if (this["expiration"]==DBNull.Value)return null; return  (DateTime?)this["expiration"];}
		set {if (value==null) this["expiration"]= DBNull.Value; else this["expiration"]= value;}
	}
	public object expirationValue { 
		get{ return this["expiration"];}
		set {if (value==null|| value==DBNull.Value) this["expiration"]= DBNull.Value; else this["expiration"]= value;}
	}
	public DateTime? expirationOriginal { 
		get {if (this["expiration",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["expiration",DataRowVersion.Original];}
	}
	public String assured{ 
		get {if (this["assured"]==DBNull.Value)return null; return  (String)this["assured"];}
		set {if (value==null) this["assured"]= DBNull.Value; else this["assured"]= value;}
	}
	public object assuredValue { 
		get{ return this["assured"];}
		set {if (value==null|| value==DBNull.Value) this["assured"]= DBNull.Value; else this["assured"]= value;}
	}
	public String assuredOriginal { 
		get {if (this["assured",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["assured",DataRowVersion.Original];}
	}
	public String active{ 
		get {if (this["active"]==DBNull.Value)return null; return  (String)this["active"];}
		set {if (value==null) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public object activeValue { 
		get{ return this["active"];}
		set {if (value==null|| value==DBNull.Value) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public String activeOriginal { 
		get {if (this["active",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["active",DataRowVersion.Original];}
	}
	public String cupcode{ 
		get {if (this["cupcode"]==DBNull.Value)return null; return  (String)this["cupcode"];}
		set {if (value==null) this["cupcode"]= DBNull.Value; else this["cupcode"]= value;}
	}
	public object cupcodeValue { 
		get{ return this["cupcode"];}
		set {if (value==null|| value==DBNull.Value) this["cupcode"]= DBNull.Value; else this["cupcode"]= value;}
	}
	public String cupcodeOriginal { 
		get {if (this["cupcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cupcode",DataRowVersion.Original];}
	}
	public Int32? idsor01{ 
		get {if (this["idsor01"]==DBNull.Value)return null; return  (Int32?)this["idsor01"];}
		set {if (value==null) this["idsor01"]= DBNull.Value; else this["idsor01"]= value;}
	}
	public object idsor01Value { 
		get{ return this["idsor01"];}
		set {if (value==null|| value==DBNull.Value) this["idsor01"]= DBNull.Value; else this["idsor01"]= value;}
	}
	public Int32? idsor01Original { 
		get {if (this["idsor01",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor01",DataRowVersion.Original];}
	}
	public Int32? idsor02{ 
		get {if (this["idsor02"]==DBNull.Value)return null; return  (Int32?)this["idsor02"];}
		set {if (value==null) this["idsor02"]= DBNull.Value; else this["idsor02"]= value;}
	}
	public object idsor02Value { 
		get{ return this["idsor02"];}
		set {if (value==null|| value==DBNull.Value) this["idsor02"]= DBNull.Value; else this["idsor02"]= value;}
	}
	public Int32? idsor02Original { 
		get {if (this["idsor02",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor02",DataRowVersion.Original];}
	}
	public Int32? idsor03{ 
		get {if (this["idsor03"]==DBNull.Value)return null; return  (Int32?)this["idsor03"];}
		set {if (value==null) this["idsor03"]= DBNull.Value; else this["idsor03"]= value;}
	}
	public object idsor03Value { 
		get{ return this["idsor03"];}
		set {if (value==null|| value==DBNull.Value) this["idsor03"]= DBNull.Value; else this["idsor03"]= value;}
	}
	public Int32? idsor03Original { 
		get {if (this["idsor03",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor03",DataRowVersion.Original];}
	}
	public Int32? idsor04{ 
		get {if (this["idsor04"]==DBNull.Value)return null; return  (Int32?)this["idsor04"];}
		set {if (value==null) this["idsor04"]= DBNull.Value; else this["idsor04"]= value;}
	}
	public object idsor04Value { 
		get{ return this["idsor04"];}
		set {if (value==null|| value==DBNull.Value) this["idsor04"]= DBNull.Value; else this["idsor04"]= value;}
	}
	public Int32? idsor04Original { 
		get {if (this["idsor04",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor04",DataRowVersion.Original];}
	}
	public Int32? idsor05{ 
		get {if (this["idsor05"]==DBNull.Value)return null; return  (Int32?)this["idsor05"];}
		set {if (value==null) this["idsor05"]= DBNull.Value; else this["idsor05"]= value;}
	}
	public object idsor05Value { 
		get{ return this["idsor05"];}
		set {if (value==null|| value==DBNull.Value) this["idsor05"]= DBNull.Value; else this["idsor05"]= value;}
	}
	public Int32? idsor05Original { 
		get {if (this["idsor05",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor05",DataRowVersion.Original];}
	}
	public Int16? flagactivity{ 
		get {if (this["flagactivity"]==DBNull.Value)return null; return  (Int16?)this["flagactivity"];}
		set {if (value==null) this["flagactivity"]= DBNull.Value; else this["flagactivity"]= value;}
	}
	public object flagactivityValue { 
		get{ return this["flagactivity"];}
		set {if (value==null|| value==DBNull.Value) this["flagactivity"]= DBNull.Value; else this["flagactivity"]= value;}
	}
	public Int16? flagactivityOriginal { 
		get {if (this["flagactivity",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["flagactivity",DataRowVersion.Original];}
	}
	public Byte? flagkind{ 
		get {if (this["flagkind"]==DBNull.Value)return null; return  (Byte?)this["flagkind"];}
		set {if (value==null) this["flagkind"]= DBNull.Value; else this["flagkind"]= value;}
	}
	public object flagkindValue { 
		get{ return this["flagkind"];}
		set {if (value==null|| value==DBNull.Value) this["flagkind"]= DBNull.Value; else this["flagkind"]= value;}
	}
	public Byte? flagkindOriginal { 
		get {if (this["flagkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["flagkind",DataRowVersion.Original];}
	}
	public String newcodeupb{ 
		get {if (this["newcodeupb"]==DBNull.Value)return null; return  (String)this["newcodeupb"];}
		set {if (value==null) this["newcodeupb"]= DBNull.Value; else this["newcodeupb"]= value;}
	}
	public object newcodeupbValue { 
		get{ return this["newcodeupb"];}
		set {if (value==null|| value==DBNull.Value) this["newcodeupb"]= DBNull.Value; else this["newcodeupb"]= value;}
	}
	public String newcodeupbOriginal { 
		get {if (this["newcodeupb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["newcodeupb",DataRowVersion.Original];}
	}
	public DateTime? start{ 
		get {if (this["start"]==DBNull.Value)return null; return  (DateTime?)this["start"];}
		set {if (value==null) this["start"]= DBNull.Value; else this["start"]= value;}
	}
	public object startValue { 
		get{ return this["start"];}
		set {if (value==null|| value==DBNull.Value) this["start"]= DBNull.Value; else this["start"]= value;}
	}
	public DateTime? startOriginal { 
		get {if (this["start",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["start",DataRowVersion.Original];}
	}
	public DateTime? stop{ 
		get {if (this["stop"]==DBNull.Value)return null; return  (DateTime?)this["stop"];}
		set {if (value==null) this["stop"]= DBNull.Value; else this["stop"]= value;}
	}
	public object stopValue { 
		get{ return this["stop"];}
		set {if (value==null|| value==DBNull.Value) this["stop"]= DBNull.Value; else this["stop"]= value;}
	}
	public DateTime? stopOriginal { 
		get {if (this["stop",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["stop",DataRowVersion.Original];}
	}
	public String cigcode{ 
		get {if (this["cigcode"]==DBNull.Value)return null; return  (String)this["cigcode"];}
		set {if (value==null) this["cigcode"]= DBNull.Value; else this["cigcode"]= value;}
	}
	public object cigcodeValue { 
		get{ return this["cigcode"];}
		set {if (value==null|| value==DBNull.Value) this["cigcode"]= DBNull.Value; else this["cigcode"]= value;}
	}
	public String cigcodeOriginal { 
		get {if (this["cigcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cigcode",DataRowVersion.Original];}
	}
	public Int32? idtreasurer{ 
		get {if (this["idtreasurer"]==DBNull.Value)return null; return  (Int32?)this["idtreasurer"];}
		set {if (value==null) this["idtreasurer"]= DBNull.Value; else this["idtreasurer"]= value;}
	}
	public object idtreasurerValue { 
		get{ return this["idtreasurer"];}
		set {if (value==null|| value==DBNull.Value) this["idtreasurer"]= DBNull.Value; else this["idtreasurer"]= value;}
	}
	public Int32? idtreasurerOriginal { 
		get {if (this["idtreasurer",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idtreasurer",DataRowVersion.Original];}
	}
	public String codetreasurer{ 
		get {if (this["codetreasurer"]==DBNull.Value)return null; return  (String)this["codetreasurer"];}
		set {if (value==null) this["codetreasurer"]= DBNull.Value; else this["codetreasurer"]= value;}
	}
	public object codetreasurerValue { 
		get{ return this["codetreasurer"];}
		set {if (value==null|| value==DBNull.Value) this["codetreasurer"]= DBNull.Value; else this["codetreasurer"]= value;}
	}
	public String codetreasurerOriginal { 
		get {if (this["codetreasurer",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codetreasurer",DataRowVersion.Original];}
	}
	public Int32? idepupbkind{ 
		get {if (this["idepupbkind"]==DBNull.Value)return null; return  (Int32?)this["idepupbkind"];}
		set {if (value==null) this["idepupbkind"]= DBNull.Value; else this["idepupbkind"]= value;}
	}
	public object idepupbkindValue { 
		get{ return this["idepupbkind"];}
		set {if (value==null|| value==DBNull.Value) this["idepupbkind"]= DBNull.Value; else this["idepupbkind"]= value;}
	}
	public Int32? idepupbkindOriginal { 
		get {if (this["idepupbkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idepupbkind",DataRowVersion.Original];}
	}
	public Int32? flag{ 
		get {if (this["flag"]==DBNull.Value)return null; return  (Int32?)this["flag"];}
		set {if (value==null) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {if (value==null|| value==DBNull.Value) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public Int32? flagOriginal { 
		get {if (this["flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["flag",DataRowVersion.Original];}
	}
	public String cu{ 
		get {if (this["cu"]==DBNull.Value)return null; return  (String)this["cu"];}
		set {if (value==null) this["cu"]= DBNull.Value; else this["cu"]= value;}
	}
	public object cuValue { 
		get{ return this["cu"];}
		set {if (value==null|| value==DBNull.Value) this["cu"]= DBNull.Value; else this["cu"]= value;}
	}
	public String cuOriginal { 
		get {if (this["cu",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cu",DataRowVersion.Original];}
	}
	public DateTime? ct{ 
		get {if (this["ct"]==DBNull.Value)return null; return  (DateTime?)this["ct"];}
		set {if (value==null) this["ct"]= DBNull.Value; else this["ct"]= value;}
	}
	public object ctValue { 
		get{ return this["ct"];}
		set {if (value==null|| value==DBNull.Value) this["ct"]= DBNull.Value; else this["ct"]= value;}
	}
	public DateTime? ctOriginal { 
		get {if (this["ct",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["ct",DataRowVersion.Original];}
	}
	public String lu{ 
		get {if (this["lu"]==DBNull.Value)return null; return  (String)this["lu"];}
		set {if (value==null) this["lu"]= DBNull.Value; else this["lu"]= value;}
	}
	public object luValue { 
		get{ return this["lu"];}
		set {if (value==null|| value==DBNull.Value) this["lu"]= DBNull.Value; else this["lu"]= value;}
	}
	public String luOriginal { 
		get {if (this["lu",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lu",DataRowVersion.Original];}
	}
	public DateTime? lt{ 
		get {if (this["lt"]==DBNull.Value)return null; return  (DateTime?)this["lt"];}
		set {if (value==null) this["lt"]= DBNull.Value; else this["lt"]= value;}
	}
	public object ltValue { 
		get{ return this["lt"];}
		set {if (value==null|| value==DBNull.Value) this["lt"]= DBNull.Value; else this["lt"]= value;}
	}
	public DateTime? ltOriginal { 
		get {if (this["lt",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["lt",DataRowVersion.Original];}
	}
	#endregion

}
public class upbviewTable : MetaTableBase<upbviewRow> {
	public upbviewTable() : base("upbview"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("idupb")){ 
			defineColumn("idupb", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("codeupb")){ 
			defineColumn("codeupb", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("title")){ 
			defineColumn("title", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("paridupb")){ 
			defineColumn("paridupb", typeof(System.String));
		}
		if (definedColums.ContainsKey("idunderwriter")){ 
			defineColumn("idunderwriter", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idman")){ 
			defineColumn("idman", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("manager")){ 
			defineColumn("manager", typeof(System.String));
		}
		if (definedColums.ContainsKey("underwriter")){ 
			defineColumn("underwriter", typeof(System.String));
		}
		if (definedColums.ContainsKey("printingorder")){ 
			defineColumn("printingorder", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("requested")){ 
			defineColumn("requested", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("granted")){ 
			defineColumn("granted", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("previousappropriation")){ 
			defineColumn("previousappropriation", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("previousassessment")){ 
			defineColumn("previousassessment", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("expiration")){ 
			defineColumn("expiration", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("assured")){ 
			defineColumn("assured", typeof(System.String));
		}
		if (definedColums.ContainsKey("active")){ 
			defineColumn("active", typeof(System.String));
		}
		if (definedColums.ContainsKey("cupcode")){ 
			defineColumn("cupcode", typeof(System.String));
		}
		if (definedColums.ContainsKey("idsor01")){ 
			defineColumn("idsor01", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor02")){ 
			defineColumn("idsor02", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor03")){ 
			defineColumn("idsor03", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor04")){ 
			defineColumn("idsor04", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor05")){ 
			defineColumn("idsor05", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("flagactivity")){ 
			defineColumn("flagactivity", typeof(System.Int16));
		}
		if (definedColums.ContainsKey("flagkind")){ 
			defineColumn("flagkind", typeof(System.Byte));
		}
		if (definedColums.ContainsKey("newcodeupb")){ 
			defineColumn("newcodeupb", typeof(System.String));
		}
		if (definedColums.ContainsKey("start")){ 
			defineColumn("start", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("stop")){ 
			defineColumn("stop", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("cigcode")){ 
			defineColumn("cigcode", typeof(System.String));
		}
		if (definedColums.ContainsKey("idtreasurer")){ 
			defineColumn("idtreasurer", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("codetreasurer")){ 
			defineColumn("codetreasurer", typeof(System.String));
		}
		if (definedColums.ContainsKey("idepupbkind")){ 
			defineColumn("idepupbkind", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("flag")){ 
			defineColumn("flag", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		#endregion

	}
}
}
