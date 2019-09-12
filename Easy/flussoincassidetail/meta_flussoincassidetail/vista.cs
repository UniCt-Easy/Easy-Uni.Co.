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
namespace meta_flussoincassidetail {
public class flussoincassidetailRow: MetaRow  {
	public flussoincassidetailRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///#
	///</summary>
	public Int32? idflusso{ 
		get {if (this["idflusso"]==DBNull.Value)return null; return  (Int32?)this["idflusso"];}
		set {if (value==null) this["idflusso"]= DBNull.Value; else this["idflusso"]= value;}
	}
	public object idflussoValue { 
		get{ return this["idflusso"];}
		set {if (value==null|| value==DBNull.Value) this["idflusso"]= DBNull.Value; else this["idflusso"]= value;}
	}
	public Int32? idflussoOriginal { 
		get {if (this["idflusso",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idflusso",DataRowVersion.Original];}
	}
	///<summary>
	///n. dettaglio
	///</summary>
	public Int32? iddetail{ 
		get {if (this["iddetail"]==DBNull.Value)return null; return  (Int32?)this["iddetail"];}
		set {if (value==null) this["iddetail"]= DBNull.Value; else this["iddetail"]= value;}
	}
	public object iddetailValue { 
		get{ return this["iddetail"];}
		set {if (value==null|| value==DBNull.Value) this["iddetail"]= DBNull.Value; else this["iddetail"]= value;}
	}
	public Int32? iddetailOriginal { 
		get {if (this["iddetail",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddetail",DataRowVersion.Original];}
	}
	///<summary>
	///codice bollettino univoco o IUV
	///</summary>
	public String iduniqueformcode{ 
		get {if (this["iduniqueformcode"]==DBNull.Value)return null; return  (String)this["iduniqueformcode"];}
		set {if (value==null) this["iduniqueformcode"]= DBNull.Value; else this["iduniqueformcode"]= value;}
	}
	public object iduniqueformcodeValue { 
		get{ return this["iduniqueformcode"];}
		set {if (value==null|| value==DBNull.Value) this["iduniqueformcode"]= DBNull.Value; else this["iduniqueformcode"]= value;}
	}
	public String iduniqueformcodeOriginal { 
		get {if (this["iduniqueformcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["iduniqueformcode",DataRowVersion.Original];}
	}
	///<summary>
	///IUV dell'incasso
	///</summary>
	public String iuv{ 
		get {if (this["iuv"]==DBNull.Value)return null; return  (String)this["iuv"];}
		set {if (value==null) this["iuv"]= DBNull.Value; else this["iuv"]= value;}
	}
	public object iuvValue { 
		get{ return this["iuv"];}
		set {if (value==null|| value==DBNull.Value) this["iuv"]= DBNull.Value; else this["iuv"]= value;}
	}
	public String iuvOriginal { 
		get {if (this["iuv",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["iuv",DataRowVersion.Original];}
	}
	///<summary>
	///Importo, deve corrispondere alla somma dei crediti con pari IUV
	///</summary>
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
	///Codice fiscale
	///</summary>
	public String cf{ 
		get {if (this["cf"]==DBNull.Value)return null; return  (String)this["cf"];}
		set {if (value==null) this["cf"]= DBNull.Value; else this["cf"]= value;}
	}
	public object cfValue { 
		get{ return this["cf"];}
		set {if (value==null|| value==DBNull.Value) this["cf"]= DBNull.Value; else this["cf"]= value;}
	}
	public String cfOriginal { 
		get {if (this["cf",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cf",DataRowVersion.Original];}
	}
	public String p_iva{ 
		get {if (this["p_iva"]==DBNull.Value)return null; return  (String)this["p_iva"];}
		set {if (value==null) this["p_iva"]= DBNull.Value; else this["p_iva"]= value;}
	}
	public object p_ivaValue { 
		get{ return this["p_iva"];}
		set {if (value==null|| value==DBNull.Value) this["p_iva"]= DBNull.Value; else this["p_iva"]= value;}
	}
	public String p_ivaOriginal { 
		get {if (this["p_iva",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["p_iva",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///dettaglio flusso incassi
///</summary>
public class flussoincassidetailTable : MetaTableBase<flussoincassidetailRow> {
	public flussoincassidetailTable() : base("flussoincassidetail"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idflusso",createColumn("idflusso",typeof(int),false,false)},
			{"iddetail",createColumn("iddetail",typeof(int),false,false)},
			{"iduniqueformcode",createColumn("iduniqueformcode",typeof(string),true,false)},
			{"iuv",createColumn("iuv",typeof(string),true,false)},
			{"importo",createColumn("importo",typeof(decimal),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"cf",createColumn("cf",typeof(string),true,false)},
			{"p_iva",createColumn("p_iva",typeof(string),true,false)},
		};
	}
}
}
