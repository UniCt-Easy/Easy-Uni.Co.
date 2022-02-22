
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
namespace meta_flussocreditidetail_gomp {
public class flussocreditidetail_gompRow: MetaRow  {
	public flussocreditidetail_gompRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 idflusso{ 
		get {return  (Int32)this["idflusso"];}
		set {this["idflusso"]= value;}
	}
	public object idflussoValue { 
		get{ return this["idflusso"];}
		set {this["idflusso"]= value;}
	}
	public Int32 idflussoOriginal { 
		get {return  (Int32)this["idflusso",DataRowVersion.Original];}
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
	public Int32? annoregolamento{ 
		get {if (this["annoregolamento"]==DBNull.Value)return null; return  (Int32?)this["annoregolamento"];}
		set {if (value==null) this["annoregolamento"]= DBNull.Value; else this["annoregolamento"]= value;}
	}
	public object annoregolamentoValue { 
		get{ return this["annoregolamento"];}
		set {if (value==null|| value==DBNull.Value) this["annoregolamento"]= DBNull.Value; else this["annoregolamento"]= value;}
	}
	public Int32? annoregolamentoOriginal { 
		get {if (this["annoregolamento",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["annoregolamento",DataRowVersion.Original];}
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
	public String codicecorsolaurea{ 
		get {return  (String)this["codicecorsolaurea"];}
		set {this["codicecorsolaurea"]= value;}
	}
	public object codicecorsolaureaValue { 
		get{ return this["codicecorsolaurea"];}
		set {this["codicecorsolaurea"]= value;}
	}
	public String codicecorsolaureaOriginal { 
		get {return  (String)this["codicecorsolaurea",DataRowVersion.Original];}
	}
	public String codicedipartimento{ 
		get {return  (String)this["codicedipartimento"];}
		set {this["codicedipartimento"]= value;}
	}
	public object codicedipartimentoValue { 
		get{ return this["codicedipartimento"];}
		set {this["codicedipartimento"]= value;}
	}
	public String codicedipartimentoOriginal { 
		get {return  (String)this["codicedipartimento",DataRowVersion.Original];}
	}
	public String codicesede{ 
		get {return  (String)this["codicesede"];}
		set {this["codicesede"]= value;}
	}
	public object codicesedeValue { 
		get{ return this["codicesede"];}
		set {this["codicesede"]= value;}
	}
	public String codicesedeOriginal { 
		get {return  (String)this["codicesede",DataRowVersion.Original];}
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
	public String descrizione{ 
		get {if (this["descrizione"]==DBNull.Value)return null; return  (String)this["descrizione"];}
		set {if (value==null) this["descrizione"]= DBNull.Value; else this["descrizione"]= value;}
	}
	public object descrizioneValue { 
		get{ return this["descrizione"];}
		set {if (value==null|| value==DBNull.Value) this["descrizione"]= DBNull.Value; else this["descrizione"]= value;}
	}
	public String descrizioneOriginal { 
		get {if (this["descrizione",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["descrizione",DataRowVersion.Original];}
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
	public String fuoricorso{ 
		get {if (this["fuoricorso"]==DBNull.Value)return null; return  (String)this["fuoricorso"];}
		set {if (value==null) this["fuoricorso"]= DBNull.Value; else this["fuoricorso"]= value;}
	}
	public object fuoricorsoValue { 
		get{ return this["fuoricorso"];}
		set {if (value==null|| value==DBNull.Value) this["fuoricorso"]= DBNull.Value; else this["fuoricorso"]= value;}
	}
	public String fuoricorsoOriginal { 
		get {if (this["fuoricorso",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["fuoricorso",DataRowVersion.Original];}
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
	public String tipologiacorso{ 
		get {if (this["tipologiacorso"]==DBNull.Value)return null; return  (String)this["tipologiacorso"];}
		set {if (value==null) this["tipologiacorso"]= DBNull.Value; else this["tipologiacorso"]= value;}
	}
	public object tipologiacorsoValue { 
		get{ return this["tipologiacorso"];}
		set {if (value==null|| value==DBNull.Value) this["tipologiacorso"]= DBNull.Value; else this["tipologiacorso"]= value;}
	}
	public String tipologiacorsoOriginal { 
		get {if (this["tipologiacorso",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tipologiacorso",DataRowVersion.Original];}
	}
	#endregion

}
public class flussocreditidetail_gompTable : MetaTableBase<flussocreditidetail_gompRow> {
	public flussocreditidetail_gompTable() : base("flussocreditidetail_gomp"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idflusso",createColumn("idflusso",typeof(int),false,false)},
			{"iddetail",createColumn("iddetail",typeof(int),false,false)},
			{"annoregolamento",createColumn("annoregolamento",typeof(int),true,false)},
			{"birthdate",createColumn("birthdate",typeof(DateTime),true,false)},
			{"cf",createColumn("cf",typeof(string),true,false)},
			{"codicecausale",createColumn("codicecausale",typeof(string),true,false)},
			{"codicecorsolaurea",createColumn("codicecorsolaurea",typeof(string),false,false)},
			{"codicedipartimento",createColumn("codicedipartimento",typeof(string),false,false)},
			{"codicesede",createColumn("codicesede",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"descrizione",createColumn("descrizione",typeof(string),true,false)},
			{"email",createColumn("email",typeof(string),true,false)},
			{"forename",createColumn("forename",typeof(string),true,false)},
			{"fuoricorso",createColumn("fuoricorso",typeof(string),true,false)},
			{"iduniqueformcode",createColumn("iduniqueformcode",typeof(string),true,false)},
			{"importoversamento",createColumn("importoversamento",typeof(decimal),true,false)},
			{"iuv",createColumn("iuv",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"surname",createColumn("surname",typeof(string),true,false)},
			{"tipologiacorso",createColumn("tipologiacorso",typeof(string),true,false)},
		};
	}
}
}
