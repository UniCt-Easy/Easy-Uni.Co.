
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
namespace meta_epexp {
public class epexpRow: MetaRow  {
	public epexpRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///id impegno di budget (tabella epexp)
	///</summary>
	public Int32? idepexp{ 
		get {if (this["idepexp"]==DBNull.Value)return null; return  (Int32?)this["idepexp"];}
		set {if (value==null) this["idepexp"]= DBNull.Value; else this["idepexp"]= value;}
	}
	public object idepexpValue { 
		get{ return this["idepexp"];}
		set {if (value==null|| value==DBNull.Value) this["idepexp"]= DBNull.Value; else this["idepexp"]= value;}
	}
	public Int32? idepexpOriginal { 
		get {if (this["idepexp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idepexp",DataRowVersion.Original];}
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
	///documento
	///</summary>
	public String doc{ 
		get {if (this["doc"]==DBNull.Value)return null; return  (String)this["doc"];}
		set {if (value==null) this["doc"]= DBNull.Value; else this["doc"]= value;}
	}
	public object docValue { 
		get{ return this["doc"];}
		set {if (value==null|| value==DBNull.Value) this["doc"]= DBNull.Value; else this["doc"]= value;}
	}
	public String docOriginal { 
		get {if (this["doc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["doc",DataRowVersion.Original];}
	}
	///<summary>
	///data documento
	///</summary>
	public DateTime? docdate{ 
		get {if (this["docdate"]==DBNull.Value)return null; return  (DateTime?)this["docdate"];}
		set {if (value==null) this["docdate"]= DBNull.Value; else this["docdate"]= value;}
	}
	public object docdateValue { 
		get{ return this["docdate"];}
		set {if (value==null|| value==DBNull.Value) this["docdate"]= DBNull.Value; else this["docdate"]= value;}
	}
	public DateTime? docdateOriginal { 
		get {if (this["docdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["docdate",DataRowVersion.Original];}
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
	///Id del documento collegato (codificato)
	///</summary>
	public String idrelated{ 
		get {if (this["idrelated"]==DBNull.Value)return null; return  (String)this["idrelated"];}
		set {if (value==null) this["idrelated"]= DBNull.Value; else this["idrelated"]= value;}
	}
	public object idrelatedValue { 
		get{ return this["idrelated"];}
		set {if (value==null|| value==DBNull.Value) this["idrelated"]= DBNull.Value; else this["idrelated"]= value;}
	}
	public String idrelatedOriginal { 
		get {if (this["idrelated",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idrelated",DataRowVersion.Original];}
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
	///N. impegno di budget
	///</summary>
	public Int32? nepexp{ 
		get {if (this["nepexp"]==DBNull.Value)return null; return  (Int32?)this["nepexp"];}
		set {if (value==null) this["nepexp"]= DBNull.Value; else this["nepexp"]= value;}
	}
	public object nepexpValue { 
		get{ return this["nepexp"];}
		set {if (value==null|| value==DBNull.Value) this["nepexp"]= DBNull.Value; else this["nepexp"]= value;}
	}
	public Int32? nepexpOriginal { 
		get {if (this["nepexp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nepexp",DataRowVersion.Original];}
	}
	///<summary>
	///N.fase
	///</summary>
	public Int16? nphase{ 
		get {if (this["nphase"]==DBNull.Value)return null; return  (Int16?)this["nphase"];}
		set {if (value==null) this["nphase"]= DBNull.Value; else this["nphase"]= value;}
	}
	public object nphaseValue { 
		get{ return this["nphase"];}
		set {if (value==null|| value==DBNull.Value) this["nphase"]= DBNull.Value; else this["nphase"]= value;}
	}
	public Int16? nphaseOriginal { 
		get {if (this["nphase",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["nphase",DataRowVersion.Original];}
	}
	///<summary>
	///chiave parent Impegno di Budget (tabella epexp) 
	///</summary>
	public Int32? paridepexp{ 
		get {if (this["paridepexp"]==DBNull.Value)return null; return  (Int32?)this["paridepexp"];}
		set {if (value==null) this["paridepexp"]= DBNull.Value; else this["paridepexp"]= value;}
	}
	public object paridepexpValue { 
		get{ return this["paridepexp"];}
		set {if (value==null|| value==DBNull.Value) this["paridepexp"]= DBNull.Value; else this["paridepexp"]= value;}
	}
	public Int32? paridepexpOriginal { 
		get {if (this["paridepexp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["paridepexp",DataRowVersion.Original];}
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
	///Anno impegno di budget
	///</summary>
	public Int16? yepexp{ 
		get {if (this["yepexp"]==DBNull.Value)return null; return  (Int16?)this["yepexp"];}
		set {if (value==null) this["yepexp"]= DBNull.Value; else this["yepexp"]= value;}
	}
	public object yepexpValue { 
		get{ return this["yepexp"];}
		set {if (value==null|| value==DBNull.Value) this["yepexp"]= DBNull.Value; else this["yepexp"]= value;}
	}
	public Int16? yepexpOriginal { 
		get {if (this["yepexp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yepexp",DataRowVersion.Original];}
	}
	///<summary>
	///Flag nota variazione (S/N)
	///	 N: Movimento normale
	///	 S: Nota di variazione
	///</summary>
	public String flagvariation{ 
		get {if (this["flagvariation"]==DBNull.Value)return null; return  (String)this["flagvariation"];}
		set {if (value==null) this["flagvariation"]= DBNull.Value; else this["flagvariation"]= value;}
	}
	public object flagvariationValue { 
		get{ return this["flagvariation"];}
		set {if (value==null|| value==DBNull.Value) this["flagvariation"]= DBNull.Value; else this["flagvariation"]= value;}
	}
	public String flagvariationOriginal { 
		get {if (this["flagvariation",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagvariation",DataRowVersion.Original];}
	}
	///<summary>
	///ID causale EP 
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
	#endregion

}
///<summary>
///Impegno di Budget
///</summary>
public class epexpTable : MetaTableBase<epexpRow> {
	public epexpTable() : base("epexp"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idepexp",createColumn("idepexp",typeof(int),false,false)},
			{"adate",createColumn("adate",typeof(DateTime),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"doc",createColumn("doc",typeof(string),true,false)},
			{"docdate",createColumn("docdate",typeof(DateTime),true,false)},
			{"idman",createColumn("idman",typeof(int),true,false)},
			{"idreg",createColumn("idreg",typeof(int),true,false)},
			{"idrelated",createColumn("idrelated",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"nepexp",createColumn("nepexp",typeof(int),false,false)},
			{"nphase",createColumn("nphase",typeof(short),false,false)},
			{"paridepexp",createColumn("paridepexp",typeof(int),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"start",createColumn("start",typeof(DateTime),true,false)},
			{"stop",createColumn("stop",typeof(DateTime),true,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"yepexp",createColumn("yepexp",typeof(short),false,false)},
			{"flagvariation",createColumn("flagvariation",typeof(string),true,false)},
			{"idaccmotive",createColumn("idaccmotive",typeof(string),true,false)},
		};
	}
}
}
