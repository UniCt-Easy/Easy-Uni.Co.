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
namespace meta_didprog {
public class didprogRow: MetaRow  {
	public didprogRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Anno accademico
	///</summary>
	public String aa{ 
		get {if (this["aa"]==DBNull.Value)return null; return  (String)this["aa"];}
		set {if (value==null) this["aa"]= DBNull.Value; else this["aa"]= value;}
	}
	public object aaValue { 
		get{ return this["aa"];}
		set {if (value==null|| value==DBNull.Value) this["aa"]= DBNull.Value; else this["aa"]= value;}
	}
	public String aaOriginal { 
		get {if (this["aa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["aa",DataRowVersion.Original];}
	}
	///<summary>
	///Anno solare
	///</summary>
	public Int32? annosolare{ 
		get {if (this["annosolare"]==DBNull.Value)return null; return  (Int32?)this["annosolare"];}
		set {if (value==null) this["annosolare"]= DBNull.Value; else this["annosolare"]= value;}
	}
	public object annosolareValue { 
		get{ return this["annosolare"];}
		set {if (value==null|| value==DBNull.Value) this["annosolare"]= DBNull.Value; else this["annosolare"]= value;}
	}
	public Int32? annosolareOriginal { 
		get {if (this["annosolare",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["annosolare",DataRowVersion.Original];}
	}
	///<summary>
	///Attribuzione eventuali crediti o debiti formativi
	///</summary>
	public String attribdebiti{ 
		get {if (this["attribdebiti"]==DBNull.Value)return null; return  (String)this["attribdebiti"];}
		set {if (value==null) this["attribdebiti"]= DBNull.Value; else this["attribdebiti"]= value;}
	}
	public object attribdebitiValue { 
		get{ return this["attribdebiti"];}
		set {if (value==null|| value==DBNull.Value) this["attribdebiti"]= DBNull.Value; else this["attribdebiti"]= value;}
	}
	public String attribdebitiOriginal { 
		get {if (this["attribdebiti",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["attribdebiti",DataRowVersion.Original];}
	}
	public Int32? ciclo{ 
		get {if (this["ciclo"]==DBNull.Value)return null; return  (Int32?)this["ciclo"];}
		set {if (value==null) this["ciclo"]= DBNull.Value; else this["ciclo"]= value;}
	}
	public object cicloValue { 
		get{ return this["ciclo"];}
		set {if (value==null|| value==DBNull.Value) this["ciclo"]= DBNull.Value; else this["ciclo"]= value;}
	}
	public Int32? cicloOriginal { 
		get {if (this["ciclo",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ciclo",DataRowVersion.Original];}
	}
	public String codice{ 
		get {if (this["codice"]==DBNull.Value)return null; return  (String)this["codice"];}
		set {if (value==null) this["codice"]= DBNull.Value; else this["codice"]= value;}
	}
	public object codiceValue { 
		get{ return this["codice"];}
		set {if (value==null|| value==DBNull.Value) this["codice"]= DBNull.Value; else this["codice"]= value;}
	}
	public String codiceOriginal { 
		get {if (this["codice",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codice",DataRowVersion.Original];}
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
	///Data del conseguimento massima per il quale è consentito iscriversi
	///</summary>
	public DateTime? dataconsmaxiscr{ 
		get {if (this["dataconsmaxiscr"]==DBNull.Value)return null; return  (DateTime?)this["dataconsmaxiscr"];}
		set {if (value==null) this["dataconsmaxiscr"]= DBNull.Value; else this["dataconsmaxiscr"]= value;}
	}
	public object dataconsmaxiscrValue { 
		get{ return this["dataconsmaxiscr"];}
		set {if (value==null|| value==DBNull.Value) this["dataconsmaxiscr"]= DBNull.Value; else this["dataconsmaxiscr"]= value;}
	}
	public DateTime? dataconsmaxiscrOriginal { 
		get {if (this["dataconsmaxiscr",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["dataconsmaxiscr",DataRowVersion.Original];}
	}
	///<summary>
	///Frequenza Obbligatoria
	///</summary>
	public String freqobbl{ 
		get {if (this["freqobbl"]==DBNull.Value)return null; return  (String)this["freqobbl"];}
		set {if (value==null) this["freqobbl"]= DBNull.Value; else this["freqobbl"]= value;}
	}
	public object freqobblValue { 
		get{ return this["freqobbl"];}
		set {if (value==null|| value==DBNull.Value) this["freqobbl"]= DBNull.Value; else this["freqobbl"]= value;}
	}
	public String freqobblOriginal { 
		get {if (this["freqobbl",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["freqobbl",DataRowVersion.Original];}
	}
	///<summary>
	///Area didattica
	///</summary>
	public Int32? idareadidattica{ 
		get {if (this["idareadidattica"]==DBNull.Value)return null; return  (Int32?)this["idareadidattica"];}
		set {if (value==null) this["idareadidattica"]= DBNull.Value; else this["idareadidattica"]= value;}
	}
	public object idareadidatticaValue { 
		get{ return this["idareadidattica"];}
		set {if (value==null|| value==DBNull.Value) this["idareadidattica"]= DBNull.Value; else this["idareadidattica"]= value;}
	}
	public Int32? idareadidatticaOriginal { 
		get {if (this["idareadidattica",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idareadidattica",DataRowVersion.Original];}
	}
	///<summary>
	///Convenzione
	///</summary>
	public Int32? idconvenzione{ 
		get {if (this["idconvenzione"]==DBNull.Value)return null; return  (Int32?)this["idconvenzione"];}
		set {if (value==null) this["idconvenzione"]= DBNull.Value; else this["idconvenzione"]= value;}
	}
	public object idconvenzioneValue { 
		get{ return this["idconvenzione"];}
		set {if (value==null|| value==DBNull.Value) this["idconvenzione"]= DBNull.Value; else this["idconvenzione"]= value;}
	}
	public Int32? idconvenzioneOriginal { 
		get {if (this["idconvenzione",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idconvenzione",DataRowVersion.Original];}
	}
	///<summary>
	///Corso di studi
	///</summary>
	public Int32? idcorsostudio{ 
		get {if (this["idcorsostudio"]==DBNull.Value)return null; return  (Int32?)this["idcorsostudio"];}
		set {if (value==null) this["idcorsostudio"]= DBNull.Value; else this["idcorsostudio"]= value;}
	}
	public object idcorsostudioValue { 
		get{ return this["idcorsostudio"];}
		set {if (value==null|| value==DBNull.Value) this["idcorsostudio"]= DBNull.Value; else this["idcorsostudio"]= value;}
	}
	public Int32? idcorsostudioOriginal { 
		get {if (this["idcorsostudio",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcorsostudio",DataRowVersion.Original];}
	}
	///<summary>
	///Identificativo
	///</summary>
	public Int32? iddidprog{ 
		get {if (this["iddidprog"]==DBNull.Value)return null; return  (Int32?)this["iddidprog"];}
		set {if (value==null) this["iddidprog"]= DBNull.Value; else this["iddidprog"]= value;}
	}
	public object iddidprogValue { 
		get{ return this["iddidprog"];}
		set {if (value==null|| value==DBNull.Value) this["iddidprog"]= DBNull.Value; else this["iddidprog"]= value;}
	}
	public Int32? iddidprogOriginal { 
		get {if (this["iddidprog",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddidprog",DataRowVersion.Original];}
	}
	///<summary>
	///Numero chiuso
	///</summary>
	public Int32? iddidprognumchiusokind{ 
		get {if (this["iddidprognumchiusokind"]==DBNull.Value)return null; return  (Int32?)this["iddidprognumchiusokind"];}
		set {if (value==null) this["iddidprognumchiusokind"]= DBNull.Value; else this["iddidprognumchiusokind"]= value;}
	}
	public object iddidprognumchiusokindValue { 
		get{ return this["iddidprognumchiusokind"];}
		set {if (value==null|| value==DBNull.Value) this["iddidprognumchiusokind"]= DBNull.Value; else this["iddidprognumchiusokind"]= value;}
	}
	public Int32? iddidprognumchiusokindOriginal { 
		get {if (this["iddidprognumchiusokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddidprognumchiusokind",DataRowVersion.Original];}
	}
	///<summary>
	///Suddivisioni dell'anno
	///</summary>
	public Int32? iddidprogsuddannokind{ 
		get {if (this["iddidprogsuddannokind"]==DBNull.Value)return null; return  (Int32?)this["iddidprogsuddannokind"];}
		set {if (value==null) this["iddidprogsuddannokind"]= DBNull.Value; else this["iddidprogsuddannokind"]= value;}
	}
	public object iddidprogsuddannokindValue { 
		get{ return this["iddidprogsuddannokind"];}
		set {if (value==null|| value==DBNull.Value) this["iddidprogsuddannokind"]= DBNull.Value; else this["iddidprogsuddannokind"]= value;}
	}
	public Int32? iddidprogsuddannokindOriginal { 
		get {if (this["iddidprogsuddannokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddidprogsuddannokind",DataRowVersion.Original];}
	}
	///<summary>
	///Erogazione
	///</summary>
	public Int32? iderogazkind{ 
		get {if (this["iderogazkind"]==DBNull.Value)return null; return  (Int32?)this["iderogazkind"];}
		set {if (value==null) this["iderogazkind"]= DBNull.Value; else this["iderogazkind"]= value;}
	}
	public object iderogazkindValue { 
		get{ return this["iderogazkind"];}
		set {if (value==null|| value==DBNull.Value) this["iderogazkind"]= DBNull.Value; else this["iderogazkind"]= value;}
	}
	public Int32? iderogazkindOriginal { 
		get {if (this["iderogazkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iderogazkind",DataRowVersion.Original];}
	}
	///<summary>
	///Graduatoria
	///</summary>
	public Int32? idgraduatoria{ 
		get {if (this["idgraduatoria"]==DBNull.Value)return null; return  (Int32?)this["idgraduatoria"];}
		set {if (value==null) this["idgraduatoria"]= DBNull.Value; else this["idgraduatoria"]= value;}
	}
	public object idgraduatoriaValue { 
		get{ return this["idgraduatoria"];}
		set {if (value==null|| value==DBNull.Value) this["idgraduatoria"]= DBNull.Value; else this["idgraduatoria"]= value;}
	}
	public Int32? idgraduatoriaOriginal { 
		get {if (this["idgraduatoria",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idgraduatoria",DataRowVersion.Original];}
	}
	///<summary>
	///Esiti della graduatoria
	///</summary>
	public Int32? idgraduatoriaesiti{ 
		get {if (this["idgraduatoriaesiti"]==DBNull.Value)return null; return  (Int32?)this["idgraduatoriaesiti"];}
		set {if (value==null) this["idgraduatoriaesiti"]= DBNull.Value; else this["idgraduatoriaesiti"]= value;}
	}
	public object idgraduatoriaesitiValue { 
		get{ return this["idgraduatoriaesiti"];}
		set {if (value==null|| value==DBNull.Value) this["idgraduatoriaesiti"]= DBNull.Value; else this["idgraduatoriaesiti"]= value;}
	}
	public Int32? idgraduatoriaesitiOriginal { 
		get {if (this["idgraduatoriaesiti",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idgraduatoriaesiti",DataRowVersion.Original];}
	}
	///<summary>
	///Lingua di erogazione
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
	///Seconda lingua di erogazione
	///</summary>
	public Int32? idnation_lang2{ 
		get {if (this["idnation_lang2"]==DBNull.Value)return null; return  (Int32?)this["idnation_lang2"];}
		set {if (value==null) this["idnation_lang2"]= DBNull.Value; else this["idnation_lang2"]= value;}
	}
	public object idnation_lang2Value { 
		get{ return this["idnation_lang2"];}
		set {if (value==null|| value==DBNull.Value) this["idnation_lang2"]= DBNull.Value; else this["idnation_lang2"]= value;}
	}
	public Int32? idnation_lang2Original { 
		get {if (this["idnation_lang2",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idnation_lang2",DataRowVersion.Original];}
	}
	///<summary>
	///Lingua di visualizzazione
	///</summary>
	public Int32? idnation_langvis{ 
		get {if (this["idnation_langvis"]==DBNull.Value)return null; return  (Int32?)this["idnation_langvis"];}
		set {if (value==null) this["idnation_langvis"]= DBNull.Value; else this["idnation_langvis"]= value;}
	}
	public object idnation_langvisValue { 
		get{ return this["idnation_langvis"];}
		set {if (value==null|| value==DBNull.Value) this["idnation_langvis"]= DBNull.Value; else this["idnation_langvis"]= value;}
	}
	public Int32? idnation_langvisOriginal { 
		get {if (this["idnation_langvis",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idnation_langvis",DataRowVersion.Original];}
	}
	///<summary>
	///Referente
	///</summary>
	public Int32? idreg_docenti{ 
		get {if (this["idreg_docenti"]==DBNull.Value)return null; return  (Int32?)this["idreg_docenti"];}
		set {if (value==null) this["idreg_docenti"]= DBNull.Value; else this["idreg_docenti"]= value;}
	}
	public object idreg_docentiValue { 
		get{ return this["idreg_docenti"];}
		set {if (value==null|| value==DBNull.Value) this["idreg_docenti"]= DBNull.Value; else this["idreg_docenti"]= value;}
	}
	public Int32? idreg_docentiOriginal { 
		get {if (this["idreg_docenti",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg_docenti",DataRowVersion.Original];}
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
	///Sessione
	///</summary>
	public Int32? idsessione{ 
		get {if (this["idsessione"]==DBNull.Value)return null; return  (Int32?)this["idsessione"];}
		set {if (value==null) this["idsessione"]= DBNull.Value; else this["idsessione"]= value;}
	}
	public object idsessioneValue { 
		get{ return this["idsessione"];}
		set {if (value==null|| value==DBNull.Value) this["idsessione"]= DBNull.Value; else this["idsessione"]= value;}
	}
	public Int32? idsessioneOriginal { 
		get {if (this["idsessione",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsessione",DataRowVersion.Original];}
	}
	///<summary>
	///Titolo di studi
	///</summary>
	public Int32? idtitolokind{ 
		get {if (this["idtitolokind"]==DBNull.Value)return null; return  (Int32?)this["idtitolokind"];}
		set {if (value==null) this["idtitolokind"]= DBNull.Value; else this["idtitolokind"]= value;}
	}
	public object idtitolokindValue { 
		get{ return this["idtitolokind"];}
		set {if (value==null|| value==DBNull.Value) this["idtitolokind"]= DBNull.Value; else this["idtitolokind"]= value;}
	}
	public Int32? idtitolokindOriginal { 
		get {if (this["idtitolokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idtitolokind",DataRowVersion.Original];}
	}
	///<summary>
	///Consenti l'immatricolazione oltre i termini
	///</summary>
	public String immatoltreauth{ 
		get {if (this["immatoltreauth"]==DBNull.Value)return null; return  (String)this["immatoltreauth"];}
		set {if (value==null) this["immatoltreauth"]= DBNull.Value; else this["immatoltreauth"]= value;}
	}
	public object immatoltreauthValue { 
		get{ return this["immatoltreauth"];}
		set {if (value==null|| value==DBNull.Value) this["immatoltreauth"]= DBNull.Value; else this["immatoltreauth"]= value;}
	}
	public String immatoltreauthOriginal { 
		get {if (this["immatoltreauth",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["immatoltreauth",DataRowVersion.Original];}
	}
	///<summary>
	///Modalità e conoscenze per l’accesso
	///</summary>
	public String modaccesso{ 
		get {if (this["modaccesso"]==DBNull.Value)return null; return  (String)this["modaccesso"];}
		set {if (value==null) this["modaccesso"]= DBNull.Value; else this["modaccesso"]= value;}
	}
	public object modaccessoValue { 
		get{ return this["modaccesso"];}
		set {if (value==null|| value==DBNull.Value) this["modaccesso"]= DBNull.Value; else this["modaccesso"]= value;}
	}
	public String modaccessoOriginal { 
		get {if (this["modaccesso",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["modaccesso",DataRowVersion.Original];}
	}
	///<summary>
	///Modalità e conoscenze per l’accesso (EN)
	///</summary>
	public String modaccesso_en{ 
		get {if (this["modaccesso_en"]==DBNull.Value)return null; return  (String)this["modaccesso_en"];}
		set {if (value==null) this["modaccesso_en"]= DBNull.Value; else this["modaccesso_en"]= value;}
	}
	public object modaccesso_enValue { 
		get{ return this["modaccesso_en"];}
		set {if (value==null|| value==DBNull.Value) this["modaccesso_en"]= DBNull.Value; else this["modaccesso_en"]= value;}
	}
	public String modaccesso_enOriginal { 
		get {if (this["modaccesso_en",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["modaccesso_en",DataRowVersion.Original];}
	}
	///<summary>
	///Obiettivi formativi
	///</summary>
	public String obbformativi{ 
		get {if (this["obbformativi"]==DBNull.Value)return null; return  (String)this["obbformativi"];}
		set {if (value==null) this["obbformativi"]= DBNull.Value; else this["obbformativi"]= value;}
	}
	public object obbformativiValue { 
		get{ return this["obbformativi"];}
		set {if (value==null|| value==DBNull.Value) this["obbformativi"]= DBNull.Value; else this["obbformativi"]= value;}
	}
	public String obbformativiOriginal { 
		get {if (this["obbformativi",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["obbformativi",DataRowVersion.Original];}
	}
	///<summary>
	///Obiettivi formativi (EN)
	///</summary>
	public String obbformativi_en{ 
		get {if (this["obbformativi_en"]==DBNull.Value)return null; return  (String)this["obbformativi_en"];}
		set {if (value==null) this["obbformativi_en"]= DBNull.Value; else this["obbformativi_en"]= value;}
	}
	public object obbformativi_enValue { 
		get{ return this["obbformativi_en"];}
		set {if (value==null|| value==DBNull.Value) this["obbformativi_en"]= DBNull.Value; else this["obbformativi_en"]= value;}
	}
	public String obbformativi_enOriginal { 
		get {if (this["obbformativi_en",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["obbformativi_en",DataRowVersion.Original];}
	}
	///<summary>
	///Consenti la pre-immatricolazione oltre i termini
	///</summary>
	public String preimmatoltreauth{ 
		get {if (this["preimmatoltreauth"]==DBNull.Value)return null; return  (String)this["preimmatoltreauth"];}
		set {if (value==null) this["preimmatoltreauth"]= DBNull.Value; else this["preimmatoltreauth"]= value;}
	}
	public object preimmatoltreauthValue { 
		get{ return this["preimmatoltreauth"];}
		set {if (value==null|| value==DBNull.Value) this["preimmatoltreauth"]= DBNull.Value; else this["preimmatoltreauth"]= value;}
	}
	public String preimmatoltreauthOriginal { 
		get {if (this["preimmatoltreauth",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["preimmatoltreauth",DataRowVersion.Original];}
	}
	///<summary>
	///Programma dell'esame di ammissione
	///</summary>
	public String progesamamm{ 
		get {if (this["progesamamm"]==DBNull.Value)return null; return  (String)this["progesamamm"];}
		set {if (value==null) this["progesamamm"]= DBNull.Value; else this["progesamamm"]= value;}
	}
	public object progesamammValue { 
		get{ return this["progesamamm"];}
		set {if (value==null|| value==DBNull.Value) this["progesamamm"]= DBNull.Value; else this["progesamamm"]= value;}
	}
	public String progesamammOriginal { 
		get {if (this["progesamamm",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["progesamamm",DataRowVersion.Original];}
	}
	///<summary>
	///Prospettive occupazionali
	///</summary>
	public String prospoccupaz{ 
		get {if (this["prospoccupaz"]==DBNull.Value)return null; return  (String)this["prospoccupaz"];}
		set {if (value==null) this["prospoccupaz"]= DBNull.Value; else this["prospoccupaz"]= value;}
	}
	public object prospoccupazValue { 
		get{ return this["prospoccupaz"];}
		set {if (value==null|| value==DBNull.Value) this["prospoccupaz"]= DBNull.Value; else this["prospoccupaz"]= value;}
	}
	public String prospoccupazOriginal { 
		get {if (this["prospoccupaz",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["prospoccupaz",DataRowVersion.Original];}
	}
	///<summary>
	///Caratteristiche della prova finale
	///</summary>
	public String provafinaledesc{ 
		get {if (this["provafinaledesc"]==DBNull.Value)return null; return  (String)this["provafinaledesc"];}
		set {if (value==null) this["provafinaledesc"]= DBNull.Value; else this["provafinaledesc"]= value;}
	}
	public object provafinaledescValue { 
		get{ return this["provafinaledesc"];}
		set {if (value==null|| value==DBNull.Value) this["provafinaledesc"]= DBNull.Value; else this["provafinaledesc"]= value;}
	}
	public String provafinaledescOriginal { 
		get {if (this["provafinaledesc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["provafinaledesc",DataRowVersion.Original];}
	}
	///<summary>
	///Regolamento delle tasse
	///</summary>
	public String regolamentotax{ 
		get {if (this["regolamentotax"]==DBNull.Value)return null; return  (String)this["regolamentotax"];}
		set {if (value==null) this["regolamentotax"]= DBNull.Value; else this["regolamentotax"]= value;}
	}
	public object regolamentotaxValue { 
		get{ return this["regolamentotax"];}
		set {if (value==null|| value==DBNull.Value) this["regolamentotax"]= DBNull.Value; else this["regolamentotax"]= value;}
	}
	public String regolamentotaxOriginal { 
		get {if (this["regolamentotax",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["regolamentotax",DataRowVersion.Original];}
	}
	///<summary>
	///Indirizzo WEB del regolamento delle tasse
	///</summary>
	public String regolamentotaxurl{ 
		get {if (this["regolamentotaxurl"]==DBNull.Value)return null; return  (String)this["regolamentotaxurl"];}
		set {if (value==null) this["regolamentotaxurl"]= DBNull.Value; else this["regolamentotaxurl"]= value;}
	}
	public object regolamentotaxurlValue { 
		get{ return this["regolamentotaxurl"];}
		set {if (value==null|| value==DBNull.Value) this["regolamentotaxurl"]= DBNull.Value; else this["regolamentotaxurl"]= value;}
	}
	public String regolamentotaxurlOriginal { 
		get {if (this["regolamentotaxurl",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["regolamentotaxurl",DataRowVersion.Original];}
	}
	///<summary>
	///Data di inizio delle iscrizioni
	///</summary>
	public DateTime? startiscrizioni{ 
		get {if (this["startiscrizioni"]==DBNull.Value)return null; return  (DateTime?)this["startiscrizioni"];}
		set {if (value==null) this["startiscrizioni"]= DBNull.Value; else this["startiscrizioni"]= value;}
	}
	public object startiscrizioniValue { 
		get{ return this["startiscrizioni"];}
		set {if (value==null|| value==DBNull.Value) this["startiscrizioni"]= DBNull.Value; else this["startiscrizioni"]= value;}
	}
	public DateTime? startiscrizioniOriginal { 
		get {if (this["startiscrizioni",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["startiscrizioni",DataRowVersion.Original];}
	}
	///<summary>
	///Data di fine delle Iscrizioni
	///</summary>
	public DateTime? stopiscrizioni{ 
		get {if (this["stopiscrizioni"]==DBNull.Value)return null; return  (DateTime?)this["stopiscrizioni"];}
		set {if (value==null) this["stopiscrizioni"]= DBNull.Value; else this["stopiscrizioni"]= value;}
	}
	public object stopiscrizioniValue { 
		get{ return this["stopiscrizioni"];}
		set {if (value==null|| value==DBNull.Value) this["stopiscrizioni"]= DBNull.Value; else this["stopiscrizioni"]= value;}
	}
	public DateTime? stopiscrizioniOriginal { 
		get {if (this["stopiscrizioni",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["stopiscrizioni",DataRowVersion.Original];}
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
	///Denominazione (EN)
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
	///<summary>
	///Utenza sostenibile
	///</summary>
	public Int32? utenzasost{ 
		get {if (this["utenzasost"]==DBNull.Value)return null; return  (Int32?)this["utenzasost"];}
		set {if (value==null) this["utenzasost"]= DBNull.Value; else this["utenzasost"]= value;}
	}
	public object utenzasostValue { 
		get{ return this["utenzasost"];}
		set {if (value==null|| value==DBNull.Value) this["utenzasost"]= DBNull.Value; else this["utenzasost"]= value;}
	}
	public Int32? utenzasostOriginal { 
		get {if (this["utenzasost",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["utenzasost",DataRowVersion.Original];}
	}
	///<summary>
	///Sito WEB del corso
	///</summary>
	public String website{ 
		get {if (this["website"]==DBNull.Value)return null; return  (String)this["website"];}
		set {if (value==null) this["website"]= DBNull.Value; else this["website"]= value;}
	}
	public object websiteValue { 
		get{ return this["website"];}
		set {if (value==null|| value==DBNull.Value) this["website"]= DBNull.Value; else this["website"]= value;}
	}
	public String websiteOriginal { 
		get {if (this["website",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["website",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///2.4.1 Didattica programmata per un anno accademico di un corso di studio
///</summary>
public class didprogTable : MetaTableBase<didprogRow> {
	public didprogTable() : base("didprog"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"aa",createColumn("aa",typeof(string),false,false)},
			{"annosolare",createColumn("annosolare",typeof(int),true,false)},
			{"attribdebiti",createColumn("attribdebiti",typeof(string),true,false)},
			{"ciclo",createColumn("ciclo",typeof(int),true,false)},
			{"codice",createColumn("codice",typeof(string),true,false)},
			{"codicemiur",createColumn("codicemiur",typeof(string),true,false)},
			{"dataconsmaxiscr",createColumn("dataconsmaxiscr",typeof(DateTime),true,false)},
			{"freqobbl",createColumn("freqobbl",typeof(string),true,false)},
			{"idareadidattica",createColumn("idareadidattica",typeof(int),true,false)},
			{"idconvenzione",createColumn("idconvenzione",typeof(int),true,false)},
			{"idcorsostudio",createColumn("idcorsostudio",typeof(int),false,false)},
			{"iddidprog",createColumn("iddidprog",typeof(int),false,false)},
			{"iddidprognumchiusokind",createColumn("iddidprognumchiusokind",typeof(int),true,false)},
			{"iddidprogsuddannokind",createColumn("iddidprogsuddannokind",typeof(int),false,false)},
			{"iderogazkind",createColumn("iderogazkind",typeof(int),true,false)},
			{"idgraduatoria",createColumn("idgraduatoria",typeof(int),true,false)},
			{"idgraduatoriaesiti",createColumn("idgraduatoriaesiti",typeof(int),true,false)},
			{"idnation_lang",createColumn("idnation_lang",typeof(int),true,false)},
			{"idnation_lang2",createColumn("idnation_lang2",typeof(int),true,false)},
			{"idnation_langvis",createColumn("idnation_langvis",typeof(int),true,false)},
			{"idreg_docenti",createColumn("idreg_docenti",typeof(int),true,false)},
			{"idsede",createColumn("idsede",typeof(int),true,false)},
			{"idsessione",createColumn("idsessione",typeof(int),true,false)},
			{"idtitolokind",createColumn("idtitolokind",typeof(int),true,false)},
			{"immatoltreauth",createColumn("immatoltreauth",typeof(string),true,false)},
			{"modaccesso",createColumn("modaccesso",typeof(string),true,false)},
			{"modaccesso_en",createColumn("modaccesso_en",typeof(string),true,false)},
			{"obbformativi",createColumn("obbformativi",typeof(string),true,false)},
			{"obbformativi_en",createColumn("obbformativi_en",typeof(string),true,false)},
			{"preimmatoltreauth",createColumn("preimmatoltreauth",typeof(string),true,false)},
			{"progesamamm",createColumn("progesamamm",typeof(string),true,false)},
			{"prospoccupaz",createColumn("prospoccupaz",typeof(string),true,false)},
			{"provafinaledesc",createColumn("provafinaledesc",typeof(string),true,false)},
			{"regolamentotax",createColumn("regolamentotax",typeof(string),true,false)},
			{"regolamentotaxurl",createColumn("regolamentotaxurl",typeof(string),true,false)},
			{"startiscrizioni",createColumn("startiscrizioni",typeof(DateTime),true,false)},
			{"stopiscrizioni",createColumn("stopiscrizioni",typeof(DateTime),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
			{"title_en",createColumn("title_en",typeof(string),true,false)},
			{"utenzasost",createColumn("utenzasost",typeof(int),true,false)},
			{"website",createColumn("website",typeof(string),true,false)},
		};
	}
}
}
