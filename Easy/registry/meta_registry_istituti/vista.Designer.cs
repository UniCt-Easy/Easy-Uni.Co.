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
namespace meta_registry_istituti {
public class registry_istitutiRow: MetaRow  {
	public registry_istitutiRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Attivo
	///</summary>
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
	///<summary>
	///Codice MIUR
	///</summary>
	public String codicemiur{ 
		get {if (this["codicemiur"]==DBNull.Value)return null; return  (String)this["codicemiur"];}
		set {if (value==null) this["codicemiur"]= DBNull.Value; else this["codicemiur"]= value;}
	}
	public object codicemiurValue { 
		get{ return this["codicemiur"];}
		set {if (value==null|| value==DBNull.Value) this["codicemiur"]= DBNull.Value; else this["codicemiur"]= value;}
	}
	public String codicemiurOriginal { 
		get {if (this["codicemiur",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicemiur",DataRowVersion.Original];}
	}
	///<summary>
	///Codice USTAT
	///</summary>
	public String codiceustat{ 
		get {if (this["codiceustat"]==DBNull.Value)return null; return  (String)this["codiceustat"];}
		set {if (value==null) this["codiceustat"]= DBNull.Value; else this["codiceustat"]= value;}
	}
	public object codiceustatValue { 
		get{ return this["codiceustat"];}
		set {if (value==null|| value==DBNull.Value) this["codiceustat"]= DBNull.Value; else this["codiceustat"]= value;}
	}
	public String codiceustatOriginal { 
		get {if (this["codiceustat",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codiceustat",DataRowVersion.Original];}
	}
	///<summary>
	///Comune
	///</summary>
	public String comune{ 
		get {if (this["comune"]==DBNull.Value)return null; return  (String)this["comune"];}
		set {if (value==null) this["comune"]= DBNull.Value; else this["comune"]= value;}
	}
	public object comuneValue { 
		get{ return this["comune"];}
		set {if (value==null|| value==DBNull.Value) this["comune"]= DBNull.Value; else this["comune"]= value;}
	}
	public String comuneOriginal { 
		get {if (this["comune",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["comune",DataRowVersion.Original];}
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
	///Tipologia
	///</summary>
	public Int32? idistitutokind{ 
		get {if (this["idistitutokind"]==DBNull.Value)return null; return  (Int32?)this["idistitutokind"];}
		set {if (value==null) this["idistitutokind"]= DBNull.Value; else this["idistitutokind"]= value;}
	}
	public object idistitutokindValue { 
		get{ return this["idistitutokind"];}
		set {if (value==null|| value==DBNull.Value) this["idistitutokind"]= DBNull.Value; else this["idistitutokind"]= value;}
	}
	public Int32? idistitutokindOriginal { 
		get {if (this["idistitutokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idistitutokind",DataRowVersion.Original];}
	}
	///<summary>
	///Codice USTAT
	///</summary>
	public Int32? idistitutoustat{ 
		get {if (this["idistitutoustat"]==DBNull.Value)return null; return  (Int32?)this["idistitutoustat"];}
		set {if (value==null) this["idistitutoustat"]= DBNull.Value; else this["idistitutoustat"]= value;}
	}
	public object idistitutoustatValue { 
		get{ return this["idistitutoustat"];}
		set {if (value==null|| value==DBNull.Value) this["idistitutoustat"]= DBNull.Value; else this["idistitutoustat"]= value;}
	}
	public Int32? idistitutoustatOriginal { 
		get {if (this["idistitutoustat",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idistitutoustat",DataRowVersion.Original];}
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
	///Denominazione breve
	///</summary>
	public String nome{ 
		get {if (this["nome"]==DBNull.Value)return null; return  (String)this["nome"];}
		set {if (value==null) this["nome"]= DBNull.Value; else this["nome"]= value;}
	}
	public object nomeValue { 
		get{ return this["nome"];}
		set {if (value==null|| value==DBNull.Value) this["nome"]= DBNull.Value; else this["nome"]= value;}
	}
	public String nomeOriginal { 
		get {if (this["nome",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["nome",DataRowVersion.Original];}
	}
	public Int32? sortcode{ 
		get {if (this["sortcode"]==DBNull.Value)return null; return  (Int32?)this["sortcode"];}
		set {if (value==null) this["sortcode"]= DBNull.Value; else this["sortcode"]= value;}
	}
	public object sortcodeValue { 
		get{ return this["sortcode"];}
		set {if (value==null|| value==DBNull.Value) this["sortcode"]= DBNull.Value; else this["sortcode"]= value;}
	}
	public Int32? sortcodeOriginal { 
		get {if (this["sortcode",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["sortcode",DataRowVersion.Original];}
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
	#endregion

}
public class registry_istitutiTable : MetaTableBase<registry_istitutiRow> {
	public registry_istitutiTable() : base("registry_istituti"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"active",createColumn("active",typeof(string),true,false)},
			{"codicemiur",createColumn("codicemiur",typeof(string),true,false)},
			{"codiceustat",createColumn("codiceustat",typeof(string),true,false)},
			{"comune",createColumn("comune",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idistitutokind",createColumn("idistitutokind",typeof(int),false,false)},
			{"idistitutoustat",createColumn("idistitutoustat",typeof(int),true,false)},
			{"idreg",createColumn("idreg",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"nome",createColumn("nome",typeof(string),true,false)},
			{"sortcode",createColumn("sortcode",typeof(int),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
			{"title_en",createColumn("title_en",typeof(string),true,false)},
		};
	}
}
}
