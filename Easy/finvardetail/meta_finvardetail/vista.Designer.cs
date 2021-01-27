
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
using metadatalibrary;
namespace meta_finvardetail {
public class finvardetailRow: MetaRow  {
	public finvardetailRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///N. variazione
	///</summary>
	public Int32? nvar{ 
		get {if (this["nvar"]==DBNull.Value)return null; return  (Int32?)this["nvar"];}
		set {if (value==null) this["nvar"]= DBNull.Value; else this["nvar"]= value;}
	}
	public object nvarValue { 
		get{ return this["nvar"];}
		set {if (value==null|| value==DBNull.Value) this["nvar"]= DBNull.Value; else this["nvar"]= value;}
	}
	public Int32? nvarOriginal { 
		get {if (this["nvar",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nvar",DataRowVersion.Original];}
	}
	///<summary>
	///Anno variazione
	///</summary>
	public Int16? yvar{ 
		get {if (this["yvar"]==DBNull.Value)return null; return  (Int16?)this["yvar"];}
		set {if (value==null) this["yvar"]= DBNull.Value; else this["yvar"]= value;}
	}
	public object yvarValue { 
		get{ return this["yvar"];}
		set {if (value==null|| value==DBNull.Value) this["yvar"]= DBNull.Value; else this["yvar"]= value;}
	}
	public Int16? yvarOriginal { 
		get {if (this["yvar",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yvar",DataRowVersion.Original];}
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
	///id voce bilancio (tabella fin)
	///</summary>
	public Int32? idfin{ 
		get {if (this["idfin"]==DBNull.Value)return null; return  (Int32?)this["idfin"];}
		set {if (value==null) this["idfin"]= DBNull.Value; else this["idfin"]= value;}
	}
	public object idfinValue { 
		get{ return this["idfin"];}
		set {if (value==null|| value==DBNull.Value) this["idfin"]= DBNull.Value; else this["idfin"]= value;}
	}
	public Int32? idfinOriginal { 
		get {if (this["idfin",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idfin",DataRowVersion.Original];}
	}
	///<summary>
	///Limite Variazione
	///</summary>
	public Decimal? limit{ 
		get {if (this["limit"]==DBNull.Value)return null; return  (Decimal?)this["limit"];}
		set {if (value==null) this["limit"]= DBNull.Value; else this["limit"]= value;}
	}
	public object limitValue { 
		get{ return this["limit"];}
		set {if (value==null|| value==DBNull.Value) this["limit"]= DBNull.Value; else this["limit"]= value;}
	}
	public Decimal? limitOriginal { 
		get {if (this["limit",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["limit",DataRowVersion.Original];}
	}
	///<summary>
	///Annotazioni
	///</summary>
	public String annotation{ 
		get {if (this["annotation"]==DBNull.Value)return null; return  (String)this["annotation"];}
		set {if (value==null) this["annotation"]= DBNull.Value; else this["annotation"]= value;}
	}
	public object annotationValue { 
		get{ return this["annotation"];}
		set {if (value==null|| value==DBNull.Value) this["annotation"]= DBNull.Value; else this["annotation"]= value;}
	}
	public String annotationOriginal { 
		get {if (this["annotation",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["annotation",DataRowVersion.Original];}
	}
	///<summary>
	///id card magazzino (tabella lcard)
	///</summary>
	public Int32? idlcard{ 
		get {if (this["idlcard"]==DBNull.Value)return null; return  (Int32?)this["idlcard"];}
		set {if (value==null) this["idlcard"]= DBNull.Value; else this["idlcard"]= value;}
	}
	public object idlcardValue { 
		get{ return this["idlcard"];}
		set {if (value==null|| value==DBNull.Value) this["idlcard"]= DBNull.Value; else this["idlcard"]= value;}
	}
	public Int32? idlcardOriginal { 
		get {if (this["idlcard",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idlcard",DataRowVersion.Original];}
	}
	///<summary>
	///N. riga
	///</summary>
	public Int32? rownum{ 
		get {if (this["rownum"]==DBNull.Value)return null; return  (Int32?)this["rownum"];}
		set {if (value==null) this["rownum"]= DBNull.Value; else this["rownum"]= value;}
	}
	public object rownumValue { 
		get{ return this["rownum"];}
		set {if (value==null|| value==DBNull.Value) this["rownum"]= DBNull.Value; else this["rownum"]= value;}
	}
	public Int32? rownumOriginal { 
		get {if (this["rownum",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["rownum",DataRowVersion.Original];}
	}
	///<summary>
	///id finanziamento (tabella underwriting)
	///</summary>
	public Int32? idunderwriting{ 
		get {if (this["idunderwriting"]==DBNull.Value)return null; return  (Int32?)this["idunderwriting"];}
		set {if (value==null) this["idunderwriting"]= DBNull.Value; else this["idunderwriting"]= value;}
	}
	public object idunderwritingValue { 
		get{ return this["idunderwriting"];}
		set {if (value==null|| value==DBNull.Value) this["idunderwriting"]= DBNull.Value; else this["idunderwriting"]= value;}
	}
	public Int32? idunderwritingOriginal { 
		get {if (this["idunderwriting",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idunderwriting",DataRowVersion.Original];}
	}
	///<summary>
	///previsione pluriennale anno +1
	///</summary>
	public Decimal? prevision2{ 
		get {if (this["prevision2"]==DBNull.Value)return null; return  (Decimal?)this["prevision2"];}
		set {if (value==null) this["prevision2"]= DBNull.Value; else this["prevision2"]= value;}
	}
	public object prevision2Value { 
		get{ return this["prevision2"];}
		set {if (value==null|| value==DBNull.Value) this["prevision2"]= DBNull.Value; else this["prevision2"]= value;}
	}
	public Decimal? prevision2Original { 
		get {if (this["prevision2",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["prevision2",DataRowVersion.Original];}
	}
	///<summary>
	///previsione pluriennale anno +2
	///</summary>
	public Decimal? prevision3{ 
		get {if (this["prevision3"]==DBNull.Value)return null; return  (Decimal?)this["prevision3"];}
		set {if (value==null) this["prevision3"]= DBNull.Value; else this["prevision3"]= value;}
	}
	public object prevision3Value { 
		get{ return this["prevision3"];}
		set {if (value==null|| value==DBNull.Value) this["prevision3"]= DBNull.Value; else this["prevision3"]= value;}
	}
	public Decimal? prevision3Original { 
		get {if (this["prevision3",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["prevision3",DataRowVersion.Original];}
	}
	///<summary>
	///Richiedi Prenotazione
	///</summary>
	public String createexpense{ 
		get {if (this["createexpense"]==DBNull.Value)return null; return  (String)this["createexpense"];}
		set {if (value==null) this["createexpense"]= DBNull.Value; else this["createexpense"]= value;}
	}
	public object createexpenseValue { 
		get{ return this["createexpense"];}
		set {if (value==null|| value==DBNull.Value) this["createexpense"]= DBNull.Value; else this["createexpense"]= value;}
	}
	public String createexpenseOriginal { 
		get {if (this["createexpense",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["createexpense",DataRowVersion.Original];}
	}
	///<summary>
	///id mov. spesa (tabella expense)
	///</summary>
	public Int32? idexp{ 
		get {if (this["idexp"]==DBNull.Value)return null; return  (Int32?)this["idexp"];}
		set {if (value==null) this["idexp"]= DBNull.Value; else this["idexp"]= value;}
	}
	public object idexpValue { 
		get{ return this["idexp"];}
		set {if (value==null|| value==DBNull.Value) this["idexp"]= DBNull.Value; else this["idexp"]= value;}
	}
	public Int32? idexpOriginal { 
		get {if (this["idexp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idexp",DataRowVersion.Original];}
	}
	///<summary>
	///Residuo
	///</summary>
	public Decimal? residual{ 
		get {if (this["residual"]==DBNull.Value)return null; return  (Decimal?)this["residual"];}
		set {if (value==null) this["residual"]= DBNull.Value; else this["residual"]= value;}
	}
	public object residualValue { 
		get{ return this["residual"];}
		set {if (value==null|| value==DBNull.Value) this["residual"]= DBNull.Value; else this["residual"]= value;}
	}
	public Decimal? residualOriginal { 
		get {if (this["residual",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["residual",DataRowVersion.Original];}
	}
	///<summary>
	///Previsione preced.
	///</summary>
	public Decimal? previousprevision{ 
		get {if (this["previousprevision"]==DBNull.Value)return null; return  (Decimal?)this["previousprevision"];}
		set {if (value==null) this["previousprevision"]= DBNull.Value; else this["previousprevision"]= value;}
	}
	public object previousprevisionValue { 
		get{ return this["previousprevision"];}
		set {if (value==null|| value==DBNull.Value) this["previousprevision"]= DBNull.Value; else this["previousprevision"]= value;}
	}
	public Decimal? previousprevisionOriginal { 
		get {if (this["previousprevision",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["previousprevision",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Dettaglio variazione
///</summary>
public class finvardetailTable : MetaTableBase<finvardetailRow> {
	public finvardetailTable() : base("finvardetail"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("idupb")){ 
			defineColumn("idupb", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("nvar")){ 
			defineColumn("nvar", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("yvar")){ 
			defineColumn("yvar", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("amount")){ 
			defineColumn("amount", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("description")){ 
			defineColumn("description", typeof(System.String));
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("idfin")){ 
			defineColumn("idfin", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("limit")){ 
			defineColumn("limit", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("annotation")){ 
			defineColumn("annotation", typeof(System.String));
		}
		if (definedColums.ContainsKey("idlcard")){ 
			defineColumn("idlcard", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("rownum")){ 
			defineColumn("rownum", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("idunderwriting")){ 
			defineColumn("idunderwriting", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("prevision2")){ 
			defineColumn("prevision2", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("prevision3")){ 
			defineColumn("prevision3", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("createexpense")){ 
			defineColumn("createexpense", typeof(System.String));
		}
		if (definedColums.ContainsKey("idexp")){ 
			defineColumn("idexp", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("residual")){ 
			defineColumn("residual", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("previousprevision")){ 
			defineColumn("previousprevision", typeof(System.Decimal));
		}
		#endregion

	}
}
}
