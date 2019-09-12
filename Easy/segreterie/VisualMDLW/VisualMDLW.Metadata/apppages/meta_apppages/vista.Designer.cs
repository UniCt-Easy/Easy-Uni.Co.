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
namespace meta_apppages {
public class apppagesRow: MetaRow  {
	public apppagesRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public String anonimous{ 
		get {if (this["anonimous"]==DBNull.Value)return null; return  (String)this["anonimous"];}
		set {if (value==null) this["anonimous"]= DBNull.Value; else this["anonimous"]= value;}
	}
	public object anonimousValue { 
		get{ return this["anonimous"];}
		set {if (value==null|| value==DBNull.Value) this["anonimous"]= DBNull.Value; else this["anonimous"]= value;}
	}
	public String anonimousOriginal { 
		get {if (this["anonimous",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["anonimous",DataRowVersion.Original];}
	}
	///<summary>
	///Ricerca automatica all'apertura
	///</summary>
	public String autosearch{ 
		get {if (this["autosearch"]==DBNull.Value)return null; return  (String)this["autosearch"];}
		set {if (value==null) this["autosearch"]= DBNull.Value; else this["autosearch"]= value;}
	}
	public object autosearchValue { 
		get{ return this["autosearch"];}
		set {if (value==null|| value==DBNull.Value) this["autosearch"]= DBNull.Value; else this["autosearch"]= value;}
	}
	public String autosearchOriginal { 
		get {if (this["autosearch",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["autosearch",DataRowVersion.Original];}
	}
	///<summary>
	///Abilita il tasto Elimina
	///</summary>
	public String cancancel{ 
		get {if (this["cancancel"]==DBNull.Value)return null; return  (String)this["cancancel"];}
		set {if (value==null) this["cancancel"]= DBNull.Value; else this["cancancel"]= value;}
	}
	public object cancancelValue { 
		get{ return this["cancancel"];}
		set {if (value==null|| value==DBNull.Value) this["cancancel"]= DBNull.Value; else this["cancancel"]= value;}
	}
	public String cancancelOriginal { 
		get {if (this["cancancel",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cancancel",DataRowVersion.Original];}
	}
	public String cancmdclose{ 
		get {if (this["cancmdclose"]==DBNull.Value)return null; return  (String)this["cancmdclose"];}
		set {if (value==null) this["cancmdclose"]= DBNull.Value; else this["cancmdclose"]= value;}
	}
	public object cancmdcloseValue { 
		get{ return this["cancmdclose"];}
		set {if (value==null|| value==DBNull.Value) this["cancmdclose"]= DBNull.Value; else this["cancmdclose"]= value;}
	}
	public String cancmdcloseOriginal { 
		get {if (this["cancmdclose",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cancmdclose",DataRowVersion.Original];}
	}
	///<summary>
	///Abilita il tasto Nuovo
	///</summary>
	public String caninsert{ 
		get {if (this["caninsert"]==DBNull.Value)return null; return  (String)this["caninsert"];}
		set {if (value==null) this["caninsert"]= DBNull.Value; else this["caninsert"]= value;}
	}
	public object caninsertValue { 
		get{ return this["caninsert"];}
		set {if (value==null|| value==DBNull.Value) this["caninsert"]= DBNull.Value; else this["caninsert"]= value;}
	}
	public String caninsertOriginal { 
		get {if (this["caninsert",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["caninsert",DataRowVersion.Original];}
	}
	///<summary>
	///Abilita il tasto Copia
	///</summary>
	public String caninsertcopy{ 
		get {if (this["caninsertcopy"]==DBNull.Value)return null; return  (String)this["caninsertcopy"];}
		set {if (value==null) this["caninsertcopy"]= DBNull.Value; else this["caninsertcopy"]= value;}
	}
	public object caninsertcopyValue { 
		get{ return this["caninsertcopy"];}
		set {if (value==null|| value==DBNull.Value) this["caninsertcopy"]= DBNull.Value; else this["caninsertcopy"]= value;}
	}
	public String caninsertcopyOriginal { 
		get {if (this["caninsertcopy",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["caninsertcopy",DataRowVersion.Original];}
	}
	public String cansave{ 
		get {if (this["cansave"]==DBNull.Value)return null; return  (String)this["cansave"];}
		set {if (value==null) this["cansave"]= DBNull.Value; else this["cansave"]= value;}
	}
	public object cansaveValue { 
		get{ return this["cansave"];}
		set {if (value==null|| value==DBNull.Value) this["cansave"]= DBNull.Value; else this["cansave"]= value;}
	}
	public String cansaveOriginal { 
		get {if (this["cansave",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cansave",DataRowVersion.Original];}
	}
	///<summary>
	///Abilita il tasto Cerca
	///</summary>
	public String cansearch{ 
		get {if (this["cansearch"]==DBNull.Value)return null; return  (String)this["cansearch"];}
		set {if (value==null) this["cansearch"]= DBNull.Value; else this["cansearch"]= value;}
	}
	public object cansearchValue { 
		get{ return this["cansearch"];}
		set {if (value==null|| value==DBNull.Value) this["cansearch"]= DBNull.Value; else this["cansearch"]= value;}
	}
	public String cansearchOriginal { 
		get {if (this["cansearch",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cansearch",DataRowVersion.Original];}
	}
	public String canshowlast{ 
		get {if (this["canshowlast"]==DBNull.Value)return null; return  (String)this["canshowlast"];}
		set {if (value==null) this["canshowlast"]= DBNull.Value; else this["canshowlast"]= value;}
	}
	public object canshowlastValue { 
		get{ return this["canshowlast"];}
		set {if (value==null|| value==DBNull.Value) this["canshowlast"]= DBNull.Value; else this["canshowlast"]= value;}
	}
	public String canshowlastOriginal { 
		get {if (this["canshowlast",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["canshowlast",DataRowVersion.Original];}
	}
	///<summary>
	///Codice aggiuntivo c#
	///</summary>
	public String customcode{ 
		get {if (this["customcode"]==DBNull.Value)return null; return  (String)this["customcode"];}
		set {if (value==null) this["customcode"]= DBNull.Value; else this["customcode"]= value;}
	}
	public object customcodeValue { 
		get{ return this["customcode"];}
		set {if (value==null|| value==DBNull.Value) this["customcode"]= DBNull.Value; else this["customcode"]= value;}
	}
	public String customcodeOriginal { 
		get {if (this["customcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["customcode",DataRowVersion.Original];}
	}
	///<summary>
	///Codice aggiuntivo Javascript
	///</summary>
	public String customjavascript{ 
		get {if (this["customjavascript"]==DBNull.Value)return null; return  (String)this["customjavascript"];}
		set {if (value==null) this["customjavascript"]= DBNull.Value; else this["customjavascript"]= value;}
	}
	public object customjavascriptValue { 
		get{ return this["customjavascript"];}
		set {if (value==null|| value==DBNull.Value) this["customjavascript"]= DBNull.Value; else this["customjavascript"]= value;}
	}
	public String customjavascriptOriginal { 
		get {if (this["customjavascript",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["customjavascript",DataRowVersion.Original];}
	}
	///<summary>
	///Reference aggiuntive nel metadato c#
	///</summary>
	public String customreference{ 
		get {if (this["customreference"]==DBNull.Value)return null; return  (String)this["customreference"];}
		set {if (value==null) this["customreference"]= DBNull.Value; else this["customreference"]= value;}
	}
	public object customreferenceValue { 
		get{ return this["customreference"];}
		set {if (value==null|| value==DBNull.Value) this["customreference"]= DBNull.Value; else this["customreference"]= value;}
	}
	public String customreferenceOriginal { 
		get {if (this["customreference",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["customreference",DataRowVersion.Original];}
	}
	///<summary>
	///Using aggiuntivi
	///</summary>
	public String customusing{ 
		get {if (this["customusing"]==DBNull.Value)return null; return  (String)this["customusing"];}
		set {if (value==null) this["customusing"]= DBNull.Value; else this["customusing"]= value;}
	}
	public object customusingValue { 
		get{ return this["customusing"];}
		set {if (value==null|| value==DBNull.Value) this["customusing"]= DBNull.Value; else this["customusing"]= value;}
	}
	public String customusingOriginal { 
		get {if (this["customusing",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["customusing",DataRowVersion.Original];}
	}
	///<summary>
	///Edit Listing Type
	///</summary>
	public String editlistingtype{ 
		get {if (this["editlistingtype"]==DBNull.Value)return null; return  (String)this["editlistingtype"];}
		set {if (value==null) this["editlistingtype"]= DBNull.Value; else this["editlistingtype"]= value;}
	}
	public object editlistingtypeValue { 
		get{ return this["editlistingtype"];}
		set {if (value==null|| value==DBNull.Value) this["editlistingtype"]= DBNull.Value; else this["editlistingtype"]= value;}
	}
	public String editlistingtypeOriginal { 
		get {if (this["editlistingtype",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["editlistingtype",DataRowVersion.Original];}
	}
	///<summary>
	///Piè di pagina
	///</summary>
	public String footer{ 
		get {if (this["footer"]==DBNull.Value)return null; return  (String)this["footer"];}
		set {if (value==null) this["footer"]= DBNull.Value; else this["footer"]= value;}
	}
	public object footerValue { 
		get{ return this["footer"];}
		set {if (value==null|| value==DBNull.Value) this["footer"]= DBNull.Value; else this["footer"]= value;}
	}
	public String footerOriginal { 
		get {if (this["footer",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["footer",DataRowVersion.Original];}
	}
	///<summary>
	///Intestazione
	///</summary>
	public String header{ 
		get {if (this["header"]==DBNull.Value)return null; return  (String)this["header"];}
		set {if (value==null) this["header"]= DBNull.Value; else this["header"]= value;}
	}
	public object headerValue { 
		get{ return this["header"];}
		set {if (value==null|| value==DBNull.Value) this["header"]= DBNull.Value; else this["header"]= value;}
	}
	public String headerOriginal { 
		get {if (this["header",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["header",DataRowVersion.Original];}
	}
	///<summary>
	///Icona
	///</summary>
	public String icon{ 
		get {if (this["icon"]==DBNull.Value)return null; return  (String)this["icon"];}
		set {if (value==null) this["icon"]= DBNull.Value; else this["icon"]= value;}
	}
	public object iconValue { 
		get{ return this["icon"];}
		set {if (value==null|| value==DBNull.Value) this["icon"]= DBNull.Value; else this["icon"]= value;}
	}
	public String iconOriginal { 
		get {if (this["icon",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["icon",DataRowVersion.Original];}
	}
	///<summary>
	///Applicazione
	///</summary>
	public Int32? idapplicazione{ 
		get {if (this["idapplicazione"]==DBNull.Value)return null; return  (Int32?)this["idapplicazione"];}
		set {if (value==null) this["idapplicazione"]= DBNull.Value; else this["idapplicazione"]= value;}
	}
	public object idapplicazioneValue { 
		get{ return this["idapplicazione"];}
		set {if (value==null|| value==DBNull.Value) this["idapplicazione"]= DBNull.Value; else this["idapplicazione"]= value;}
	}
	public Int32? idapplicazioneOriginal { 
		get {if (this["idapplicazione",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idapplicazione",DataRowVersion.Original];}
	}
	///<summary>
	///Identificativo
	///</summary>
	public Int32? idapppages{ 
		get {if (this["idapppages"]==DBNull.Value)return null; return  (Int32?)this["idapppages"];}
		set {if (value==null) this["idapppages"]= DBNull.Value; else this["idapppages"]= value;}
	}
	public object idapppagesValue { 
		get{ return this["idapppages"];}
		set {if (value==null|| value==DBNull.Value) this["idapppages"]= DBNull.Value; else this["idapppages"]= value;}
	}
	public Int32? idapppagesOriginal { 
		get {if (this["idapppages",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idapppages",DataRowVersion.Original];}
	}
	///<summary>
	///Voce di Menù madre
	///</summary>
	public Int32? idmenuweb{ 
		get {if (this["idmenuweb"]==DBNull.Value)return null; return  (Int32?)this["idmenuweb"];}
		set {if (value==null) this["idmenuweb"]= DBNull.Value; else this["idmenuweb"]= value;}
	}
	public object idmenuwebValue { 
		get{ return this["idmenuweb"];}
		set {if (value==null|| value==DBNull.Value) this["idmenuweb"]= DBNull.Value; else this["idmenuweb"]= value;}
	}
	public Int32? idmenuwebOriginal { 
		get {if (this["idmenuweb",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idmenuweb",DataRowVersion.Original];}
	}
	public String isvalid{ 
		get {if (this["isvalid"]==DBNull.Value)return null; return  (String)this["isvalid"];}
		set {if (value==null) this["isvalid"]= DBNull.Value; else this["isvalid"]= value;}
	}
	public object isvalidValue { 
		get{ return this["isvalid"];}
		set {if (value==null|| value==DBNull.Value) this["isvalid"]= DBNull.Value; else this["isvalid"]= value;}
	}
	public String isvalidOriginal { 
		get {if (this["isvalid",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["isvalid",DataRowVersion.Original];}
	}
	public String othersapp{ 
		get {if (this["othersapp"]==DBNull.Value)return null; return  (String)this["othersapp"];}
		set {if (value==null) this["othersapp"]= DBNull.Value; else this["othersapp"]= value;}
	}
	public object othersappValue { 
		get{ return this["othersapp"];}
		set {if (value==null|| value==DBNull.Value) this["othersapp"]= DBNull.Value; else this["othersapp"]= value;}
	}
	public String othersappOriginal { 
		get {if (this["othersapp",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["othersapp",DataRowVersion.Original];}
	}
	public String principale{ 
		get {if (this["principale"]==DBNull.Value)return null; return  (String)this["principale"];}
		set {if (value==null) this["principale"]= DBNull.Value; else this["principale"]= value;}
	}
	public object principaleValue { 
		get{ return this["principale"];}
		set {if (value==null|| value==DBNull.Value) this["principale"]= DBNull.Value; else this["principale"]= value;}
	}
	public String principaleOriginal { 
		get {if (this["principale",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["principale",DataRowVersion.Original];}
	}
	///<summary>
	///Filtro statico sul metadato applicato alle query
	///</summary>
	public String staticfilter{ 
		get {if (this["staticfilter"]==DBNull.Value)return null; return  (String)this["staticfilter"];}
		set {if (value==null) this["staticfilter"]= DBNull.Value; else this["staticfilter"]= value;}
	}
	public object staticfilterValue { 
		get{ return this["staticfilter"];}
		set {if (value==null|| value==DBNull.Value) this["staticfilter"]= DBNull.Value; else this["staticfilter"]= value;}
	}
	public String staticfilterOriginal { 
		get {if (this["staticfilter",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["staticfilter",DataRowVersion.Original];}
	}
	///<summary>
	///Tabella
	///</summary>
	public String tablename{ 
		get {if (this["tablename"]==DBNull.Value)return null; return  (String)this["tablename"];}
		set {if (value==null) this["tablename"]= DBNull.Value; else this["tablename"]= value;}
	}
	public object tablenameValue { 
		get{ return this["tablename"];}
		set {if (value==null|| value==DBNull.Value) this["tablename"]= DBNull.Value; else this["tablename"]= value;}
	}
	public String tablenameOriginal { 
		get {if (this["tablename",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tablename",DataRowVersion.Original];}
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
	public String vocabolario{ 
		get {if (this["vocabolario"]==DBNull.Value)return null; return  (String)this["vocabolario"];}
		set {if (value==null) this["vocabolario"]= DBNull.Value; else this["vocabolario"]= value;}
	}
	public object vocabolarioValue { 
		get{ return this["vocabolario"];}
		set {if (value==null|| value==DBNull.Value) this["vocabolario"]= DBNull.Value; else this["vocabolario"]= value;}
	}
	public String vocabolarioOriginal { 
		get {if (this["vocabolario",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["vocabolario",DataRowVersion.Original];}
	}
	#endregion

}
public class apppagesTable : MetaTableBase<apppagesRow> {
	public apppagesTable() : base("apppages"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"anonimous",createColumn("anonimous",typeof(string),true,false)},
			{"autosearch",createColumn("autosearch",typeof(string),false,false)},
			{"cancancel",createColumn("cancancel",typeof(string),false,false)},
			{"cancmdclose",createColumn("cancmdclose",typeof(string),true,false)},
			{"caninsert",createColumn("caninsert",typeof(string),false,false)},
			{"caninsertcopy",createColumn("caninsertcopy",typeof(string),false,false)},
			{"cansave",createColumn("cansave",typeof(string),false,false)},
			{"cansearch",createColumn("cansearch",typeof(string),false,false)},
			{"canshowlast",createColumn("canshowlast",typeof(string),false,false)},
			{"customcode",createColumn("customcode",typeof(string),true,false)},
			{"customjavascript",createColumn("customjavascript",typeof(string),true,false)},
			{"customreference",createColumn("customreference",typeof(string),true,false)},
			{"customusing",createColumn("customusing",typeof(string),true,false)},
			{"editlistingtype",createColumn("editlistingtype",typeof(string),true,false)},
			{"footer",createColumn("footer",typeof(string),true,false)},
			{"header",createColumn("header",typeof(string),true,false)},
			{"icon",createColumn("icon",typeof(string),true,false)},
			{"idapplicazione",createColumn("idapplicazione",typeof(int),true,false)},
			{"idapppages",createColumn("idapppages",typeof(int),false,false)},
			{"idmenuweb",createColumn("idmenuweb",typeof(int),true,false)},
			{"isvalid",createColumn("isvalid",typeof(string),true,false)},
			{"othersapp",createColumn("othersapp",typeof(string),true,false)},
			{"principale",createColumn("principale",typeof(string),true,false)},
			{"staticfilter",createColumn("staticfilter",typeof(string),true,false)},
			{"tablename",createColumn("tablename",typeof(string),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
			{"vocabolario",createColumn("vocabolario",typeof(string),true,false)},
		};
	}
}
}
