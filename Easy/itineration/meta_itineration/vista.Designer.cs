
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
	///Num. miss.
	///</summary>
	public Int32 nitineration{ 
		get {return  (Int32)this["nitineration"];}
		set {this["nitineration"]= value;}
	}
	public object nitinerationValue { 
		get{ return this["nitineration"];}
		set {this["nitineration"]= value;}
	}
	public Int32 nitinerationOriginal { 
		get {return  (Int32)this["nitineration",DataRowVersion.Original];}
	}
	///<summary>
	///Eserc. miss.
	///</summary>
	public Int16 yitineration{ 
		get {return  (Int16)this["yitineration"];}
		set {this["yitineration"]= value;}
	}
	public object yitinerationValue { 
		get{ return this["yitineration"];}
		set {this["yitineration"]= value;}
	}
	public Int16 yitinerationOriginal { 
		get {return  (Int16)this["yitineration",DataRowVersion.Original];}
	}
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
	public DateTime adate{ 
		get {return  (DateTime)this["adate"];}
		set {this["adate"]= value;}
	}
	public object adateValue { 
		get{ return this["adate"];}
		set {this["adate"]= value;}
	}
	public DateTime adateOriginal { 
		get {return  (DateTime)this["adate",DataRowVersion.Original];}
	}
	///<summary>
	///Km percorsi con mezzo amministrazione
	///</summary>
	public Double? admincarkm{ 
		get {if (this["admincarkm"]==DBNull.Value)return null; return  (Double?)this["admincarkm"];}
		set {if (value==null) this["admincarkm"]= DBNull.Value; else this["admincarkm"]= value;}
	}
	public object admincarkmValue { 
		get{ return this["admincarkm"];}
		set {if (value==null|| value==DBNull.Value) this["admincarkm"]= DBNull.Value; else this["admincarkm"]= value;}
	}
	public Double? admincarkmOriginal { 
		get {if (this["admincarkm",DataRowVersion.Original]==DBNull.Value)return null; return  (Double?)this["admincarkm",DataRowVersion.Original];}
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
	///<summary>
	///Data autorizz.
	///</summary>
	public DateTime authorizationdate{ 
		get {return  (DateTime)this["authorizationdate"];}
		set {this["authorizationdate"]= value;}
	}
	public object authorizationdateValue { 
		get{ return this["authorizationdate"];}
		set {this["authorizationdate"]= value;}
	}
	public DateTime authorizationdateOriginal { 
		get {return  (DateTime)this["authorizationdate",DataRowVersion.Original];}
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
	public DateTime ct{ 
		get {return  (DateTime)this["ct"];}
		set {this["ct"]= value;}
	}
	public object ctValue { 
		get{ return this["ct"];}
		set {this["ct"]= value;}
	}
	public DateTime ctOriginal { 
		get {return  (DateTime)this["ct",DataRowVersion.Original];}
	}
	///<summary>
	///nome utente creazione
	///</summary>
	public String cu{ 
		get {return  (String)this["cu"];}
		set {this["cu"]= value;}
	}
	public object cuValue { 
		get{ return this["cu"];}
		set {this["cu"]= value;}
	}
	public String cuOriginal { 
		get {return  (String)this["cu",DataRowVersion.Original];}
	}
	///<summary>
	///Descrizione
	///</summary>
	public String description{ 
		get {return  (String)this["description"];}
		set {this["description"]= value;}
	}
	public object descriptionValue { 
		get{ return this["description"];}
		set {this["description"]= value;}
	}
	public String descriptionOriginal { 
		get {return  (String)this["description",DataRowVersion.Original];}
	}
	///<summary>
	///Km percorsi a piedi
	///</summary>
	public Double? footkm{ 
		get {if (this["footkm"]==DBNull.Value)return null; return  (Double?)this["footkm"];}
		set {if (value==null) this["footkm"]= DBNull.Value; else this["footkm"]= value;}
	}
	public object footkmValue { 
		get{ return this["footkm"];}
		set {if (value==null|| value==DBNull.Value) this["footkm"]= DBNull.Value; else this["footkm"]= value;}
	}
	public Double? footkmOriginal { 
		get {if (this["footkm",DataRowVersion.Original]==DBNull.Value)return null; return  (Double?)this["footkm",DataRowVersion.Original];}
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
	public Double? grossfactor{ 
		get {if (this["grossfactor"]==DBNull.Value)return null; return  (Double?)this["grossfactor"];}
		set {if (value==null) this["grossfactor"]= DBNull.Value; else this["grossfactor"]= value;}
	}
	public object grossfactorValue { 
		get{ return this["grossfactor"];}
		set {if (value==null|| value==DBNull.Value) this["grossfactor"]= DBNull.Value; else this["grossfactor"]= value;}
	}
	public Double? grossfactorOriginal { 
		get {if (this["grossfactor",DataRowVersion.Original]==DBNull.Value)return null; return  (Double?)this["grossfactor",DataRowVersion.Original];}
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
	///id anagrafica (tabella registry)
	///</summary>
	public Int32 idreg{ 
		get {return  (Int32)this["idreg"];}
		set {this["idreg"]= value;}
	}
	public object idregValue { 
		get{ return this["idreg"];}
		set {this["idreg"]= value;}
	}
	public Int32 idregOriginal { 
		get {return  (Int32)this["idreg",DataRowVersion.Original];}
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
	///data ultima modifica
	///</summary>
	public DateTime lt{ 
		get {return  (DateTime)this["lt"];}
		set {this["lt"]= value;}
	}
	public object ltValue { 
		get{ return this["lt"];}
		set {this["lt"]= value;}
	}
	public DateTime ltOriginal { 
		get {return  (DateTime)this["lt",DataRowVersion.Original];}
	}
	///<summary>
	///nome ultimo utente modifica
	///</summary>
	public String lu{ 
		get {return  (String)this["lu"];}
		set {this["lu"]= value;}
	}
	public object luValue { 
		get{ return this["lu"];}
		set {this["lu"]= value;}
	}
	public String luOriginal { 
		get {return  (String)this["lu",DataRowVersion.Original];}
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
	///<summary>
	///Km percorsi con mezzo proprio
	///</summary>
	public Double? owncarkm{ 
		get {if (this["owncarkm"]==DBNull.Value)return null; return  (Double?)this["owncarkm"];}
		set {if (value==null) this["owncarkm"]= DBNull.Value; else this["owncarkm"]= value;}
	}
	public object owncarkmValue { 
		get{ return this["owncarkm"];}
		set {if (value==null|| value==DBNull.Value) this["owncarkm"]= DBNull.Value; else this["owncarkm"]= value;}
	}
	public Double? owncarkmOriginal { 
		get {if (this["owncarkm",DataRowVersion.Original]==DBNull.Value)return null; return  (Double?)this["owncarkm",DataRowVersion.Original];}
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
	public DateTime start{ 
		get {return  (DateTime)this["start"];}
		set {this["start"]= value;}
	}
	public object startValue { 
		get{ return this["start"];}
		set {this["start"]= value;}
	}
	public DateTime startOriginal { 
		get {return  (DateTime)this["start",DataRowVersion.Original];}
	}
	///<summary>
	///data fine
	///</summary>
	public DateTime stop{ 
		get {return  (DateTime)this["stop"];}
		set {this["stop"]= value;}
	}
	public object stopValue { 
		get{ return this["stop"];}
		set {this["stop"]= value;}
	}
	public DateTime stopOriginal { 
		get {return  (DateTime)this["stop",DataRowVersion.Original];}
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
	///chiave prestazione (tabella service)
	///</summary>
	public Int32 idser{ 
		get {return  (Int32)this["idser"];}
		set {this["idser"]= value;}
	}
	public object idserValue { 
		get{ return this["idser"];}
		set {this["idser"]= value;}
	}
	public Int32 idserOriginal { 
		get {return  (Int32)this["idser",DataRowVersion.Original];}
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
	///id missione (tabella itineration)
	///</summary>
	public Int32 iditineration{ 
		get {return  (Int32)this["iditineration"];}
		set {this["iditineration"]= value;}
	}
	public object iditinerationValue { 
		get{ return this["iditineration"];}
		set {this["iditineration"]= value;}
	}
	public Int32 iditinerationOriginal { 
		get {return  (Int32)this["iditineration",DataRowVersion.Original];}
	}
	///<summary>
	///Id della causale di debito (tabella accmotive) 
	///</summary>
	public String idaccmotivedebit{ 
		get {if (this["idaccmotivedebit"]==DBNull.Value)return null; return  (String)this["idaccmotivedebit"];}
		set {if (value==null) this["idaccmotivedebit"]= DBNull.Value; else this["idaccmotivedebit"]= value;}
	}
	public object idaccmotivedebitValue { 
		get{ return this["idaccmotivedebit"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotivedebit"]= DBNull.Value; else this["idaccmotivedebit"]= value;}
	}
	public String idaccmotivedebitOriginal { 
		get {if (this["idaccmotivedebit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotivedebit",DataRowVersion.Original];}
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
	///ID Stato missione (tabella itinerationstatus)
	///</summary>
	public Int16? iditinerationstatus{ 
		get {if (this["iditinerationstatus"]==DBNull.Value)return null; return  (Int16?)this["iditinerationstatus"];}
		set {if (value==null) this["iditinerationstatus"]= DBNull.Value; else this["iditinerationstatus"]= value;}
	}
	public object iditinerationstatusValue { 
		get{ return this["iditinerationstatus"];}
		set {if (value==null|| value==DBNull.Value) this["iditinerationstatus"]= DBNull.Value; else this["iditinerationstatus"]= value;}
	}
	public Int16? iditinerationstatusOriginal { 
		get {if (this["iditinerationstatus",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["iditinerationstatus",DataRowVersion.Original];}
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
	///id responsabile (tabella manager)
	///</summary>
	public Int32? idman{ 
		get {if (this["idman"]==DBNull.Value)return null; return  (Int32?)this["idman"];}
		set {if (value==null) this["idman"]= DBNull.Value; else this["idman"]= value;}
	}
	public object idmanValue { 
		get{ return this["idman"];}
		set {if (value==null|| value==DBNull.Value) this["idman"]= DBNull.Value; else this["idman"]= value;}
	}
	public Int32? idmanOriginal { 
		get {if (this["idman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idman",DataRowVersion.Original];}
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
	///id voce class.sicurezza 1(tabella sorting)
	///</summary>
	public Int32? idsor01{ 
		get {if (this["idsor01"]==DBNull.Value)return null; return  (Int32?)this["idsor01"];}
		set {if (value==null) this["idsor01"]= DBNull.Value; else this["idsor01"]= value;}
	}
	public object idsor01Value { 
		get{ return this["idsor01"];}
		set {if (value==null|| value==DBNull.Value) this["idsor01"]= DBNull.Value; else this["idsor01"]= value;}
	}
	public Int32? idsor01Original { 
		get {if (this["idsor01",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor01",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 2(tabella sorting)
	///</summary>
	public Int32? idsor02{ 
		get {if (this["idsor02"]==DBNull.Value)return null; return  (Int32?)this["idsor02"];}
		set {if (value==null) this["idsor02"]= DBNull.Value; else this["idsor02"]= value;}
	}
	public object idsor02Value { 
		get{ return this["idsor02"];}
		set {if (value==null|| value==DBNull.Value) this["idsor02"]= DBNull.Value; else this["idsor02"]= value;}
	}
	public Int32? idsor02Original { 
		get {if (this["idsor02",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor02",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 3(tabella sorting)
	///</summary>
	public Int32? idsor03{ 
		get {if (this["idsor03"]==DBNull.Value)return null; return  (Int32?)this["idsor03"];}
		set {if (value==null) this["idsor03"]= DBNull.Value; else this["idsor03"]= value;}
	}
	public object idsor03Value { 
		get{ return this["idsor03"];}
		set {if (value==null|| value==DBNull.Value) this["idsor03"]= DBNull.Value; else this["idsor03"]= value;}
	}
	public Int32? idsor03Original { 
		get {if (this["idsor03",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor03",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 4(tabella sorting)
	///</summary>
	public Int32? idsor04{ 
		get {if (this["idsor04"]==DBNull.Value)return null; return  (Int32?)this["idsor04"];}
		set {if (value==null) this["idsor04"]= DBNull.Value; else this["idsor04"]= value;}
	}
	public object idsor04Value { 
		get{ return this["idsor04"];}
		set {if (value==null|| value==DBNull.Value) this["idsor04"]= DBNull.Value; else this["idsor04"]= value;}
	}
	public Int32? idsor04Original { 
		get {if (this["idsor04",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor04",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 5(tabella sorting)
	///</summary>
	public Int32? idsor05{ 
		get {if (this["idsor05"]==DBNull.Value)return null; return  (Int32?)this["idsor05"];}
		set {if (value==null) this["idsor05"]= DBNull.Value; else this["idsor05"]= value;}
	}
	public object idsor05Value { 
		get{ return this["idsor05"];}
		set {if (value==null|| value==DBNull.Value) this["idsor05"]= DBNull.Value; else this["idsor05"]= value;}
	}
	public Int32? idsor05Original { 
		get {if (this["idsor05",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor05",DataRowVersion.Original];}
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
	public DateTime? starttime{ 
		get {if (this["starttime"]==DBNull.Value)return null; return  (DateTime?)this["starttime"];}
		set {if (value==null) this["starttime"]= DBNull.Value; else this["starttime"]= value;}
	}
	public object starttimeValue { 
		get{ return this["starttime"];}
		set {if (value==null|| value==DBNull.Value) this["starttime"]= DBNull.Value; else this["starttime"]= value;}
	}
	public DateTime? starttimeOriginal { 
		get {if (this["starttime",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["starttime",DataRowVersion.Original];}
	}
	public DateTime? stoptime{ 
		get {if (this["stoptime"]==DBNull.Value)return null; return  (DateTime?)this["stoptime"];}
		set {if (value==null) this["stoptime"]= DBNull.Value; else this["stoptime"]= value;}
	}
	public object stoptimeValue { 
		get{ return this["stoptime"];}
		set {if (value==null|| value==DBNull.Value) this["stoptime"]= DBNull.Value; else this["stoptime"]= value;}
	}
	public DateTime? stoptimeOriginal { 
		get {if (this["stoptime",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["stoptime",DataRowVersion.Original];}
	}
	public Int32? iddalia_funzionale{ 
		get {if (this["iddalia_funzionale"]==DBNull.Value)return null; return  (Int32?)this["iddalia_funzionale"];}
		set {if (value==null) this["iddalia_funzionale"]= DBNull.Value; else this["iddalia_funzionale"]= value;}
	}
	public object iddalia_funzionaleValue { 
		get{ return this["iddalia_funzionale"];}
		set {if (value==null|| value==DBNull.Value) this["iddalia_funzionale"]= DBNull.Value; else this["iddalia_funzionale"]= value;}
	}
	public Int32? iddalia_funzionaleOriginal { 
		get {if (this["iddalia_funzionale",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddalia_funzionale",DataRowVersion.Original];}
	}
	public Int32? iddalia_dipartimento{ 
		get {if (this["iddalia_dipartimento"]==DBNull.Value)return null; return  (Int32?)this["iddalia_dipartimento"];}
		set {if (value==null) this["iddalia_dipartimento"]= DBNull.Value; else this["iddalia_dipartimento"]= value;}
	}
	public object iddalia_dipartimentoValue { 
		get{ return this["iddalia_dipartimento"];}
		set {if (value==null|| value==DBNull.Value) this["iddalia_dipartimento"]= DBNull.Value; else this["iddalia_dipartimento"]= value;}
	}
	public Int32? iddalia_dipartimentoOriginal { 
		get {if (this["iddalia_dipartimento",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddalia_dipartimento",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Missione
///</summary>
public class itinerationTable : MetaTableBase<itinerationRow> {
	public itinerationTable() : base("itineration"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nitineration",createColumn("nitineration",typeof(int),false,false)},
			{"yitineration",createColumn("yitineration",typeof(short),false,false)},
			{"active",createColumn("active",typeof(string),true,false)},
			{"adate",createColumn("adate",typeof(DateTime),false,false)},
			{"admincarkm",createColumn("admincarkm",typeof(double),true,false)},
			{"admincarkmcost",createColumn("admincarkmcost",typeof(decimal),true,false)},
			{"authorizationdate",createColumn("authorizationdate",typeof(DateTime),false,false)},
			{"completed",createColumn("completed",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"footkm",createColumn("footkm",typeof(double),true,false)},
			{"footkmcost",createColumn("footkmcost",typeof(decimal),true,false)},
			{"grossfactor",createColumn("grossfactor",typeof(double),true,false)},
			{"idaccmotive",createColumn("idaccmotive",typeof(string),true,false)},
			{"idreg",createColumn("idreg",typeof(int),false,false)},
			{"idupb",createColumn("idupb",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"netfee",createColumn("netfee",typeof(decimal),true,false)},
			{"owncarkm",createColumn("owncarkm",typeof(double),true,false)},
			{"owncarkmcost",createColumn("owncarkmcost",typeof(decimal),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"start",createColumn("start",typeof(DateTime),false,false)},
			{"stop",createColumn("stop",typeof(DateTime),false,false)},
			{"totadvance",createColumn("totadvance",typeof(decimal),true,false)},
			{"total",createColumn("total",typeof(decimal),true,false)},
			{"totalgross",createColumn("totalgross",typeof(decimal),true,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"idser",createColumn("idser",typeof(int),false,false)},
			{"idsor1",createColumn("idsor1",typeof(int),true,false)},
			{"idsor2",createColumn("idsor2",typeof(int),true,false)},
			{"idsor3",createColumn("idsor3",typeof(int),true,false)},
			{"iditineration",createColumn("iditineration",typeof(int),false,false)},
			{"idaccmotivedebit",createColumn("idaccmotivedebit",typeof(string),true,false)},
			{"idaccmotivedebit_crg",createColumn("idaccmotivedebit_crg",typeof(string),true,false)},
			{"idaccmotivedebit_datacrg",createColumn("idaccmotivedebit_datacrg",typeof(DateTime),true,false)},
			{"idregistrylegalstatus",createColumn("idregistrylegalstatus",typeof(int),true,false)},
			{"flagweb",createColumn("flagweb",typeof(string),true,false)},
			{"iditinerationstatus",createColumn("iditinerationstatus",typeof(short),true,false)},
			{"applierannotations",createColumn("applierannotations",typeof(string),true,false)},
			{"idman",createColumn("idman",typeof(int),true,false)},
			{"idauthmodel",createColumn("idauthmodel",typeof(int),true,false)},
			{"webwarn",createColumn("webwarn",typeof(string),true,false)},
			{"cancelreason",createColumn("cancelreason",typeof(string),true,false)},
			{"authneeded",createColumn("authneeded",typeof(string),true,false)},
			{"authdoc",createColumn("authdoc",typeof(string),true,false)},
			{"authdocdate",createColumn("authdocdate",typeof(DateTime),true,false)},
			{"noauthreason",createColumn("noauthreason",typeof(string),true,false)},
			{"clause_accepted",createColumn("clause_accepted",typeof(string),true,false)},
			{"vehicle_motive",createColumn("vehicle_motive",typeof(string),true,false)},
			{"vehicle_info",createColumn("vehicle_info",typeof(string),true,false)},
			{"location",createColumn("location",typeof(string),true,false)},
			{"idsor01",createColumn("idsor01",typeof(int),true,false)},
			{"idsor02",createColumn("idsor02",typeof(int),true,false)},
			{"idsor03",createColumn("idsor03",typeof(int),true,false)},
			{"idsor04",createColumn("idsor04",typeof(int),true,false)},
			{"idsor05",createColumn("idsor05",typeof(int),true,false)},
			{"datecompleted",createColumn("datecompleted",typeof(DateTime),true,false)},
			{"iddaliaposition",createColumn("iddaliaposition",typeof(int),true,false)},
			{"additionalannotations",createColumn("additionalannotations",typeof(string),true,false)},
			{"idsor_siope",createColumn("idsor_siope",typeof(int),true,false)},
			{"iditineration_ref",createColumn("iditineration_ref",typeof(int),true,false)},
			{"supposedtravel",createColumn("supposedtravel",typeof(decimal),true,false)},
			{"supposedliving",createColumn("supposedliving",typeof(decimal),true,false)},
			{"supposedfood",createColumn("supposedfood",typeof(decimal),true,false)},
			{"nfood",createColumn("nfood",typeof(int),true,false)},
			{"flagownfunds",createColumn("flagownfunds",typeof(string),true,false)},
			{"idforeigncountry",createColumn("idforeigncountry",typeof(int),true,false)},
			{"advancepercentage",createColumn("advancepercentage",typeof(decimal),true,false)},
			{"supposedamount",createColumn("supposedamount",typeof(decimal),true,false)},
			{"flagoutside",createColumn("flagoutside",typeof(string),true,false)},
			{"idregistrypaymethod",createColumn("idregistrypaymethod",typeof(int),true,false)},
			{"flagmove",createColumn("flagmove",typeof(int),true,false)},
			{"advanceapplied",createColumn("advanceapplied",typeof(string),true,false)},
			{"iddaliarecruitmentmotive",createColumn("iddaliarecruitmentmotive",typeof(int),true,false)},
			{"starttime",createColumn("starttime",typeof(DateTime),true,false)},
			{"stoptime",createColumn("stoptime",typeof(DateTime),true,false)},
			{"iddalia_funzionale",createColumn("iddalia_funzionale",typeof(int),true,false)},
			{"iddalia_dipartimento",createColumn("iddalia_dipartimento",typeof(int),true,false)},
		};
	}
}
}
