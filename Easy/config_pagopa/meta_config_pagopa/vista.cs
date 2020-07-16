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
namespace meta_config_pagopa {
public class config_pagopaRow: MetaRow  {
	public config_pagopaRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Chiave fittizia
	///</summary>
	public Int32? dummykey{ 
		get {if (this["dummykey"]==DBNull.Value)return null; return  (Int32?)this["dummykey"];}
		set {if (value==null) this["dummykey"]= DBNull.Value; else this["dummykey"]= value;}
	}
	public object dummykeyValue { 
		get{ return this["dummykey"];}
		set {if (value==null|| value==DBNull.Value) this["dummykey"]= DBNull.Value; else this["dummykey"]= value;}
	}
	public Int32? dummykeyOriginal { 
		get {if (this["dummykey",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["dummykey",DataRowVersion.Original];}
	}
	///<summary>
	///Per esse3, gomp e sisest, è il codice tipo contratto attivo usato per l'importazione crediti
	///</summary>
	public String codicecontrattostudenti{ 
		get {if (this["codicecontrattostudenti"]==DBNull.Value)return null; return  (String)this["codicecontrattostudenti"];}
		set {if (value==null) this["codicecontrattostudenti"]= DBNull.Value; else this["codicecontrattostudenti"]= value;}
	}
	public object codicecontrattostudentiValue { 
		get{ return this["codicecontrattostudenti"];}
		set {if (value==null|| value==DBNull.Value) this["codicecontrattostudenti"]= DBNull.Value; else this["codicecontrattostudenti"]= value;}
	}
	public String codicecontrattostudentiOriginal { 
		get {if (this["codicecontrattostudenti",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicecontrattostudenti",DataRowVersion.Original];}
	}
	///<summary>
	///Flag usato nell'importazione crediti da esse3 (servizio easystudenti) che se impostato assume che tutti i  crediti siano già trasmessi.
	///	 N: Il credito importato non si assume già trasmesso
	///	 S: Il credito importato si assume già trasmesso
	///</summary>
	public String flussocrediti_transmitted{ 
		get {if (this["flussocrediti_transmitted"]==DBNull.Value)return null; return  (String)this["flussocrediti_transmitted"];}
		set {if (value==null) this["flussocrediti_transmitted"]= DBNull.Value; else this["flussocrediti_transmitted"]= value;}
	}
	public object flussocrediti_transmittedValue { 
		get{ return this["flussocrediti_transmitted"];}
		set {if (value==null|| value==DBNull.Value) this["flussocrediti_transmitted"]= DBNull.Value; else this["flussocrediti_transmitted"]= value;}
	}
	public String flussocrediti_transmittedOriginal { 
		get {if (this["flussocrediti_transmitted",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flussocrediti_transmitted",DataRowVersion.Original];}
	}
	///<summary>
	///id upb per importazione crediti da sisest
	///</summary>
	public String codeupb_sisest{ 
		get {if (this["codeupb_sisest"]==DBNull.Value)return null; return  (String)this["codeupb_sisest"];}
		set {if (value==null) this["codeupb_sisest"]= DBNull.Value; else this["codeupb_sisest"]= value;}
	}
	public object codeupb_sisestValue { 
		get{ return this["codeupb_sisest"];}
		set {if (value==null|| value==DBNull.Value) this["codeupb_sisest"]= DBNull.Value; else this["codeupb_sisest"]= value;}
	}
	public String codeupb_sisestOriginal { 
		get {if (this["codeupb_sisest",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeupb_sisest",DataRowVersion.Original];}
	}
	///<summary>
	///Per Ubibanca e Unicredit, la tipologia servizio, usato nell'ottenimento dell'avviso di pagamento
	///</summary>
	public String tipologiaservizio{ 
		get {if (this["tipologiaservizio"]==DBNull.Value)return null; return  (String)this["tipologiaservizio"];}
		set {if (value==null) this["tipologiaservizio"]= DBNull.Value; else this["tipologiaservizio"]= value;}
	}
	public object tipologiaservizioValue { 
		get{ return this["tipologiaservizio"];}
		set {if (value==null|| value==DBNull.Value) this["tipologiaservizio"]= DBNull.Value; else this["tipologiaservizio"]= value;}
	}
	public String tipologiaservizioOriginal { 
		get {if (this["tipologiaservizio",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tipologiaservizio",DataRowVersion.Original];}
	}
	///<summary>
	///Codice SIA usato in pagoPA per avviso Unicredit
	///</summary>
	public String codicesia{ 
		get {if (this["codicesia"]==DBNull.Value)return null; return  (String)this["codicesia"];}
		set {if (value==null) this["codicesia"]= DBNull.Value; else this["codicesia"]= value;}
	}
	public object codicesiaValue { 
		get{ return this["codicesia"];}
		set {if (value==null|| value==DBNull.Value) this["codicesia"]= DBNull.Value; else this["codicesia"]= value;}
	}
	public String codicesiaOriginal { 
		get {if (this["codicesia",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicesia",DataRowVersion.Original];}
	}
	///<summary>
	///Url servizio pagamento per ottenimento avvisi ubibanca e unicredit, ed è anche l'indirizzo a cui è rediretto l'utente se decide di pagare immediatamente nel portale pagamenti
	///</summary>
	public String urlserviziopagamento{ 
		get {if (this["urlserviziopagamento"]==DBNull.Value)return null; return  (String)this["urlserviziopagamento"];}
		set {if (value==null) this["urlserviziopagamento"]= DBNull.Value; else this["urlserviziopagamento"]= value;}
	}
	public object urlserviziopagamentoValue { 
		get{ return this["urlserviziopagamento"];}
		set {if (value==null|| value==DBNull.Value) this["urlserviziopagamento"]= DBNull.Value; else this["urlserviziopagamento"]= value;}
	}
	public String urlserviziopagamentoOriginal { 
		get {if (this["urlserviziopagamento",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["urlserviziopagamento",DataRowVersion.Original];}
	}
	///<summary>
	///Url sito istituzionale per avvisi Ubibanca ed Unicredit
	///</summary>
	public String urlsitoistituzionale{ 
		get {if (this["urlsitoistituzionale"]==DBNull.Value)return null; return  (String)this["urlsitoistituzionale"];}
		set {if (value==null) this["urlsitoistituzionale"]= DBNull.Value; else this["urlsitoistituzionale"]= value;}
	}
	public object urlsitoistituzionaleValue { 
		get{ return this["urlsitoistituzionale"];}
		set {if (value==null|| value==DBNull.Value) this["urlsitoistituzionale"]= DBNull.Value; else this["urlsitoistituzionale"]= value;}
	}
	public String urlsitoistituzionaleOriginal { 
		get {if (this["urlsitoistituzionale",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["urlsitoistituzionale",DataRowVersion.Original];}
	}
	///<summary>
	///nota privacy che viene scritta in calce quando si crea l'account da websul portale pagamenti
	///
	///
	///</summary>
	public String titolaredatiprivacy{ 
		get {if (this["titolaredatiprivacy"]==DBNull.Value)return null; return  (String)this["titolaredatiprivacy"];}
		set {if (value==null) this["titolaredatiprivacy"]= DBNull.Value; else this["titolaredatiprivacy"]= value;}
	}
	public object titolaredatiprivacyValue { 
		get{ return this["titolaredatiprivacy"];}
		set {if (value==null|| value==DBNull.Value) this["titolaredatiprivacy"]= DBNull.Value; else this["titolaredatiprivacy"]= value;}
	}
	public String titolaredatiprivacyOriginal { 
		get {if (this["titolaredatiprivacy",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["titolaredatiprivacy",DataRowVersion.Original];}
	}
	public String codicecontrattorimborsi{ 
		get {if (this["codicecontrattorimborsi"]==DBNull.Value)return null; return  (String)this["codicecontrattorimborsi"];}
		set {if (value==null) this["codicecontrattorimborsi"]= DBNull.Value; else this["codicecontrattorimborsi"]= value;}
	}
	public object codicecontrattorimborsiValue { 
		get{ return this["codicecontrattorimborsi"];}
		set {if (value==null|| value==DBNull.Value) this["codicecontrattorimborsi"]= DBNull.Value; else this["codicecontrattorimborsi"]= value;}
	}
	public String codicecontrattorimborsiOriginal { 
		get {if (this["codicecontrattorimborsi",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicecontrattorimborsi",DataRowVersion.Original];}
	}
	public String lt{ 
		get {if (this["lt"]==DBNull.Value)return null; return  (String)this["lt"];}
		set {if (value==null) this["lt"]= DBNull.Value; else this["lt"]= value;}
	}
	public object ltValue { 
		get{ return this["lt"];}
		set {if (value==null|| value==DBNull.Value) this["lt"]= DBNull.Value; else this["lt"]= value;}
	}
	public String ltOriginal { 
		get {if (this["lt",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lt",DataRowVersion.Original];}
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
	#endregion

}
///<summary>
///Configurazione pagoPA
///</summary>
public class config_pagopaTable : MetaTableBase<config_pagopaRow> {
	public config_pagopaTable() : base("config_pagopa"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"dummykey",createColumn("dummykey",typeof(int),false,false)},
			{"codicecontrattostudenti",createColumn("codicecontrattostudenti",typeof(string),true,false)},
			{"flussocrediti_transmitted",createColumn("flussocrediti_transmitted",typeof(string),true,false)},
			{"codeupb_sisest",createColumn("codeupb_sisest",typeof(string),true,false)},
			{"tipologiaservizio",createColumn("tipologiaservizio",typeof(string),true,false)},
			{"codicesia",createColumn("codicesia",typeof(string),true,false)},
			{"urlserviziopagamento",createColumn("urlserviziopagamento",typeof(string),true,false)},
			{"urlsitoistituzionale",createColumn("urlsitoistituzionale",typeof(string),true,false)},
			{"titolaredatiprivacy",createColumn("titolaredatiprivacy",typeof(string),true,false)},
			{"codicecontrattorimborsi",createColumn("codicecontrattorimborsi",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(string),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
		};
	}
}
}
