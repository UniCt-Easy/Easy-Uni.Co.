
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
using System.Collections.Generic;
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_sede {
public class sedeRow: MetaRow  {
	public sedeRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Indirizzo
	///</summary>
	public String address{ 
		get {if (this["address"]==DBNull.Value)return null; return  (String)this["address"];}
		set {if (value==null) this["address"]= DBNull.Value; else this["address"]= value;}
	}
	public object addressValue { 
		get{ return this["address"];}
		set {if (value==null|| value==DBNull.Value) this["address"]= DBNull.Value; else this["address"]= value;}
	}
	public String addressOriginal { 
		get {if (this["address",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["address",DataRowVersion.Original];}
	}
	///<summary>
	///Note
	///</summary>
	public String annotations{ 
		get {if (this["annotations"]==DBNull.Value)return null; return  (String)this["annotations"];}
		set {if (value==null) this["annotations"]= DBNull.Value; else this["annotations"]= value;}
	}
	public object annotationsValue { 
		get{ return this["annotations"];}
		set {if (value==null|| value==DBNull.Value) this["annotations"]= DBNull.Value; else this["annotations"]= value;}
	}
	public String annotationsOriginal { 
		get {if (this["annotations",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["annotations",DataRowVersion.Original];}
	}
	///<summary>
	///CAP
	///</summary>
	public String cap{ 
		get {if (this["cap"]==DBNull.Value)return null; return  (String)this["cap"];}
		set {if (value==null) this["cap"]= DBNull.Value; else this["cap"]= value;}
	}
	public object capValue { 
		get{ return this["cap"];}
		set {if (value==null|| value==DBNull.Value) this["cap"]= DBNull.Value; else this["cap"]= value;}
	}
	public String capOriginal { 
		get {if (this["cap",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cap",DataRowVersion.Original];}
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
	///<summary>
	///Comune
	///</summary>
	public Int32? idcity{ 
		get {if (this["idcity"]==DBNull.Value)return null; return  (Int32?)this["idcity"];}
		set {if (value==null) this["idcity"]= DBNull.Value; else this["idcity"]= value;}
	}
	public object idcityValue { 
		get{ return this["idcity"];}
		set {if (value==null|| value==DBNull.Value) this["idcity"]= DBNull.Value; else this["idcity"]= value;}
	}
	public Int32? idcityOriginal { 
		get {if (this["idcity",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcity",DataRowVersion.Original];}
	}
	///<summary>
	///Nazione
	///</summary>
	public Int32? idnation{ 
		get {if (this["idnation"]==DBNull.Value)return null; return  (Int32?)this["idnation"];}
		set {if (value==null) this["idnation"]= DBNull.Value; else this["idnation"]= value;}
	}
	public object idnationValue { 
		get{ return this["idnation"];}
		set {if (value==null|| value==DBNull.Value) this["idnation"]= DBNull.Value; else this["idnation"]= value;}
	}
	public Int32? idnationOriginal { 
		get {if (this["idnation",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idnation",DataRowVersion.Original];}
	}
	///<summary>
	///Istituto o Ente
	///</summary>
	public Int32? idreg{ 
		get {if (this["idreg"]==DBNull.Value)return null; return  (Int32?)this["idreg"];}
		set {if (value==null) this["idreg"]= DBNull.Value; else this["idreg"]= value;}
	}
	public object idregValue { 
		get{ return this["idreg"];}
		set {if (value==null|| value==DBNull.Value) this["idreg"]= DBNull.Value; else this["idreg"]= value;}
	}
	public Int32? idregOriginal { 
		get {if (this["idreg",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg",DataRowVersion.Original];}
	}
	///<summary>
	///Codice
	///</summary>
	public Int32? idsede{ 
		get {if (this["idsede"]==DBNull.Value)return null; return  (Int32?)this["idsede"];}
		set {if (value==null) this["idsede"]= DBNull.Value; else this["idsede"]= value;}
	}
	public object idsedeValue { 
		get{ return this["idsede"];}
		set {if (value==null|| value==DBNull.Value) this["idsede"]= DBNull.Value; else this["idsede"]= value;}
	}
	public Int32? idsedeOriginal { 
		get {if (this["idsede",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsede",DataRowVersion.Original];}
	}
	///<summary>
	///Identificativo MIUR
	///</summary>
	public Int32? idsedemiur{ 
		get {if (this["idsedemiur"]==DBNull.Value)return null; return  (Int32?)this["idsedemiur"];}
		set {if (value==null) this["idsedemiur"]= DBNull.Value; else this["idsedemiur"]= value;}
	}
	public object idsedemiurValue { 
		get{ return this["idsedemiur"];}
		set {if (value==null|| value==DBNull.Value) this["idsedemiur"]= DBNull.Value; else this["idsedemiur"]= value;}
	}
	public Int32? idsedemiurOriginal { 
		get {if (this["idsedemiur",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsedemiur",DataRowVersion.Original];}
	}
	///<summary>
	///Latitudine
	///</summary>
	public Decimal? latitude{ 
		get {if (this["latitude"]==DBNull.Value)return null; return  (Decimal?)this["latitude"];}
		set {if (value==null) this["latitude"]= DBNull.Value; else this["latitude"]= value;}
	}
	public object latitudeValue { 
		get{ return this["latitude"];}
		set {if (value==null|| value==DBNull.Value) this["latitude"]= DBNull.Value; else this["latitude"]= value;}
	}
	public Decimal? latitudeOriginal { 
		get {if (this["latitude",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["latitude",DataRowVersion.Original];}
	}
	///<summary>
	///Longitudine
	///</summary>
	public Decimal? longitude{ 
		get {if (this["longitude"]==DBNull.Value)return null; return  (Decimal?)this["longitude"];}
		set {if (value==null) this["longitude"]= DBNull.Value; else this["longitude"]= value;}
	}
	public object longitudeValue { 
		get{ return this["longitude"];}
		set {if (value==null|| value==DBNull.Value) this["longitude"]= DBNull.Value; else this["longitude"]= value;}
	}
	public Decimal? longitudeOriginal { 
		get {if (this["longitude",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["longitude",DataRowVersion.Original];}
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
	///<summary>
	///Denominazione
	///</summary>
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
	#endregion

}
///<summary>
///2.4.26 Sedi
///</summary>
public class sedeTable : MetaTableBase<sedeRow> {
	public sedeTable() : base("sede"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"address",createColumn("address",typeof(string),true,false)},
			{"annotations",createColumn("annotations",typeof(string),true,false)},
			{"cap",createColumn("cap",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idcity",createColumn("idcity",typeof(int),true,false)},
			{"idnation",createColumn("idnation",typeof(int),true,false)},
			{"idreg",createColumn("idreg",typeof(int),true,false)},
			{"idsede",createColumn("idsede",typeof(int),false,false)},
			{"idsedemiur",createColumn("idsedemiur",typeof(int),true,false)},
			{"latitude",createColumn("latitude",typeof(decimal),true,false)},
			{"longitude",createColumn("longitude",typeof(decimal),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"title",createColumn("title",typeof(string),true,false)},
		};
	}
}
}
