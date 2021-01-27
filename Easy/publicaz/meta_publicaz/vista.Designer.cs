
/*
Easy
Copyright (C) 2021 Universit‡ degli Studi di Catania (www.unict.it)
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
namespace meta_publicaz {
public class publicazRow: MetaRow  {
	public publicazRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Abstract
	///</summary>
	public String abstractstring{ 
		get {if (this["abstractstring"]==DBNull.Value)return null; return  (String)this["abstractstring"];}
		set {if (value==null) this["abstractstring"]= DBNull.Value; else this["abstractstring"]= value;}
	}
	public object abstractstringValue { 
		get{ return this["abstractstring"];}
		set {if (value==null|| value==DBNull.Value) this["abstractstring"]= DBNull.Value; else this["abstractstring"]= value;}
	}
	public String abstractstringOriginal { 
		get {if (this["abstractstring",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["abstractstring",DataRowVersion.Original];}
	}
	///<summary>
	///Anno Copyright
	///</summary>
	public Int32? annocopyright{ 
		get {if (this["annocopyright"]==DBNull.Value)return null; return  (Int32?)this["annocopyright"];}
		set {if (value==null) this["annocopyright"]= DBNull.Value; else this["annocopyright"]= value;}
	}
	public object annocopyrightValue { 
		get{ return this["annocopyright"];}
		set {if (value==null|| value==DBNull.Value) this["annocopyright"]= DBNull.Value; else this["annocopyright"]= value;}
	}
	public Int32? annocopyrightOriginal { 
		get {if (this["annocopyright",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["annocopyright",DataRowVersion.Original];}
	}
	///<summary>
	///Anno pubblicazione
	///</summary>
	public Int32? annopub{ 
		get {if (this["annopub"]==DBNull.Value)return null; return  (Int32?)this["annopub"];}
		set {if (value==null) this["annopub"]= DBNull.Value; else this["annopub"]= value;}
	}
	public object annopubValue { 
		get{ return this["annopub"];}
		set {if (value==null|| value==DBNull.Value) this["annopub"]= DBNull.Value; else this["annopub"]= value;}
	}
	public Int32? annopubOriginal { 
		get {if (this["annopub",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["annopub",DataRowVersion.Original];}
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
	public String editore{ 
		get {if (this["editore"]==DBNull.Value)return null; return  (String)this["editore"];}
		set {if (value==null) this["editore"]= DBNull.Value; else this["editore"]= value;}
	}
	public object editoreValue { 
		get{ return this["editore"];}
		set {if (value==null|| value==DBNull.Value) this["editore"]= DBNull.Value; else this["editore"]= value;}
	}
	public String editoreOriginal { 
		get {if (this["editore",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["editore",DataRowVersion.Original];}
	}
	public String fascicolo{ 
		get {if (this["fascicolo"]==DBNull.Value)return null; return  (String)this["fascicolo"];}
		set {if (value==null) this["fascicolo"]= DBNull.Value; else this["fascicolo"]= value;}
	}
	public object fascicoloValue { 
		get{ return this["fascicolo"];}
		set {if (value==null|| value==DBNull.Value) this["fascicolo"]= DBNull.Value; else this["fascicolo"]= value;}
	}
	public String fascicoloOriginal { 
		get {if (this["fascicolo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["fascicolo",DataRowVersion.Original];}
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
	///Comune editore
	///</summary>
	public Int32? idcity_ed{ 
		get {if (this["idcity_ed"]==DBNull.Value)return null; return  (Int32?)this["idcity_ed"];}
		set {if (value==null) this["idcity_ed"]= DBNull.Value; else this["idcity_ed"]= value;}
	}
	public object idcity_edValue { 
		get{ return this["idcity_ed"];}
		set {if (value==null|| value==DBNull.Value) this["idcity_ed"]= DBNull.Value; else this["idcity_ed"]= value;}
	}
	public Int32? idcity_edOriginal { 
		get {if (this["idcity_ed",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcity_ed",DataRowVersion.Original];}
	}
	///<summary>
	///Nazionalit√† editore
	///</summary>
	public Int32? idnation_ed{ 
		get {if (this["idnation_ed"]==DBNull.Value)return null; return  (Int32?)this["idnation_ed"];}
		set {if (value==null) this["idnation_ed"]= DBNull.Value; else this["idnation_ed"]= value;}
	}
	public object idnation_edValue { 
		get{ return this["idnation_ed"];}
		set {if (value==null|| value==DBNull.Value) this["idnation_ed"]= DBNull.Value; else this["idnation_ed"]= value;}
	}
	public Int32? idnation_edOriginal { 
		get {if (this["idnation_ed",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idnation_ed",DataRowVersion.Original];}
	}
	///<summary>
	///Lingua
	///</summary>
	public Int32? idnation_lang{ 
		get {if (this["idnation_lang"]==DBNull.Value)return null; return  (Int32?)this["idnation_lang"];}
		set {if (value==null) this["idnation_lang"]= DBNull.Value; else this["idnation_lang"]= value;}
	}
	public object idnation_langValue { 
		get{ return this["idnation_lang"];}
		set {if (value==null|| value==DBNull.Value) this["idnation_lang"]= DBNull.Value; else this["idnation_lang"]= value;}
	}
	public Int32? idnation_langOriginal { 
		get {if (this["idnation_lang",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idnation_lang",DataRowVersion.Original];}
	}
	///<summary>
	///Codice Istituto
	///</summary>
	public Int32? idpublicaz{ 
		get {if (this["idpublicaz"]==DBNull.Value)return null; return  (Int32?)this["idpublicaz"];}
		set {if (value==null) this["idpublicaz"]= DBNull.Value; else this["idpublicaz"]= value;}
	}
	public object idpublicazValue { 
		get{ return this["idpublicaz"];}
		set {if (value==null|| value==DBNull.Value) this["idpublicaz"]= DBNull.Value; else this["idpublicaz"]= value;}
	}
	public Int32? idpublicazOriginal { 
		get {if (this["idpublicaz",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpublicaz",DataRowVersion.Original];}
	}
	///<summary>
	///ISBN
	///</summary>
	public String isbn{ 
		get {if (this["isbn"]==DBNull.Value)return null; return  (String)this["isbn"];}
		set {if (value==null) this["isbn"]= DBNull.Value; else this["isbn"]= value;}
	}
	public object isbnValue { 
		get{ return this["isbn"];}
		set {if (value==null|| value==DBNull.Value) this["isbn"]= DBNull.Value; else this["isbn"]= value;}
	}
	public String isbnOriginal { 
		get {if (this["isbn",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["isbn",DataRowVersion.Original];}
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
	///Numero Rivista
	///</summary>
	public Int32? numrivista{ 
		get {if (this["numrivista"]==DBNull.Value)return null; return  (Int32?)this["numrivista"];}
		set {if (value==null) this["numrivista"]= DBNull.Value; else this["numrivista"]= value;}
	}
	public object numrivistaValue { 
		get{ return this["numrivista"];}
		set {if (value==null|| value==DBNull.Value) this["numrivista"]= DBNull.Value; else this["numrivista"]= value;}
	}
	public Int32? numrivistaOriginal { 
		get {if (this["numrivista",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["numrivista",DataRowVersion.Original];}
	}
	///<summary>
	///Inizio a pagina
	///</summary>
	public Int32? pagestart{ 
		get {if (this["pagestart"]==DBNull.Value)return null; return  (Int32?)this["pagestart"];}
		set {if (value==null) this["pagestart"]= DBNull.Value; else this["pagestart"]= value;}
	}
	public object pagestartValue { 
		get{ return this["pagestart"];}
		set {if (value==null|| value==DBNull.Value) this["pagestart"]= DBNull.Value; else this["pagestart"]= value;}
	}
	public Int32? pagestartOriginal { 
		get {if (this["pagestart",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["pagestart",DataRowVersion.Original];}
	}
	///<summary>
	///fine a pagina
	///</summary>
	public Int32? pagestop{ 
		get {if (this["pagestop"]==DBNull.Value)return null; return  (Int32?)this["pagestop"];}
		set {if (value==null) this["pagestop"]= DBNull.Value; else this["pagestop"]= value;}
	}
	public object pagestopValue { 
		get{ return this["pagestop"];}
		set {if (value==null|| value==DBNull.Value) this["pagestop"]= DBNull.Value; else this["pagestop"]= value;}
	}
	public Int32? pagestopOriginal { 
		get {if (this["pagestop",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["pagestop",DataRowVersion.Original];}
	}
	///<summary>
	///Numero di pagine
	///</summary>
	public Int32? pagetot{ 
		get {if (this["pagetot"]==DBNull.Value)return null; return  (Int32?)this["pagetot"];}
		set {if (value==null) this["pagetot"]= DBNull.Value; else this["pagetot"]= value;}
	}
	public object pagetotValue { 
		get{ return this["pagetot"];}
		set {if (value==null|| value==DBNull.Value) this["pagetot"]= DBNull.Value; else this["pagetot"]= value;}
	}
	public Int32? pagetotOriginal { 
		get {if (this["pagetot",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["pagetot",DataRowVersion.Original];}
	}
	///<summary>
	///Titolo
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
	///Sottotitolo
	///</summary>
	public String title2{ 
		get {if (this["title2"]==DBNull.Value)return null; return  (String)this["title2"];}
		set {if (value==null) this["title2"]= DBNull.Value; else this["title2"]= value;}
	}
	public object title2Value { 
		get{ return this["title2"];}
		set {if (value==null|| value==DBNull.Value) this["title2"]= DBNull.Value; else this["title2"]= value;}
	}
	public String title2Original { 
		get {if (this["title2",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["title2",DataRowVersion.Original];}
	}
	public String volume{ 
		get {if (this["volume"]==DBNull.Value)return null; return  (String)this["volume"];}
		set {if (value==null) this["volume"]= DBNull.Value; else this["volume"]= value;}
	}
	public object volumeValue { 
		get{ return this["volume"];}
		set {if (value==null|| value==DBNull.Value) this["volume"]= DBNull.Value; else this["volume"]= value;}
	}
	public String volumeOriginal { 
		get {if (this["volume",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["volume",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///2.4.27 pubblicazione
///</summary>
public class publicazTable : MetaTableBase<publicazRow> {
	public publicazTable() : base("publicaz"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"abstractstring",createColumn("abstractstring",typeof(string),true,false)},
			{"annocopyright",createColumn("annocopyright",typeof(int),true,false)},
			{"annopub",createColumn("annopub",typeof(int),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"editore",createColumn("editore",typeof(string),true,false)},
			{"fascicolo",createColumn("fascicolo",typeof(string),true,false)},
			{"idcity",createColumn("idcity",typeof(int),true,false)},
			{"idcity_ed",createColumn("idcity_ed",typeof(int),true,false)},
			{"idnation_ed",createColumn("idnation_ed",typeof(int),true,false)},
			{"idnation_lang",createColumn("idnation_lang",typeof(int),true,false)},
			{"idpublicaz",createColumn("idpublicaz",typeof(int),false,false)},
			{"isbn",createColumn("isbn",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"numrivista",createColumn("numrivista",typeof(int),true,false)},
			{"pagestart",createColumn("pagestart",typeof(int),true,false)},
			{"pagestop",createColumn("pagestop",typeof(int),true,false)},
			{"pagetot",createColumn("pagetot",typeof(int),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
			{"title2",createColumn("title2",typeof(string),true,false)},
			{"volume",createColumn("volume",typeof(string),true,false)},
		};
	}
}
}
