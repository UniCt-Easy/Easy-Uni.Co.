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
namespace meta_itineration {
public class itinerationRow: MetaRow  {
	public itinerationRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///attivo
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
	///data contabile
	///</summary>
	public DateTime? adate{ 
		get {if (this["adate"]==DBNull.Value)return null; return  (DateTime?)this["adate"];}
		set {if (value==null) this["adate"]= DBNull.Value; else this["adate"]= value;}
	}
	public object adateValue { 
		get{ return this["adate"];}
		set {if (value==null|| value==DBNull.Value) this["adate"]= DBNull.Value; else this["adate"]= value;}
	}
	public DateTime? adateOriginal { 
		get {if (this["adate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["adate",DataRowVersion.Original];}
	}
	///<summary>
	///Richieste aggiuntive sulla missione
	///</summary>
	public String additionalannotations{ 
		get {if (this["additionalannotations"]==DBNull.Value)return null; return  (String)this["additionalannotations"];}
		set {if (value==null) this["additionalannotations"]= DBNull.Value; else this["additionalannotations"]= value;}
	}
	public object additionalannotationsValue { 
		get{ return this["additionalannotations"];}
		set {if (value==null|| value==DBNull.Value) this["additionalannotations"]= DBNull.Value; else this["additionalannotations"]= value;}
	}
	public String additionalannotationsOriginal { 
		get {if (this["additionalannotations",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["additionalannotations",DataRowVersion.Original];}
	}
	///<summary>
	///Km percorsi con mezzo amministrazione
	///</summary>
	public Decimal? admincarkm{ 
		get {if (this["admincarkm"]==DBNull.Value)return null; return  (Decimal?)this["admincarkm"];}
		set {if (value==null) this["admincarkm"]= DBNull.Value; else this["admincarkm"]= value;}
	}
	public object admincarkmValue { 
		get{ return this["admincarkm"];}
		set {if (value==null|| value==DBNull.Value) this["admincarkm"]= DBNull.Value; else this["admincarkm"]= value;}
	}
	public Decimal? admincarkmOriginal { 
		get {if (this["admincarkm",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["admincarkm",DataRowVersion.Original];}
	}
	///<summary>
	///Costo a Km per utilizzo mezzo amministrazione
	///</summary>
	public Decimal? admincarkmcost{ 
		get {if (this["admincarkmcost"]==DBNull.Value)return null; return  (Decimal?)this["admincarkmcost"];}
		set {if (value==null) this["admincarkmcost"]= DBNull.Value; else this["admincarkmcost"]= value;}
	}
	public object admincarkmcostValue { 
		get{ return this["admincarkmcost"];}
		set {if (value==null|| value==DBNull.Value) this["admincarkmcost"]= DBNull.Value; else this["admincarkmcost"]= value;}
	}
	public Decimal? admincarkmcostOriginal { 
		get {if (this["admincarkmcost",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["admincarkmcost",DataRowVersion.Original];}
	}
	public String advanceapplied{ 
		get {if (this["advanceapplied"]==DBNull.Value)return null; return  (String)this["advanceapplied"];}
		set {if (value==null) this["advanceapplied"]= DBNull.Value; else this["advanceapplied"]= value;}
	}
	public object advanceappliedValue { 
		get{ return this["advanceapplied"];}
		set {if (value==null|| value==DBNull.Value) this["advanceapplied"]= DBNull.Value; else this["advanceapplied"]= value;}
	}
	public String advanceappliedOriginal { 
		get {if (this["advanceapplied",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["advanceapplied",DataRowVersion.Original];}
	}
	public Decimal? advancepercentage{ 
		get {if (this["advancepercentage"]==DBNull.Value)return null; return  (Decimal?)this["advancepercentage"];}
		set {if (value==null) this["advancepercentage"]= DBNull.Value; else this["advancepercentage"]= value;}
	}
	public object advancepercentageValue { 
		get{ return this["advancepercentage"];}
		set {if (value==null|| value==DBNull.Value) this["advancepercentage"]= DBNull.Value; else this["advancepercentage"]= value;}
	}
	public Decimal? advancepercentageOriginal { 
		get {if (this["advancepercentage",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["advancepercentage",DataRowVersion.Original];}
	}
	///<summary>
	///Appunti per il pagamento
	///</summary>
	public String applierannotations{ 
		get {if (this["applierannotations"]==DBNull.Value)return null; return  (String)this["applierannotations"];}
		set {if (value==null) this["applierannotations"]= DBNull.Value; else this["applierannotations"]= value;}
	}
	public object applierannotationsValue { 
		get{ return this["applierannotations"];}
		set {if (value==null|| value==DBNull.Value) this["applierannotations"]= DBNull.Value; else this["applierannotations"]= value;}
	}
	public String applierannotationsOriginal { 
		get {if (this["applierannotations",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["applierannotations",DataRowVersion.Original];}
	}
	///<summary>
	///Doc. autorizzazione
	///</summary>
	public String authdoc{ 
		get {if (this["authdoc"]==DBNull.Value)return null; return  (String)this["authdoc"];}
		set {if (value==null) this["authdoc"]= DBNull.Value; else this["authdoc"]= value;}
	}
	public object authdocValue { 
		get{ return this["authdoc"];}
		set {if (value==null|| value==DBNull.Value) this["authdoc"]= DBNull.Value; else this["authdoc"]= value;}
	}
	public String authdocOriginal { 
		get {if (this["authdoc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["authdoc",DataRowVersion.Original];}
	}
	///<summary>
	///Data autorizzazione
	///</summary>
	public DateTime? authdocdate{ 
		get {if (this["authdocdate"]==DBNull.Value)return null; return  (DateTime?)this["authdocdate"];}
		set {if (value==null) this["authdocdate"]= DBNull.Value; else this["authdocdate"]= value;}
	}
	public object authdocdateValue { 
		get{ return this["authdocdate"];}
		set {if (value==null|| value==DBNull.Value) this["authdocdate"]= DBNull.Value; else this["authdocdate"]= value;}
	}
	public DateTime? authdocdateOriginal { 
		get {if (this["authdocdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["authdocdate",DataRowVersion.Original];}
	}
	///<summary>
	///Autorizzazione da sede di appartenenza
	///</summary>
	public String authemployer{ 
		get {if (this["authemployer"]==DBNull.Value)return null; return  (String)this["authemployer"];}
		set {if (value==null) this["authemployer"]= DBNull.Value; else this["authemployer"]= value;}
	}
	public object authemployerValue { 
		get{ return this["authemployer"];}
		set {if (value==null|| value==DBNull.Value) this["authemployer"]= DBNull.Value; else this["authemployer"]= value;}
	}
	public String authemployerOriginal { 
		get {if (this["authemployer",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["authemployer",DataRowVersion.Original];}
	}
	///<summary>
	///Autorizzaz. richiesta
	///</summary>
	public String authneeded{ 
		get {if (this["authneeded"]==DBNull.Value)return null; return  (String)this["authneeded"];}
		set {if (value==null) this["authneeded"]= DBNull.Value; else this["authneeded"]= value;}
	}
	public object authneededValue { 
		get{ return this["authneeded"];}
		set {if (value==null|| value==DBNull.Value) this["authneeded"]= DBNull.Value; else this["authneeded"]= value;}
	}
	public String authneededOriginal { 
		get {if (this["authneeded",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["authneeded",DataRowVersion.Original];}
	}
	///<summary>
	///Data autorizz.
	///</summary>
	public DateTime? authorizationdate{ 
		get {if (this["authorizationdate"]==DBNull.Value)return null; return  (DateTime?)this["authorizationdate"];}
		set {if (value==null) this["authorizationdate"]= DBNull.Value; else this["authorizationdate"]= value;}
	}
	public object authorizationdateValue { 
		get{ return this["authorizationdate"];}
		set {if (value==null|| value==DBNull.Value) this["authorizationdate"]= DBNull.Value; else this["authorizationdate"]= value;}
	}
	public DateTime? authorizationdateOriginal { 
		get {if (this["authorizationdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["authorizationdate",DataRowVersion.Original];}
	}
	///<summary>
	///Motivo rifiuto richiesta
	///</summary>
	public String cancelreason{ 
		get {if (this["cancelreason"]==DBNull.Value)return null; return  (String)this["cancelreason"];}
		set {if (value==null) this["cancelreason"]= DBNull.Value; else this["cancelreason"]= value;}
	}
	public object cancelreasonValue { 
		get{ return this["cancelreason"];}
		set {if (value==null|| value==DBNull.Value) this["cancelreason"]= DBNull.Value; else this["cancelreason"]= value;}
	}
	public String cancelreasonOriginal { 
		get {if (this["cancelreason",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cancelreason",DataRowVersion.Original];}
	}
	///<summary>
	///Accetta la clausola per utilizzo mezzo indicato
	///	 N: Non accetta la clausola per utilizzo mezzo indicato
	///	 S: Accetta la clausola per utilizzo mezzo indicato
	///</summary>
	public String clause_accepted{ 
		get {if (this["clause_accepted"]==DBNull.Value)return null; return  (String)this["clause_accepted"];}
		set {if (value==null) this["clause_accepted"]= DBNull.Value; else this["clause_accepted"]= value;}
	}
	public object clause_acceptedValue { 
		get{ return this["clause_accepted"];}
		set {if (value==null|| value==DBNull.Value) this["clause_accepted"]= DBNull.Value; else this["clause_accepted"]= value;}
	}
	public String clause_acceptedOriginal { 
		get {if (this["clause_accepted",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["clause_accepted",DataRowVersion.Original];}
	}
	///<summary>
	///Considera eseguito quindi pagabile
	///</summary>
	public String completed{ 
		get {if (this["completed"]==DBNull.Value)return null; return  (String)this["completed"];}
		set {if (value==null) this["completed"]= DBNull.Value; else this["completed"]= value;}
	}
	public object completedValue { 
		get{ return this["completed"];}
		set {if (value==null|| value==DBNull.Value) this["completed"]= DBNull.Value; else this["completed"]= value;}
	}
	public String completedOriginal { 
		get {if (this["completed",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["completed",DataRowVersion.Original];}
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
	///data acquisizione documentazione definitiva
	///</summary>
	public DateTime? datecompleted{ 
		get {if (this["datecompleted"]==DBNull.Value)return null; return  (DateTime?)this["datecompleted"];}
		set {if (value==null) this["datecompleted"]= DBNull.Value; else this["datecompleted"]= value;}
	}
	public object datecompletedValue { 
		get{ return this["datecompleted"];}
		set {if (value==null|| value==DBNull.Value) this["datecompleted"]= DBNull.Value; else this["datecompleted"]= value;}
	}
	public DateTime? datecompletedOriginal { 
		get {if (this["datecompleted",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["datecompleted",DataRowVersion.Original];}
	}
	///<summary>
	///Descrizione
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
	///Presso
	///</summary>
	public String destination{ 
		get {if (this["destination"]==DBNull.Value)return null; return  (String)this["destination"];}
		set {if (value==null) this["destination"]= DBNull.Value; else this["destination"]= value;}
	}
	public object destinationValue { 
		get{ return this["destination"];}
		set {if (value==null|| value==DBNull.Value) this["destination"]= DBNull.Value; else this["destination"]= value;}
	}
	public String destinationOriginal { 
		get {if (this["destination",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["destination",DataRowVersion.Original];}
	}
	///<summary>
	///Località non corrispondente a sede di servizio
	///</summary>
	public String differentlocation{ 
		get {if (this["differentlocation"]==DBNull.Value)return null; return  (String)this["differentlocation"];}
		set {if (value==null) this["differentlocation"]= DBNull.Value; else this["differentlocation"]= value;}
	}
	public object differentlocationValue { 
		get{ return this["differentlocation"];}
		set {if (value==null|| value==DBNull.Value) this["differentlocation"]= DBNull.Value; else this["differentlocation"]= value;}
	}
	public String differentlocationOriginal { 
		get {if (this["differentlocation",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["differentlocation",DataRowVersion.Original];}
	}
	public Int32? flagmove{ 
		get {if (this["flagmove"]==DBNull.Value)return null; return  (Int32?)this["flagmove"];}
		set {if (value==null) this["flagmove"]= DBNull.Value; else this["flagmove"]= value;}
	}
	public object flagmoveValue { 
		get{ return this["flagmove"];}
		set {if (value==null|| value==DBNull.Value) this["flagmove"]= DBNull.Value; else this["flagmove"]= value;}
	}
	public Int32? flagmoveOriginal { 
		get {if (this["flagmove",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["flagmove",DataRowVersion.Original];}
	}
	public String flagoutside{ 
		get {if (this["flagoutside"]==DBNull.Value)return null; return  (String)this["flagoutside"];}
		set {if (value==null) this["flagoutside"]= DBNull.Value; else this["flagoutside"]= value;}
	}
	public object flagoutsideValue { 
		get{ return this["flagoutside"];}
		set {if (value==null|| value==DBNull.Value) this["flagoutside"]= DBNull.Value; else this["flagoutside"]= value;}
	}
	public String flagoutsideOriginal { 
		get {if (this["flagoutside",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagoutside",DataRowVersion.Original];}
	}
	public String flagownfunds{ 
		get {if (this["flagownfunds"]==DBNull.Value)return null; return  (String)this["flagownfunds"];}
		set {if (value==null) this["flagownfunds"]= DBNull.Value; else this["flagownfunds"]= value;}
	}
	public object flagownfundsValue { 
		get{ return this["flagownfunds"];}
		set {if (value==null|| value==DBNull.Value) this["flagownfunds"]= DBNull.Value; else this["flagownfunds"]= value;}
	}
	public String flagownfundsOriginal { 
		get {if (this["flagownfunds",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagownfunds",DataRowVersion.Original];}
	}
	///<summary>
	///Missione inserita mediante interfaccia web
	///	 N: Missione inserita mediante interfaccia windows
	///	 S: Missione inserita mediante interfaccia web
	///</summary>
	public String flagweb{ 
		get {if (this["flagweb"]==DBNull.Value)return null; return  (String)this["flagweb"];}
		set {if (value==null) this["flagweb"]= DBNull.Value; else this["flagweb"]= value;}
	}
	public object flagwebValue { 
		get{ return this["flagweb"];}
		set {if (value==null|| value==DBNull.Value) this["flagweb"]= DBNull.Value; else this["flagweb"]= value;}
	}
	public String flagwebOriginal { 
		get {if (this["flagweb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagweb",DataRowVersion.Original];}
	}
	///<summary>
	///Km percorsi a piedi
	///</summary>
	public Decimal? footkm{ 
		get {if (this["footkm"]==DBNull.Value)return null; return  (Decimal?)this["footkm"];}
		set {if (value==null) this["footkm"]= DBNull.Value; else this["footkm"]= value;}
	}
	public object footkmValue { 
		get{ return this["footkm"];}
		set {if (value==null|| value==DBNull.Value) this["footkm"]= DBNull.Value; else this["footkm"]= value;}
	}
	public Decimal? footkmOriginal { 
		get {if (this["footkm",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["footkm",DataRowVersion.Original];}
	}
	///<summary>
	///Costo a Km per percorso a piedi
	///</summary>
	public Decimal? footkmcost{ 
		get {if (this["footkmcost"]==DBNull.Value)return null; return  (Decimal?)this["footkmcost"];}
		set {if (value==null) this["footkmcost"]= DBNull.Value; else this["footkmcost"]= value;}
	}
	public object footkmcostValue { 
		get{ return this["footkmcost"];}
		set {if (value==null|| value==DBNull.Value) this["footkmcost"]= DBNull.Value; else this["footkmcost"]= value;}
	}
	public Decimal? footkmcostOriginal { 
		get {if (this["footkmcost",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["footkmcost",DataRowVersion.Original];}
	}
	///<summary>
	///Coeff. di lordizzazione
	///</summary>
	public Decimal? grossfactor{ 
		get {if (this["grossfactor"]==DBNull.Value)return null; return  (Decimal?)this["grossfactor"];}
		set {if (value==null) this["grossfactor"]= DBNull.Value; else this["grossfactor"]= value;}
	}
	public object grossfactorValue { 
		get{ return this["grossfactor"];}
		set {if (value==null|| value==DBNull.Value) this["grossfactor"]= DBNull.Value; else this["grossfactor"]= value;}
	}
	public Decimal? grossfactorOriginal { 
		get {if (this["grossfactor",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["grossfactor",DataRowVersion.Original];}
	}
	///<summary>
	///id causale (tabella acccmotive)
	///</summary>
	public String idaccmotive{ 
		get {if (this["idaccmotive"]==DBNull.Value)return null; return  (String)this["idaccmotive"];}
		set {if (value==null) this["idaccmotive"]= DBNull.Value; else this["idaccmotive"]= value;}
	}
	public object idaccmotiveValue { 
		get{ return this["idaccmotive"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive"]= DBNull.Value; else this["idaccmotive"]= value;}
	}
	public String idaccmotiveOriginal { 
		get {if (this["idaccmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive",DataRowVersion.Original];}
	}
	///<summary>
	///Id causale di debito - correzione (tabella accmotive)
	///</summary>
	public String idaccmotivedebit_crg{ 
		get {if (this["idaccmotivedebit_crg"]==DBNull.Value)return null; return  (String)this["idaccmotivedebit_crg"];}
		set {if (value==null) this["idaccmotivedebit_crg"]= DBNull.Value; else this["idaccmotivedebit_crg"]= value;}
	}
	public object idaccmotivedebit_crgValue { 
		get{ return this["idaccmotivedebit_crg"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotivedebit_crg"]= DBNull.Value; else this["idaccmotivedebit_crg"]= value;}
	}
	public String idaccmotivedebit_crgOriginal { 
		get {if (this["idaccmotivedebit_crg",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotivedebit_crg",DataRowVersion.Original];}
	}
	///<summary>
	///Data correzione causale di debito
	///</summary>
	public DateTime? idaccmotivedebit_datacrg{ 
		get {if (this["idaccmotivedebit_datacrg"]==DBNull.Value)return null; return  (DateTime?)this["idaccmotivedebit_datacrg"];}
		set {if (value==null) this["idaccmotivedebit_datacrg"]= DBNull.Value; else this["idaccmotivedebit_datacrg"]= value;}
	}
	public object idaccmotivedebit_datacrgValue { 
		get{ return this["idaccmotivedebit_datacrg"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotivedebit_datacrg"]= DBNull.Value; else this["idaccmotivedebit_datacrg"]= value;}
	}
	public DateTime? idaccmotivedebit_datacrgOriginal { 
		get {if (this["idaccmotivedebit_datacrg",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["idaccmotivedebit_datacrg",DataRowVersion.Original];}
	}
	///<summary>
	///id modello autorizzativo (tabella authmodel)
	///</summary>
	public Int32? idauthmodel{ 
		get {if (this["idauthmodel"]==DBNull.Value)return null; return  (Int32?)this["idauthmodel"];}
		set {if (value==null) this["idauthmodel"]= DBNull.Value; else this["idauthmodel"]= value;}
	}
	public object idauthmodelValue { 
		get{ return this["idauthmodel"];}
		set {if (value==null|| value==DBNull.Value) this["idauthmodel"]= DBNull.Value; else this["idauthmodel"]= value;}
	}
	public Int32? idauthmodelOriginal { 
		get {if (this["idauthmodel",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idauthmodel",DataRowVersion.Original];}
	}
	///<summary>
	///Località di partenza se diversa da quella di servizio
	///</summary>
	public Int32? idcity_start{ 
		get {if (this["idcity_start"]==DBNull.Value)return null; return  (Int32?)this["idcity_start"];}
		set {if (value==null) this["idcity_start"]= DBNull.Value; else this["idcity_start"]= value;}
	}
	public object idcity_startValue { 
		get{ return this["idcity_start"];}
		set {if (value==null|| value==DBNull.Value) this["idcity_start"]= DBNull.Value; else this["idcity_start"]= value;}
	}
	public Int32? idcity_startOriginal { 
		get {if (this["idcity_start",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcity_start",DataRowVersion.Original];}
	}
	///<summary>
	///Codice qualifica Dalia
	///</summary>
	public Int32? iddaliaposition{ 
		get {if (this["iddaliaposition"]==DBNull.Value)return null; return  (Int32?)this["iddaliaposition"];}
		set {if (value==null) this["iddaliaposition"]= DBNull.Value; else this["iddaliaposition"]= value;}
	}
	public object iddaliapositionValue { 
		get{ return this["iddaliaposition"];}
		set {if (value==null|| value==DBNull.Value) this["iddaliaposition"]= DBNull.Value; else this["iddaliaposition"]= value;}
	}
	public Int32? iddaliapositionOriginal { 
		get {if (this["iddaliaposition",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddaliaposition",DataRowVersion.Original];}
	}
	public Int32? iddaliarecruitmentmotive{ 
		get {if (this["iddaliarecruitmentmotive"]==DBNull.Value)return null; return  (Int32?)this["iddaliarecruitmentmotive"];}
		set {if (value==null) this["iddaliarecruitmentmotive"]= DBNull.Value; else this["iddaliarecruitmentmotive"]= value;}
	}
	public object iddaliarecruitmentmotiveValue { 
		get{ return this["iddaliarecruitmentmotive"];}
		set {if (value==null|| value==DBNull.Value) this["iddaliarecruitmentmotive"]= DBNull.Value; else this["iddaliarecruitmentmotive"]= value;}
	}
	public Int32? iddaliarecruitmentmotiveOriginal { 
		get {if (this["iddaliarecruitmentmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddaliarecruitmentmotive",DataRowVersion.Original];}
	}
	public Int32? idforeigncountry{ 
		get {if (this["idforeigncountry"]==DBNull.Value)return null; return  (Int32?)this["idforeigncountry"];}
		set {if (value==null) this["idforeigncountry"]= DBNull.Value; else this["idforeigncountry"]= value;}
	}
	public object idforeigncountryValue { 
		get{ return this["idforeigncountry"];}
		set {if (value==null|| value==DBNull.Value) this["idforeigncountry"]= DBNull.Value; else this["idforeigncountry"]= value;}
	}
	public Int32? idforeigncountryOriginal { 
		get {if (this["idforeigncountry",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idforeigncountry",DataRowVersion.Original];}
	}
	///<summary>
	///id missione (tabella itineration)
	///</summary>
	public Int32? iditineration{ 
		get {if (this["iditineration"]==DBNull.Value)return null; return  (Int32?)this["iditineration"];}
		set {if (value==null) this["iditineration"]= DBNull.Value; else this["iditineration"]= value;}
	}
	public object iditinerationValue { 
		get{ return this["iditineration"];}
		set {if (value==null|| value==DBNull.Value) this["iditineration"]= DBNull.Value; else this["iditineration"]= value;}
	}
	public Int32? iditinerationOriginal { 
		get {if (this["iditineration",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iditineration",DataRowVersion.Original];}
	}
	public Int32? iditineration_ref{ 
		get {if (this["iditineration_ref"]==DBNull.Value)return null; return  (Int32?)this["iditineration_ref"];}
		set {if (value==null) this["iditineration_ref"]= DBNull.Value; else this["iditineration_ref"]= value;}
	}
	public object iditineration_refValue { 
		get{ return this["iditineration_ref"];}
		set {if (value==null|| value==DBNull.Value) this["iditineration_ref"]= DBNull.Value; else this["iditineration_ref"]= value;}
	}
	public Int32? iditineration_refOriginal { 
		get {if (this["iditineration_ref",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iditineration_ref",DataRowVersion.Original];}
	}
	///<summary>
	///ID Stato missione (tabella itinerationstatus)
	///</summary>
	public Int32? iditinerationstatus{ 
		get {if (this["iditinerationstatus"]==DBNull.Value)return null; return  (Int32?)this["iditinerationstatus"];}
		set {if (value==null) this["iditinerationstatus"]= DBNull.Value; else this["iditinerationstatus"]= value;}
	}
	public object iditinerationstatusValue { 
		get{ return this["iditinerationstatus"];}
		set {if (value==null|| value==DBNull.Value) this["iditinerationstatus"]= DBNull.Value; else this["iditinerationstatus"]= value;}
	}
	public Int32? iditinerationstatusOriginal { 
		get {if (this["iditinerationstatus",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iditinerationstatus",DataRowVersion.Original];}
	}
	///<summary>
	///id anagrafica (tabella registry)
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
	///id progressivo pos. giuridica
	///</summary>
	public Int32? idregistrylegalstatus{ 
		get {if (this["idregistrylegalstatus"]==DBNull.Value)return null; return  (Int32?)this["idregistrylegalstatus"];}
		set {if (value==null) this["idregistrylegalstatus"]= DBNull.Value; else this["idregistrylegalstatus"]= value;}
	}
	public object idregistrylegalstatusValue { 
		get{ return this["idregistrylegalstatus"];}
		set {if (value==null|| value==DBNull.Value) this["idregistrylegalstatus"]= DBNull.Value; else this["idregistrylegalstatus"]= value;}
	}
	public Int32? idregistrylegalstatusOriginal { 
		get {if (this["idregistrylegalstatus",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idregistrylegalstatus",DataRowVersion.Original];}
	}
	public Int32? idregistrypaymethod{ 
		get {if (this["idregistrypaymethod"]==DBNull.Value)return null; return  (Int32?)this["idregistrypaymethod"];}
		set {if (value==null) this["idregistrypaymethod"]= DBNull.Value; else this["idregistrypaymethod"]= value;}
	}
	public object idregistrypaymethodValue { 
		get{ return this["idregistrypaymethod"];}
		set {if (value==null|| value==DBNull.Value) this["idregistrypaymethod"]= DBNull.Value; else this["idregistrypaymethod"]= value;}
	}
	public Int32? idregistrypaymethodOriginal { 
		get {if (this["idregistrypaymethod",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idregistrypaymethod",DataRowVersion.Original];}
	}
	///<summary>
	///chiave prestazione (tabella service)
	///</summary>
	public Int32? idser{ 
		get {if (this["idser"]==DBNull.Value)return null; return  (Int32?)this["idser"];}
		set {if (value==null) this["idser"]= DBNull.Value; else this["idser"]= value;}
	}
	public object idserValue { 
		get{ return this["idser"];}
		set {if (value==null|| value==DBNull.Value) this["idser"]= DBNull.Value; else this["idser"]= value;}
	}
	public Int32? idserOriginal { 
		get {if (this["idser",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idser",DataRowVersion.Original];}
	}
	///<summary>
	///id della class. siope (idsor di sorting) per il costo
	///</summary>
	public Int32? idsor_siope{ 
		get {if (this["idsor_siope"]==DBNull.Value)return null; return  (Int32?)this["idsor_siope"];}
		set {if (value==null) this["idsor_siope"]= DBNull.Value; else this["idsor_siope"]= value;}
	}
	public object idsor_siopeValue { 
		get{ return this["idsor_siope"];}
		set {if (value==null|| value==DBNull.Value) this["idsor_siope"]= DBNull.Value; else this["idsor_siope"]= value;}
	}
	public Int32? idsor_siopeOriginal { 
		get {if (this["idsor_siope",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor_siope",DataRowVersion.Original];}
	}
	///<summary>
	///id voce analitica 1(tabella sorting)
	///</summary>
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
	///<summary>
	///id voce analitica 2(tabella sorting)
	///</summary>
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
	///<summary>
	///id voce analitica 3(tabella sorting)
	///</summary>
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
	///ubicazione
	///</summary>
	public String location{ 
		get {if (this["location"]==DBNull.Value)return null; return  (String)this["location"];}
		set {if (value==null) this["location"]= DBNull.Value; else this["location"]= value;}
	}
	public object locationValue { 
		get{ return this["location"];}
		set {if (value==null|| value==DBNull.Value) this["location"]= DBNull.Value; else this["location"]= value;}
	}
	public String locationOriginal { 
		get {if (this["location",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["location",DataRowVersion.Original];}
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
	///Importo Netto
	///</summary>
	public Decimal? netfee{ 
		get {if (this["netfee"]==DBNull.Value)return null; return  (Decimal?)this["netfee"];}
		set {if (value==null) this["netfee"]= DBNull.Value; else this["netfee"]= value;}
	}
	public object netfeeValue { 
		get{ return this["netfee"];}
		set {if (value==null|| value==DBNull.Value) this["netfee"]= DBNull.Value; else this["netfee"]= value;}
	}
	public Decimal? netfeeOriginal { 
		get {if (this["netfee",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["netfee",DataRowVersion.Original];}
	}
	public Int32? nfood{ 
		get {if (this["nfood"]==DBNull.Value)return null; return  (Int32?)this["nfood"];}
		set {if (value==null) this["nfood"]= DBNull.Value; else this["nfood"]= value;}
	}
	public object nfoodValue { 
		get{ return this["nfood"];}
		set {if (value==null|| value==DBNull.Value) this["nfood"]= DBNull.Value; else this["nfood"]= value;}
	}
	public Int32? nfoodOriginal { 
		get {if (this["nfood",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nfood",DataRowVersion.Original];}
	}
	///<summary>
	///Num. miss.
	///</summary>
	public Int32? nitineration{ 
		get {if (this["nitineration"]==DBNull.Value)return null; return  (Int32?)this["nitineration"];}
		set {if (value==null) this["nitineration"]= DBNull.Value; else this["nitineration"]= value;}
	}
	public object nitinerationValue { 
		get{ return this["nitineration"];}
		set {if (value==null|| value==DBNull.Value) this["nitineration"]= DBNull.Value; else this["nitineration"]= value;}
	}
	public Int32? nitinerationOriginal { 
		get {if (this["nitineration",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nitineration",DataRowVersion.Original];}
	}
	///<summary>
	///Motivo di rifiuto autorizzazione
	///</summary>
	public String noauthreason{ 
		get {if (this["noauthreason"]==DBNull.Value)return null; return  (String)this["noauthreason"];}
		set {if (value==null) this["noauthreason"]= DBNull.Value; else this["noauthreason"]= value;}
	}
	public object noauthreasonValue { 
		get{ return this["noauthreason"];}
		set {if (value==null|| value==DBNull.Value) this["noauthreason"]= DBNull.Value; else this["noauthreason"]= value;}
	}
	public String noauthreasonOriginal { 
		get {if (this["noauthreason",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["noauthreason",DataRowVersion.Original];}
	}
	///<summary>
	///Sussistenza motivi che prevedono utilizzo mezzi diversi da treno o aereo
	///</summary>
	public String othervehicle{ 
		get {if (this["othervehicle"]==DBNull.Value)return null; return  (String)this["othervehicle"];}
		set {if (value==null) this["othervehicle"]= DBNull.Value; else this["othervehicle"]= value;}
	}
	public object othervehicleValue { 
		get{ return this["othervehicle"];}
		set {if (value==null|| value==DBNull.Value) this["othervehicle"]= DBNull.Value; else this["othervehicle"]= value;}
	}
	public String othervehicleOriginal { 
		get {if (this["othervehicle",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["othervehicle",DataRowVersion.Original];}
	}
	///<summary>
	///Motivazioni
	///</summary>
	public String othervehiclereason{ 
		get {if (this["othervehiclereason"]==DBNull.Value)return null; return  (String)this["othervehiclereason"];}
		set {if (value==null) this["othervehiclereason"]= DBNull.Value; else this["othervehiclereason"]= value;}
	}
	public object othervehiclereasonValue { 
		get{ return this["othervehiclereason"];}
		set {if (value==null|| value==DBNull.Value) this["othervehiclereason"]= DBNull.Value; else this["othervehiclereason"]= value;}
	}
	public String othervehiclereasonOriginal { 
		get {if (this["othervehiclereason",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["othervehiclereason",DataRowVersion.Original];}
	}
	///<summary>
	///Km percorsi con mezzo proprio
	///</summary>
	public Decimal? owncarkm{ 
		get {if (this["owncarkm"]==DBNull.Value)return null; return  (Decimal?)this["owncarkm"];}
		set {if (value==null) this["owncarkm"]= DBNull.Value; else this["owncarkm"]= value;}
	}
	public object owncarkmValue { 
		get{ return this["owncarkm"];}
		set {if (value==null|| value==DBNull.Value) this["owncarkm"]= DBNull.Value; else this["owncarkm"]= value;}
	}
	public Decimal? owncarkmOriginal { 
		get {if (this["owncarkm",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["owncarkm",DataRowVersion.Original];}
	}
	///<summary>
	///Costo a Km per utilizzo mezzo proprio
	///</summary>
	public Decimal? owncarkmcost{ 
		get {if (this["owncarkmcost"]==DBNull.Value)return null; return  (Decimal?)this["owncarkmcost"];}
		set {if (value==null) this["owncarkmcost"]= DBNull.Value; else this["owncarkmcost"]= value;}
	}
	public object owncarkmcostValue { 
		get{ return this["owncarkmcost"];}
		set {if (value==null|| value==DBNull.Value) this["owncarkmcost"]= DBNull.Value; else this["owncarkmcost"]= value;}
	}
	public Decimal? owncarkmcostOriginal { 
		get {if (this["owncarkmcost",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["owncarkmcost",DataRowVersion.Original];}
	}
	///<summary>
	///Conoscenza regolamento
	///</summary>
	public String regulationaccept{ 
		get {if (this["regulationaccept"]==DBNull.Value)return null; return  (String)this["regulationaccept"];}
		set {if (value==null) this["regulationaccept"]= DBNull.Value; else this["regulationaccept"]= value;}
	}
	public object regulationacceptValue { 
		get{ return this["regulationaccept"];}
		set {if (value==null|| value==DBNull.Value) this["regulationaccept"]= DBNull.Value; else this["regulationaccept"]= value;}
	}
	public String regulationacceptOriginal { 
		get {if (this["regulationaccept",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["regulationaccept",DataRowVersion.Original];}
	}
	///<summary>
	///allegati
	///</summary>
	public Byte[] rtf{ 
		get {if (this["rtf"]==DBNull.Value)return null; return  (Byte[])this["rtf"];}
		set {if (value==null) this["rtf"]= DBNull.Value; else this["rtf"]= value;}
	}
	public object rtfValue { 
		get{ return this["rtf"];}
		set {if (value==null|| value==DBNull.Value) this["rtf"]= DBNull.Value; else this["rtf"]= value;}
	}
	public Byte[] rtfOriginal { 
		get {if (this["rtf",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte[])this["rtf",DataRowVersion.Original];}
	}
	///<summary>
	///data inizio
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
	///Motivi che giustificano località di partenza diversa diversa
	///</summary>
	public String startreason{ 
		get {if (this["startreason"]==DBNull.Value)return null; return  (String)this["startreason"];}
		set {if (value==null) this["startreason"]= DBNull.Value; else this["startreason"]= value;}
	}
	public object startreasonValue { 
		get{ return this["startreason"];}
		set {if (value==null|| value==DBNull.Value) this["startreason"]= DBNull.Value; else this["startreason"]= value;}
	}
	public String startreasonOriginal { 
		get {if (this["startreason",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["startreason",DataRowVersion.Original];}
	}
	///<summary>
	///data fine
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
	public Decimal? supposedamount{ 
		get {if (this["supposedamount"]==DBNull.Value)return null; return  (Decimal?)this["supposedamount"];}
		set {if (value==null) this["supposedamount"]= DBNull.Value; else this["supposedamount"]= value;}
	}
	public object supposedamountValue { 
		get{ return this["supposedamount"];}
		set {if (value==null|| value==DBNull.Value) this["supposedamount"]= DBNull.Value; else this["supposedamount"]= value;}
	}
	public Decimal? supposedamountOriginal { 
		get {if (this["supposedamount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["supposedamount",DataRowVersion.Original];}
	}
	public Decimal? supposedfood{ 
		get {if (this["supposedfood"]==DBNull.Value)return null; return  (Decimal?)this["supposedfood"];}
		set {if (value==null) this["supposedfood"]= DBNull.Value; else this["supposedfood"]= value;}
	}
	public object supposedfoodValue { 
		get{ return this["supposedfood"];}
		set {if (value==null|| value==DBNull.Value) this["supposedfood"]= DBNull.Value; else this["supposedfood"]= value;}
	}
	public Decimal? supposedfoodOriginal { 
		get {if (this["supposedfood",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["supposedfood",DataRowVersion.Original];}
	}
	public Decimal? supposedliving{ 
		get {if (this["supposedliving"]==DBNull.Value)return null; return  (Decimal?)this["supposedliving"];}
		set {if (value==null) this["supposedliving"]= DBNull.Value; else this["supposedliving"]= value;}
	}
	public object supposedlivingValue { 
		get{ return this["supposedliving"];}
		set {if (value==null|| value==DBNull.Value) this["supposedliving"]= DBNull.Value; else this["supposedliving"]= value;}
	}
	public Decimal? supposedlivingOriginal { 
		get {if (this["supposedliving",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["supposedliving",DataRowVersion.Original];}
	}
	public Decimal? supposedtravel{ 
		get {if (this["supposedtravel"]==DBNull.Value)return null; return  (Decimal?)this["supposedtravel"];}
		set {if (value==null) this["supposedtravel"]= DBNull.Value; else this["supposedtravel"]= value;}
	}
	public object supposedtravelValue { 
		get{ return this["supposedtravel"];}
		set {if (value==null|| value==DBNull.Value) this["supposedtravel"]= DBNull.Value; else this["supposedtravel"]= value;}
	}
	public Decimal? supposedtravelOriginal { 
		get {if (this["supposedtravel",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["supposedtravel",DataRowVersion.Original];}
	}
	///<summary>
	///Anticipo
	///</summary>
	public Decimal? totadvance{ 
		get {if (this["totadvance"]==DBNull.Value)return null; return  (Decimal?)this["totadvance"];}
		set {if (value==null) this["totadvance"]= DBNull.Value; else this["totadvance"]= value;}
	}
	public object totadvanceValue { 
		get{ return this["totadvance"];}
		set {if (value==null|| value==DBNull.Value) this["totadvance"]= DBNull.Value; else this["totadvance"]= value;}
	}
	public Decimal? totadvanceOriginal { 
		get {if (this["totadvance",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["totadvance",DataRowVersion.Original];}
	}
	///<summary>
	///Totale
	///</summary>
	public Decimal? total{ 
		get {if (this["total"]==DBNull.Value)return null; return  (Decimal?)this["total"];}
		set {if (value==null) this["total"]= DBNull.Value; else this["total"]= value;}
	}
	public object totalValue { 
		get{ return this["total"];}
		set {if (value==null|| value==DBNull.Value) this["total"]= DBNull.Value; else this["total"]= value;}
	}
	public Decimal? totalOriginal { 
		get {if (this["total",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["total",DataRowVersion.Original];}
	}
	///<summary>
	///Importo Lordo
	///</summary>
	public Decimal? totalgross{ 
		get {if (this["totalgross"]==DBNull.Value)return null; return  (Decimal?)this["totalgross"];}
		set {if (value==null) this["totalgross"]= DBNull.Value; else this["totalgross"]= value;}
	}
	public object totalgrossValue { 
		get{ return this["totalgross"];}
		set {if (value==null|| value==DBNull.Value) this["totalgross"]= DBNull.Value; else this["totalgross"]= value;}
	}
	public Decimal? totalgrossOriginal { 
		get {if (this["totalgross",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["totalgross",DataRowVersion.Original];}
	}
	///<summary>
	///note testuali
	///</summary>
	public String txt{ 
		get {if (this["txt"]==DBNull.Value)return null; return  (String)this["txt"];}
		set {if (value==null) this["txt"]= DBNull.Value; else this["txt"]= value;}
	}
	public object txtValue { 
		get{ return this["txt"];}
		set {if (value==null|| value==DBNull.Value) this["txt"]= DBNull.Value; else this["txt"]= value;}
	}
	public String txtOriginal { 
		get {if (this["txt",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["txt",DataRowVersion.Original];}
	}
	///<summary>
	///Dati identificativi del veicolo
	///</summary>
	public String vehicle_info{ 
		get {if (this["vehicle_info"]==DBNull.Value)return null; return  (String)this["vehicle_info"];}
		set {if (value==null) this["vehicle_info"]= DBNull.Value; else this["vehicle_info"]= value;}
	}
	public object vehicle_infoValue { 
		get{ return this["vehicle_info"];}
		set {if (value==null|| value==DBNull.Value) this["vehicle_info"]= DBNull.Value; else this["vehicle_info"]= value;}
	}
	public String vehicle_infoOriginal { 
		get {if (this["vehicle_info",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["vehicle_info",DataRowVersion.Original];}
	}
	///<summary>
	///Causale per utilizzo mezzo
	///</summary>
	public String vehicle_motive{ 
		get {if (this["vehicle_motive"]==DBNull.Value)return null; return  (String)this["vehicle_motive"];}
		set {if (value==null) this["vehicle_motive"]= DBNull.Value; else this["vehicle_motive"]= value;}
	}
	public object vehicle_motiveValue { 
		get{ return this["vehicle_motive"];}
		set {if (value==null|| value==DBNull.Value) this["vehicle_motive"]= DBNull.Value; else this["vehicle_motive"]= value;}
	}
	public String vehicle_motiveOriginal { 
		get {if (this["vehicle_motive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["vehicle_motive",DataRowVersion.Original];}
	}
	///<summary>
	///Avvisi per il Richiedente
	///</summary>
	public String webwarn{ 
		get {if (this["webwarn"]==DBNull.Value)return null; return  (String)this["webwarn"];}
		set {if (value==null) this["webwarn"]= DBNull.Value; else this["webwarn"]= value;}
	}
	public object webwarnValue { 
		get{ return this["webwarn"];}
		set {if (value==null|| value==DBNull.Value) this["webwarn"]= DBNull.Value; else this["webwarn"]= value;}
	}
	public String webwarnOriginal { 
		get {if (this["webwarn",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["webwarn",DataRowVersion.Original];}
	}
	///<summary>
	///Eserc. miss.
	///</summary>
	public Int32? yitineration{ 
		get {if (this["yitineration"]==DBNull.Value)return null; return  (Int32?)this["yitineration"];}
		set {if (value==null) this["yitineration"]= DBNull.Value; else this["yitineration"]= value;}
	}
	public object yitinerationValue { 
		get{ return this["yitineration"];}
		set {if (value==null|| value==DBNull.Value) this["yitineration"]= DBNull.Value; else this["yitineration"]= value;}
	}
	public Int32? yitinerationOriginal { 
		get {if (this["yitineration",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["yitineration",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Missione
///</summary>
public class itinerationTable : MetaTableBase<itinerationRow> {
	public itinerationTable() : base("itineration"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"active",createColumn("active",typeof(string),true,false)},
			{"adate",createColumn("adate",typeof(DateTime),false,false)},
			{"additionalannotations",createColumn("additionalannotations",typeof(string),true,false)},
			{"admincarkm",createColumn("admincarkm",typeof(decimal),true,false)},
			{"admincarkmcost",createColumn("admincarkmcost",typeof(decimal),false,false)},
			{"advanceapplied",createColumn("advanceapplied",typeof(string),true,false)},
			{"advancepercentage",createColumn("advancepercentage",typeof(decimal),true,false)},
			{"applierannotations",createColumn("applierannotations",typeof(string),true,false)},
			{"authdoc",createColumn("authdoc",typeof(string),true,false)},
			{"authdocdate",createColumn("authdocdate",typeof(DateTime),true,false)},
			{"authemployer",createColumn("authemployer",typeof(string),true,false)},
			{"authneeded",createColumn("authneeded",typeof(string),true,false)},
			{"authorizationdate",createColumn("authorizationdate",typeof(DateTime),false,false)},
			{"cancelreason",createColumn("cancelreason",typeof(string),true,false)},
			{"clause_accepted",createColumn("clause_accepted",typeof(string),true,false)},
			{"completed",createColumn("completed",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"datecompleted",createColumn("datecompleted",typeof(DateTime),true,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"destination",createColumn("destination",typeof(string),true,false)},
			{"differentlocation",createColumn("differentlocation",typeof(string),true,false)},
			{"flagmove",createColumn("flagmove",typeof(int),true,false)},
			{"flagoutside",createColumn("flagoutside",typeof(string),true,false)},
			{"flagownfunds",createColumn("flagownfunds",typeof(string),true,false)},
			{"flagweb",createColumn("flagweb",typeof(string),true,false)},
			{"footkm",createColumn("footkm",typeof(decimal),true,false)},
			{"footkmcost",createColumn("footkmcost",typeof(decimal),true,false)},
			{"grossfactor",createColumn("grossfactor",typeof(decimal),true,false)},
			{"idaccmotive",createColumn("idaccmotive",typeof(string),true,false)},
			{"idaccmotivedebit_crg",createColumn("idaccmotivedebit_crg",typeof(string),true,false)},
			{"idaccmotivedebit_datacrg",createColumn("idaccmotivedebit_datacrg",typeof(DateTime),true,false)},
			{"idauthmodel",createColumn("idauthmodel",typeof(int),true,false)},
			{"idcity_start",createColumn("idcity_start",typeof(int),true,false)},
			{"iddaliaposition",createColumn("iddaliaposition",typeof(int),true,false)},
			{"iddaliarecruitmentmotive",createColumn("iddaliarecruitmentmotive",typeof(int),true,false)},
			{"idforeigncountry",createColumn("idforeigncountry",typeof(int),true,false)},
			{"iditineration",createColumn("iditineration",typeof(int),false,false)},
			{"iditineration_ref",createColumn("iditineration_ref",typeof(int),true,false)},
			{"iditinerationstatus",createColumn("iditinerationstatus",typeof(int),true,false)},
			{"idreg",createColumn("idreg",typeof(int),false,false)},
			{"idregistrylegalstatus",createColumn("idregistrylegalstatus",typeof(int),true,false)},
			{"idregistrypaymethod",createColumn("idregistrypaymethod",typeof(int),true,false)},
			{"idser",createColumn("idser",typeof(int),false,false)},
			{"idsor_siope",createColumn("idsor_siope",typeof(int),true,false)},
			{"idsor1",createColumn("idsor1",typeof(int),true,false)},
			{"idsor2",createColumn("idsor2",typeof(int),true,false)},
			{"idsor3",createColumn("idsor3",typeof(int),true,false)},
			{"idupb",createColumn("idupb",typeof(string),true,false)},
			{"location",createColumn("location",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"netfee",createColumn("netfee",typeof(decimal),true,false)},
			{"nfood",createColumn("nfood",typeof(int),true,false)},
			{"nitineration",createColumn("nitineration",typeof(int),false,false)},
			{"noauthreason",createColumn("noauthreason",typeof(string),true,false)},
			{"othervehicle",createColumn("othervehicle",typeof(string),true,false)},
			{"othervehiclereason",createColumn("othervehiclereason",typeof(string),true,false)},
			{"owncarkm",createColumn("owncarkm",typeof(decimal),true,false)},
			{"owncarkmcost",createColumn("owncarkmcost",typeof(decimal),true,false)},
			{"regulationaccept",createColumn("regulationaccept",typeof(string),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"start",createColumn("start",typeof(DateTime),false,false)},
			{"startreason",createColumn("startreason",typeof(string),true,false)},
			{"stop",createColumn("stop",typeof(DateTime),false,false)},
			{"supposedamount",createColumn("supposedamount",typeof(decimal),true,false)},
			{"supposedfood",createColumn("supposedfood",typeof(decimal),true,false)},
			{"supposedliving",createColumn("supposedliving",typeof(decimal),true,false)},
			{"supposedtravel",createColumn("supposedtravel",typeof(decimal),true,false)},
			{"totadvance",createColumn("totadvance",typeof(decimal),true,false)},
			{"total",createColumn("total",typeof(decimal),true,false)},
			{"totalgross",createColumn("totalgross",typeof(decimal),true,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"vehicle_info",createColumn("vehicle_info",typeof(string),true,false)},
			{"vehicle_motive",createColumn("vehicle_motive",typeof(string),true,false)},
			{"webwarn",createColumn("webwarn",typeof(string),true,false)},
			{"yitineration",createColumn("yitineration",typeof(int),false,false)},
		};
	}
}
}
