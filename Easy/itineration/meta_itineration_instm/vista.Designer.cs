
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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
namespace meta_itineration_instm {
public class itineration_instmRow: MetaRow  {
	public itineration_instmRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Autorizzazione da sede di appartenenza
	///</summary>
	public String authemployer{ 
		get {if (this["authemployer"]==DBNull.Value)return null; return  (String)this["authemployer"];}
		set {if (value==null) this["authemployer"]= DBNull.Value; else this["authemployer"]= value;}
	}
	public object authemployerValue { 
		get{ return this["authemployer"];}
		set {if (value==null|| value==DBNull.Value) this["authemployer"]= DBNull.Value; else this["authemployer"]= value;}
	}
	public String authemployerOriginal { 
		get {if (this["authemployer",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["authemployer",DataRowVersion.Original];}
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
	///Presso
	///</summary>
	public String destination{ 
		get {if (this["destination"]==DBNull.Value)return null; return  (String)this["destination"];}
		set {if (value==null) this["destination"]= DBNull.Value; else this["destination"]= value;}
	}
	public object destinationValue { 
		get{ return this["destination"];}
		set {if (value==null|| value==DBNull.Value) this["destination"]= DBNull.Value; else this["destination"]= value;}
	}
	public String destinationOriginal { 
		get {if (this["destination",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["destination",DataRowVersion.Original];}
	}
	///<summary>
	///Località non corrispondente a sede di servizio
	///</summary>
	public String differentlocation{ 
		get {if (this["differentlocation"]==DBNull.Value)return null; return  (String)this["differentlocation"];}
		set {if (value==null) this["differentlocation"]= DBNull.Value; else this["differentlocation"]= value;}
	}
	public object differentlocationValue { 
		get{ return this["differentlocation"];}
		set {if (value==null|| value==DBNull.Value) this["differentlocation"]= DBNull.Value; else this["differentlocation"]= value;}
	}
	public String differentlocationOriginal { 
		get {if (this["differentlocation",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["differentlocation",DataRowVersion.Original];}
	}
	///<summary>
	///Località di partenza se diversa da quella di servizio
	///</summary>
	public Int32? idcity_start{ 
		get {if (this["idcity_start"]==DBNull.Value)return null; return  (Int32?)this["idcity_start"];}
		set {if (value==null) this["idcity_start"]= DBNull.Value; else this["idcity_start"]= value;}
	}
	public object idcity_startValue { 
		get{ return this["idcity_start"];}
		set {if (value==null|| value==DBNull.Value) this["idcity_start"]= DBNull.Value; else this["idcity_start"]= value;}
	}
	public Int32? idcity_startOriginal { 
		get {if (this["idcity_start",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcity_start",DataRowVersion.Original];}
	}
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
	///N° Work Package
	///</summary>
	public String numberwp{ 
		get {if (this["numberwp"]==DBNull.Value)return null; return  (String)this["numberwp"];}
		set {if (value==null) this["numberwp"]= DBNull.Value; else this["numberwp"]= value;}
	}
	public object numberwpValue { 
		get{ return this["numberwp"];}
		set {if (value==null|| value==DBNull.Value) this["numberwp"]= DBNull.Value; else this["numberwp"]= value;}
	}
	public String numberwpOriginal { 
		get {if (this["numberwp",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["numberwp",DataRowVersion.Original];}
	}
	///<summary>
	///Sussistenza motivi che prevedono utilizzo mezzi diversi da treno o aereo
	///</summary>
	public String othervehicle{ 
		get {if (this["othervehicle"]==DBNull.Value)return null; return  (String)this["othervehicle"];}
		set {if (value==null) this["othervehicle"]= DBNull.Value; else this["othervehicle"]= value;}
	}
	public object othervehicleValue { 
		get{ return this["othervehicle"];}
		set {if (value==null|| value==DBNull.Value) this["othervehicle"]= DBNull.Value; else this["othervehicle"]= value;}
	}
	public String othervehicleOriginal { 
		get {if (this["othervehicle",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["othervehicle",DataRowVersion.Original];}
	}
	///<summary>
	///motivazioni
	///</summary>
	public String othervehiclereason{ 
		get {if (this["othervehiclereason"]==DBNull.Value)return null; return  (String)this["othervehiclereason"];}
		set {if (value==null) this["othervehiclereason"]= DBNull.Value; else this["othervehiclereason"]= value;}
	}
	public object othervehiclereasonValue { 
		get{ return this["othervehiclereason"];}
		set {if (value==null|| value==DBNull.Value) this["othervehiclereason"]= DBNull.Value; else this["othervehiclereason"]= value;}
	}
	public String othervehiclereasonOriginal { 
		get {if (this["othervehiclereason",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["othervehiclereason",DataRowVersion.Original];}
	}
	///<summary>
	///Conoscenza regolamento
	///</summary>
	public String regulationaccept{ 
		get {if (this["regulationaccept"]==DBNull.Value)return null; return  (String)this["regulationaccept"];}
		set {if (value==null) this["regulationaccept"]= DBNull.Value; else this["regulationaccept"]= value;}
	}
	public object regulationacceptValue { 
		get{ return this["regulationaccept"];}
		set {if (value==null|| value==DBNull.Value) this["regulationaccept"]= DBNull.Value; else this["regulationaccept"]= value;}
	}
	public String regulationacceptOriginal { 
		get {if (this["regulationaccept",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["regulationaccept",DataRowVersion.Original];}
	}
	///<summary>
	///Motivi che giustificano località di partenza diversa diversa
	///</summary>
	public String startreason{ 
		get {if (this["startreason"]==DBNull.Value)return null; return  (String)this["startreason"];}
		set {if (value==null) this["startreason"]= DBNull.Value; else this["startreason"]= value;}
	}
	public object startreasonValue { 
		get{ return this["startreason"];}
		set {if (value==null|| value==DBNull.Value) this["startreason"]= DBNull.Value; else this["startreason"]= value;}
	}
	public String startreasonOriginal { 
		get {if (this["startreason",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["startreason",DataRowVersion.Original];}
	}
	///<summary>
	///Titolo Progetto
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
	///<summary>
	///Titolo Work Package
	///</summary>
	public String titlewp{ 
		get {if (this["titlewp"]==DBNull.Value)return null; return  (String)this["titlewp"];}
		set {if (value==null) this["titlewp"]= DBNull.Value; else this["titlewp"]= value;}
	}
	public object titlewpValue { 
		get{ return this["titlewp"];}
		set {if (value==null|| value==DBNull.Value) this["titlewp"]= DBNull.Value; else this["titlewp"]= value;}
	}
	public String titlewpOriginal { 
		get {if (this["titlewp",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["titlewp",DataRowVersion.Original];}
	}
	#endregion

}
public class itineration_instmTable : MetaTableBase<itineration_instmRow> {
	public itineration_instmTable() : base("itineration_instm"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"authemployer",createColumn("authemployer",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"destination",createColumn("destination",typeof(string),true,false)},
			{"differentlocation",createColumn("differentlocation",typeof(string),true,false)},
			{"idcity_start",createColumn("idcity_start",typeof(int),true,false)},
			{"iditineration",createColumn("iditineration",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"numberwp",createColumn("numberwp",typeof(string),false,false)},
			{"othervehicle",createColumn("othervehicle",typeof(string),true,false)},
			{"othervehiclereason",createColumn("othervehiclereason",typeof(string),true,false)},
			{"regulationaccept",createColumn("regulationaccept",typeof(string),true,false)},
			{"startreason",createColumn("startreason",typeof(string),true,false)},
			{"title",createColumn("title",typeof(string),false,false)},
			{"titlewp",createColumn("titlewp",typeof(string),false,false)},
		};
	}
}
}
