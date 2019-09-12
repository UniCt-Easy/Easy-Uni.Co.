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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_rendicontlezionestud {
public class rendicontlezionestudRow: MetaRow  {
	public rendicontlezionestudRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public String assente{ 
		get {if (this["assente"]==DBNull.Value)return null; return  (String)this["assente"];}
		set {if (value==null) this["assente"]= DBNull.Value; else this["assente"]= value;}
	}
	public object assenteValue { 
		get{ return this["assente"];}
		set {if (value==null|| value==DBNull.Value) this["assente"]= DBNull.Value; else this["assente"]= value;}
	}
	public String assenteOriginal { 
		get {if (this["assente",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["assente",DataRowVersion.Original];}
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
	///<summary>
	///Studente
	///</summary>
	public Int32? idreg_studenti{ 
		get {if (this["idreg_studenti"]==DBNull.Value)return null; return  (Int32?)this["idreg_studenti"];}
		set {if (value==null) this["idreg_studenti"]= DBNull.Value; else this["idreg_studenti"]= value;}
	}
	public object idreg_studentiValue { 
		get{ return this["idreg_studenti"];}
		set {if (value==null|| value==DBNull.Value) this["idreg_studenti"]= DBNull.Value; else this["idreg_studenti"]= value;}
	}
	public Int32? idreg_studentiOriginal { 
		get {if (this["idreg_studenti",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg_studenti",DataRowVersion.Original];}
	}
	///<summary>
	///Registro della lezione
	///</summary>
	public Int32? idrendicontlezione{ 
		get {if (this["idrendicontlezione"]==DBNull.Value)return null; return  (Int32?)this["idrendicontlezione"];}
		set {if (value==null) this["idrendicontlezione"]= DBNull.Value; else this["idrendicontlezione"]= value;}
	}
	public object idrendicontlezioneValue { 
		get{ return this["idrendicontlezione"];}
		set {if (value==null|| value==DBNull.Value) this["idrendicontlezione"]= DBNull.Value; else this["idrendicontlezione"]= value;}
	}
	public Int32? idrendicontlezioneOriginal { 
		get {if (this["idrendicontlezione",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idrendicontlezione",DataRowVersion.Original];}
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
	///<summary>
	///Nota disciplinare
	///</summary>
	public String notadisciplinare{ 
		get {if (this["notadisciplinare"]==DBNull.Value)return null; return  (String)this["notadisciplinare"];}
		set {if (value==null) this["notadisciplinare"]= DBNull.Value; else this["notadisciplinare"]= value;}
	}
	public object notadisciplinareValue { 
		get{ return this["notadisciplinare"];}
		set {if (value==null|| value==DBNull.Value) this["notadisciplinare"]= DBNull.Value; else this["notadisciplinare"]= value;}
	}
	public String notadisciplinareOriginal { 
		get {if (this["notadisciplinare",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["notadisciplinare",DataRowVersion.Original];}
	}
	public DateTime? ritardo{ 
		get {if (this["ritardo"]==DBNull.Value)return null; return  (DateTime?)this["ritardo"];}
		set {if (value==null) this["ritardo"]= DBNull.Value; else this["ritardo"]= value;}
	}
	public object ritardoValue { 
		get{ return this["ritardo"];}
		set {if (value==null|| value==DBNull.Value) this["ritardo"]= DBNull.Value; else this["ritardo"]= value;}
	}
	public DateTime? ritardoOriginal { 
		get {if (this["ritardo",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["ritardo",DataRowVersion.Original];}
	}
	///<summary>
	///Giustificazione del ritardo
	///</summary>
	public String ritardogiustifica{ 
		get {if (this["ritardogiustifica"]==DBNull.Value)return null; return  (String)this["ritardogiustifica"];}
		set {if (value==null) this["ritardogiustifica"]= DBNull.Value; else this["ritardogiustifica"]= value;}
	}
	public object ritardogiustificaValue { 
		get{ return this["ritardogiustifica"];}
		set {if (value==null|| value==DBNull.Value) this["ritardogiustifica"]= DBNull.Value; else this["ritardogiustifica"]= value;}
	}
	public String ritardogiustificaOriginal { 
		get {if (this["ritardogiustifica",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ritardogiustifica",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///descrive una riga del registro elettronico
///</summary>
public class rendicontlezionestudTable : MetaTableBase<rendicontlezionestudRow> {
	public rendicontlezionestudTable() : base("rendicontlezionestud"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"assente",createColumn("assente",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idreg_studenti",createColumn("idreg_studenti",typeof(int),false,false)},
			{"idrendicontlezione",createColumn("idrendicontlezione",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"notadisciplinare",createColumn("notadisciplinare",typeof(string),true,false)},
			{"ritardo",createColumn("ritardo",typeof(DateTime),true,false)},
			{"ritardogiustifica",createColumn("ritardogiustifica",typeof(string),true,false)},
		};
	}
}
}
