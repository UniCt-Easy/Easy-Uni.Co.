
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
namespace meta_classconsorsuale {
public class classconsorsualeRow: MetaRow  {
	public classconsorsualeRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Attiva
	///</summary>
	public String active{ 
		get {if (this["active"]==DBNull.Value)return null; return  (String)this["active"];}
		set {if (value==null) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public object activeValue { 
		get{ return this["active"];}
		set {if (value==null|| value==DBNull.Value) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public String activeOriginal { 
		get {if (this["active",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["active",DataRowVersion.Original];}
	}
	///<summary>
	///Ambito Disciplinare
	///</summary>
	public String ambitodisci{ 
		get {if (this["ambitodisci"]==DBNull.Value)return null; return  (String)this["ambitodisci"];}
		set {if (value==null) this["ambitodisci"]= DBNull.Value; else this["ambitodisci"]= value;}
	}
	public object ambitodisciValue { 
		get{ return this["ambitodisci"];}
		set {if (value==null|| value==DBNull.Value) this["ambitodisci"]= DBNull.Value; else this["ambitodisci"]= value;}
	}
	public String ambitodisciOriginal { 
		get {if (this["ambitodisci",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ambitodisci",DataRowVersion.Original];}
	}
	///<summary>
	///Corrispondenza
	///</summary>
	public String corr2592017{ 
		get {if (this["corr2592017"]==DBNull.Value)return null; return  (String)this["corr2592017"];}
		set {if (value==null) this["corr2592017"]= DBNull.Value; else this["corr2592017"]= value;}
	}
	public object corr2592017Value { 
		get{ return this["corr2592017"];}
		set {if (value==null|| value==DBNull.Value) this["corr2592017"]= DBNull.Value; else this["corr2592017"]= value;}
	}
	public String corr2592017Original { 
		get {if (this["corr2592017",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["corr2592017",DataRowVersion.Original];}
	}
	///<summary>
	///Descrizione
	///</summary>
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
	///<summary>
	///Codice
	///</summary>
	public Int32? idclassconsorsuale{ 
		get {if (this["idclassconsorsuale"]==DBNull.Value)return null; return  (Int32?)this["idclassconsorsuale"];}
		set {if (value==null) this["idclassconsorsuale"]= DBNull.Value; else this["idclassconsorsuale"]= value;}
	}
	public object idclassconsorsualeValue { 
		get{ return this["idclassconsorsuale"];}
		set {if (value==null|| value==DBNull.Value) this["idclassconsorsuale"]= DBNull.Value; else this["idclassconsorsuale"]= value;}
	}
	public Int32? idclassconsorsualeOriginal { 
		get {if (this["idclassconsorsuale",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idclassconsorsuale",DataRowVersion.Original];}
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
	public String normativa{ 
		get {if (this["normativa"]==DBNull.Value)return null; return  (String)this["normativa"];}
		set {if (value==null) this["normativa"]= DBNull.Value; else this["normativa"]= value;}
	}
	public object normativaValue { 
		get{ return this["normativa"];}
		set {if (value==null|| value==DBNull.Value) this["normativa"]= DBNull.Value; else this["normativa"]= value;}
	}
	public String normativaOriginal { 
		get {if (this["normativa",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["normativa",DataRowVersion.Original];}
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
///VOCABOLARIO MIUR delle classi di concorso
///</summary>
public class classconsorsualeTable : MetaTableBase<classconsorsualeRow> {
	public classconsorsualeTable() : base("classconsorsuale"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"active",createColumn("active",typeof(string),false,false)},
			{"ambitodisci",createColumn("ambitodisci",typeof(string),true,false)},
			{"corr2592017",createColumn("corr2592017",typeof(string),true,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"idclassconsorsuale",createColumn("idclassconsorsuale",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"normativa",createColumn("normativa",typeof(string),false,false)},
			{"title",createColumn("title",typeof(string),false,false)},
		};
	}
}
}
