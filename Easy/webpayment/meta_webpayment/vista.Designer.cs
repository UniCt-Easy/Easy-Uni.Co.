/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace meta_webpayment {
public class webpaymentRow: MetaRow  {
	public webpaymentRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32? idwebpayment{ 
		get {if (this["idwebpayment"]==DBNull.Value)return null; return  (Int32?)this["idwebpayment"];}
		set {if (value==null) this["idwebpayment"]= DBNull.Value; else this["idwebpayment"]= value;}
	}
	public object idwebpaymentValue { 
		get{ return this["idwebpayment"];}
		set {if (value==null|| value==DBNull.Value) this["idwebpayment"]= DBNull.Value; else this["idwebpayment"]= value;}
	}
	public Int32? idwebpaymentOriginal { 
		get {if (this["idwebpayment",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idwebpayment",DataRowVersion.Original];}
	}
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
	public Int16? ywebpayment{ 
		get {if (this["ywebpayment"]==DBNull.Value)return null; return  (Int16?)this["ywebpayment"];}
		set {if (value==null) this["ywebpayment"]= DBNull.Value; else this["ywebpayment"]= value;}
	}
	public object ywebpaymentValue { 
		get{ return this["ywebpayment"];}
		set {if (value==null|| value==DBNull.Value) this["ywebpayment"]= DBNull.Value; else this["ywebpayment"]= value;}
	}
	public Int16? ywebpaymentOriginal { 
		get {if (this["ywebpayment",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["ywebpayment",DataRowVersion.Original];}
	}
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
public class webpaymentTable : MetaTableBase<webpaymentRow> {
	public webpaymentTable() : base("webpayment"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idwebpayment",createColumn("idwebpayment",typeof(Int32),false,false)},
			{"cf",createColumn("cf",typeof(String),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(String),true,false)},
			{"email",createColumn("email",typeof(String),true,false)},
			{"forename",createColumn("forename",typeof(String),true,false)},
			{"idcustomuser",createColumn("idcustomuser",typeof(String),true,false)},
			{"idlcard",createColumn("idlcard",typeof(Int32),true,false)},
			{"idman",createColumn("idman",typeof(Int32),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(String),true,false)},
			{"nwebpayment",createColumn("nwebpayment",typeof(Int32),true,false)},
			{"surname",createColumn("surname",typeof(String),true,false)},
			{"ywebpayment",createColumn("ywebpayment",typeof(Int16),false,false)},
			{"idwebpaymentstatus",createColumn("idwebpaymentstatus",typeof(Int16),true,false)},
			{"idreg",createColumn("idreg",typeof(Int32),true,false)},
			{"iuv",createColumn("iuv",typeof(String),true,false)},
			{"qrcode",createColumn("qrcode",typeof(String),true,false)},
			{"idflussocrediti",createColumn("idflussocrediti",typeof(Int32),true,false)},
			{"adate",createColumn("adate",typeof(DateTime),true,false)},
		};
	}
}
}
