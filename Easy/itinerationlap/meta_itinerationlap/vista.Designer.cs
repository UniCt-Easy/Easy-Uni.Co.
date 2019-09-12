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
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_itinerationlap {
public class itinerationlapRow: MetaRow  {
	public itinerationlapRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Percentuale anticipo
	///</summary>
	public Decimal? advancepercentage{ 
		get {if (this["advancepercentage"]==DBNull.Value)return null; return  (Decimal?)this["advancepercentage"];}
		set {if (value==null) this["advancepercentage"]= DBNull.Value; else this["advancepercentage"]= value;}
	}
	public object advancepercentageValue { 
		get{ return this["advancepercentage"];}
		set {if (value==null|| value==DBNull.Value) this["advancepercentage"]= DBNull.Value; else this["advancepercentage"]= value;}
	}
	public Decimal? advancepercentageOriginal { 
		get {if (this["advancepercentage",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["advancepercentage",DataRowVersion.Original];}
	}
	///<summary>
	///Indennità giornaliera corrisposta
	///</summary>
	public Decimal? allowance{ 
		get {if (this["allowance"]==DBNull.Value)return null; return  (Decimal?)this["allowance"];}
		set {if (value==null) this["allowance"]= DBNull.Value; else this["allowance"]= value;}
	}
	public object allowanceValue { 
		get{ return this["allowance"];}
		set {if (value==null|| value==DBNull.Value) this["allowance"]= DBNull.Value; else this["allowance"]= value;}
	}
	public Decimal? allowanceOriginal { 
		get {if (this["allowance",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["allowance",DataRowVersion.Original];}
	}
	///<summary>
	///A/R
	///</summary>
	public String ar{ 
		get {if (this["ar"]==DBNull.Value)return null; return  (String)this["ar"];}
		set {if (value==null) this["ar"]= DBNull.Value; else this["ar"]= value;}
	}
	public object arValue { 
		get{ return this["ar"];}
		set {if (value==null|| value==DBNull.Value) this["ar"]= DBNull.Value; else this["ar"]= value;}
	}
	public String arOriginal { 
		get {if (this["ar",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ar",DataRowVersion.Original];}
	}
	///<summary>
	///data creazione
	///</summary>
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
	///<summary>
	///nome utente creazione
	///</summary>
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
	///<summary>
	///Giorni
	///</summary>
	public Decimal? days{ 
		get {if (this["days"]==DBNull.Value)return null; return  (Decimal?)this["days"];}
		set {if (value==null) this["days"]= DBNull.Value; else this["days"]= value;}
	}
	public object daysValue { 
		get{ return this["days"];}
		set {if (value==null|| value==DBNull.Value) this["days"]= DBNull.Value; else this["days"]= value;}
	}
	public Decimal? daysOriginal { 
		get {if (this["days",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["days",DataRowVersion.Original];}
	}
	///<summary>
	///Descrizione
	///</summary>
	public String description{ 
		get {if (this["description"]==DBNull.Value)return null; return  (String)this["description"];}
		set {if (value==null) this["description"]= DBNull.Value; else this["description"]= value;}
	}
	public object descriptionValue { 
		get{ return this["description"];}
		set {if (value==null|| value==DBNull.Value) this["description"]= DBNull.Value; else this["description"]= value;}
	}
	public String descriptionOriginal { 
		get {if (this["description",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["description",DataRowVersion.Original];}
	}
	///<summary>
	///Tappa italiana
	///	 N: Tappa estera
	///	 S: Tappa italiana
	///</summary>
	public String flagitalian{ 
		get {if (this["flagitalian"]==DBNull.Value)return null; return  (String)this["flagitalian"];}
		set {if (value==null) this["flagitalian"]= DBNull.Value; else this["flagitalian"]= value;}
	}
	public object flagitalianValue { 
		get{ return this["flagitalian"];}
		set {if (value==null|| value==DBNull.Value) this["flagitalian"]= DBNull.Value; else this["flagitalian"]= value;}
	}
	public String flagitalianOriginal { 
		get {if (this["flagitalian",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagitalian",DataRowVersion.Original];}
	}
	///<summary>
	///Ore
	///</summary>
	public Decimal? hours{ 
		get {if (this["hours"]==DBNull.Value)return null; return  (Decimal?)this["hours"];}
		set {if (value==null) this["hours"]= DBNull.Value; else this["hours"]= value;}
	}
	public object hoursValue { 
		get{ return this["hours"];}
		set {if (value==null|| value==DBNull.Value) this["hours"]= DBNull.Value; else this["hours"]= value;}
	}
	public Decimal? hoursOriginal { 
		get {if (this["hours",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["hours",DataRowVersion.Original];}
	}
	///<summary>
	///Località di partenza
	///</summary>
	public Int32? idcity_departure{ 
		get {if (this["idcity_departure"]==DBNull.Value)return null; return  (Int32?)this["idcity_departure"];}
		set {if (value==null) this["idcity_departure"]= DBNull.Value; else this["idcity_departure"]= value;}
	}
	public object idcity_departureValue { 
		get{ return this["idcity_departure"];}
		set {if (value==null|| value==DBNull.Value) this["idcity_departure"]= DBNull.Value; else this["idcity_departure"]= value;}
	}
	public Int32? idcity_departureOriginal { 
		get {if (this["idcity_departure",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcity_departure",DataRowVersion.Original];}
	}
	///<summary>
	///Località di arrivo
	///</summary>
	public Int32? idcity_destination{ 
		get {if (this["idcity_destination"]==DBNull.Value)return null; return  (Int32?)this["idcity_destination"];}
		set {if (value==null) this["idcity_destination"]= DBNull.Value; else this["idcity_destination"]= value;}
	}
	public object idcity_destinationValue { 
		get{ return this["idcity_destination"];}
		set {if (value==null|| value==DBNull.Value) this["idcity_destination"]= DBNull.Value; else this["idcity_destination"]= value;}
	}
	public Int32? idcity_destinationOriginal { 
		get {if (this["idcity_destination",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcity_destination",DataRowVersion.Original];}
	}
	///<summary>
	///ID Località Estere (tabella foreigncountry)
	///</summary>
	public Int32? idforeigncountry{ 
		get {if (this["idforeigncountry"]==DBNull.Value)return null; return  (Int32?)this["idforeigncountry"];}
		set {if (value==null) this["idforeigncountry"]= DBNull.Value; else this["idforeigncountry"]= value;}
	}
	public object idforeigncountryValue { 
		get{ return this["idforeigncountry"];}
		set {if (value==null|| value==DBNull.Value) this["idforeigncountry"]= DBNull.Value; else this["idforeigncountry"]= value;}
	}
	public Int32? idforeigncountryOriginal { 
		get {if (this["idforeigncountry",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idforeigncountry",DataRowVersion.Original];}
	}
	///<summary>
	///id missione (tabella itineration)
	///</summary>
	public Int32? iditineration{ 
		get {if (this["iditineration"]==DBNull.Value)return null; return  (Int32?)this["iditineration"];}
		set {if (value==null) this["iditineration"]= DBNull.Value; else this["iditineration"]= value;}
	}
	public object iditinerationValue { 
		get{ return this["iditineration"];}
		set {if (value==null|| value==DBNull.Value) this["iditineration"]= DBNull.Value; else this["iditineration"]= value;}
	}
	public Int32? iditinerationOriginal { 
		get {if (this["iditineration",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iditineration",DataRowVersion.Original];}
	}
	///<summary>
	///Mezzo
	///</summary>
	public Int32? iditinerationlapvehiclekind{ 
		get {if (this["iditinerationlapvehiclekind"]==DBNull.Value)return null; return  (Int32?)this["iditinerationlapvehiclekind"];}
		set {if (value==null) this["iditinerationlapvehiclekind"]= DBNull.Value; else this["iditinerationlapvehiclekind"]= value;}
	}
	public object iditinerationlapvehiclekindValue { 
		get{ return this["iditinerationlapvehiclekind"];}
		set {if (value==null|| value==DBNull.Value) this["iditinerationlapvehiclekind"]= DBNull.Value; else this["iditinerationlapvehiclekind"]= value;}
	}
	public Int32? iditinerationlapvehiclekindOriginal { 
		get {if (this["iditinerationlapvehiclekind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iditinerationlapvehiclekind",DataRowVersion.Original];}
	}
	///<summary>
	///ID Tipi di riduzione della diaria (tabella reduction)
	///</summary>
	public String idreduction{ 
		get {if (this["idreduction"]==DBNull.Value)return null; return  (String)this["idreduction"];}
		set {if (value==null) this["idreduction"]= DBNull.Value; else this["idreduction"]= value;}
	}
	public object idreductionValue { 
		get{ return this["idreduction"];}
		set {if (value==null|| value==DBNull.Value) this["idreduction"]= DBNull.Value; else this["idreduction"]= value;}
	}
	public String idreductionOriginal { 
		get {if (this["idreduction",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idreduction",DataRowVersion.Original];}
	}
	///<summary>
	///Kilometri
	///</summary>
	public Int32? km{ 
		get {if (this["km"]==DBNull.Value)return null; return  (Int32?)this["km"];}
		set {if (value==null) this["km"]= DBNull.Value; else this["km"]= value;}
	}
	public object kmValue { 
		get{ return this["km"];}
		set {if (value==null|| value==DBNull.Value) this["km"]= DBNull.Value; else this["km"]= value;}
	}
	public Int32? kmOriginal { 
		get {if (this["km",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["km",DataRowVersion.Original];}
	}
	///<summary>
	///numero tappa
	///</summary>
	public Int32? lapnumber{ 
		get {if (this["lapnumber"]==DBNull.Value)return null; return  (Int32?)this["lapnumber"];}
		set {if (value==null) this["lapnumber"]= DBNull.Value; else this["lapnumber"]= value;}
	}
	public object lapnumberValue { 
		get{ return this["lapnumber"];}
		set {if (value==null|| value==DBNull.Value) this["lapnumber"]= DBNull.Value; else this["lapnumber"]= value;}
	}
	public Int32? lapnumberOriginal { 
		get {if (this["lapnumber",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["lapnumber",DataRowVersion.Original];}
	}
	///<summary>
	///data ultima modifica
	///</summary>
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
	///<summary>
	///nome ultimo utente modifica
	///</summary>
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
	///<summary>
	///percentuale riduzione della diaria applicata
	///</summary>
	public Decimal? reductionpercentage{ 
		get {if (this["reductionpercentage"]==DBNull.Value)return null; return  (Decimal?)this["reductionpercentage"];}
		set {if (value==null) this["reductionpercentage"]= DBNull.Value; else this["reductionpercentage"]= value;}
	}
	public object reductionpercentageValue { 
		get{ return this["reductionpercentage"];}
		set {if (value==null|| value==DBNull.Value) this["reductionpercentage"]= DBNull.Value; else this["reductionpercentage"]= value;}
	}
	public Decimal? reductionpercentageOriginal { 
		get {if (this["reductionpercentage",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["reductionpercentage",DataRowVersion.Original];}
	}
	///<summary>
	///Inizio
	///</summary>
	public DateTime? starttime{ 
		get {if (this["starttime"]==DBNull.Value)return null; return  (DateTime?)this["starttime"];}
		set {if (value==null) this["starttime"]= DBNull.Value; else this["starttime"]= value;}
	}
	public object starttimeValue { 
		get{ return this["starttime"];}
		set {if (value==null|| value==DBNull.Value) this["starttime"]= DBNull.Value; else this["starttime"]= value;}
	}
	public DateTime? starttimeOriginal { 
		get {if (this["starttime",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["starttime",DataRowVersion.Original];}
	}
	///<summary>
	///Termine
	///</summary>
	public DateTime? stoptime{ 
		get {if (this["stoptime"]==DBNull.Value)return null; return  (DateTime?)this["stoptime"];}
		set {if (value==null) this["stoptime"]= DBNull.Value; else this["stoptime"]= value;}
	}
	public object stoptimeValue { 
		get{ return this["stoptime"];}
		set {if (value==null|| value==DBNull.Value) this["stoptime"]= DBNull.Value; else this["stoptime"]= value;}
	}
	public DateTime? stoptimeOriginal { 
		get {if (this["stoptime",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["stoptime",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Tappa missione
///</summary>
public class itinerationlapTable : MetaTableBase<itinerationlapRow> {
	public itinerationlapTable() : base("itinerationlap"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"advancepercentage",createColumn("advancepercentage",typeof(decimal),true,false)},
			{"allowance",createColumn("allowance",typeof(decimal),true,false)},
			{"ar",createColumn("ar",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"days",createColumn("days",typeof(decimal),false,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"flagitalian",createColumn("flagitalian",typeof(string),false,false)},
			{"hours",createColumn("hours",typeof(decimal),false,false)},
			{"idcity_departure",createColumn("idcity_departure",typeof(int),true,false)},
			{"idcity_destination",createColumn("idcity_destination",typeof(int),true,false)},
			{"idforeigncountry",createColumn("idforeigncountry",typeof(int),true,false)},
			{"iditineration",createColumn("iditineration",typeof(int),false,false)},
			{"iditinerationlapvehiclekind",createColumn("iditinerationlapvehiclekind",typeof(int),true,false)},
			{"idreduction",createColumn("idreduction",typeof(string),true,false)},
			{"km",createColumn("km",typeof(int),true,false)},
			{"lapnumber",createColumn("lapnumber",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"reductionpercentage",createColumn("reductionpercentage",typeof(decimal),true,false)},
			{"starttime",createColumn("starttime",typeof(DateTime),true,false)},
			{"stoptime",createColumn("stoptime",typeof(DateTime),true,false)},
		};
	}
}
}
