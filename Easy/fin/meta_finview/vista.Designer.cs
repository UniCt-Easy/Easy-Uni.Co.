
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
using System.Collections.Generic;
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_finview {
public class finviewRow: MetaRow  {
	public finviewRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 idfin{ 
		get {return  (Int32)this["idfin"];}
		set {this["idfin"]= value;}
	}
	public object idfinValue { 
		get{ return this["idfin"];}
		set {this["idfin"]= value;}
	}
	public Int32 idfinOriginal { 
		get {return  (Int32)this["idfin",DataRowVersion.Original];}
	}
	public Int16 ayear{ 
		get {return  (Int16)this["ayear"];}
		set {this["ayear"]= value;}
	}
	public object ayearValue { 
		get{ return this["ayear"];}
		set {this["ayear"]= value;}
	}
	public Int16 ayearOriginal { 
		get {return  (Int16)this["ayear",DataRowVersion.Original];}
	}
	public String finpart{ 
		get {if (this["finpart"]==DBNull.Value)return null; return  (String)this["finpart"];}
		set {if (value==null) this["finpart"]= DBNull.Value; else this["finpart"]= value;}
	}
	public object finpartValue { 
		get{ return this["finpart"];}
		set {if (value==null|| value==DBNull.Value) this["finpart"]= DBNull.Value; else this["finpart"]= value;}
	}
	public String finpartOriginal { 
		get {if (this["finpart",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["finpart",DataRowVersion.Original];}
	}
	public String codefin{ 
		get {return  (String)this["codefin"];}
		set {this["codefin"]= value;}
	}
	public object codefinValue { 
		get{ return this["codefin"];}
		set {this["codefin"]= value;}
	}
	public String codefinOriginal { 
		get {return  (String)this["codefin",DataRowVersion.Original];}
	}
	public Byte nlevel{ 
		get {return  (Byte)this["nlevel"];}
		set {this["nlevel"]= value;}
	}
	public object nlevelValue { 
		get{ return this["nlevel"];}
		set {this["nlevel"]= value;}
	}
	public Byte nlevelOriginal { 
		get {return  (Byte)this["nlevel",DataRowVersion.Original];}
	}
	public String leveldescr{ 
		get {return  (String)this["leveldescr"];}
		set {this["leveldescr"]= value;}
	}
	public object leveldescrValue { 
		get{ return this["leveldescr"];}
		set {this["leveldescr"]= value;}
	}
	public String leveldescrOriginal { 
		get {return  (String)this["leveldescr",DataRowVersion.Original];}
	}
	public Int32? paridfin{ 
		get {if (this["paridfin"]==DBNull.Value)return null; return  (Int32?)this["paridfin"];}
		set {if (value==null) this["paridfin"]= DBNull.Value; else this["paridfin"]= value;}
	}
	public object paridfinValue { 
		get{ return this["paridfin"];}
		set {if (value==null|| value==DBNull.Value) this["paridfin"]= DBNull.Value; else this["paridfin"]= value;}
	}
	public Int32? paridfinOriginal { 
		get {if (this["paridfin",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["paridfin",DataRowVersion.Original];}
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
	public String printingorder{ 
		get {return  (String)this["printingorder"];}
		set {this["printingorder"]= value;}
	}
	public object printingorderValue { 
		get{ return this["printingorder"];}
		set {this["printingorder"]= value;}
	}
	public String printingorderOriginal { 
		get {return  (String)this["printingorder",DataRowVersion.Original];}
	}
	public String title{ 
		get {return  (String)this["title"];}
		set {this["title"]= value;}
	}
	public object titleValue { 
		get{ return this["title"];}
		set {this["title"]= value;}
	}
	public String titleOriginal { 
		get {return  (String)this["title",DataRowVersion.Original];}
	}
	public Decimal? prevision{ 
		get {if (this["prevision"]==DBNull.Value)return null; return  (Decimal?)this["prevision"];}
		set {if (value==null) this["prevision"]= DBNull.Value; else this["prevision"]= value;}
	}
	public object previsionValue { 
		get{ return this["prevision"];}
		set {if (value==null|| value==DBNull.Value) this["prevision"]= DBNull.Value; else this["prevision"]= value;}
	}
	public Decimal? previsionOriginal { 
		get {if (this["prevision",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["prevision",DataRowVersion.Original];}
	}
	public Decimal? currentprevision{ 
		get {if (this["currentprevision"]==DBNull.Value)return null; return  (Decimal?)this["currentprevision"];}
		set {if (value==null) this["currentprevision"]= DBNull.Value; else this["currentprevision"]= value;}
	}
	public object currentprevisionValue { 
		get{ return this["currentprevision"];}
		set {if (value==null|| value==DBNull.Value) this["currentprevision"]= DBNull.Value; else this["currentprevision"]= value;}
	}
	public Decimal? currentprevisionOriginal { 
		get {if (this["currentprevision",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["currentprevision",DataRowVersion.Original];}
	}
	public Decimal? availableprevision{ 
		get {if (this["availableprevision"]==DBNull.Value)return null; return  (Decimal?)this["availableprevision"];}
		set {if (value==null) this["availableprevision"]= DBNull.Value; else this["availableprevision"]= value;}
	}
	public object availableprevisionValue { 
		get{ return this["availableprevision"];}
		set {if (value==null|| value==DBNull.Value) this["availableprevision"]= DBNull.Value; else this["availableprevision"]= value;}
	}
	public Decimal? availableprevisionOriginal { 
		get {if (this["availableprevision",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["availableprevision",DataRowVersion.Original];}
	}
	public Decimal? previousprevision{ 
		get {if (this["previousprevision"]==DBNull.Value)return null; return  (Decimal?)this["previousprevision"];}
		set {if (value==null) this["previousprevision"]= DBNull.Value; else this["previousprevision"]= value;}
	}
	public object previousprevisionValue { 
		get{ return this["previousprevision"];}
		set {if (value==null|| value==DBNull.Value) this["previousprevision"]= DBNull.Value; else this["previousprevision"]= value;}
	}
	public Decimal? previousprevisionOriginal { 
		get {if (this["previousprevision",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["previousprevision",DataRowVersion.Original];}
	}
	public Decimal? secondaryprev{ 
		get {if (this["secondaryprev"]==DBNull.Value)return null; return  (Decimal?)this["secondaryprev"];}
		set {if (value==null) this["secondaryprev"]= DBNull.Value; else this["secondaryprev"]= value;}
	}
	public object secondaryprevValue { 
		get{ return this["secondaryprev"];}
		set {if (value==null|| value==DBNull.Value) this["secondaryprev"]= DBNull.Value; else this["secondaryprev"]= value;}
	}
	public Decimal? secondaryprevOriginal { 
		get {if (this["secondaryprev",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["secondaryprev",DataRowVersion.Original];}
	}
	public Decimal? currentsecondaryprev{ 
		get {if (this["currentsecondaryprev"]==DBNull.Value)return null; return  (Decimal?)this["currentsecondaryprev"];}
		set {if (value==null) this["currentsecondaryprev"]= DBNull.Value; else this["currentsecondaryprev"]= value;}
	}
	public object currentsecondaryprevValue { 
		get{ return this["currentsecondaryprev"];}
		set {if (value==null|| value==DBNull.Value) this["currentsecondaryprev"]= DBNull.Value; else this["currentsecondaryprev"]= value;}
	}
	public Decimal? currentsecondaryprevOriginal { 
		get {if (this["currentsecondaryprev",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["currentsecondaryprev",DataRowVersion.Original];}
	}
	public Decimal? availablesecondaryprev{ 
		get {if (this["availablesecondaryprev"]==DBNull.Value)return null; return  (Decimal?)this["availablesecondaryprev"];}
		set {if (value==null) this["availablesecondaryprev"]= DBNull.Value; else this["availablesecondaryprev"]= value;}
	}
	public object availablesecondaryprevValue { 
		get{ return this["availablesecondaryprev"];}
		set {if (value==null|| value==DBNull.Value) this["availablesecondaryprev"]= DBNull.Value; else this["availablesecondaryprev"]= value;}
	}
	public Decimal? availablesecondaryprevOriginal { 
		get {if (this["availablesecondaryprev",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["availablesecondaryprev",DataRowVersion.Original];}
	}
	public Decimal? previoussecondaryprev{ 
		get {if (this["previoussecondaryprev"]==DBNull.Value)return null; return  (Decimal?)this["previoussecondaryprev"];}
		set {if (value==null) this["previoussecondaryprev"]= DBNull.Value; else this["previoussecondaryprev"]= value;}
	}
	public object previoussecondaryprevValue { 
		get{ return this["previoussecondaryprev"];}
		set {if (value==null|| value==DBNull.Value) this["previoussecondaryprev"]= DBNull.Value; else this["previoussecondaryprev"]= value;}
	}
	public Decimal? previoussecondaryprevOriginal { 
		get {if (this["previoussecondaryprev",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["previoussecondaryprev",DataRowVersion.Original];}
	}
	public Decimal? currentarrears{ 
		get {if (this["currentarrears"]==DBNull.Value)return null; return  (Decimal?)this["currentarrears"];}
		set {if (value==null) this["currentarrears"]= DBNull.Value; else this["currentarrears"]= value;}
	}
	public object currentarrearsValue { 
		get{ return this["currentarrears"];}
		set {if (value==null|| value==DBNull.Value) this["currentarrears"]= DBNull.Value; else this["currentarrears"]= value;}
	}
	public Decimal? currentarrearsOriginal { 
		get {if (this["currentarrears",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["currentarrears",DataRowVersion.Original];}
	}
	public Decimal? previousarrears{ 
		get {if (this["previousarrears"]==DBNull.Value)return null; return  (Decimal?)this["previousarrears"];}
		set {if (value==null) this["previousarrears"]= DBNull.Value; else this["previousarrears"]= value;}
	}
	public object previousarrearsValue { 
		get{ return this["previousarrears"];}
		set {if (value==null|| value==DBNull.Value) this["previousarrears"]= DBNull.Value; else this["previousarrears"]= value;}
	}
	public Decimal? previousarrearsOriginal { 
		get {if (this["previousarrears",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["previousarrears",DataRowVersion.Original];}
	}
	public Decimal? prevision2{ 
		get {if (this["prevision2"]==DBNull.Value)return null; return  (Decimal?)this["prevision2"];}
		set {if (value==null) this["prevision2"]= DBNull.Value; else this["prevision2"]= value;}
	}
	public object prevision2Value { 
		get{ return this["prevision2"];}
		set {if (value==null|| value==DBNull.Value) this["prevision2"]= DBNull.Value; else this["prevision2"]= value;}
	}
	public Decimal? prevision2Original { 
		get {if (this["prevision2",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["prevision2",DataRowVersion.Original];}
	}
	public Decimal? prevision3{ 
		get {if (this["prevision3"]==DBNull.Value)return null; return  (Decimal?)this["prevision3"];}
		set {if (value==null) this["prevision3"]= DBNull.Value; else this["prevision3"]= value;}
	}
	public object prevision3Value { 
		get{ return this["prevision3"];}
		set {if (value==null|| value==DBNull.Value) this["prevision3"]= DBNull.Value; else this["prevision3"]= value;}
	}
	public Decimal? prevision3Original { 
		get {if (this["prevision3",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["prevision3",DataRowVersion.Original];}
	}
	public Decimal? prevision4{ 
		get {if (this["prevision4"]==DBNull.Value)return null; return  (Decimal?)this["prevision4"];}
		set {if (value==null) this["prevision4"]= DBNull.Value; else this["prevision4"]= value;}
	}
	public object prevision4Value { 
		get{ return this["prevision4"];}
		set {if (value==null|| value==DBNull.Value) this["prevision4"]= DBNull.Value; else this["prevision4"]= value;}
	}
	public Decimal? prevision4Original { 
		get {if (this["prevision4",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["prevision4",DataRowVersion.Original];}
	}
	public Decimal? prevision5{ 
		get {if (this["prevision5"]==DBNull.Value)return null; return  (Decimal?)this["prevision5"];}
		set {if (value==null) this["prevision5"]= DBNull.Value; else this["prevision5"]= value;}
	}
	public object prevision5Value { 
		get{ return this["prevision5"];}
		set {if (value==null|| value==DBNull.Value) this["prevision5"]= DBNull.Value; else this["prevision5"]= value;}
	}
	public Decimal? prevision5Original { 
		get {if (this["prevision5",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["prevision5",DataRowVersion.Original];}
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
	public Decimal? limit{ 
		get {if (this["limit"]==DBNull.Value)return null; return  (Decimal?)this["limit"];}
		set {if (value==null) this["limit"]= DBNull.Value; else this["limit"]= value;}
	}
	public object limitValue { 
		get{ return this["limit"];}
		set {if (value==null|| value==DBNull.Value) this["limit"]= DBNull.Value; else this["limit"]= value;}
	}
	public Decimal? limitOriginal { 
		get {if (this["limit",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["limit",DataRowVersion.Original];}
	}
	public Byte flag{ 
		get {return  (Byte)this["flag"];}
		set {this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {this["flag"]= value;}
	}
	public Byte flagOriginal { 
		get {return  (Byte)this["flag",DataRowVersion.Original];}
	}
	public String flagusable{ 
		get {if (this["flagusable"]==DBNull.Value)return null; return  (String)this["flagusable"];}
		set {if (value==null) this["flagusable"]= DBNull.Value; else this["flagusable"]= value;}
	}
	public object flagusableValue { 
		get{ return this["flagusable"];}
		set {if (value==null|| value==DBNull.Value) this["flagusable"]= DBNull.Value; else this["flagusable"]= value;}
	}
	public String flagusableOriginal { 
		get {if (this["flagusable",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagusable",DataRowVersion.Original];}
	}
	public String idupb{ 
		get {return  (String)this["idupb"];}
		set {this["idupb"]= value;}
	}
	public object idupbValue { 
		get{ return this["idupb"];}
		set {this["idupb"]= value;}
	}
	public String idupbOriginal { 
		get {return  (String)this["idupb",DataRowVersion.Original];}
	}
	public String codeupb{ 
		get {return  (String)this["codeupb"];}
		set {this["codeupb"]= value;}
	}
	public object codeupbValue { 
		get{ return this["codeupb"];}
		set {this["codeupb"]= value;}
	}
	public String codeupbOriginal { 
		get {return  (String)this["codeupb",DataRowVersion.Original];}
	}
	public String upb{ 
		get {return  (String)this["upb"];}
		set {this["upb"]= value;}
	}
	public object upbValue { 
		get{ return this["upb"];}
		set {this["upb"]= value;}
	}
	public String upbOriginal { 
		get {return  (String)this["upb",DataRowVersion.Original];}
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
	public String cu{ 
		get {return  (String)this["cu"];}
		set {this["cu"]= value;}
	}
	public object cuValue { 
		get{ return this["cu"];}
		set {this["cu"]= value;}
	}
	public String cuOriginal { 
		get {return  (String)this["cu",DataRowVersion.Original];}
	}
	public DateTime ct{ 
		get {return  (DateTime)this["ct"];}
		set {this["ct"]= value;}
	}
	public object ctValue { 
		get{ return this["ct"];}
		set {this["ct"]= value;}
	}
	public DateTime ctOriginal { 
		get {return  (DateTime)this["ct",DataRowVersion.Original];}
	}
	public String lu{ 
		get {return  (String)this["lu"];}
		set {this["lu"]= value;}
	}
	public object luValue { 
		get{ return this["lu"];}
		set {this["lu"]= value;}
	}
	public String luOriginal { 
		get {return  (String)this["lu",DataRowVersion.Original];}
	}
	public DateTime lt{ 
		get {return  (DateTime)this["lt"];}
		set {this["lt"]= value;}
	}
	public object ltValue { 
		get{ return this["lt"];}
		set {this["lt"]= value;}
	}
	public DateTime ltOriginal { 
		get {return  (DateTime)this["lt",DataRowVersion.Original];}
	}
	#endregion

}
public class finviewTable : MetaTableBase<finviewRow> {
	public finviewTable() : base("finview"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idfin",createColumn("idfin",typeof(int),false,false)},
			{"ayear",createColumn("ayear",typeof(short),false,false)},
			{"finpart",createColumn("finpart",typeof(string),true,true)},
			{"codefin",createColumn("codefin",typeof(string),false,false)},
			{"nlevel",createColumn("nlevel",typeof(byte),false,false)},
			{"leveldescr",createColumn("leveldescr",typeof(string),false,false)},
			{"paridfin",createColumn("paridfin",typeof(int),true,false)},
			{"idman",createColumn("idman",typeof(int),true,true)},
			{"manager",createColumn("manager",typeof(string),true,true)},
			{"printingorder",createColumn("printingorder",typeof(string),false,false)},
			{"title",createColumn("title",typeof(string),false,false)},
			{"prevision",createColumn("prevision",typeof(decimal),true,true)},
			{"currentprevision",createColumn("currentprevision",typeof(decimal),true,true)},
			{"availableprevision",createColumn("availableprevision",typeof(decimal),true,true)},
			{"previousprevision",createColumn("previousprevision",typeof(decimal),true,false)},
			{"secondaryprev",createColumn("secondaryprev",typeof(decimal),true,false)},
			{"currentsecondaryprev",createColumn("currentsecondaryprev",typeof(decimal),true,true)},
			{"availablesecondaryprev",createColumn("availablesecondaryprev",typeof(decimal),true,true)},
			{"previoussecondaryprev",createColumn("previoussecondaryprev",typeof(decimal),true,false)},
			{"currentarrears",createColumn("currentarrears",typeof(decimal),true,false)},
			{"previousarrears",createColumn("previousarrears",typeof(decimal),true,false)},
			{"prevision2",createColumn("prevision2",typeof(decimal),true,false)},
			{"prevision3",createColumn("prevision3",typeof(decimal),true,false)},
			{"prevision4",createColumn("prevision4",typeof(decimal),true,false)},
			{"prevision5",createColumn("prevision5",typeof(decimal),true,false)},
			{"expiration",createColumn("expiration",typeof(DateTime),true,false)},
			{"limit",createColumn("limit",typeof(decimal),true,false)},
			{"flag",createColumn("flag",typeof(byte),false,false)},
			{"flagusable",createColumn("flagusable",typeof(string),true,true)},
			{"idupb",createColumn("idupb",typeof(string),false,false)},
			{"codeupb",createColumn("codeupb",typeof(string),false,false)},
			{"upb",createColumn("upb",typeof(string),false,false)},
			{"idsor01",createColumn("idsor01",typeof(int),true,false)},
			{"idsor02",createColumn("idsor02",typeof(int),true,false)},
			{"idsor03",createColumn("idsor03",typeof(int),true,false)},
			{"idsor04",createColumn("idsor04",typeof(int),true,false)},
			{"idsor05",createColumn("idsor05",typeof(int),true,false)},
			{"cupcode",createColumn("cupcode",typeof(string),true,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
		};
	}
}
}
