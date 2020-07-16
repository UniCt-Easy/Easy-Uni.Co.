/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
namespace meta_registryclass {
public class registryclassRow: MetaRow  {
	public registryclassRow(DataRowBuilder rb) : base(rb) {} 

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
	///Codice badge visibile
	///	 N: Codice badge non visibile
	///	 S: Codice badge visibile
	///</summary>
	public String flagbadgecode{ 
		get {if (this["flagbadgecode"]==DBNull.Value)return null; return  (String)this["flagbadgecode"];}
		set {if (value==null) this["flagbadgecode"]= DBNull.Value; else this["flagbadgecode"]= value;}
	}
	public object flagbadgecodeValue { 
		get{ return this["flagbadgecode"];}
		set {if (value==null|| value==DBNull.Value) this["flagbadgecode"]= DBNull.Value; else this["flagbadgecode"]= value;}
	}
	public String flagbadgecodeOriginal { 
		get {if (this["flagbadgecode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagbadgecode",DataRowVersion.Original];}
	}
	///<summary>
	///Codice badge obbligatorio
	///	 N: Codice badge non obbligatorio
	///	 S: Codice badge obbligatorio
	///</summary>
	public String flagbadgecode_forced{ 
		get {if (this["flagbadgecode_forced"]==DBNull.Value)return null; return  (String)this["flagbadgecode_forced"];}
		set {if (value==null) this["flagbadgecode_forced"]= DBNull.Value; else this["flagbadgecode_forced"]= value;}
	}
	public object flagbadgecode_forcedValue { 
		get{ return this["flagbadgecode_forced"];}
		set {if (value==null|| value==DBNull.Value) this["flagbadgecode_forced"]= DBNull.Value; else this["flagbadgecode_forced"]= value;}
	}
	public String flagbadgecode_forcedOriginal { 
		get {if (this["flagbadgecode_forced",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagbadgecode_forced",DataRowVersion.Original];}
	}
	///<summary>
	///Codice fiscale visibile
	///	 N: Codice fiscale non visibile
	///	 S: Codice fiscale visibile
	///</summary>
	public String flagCF{ 
		get {if (this["flagCF"]==DBNull.Value)return null; return  (String)this["flagCF"];}
		set {if (value==null) this["flagCF"]= DBNull.Value; else this["flagCF"]= value;}
	}
	public object flagCFValue { 
		get{ return this["flagCF"];}
		set {if (value==null|| value==DBNull.Value) this["flagCF"]= DBNull.Value; else this["flagCF"]= value;}
	}
	public String flagCFOriginal { 
		get {if (this["flagCF",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagCF",DataRowVersion.Original];}
	}
	///<summary>
	///Codice fiscale obbligatorio
	///	 N: Codice fiscale non obbligatorio
	///	 S: Codice fiscale obbligatorio
	///</summary>
	public String flagcf_forced{ 
		get {if (this["flagcf_forced"]==DBNull.Value)return null; return  (String)this["flagcf_forced"];}
		set {if (value==null) this["flagcf_forced"]= DBNull.Value; else this["flagcf_forced"]= value;}
	}
	public object flagcf_forcedValue { 
		get{ return this["flagcf_forced"];}
		set {if (value==null|| value==DBNull.Value) this["flagcf_forced"]= DBNull.Value; else this["flagcf_forced"]= value;}
	}
	public String flagcf_forcedOriginal { 
		get {if (this["flagcf_forced",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagcf_forced",DataRowVersion.Original];}
	}
	///<summary>
	///Bottone "calcola codice fiscale" visibile
	///	 N: Bottone "calcola codice fiscale" nascosto
	///	 S: Bottone "calcola codice fiscale" visibile
	///</summary>
	public String flagcfbutton{ 
		get {if (this["flagcfbutton"]==DBNull.Value)return null; return  (String)this["flagcfbutton"];}
		set {if (value==null) this["flagcfbutton"]= DBNull.Value; else this["flagcfbutton"]= value;}
	}
	public object flagcfbuttonValue { 
		get{ return this["flagcfbutton"];}
		set {if (value==null|| value==DBNull.Value) this["flagcfbutton"]= DBNull.Value; else this["flagcfbutton"]= value;}
	}
	public String flagcfbuttonOriginal { 
		get {if (this["flagcfbutton",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagcfbutton",DataRowVersion.Original];}
	}
	///<summary>
	///Matricola esterna visibile
	///	 N: Matricola esterna nascosta
	///	 S: Matricola esterna visibile
	///</summary>
	public String flagextmatricula{ 
		get {if (this["flagextmatricula"]==DBNull.Value)return null; return  (String)this["flagextmatricula"];}
		set {if (value==null) this["flagextmatricula"]= DBNull.Value; else this["flagextmatricula"]= value;}
	}
	public object flagextmatriculaValue { 
		get{ return this["flagextmatricula"];}
		set {if (value==null|| value==DBNull.Value) this["flagextmatricula"]= DBNull.Value; else this["flagextmatricula"]= value;}
	}
	public String flagextmatriculaOriginal { 
		get {if (this["flagextmatricula",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagextmatricula",DataRowVersion.Original];}
	}
	///<summary>
	///Matricola esterna obbligatoria
	///	 N: Matricola esterna non obbligatoria
	///	 S: Matricola esterna obbligatoria
	///</summary>
	public String flagextmatricula_forced{ 
		get {if (this["flagextmatricula_forced"]==DBNull.Value)return null; return  (String)this["flagextmatricula_forced"];}
		set {if (value==null) this["flagextmatricula_forced"]= DBNull.Value; else this["flagextmatricula_forced"]= value;}
	}
	public object flagextmatricula_forcedValue { 
		get{ return this["flagextmatricula_forced"];}
		set {if (value==null|| value==DBNull.Value) this["flagextmatricula_forced"]= DBNull.Value; else this["flagextmatricula_forced"]= value;}
	}
	public String flagextmatricula_forcedOriginal { 
		get {if (this["flagextmatricula_forced",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagextmatricula_forced",DataRowVersion.Original];}
	}
	///<summary>
	///Campo residenza visibile
	///	 N: Campo residenza non visibile
	///	 S: Campo residenza visibile
	///</summary>
	public String flagfiscalresidence{ 
		get {if (this["flagfiscalresidence"]==DBNull.Value)return null; return  (String)this["flagfiscalresidence"];}
		set {if (value==null) this["flagfiscalresidence"]= DBNull.Value; else this["flagfiscalresidence"]= value;}
	}
	public object flagfiscalresidenceValue { 
		get{ return this["flagfiscalresidence"];}
		set {if (value==null|| value==DBNull.Value) this["flagfiscalresidence"]= DBNull.Value; else this["flagfiscalresidence"]= value;}
	}
	public String flagfiscalresidenceOriginal { 
		get {if (this["flagfiscalresidence",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagfiscalresidence",DataRowVersion.Original];}
	}
	///<summary>
	///inserimento residenza obbligatorio
	///	 N: Inserimento residenza non obbligatorio
	///	 S: inserimento residenza obbligatorio
	///</summary>
	public String flagfiscalresidence_forced{ 
		get {if (this["flagfiscalresidence_forced"]==DBNull.Value)return null; return  (String)this["flagfiscalresidence_forced"];}
		set {if (value==null) this["flagfiscalresidence_forced"]= DBNull.Value; else this["flagfiscalresidence_forced"]= value;}
	}
	public object flagfiscalresidence_forcedValue { 
		get{ return this["flagfiscalresidence_forced"];}
		set {if (value==null|| value==DBNull.Value) this["flagfiscalresidence_forced"]= DBNull.Value; else this["flagfiscalresidence_forced"]= value;}
	}
	public String flagfiscalresidence_forcedOriginal { 
		get {if (this["flagfiscalresidence_forced",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagfiscalresidence_forced",DataRowVersion.Original];}
	}
	///<summary>
	///Codice fiscale estero visibile
	///	 N: Codice fiscale estero non visibile
	///	 S: Codice fiscale estero visibile
	///</summary>
	public String flagforeigncf{ 
		get {if (this["flagforeigncf"]==DBNull.Value)return null; return  (String)this["flagforeigncf"];}
		set {if (value==null) this["flagforeigncf"]= DBNull.Value; else this["flagforeigncf"]= value;}
	}
	public object flagforeigncfValue { 
		get{ return this["flagforeigncf"];}
		set {if (value==null|| value==DBNull.Value) this["flagforeigncf"]= DBNull.Value; else this["flagforeigncf"]= value;}
	}
	public String flagforeigncfOriginal { 
		get {if (this["flagforeigncf",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagforeigncf",DataRowVersion.Original];}
	}
	///<summary>
	///Codice fiscale estero obbligatorio
	///	 N: Codice fiscale estero non obbligatorio
	///	 S: Codice fiscale estero obbligatorio
	///</summary>
	public String flagforeigncf_forced{ 
		get {if (this["flagforeigncf_forced"]==DBNull.Value)return null; return  (String)this["flagforeigncf_forced"];}
		set {if (value==null) this["flagforeigncf_forced"]= DBNull.Value; else this["flagforeigncf_forced"]= value;}
	}
	public object flagforeigncf_forcedValue { 
		get{ return this["flagforeigncf_forced"];}
		set {if (value==null|| value==DBNull.Value) this["flagforeigncf_forced"]= DBNull.Value; else this["flagforeigncf_forced"]= value;}
	}
	public String flagforeigncf_forcedOriginal { 
		get {if (this["flagforeigncf_forced",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagforeigncf_forced",DataRowVersion.Original];}
	}
	///<summary>
	///Persona fisica
	///	 N: Non è Persona fisica
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
	///Bottone "Comune, Data da C.F." visibile
	///	 N: Bottone "Comune, Data da C.F. non visibile
	///	 S: Bottone "Comune, Data da C.F." visibile
	///</summary>
	public String flaginfofromcfbutton{ 
		get {if (this["flaginfofromcfbutton"]==DBNull.Value)return null; return  (String)this["flaginfofromcfbutton"];}
		set {if (value==null) this["flaginfofromcfbutton"]= DBNull.Value; else this["flaginfofromcfbutton"]= value;}
	}
	public object flaginfofromcfbuttonValue { 
		get{ return this["flaginfofromcfbutton"];}
		set {if (value==null|| value==DBNull.Value) this["flaginfofromcfbutton"]= DBNull.Value; else this["flaginfofromcfbutton"]= value;}
	}
	public String flaginfofromcfbuttonOriginal { 
		get {if (this["flaginfofromcfbutton",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flaginfofromcfbutton",DataRowVersion.Original];}
	}
	///<summary>
	///Campo stato civile visibile
	///	 N: Campo stato civile non visibile
	///	 S: Campo stato civile visibile
	///</summary>
	public String flagmaritalstatus{ 
		get {if (this["flagmaritalstatus"]==DBNull.Value)return null; return  (String)this["flagmaritalstatus"];}
		set {if (value==null) this["flagmaritalstatus"]= DBNull.Value; else this["flagmaritalstatus"]= value;}
	}
	public object flagmaritalstatusValue { 
		get{ return this["flagmaritalstatus"];}
		set {if (value==null|| value==DBNull.Value) this["flagmaritalstatus"]= DBNull.Value; else this["flagmaritalstatus"]= value;}
	}
	public String flagmaritalstatusOriginal { 
		get {if (this["flagmaritalstatus",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagmaritalstatus",DataRowVersion.Original];}
	}
	///<summary>
	///Campo stato civile obbligatorio
	///	 N: Campo stato civile non obbligatorio
	///	 S: Campo stato civile obbligatorio
	///</summary>
	public String flagmaritalstatus_forced{ 
		get {if (this["flagmaritalstatus_forced"]==DBNull.Value)return null; return  (String)this["flagmaritalstatus_forced"];}
		set {if (value==null) this["flagmaritalstatus_forced"]= DBNull.Value; else this["flagmaritalstatus_forced"]= value;}
	}
	public object flagmaritalstatus_forcedValue { 
		get{ return this["flagmaritalstatus_forced"];}
		set {if (value==null|| value==DBNull.Value) this["flagmaritalstatus_forced"]= DBNull.Value; else this["flagmaritalstatus_forced"]= value;}
	}
	public String flagmaritalstatus_forcedOriginal { 
		get {if (this["flagmaritalstatus_forced",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagmaritalstatus_forced",DataRowVersion.Original];}
	}
	///<summary>
	///Cognome acquisito visibile
	///	 N: Cognome acquisito non visibile
	///	 S: Cognome acquisito visibile
	///</summary>
	public String flagmaritalsurname{ 
		get {if (this["flagmaritalsurname"]==DBNull.Value)return null; return  (String)this["flagmaritalsurname"];}
		set {if (value==null) this["flagmaritalsurname"]= DBNull.Value; else this["flagmaritalsurname"]= value;}
	}
	public object flagmaritalsurnameValue { 
		get{ return this["flagmaritalsurname"];}
		set {if (value==null|| value==DBNull.Value) this["flagmaritalsurname"]= DBNull.Value; else this["flagmaritalsurname"]= value;}
	}
	public String flagmaritalsurnameOriginal { 
		get {if (this["flagmaritalsurname",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagmaritalsurname",DataRowVersion.Original];}
	}
	///<summary>
	///Cognome acquisito obbligatorio
	///	 N: Cognome acquisito non obbligatorio
	///	 S: Cognome acquisito obbligatorio
	///</summary>
	public String flagmaritalsurname_forced{ 
		get {if (this["flagmaritalsurname_forced"]==DBNull.Value)return null; return  (String)this["flagmaritalsurname_forced"];}
		set {if (value==null) this["flagmaritalsurname_forced"]= DBNull.Value; else this["flagmaritalsurname_forced"]= value;}
	}
	public object flagmaritalsurname_forcedValue { 
		get{ return this["flagmaritalsurname_forced"];}
		set {if (value==null|| value==DBNull.Value) this["flagmaritalsurname_forced"]= DBNull.Value; else this["flagmaritalsurname_forced"]= value;}
	}
	public String flagmaritalsurname_forcedOriginal { 
		get {if (this["flagmaritalsurname_forced",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagmaritalsurname_forced",DataRowVersion.Original];}
	}
	///<summary>
	///campo non usato
	///</summary>
	public String flagothers{ 
		get {if (this["flagothers"]==DBNull.Value)return null; return  (String)this["flagothers"];}
		set {if (value==null) this["flagothers"]= DBNull.Value; else this["flagothers"]= value;}
	}
	public object flagothersValue { 
		get{ return this["flagothers"];}
		set {if (value==null|| value==DBNull.Value) this["flagothers"]= DBNull.Value; else this["flagothers"]= value;}
	}
	public String flagothersOriginal { 
		get {if (this["flagothers",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagothers",DataRowVersion.Original];}
	}
	///<summary>
	///campo non usato
	///</summary>
	public String flagothers_forced{ 
		get {if (this["flagothers_forced"]==DBNull.Value)return null; return  (String)this["flagothers_forced"];}
		set {if (value==null) this["flagothers_forced"]= DBNull.Value; else this["flagothers_forced"]= value;}
	}
	public object flagothers_forcedValue { 
		get{ return this["flagothers_forced"];}
		set {if (value==null|| value==DBNull.Value) this["flagothers_forced"]= DBNull.Value; else this["flagothers_forced"]= value;}
	}
	public String flagothers_forcedOriginal { 
		get {if (this["flagothers_forced",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagothers_forced",DataRowVersion.Original];}
	}
	///<summary>
	///Partita iva visibile
	///	 N: Partita iva non visibile
	///	 S: Partita iva visibile
	///</summary>
	public String flagp_iva{ 
		get {if (this["flagp_iva"]==DBNull.Value)return null; return  (String)this["flagp_iva"];}
		set {if (value==null) this["flagp_iva"]= DBNull.Value; else this["flagp_iva"]= value;}
	}
	public object flagp_ivaValue { 
		get{ return this["flagp_iva"];}
		set {if (value==null|| value==DBNull.Value) this["flagp_iva"]= DBNull.Value; else this["flagp_iva"]= value;}
	}
	public String flagp_ivaOriginal { 
		get {if (this["flagp_iva",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagp_iva",DataRowVersion.Original];}
	}
	///<summary>
	///Partita iva obbligatoria
	///	 N: Partita iva non obbligatoria
	///	 S: Partita iva obbligatoria
	///</summary>
	public String flagp_iva_forced{ 
		get {if (this["flagp_iva_forced"]==DBNull.Value)return null; return  (String)this["flagp_iva_forced"];}
		set {if (value==null) this["flagp_iva_forced"]= DBNull.Value; else this["flagp_iva_forced"]= value;}
	}
	public object flagp_iva_forcedValue { 
		get{ return this["flagp_iva_forced"];}
		set {if (value==null|| value==DBNull.Value) this["flagp_iva_forced"]= DBNull.Value; else this["flagp_iva_forced"]= value;}
	}
	public String flagp_iva_forcedOriginal { 
		get {if (this["flagp_iva_forced",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagp_iva_forced",DataRowVersion.Original];}
	}
	///<summary>
	///campo "Titolo" visibile
	///	 N: campo "Titolo" non visibile
	///	 S: campo "Titolo" visibile
	///</summary>
	public String flagqualification{ 
		get {if (this["flagqualification"]==DBNull.Value)return null; return  (String)this["flagqualification"];}
		set {if (value==null) this["flagqualification"]= DBNull.Value; else this["flagqualification"]= value;}
	}
	public object flagqualificationValue { 
		get{ return this["flagqualification"];}
		set {if (value==null|| value==DBNull.Value) this["flagqualification"]= DBNull.Value; else this["flagqualification"]= value;}
	}
	public String flagqualificationOriginal { 
		get {if (this["flagqualification",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagqualification",DataRowVersion.Original];}
	}
	///<summary>
	///campo "Titolo" obbligatorio
	///	 N: campo "Titolo" non obbligatorio
	///	 S: campo "Titolo" obbligatorio
	///</summary>
	public String flagqualification_forced{ 
		get {if (this["flagqualification_forced"]==DBNull.Value)return null; return  (String)this["flagqualification_forced"];}
		set {if (value==null) this["flagqualification_forced"]= DBNull.Value; else this["flagqualification_forced"]= value;}
	}
	public object flagqualification_forcedValue { 
		get{ return this["flagqualification_forced"];}
		set {if (value==null|| value==DBNull.Value) this["flagqualification_forced"]= DBNull.Value; else this["flagqualification_forced"]= value;}
	}
	public String flagqualification_forcedOriginal { 
		get {if (this["flagqualification_forced",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagqualification_forced",DataRowVersion.Original];}
	}
	///<summary>
	///Usato congiuntamente a flagresidence_forced per stabilire se l'indirizzo di residenza è obbligatorio, Da solo non ha un gran significato poiché non esiste un campo indirizzo di residenza
	///	 N: Nascondi informazioni su residenza
	///	 S: Informazioni sulla residenza visibili
	///</summary>
	public String flagresidence{ 
		get {if (this["flagresidence"]==DBNull.Value)return null; return  (String)this["flagresidence"];}
		set {if (value==null) this["flagresidence"]= DBNull.Value; else this["flagresidence"]= value;}
	}
	public object flagresidenceValue { 
		get{ return this["flagresidence"];}
		set {if (value==null|| value==DBNull.Value) this["flagresidence"]= DBNull.Value; else this["flagresidence"]= value;}
	}
	public String flagresidenceOriginal { 
		get {if (this["flagresidence",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagresidence",DataRowVersion.Original];}
	}
	///<summary>
	///Informazioni sulla residenza obbligatorie
	///	 N: Informazioni sulla residenza non obbligatorie
	///	 S: Informazioni sulla residenza obbligatorie
	///</summary>
	public String flagresidence_forced{ 
		get {if (this["flagresidence_forced"]==DBNull.Value)return null; return  (String)this["flagresidence_forced"];}
		set {if (value==null) this["flagresidence_forced"]= DBNull.Value; else this["flagresidence_forced"]= value;}
	}
	public object flagresidence_forcedValue { 
		get{ return this["flagresidence_forced"];}
		set {if (value==null|| value==DBNull.Value) this["flagresidence_forced"]= DBNull.Value; else this["flagresidence_forced"]= value;}
	}
	public String flagresidence_forcedOriginal { 
		get {if (this["flagresidence_forced",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagresidence_forced",DataRowVersion.Original];}
	}
	///<summary>
	///Campo Denominazione diverso da cognome+nome, inserito manualmente
	///	 N: Campo Denominazione uguale a cognome+nome, inserito in automatico
	///	 S: Campo Denominazione diverso da cognome+nome, inserito manualmente
	///</summary>
	public String flagtitle{ 
		get {if (this["flagtitle"]==DBNull.Value)return null; return  (String)this["flagtitle"];}
		set {if (value==null) this["flagtitle"]= DBNull.Value; else this["flagtitle"]= value;}
	}
	public object flagtitleValue { 
		get{ return this["flagtitle"];}
		set {if (value==null|| value==DBNull.Value) this["flagtitle"]= DBNull.Value; else this["flagtitle"]= value;}
	}
	public String flagtitleOriginal { 
		get {if (this["flagtitle",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagtitle",DataRowVersion.Original];}
	}
	///<summary>
	///Non usato, il campo denominazione  è sempre obbligatorio in un modo o nell'altro
	///</summary>
	public String flagtitle_forced{ 
		get {if (this["flagtitle_forced"]==DBNull.Value)return null; return  (String)this["flagtitle_forced"];}
		set {if (value==null) this["flagtitle_forced"]= DBNull.Value; else this["flagtitle_forced"]= value;}
	}
	public object flagtitle_forcedValue { 
		get{ return this["flagtitle_forced"];}
		set {if (value==null|| value==DBNull.Value) this["flagtitle_forced"]= DBNull.Value; else this["flagtitle_forced"]= value;}
	}
	public String flagtitle_forcedOriginal { 
		get {if (this["flagtitle_forced",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagtitle_forced",DataRowVersion.Original];}
	}
	///<summary>
	///Codice
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
	#endregion

}
///<summary>
///Tipologie classificazione
///</summary>
public class registryclassTable : MetaTableBase<registryclassRow> {
	public registryclassTable() : base("registryclass"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"active",createColumn("active",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"flagbadgecode",createColumn("flagbadgecode",typeof(string),false,false)},
			{"flagbadgecode_forced",createColumn("flagbadgecode_forced",typeof(string),false,false)},
			{"flagCF",createColumn("flagCF",typeof(string),false,false)},
			{"flagcf_forced",createColumn("flagcf_forced",typeof(string),false,false)},
			{"flagcfbutton",createColumn("flagcfbutton",typeof(string),true,false)},
			{"flagextmatricula",createColumn("flagextmatricula",typeof(string),false,false)},
			{"flagextmatricula_forced",createColumn("flagextmatricula_forced",typeof(string),false,false)},
			{"flagfiscalresidence",createColumn("flagfiscalresidence",typeof(string),false,false)},
			{"flagfiscalresidence_forced",createColumn("flagfiscalresidence_forced",typeof(string),false,false)},
			{"flagforeigncf",createColumn("flagforeigncf",typeof(string),false,false)},
			{"flagforeigncf_forced",createColumn("flagforeigncf_forced",typeof(string),false,false)},
			{"flaghuman",createColumn("flaghuman",typeof(string),true,false)},
			{"flaginfofromcfbutton",createColumn("flaginfofromcfbutton",typeof(string),true,false)},
			{"flagmaritalstatus",createColumn("flagmaritalstatus",typeof(string),false,false)},
			{"flagmaritalstatus_forced",createColumn("flagmaritalstatus_forced",typeof(string),false,false)},
			{"flagmaritalsurname",createColumn("flagmaritalsurname",typeof(string),false,false)},
			{"flagmaritalsurname_forced",createColumn("flagmaritalsurname_forced",typeof(string),false,false)},
			{"flagothers",createColumn("flagothers",typeof(string),false,false)},
			{"flagothers_forced",createColumn("flagothers_forced",typeof(string),false,false)},
			{"flagp_iva",createColumn("flagp_iva",typeof(string),false,false)},
			{"flagp_iva_forced",createColumn("flagp_iva_forced",typeof(string),false,false)},
			{"flagqualification",createColumn("flagqualification",typeof(string),false,false)},
			{"flagqualification_forced",createColumn("flagqualification_forced",typeof(string),false,false)},
			{"flagresidence",createColumn("flagresidence",typeof(string),false,false)},
			{"flagresidence_forced",createColumn("flagresidence_forced",typeof(string),false,false)},
			{"flagtitle",createColumn("flagtitle",typeof(string),false,false)},
			{"flagtitle_forced",createColumn("flagtitle_forced",typeof(string),false,false)},
			{"idregistryclass",createColumn("idregistryclass",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
		};
	}
}
}
