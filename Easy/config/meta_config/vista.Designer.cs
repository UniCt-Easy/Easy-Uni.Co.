
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
namespace meta_config {
public class configRow: MetaRow  {
	public configRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int16 ayear{ 
		get {return  (Int16)this["ayear"];}
		set {this["ayear"]= value;}
	}
	public object ayearValue { 
		get{ return this["ayear"];}
		set {this["ayear"]= value;}
	}
	public Int16 ayearOriginal { 
		get {return  (Int16)this["ayear",DataRowVersion.Original];}
	}
	public String agencycode{ 
		get {if (this["agencycode"]==DBNull.Value)return null; return  (String)this["agencycode"];}
		set {if (value==null) this["agencycode"]= DBNull.Value; else this["agencycode"]= value;}
	}
	public object agencycodeValue { 
		get{ return this["agencycode"];}
		set {if (value==null|| value==DBNull.Value) this["agencycode"]= DBNull.Value; else this["agencycode"]= value;}
	}
	public String agencycodeOriginal { 
		get {if (this["agencycode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["agencycode",DataRowVersion.Original];}
	}
	public String appname{ 
		get {if (this["appname"]==DBNull.Value)return null; return  (String)this["appname"];}
		set {if (value==null) this["appname"]= DBNull.Value; else this["appname"]= value;}
	}
	public object appnameValue { 
		get{ return this["appname"];}
		set {if (value==null|| value==DBNull.Value) this["appname"]= DBNull.Value; else this["appname"]= value;}
	}
	public String appnameOriginal { 
		get {if (this["appname",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["appname",DataRowVersion.Original];}
	}
	public Byte? appropriationphasecode{ 
		get {if (this["appropriationphasecode"]==DBNull.Value)return null; return  (Byte?)this["appropriationphasecode"];}
		set {if (value==null) this["appropriationphasecode"]= DBNull.Value; else this["appropriationphasecode"]= value;}
	}
	public object appropriationphasecodeValue { 
		get{ return this["appropriationphasecode"];}
		set {if (value==null|| value==DBNull.Value) this["appropriationphasecode"]= DBNull.Value; else this["appropriationphasecode"]= value;}
	}
	public Byte? appropriationphasecodeOriginal { 
		get {if (this["appropriationphasecode",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["appropriationphasecode",DataRowVersion.Original];}
	}
	public Byte? assessmentphasecode{ 
		get {if (this["assessmentphasecode"]==DBNull.Value)return null; return  (Byte?)this["assessmentphasecode"];}
		set {if (value==null) this["assessmentphasecode"]= DBNull.Value; else this["assessmentphasecode"]= value;}
	}
	public object assessmentphasecodeValue { 
		get{ return this["assessmentphasecode"];}
		set {if (value==null|| value==DBNull.Value) this["assessmentphasecode"]= DBNull.Value; else this["assessmentphasecode"]= value;}
	}
	public Byte? assessmentphasecodeOriginal { 
		get {if (this["assessmentphasecode",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["assessmentphasecode",DataRowVersion.Original];}
	}
	public String asset_flagnumbering{ 
		get {if (this["asset_flagnumbering"]==DBNull.Value)return null; return  (String)this["asset_flagnumbering"];}
		set {if (value==null) this["asset_flagnumbering"]= DBNull.Value; else this["asset_flagnumbering"]= value;}
	}
	public object asset_flagnumberingValue { 
		get{ return this["asset_flagnumbering"];}
		set {if (value==null|| value==DBNull.Value) this["asset_flagnumbering"]= DBNull.Value; else this["asset_flagnumbering"]= value;}
	}
	public String asset_flagnumberingOriginal { 
		get {if (this["asset_flagnumbering",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["asset_flagnumbering",DataRowVersion.Original];}
	}
	public String asset_flagrestart{ 
		get {if (this["asset_flagrestart"]==DBNull.Value)return null; return  (String)this["asset_flagrestart"];}
		set {if (value==null) this["asset_flagrestart"]= DBNull.Value; else this["asset_flagrestart"]= value;}
	}
	public object asset_flagrestartValue { 
		get{ return this["asset_flagrestart"];}
		set {if (value==null|| value==DBNull.Value) this["asset_flagrestart"]= DBNull.Value; else this["asset_flagrestart"]= value;}
	}
	public String asset_flagrestartOriginal { 
		get {if (this["asset_flagrestart",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["asset_flagrestart",DataRowVersion.Original];}
	}
	public Byte? assetload_flag{ 
		get {if (this["assetload_flag"]==DBNull.Value)return null; return  (Byte?)this["assetload_flag"];}
		set {if (value==null) this["assetload_flag"]= DBNull.Value; else this["assetload_flag"]= value;}
	}
	public object assetload_flagValue { 
		get{ return this["assetload_flag"];}
		set {if (value==null|| value==DBNull.Value) this["assetload_flag"]= DBNull.Value; else this["assetload_flag"]= value;}
	}
	public Byte? assetload_flagOriginal { 
		get {if (this["assetload_flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["assetload_flag",DataRowVersion.Original];}
	}
	public String boxpartitiontitle{ 
		get {if (this["boxpartitiontitle"]==DBNull.Value)return null; return  (String)this["boxpartitiontitle"];}
		set {if (value==null) this["boxpartitiontitle"]= DBNull.Value; else this["boxpartitiontitle"]= value;}
	}
	public object boxpartitiontitleValue { 
		get{ return this["boxpartitiontitle"];}
		set {if (value==null|| value==DBNull.Value) this["boxpartitiontitle"]= DBNull.Value; else this["boxpartitiontitle"]= value;}
	}
	public String boxpartitiontitleOriginal { 
		get {if (this["boxpartitiontitle",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["boxpartitiontitle",DataRowVersion.Original];}
	}
	public String finvarofficial_default{ 
		get {if (this["finvarofficial_default"]==DBNull.Value)return null; return  (String)this["finvarofficial_default"];}
		set {if (value==null) this["finvarofficial_default"]= DBNull.Value; else this["finvarofficial_default"]= value;}
	}
	public object finvarofficial_defaultValue { 
		get{ return this["finvarofficial_default"];}
		set {if (value==null|| value==DBNull.Value) this["finvarofficial_default"]= DBNull.Value; else this["finvarofficial_default"]= value;}
	}
	public String finvarofficial_defaultOriginal { 
		get {if (this["finvarofficial_default",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["finvarofficial_default",DataRowVersion.Original];}
	}
	public String casualcontract_flagrestart{ 
		get {if (this["casualcontract_flagrestart"]==DBNull.Value)return null; return  (String)this["casualcontract_flagrestart"];}
		set {if (value==null) this["casualcontract_flagrestart"]= DBNull.Value; else this["casualcontract_flagrestart"]= value;}
	}
	public object casualcontract_flagrestartValue { 
		get{ return this["casualcontract_flagrestart"];}
		set {if (value==null|| value==DBNull.Value) this["casualcontract_flagrestart"]= DBNull.Value; else this["casualcontract_flagrestart"]= value;}
	}
	public String casualcontract_flagrestartOriginal { 
		get {if (this["casualcontract_flagrestart",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["casualcontract_flagrestart",DataRowVersion.Original];}
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
	public String currpartitiontitle{ 
		get {if (this["currpartitiontitle"]==DBNull.Value)return null; return  (String)this["currpartitiontitle"];}
		set {if (value==null) this["currpartitiontitle"]= DBNull.Value; else this["currpartitiontitle"]= value;}
	}
	public object currpartitiontitleValue { 
		get{ return this["currpartitiontitle"];}
		set {if (value==null|| value==DBNull.Value) this["currpartitiontitle"]= DBNull.Value; else this["currpartitiontitle"]= value;}
	}
	public String currpartitiontitleOriginal { 
		get {if (this["currpartitiontitle",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["currpartitiontitle",DataRowVersion.Original];}
	}
	public String deferredexpensephase{ 
		get {if (this["deferredexpensephase"]==DBNull.Value)return null; return  (String)this["deferredexpensephase"];}
		set {if (value==null) this["deferredexpensephase"]= DBNull.Value; else this["deferredexpensephase"]= value;}
	}
	public object deferredexpensephaseValue { 
		get{ return this["deferredexpensephase"];}
		set {if (value==null|| value==DBNull.Value) this["deferredexpensephase"]= DBNull.Value; else this["deferredexpensephase"]= value;}
	}
	public String deferredexpensephaseOriginal { 
		get {if (this["deferredexpensephase",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["deferredexpensephase",DataRowVersion.Original];}
	}
	public String deferredincomephase{ 
		get {if (this["deferredincomephase"]==DBNull.Value)return null; return  (String)this["deferredincomephase"];}
		set {if (value==null) this["deferredincomephase"]= DBNull.Value; else this["deferredincomephase"]= value;}
	}
	public object deferredincomephaseValue { 
		get{ return this["deferredincomephase"];}
		set {if (value==null|| value==DBNull.Value) this["deferredincomephase"]= DBNull.Value; else this["deferredincomephase"]= value;}
	}
	public String deferredincomephaseOriginal { 
		get {if (this["deferredincomephase",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["deferredincomephase",DataRowVersion.Original];}
	}
	public String electronicimport{ 
		get {if (this["electronicimport"]==DBNull.Value)return null; return  (String)this["electronicimport"];}
		set {if (value==null) this["electronicimport"]= DBNull.Value; else this["electronicimport"]= value;}
	}
	public object electronicimportValue { 
		get{ return this["electronicimport"];}
		set {if (value==null|| value==DBNull.Value) this["electronicimport"]= DBNull.Value; else this["electronicimport"]= value;}
	}
	public String electronicimportOriginal { 
		get {if (this["electronicimport",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["electronicimport",DataRowVersion.Original];}
	}
	public String electronictrasmission{ 
		get {if (this["electronictrasmission"]==DBNull.Value)return null; return  (String)this["electronictrasmission"];}
		set {if (value==null) this["electronictrasmission"]= DBNull.Value; else this["electronictrasmission"]= value;}
	}
	public object electronictrasmissionValue { 
		get{ return this["electronictrasmission"];}
		set {if (value==null|| value==DBNull.Value) this["electronictrasmission"]= DBNull.Value; else this["electronictrasmission"]= value;}
	}
	public String electronictrasmissionOriginal { 
		get {if (this["electronictrasmission",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["electronictrasmission",DataRowVersion.Original];}
	}
	public Int16? expense_expiringdays{ 
		get {if (this["expense_expiringdays"]==DBNull.Value)return null; return  (Int16?)this["expense_expiringdays"];}
		set {if (value==null) this["expense_expiringdays"]= DBNull.Value; else this["expense_expiringdays"]= value;}
	}
	public object expense_expiringdaysValue { 
		get{ return this["expense_expiringdays"];}
		set {if (value==null|| value==DBNull.Value) this["expense_expiringdays"]= DBNull.Value; else this["expense_expiringdays"]= value;}
	}
	public Int16? expense_expiringdaysOriginal { 
		get {if (this["expense_expiringdays",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["expense_expiringdays",DataRowVersion.Original];}
	}
	public Byte? expensephase{ 
		get {if (this["expensephase"]==DBNull.Value)return null; return  (Byte?)this["expensephase"];}
		set {if (value==null) this["expensephase"]= DBNull.Value; else this["expensephase"]= value;}
	}
	public object expensephaseValue { 
		get{ return this["expensephase"];}
		set {if (value==null|| value==DBNull.Value) this["expensephase"]= DBNull.Value; else this["expensephase"]= value;}
	}
	public Byte? expensephaseOriginal { 
		get {if (this["expensephase",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["expensephase",DataRowVersion.Original];}
	}
	public String flagautopayment{ 
		get {if (this["flagautopayment"]==DBNull.Value)return null; return  (String)this["flagautopayment"];}
		set {if (value==null) this["flagautopayment"]= DBNull.Value; else this["flagautopayment"]= value;}
	}
	public object flagautopaymentValue { 
		get{ return this["flagautopayment"];}
		set {if (value==null|| value==DBNull.Value) this["flagautopayment"]= DBNull.Value; else this["flagautopayment"]= value;}
	}
	public String flagautopaymentOriginal { 
		get {if (this["flagautopayment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagautopayment",DataRowVersion.Original];}
	}
	public String flagautoproceeds{ 
		get {if (this["flagautoproceeds"]==DBNull.Value)return null; return  (String)this["flagautoproceeds"];}
		set {if (value==null) this["flagautoproceeds"]= DBNull.Value; else this["flagautoproceeds"]= value;}
	}
	public object flagautoproceedsValue { 
		get{ return this["flagautoproceeds"];}
		set {if (value==null|| value==DBNull.Value) this["flagautoproceeds"]= DBNull.Value; else this["flagautoproceeds"]= value;}
	}
	public String flagautoproceedsOriginal { 
		get {if (this["flagautoproceeds",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagautoproceeds",DataRowVersion.Original];}
	}
	public String flagcredit{ 
		get {if (this["flagcredit"]==DBNull.Value)return null; return  (String)this["flagcredit"];}
		set {if (value==null) this["flagcredit"]= DBNull.Value; else this["flagcredit"]= value;}
	}
	public object flagcreditValue { 
		get{ return this["flagcredit"];}
		set {if (value==null|| value==DBNull.Value) this["flagcredit"]= DBNull.Value; else this["flagcredit"]= value;}
	}
	public String flagcreditOriginal { 
		get {if (this["flagcredit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagcredit",DataRowVersion.Original];}
	}
	public String flagepexp{ 
		get {if (this["flagepexp"]==DBNull.Value)return null; return  (String)this["flagepexp"];}
		set {if (value==null) this["flagepexp"]= DBNull.Value; else this["flagepexp"]= value;}
	}
	public object flagepexpValue { 
		get{ return this["flagepexp"];}
		set {if (value==null|| value==DBNull.Value) this["flagepexp"]= DBNull.Value; else this["flagepexp"]= value;}
	}
	public String flagepexpOriginal { 
		get {if (this["flagepexp",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagepexp",DataRowVersion.Original];}
	}
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
	public String flagpayment{ 
		get {if (this["flagpayment"]==DBNull.Value)return null; return  (String)this["flagpayment"];}
		set {if (value==null) this["flagpayment"]= DBNull.Value; else this["flagpayment"]= value;}
	}
	public object flagpaymentValue { 
		get{ return this["flagpayment"];}
		set {if (value==null|| value==DBNull.Value) this["flagpayment"]= DBNull.Value; else this["flagpayment"]= value;}
	}
	public String flagpaymentOriginal { 
		get {if (this["flagpayment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagpayment",DataRowVersion.Original];}
	}
	public String flagproceeds{ 
		get {if (this["flagproceeds"]==DBNull.Value)return null; return  (String)this["flagproceeds"];}
		set {if (value==null) this["flagproceeds"]= DBNull.Value; else this["flagproceeds"]= value;}
	}
	public object flagproceedsValue { 
		get{ return this["flagproceeds"];}
		set {if (value==null|| value==DBNull.Value) this["flagproceeds"]= DBNull.Value; else this["flagproceeds"]= value;}
	}
	public String flagproceedsOriginal { 
		get {if (this["flagproceeds",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagproceeds",DataRowVersion.Original];}
	}
	public String flagrefund{ 
		get {if (this["flagrefund"]==DBNull.Value)return null; return  (String)this["flagrefund"];}
		set {if (value==null) this["flagrefund"]= DBNull.Value; else this["flagrefund"]= value;}
	}
	public object flagrefundValue { 
		get{ return this["flagrefund"];}
		set {if (value==null|| value==DBNull.Value) this["flagrefund"]= DBNull.Value; else this["flagrefund"]= value;}
	}
	public String flagrefundOriginal { 
		get {if (this["flagrefund",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagrefund",DataRowVersion.Original];}
	}
	public Int32? foreignhours{ 
		get {if (this["foreignhours"]==DBNull.Value)return null; return  (Int32?)this["foreignhours"];}
		set {if (value==null) this["foreignhours"]= DBNull.Value; else this["foreignhours"]= value;}
	}
	public object foreignhoursValue { 
		get{ return this["foreignhours"];}
		set {if (value==null|| value==DBNull.Value) this["foreignhours"]= DBNull.Value; else this["foreignhours"]= value;}
	}
	public Int32? foreignhoursOriginal { 
		get {if (this["foreignhours",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["foreignhours",DataRowVersion.Original];}
	}
	public String idacc_accruedcost{ 
		get {if (this["idacc_accruedcost"]==DBNull.Value)return null; return  (String)this["idacc_accruedcost"];}
		set {if (value==null) this["idacc_accruedcost"]= DBNull.Value; else this["idacc_accruedcost"]= value;}
	}
	public object idacc_accruedcostValue { 
		get{ return this["idacc_accruedcost"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_accruedcost"]= DBNull.Value; else this["idacc_accruedcost"]= value;}
	}
	public String idacc_accruedcostOriginal { 
		get {if (this["idacc_accruedcost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_accruedcost",DataRowVersion.Original];}
	}
	public String idacc_accruedrevenue{ 
		get {if (this["idacc_accruedrevenue"]==DBNull.Value)return null; return  (String)this["idacc_accruedrevenue"];}
		set {if (value==null) this["idacc_accruedrevenue"]= DBNull.Value; else this["idacc_accruedrevenue"]= value;}
	}
	public object idacc_accruedrevenueValue { 
		get{ return this["idacc_accruedrevenue"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_accruedrevenue"]= DBNull.Value; else this["idacc_accruedrevenue"]= value;}
	}
	public String idacc_accruedrevenueOriginal { 
		get {if (this["idacc_accruedrevenue",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_accruedrevenue",DataRowVersion.Original];}
	}
	public String idacc_customer{ 
		get {if (this["idacc_customer"]==DBNull.Value)return null; return  (String)this["idacc_customer"];}
		set {if (value==null) this["idacc_customer"]= DBNull.Value; else this["idacc_customer"]= value;}
	}
	public object idacc_customerValue { 
		get{ return this["idacc_customer"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_customer"]= DBNull.Value; else this["idacc_customer"]= value;}
	}
	public String idacc_customerOriginal { 
		get {if (this["idacc_customer",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_customer",DataRowVersion.Original];}
	}
	public String idacc_deferredcost{ 
		get {if (this["idacc_deferredcost"]==DBNull.Value)return null; return  (String)this["idacc_deferredcost"];}
		set {if (value==null) this["idacc_deferredcost"]= DBNull.Value; else this["idacc_deferredcost"]= value;}
	}
	public object idacc_deferredcostValue { 
		get{ return this["idacc_deferredcost"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_deferredcost"]= DBNull.Value; else this["idacc_deferredcost"]= value;}
	}
	public String idacc_deferredcostOriginal { 
		get {if (this["idacc_deferredcost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_deferredcost",DataRowVersion.Original];}
	}
	public String idacc_deferredcredit{ 
		get {if (this["idacc_deferredcredit"]==DBNull.Value)return null; return  (String)this["idacc_deferredcredit"];}
		set {if (value==null) this["idacc_deferredcredit"]= DBNull.Value; else this["idacc_deferredcredit"]= value;}
	}
	public object idacc_deferredcreditValue { 
		get{ return this["idacc_deferredcredit"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_deferredcredit"]= DBNull.Value; else this["idacc_deferredcredit"]= value;}
	}
	public String idacc_deferredcreditOriginal { 
		get {if (this["idacc_deferredcredit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_deferredcredit",DataRowVersion.Original];}
	}
	public String idacc_deferreddebit{ 
		get {if (this["idacc_deferreddebit"]==DBNull.Value)return null; return  (String)this["idacc_deferreddebit"];}
		set {if (value==null) this["idacc_deferreddebit"]= DBNull.Value; else this["idacc_deferreddebit"]= value;}
	}
	public object idacc_deferreddebitValue { 
		get{ return this["idacc_deferreddebit"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_deferreddebit"]= DBNull.Value; else this["idacc_deferreddebit"]= value;}
	}
	public String idacc_deferreddebitOriginal { 
		get {if (this["idacc_deferreddebit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_deferreddebit",DataRowVersion.Original];}
	}
	public String idacc_deferredrevenue{ 
		get {if (this["idacc_deferredrevenue"]==DBNull.Value)return null; return  (String)this["idacc_deferredrevenue"];}
		set {if (value==null) this["idacc_deferredrevenue"]= DBNull.Value; else this["idacc_deferredrevenue"]= value;}
	}
	public object idacc_deferredrevenueValue { 
		get{ return this["idacc_deferredrevenue"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_deferredrevenue"]= DBNull.Value; else this["idacc_deferredrevenue"]= value;}
	}
	public String idacc_deferredrevenueOriginal { 
		get {if (this["idacc_deferredrevenue",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_deferredrevenue",DataRowVersion.Original];}
	}
	public String idacc_ivapayment{ 
		get {if (this["idacc_ivapayment"]==DBNull.Value)return null; return  (String)this["idacc_ivapayment"];}
		set {if (value==null) this["idacc_ivapayment"]= DBNull.Value; else this["idacc_ivapayment"]= value;}
	}
	public object idacc_ivapaymentValue { 
		get{ return this["idacc_ivapayment"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_ivapayment"]= DBNull.Value; else this["idacc_ivapayment"]= value;}
	}
	public String idacc_ivapaymentOriginal { 
		get {if (this["idacc_ivapayment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_ivapayment",DataRowVersion.Original];}
	}
	public String idacc_ivarefund{ 
		get {if (this["idacc_ivarefund"]==DBNull.Value)return null; return  (String)this["idacc_ivarefund"];}
		set {if (value==null) this["idacc_ivarefund"]= DBNull.Value; else this["idacc_ivarefund"]= value;}
	}
	public object idacc_ivarefundValue { 
		get{ return this["idacc_ivarefund"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_ivarefund"]= DBNull.Value; else this["idacc_ivarefund"]= value;}
	}
	public String idacc_ivarefundOriginal { 
		get {if (this["idacc_ivarefund",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_ivarefund",DataRowVersion.Original];}
	}
	public String idacc_patrimony{ 
		get {if (this["idacc_patrimony"]==DBNull.Value)return null; return  (String)this["idacc_patrimony"];}
		set {if (value==null) this["idacc_patrimony"]= DBNull.Value; else this["idacc_patrimony"]= value;}
	}
	public object idacc_patrimonyValue { 
		get{ return this["idacc_patrimony"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_patrimony"]= DBNull.Value; else this["idacc_patrimony"]= value;}
	}
	public String idacc_patrimonyOriginal { 
		get {if (this["idacc_patrimony",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_patrimony",DataRowVersion.Original];}
	}
	public String idacc_pl{ 
		get {if (this["idacc_pl"]==DBNull.Value)return null; return  (String)this["idacc_pl"];}
		set {if (value==null) this["idacc_pl"]= DBNull.Value; else this["idacc_pl"]= value;}
	}
	public object idacc_plValue { 
		get{ return this["idacc_pl"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_pl"]= DBNull.Value; else this["idacc_pl"]= value;}
	}
	public String idacc_plOriginal { 
		get {if (this["idacc_pl",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_pl",DataRowVersion.Original];}
	}
	public String idacc_supplier{ 
		get {if (this["idacc_supplier"]==DBNull.Value)return null; return  (String)this["idacc_supplier"];}
		set {if (value==null) this["idacc_supplier"]= DBNull.Value; else this["idacc_supplier"]= value;}
	}
	public object idacc_supplierValue { 
		get{ return this["idacc_supplier"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_supplier"]= DBNull.Value; else this["idacc_supplier"]= value;}
	}
	public String idacc_supplierOriginal { 
		get {if (this["idacc_supplier",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_supplier",DataRowVersion.Original];}
	}
	public String idaccmotive_admincar{ 
		get {if (this["idaccmotive_admincar"]==DBNull.Value)return null; return  (String)this["idaccmotive_admincar"];}
		set {if (value==null) this["idaccmotive_admincar"]= DBNull.Value; else this["idaccmotive_admincar"]= value;}
	}
	public object idaccmotive_admincarValue { 
		get{ return this["idaccmotive_admincar"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive_admincar"]= DBNull.Value; else this["idaccmotive_admincar"]= value;}
	}
	public String idaccmotive_admincarOriginal { 
		get {if (this["idaccmotive_admincar",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive_admincar",DataRowVersion.Original];}
	}
	public String idaccmotive_foot{ 
		get {if (this["idaccmotive_foot"]==DBNull.Value)return null; return  (String)this["idaccmotive_foot"];}
		set {if (value==null) this["idaccmotive_foot"]= DBNull.Value; else this["idaccmotive_foot"]= value;}
	}
	public object idaccmotive_footValue { 
		get{ return this["idaccmotive_foot"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive_foot"]= DBNull.Value; else this["idaccmotive_foot"]= value;}
	}
	public String idaccmotive_footOriginal { 
		get {if (this["idaccmotive_foot",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive_foot",DataRowVersion.Original];}
	}
	public String idaccmotive_owncar{ 
		get {if (this["idaccmotive_owncar"]==DBNull.Value)return null; return  (String)this["idaccmotive_owncar"];}
		set {if (value==null) this["idaccmotive_owncar"]= DBNull.Value; else this["idaccmotive_owncar"]= value;}
	}
	public object idaccmotive_owncarValue { 
		get{ return this["idaccmotive_owncar"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive_owncar"]= DBNull.Value; else this["idaccmotive_owncar"]= value;}
	}
	public String idaccmotive_owncarOriginal { 
		get {if (this["idaccmotive_owncar",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive_owncar",DataRowVersion.Original];}
	}
	public Int32? idclawback{ 
		get {if (this["idclawback"]==DBNull.Value)return null; return  (Int32?)this["idclawback"];}
		set {if (value==null) this["idclawback"]= DBNull.Value; else this["idclawback"]= value;}
	}
	public object idclawbackValue { 
		get{ return this["idclawback"];}
		set {if (value==null|| value==DBNull.Value) this["idclawback"]= DBNull.Value; else this["idclawback"]= value;}
	}
	public Int32? idclawbackOriginal { 
		get {if (this["idclawback",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idclawback",DataRowVersion.Original];}
	}
	public Int32? idfinexpense{ 
		get {if (this["idfinexpense"]==DBNull.Value)return null; return  (Int32?)this["idfinexpense"];}
		set {if (value==null) this["idfinexpense"]= DBNull.Value; else this["idfinexpense"]= value;}
	}
	public object idfinexpenseValue { 
		get{ return this["idfinexpense"];}
		set {if (value==null|| value==DBNull.Value) this["idfinexpense"]= DBNull.Value; else this["idfinexpense"]= value;}
	}
	public Int32? idfinexpenseOriginal { 
		get {if (this["idfinexpense",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idfinexpense",DataRowVersion.Original];}
	}
	public Int32? idfinexpensesurplus{ 
		get {if (this["idfinexpensesurplus"]==DBNull.Value)return null; return  (Int32?)this["idfinexpensesurplus"];}
		set {if (value==null) this["idfinexpensesurplus"]= DBNull.Value; else this["idfinexpensesurplus"]= value;}
	}
	public object idfinexpensesurplusValue { 
		get{ return this["idfinexpensesurplus"];}
		set {if (value==null|| value==DBNull.Value) this["idfinexpensesurplus"]= DBNull.Value; else this["idfinexpensesurplus"]= value;}
	}
	public Int32? idfinexpensesurplusOriginal { 
		get {if (this["idfinexpensesurplus",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idfinexpensesurplus",DataRowVersion.Original];}
	}
	public Int32? idfinincomesurplus{ 
		get {if (this["idfinincomesurplus"]==DBNull.Value)return null; return  (Int32?)this["idfinincomesurplus"];}
		set {if (value==null) this["idfinincomesurplus"]= DBNull.Value; else this["idfinincomesurplus"]= value;}
	}
	public object idfinincomesurplusValue { 
		get{ return this["idfinincomesurplus"];}
		set {if (value==null|| value==DBNull.Value) this["idfinincomesurplus"]= DBNull.Value; else this["idfinincomesurplus"]= value;}
	}
	public Int32? idfinincomesurplusOriginal { 
		get {if (this["idfinincomesurplus",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idfinincomesurplus",DataRowVersion.Original];}
	}
	public Int32? idfinivapayment{ 
		get {if (this["idfinivapayment"]==DBNull.Value)return null; return  (Int32?)this["idfinivapayment"];}
		set {if (value==null) this["idfinivapayment"]= DBNull.Value; else this["idfinivapayment"]= value;}
	}
	public object idfinivapaymentValue { 
		get{ return this["idfinivapayment"];}
		set {if (value==null|| value==DBNull.Value) this["idfinivapayment"]= DBNull.Value; else this["idfinivapayment"]= value;}
	}
	public Int32? idfinivapaymentOriginal { 
		get {if (this["idfinivapayment",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idfinivapayment",DataRowVersion.Original];}
	}
	public Int32? idfinivarefund{ 
		get {if (this["idfinivarefund"]==DBNull.Value)return null; return  (Int32?)this["idfinivarefund"];}
		set {if (value==null) this["idfinivarefund"]= DBNull.Value; else this["idfinivarefund"]= value;}
	}
	public object idfinivarefundValue { 
		get{ return this["idfinivarefund"];}
		set {if (value==null|| value==DBNull.Value) this["idfinivarefund"]= DBNull.Value; else this["idfinivarefund"]= value;}
	}
	public Int32? idfinivarefundOriginal { 
		get {if (this["idfinivarefund",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idfinivarefund",DataRowVersion.Original];}
	}
	public Int32? idregauto{ 
		get {if (this["idregauto"]==DBNull.Value)return null; return  (Int32?)this["idregauto"];}
		set {if (value==null) this["idregauto"]= DBNull.Value; else this["idregauto"]= value;}
	}
	public object idregautoValue { 
		get{ return this["idregauto"];}
		set {if (value==null|| value==DBNull.Value) this["idregauto"]= DBNull.Value; else this["idregauto"]= value;}
	}
	public Int32? idregautoOriginal { 
		get {if (this["idregauto",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idregauto",DataRowVersion.Original];}
	}
	public String importappname{ 
		get {if (this["importappname"]==DBNull.Value)return null; return  (String)this["importappname"];}
		set {if (value==null) this["importappname"]= DBNull.Value; else this["importappname"]= value;}
	}
	public object importappnameValue { 
		get{ return this["importappname"];}
		set {if (value==null|| value==DBNull.Value) this["importappname"]= DBNull.Value; else this["importappname"]= value;}
	}
	public String importappnameOriginal { 
		get {if (this["importappname",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["importappname",DataRowVersion.Original];}
	}
	public Int16? income_expiringdays{ 
		get {if (this["income_expiringdays"]==DBNull.Value)return null; return  (Int16?)this["income_expiringdays"];}
		set {if (value==null) this["income_expiringdays"]= DBNull.Value; else this["income_expiringdays"]= value;}
	}
	public object income_expiringdaysValue { 
		get{ return this["income_expiringdays"];}
		set {if (value==null|| value==DBNull.Value) this["income_expiringdays"]= DBNull.Value; else this["income_expiringdays"]= value;}
	}
	public Int16? income_expiringdaysOriginal { 
		get {if (this["income_expiringdays",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["income_expiringdays",DataRowVersion.Original];}
	}
	public Byte? incomephase{ 
		get {if (this["incomephase"]==DBNull.Value)return null; return  (Byte?)this["incomephase"];}
		set {if (value==null) this["incomephase"]= DBNull.Value; else this["incomephase"]= value;}
	}
	public object incomephaseValue { 
		get{ return this["incomephase"];}
		set {if (value==null|| value==DBNull.Value) this["incomephase"]= DBNull.Value; else this["incomephase"]= value;}
	}
	public Byte? incomephaseOriginal { 
		get {if (this["incomephase",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["incomephase",DataRowVersion.Original];}
	}
	public String linktoinvoice{ 
		get {if (this["linktoinvoice"]==DBNull.Value)return null; return  (String)this["linktoinvoice"];}
		set {if (value==null) this["linktoinvoice"]= DBNull.Value; else this["linktoinvoice"]= value;}
	}
	public object linktoinvoiceValue { 
		get{ return this["linktoinvoice"];}
		set {if (value==null|| value==DBNull.Value) this["linktoinvoice"]= DBNull.Value; else this["linktoinvoice"]= value;}
	}
	public String linktoinvoiceOriginal { 
		get {if (this["linktoinvoice",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["linktoinvoice",DataRowVersion.Original];}
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
	public Decimal? minpayment{ 
		get {if (this["minpayment"]==DBNull.Value)return null; return  (Decimal?)this["minpayment"];}
		set {if (value==null) this["minpayment"]= DBNull.Value; else this["minpayment"]= value;}
	}
	public object minpaymentValue { 
		get{ return this["minpayment"];}
		set {if (value==null|| value==DBNull.Value) this["minpayment"]= DBNull.Value; else this["minpayment"]= value;}
	}
	public Decimal? minpaymentOriginal { 
		get {if (this["minpayment",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["minpayment",DataRowVersion.Original];}
	}
	public Decimal? minrefund{ 
		get {if (this["minrefund"]==DBNull.Value)return null; return  (Decimal?)this["minrefund"];}
		set {if (value==null) this["minrefund"]= DBNull.Value; else this["minrefund"]= value;}
	}
	public object minrefundValue { 
		get{ return this["minrefund"];}
		set {if (value==null|| value==DBNull.Value) this["minrefund"]= DBNull.Value; else this["minrefund"]= value;}
	}
	public Decimal? minrefundOriginal { 
		get {if (this["minrefund",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["minrefund",DataRowVersion.Original];}
	}
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
	public Byte? payment_finlevel{ 
		get {if (this["payment_finlevel"]==DBNull.Value)return null; return  (Byte?)this["payment_finlevel"];}
		set {if (value==null) this["payment_finlevel"]= DBNull.Value; else this["payment_finlevel"]= value;}
	}
	public object payment_finlevelValue { 
		get{ return this["payment_finlevel"];}
		set {if (value==null|| value==DBNull.Value) this["payment_finlevel"]= DBNull.Value; else this["payment_finlevel"]= value;}
	}
	public Byte? payment_finlevelOriginal { 
		get {if (this["payment_finlevel",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["payment_finlevel",DataRowVersion.Original];}
	}
	public Byte? payment_flag{ 
		get {if (this["payment_flag"]==DBNull.Value)return null; return  (Byte?)this["payment_flag"];}
		set {if (value==null) this["payment_flag"]= DBNull.Value; else this["payment_flag"]= value;}
	}
	public object payment_flagValue { 
		get{ return this["payment_flag"];}
		set {if (value==null|| value==DBNull.Value) this["payment_flag"]= DBNull.Value; else this["payment_flag"]= value;}
	}
	public Byte? payment_flagOriginal { 
		get {if (this["payment_flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["payment_flag",DataRowVersion.Original];}
	}
	public String payment_flagautoprintdate{ 
		get {if (this["payment_flagautoprintdate"]==DBNull.Value)return null; return  (String)this["payment_flagautoprintdate"];}
		set {if (value==null) this["payment_flagautoprintdate"]= DBNull.Value; else this["payment_flagautoprintdate"]= value;}
	}
	public object payment_flagautoprintdateValue { 
		get{ return this["payment_flagautoprintdate"];}
		set {if (value==null|| value==DBNull.Value) this["payment_flagautoprintdate"]= DBNull.Value; else this["payment_flagautoprintdate"]= value;}
	}
	public String payment_flagautoprintdateOriginal { 
		get {if (this["payment_flagautoprintdate",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["payment_flagautoprintdate",DataRowVersion.Original];}
	}
	public Int32? paymentagency{ 
		get {if (this["paymentagency"]==DBNull.Value)return null; return  (Int32?)this["paymentagency"];}
		set {if (value==null) this["paymentagency"]= DBNull.Value; else this["paymentagency"]= value;}
	}
	public object paymentagencyValue { 
		get{ return this["paymentagency"];}
		set {if (value==null|| value==DBNull.Value) this["paymentagency"]= DBNull.Value; else this["paymentagency"]= value;}
	}
	public Int32? paymentagencyOriginal { 
		get {if (this["paymentagency",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["paymentagency",DataRowVersion.Original];}
	}
	public String prevpartitiontitle{ 
		get {if (this["prevpartitiontitle"]==DBNull.Value)return null; return  (String)this["prevpartitiontitle"];}
		set {if (value==null) this["prevpartitiontitle"]= DBNull.Value; else this["prevpartitiontitle"]= value;}
	}
	public object prevpartitiontitleValue { 
		get{ return this["prevpartitiontitle"];}
		set {if (value==null|| value==DBNull.Value) this["prevpartitiontitle"]= DBNull.Value; else this["prevpartitiontitle"]= value;}
	}
	public String prevpartitiontitleOriginal { 
		get {if (this["prevpartitiontitle",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["prevpartitiontitle",DataRowVersion.Original];}
	}
	public Byte? proceeds_finlevel{ 
		get {if (this["proceeds_finlevel"]==DBNull.Value)return null; return  (Byte?)this["proceeds_finlevel"];}
		set {if (value==null) this["proceeds_finlevel"]= DBNull.Value; else this["proceeds_finlevel"]= value;}
	}
	public object proceeds_finlevelValue { 
		get{ return this["proceeds_finlevel"];}
		set {if (value==null|| value==DBNull.Value) this["proceeds_finlevel"]= DBNull.Value; else this["proceeds_finlevel"]= value;}
	}
	public Byte? proceeds_finlevelOriginal { 
		get {if (this["proceeds_finlevel",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["proceeds_finlevel",DataRowVersion.Original];}
	}
	public Byte? proceeds_flag{ 
		get {if (this["proceeds_flag"]==DBNull.Value)return null; return  (Byte?)this["proceeds_flag"];}
		set {if (value==null) this["proceeds_flag"]= DBNull.Value; else this["proceeds_flag"]= value;}
	}
	public object proceeds_flagValue { 
		get{ return this["proceeds_flag"];}
		set {if (value==null|| value==DBNull.Value) this["proceeds_flag"]= DBNull.Value; else this["proceeds_flag"]= value;}
	}
	public Byte? proceeds_flagOriginal { 
		get {if (this["proceeds_flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["proceeds_flag",DataRowVersion.Original];}
	}
	public String proceeds_flagautoprintdate{ 
		get {if (this["proceeds_flagautoprintdate"]==DBNull.Value)return null; return  (String)this["proceeds_flagautoprintdate"];}
		set {if (value==null) this["proceeds_flagautoprintdate"]= DBNull.Value; else this["proceeds_flagautoprintdate"]= value;}
	}
	public object proceeds_flagautoprintdateValue { 
		get{ return this["proceeds_flagautoprintdate"];}
		set {if (value==null|| value==DBNull.Value) this["proceeds_flagautoprintdate"]= DBNull.Value; else this["proceeds_flagautoprintdate"]= value;}
	}
	public String proceeds_flagautoprintdateOriginal { 
		get {if (this["proceeds_flagautoprintdate",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["proceeds_flagautoprintdate",DataRowVersion.Original];}
	}
	public String profservice_flagrestart{ 
		get {if (this["profservice_flagrestart"]==DBNull.Value)return null; return  (String)this["profservice_flagrestart"];}
		set {if (value==null) this["profservice_flagrestart"]= DBNull.Value; else this["profservice_flagrestart"]= value;}
	}
	public object profservice_flagrestartValue { 
		get{ return this["profservice_flagrestart"];}
		set {if (value==null|| value==DBNull.Value) this["profservice_flagrestart"]= DBNull.Value; else this["profservice_flagrestart"]= value;}
	}
	public String profservice_flagrestartOriginal { 
		get {if (this["profservice_flagrestart",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["profservice_flagrestart",DataRowVersion.Original];}
	}
	public Int32? refundagency{ 
		get {if (this["refundagency"]==DBNull.Value)return null; return  (Int32?)this["refundagency"];}
		set {if (value==null) this["refundagency"]= DBNull.Value; else this["refundagency"]= value;}
	}
	public object refundagencyValue { 
		get{ return this["refundagency"];}
		set {if (value==null|| value==DBNull.Value) this["refundagency"]= DBNull.Value; else this["refundagency"]= value;}
	}
	public Int32? refundagencyOriginal { 
		get {if (this["refundagency",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["refundagency",DataRowVersion.Original];}
	}
	public String wageaddition_flagrestart{ 
		get {if (this["wageaddition_flagrestart"]==DBNull.Value)return null; return  (String)this["wageaddition_flagrestart"];}
		set {if (value==null) this["wageaddition_flagrestart"]= DBNull.Value; else this["wageaddition_flagrestart"]= value;}
	}
	public object wageaddition_flagrestartValue { 
		get{ return this["wageaddition_flagrestart"];}
		set {if (value==null|| value==DBNull.Value) this["wageaddition_flagrestart"]= DBNull.Value; else this["wageaddition_flagrestart"]= value;}
	}
	public String wageaddition_flagrestartOriginal { 
		get {if (this["wageaddition_flagrestart",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["wageaddition_flagrestart",DataRowVersion.Original];}
	}
	public Int32? idivapayperiodicity{ 
		get {if (this["idivapayperiodicity"]==DBNull.Value)return null; return  (Int32?)this["idivapayperiodicity"];}
		set {if (value==null) this["idivapayperiodicity"]= DBNull.Value; else this["idivapayperiodicity"]= value;}
	}
	public object idivapayperiodicityValue { 
		get{ return this["idivapayperiodicity"];}
		set {if (value==null|| value==DBNull.Value) this["idivapayperiodicity"]= DBNull.Value; else this["idivapayperiodicity"]= value;}
	}
	public Int32? idivapayperiodicityOriginal { 
		get {if (this["idivapayperiodicity",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idivapayperiodicity",DataRowVersion.Original];}
	}
	public Int32? idsortingkind1{ 
		get {if (this["idsortingkind1"]==DBNull.Value)return null; return  (Int32?)this["idsortingkind1"];}
		set {if (value==null) this["idsortingkind1"]= DBNull.Value; else this["idsortingkind1"]= value;}
	}
	public object idsortingkind1Value { 
		get{ return this["idsortingkind1"];}
		set {if (value==null|| value==DBNull.Value) this["idsortingkind1"]= DBNull.Value; else this["idsortingkind1"]= value;}
	}
	public Int32? idsortingkind1Original { 
		get {if (this["idsortingkind1",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsortingkind1",DataRowVersion.Original];}
	}
	public Int32? idsortingkind2{ 
		get {if (this["idsortingkind2"]==DBNull.Value)return null; return  (Int32?)this["idsortingkind2"];}
		set {if (value==null) this["idsortingkind2"]= DBNull.Value; else this["idsortingkind2"]= value;}
	}
	public object idsortingkind2Value { 
		get{ return this["idsortingkind2"];}
		set {if (value==null|| value==DBNull.Value) this["idsortingkind2"]= DBNull.Value; else this["idsortingkind2"]= value;}
	}
	public Int32? idsortingkind2Original { 
		get {if (this["idsortingkind2",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsortingkind2",DataRowVersion.Original];}
	}
	public Int32? idsortingkind3{ 
		get {if (this["idsortingkind3"]==DBNull.Value)return null; return  (Int32?)this["idsortingkind3"];}
		set {if (value==null) this["idsortingkind3"]= DBNull.Value; else this["idsortingkind3"]= value;}
	}
	public object idsortingkind3Value { 
		get{ return this["idsortingkind3"];}
		set {if (value==null|| value==DBNull.Value) this["idsortingkind3"]= DBNull.Value; else this["idsortingkind3"]= value;}
	}
	public Int32? idsortingkind3Original { 
		get {if (this["idsortingkind3",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsortingkind3",DataRowVersion.Original];}
	}
	public Byte? fin_kind{ 
		get {if (this["fin_kind"]==DBNull.Value)return null; return  (Byte?)this["fin_kind"];}
		set {if (value==null) this["fin_kind"]= DBNull.Value; else this["fin_kind"]= value;}
	}
	public object fin_kindValue { 
		get{ return this["fin_kind"];}
		set {if (value==null|| value==DBNull.Value) this["fin_kind"]= DBNull.Value; else this["fin_kind"]= value;}
	}
	public Byte? fin_kindOriginal { 
		get {if (this["fin_kind",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["fin_kind",DataRowVersion.Original];}
	}
	public Byte? taxvaliditykind{ 
		get {if (this["taxvaliditykind"]==DBNull.Value)return null; return  (Byte?)this["taxvaliditykind"];}
		set {if (value==null) this["taxvaliditykind"]= DBNull.Value; else this["taxvaliditykind"]= value;}
	}
	public object taxvaliditykindValue { 
		get{ return this["taxvaliditykind"];}
		set {if (value==null|| value==DBNull.Value) this["taxvaliditykind"]= DBNull.Value; else this["taxvaliditykind"]= value;}
	}
	public Byte? taxvaliditykindOriginal { 
		get {if (this["taxvaliditykind",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["taxvaliditykind",DataRowVersion.Original];}
	}
	public Byte? flag_paymentamount{ 
		get {if (this["flag_paymentamount"]==DBNull.Value)return null; return  (Byte?)this["flag_paymentamount"];}
		set {if (value==null) this["flag_paymentamount"]= DBNull.Value; else this["flag_paymentamount"]= value;}
	}
	public object flag_paymentamountValue { 
		get{ return this["flag_paymentamount"];}
		set {if (value==null|| value==DBNull.Value) this["flag_paymentamount"]= DBNull.Value; else this["flag_paymentamount"]= value;}
	}
	public Byte? flag_paymentamountOriginal { 
		get {if (this["flag_paymentamount",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["flag_paymentamount",DataRowVersion.Original];}
	}
	public Int32? automanagekind{ 
		get {if (this["automanagekind"]==DBNull.Value)return null; return  (Int32?)this["automanagekind"];}
		set {if (value==null) this["automanagekind"]= DBNull.Value; else this["automanagekind"]= value;}
	}
	public object automanagekindValue { 
		get{ return this["automanagekind"];}
		set {if (value==null|| value==DBNull.Value) this["automanagekind"]= DBNull.Value; else this["automanagekind"]= value;}
	}
	public Int32? automanagekindOriginal { 
		get {if (this["automanagekind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["automanagekind",DataRowVersion.Original];}
	}
	public Int32? flag_autodocnumbering{ 
		get {if (this["flag_autodocnumbering"]==DBNull.Value)return null; return  (Int32?)this["flag_autodocnumbering"];}
		set {if (value==null) this["flag_autodocnumbering"]= DBNull.Value; else this["flag_autodocnumbering"]= value;}
	}
	public object flag_autodocnumberingValue { 
		get{ return this["flag_autodocnumbering"];}
		set {if (value==null|| value==DBNull.Value) this["flag_autodocnumbering"]= DBNull.Value; else this["flag_autodocnumbering"]= value;}
	}
	public Int32? flag_autodocnumberingOriginal { 
		get {if (this["flag_autodocnumbering",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["flag_autodocnumbering",DataRowVersion.Original];}
	}
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
	public Byte? cashvaliditykind{ 
		get {if (this["cashvaliditykind"]==DBNull.Value)return null; return  (Byte?)this["cashvaliditykind"];}
		set {if (value==null) this["cashvaliditykind"]= DBNull.Value; else this["cashvaliditykind"]= value;}
	}
	public object cashvaliditykindValue { 
		get{ return this["cashvaliditykind"];}
		set {if (value==null|| value==DBNull.Value) this["cashvaliditykind"]= DBNull.Value; else this["cashvaliditykind"]= value;}
	}
	public Byte? cashvaliditykindOriginal { 
		get {if (this["cashvaliditykind",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["cashvaliditykind",DataRowVersion.Original];}
	}
	public String wageimportappname{ 
		get {if (this["wageimportappname"]==DBNull.Value)return null; return  (String)this["wageimportappname"];}
		set {if (value==null) this["wageimportappname"]= DBNull.Value; else this["wageimportappname"]= value;}
	}
	public object wageimportappnameValue { 
		get{ return this["wageimportappname"];}
		set {if (value==null|| value==DBNull.Value) this["wageimportappname"]= DBNull.Value; else this["wageimportappname"]= value;}
	}
	public String wageimportappnameOriginal { 
		get {if (this["wageimportappname",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["wageimportappname",DataRowVersion.Original];}
	}
	public Byte? balancekind{ 
		get {if (this["balancekind"]==DBNull.Value)return null; return  (Byte?)this["balancekind"];}
		set {if (value==null) this["balancekind"]= DBNull.Value; else this["balancekind"]= value;}
	}
	public object balancekindValue { 
		get{ return this["balancekind"];}
		set {if (value==null|| value==DBNull.Value) this["balancekind"]= DBNull.Value; else this["balancekind"]= value;}
	}
	public Byte? balancekindOriginal { 
		get {if (this["balancekind",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["balancekind",DataRowVersion.Original];}
	}
	public Int32? idpaymethodabi{ 
		get {if (this["idpaymethodabi"]==DBNull.Value)return null; return  (Int32?)this["idpaymethodabi"];}
		set {if (value==null) this["idpaymethodabi"]= DBNull.Value; else this["idpaymethodabi"]= value;}
	}
	public object idpaymethodabiValue { 
		get{ return this["idpaymethodabi"];}
		set {if (value==null|| value==DBNull.Value) this["idpaymethodabi"]= DBNull.Value; else this["idpaymethodabi"]= value;}
	}
	public Int32? idpaymethodabiOriginal { 
		get {if (this["idpaymethodabi",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpaymethodabi",DataRowVersion.Original];}
	}
	public Int32? idpaymethodnoabi{ 
		get {if (this["idpaymethodnoabi"]==DBNull.Value)return null; return  (Int32?)this["idpaymethodnoabi"];}
		set {if (value==null) this["idpaymethodnoabi"]= DBNull.Value; else this["idpaymethodnoabi"]= value;}
	}
	public object idpaymethodnoabiValue { 
		get{ return this["idpaymethodnoabi"];}
		set {if (value==null|| value==DBNull.Value) this["idpaymethodnoabi"]= DBNull.Value; else this["idpaymethodnoabi"]= value;}
	}
	public Int32? idpaymethodnoabiOriginal { 
		get {if (this["idpaymethodnoabi",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpaymethodnoabi",DataRowVersion.Original];}
	}
	public String iban_f24{ 
		get {if (this["iban_f24"]==DBNull.Value)return null; return  (String)this["iban_f24"];}
		set {if (value==null) this["iban_f24"]= DBNull.Value; else this["iban_f24"]= value;}
	}
	public object iban_f24Value { 
		get{ return this["iban_f24"];}
		set {if (value==null|| value==DBNull.Value) this["iban_f24"]= DBNull.Value; else this["iban_f24"]= value;}
	}
	public String iban_f24Original { 
		get {if (this["iban_f24",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["iban_f24",DataRowVersion.Original];}
	}
	public String cudactivitycode{ 
		get {if (this["cudactivitycode"]==DBNull.Value)return null; return  (String)this["cudactivitycode"];}
		set {if (value==null) this["cudactivitycode"]= DBNull.Value; else this["cudactivitycode"]= value;}
	}
	public object cudactivitycodeValue { 
		get{ return this["cudactivitycode"];}
		set {if (value==null|| value==DBNull.Value) this["cudactivitycode"]= DBNull.Value; else this["cudactivitycode"]= value;}
	}
	public String cudactivitycodeOriginal { 
		get {if (this["cudactivitycode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cudactivitycode",DataRowVersion.Original];}
	}
	public Decimal? startivabalance{ 
		get {if (this["startivabalance"]==DBNull.Value)return null; return  (Decimal?)this["startivabalance"];}
		set {if (value==null) this["startivabalance"]= DBNull.Value; else this["startivabalance"]= value;}
	}
	public object startivabalanceValue { 
		get{ return this["startivabalance"];}
		set {if (value==null|| value==DBNull.Value) this["startivabalance"]= DBNull.Value; else this["startivabalance"]= value;}
	}
	public Decimal? startivabalanceOriginal { 
		get {if (this["startivabalance",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["startivabalance",DataRowVersion.Original];}
	}
	public String flagivapaybyrow{ 
		get {if (this["flagivapaybyrow"]==DBNull.Value)return null; return  (String)this["flagivapaybyrow"];}
		set {if (value==null) this["flagivapaybyrow"]= DBNull.Value; else this["flagivapaybyrow"]= value;}
	}
	public object flagivapaybyrowValue { 
		get{ return this["flagivapaybyrow"];}
		set {if (value==null|| value==DBNull.Value) this["flagivapaybyrow"]= DBNull.Value; else this["flagivapaybyrow"]= value;}
	}
	public String flagivapaybyrowOriginal { 
		get {if (this["flagivapaybyrow",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagivapaybyrow",DataRowVersion.Original];}
	}
	public String idacc_unabatable{ 
		get {if (this["idacc_unabatable"]==DBNull.Value)return null; return  (String)this["idacc_unabatable"];}
		set {if (value==null) this["idacc_unabatable"]= DBNull.Value; else this["idacc_unabatable"]= value;}
	}
	public object idacc_unabatableValue { 
		get{ return this["idacc_unabatable"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_unabatable"]= DBNull.Value; else this["idacc_unabatable"]= value;}
	}
	public String idacc_unabatableOriginal { 
		get {if (this["idacc_unabatable",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_unabatable",DataRowVersion.Original];}
	}
	public String idacc_unabatable_refund{ 
		get {if (this["idacc_unabatable_refund"]==DBNull.Value)return null; return  (String)this["idacc_unabatable_refund"];}
		set {if (value==null) this["idacc_unabatable_refund"]= DBNull.Value; else this["idacc_unabatable_refund"]= value;}
	}
	public object idacc_unabatable_refundValue { 
		get{ return this["idacc_unabatable_refund"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_unabatable_refund"]= DBNull.Value; else this["idacc_unabatable_refund"]= value;}
	}
	public String idacc_unabatable_refundOriginal { 
		get {if (this["idacc_unabatable_refund",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_unabatable_refund",DataRowVersion.Original];}
	}
	public String invoice_flagregister{ 
		get {if (this["invoice_flagregister"]==DBNull.Value)return null; return  (String)this["invoice_flagregister"];}
		set {if (value==null) this["invoice_flagregister"]= DBNull.Value; else this["invoice_flagregister"]= value;}
	}
	public object invoice_flagregisterValue { 
		get{ return this["invoice_flagregister"];}
		set {if (value==null|| value==DBNull.Value) this["invoice_flagregister"]= DBNull.Value; else this["invoice_flagregister"]= value;}
	}
	public String invoice_flagregisterOriginal { 
		get {if (this["invoice_flagregister",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["invoice_flagregister",DataRowVersion.Original];}
	}
	public Int16? default_idfinvarstatus{ 
		get {if (this["default_idfinvarstatus"]==DBNull.Value)return null; return  (Int16?)this["default_idfinvarstatus"];}
		set {if (value==null) this["default_idfinvarstatus"]= DBNull.Value; else this["default_idfinvarstatus"]= value;}
	}
	public object default_idfinvarstatusValue { 
		get{ return this["default_idfinvarstatus"];}
		set {if (value==null|| value==DBNull.Value) this["default_idfinvarstatus"]= DBNull.Value; else this["default_idfinvarstatus"]= value;}
	}
	public Int16? default_idfinvarstatusOriginal { 
		get {if (this["default_idfinvarstatus",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["default_idfinvarstatus",DataRowVersion.Original];}
	}
	public String flagivaregphase{ 
		get {if (this["flagivaregphase"]==DBNull.Value)return null; return  (String)this["flagivaregphase"];}
		set {if (value==null) this["flagivaregphase"]= DBNull.Value; else this["flagivaregphase"]= value;}
	}
	public object flagivaregphaseValue { 
		get{ return this["flagivaregphase"];}
		set {if (value==null|| value==DBNull.Value) this["flagivaregphase"]= DBNull.Value; else this["flagivaregphase"]= value;}
	}
	public String flagivaregphaseOriginal { 
		get {if (this["flagivaregphase",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagivaregphase",DataRowVersion.Original];}
	}
	public String mainflagpayment{ 
		get {if (this["mainflagpayment"]==DBNull.Value)return null; return  (String)this["mainflagpayment"];}
		set {if (value==null) this["mainflagpayment"]= DBNull.Value; else this["mainflagpayment"]= value;}
	}
	public object mainflagpaymentValue { 
		get{ return this["mainflagpayment"];}
		set {if (value==null|| value==DBNull.Value) this["mainflagpayment"]= DBNull.Value; else this["mainflagpayment"]= value;}
	}
	public String mainflagpaymentOriginal { 
		get {if (this["mainflagpayment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["mainflagpayment",DataRowVersion.Original];}
	}
	public String mainflagrefund{ 
		get {if (this["mainflagrefund"]==DBNull.Value)return null; return  (String)this["mainflagrefund"];}
		set {if (value==null) this["mainflagrefund"]= DBNull.Value; else this["mainflagrefund"]= value;}
	}
	public object mainflagrefundValue { 
		get{ return this["mainflagrefund"];}
		set {if (value==null|| value==DBNull.Value) this["mainflagrefund"]= DBNull.Value; else this["mainflagrefund"]= value;}
	}
	public String mainflagrefundOriginal { 
		get {if (this["mainflagrefund",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["mainflagrefund",DataRowVersion.Original];}
	}
	public Int32? mainidfinivapayment{ 
		get {if (this["mainidfinivapayment"]==DBNull.Value)return null; return  (Int32?)this["mainidfinivapayment"];}
		set {if (value==null) this["mainidfinivapayment"]= DBNull.Value; else this["mainidfinivapayment"]= value;}
	}
	public object mainidfinivapaymentValue { 
		get{ return this["mainidfinivapayment"];}
		set {if (value==null|| value==DBNull.Value) this["mainidfinivapayment"]= DBNull.Value; else this["mainidfinivapayment"]= value;}
	}
	public Int32? mainidfinivapaymentOriginal { 
		get {if (this["mainidfinivapayment",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["mainidfinivapayment",DataRowVersion.Original];}
	}
	public Int32? mainidfinivarefund{ 
		get {if (this["mainidfinivarefund"]==DBNull.Value)return null; return  (Int32?)this["mainidfinivarefund"];}
		set {if (value==null) this["mainidfinivarefund"]= DBNull.Value; else this["mainidfinivarefund"]= value;}
	}
	public object mainidfinivarefundValue { 
		get{ return this["mainidfinivarefund"];}
		set {if (value==null|| value==DBNull.Value) this["mainidfinivarefund"]= DBNull.Value; else this["mainidfinivarefund"]= value;}
	}
	public Int32? mainidfinivarefundOriginal { 
		get {if (this["mainidfinivarefund",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["mainidfinivarefund",DataRowVersion.Original];}
	}
	public Decimal? mainminpayment{ 
		get {if (this["mainminpayment"]==DBNull.Value)return null; return  (Decimal?)this["mainminpayment"];}
		set {if (value==null) this["mainminpayment"]= DBNull.Value; else this["mainminpayment"]= value;}
	}
	public object mainminpaymentValue { 
		get{ return this["mainminpayment"];}
		set {if (value==null|| value==DBNull.Value) this["mainminpayment"]= DBNull.Value; else this["mainminpayment"]= value;}
	}
	public Decimal? mainminpaymentOriginal { 
		get {if (this["mainminpayment",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["mainminpayment",DataRowVersion.Original];}
	}
	public Decimal? mainminrefund{ 
		get {if (this["mainminrefund"]==DBNull.Value)return null; return  (Decimal?)this["mainminrefund"];}
		set {if (value==null) this["mainminrefund"]= DBNull.Value; else this["mainminrefund"]= value;}
	}
	public object mainminrefundValue { 
		get{ return this["mainminrefund"];}
		set {if (value==null|| value==DBNull.Value) this["mainminrefund"]= DBNull.Value; else this["mainminrefund"]= value;}
	}
	public Decimal? mainminrefundOriginal { 
		get {if (this["mainminrefund",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["mainminrefund",DataRowVersion.Original];}
	}
	public Int32? mainpaymentagency{ 
		get {if (this["mainpaymentagency"]==DBNull.Value)return null; return  (Int32?)this["mainpaymentagency"];}
		set {if (value==null) this["mainpaymentagency"]= DBNull.Value; else this["mainpaymentagency"]= value;}
	}
	public object mainpaymentagencyValue { 
		get{ return this["mainpaymentagency"];}
		set {if (value==null|| value==DBNull.Value) this["mainpaymentagency"]= DBNull.Value; else this["mainpaymentagency"]= value;}
	}
	public Int32? mainpaymentagencyOriginal { 
		get {if (this["mainpaymentagency",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["mainpaymentagency",DataRowVersion.Original];}
	}
	public Int32? mainrefundagency{ 
		get {if (this["mainrefundagency"]==DBNull.Value)return null; return  (Int32?)this["mainrefundagency"];}
		set {if (value==null) this["mainrefundagency"]= DBNull.Value; else this["mainrefundagency"]= value;}
	}
	public object mainrefundagencyValue { 
		get{ return this["mainrefundagency"];}
		set {if (value==null|| value==DBNull.Value) this["mainrefundagency"]= DBNull.Value; else this["mainrefundagency"]= value;}
	}
	public Int32? mainrefundagencyOriginal { 
		get {if (this["mainrefundagency",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["mainrefundagency",DataRowVersion.Original];}
	}
	public String mainflagivaregphase{ 
		get {if (this["mainflagivaregphase"]==DBNull.Value)return null; return  (String)this["mainflagivaregphase"];}
		set {if (value==null) this["mainflagivaregphase"]= DBNull.Value; else this["mainflagivaregphase"]= value;}
	}
	public object mainflagivaregphaseValue { 
		get{ return this["mainflagivaregphase"];}
		set {if (value==null|| value==DBNull.Value) this["mainflagivaregphase"]= DBNull.Value; else this["mainflagivaregphase"]= value;}
	}
	public String mainflagivaregphaseOriginal { 
		get {if (this["mainflagivaregphase",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["mainflagivaregphase",DataRowVersion.Original];}
	}
	public Decimal? mainstartivabalance{ 
		get {if (this["mainstartivabalance"]==DBNull.Value)return null; return  (Decimal?)this["mainstartivabalance"];}
		set {if (value==null) this["mainstartivabalance"]= DBNull.Value; else this["mainstartivabalance"]= value;}
	}
	public object mainstartivabalanceValue { 
		get{ return this["mainstartivabalance"];}
		set {if (value==null|| value==DBNull.Value) this["mainstartivabalance"]= DBNull.Value; else this["mainstartivabalance"]= value;}
	}
	public Decimal? mainstartivabalanceOriginal { 
		get {if (this["mainstartivabalance",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["mainstartivabalance",DataRowVersion.Original];}
	}
	public String mainidacc_unabatable{ 
		get {if (this["mainidacc_unabatable"]==DBNull.Value)return null; return  (String)this["mainidacc_unabatable"];}
		set {if (value==null) this["mainidacc_unabatable"]= DBNull.Value; else this["mainidacc_unabatable"]= value;}
	}
	public object mainidacc_unabatableValue { 
		get{ return this["mainidacc_unabatable"];}
		set {if (value==null|| value==DBNull.Value) this["mainidacc_unabatable"]= DBNull.Value; else this["mainidacc_unabatable"]= value;}
	}
	public String mainidacc_unabatableOriginal { 
		get {if (this["mainidacc_unabatable",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["mainidacc_unabatable",DataRowVersion.Original];}
	}
	public String mainidacc_unabatable_refund{ 
		get {if (this["mainidacc_unabatable_refund"]==DBNull.Value)return null; return  (String)this["mainidacc_unabatable_refund"];}
		set {if (value==null) this["mainidacc_unabatable_refund"]= DBNull.Value; else this["mainidacc_unabatable_refund"]= value;}
	}
	public object mainidacc_unabatable_refundValue { 
		get{ return this["mainidacc_unabatable_refund"];}
		set {if (value==null|| value==DBNull.Value) this["mainidacc_unabatable_refund"]= DBNull.Value; else this["mainidacc_unabatable_refund"]= value;}
	}
	public String mainidacc_unabatable_refundOriginal { 
		get {if (this["mainidacc_unabatable_refund",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["mainidacc_unabatable_refund",DataRowVersion.Original];}
	}
	public String idacc_mainivapayment{ 
		get {if (this["idacc_mainivapayment"]==DBNull.Value)return null; return  (String)this["idacc_mainivapayment"];}
		set {if (value==null) this["idacc_mainivapayment"]= DBNull.Value; else this["idacc_mainivapayment"]= value;}
	}
	public object idacc_mainivapaymentValue { 
		get{ return this["idacc_mainivapayment"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_mainivapayment"]= DBNull.Value; else this["idacc_mainivapayment"]= value;}
	}
	public String idacc_mainivapaymentOriginal { 
		get {if (this["idacc_mainivapayment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_mainivapayment",DataRowVersion.Original];}
	}
	public String idacc_mainivapayment_internal{ 
		get {if (this["idacc_mainivapayment_internal"]==DBNull.Value)return null; return  (String)this["idacc_mainivapayment_internal"];}
		set {if (value==null) this["idacc_mainivapayment_internal"]= DBNull.Value; else this["idacc_mainivapayment_internal"]= value;}
	}
	public object idacc_mainivapayment_internalValue { 
		get{ return this["idacc_mainivapayment_internal"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_mainivapayment_internal"]= DBNull.Value; else this["idacc_mainivapayment_internal"]= value;}
	}
	public String idacc_mainivapayment_internalOriginal { 
		get {if (this["idacc_mainivapayment_internal",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_mainivapayment_internal",DataRowVersion.Original];}
	}
	public String idacc_mainivarefund{ 
		get {if (this["idacc_mainivarefund"]==DBNull.Value)return null; return  (String)this["idacc_mainivarefund"];}
		set {if (value==null) this["idacc_mainivarefund"]= DBNull.Value; else this["idacc_mainivarefund"]= value;}
	}
	public object idacc_mainivarefundValue { 
		get{ return this["idacc_mainivarefund"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_mainivarefund"]= DBNull.Value; else this["idacc_mainivarefund"]= value;}
	}
	public String idacc_mainivarefundOriginal { 
		get {if (this["idacc_mainivarefund",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_mainivarefund",DataRowVersion.Original];}
	}
	public String idacc_mainivarefund_internal{ 
		get {if (this["idacc_mainivarefund_internal"]==DBNull.Value)return null; return  (String)this["idacc_mainivarefund_internal"];}
		set {if (value==null) this["idacc_mainivarefund_internal"]= DBNull.Value; else this["idacc_mainivarefund_internal"]= value;}
	}
	public object idacc_mainivarefund_internalValue { 
		get{ return this["idacc_mainivarefund_internal"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_mainivarefund_internal"]= DBNull.Value; else this["idacc_mainivarefund_internal"]= value;}
	}
	public String idacc_mainivarefund_internalOriginal { 
		get {if (this["idacc_mainivarefund_internal",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_mainivarefund_internal",DataRowVersion.Original];}
	}
	public String flagva3{ 
		get {if (this["flagva3"]==DBNull.Value)return null; return  (String)this["flagva3"];}
		set {if (value==null) this["flagva3"]= DBNull.Value; else this["flagva3"]= value;}
	}
	public object flagva3Value { 
		get{ return this["flagva3"];}
		set {if (value==null|| value==DBNull.Value) this["flagva3"]= DBNull.Value; else this["flagva3"]= value;}
	}
	public String flagva3Original { 
		get {if (this["flagva3",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagva3",DataRowVersion.Original];}
	}
	public String flagrefund12{ 
		get {if (this["flagrefund12"]==DBNull.Value)return null; return  (String)this["flagrefund12"];}
		set {if (value==null) this["flagrefund12"]= DBNull.Value; else this["flagrefund12"]= value;}
	}
	public object flagrefund12Value { 
		get{ return this["flagrefund12"];}
		set {if (value==null|| value==DBNull.Value) this["flagrefund12"]= DBNull.Value; else this["flagrefund12"]= value;}
	}
	public String flagrefund12Original { 
		get {if (this["flagrefund12",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagrefund12",DataRowVersion.Original];}
	}
	public String flagpayment12{ 
		get {if (this["flagpayment12"]==DBNull.Value)return null; return  (String)this["flagpayment12"];}
		set {if (value==null) this["flagpayment12"]= DBNull.Value; else this["flagpayment12"]= value;}
	}
	public object flagpayment12Value { 
		get{ return this["flagpayment12"];}
		set {if (value==null|| value==DBNull.Value) this["flagpayment12"]= DBNull.Value; else this["flagpayment12"]= value;}
	}
	public String flagpayment12Original { 
		get {if (this["flagpayment12",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagpayment12",DataRowVersion.Original];}
	}
	public Int32? refundagency12{ 
		get {if (this["refundagency12"]==DBNull.Value)return null; return  (Int32?)this["refundagency12"];}
		set {if (value==null) this["refundagency12"]= DBNull.Value; else this["refundagency12"]= value;}
	}
	public object refundagency12Value { 
		get{ return this["refundagency12"];}
		set {if (value==null|| value==DBNull.Value) this["refundagency12"]= DBNull.Value; else this["refundagency12"]= value;}
	}
	public Int32? refundagency12Original { 
		get {if (this["refundagency12",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["refundagency12",DataRowVersion.Original];}
	}
	public Int32? paymentagency12{ 
		get {if (this["paymentagency12"]==DBNull.Value)return null; return  (Int32?)this["paymentagency12"];}
		set {if (value==null) this["paymentagency12"]= DBNull.Value; else this["paymentagency12"]= value;}
	}
	public object paymentagency12Value { 
		get{ return this["paymentagency12"];}
		set {if (value==null|| value==DBNull.Value) this["paymentagency12"]= DBNull.Value; else this["paymentagency12"]= value;}
	}
	public Int32? paymentagency12Original { 
		get {if (this["paymentagency12",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["paymentagency12",DataRowVersion.Original];}
	}
	public Int32? idfinivarefund12{ 
		get {if (this["idfinivarefund12"]==DBNull.Value)return null; return  (Int32?)this["idfinivarefund12"];}
		set {if (value==null) this["idfinivarefund12"]= DBNull.Value; else this["idfinivarefund12"]= value;}
	}
	public object idfinivarefund12Value { 
		get{ return this["idfinivarefund12"];}
		set {if (value==null|| value==DBNull.Value) this["idfinivarefund12"]= DBNull.Value; else this["idfinivarefund12"]= value;}
	}
	public Int32? idfinivarefund12Original { 
		get {if (this["idfinivarefund12",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idfinivarefund12",DataRowVersion.Original];}
	}
	public Int32? idfinivapayment12{ 
		get {if (this["idfinivapayment12"]==DBNull.Value)return null; return  (Int32?)this["idfinivapayment12"];}
		set {if (value==null) this["idfinivapayment12"]= DBNull.Value; else this["idfinivapayment12"]= value;}
	}
	public object idfinivapayment12Value { 
		get{ return this["idfinivapayment12"];}
		set {if (value==null|| value==DBNull.Value) this["idfinivapayment12"]= DBNull.Value; else this["idfinivapayment12"]= value;}
	}
	public Int32? idfinivapayment12Original { 
		get {if (this["idfinivapayment12",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idfinivapayment12",DataRowVersion.Original];}
	}
	public Decimal? minrefund12{ 
		get {if (this["minrefund12"]==DBNull.Value)return null; return  (Decimal?)this["minrefund12"];}
		set {if (value==null) this["minrefund12"]= DBNull.Value; else this["minrefund12"]= value;}
	}
	public object minrefund12Value { 
		get{ return this["minrefund12"];}
		set {if (value==null|| value==DBNull.Value) this["minrefund12"]= DBNull.Value; else this["minrefund12"]= value;}
	}
	public Decimal? minrefund12Original { 
		get {if (this["minrefund12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["minrefund12",DataRowVersion.Original];}
	}
	public Decimal? minpayment12{ 
		get {if (this["minpayment12"]==DBNull.Value)return null; return  (Decimal?)this["minpayment12"];}
		set {if (value==null) this["minpayment12"]= DBNull.Value; else this["minpayment12"]= value;}
	}
	public object minpayment12Value { 
		get{ return this["minpayment12"];}
		set {if (value==null|| value==DBNull.Value) this["minpayment12"]= DBNull.Value; else this["minpayment12"]= value;}
	}
	public Decimal? minpayment12Original { 
		get {if (this["minpayment12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["minpayment12",DataRowVersion.Original];}
	}
	public String idacc_ivapayment12{ 
		get {if (this["idacc_ivapayment12"]==DBNull.Value)return null; return  (String)this["idacc_ivapayment12"];}
		set {if (value==null) this["idacc_ivapayment12"]= DBNull.Value; else this["idacc_ivapayment12"]= value;}
	}
	public object idacc_ivapayment12Value { 
		get{ return this["idacc_ivapayment12"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_ivapayment12"]= DBNull.Value; else this["idacc_ivapayment12"]= value;}
	}
	public String idacc_ivapayment12Original { 
		get {if (this["idacc_ivapayment12",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_ivapayment12",DataRowVersion.Original];}
	}
	public String idacc_ivarefund12{ 
		get {if (this["idacc_ivarefund12"]==DBNull.Value)return null; return  (String)this["idacc_ivarefund12"];}
		set {if (value==null) this["idacc_ivarefund12"]= DBNull.Value; else this["idacc_ivarefund12"]= value;}
	}
	public object idacc_ivarefund12Value { 
		get{ return this["idacc_ivarefund12"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_ivarefund12"]= DBNull.Value; else this["idacc_ivarefund12"]= value;}
	}
	public String idacc_ivarefund12Original { 
		get {if (this["idacc_ivarefund12",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_ivarefund12",DataRowVersion.Original];}
	}
	public String idacc_mainivarefund12{ 
		get {if (this["idacc_mainivarefund12"]==DBNull.Value)return null; return  (String)this["idacc_mainivarefund12"];}
		set {if (value==null) this["idacc_mainivarefund12"]= DBNull.Value; else this["idacc_mainivarefund12"]= value;}
	}
	public object idacc_mainivarefund12Value { 
		get{ return this["idacc_mainivarefund12"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_mainivarefund12"]= DBNull.Value; else this["idacc_mainivarefund12"]= value;}
	}
	public String idacc_mainivarefund12Original { 
		get {if (this["idacc_mainivarefund12",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_mainivarefund12",DataRowVersion.Original];}
	}
	public String idacc_mainivapayment12{ 
		get {if (this["idacc_mainivapayment12"]==DBNull.Value)return null; return  (String)this["idacc_mainivapayment12"];}
		set {if (value==null) this["idacc_mainivapayment12"]= DBNull.Value; else this["idacc_mainivapayment12"]= value;}
	}
	public object idacc_mainivapayment12Value { 
		get{ return this["idacc_mainivapayment12"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_mainivapayment12"]= DBNull.Value; else this["idacc_mainivapayment12"]= value;}
	}
	public String idacc_mainivapayment12Original { 
		get {if (this["idacc_mainivapayment12",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_mainivapayment12",DataRowVersion.Original];}
	}
	public String idacc_mainivapayment_internal12{ 
		get {if (this["idacc_mainivapayment_internal12"]==DBNull.Value)return null; return  (String)this["idacc_mainivapayment_internal12"];}
		set {if (value==null) this["idacc_mainivapayment_internal12"]= DBNull.Value; else this["idacc_mainivapayment_internal12"]= value;}
	}
	public object idacc_mainivapayment_internal12Value { 
		get{ return this["idacc_mainivapayment_internal12"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_mainivapayment_internal12"]= DBNull.Value; else this["idacc_mainivapayment_internal12"]= value;}
	}
	public String idacc_mainivapayment_internal12Original { 
		get {if (this["idacc_mainivapayment_internal12",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_mainivapayment_internal12",DataRowVersion.Original];}
	}
	public String idacc_mainivarefund_internal12{ 
		get {if (this["idacc_mainivarefund_internal12"]==DBNull.Value)return null; return  (String)this["idacc_mainivarefund_internal12"];}
		set {if (value==null) this["idacc_mainivarefund_internal12"]= DBNull.Value; else this["idacc_mainivarefund_internal12"]= value;}
	}
	public object idacc_mainivarefund_internal12Value { 
		get{ return this["idacc_mainivarefund_internal12"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_mainivarefund_internal12"]= DBNull.Value; else this["idacc_mainivarefund_internal12"]= value;}
	}
	public String idacc_mainivarefund_internal12Original { 
		get {if (this["idacc_mainivarefund_internal12",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_mainivarefund_internal12",DataRowVersion.Original];}
	}
	public Decimal? startivabalance12{ 
		get {if (this["startivabalance12"]==DBNull.Value)return null; return  (Decimal?)this["startivabalance12"];}
		set {if (value==null) this["startivabalance12"]= DBNull.Value; else this["startivabalance12"]= value;}
	}
	public object startivabalance12Value { 
		get{ return this["startivabalance12"];}
		set {if (value==null|| value==DBNull.Value) this["startivabalance12"]= DBNull.Value; else this["startivabalance12"]= value;}
	}
	public Decimal? startivabalance12Original { 
		get {if (this["startivabalance12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["startivabalance12",DataRowVersion.Original];}
	}
	public Int32? mainrefundagency12{ 
		get {if (this["mainrefundagency12"]==DBNull.Value)return null; return  (Int32?)this["mainrefundagency12"];}
		set {if (value==null) this["mainrefundagency12"]= DBNull.Value; else this["mainrefundagency12"]= value;}
	}
	public object mainrefundagency12Value { 
		get{ return this["mainrefundagency12"];}
		set {if (value==null|| value==DBNull.Value) this["mainrefundagency12"]= DBNull.Value; else this["mainrefundagency12"]= value;}
	}
	public Int32? mainrefundagency12Original { 
		get {if (this["mainrefundagency12",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["mainrefundagency12",DataRowVersion.Original];}
	}
	public Int32? mainpaymentagency12{ 
		get {if (this["mainpaymentagency12"]==DBNull.Value)return null; return  (Int32?)this["mainpaymentagency12"];}
		set {if (value==null) this["mainpaymentagency12"]= DBNull.Value; else this["mainpaymentagency12"]= value;}
	}
	public object mainpaymentagency12Value { 
		get{ return this["mainpaymentagency12"];}
		set {if (value==null|| value==DBNull.Value) this["mainpaymentagency12"]= DBNull.Value; else this["mainpaymentagency12"]= value;}
	}
	public Int32? mainpaymentagency12Original { 
		get {if (this["mainpaymentagency12",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["mainpaymentagency12",DataRowVersion.Original];}
	}
	public String mainflagrefund12{ 
		get {if (this["mainflagrefund12"]==DBNull.Value)return null; return  (String)this["mainflagrefund12"];}
		set {if (value==null) this["mainflagrefund12"]= DBNull.Value; else this["mainflagrefund12"]= value;}
	}
	public object mainflagrefund12Value { 
		get{ return this["mainflagrefund12"];}
		set {if (value==null|| value==DBNull.Value) this["mainflagrefund12"]= DBNull.Value; else this["mainflagrefund12"]= value;}
	}
	public String mainflagrefund12Original { 
		get {if (this["mainflagrefund12",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["mainflagrefund12",DataRowVersion.Original];}
	}
	public String mainflagpayment12{ 
		get {if (this["mainflagpayment12"]==DBNull.Value)return null; return  (String)this["mainflagpayment12"];}
		set {if (value==null) this["mainflagpayment12"]= DBNull.Value; else this["mainflagpayment12"]= value;}
	}
	public object mainflagpayment12Value { 
		get{ return this["mainflagpayment12"];}
		set {if (value==null|| value==DBNull.Value) this["mainflagpayment12"]= DBNull.Value; else this["mainflagpayment12"]= value;}
	}
	public String mainflagpayment12Original { 
		get {if (this["mainflagpayment12",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["mainflagpayment12",DataRowVersion.Original];}
	}
	public Int32? mainidfinivarefund12{ 
		get {if (this["mainidfinivarefund12"]==DBNull.Value)return null; return  (Int32?)this["mainidfinivarefund12"];}
		set {if (value==null) this["mainidfinivarefund12"]= DBNull.Value; else this["mainidfinivarefund12"]= value;}
	}
	public object mainidfinivarefund12Value { 
		get{ return this["mainidfinivarefund12"];}
		set {if (value==null|| value==DBNull.Value) this["mainidfinivarefund12"]= DBNull.Value; else this["mainidfinivarefund12"]= value;}
	}
	public Int32? mainidfinivarefund12Original { 
		get {if (this["mainidfinivarefund12",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["mainidfinivarefund12",DataRowVersion.Original];}
	}
	public Int32? mainidfinivapayment12{ 
		get {if (this["mainidfinivapayment12"]==DBNull.Value)return null; return  (Int32?)this["mainidfinivapayment12"];}
		set {if (value==null) this["mainidfinivapayment12"]= DBNull.Value; else this["mainidfinivapayment12"]= value;}
	}
	public object mainidfinivapayment12Value { 
		get{ return this["mainidfinivapayment12"];}
		set {if (value==null|| value==DBNull.Value) this["mainidfinivapayment12"]= DBNull.Value; else this["mainidfinivapayment12"]= value;}
	}
	public Int32? mainidfinivapayment12Original { 
		get {if (this["mainidfinivapayment12",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["mainidfinivapayment12",DataRowVersion.Original];}
	}
	public Decimal? mainminrefund12{ 
		get {if (this["mainminrefund12"]==DBNull.Value)return null; return  (Decimal?)this["mainminrefund12"];}
		set {if (value==null) this["mainminrefund12"]= DBNull.Value; else this["mainminrefund12"]= value;}
	}
	public object mainminrefund12Value { 
		get{ return this["mainminrefund12"];}
		set {if (value==null|| value==DBNull.Value) this["mainminrefund12"]= DBNull.Value; else this["mainminrefund12"]= value;}
	}
	public Decimal? mainminrefund12Original { 
		get {if (this["mainminrefund12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["mainminrefund12",DataRowVersion.Original];}
	}
	public Decimal? mainminpayment12{ 
		get {if (this["mainminpayment12"]==DBNull.Value)return null; return  (Decimal?)this["mainminpayment12"];}
		set {if (value==null) this["mainminpayment12"]= DBNull.Value; else this["mainminpayment12"]= value;}
	}
	public object mainminpayment12Value { 
		get{ return this["mainminpayment12"];}
		set {if (value==null|| value==DBNull.Value) this["mainminpayment12"]= DBNull.Value; else this["mainminpayment12"]= value;}
	}
	public Decimal? mainminpayment12Original { 
		get {if (this["mainminpayment12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["mainminpayment12",DataRowVersion.Original];}
	}
	public Decimal? mainstartivabalance12{ 
		get {if (this["mainstartivabalance12"]==DBNull.Value)return null; return  (Decimal?)this["mainstartivabalance12"];}
		set {if (value==null) this["mainstartivabalance12"]= DBNull.Value; else this["mainstartivabalance12"]= value;}
	}
	public object mainstartivabalance12Value { 
		get{ return this["mainstartivabalance12"];}
		set {if (value==null|| value==DBNull.Value) this["mainstartivabalance12"]= DBNull.Value; else this["mainstartivabalance12"]= value;}
	}
	public Decimal? mainstartivabalance12Original { 
		get {if (this["mainstartivabalance12",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["mainstartivabalance12",DataRowVersion.Original];}
	}
	public Int32? idreg_csa{ 
		get {if (this["idreg_csa"]==DBNull.Value)return null; return  (Int32?)this["idreg_csa"];}
		set {if (value==null) this["idreg_csa"]= DBNull.Value; else this["idreg_csa"]= value;}
	}
	public object idreg_csaValue { 
		get{ return this["idreg_csa"];}
		set {if (value==null|| value==DBNull.Value) this["idreg_csa"]= DBNull.Value; else this["idreg_csa"]= value;}
	}
	public Int32? idreg_csaOriginal { 
		get {if (this["idreg_csa",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg_csa",DataRowVersion.Original];}
	}
	public String finvar_warnmail{ 
		get {if (this["finvar_warnmail"]==DBNull.Value)return null; return  (String)this["finvar_warnmail"];}
		set {if (value==null) this["finvar_warnmail"]= DBNull.Value; else this["finvar_warnmail"]= value;}
	}
	public object finvar_warnmailValue { 
		get{ return this["finvar_warnmail"];}
		set {if (value==null|| value==DBNull.Value) this["finvar_warnmail"]= DBNull.Value; else this["finvar_warnmail"]= value;}
	}
	public String finvar_warnmailOriginal { 
		get {if (this["finvar_warnmail",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["finvar_warnmail",DataRowVersion.Original];}
	}
	public String flagdirectcsaclawback{ 
		get {if (this["flagdirectcsaclawback"]==DBNull.Value)return null; return  (String)this["flagdirectcsaclawback"];}
		set {if (value==null) this["flagdirectcsaclawback"]= DBNull.Value; else this["flagdirectcsaclawback"]= value;}
	}
	public object flagdirectcsaclawbackValue { 
		get{ return this["flagdirectcsaclawback"];}
		set {if (value==null|| value==DBNull.Value) this["flagdirectcsaclawback"]= DBNull.Value; else this["flagdirectcsaclawback"]= value;}
	}
	public String flagdirectcsaclawbackOriginal { 
		get {if (this["flagdirectcsaclawback",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagdirectcsaclawback",DataRowVersion.Original];}
	}
	public String idacc_revenue_gross_csa{ 
		get {if (this["idacc_revenue_gross_csa"]==DBNull.Value)return null; return  (String)this["idacc_revenue_gross_csa"];}
		set {if (value==null) this["idacc_revenue_gross_csa"]= DBNull.Value; else this["idacc_revenue_gross_csa"]= value;}
	}
	public object idacc_revenue_gross_csaValue { 
		get{ return this["idacc_revenue_gross_csa"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_revenue_gross_csa"]= DBNull.Value; else this["idacc_revenue_gross_csa"]= value;}
	}
	public String idacc_revenue_gross_csaOriginal { 
		get {if (this["idacc_revenue_gross_csa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_revenue_gross_csa",DataRowVersion.Original];}
	}
	public Int32? idfinincome_gross_csa{ 
		get {if (this["idfinincome_gross_csa"]==DBNull.Value)return null; return  (Int32?)this["idfinincome_gross_csa"];}
		set {if (value==null) this["idfinincome_gross_csa"]= DBNull.Value; else this["idfinincome_gross_csa"]= value;}
	}
	public object idfinincome_gross_csaValue { 
		get{ return this["idfinincome_gross_csa"];}
		set {if (value==null|| value==DBNull.Value) this["idfinincome_gross_csa"]= DBNull.Value; else this["idfinincome_gross_csa"]= value;}
	}
	public Int32? idfinincome_gross_csaOriginal { 
		get {if (this["idfinincome_gross_csa",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idfinincome_gross_csa",DataRowVersion.Original];}
	}
	public Int32? idsor1_stock{ 
		get {if (this["idsor1_stock"]==DBNull.Value)return null; return  (Int32?)this["idsor1_stock"];}
		set {if (value==null) this["idsor1_stock"]= DBNull.Value; else this["idsor1_stock"]= value;}
	}
	public object idsor1_stockValue { 
		get{ return this["idsor1_stock"];}
		set {if (value==null|| value==DBNull.Value) this["idsor1_stock"]= DBNull.Value; else this["idsor1_stock"]= value;}
	}
	public Int32? idsor1_stockOriginal { 
		get {if (this["idsor1_stock",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor1_stock",DataRowVersion.Original];}
	}
	public Int32? idsor2_stock{ 
		get {if (this["idsor2_stock"]==DBNull.Value)return null; return  (Int32?)this["idsor2_stock"];}
		set {if (value==null) this["idsor2_stock"]= DBNull.Value; else this["idsor2_stock"]= value;}
	}
	public object idsor2_stockValue { 
		get{ return this["idsor2_stock"];}
		set {if (value==null|| value==DBNull.Value) this["idsor2_stock"]= DBNull.Value; else this["idsor2_stock"]= value;}
	}
	public Int32? idsor2_stockOriginal { 
		get {if (this["idsor2_stock",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor2_stock",DataRowVersion.Original];}
	}
	public Int32? idsor3_stock{ 
		get {if (this["idsor3_stock"]==DBNull.Value)return null; return  (Int32?)this["idsor3_stock"];}
		set {if (value==null) this["idsor3_stock"]= DBNull.Value; else this["idsor3_stock"]= value;}
	}
	public object idsor3_stockValue { 
		get{ return this["idsor3_stock"];}
		set {if (value==null|| value==DBNull.Value) this["idsor3_stock"]= DBNull.Value; else this["idsor3_stock"]= value;}
	}
	public Int32? idsor3_stockOriginal { 
		get {if (this["idsor3_stock",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor3_stock",DataRowVersion.Original];}
	}
	public String idinpscenter{ 
		get {if (this["idinpscenter"]==DBNull.Value)return null; return  (String)this["idinpscenter"];}
		set {if (value==null) this["idinpscenter"]= DBNull.Value; else this["idinpscenter"]= value;}
	}
	public object idinpscenterValue { 
		get{ return this["idinpscenter"];}
		set {if (value==null|| value==DBNull.Value) this["idinpscenter"]= DBNull.Value; else this["idinpscenter"]= value;}
	}
	public String idinpscenterOriginal { 
		get {if (this["idinpscenter",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idinpscenter",DataRowVersion.Original];}
	}
	public Int32? idivapayperiodicity_instit{ 
		get {if (this["idivapayperiodicity_instit"]==DBNull.Value)return null; return  (Int32?)this["idivapayperiodicity_instit"];}
		set {if (value==null) this["idivapayperiodicity_instit"]= DBNull.Value; else this["idivapayperiodicity_instit"]= value;}
	}
	public object idivapayperiodicity_institValue { 
		get{ return this["idivapayperiodicity_instit"];}
		set {if (value==null|| value==DBNull.Value) this["idivapayperiodicity_instit"]= DBNull.Value; else this["idivapayperiodicity_instit"]= value;}
	}
	public Int32? idivapayperiodicity_institOriginal { 
		get {if (this["idivapayperiodicity_instit",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idivapayperiodicity_instit",DataRowVersion.Original];}
	}
	public Int32? idfin_store{ 
		get {if (this["idfin_store"]==DBNull.Value)return null; return  (Int32?)this["idfin_store"];}
		set {if (value==null) this["idfin_store"]= DBNull.Value; else this["idfin_store"]= value;}
	}
	public object idfin_storeValue { 
		get{ return this["idfin_store"];}
		set {if (value==null|| value==DBNull.Value) this["idfin_store"]= DBNull.Value; else this["idfin_store"]= value;}
	}
	public Int32? idfin_storeOriginal { 
		get {if (this["idfin_store",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idfin_store",DataRowVersion.Original];}
	}
	public String flagpcashautopayment{ 
		get {if (this["flagpcashautopayment"]==DBNull.Value)return null; return  (String)this["flagpcashautopayment"];}
		set {if (value==null) this["flagpcashautopayment"]= DBNull.Value; else this["flagpcashautopayment"]= value;}
	}
	public object flagpcashautopaymentValue { 
		get{ return this["flagpcashautopayment"];}
		set {if (value==null|| value==DBNull.Value) this["flagpcashautopayment"]= DBNull.Value; else this["flagpcashautopayment"]= value;}
	}
	public String flagpcashautopaymentOriginal { 
		get {if (this["flagpcashautopayment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagpcashautopayment",DataRowVersion.Original];}
	}
	public String flagpcashautoproceeds{ 
		get {if (this["flagpcashautoproceeds"]==DBNull.Value)return null; return  (String)this["flagpcashautoproceeds"];}
		set {if (value==null) this["flagpcashautoproceeds"]= DBNull.Value; else this["flagpcashautoproceeds"]= value;}
	}
	public object flagpcashautoproceedsValue { 
		get{ return this["flagpcashautoproceeds"];}
		set {if (value==null|| value==DBNull.Value) this["flagpcashautoproceeds"]= DBNull.Value; else this["flagpcashautoproceeds"]= value;}
	}
	public String flagpcashautoproceedsOriginal { 
		get {if (this["flagpcashautoproceeds",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagpcashautoproceeds",DataRowVersion.Original];}
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
	public String lcard{ 
		get {if (this["lcard"]==DBNull.Value)return null; return  (String)this["lcard"];}
		set {if (value==null) this["lcard"]= DBNull.Value; else this["lcard"]= value;}
	}
	public object lcardValue { 
		get{ return this["lcard"];}
		set {if (value==null|| value==DBNull.Value) this["lcard"]= DBNull.Value; else this["lcard"]= value;}
	}
	public String lcardOriginal { 
		get {if (this["lcard",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lcard",DataRowVersion.Original];}
	}
	public String booking_on_invoice{ 
		get {if (this["booking_on_invoice"]==DBNull.Value)return null; return  (String)this["booking_on_invoice"];}
		set {if (value==null) this["booking_on_invoice"]= DBNull.Value; else this["booking_on_invoice"]= value;}
	}
	public object booking_on_invoiceValue { 
		get{ return this["booking_on_invoice"];}
		set {if (value==null|| value==DBNull.Value) this["booking_on_invoice"]= DBNull.Value; else this["booking_on_invoice"]= value;}
	}
	public String booking_on_invoiceOriginal { 
		get {if (this["booking_on_invoice",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["booking_on_invoice",DataRowVersion.Original];}
	}
	public String itineration_directauth{ 
		get {if (this["itineration_directauth"]==DBNull.Value)return null; return  (String)this["itineration_directauth"];}
		set {if (value==null) this["itineration_directauth"]= DBNull.Value; else this["itineration_directauth"]= value;}
	}
	public object itineration_directauthValue { 
		get{ return this["itineration_directauth"];}
		set {if (value==null|| value==DBNull.Value) this["itineration_directauth"]= DBNull.Value; else this["itineration_directauth"]= value;}
	}
	public String itineration_directauthOriginal { 
		get {if (this["itineration_directauth",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["itineration_directauth",DataRowVersion.Original];}
	}
	public String email_f24{ 
		get {if (this["email_f24"]==DBNull.Value)return null; return  (String)this["email_f24"];}
		set {if (value==null) this["email_f24"]= DBNull.Value; else this["email_f24"]= value;}
	}
	public object email_f24Value { 
		get{ return this["email_f24"];}
		set {if (value==null|| value==DBNull.Value) this["email_f24"]= DBNull.Value; else this["email_f24"]= value;}
	}
	public String email_f24Original { 
		get {if (this["email_f24",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["email_f24",DataRowVersion.Original];}
	}
	public String csa_flaggroupby_income{ 
		get {if (this["csa_flaggroupby_income"]==DBNull.Value)return null; return  (String)this["csa_flaggroupby_income"];}
		set {if (value==null) this["csa_flaggroupby_income"]= DBNull.Value; else this["csa_flaggroupby_income"]= value;}
	}
	public object csa_flaggroupby_incomeValue { 
		get{ return this["csa_flaggroupby_income"];}
		set {if (value==null|| value==DBNull.Value) this["csa_flaggroupby_income"]= DBNull.Value; else this["csa_flaggroupby_income"]= value;}
	}
	public String csa_flaggroupby_incomeOriginal { 
		get {if (this["csa_flaggroupby_income",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["csa_flaggroupby_income",DataRowVersion.Original];}
	}
	public String csa_flaggroupby_expense{ 
		get {if (this["csa_flaggroupby_expense"]==DBNull.Value)return null; return  (String)this["csa_flaggroupby_expense"];}
		set {if (value==null) this["csa_flaggroupby_expense"]= DBNull.Value; else this["csa_flaggroupby_expense"]= value;}
	}
	public object csa_flaggroupby_expenseValue { 
		get{ return this["csa_flaggroupby_expense"];}
		set {if (value==null|| value==DBNull.Value) this["csa_flaggroupby_expense"]= DBNull.Value; else this["csa_flaggroupby_expense"]= value;}
	}
	public String csa_flaggroupby_expenseOriginal { 
		get {if (this["csa_flaggroupby_expense",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["csa_flaggroupby_expense",DataRowVersion.Original];}
	}
	public String csa_flaglinktoexp{ 
		get {if (this["csa_flaglinktoexp"]==DBNull.Value)return null; return  (String)this["csa_flaglinktoexp"];}
		set {if (value==null) this["csa_flaglinktoexp"]= DBNull.Value; else this["csa_flaglinktoexp"]= value;}
	}
	public object csa_flaglinktoexpValue { 
		get{ return this["csa_flaglinktoexp"];}
		set {if (value==null|| value==DBNull.Value) this["csa_flaglinktoexp"]= DBNull.Value; else this["csa_flaglinktoexp"]= value;}
	}
	public String csa_flaglinktoexpOriginal { 
		get {if (this["csa_flaglinktoexp",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["csa_flaglinktoexp",DataRowVersion.Original];}
	}
	public String csa_nominativo{ 
		get {if (this["csa_nominativo"]==DBNull.Value)return null; return  (String)this["csa_nominativo"];}
		set {if (value==null) this["csa_nominativo"]= DBNull.Value; else this["csa_nominativo"]= value;}
	}
	public object csa_nominativoValue { 
		get{ return this["csa_nominativo"];}
		set {if (value==null|| value==DBNull.Value) this["csa_nominativo"]= DBNull.Value; else this["csa_nominativo"]= value;}
	}
	public String csa_nominativoOriginal { 
		get {if (this["csa_nominativo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["csa_nominativo",DataRowVersion.Original];}
	}
	public Int32? idsiopeincome_csa{ 
		get {if (this["idsiopeincome_csa"]==DBNull.Value)return null; return  (Int32?)this["idsiopeincome_csa"];}
		set {if (value==null) this["idsiopeincome_csa"]= DBNull.Value; else this["idsiopeincome_csa"]= value;}
	}
	public object idsiopeincome_csaValue { 
		get{ return this["idsiopeincome_csa"];}
		set {if (value==null|| value==DBNull.Value) this["idsiopeincome_csa"]= DBNull.Value; else this["idsiopeincome_csa"]= value;}
	}
	public Int32? idsiopeincome_csaOriginal { 
		get {if (this["idsiopeincome_csa",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsiopeincome_csa",DataRowVersion.Original];}
	}
	public String idacc_invoicetoemit{ 
		get {if (this["idacc_invoicetoemit"]==DBNull.Value)return null; return  (String)this["idacc_invoicetoemit"];}
		set {if (value==null) this["idacc_invoicetoemit"]= DBNull.Value; else this["idacc_invoicetoemit"]= value;}
	}
	public object idacc_invoicetoemitValue { 
		get{ return this["idacc_invoicetoemit"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_invoicetoemit"]= DBNull.Value; else this["idacc_invoicetoemit"]= value;}
	}
	public String idacc_invoicetoemitOriginal { 
		get {if (this["idacc_invoicetoemit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_invoicetoemit",DataRowVersion.Original];}
	}
	public String idacc_invoicetoreceive{ 
		get {if (this["idacc_invoicetoreceive"]==DBNull.Value)return null; return  (String)this["idacc_invoicetoreceive"];}
		set {if (value==null) this["idacc_invoicetoreceive"]= DBNull.Value; else this["idacc_invoicetoreceive"]= value;}
	}
	public object idacc_invoicetoreceiveValue { 
		get{ return this["idacc_invoicetoreceive"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_invoicetoreceive"]= DBNull.Value; else this["idacc_invoicetoreceive"]= value;}
	}
	public String idacc_invoicetoreceiveOriginal { 
		get {if (this["idacc_invoicetoreceive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_invoicetoreceive",DataRowVersion.Original];}
	}
	public Decimal? epannualthreeshold{ 
		get {if (this["epannualthreeshold"]==DBNull.Value)return null; return  (Decimal?)this["epannualthreeshold"];}
		set {if (value==null) this["epannualthreeshold"]= DBNull.Value; else this["epannualthreeshold"]= value;}
	}
	public object epannualthreesholdValue { 
		get{ return this["epannualthreeshold"];}
		set {if (value==null|| value==DBNull.Value) this["epannualthreeshold"]= DBNull.Value; else this["epannualthreeshold"]= value;}
	}
	public Decimal? epannualthreesholdOriginal { 
		get {if (this["epannualthreeshold",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["epannualthreeshold",DataRowVersion.Original];}
	}
	public String flagbalance_csa{ 
		get {if (this["flagbalance_csa"]==DBNull.Value)return null; return  (String)this["flagbalance_csa"];}
		set {if (value==null) this["flagbalance_csa"]= DBNull.Value; else this["flagbalance_csa"]= value;}
	}
	public object flagbalance_csaValue { 
		get{ return this["flagbalance_csa"];}
		set {if (value==null|| value==DBNull.Value) this["flagbalance_csa"]= DBNull.Value; else this["flagbalance_csa"]= value;}
	}
	public String flagbalance_csaOriginal { 
		get {if (this["flagbalance_csa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagbalance_csa",DataRowVersion.Original];}
	}
	public String flagiva_immediate_or_deferred{ 
		get {if (this["flagiva_immediate_or_deferred"]==DBNull.Value)return null; return  (String)this["flagiva_immediate_or_deferred"];}
		set {if (value==null) this["flagiva_immediate_or_deferred"]= DBNull.Value; else this["flagiva_immediate_or_deferred"]= value;}
	}
	public object flagiva_immediate_or_deferredValue { 
		get{ return this["flagiva_immediate_or_deferred"];}
		set {if (value==null|| value==DBNull.Value) this["flagiva_immediate_or_deferred"]= DBNull.Value; else this["flagiva_immediate_or_deferred"]= value;}
	}
	public String flagiva_immediate_or_deferredOriginal { 
		get {if (this["flagiva_immediate_or_deferred",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagiva_immediate_or_deferred",DataRowVersion.Original];}
	}
	public String flagenabletransmission{ 
		get {if (this["flagenabletransmission"]==DBNull.Value)return null; return  (String)this["flagenabletransmission"];}
		set {if (value==null) this["flagenabletransmission"]= DBNull.Value; else this["flagenabletransmission"]= value;}
	}
	public object flagenabletransmissionValue { 
		get{ return this["flagenabletransmission"];}
		set {if (value==null|| value==DBNull.Value) this["flagenabletransmission"]= DBNull.Value; else this["flagenabletransmission"]= value;}
	}
	public String flagenabletransmissionOriginal { 
		get {if (this["flagenabletransmission",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagenabletransmission",DataRowVersion.Original];}
	}
	public String idpccdebitstatus{ 
		get {if (this["idpccdebitstatus"]==DBNull.Value)return null; return  (String)this["idpccdebitstatus"];}
		set {if (value==null) this["idpccdebitstatus"]= DBNull.Value; else this["idpccdebitstatus"]= value;}
	}
	public object idpccdebitstatusValue { 
		get{ return this["idpccdebitstatus"];}
		set {if (value==null|| value==DBNull.Value) this["idpccdebitstatus"]= DBNull.Value; else this["idpccdebitstatus"]= value;}
	}
	public String idpccdebitstatusOriginal { 
		get {if (this["idpccdebitstatus",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idpccdebitstatus",DataRowVersion.Original];}
	}
	public String flagsplitpayment{ 
		get {if (this["flagsplitpayment"]==DBNull.Value)return null; return  (String)this["flagsplitpayment"];}
		set {if (value==null) this["flagsplitpayment"]= DBNull.Value; else this["flagsplitpayment"]= value;}
	}
	public object flagsplitpaymentValue { 
		get{ return this["flagsplitpayment"];}
		set {if (value==null|| value==DBNull.Value) this["flagsplitpayment"]= DBNull.Value; else this["flagsplitpayment"]= value;}
	}
	public String flagsplitpaymentOriginal { 
		get {if (this["flagsplitpayment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagsplitpayment",DataRowVersion.Original];}
	}
	public Decimal? startivabalancesplit{ 
		get {if (this["startivabalancesplit"]==DBNull.Value)return null; return  (Decimal?)this["startivabalancesplit"];}
		set {if (value==null) this["startivabalancesplit"]= DBNull.Value; else this["startivabalancesplit"]= value;}
	}
	public object startivabalancesplitValue { 
		get{ return this["startivabalancesplit"];}
		set {if (value==null|| value==DBNull.Value) this["startivabalancesplit"]= DBNull.Value; else this["startivabalancesplit"]= value;}
	}
	public Decimal? startivabalancesplitOriginal { 
		get {if (this["startivabalancesplit",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["startivabalancesplit",DataRowVersion.Original];}
	}
	public Int32? paymentagencysplit{ 
		get {if (this["paymentagencysplit"]==DBNull.Value)return null; return  (Int32?)this["paymentagencysplit"];}
		set {if (value==null) this["paymentagencysplit"]= DBNull.Value; else this["paymentagencysplit"]= value;}
	}
	public object paymentagencysplitValue { 
		get{ return this["paymentagencysplit"];}
		set {if (value==null|| value==DBNull.Value) this["paymentagencysplit"]= DBNull.Value; else this["paymentagencysplit"]= value;}
	}
	public Int32? paymentagencysplitOriginal { 
		get {if (this["paymentagencysplit",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["paymentagencysplit",DataRowVersion.Original];}
	}
	public Int32? idfinivapaymentsplit{ 
		get {if (this["idfinivapaymentsplit"]==DBNull.Value)return null; return  (Int32?)this["idfinivapaymentsplit"];}
		set {if (value==null) this["idfinivapaymentsplit"]= DBNull.Value; else this["idfinivapaymentsplit"]= value;}
	}
	public object idfinivapaymentsplitValue { 
		get{ return this["idfinivapaymentsplit"];}
		set {if (value==null|| value==DBNull.Value) this["idfinivapaymentsplit"]= DBNull.Value; else this["idfinivapaymentsplit"]= value;}
	}
	public Int32? idfinivapaymentsplitOriginal { 
		get {if (this["idfinivapaymentsplit",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idfinivapaymentsplit",DataRowVersion.Original];}
	}
	public String flagpaymentsplit{ 
		get {if (this["flagpaymentsplit"]==DBNull.Value)return null; return  (String)this["flagpaymentsplit"];}
		set {if (value==null) this["flagpaymentsplit"]= DBNull.Value; else this["flagpaymentsplit"]= value;}
	}
	public object flagpaymentsplitValue { 
		get{ return this["flagpaymentsplit"];}
		set {if (value==null|| value==DBNull.Value) this["flagpaymentsplit"]= DBNull.Value; else this["flagpaymentsplit"]= value;}
	}
	public String flagpaymentsplitOriginal { 
		get {if (this["flagpaymentsplit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagpaymentsplit",DataRowVersion.Original];}
	}
	public String idacc_unabatable_split{ 
		get {if (this["idacc_unabatable_split"]==DBNull.Value)return null; return  (String)this["idacc_unabatable_split"];}
		set {if (value==null) this["idacc_unabatable_split"]= DBNull.Value; else this["idacc_unabatable_split"]= value;}
	}
	public object idacc_unabatable_splitValue { 
		get{ return this["idacc_unabatable_split"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_unabatable_split"]= DBNull.Value; else this["idacc_unabatable_split"]= value;}
	}
	public String idacc_unabatable_splitOriginal { 
		get {if (this["idacc_unabatable_split",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_unabatable_split",DataRowVersion.Original];}
	}
	public String idacc_ivapaymentsplit{ 
		get {if (this["idacc_ivapaymentsplit"]==DBNull.Value)return null; return  (String)this["idacc_ivapaymentsplit"];}
		set {if (value==null) this["idacc_ivapaymentsplit"]= DBNull.Value; else this["idacc_ivapaymentsplit"]= value;}
	}
	public object idacc_ivapaymentsplitValue { 
		get{ return this["idacc_ivapaymentsplit"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_ivapaymentsplit"]= DBNull.Value; else this["idacc_ivapaymentsplit"]= value;}
	}
	public String idacc_ivapaymentsplitOriginal { 
		get {if (this["idacc_ivapaymentsplit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_ivapaymentsplit",DataRowVersion.Original];}
	}
	public String agencynumber{ 
		get {if (this["agencynumber"]==DBNull.Value)return null; return  (String)this["agencynumber"];}
		set {if (value==null) this["agencynumber"]= DBNull.Value; else this["agencynumber"]= value;}
	}
	public object agencynumberValue { 
		get{ return this["agencynumber"];}
		set {if (value==null|| value==DBNull.Value) this["agencynumber"]= DBNull.Value; else this["agencynumber"]= value;}
	}
	public String agencynumberOriginal { 
		get {if (this["agencynumber",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["agencynumber",DataRowVersion.Original];}
	}
	public String femode{ 
		get {if (this["femode"]==DBNull.Value)return null; return  (String)this["femode"];}
		set {if (value==null) this["femode"]= DBNull.Value; else this["femode"]= value;}
	}
	public object femodeValue { 
		get{ return this["femode"];}
		set {if (value==null|| value==DBNull.Value) this["femode"]= DBNull.Value; else this["femode"]= value;}
	}
	public String femodeOriginal { 
		get {if (this["femode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["femode",DataRowVersion.Original];}
	}
	public String idacc_economic_result{ 
		get {if (this["idacc_economic_result"]==DBNull.Value)return null; return  (String)this["idacc_economic_result"];}
		set {if (value==null) this["idacc_economic_result"]= DBNull.Value; else this["idacc_economic_result"]= value;}
	}
	public object idacc_economic_resultValue { 
		get{ return this["idacc_economic_result"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_economic_result"]= DBNull.Value; else this["idacc_economic_result"]= value;}
	}
	public String idacc_economic_resultOriginal { 
		get {if (this["idacc_economic_result",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_economic_result",DataRowVersion.Original];}
	}
	public String idacc_previous_economic_result{ 
		get {if (this["idacc_previous_economic_result"]==DBNull.Value)return null; return  (String)this["idacc_previous_economic_result"];}
		set {if (value==null) this["idacc_previous_economic_result"]= DBNull.Value; else this["idacc_previous_economic_result"]= value;}
	}
	public object idacc_previous_economic_resultValue { 
		get{ return this["idacc_previous_economic_result"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_previous_economic_result"]= DBNull.Value; else this["idacc_previous_economic_result"]= value;}
	}
	public String idacc_previous_economic_resultOriginal { 
		get {if (this["idacc_previous_economic_result",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_previous_economic_result",DataRowVersion.Original];}
	}
	public String idacc_bankpaydoc{ 
		get {if (this["idacc_bankpaydoc"]==DBNull.Value)return null; return  (String)this["idacc_bankpaydoc"];}
		set {if (value==null) this["idacc_bankpaydoc"]= DBNull.Value; else this["idacc_bankpaydoc"]= value;}
	}
	public object idacc_bankpaydocValue { 
		get{ return this["idacc_bankpaydoc"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_bankpaydoc"]= DBNull.Value; else this["idacc_bankpaydoc"]= value;}
	}
	public String idacc_bankpaydocOriginal { 
		get {if (this["idacc_bankpaydoc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_bankpaydoc",DataRowVersion.Original];}
	}
	public String idacc_bankprodoc{ 
		get {if (this["idacc_bankprodoc"]==DBNull.Value)return null; return  (String)this["idacc_bankprodoc"];}
		set {if (value==null) this["idacc_bankprodoc"]= DBNull.Value; else this["idacc_bankprodoc"]= value;}
	}
	public object idacc_bankprodocValue { 
		get{ return this["idacc_bankprodoc"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_bankprodoc"]= DBNull.Value; else this["idacc_bankprodoc"]= value;}
	}
	public String idacc_bankprodocOriginal { 
		get {if (this["idacc_bankprodoc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_bankprodoc",DataRowVersion.Original];}
	}
	public String csa_flagtransmissionlinking{ 
		get {if (this["csa_flagtransmissionlinking"]==DBNull.Value)return null; return  (String)this["csa_flagtransmissionlinking"];}
		set {if (value==null) this["csa_flagtransmissionlinking"]= DBNull.Value; else this["csa_flagtransmissionlinking"]= value;}
	}
	public object csa_flagtransmissionlinkingValue { 
		get{ return this["csa_flagtransmissionlinking"];}
		set {if (value==null|| value==DBNull.Value) this["csa_flagtransmissionlinking"]= DBNull.Value; else this["csa_flagtransmissionlinking"]= value;}
	}
	public String csa_flagtransmissionlinkingOriginal { 
		get {if (this["csa_flagtransmissionlinking",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["csa_flagtransmissionlinking",DataRowVersion.Original];}
	}
	public Int32? csa_idchargehandling{ 
		get {if (this["csa_idchargehandling"]==DBNull.Value)return null; return  (Int32?)this["csa_idchargehandling"];}
		set {if (value==null) this["csa_idchargehandling"]= DBNull.Value; else this["csa_idchargehandling"]= value;}
	}
	public object csa_idchargehandlingValue { 
		get{ return this["csa_idchargehandling"];}
		set {if (value==null|| value==DBNull.Value) this["csa_idchargehandling"]= DBNull.Value; else this["csa_idchargehandling"]= value;}
	}
	public Int32? csa_idchargehandlingOriginal { 
		get {if (this["csa_idchargehandling",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["csa_idchargehandling",DataRowVersion.Original];}
	}
	public Int32? csa_flag{ 
		get {if (this["csa_flag"]==DBNull.Value)return null; return  (Int32?)this["csa_flag"];}
		set {if (value==null) this["csa_flag"]= DBNull.Value; else this["csa_flag"]= value;}
	}
	public object csa_flagValue { 
		get{ return this["csa_flag"];}
		set {if (value==null|| value==DBNull.Value) this["csa_flag"]= DBNull.Value; else this["csa_flag"]= value;}
	}
	public Int32? csa_flagOriginal { 
		get {if (this["csa_flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["csa_flag",DataRowVersion.Original];}
	}
	public String idaccmotive_forwarder{ 
		get {if (this["idaccmotive_forwarder"]==DBNull.Value)return null; return  (String)this["idaccmotive_forwarder"];}
		set {if (value==null) this["idaccmotive_forwarder"]= DBNull.Value; else this["idaccmotive_forwarder"]= value;}
	}
	public object idaccmotive_forwarderValue { 
		get{ return this["idaccmotive_forwarder"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive_forwarder"]= DBNull.Value; else this["idaccmotive_forwarder"]= value;}
	}
	public String idaccmotive_forwarderOriginal { 
		get {if (this["idaccmotive_forwarder",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive_forwarder",DataRowVersion.Original];}
	}
	public Int32? idivakind_forwarder{ 
		get {if (this["idivakind_forwarder"]==DBNull.Value)return null; return  (Int32?)this["idivakind_forwarder"];}
		set {if (value==null) this["idivakind_forwarder"]= DBNull.Value; else this["idivakind_forwarder"]= value;}
	}
	public object idivakind_forwarderValue { 
		get{ return this["idivakind_forwarder"];}
		set {if (value==null|| value==DBNull.Value) this["idivakind_forwarder"]= DBNull.Value; else this["idivakind_forwarder"]= value;}
	}
	public Int32? idivakind_forwarderOriginal { 
		get {if (this["idivakind_forwarder",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idivakind_forwarder",DataRowVersion.Original];}
	}
	public String idaccmotive_grantrevenue{ 
		get {if (this["idaccmotive_grantrevenue"]==DBNull.Value)return null; return  (String)this["idaccmotive_grantrevenue"];}
		set {if (value==null) this["idaccmotive_grantrevenue"]= DBNull.Value; else this["idaccmotive_grantrevenue"]= value;}
	}
	public object idaccmotive_grantrevenueValue { 
		get{ return this["idaccmotive_grantrevenue"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive_grantrevenue"]= DBNull.Value; else this["idaccmotive_grantrevenue"]= value;}
	}
	public String idaccmotive_grantrevenueOriginal { 
		get {if (this["idaccmotive_grantrevenue",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive_grantrevenue",DataRowVersion.Original];}
	}
	public String idaccmotive_grantdeferredcost{ 
		get {if (this["idaccmotive_grantdeferredcost"]==DBNull.Value)return null; return  (String)this["idaccmotive_grantdeferredcost"];}
		set {if (value==null) this["idaccmotive_grantdeferredcost"]= DBNull.Value; else this["idaccmotive_grantdeferredcost"]= value;}
	}
	public object idaccmotive_grantdeferredcostValue { 
		get{ return this["idaccmotive_grantdeferredcost"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive_grantdeferredcost"]= DBNull.Value; else this["idaccmotive_grantdeferredcost"]= value;}
	}
	public String idaccmotive_grantdeferredcostOriginal { 
		get {if (this["idaccmotive_grantdeferredcost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive_grantdeferredcost",DataRowVersion.Original];}
	}
	public String idaccmotive_assetrevenue{ 
		get {if (this["idaccmotive_assetrevenue"]==DBNull.Value)return null; return  (String)this["idaccmotive_assetrevenue"];}
		set {if (value==null) this["idaccmotive_assetrevenue"]= DBNull.Value; else this["idaccmotive_assetrevenue"]= value;}
	}
	public object idaccmotive_assetrevenueValue { 
		get{ return this["idaccmotive_assetrevenue"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive_assetrevenue"]= DBNull.Value; else this["idaccmotive_assetrevenue"]= value;}
	}
	public String idaccmotive_assetrevenueOriginal { 
		get {if (this["idaccmotive_assetrevenue",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive_assetrevenue",DataRowVersion.Original];}
	}
	public String idaccmotive_prorata_cost{ 
		get {if (this["idaccmotive_prorata_cost"]==DBNull.Value)return null; return  (String)this["idaccmotive_prorata_cost"];}
		set {if (value==null) this["idaccmotive_prorata_cost"]= DBNull.Value; else this["idaccmotive_prorata_cost"]= value;}
	}
	public object idaccmotive_prorata_costValue { 
		get{ return this["idaccmotive_prorata_cost"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive_prorata_cost"]= DBNull.Value; else this["idaccmotive_prorata_cost"]= value;}
	}
	public String idaccmotive_prorata_costOriginal { 
		get {if (this["idaccmotive_prorata_cost",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive_prorata_cost",DataRowVersion.Original];}
	}
	public String idaccmotive_prorata_revenue{ 
		get {if (this["idaccmotive_prorata_revenue"]==DBNull.Value)return null; return  (String)this["idaccmotive_prorata_revenue"];}
		set {if (value==null) this["idaccmotive_prorata_revenue"]= DBNull.Value; else this["idaccmotive_prorata_revenue"]= value;}
	}
	public object idaccmotive_prorata_revenueValue { 
		get{ return this["idaccmotive_prorata_revenue"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive_prorata_revenue"]= DBNull.Value; else this["idaccmotive_prorata_revenue"]= value;}
	}
	public String idaccmotive_prorata_revenueOriginal { 
		get {if (this["idaccmotive_prorata_revenue",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive_prorata_revenue",DataRowVersion.Original];}
	}
	public Int32? idsor_siopeivaexp{ 
		get {if (this["idsor_siopeivaexp"]==DBNull.Value)return null; return  (Int32?)this["idsor_siopeivaexp"];}
		set {if (value==null) this["idsor_siopeivaexp"]= DBNull.Value; else this["idsor_siopeivaexp"]= value;}
	}
	public object idsor_siopeivaexpValue { 
		get{ return this["idsor_siopeivaexp"];}
		set {if (value==null|| value==DBNull.Value) this["idsor_siopeivaexp"]= DBNull.Value; else this["idsor_siopeivaexp"]= value;}
	}
	public Int32? idsor_siopeivaexpOriginal { 
		get {if (this["idsor_siopeivaexp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor_siopeivaexp",DataRowVersion.Original];}
	}
	public Int32? idsor_siopeiva12exp{ 
		get {if (this["idsor_siopeiva12exp"]==DBNull.Value)return null; return  (Int32?)this["idsor_siopeiva12exp"];}
		set {if (value==null) this["idsor_siopeiva12exp"]= DBNull.Value; else this["idsor_siopeiva12exp"]= value;}
	}
	public object idsor_siopeiva12expValue { 
		get{ return this["idsor_siopeiva12exp"];}
		set {if (value==null|| value==DBNull.Value) this["idsor_siopeiva12exp"]= DBNull.Value; else this["idsor_siopeiva12exp"]= value;}
	}
	public Int32? idsor_siopeiva12expOriginal { 
		get {if (this["idsor_siopeiva12exp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor_siopeiva12exp",DataRowVersion.Original];}
	}
	public Int32? idsor_siopeivasplitexp{ 
		get {if (this["idsor_siopeivasplitexp"]==DBNull.Value)return null; return  (Int32?)this["idsor_siopeivasplitexp"];}
		set {if (value==null) this["idsor_siopeivasplitexp"]= DBNull.Value; else this["idsor_siopeivasplitexp"]= value;}
	}
	public object idsor_siopeivasplitexpValue { 
		get{ return this["idsor_siopeivasplitexp"];}
		set {if (value==null|| value==DBNull.Value) this["idsor_siopeivasplitexp"]= DBNull.Value; else this["idsor_siopeivasplitexp"]= value;}
	}
	public Int32? idsor_siopeivasplitexpOriginal { 
		get {if (this["idsor_siopeivasplitexp",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor_siopeivasplitexp",DataRowVersion.Original];}
	}
	public Int32? idsor_siopeivainc{ 
		get {if (this["idsor_siopeivainc"]==DBNull.Value)return null; return  (Int32?)this["idsor_siopeivainc"];}
		set {if (value==null) this["idsor_siopeivainc"]= DBNull.Value; else this["idsor_siopeivainc"]= value;}
	}
	public object idsor_siopeivaincValue { 
		get{ return this["idsor_siopeivainc"];}
		set {if (value==null|| value==DBNull.Value) this["idsor_siopeivainc"]= DBNull.Value; else this["idsor_siopeivainc"]= value;}
	}
	public Int32? idsor_siopeivaincOriginal { 
		get {if (this["idsor_siopeivainc",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor_siopeivainc",DataRowVersion.Original];}
	}
	public Int32? idsor_siopeiva12inc{ 
		get {if (this["idsor_siopeiva12inc"]==DBNull.Value)return null; return  (Int32?)this["idsor_siopeiva12inc"];}
		set {if (value==null) this["idsor_siopeiva12inc"]= DBNull.Value; else this["idsor_siopeiva12inc"]= value;}
	}
	public object idsor_siopeiva12incValue { 
		get{ return this["idsor_siopeiva12inc"];}
		set {if (value==null|| value==DBNull.Value) this["idsor_siopeiva12inc"]= DBNull.Value; else this["idsor_siopeiva12inc"]= value;}
	}
	public Int32? idsor_siopeiva12incOriginal { 
		get {if (this["idsor_siopeiva12inc",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor_siopeiva12inc",DataRowVersion.Original];}
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
	public Decimal? assignedrequirement{ 
		get {if (this["assignedrequirement"]==DBNull.Value)return null; return  (Decimal?)this["assignedrequirement"];}
		set {if (value==null) this["assignedrequirement"]= DBNull.Value; else this["assignedrequirement"]= value;}
	}
	public object assignedrequirementValue { 
		get{ return this["assignedrequirement"];}
		set {if (value==null|| value==DBNull.Value) this["assignedrequirement"]= DBNull.Value; else this["assignedrequirement"]= value;}
	}
	public Decimal? assignedrequirementOriginal { 
		get {if (this["assignedrequirement",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["assignedrequirement",DataRowVersion.Original];}
	}
	public String risconta_ammortamenti_futuri{ 
		get {if (this["risconta_ammortamenti_futuri"]==DBNull.Value)return null; return  (String)this["risconta_ammortamenti_futuri"];}
		set {if (value==null) this["risconta_ammortamenti_futuri"]= DBNull.Value; else this["risconta_ammortamenti_futuri"]= value;}
	}
	public object risconta_ammortamenti_futuriValue { 
		get{ return this["risconta_ammortamenti_futuri"];}
		set {if (value==null|| value==DBNull.Value) this["risconta_ammortamenti_futuri"]= DBNull.Value; else this["risconta_ammortamenti_futuri"]= value;}
	}
	public String risconta_ammortamenti_futuriOriginal { 
		get {if (this["risconta_ammortamenti_futuri",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["risconta_ammortamenti_futuri",DataRowVersion.Original];}
	}
	public String idacc_unabatable_estera{ 
		get {if (this["idacc_unabatable_estera"]==DBNull.Value)return null; return  (String)this["idacc_unabatable_estera"];}
		set {if (value==null) this["idacc_unabatable_estera"]= DBNull.Value; else this["idacc_unabatable_estera"]= value;}
	}
	public object idacc_unabatable_esteraValue { 
		get{ return this["idacc_unabatable_estera"];}
		set {if (value==null|| value==DBNull.Value) this["idacc_unabatable_estera"]= DBNull.Value; else this["idacc_unabatable_estera"]= value;}
	}
	public String idacc_unabatable_esteraOriginal { 
		get {if (this["idacc_unabatable_estera",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacc_unabatable_estera",DataRowVersion.Original];}
	}
	public Int32? idsor_siopeivavendita{ 
		get {if (this["idsor_siopeivavendita"]==DBNull.Value)return null; return  (Int32?)this["idsor_siopeivavendita"];}
		set {if (value==null) this["idsor_siopeivavendita"]= DBNull.Value; else this["idsor_siopeivavendita"]= value;}
	}
	public object idsor_siopeivavenditaValue { 
		get{ return this["idsor_siopeivavendita"];}
		set {if (value==null|| value==DBNull.Value) this["idsor_siopeivavendita"]= DBNull.Value; else this["idsor_siopeivavendita"]= value;}
	}
	public Int32? idsor_siopeivavenditaOriginal { 
		get {if (this["idsor_siopeivavendita",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor_siopeivavendita",DataRowVersion.Original];}
	}
	#endregion

}
public class configTable : MetaTableBase<configRow> {
	public configTable() : base("config"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ayear",createColumn("ayear",typeof(short),false,false)},
			{"agencycode",createColumn("agencycode",typeof(string),true,false)},
			{"appname",createColumn("appname",typeof(string),true,false)},
			{"appropriationphasecode",createColumn("appropriationphasecode",typeof(byte),true,false)},
			{"assessmentphasecode",createColumn("assessmentphasecode",typeof(byte),true,false)},
			{"asset_flagnumbering",createColumn("asset_flagnumbering",typeof(string),true,false)},
			{"asset_flagrestart",createColumn("asset_flagrestart",typeof(string),true,false)},
			{"assetload_flag",createColumn("assetload_flag",typeof(byte),true,false)},
			{"boxpartitiontitle",createColumn("boxpartitiontitle",typeof(string),true,false)},
			{"finvarofficial_default",createColumn("finvarofficial_default",typeof(string),true,false)},
			{"casualcontract_flagrestart",createColumn("casualcontract_flagrestart",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"currpartitiontitle",createColumn("currpartitiontitle",typeof(string),true,false)},
			{"deferredexpensephase",createColumn("deferredexpensephase",typeof(string),true,false)},
			{"deferredincomephase",createColumn("deferredincomephase",typeof(string),true,false)},
			{"electronicimport",createColumn("electronicimport",typeof(string),true,false)},
			{"electronictrasmission",createColumn("electronictrasmission",typeof(string),true,false)},
			{"expense_expiringdays",createColumn("expense_expiringdays",typeof(short),true,false)},
			{"expensephase",createColumn("expensephase",typeof(byte),true,false)},
			{"flagautopayment",createColumn("flagautopayment",typeof(string),true,false)},
			{"flagautoproceeds",createColumn("flagautoproceeds",typeof(string),true,false)},
			{"flagcredit",createColumn("flagcredit",typeof(string),true,false)},
			{"flagepexp",createColumn("flagepexp",typeof(string),true,false)},
			{"flagfruitful",createColumn("flagfruitful",typeof(string),true,false)},
			{"flagpayment",createColumn("flagpayment",typeof(string),true,false)},
			{"flagproceeds",createColumn("flagproceeds",typeof(string),true,false)},
			{"flagrefund",createColumn("flagrefund",typeof(string),true,false)},
			{"foreignhours",createColumn("foreignhours",typeof(int),true,false)},
			{"idacc_accruedcost",createColumn("idacc_accruedcost",typeof(string),true,false)},
			{"idacc_accruedrevenue",createColumn("idacc_accruedrevenue",typeof(string),true,false)},
			{"idacc_customer",createColumn("idacc_customer",typeof(string),true,false)},
			{"idacc_deferredcost",createColumn("idacc_deferredcost",typeof(string),true,false)},
			{"idacc_deferredcredit",createColumn("idacc_deferredcredit",typeof(string),true,false)},
			{"idacc_deferreddebit",createColumn("idacc_deferreddebit",typeof(string),true,false)},
			{"idacc_deferredrevenue",createColumn("idacc_deferredrevenue",typeof(string),true,false)},
			{"idacc_ivapayment",createColumn("idacc_ivapayment",typeof(string),true,false)},
			{"idacc_ivarefund",createColumn("idacc_ivarefund",typeof(string),true,false)},
			{"idacc_patrimony",createColumn("idacc_patrimony",typeof(string),true,false)},
			{"idacc_pl",createColumn("idacc_pl",typeof(string),true,false)},
			{"idacc_supplier",createColumn("idacc_supplier",typeof(string),true,false)},
			{"idaccmotive_admincar",createColumn("idaccmotive_admincar",typeof(string),true,false)},
			{"idaccmotive_foot",createColumn("idaccmotive_foot",typeof(string),true,false)},
			{"idaccmotive_owncar",createColumn("idaccmotive_owncar",typeof(string),true,false)},
			{"idclawback",createColumn("idclawback",typeof(int),true,false)},
			{"idfinexpense",createColumn("idfinexpense",typeof(int),true,false)},
			{"idfinexpensesurplus",createColumn("idfinexpensesurplus",typeof(int),true,false)},
			{"idfinincomesurplus",createColumn("idfinincomesurplus",typeof(int),true,false)},
			{"idfinivapayment",createColumn("idfinivapayment",typeof(int),true,false)},
			{"idfinivarefund",createColumn("idfinivarefund",typeof(int),true,false)},
			{"idregauto",createColumn("idregauto",typeof(int),true,false)},
			{"importappname",createColumn("importappname",typeof(string),true,false)},
			{"income_expiringdays",createColumn("income_expiringdays",typeof(short),true,false)},
			{"incomephase",createColumn("incomephase",typeof(byte),true,false)},
			{"linktoinvoice",createColumn("linktoinvoice",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"minpayment",createColumn("minpayment",typeof(decimal),true,false)},
			{"minrefund",createColumn("minrefund",typeof(decimal),true,false)},
			{"motivelen",createColumn("motivelen",typeof(short),true,false)},
			{"motiveprefix",createColumn("motiveprefix",typeof(string),true,false)},
			{"motiveseparator",createColumn("motiveseparator",typeof(string),true,false)},
			{"payment_finlevel",createColumn("payment_finlevel",typeof(byte),true,false)},
			{"payment_flag",createColumn("payment_flag",typeof(byte),true,false)},
			{"payment_flagautoprintdate",createColumn("payment_flagautoprintdate",typeof(string),true,false)},
			{"paymentagency",createColumn("paymentagency",typeof(int),true,false)},
			{"prevpartitiontitle",createColumn("prevpartitiontitle",typeof(string),true,false)},
			{"proceeds_finlevel",createColumn("proceeds_finlevel",typeof(byte),true,false)},
			{"proceeds_flag",createColumn("proceeds_flag",typeof(byte),true,false)},
			{"proceeds_flagautoprintdate",createColumn("proceeds_flagautoprintdate",typeof(string),true,false)},
			{"profservice_flagrestart",createColumn("profservice_flagrestart",typeof(string),true,false)},
			{"refundagency",createColumn("refundagency",typeof(int),true,false)},
			{"wageaddition_flagrestart",createColumn("wageaddition_flagrestart",typeof(string),true,false)},
			{"idivapayperiodicity",createColumn("idivapayperiodicity",typeof(int),true,false)},
			{"idsortingkind1",createColumn("idsortingkind1",typeof(int),true,false)},
			{"idsortingkind2",createColumn("idsortingkind2",typeof(int),true,false)},
			{"idsortingkind3",createColumn("idsortingkind3",typeof(int),true,false)},
			{"fin_kind",createColumn("fin_kind",typeof(byte),true,false)},
			{"taxvaliditykind",createColumn("taxvaliditykind",typeof(byte),true,false)},
			{"flag_paymentamount",createColumn("flag_paymentamount",typeof(byte),true,false)},
			{"automanagekind",createColumn("automanagekind",typeof(int),true,false)},
			{"flag_autodocnumbering",createColumn("flag_autodocnumbering",typeof(int),true,false)},
			{"flagbank_grouping",createColumn("flagbank_grouping",typeof(int),true,false)},
			{"cashvaliditykind",createColumn("cashvaliditykind",typeof(byte),true,false)},
			{"wageimportappname",createColumn("wageimportappname",typeof(string),true,false)},
			{"balancekind",createColumn("balancekind",typeof(byte),true,false)},
			{"idpaymethodabi",createColumn("idpaymethodabi",typeof(int),true,false)},
			{"idpaymethodnoabi",createColumn("idpaymethodnoabi",typeof(int),true,false)},
			{"iban_f24",createColumn("iban_f24",typeof(string),true,false)},
			{"cudactivitycode",createColumn("cudactivitycode",typeof(string),true,false)},
			{"startivabalance",createColumn("startivabalance",typeof(decimal),true,false)},
			{"flagivapaybyrow",createColumn("flagivapaybyrow",typeof(string),true,false)},
			{"idacc_unabatable",createColumn("idacc_unabatable",typeof(string),true,false)},
			{"idacc_unabatable_refund",createColumn("idacc_unabatable_refund",typeof(string),true,false)},
			{"invoice_flagregister",createColumn("invoice_flagregister",typeof(string),true,false)},
			{"default_idfinvarstatus",createColumn("default_idfinvarstatus",typeof(short),true,false)},
			{"flagivaregphase",createColumn("flagivaregphase",typeof(string),true,false)},
			{"mainflagpayment",createColumn("mainflagpayment",typeof(string),true,false)},
			{"mainflagrefund",createColumn("mainflagrefund",typeof(string),true,false)},
			{"mainidfinivapayment",createColumn("mainidfinivapayment",typeof(int),true,false)},
			{"mainidfinivarefund",createColumn("mainidfinivarefund",typeof(int),true,false)},
			{"mainminpayment",createColumn("mainminpayment",typeof(decimal),true,false)},
			{"mainminrefund",createColumn("mainminrefund",typeof(decimal),true,false)},
			{"mainpaymentagency",createColumn("mainpaymentagency",typeof(int),true,false)},
			{"mainrefundagency",createColumn("mainrefundagency",typeof(int),true,false)},
			{"mainflagivaregphase",createColumn("mainflagivaregphase",typeof(string),true,false)},
			{"mainstartivabalance",createColumn("mainstartivabalance",typeof(decimal),true,false)},
			{"mainidacc_unabatable",createColumn("mainidacc_unabatable",typeof(string),true,false)},
			{"mainidacc_unabatable_refund",createColumn("mainidacc_unabatable_refund",typeof(string),true,false)},
			{"idacc_mainivapayment",createColumn("idacc_mainivapayment",typeof(string),true,false)},
			{"idacc_mainivapayment_internal",createColumn("idacc_mainivapayment_internal",typeof(string),true,false)},
			{"idacc_mainivarefund",createColumn("idacc_mainivarefund",typeof(string),true,false)},
			{"idacc_mainivarefund_internal",createColumn("idacc_mainivarefund_internal",typeof(string),true,false)},
			{"flagva3",createColumn("flagva3",typeof(string),true,false)},
			{"flagrefund12",createColumn("flagrefund12",typeof(string),true,false)},
			{"flagpayment12",createColumn("flagpayment12",typeof(string),true,false)},
			{"refundagency12",createColumn("refundagency12",typeof(int),true,false)},
			{"paymentagency12",createColumn("paymentagency12",typeof(int),true,false)},
			{"idfinivarefund12",createColumn("idfinivarefund12",typeof(int),true,false)},
			{"idfinivapayment12",createColumn("idfinivapayment12",typeof(int),true,false)},
			{"minrefund12",createColumn("minrefund12",typeof(decimal),true,false)},
			{"minpayment12",createColumn("minpayment12",typeof(decimal),true,false)},
			{"idacc_ivapayment12",createColumn("idacc_ivapayment12",typeof(string),true,false)},
			{"idacc_ivarefund12",createColumn("idacc_ivarefund12",typeof(string),true,false)},
			{"idacc_mainivarefund12",createColumn("idacc_mainivarefund12",typeof(string),true,false)},
			{"idacc_mainivapayment12",createColumn("idacc_mainivapayment12",typeof(string),true,false)},
			{"idacc_mainivapayment_internal12",createColumn("idacc_mainivapayment_internal12",typeof(string),true,false)},
			{"idacc_mainivarefund_internal12",createColumn("idacc_mainivarefund_internal12",typeof(string),true,false)},
			{"startivabalance12",createColumn("startivabalance12",typeof(decimal),true,false)},
			{"mainrefundagency12",createColumn("mainrefundagency12",typeof(int),true,false)},
			{"mainpaymentagency12",createColumn("mainpaymentagency12",typeof(int),true,false)},
			{"mainflagrefund12",createColumn("mainflagrefund12",typeof(string),true,false)},
			{"mainflagpayment12",createColumn("mainflagpayment12",typeof(string),true,false)},
			{"mainidfinivarefund12",createColumn("mainidfinivarefund12",typeof(int),true,false)},
			{"mainidfinivapayment12",createColumn("mainidfinivapayment12",typeof(int),true,false)},
			{"mainminrefund12",createColumn("mainminrefund12",typeof(decimal),true,false)},
			{"mainminpayment12",createColumn("mainminpayment12",typeof(decimal),true,false)},
			{"mainstartivabalance12",createColumn("mainstartivabalance12",typeof(decimal),true,false)},
			{"idreg_csa",createColumn("idreg_csa",typeof(int),true,false)},
			{"finvar_warnmail",createColumn("finvar_warnmail",typeof(string),true,false)},
			{"flagdirectcsaclawback",createColumn("flagdirectcsaclawback",typeof(string),true,false)},
			{"idacc_revenue_gross_csa",createColumn("idacc_revenue_gross_csa",typeof(string),true,false)},
			{"idfinincome_gross_csa",createColumn("idfinincome_gross_csa",typeof(int),true,false)},
			{"idsor1_stock",createColumn("idsor1_stock",typeof(int),true,false)},
			{"idsor2_stock",createColumn("idsor2_stock",typeof(int),true,false)},
			{"idsor3_stock",createColumn("idsor3_stock",typeof(int),true,false)},
			{"idinpscenter",createColumn("idinpscenter",typeof(string),true,false)},
			{"idivapayperiodicity_instit",createColumn("idivapayperiodicity_instit",typeof(int),true,false)},
			{"idfin_store",createColumn("idfin_store",typeof(int),true,false)},
			{"flagpcashautopayment",createColumn("flagpcashautopayment",typeof(string),true,false)},
			{"flagpcashautoproceeds",createColumn("flagpcashautoproceeds",typeof(string),true,false)},
			{"email",createColumn("email",typeof(string),true,false)},
			{"lcard",createColumn("lcard",typeof(string),true,false)},
			{"booking_on_invoice",createColumn("booking_on_invoice",typeof(string),true,false)},
			{"itineration_directauth",createColumn("itineration_directauth",typeof(string),true,false)},
			{"email_f24",createColumn("email_f24",typeof(string),true,false)},
			{"csa_flaggroupby_income",createColumn("csa_flaggroupby_income",typeof(string),true,false)},
			{"csa_flaggroupby_expense",createColumn("csa_flaggroupby_expense",typeof(string),true,false)},
			{"csa_flaglinktoexp",createColumn("csa_flaglinktoexp",typeof(string),true,false)},
			{"csa_nominativo",createColumn("csa_nominativo",typeof(string),true,false)},
			{"idsiopeincome_csa",createColumn("idsiopeincome_csa",typeof(int),true,false)},
			{"idacc_invoicetoemit",createColumn("idacc_invoicetoemit",typeof(string),true,false)},
			{"idacc_invoicetoreceive",createColumn("idacc_invoicetoreceive",typeof(string),true,false)},
			{"epannualthreeshold",createColumn("epannualthreeshold",typeof(decimal),true,false)},
			{"flagbalance_csa",createColumn("flagbalance_csa",typeof(string),true,false)},
			{"flagiva_immediate_or_deferred",createColumn("flagiva_immediate_or_deferred",typeof(string),true,false)},
			{"flagenabletransmission",createColumn("flagenabletransmission",typeof(string),true,false)},
			{"idpccdebitstatus",createColumn("idpccdebitstatus",typeof(string),true,false)},
			{"flagsplitpayment",createColumn("flagsplitpayment",typeof(string),true,false)},
			{"startivabalancesplit",createColumn("startivabalancesplit",typeof(decimal),true,false)},
			{"paymentagencysplit",createColumn("paymentagencysplit",typeof(int),true,false)},
			{"idfinivapaymentsplit",createColumn("idfinivapaymentsplit",typeof(int),true,false)},
			{"flagpaymentsplit",createColumn("flagpaymentsplit",typeof(string),true,false)},
			{"idacc_unabatable_split",createColumn("idacc_unabatable_split",typeof(string),true,false)},
			{"idacc_ivapaymentsplit",createColumn("idacc_ivapaymentsplit",typeof(string),true,false)},
			{"agencynumber",createColumn("agencynumber",typeof(string),true,false)},
			{"femode",createColumn("femode",typeof(string),true,false)},
			{"idacc_economic_result",createColumn("idacc_economic_result",typeof(string),true,false)},
			{"idacc_previous_economic_result",createColumn("idacc_previous_economic_result",typeof(string),true,false)},
			{"idacc_bankpaydoc",createColumn("idacc_bankpaydoc",typeof(string),true,false)},
			{"idacc_bankprodoc",createColumn("idacc_bankprodoc",typeof(string),true,false)},
			{"csa_flagtransmissionlinking",createColumn("csa_flagtransmissionlinking",typeof(string),true,false)},
			{"csa_idchargehandling",createColumn("csa_idchargehandling",typeof(int),true,false)},
			{"csa_flag",createColumn("csa_flag",typeof(int),true,false)},
			{"idaccmotive_forwarder",createColumn("idaccmotive_forwarder",typeof(string),true,false)},
			{"idivakind_forwarder",createColumn("idivakind_forwarder",typeof(int),true,false)},
			{"idaccmotive_grantrevenue",createColumn("idaccmotive_grantrevenue",typeof(string),true,false)},
			{"idaccmotive_grantdeferredcost",createColumn("idaccmotive_grantdeferredcost",typeof(string),true,false)},
			{"idaccmotive_assetrevenue",createColumn("idaccmotive_assetrevenue",typeof(string),true,false)},
			{"idaccmotive_prorata_cost",createColumn("idaccmotive_prorata_cost",typeof(string),true,false)},
			{"idaccmotive_prorata_revenue",createColumn("idaccmotive_prorata_revenue",typeof(string),true,false)},
			{"idsor_siopeivaexp",createColumn("idsor_siopeivaexp",typeof(int),true,false)},
			{"idsor_siopeiva12exp",createColumn("idsor_siopeiva12exp",typeof(int),true,false)},
			{"idsor_siopeivasplitexp",createColumn("idsor_siopeivasplitexp",typeof(int),true,false)},
			{"idsor_siopeivainc",createColumn("idsor_siopeivainc",typeof(int),true,false)},
			{"idsor_siopeiva12inc",createColumn("idsor_siopeiva12inc",typeof(int),true,false)},
			{"flag",createColumn("flag",typeof(int),true,false)},
			{"assignedrequirement",createColumn("assignedrequirement",typeof(decimal),true,false)},
			{"risconta_ammortamenti_futuri",createColumn("risconta_ammortamenti_futuri",typeof(string),true,false)},
			{"idacc_unabatable_estera",createColumn("idacc_unabatable_estera",typeof(string),true,false)},
			{"idsor_siopeivavendita",createColumn("idsor_siopeivavendita",typeof(int),true,false)},
		};
	}
}
}
