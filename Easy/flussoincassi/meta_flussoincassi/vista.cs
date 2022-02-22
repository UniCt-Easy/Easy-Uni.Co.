
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
using System.Collections.Generic;
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_flussoincassi {
public class flussoincassiRow: MetaRow  {
	public flussoincassiRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 idflusso{ 
		get {return  (Int32)this["idflusso"];}
		set {this["idflusso"]= value;}
	}
	public object idflussoValue { 
		get{ return this["idflusso"];}
		set {this["idflusso"]= value;}
	}
	public Int32 idflussoOriginal { 
		get {return  (Int32)this["idflusso",DataRowVersion.Original];}
	}
	public String codiceflusso{ 
		get {if (this["codiceflusso"]==DBNull.Value)return null; return  (String)this["codiceflusso"];}
		set {if (value==null) this["codiceflusso"]= DBNull.Value; else this["codiceflusso"]= value;}
	}
	public object codiceflussoValue { 
		get{ return this["codiceflusso"];}
		set {if (value==null|| value==DBNull.Value) this["codiceflusso"]= DBNull.Value; else this["codiceflusso"]= value;}
	}
	public String codiceflussoOriginal { 
		get {if (this["codiceflusso",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codiceflusso",DataRowVersion.Original];}
	}
	public String trn{ 
		get {if (this["trn"]==DBNull.Value)return null; return  (String)this["trn"];}
		set {if (value==null) this["trn"]= DBNull.Value; else this["trn"]= value;}
	}
	public object trnValue { 
		get{ return this["trn"];}
		set {if (value==null|| value==DBNull.Value) this["trn"]= DBNull.Value; else this["trn"]= value;}
	}
	public String trnOriginal { 
		get {if (this["trn",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["trn",DataRowVersion.Original];}
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
	public Int16? ayear{ 
		get {if (this["ayear"]==DBNull.Value)return null; return  (Int16?)this["ayear"];}
		set {if (value==null) this["ayear"]= DBNull.Value; else this["ayear"]= value;}
	}
	public object ayearValue { 
		get{ return this["ayear"];}
		set {if (value==null|| value==DBNull.Value) this["ayear"]= DBNull.Value; else this["ayear"]= value;}
	}
	public Int16? ayearOriginal { 
		get {if (this["ayear",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["ayear",DataRowVersion.Original];}
	}
	public String causale{ 
		get {if (this["causale"]==DBNull.Value)return null; return  (String)this["causale"];}
		set {if (value==null) this["causale"]= DBNull.Value; else this["causale"]= value;}
	}
	public object causaleValue { 
		get{ return this["causale"];}
		set {if (value==null|| value==DBNull.Value) this["causale"]= DBNull.Value; else this["causale"]= value;}
	}
	public String causaleOriginal { 
		get {if (this["causale",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["causale",DataRowVersion.Original];}
	}
	public DateTime? dataincasso{ 
		get {if (this["dataincasso"]==DBNull.Value)return null; return  (DateTime?)this["dataincasso"];}
		set {if (value==null) this["dataincasso"]= DBNull.Value; else this["dataincasso"]= value;}
	}
	public object dataincassoValue { 
		get{ return this["dataincasso"];}
		set {if (value==null|| value==DBNull.Value) this["dataincasso"]= DBNull.Value; else this["dataincasso"]= value;}
	}
	public DateTime? dataincassoOriginal { 
		get {if (this["dataincasso",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["dataincasso",DataRowVersion.Original];}
	}
	public Int32? nbill{ 
		get {if (this["nbill"]==DBNull.Value)return null; return  (Int32?)this["nbill"];}
		set {if (value==null) this["nbill"]= DBNull.Value; else this["nbill"]= value;}
	}
	public object nbillValue { 
		get{ return this["nbill"];}
		set {if (value==null|| value==DBNull.Value) this["nbill"]= DBNull.Value; else this["nbill"]= value;}
	}
	public Int32? nbillOriginal { 
		get {if (this["nbill",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nbill",DataRowVersion.Original];}
	}
	public Decimal? importo{ 
		get {if (this["importo"]==DBNull.Value)return null; return  (Decimal?)this["importo"];}
		set {if (value==null) this["importo"]= DBNull.Value; else this["importo"]= value;}
	}
	public object importoValue { 
		get{ return this["importo"];}
		set {if (value==null|| value==DBNull.Value) this["importo"]= DBNull.Value; else this["importo"]= value;}
	}
	public Decimal? importoOriginal { 
		get {if (this["importo",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["importo",DataRowVersion.Original];}
	}
	public String to_complete{ 
		get {if (this["to_complete"]==DBNull.Value)return null; return  (String)this["to_complete"];}
		set {if (value==null) this["to_complete"]= DBNull.Value; else this["to_complete"]= value;}
	}
	public object to_completeValue { 
		get{ return this["to_complete"];}
		set {if (value==null|| value==DBNull.Value) this["to_complete"]= DBNull.Value; else this["to_complete"]= value;}
	}
	public String to_completeOriginal { 
		get {if (this["to_complete",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["to_complete",DataRowVersion.Original];}
	}
	public String elaborato{ 
		get {if (this["elaborato"]==DBNull.Value)return null; return  (String)this["elaborato"];}
		set {if (value==null) this["elaborato"]= DBNull.Value; else this["elaborato"]= value;}
	}
	public object elaboratoValue { 
		get{ return this["elaborato"];}
		set {if (value==null|| value==DBNull.Value) this["elaborato"]= DBNull.Value; else this["elaborato"]= value;}
	}
	public String elaboratoOriginal { 
		get {if (this["elaborato",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["elaborato",DataRowVersion.Original];}
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
	#endregion

}
public class flussoincassiTable : MetaTableBase<flussoincassiRow> {
	public flussoincassiTable() : base("flussoincassi"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idflusso",createColumn("idflusso",typeof(int),false,false)},
			{"codiceflusso",createColumn("codiceflusso",typeof(string),true,false)},
			{"trn",createColumn("trn",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"ayear",createColumn("ayear",typeof(short),true,false)},
			{"causale",createColumn("causale",typeof(string),true,false)},
			{"dataincasso",createColumn("dataincasso",typeof(DateTime),true,false)},
			{"nbill",createColumn("nbill",typeof(int),true,false)},
			{"importo",createColumn("importo",typeof(decimal),true,false)},
			{"to_complete",createColumn("to_complete",typeof(string),true,false)},
			{"elaborato",createColumn("elaborato",typeof(string),true,false)},
			{"active",createColumn("active",typeof(string),true,false)},
			{"idsor01",createColumn("idsor01",typeof(int),true,false)},
			{"idsor02",createColumn("idsor02",typeof(int),true,false)},
			{"idsor03",createColumn("idsor03",typeof(int),true,false)},
			{"idsor04",createColumn("idsor04",typeof(int),true,false)},
			{"idsor05",createColumn("idsor05",typeof(int),true,false)},
		};
	}
}
}
