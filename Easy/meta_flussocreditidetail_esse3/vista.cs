
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
namespace meta_flussocreditidetail_esse3 {
public class flussocreditidetail_esse3Row: MetaRow  {
	public flussocreditidetail_esse3Row(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32? idflusso{ 
		get {if (this["idflusso"]==DBNull.Value)return null; return  (Int32?)this["idflusso"];}
		set {if (value==null) this["idflusso"]= DBNull.Value; else this["idflusso"]= value;}
	}
	public object idflussoValue { 
		get{ return this["idflusso"];}
		set {if (value==null|| value==DBNull.Value) this["idflusso"]= DBNull.Value; else this["idflusso"]= value;}
	}
	public Int32? idflussoOriginal { 
		get {if (this["idflusso",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idflusso",DataRowVersion.Original];}
	}
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
	public String codicevoce{ 
		get {if (this["codicevoce"]==DBNull.Value)return null; return  (String)this["codicevoce"];}
		set {if (value==null) this["codicevoce"]= DBNull.Value; else this["codicevoce"]= value;}
	}
	public object codicevoceValue { 
		get{ return this["codicevoce"];}
		set {if (value==null|| value==DBNull.Value) this["codicevoce"]= DBNull.Value; else this["codicevoce"]= value;}
	}
	public String codicevoceOriginal { 
		get {if (this["codicevoce",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicevoce",DataRowVersion.Original];}
	}
	public String codicetassa{ 
		get {if (this["codicetassa"]==DBNull.Value)return null; return  (String)this["codicetassa"];}
		set {if (value==null) this["codicetassa"]= DBNull.Value; else this["codicetassa"]= value;}
	}
	public object codicetassaValue { 
		get{ return this["codicetassa"];}
		set {if (value==null|| value==DBNull.Value) this["codicetassa"]= DBNull.Value; else this["codicetassa"]= value;}
	}
	public String codicetassaOriginal { 
		get {if (this["codicetassa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicetassa",DataRowVersion.Original];}
	}
	public String codicedipartimento{ 
		get {if (this["codicedipartimento"]==DBNull.Value)return null; return  (String)this["codicedipartimento"];}
		set {if (value==null) this["codicedipartimento"]= DBNull.Value; else this["codicedipartimento"]= value;}
	}
	public object codicedipartimentoValue { 
		get{ return this["codicedipartimento"];}
		set {if (value==null|| value==DBNull.Value) this["codicedipartimento"]= DBNull.Value; else this["codicedipartimento"]= value;}
	}
	public String codicedipartimentoOriginal { 
		get {if (this["codicedipartimento",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicedipartimento",DataRowVersion.Original];}
	}
	public String codicesede{ 
		get {if (this["codicesede"]==DBNull.Value)return null; return  (String)this["codicesede"];}
		set {if (value==null) this["codicesede"]= DBNull.Value; else this["codicesede"]= value;}
	}
	public object codicesedeValue { 
		get{ return this["codicesede"];}
		set {if (value==null|| value==DBNull.Value) this["codicesede"]= DBNull.Value; else this["codicesede"]= value;}
	}
	public String codicesedeOriginal { 
		get {if (this["codicesede",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicesede",DataRowVersion.Original];}
	}
	public String codicecorsolaurea{ 
		get {if (this["codicecorsolaurea"]==DBNull.Value)return null; return  (String)this["codicecorsolaurea"];}
		set {if (value==null) this["codicecorsolaurea"]= DBNull.Value; else this["codicecorsolaurea"]= value;}
	}
	public object codicecorsolaureaValue { 
		get{ return this["codicecorsolaurea"];}
		set {if (value==null|| value==DBNull.Value) this["codicecorsolaurea"]= DBNull.Value; else this["codicecorsolaurea"]= value;}
	}
	public String codicecorsolaureaOriginal { 
		get {if (this["codicecorsolaurea",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicecorsolaurea",DataRowVersion.Original];}
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
	public String codicecausale{ 
		get {if (this["codicecausale"]==DBNull.Value)return null; return  (String)this["codicecausale"];}
		set {if (value==null) this["codicecausale"]= DBNull.Value; else this["codicecausale"]= value;}
	}
	public object codicecausaleValue { 
		get{ return this["codicecausale"];}
		set {if (value==null|| value==DBNull.Value) this["codicecausale"]= DBNull.Value; else this["codicecausale"]= value;}
	}
	public String codicecausaleOriginal { 
		get {if (this["codicecausale",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicecausale",DataRowVersion.Original];}
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
	public DateTime? competencystart{ 
		get {if (this["competencystart"]==DBNull.Value)return null; return  (DateTime?)this["competencystart"];}
		set {if (value==null) this["competencystart"]= DBNull.Value; else this["competencystart"]= value;}
	}
	public object competencystartValue { 
		get{ return this["competencystart"];}
		set {if (value==null|| value==DBNull.Value) this["competencystart"]= DBNull.Value; else this["competencystart"]= value;}
	}
	public DateTime? competencystartOriginal { 
		get {if (this["competencystart",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["competencystart",DataRowVersion.Original];}
	}
	public DateTime? competencystop{ 
		get {if (this["competencystop"]==DBNull.Value)return null; return  (DateTime?)this["competencystop"];}
		set {if (value==null) this["competencystop"]= DBNull.Value; else this["competencystop"]= value;}
	}
	public object competencystopValue { 
		get{ return this["competencystop"];}
		set {if (value==null|| value==DBNull.Value) this["competencystop"]= DBNull.Value; else this["competencystop"]= value;}
	}
	public DateTime? competencystopOriginal { 
		get {if (this["competencystop",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["competencystop",DataRowVersion.Original];}
	}
	public Decimal? importoversamento{ 
		get {if (this["importoversamento"]==DBNull.Value)return null; return  (Decimal?)this["importoversamento"];}
		set {if (value==null) this["importoversamento"]= DBNull.Value; else this["importoversamento"]= value;}
	}
	public object importoversamentoValue { 
		get{ return this["importoversamento"];}
		set {if (value==null|| value==DBNull.Value) this["importoversamento"]= DBNull.Value; else this["importoversamento"]= value;}
	}
	public Decimal? importoversamentoOriginal { 
		get {if (this["importoversamento",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["importoversamento",DataRowVersion.Original];}
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
	public DateTime? datacontabile{ 
		get {if (this["datacontabile"]==DBNull.Value)return null; return  (DateTime?)this["datacontabile"];}
		set {if (value==null) this["datacontabile"]= DBNull.Value; else this["datacontabile"]= value;}
	}
	public object datacontabileValue { 
		get{ return this["datacontabile"];}
		set {if (value==null|| value==DBNull.Value) this["datacontabile"]= DBNull.Value; else this["datacontabile"]= value;}
	}
	public DateTime? datacontabileOriginal { 
		get {if (this["datacontabile",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["datacontabile",DataRowVersion.Original];}
	}
	public String iduniqueformcode{ 
		get {if (this["iduniqueformcode"]==DBNull.Value)return null; return  (String)this["iduniqueformcode"];}
		set {if (value==null) this["iduniqueformcode"]= DBNull.Value; else this["iduniqueformcode"]= value;}
	}
	public object iduniqueformcodeValue { 
		get{ return this["iduniqueformcode"];}
		set {if (value==null|| value==DBNull.Value) this["iduniqueformcode"]= DBNull.Value; else this["iduniqueformcode"]= value;}
	}
	public String iduniqueformcodeOriginal { 
		get {if (this["iduniqueformcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["iduniqueformcode",DataRowVersion.Original];}
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
	public DateTime? datascadenza{ 
		get {if (this["datascadenza"]==DBNull.Value)return null; return  (DateTime?)this["datascadenza"];}
		set {if (value==null) this["datascadenza"]= DBNull.Value; else this["datascadenza"]= value;}
	}
	public object datascadenzaValue { 
		get{ return this["datascadenza"];}
		set {if (value==null|| value==DBNull.Value) this["datascadenza"]= DBNull.Value; else this["datascadenza"]= value;}
	}
	public DateTime? datascadenzaOriginal { 
		get {if (this["datascadenza",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["datascadenza",DataRowVersion.Original];}
	}
	public Int32? annoedizione{ 
		get {if (this["annoedizione"]==DBNull.Value)return null; return  (Int32?)this["annoedizione"];}
		set {if (value==null) this["annoedizione"]= DBNull.Value; else this["annoedizione"]= value;}
	}
	public object annoedizioneValue { 
		get{ return this["annoedizione"];}
		set {if (value==null|| value==DBNull.Value) this["annoedizione"]= DBNull.Value; else this["annoedizione"]= value;}
	}
	public Int32? annoedizioneOriginal { 
		get {if (this["annoedizione",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["annoedizione",DataRowVersion.Original];}
	}
	public String codicepercorsostudi{ 
		get {if (this["codicepercorsostudi"]==DBNull.Value)return null; return  (String)this["codicepercorsostudi"];}
		set {if (value==null) this["codicepercorsostudi"]= DBNull.Value; else this["codicepercorsostudi"]= value;}
	}
	public object codicepercorsostudiValue { 
		get{ return this["codicepercorsostudi"];}
		set {if (value==null|| value==DBNull.Value) this["codicepercorsostudi"]= DBNull.Value; else this["codicepercorsostudi"]= value;}
	}
	public String codicepercorsostudiOriginal { 
		get {if (this["codicepercorsostudi",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicepercorsostudi",DataRowVersion.Original];}
	}
	public Int32? rata{ 
		get {if (this["rata"]==DBNull.Value)return null; return  (Int32?)this["rata"];}
		set {if (value==null) this["rata"]= DBNull.Value; else this["rata"]= value;}
	}
	public object rataValue { 
		get{ return this["rata"];}
		set {if (value==null|| value==DBNull.Value) this["rata"]= DBNull.Value; else this["rata"]= value;}
	}
	public Int32? rataOriginal { 
		get {if (this["rata",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["rata",DataRowVersion.Original];}
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
	#endregion

}
public class flussocreditidetail_esse3Table : MetaTableBase<flussocreditidetail_esse3Row> {
	public flussocreditidetail_esse3Table() : base("flussocreditidetail_esse3"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idflusso",createColumn("idflusso",typeof(int),false,false)},
			{"iddetail",createColumn("iddetail",typeof(int),false,false)},
			{"codicevoce",createColumn("codicevoce",typeof(string),true,false)},
			{"codicetassa",createColumn("codicetassa",typeof(string),true,false)},
			{"codicedipartimento",createColumn("codicedipartimento",typeof(string),true,false)},
			{"codicesede",createColumn("codicesede",typeof(string),true,false)},
			{"codicecorsolaurea",createColumn("codicecorsolaurea",typeof(string),true,false)},
			{"cf",createColumn("cf",typeof(string),true,false)},
			{"codicecausale",createColumn("codicecausale",typeof(string),true,false)},
			{"iuv",createColumn("iuv",typeof(string),true,false)},
			{"competencystart",createColumn("competencystart",typeof(DateTime),true,false)},
			{"competencystop",createColumn("competencystop",typeof(DateTime),true,false)},
			{"importoversamento",createColumn("importoversamento",typeof(decimal),true,false)},
			{"forename",createColumn("forename",typeof(string),true,false)},
			{"surname",createColumn("surname",typeof(string),true,false)},
			{"datacontabile",createColumn("datacontabile",typeof(DateTime),true,false)},
			{"iduniqueformcode",createColumn("iduniqueformcode",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"datascadenza",createColumn("datascadenza",typeof(DateTime),true,false)},
			{"annoedizione",createColumn("annoedizione",typeof(int),true,false)},
			{"codicepercorsostudi",createColumn("codicepercorsostudi",typeof(string),true,false)},
			{"rata",createColumn("rata",typeof(int),true,false)},
			{"email",createColumn("email",typeof(string),true,false)},
		};
	}
}
}
