
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
namespace meta_entrydetail {
public class entrydetailRow: MetaRow  {
	public entrydetailRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///N. dettaglio
	///</summary>
	public Int32? ndetail{ 
		get {if (this["ndetail"]==DBNull.Value)return null; return  (Int32?)this["ndetail"];}
		set {if (value==null) this["ndetail"]= DBNull.Value; else this["ndetail"]= value;}
	}
	public object ndetailValue { 
		get{ return this["ndetail"];}
		set {if (value==null|| value==DBNull.Value) this["ndetail"]= DBNull.Value; else this["ndetail"]= value;}
	}
	public Int32? ndetailOriginal { 
		get {if (this["ndetail",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ndetail",DataRowVersion.Original];}
	}
	///<summary>
	///Num. Scrittura
	///</summary>
	public Int32? nentry{ 
		get {if (this["nentry"]==DBNull.Value)return null; return  (Int32?)this["nentry"];}
		set {if (value==null) this["nentry"]= DBNull.Value; else this["nentry"]= value;}
	}
	public object nentryValue { 
		get{ return this["nentry"];}
		set {if (value==null|| value==DBNull.Value) this["nentry"]= DBNull.Value; else this["nentry"]= value;}
	}
	public Int32? nentryOriginal { 
		get {if (this["nentry",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nentry",DataRowVersion.Original];}
	}
	///<summary>
	///Eserc. Scrittura
	///</summary>
	public Int16? yentry{ 
		get {if (this["yentry"]==DBNull.Value)return null; return  (Int16?)this["yentry"];}
		set {if (value==null) this["yentry"]= DBNull.Value; else this["yentry"]= value;}
	}
	public object yentryValue { 
		get{ return this["yentry"];}
		set {if (value==null|| value==DBNull.Value) this["yentry"]= DBNull.Value; else this["yentry"]= value;}
	}
	public Int16? yentryOriginal { 
		get {if (this["yentry",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yentry",DataRowVersion.Original];}
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
	///id voce piano conti (tabella account)
	///</summary>
	public String idacc{ 
		get {if (this["idacc"]==DBNull.Value)return null; return  (String)this["idacc"];}
		set {if (value==null) this["idacc"]= DBNull.Value; else this["idacc"]= value;}
	}
	public object idaccValue { 
		get{ return this["idacc"];}
		set {if (value==null|| value==DBNull.Value) this["idacc"]= DBNull.Value; else this["idacc"]= value;}
	}
	public String idaccOriginal { 
		get {if (this["idacc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc",DataRowVersion.Original];}
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
	///Data inizio competenza
	///</summary>
	public DateTime? competencystart{ 
		get {if (this["competencystart"]==DBNull.Value)return null; return  (DateTime?)this["competencystart"];}
		set {if (value==null) this["competencystart"]= DBNull.Value; else this["competencystart"]= value;}
	}
	public object competencystartValue { 
		get{ return this["competencystart"];}
		set {if (value==null|| value==DBNull.Value) this["competencystart"]= DBNull.Value; else this["competencystart"]= value;}
	}
	public DateTime? competencystartOriginal { 
		get {if (this["competencystart",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["competencystart",DataRowVersion.Original];}
	}
	///<summary>
	///Data fine competenza
	///</summary>
	public DateTime? competencystop{ 
		get {if (this["competencystop"]==DBNull.Value)return null; return  (DateTime?)this["competencystop"];}
		set {if (value==null) this["competencystop"]= DBNull.Value; else this["competencystop"]= value;}
	}
	public object competencystopValue { 
		get{ return this["competencystop"];}
		set {if (value==null|| value==DBNull.Value) this["competencystop"]= DBNull.Value; else this["competencystop"]= value;}
	}
	public DateTime? competencystopOriginal { 
		get {if (this["competencystop",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["competencystop",DataRowVersion.Original];}
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
	///Codice importazione
	///</summary>
	public String importcode{ 
		get {if (this["importcode"]==DBNull.Value)return null; return  (String)this["importcode"];}
		set {if (value==null) this["importcode"]= DBNull.Value; else this["importcode"]= value;}
	}
	public object importcodeValue { 
		get{ return this["importcode"];}
		set {if (value==null|| value==DBNull.Value) this["importcode"]= DBNull.Value; else this["importcode"]= value;}
	}
	public String importcodeOriginal { 
		get {if (this["importcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["importcode",DataRowVersion.Original];}
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
	///Rateo auto generato se S
	///	 N: Rateo inserito manualmente
	///	 S: Rateo generato in automatico
	///</summary>
	public String autogenerated{ 
		get {if (this["autogenerated"]==DBNull.Value)return null; return  (String)this["autogenerated"];}
		set {if (value==null) this["autogenerated"]= DBNull.Value; else this["autogenerated"]= value;}
	}
	public object autogeneratedValue { 
		get{ return this["autogenerated"];}
		set {if (value==null|| value==DBNull.Value) this["autogenerated"]= DBNull.Value; else this["autogenerated"]= value;}
	}
	public String autogeneratedOriginal { 
		get {if (this["autogenerated",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["autogenerated",DataRowVersion.Original];}
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
	///id accertamento di budget (tabella epacc)
	///</summary>
	public Int32? idepacc{ 
		get {if (this["idepacc"]==DBNull.Value)return null; return  (Int32?)this["idepacc"];}
		set {if (value==null) this["idepacc"]= DBNull.Value; else this["idepacc"]= value;}
	}
	public object idepaccValue { 
		get{ return this["idepacc"];}
		set {if (value==null|| value==DBNull.Value) this["idepacc"]= DBNull.Value; else this["idepacc"]= value;}
	}
	public Int32? idepaccOriginal { 
		get {if (this["idepacc",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idepacc",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Dettaglio scrittura
///</summary>
public class entrydetailTable : MetaTableBase<entrydetailRow> {
	public entrydetailTable() : base("entrydetail"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("ndetail")){ 
			defineColumn("ndetail", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("nentry")){ 
			defineColumn("nentry", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("yentry")){ 
			defineColumn("yentry", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("amount")){ 
			defineColumn("amount", typeof(System.Decimal),false);
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("idacc")){ 
			defineColumn("idacc", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("idreg")){ 
			defineColumn("idreg", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idupb")){ 
			defineColumn("idupb", typeof(System.String));
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("idaccmotive")){ 
			defineColumn("idaccmotive", typeof(System.String));
		}
		if (definedColums.ContainsKey("competencystart")){ 
			defineColumn("competencystart", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("competencystop")){ 
			defineColumn("competencystop", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("idsor1")){ 
			defineColumn("idsor1", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor2")){ 
			defineColumn("idsor2", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor3")){ 
			defineColumn("idsor3", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("importcode")){ 
			defineColumn("importcode", typeof(System.String));
		}
		if (definedColums.ContainsKey("description")){ 
			defineColumn("description", typeof(System.String));
		}
		if (definedColums.ContainsKey("autogenerated")){ 
			defineColumn("autogenerated", typeof(System.String));
		}
		if (definedColums.ContainsKey("idrelated")){ 
			defineColumn("idrelated", typeof(System.String));
		}
		if (definedColums.ContainsKey("idepexp")){ 
			defineColumn("idepexp", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idepacc")){ 
			defineColumn("idepacc", typeof(System.Int32));
		}
		#endregion

	}
}
}
