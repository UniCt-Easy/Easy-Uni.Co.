
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
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_expenselast {
public class expenselastRow: MetaRow  {
	public expenselastRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///flag
	///</summary>
	public Byte? flag{ 
		get {if (this["flag"]==DBNull.Value)return null; return  (Byte?)this["flag"];}
		set {if (value==null) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {if (value==null|| value==DBNull.Value) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public Byte? flagOriginal { 
		get {if (this["flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["flag",DataRowVersion.Original];}
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
	///id anagrafica delegato (tabella registry)
	///</summary>
	public Int32? iddeputy{ 
		get {if (this["iddeputy"]==DBNull.Value)return null; return  (Int32?)this["iddeputy"];}
		set {if (value==null) this["iddeputy"]= DBNull.Value; else this["iddeputy"]= value;}
	}
	public object iddeputyValue { 
		get{ return this["iddeputy"];}
		set {if (value==null|| value==DBNull.Value) this["iddeputy"]= DBNull.Value; else this["iddeputy"]= value;}
	}
	public Int32? iddeputyOriginal { 
		get {if (this["iddeputy",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddeputy",DataRowVersion.Original];}
	}
	///<summary>
	///progressivo per il mandato, valorizzato da trigger
	///Num SUB (trasmissione)
	///</summary>
	public Int32? idpay{ 
		get {if (this["idpay"]==DBNull.Value)return null; return  (Int32?)this["idpay"];}
		set {if (value==null) this["idpay"]= DBNull.Value; else this["idpay"]= value;}
	}
	public object idpayValue { 
		get{ return this["idpay"];}
		set {if (value==null|| value==DBNull.Value) this["idpay"]= DBNull.Value; else this["idpay"]= value;}
	}
	public Int32? idpayOriginal { 
		get {if (this["idpay",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpay",DataRowVersion.Original];}
	}
	///<summary>
	///#
	///</summary>
	public Int32? idregistrypaymethod{ 
		get {if (this["idregistrypaymethod"]==DBNull.Value)return null; return  (Int32?)this["idregistrypaymethod"];}
		set {if (value==null) this["idregistrypaymethod"]= DBNull.Value; else this["idregistrypaymethod"]= value;}
	}
	public object idregistrypaymethodValue { 
		get{ return this["idregistrypaymethod"];}
		set {if (value==null|| value==DBNull.Value) this["idregistrypaymethod"]= DBNull.Value; else this["idregistrypaymethod"]= value;}
	}
	public Int32? idregistrypaymethodOriginal { 
		get {if (this["idregistrypaymethod",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idregistrypaymethod",DataRowVersion.Original];}
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
	///Importo iva
	///</summary>
	public Decimal? ivaamount{ 
		get {if (this["ivaamount"]==DBNull.Value)return null; return  (Decimal?)this["ivaamount"];}
		set {if (value==null) this["ivaamount"]= DBNull.Value; else this["ivaamount"]= value;}
	}
	public object ivaamountValue { 
		get{ return this["ivaamount"];}
		set {if (value==null|| value==DBNull.Value) this["ivaamount"]= DBNull.Value; else this["ivaamount"]= value;}
	}
	public Decimal? ivaamountOriginal { 
		get {if (this["ivaamount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["ivaamount",DataRowVersion.Original];}
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
	///N.bolletta
	///</summary>
	public Int32? nbill{ 
		get {if (this["nbill"]==DBNull.Value)return null; return  (Int32?)this["nbill"];}
		set {if (value==null) this["nbill"]= DBNull.Value; else this["nbill"]= value;}
	}
	public object nbillValue { 
		get{ return this["nbill"];}
		set {if (value==null|| value==DBNull.Value) this["nbill"]= DBNull.Value; else this["nbill"]= value;}
	}
	public Int32? nbillOriginal { 
		get {if (this["nbill",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nbill",DataRowVersion.Original];}
	}
	///<summary>
	///Descrizione pagamento
	///</summary>
	public String paymentdescr{ 
		get {if (this["paymentdescr"]==DBNull.Value)return null; return  (String)this["paymentdescr"];}
		set {if (value==null) this["paymentdescr"]= DBNull.Value; else this["paymentdescr"]= value;}
	}
	public object paymentdescrValue { 
		get{ return this["paymentdescr"];}
		set {if (value==null|| value==DBNull.Value) this["paymentdescr"]= DBNull.Value; else this["paymentdescr"]= value;}
	}
	public String paymentdescrOriginal { 
		get {if (this["paymentdescr",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["paymentdescr",DataRowVersion.Original];}
	}
	///<summary>
	///Riferimento a doc.esterno per pagamento
	///</summary>
	public String refexternaldoc{ 
		get {if (this["refexternaldoc"]==DBNull.Value)return null; return  (String)this["refexternaldoc"];}
		set {if (value==null) this["refexternaldoc"]= DBNull.Value; else this["refexternaldoc"]= value;}
	}
	public object refexternaldocValue { 
		get{ return this["refexternaldoc"];}
		set {if (value==null|| value==DBNull.Value) this["refexternaldoc"]= DBNull.Value; else this["refexternaldoc"]= value;}
	}
	public String refexternaldocOriginal { 
		get {if (this["refexternaldoc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["refexternaldoc",DataRowVersion.Original];}
	}
	///<summary>
	///Inizio prestazione
	///</summary>
	public DateTime? servicestart{ 
		get {if (this["servicestart"]==DBNull.Value)return null; return  (DateTime?)this["servicestart"];}
		set {if (value==null) this["servicestart"]= DBNull.Value; else this["servicestart"]= value;}
	}
	public object servicestartValue { 
		get{ return this["servicestart"];}
		set {if (value==null|| value==DBNull.Value) this["servicestart"]= DBNull.Value; else this["servicestart"]= value;}
	}
	public DateTime? servicestartOriginal { 
		get {if (this["servicestart",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["servicestart",DataRowVersion.Original];}
	}
	///<summary>
	///Fine prestazione
	///</summary>
	public DateTime? servicestop{ 
		get {if (this["servicestop"]==DBNull.Value)return null; return  (DateTime?)this["servicestop"];}
		set {if (value==null) this["servicestop"]= DBNull.Value; else this["servicestop"]= value;}
	}
	public object servicestopValue { 
		get{ return this["servicestop"];}
		set {if (value==null|| value==DBNull.Value) this["servicestop"]= DBNull.Value; else this["servicestop"]= value;}
	}
	public DateTime? servicestopOriginal { 
		get {if (this["servicestop",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["servicestop",DataRowVersion.Original];}
	}
	///<summary>
	///Chiave modalità pagamento (tabella paymethod)
	///</summary>
	public Int32? idpaymethod{ 
		get {if (this["idpaymethod"]==DBNull.Value)return null; return  (Int32?)this["idpaymethod"];}
		set {if (value==null) this["idpaymethod"]= DBNull.Value; else this["idpaymethod"]= value;}
	}
	public object idpaymethodValue { 
		get{ return this["idpaymethod"];}
		set {if (value==null|| value==DBNull.Value) this["idpaymethod"]= DBNull.Value; else this["idpaymethod"]= value;}
	}
	public Int32? idpaymethodOriginal { 
		get {if (this["idpaymethod",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpaymethod",DataRowVersion.Original];}
	}
	///<summary>
	///chiave mandato (tabella payment)
	///</summary>
	public Int32? kpay{ 
		get {if (this["kpay"]==DBNull.Value)return null; return  (Int32?)this["kpay"];}
		set {if (value==null) this["kpay"]= DBNull.Value; else this["kpay"]= value;}
	}
	public object kpayValue { 
		get{ return this["kpay"];}
		set {if (value==null|| value==DBNull.Value) this["kpay"]= DBNull.Value; else this["kpay"]= value;}
	}
	public Int32? kpayOriginal { 
		get {if (this["kpay",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["kpay",DataRowVersion.Original];}
	}
	///<summary>
	///conto EP da usare per il debito 
	///</summary>
	public String idaccdebit{ 
		get {if (this["idaccdebit"]==DBNull.Value)return null; return  (String)this["idaccdebit"];}
		set {if (value==null) this["idaccdebit"]= DBNull.Value; else this["idaccdebit"]= value;}
	}
	public object idaccdebitValue { 
		get{ return this["idaccdebit"];}
		set {if (value==null|| value==DBNull.Value) this["idaccdebit"]= DBNull.Value; else this["idaccdebit"]= value;}
	}
	public String idaccdebitOriginal { 
		get {if (this["idaccdebit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccdebit",DataRowVersion.Original];}
	}
	///<summary>
	///Codice BIC/SWIFT
	///</summary>
	public String biccode{ 
		get {if (this["biccode"]==DBNull.Value)return null; return  (String)this["biccode"];}
		set {if (value==null) this["biccode"]= DBNull.Value; else this["biccode"]= value;}
	}
	public object biccodeValue { 
		get{ return this["biccode"];}
		set {if (value==null|| value==DBNull.Value) this["biccode"]= DBNull.Value; else this["biccode"]= value;}
	}
	public String biccodeOriginal { 
		get {if (this["biccode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["biccode",DataRowVersion.Original];}
	}
	///<summary>
	///Conto banca d'Italia
	///</summary>
	public String extracode{ 
		get {if (this["extracode"]==DBNull.Value)return null; return  (String)this["extracode"];}
		set {if (value==null) this["extracode"]= DBNull.Value; else this["extracode"]= value;}
	}
	public object extracodeValue { 
		get{ return this["extracode"];}
		set {if (value==null|| value==DBNull.Value) this["extracode"]= DBNull.Value; else this["extracode"]= value;}
	}
	public String extracodeOriginal { 
		get {if (this["extracode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["extracode",DataRowVersion.Original];}
	}
	///<summary>
	///Ammetti delegato
	///	 N: Non è vero che: "Ammetti delegato"
	///	 S: Ammetti delegato
	///</summary>
	public String paymethod_allowdeputy{ 
		get {if (this["paymethod_allowdeputy"]==DBNull.Value)return null; return  (String)this["paymethod_allowdeputy"];}
		set {if (value==null) this["paymethod_allowdeputy"]= DBNull.Value; else this["paymethod_allowdeputy"]= value;}
	}
	public object paymethod_allowdeputyValue { 
		get{ return this["paymethod_allowdeputy"];}
		set {if (value==null|| value==DBNull.Value) this["paymethod_allowdeputy"]= DBNull.Value; else this["paymethod_allowdeputy"]= value;}
	}
	public String paymethod_allowdeputyOriginal { 
		get {if (this["paymethod_allowdeputy",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["paymethod_allowdeputy",DataRowVersion.Original];}
	}
	///<summary>
	///flag su modalità pagamento
	///</summary>
	public Int32? paymethod_flag{ 
		get {if (this["paymethod_flag"]==DBNull.Value)return null; return  (Int32?)this["paymethod_flag"];}
		set {if (value==null) this["paymethod_flag"]= DBNull.Value; else this["paymethod_flag"]= value;}
	}
	public object paymethod_flagValue { 
		get{ return this["paymethod_flag"];}
		set {if (value==null|| value==DBNull.Value) this["paymethod_flag"]= DBNull.Value; else this["paymethod_flag"]= value;}
	}
	public Int32? paymethod_flagOriginal { 
		get {if (this["paymethod_flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["paymethod_flag",DataRowVersion.Original];}
	}
	///<summary>
	///ID Trattamento delle spese (tabella chargehandling)
	///</summary>
	public Int32? idchargehandling{ 
		get {if (this["idchargehandling"]==DBNull.Value)return null; return  (Int32?)this["idchargehandling"];}
		set {if (value==null) this["idchargehandling"]= DBNull.Value; else this["idchargehandling"]= value;}
	}
	public object idchargehandlingValue { 
		get{ return this["idchargehandling"];}
		set {if (value==null|| value==DBNull.Value) this["idchargehandling"]= DBNull.Value; else this["idchargehandling"]= value;}
	}
	public Int32? idchargehandlingOriginal { 
		get {if (this["idchargehandling",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idchargehandling",DataRowVersion.Original];}
	}
	public String pagopanoticenum{ 
		get {if (this["pagopanoticenum"]==DBNull.Value)return null; return  (String)this["pagopanoticenum"];}
		set {if (value==null) this["pagopanoticenum"]= DBNull.Value; else this["pagopanoticenum"]= value;}
	}
	public object pagopanoticenumValue { 
		get{ return this["pagopanoticenum"];}
		set {if (value==null|| value==DBNull.Value) this["pagopanoticenum"]= DBNull.Value; else this["pagopanoticenum"]= value;}
	}
	public String pagopanoticenumOriginal { 
		get {if (this["pagopanoticenum",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["pagopanoticenum",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Movimento di spesa - Dettaglio
///</summary>
public class expenselastTable : MetaTableBase<expenselastRow> {
	public expenselastTable() : base("expenselast"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idexp",createColumn("idexp",typeof(int),false,false)},
			{"cc",createColumn("cc",typeof(string),true,false)},
			{"cin",createColumn("cin",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"flag",createColumn("flag",typeof(byte),false,false)},
			{"iban",createColumn("iban",typeof(string),true,false)},
			{"idbank",createColumn("idbank",typeof(string),true,false)},
			{"idcab",createColumn("idcab",typeof(string),true,false)},
			{"iddeputy",createColumn("iddeputy",typeof(int),true,false)},
			{"idpay",createColumn("idpay",typeof(int),true,false)},
			{"idregistrypaymethod",createColumn("idregistrypaymethod",typeof(int),true,false)},
			{"idser",createColumn("idser",typeof(int),true,false)},
			{"ivaamount",createColumn("ivaamount",typeof(decimal),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"nbill",createColumn("nbill",typeof(int),true,false)},
			{"paymentdescr",createColumn("paymentdescr",typeof(string),true,false)},
			{"refexternaldoc",createColumn("refexternaldoc",typeof(string),true,false)},
			{"servicestart",createColumn("servicestart",typeof(DateTime),true,false)},
			{"servicestop",createColumn("servicestop",typeof(DateTime),true,false)},
			{"idpaymethod",createColumn("idpaymethod",typeof(int),true,false)},
			{"kpay",createColumn("kpay",typeof(int),true,false)},
			{"idaccdebit",createColumn("idaccdebit",typeof(string),true,false)},
			{"biccode",createColumn("biccode",typeof(string),true,false)},
			{"extracode",createColumn("extracode",typeof(string),true,false)},
			{"paymethod_allowdeputy",createColumn("paymethod_allowdeputy",typeof(string),true,false)},
			{"paymethod_flag",createColumn("paymethod_flag",typeof(int),true,false)},
			{"idchargehandling",createColumn("idchargehandling",typeof(int),true,false)},
			{"pagopanoticenum",createColumn("pagopanoticenum",typeof(string),true,false)},
		};
	}
}
}
