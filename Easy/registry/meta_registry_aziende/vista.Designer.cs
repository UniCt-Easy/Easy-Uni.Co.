/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace meta_registry_aziende {
public class registry_aziendeRow: MetaRow  {
	public registry_aziendeRow(DataRowBuilder rb) : base(rb) {} 

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
	///Classificazione Ateco
	///</summary>
	public Int32? idateco{ 
		get {if (this["idateco"]==DBNull.Value)return null; return  (Int32?)this["idateco"];}
		set {if (value==null) this["idateco"]= DBNull.Value; else this["idateco"]= value;}
	}
	public object idatecoValue { 
		get{ return this["idateco"];}
		set {if (value==null|| value==DBNull.Value) this["idateco"]= DBNull.Value; else this["idateco"]= value;}
	}
	public Int32? idatecoOriginal { 
		get {if (this["idateco",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idateco",DataRowVersion.Original];}
	}
	///<summary>
	///Codice NACE
	///</summary>
	public String idnace{ 
		get {if (this["idnace"]==DBNull.Value)return null; return  (String)this["idnace"];}
		set {if (value==null) this["idnace"]= DBNull.Value; else this["idnace"]= value;}
	}
	public object idnaceValue { 
		get{ return this["idnace"];}
		set {if (value==null|| value==DBNull.Value) this["idnace"]= DBNull.Value; else this["idnace"]= value;}
	}
	public String idnaceOriginal { 
		get {if (this["idnace",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idnace",DataRowVersion.Original];}
	}
	///<summary>
	///Natura Giuridica
	///</summary>
	public Int32? idnaturagiur{ 
		get {if (this["idnaturagiur"]==DBNull.Value)return null; return  (Int32?)this["idnaturagiur"];}
		set {if (value==null) this["idnaturagiur"]= DBNull.Value; else this["idnaturagiur"]= value;}
	}
	public object idnaturagiurValue { 
		get{ return this["idnaturagiur"];}
		set {if (value==null|| value==DBNull.Value) this["idnaturagiur"]= DBNull.Value; else this["idnaturagiur"]= value;}
	}
	public Int32? idnaturagiurOriginal { 
		get {if (this["idnaturagiur",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idnaturagiur",DataRowVersion.Original];}
	}
	///<summary>
	///Numero di dipendenti
	///</summary>
	public Int32? idnumerodip{ 
		get {if (this["idnumerodip"]==DBNull.Value)return null; return  (Int32?)this["idnumerodip"];}
		set {if (value==null) this["idnumerodip"]= DBNull.Value; else this["idnumerodip"]= value;}
	}
	public object idnumerodipValue { 
		get{ return this["idnumerodip"];}
		set {if (value==null|| value==DBNull.Value) this["idnumerodip"]= DBNull.Value; else this["idnumerodip"]= value;}
	}
	public Int32? idnumerodipOriginal { 
		get {if (this["idnumerodip",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idnumerodip",DataRowVersion.Original];}
	}
	///<summary>
	///Codice
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
	///Denominazione (ENG)
	///</summary>
	public String title_en{ 
		get {if (this["title_en"]==DBNull.Value)return null; return  (String)this["title_en"];}
		set {if (value==null) this["title_en"]= DBNull.Value; else this["title_en"]= value;}
	}
	public object title_enValue { 
		get{ return this["title_en"];}
		set {if (value==null|| value==DBNull.Value) this["title_en"]= DBNull.Value; else this["title_en"]= value;}
	}
	public String title_enOriginal { 
		get {if (this["title_en",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["title_en",DataRowVersion.Original];}
	}
	public String txt_en{ 
		get {if (this["txt_en"]==DBNull.Value)return null; return  (String)this["txt_en"];}
		set {if (value==null) this["txt_en"]= DBNull.Value; else this["txt_en"]= value;}
	}
	public object txt_enValue { 
		get{ return this["txt_en"];}
		set {if (value==null|| value==DBNull.Value) this["txt_en"]= DBNull.Value; else this["txt_en"]= value;}
	}
	public String txt_enOriginal { 
		get {if (this["txt_en",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["txt_en",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///2.4.34 2.5.19  Enti e Aziende
///</summary>
public class registry_aziendeTable : MetaTableBase<registry_aziendeRow> {
	public registry_aziendeTable() : base("registry_aziende"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idateco",createColumn("idateco",typeof(int),true,false)},
			{"idnace",createColumn("idnace",typeof(string),true,false)},
			{"idnaturagiur",createColumn("idnaturagiur",typeof(int),true,false)},
			{"idnumerodip",createColumn("idnumerodip",typeof(int),true,false)},
			{"idreg",createColumn("idreg",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"title_en",createColumn("title_en",typeof(string),true,false)},
			{"txt_en",createColumn("txt_en",typeof(string),true,false)},
		};
	}
}
}
