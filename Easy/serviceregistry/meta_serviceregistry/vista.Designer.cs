
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
namespace meta_serviceregistry {
public class serviceregistryRow: MetaRow  {
	public serviceregistryRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 yservreg{ 
		get {return  (Int32)this["yservreg"];}
		set {this["yservreg"]= value;}
	}
	public object yservregValue { 
		get{ return this["yservreg"];}
		set {this["yservreg"]= value;}
	}
	public Int32 yservregOriginal { 
		get {return  (Int32)this["yservreg",DataRowVersion.Original];}
	}
	public Int32 nservreg{ 
		get {return  (Int32)this["nservreg"];}
		set {this["nservreg"]= value;}
	}
	public object nservregValue { 
		get{ return this["nservreg"];}
		set {this["nservreg"]= value;}
	}
	public Int32 nservregOriginal { 
		get {return  (Int32)this["nservreg",DataRowVersion.Original];}
	}
	public String id_service{ 
		get {if (this["id_service"]==DBNull.Value)return null; return  (String)this["id_service"];}
		set {if (value==null) this["id_service"]= DBNull.Value; else this["id_service"]= value;}
	}
	public object id_serviceValue { 
		get{ return this["id_service"];}
		set {if (value==null|| value==DBNull.Value) this["id_service"]= DBNull.Value; else this["id_service"]= value;}
	}
	public String id_serviceOriginal { 
		get {if (this["id_service",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["id_service",DataRowVersion.Original];}
	}
	public String employkind{ 
		get {if (this["employkind"]==DBNull.Value)return null; return  (String)this["employkind"];}
		set {if (value==null) this["employkind"]= DBNull.Value; else this["employkind"]= value;}
	}
	public object employkindValue { 
		get{ return this["employkind"];}
		set {if (value==null|| value==DBNull.Value) this["employkind"]= DBNull.Value; else this["employkind"]= value;}
	}
	public String employkindOriginal { 
		get {if (this["employkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["employkind",DataRowVersion.Original];}
	}
	public Int32? iddepartment{ 
		get {if (this["iddepartment"]==DBNull.Value)return null; return  (Int32?)this["iddepartment"];}
		set {if (value==null) this["iddepartment"]= DBNull.Value; else this["iddepartment"]= value;}
	}
	public object iddepartmentValue { 
		get{ return this["iddepartment"];}
		set {if (value==null|| value==DBNull.Value) this["iddepartment"]= DBNull.Value; else this["iddepartment"]= value;}
	}
	public Int32? iddepartmentOriginal { 
		get {if (this["iddepartment",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddepartment",DataRowVersion.Original];}
	}
	public String is_annulled{ 
		get {if (this["is_annulled"]==DBNull.Value)return null; return  (String)this["is_annulled"];}
		set {if (value==null) this["is_annulled"]= DBNull.Value; else this["is_annulled"]= value;}
	}
	public object is_annulledValue { 
		get{ return this["is_annulled"];}
		set {if (value==null|| value==DBNull.Value) this["is_annulled"]= DBNull.Value; else this["is_annulled"]= value;}
	}
	public String is_annulledOriginal { 
		get {if (this["is_annulled",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["is_annulled",DataRowVersion.Original];}
	}
	public String is_delivered{ 
		get {if (this["is_delivered"]==DBNull.Value)return null; return  (String)this["is_delivered"];}
		set {if (value==null) this["is_delivered"]= DBNull.Value; else this["is_delivered"]= value;}
	}
	public object is_deliveredValue { 
		get{ return this["is_delivered"];}
		set {if (value==null|| value==DBNull.Value) this["is_delivered"]= DBNull.Value; else this["is_delivered"]= value;}
	}
	public String is_deliveredOriginal { 
		get {if (this["is_delivered",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["is_delivered",DataRowVersion.Original];}
	}
	public String is_changed{ 
		get {if (this["is_changed"]==DBNull.Value)return null; return  (String)this["is_changed"];}
		set {if (value==null) this["is_changed"]= DBNull.Value; else this["is_changed"]= value;}
	}
	public object is_changedValue { 
		get{ return this["is_changed"];}
		set {if (value==null|| value==DBNull.Value) this["is_changed"]= DBNull.Value; else this["is_changed"]= value;}
	}
	public String is_changedOriginal { 
		get {if (this["is_changed",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["is_changed",DataRowVersion.Original];}
	}
	public String idconsultingkind{ 
		get {if (this["idconsultingkind"]==DBNull.Value)return null; return  (String)this["idconsultingkind"];}
		set {if (value==null) this["idconsultingkind"]= DBNull.Value; else this["idconsultingkind"]= value;}
	}
	public object idconsultingkindValue { 
		get{ return this["idconsultingkind"];}
		set {if (value==null|| value==DBNull.Value) this["idconsultingkind"]= DBNull.Value; else this["idconsultingkind"]= value;}
	}
	public String idconsultingkindOriginal { 
		get {if (this["idconsultingkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idconsultingkind",DataRowVersion.Original];}
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
	public String codcity{ 
		get {if (this["codcity"]==DBNull.Value)return null; return  (String)this["codcity"];}
		set {if (value==null) this["codcity"]= DBNull.Value; else this["codcity"]= value;}
	}
	public object codcityValue { 
		get{ return this["codcity"];}
		set {if (value==null|| value==DBNull.Value) this["codcity"]= DBNull.Value; else this["codcity"]= value;}
	}
	public String codcityOriginal { 
		get {if (this["codcity",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codcity",DataRowVersion.Original];}
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
	public Int32? referencesemester{ 
		get {if (this["referencesemester"]==DBNull.Value)return null; return  (Int32?)this["referencesemester"];}
		set {if (value==null) this["referencesemester"]= DBNull.Value; else this["referencesemester"]= value;}
	}
	public object referencesemesterValue { 
		get{ return this["referencesemester"];}
		set {if (value==null|| value==DBNull.Value) this["referencesemester"]= DBNull.Value; else this["referencesemester"]= value;}
	}
	public Int32? referencesemesterOriginal { 
		get {if (this["referencesemester",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["referencesemester",DataRowVersion.Original];}
	}
	public String pa_code{ 
		get {if (this["pa_code"]==DBNull.Value)return null; return  (String)this["pa_code"];}
		set {if (value==null) this["pa_code"]= DBNull.Value; else this["pa_code"]= value;}
	}
	public object pa_codeValue { 
		get{ return this["pa_code"];}
		set {if (value==null|| value==DBNull.Value) this["pa_code"]= DBNull.Value; else this["pa_code"]= value;}
	}
	public String pa_codeOriginal { 
		get {if (this["pa_code",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["pa_code",DataRowVersion.Original];}
	}
	public String idacquirekind{ 
		get {if (this["idacquirekind"]==DBNull.Value)return null; return  (String)this["idacquirekind"];}
		set {if (value==null) this["idacquirekind"]= DBNull.Value; else this["idacquirekind"]= value;}
	}
	public object idacquirekindValue { 
		get{ return this["idacquirekind"];}
		set {if (value==null|| value==DBNull.Value) this["idacquirekind"]= DBNull.Value; else this["idacquirekind"]= value;}
	}
	public String idacquirekindOriginal { 
		get {if (this["idacquirekind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacquirekind",DataRowVersion.Original];}
	}
	public String idapcontractkind{ 
		get {if (this["idapcontractkind"]==DBNull.Value)return null; return  (String)this["idapcontractkind"];}
		set {if (value==null) this["idapcontractkind"]= DBNull.Value; else this["idapcontractkind"]= value;}
	}
	public object idapcontractkindValue { 
		get{ return this["idapcontractkind"];}
		set {if (value==null|| value==DBNull.Value) this["idapcontractkind"]= DBNull.Value; else this["idapcontractkind"]= value;}
	}
	public String idapcontractkindOriginal { 
		get {if (this["idapcontractkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idapcontractkind",DataRowVersion.Original];}
	}
	public String idfinancialactivity{ 
		get {if (this["idfinancialactivity"]==DBNull.Value)return null; return  (String)this["idfinancialactivity"];}
		set {if (value==null) this["idfinancialactivity"]= DBNull.Value; else this["idfinancialactivity"]= value;}
	}
	public object idfinancialactivityValue { 
		get{ return this["idfinancialactivity"];}
		set {if (value==null|| value==DBNull.Value) this["idfinancialactivity"]= DBNull.Value; else this["idfinancialactivity"]= value;}
	}
	public String idfinancialactivityOriginal { 
		get {if (this["idfinancialactivity",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idfinancialactivity",DataRowVersion.Original];}
	}
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
	public DateTime? start{ 
		get {if (this["start"]==DBNull.Value)return null; return  (DateTime?)this["start"];}
		set {if (value==null) this["start"]= DBNull.Value; else this["start"]= value;}
	}
	public object startValue { 
		get{ return this["start"];}
		set {if (value==null|| value==DBNull.Value) this["start"]= DBNull.Value; else this["start"]= value;}
	}
	public DateTime? startOriginal { 
		get {if (this["start",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["start",DataRowVersion.Original];}
	}
	public DateTime? stop{ 
		get {if (this["stop"]==DBNull.Value)return null; return  (DateTime?)this["stop"];}
		set {if (value==null) this["stop"]= DBNull.Value; else this["stop"]= value;}
	}
	public object stopValue { 
		get{ return this["stop"];}
		set {if (value==null|| value==DBNull.Value) this["stop"]= DBNull.Value; else this["stop"]= value;}
	}
	public DateTime? stopOriginal { 
		get {if (this["stop",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["stop",DataRowVersion.Original];}
	}
	public String servicevariation{ 
		get {if (this["servicevariation"]==DBNull.Value)return null; return  (String)this["servicevariation"];}
		set {if (value==null) this["servicevariation"]= DBNull.Value; else this["servicevariation"]= value;}
	}
	public object servicevariationValue { 
		get{ return this["servicevariation"];}
		set {if (value==null|| value==DBNull.Value) this["servicevariation"]= DBNull.Value; else this["servicevariation"]= value;}
	}
	public String servicevariationOriginal { 
		get {if (this["servicevariation",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["servicevariation",DataRowVersion.Original];}
	}
	public Decimal expectedamount{ 
		get {return  (Decimal)this["expectedamount"];}
		set {this["expectedamount"]= value;}
	}
	public object expectedamountValue { 
		get{ return this["expectedamount"];}
		set {this["expectedamount"]= value;}
	}
	public Decimal expectedamountOriginal { 
		get {return  (Decimal)this["expectedamount",DataRowVersion.Original];}
	}
	public String payment{ 
		get {if (this["payment"]==DBNull.Value)return null; return  (String)this["payment"];}
		set {if (value==null) this["payment"]= DBNull.Value; else this["payment"]= value;}
	}
	public object paymentValue { 
		get{ return this["payment"];}
		set {if (value==null|| value==DBNull.Value) this["payment"]= DBNull.Value; else this["payment"]= value;}
	}
	public String paymentOriginal { 
		get {if (this["payment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["payment",DataRowVersion.Original];}
	}
	public Int32? ypay{ 
		get {if (this["ypay"]==DBNull.Value)return null; return  (Int32?)this["ypay"];}
		set {if (value==null) this["ypay"]= DBNull.Value; else this["ypay"]= value;}
	}
	public object ypayValue { 
		get{ return this["ypay"];}
		set {if (value==null|| value==DBNull.Value) this["ypay"]= DBNull.Value; else this["ypay"]= value;}
	}
	public Int32? ypayOriginal { 
		get {if (this["ypay",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ypay",DataRowVersion.Original];}
	}
	public String idapmanager{ 
		get {if (this["idapmanager"]==DBNull.Value)return null; return  (String)this["idapmanager"];}
		set {if (value==null) this["idapmanager"]= DBNull.Value; else this["idapmanager"]= value;}
	}
	public object idapmanagerValue { 
		get{ return this["idapmanager"];}
		set {if (value==null|| value==DBNull.Value) this["idapmanager"]= DBNull.Value; else this["idapmanager"]= value;}
	}
	public String idapmanagerOriginal { 
		get {if (this["idapmanager",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idapmanager",DataRowVersion.Original];}
	}
	public String idapregistrykind{ 
		get {if (this["idapregistrykind"]==DBNull.Value)return null; return  (String)this["idapregistrykind"];}
		set {if (value==null) this["idapregistrykind"]= DBNull.Value; else this["idapregistrykind"]= value;}
	}
	public object idapregistrykindValue { 
		get{ return this["idapregistrykind"];}
		set {if (value==null|| value==DBNull.Value) this["idapregistrykind"]= DBNull.Value; else this["idapregistrykind"]= value;}
	}
	public String idapregistrykindOriginal { 
		get {if (this["idapregistrykind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idapregistrykind",DataRowVersion.Original];}
	}
	public String idapactivitykind{ 
		get {if (this["idapactivitykind"]==DBNull.Value)return null; return  (String)this["idapactivitykind"];}
		set {if (value==null) this["idapactivitykind"]= DBNull.Value; else this["idapactivitykind"]= value;}
	}
	public object idapactivitykindValue { 
		get{ return this["idapactivitykind"];}
		set {if (value==null|| value==DBNull.Value) this["idapactivitykind"]= DBNull.Value; else this["idapactivitykind"]= value;}
	}
	public String idapactivitykindOriginal { 
		get {if (this["idapactivitykind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idapactivitykind",DataRowVersion.Original];}
	}
	public String pa_cf{ 
		get {if (this["pa_cf"]==DBNull.Value)return null; return  (String)this["pa_cf"];}
		set {if (value==null) this["pa_cf"]= DBNull.Value; else this["pa_cf"]= value;}
	}
	public object pa_cfValue { 
		get{ return this["pa_cf"];}
		set {if (value==null|| value==DBNull.Value) this["pa_cf"]= DBNull.Value; else this["pa_cf"]= value;}
	}
	public String pa_cfOriginal { 
		get {if (this["pa_cf",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["pa_cf",DataRowVersion.Original];}
	}
	public String pa_title{ 
		get {if (this["pa_title"]==DBNull.Value)return null; return  (String)this["pa_title"];}
		set {if (value==null) this["pa_title"]= DBNull.Value; else this["pa_title"]= value;}
	}
	public object pa_titleValue { 
		get{ return this["pa_title"];}
		set {if (value==null|| value==DBNull.Value) this["pa_title"]= DBNull.Value; else this["pa_title"]= value;}
	}
	public String pa_titleOriginal { 
		get {if (this["pa_title",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["pa_title",DataRowVersion.Original];}
	}
	public DateTime? authorizationdate{ 
		get {if (this["authorizationdate"]==DBNull.Value)return null; return  (DateTime?)this["authorizationdate"];}
		set {if (value==null) this["authorizationdate"]= DBNull.Value; else this["authorizationdate"]= value;}
	}
	public object authorizationdateValue { 
		get{ return this["authorizationdate"];}
		set {if (value==null|| value==DBNull.Value) this["authorizationdate"]= DBNull.Value; else this["authorizationdate"]= value;}
	}
	public DateTime? authorizationdateOriginal { 
		get {if (this["authorizationdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["authorizationdate",DataRowVersion.Original];}
	}
	public String officeduty{ 
		get {if (this["officeduty"]==DBNull.Value)return null; return  (String)this["officeduty"];}
		set {if (value==null) this["officeduty"]= DBNull.Value; else this["officeduty"]= value;}
	}
	public object officedutyValue { 
		get{ return this["officeduty"];}
		set {if (value==null|| value==DBNull.Value) this["officeduty"]= DBNull.Value; else this["officeduty"]= value;}
	}
	public String officedutyOriginal { 
		get {if (this["officeduty",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["officeduty",DataRowVersion.Original];}
	}
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
	public String referencerule{ 
		get {if (this["referencerule"]==DBNull.Value)return null; return  (String)this["referencerule"];}
		set {if (value==null) this["referencerule"]= DBNull.Value; else this["referencerule"]= value;}
	}
	public object referenceruleValue { 
		get{ return this["referencerule"];}
		set {if (value==null|| value==DBNull.Value) this["referencerule"]= DBNull.Value; else this["referencerule"]= value;}
	}
	public String referenceruleOriginal { 
		get {if (this["referencerule",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["referencerule",DataRowVersion.Original];}
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
	public String idrelated{ 
		get {if (this["idrelated"]==DBNull.Value)return null; return  (String)this["idrelated"];}
		set {if (value==null) this["idrelated"]= DBNull.Value; else this["idrelated"]= value;}
	}
	public object idrelatedValue { 
		get{ return this["idrelated"];}
		set {if (value==null|| value==DBNull.Value) this["idrelated"]= DBNull.Value; else this["idrelated"]= value;}
	}
	public String idrelatedOriginal { 
		get {if (this["idrelated",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idrelated",DataRowVersion.Original];}
	}
	public String is_blocked{ 
		get {if (this["is_blocked"]==DBNull.Value)return null; return  (String)this["is_blocked"];}
		set {if (value==null) this["is_blocked"]= DBNull.Value; else this["is_blocked"]= value;}
	}
	public object is_blockedValue { 
		get{ return this["is_blocked"];}
		set {if (value==null|| value==DBNull.Value) this["is_blocked"]= DBNull.Value; else this["is_blocked"]= value;}
	}
	public String is_blockedOriginal { 
		get {if (this["is_blocked",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["is_blocked",DataRowVersion.Original];}
	}
	public String regulation{ 
		get {if (this["regulation"]==DBNull.Value)return null; return  (String)this["regulation"];}
		set {if (value==null) this["regulation"]= DBNull.Value; else this["regulation"]= value;}
	}
	public object regulationValue { 
		get{ return this["regulation"];}
		set {if (value==null|| value==DBNull.Value) this["regulation"]= DBNull.Value; else this["regulation"]= value;}
	}
	public String regulationOriginal { 
		get {if (this["regulation",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["regulation",DataRowVersion.Original];}
	}
	public String paragraph{ 
		get {if (this["paragraph"]==DBNull.Value)return null; return  (String)this["paragraph"];}
		set {if (value==null) this["paragraph"]= DBNull.Value; else this["paragraph"]= value;}
	}
	public object paragraphValue { 
		get{ return this["paragraph"];}
		set {if (value==null|| value==DBNull.Value) this["paragraph"]= DBNull.Value; else this["paragraph"]= value;}
	}
	public String paragraphOriginal { 
		get {if (this["paragraph",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["paragraph",DataRowVersion.Original];}
	}
	public String article{ 
		get {if (this["article"]==DBNull.Value)return null; return  (String)this["article"];}
		set {if (value==null) this["article"]= DBNull.Value; else this["article"]= value;}
	}
	public object articleValue { 
		get{ return this["article"];}
		set {if (value==null|| value==DBNull.Value) this["article"]= DBNull.Value; else this["article"]= value;}
	}
	public String articleOriginal { 
		get {if (this["article",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["article",DataRowVersion.Original];}
	}
	public String articlenumber{ 
		get {if (this["articlenumber"]==DBNull.Value)return null; return  (String)this["articlenumber"];}
		set {if (value==null) this["articlenumber"]= DBNull.Value; else this["articlenumber"]= value;}
	}
	public object articlenumberValue { 
		get{ return this["articlenumber"];}
		set {if (value==null|| value==DBNull.Value) this["articlenumber"]= DBNull.Value; else this["articlenumber"]= value;}
	}
	public String articlenumberOriginal { 
		get {if (this["articlenumber",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["articlenumber",DataRowVersion.Original];}
	}
	public DateTime? referencedate{ 
		get {if (this["referencedate"]==DBNull.Value)return null; return  (DateTime?)this["referencedate"];}
		set {if (value==null) this["referencedate"]= DBNull.Value; else this["referencedate"]= value;}
	}
	public object referencedateValue { 
		get{ return this["referencedate"];}
		set {if (value==null|| value==DBNull.Value) this["referencedate"]= DBNull.Value; else this["referencedate"]= value;}
	}
	public DateTime? referencedateOriginal { 
		get {if (this["referencedate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["referencedate",DataRowVersion.Original];}
	}
	public String idreferencerule{ 
		get {if (this["idreferencerule"]==DBNull.Value)return null; return  (String)this["idreferencerule"];}
		set {if (value==null) this["idreferencerule"]= DBNull.Value; else this["idreferencerule"]= value;}
	}
	public object idreferenceruleValue { 
		get{ return this["idreferencerule"];}
		set {if (value==null|| value==DBNull.Value) this["idreferencerule"]= DBNull.Value; else this["idreferencerule"]= value;}
	}
	public String idreferenceruleOriginal { 
		get {if (this["idreferencerule",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idreferencerule",DataRowVersion.Original];}
	}
	public Int32? idapfinancialactivity{ 
		get {if (this["idapfinancialactivity"]==DBNull.Value)return null; return  (Int32?)this["idapfinancialactivity"];}
		set {if (value==null) this["idapfinancialactivity"]= DBNull.Value; else this["idapfinancialactivity"]= value;}
	}
	public object idapfinancialactivityValue { 
		get{ return this["idapfinancialactivity"];}
		set {if (value==null|| value==DBNull.Value) this["idapfinancialactivity"]= DBNull.Value; else this["idapfinancialactivity"]= value;}
	}
	public Int32? idapfinancialactivityOriginal { 
		get {if (this["idapfinancialactivity",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idapfinancialactivity",DataRowVersion.Original];}
	}
	public String rulespecifics{ 
		get {if (this["rulespecifics"]==DBNull.Value)return null; return  (String)this["rulespecifics"];}
		set {if (value==null) this["rulespecifics"]= DBNull.Value; else this["rulespecifics"]= value;}
	}
	public object rulespecificsValue { 
		get{ return this["rulespecifics"];}
		set {if (value==null|| value==DBNull.Value) this["rulespecifics"]= DBNull.Value; else this["rulespecifics"]= value;}
	}
	public String rulespecificsOriginal { 
		get {if (this["rulespecifics",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["rulespecifics",DataRowVersion.Original];}
	}
	public DateTime? expectationsdate{ 
		get {if (this["expectationsdate"]==DBNull.Value)return null; return  (DateTime?)this["expectationsdate"];}
		set {if (value==null) this["expectationsdate"]= DBNull.Value; else this["expectationsdate"]= value;}
	}
	public object expectationsdateValue { 
		get{ return this["expectationsdate"];}
		set {if (value==null|| value==DBNull.Value) this["expectationsdate"]= DBNull.Value; else this["expectationsdate"]= value;}
	}
	public DateTime? expectationsdateOriginal { 
		get {if (this["expectationsdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["expectationsdate",DataRowVersion.Original];}
	}
	public String senderreporting{ 
		get {if (this["senderreporting"]==DBNull.Value)return null; return  (String)this["senderreporting"];}
		set {if (value==null) this["senderreporting"]= DBNull.Value; else this["senderreporting"]= value;}
	}
	public object senderreportingValue { 
		get{ return this["senderreporting"];}
		set {if (value==null|| value==DBNull.Value) this["senderreporting"]= DBNull.Value; else this["senderreporting"]= value;}
	}
	public String senderreportingOriginal { 
		get {if (this["senderreporting",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["senderreporting",DataRowVersion.Original];}
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
	public String conferring_piva{ 
		get {if (this["conferring_piva"]==DBNull.Value)return null; return  (String)this["conferring_piva"];}
		set {if (value==null) this["conferring_piva"]= DBNull.Value; else this["conferring_piva"]= value;}
	}
	public object conferring_pivaValue { 
		get{ return this["conferring_piva"];}
		set {if (value==null|| value==DBNull.Value) this["conferring_piva"]= DBNull.Value; else this["conferring_piva"]= value;}
	}
	public String conferring_pivaOriginal { 
		get {if (this["conferring_piva",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["conferring_piva",DataRowVersion.Original];}
	}
	public String conferring_forename{ 
		get {if (this["conferring_forename"]==DBNull.Value)return null; return  (String)this["conferring_forename"];}
		set {if (value==null) this["conferring_forename"]= DBNull.Value; else this["conferring_forename"]= value;}
	}
	public object conferring_forenameValue { 
		get{ return this["conferring_forename"];}
		set {if (value==null|| value==DBNull.Value) this["conferring_forename"]= DBNull.Value; else this["conferring_forename"]= value;}
	}
	public String conferring_forenameOriginal { 
		get {if (this["conferring_forename",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["conferring_forename",DataRowVersion.Original];}
	}
	public String conferring_surname{ 
		get {if (this["conferring_surname"]==DBNull.Value)return null; return  (String)this["conferring_surname"];}
		set {if (value==null) this["conferring_surname"]= DBNull.Value; else this["conferring_surname"]= value;}
	}
	public object conferring_surnameValue { 
		get{ return this["conferring_surname"];}
		set {if (value==null|| value==DBNull.Value) this["conferring_surname"]= DBNull.Value; else this["conferring_surname"]= value;}
	}
	public String conferring_surnameOriginal { 
		get {if (this["conferring_surname",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["conferring_surname",DataRowVersion.Original];}
	}
	public String conferring_flagforeign{ 
		get {if (this["conferring_flagforeign"]==DBNull.Value)return null; return  (String)this["conferring_flagforeign"];}
		set {if (value==null) this["conferring_flagforeign"]= DBNull.Value; else this["conferring_flagforeign"]= value;}
	}
	public object conferring_flagforeignValue { 
		get{ return this["conferring_flagforeign"];}
		set {if (value==null|| value==DBNull.Value) this["conferring_flagforeign"]= DBNull.Value; else this["conferring_flagforeign"]= value;}
	}
	public String conferring_flagforeignOriginal { 
		get {if (this["conferring_flagforeign",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["conferring_flagforeign",DataRowVersion.Original];}
	}
	public DateTime? conferring_birthdate{ 
		get {if (this["conferring_birthdate"]==DBNull.Value)return null; return  (DateTime?)this["conferring_birthdate"];}
		set {if (value==null) this["conferring_birthdate"]= DBNull.Value; else this["conferring_birthdate"]= value;}
	}
	public object conferring_birthdateValue { 
		get{ return this["conferring_birthdate"];}
		set {if (value==null|| value==DBNull.Value) this["conferring_birthdate"]= DBNull.Value; else this["conferring_birthdate"]= value;}
	}
	public DateTime? conferring_birthdateOriginal { 
		get {if (this["conferring_birthdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["conferring_birthdate",DataRowVersion.Original];}
	}
	public String conferring_gender{ 
		get {if (this["conferring_gender"]==DBNull.Value)return null; return  (String)this["conferring_gender"];}
		set {if (value==null) this["conferring_gender"]= DBNull.Value; else this["conferring_gender"]= value;}
	}
	public object conferring_genderValue { 
		get{ return this["conferring_gender"];}
		set {if (value==null|| value==DBNull.Value) this["conferring_gender"]= DBNull.Value; else this["conferring_gender"]= value;}
	}
	public String conferring_genderOriginal { 
		get {if (this["conferring_gender",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["conferring_gender",DataRowVersion.Original];}
	}
	public String conferring_codcity{ 
		get {if (this["conferring_codcity"]==DBNull.Value)return null; return  (String)this["conferring_codcity"];}
		set {if (value==null) this["conferring_codcity"]= DBNull.Value; else this["conferring_codcity"]= value;}
	}
	public object conferring_codcityValue { 
		get{ return this["conferring_codcity"];}
		set {if (value==null|| value==DBNull.Value) this["conferring_codcity"]= DBNull.Value; else this["conferring_codcity"]= value;}
	}
	public String conferring_codcityOriginal { 
		get {if (this["conferring_codcity",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["conferring_codcity",DataRowVersion.Original];}
	}
	public Int32? conferring_idcity{ 
		get {if (this["conferring_idcity"]==DBNull.Value)return null; return  (Int32?)this["conferring_idcity"];}
		set {if (value==null) this["conferring_idcity"]= DBNull.Value; else this["conferring_idcity"]= value;}
	}
	public object conferring_idcityValue { 
		get{ return this["conferring_idcity"];}
		set {if (value==null|| value==DBNull.Value) this["conferring_idcity"]= DBNull.Value; else this["conferring_idcity"]= value;}
	}
	public Int32? conferring_idcityOriginal { 
		get {if (this["conferring_idcity",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["conferring_idcity",DataRowVersion.Original];}
	}
	public Int32? idconferring{ 
		get {if (this["idconferring"]==DBNull.Value)return null; return  (Int32?)this["idconferring"];}
		set {if (value==null) this["idconferring"]= DBNull.Value; else this["idconferring"]= value;}
	}
	public object idconferringValue { 
		get{ return this["idconferring"];}
		set {if (value==null|| value==DBNull.Value) this["idconferring"]= DBNull.Value; else this["idconferring"]= value;}
	}
	public Int32? idconferringOriginal { 
		get {if (this["idconferring",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idconferring",DataRowVersion.Original];}
	}
	public String conferringstructure{ 
		get {if (this["conferringstructure"]==DBNull.Value)return null; return  (String)this["conferringstructure"];}
		set {if (value==null) this["conferringstructure"]= DBNull.Value; else this["conferringstructure"]= value;}
	}
	public object conferringstructureValue { 
		get{ return this["conferringstructure"];}
		set {if (value==null|| value==DBNull.Value) this["conferringstructure"]= DBNull.Value; else this["conferringstructure"]= value;}
	}
	public String conferringstructureOriginal { 
		get {if (this["conferringstructure",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["conferringstructure",DataRowVersion.Original];}
	}
	public String ordinancelink{ 
		get {if (this["ordinancelink"]==DBNull.Value)return null; return  (String)this["ordinancelink"];}
		set {if (value==null) this["ordinancelink"]= DBNull.Value; else this["ordinancelink"]= value;}
	}
	public object ordinancelinkValue { 
		get{ return this["ordinancelink"];}
		set {if (value==null|| value==DBNull.Value) this["ordinancelink"]= DBNull.Value; else this["ordinancelink"]= value;}
	}
	public String ordinancelinkOriginal { 
		get {if (this["ordinancelink",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ordinancelink",DataRowVersion.Original];}
	}
	public String authorizingstructure{ 
		get {if (this["authorizingstructure"]==DBNull.Value)return null; return  (String)this["authorizingstructure"];}
		set {if (value==null) this["authorizingstructure"]= DBNull.Value; else this["authorizingstructure"]= value;}
	}
	public object authorizingstructureValue { 
		get{ return this["authorizingstructure"];}
		set {if (value==null|| value==DBNull.Value) this["authorizingstructure"]= DBNull.Value; else this["authorizingstructure"]= value;}
	}
	public String authorizingstructureOriginal { 
		get {if (this["authorizingstructure",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["authorizingstructure",DataRowVersion.Original];}
	}
	public String authorizinglink{ 
		get {if (this["authorizinglink"]==DBNull.Value)return null; return  (String)this["authorizinglink"];}
		set {if (value==null) this["authorizinglink"]= DBNull.Value; else this["authorizinglink"]= value;}
	}
	public object authorizinglinkValue { 
		get{ return this["authorizinglink"];}
		set {if (value==null|| value==DBNull.Value) this["authorizinglink"]= DBNull.Value; else this["authorizinglink"]= value;}
	}
	public String authorizinglinkOriginal { 
		get {if (this["authorizinglink",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["authorizinglink",DataRowVersion.Original];}
	}
	public String actreference{ 
		get {if (this["actreference"]==DBNull.Value)return null; return  (String)this["actreference"];}
		set {if (value==null) this["actreference"]= DBNull.Value; else this["actreference"]= value;}
	}
	public object actreferenceValue { 
		get{ return this["actreference"];}
		set {if (value==null|| value==DBNull.Value) this["actreference"]= DBNull.Value; else this["actreference"]= value;}
	}
	public String actreferenceOriginal { 
		get {if (this["actreference",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["actreference",DataRowVersion.Original];}
	}
	public String announcementlink{ 
		get {if (this["announcementlink"]==DBNull.Value)return null; return  (String)this["announcementlink"];}
		set {if (value==null) this["announcementlink"]= DBNull.Value; else this["announcementlink"]= value;}
	}
	public object announcementlinkValue { 
		get{ return this["announcementlink"];}
		set {if (value==null|| value==DBNull.Value) this["announcementlink"]= DBNull.Value; else this["announcementlink"]= value;}
	}
	public String announcementlinkOriginal { 
		get {if (this["announcementlink",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["announcementlink",DataRowVersion.Original];}
	}
	public String otherservice{ 
		get {if (this["otherservice"]==DBNull.Value)return null; return  (String)this["otherservice"];}
		set {if (value==null) this["otherservice"]= DBNull.Value; else this["otherservice"]= value;}
	}
	public object otherserviceValue { 
		get{ return this["otherservice"];}
		set {if (value==null|| value==DBNull.Value) this["otherservice"]= DBNull.Value; else this["otherservice"]= value;}
	}
	public String otherserviceOriginal { 
		get {if (this["otherservice",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["otherservice",DataRowVersion.Original];}
	}
	public String professionalservice{ 
		get {if (this["professionalservice"]==DBNull.Value)return null; return  (String)this["professionalservice"];}
		set {if (value==null) this["professionalservice"]= DBNull.Value; else this["professionalservice"]= value;}
	}
	public object professionalserviceValue { 
		get{ return this["professionalservice"];}
		set {if (value==null|| value==DBNull.Value) this["professionalservice"]= DBNull.Value; else this["professionalservice"]= value;}
	}
	public String professionalserviceOriginal { 
		get {if (this["professionalservice",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["professionalservice",DataRowVersion.Original];}
	}
	public String componentsvariable{ 
		get {if (this["componentsvariable"]==DBNull.Value)return null; return  (String)this["componentsvariable"];}
		set {if (value==null) this["componentsvariable"]= DBNull.Value; else this["componentsvariable"]= value;}
	}
	public object componentsvariableValue { 
		get{ return this["componentsvariable"];}
		set {if (value==null|| value==DBNull.Value) this["componentsvariable"]= DBNull.Value; else this["componentsvariable"]= value;}
	}
	public String componentsvariableOriginal { 
		get {if (this["componentsvariable",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["componentsvariable",DataRowVersion.Original];}
	}
	public Int32? idserviceregistrykind{ 
		get {if (this["idserviceregistrykind"]==DBNull.Value)return null; return  (Int32?)this["idserviceregistrykind"];}
		set {if (value==null) this["idserviceregistrykind"]= DBNull.Value; else this["idserviceregistrykind"]= value;}
	}
	public object idserviceregistrykindValue { 
		get{ return this["idserviceregistrykind"];}
		set {if (value==null|| value==DBNull.Value) this["idserviceregistrykind"]= DBNull.Value; else this["idserviceregistrykind"]= value;}
	}
	public Int32? idserviceregistrykindOriginal { 
		get {if (this["idserviceregistrykind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idserviceregistrykind",DataRowVersion.Original];}
	}
	public String employtime{ 
		get {if (this["employtime"]==DBNull.Value)return null; return  (String)this["employtime"];}
		set {if (value==null) this["employtime"]= DBNull.Value; else this["employtime"]= value;}
	}
	public object employtimeValue { 
		get{ return this["employtime"];}
		set {if (value==null|| value==DBNull.Value) this["employtime"]= DBNull.Value; else this["employtime"]= value;}
	}
	public String employtimeOriginal { 
		get {if (this["employtime",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["employtime",DataRowVersion.Original];}
	}
	public String notes{ 
		get {if (this["notes"]==DBNull.Value)return null; return  (String)this["notes"];}
		set {if (value==null) this["notes"]= DBNull.Value; else this["notes"]= value;}
	}
	public object notesValue { 
		get{ return this["notes"];}
		set {if (value==null|| value==DBNull.Value) this["notes"]= DBNull.Value; else this["notes"]= value;}
	}
	public String notesOriginal { 
		get {if (this["notes",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["notes",DataRowVersion.Original];}
	}
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
	public String codicepaipa{ 
		get {if (this["codicepaipa"]==DBNull.Value)return null; return  (String)this["codicepaipa"];}
		set {if (value==null) this["codicepaipa"]= DBNull.Value; else this["codicepaipa"]= value;}
	}
	public object codicepaipaValue { 
		get{ return this["codicepaipa"];}
		set {if (value==null|| value==DBNull.Value) this["codicepaipa"]= DBNull.Value; else this["codicepaipa"]= value;}
	}
	public String codicepaipaOriginal { 
		get {if (this["codicepaipa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicepaipa",DataRowVersion.Original];}
	}
	public String codiceaooipa{ 
		get {if (this["codiceaooipa"]==DBNull.Value)return null; return  (String)this["codiceaooipa"];}
		set {if (value==null) this["codiceaooipa"]= DBNull.Value; else this["codiceaooipa"]= value;}
	}
	public object codiceaooipaValue { 
		get{ return this["codiceaooipa"];}
		set {if (value==null|| value==DBNull.Value) this["codiceaooipa"]= DBNull.Value; else this["codiceaooipa"]= value;}
	}
	public String codiceaooipaOriginal { 
		get {if (this["codiceaooipa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codiceaooipa",DataRowVersion.Original];}
	}
	public String codiceuoipa{ 
		get {if (this["codiceuoipa"]==DBNull.Value)return null; return  (String)this["codiceuoipa"];}
		set {if (value==null) this["codiceuoipa"]= DBNull.Value; else this["codiceuoipa"]= value;}
	}
	public object codiceuoipaValue { 
		get{ return this["codiceuoipa"];}
		set {if (value==null|| value==DBNull.Value) this["codiceuoipa"]= DBNull.Value; else this["codiceuoipa"]= value;}
	}
	public String codiceuoipaOriginal { 
		get {if (this["codiceuoipa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codiceuoipa",DataRowVersion.Original];}
	}
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
	public String certinterestconflicts{ 
		get {if (this["certinterestconflicts"]==DBNull.Value)return null; return  (String)this["certinterestconflicts"];}
		set {if (value==null) this["certinterestconflicts"]= DBNull.Value; else this["certinterestconflicts"]= value;}
	}
	public object certinterestconflictsValue { 
		get{ return this["certinterestconflicts"];}
		set {if (value==null|| value==DBNull.Value) this["certinterestconflicts"]= DBNull.Value; else this["certinterestconflicts"]= value;}
	}
	public String certinterestconflictsOriginal { 
		get {if (this["certinterestconflicts",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["certinterestconflicts",DataRowVersion.Original];}
	}
	public String website_annulled{ 
		get {if (this["website_annulled"]==DBNull.Value)return null; return  (String)this["website_annulled"];}
		set {if (value==null) this["website_annulled"]= DBNull.Value; else this["website_annulled"]= value;}
	}
	public object website_annulledValue { 
		get{ return this["website_annulled"];}
		set {if (value==null|| value==DBNull.Value) this["website_annulled"]= DBNull.Value; else this["website_annulled"]= value;}
	}
	public String website_annulledOriginal { 
		get {if (this["website_annulled",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["website_annulled",DataRowVersion.Original];}
	}
	public String perla_error{ 
		get {if (this["perla_error"]==DBNull.Value)return null; return  (String)this["perla_error"];}
		set {if (value==null) this["perla_error"]= DBNull.Value; else this["perla_error"]= value;}
	}
	public object perla_errorValue { 
		get{ return this["perla_error"];}
		set {if (value==null|| value==DBNull.Value) this["perla_error"]= DBNull.Value; else this["perla_error"]= value;}
	}
	public String perla_errorOriginal { 
		get {if (this["perla_error",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["perla_error",DataRowVersion.Original];}
	}
	public Int32? idpublicinstitutionservice{ 
		get {if (this["idpublicinstitutionservice"]==DBNull.Value)return null; return  (Int32?)this["idpublicinstitutionservice"];}
		set {if (value==null) this["idpublicinstitutionservice"]= DBNull.Value; else this["idpublicinstitutionservice"]= value;}
	}
	public object idpublicinstitutionserviceValue { 
		get{ return this["idpublicinstitutionservice"];}
		set {if (value==null|| value==DBNull.Value) this["idpublicinstitutionservice"]= DBNull.Value; else this["idpublicinstitutionservice"]= value;}
	}
	public Int32? idpublicinstitutionserviceOriginal { 
		get {if (this["idpublicinstitutionservice",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpublicinstitutionservice",DataRowVersion.Original];}
	}
	public Int32? idthematicscope{ 
		get {if (this["idthematicscope"]==DBNull.Value)return null; return  (Int32?)this["idthematicscope"];}
		set {if (value==null) this["idthematicscope"]= DBNull.Value; else this["idthematicscope"]= value;}
	}
	public object idthematicscopeValue { 
		get{ return this["idthematicscope"];}
		set {if (value==null|| value==DBNull.Value) this["idthematicscope"]= DBNull.Value; else this["idthematicscope"]= value;}
	}
	public Int32? idthematicscopeOriginal { 
		get {if (this["idthematicscope",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idthematicscope",DataRowVersion.Original];}
	}
	#endregion

}
public class serviceregistryTable : MetaTableBase<serviceregistryRow> {
	public serviceregistryTable() : base("serviceregistry"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"yservreg",createColumn("yservreg",typeof(int),false,false)},
			{"nservreg",createColumn("nservreg",typeof(int),false,false)},
			{"id_service",createColumn("id_service",typeof(string),true,false)},
			{"employkind",createColumn("employkind",typeof(string),true,false)},
			{"iddepartment",createColumn("iddepartment",typeof(int),true,false)},
			{"is_annulled",createColumn("is_annulled",typeof(string),true,false)},
			{"is_delivered",createColumn("is_delivered",typeof(string),true,false)},
			{"is_changed",createColumn("is_changed",typeof(string),true,false)},
			{"idconsultingkind",createColumn("idconsultingkind",typeof(string),true,false)},
			{"p_iva",createColumn("p_iva",typeof(string),true,false)},
			{"cf",createColumn("cf",typeof(string),true,false)},
			{"flagforeign",createColumn("flagforeign",typeof(string),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
			{"codcity",createColumn("codcity",typeof(string),true,false)},
			{"surname",createColumn("surname",typeof(string),true,false)},
			{"forename",createColumn("forename",typeof(string),true,false)},
			{"birthdate",createColumn("birthdate",typeof(DateTime),true,false)},
			{"gender",createColumn("gender",typeof(string),true,false)},
			{"referencesemester",createColumn("referencesemester",typeof(int),true,false)},
			{"pa_code",createColumn("pa_code",typeof(string),true,false)},
			{"idacquirekind",createColumn("idacquirekind",typeof(string),true,false)},
			{"idapcontractkind",createColumn("idapcontractkind",typeof(string),true,false)},
			{"idfinancialactivity",createColumn("idfinancialactivity",typeof(string),true,false)},
			{"description",createColumn("description",typeof(string),true,false)},
			{"start",createColumn("start",typeof(DateTime),true,false)},
			{"stop",createColumn("stop",typeof(DateTime),true,false)},
			{"servicevariation",createColumn("servicevariation",typeof(string),true,false)},
			{"expectedamount",createColumn("expectedamount",typeof(decimal),false,false)},
			{"payment",createColumn("payment",typeof(string),true,false)},
			{"ypay",createColumn("ypay",typeof(int),true,false)},
			{"idapmanager",createColumn("idapmanager",typeof(string),true,false)},
			{"idapregistrykind",createColumn("idapregistrykind",typeof(string),true,false)},
			{"idapactivitykind",createColumn("idapactivitykind",typeof(string),true,false)},
			{"pa_cf",createColumn("pa_cf",typeof(string),true,false)},
			{"pa_title",createColumn("pa_title",typeof(string),true,false)},
			{"authorizationdate",createColumn("authorizationdate",typeof(DateTime),true,false)},
			{"officeduty",createColumn("officeduty",typeof(string),true,false)},
			{"annotation",createColumn("annotation",typeof(string),true,false)},
			{"referencerule",createColumn("referencerule",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"idreg",createColumn("idreg",typeof(int),true,false)},
			{"idcity",createColumn("idcity",typeof(int),true,false)},
			{"idrelated",createColumn("idrelated",typeof(string),true,false)},
			{"is_blocked",createColumn("is_blocked",typeof(string),true,false)},
			{"regulation",createColumn("regulation",typeof(string),true,false)},
			{"paragraph",createColumn("paragraph",typeof(string),true,false)},
			{"article",createColumn("article",typeof(string),true,false)},
			{"articlenumber",createColumn("articlenumber",typeof(string),true,false)},
			{"referencedate",createColumn("referencedate",typeof(DateTime),true,false)},
			{"idreferencerule",createColumn("idreferencerule",typeof(string),true,false)},
			{"idapfinancialactivity",createColumn("idapfinancialactivity",typeof(int),true,false)},
			{"rulespecifics",createColumn("rulespecifics",typeof(string),true,false)},
			{"expectationsdate",createColumn("expectationsdate",typeof(DateTime),true,false)},
			{"senderreporting",createColumn("senderreporting",typeof(string),true,false)},
			{"flaghuman",createColumn("flaghuman",typeof(string),true,false)},
			{"conferring_piva",createColumn("conferring_piva",typeof(string),true,false)},
			{"conferring_forename",createColumn("conferring_forename",typeof(string),true,false)},
			{"conferring_surname",createColumn("conferring_surname",typeof(string),true,false)},
			{"conferring_flagforeign",createColumn("conferring_flagforeign",typeof(string),true,false)},
			{"conferring_birthdate",createColumn("conferring_birthdate",typeof(DateTime),true,false)},
			{"conferring_gender",createColumn("conferring_gender",typeof(string),true,false)},
			{"conferring_codcity",createColumn("conferring_codcity",typeof(string),true,false)},
			{"conferring_idcity",createColumn("conferring_idcity",typeof(int),true,false)},
			{"idconferring",createColumn("idconferring",typeof(int),true,false)},
			{"conferringstructure",createColumn("conferringstructure",typeof(string),true,false)},
			{"ordinancelink",createColumn("ordinancelink",typeof(string),true,false)},
			{"authorizingstructure",createColumn("authorizingstructure",typeof(string),true,false)},
			{"authorizinglink",createColumn("authorizinglink",typeof(string),true,false)},
			{"actreference",createColumn("actreference",typeof(string),true,false)},
			{"announcementlink",createColumn("announcementlink",typeof(string),true,false)},
			{"otherservice",createColumn("otherservice",typeof(string),true,false)},
			{"professionalservice",createColumn("professionalservice",typeof(string),true,false)},
			{"componentsvariable",createColumn("componentsvariable",typeof(string),true,false)},
			{"idserviceregistrykind",createColumn("idserviceregistrykind",typeof(int),true,false)},
			{"employtime",createColumn("employtime",typeof(string),true,false)},
			{"notes",createColumn("notes",typeof(string),true,false)},
			{"idsor01",createColumn("idsor01",typeof(int),true,false)},
			{"idsor02",createColumn("idsor02",typeof(int),true,false)},
			{"idsor03",createColumn("idsor03",typeof(int),true,false)},
			{"idsor04",createColumn("idsor04",typeof(int),true,false)},
			{"codicepaipa",createColumn("codicepaipa",typeof(string),true,false)},
			{"codiceaooipa",createColumn("codiceaooipa",typeof(string),true,false)},
			{"codiceuoipa",createColumn("codiceuoipa",typeof(string),true,false)},
			{"idsor05",createColumn("idsor05",typeof(int),true,false)},
			{"certinterestconflicts",createColumn("certinterestconflicts",typeof(string),true,false)},
			{"website_annulled",createColumn("website_annulled",typeof(string),true,false)},
			{"perla_error",createColumn("perla_error",typeof(string),true,false)},
			{"idpublicinstitutionservice",createColumn("idpublicinstitutionservice",typeof(int),true,false)},
			{"idthematicscope",createColumn("idthematicscope",typeof(int),true,false)},
		};
	}
}
}
