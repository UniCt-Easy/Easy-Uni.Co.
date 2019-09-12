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
namespace meta_treasurer {
public class treasurerRow: MetaRow  {
	public treasurerRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///Dati Esportazione Elettronica - codice ente
	///</summary>
	public String agencycodefortransmission{ 
		get {if (this["agencycodefortransmission"]==DBNull.Value)return null; return  (String)this["agencycodefortransmission"];}
		set {if (value==null) this["agencycodefortransmission"]= DBNull.Value; else this["agencycodefortransmission"]= value;}
	}
	public object agencycodefortransmissionValue { 
		get{ return this["agencycodefortransmission"];}
		set {if (value==null|| value==DBNull.Value) this["agencycodefortransmission"]= DBNull.Value; else this["agencycodefortransmission"]= value;}
	}
	public String agencycodefortransmissionOriginal { 
		get {if (this["agencycodefortransmission",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["agencycodefortransmission",DataRowVersion.Original];}
	}
	///<summary>
	///Dati Esportazione Elettronica - Codice filiale
	///</summary>
	public String cabcodefortransmission{ 
		get {if (this["cabcodefortransmission"]==DBNull.Value)return null; return  (String)this["cabcodefortransmission"];}
		set {if (value==null) this["cabcodefortransmission"]= DBNull.Value; else this["cabcodefortransmission"]= value;}
	}
	public object cabcodefortransmissionValue { 
		get{ return this["cabcodefortransmission"];}
		set {if (value==null|| value==DBNull.Value) this["cabcodefortransmission"]= DBNull.Value; else this["cabcodefortransmission"]= value;}
	}
	public String cabcodefortransmissionOriginal { 
		get {if (this["cabcodefortransmission",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cabcodefortransmission",DataRowVersion.Original];}
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
	///Nome città
	///</summary>
	public String city{ 
		get {if (this["city"]==DBNull.Value)return null; return  (String)this["city"];}
		set {if (value==null) this["city"]= DBNull.Value; else this["city"]= value;}
	}
	public object cityValue { 
		get{ return this["city"];}
		set {if (value==null|| value==DBNull.Value) this["city"]= DBNull.Value; else this["city"]= value;}
	}
	public String cityOriginal { 
		get {if (this["city",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["city",DataRowVersion.Original];}
	}
	///<summary>
	///Paese
	///</summary>
	public String country{ 
		get {if (this["country"]==DBNull.Value)return null; return  (String)this["country"];}
		set {if (value==null) this["country"]= DBNull.Value; else this["country"]= value;}
	}
	public object countryValue { 
		get{ return this["country"];}
		set {if (value==null|| value==DBNull.Value) this["country"]= DBNull.Value; else this["country"]= value;}
	}
	public String countryOriginal { 
		get {if (this["country",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["country",DataRowVersion.Original];}
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
	///Dati Esportazione Elettronica - Codice istituto
	///</summary>
	public String depcodefortransmission{ 
		get {if (this["depcodefortransmission"]==DBNull.Value)return null; return  (String)this["depcodefortransmission"];}
		set {if (value==null) this["depcodefortransmission"]= DBNull.Value; else this["depcodefortransmission"]= value;}
	}
	public object depcodefortransmissionValue { 
		get{ return this["depcodefortransmission"];}
		set {if (value==null|| value==DBNull.Value) this["depcodefortransmission"]= DBNull.Value; else this["depcodefortransmission"]= value;}
	}
	public String depcodefortransmissionOriginal { 
		get {if (this["depcodefortransmission",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["depcodefortransmission",DataRowVersion.Original];}
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
	///Numero fax
	///</summary>
	public String faxnumber{ 
		get {if (this["faxnumber"]==DBNull.Value)return null; return  (String)this["faxnumber"];}
		set {if (value==null) this["faxnumber"]= DBNull.Value; else this["faxnumber"]= value;}
	}
	public object faxnumberValue { 
		get{ return this["faxnumber"];}
		set {if (value==null|| value==DBNull.Value) this["faxnumber"]= DBNull.Value; else this["faxnumber"]= value;}
	}
	public String faxnumberOriginal { 
		get {if (this["faxnumber",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["faxnumber",DataRowVersion.Original];}
	}
	///<summary>
	///Prefisso fax
	///</summary>
	public String faxprefix{ 
		get {if (this["faxprefix"]==DBNull.Value)return null; return  (String)this["faxprefix"];}
		set {if (value==null) this["faxprefix"]= DBNull.Value; else this["faxprefix"]= value;}
	}
	public object faxprefixValue { 
		get{ return this["faxprefix"];}
		set {if (value==null|| value==DBNull.Value) this["faxprefix"]= DBNull.Value; else this["faxprefix"]= value;}
	}
	public String faxprefixOriginal { 
		get {if (this["faxprefix",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["faxprefix",DataRowVersion.Original];}
	}
	///<summary>
	///Cassiere predefinito
	///	 N: Non è cassiere predefinito
	///	 S: Cassiere predefinito
	///</summary>
	public String flagdefault{ 
		get {if (this["flagdefault"]==DBNull.Value)return null; return  (String)this["flagdefault"];}
		set {if (value==null) this["flagdefault"]= DBNull.Value; else this["flagdefault"]= value;}
	}
	public object flagdefaultValue { 
		get{ return this["flagdefault"];}
		set {if (value==null|| value==DBNull.Value) this["flagdefault"]= DBNull.Value; else this["flagdefault"]= value;}
	}
	public String flagdefaultOriginal { 
		get {if (this["flagdefault",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagdefault",DataRowVersion.Original];}
	}
	///<summary>
	///causale banca per pagamenti
	///</summary>
	public String idaccmotive_payment{ 
		get {if (this["idaccmotive_payment"]==DBNull.Value)return null; return  (String)this["idaccmotive_payment"];}
		set {if (value==null) this["idaccmotive_payment"]= DBNull.Value; else this["idaccmotive_payment"]= value;}
	}
	public object idaccmotive_paymentValue { 
		get{ return this["idaccmotive_payment"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive_payment"]= DBNull.Value; else this["idaccmotive_payment"]= value;}
	}
	public String idaccmotive_paymentOriginal { 
		get {if (this["idaccmotive_payment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive_payment",DataRowVersion.Original];}
	}
	///<summary>
	///causale banca per incasi
	///</summary>
	public String idaccmotive_proceeds{ 
		get {if (this["idaccmotive_proceeds"]==DBNull.Value)return null; return  (String)this["idaccmotive_proceeds"];}
		set {if (value==null) this["idaccmotive_proceeds"]= DBNull.Value; else this["idaccmotive_proceeds"]= value;}
	}
	public object idaccmotive_proceedsValue { 
		get{ return this["idaccmotive_proceeds"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive_proceeds"]= DBNull.Value; else this["idaccmotive_proceeds"]= value;}
	}
	public String idaccmotive_proceedsOriginal { 
		get {if (this["idaccmotive_proceeds",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive_proceeds",DataRowVersion.Original];}
	}
	///<summary>
	///ABI
	///</summary>
	public String idbank{ 
		get {if (this["idbank"]==DBNull.Value)return null; return  (String)this["idbank"];}
		set {if (value==null) this["idbank"]= DBNull.Value; else this["idbank"]= value;}
	}
	public object idbankValue { 
		get{ return this["idbank"];}
		set {if (value==null|| value==DBNull.Value) this["idbank"]= DBNull.Value; else this["idbank"]= value;}
	}
	public String idbankOriginal { 
		get {if (this["idbank",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idbank",DataRowVersion.Original];}
	}
	///<summary>
	///CAB
	///</summary>
	public String idcab{ 
		get {if (this["idcab"]==DBNull.Value)return null; return  (String)this["idcab"];}
		set {if (value==null) this["idcab"]= DBNull.Value; else this["idcab"]= value;}
	}
	public object idcabValue { 
		get{ return this["idcab"];}
		set {if (value==null|| value==DBNull.Value) this["idcab"]= DBNull.Value; else this["idcab"]= value;}
	}
	public String idcabOriginal { 
		get {if (this["idcab",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idcab",DataRowVersion.Original];}
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
	///Numero tel.
	///</summary>
	public String phonenumber{ 
		get {if (this["phonenumber"]==DBNull.Value)return null; return  (String)this["phonenumber"];}
		set {if (value==null) this["phonenumber"]= DBNull.Value; else this["phonenumber"]= value;}
	}
	public object phonenumberValue { 
		get{ return this["phonenumber"];}
		set {if (value==null|| value==DBNull.Value) this["phonenumber"]= DBNull.Value; else this["phonenumber"]= value;}
	}
	public String phonenumberOriginal { 
		get {if (this["phonenumber",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["phonenumber",DataRowVersion.Original];}
	}
	///<summary>
	///Prefisso tel.
	///</summary>
	public String phoneprefix{ 
		get {if (this["phoneprefix"]==DBNull.Value)return null; return  (String)this["phoneprefix"];}
		set {if (value==null) this["phoneprefix"]= DBNull.Value; else this["phoneprefix"]= value;}
	}
	public object phoneprefixValue { 
		get{ return this["phoneprefix"];}
		set {if (value==null|| value==DBNull.Value) this["phoneprefix"]= DBNull.Value; else this["phoneprefix"]= value;}
	}
	public String phoneprefixOriginal { 
		get {if (this["phoneprefix",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["phoneprefix",DataRowVersion.Original];}
	}
	///<summary>
	///Cod. Cassiere
	///</summary>
	public String codetreasurer{ 
		get {if (this["codetreasurer"]==DBNull.Value)return null; return  (String)this["codetreasurer"];}
		set {if (value==null) this["codetreasurer"]= DBNull.Value; else this["codetreasurer"]= value;}
	}
	public object codetreasurerValue { 
		get{ return this["codetreasurer"];}
		set {if (value==null|| value==DBNull.Value) this["codetreasurer"]= DBNull.Value; else this["codetreasurer"]= value;}
	}
	public String codetreasurerOriginal { 
		get {if (this["codetreasurer",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codetreasurer",DataRowVersion.Original];}
	}
	///<summary>
	///Id cassiere (tabella treasurer)
	///</summary>
	public Int32? idtreasurer{ 
		get {if (this["idtreasurer"]==DBNull.Value)return null; return  (Int32?)this["idtreasurer"];}
		set {if (value==null) this["idtreasurer"]= DBNull.Value; else this["idtreasurer"]= value;}
	}
	public object idtreasurerValue { 
		get{ return this["idtreasurer"];}
		set {if (value==null|| value==DBNull.Value) this["idtreasurer"]= DBNull.Value; else this["idtreasurer"]= value;}
	}
	public Int32? idtreasurerOriginal { 
		get {if (this["idtreasurer",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idtreasurer",DataRowVersion.Original];}
	}
	///<summary>
	///SP Esporta Mandati
	///</summary>
	public String spexportexp{ 
		get {if (this["spexportexp"]==DBNull.Value)return null; return  (String)this["spexportexp"];}
		set {if (value==null) this["spexportexp"]= DBNull.Value; else this["spexportexp"]= value;}
	}
	public object spexportexpValue { 
		get{ return this["spexportexp"];}
		set {if (value==null|| value==DBNull.Value) this["spexportexp"]= DBNull.Value; else this["spexportexp"]= value;}
	}
	public String spexportexpOriginal { 
		get {if (this["spexportexp",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["spexportexp",DataRowVersion.Original];}
	}
	///<summary>
	///Trasmissione contemporanea su più distinte
	///	 N: Non prevede trasmissione contemporanea su più distinte
	///	 S: Trasmissione contemporanea su più distinte
	///</summary>
	public String flagmultiexp{ 
		get {if (this["flagmultiexp"]==DBNull.Value)return null; return  (String)this["flagmultiexp"];}
		set {if (value==null) this["flagmultiexp"]= DBNull.Value; else this["flagmultiexp"]= value;}
	}
	public object flagmultiexpValue { 
		get{ return this["flagmultiexp"];}
		set {if (value==null|| value==DBNull.Value) this["flagmultiexp"]= DBNull.Value; else this["flagmultiexp"]= value;}
	}
	public String flagmultiexpOriginal { 
		get {if (this["flagmultiexp",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagmultiexp",DataRowVersion.Original];}
	}
	///<summary>
	///Estensione del file (cfg. trasmissione)
	///</summary>
	public String fileextension{ 
		get {if (this["fileextension"]==DBNull.Value)return null; return  (String)this["fileextension"];}
		set {if (value==null) this["fileextension"]= DBNull.Value; else this["fileextension"]= value;}
	}
	public object fileextensionValue { 
		get{ return this["fileextension"];}
		set {if (value==null|| value==DBNull.Value) this["fileextension"]= DBNull.Value; else this["fileextension"]= value;}
	}
	public String fileextensionOriginal { 
		get {if (this["fileextension",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["fileextension",DataRowVersion.Original];}
	}
	///<summary>
	///SP Esporta Reversali
	///</summary>
	public String spexportinc{ 
		get {if (this["spexportinc"]==DBNull.Value)return null; return  (String)this["spexportinc"];}
		set {if (value==null) this["spexportinc"]= DBNull.Value; else this["spexportinc"]= value;}
	}
	public object spexportincValue { 
		get{ return this["spexportinc"];}
		set {if (value==null|| value==DBNull.Value) this["spexportinc"]= DBNull.Value; else this["spexportinc"]= value;}
	}
	public String spexportincOriginal { 
		get {if (this["spexportinc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["spexportinc",DataRowVersion.Original];}
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
	///BIC
	///</summary>
	public String bic{ 
		get {if (this["bic"]==DBNull.Value)return null; return  (String)this["bic"];}
		set {if (value==null) this["bic"]= DBNull.Value; else this["bic"]= value;}
	}
	public object bicValue { 
		get{ return this["bic"];}
		set {if (value==null|| value==DBNull.Value) this["bic"]= DBNull.Value; else this["bic"]= value;}
	}
	public String bicOriginal { 
		get {if (this["bic",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["bic",DataRowVersion.Original];}
	}
	///<summary>
	///Il conto è fruttifero (valore predefinito per le reversali)
	///	 N: Conto non fruttifero (valore predefinito per le reversali)
	///	 S: Il conto è fruttifero (valore predefinito per le reversali)
	///</summary>
	public String flagfruitful{ 
		get {if (this["flagfruitful"]==DBNull.Value)return null; return  (String)this["flagfruitful"];}
		set {if (value==null) this["flagfruitful"]= DBNull.Value; else this["flagfruitful"]= value;}
	}
	public object flagfruitfulValue { 
		get{ return this["flagfruitful"];}
		set {if (value==null|| value==DBNull.Value) this["flagfruitful"]= DBNull.Value; else this["flagfruitful"]= value;}
	}
	public String flagfruitfulOriginal { 
		get {if (this["flagfruitful",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagfruitful",DataRowVersion.Original];}
	}
	///<summary>
	///CC per trasmissione CNI di disposizioni per cassa
	///</summary>
	public String cccbi{ 
		get {if (this["cccbi"]==DBNull.Value)return null; return  (String)this["cccbi"];}
		set {if (value==null) this["cccbi"]= DBNull.Value; else this["cccbi"]= value;}
	}
	public object cccbiValue { 
		get{ return this["cccbi"];}
		set {if (value==null|| value==DBNull.Value) this["cccbi"]= DBNull.Value; else this["cccbi"]= value;}
	}
	public String cccbiOriginal { 
		get {if (this["cccbi",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cccbi",DataRowVersion.Original];}
	}
	///<summary>
	///CIN per trasm.CBI di disposizioni per cassa
	///</summary>
	public String cincbi{ 
		get {if (this["cincbi"]==DBNull.Value)return null; return  (String)this["cincbi"];}
		set {if (value==null) this["cincbi"]= DBNull.Value; else this["cincbi"]= value;}
	}
	public object cincbiValue { 
		get{ return this["cincbi"];}
		set {if (value==null|| value==DBNull.Value) this["cincbi"]= DBNull.Value; else this["cincbi"]= value;}
	}
	public String cincbiOriginal { 
		get {if (this["cincbi",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cincbi",DataRowVersion.Original];}
	}
	///<summary>
	///ABI per trasmissione CBI di disposizioni per cassa
	///</summary>
	public String idbankcbi{ 
		get {if (this["idbankcbi"]==DBNull.Value)return null; return  (String)this["idbankcbi"];}
		set {if (value==null) this["idbankcbi"]= DBNull.Value; else this["idbankcbi"]= value;}
	}
	public object idbankcbiValue { 
		get{ return this["idbankcbi"];}
		set {if (value==null|| value==DBNull.Value) this["idbankcbi"]= DBNull.Value; else this["idbankcbi"]= value;}
	}
	public String idbankcbiOriginal { 
		get {if (this["idbankcbi",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idbankcbi",DataRowVersion.Original];}
	}
	///<summary>
	///id CAB per trasmissioni CBI di disposizioni per cassa
	///</summary>
	public String idcabcbi{ 
		get {if (this["idcabcbi"]==DBNull.Value)return null; return  (String)this["idcabcbi"];}
		set {if (value==null) this["idcabcbi"]= DBNull.Value; else this["idcabcbi"]= value;}
	}
	public object idcabcbiValue { 
		get{ return this["idcabcbi"];}
		set {if (value==null|| value==DBNull.Value) this["idcabcbi"]= DBNull.Value; else this["idcabcbi"]= value;}
	}
	public String idcabcbiOriginal { 
		get {if (this["idcabcbi",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idcabcbi",DataRowVersion.Original];}
	}
	///<summary>
	///IBAN per trasmissione CBI di disposizioni per cassa
	///</summary>
	public String ibancbi{ 
		get {if (this["ibancbi"]==DBNull.Value)return null; return  (String)this["ibancbi"];}
		set {if (value==null) this["ibancbi"]= DBNull.Value; else this["ibancbi"]= value;}
	}
	public object ibancbiValue { 
		get{ return this["ibancbi"];}
		set {if (value==null|| value==DBNull.Value) this["ibancbi"]= DBNull.Value; else this["ibancbi"]= value;}
	}
	public String ibancbiOriginal { 
		get {if (this["ibancbi",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ibancbi",DataRowVersion.Original];}
	}
	///<summary>
	///Codice SIA per codice CBI
	///</summary>
	public String siacodecbi{ 
		get {if (this["siacodecbi"]==DBNull.Value)return null; return  (String)this["siacodecbi"];}
		set {if (value==null) this["siacodecbi"]= DBNull.Value; else this["siacodecbi"]= value;}
	}
	public object siacodecbiValue { 
		get{ return this["siacodecbi"];}
		set {if (value==null|| value==DBNull.Value) this["siacodecbi"]= DBNull.Value; else this["siacodecbi"]= value;}
	}
	public String siacodecbiOriginal { 
		get {if (this["siacodecbi",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["siacodecbi",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo Record CBI 
	///	 10: trasmissione coord. bancarie tramite record 10
	///	 17: trasmissione coord. bancarie con record 17
	///</summary>
	public String reccbikind{ 
		get {if (this["reccbikind"]==DBNull.Value)return null; return  (String)this["reccbikind"];}
		set {if (value==null) this["reccbikind"]= DBNull.Value; else this["reccbikind"]= value;}
	}
	public object reccbikindValue { 
		get{ return this["reccbikind"];}
		set {if (value==null|| value==DBNull.Value) this["reccbikind"]= DBNull.Value; else this["reccbikind"]= value;}
	}
	public String reccbikindOriginal { 
		get {if (this["reccbikind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["reccbikind",DataRowVersion.Original];}
	}
	///<summary>
	///Codice Conto Tesoreria
	///</summary>
	public String trasmcode{ 
		get {if (this["trasmcode"]==DBNull.Value)return null; return  (String)this["trasmcode"];}
		set {if (value==null) this["trasmcode"]= DBNull.Value; else this["trasmcode"]= value;}
	}
	public object trasmcodeValue { 
		get{ return this["trasmcode"];}
		set {if (value==null|| value==DBNull.Value) this["trasmcode"]= DBNull.Value; else this["trasmcode"]= value;}
	}
	public String trasmcodeOriginal { 
		get {if (this["trasmcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["trasmcode",DataRowVersion.Original];}
	}
	///<summary>
	///Non più usato. Non raggruppiamo i movimenti bancari.
	///</summary>
	public Int32? flagbank_grouping{ 
		get {if (this["flagbank_grouping"]==DBNull.Value)return null; return  (Int32?)this["flagbank_grouping"];}
		set {if (value==null) this["flagbank_grouping"]= DBNull.Value; else this["flagbank_grouping"]= value;}
	}
	public object flagbank_groupingValue { 
		get{ return this["flagbank_grouping"];}
		set {if (value==null|| value==DBNull.Value) this["flagbank_grouping"]= DBNull.Value; else this["flagbank_grouping"]= value;}
	}
	public Int32? flagbank_groupingOriginal { 
		get {if (this["flagbank_grouping",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["flagbank_grouping",DataRowVersion.Original];}
	}
	///<summary>
	///Costruzione Causale Pagamenti - lunghezza
	///</summary>
	public Int16? motivelen{ 
		get {if (this["motivelen"]==DBNull.Value)return null; return  (Int16?)this["motivelen"];}
		set {if (value==null) this["motivelen"]= DBNull.Value; else this["motivelen"]= value;}
	}
	public object motivelenValue { 
		get{ return this["motivelen"];}
		set {if (value==null|| value==DBNull.Value) this["motivelen"]= DBNull.Value; else this["motivelen"]= value;}
	}
	public Int16? motivelenOriginal { 
		get {if (this["motivelen",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["motivelen",DataRowVersion.Original];}
	}
	///<summary>
	///Costruzione Causale Pagamenti - prefisso
	///</summary>
	public String motiveprefix{ 
		get {if (this["motiveprefix"]==DBNull.Value)return null; return  (String)this["motiveprefix"];}
		set {if (value==null) this["motiveprefix"]= DBNull.Value; else this["motiveprefix"]= value;}
	}
	public object motiveprefixValue { 
		get{ return this["motiveprefix"];}
		set {if (value==null|| value==DBNull.Value) this["motiveprefix"]= DBNull.Value; else this["motiveprefix"]= value;}
	}
	public String motiveprefixOriginal { 
		get {if (this["motiveprefix",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["motiveprefix",DataRowVersion.Original];}
	}
	///<summary>
	///Costruzione Causale Pagamenti - separatore
	///</summary>
	public String motiveseparator{ 
		get {if (this["motiveseparator"]==DBNull.Value)return null; return  (String)this["motiveseparator"];}
		set {if (value==null) this["motiveseparator"]= DBNull.Value; else this["motiveseparator"]= value;}
	}
	public object motiveseparatorValue { 
		get{ return this["motiveseparator"];}
		set {if (value==null|| value==DBNull.Value) this["motiveseparator"]= DBNull.Value; else this["motiveseparator"]= value;}
	}
	public String motiveseparatorOriginal { 
		get {if (this["motiveseparator",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["motiveseparator",DataRowVersion.Original];}
	}
	///<summary>
	///Annotazioni
	///</summary>
	public String annotations{ 
		get {if (this["annotations"]==DBNull.Value)return null; return  (String)this["annotations"];}
		set {if (value==null) this["annotations"]= DBNull.Value; else this["annotations"]= value;}
	}
	public object annotationsValue { 
		get{ return this["annotations"];}
		set {if (value==null|| value==DBNull.Value) this["annotations"]= DBNull.Value; else this["annotations"]= value;}
	}
	public String annotationsOriginal { 
		get {if (this["annotations",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["annotations",DataRowVersion.Original];}
	}
	///<summary>
	///Gestione ordinativo Informatico (Annullamenti e Variazioni)
	///	 N: Non prevede gestione ordinativo Informatico
	///	 S: Gestione ordinativo Informatico (Annullamenti e Variazioni)
	///</summary>
	public String flagedisp{ 
		get {if (this["flagedisp"]==DBNull.Value)return null; return  (String)this["flagedisp"];}
		set {if (value==null) this["flagedisp"]= DBNull.Value; else this["flagedisp"]= value;}
	}
	public object flagedispValue { 
		get{ return this["flagedisp"];}
		set {if (value==null|| value==DBNull.Value) this["flagedisp"]= DBNull.Value; else this["flagedisp"]= value;}
	}
	public String flagedispOriginal { 
		get {if (this["flagedisp",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagedisp",DataRowVersion.Original];}
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
	///Codeice struttura per trasm. elettronica
	///</summary>
	public String billcode{ 
		get {if (this["billcode"]==DBNull.Value)return null; return  (String)this["billcode"];}
		set {if (value==null) this["billcode"]= DBNull.Value; else this["billcode"]= value;}
	}
	public object billcodeValue { 
		get{ return this["billcode"];}
		set {if (value==null|| value==DBNull.Value) this["billcode"]= DBNull.Value; else this["billcode"]= value;}
	}
	public String billcodeOriginal { 
		get {if (this["billcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["billcode",DataRowVersion.Original];}
	}
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
	///Header
	///</summary>
	public String header{ 
		get {if (this["header"]==DBNull.Value)return null; return  (String)this["header"];}
		set {if (value==null) this["header"]= DBNull.Value; else this["header"]= value;}
	}
	public object headerValue { 
		get{ return this["header"];}
		set {if (value==null|| value==DBNull.Value) this["header"]= DBNull.Value; else this["header"]= value;}
	}
	public String headerOriginal { 
		get {if (this["header",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["header",DataRowVersion.Original];}
	}
	///<summary>
	///Cartella di salvataggio dei file
	///</summary>
	public String savepath{ 
		get {if (this["savepath"]==DBNull.Value)return null; return  (String)this["savepath"];}
		set {if (value==null) this["savepath"]= DBNull.Value; else this["savepath"]= value;}
	}
	public object savepathValue { 
		get{ return this["savepath"];}
		set {if (value==null|| value==DBNull.Value) this["savepath"]= DBNull.Value; else this["savepath"]= value;}
	}
	public String savepathOriginal { 
		get {if (this["savepath",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["savepath",DataRowVersion.Original];}
	}
	///<summary>
	///Denominazione F.E.
	///</summary>
	public String departmentname_fe{ 
		get {if (this["departmentname_fe"]==DBNull.Value)return null; return  (String)this["departmentname_fe"];}
		set {if (value==null) this["departmentname_fe"]= DBNull.Value; else this["departmentname_fe"]= value;}
	}
	public object departmentname_feValue { 
		get{ return this["departmentname_fe"];}
		set {if (value==null|| value==DBNull.Value) this["departmentname_fe"]= DBNull.Value; else this["departmentname_fe"]= value;}
	}
	public String departmentname_feOriginal { 
		get {if (this["departmentname_fe",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["departmentname_fe",DataRowVersion.Original];}
	}
	///<summary>
	///usato per  i ticket
	///</summary>
	public Int32? idstruttura{ 
		get {if (this["idstruttura"]==DBNull.Value)return null; return  (Int32?)this["idstruttura"];}
		set {if (value==null) this["idstruttura"]= DBNull.Value; else this["idstruttura"]= value;}
	}
	public object idstrutturaValue { 
		get{ return this["idstruttura"];}
		set {if (value==null|| value==DBNull.Value) this["idstruttura"]= DBNull.Value; else this["idstruttura"]= value;}
	}
	public Int32? idstrutturaOriginal { 
		get {if (this["idstruttura",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idstruttura",DataRowVersion.Original];}
	}
	///<summary>
	///Abilita Numerazione dei Documenti per Cassiere
	///	 N: Non è vero che: "Abilita Numerazione dei Documenti per Cassiere"
	///	 S: Abilita Numerazione dei Documenti per Cassiere
	///</summary>
	public String enable_ndoc_treasurer{ 
		get {if (this["enable_ndoc_treasurer"]==DBNull.Value)return null; return  (String)this["enable_ndoc_treasurer"];}
		set {if (value==null) this["enable_ndoc_treasurer"]= DBNull.Value; else this["enable_ndoc_treasurer"]= value;}
	}
	public object enable_ndoc_treasurerValue { 
		get{ return this["enable_ndoc_treasurer"];}
		set {if (value==null|| value==DBNull.Value) this["enable_ndoc_treasurer"]= DBNull.Value; else this["enable_ndoc_treasurer"]= value;}
	}
	public String enable_ndoc_treasurerOriginal { 
		get {if (this["enable_ndoc_treasurer",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["enable_ndoc_treasurer",DataRowVersion.Original];}
	}
	///<summary>
	///codice per flusso crediti
	///</summary>
	public String flussocrediticode{ 
		get {if (this["flussocrediticode"]==DBNull.Value)return null; return  (String)this["flussocrediticode"];}
		set {if (value==null) this["flussocrediticode"]= DBNull.Value; else this["flussocrediticode"]= value;}
	}
	public object flussocrediticodeValue { 
		get{ return this["flussocrediticode"];}
		set {if (value==null|| value==DBNull.Value) this["flussocrediticode"]= DBNull.Value; else this["flussocrediticode"]= value;}
	}
	public String flussocrediticodeOriginal { 
		get {if (this["flussocrediticode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flussocrediticode",DataRowVersion.Original];}
	}
	///<summary>
	///user ftp
	///</summary>
	public String ftpuser{ 
		get {if (this["ftpuser"]==DBNull.Value)return null; return  (String)this["ftpuser"];}
		set {if (value==null) this["ftpuser"]= DBNull.Value; else this["ftpuser"]= value;}
	}
	public object ftpuserValue { 
		get{ return this["ftpuser"];}
		set {if (value==null|| value==DBNull.Value) this["ftpuser"]= DBNull.Value; else this["ftpuser"]= value;}
	}
	public String ftpuserOriginal { 
		get {if (this["ftpuser",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ftpuser",DataRowVersion.Original];}
	}
	///<summary>
	///password ftp
	///</summary>
	public String ftppassword{ 
		get {if (this["ftppassword"]==DBNull.Value)return null; return  (String)this["ftppassword"];}
		set {if (value==null) this["ftppassword"]= DBNull.Value; else this["ftppassword"]= value;}
	}
	public object ftppasswordValue { 
		get{ return this["ftppassword"];}
		set {if (value==null|| value==DBNull.Value) this["ftppassword"]= DBNull.Value; else this["ftppassword"]= value;}
	}
	public String ftppasswordOriginal { 
		get {if (this["ftppassword",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ftppassword",DataRowVersion.Original];}
	}
	///<summary>
	///Indirizzo ftp
	///</summary>
	public String ftpaddress{ 
		get {if (this["ftpaddress"]==DBNull.Value)return null; return  (String)this["ftpaddress"];}
		set {if (value==null) this["ftpaddress"]= DBNull.Value; else this["ftpaddress"]= value;}
	}
	public object ftpaddressValue { 
		get{ return this["ftpaddress"];}
		set {if (value==null|| value==DBNull.Value) this["ftpaddress"]= DBNull.Value; else this["ftpaddress"]= value;}
	}
	public String ftpaddressOriginal { 
		get {if (this["ftpaddress",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ftpaddress",DataRowVersion.Original];}
	}
	///<summary>
	///pasv mode ftp
	///</summary>
	public String pasvmode{ 
		get {if (this["pasvmode"]==DBNull.Value)return null; return  (String)this["pasvmode"];}
		set {if (value==null) this["pasvmode"]= DBNull.Value; else this["pasvmode"]= value;}
	}
	public object pasvmodeValue { 
		get{ return this["pasvmode"];}
		set {if (value==null|| value==DBNull.Value) this["pasvmode"]= DBNull.Value; else this["pasvmode"]= value;}
	}
	public String pasvmodeOriginal { 
		get {if (this["pasvmode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["pasvmode",DataRowVersion.Original];}
	}
	///<summary>
	///porta ftp
	///</summary>
	public Int32? ftpport{ 
		get {if (this["ftpport"]==DBNull.Value)return null; return  (Int32?)this["ftpport"];}
		set {if (value==null) this["ftpport"]= DBNull.Value; else this["ftpport"]= value;}
	}
	public object ftpportValue { 
		get{ return this["ftpport"];}
		set {if (value==null|| value==DBNull.Value) this["ftpport"]= DBNull.Value; else this["ftpport"]= value;}
	}
	public Int32? ftpportOriginal { 
		get {if (this["ftpport",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ftpport",DataRowVersion.Original];}
	}
	///<summary>
	///directory ftp
	///</summary>
	public String ftpdir{ 
		get {if (this["ftpdir"]==DBNull.Value)return null; return  (String)this["ftpdir"];}
		set {if (value==null) this["ftpdir"]= DBNull.Value; else this["ftpdir"]= value;}
	}
	public object ftpdirValue { 
		get{ return this["ftpdir"];}
		set {if (value==null|| value==DBNull.Value) this["ftpdir"]= DBNull.Value; else this["ftpdir"]= value;}
	}
	public String ftpdirOriginal { 
		get {if (this["ftpdir",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ftpdir",DataRowVersion.Original];}
	}
	public String tramite_bt_code{ 
		get {if (this["tramite_bt_code"]==DBNull.Value)return null; return  (String)this["tramite_bt_code"];}
		set {if (value==null) this["tramite_bt_code"]= DBNull.Value; else this["tramite_bt_code"]= value;}
	}
	public object tramite_bt_codeValue { 
		get{ return this["tramite_bt_code"];}
		set {if (value==null|| value==DBNull.Value) this["tramite_bt_code"]= DBNull.Value; else this["tramite_bt_code"]= value;}
	}
	public String tramite_bt_codeOriginal { 
		get {if (this["tramite_bt_code",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tramite_bt_code",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Tesoriere
///</summary>
public class treasurerTable : MetaTableBase<treasurerRow> {
	public treasurerTable() : base("treasurer"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"address",createColumn("address",typeof(string),true,false)},
			{"agencycodefortransmission",createColumn("agencycodefortransmission",typeof(string),true,false)},
			{"cabcodefortransmission",createColumn("cabcodefortransmission",typeof(string),true,false)},
			{"cap",createColumn("cap",typeof(string),true,false)},
			{"cc",createColumn("cc",typeof(string),true,false)},
			{"cin",createColumn("cin",typeof(string),true,false)},
			{"city",createColumn("city",typeof(string),true,false)},
			{"country",createColumn("country",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"depcodefortransmission",createColumn("depcodefortransmission",typeof(string),true,false)},
			{"description",createColumn("description",typeof(string),true,false)},
			{"faxnumber",createColumn("faxnumber",typeof(string),true,false)},
			{"faxprefix",createColumn("faxprefix",typeof(string),true,false)},
			{"flagdefault",createColumn("flagdefault",typeof(string),false,false)},
			{"idaccmotive_payment",createColumn("idaccmotive_payment",typeof(string),true,false)},
			{"idaccmotive_proceeds",createColumn("idaccmotive_proceeds",typeof(string),true,false)},
			{"idbank",createColumn("idbank",typeof(string),true,false)},
			{"idcab",createColumn("idcab",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"phonenumber",createColumn("phonenumber",typeof(string),true,false)},
			{"phoneprefix",createColumn("phoneprefix",typeof(string),true,false)},
			{"codetreasurer",createColumn("codetreasurer",typeof(string),false,false)},
			{"idtreasurer",createColumn("idtreasurer",typeof(int),false,false)},
			{"spexportexp",createColumn("spexportexp",typeof(string),true,false)},
			{"flagmultiexp",createColumn("flagmultiexp",typeof(string),true,false)},
			{"fileextension",createColumn("fileextension",typeof(string),true,false)},
			{"spexportinc",createColumn("spexportinc",typeof(string),true,false)},
			{"iban",createColumn("iban",typeof(string),true,false)},
			{"bic",createColumn("bic",typeof(string),true,false)},
			{"flagfruitful",createColumn("flagfruitful",typeof(string),true,false)},
			{"cccbi",createColumn("cccbi",typeof(string),true,false)},
			{"cincbi",createColumn("cincbi",typeof(string),true,false)},
			{"idbankcbi",createColumn("idbankcbi",typeof(string),true,false)},
			{"idcabcbi",createColumn("idcabcbi",typeof(string),true,false)},
			{"ibancbi",createColumn("ibancbi",typeof(string),true,false)},
			{"siacodecbi",createColumn("siacodecbi",typeof(string),true,false)},
			{"reccbikind",createColumn("reccbikind",typeof(string),true,false)},
			{"trasmcode",createColumn("trasmcode",typeof(string),true,false)},
			{"flagbank_grouping",createColumn("flagbank_grouping",typeof(int),true,false)},
			{"motivelen",createColumn("motivelen",typeof(short),true,false)},
			{"motiveprefix",createColumn("motiveprefix",typeof(string),true,false)},
			{"motiveseparator",createColumn("motiveseparator",typeof(string),true,false)},
			{"annotations",createColumn("annotations",typeof(string),true,false)},
			{"flagedisp",createColumn("flagedisp",typeof(string),true,false)},
			{"idsor01",createColumn("idsor01",typeof(int),true,false)},
			{"idsor02",createColumn("idsor02",typeof(int),true,false)},
			{"idsor03",createColumn("idsor03",typeof(int),true,false)},
			{"idsor04",createColumn("idsor04",typeof(int),true,false)},
			{"idsor05",createColumn("idsor05",typeof(int),true,false)},
			{"billcode",createColumn("billcode",typeof(string),true,false)},
			{"active",createColumn("active",typeof(string),true,false)},
			{"flag",createColumn("flag",typeof(int),true,false)},
			{"header",createColumn("header",typeof(string),true,false)},
			{"savepath",createColumn("savepath",typeof(string),true,false)},
			{"departmentname_fe",createColumn("departmentname_fe",typeof(string),true,false)},
			{"idstruttura",createColumn("idstruttura",typeof(int),true,false)},
			{"enable_ndoc_treasurer",createColumn("enable_ndoc_treasurer",typeof(string),true,false)},
			{"flussocrediticode",createColumn("flussocrediticode",typeof(string),true,false)},
			{"ftpuser",createColumn("ftpuser",typeof(string),true,false)},
			{"ftppassword",createColumn("ftppassword",typeof(string),true,false)},
			{"ftpaddress",createColumn("ftpaddress",typeof(string),true,false)},
			{"pasvmode",createColumn("pasvmode",typeof(string),true,false)},
			{"ftpport",createColumn("ftpport",typeof(int),true,false)},
			{"ftpdir",createColumn("ftpdir",typeof(string),true,false)},
			{"tramite_bt_code",createColumn("tramite_bt_code",typeof(string),true,false)},
		};
	}
}
}
