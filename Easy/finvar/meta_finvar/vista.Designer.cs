
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
namespace meta_finvar {
public class finvarRow: MetaRow  {
	public finvarRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///Provvedimento
	///</summary>
	public String enactment{ 
		get {if (this["enactment"]==DBNull.Value)return null; return  (String)this["enactment"];}
		set {if (value==null) this["enactment"]= DBNull.Value; else this["enactment"]= value;}
	}
	public object enactmentValue { 
		get{ return this["enactment"];}
		set {if (value==null|| value==DBNull.Value) this["enactment"]= DBNull.Value; else this["enactment"]= value;}
	}
	public String enactmentOriginal { 
		get {if (this["enactment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["enactment",DataRowVersion.Original];}
	}
	///<summary>
	///Data provv.
	///</summary>
	public DateTime? enactmentdate{ 
		get {if (this["enactmentdate"]==DBNull.Value)return null; return  (DateTime?)this["enactmentdate"];}
		set {if (value==null) this["enactmentdate"]= DBNull.Value; else this["enactmentdate"]= value;}
	}
	public object enactmentdateValue { 
		get{ return this["enactmentdate"];}
		set {if (value==null|| value==DBNull.Value) this["enactmentdate"]= DBNull.Value; else this["enactmentdate"]= value;}
	}
	public DateTime? enactmentdateOriginal { 
		get {if (this["enactmentdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["enactmentdate",DataRowVersion.Original];}
	}
	///<summary>
	///Crediti
	///	 N: Non agisce sui crediti
	///	 S: Crediti
	///</summary>
	public String flagcredit{ 
		get {if (this["flagcredit"]==DBNull.Value)return null; return  (String)this["flagcredit"];}
		set {if (value==null) this["flagcredit"]= DBNull.Value; else this["flagcredit"]= value;}
	}
	public object flagcreditValue { 
		get{ return this["flagcredit"];}
		set {if (value==null|| value==DBNull.Value) this["flagcredit"]= DBNull.Value; else this["flagcredit"]= value;}
	}
	public String flagcreditOriginal { 
		get {if (this["flagcredit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagcredit",DataRowVersion.Original];}
	}
	///<summary>
	///Prev.principale
	///	 N: Non agisce sulla prev. principale
	///	 S: Prev.principale
	///</summary>
	public String flagprevision{ 
		get {if (this["flagprevision"]==DBNull.Value)return null; return  (String)this["flagprevision"];}
		set {if (value==null) this["flagprevision"]= DBNull.Value; else this["flagprevision"]= value;}
	}
	public object flagprevisionValue { 
		get{ return this["flagprevision"];}
		set {if (value==null|| value==DBNull.Value) this["flagprevision"]= DBNull.Value; else this["flagprevision"]= value;}
	}
	public String flagprevisionOriginal { 
		get {if (this["flagprevision",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagprevision",DataRowVersion.Original];}
	}
	///<summary>
	///Dotazione Cassa
	///	 N: Non agisce sulla dotazione cassa
	///	 S: Agisce sulla dotaz. cassa
	///</summary>
	public String flagproceeds{ 
		get {if (this["flagproceeds"]==DBNull.Value)return null; return  (String)this["flagproceeds"];}
		set {if (value==null) this["flagproceeds"]= DBNull.Value; else this["flagproceeds"]= value;}
	}
	public object flagproceedsValue { 
		get{ return this["flagproceeds"];}
		set {if (value==null|| value==DBNull.Value) this["flagproceeds"]= DBNull.Value; else this["flagproceeds"]= value;}
	}
	public String flagproceedsOriginal { 
		get {if (this["flagproceeds",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagproceeds",DataRowVersion.Original];}
	}
	///<summary>
	///Prev.secondaria
	///	 N: Non agisce sulla prev.secondaria
	///	 S: Prev.secondaria
	///</summary>
	public String flagsecondaryprev{ 
		get {if (this["flagsecondaryprev"]==DBNull.Value)return null; return  (String)this["flagsecondaryprev"];}
		set {if (value==null) this["flagsecondaryprev"]= DBNull.Value; else this["flagsecondaryprev"]= value;}
	}
	public object flagsecondaryprevValue { 
		get{ return this["flagsecondaryprev"];}
		set {if (value==null|| value==DBNull.Value) this["flagsecondaryprev"]= DBNull.Value; else this["flagsecondaryprev"]= value;}
	}
	public String flagsecondaryprevOriginal { 
		get {if (this["flagsecondaryprev",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagsecondaryprev",DataRowVersion.Original];}
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
	///Num. provv.
	///</summary>
	public String nenactment{ 
		get {if (this["nenactment"]==DBNull.Value)return null; return  (String)this["nenactment"];}
		set {if (value==null) this["nenactment"]= DBNull.Value; else this["nenactment"]= value;}
	}
	public object nenactmentValue { 
		get{ return this["nenactment"];}
		set {if (value==null|| value==DBNull.Value) this["nenactment"]= DBNull.Value; else this["nenactment"]= value;}
	}
	public String nenactmentOriginal { 
		get {if (this["nenactment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["nenactment",DataRowVersion.Original];}
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
	///Ufficiale
	///</summary>
	public String official{ 
		get {if (this["official"]==DBNull.Value)return null; return  (String)this["official"];}
		set {if (value==null) this["official"]= DBNull.Value; else this["official"]= value;}
	}
	public object officialValue { 
		get{ return this["official"];}
		set {if (value==null|| value==DBNull.Value) this["official"]= DBNull.Value; else this["official"]= value;}
	}
	public String officialOriginal { 
		get {if (this["official",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["official",DataRowVersion.Original];}
	}
	///<summary>
	///Num. Var. Ufficiale
	///</summary>
	public Int32? nofficial{ 
		get {if (this["nofficial"]==DBNull.Value)return null; return  (Int32?)this["nofficial"];}
		set {if (value==null) this["nofficial"]= DBNull.Value; else this["nofficial"]= value;}
	}
	public object nofficialValue { 
		get{ return this["nofficial"];}
		set {if (value==null|| value==DBNull.Value) this["nofficial"]= DBNull.Value; else this["nofficial"]= value;}
	}
	public Int32? nofficialOriginal { 
		get {if (this["nofficial",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nofficial",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo variazione
	///	 1: Normale
	///	 2: Ripartizione
	///	 3: Assestamento
	///	 4: Storno
	///	 5: Iniziale
	///</summary>
	public Byte? variationkind{ 
		get {if (this["variationkind"]==DBNull.Value)return null; return  (Byte?)this["variationkind"];}
		set {if (value==null) this["variationkind"]= DBNull.Value; else this["variationkind"]= value;}
	}
	public object variationkindValue { 
		get{ return this["variationkind"];}
		set {if (value==null|| value==DBNull.Value) this["variationkind"]= DBNull.Value; else this["variationkind"]= value;}
	}
	public Byte? variationkindOriginal { 
		get {if (this["variationkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["variationkind",DataRowVersion.Original];}
	}
	///<summary>
	///ID Stato variazione bilancio (tabella finvarstatus)
	///</summary>
	public Int16? idfinvarstatus{ 
		get {if (this["idfinvarstatus"]==DBNull.Value)return null; return  (Int16?)this["idfinvarstatus"];}
		set {if (value==null) this["idfinvarstatus"]= DBNull.Value; else this["idfinvarstatus"]= value;}
	}
	public object idfinvarstatusValue { 
		get{ return this["idfinvarstatus"];}
		set {if (value==null|| value==DBNull.Value) this["idfinvarstatus"]= DBNull.Value; else this["idfinvarstatus"]= value;}
	}
	public Int16? idfinvarstatusOriginal { 
		get {if (this["idfinvarstatus",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["idfinvarstatus",DataRowVersion.Original];}
	}
	///<summary>
	///ID Atto Amministrativo (tabella enactment)
	///</summary>
	public Int32? idenactment{ 
		get {if (this["idenactment"]==DBNull.Value)return null; return  (Int32?)this["idenactment"];}
		set {if (value==null) this["idenactment"]= DBNull.Value; else this["idenactment"]= value;}
	}
	public object idenactmentValue { 
		get{ return this["idenactment"];}
		set {if (value==null|| value==DBNull.Value) this["idenactment"]= DBNull.Value; else this["idenactment"]= value;}
	}
	public Int32? idenactmentOriginal { 
		get {if (this["idenactment",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idenactment",DataRowVersion.Original];}
	}
	///<summary>
	///Motivazione
	///</summary>
	public String reason{ 
		get {if (this["reason"]==DBNull.Value)return null; return  (String)this["reason"];}
		set {if (value==null) this["reason"]= DBNull.Value; else this["reason"]= value;}
	}
	public object reasonValue { 
		get{ return this["reason"];}
		set {if (value==null|| value==DBNull.Value) this["reason"]= DBNull.Value; else this["reason"]= value;}
	}
	public String reasonOriginal { 
		get {if (this["reason",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["reason",DataRowVersion.Original];}
	}
	///<summary>
	///Limite da applicare
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
	///ID Tipo Classificazione (tabella finvarkind)
	///</summary>
	public Int32? idfinvarkind{ 
		get {if (this["idfinvarkind"]==DBNull.Value)return null; return  (Int32?)this["idfinvarkind"];}
		set {if (value==null) this["idfinvarkind"]= DBNull.Value; else this["idfinvarkind"]= value;}
	}
	public object idfinvarkindValue { 
		get{ return this["idfinvarkind"];}
		set {if (value==null|| value==DBNull.Value) this["idfinvarkind"]= DBNull.Value; else this["idfinvarkind"]= value;}
	}
	public Int32? idfinvarkindOriginal { 
		get {if (this["idfinvarkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idfinvarkind",DataRowVersion.Original];}
	}
	///<summary>
	///Storno di cassa
	///	 N: Non ? storno di cassa
	///	 S: Storno di cassa
	///</summary>
	public String moneytransfer{ 
		get {if (this["moneytransfer"]==DBNull.Value)return null; return  (String)this["moneytransfer"];}
		set {if (value==null) this["moneytransfer"]= DBNull.Value; else this["moneytransfer"]= value;}
	}
	public object moneytransferValue { 
		get{ return this["moneytransfer"];}
		set {if (value==null|| value==DBNull.Value) this["moneytransfer"]= DBNull.Value; else this["moneytransfer"]= value;}
	}
	public String moneytransferOriginal { 
		get {if (this["moneytransfer",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["moneytransfer",DataRowVersion.Original];}
	}
	///<summary>
	///Flag a bit
	///</summary>
	public Int32? varflag{ 
		get {if (this["varflag"]==DBNull.Value)return null; return  (Int32?)this["varflag"];}
		set {if (value==null) this["varflag"]= DBNull.Value; else this["varflag"]= value;}
	}
	public object varflagValue { 
		get{ return this["varflag"];}
		set {if (value==null|| value==DBNull.Value) this["varflag"]= DBNull.Value; else this["varflag"]= value;}
	}
	public Int32? varflagOriginal { 
		get {if (this["varflag",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["varflag",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Variazione/Storno
///</summary>
public class finvarTable : MetaTableBase<finvarRow> {
	public finvarTable() : base("finvar"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("nvar")){ 
			defineColumn("nvar", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("yvar")){ 
			defineColumn("yvar", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("adate")){ 
			defineColumn("adate", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("description")){ 
			defineColumn("description", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("enactment")){ 
			defineColumn("enactment", typeof(System.String));
		}
		if (definedColums.ContainsKey("enactmentdate")){ 
			defineColumn("enactmentdate", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("flagcredit")){ 
			defineColumn("flagcredit", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("flagprevision")){ 
			defineColumn("flagprevision", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("flagproceeds")){ 
			defineColumn("flagproceeds", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("flagsecondaryprev")){ 
			defineColumn("flagsecondaryprev", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("nenactment")){ 
			defineColumn("nenactment", typeof(System.String));
		}
		if (definedColums.ContainsKey("rtf")){ 
			defineColumn("rtf", typeof(System.Byte[]));
		}
		if (definedColums.ContainsKey("txt")){ 
			defineColumn("txt", typeof(System.String));
		}
		if (definedColums.ContainsKey("official")){ 
			defineColumn("official", typeof(System.String));
		}
		if (definedColums.ContainsKey("nofficial")){ 
			defineColumn("nofficial", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("variationkind")){ 
			defineColumn("variationkind", typeof(System.Byte),false);
		}
		if (definedColums.ContainsKey("idfinvarstatus")){ 
			defineColumn("idfinvarstatus", typeof(System.Int16));
		}
		if (definedColums.ContainsKey("idenactment")){ 
			defineColumn("idenactment", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("reason")){ 
			defineColumn("reason", typeof(System.String));
		}
		if (definedColums.ContainsKey("limit")){ 
			defineColumn("limit", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("idman")){ 
			defineColumn("idman", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("annotation")){ 
			defineColumn("annotation", typeof(System.String));
		}
		if (definedColums.ContainsKey("idsor01")){ 
			defineColumn("idsor01", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor02")){ 
			defineColumn("idsor02", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor03")){ 
			defineColumn("idsor03", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor04")){ 
			defineColumn("idsor04", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor05")){ 
			defineColumn("idsor05", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idfinvarkind")){ 
			defineColumn("idfinvarkind", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("moneytransfer")){ 
			defineColumn("moneytransfer", typeof(System.String));
		}
		if (definedColums.ContainsKey("varflag")){ 
			defineColumn("varflag", typeof(System.Int32));
		}
		#endregion

	}
}
}
