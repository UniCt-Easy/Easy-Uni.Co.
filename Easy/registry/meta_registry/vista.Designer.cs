
/*
Easy
Copyright (C) 2021 Universit‡ degli Studi di Catania (www.unict.it)
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
namespace meta_registry {
public class registryRow: MetaRow  {
	public registryRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///attivo
	///</summary>
	public String active{ 
		get {return  (String)this["active"];}
		set {this["active"]= value;}
	}
	public object activeValue { 
		get{ return this["active"];}
		set {this["active"]= value;}
	}
	public String activeOriginal { 
		get {return  (String)this["active",DataRowVersion.Original];}
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
	///Codice badge
	///</summary>
	public String badgecode{ 
		get {if (this["badgecode"]==DBNull.Value)return null; return  (String)this["badgecode"];}
		set {if (value==null) this["badgecode"]= DBNull.Value; else this["badgecode"]= value;}
	}
	public object badgecodeValue { 
		get{ return this["badgecode"];}
		set {if (value==null|| value==DBNull.Value) this["badgecode"]= DBNull.Value; else this["badgecode"]= value;}
	}
	public String badgecodeOriginal { 
		get {if (this["badgecode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["badgecode",DataRowVersion.Original];}
	}
	///<summary>
	///Data di nascita
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
	///Matricola
	///</summary>
	public String extmatricula{ 
		get {if (this["extmatricula"]==DBNull.Value)return null; return  (String)this["extmatricula"];}
		set {if (value==null) this["extmatricula"]= DBNull.Value; else this["extmatricula"]= value;}
	}
	public object extmatriculaValue { 
		get{ return this["extmatricula"];}
		set {if (value==null|| value==DBNull.Value) this["extmatricula"]= DBNull.Value; else this["extmatricula"]= value;}
	}
	public String extmatriculaOriginal { 
		get {if (this["extmatricula",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["extmatricula",DataRowVersion.Original];}
	}
	///<summary>
	///Codice fiscale estero
	///</summary>
	public String foreigncf{ 
		get {if (this["foreigncf"]==DBNull.Value)return null; return  (String)this["foreigncf"];}
		set {if (value==null) this["foreigncf"]= DBNull.Value; else this["foreigncf"]= value;}
	}
	public object foreigncfValue { 
		get{ return this["foreigncf"];}
		set {if (value==null|| value==DBNull.Value) this["foreigncf"]= DBNull.Value; else this["foreigncf"]= value;}
	}
	public String foreigncfOriginal { 
		get {if (this["foreigncf",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["foreigncf",DataRowVersion.Original];}
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
	///Sesso (M/F)
	///	 F: Femmina
	///	 M: Maschio
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
	///ID Categoria (tabella category)
	///</summary>
	public String idcategory{ 
		get {if (this["idcategory"]==DBNull.Value)return null; return  (String)this["idcategory"];}
		set {if (value==null) this["idcategory"]= DBNull.Value; else this["idcategory"]= value;}
	}
	public object idcategoryValue { 
		get{ return this["idcategory"];}
		set {if (value==null|| value==DBNull.Value) this["idcategory"]= DBNull.Value; else this["idcategory"]= value;}
	}
	public String idcategoryOriginal { 
		get {if (this["idcategory",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idcategory",DataRowVersion.Original];}
	}
	///<summary>
	///ID Classificazione centralizzata anagrafica (tabella centralizedcategory)
	///</summary>
	public String idcentralizedcategory{ 
		get {if (this["idcentralizedcategory"]==DBNull.Value)return null; return  (String)this["idcentralizedcategory"];}
		set {if (value==null) this["idcentralizedcategory"]= DBNull.Value; else this["idcentralizedcategory"]= value;}
	}
	public object idcentralizedcategoryValue { 
		get{ return this["idcentralizedcategory"];}
		set {if (value==null|| value==DBNull.Value) this["idcentralizedcategory"]= DBNull.Value; else this["idcentralizedcategory"]= value;}
	}
	public String idcentralizedcategoryOriginal { 
		get {if (this["idcentralizedcategory",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idcentralizedcategory",DataRowVersion.Original];}
	}
	///<summary>
	///id citt√† (tabella geo_city)
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
	///ID Stato civile (tabella maritalstatus)
	///</summary>
	public String idmaritalstatus{ 
		get {if (this["idmaritalstatus"]==DBNull.Value)return null; return  (String)this["idmaritalstatus"];}
		set {if (value==null) this["idmaritalstatus"]= DBNull.Value; else this["idmaritalstatus"]= value;}
	}
	public object idmaritalstatusValue { 
		get{ return this["idmaritalstatus"];}
		set {if (value==null|| value==DBNull.Value) this["idmaritalstatus"]= DBNull.Value; else this["idmaritalstatus"]= value;}
	}
	public String idmaritalstatusOriginal { 
		get {if (this["idmaritalstatus",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idmaritalstatus",DataRowVersion.Original];}
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
	///ID Tipologie classificazione (tabella registryclass)
	///</summary>
	public String idregistryclass{ 
		get {if (this["idregistryclass"]==DBNull.Value)return null; return  (String)this["idregistryclass"];}
		set {if (value==null) this["idregistryclass"]= DBNull.Value; else this["idregistryclass"]= value;}
	}
	public object idregistryclassValue { 
		get{ return this["idregistryclass"];}
		set {if (value==null|| value==DBNull.Value) this["idregistryclass"]= DBNull.Value; else this["idregistryclass"]= value;}
	}
	public String idregistryclassOriginal { 
		get {if (this["idregistryclass",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idregistryclass",DataRowVersion.Original];}
	}
	///<summary>
	///ID Titolo (tabella title)
	///</summary>
	public String idtitle{ 
		get {if (this["idtitle"]==DBNull.Value)return null; return  (String)this["idtitle"];}
		set {if (value==null) this["idtitle"]= DBNull.Value; else this["idtitle"]= value;}
	}
	public object idtitleValue { 
		get{ return this["idtitle"];}
		set {if (value==null|| value==DBNull.Value) this["idtitle"]= DBNull.Value; else this["idtitle"]= value;}
	}
	public String idtitleOriginal { 
		get {if (this["idtitle",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idtitle",DataRowVersion.Original];}
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
	///Cognome acquisito
	///</summary>
	public String maritalsurname{ 
		get {if (this["maritalsurname"]==DBNull.Value)return null; return  (String)this["maritalsurname"];}
		set {if (value==null) this["maritalsurname"]= DBNull.Value; else this["maritalsurname"]= value;}
	}
	public object maritalsurnameValue { 
		get{ return this["maritalsurname"];}
		set {if (value==null|| value==DBNull.Value) this["maritalsurname"]= DBNull.Value; else this["maritalsurname"]= value;}
	}
	public String maritalsurnameOriginal { 
		get {if (this["maritalsurname",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["maritalsurname",DataRowVersion.Original];}
	}
	///<summary>
	///Partita iva
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
	///Denominazione
	///</summary>
	public String title{ 
		get {return  (String)this["title"];}
		set {this["title"]= value;}
	}
	public object titleValue { 
		get{ return this["title"];}
		set {this["title"]= value;}
	}
	public String titleOriginal { 
		get {return  (String)this["title",DataRowVersion.Original];}
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
	///Tipo residenza (chiave di tabella residence)
	///	 1: Residente in Italia (coderesidence I)
	///	 2: Residente in altri paesi dell'UE (coderesidence J)
	///	 3: Trasferimenti interni (code residence U)
	///	 4: Residente fuori dall'UE (coderesidence X)
	///</summary>
	public Int32 residence{ 
		get {return  (Int32)this["residence"];}
		set {this["residence"]= value;}
	}
	public object residenceValue { 
		get{ return this["residence"];}
		set {this["residence"]= value;}
	}
	public Int32 residenceOriginal { 
		get {return  (Int32)this["residence",DataRowVersion.Original];}
	}
	///<summary>
	///ID Classificazione Anagrafica (tabella registrykind)
	///</summary>
	public Int32? idregistrykind{ 
		get {if (this["idregistrykind"]==DBNull.Value)return null; return  (Int32?)this["idregistrykind"];}
		set {if (value==null) this["idregistrykind"]= DBNull.Value; else this["idregistrykind"]= value;}
	}
	public object idregistrykindValue { 
		get{ return this["idregistrykind"];}
		set {if (value==null|| value==DBNull.Value) this["idregistrykind"]= DBNull.Value; else this["idregistrykind"]= value;}
	}
	public Int32? idregistrykindOriginal { 
		get {if (this["idregistrykind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idregistrykind",DataRowVersion.Original];}
	}
	///<summary>
	///Esente ai fini dell'autorizzazione EQUITALIA. (S/N)
	///	 N: Non esente ai fini dell'autorizzazione EQUITALIA.
	///	 S: Esente ai fini dell'autorizzazione EQUITALIA.
	///</summary>
	public String authorization_free{ 
		get {if (this["authorization_free"]==DBNull.Value)return null; return  (String)this["authorization_free"];}
		set {if (value==null) this["authorization_free"]= DBNull.Value; else this["authorization_free"]= value;}
	}
	public object authorization_freeValue { 
		get{ return this["authorization_free"];}
		set {if (value==null|| value==DBNull.Value) this["authorization_free"]= DBNull.Value; else this["authorization_free"]= value;}
	}
	public String authorization_freeOriginal { 
		get {if (this["authorization_free",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["authorization_free",DataRowVersion.Original];}
	}
	///<summary>
	///Consenti duplicazione CF/P. IVA (S/N)
	///	 N: Non consentire duplicazione cf/p.iva (la norma)
	///	 S: Consenti duplicazione CF/P. IVA
	///</summary>
	public String multi_cf{ 
		get {if (this["multi_cf"]==DBNull.Value)return null; return  (String)this["multi_cf"];}
		set {if (value==null) this["multi_cf"]= DBNull.Value; else this["multi_cf"]= value;}
	}
	public object multi_cfValue { 
		get{ return this["multi_cf"];}
		set {if (value==null|| value==DBNull.Value) this["multi_cf"]= DBNull.Value; else this["multi_cf"]= value;}
	}
	public String multi_cfOriginal { 
		get {if (this["multi_cf",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["multi_cf",DataRowVersion.Original];}
	}
	///<summary>
	///E' stato usato in qualche migrazione
	///</summary>
	public Int32? toredirect{ 
		get {if (this["toredirect"]==DBNull.Value)return null; return  (Int32?)this["toredirect"];}
		set {if (value==null) this["toredirect"]= DBNull.Value; else this["toredirect"]= value;}
	}
	public object toredirectValue { 
		get{ return this["toredirect"];}
		set {if (value==null|| value==DBNull.Value) this["toredirect"]= DBNull.Value; else this["toredirect"]= value;}
	}
	public Int32? toredirectOriginal { 
		get {if (this["toredirect",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["toredirect",DataRowVersion.Original];}
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
	///ID Causale per i crediti (tabella accmotive)
	///</summary>
	public String idaccmotivecredit{ 
		get {if (this["idaccmotivecredit"]==DBNull.Value)return null; return  (String)this["idaccmotivecredit"];}
		set {if (value==null) this["idaccmotivecredit"]= DBNull.Value; else this["idaccmotivecredit"]= value;}
	}
	public object idaccmotivecreditValue { 
		get{ return this["idaccmotivecredit"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotivecredit"]= DBNull.Value; else this["idaccmotivecredit"]= value;}
	}
	public String idaccmotivecreditOriginal { 
		get {if (this["idaccmotivecredit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotivecredit",DataRowVersion.Original];}
	}
	///<summary>
	///Conto corrente postale di Riscossione
	///</summary>
	public String ccp{ 
		get {if (this["ccp"]==DBNull.Value)return null; return  (String)this["ccp"];}
		set {if (value==null) this["ccp"]= DBNull.Value; else this["ccp"]= value;}
	}
	public object ccpValue { 
		get{ return this["ccp"];}
		set {if (value==null|| value==DBNull.Value) this["ccp"]= DBNull.Value; else this["ccp"]= value;}
	}
	public String ccpOriginal { 
		get {if (this["ccp",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ccp",DataRowVersion.Original];}
	}
	///<summary>
	///Regolarizzazione Riscossioni presso  T.P.S. - Banca d'Italia
	///	 N: La regolarizzazione delle riscossioni avviene norm
	///	 S: Regolarizzazione riscoss. presso Banca d'Italia
	///</summary>
	public String flagbankitaliaproceeds{ 
		get {if (this["flagbankitaliaproceeds"]==DBNull.Value)return null; return  (String)this["flagbankitaliaproceeds"];}
		set {if (value==null) this["flagbankitaliaproceeds"]= DBNull.Value; else this["flagbankitaliaproceeds"]= value;}
	}
	public object flagbankitaliaproceedsValue { 
		get{ return this["flagbankitaliaproceeds"];}
		set {if (value==null|| value==DBNull.Value) this["flagbankitaliaproceeds"]= DBNull.Value; else this["flagbankitaliaproceeds"]= value;}
	}
	public String flagbankitaliaproceedsOriginal { 
		get {if (this["flagbankitaliaproceeds",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagbankitaliaproceeds",DataRowVersion.Original];}
	}
	///<summary>
	///Id chiave in altri database, usato in migrazioni o simili
	///</summary>
	public Int32? idexternal{ 
		get {if (this["idexternal"]==DBNull.Value)return null; return  (Int32?)this["idexternal"];}
		set {if (value==null) this["idexternal"]= DBNull.Value; else this["idexternal"]= value;}
	}
	public object idexternalValue { 
		get{ return this["idexternal"];}
		set {if (value==null|| value==DBNull.Value) this["idexternal"]= DBNull.Value; else this["idexternal"]= value;}
	}
	public Int32? idexternalOriginal { 
		get {if (this["idexternal",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idexternal",DataRowVersion.Original];}
	}
	///<summary>
	///Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.
	///</summary>
	public String ipa_fe{ 
		get {if (this["ipa_fe"]==DBNull.Value)return null; return  (String)this["ipa_fe"];}
		set {if (value==null) this["ipa_fe"]= DBNull.Value; else this["ipa_fe"]= value;}
	}
	public object ipa_feValue { 
		get{ return this["ipa_fe"];}
		set {if (value==null|| value==DBNull.Value) this["ipa_fe"]= DBNull.Value; else this["ipa_fe"]= value;}
	}
	public String ipa_feOriginal { 
		get {if (this["ipa_fe",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ipa_fe",DataRowVersion.Original];}
	}
	///<summary>
	///Applica lo split payment  (per le fatture di vendita)
	///	 N: Non applicare lo split payment  (per le fatture di vendita)
	///	 S: Applica lo split payment  (per le fatture di vendita)
	///</summary>
	public String flag_pa{ 
		get {if (this["flag_pa"]==DBNull.Value)return null; return  (String)this["flag_pa"];}
		set {if (value==null) this["flag_pa"]= DBNull.Value; else this["flag_pa"]= value;}
	}
	public object flag_paValue { 
		get{ return this["flag_pa"];}
		set {if (value==null|| value==DBNull.Value) this["flag_pa"]= DBNull.Value; else this["flag_pa"]= value;}
	}
	public String flag_paOriginal { 
		get {if (this["flag_pa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flag_pa",DataRowVersion.Original];}
	}
	///<summary>
	///Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica
	///</summary>
	public String sdi_norifamm{ 
		get {if (this["sdi_norifamm"]==DBNull.Value)return null; return  (String)this["sdi_norifamm"];}
		set {if (value==null) this["sdi_norifamm"]= DBNull.Value; else this["sdi_norifamm"]= value;}
	}
	public object sdi_norifammValue { 
		get{ return this["sdi_norifamm"];}
		set {if (value==null|| value==DBNull.Value) this["sdi_norifamm"]= DBNull.Value; else this["sdi_norifamm"]= value;}
	}
	public String sdi_norifammOriginal { 
		get {if (this["sdi_norifamm",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["sdi_norifamm",DataRowVersion.Original];}
	}
	///<summary>
	///Rif.Amministrazione di default per fattura elettronica
	///</summary>
	public String sdi_defrifamm{ 
		get {if (this["sdi_defrifamm"]==DBNull.Value)return null; return  (String)this["sdi_defrifamm"];}
		set {if (value==null) this["sdi_defrifamm"]= DBNull.Value; else this["sdi_defrifamm"]= value;}
	}
	public object sdi_defrifammValue { 
		get{ return this["sdi_defrifamm"];}
		set {if (value==null|| value==DBNull.Value) this["sdi_defrifamm"]= DBNull.Value; else this["sdi_defrifamm"]= value;}
	}
	public String sdi_defrifammOriginal { 
		get {if (this["sdi_defrifamm",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["sdi_defrifamm",DataRowVersion.Original];}
	}
	public String pec_fe{ 
		get {if (this["pec_fe"]==DBNull.Value)return null; return  (String)this["pec_fe"];}
		set {if (value==null) this["pec_fe"]= DBNull.Value; else this["pec_fe"]= value;}
	}
	public object pec_feValue { 
		get{ return this["pec_fe"];}
		set {if (value==null|| value==DBNull.Value) this["pec_fe"]= DBNull.Value; else this["pec_fe"]= value;}
	}
	public String pec_feOriginal { 
		get {if (this["pec_fe",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["pec_fe",DataRowVersion.Original];}
	}
	///<summary>
	///tabella che estende il record
	///</summary>
	public String extension{ 
		get {if (this["extension"]==DBNull.Value)return null; return  (String)this["extension"];}
		set {if (value==null) this["extension"]= DBNull.Value; else this["extension"]= value;}
	}
	public object extensionValue { 
		get{ return this["extension"];}
		set {if (value==null|| value==DBNull.Value) this["extension"]= DBNull.Value; else this["extension"]= value;}
	}
	public String extensionOriginal { 
		get {if (this["extension",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["extension",DataRowVersion.Original];}
	}
	public String email_fe{ 
		get {if (this["email_fe"]==DBNull.Value)return null; return  (String)this["email_fe"];}
		set {if (value==null) this["email_fe"]= DBNull.Value; else this["email_fe"]= value;}
	}
	public object email_feValue { 
		get{ return this["email_fe"];}
		set {if (value==null|| value==DBNull.Value) this["email_fe"]= DBNull.Value; else this["email_fe"]= value;}
	}
	public String email_feOriginal { 
		get {if (this["email_fe",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["email_fe",DataRowVersion.Original];}
	}
	public String ipa_perlapa{ 
		get {if (this["ipa_perlapa"]==DBNull.Value)return null; return  (String)this["ipa_perlapa"];}
		set {if (value==null) this["ipa_perlapa"]= DBNull.Value; else this["ipa_perlapa"]= value;}
	}
	public object ipa_perlapaValue { 
		get{ return this["ipa_perlapa"];}
		set {if (value==null|| value==DBNull.Value) this["ipa_perlapa"]= DBNull.Value; else this["ipa_perlapa"]= value;}
	}
	public String ipa_perlapaOriginal { 
		get {if (this["ipa_perlapa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ipa_perlapa",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Anagrafica
///</summary>
public class registryTable : MetaTableBase<registryRow> {
	public registryTable() : base("registry"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idreg",createColumn("idreg",typeof(int),false,false)},
			{"active",createColumn("active",typeof(string),false,false)},
			{"annotation",createColumn("annotation",typeof(string),true,false)},
			{"badgecode",createColumn("badgecode",typeof(string),true,false)},
			{"birthdate",createColumn("birthdate",typeof(DateTime),true,false)},
			{"cf",createColumn("cf",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"extmatricula",createColumn("extmatricula",typeof(string),true,false)},
			{"foreigncf",createColumn("foreigncf",typeof(string),true,false)},
			{"forename",createColumn("forename",typeof(string),true,false)},
			{"gender",createColumn("gender",typeof(string),true,false)},
			{"idcategory",createColumn("idcategory",typeof(string),true,false)},
			{"idcentralizedcategory",createColumn("idcentralizedcategory",typeof(string),true,false)},
			{"idcity",createColumn("idcity",typeof(int),true,false)},
			{"idmaritalstatus",createColumn("idmaritalstatus",typeof(string),true,false)},
			{"idnation",createColumn("idnation",typeof(int),true,false)},
			{"idregistryclass",createColumn("idregistryclass",typeof(string),true,false)},
			{"idtitle",createColumn("idtitle",typeof(string),true,false)},
			{"location",createColumn("location",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"maritalsurname",createColumn("maritalsurname",typeof(string),true,false)},
			{"p_iva",createColumn("p_iva",typeof(string),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"surname",createColumn("surname",typeof(string),true,false)},
			{"title",createColumn("title",typeof(string),false,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"residence",createColumn("residence",typeof(int),false,false)},
			{"idregistrykind",createColumn("idregistrykind",typeof(int),true,false)},
			{"authorization_free",createColumn("authorization_free",typeof(string),true,false)},
			{"multi_cf",createColumn("multi_cf",typeof(string),true,false)},
			{"toredirect",createColumn("toredirect",typeof(int),true,false)},
			{"idaccmotivedebit",createColumn("idaccmotivedebit",typeof(string),true,false)},
			{"idaccmotivecredit",createColumn("idaccmotivecredit",typeof(string),true,false)},
			{"ccp",createColumn("ccp",typeof(string),true,false)},
			{"flagbankitaliaproceeds",createColumn("flagbankitaliaproceeds",typeof(string),true,false)},
			{"idexternal",createColumn("idexternal",typeof(int),true,false)},
			{"ipa_fe",createColumn("ipa_fe",typeof(string),true,false)},
			{"flag_pa",createColumn("flag_pa",typeof(string),true,false)},
			{"sdi_norifamm",createColumn("sdi_norifamm",typeof(string),true,false)},
			{"sdi_defrifamm",createColumn("sdi_defrifamm",typeof(string),true,false)},
			{"pec_fe",createColumn("pec_fe",typeof(string),true,false)},
			{"extension",createColumn("extension",typeof(string),true,false)},
			{"email_fe",createColumn("email_fe",typeof(string),true,false)},
			{"ipa_perlapa",createColumn("ipa_perlapa",typeof(string),true,false)},
		};
	}
}
}
