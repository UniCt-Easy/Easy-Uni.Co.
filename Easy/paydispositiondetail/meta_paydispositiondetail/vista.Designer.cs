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
namespace meta_paydispositiondetail {
public class paydispositiondetailRow: MetaRow  {
	public paydispositiondetailRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///N. Disposizione
	///</summary>
	public Int32? idpaydisposition{ 
		get {if (this["idpaydisposition"]==DBNull.Value)return null; return  (Int32?)this["idpaydisposition"];}
		set {if (value==null) this["idpaydisposition"]= DBNull.Value; else this["idpaydisposition"]= value;}
	}
	public object idpaydispositionValue { 
		get{ return this["idpaydisposition"];}
		set {if (value==null|| value==DBNull.Value) this["idpaydisposition"]= DBNull.Value; else this["idpaydisposition"]= value;}
	}
	public Int32? idpaydispositionOriginal { 
		get {if (this["idpaydisposition",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpaydisposition",DataRowVersion.Original];}
	}
	///<summary>
	///n. dettaglio
	///</summary>
	public Int32? iddetail{ 
		get {if (this["iddetail"]==DBNull.Value)return null; return  (Int32?)this["iddetail"];}
		set {if (value==null) this["iddetail"]= DBNull.Value; else this["iddetail"]= value;}
	}
	public object iddetailValue { 
		get{ return this["iddetail"];}
		set {if (value==null|| value==DBNull.Value) this["iddetail"]= DBNull.Value; else this["iddetail"]= value;}
	}
	public Int32? iddetailOriginal { 
		get {if (this["iddetail",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddetail",DataRowVersion.Original];}
	}
	///<summary>
	///Cognome
	///</summary>
	public String surname{ 
		get {if (this["surname"]==DBNull.Value)return null; return  (String)this["surname"];}
		set {if (value==null) this["surname"]= DBNull.Value; else this["surname"]= value;}
	}
	public object surnameValue { 
		get{ return this["surname"];}
		set {if (value==null|| value==DBNull.Value) this["surname"]= DBNull.Value; else this["surname"]= value;}
	}
	public String surnameOriginal { 
		get {if (this["surname",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["surname",DataRowVersion.Original];}
	}
	///<summary>
	///Nome
	///</summary>
	public String forename{ 
		get {if (this["forename"]==DBNull.Value)return null; return  (String)this["forename"];}
		set {if (value==null) this["forename"]= DBNull.Value; else this["forename"]= value;}
	}
	public object forenameValue { 
		get{ return this["forename"];}
		set {if (value==null|| value==DBNull.Value) this["forename"]= DBNull.Value; else this["forename"]= value;}
	}
	public String forenameOriginal { 
		get {if (this["forename",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forename",DataRowVersion.Original];}
	}
	///<summary>
	///genere M/F
	///	 F: Femmina
	///	 M: maschio
	///</summary>
	public String gender{ 
		get {if (this["gender"]==DBNull.Value)return null; return  (String)this["gender"];}
		set {if (value==null) this["gender"]= DBNull.Value; else this["gender"]= value;}
	}
	public object genderValue { 
		get{ return this["gender"];}
		set {if (value==null|| value==DBNull.Value) this["gender"]= DBNull.Value; else this["gender"]= value;}
	}
	public String genderOriginal { 
		get {if (this["gender",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["gender",DataRowVersion.Original];}
	}
	///<summary>
	///data di nascita
	///</summary>
	public DateTime? birthdate{ 
		get {if (this["birthdate"]==DBNull.Value)return null; return  (DateTime?)this["birthdate"];}
		set {if (value==null) this["birthdate"]= DBNull.Value; else this["birthdate"]= value;}
	}
	public object birthdateValue { 
		get{ return this["birthdate"];}
		set {if (value==null|| value==DBNull.Value) this["birthdate"]= DBNull.Value; else this["birthdate"]= value;}
	}
	public DateTime? birthdateOriginal { 
		get {if (this["birthdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["birthdate",DataRowVersion.Original];}
	}
	///<summary>
	///id città (tabella geo_city)
	///</summary>
	public Int32? idcity{ 
		get {if (this["idcity"]==DBNull.Value)return null; return  (Int32?)this["idcity"];}
		set {if (value==null) this["idcity"]= DBNull.Value; else this["idcity"]= value;}
	}
	public object idcityValue { 
		get{ return this["idcity"];}
		set {if (value==null|| value==DBNull.Value) this["idcity"]= DBNull.Value; else this["idcity"]= value;}
	}
	public Int32? idcityOriginal { 
		get {if (this["idcity",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcity",DataRowVersion.Original];}
	}
	///<summary>
	///Id nazione (tabella geo_nation)
	///</summary>
	public Int32? idnation{ 
		get {if (this["idnation"]==DBNull.Value)return null; return  (Int32?)this["idnation"];}
		set {if (value==null) this["idnation"]= DBNull.Value; else this["idnation"]= value;}
	}
	public object idnationValue { 
		get{ return this["idnation"];}
		set {if (value==null|| value==DBNull.Value) this["idnation"]= DBNull.Value; else this["idnation"]= value;}
	}
	public Int32? idnationOriginal { 
		get {if (this["idnation",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idnation",DataRowVersion.Original];}
	}
	///<summary>
	///Codice fiscale
	///</summary>
	public String cf{ 
		get {if (this["cf"]==DBNull.Value)return null; return  (String)this["cf"];}
		set {if (value==null) this["cf"]= DBNull.Value; else this["cf"]= value;}
	}
	public object cfValue { 
		get{ return this["cf"];}
		set {if (value==null|| value==DBNull.Value) this["cf"]= DBNull.Value; else this["cf"]= value;}
	}
	public String cfOriginal { 
		get {if (this["cf",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cf",DataRowVersion.Original];}
	}
	///<summary>
	///n. operazione
	///</summary>
	public String address{ 
		get {if (this["address"]==DBNull.Value)return null; return  (String)this["address"];}
		set {if (value==null) this["address"]= DBNull.Value; else this["address"]= value;}
	}
	public object addressValue { 
		get{ return this["address"];}
		set {if (value==null|| value==DBNull.Value) this["address"]= DBNull.Value; else this["address"]= value;}
	}
	public String addressOriginal { 
		get {if (this["address",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["address",DataRowVersion.Original];}
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
	///provincia
	///</summary>
	public String province{ 
		get {if (this["province"]==DBNull.Value)return null; return  (String)this["province"];}
		set {if (value==null) this["province"]= DBNull.Value; else this["province"]= value;}
	}
	public object provinceValue { 
		get{ return this["province"];}
		set {if (value==null|| value==DBNull.Value) this["province"]= DBNull.Value; else this["province"]= value;}
	}
	public String provinceOriginal { 
		get {if (this["province",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["province",DataRowVersion.Original];}
	}
	///<summary>
	///Codice avv. postale
	///</summary>
	public String cap{ 
		get {if (this["cap"]==DBNull.Value)return null; return  (String)this["cap"];}
		set {if (value==null) this["cap"]= DBNull.Value; else this["cap"]= value;}
	}
	public object capValue { 
		get{ return this["cap"];}
		set {if (value==null|| value==DBNull.Value) this["cap"]= DBNull.Value; else this["cap"]= value;}
	}
	public String capOriginal { 
		get {if (this["cap",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cap",DataRowVersion.Original];}
	}
	///<summary>
	///codice abi
	///</summary>
	public String abi{ 
		get {if (this["abi"]==DBNull.Value)return null; return  (String)this["abi"];}
		set {if (value==null) this["abi"]= DBNull.Value; else this["abi"]= value;}
	}
	public object abiValue { 
		get{ return this["abi"];}
		set {if (value==null|| value==DBNull.Value) this["abi"]= DBNull.Value; else this["abi"]= value;}
	}
	public String abiOriginal { 
		get {if (this["abi",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["abi",DataRowVersion.Original];}
	}
	///<summary>
	///codice CAB
	///</summary>
	public String cab{ 
		get {if (this["cab"]==DBNull.Value)return null; return  (String)this["cab"];}
		set {if (value==null) this["cab"]= DBNull.Value; else this["cab"]= value;}
	}
	public object cabValue { 
		get{ return this["cab"];}
		set {if (value==null|| value==DBNull.Value) this["cab"]= DBNull.Value; else this["cab"]= value;}
	}
	public String cabOriginal { 
		get {if (this["cab",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cab",DataRowVersion.Original];}
	}
	///<summary>
	///Causale (descrizione)
	///</summary>
	public String motive{ 
		get {if (this["motive"]==DBNull.Value)return null; return  (String)this["motive"];}
		set {if (value==null) this["motive"]= DBNull.Value; else this["motive"]= value;}
	}
	public object motiveValue { 
		get{ return this["motive"];}
		set {if (value==null|| value==DBNull.Value) this["motive"]= DBNull.Value; else this["motive"]= value;}
	}
	public String motiveOriginal { 
		get {if (this["motive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["motive",DataRowVersion.Original];}
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
	///Email
	///</summary>
	public String email{ 
		get {if (this["email"]==DBNull.Value)return null; return  (String)this["email"];}
		set {if (value==null) this["email"]= DBNull.Value; else this["email"]= value;}
	}
	public object emailValue { 
		get{ return this["email"];}
		set {if (value==null|| value==DBNull.Value) this["email"]= DBNull.Value; else this["email"]= value;}
	}
	public String emailOriginal { 
		get {if (this["email",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["email",DataRowVersion.Original];}
	}
	///<summary>
	///ID Causale CBI (tabella cbimotive)
	///</summary>
	public Int32? idcbimotive{ 
		get {if (this["idcbimotive"]==DBNull.Value)return null; return  (Int32?)this["idcbimotive"];}
		set {if (value==null) this["idcbimotive"]= DBNull.Value; else this["idcbimotive"]= value;}
	}
	public object idcbimotiveValue { 
		get{ return this["idcbimotive"];}
		set {if (value==null|| value==DBNull.Value) this["idcbimotive"]= DBNull.Value; else this["idcbimotive"]= value;}
	}
	public Int32? idcbimotiveOriginal { 
		get {if (this["idcbimotive",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcbimotive",DataRowVersion.Original];}
	}
	///<summary>
	///conto corrente
	///</summary>
	public String cc{ 
		get {if (this["cc"]==DBNull.Value)return null; return  (String)this["cc"];}
		set {if (value==null) this["cc"]= DBNull.Value; else this["cc"]= value;}
	}
	public object ccValue { 
		get{ return this["cc"];}
		set {if (value==null|| value==DBNull.Value) this["cc"]= DBNull.Value; else this["cc"]= value;}
	}
	public String ccOriginal { 
		get {if (this["cc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cc",DataRowVersion.Original];}
	}
	///<summary>
	///CIN della mod. pagamento
	///</summary>
	public String cin{ 
		get {if (this["cin"]==DBNull.Value)return null; return  (String)this["cin"];}
		set {if (value==null) this["cin"]= DBNull.Value; else this["cin"]= value;}
	}
	public object cinValue { 
		get{ return this["cin"];}
		set {if (value==null|| value==DBNull.Value) this["cin"]= DBNull.Value; else this["cin"]= value;}
	}
	public String cinOriginal { 
		get {if (this["cin",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cin",DataRowVersion.Original];}
	}
	///<summary>
	///IBAN
	///</summary>
	public String iban{ 
		get {if (this["iban"]==DBNull.Value)return null; return  (String)this["iban"];}
		set {if (value==null) this["iban"]= DBNull.Value; else this["iban"]= value;}
	}
	public object ibanValue { 
		get{ return this["iban"];}
		set {if (value==null|| value==DBNull.Value) this["iban"]= DBNull.Value; else this["iban"]= value;}
	}
	public String ibanOriginal { 
		get {if (this["iban",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["iban",DataRowVersion.Original];}
	}
	///<summary>
	///Persona fisica
	///	 N: Non persona fisica
	///	 S: Persona fisica
	///</summary>
	public String flaghuman{ 
		get {if (this["flaghuman"]==DBNull.Value)return null; return  (String)this["flaghuman"];}
		set {if (value==null) this["flaghuman"]= DBNull.Value; else this["flaghuman"]= value;}
	}
	public object flaghumanValue { 
		get{ return this["flaghuman"];}
		set {if (value==null|| value==DBNull.Value) this["flaghuman"]= DBNull.Value; else this["flaghuman"]= value;}
	}
	public String flaghumanOriginal { 
		get {if (this["flaghuman",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flaghuman",DataRowVersion.Original];}
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
	///Partita IVA
	///</summary>
	public String p_iva{ 
		get {if (this["p_iva"]==DBNull.Value)return null; return  (String)this["p_iva"];}
		set {if (value==null) this["p_iva"]= DBNull.Value; else this["p_iva"]= value;}
	}
	public object p_ivaValue { 
		get{ return this["p_iva"];}
		set {if (value==null|| value==DBNull.Value) this["p_iva"]= DBNull.Value; else this["p_iva"]= value;}
	}
	public String p_ivaOriginal { 
		get {if (this["p_iva",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["p_iva",DataRowVersion.Original];}
	}
	///<summary>
	///Cod. Pagamento
	///</summary>
	public String paymentcode{ 
		get {if (this["paymentcode"]==DBNull.Value)return null; return  (String)this["paymentcode"];}
		set {if (value==null) this["paymentcode"]= DBNull.Value; else this["paymentcode"]= value;}
	}
	public object paymentcodeValue { 
		get{ return this["paymentcode"];}
		set {if (value==null|| value==DBNull.Value) this["paymentcode"]= DBNull.Value; else this["paymentcode"]= value;}
	}
	public String paymentcodeOriginal { 
		get {if (this["paymentcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["paymentcode",DataRowVersion.Original];}
	}
	///<summary>
	///Codice Pagamento
	///</summary>
	public Int32? paymethodcode{ 
		get {if (this["paymethodcode"]==DBNull.Value)return null; return  (Int32?)this["paymethodcode"];}
		set {if (value==null) this["paymethodcode"]= DBNull.Value; else this["paymethodcode"]= value;}
	}
	public object paymethodcodeValue { 
		get{ return this["paymethodcode"];}
		set {if (value==null|| value==DBNull.Value) this["paymethodcode"]= DBNull.Value; else this["paymethodcode"]= value;}
	}
	public Int32? paymethodcodeOriginal { 
		get {if (this["paymethodcode",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["paymethodcode",DataRowVersion.Original];}
	}
	///<summary>
	///anno accademico a cui si riferiscono le spese
	///</summary>
	public Int32? academicyear{ 
		get {if (this["academicyear"]==DBNull.Value)return null; return  (Int32?)this["academicyear"];}
		set {if (value==null) this["academicyear"]= DBNull.Value; else this["academicyear"]= value;}
	}
	public object academicyearValue { 
		get{ return this["academicyear"];}
		set {if (value==null|| value==DBNull.Value) this["academicyear"]= DBNull.Value; else this["academicyear"]= value;}
	}
	public Int32? academicyearOriginal { 
		get {if (this["academicyear",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["academicyear",DataRowVersion.Original];}
	}
	///<summary>
	///tipologia del corso
	///	 1: laurea
	///	 2: laurea magistrale
	///	 3: laurea vecchio ordinamento
	///	 4: master I livello
	///	 5: master II livello
	///	 6: dottorato
	///	 7: scuola specializzazione
	///	 8: corsi di perfezionamento
	///</summary>
	public String degreekind{ 
		get {if (this["degreekind"]==DBNull.Value)return null; return  (String)this["degreekind"];}
		set {if (value==null) this["degreekind"]= DBNull.Value; else this["degreekind"]= value;}
	}
	public object degreekindValue { 
		get{ return this["degreekind"];}
		set {if (value==null|| value==DBNull.Value) this["degreekind"]= DBNull.Value; else this["degreekind"]= value;}
	}
	public String degreekindOriginal { 
		get {if (this["degreekind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["degreekind",DataRowVersion.Original];}
	}
	///<summary>
	///codice corso universitario
	///</summary>
	public String degreecode{ 
		get {if (this["degreecode"]==DBNull.Value)return null; return  (String)this["degreecode"];}
		set {if (value==null) this["degreecode"]= DBNull.Value; else this["degreecode"]= value;}
	}
	public object degreecodeValue { 
		get{ return this["degreecode"];}
		set {if (value==null|| value==DBNull.Value) this["degreecode"]= DBNull.Value; else this["degreecode"]= value;}
	}
	public String degreecodeOriginal { 
		get {if (this["degreecode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["degreecode",DataRowVersion.Original];}
	}
	///<summary>
	///Rimborso Tasse
	///	 N: Non è vero che: "Rimborso Tasse"
	///	 S: Rimborso Tasse
	///</summary>
	public String flagtaxrefund{ 
		get {if (this["flagtaxrefund"]==DBNull.Value)return null; return  (String)this["flagtaxrefund"];}
		set {if (value==null) this["flagtaxrefund"]= DBNull.Value; else this["flagtaxrefund"]= value;}
	}
	public object flagtaxrefundValue { 
		get{ return this["flagtaxrefund"];}
		set {if (value==null|| value==DBNull.Value) this["flagtaxrefund"]= DBNull.Value; else this["flagtaxrefund"]= value;}
	}
	public String flagtaxrefundOriginal { 
		get {if (this["flagtaxrefund",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagtaxrefund",DataRowVersion.Original];}
	}
	///<summary>
	///anno solare in cui è stata sostenuta la spesa rimborsata
	///</summary>
	public Int32? calendaryear{ 
		get {if (this["calendaryear"]==DBNull.Value)return null; return  (Int32?)this["calendaryear"];}
		set {if (value==null) this["calendaryear"]= DBNull.Value; else this["calendaryear"]= value;}
	}
	public object calendaryearValue { 
		get{ return this["calendaryear"];}
		set {if (value==null|| value==DBNull.Value) this["calendaryear"]= DBNull.Value; else this["calendaryear"]= value;}
	}
	public Int32? calendaryearOriginal { 
		get {if (this["calendaryear",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["calendaryear",DataRowVersion.Original];}
	}
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
	#endregion

}
///<summary>
///Disposizione di Pagamento - Dettaglio
///</summary>
public class paydispositiondetailTable : MetaTableBase<paydispositiondetailRow> {
	public paydispositiondetailTable() : base("paydispositiondetail"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idpaydisposition",createColumn("idpaydisposition",typeof(int),false,false)},
			{"iddetail",createColumn("iddetail",typeof(int),false,false)},
			{"surname",createColumn("surname",typeof(string),true,false)},
			{"forename",createColumn("forename",typeof(string),true,false)},
			{"gender",createColumn("gender",typeof(string),true,false)},
			{"birthdate",createColumn("birthdate",typeof(DateTime),true,false)},
			{"idcity",createColumn("idcity",typeof(int),true,false)},
			{"idnation",createColumn("idnation",typeof(int),true,false)},
			{"cf",createColumn("cf",typeof(string),true,false)},
			{"address",createColumn("address",typeof(string),true,false)},
			{"location",createColumn("location",typeof(string),true,false)},
			{"province",createColumn("province",typeof(string),true,false)},
			{"cap",createColumn("cap",typeof(string),true,false)},
			{"abi",createColumn("abi",typeof(string),true,false)},
			{"cab",createColumn("cab",typeof(string),true,false)},
			{"motive",createColumn("motive",typeof(string),true,false)},
			{"amount",createColumn("amount",typeof(decimal),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"email",createColumn("email",typeof(string),true,false)},
			{"idcbimotive",createColumn("idcbimotive",typeof(int),true,false)},
			{"cc",createColumn("cc",typeof(string),true,false)},
			{"cin",createColumn("cin",typeof(string),true,false)},
			{"iban",createColumn("iban",typeof(string),true,false)},
			{"flaghuman",createColumn("flaghuman",typeof(string),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
			{"p_iva",createColumn("p_iva",typeof(string),true,false)},
			{"paymentcode",createColumn("paymentcode",typeof(string),true,false)},
			{"paymethodcode",createColumn("paymethodcode",typeof(int),true,false)},
			{"academicyear",createColumn("academicyear",typeof(int),true,false)},
			{"degreekind",createColumn("degreekind",typeof(string),true,false)},
			{"degreecode",createColumn("degreecode",typeof(string),true,false)},
			{"flagtaxrefund",createColumn("flagtaxrefund",typeof(string),true,false)},
			{"calendaryear",createColumn("calendaryear",typeof(int),true,false)},
			{"idexp",createColumn("idexp",typeof(int),true,false)},
		};
	}
}
}
