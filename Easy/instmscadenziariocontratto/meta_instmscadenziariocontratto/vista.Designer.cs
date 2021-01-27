
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
namespace meta_instmscadenziariocontratto {
public class instmscadenziariocontrattoRow: MetaRow  {
	public instmscadenziariocontrattoRow(DataRowBuilder rb) : base(rb) {} 

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
	///Data Fattura
	///</summary>
	public Int32? datafattura{ 
		get {if (this["datafattura"]==DBNull.Value)return null; return  (Int32?)this["datafattura"];}
		set {if (value==null) this["datafattura"]= DBNull.Value; else this["datafattura"]= value;}
	}
	public object datafatturaValue { 
		get{ return this["datafattura"];}
		set {if (value==null|| value==DBNull.Value) this["datafattura"]= DBNull.Value; else this["datafattura"]= value;}
	}
	public Int32? datafatturaOriginal { 
		get {if (this["datafattura",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["datafattura",DataRowVersion.Original];}
	}
	///<summary>
	///Data Scadenza
	///</summary>
	public DateTime? datascadenza{ 
		get {if (this["datascadenza"]==DBNull.Value)return null; return  (DateTime?)this["datascadenza"];}
		set {if (value==null) this["datascadenza"]= DBNull.Value; else this["datascadenza"]= value;}
	}
	public object datascadenzaValue { 
		get{ return this["datascadenza"];}
		set {if (value==null|| value==DBNull.Value) this["datascadenza"]= DBNull.Value; else this["datascadenza"]= value;}
	}
	public DateTime? datascadenzaOriginal { 
		get {if (this["datascadenza",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["datascadenza",DataRowVersion.Original];}
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
	public Int32? idinstmscadenziariocontratto{ 
		get {if (this["idinstmscadenziariocontratto"]==DBNull.Value)return null; return  (Int32?)this["idinstmscadenziariocontratto"];}
		set {if (value==null) this["idinstmscadenziariocontratto"]= DBNull.Value; else this["idinstmscadenziariocontratto"]= value;}
	}
	public object idinstmscadenziariocontrattoValue { 
		get{ return this["idinstmscadenziariocontratto"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmscadenziariocontratto"]= DBNull.Value; else this["idinstmscadenziariocontratto"]= value;}
	}
	public Int32? idinstmscadenziariocontrattoOriginal { 
		get {if (this["idinstmscadenziariocontratto",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmscadenziariocontratto",DataRowVersion.Original];}
	}
	public Int32? idinstmscadenziariocontrattokind{ 
		get {if (this["idinstmscadenziariocontrattokind"]==DBNull.Value)return null; return  (Int32?)this["idinstmscadenziariocontrattokind"];}
		set {if (value==null) this["idinstmscadenziariocontrattokind"]= DBNull.Value; else this["idinstmscadenziariocontrattokind"]= value;}
	}
	public object idinstmscadenziariocontrattokindValue { 
		get{ return this["idinstmscadenziariocontrattokind"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmscadenziariocontrattokind"]= DBNull.Value; else this["idinstmscadenziariocontrattokind"]= value;}
	}
	public Int32? idinstmscadenziariocontrattokindOriginal { 
		get {if (this["idinstmscadenziariocontrattokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmscadenziariocontrattokind",DataRowVersion.Original];}
	}
	public Decimal? imponibile{ 
		get {if (this["imponibile"]==DBNull.Value)return null; return  (Decimal?)this["imponibile"];}
		set {if (value==null) this["imponibile"]= DBNull.Value; else this["imponibile"]= value;}
	}
	public object imponibileValue { 
		get{ return this["imponibile"];}
		set {if (value==null|| value==DBNull.Value) this["imponibile"]= DBNull.Value; else this["imponibile"]= value;}
	}
	public Decimal? imponibileOriginal { 
		get {if (this["imponibile",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["imponibile",DataRowVersion.Original];}
	}
	public Decimal? iva{ 
		get {if (this["iva"]==DBNull.Value)return null; return  (Decimal?)this["iva"];}
		set {if (value==null) this["iva"]= DBNull.Value; else this["iva"]= value;}
	}
	public object ivaValue { 
		get{ return this["iva"];}
		set {if (value==null|| value==DBNull.Value) this["iva"]= DBNull.Value; else this["iva"]= value;}
	}
	public Decimal? ivaOriginal { 
		get {if (this["iva",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["iva",DataRowVersion.Original];}
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
	public String note{ 
		get {if (this["note"]==DBNull.Value)return null; return  (String)this["note"];}
		set {if (value==null) this["note"]= DBNull.Value; else this["note"]= value;}
	}
	public object noteValue { 
		get{ return this["note"];}
		set {if (value==null|| value==DBNull.Value) this["note"]= DBNull.Value; else this["note"]= value;}
	}
	public String noteOriginal { 
		get {if (this["note",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["note",DataRowVersion.Original];}
	}
	///<summary>
	///Numero Fattura
	///</summary>
	public Int32? numerofattura{ 
		get {if (this["numerofattura"]==DBNull.Value)return null; return  (Int32?)this["numerofattura"];}
		set {if (value==null) this["numerofattura"]= DBNull.Value; else this["numerofattura"]= value;}
	}
	public object numerofatturaValue { 
		get{ return this["numerofattura"];}
		set {if (value==null|| value==DBNull.Value) this["numerofattura"]= DBNull.Value; else this["numerofattura"]= value;}
	}
	public Int32? numerofatturaOriginal { 
		get {if (this["numerofattura",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["numerofattura",DataRowVersion.Original];}
	}
	public String pagato{ 
		get {if (this["pagato"]==DBNull.Value)return null; return  (String)this["pagato"];}
		set {if (value==null) this["pagato"]= DBNull.Value; else this["pagato"]= value;}
	}
	public object pagatoValue { 
		get{ return this["pagato"];}
		set {if (value==null|| value==DBNull.Value) this["pagato"]= DBNull.Value; else this["pagato"]= value;}
	}
	public String pagatoOriginal { 
		get {if (this["pagato",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["pagato",DataRowVersion.Original];}
	}
	///<summary>
	///Quota di Gestione
	///</summary>
	public Decimal? quotagestione{ 
		get {if (this["quotagestione"]==DBNull.Value)return null; return  (Decimal?)this["quotagestione"];}
		set {if (value==null) this["quotagestione"]= DBNull.Value; else this["quotagestione"]= value;}
	}
	public object quotagestioneValue { 
		get{ return this["quotagestione"];}
		set {if (value==null|| value==DBNull.Value) this["quotagestione"]= DBNull.Value; else this["quotagestione"]= value;}
	}
	public Decimal? quotagestioneOriginal { 
		get {if (this["quotagestione",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["quotagestione",DataRowVersion.Original];}
	}
	///<summary>
	///Quota Udr
	///</summary>
	public Decimal? quotaudr{ 
		get {if (this["quotaudr"]==DBNull.Value)return null; return  (Decimal?)this["quotaudr"];}
		set {if (value==null) this["quotaudr"]= DBNull.Value; else this["quotaudr"]= value;}
	}
	public object quotaudrValue { 
		get{ return this["quotaudr"];}
		set {if (value==null|| value==DBNull.Value) this["quotaudr"]= DBNull.Value; else this["quotaudr"]= value;}
	}
	public Decimal? quotaudrOriginal { 
		get {if (this["quotaudr",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["quotaudr",DataRowVersion.Original];}
	}
	#endregion

}
public class instmscadenziariocontrattoTable : MetaTableBase<instmscadenziariocontrattoRow> {
	public instmscadenziariocontrattoTable() : base("instmscadenziariocontratto"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"datafattura",createColumn("datafattura",typeof(int),true,false)},
			{"datascadenza",createColumn("datascadenza",typeof(DateTime),true,false)},
			{"idinstmcontratto",createColumn("idinstmcontratto",typeof(int),false,false)},
			{"idinstmscadenziariocontratto",createColumn("idinstmscadenziariocontratto",typeof(int),false,false)},
			{"idinstmscadenziariocontrattokind",createColumn("idinstmscadenziariocontrattokind",typeof(int),true,false)},
			{"imponibile",createColumn("imponibile",typeof(decimal),true,false)},
			{"iva",createColumn("iva",typeof(decimal),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"note",createColumn("note",typeof(string),true,false)},
			{"numerofattura",createColumn("numerofattura",typeof(int),true,false)},
			{"pagato",createColumn("pagato",typeof(string),true,false)},
			{"quotagestione",createColumn("quotagestione",typeof(decimal),true,false)},
			{"quotaudr",createColumn("quotaudr",typeof(decimal),true,false)},
		};
	}
}
}
