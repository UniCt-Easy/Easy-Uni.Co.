/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
	public Decimal days{ 
		get {return  (Decimal)this["days"];}
		set {this["days"]= value;}
	}
	public object daysValue { 
		get{ return this["days"];}
		set {this["days"]= value;}
	}
	public Decimal daysOriginal { 
		get {return  (Decimal)this["days",DataRowVersion.Original];}
	}
	public String description{ 
		get {return  (String)this["description"];}
		set {this["description"]= value;}
	}
	public object descriptionValue { 
		get{ return this["description"];}
		set {this["description"]= value;}
	}
	public String descriptionOriginal { 
		get {return  (String)this["description",DataRowVersion.Original];}
	}
	public String flagitalian{ 
		get {return  (String)this["flagitalian"];}
		set {this["flagitalian"]= value;}
	}
	public object flagitalianValue { 
		get{ return this["flagitalian"];}
		set {this["flagitalian"]= value;}
	}
	public String flagitalianOriginal { 
		get {return  (String)this["flagitalian",DataRowVersion.Original];}
	}
	public Decimal hours{ 
		get {return  (Decimal)this["hours"];}
		set {this["hours"]= value;}
	}
	public object hoursValue { 
		get{ return this["hours"];}
		set {this["hours"]= value;}
	}
	public Decimal hoursOriginal { 
		get {return  (Decimal)this["hours",DataRowVersion.Original];}
	}
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
	public Int32 iditineration{ 
		get {return  (Int32)this["iditineration"];}
		set {this["iditineration"]= value;}
	}
	public object iditinerationValue { 
		get{ return this["iditineration"];}
		set {this["iditineration"]= value;}
	}
	public Int32 iditinerationOriginal { 
		get {return  (Int32)this["iditineration",DataRowVersion.Original];}
	}
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
	public Int32 lapnumber{ 
		get {return  (Int32)this["lapnumber"];}
		set {this["lapnumber"]= value;}
	}
	public object lapnumberValue { 
		get{ return this["lapnumber"];}
		set {this["lapnumber"]= value;}
	}
	public Int32 lapnumberOriginal { 
		get {return  (Int32)this["lapnumber",DataRowVersion.Original];}
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
	public String extension{ 
		get {if (this["extension"]==DBNull.Value)return null; return  (String)this["extension"];}
		set {if (value==null) this["extension"]= DBNull.Value; else this["extension"]= value;}
	}
	public object extensionValue { 
		get{ return this["extension"];}
		set {if (value==null|| value==DBNull.Value) this["extension"]= DBNull.Value; else this["extension"]= value;}
	}
	public String extensionOriginal { 
		get {if (this["extension",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["extension",DataRowVersion.Original];}
	}
	#endregion

}
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
			{"extension",createColumn("extension",typeof(string),true,false)},
		};
	}
}
}
