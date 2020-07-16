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
namespace meta_instmcontratto {
public class instmcontrattoRow: MetaRow  {
	public instmcontrattoRow(DataRowBuilder rb) : base(rb) {} 

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
	///Data Contratto
	///</summary>
	public DateTime? datacontratto{ 
		get {if (this["datacontratto"]==DBNull.Value)return null; return  (DateTime?)this["datacontratto"];}
		set {if (value==null) this["datacontratto"]= DBNull.Value; else this["datacontratto"]= value;}
	}
	public object datacontrattoValue { 
		get{ return this["datacontratto"];}
		set {if (value==null|| value==DBNull.Value) this["datacontratto"]= DBNull.Value; else this["datacontratto"]= value;}
	}
	public DateTime? datacontrattoOriginal { 
		get {if (this["datacontratto",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["datacontratto",DataRowVersion.Original];}
	}
	///<summary>
	///Data Fine Contratto
	///</summary>
	public DateTime? datafine{ 
		get {if (this["datafine"]==DBNull.Value)return null; return  (DateTime?)this["datafine"];}
		set {if (value==null) this["datafine"]= DBNull.Value; else this["datafine"]= value;}
	}
	public object datafineValue { 
		get{ return this["datafine"];}
		set {if (value==null|| value==DBNull.Value) this["datafine"]= DBNull.Value; else this["datafine"]= value;}
	}
	public DateTime? datafineOriginal { 
		get {if (this["datafine",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["datafine",DataRowVersion.Original];}
	}
	///<summary>
	///Data Inizio Contratto
	///</summary>
	public DateTime? datainizio{ 
		get {if (this["datainizio"]==DBNull.Value)return null; return  (DateTime?)this["datainizio"];}
		set {if (value==null) this["datainizio"]= DBNull.Value; else this["datainizio"]= value;}
	}
	public object datainizioValue { 
		get{ return this["datainizio"];}
		set {if (value==null|| value==DBNull.Value) this["datainizio"]= DBNull.Value; else this["datainizio"]= value;}
	}
	public DateTime? datainizioOriginal { 
		get {if (this["datainizio",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["datainizio",DataRowVersion.Original];}
	}
	///<summary>
	///Motivazione e Note
	///</summary>
	public String description{ 
		get {if (this["description"]==DBNull.Value)return null; return  (String)this["description"];}
		set {if (value==null) this["description"]= DBNull.Value; else this["description"]= value;}
	}
	public object descriptionValue { 
		get{ return this["description"];}
		set {if (value==null|| value==DBNull.Value) this["description"]= DBNull.Value; else this["description"]= value;}
	}
	public String descriptionOriginal { 
		get {if (this["description",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["description",DataRowVersion.Original];}
	}
	///<summary>
	///Dipendente PA
	///</summary>
	public String dipendentepa{ 
		get {if (this["dipendentepa"]==DBNull.Value)return null; return  (String)this["dipendentepa"];}
		set {if (value==null) this["dipendentepa"]= DBNull.Value; else this["dipendentepa"]= value;}
	}
	public object dipendentepaValue { 
		get{ return this["dipendentepa"];}
		set {if (value==null|| value==DBNull.Value) this["dipendentepa"]= DBNull.Value; else this["dipendentepa"]= value;}
	}
	public String dipendentepaOriginal { 
		get {if (this["dipendentepa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["dipendentepa",DataRowVersion.Original];}
	}
	///<summary>
	///Durata Mesi
	///</summary>
	public Int32? duratamesi{ 
		get {if (this["duratamesi"]==DBNull.Value)return null; return  (Int32?)this["duratamesi"];}
		set {if (value==null) this["duratamesi"]= DBNull.Value; else this["duratamesi"]= value;}
	}
	public object duratamesiValue { 
		get{ return this["duratamesi"];}
		set {if (value==null|| value==DBNull.Value) this["duratamesi"]= DBNull.Value; else this["duratamesi"]= value;}
	}
	public Int32? duratamesiOriginal { 
		get {if (this["duratamesi",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["duratamesi",DataRowVersion.Original];}
	}
	///<summary>
	///Albo Professionale
	///</summary>
	public Int32? idalboprofessionale{ 
		get {if (this["idalboprofessionale"]==DBNull.Value)return null; return  (Int32?)this["idalboprofessionale"];}
		set {if (value==null) this["idalboprofessionale"]= DBNull.Value; else this["idalboprofessionale"]= value;}
	}
	public object idalboprofessionaleValue { 
		get{ return this["idalboprofessionale"];}
		set {if (value==null|| value==DBNull.Value) this["idalboprofessionale"]= DBNull.Value; else this["idalboprofessionale"]= value;}
	}
	public Int32? idalboprofessionaleOriginal { 
		get {if (this["idalboprofessionale",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idalboprofessionale",DataRowVersion.Original];}
	}
	///<summary>
	///Ente Previdenziale
	///</summary>
	public Int32? identeprevidenziale{ 
		get {if (this["identeprevidenziale"]==DBNull.Value)return null; return  (Int32?)this["identeprevidenziale"];}
		set {if (value==null) this["identeprevidenziale"]= DBNull.Value; else this["identeprevidenziale"]= value;}
	}
	public object identeprevidenzialeValue { 
		get{ return this["identeprevidenziale"];}
		set {if (value==null|| value==DBNull.Value) this["identeprevidenziale"]= DBNull.Value; else this["identeprevidenziale"]= value;}
	}
	public Int32? identeprevidenzialeOriginal { 
		get {if (this["identeprevidenziale",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["identeprevidenziale",DataRowVersion.Original];}
	}
	public Int32? idinstmcontratto{ 
		get {if (this["idinstmcontratto"]==DBNull.Value)return null; return  (Int32?)this["idinstmcontratto"];}
		set {if (value==null) this["idinstmcontratto"]= DBNull.Value; else this["idinstmcontratto"]= value;}
	}
	public object idinstmcontrattoValue { 
		get{ return this["idinstmcontratto"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmcontratto"]= DBNull.Value; else this["idinstmcontratto"]= value;}
	}
	public Int32? idinstmcontrattoOriginal { 
		get {if (this["idinstmcontratto",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmcontratto",DataRowVersion.Original];}
	}
	///<summary>
	///Tipologia
	///</summary>
	public Int32? idinstmcontrattokind{ 
		get {if (this["idinstmcontrattokind"]==DBNull.Value)return null; return  (Int32?)this["idinstmcontrattokind"];}
		set {if (value==null) this["idinstmcontrattokind"]= DBNull.Value; else this["idinstmcontrattokind"]= value;}
	}
	public object idinstmcontrattokindValue { 
		get{ return this["idinstmcontrattokind"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmcontrattokind"]= DBNull.Value; else this["idinstmcontrattokind"]= value;}
	}
	public Int32? idinstmcontrattokindOriginal { 
		get {if (this["idinstmcontrattokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmcontrattokind",DataRowVersion.Original];}
	}
	///<summary>
	///Progetto
	///</summary>
	public Int32? idinstmprogetti{ 
		get {if (this["idinstmprogetti"]==DBNull.Value)return null; return  (Int32?)this["idinstmprogetti"];}
		set {if (value==null) this["idinstmprogetti"]= DBNull.Value; else this["idinstmprogetti"]= value;}
	}
	public object idinstmprogettiValue { 
		get{ return this["idinstmprogetti"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmprogetti"]= DBNull.Value; else this["idinstmprogetti"]= value;}
	}
	public Int32? idinstmprogettiOriginal { 
		get {if (this["idinstmprogetti",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmprogetti",DataRowVersion.Original];}
	}
	///<summary>
	///Titolo di Studio
	///</summary>
	public Int32? idistattitolistudio{ 
		get {if (this["idistattitolistudio"]==DBNull.Value)return null; return  (Int32?)this["idistattitolistudio"];}
		set {if (value==null) this["idistattitolistudio"]= DBNull.Value; else this["idistattitolistudio"]= value;}
	}
	public object idistattitolistudioValue { 
		get{ return this["idistattitolistudio"];}
		set {if (value==null|| value==DBNull.Value) this["idistattitolistudio"]= DBNull.Value; else this["idistattitolistudio"]= value;}
	}
	public Int32? idistattitolistudioOriginal { 
		get {if (this["idistattitolistudio",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idistattitolistudio",DataRowVersion.Original];}
	}
	///<summary>
	///Afferente
	///</summary>
	public Int32? idreg_instmuser{ 
		get {if (this["idreg_instmuser"]==DBNull.Value)return null; return  (Int32?)this["idreg_instmuser"];}
		set {if (value==null) this["idreg_instmuser"]= DBNull.Value; else this["idreg_instmuser"]= value;}
	}
	public object idreg_instmuserValue { 
		get{ return this["idreg_instmuser"];}
		set {if (value==null|| value==DBNull.Value) this["idreg_instmuser"]= DBNull.Value; else this["idreg_instmuser"]= value;}
	}
	public Int32? idreg_instmuserOriginal { 
		get {if (this["idreg_instmuser",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg_instmuser",DataRowVersion.Original];}
	}
	///<summary>
	///Responsabile
	///</summary>
	public Int32? idreg_instmuser_resp{ 
		get {if (this["idreg_instmuser_resp"]==DBNull.Value)return null; return  (Int32?)this["idreg_instmuser_resp"];}
		set {if (value==null) this["idreg_instmuser_resp"]= DBNull.Value; else this["idreg_instmuser_resp"]= value;}
	}
	public object idreg_instmuser_respValue { 
		get{ return this["idreg_instmuser_resp"];}
		set {if (value==null|| value==DBNull.Value) this["idreg_instmuser_resp"]= DBNull.Value; else this["idreg_instmuser_resp"]= value;}
	}
	public Int32? idreg_instmuser_respOriginal { 
		get {if (this["idreg_instmuser_resp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg_instmuser_resp",DataRowVersion.Original];}
	}
	///<summary>
	///Importo Lordo
	///</summary>
	public Decimal? importolordo{ 
		get {if (this["importolordo"]==DBNull.Value)return null; return  (Decimal?)this["importolordo"];}
		set {if (value==null) this["importolordo"]= DBNull.Value; else this["importolordo"]= value;}
	}
	public object importolordoValue { 
		get{ return this["importolordo"];}
		set {if (value==null|| value==DBNull.Value) this["importolordo"]= DBNull.Value; else this["importolordo"]= value;}
	}
	public Decimal? importolordoOriginal { 
		get {if (this["importolordo",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["importolordo",DataRowVersion.Original];}
	}
	///<summary>
	///Incarichi Periodo
	///</summary>
	public String incarichiperiodo{ 
		get {if (this["incarichiperiodo"]==DBNull.Value)return null; return  (String)this["incarichiperiodo"];}
		set {if (value==null) this["incarichiperiodo"]= DBNull.Value; else this["incarichiperiodo"]= value;}
	}
	public object incarichiperiodoValue { 
		get{ return this["incarichiperiodo"];}
		set {if (value==null|| value==DBNull.Value) this["incarichiperiodo"]= DBNull.Value; else this["incarichiperiodo"]= value;}
	}
	public String incarichiperiodoOriginal { 
		get {if (this["incarichiperiodo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["incarichiperiodo",DataRowVersion.Original];}
	}
	///<summary>
	///Incarichi Precedenti
	///</summary>
	public String incarichiprecedenti{ 
		get {if (this["incarichiprecedenti"]==DBNull.Value)return null; return  (String)this["incarichiprecedenti"];}
		set {if (value==null) this["incarichiprecedenti"]= DBNull.Value; else this["incarichiprecedenti"]= value;}
	}
	public object incarichiprecedentiValue { 
		get{ return this["incarichiprecedenti"];}
		set {if (value==null|| value==DBNull.Value) this["incarichiprecedenti"]= DBNull.Value; else this["incarichiprecedenti"]= value;}
	}
	public String incarichiprecedentiOriginal { 
		get {if (this["incarichiprecedenti",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["incarichiprecedenti",DataRowVersion.Original];}
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
	///Luogo Svolgimento
	///</summary>
	public String luogosvolgimento{ 
		get {if (this["luogosvolgimento"]==DBNull.Value)return null; return  (String)this["luogosvolgimento"];}
		set {if (value==null) this["luogosvolgimento"]= DBNull.Value; else this["luogosvolgimento"]= value;}
	}
	public object luogosvolgimentoValue { 
		get{ return this["luogosvolgimento"];}
		set {if (value==null|| value==DBNull.Value) this["luogosvolgimento"]= DBNull.Value; else this["luogosvolgimento"]= value;}
	}
	public String luogosvolgimentoOriginal { 
		get {if (this["luogosvolgimento",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["luogosvolgimento",DataRowVersion.Original];}
	}
	public String pensione{ 
		get {if (this["pensione"]==DBNull.Value)return null; return  (String)this["pensione"];}
		set {if (value==null) this["pensione"]= DBNull.Value; else this["pensione"]= value;}
	}
	public object pensioneValue { 
		get{ return this["pensione"];}
		set {if (value==null|| value==DBNull.Value) this["pensione"]= DBNull.Value; else this["pensione"]= value;}
	}
	public String pensioneOriginal { 
		get {if (this["pensione",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["pensione",DataRowVersion.Original];}
	}
	///<summary>
	///Partita Iva
	///</summary>
	public String piva{ 
		get {if (this["piva"]==DBNull.Value)return null; return  (String)this["piva"];}
		set {if (value==null) this["piva"]= DBNull.Value; else this["piva"]= value;}
	}
	public object pivaValue { 
		get{ return this["piva"];}
		set {if (value==null|| value==DBNull.Value) this["piva"]= DBNull.Value; else this["piva"]= value;}
	}
	public String pivaOriginal { 
		get {if (this["piva",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["piva",DataRowVersion.Original];}
	}
	///<summary>
	///Titolo della Prestazione
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
public class instmcontrattoTable : MetaTableBase<instmcontrattoRow> {
	public instmcontrattoTable() : base("instmcontratto"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"datacontratto",createColumn("datacontratto",typeof(DateTime),true,false)},
			{"datafine",createColumn("datafine",typeof(DateTime),true,false)},
			{"datainizio",createColumn("datainizio",typeof(DateTime),true,false)},
			{"description",createColumn("description",typeof(string),true,false)},
			{"dipendentepa",createColumn("dipendentepa",typeof(string),true,false)},
			{"duratamesi",createColumn("duratamesi",typeof(int),true,false)},
			{"idalboprofessionale",createColumn("idalboprofessionale",typeof(int),true,false)},
			{"identeprevidenziale",createColumn("identeprevidenziale",typeof(int),true,false)},
			{"idinstmcontratto",createColumn("idinstmcontratto",typeof(int),false,false)},
			{"idinstmcontrattokind",createColumn("idinstmcontrattokind",typeof(int),true,false)},
			{"idinstmprogetti",createColumn("idinstmprogetti",typeof(int),true,false)},
			{"idistattitolistudio",createColumn("idistattitolistudio",typeof(int),true,false)},
			{"idreg_instmuser",createColumn("idreg_instmuser",typeof(int),true,false)},
			{"idreg_instmuser_resp",createColumn("idreg_instmuser_resp",typeof(int),true,false)},
			{"importolordo",createColumn("importolordo",typeof(decimal),true,false)},
			{"incarichiperiodo",createColumn("incarichiperiodo",typeof(string),true,false)},
			{"incarichiprecedenti",createColumn("incarichiprecedenti",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"luogosvolgimento",createColumn("luogosvolgimento",typeof(string),true,false)},
			{"pensione",createColumn("pensione",typeof(string),true,false)},
			{"piva",createColumn("piva",typeof(string),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
		};
	}
}
}
