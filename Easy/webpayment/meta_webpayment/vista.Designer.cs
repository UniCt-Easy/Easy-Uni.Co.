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
namespace meta_webpayment {
public class webpaymentRow: MetaRow  {
	public webpaymentRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///#
	///</summary>
	public Int32 idwebpayment{ 
		get {return  (Int32)this["idwebpayment"];}
		set {this["idwebpayment"]= value;}
	}
	public object idwebpaymentValue { 
		get{ return this["idwebpayment"];}
		set {this["idwebpayment"]= value;}
	}
	public Int32 idwebpaymentOriginal { 
		get {return  (Int32)this["idwebpayment",DataRowVersion.Original];}
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
	///nome
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
	///riferimento al customuser 
	///</summary>
	public String idcustomuser{ 
		get {if (this["idcustomuser"]==DBNull.Value)return null; return  (String)this["idcustomuser"];}
		set {if (value==null) this["idcustomuser"]= DBNull.Value; else this["idcustomuser"]= value;}
	}
	public object idcustomuserValue { 
		get{ return this["idcustomuser"];}
		set {if (value==null|| value==DBNull.Value) this["idcustomuser"]= DBNull.Value; else this["idcustomuser"]= value;}
	}
	public String idcustomuserOriginal { 
		get {if (this["idcustomuser",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idcustomuser",DataRowVersion.Original];}
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
	///n. pagamento
	///</summary>
	public Int32? nwebpayment{ 
		get {if (this["nwebpayment"]==DBNull.Value)return null; return  (Int32?)this["nwebpayment"];}
		set {if (value==null) this["nwebpayment"]= DBNull.Value; else this["nwebpayment"]= value;}
	}
	public object nwebpaymentValue { 
		get{ return this["nwebpayment"];}
		set {if (value==null|| value==DBNull.Value) this["nwebpayment"]= DBNull.Value; else this["nwebpayment"]= value;}
	}
	public Int32? nwebpaymentOriginal { 
		get {if (this["nwebpayment",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nwebpayment",DataRowVersion.Original];}
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
	///anno pagamento
	///</summary>
	public Int16 ywebpayment{ 
		get {return  (Int16)this["ywebpayment"];}
		set {this["ywebpayment"]= value;}
	}
	public object ywebpaymentValue { 
		get{ return this["ywebpayment"];}
		set {this["ywebpayment"]= value;}
	}
	public Int16 ywebpaymentOriginal { 
		get {return  (Int16)this["ywebpayment",DataRowVersion.Original];}
	}
	///<summary>
	///stato del pagamento
	///</summary>
	public Int16? idwebpaymentstatus{ 
		get {if (this["idwebpaymentstatus"]==DBNull.Value)return null; return  (Int16?)this["idwebpaymentstatus"];}
		set {if (value==null) this["idwebpaymentstatus"]= DBNull.Value; else this["idwebpaymentstatus"]= value;}
	}
	public object idwebpaymentstatusValue { 
		get{ return this["idwebpaymentstatus"];}
		set {if (value==null|| value==DBNull.Value) this["idwebpaymentstatus"]= DBNull.Value; else this["idwebpaymentstatus"]= value;}
	}
	public Int16? idwebpaymentstatusOriginal { 
		get {if (this["idwebpaymentstatus",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["idwebpaymentstatus",DataRowVersion.Original];}
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
	///iuv restituito dalla banca
	///</summary>
	public String iuv{ 
		get {if (this["iuv"]==DBNull.Value)return null; return  (String)this["iuv"];}
		set {if (value==null) this["iuv"]= DBNull.Value; else this["iuv"]= value;}
	}
	public object iuvValue { 
		get{ return this["iuv"];}
		set {if (value==null|| value==DBNull.Value) this["iuv"]= DBNull.Value; else this["iuv"]= value;}
	}
	public String iuvOriginal { 
		get {if (this["iuv",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["iuv",DataRowVersion.Original];}
	}
	///<summary>
	///codice QR
	///</summary>
	public String qrcode{ 
		get {if (this["qrcode"]==DBNull.Value)return null; return  (String)this["qrcode"];}
		set {if (value==null) this["qrcode"]= DBNull.Value; else this["qrcode"]= value;}
	}
	public object qrcodeValue { 
		get{ return this["qrcode"];}
		set {if (value==null|| value==DBNull.Value) this["qrcode"]= DBNull.Value; else this["qrcode"]= value;}
	}
	public String qrcodeOriginal { 
		get {if (this["qrcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["qrcode",DataRowVersion.Original];}
	}
	///<summary>
	///id flusso crediti associato
	///</summary>
	public Int32? idflussocrediti{ 
		get {if (this["idflussocrediti"]==DBNull.Value)return null; return  (Int32?)this["idflussocrediti"];}
		set {if (value==null) this["idflussocrediti"]= DBNull.Value; else this["idflussocrediti"]= value;}
	}
	public object idflussocreditiValue { 
		get{ return this["idflussocrediti"];}
		set {if (value==null|| value==DBNull.Value) this["idflussocrediti"]= DBNull.Value; else this["idflussocrediti"]= value;}
	}
	public Int32? idflussocreditiOriginal { 
		get {if (this["idflussocrediti",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idflussocrediti",DataRowVersion.Original];}
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
	#endregion

}
///<summary>
///Pagamento web
///</summary>
public class webpaymentTable : MetaTableBase<webpaymentRow> {
	public webpaymentTable() : base("webpayment"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idwebpayment",createColumn("idwebpayment",typeof(int),false,false)},
			{"cf",createColumn("cf",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"email",createColumn("email",typeof(string),true,false)},
			{"forename",createColumn("forename",typeof(string),true,false)},
			{"idcustomuser",createColumn("idcustomuser",typeof(string),true,false)},
			{"idlcard",createColumn("idlcard",typeof(int),true,false)},
			{"idman",createColumn("idman",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"nwebpayment",createColumn("nwebpayment",typeof(int),true,false)},
			{"surname",createColumn("surname",typeof(string),true,false)},
			{"ywebpayment",createColumn("ywebpayment",typeof(short),false,false)},
			{"idwebpaymentstatus",createColumn("idwebpaymentstatus",typeof(short),true,false)},
			{"idreg",createColumn("idreg",typeof(int),true,false)},
			{"iuv",createColumn("iuv",typeof(string),true,false)},
			{"qrcode",createColumn("qrcode",typeof(string),true,false)},
			{"idflussocrediti",createColumn("idflussocrediti",typeof(int),true,false)},
			{"adate",createColumn("adate",typeof(DateTime),true,false)},
		};
	}
}
}
