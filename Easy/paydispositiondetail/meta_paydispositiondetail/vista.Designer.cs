
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
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_paydispositiondetail {
public class paydispositiondetailRow: MetaRow  {
	public paydispositiondetailRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 idpaydisposition{ 
		get {return  (Int32)this["idpaydisposition"];}
		set {this["idpaydisposition"]= value;}
	}
	public object idpaydispositionValue { 
		get{ return this["idpaydisposition"];}
		set {this["idpaydisposition"]= value;}
	}
	public Int32 idpaydispositionOriginal { 
		get {return  (Int32)this["idpaydisposition",DataRowVersion.Original];}
	}
	public Int32 iddetail{ 
		get {return  (Int32)this["iddetail"];}
		set {this["iddetail"]= value;}
	}
	public object iddetailValue { 
		get{ return this["iddetail"];}
		set {this["iddetail"]= value;}
	}
	public Int32 iddetailOriginal { 
		get {return  (Int32)this["iddetail",DataRowVersion.Original];}
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
	#endregion

}
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
			{"flag",createColumn("flag",typeof(int),true,false)},
			{"idchargehandling",createColumn("idchargehandling",typeof(int),true,false)},
		};
	}
}
}
