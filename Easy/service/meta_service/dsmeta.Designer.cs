
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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
namespace meta_service {
public class serviceRow: MetaRow  {
	public serviceRow(DataRowBuilder rb) : base(rb) {} 

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
	///Immissione manuale ritenute
	///</summary>
	public String allowedit{ 
		get {if (this["allowedit"]==DBNull.Value)return null; return  (String)this["allowedit"];}
		set {if (value==null) this["allowedit"]= DBNull.Value; else this["allowedit"]= value;}
	}
	public object alloweditValue { 
		get{ return this["allowedit"];}
		set {if (value==null|| value==DBNull.Value) this["allowedit"]= DBNull.Value; else this["allowedit"]= value;}
	}
	public String alloweditOriginal { 
		get {if (this["allowedit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["allowedit",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo Cert.Fiscale
	///</summary>
	public String certificatekind{ 
		get {if (this["certificatekind"]==DBNull.Value)return null; return  (String)this["certificatekind"];}
		set {if (value==null) this["certificatekind"]= DBNull.Value; else this["certificatekind"]= value;}
	}
	public object certificatekindValue { 
		get{ return this["certificatekind"];}
		set {if (value==null|| value==DBNull.Value) this["certificatekind"]= DBNull.Value; else this["certificatekind"]= value;}
	}
	public String certificatekindOriginal { 
		get {if (this["certificatekind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["certificatekind",DataRowVersion.Original];}
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
	///Includi sempre in certificazioni fiscali, anche se non ci sono ritenute
	///	 N: Include in cert. fiscali anche in assenza di ritenute
	///	 S: Includi sempre in certificazioni fiscali, anche se non ci sono ritenute
	///</summary>
	public String flagalwaysinfiscalmodels{ 
		get {if (this["flagalwaysinfiscalmodels"]==DBNull.Value)return null; return  (String)this["flagalwaysinfiscalmodels"];}
		set {if (value==null) this["flagalwaysinfiscalmodels"]= DBNull.Value; else this["flagalwaysinfiscalmodels"]= value;}
	}
	public object flagalwaysinfiscalmodelsValue { 
		get{ return this["flagalwaysinfiscalmodels"];}
		set {if (value==null|| value==DBNull.Value) this["flagalwaysinfiscalmodels"]= DBNull.Value; else this["flagalwaysinfiscalmodels"]= value;}
	}
	public String flagalwaysinfiscalmodelsOriginal { 
		get {if (this["flagalwaysinfiscalmodels",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagalwaysinfiscalmodels",DataRowVersion.Original];}
	}
	///<summary>
	///Calcola Detrazioni, determina il valore iniziale di notaxappliance della tabella parasubcontractyear (I se flagapplyabatements='S' o N se flagapplyabatements='N')
	///	 N: Non calcolare detrazioni
	///	 S: Calcola Detrazioni
	///</summary>
	public String flagapplyabatements{ 
		get {if (this["flagapplyabatements"]==DBNull.Value)return null; return  (String)this["flagapplyabatements"];}
		set {if (value==null) this["flagapplyabatements"]= DBNull.Value; else this["flagapplyabatements"]= value;}
	}
	public object flagapplyabatementsValue { 
		get{ return this["flagapplyabatements"];}
		set {if (value==null|| value==DBNull.Value) this["flagapplyabatements"]= DBNull.Value; else this["flagapplyabatements"]= value;}
	}
	public String flagapplyabatementsOriginal { 
		get {if (this["flagapplyabatements",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagapplyabatements",DataRowVersion.Original];}
	}
	///<summary>
	///Non dedurre le ritenute previdenziali e assistenziali dall'imponibile fiscale
	///	 N: Deduci le ritenute previdenziali e assistenziali dall'imponibile fiscale
	///	 S: Non dedurre le ritenute previdenziali e assistenziali dall'imponibile fiscale
	///</summary>
	public String flagonlyfiscalabatement{ 
		get {if (this["flagonlyfiscalabatement"]==DBNull.Value)return null; return  (String)this["flagonlyfiscalabatement"];}
		set {if (value==null) this["flagonlyfiscalabatement"]= DBNull.Value; else this["flagonlyfiscalabatement"]= value;}
	}
	public object flagonlyfiscalabatementValue { 
		get{ return this["flagonlyfiscalabatement"];}
		set {if (value==null|| value==DBNull.Value) this["flagonlyfiscalabatement"]= DBNull.Value; else this["flagonlyfiscalabatement"]= value;}
	}
	public String flagonlyfiscalabatementOriginal { 
		get {if (this["flagonlyfiscalabatement",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagonlyfiscalabatement",DataRowVersion.Original];}
	}
	///<summary>
	///id Causale per Modello 770
	///</summary>
	public Int32? idmotive{ 
		get {if (this["idmotive"]==DBNull.Value)return null; return  (Int32?)this["idmotive"];}
		set {if (value==null) this["idmotive"]= DBNull.Value; else this["idmotive"]= value;}
	}
	public object idmotiveValue { 
		get{ return this["idmotive"];}
		set {if (value==null|| value==DBNull.Value) this["idmotive"]= DBNull.Value; else this["idmotive"]= value;}
	}
	public Int32? idmotiveOriginal { 
		get {if (this["idmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idmotive",DataRowVersion.Original];}
	}
	///<summary>
	///Visibile in missione
	///</summary>
	public String itinerationvisible{ 
		get {if (this["itinerationvisible"]==DBNull.Value)return null; return  (String)this["itinerationvisible"];}
		set {if (value==null) this["itinerationvisible"]= DBNull.Value; else this["itinerationvisible"]= value;}
	}
	public object itinerationvisibleValue { 
		get{ return this["itinerationvisible"];}
		set {if (value==null|| value==DBNull.Value) this["itinerationvisible"]= DBNull.Value; else this["itinerationvisible"]= value;}
	}
	public String itinerationvisibleOriginal { 
		get {if (this["itinerationvisible",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["itinerationvisible",DataRowVersion.Original];}
	}
	///<summary>
	///Importo iva
	///</summary>
	public String ivaamount{ 
		get {if (this["ivaamount"]==DBNull.Value)return null; return  (String)this["ivaamount"];}
		set {if (value==null) this["ivaamount"]= DBNull.Value; else this["ivaamount"]= value;}
	}
	public object ivaamountValue { 
		get{ return this["ivaamount"];}
		set {if (value==null|| value==DBNull.Value) this["ivaamount"]= DBNull.Value; else this["ivaamount"]= value;}
	}
	public String ivaamountOriginal { 
		get {if (this["ivaamount",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ivaamount",DataRowVersion.Original];}
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
	///OCCASIONALE PARASUBORDINATI PROFESSIONALE DIPENDENTE
	///</summary>
	public String module{ 
		get {if (this["module"]==DBNull.Value)return null; return  (String)this["module"];}
		set {if (value==null) this["module"]= DBNull.Value; else this["module"]= value;}
	}
	public object moduleValue { 
		get{ return this["module"];}
		set {if (value==null|| value==DBNull.Value) this["module"]= DBNull.Value; else this["module"]= value;}
	}
	public String moduleOriginal { 
		get {if (this["module",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["module",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo Record 770 e Certificazione Unica
	///</summary>
	public String rec770kind{ 
		get {if (this["rec770kind"]==DBNull.Value)return null; return  (String)this["rec770kind"];}
		set {if (value==null) this["rec770kind"]= DBNull.Value; else this["rec770kind"]= value;}
	}
	public object rec770kindValue { 
		get{ return this["rec770kind"];}
		set {if (value==null|| value==DBNull.Value) this["rec770kind"]= DBNull.Value; else this["rec770kind"]= value;}
	}
	public String rec770kindOriginal { 
		get {if (this["rec770kind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["rec770kind",DataRowVersion.Original];}
	}
	///<summary>
	///codice prestazione (tabella service)
	///</summary>
	public String codeser{ 
		get {if (this["codeser"]==DBNull.Value)return null; return  (String)this["codeser"];}
		set {if (value==null) this["codeser"]= DBNull.Value; else this["codeser"]= value;}
	}
	public object codeserValue { 
		get{ return this["codeser"];}
		set {if (value==null|| value==DBNull.Value) this["codeser"]= DBNull.Value; else this["codeser"]= value;}
	}
	public String codeserOriginal { 
		get {if (this["codeser",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeser",DataRowVersion.Original];}
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
	///Con Conguaglio a fine anno
	///	 N: Non richiede conguaglio a fine anno
	///	 S: Richiede conguaglio a fine anno
	///</summary>
	public String flagneedbalance{ 
		get {if (this["flagneedbalance"]==DBNull.Value)return null; return  (String)this["flagneedbalance"];}
		set {if (value==null) this["flagneedbalance"]= DBNull.Value; else this["flagneedbalance"]= value;}
	}
	public object flagneedbalanceValue { 
		get{ return this["flagneedbalance"];}
		set {if (value==null|| value==DBNull.Value) this["flagneedbalance"]= DBNull.Value; else this["flagneedbalance"]= value;}
	}
	public String flagneedbalanceOriginal { 
		get {if (this["flagneedbalance",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagneedbalance",DataRowVersion.Original];}
	}
	///<summary>
	///Per Residenti all''estero
	///	 N: non è per Residenti all''estero
	///	 S: Per Residenti all''estero
	///</summary>
	public String flagforeign{ 
		get {if (this["flagforeign"]==DBNull.Value)return null; return  (String)this["flagforeign"];}
		set {if (value==null) this["flagforeign"]= DBNull.Value; else this["flagforeign"]= value;}
	}
	public object flagforeignValue { 
		get{ return this["flagforeign"];}
		set {if (value==null|| value==DBNull.Value) this["flagforeign"]= DBNull.Value; else this["flagforeign"]= value;}
	}
	public String flagforeignOriginal { 
		get {if (this["flagforeign",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagforeign",DataRowVersion.Original];}
	}
	///<summary>
	///Voce CSA per Imponibile
	///</summary>
	public String voce8000{ 
		get {if (this["voce8000"]==DBNull.Value)return null; return  (String)this["voce8000"];}
		set {if (value==null) this["voce8000"]= DBNull.Value; else this["voce8000"]= value;}
	}
	public object voce8000Value { 
		get{ return this["voce8000"];}
		set {if (value==null|| value==DBNull.Value) this["voce8000"]= DBNull.Value; else this["voce8000"]= value;}
	}
	public String voce8000Original { 
		get {if (this["voce8000",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["voce8000",DataRowVersion.Original];}
	}
	///<summary>
	///Predefinita per il WEB 
	///</summary>
	public String webdefault{ 
		get {if (this["webdefault"]==DBNull.Value)return null; return  (String)this["webdefault"];}
		set {if (value==null) this["webdefault"]= DBNull.Value; else this["webdefault"]= value;}
	}
	public object webdefaultValue { 
		get{ return this["webdefault"];}
		set {if (value==null|| value==DBNull.Value) this["webdefault"]= DBNull.Value; else this["webdefault"]= value;}
	}
	public String webdefaultOriginal { 
		get {if (this["webdefault",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["webdefault",DataRowVersion.Original];}
	}
	///<summary>
	///Prestazione per Pignoramento Presso Terzi
	///	 N: Non è prestazione per Pignoramento Presso Terzi
	///	 S: Prestazione per Pignoramento Presso Terzi
	///</summary>
	public String flagdistraint{ 
		get {if (this["flagdistraint"]==DBNull.Value)return null; return  (String)this["flagdistraint"];}
		set {if (value==null) this["flagdistraint"]= DBNull.Value; else this["flagdistraint"]= value;}
	}
	public object flagdistraintValue { 
		get{ return this["flagdistraint"];}
		set {if (value==null|| value==DBNull.Value) this["flagdistraint"]= DBNull.Value; else this["flagdistraint"]= value;}
	}
	public String flagdistraintOriginal { 
		get {if (this["flagdistraint",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagdistraint",DataRowVersion.Original];}
	}
	///<summary>
	///Voce CSA per Spese missione Italia
	///</summary>
	public String voce8000refund_i{ 
		get {if (this["voce8000refund_i"]==DBNull.Value)return null; return  (String)this["voce8000refund_i"];}
		set {if (value==null) this["voce8000refund_i"]= DBNull.Value; else this["voce8000refund_i"]= value;}
	}
	public object voce8000refund_iValue { 
		get{ return this["voce8000refund_i"];}
		set {if (value==null|| value==DBNull.Value) this["voce8000refund_i"]= DBNull.Value; else this["voce8000refund_i"]= value;}
	}
	public String voce8000refund_iOriginal { 
		get {if (this["voce8000refund_i",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["voce8000refund_i",DataRowVersion.Original];}
	}
	///<summary>
	///Voce CSA per Spese missione Estero
	///</summary>
	public String voce8000refund_e{ 
		get {if (this["voce8000refund_e"]==DBNull.Value)return null; return  (String)this["voce8000refund_e"];}
		set {if (value==null) this["voce8000refund_e"]= DBNull.Value; else this["voce8000refund_e"]= value;}
	}
	public object voce8000refund_eValue { 
		get{ return this["voce8000refund_e"];}
		set {if (value==null|| value==DBNull.Value) this["voce8000refund_e"]= DBNull.Value; else this["voce8000refund_e"]= value;}
	}
	public String voce8000refund_eOriginal { 
		get {if (this["voce8000refund_e",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["voce8000refund_e",DataRowVersion.Original];}
	}
	///<summary>
	///Usabilità per il Record 8000 (Flag a Bit Configurabile). Il significato dei bit è configurato nella tabella servicecsausability
	///</summary>
	public Int32? flagcsausability{ 
		get {if (this["flagcsausability"]==DBNull.Value)return null; return  (Int32?)this["flagcsausability"];}
		set {if (value==null) this["flagcsausability"]= DBNull.Value; else this["flagcsausability"]= value;}
	}
	public object flagcsausabilityValue { 
		get{ return this["flagcsausability"];}
		set {if (value==null|| value==DBNull.Value) this["flagcsausability"]= DBNull.Value; else this["flagcsausability"]= value;}
	}
	public Int32? flagcsausabilityOriginal { 
		get {if (this["flagcsausability",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["flagcsausability",DataRowVersion.Original];}
	}
	///<summary>
	///Non applicare quota esente previdenziale
	///	 N: Non è vero che: "Non applicare quota esente previdenziale"
	///	 S: Non applicare quota esente previdenziale
	///</summary>
	public String flagnoexemptionquote{ 
		get {if (this["flagnoexemptionquote"]==DBNull.Value)return null; return  (String)this["flagnoexemptionquote"];}
		set {if (value==null) this["flagnoexemptionquote"]= DBNull.Value; else this["flagnoexemptionquote"]= value;}
	}
	public object flagnoexemptionquoteValue { 
		get{ return this["flagnoexemptionquote"];}
		set {if (value==null|| value==DBNull.Value) this["flagnoexemptionquote"]= DBNull.Value; else this["flagnoexemptionquote"]= value;}
	}
	public String flagnoexemptionquoteOriginal { 
		get {if (this["flagnoexemptionquote",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagnoexemptionquote",DataRowVersion.Original];}
	}
	///<summary>
	///abilita la trasmissione a dalia
	///</summary>
	public String flagdalia{ 
		get {if (this["flagdalia"]==DBNull.Value)return null; return  (String)this["flagdalia"];}
		set {if (value==null) this["flagdalia"]= DBNull.Value; else this["flagdalia"]= value;}
	}
	public object flagdaliaValue { 
		get{ return this["flagdalia"];}
		set {if (value==null|| value==DBNull.Value) this["flagdalia"]= DBNull.Value; else this["flagdalia"]= value;}
	}
	public String flagdaliaOriginal { 
		get {if (this["flagdalia",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagdalia",DataRowVersion.Original];}
	}
	///<summary>
	///alias codice prestazione  per 770
	///</summary>
	public String servicecode770{ 
		get {if (this["servicecode770"]==DBNull.Value)return null; return  (String)this["servicecode770"];}
		set {if (value==null) this["servicecode770"]= DBNull.Value; else this["servicecode770"]= value;}
	}
	public object servicecode770Value { 
		get{ return this["servicecode770"];}
		set {if (value==null|| value==DBNull.Value) this["servicecode770"]= DBNull.Value; else this["servicecode770"]= value;}
	}
	public String servicecode770Original { 
		get {if (this["servicecode770",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["servicecode770",DataRowVersion.Original];}
	}
	///<summary>
	///Documenti richiesti per i pagamenti di questo tipo prestazioni
	///</summary>
	public Int32? requested_doc{ 
		get {if (this["requested_doc"]==DBNull.Value)return null; return  (Int32?)this["requested_doc"];}
		set {if (value==null) this["requested_doc"]= DBNull.Value; else this["requested_doc"]= value;}
	}
	public object requested_docValue { 
		get{ return this["requested_doc"];}
		set {if (value==null|| value==DBNull.Value) this["requested_doc"]= DBNull.Value; else this["requested_doc"]= value;}
	}
	public Int32? requested_docOriginal { 
		get {if (this["requested_doc",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["requested_doc",DataRowVersion.Original];}
	}
	public String flagnoncumula{ 
		get {if (this["flagnoncumula"]==DBNull.Value)return null; return  (String)this["flagnoncumula"];}
		set {if (value==null) this["flagnoncumula"]= DBNull.Value; else this["flagnoncumula"]= value;}
	}
	public object flagnoncumulaValue { 
		get{ return this["flagnoncumula"];}
		set {if (value==null|| value==DBNull.Value) this["flagnoncumula"]= DBNull.Value; else this["flagnoncumula"]= value;}
	}
	public String flagnoncumulaOriginal { 
		get {if (this["flagnoncumula",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagnoncumula",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Tipo Prestazione
///</summary>
public class serviceTable : MetaTableBase<serviceRow> {
	public serviceTable() : base("service"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"active",createColumn("active",typeof(string),true,false)},
			{"allowedit",createColumn("allowedit",typeof(string),true,false)},
			{"certificatekind",createColumn("certificatekind",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"flagalwaysinfiscalmodels",createColumn("flagalwaysinfiscalmodels",typeof(string),true,false)},
			{"flagapplyabatements",createColumn("flagapplyabatements",typeof(string),true,false)},
			{"flagonlyfiscalabatement",createColumn("flagonlyfiscalabatement",typeof(string),false,false)},
			{"idmotive",createColumn("idmotive",typeof(int),true,false)},
			{"itinerationvisible",createColumn("itinerationvisible",typeof(string),true,false)},
			{"ivaamount",createColumn("ivaamount",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"module",createColumn("module",typeof(string),true,false)},
			{"rec770kind",createColumn("rec770kind",typeof(string),true,false)},
			{"codeser",createColumn("codeser",typeof(string),false,false)},
			{"idser",createColumn("idser",typeof(int),false,false)},
			{"flagneedbalance",createColumn("flagneedbalance",typeof(string),true,false)},
			{"flagforeign",createColumn("flagforeign",typeof(string),true,false)},
			{"voce8000",createColumn("voce8000",typeof(string),true,false)},
			{"webdefault",createColumn("webdefault",typeof(string),true,false)},
			{"flagdistraint",createColumn("flagdistraint",typeof(string),true,false)},
			{"voce8000refund_i",createColumn("voce8000refund_i",typeof(string),true,false)},
			{"voce8000refund_e",createColumn("voce8000refund_e",typeof(string),true,false)},
			{"flagcsausability",createColumn("flagcsausability",typeof(int),true,false)},
			{"flagnoexemptionquote",createColumn("flagnoexemptionquote",typeof(string),true,false)},
			{"flagdalia",createColumn("flagdalia",typeof(string),true,false)},
			{"servicecode770",createColumn("servicecode770",typeof(string),true,false)},
			{"requested_doc",createColumn("requested_doc",typeof(int),true,false)},
			{"flagnoncumula",createColumn("flagnoncumula",typeof(string),true,false)},
		};
	}
}
}
