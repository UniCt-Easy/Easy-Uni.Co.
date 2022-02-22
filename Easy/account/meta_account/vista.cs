
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
namespace meta_account {
public class accountRow: MetaRow  {
	public accountRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///Codice conto (tabella account)
	///</summary>
	public String codeacc{ 
		get {if (this["codeacc"]==DBNull.Value)return null; return  (String)this["codeacc"];}
		set {if (value==null) this["codeacc"]= DBNull.Value; else this["codeacc"]= value;}
	}
	public object codeaccValue { 
		get{ return this["codeacc"];}
		set {if (value==null|| value==DBNull.Value) this["codeacc"]= DBNull.Value; else this["codeacc"]= value;}
	}
	public String codeaccOriginal { 
		get {if (this["codeacc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeacc",DataRowVersion.Original];}
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
	///Registra il cliente/fornitore nella scrittura in partita doppia
	///	 N: Non è vero che: "Registra il cliente/fornitore nella scrittura in partita doppia"
	///	 S: Non registra il cliente/fornitore nelle scritture
	///</summary>
	public String flagregistry{ 
		get {if (this["flagregistry"]==DBNull.Value)return null; return  (String)this["flagregistry"];}
		set {if (value==null) this["flagregistry"]= DBNull.Value; else this["flagregistry"]= value;}
	}
	public object flagregistryValue { 
		get{ return this["flagregistry"];}
		set {if (value==null|| value==DBNull.Value) this["flagregistry"]= DBNull.Value; else this["flagregistry"]= value;}
	}
	public String flagregistryOriginal { 
		get {if (this["flagregistry",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagregistry",DataRowVersion.Original];}
	}
	///<summary>
	///Transitorio, non è usato al momento nel codice
	///	 N: Non è vero che: "Transitorio"
	///	 S: Transitorio
	///</summary>
	public String flagtransitory{ 
		get {if (this["flagtransitory"]==DBNull.Value)return null; return  (String)this["flagtransitory"];}
		set {if (value==null) this["flagtransitory"]= DBNull.Value; else this["flagtransitory"]= value;}
	}
	public object flagtransitoryValue { 
		get{ return this["flagtransitory"];}
		set {if (value==null|| value==DBNull.Value) this["flagtransitory"]= DBNull.Value; else this["flagtransitory"]= value;}
	}
	public String flagtransitoryOriginal { 
		get {if (this["flagtransitory",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagtransitory",DataRowVersion.Original];}
	}
	///<summary>
	///Registra l'UPB nella scrittura in partita doppia
	///	 N: Non registra l'UPB nella scrittura in partita doppia
	///	 S: Registra l'UPB nella scrittura in partita doppia
	///</summary>
	public String flagupb{ 
		get {if (this["flagupb"]==DBNull.Value)return null; return  (String)this["flagupb"];}
		set {if (value==null) this["flagupb"]= DBNull.Value; else this["flagupb"]= value;}
	}
	public object flagupbValue { 
		get{ return this["flagupb"];}
		set {if (value==null|| value==DBNull.Value) this["flagupb"]= DBNull.Value; else this["flagupb"]= value;}
	}
	public String flagupbOriginal { 
		get {if (this["flagupb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagupb",DataRowVersion.Original];}
	}
	///<summary>
	///ID Tipo conto (tabella accountkind)
	///</summary>
	public String idaccountkind{ 
		get {if (this["idaccountkind"]==DBNull.Value)return null; return  (String)this["idaccountkind"];}
		set {if (value==null) this["idaccountkind"]= DBNull.Value; else this["idaccountkind"]= value;}
	}
	public object idaccountkindValue { 
		get{ return this["idaccountkind"];}
		set {if (value==null|| value==DBNull.Value) this["idaccountkind"]= DBNull.Value; else this["idaccountkind"]= value;}
	}
	public String idaccountkindOriginal { 
		get {if (this["idaccountkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccountkind",DataRowVersion.Original];}
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
	///N. livello
	///</summary>
	public String nlevel{ 
		get {if (this["nlevel"]==DBNull.Value)return null; return  (String)this["nlevel"];}
		set {if (value==null) this["nlevel"]= DBNull.Value; else this["nlevel"]= value;}
	}
	public object nlevelValue { 
		get{ return this["nlevel"];}
		set {if (value==null|| value==DBNull.Value) this["nlevel"]= DBNull.Value; else this["nlevel"]= value;}
	}
	public String nlevelOriginal { 
		get {if (this["nlevel",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["nlevel",DataRowVersion.Original];}
	}
	///<summary>
	///Chiave del conto parent (idacc) su questa stessa tabella
	///</summary>
	public String paridacc{ 
		get {if (this["paridacc"]==DBNull.Value)return null; return  (String)this["paridacc"];}
		set {if (value==null) this["paridacc"]= DBNull.Value; else this["paridacc"]= value;}
	}
	public object paridaccValue { 
		get{ return this["paridacc"];}
		set {if (value==null|| value==DBNull.Value) this["paridacc"]= DBNull.Value; else this["paridacc"]= value;}
	}
	public String paridaccOriginal { 
		get {if (this["paridacc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["paridacc",DataRowVersion.Original];}
	}
	///<summary>
	///Ordine di stampa
	///</summary>
	public String printingorder{ 
		get {if (this["printingorder"]==DBNull.Value)return null; return  (String)this["printingorder"];}
		set {if (value==null) this["printingorder"]= DBNull.Value; else this["printingorder"]= value;}
	}
	public object printingorderValue { 
		get{ return this["printingorder"];}
		set {if (value==null|| value==DBNull.Value) this["printingorder"]= DBNull.Value; else this["printingorder"]= value;}
	}
	public String printingorderOriginal { 
		get {if (this["printingorder",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["printingorder",DataRowVersion.Original];}
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
	///Denominazione
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
	///ID Stato Patrimoniale (tabella patrimony)
	///</summary>
	public String idpatrimony{ 
		get {if (this["idpatrimony"]==DBNull.Value)return null; return  (String)this["idpatrimony"];}
		set {if (value==null) this["idpatrimony"]= DBNull.Value; else this["idpatrimony"]= value;}
	}
	public object idpatrimonyValue { 
		get{ return this["idpatrimony"];}
		set {if (value==null|| value==DBNull.Value) this["idpatrimony"]= DBNull.Value; else this["idpatrimony"]= value;}
	}
	public String idpatrimonyOriginal { 
		get {if (this["idpatrimony",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idpatrimony",DataRowVersion.Original];}
	}
	///<summary>
	///ID Conto Economico (tabella placcount)
	///</summary>
	public String idplaccount{ 
		get {if (this["idplaccount"]==DBNull.Value)return null; return  (String)this["idplaccount"];}
		set {if (value==null) this["idplaccount"]= DBNull.Value; else this["idplaccount"]= value;}
	}
	public object idplaccountValue { 
		get{ return this["idplaccount"];}
		set {if (value==null|| value==DBNull.Value) this["idplaccount"]= DBNull.Value; else this["idplaccount"]= value;}
	}
	public String idplaccountOriginal { 
		get {if (this["idplaccount",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idplaccount",DataRowVersion.Original];}
	}
	///<summary>
	///Utile, forse usato in qualche stampa
	///	 N: Non è vero che: "Utile"
	///	 S: Utile
	///</summary>
	public String flagprofit{ 
		get {if (this["flagprofit"]==DBNull.Value)return null; return  (String)this["flagprofit"];}
		set {if (value==null) this["flagprofit"]= DBNull.Value; else this["flagprofit"]= value;}
	}
	public object flagprofitValue { 
		get{ return this["flagprofit"];}
		set {if (value==null|| value==DBNull.Value) this["flagprofit"]= DBNull.Value; else this["flagprofit"]= value;}
	}
	public String flagprofitOriginal { 
		get {if (this["flagprofit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagprofit",DataRowVersion.Original];}
	}
	///<summary>
	///Perdita , forse usato in qualche stampa
	///	 N: Non è vero che: "Perdita"
	///	 S: Perdita
	///</summary>
	public String flagloss{ 
		get {if (this["flagloss"]==DBNull.Value)return null; return  (String)this["flagloss"];}
		set {if (value==null) this["flagloss"]= DBNull.Value; else this["flagloss"]= value;}
	}
	public object flaglossValue { 
		get{ return this["flagloss"];}
		set {if (value==null|| value==DBNull.Value) this["flagloss"]= DBNull.Value; else this["flagloss"]= value;}
	}
	public String flaglossOriginal { 
		get {if (this["flagloss",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagloss",DataRowVersion.Original];}
	}
	///<summary>
	///Segno positivo nel Conto Economico
	///	 N: Segno negativo nel Conto Economico
	///	 S: Segno positivo nel Conto Economico
	///</summary>
	public String placcount_sign{ 
		get {if (this["placcount_sign"]==DBNull.Value)return null; return  (String)this["placcount_sign"];}
		set {if (value==null) this["placcount_sign"]= DBNull.Value; else this["placcount_sign"]= value;}
	}
	public object placcount_signValue { 
		get{ return this["placcount_sign"];}
		set {if (value==null|| value==DBNull.Value) this["placcount_sign"]= DBNull.Value; else this["placcount_sign"]= value;}
	}
	public String placcount_signOriginal { 
		get {if (this["placcount_sign",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["placcount_sign",DataRowVersion.Original];}
	}
	///<summary>
	///Segno positivo nello stato patrimoniale
	///	 N: Segno negativo nello stato patrimoniale
	///	 S: Segno positivo nello stato patrimoniale
	///</summary>
	public String patrimony_sign{ 
		get {if (this["patrimony_sign"]==DBNull.Value)return null; return  (String)this["patrimony_sign"];}
		set {if (value==null) this["patrimony_sign"]= DBNull.Value; else this["patrimony_sign"]= value;}
	}
	public object patrimony_signValue { 
		get{ return this["patrimony_sign"];}
		set {if (value==null|| value==DBNull.Value) this["patrimony_sign"]= DBNull.Value; else this["patrimony_sign"]= value;}
	}
	public String patrimony_signOriginal { 
		get {if (this["patrimony_sign",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["patrimony_sign",DataRowVersion.Original];}
	}
	///<summary>
	///Gestisci competenza, ossia registra data inizio e fine nelle scritture e collega eventuali ratei nei casi opportuni.
	///	 N: Non gestire dati sulla competenza
	///	 S: Gestisci informazioni su competenza
	///</summary>
	public String flagcompetency{ 
		get {if (this["flagcompetency"]==DBNull.Value)return null; return  (String)this["flagcompetency"];}
		set {if (value==null) this["flagcompetency"]= DBNull.Value; else this["flagcompetency"]= value;}
	}
	public object flagcompetencyValue { 
		get{ return this["flagcompetency"];}
		set {if (value==null|| value==DBNull.Value) this["flagcompetency"]= DBNull.Value; else this["flagcompetency"]= value;}
	}
	public String flagcompetencyOriginal { 
		get {if (this["flagcompetency",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagcompetency",DataRowVersion.Original];}
	}
	///<summary>
	///flag
	///</summary>
	public Int32? flag{ 
		get {if (this["flag"]==DBNull.Value)return null; return  (Int32?)this["flag"];}
		set {if (value==null) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {if (value==null|| value==DBNull.Value) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public Int32? flagOriginal { 
		get {if (this["flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["flag",DataRowVersion.Original];}
	}
	///<summary>
	///Contabilità speciale su impegni di budget (in base a UPB), chiave ad di conto collegato
	///</summary>
	public String idacc_special{ 
		get {if (this["idacc_special"]==DBNull.Value)return null; return  (String)this["idacc_special"];}
		set {if (value==null) this["idacc_special"]= DBNull.Value; else this["idacc_special"]= value;}
	}
	public object idacc_specialValue { 
		get{ return this["idacc_special"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_special"]= DBNull.Value; else this["idacc_special"]= value;}
	}
	public String idacc_specialOriginal { 
		get {if (this["idacc_special",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_special",DataRowVersion.Original];}
	}
	///<summary>
	///Abilita Previsione Budget
	///	 N: Non abilitare Previsione Budget
	///	 S: Abilita Previsione Budget
	///</summary>
	public String flagenablebudgetprev{ 
		get {if (this["flagenablebudgetprev"]==DBNull.Value)return null; return  (String)this["flagenablebudgetprev"];}
		set {if (value==null) this["flagenablebudgetprev"]= DBNull.Value; else this["flagenablebudgetprev"]= value;}
	}
	public object flagenablebudgetprevValue { 
		get{ return this["flagenablebudgetprev"];}
		set {if (value==null|| value==DBNull.Value) this["flagenablebudgetprev"]= DBNull.Value; else this["flagenablebudgetprev"]= value;}
	}
	public String flagenablebudgetprevOriginal { 
		get {if (this["flagenablebudgetprev",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagenablebudgetprev",DataRowVersion.Original];}
	}
	///<summary>
	///Flag utilizzo conto
	///</summary>
	public Int32? flagaccountusage{ 
		get {if (this["flagaccountusage"]==DBNull.Value)return null; return  (Int32?)this["flagaccountusage"];}
		set {if (value==null) this["flagaccountusage"]= DBNull.Value; else this["flagaccountusage"]= value;}
	}
	public object flagaccountusageValue { 
		get{ return this["flagaccountusage"];}
		set {if (value==null|| value==DBNull.Value) this["flagaccountusage"]= DBNull.Value; else this["flagaccountusage"]= value;}
	}
	public Int32? flagaccountusageOriginal { 
		get {if (this["flagaccountusage",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["flagaccountusage",DataRowVersion.Original];}
	}
	///<summary>
	///voce di classificazione per budget economico (idsor di sorting)
	///</summary>
	public Int32? idsor_economicbudget{ 
		get {if (this["idsor_economicbudget"]==DBNull.Value)return null; return  (Int32?)this["idsor_economicbudget"];}
		set {if (value==null) this["idsor_economicbudget"]= DBNull.Value; else this["idsor_economicbudget"]= value;}
	}
	public object idsor_economicbudgetValue { 
		get{ return this["idsor_economicbudget"];}
		set {if (value==null|| value==DBNull.Value) this["idsor_economicbudget"]= DBNull.Value; else this["idsor_economicbudget"]= value;}
	}
	public Int32? idsor_economicbudgetOriginal { 
		get {if (this["idsor_economicbudget",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor_economicbudget",DataRowVersion.Original];}
	}
	///<summary>
	///Segno positivo  nel budget economico
	///	 N: Segno negativo  nel budget economico
	///	 S: Segno positivo  nel budget economico
	///</summary>
	public String economicbudget_sign{ 
		get {if (this["economicbudget_sign"]==DBNull.Value)return null; return  (String)this["economicbudget_sign"];}
		set {if (value==null) this["economicbudget_sign"]= DBNull.Value; else this["economicbudget_sign"]= value;}
	}
	public object economicbudget_signValue { 
		get{ return this["economicbudget_sign"];}
		set {if (value==null|| value==DBNull.Value) this["economicbudget_sign"]= DBNull.Value; else this["economicbudget_sign"]= value;}
	}
	public String economicbudget_signOriginal { 
		get {if (this["economicbudget_sign",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["economicbudget_sign",DataRowVersion.Original];}
	}
	///<summary>
	///voce di classificazione per buedget investimenti (idsor di sorting)
	///</summary>
	public Int32? idsor_investmentbudget{ 
		get {if (this["idsor_investmentbudget"]==DBNull.Value)return null; return  (Int32?)this["idsor_investmentbudget"];}
		set {if (value==null) this["idsor_investmentbudget"]= DBNull.Value; else this["idsor_investmentbudget"]= value;}
	}
	public object idsor_investmentbudgetValue { 
		get{ return this["idsor_investmentbudget"];}
		set {if (value==null|| value==DBNull.Value) this["idsor_investmentbudget"]= DBNull.Value; else this["idsor_investmentbudget"]= value;}
	}
	public Int32? idsor_investmentbudgetOriginal { 
		get {if (this["idsor_investmentbudget",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor_investmentbudget",DataRowVersion.Original];}
	}
	///<summary>
	///segno positivo per budget investimenti
	///	 N: negativo
	///	 S: positivo
	///</summary>
	public String investmentbudget_sign{ 
		get {if (this["investmentbudget_sign"]==DBNull.Value)return null; return  (String)this["investmentbudget_sign"];}
		set {if (value==null) this["investmentbudget_sign"]= DBNull.Value; else this["investmentbudget_sign"]= value;}
	}
	public object investmentbudget_signValue { 
		get{ return this["investmentbudget_sign"];}
		set {if (value==null|| value==DBNull.Value) this["investmentbudget_sign"]= DBNull.Value; else this["investmentbudget_sign"]= value;}
	}
	public String investmentbudget_signOriginal { 
		get {if (this["investmentbudget_sign",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["investmentbudget_sign",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Piano dei conti
///</summary>
public class accountTable : MetaTableBase<accountRow> {
	public accountTable() : base("account"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("idacc")){ 
			defineColumn("idacc", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("ayear")){ 
			defineColumn("ayear", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("codeacc")){ 
			defineColumn("codeacc", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("flagregistry")){ 
			defineColumn("flagregistry", typeof(System.String));
		}
		if (definedColums.ContainsKey("flagtransitory")){ 
			defineColumn("flagtransitory", typeof(System.String));
		}
		if (definedColums.ContainsKey("flagupb")){ 
			defineColumn("flagupb", typeof(System.String));
		}
		if (definedColums.ContainsKey("idaccountkind")){ 
			defineColumn("idaccountkind", typeof(System.String));
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("nlevel")){ 
			defineColumn("nlevel", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("paridacc")){ 
			defineColumn("paridacc", typeof(System.String));
		}
		if (definedColums.ContainsKey("printingorder")){ 
			defineColumn("printingorder", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("rtf")){ 
			defineColumn("rtf", typeof(System.Byte[]));
		}
		if (definedColums.ContainsKey("title")){ 
			defineColumn("title", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("txt")){ 
			defineColumn("txt", typeof(System.String));
		}
		if (definedColums.ContainsKey("idpatrimony")){ 
			defineColumn("idpatrimony", typeof(System.String));
		}
		if (definedColums.ContainsKey("idplaccount")){ 
			defineColumn("idplaccount", typeof(System.String));
		}
		if (definedColums.ContainsKey("flagprofit")){ 
			defineColumn("flagprofit", typeof(System.String));
		}
		if (definedColums.ContainsKey("flagloss")){ 
			defineColumn("flagloss", typeof(System.String));
		}
		if (definedColums.ContainsKey("placcount_sign")){ 
			defineColumn("placcount_sign", typeof(System.String));
		}
		if (definedColums.ContainsKey("patrimony_sign")){ 
			defineColumn("patrimony_sign", typeof(System.String));
		}
		if (definedColums.ContainsKey("flagcompetency")){ 
			defineColumn("flagcompetency", typeof(System.String));
		}
		if (definedColums.ContainsKey("flag")){ 
			defineColumn("flag", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idacc_special")){ 
			defineColumn("idacc_special", typeof(System.String));
		}
		if (definedColums.ContainsKey("flagenablebudgetprev")){ 
			defineColumn("flagenablebudgetprev", typeof(System.String));
		}
		if (definedColums.ContainsKey("flagaccountusage")){ 
			defineColumn("flagaccountusage", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor_economicbudget")){ 
			defineColumn("idsor_economicbudget", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("economicbudget_sign")){ 
			defineColumn("economicbudget_sign", typeof(System.String));
		}
		if (definedColums.ContainsKey("idsor_investmentbudget")){ 
			defineColumn("idsor_investmentbudget", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("investmentbudget_sign")){ 
			defineColumn("investmentbudget_sign", typeof(System.String));
		}
		#endregion

	}
}
}
