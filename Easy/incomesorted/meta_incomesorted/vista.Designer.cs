
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
namespace meta_incomesorted {
public class incomesortedRow: MetaRow  {
	public incomesortedRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///#
	///</summary>
	public Int16? idsubclass{ 
		get {if (this["idsubclass"]==DBNull.Value)return null; return  (Int16?)this["idsubclass"];}
		set {if (value==null) this["idsubclass"]= DBNull.Value; else this["idsubclass"]= value;}
	}
	public object idsubclassValue { 
		get{ return this["idsubclass"];}
		set {if (value==null|| value==DBNull.Value) this["idsubclass"]= DBNull.Value; else this["idsubclass"]= value;}
	}
	public Int16? idsubclassOriginal { 
		get {if (this["idsubclass",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["idsubclass",DataRowVersion.Original];}
	}
	///<summary>
	///importo
	///</summary>
	public Decimal? amount{ 
		get {if (this["amount"]==DBNull.Value)return null; return  (Decimal?)this["amount"];}
		set {if (value==null) this["amount"]= DBNull.Value; else this["amount"]= value;}
	}
	public object amountValue { 
		get{ return this["amount"];}
		set {if (value==null|| value==DBNull.Value) this["amount"]= DBNull.Value; else this["amount"]= value;}
	}
	public Decimal? amountOriginal { 
		get {if (this["amount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["amount",DataRowVersion.Original];}
	}
	///<summary>
	///esercizio
	///</summary>
	public Int16? ayear{ 
		get {if (this["ayear"]==DBNull.Value)return null; return  (Int16?)this["ayear"];}
		set {if (value==null) this["ayear"]= DBNull.Value; else this["ayear"]= value;}
	}
	public object ayearValue { 
		get{ return this["ayear"];}
		set {if (value==null|| value==DBNull.Value) this["ayear"]= DBNull.Value; else this["ayear"]= value;}
	}
	public Int16? ayearOriginal { 
		get {if (this["ayear",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["ayear",DataRowVersion.Original];}
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
	///Date inizio e fine competenza non registrate
	///	 N: Date inizio e fine competenza registrate
	///	 S: Date inizio e fine competenza non registrate
	///</summary>
	public String flagnodate{ 
		get {if (this["flagnodate"]==DBNull.Value)return null; return  (String)this["flagnodate"];}
		set {if (value==null) this["flagnodate"]= DBNull.Value; else this["flagnodate"]= value;}
	}
	public object flagnodateValue { 
		get{ return this["flagnodate"];}
		set {if (value==null|| value==DBNull.Value) this["flagnodate"]= DBNull.Value; else this["flagnodate"]= value;}
	}
	public String flagnodateOriginal { 
		get {if (this["flagnodate",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagnodate",DataRowVersion.Original];}
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
	///Chiave parent classificazione (tabella sorting)
	///</summary>
	public Int32? paridsor{ 
		get {if (this["paridsor"]==DBNull.Value)return null; return  (Int32?)this["paridsor"];}
		set {if (value==null) this["paridsor"]= DBNull.Value; else this["paridsor"]= value;}
	}
	public object paridsorValue { 
		get{ return this["paridsor"];}
		set {if (value==null|| value==DBNull.Value) this["paridsor"]= DBNull.Value; else this["paridsor"]= value;}
	}
	public Int32? paridsorOriginal { 
		get {if (this["paridsor",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["paridsor",DataRowVersion.Original];}
	}
	///<summary>
	///idsub movimento parent che ha generato questa classificazione
	///</summary>
	public Int16? paridsubclass{ 
		get {if (this["paridsubclass"]==DBNull.Value)return null; return  (Int16?)this["paridsubclass"];}
		set {if (value==null) this["paridsubclass"]= DBNull.Value; else this["paridsubclass"]= value;}
	}
	public object paridsubclassValue { 
		get{ return this["paridsubclass"];}
		set {if (value==null|| value==DBNull.Value) this["paridsubclass"]= DBNull.Value; else this["paridsubclass"]= value;}
	}
	public Int16? paridsubclassOriginal { 
		get {if (this["paridsubclass",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["paridsubclass",DataRowVersion.Original];}
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
	///<summary>
	///classificazione da completare
	///</summary>
	public String tobecontinued{ 
		get {if (this["tobecontinued"]==DBNull.Value)return null; return  (String)this["tobecontinued"];}
		set {if (value==null) this["tobecontinued"]= DBNull.Value; else this["tobecontinued"]= value;}
	}
	public object tobecontinuedValue { 
		get{ return this["tobecontinued"];}
		set {if (value==null|| value==DBNull.Value) this["tobecontinued"]= DBNull.Value; else this["tobecontinued"]= value;}
	}
	public String tobecontinuedOriginal { 
		get {if (this["tobecontinued",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tobecontinued",DataRowVersion.Original];}
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
	///valore numerico 1 associato al tipo class.
	///</summary>
	public Decimal? valuen1{ 
		get {if (this["valuen1"]==DBNull.Value)return null; return  (Decimal?)this["valuen1"];}
		set {if (value==null) this["valuen1"]= DBNull.Value; else this["valuen1"]= value;}
	}
	public object valuen1Value { 
		get{ return this["valuen1"];}
		set {if (value==null|| value==DBNull.Value) this["valuen1"]= DBNull.Value; else this["valuen1"]= value;}
	}
	public Decimal? valuen1Original { 
		get {if (this["valuen1",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["valuen1",DataRowVersion.Original];}
	}
	///<summary>
	///valore numerico 2 associato al tipo class.
	///</summary>
	public Decimal? valuen2{ 
		get {if (this["valuen2"]==DBNull.Value)return null; return  (Decimal?)this["valuen2"];}
		set {if (value==null) this["valuen2"]= DBNull.Value; else this["valuen2"]= value;}
	}
	public object valuen2Value { 
		get{ return this["valuen2"];}
		set {if (value==null|| value==DBNull.Value) this["valuen2"]= DBNull.Value; else this["valuen2"]= value;}
	}
	public Decimal? valuen2Original { 
		get {if (this["valuen2",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["valuen2",DataRowVersion.Original];}
	}
	///<summary>
	///valore numerico 3 associato al tipo class.
	///</summary>
	public Decimal? valuen3{ 
		get {if (this["valuen3"]==DBNull.Value)return null; return  (Decimal?)this["valuen3"];}
		set {if (value==null) this["valuen3"]= DBNull.Value; else this["valuen3"]= value;}
	}
	public object valuen3Value { 
		get{ return this["valuen3"];}
		set {if (value==null|| value==DBNull.Value) this["valuen3"]= DBNull.Value; else this["valuen3"]= value;}
	}
	public Decimal? valuen3Original { 
		get {if (this["valuen3",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["valuen3",DataRowVersion.Original];}
	}
	///<summary>
	///valore numerico 4 associato al tipo class.
	///</summary>
	public Decimal? valuen4{ 
		get {if (this["valuen4"]==DBNull.Value)return null; return  (Decimal?)this["valuen4"];}
		set {if (value==null) this["valuen4"]= DBNull.Value; else this["valuen4"]= value;}
	}
	public object valuen4Value { 
		get{ return this["valuen4"];}
		set {if (value==null|| value==DBNull.Value) this["valuen4"]= DBNull.Value; else this["valuen4"]= value;}
	}
	public Decimal? valuen4Original { 
		get {if (this["valuen4",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["valuen4",DataRowVersion.Original];}
	}
	///<summary>
	///valore numerico 5  associato al tipo class.
	///</summary>
	public Decimal? valuen5{ 
		get {if (this["valuen5"]==DBNull.Value)return null; return  (Decimal?)this["valuen5"];}
		set {if (value==null) this["valuen5"]= DBNull.Value; else this["valuen5"]= value;}
	}
	public object valuen5Value { 
		get{ return this["valuen5"];}
		set {if (value==null|| value==DBNull.Value) this["valuen5"]= DBNull.Value; else this["valuen5"]= value;}
	}
	public Decimal? valuen5Original { 
		get {if (this["valuen5",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["valuen5",DataRowVersion.Original];}
	}
	///<summary>
	///valore alfanumerico 1 associato al tipo class.
	///</summary>
	public String values1{ 
		get {if (this["values1"]==DBNull.Value)return null; return  (String)this["values1"];}
		set {if (value==null) this["values1"]= DBNull.Value; else this["values1"]= value;}
	}
	public object values1Value { 
		get{ return this["values1"];}
		set {if (value==null|| value==DBNull.Value) this["values1"]= DBNull.Value; else this["values1"]= value;}
	}
	public String values1Original { 
		get {if (this["values1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["values1",DataRowVersion.Original];}
	}
	///<summary>
	///valore alfanumerico 2 associato al tipo class.
	///</summary>
	public String values2{ 
		get {if (this["values2"]==DBNull.Value)return null; return  (String)this["values2"];}
		set {if (value==null) this["values2"]= DBNull.Value; else this["values2"]= value;}
	}
	public object values2Value { 
		get{ return this["values2"];}
		set {if (value==null|| value==DBNull.Value) this["values2"]= DBNull.Value; else this["values2"]= value;}
	}
	public String values2Original { 
		get {if (this["values2",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["values2",DataRowVersion.Original];}
	}
	///<summary>
	///valore alfanumerico 3 associato al tipo class.
	///</summary>
	public String values3{ 
		get {if (this["values3"]==DBNull.Value)return null; return  (String)this["values3"];}
		set {if (value==null) this["values3"]= DBNull.Value; else this["values3"]= value;}
	}
	public object values3Value { 
		get{ return this["values3"];}
		set {if (value==null|| value==DBNull.Value) this["values3"]= DBNull.Value; else this["values3"]= value;}
	}
	public String values3Original { 
		get {if (this["values3",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["values3",DataRowVersion.Original];}
	}
	///<summary>
	///valore alfanumerico 4 associato al tipo class.
	///</summary>
	public String values4{ 
		get {if (this["values4"]==DBNull.Value)return null; return  (String)this["values4"];}
		set {if (value==null) this["values4"]= DBNull.Value; else this["values4"]= value;}
	}
	public object values4Value { 
		get{ return this["values4"];}
		set {if (value==null|| value==DBNull.Value) this["values4"]= DBNull.Value; else this["values4"]= value;}
	}
	public String values4Original { 
		get {if (this["values4",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["values4",DataRowVersion.Original];}
	}
	///<summary>
	///valore alfanumerico 5 associato al tipo class.
	///</summary>
	public String values5{ 
		get {if (this["values5"]==DBNull.Value)return null; return  (String)this["values5"];}
		set {if (value==null) this["values5"]= DBNull.Value; else this["values5"]= value;}
	}
	public object values5Value { 
		get{ return this["values5"];}
		set {if (value==null|| value==DBNull.Value) this["values5"]= DBNull.Value; else this["values5"]= value;}
	}
	public String values5Original { 
		get {if (this["values5",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["values5",DataRowVersion.Original];}
	}
	///<summary>
	///valore numerico 1 associato al tipo class.
	///</summary>
	public Decimal? valuev1{ 
		get {if (this["valuev1"]==DBNull.Value)return null; return  (Decimal?)this["valuev1"];}
		set {if (value==null) this["valuev1"]= DBNull.Value; else this["valuev1"]= value;}
	}
	public object valuev1Value { 
		get{ return this["valuev1"];}
		set {if (value==null|| value==DBNull.Value) this["valuev1"]= DBNull.Value; else this["valuev1"]= value;}
	}
	public Decimal? valuev1Original { 
		get {if (this["valuev1",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["valuev1",DataRowVersion.Original];}
	}
	///<summary>
	///valore numerico 2 associato al tipo class.
	///</summary>
	public Decimal? valuev2{ 
		get {if (this["valuev2"]==DBNull.Value)return null; return  (Decimal?)this["valuev2"];}
		set {if (value==null) this["valuev2"]= DBNull.Value; else this["valuev2"]= value;}
	}
	public object valuev2Value { 
		get{ return this["valuev2"];}
		set {if (value==null|| value==DBNull.Value) this["valuev2"]= DBNull.Value; else this["valuev2"]= value;}
	}
	public Decimal? valuev2Original { 
		get {if (this["valuev2",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["valuev2",DataRowVersion.Original];}
	}
	///<summary>
	///valore numerico 3 associato al tipo class.
	///</summary>
	public Decimal? valuev3{ 
		get {if (this["valuev3"]==DBNull.Value)return null; return  (Decimal?)this["valuev3"];}
		set {if (value==null) this["valuev3"]= DBNull.Value; else this["valuev3"]= value;}
	}
	public object valuev3Value { 
		get{ return this["valuev3"];}
		set {if (value==null|| value==DBNull.Value) this["valuev3"]= DBNull.Value; else this["valuev3"]= value;}
	}
	public Decimal? valuev3Original { 
		get {if (this["valuev3",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["valuev3",DataRowVersion.Original];}
	}
	///<summary>
	///valore numerico 4 associato al tipo class.
	///</summary>
	public Decimal? valuev4{ 
		get {if (this["valuev4"]==DBNull.Value)return null; return  (Decimal?)this["valuev4"];}
		set {if (value==null) this["valuev4"]= DBNull.Value; else this["valuev4"]= value;}
	}
	public object valuev4Value { 
		get{ return this["valuev4"];}
		set {if (value==null|| value==DBNull.Value) this["valuev4"]= DBNull.Value; else this["valuev4"]= value;}
	}
	public Decimal? valuev4Original { 
		get {if (this["valuev4",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["valuev4",DataRowVersion.Original];}
	}
	///<summary>
	///valore numerico 5 associato al tipo class.
	///</summary>
	public Decimal? valuev5{ 
		get {if (this["valuev5"]==DBNull.Value)return null; return  (Decimal?)this["valuev5"];}
		set {if (value==null) this["valuev5"]= DBNull.Value; else this["valuev5"]= value;}
	}
	public object valuev5Value { 
		get{ return this["valuev5"];}
		set {if (value==null|| value==DBNull.Value) this["valuev5"]= DBNull.Value; else this["valuev5"]= value;}
	}
	public Decimal? valuev5Original { 
		get {if (this["valuev5",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["valuev5",DataRowVersion.Original];}
	}
	///<summary>
	///id mov. entrata (tabella income)
	///</summary>
	public Int32? idinc{ 
		get {if (this["idinc"]==DBNull.Value)return null; return  (Int32?)this["idinc"];}
		set {if (value==null) this["idinc"]= DBNull.Value; else this["idinc"]= value;}
	}
	public object idincValue { 
		get{ return this["idinc"];}
		set {if (value==null|| value==DBNull.Value) this["idinc"]= DBNull.Value; else this["idinc"]= value;}
	}
	public Int32? idincOriginal { 
		get {if (this["idinc",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinc",DataRowVersion.Original];}
	}
	///<summary>
	///id classificazione (tabella sorting)
	///</summary>
	public Int32? idsor{ 
		get {if (this["idsor"]==DBNull.Value)return null; return  (Int32?)this["idsor"];}
		set {if (value==null) this["idsor"]= DBNull.Value; else this["idsor"]= value;}
	}
	public object idsorValue { 
		get{ return this["idsor"];}
		set {if (value==null|| value==DBNull.Value) this["idsor"]= DBNull.Value; else this["idsor"]= value;}
	}
	public Int32? idsorOriginal { 
		get {if (this["idsor",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor",DataRowVersion.Original];}
	}
	public Decimal? originalamount{ 
		get {if (this["originalamount"]==DBNull.Value)return null; return  (Decimal?)this["originalamount"];}
		set {if (value==null) this["originalamount"]= DBNull.Value; else this["originalamount"]= value;}
	}
	public object originalamountValue { 
		get{ return this["originalamount"];}
		set {if (value==null|| value==DBNull.Value) this["originalamount"]= DBNull.Value; else this["originalamount"]= value;}
	}
	public Decimal? originalamountOriginal { 
		get {if (this["originalamount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["originalamount",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Classificazione Movimenti di entrata
///</summary>
public class incomesortedTable : MetaTableBase<incomesortedRow> {
	public incomesortedTable() : base("incomesorted"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idsubclass",createColumn("idsubclass",typeof(short),false,false)},
			{"amount",createColumn("amount",typeof(decimal),true,false)},
			{"ayear",createColumn("ayear",typeof(short),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),true,false)},
			{"flagnodate",createColumn("flagnodate",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"paridsor",createColumn("paridsor",typeof(int),true,false)},
			{"paridsubclass",createColumn("paridsubclass",typeof(short),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"start",createColumn("start",typeof(DateTime),true,false)},
			{"stop",createColumn("stop",typeof(DateTime),true,false)},
			{"tobecontinued",createColumn("tobecontinued",typeof(string),true,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"valuen1",createColumn("valuen1",typeof(decimal),true,false)},
			{"valuen2",createColumn("valuen2",typeof(decimal),true,false)},
			{"valuen3",createColumn("valuen3",typeof(decimal),true,false)},
			{"valuen4",createColumn("valuen4",typeof(decimal),true,false)},
			{"valuen5",createColumn("valuen5",typeof(decimal),true,false)},
			{"values1",createColumn("values1",typeof(string),true,false)},
			{"values2",createColumn("values2",typeof(string),true,false)},
			{"values3",createColumn("values3",typeof(string),true,false)},
			{"values4",createColumn("values4",typeof(string),true,false)},
			{"values5",createColumn("values5",typeof(string),true,false)},
			{"valuev1",createColumn("valuev1",typeof(decimal),true,false)},
			{"valuev2",createColumn("valuev2",typeof(decimal),true,false)},
			{"valuev3",createColumn("valuev3",typeof(decimal),true,false)},
			{"valuev4",createColumn("valuev4",typeof(decimal),true,false)},
			{"valuev5",createColumn("valuev5",typeof(decimal),true,false)},
			{"idinc",createColumn("idinc",typeof(int),false,false)},
			{"idsor",createColumn("idsor",typeof(int),false,false)},
			{"originalamount",createColumn("originalamount",typeof(decimal),true,false)},
		};
	}
}
}
