/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
namespace meta_stip_corsolaurea {
public class stip_corsolaureaRow: MetaRow  {
	public stip_corsolaureaRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///#
	///</summary>
	public Int32? idstipcorsolaurea{ 
		get {if (this["idstipcorsolaurea"]==DBNull.Value)return null; return  (Int32?)this["idstipcorsolaurea"];}
		set {if (value==null) this["idstipcorsolaurea"]= DBNull.Value; else this["idstipcorsolaurea"]= value;}
	}
	public object idstipcorsolaureaValue { 
		get{ return this["idstipcorsolaurea"];}
		set {if (value==null|| value==DBNull.Value) this["idstipcorsolaurea"]= DBNull.Value; else this["idstipcorsolaurea"]= value;}
	}
	public Int32? idstipcorsolaureaOriginal { 
		get {if (this["idstipcorsolaurea",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idstipcorsolaurea",DataRowVersion.Original];}
	}
	///<summary>
	///Codice corso di laurea
	///</summary>
	public String codicecorsolaurea{ 
		get {if (this["codicecorsolaurea"]==DBNull.Value)return null; return  (String)this["codicecorsolaurea"];}
		set {if (value==null) this["codicecorsolaurea"]= DBNull.Value; else this["codicecorsolaurea"]= value;}
	}
	public object codicecorsolaureaValue { 
		get{ return this["codicecorsolaurea"];}
		set {if (value==null|| value==DBNull.Value) this["codicecorsolaurea"]= DBNull.Value; else this["codicecorsolaurea"]= value;}
	}
	public String codicecorsolaureaOriginal { 
		get {if (this["codicecorsolaurea",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicecorsolaurea",DataRowVersion.Original];}
	}
	///<summary>
	///Descrizione corso laurea
	///</summary>
	public String descrizionecorsolaurea{ 
		get {if (this["descrizionecorsolaurea"]==DBNull.Value)return null; return  (String)this["descrizionecorsolaurea"];}
		set {if (value==null) this["descrizionecorsolaurea"]= DBNull.Value; else this["descrizionecorsolaurea"]= value;}
	}
	public object descrizionecorsolaureaValue { 
		get{ return this["descrizionecorsolaurea"];}
		set {if (value==null|| value==DBNull.Value) this["descrizionecorsolaurea"]= DBNull.Value; else this["descrizionecorsolaurea"]= value;}
	}
	public String descrizionecorsolaureaOriginal { 
		get {if (this["descrizionecorsolaurea",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["descrizionecorsolaurea",DataRowVersion.Original];}
	}
	///<summary>
	///Codice dipartimento
	///</summary>
	public String codicedipartimento{ 
		get {if (this["codicedipartimento"]==DBNull.Value)return null; return  (String)this["codicedipartimento"];}
		set {if (value==null) this["codicedipartimento"]= DBNull.Value; else this["codicedipartimento"]= value;}
	}
	public object codicedipartimentoValue { 
		get{ return this["codicedipartimento"];}
		set {if (value==null|| value==DBNull.Value) this["codicedipartimento"]= DBNull.Value; else this["codicedipartimento"]= value;}
	}
	public String codicedipartimentoOriginal { 
		get {if (this["codicedipartimento",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicedipartimento",DataRowVersion.Original];}
	}
	///<summary>
	///Dipartimento
	///</summary>
	public String dipartimento{ 
		get {if (this["dipartimento"]==DBNull.Value)return null; return  (String)this["dipartimento"];}
		set {if (value==null) this["dipartimento"]= DBNull.Value; else this["dipartimento"]= value;}
	}
	public object dipartimentoValue { 
		get{ return this["dipartimento"];}
		set {if (value==null|| value==DBNull.Value) this["dipartimento"]= DBNull.Value; else this["dipartimento"]= value;}
	}
	public String dipartimentoOriginal { 
		get {if (this["dipartimento",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["dipartimento",DataRowVersion.Original];}
	}
	///<summary>
	///Codice sede
	///</summary>
	public String codicesede{ 
		get {if (this["codicesede"]==DBNull.Value)return null; return  (String)this["codicesede"];}
		set {if (value==null) this["codicesede"]= DBNull.Value; else this["codicesede"]= value;}
	}
	public object codicesedeValue { 
		get{ return this["codicesede"];}
		set {if (value==null|| value==DBNull.Value) this["codicesede"]= DBNull.Value; else this["codicesede"]= value;}
	}
	public String codicesedeOriginal { 
		get {if (this["codicesede",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicesede",DataRowVersion.Original];}
	}
	///<summary>
	///Sede
	///</summary>
	public String sede{ 
		get {if (this["sede"]==DBNull.Value)return null; return  (String)this["sede"];}
		set {if (value==null) this["sede"]= DBNull.Value; else this["sede"]= value;}
	}
	public object sedeValue { 
		get{ return this["sede"];}
		set {if (value==null|| value==DBNull.Value) this["sede"]= DBNull.Value; else this["sede"]= value;}
	}
	public String sedeOriginal { 
		get {if (this["sede",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["sede",DataRowVersion.Original];}
	}
	///<summary>
	///Codice percorso
	///</summary>
	public String codicepercorso{ 
		get {if (this["codicepercorso"]==DBNull.Value)return null; return  (String)this["codicepercorso"];}
		set {if (value==null) this["codicepercorso"]= DBNull.Value; else this["codicepercorso"]= value;}
	}
	public object codicepercorsoValue { 
		get{ return this["codicepercorso"];}
		set {if (value==null|| value==DBNull.Value) this["codicepercorso"]= DBNull.Value; else this["codicepercorso"]= value;}
	}
	public String codicepercorsoOriginal { 
		get {if (this["codicepercorso",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicepercorso",DataRowVersion.Original];}
	}
	///<summary>
	///Percorso di laurea
	///</summary>
	public String percorso{ 
		get {if (this["percorso"]==DBNull.Value)return null; return  (String)this["percorso"];}
		set {if (value==null) this["percorso"]= DBNull.Value; else this["percorso"]= value;}
	}
	public object percorsoValue { 
		get{ return this["percorso"];}
		set {if (value==null|| value==DBNull.Value) this["percorso"]= DBNull.Value; else this["percorso"]= value;}
	}
	public String percorsoOriginal { 
		get {if (this["percorso",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["percorso",DataRowVersion.Original];}
	}
	///<summary>
	///anno
	///</summary>
	public Int32? anno{ 
		get {if (this["anno"]==DBNull.Value)return null; return  (Int32?)this["anno"];}
		set {if (value==null) this["anno"]= DBNull.Value; else this["anno"]= value;}
	}
	public object annoValue { 
		get{ return this["anno"];}
		set {if (value==null|| value==DBNull.Value) this["anno"]= DBNull.Value; else this["anno"]= value;}
	}
	public Int32? annoOriginal { 
		get {if (this["anno",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["anno",DataRowVersion.Original];}
	}
	///<summary>
	///id voce upb (tabella upb)
	///</summary>
	public String idupb{ 
		get {if (this["idupb"]==DBNull.Value)return null; return  (String)this["idupb"];}
		set {if (value==null) this["idupb"]= DBNull.Value; else this["idupb"]= value;}
	}
	public object idupbValue { 
		get{ return this["idupb"];}
		set {if (value==null|| value==DBNull.Value) this["idupb"]= DBNull.Value; else this["idupb"]= value;}
	}
	public String idupbOriginal { 
		get {if (this["idupb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idupb",DataRowVersion.Original];}
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
	///Descrizione
	///</summary>
	public String descrizione{ 
		get {if (this["descrizione"]==DBNull.Value)return null; return  (String)this["descrizione"];}
		set {if (value==null) this["descrizione"]= DBNull.Value; else this["descrizione"]= value;}
	}
	public object descrizioneValue { 
		get{ return this["descrizione"];}
		set {if (value==null|| value==DBNull.Value) this["descrizione"]= DBNull.Value; else this["descrizione"]= value;}
	}
	public String descrizioneOriginal { 
		get {if (this["descrizione",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["descrizione",DataRowVersion.Original];}
	}
	public String codicecausale{ 
		get {if (this["codicecausale"]==DBNull.Value)return null; return  (String)this["codicecausale"];}
		set {if (value==null) this["codicecausale"]= DBNull.Value; else this["codicecausale"]= value;}
	}
	public object codicecausaleValue { 
		get{ return this["codicecausale"];}
		set {if (value==null|| value==DBNull.Value) this["codicecausale"]= DBNull.Value; else this["codicecausale"]= value;}
	}
	public String codicecausaleOriginal { 
		get {if (this["codicecausale",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicecausale",DataRowVersion.Original];}
	}
	public String causale{ 
		get {if (this["causale"]==DBNull.Value)return null; return  (String)this["causale"];}
		set {if (value==null) this["causale"]= DBNull.Value; else this["causale"]= value;}
	}
	public object causaleValue { 
		get{ return this["causale"];}
		set {if (value==null|| value==DBNull.Value) this["causale"]= DBNull.Value; else this["causale"]= value;}
	}
	public String causaleOriginal { 
		get {if (this["causale",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["causale",DataRowVersion.Original];}
	}
	public Int32? idstiptassa{ 
		get {if (this["idstiptassa"]==DBNull.Value)return null; return  (Int32?)this["idstiptassa"];}
		set {if (value==null) this["idstiptassa"]= DBNull.Value; else this["idstiptassa"]= value;}
	}
	public object idstiptassaValue { 
		get{ return this["idstiptassa"];}
		set {if (value==null|| value==DBNull.Value) this["idstiptassa"]= DBNull.Value; else this["idstiptassa"]= value;}
	}
	public Int32? idstiptassaOriginal { 
		get {if (this["idstiptassa",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idstiptassa",DataRowVersion.Original];}
	}
	public Int32? idstipvoce{ 
		get {if (this["idstipvoce"]==DBNull.Value)return null; return  (Int32?)this["idstipvoce"];}
		set {if (value==null) this["idstipvoce"]= DBNull.Value; else this["idstipvoce"]= value;}
	}
	public object idstipvoceValue { 
		get{ return this["idstipvoce"];}
		set {if (value==null|| value==DBNull.Value) this["idstipvoce"]= DBNull.Value; else this["idstipvoce"]= value;}
	}
	public Int32? idstipvoceOriginal { 
		get {if (this["idstipvoce",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idstipvoce",DataRowVersion.Original];}
	}
	public Int32? idsor1{ 
		get {if (this["idsor1"]==DBNull.Value)return null; return  (Int32?)this["idsor1"];}
		set {if (value==null) this["idsor1"]= DBNull.Value; else this["idsor1"]= value;}
	}
	public object idsor1Value { 
		get{ return this["idsor1"];}
		set {if (value==null|| value==DBNull.Value) this["idsor1"]= DBNull.Value; else this["idsor1"]= value;}
	}
	public Int32? idsor1Original { 
		get {if (this["idsor1",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor1",DataRowVersion.Original];}
	}
	public Int32? idsor2{ 
		get {if (this["idsor2"]==DBNull.Value)return null; return  (Int32?)this["idsor2"];}
		set {if (value==null) this["idsor2"]= DBNull.Value; else this["idsor2"]= value;}
	}
	public object idsor2Value { 
		get{ return this["idsor2"];}
		set {if (value==null|| value==DBNull.Value) this["idsor2"]= DBNull.Value; else this["idsor2"]= value;}
	}
	public Int32? idsor2Original { 
		get {if (this["idsor2",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor2",DataRowVersion.Original];}
	}
	public Int32? idsor3{ 
		get {if (this["idsor3"]==DBNull.Value)return null; return  (Int32?)this["idsor3"];}
		set {if (value==null) this["idsor3"]= DBNull.Value; else this["idsor3"]= value;}
	}
	public object idsor3Value { 
		get{ return this["idsor3"];}
		set {if (value==null|| value==DBNull.Value) this["idsor3"]= DBNull.Value; else this["idsor3"]= value;}
	}
	public Int32? idsor3Original { 
		get {if (this["idsor3",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor3",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///elenco corsi laurea prog. esterno gestione studenti
///</summary>
public class stip_corsolaureaTable : MetaTableBase<stip_corsolaureaRow> {
	public stip_corsolaureaTable() : base("stip_corsolaurea"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idstipcorsolaurea",createColumn("idstipcorsolaurea",typeof(int),false,false)},
			{"codicecorsolaurea",createColumn("codicecorsolaurea",typeof(string),false,false)},
			{"descrizionecorsolaurea",createColumn("descrizionecorsolaurea",typeof(string),true,false)},
			{"codicedipartimento",createColumn("codicedipartimento",typeof(string),false,false)},
			{"dipartimento",createColumn("dipartimento",typeof(string),true,false)},
			{"codicesede",createColumn("codicesede",typeof(string),false,false)},
			{"sede",createColumn("sede",typeof(string),true,false)},
			{"codicepercorso",createColumn("codicepercorso",typeof(string),false,false)},
			{"percorso",createColumn("percorso",typeof(string),true,false)},
			{"anno",createColumn("anno",typeof(int),true,false)},
			{"idupb",createColumn("idupb",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"descrizione",createColumn("descrizione",typeof(string),true,false)},
			{"codicecausale",createColumn("codicecausale",typeof(string),true,false)},
			{"causale",createColumn("causale",typeof(string),true,false)},
			{"idstiptassa",createColumn("idstiptassa",typeof(int),true,false)},
			{"idstipvoce",createColumn("idstipvoce",typeof(int),true,false)},
			{"idsor1",createColumn("idsor1",typeof(int),true,false)},
			{"idsor2",createColumn("idsor2",typeof(int),true,false)},
			{"idsor3",createColumn("idsor3",typeof(int),true,false)},
		};
	}
}
}
