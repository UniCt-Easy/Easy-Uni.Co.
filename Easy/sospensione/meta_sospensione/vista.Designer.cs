
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
namespace meta_sospensione {
public class sospensioneRow: MetaRow  {
	public sospensioneRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///Aula
	///</summary>
	public Int32? idaula{ 
		get {if (this["idaula"]==DBNull.Value)return null; return  (Int32?)this["idaula"];}
		set {if (value==null) this["idaula"]= DBNull.Value; else this["idaula"]= value;}
	}
	public object idaulaValue { 
		get{ return this["idaula"];}
		set {if (value==null|| value==DBNull.Value) this["idaula"]= DBNull.Value; else this["idaula"]= value;}
	}
	public Int32? idaulaOriginal { 
		get {if (this["idaula",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idaula",DataRowVersion.Original];}
	}
	///<summary>
	///Edificio
	///</summary>
	public Int32? idedificio{ 
		get {if (this["idedificio"]==DBNull.Value)return null; return  (Int32?)this["idedificio"];}
		set {if (value==null) this["idedificio"]= DBNull.Value; else this["idedificio"]= value;}
	}
	public object idedificioValue { 
		get{ return this["idedificio"];}
		set {if (value==null|| value==DBNull.Value) this["idedificio"]= DBNull.Value; else this["idedificio"]= value;}
	}
	public Int32? idedificioOriginal { 
		get {if (this["idedificio",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idedificio",DataRowVersion.Original];}
	}
	///<summary>
	///Docente, Studente o Istituto
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
	///Sede
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
	///Codice
	///</summary>
	public Int32? idsospensione{ 
		get {if (this["idsospensione"]==DBNull.Value)return null; return  (Int32?)this["idsospensione"];}
		set {if (value==null) this["idsospensione"]= DBNull.Value; else this["idsospensione"]= value;}
	}
	public object idsospensioneValue { 
		get{ return this["idsospensione"];}
		set {if (value==null|| value==DBNull.Value) this["idsospensione"]= DBNull.Value; else this["idsospensione"]= value;}
	}
	public Int32? idsospensioneOriginal { 
		get {if (this["idsospensione",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsospensione",DataRowVersion.Original];}
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
	public String motivo{ 
		get {if (this["motivo"]==DBNull.Value)return null; return  (String)this["motivo"];}
		set {if (value==null) this["motivo"]= DBNull.Value; else this["motivo"]= value;}
	}
	public object motivoValue { 
		get{ return this["motivo"];}
		set {if (value==null|| value==DBNull.Value) this["motivo"]= DBNull.Value; else this["motivo"]= value;}
	}
	public String motivoOriginal { 
		get {if (this["motivo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["motivo",DataRowVersion.Original];}
	}
	///<summary>
	///Inizio
	///</summary>
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
	///<summary>
	///Fine
	///</summary>
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
	#endregion

}
///<summary>
///sospenione di attività, che sia di una carriera, didattica del docente o di utilizzabilità di un’aula
///</summary>
public class sospensioneTable : MetaTableBase<sospensioneRow> {
	public sospensioneTable() : base("sospensione"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idaula",createColumn("idaula",typeof(int),true,false)},
			{"idedificio",createColumn("idedificio",typeof(int),true,false)},
			{"idreg",createColumn("idreg",typeof(int),true,false)},
			{"idsede",createColumn("idsede",typeof(int),true,false)},
			{"idsospensione",createColumn("idsospensione",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"motivo",createColumn("motivo",typeof(string),true,false)},
			{"start",createColumn("start",typeof(DateTime),false,false)},
			{"stop",createColumn("stop",typeof(DateTime),true,false)},
		};
	}
}
}
