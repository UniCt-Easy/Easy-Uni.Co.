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
namespace meta_classescuola {
public class classescuolaRow: MetaRow  {
	public classescuolaRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Identificativo
	///</summary>
	public Int32? idclassescuola{ 
		get {if (this["idclassescuola"]==DBNull.Value)return null; return  (Int32?)this["idclassescuola"];}
		set {if (value==null) this["idclassescuola"]= DBNull.Value; else this["idclassescuola"]= value;}
	}
	public object idclassescuolaValue { 
		get{ return this["idclassescuola"];}
		set {if (value==null|| value==DBNull.Value) this["idclassescuola"]= DBNull.Value; else this["idclassescuola"]= value;}
	}
	public Int32? idclassescuolaOriginal { 
		get {if (this["idclassescuola",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idclassescuola",DataRowVersion.Original];}
	}
	///<summary>
	///Livello
	///</summary>
	public Int32? idcorsostudiolivello{ 
		get {if (this["idcorsostudiolivello"]==DBNull.Value)return null; return  (Int32?)this["idcorsostudiolivello"];}
		set {if (value==null) this["idcorsostudiolivello"]= DBNull.Value; else this["idcorsostudiolivello"]= value;}
	}
	public object idcorsostudiolivelloValue { 
		get{ return this["idcorsostudiolivello"];}
		set {if (value==null|| value==DBNull.Value) this["idcorsostudiolivello"]= DBNull.Value; else this["idcorsostudiolivello"]= value;}
	}
	public Int32? idcorsostudiolivelloOriginal { 
		get {if (this["idcorsostudiolivello",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcorsostudiolivello",DataRowVersion.Original];}
	}
	///<summary>
	///Normativa
	///</summary>
	public Int32? idcorsostudionorma{ 
		get {if (this["idcorsostudionorma"]==DBNull.Value)return null; return  (Int32?)this["idcorsostudionorma"];}
		set {if (value==null) this["idcorsostudionorma"]= DBNull.Value; else this["idcorsostudionorma"]= value;}
	}
	public object idcorsostudionormaValue { 
		get{ return this["idcorsostudionorma"];}
		set {if (value==null|| value==DBNull.Value) this["idcorsostudionorma"]= DBNull.Value; else this["idcorsostudionorma"]= value;}
	}
	public Int32? idcorsostudionormaOriginal { 
		get {if (this["idcorsostudionorma",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcorsostudionorma",DataRowVersion.Original];}
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
	///Obiettivi formativi
	///</summary>
	public String obbform{ 
		get {if (this["obbform"]==DBNull.Value)return null; return  (String)this["obbform"];}
		set {if (value==null) this["obbform"]= DBNull.Value; else this["obbform"]= value;}
	}
	public object obbformValue { 
		get{ return this["obbform"];}
		set {if (value==null|| value==DBNull.Value) this["obbform"]= DBNull.Value; else this["obbform"]= value;}
	}
	public String obbformOriginal { 
		get {if (this["obbform",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["obbform",DataRowVersion.Original];}
	}
	///<summary>
	///Prospettive occupazionali
	///</summary>
	public String prospocc{ 
		get {if (this["prospocc"]==DBNull.Value)return null; return  (String)this["prospocc"];}
		set {if (value==null) this["prospocc"]= DBNull.Value; else this["prospocc"]= value;}
	}
	public object prospoccValue { 
		get{ return this["prospocc"];}
		set {if (value==null|| value==DBNull.Value) this["prospocc"]= DBNull.Value; else this["prospocc"]= value;}
	}
	public String prospoccOriginal { 
		get {if (this["prospocc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["prospocc",DataRowVersion.Original];}
	}
	public String sigla{ 
		get {if (this["sigla"]==DBNull.Value)return null; return  (String)this["sigla"];}
		set {if (value==null) this["sigla"]= DBNull.Value; else this["sigla"]= value;}
	}
	public object siglaValue { 
		get{ return this["sigla"];}
		set {if (value==null|| value==DBNull.Value) this["sigla"]= DBNull.Value; else this["sigla"]= value;}
	}
	public String siglaOriginal { 
		get {if (this["sigla",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["sigla",DataRowVersion.Original];}
	}
	///<summary>
	///Denominazione
	///</summary>
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
	#endregion

}
///<summary>
///VOCABOLARIO MIUR delle scuole di diploma e delle classi di laurea
///</summary>
public class classescuolaTable : MetaTableBase<classescuolaRow> {
	public classescuolaTable() : base("classescuola"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idclassescuola",createColumn("idclassescuola",typeof(int),false,false)},
			{"idcorsostudiolivello",createColumn("idcorsostudiolivello",typeof(int),true,false)},
			{"idcorsostudionorma",createColumn("idcorsostudionorma",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"obbform",createColumn("obbform",typeof(string),true,false)},
			{"prospocc",createColumn("prospocc",typeof(string),true,false)},
			{"sigla",createColumn("sigla",typeof(string),true,false)},
			{"title",createColumn("title",typeof(string),false,false)},
		};
	}
}
}
