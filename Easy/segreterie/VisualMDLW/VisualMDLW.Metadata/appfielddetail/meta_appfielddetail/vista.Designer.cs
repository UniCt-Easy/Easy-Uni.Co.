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
namespace meta_appfielddetail {
public class appfielddetailRow: MetaRow  {
	public appfielddetailRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Corpo della funzione nel caso sia un campo calcolato
	///</summary>
	public String calculatedfieldfunction{ 
		get {if (this["calculatedfieldfunction"]==DBNull.Value)return null; return  (String)this["calculatedfieldfunction"];}
		set {if (value==null) this["calculatedfieldfunction"]= DBNull.Value; else this["calculatedfieldfunction"]= value;}
	}
	public object calculatedfieldfunctionValue { 
		get{ return this["calculatedfieldfunction"];}
		set {if (value==null|| value==DBNull.Value) this["calculatedfieldfunction"]= DBNull.Value; else this["calculatedfieldfunction"]= value;}
	}
	public String calculatedfieldfunctionOriginal { 
		get {if (this["calculatedfieldfunction",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["calculatedfieldfunction",DataRowVersion.Original];}
	}
	///<summary>
	///Nome colonna
	///</summary>
	public String columnname{ 
		get {if (this["columnname"]==DBNull.Value)return null; return  (String)this["columnname"];}
		set {if (value==null) this["columnname"]= DBNull.Value; else this["columnname"]= value;}
	}
	public object columnnameValue { 
		get{ return this["columnname"];}
		set {if (value==null|| value==DBNull.Value) this["columnname"]= DBNull.Value; else this["columnname"]= value;}
	}
	public String columnnameOriginal { 
		get {if (this["columnname",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["columnname",DataRowVersion.Original];}
	}
	///<summary>
	///Default Value
	///</summary>
	public String defaultvalue{ 
		get {if (this["defaultvalue"]==DBNull.Value)return null; return  (String)this["defaultvalue"];}
		set {if (value==null) this["defaultvalue"]= DBNull.Value; else this["defaultvalue"]= value;}
	}
	public object defaultvalueValue { 
		get{ return this["defaultvalue"];}
		set {if (value==null|| value==DBNull.Value) this["defaultvalue"]= DBNull.Value; else this["defaultvalue"]= value;}
	}
	public String defaultvalueOriginal { 
		get {if (this["defaultvalue",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["defaultvalue",DataRowVersion.Original];}
	}
	///<summary>
	///Nascosto
	///</summary>
	public String hidden{ 
		get {if (this["hidden"]==DBNull.Value)return null; return  (String)this["hidden"];}
		set {if (value==null) this["hidden"]= DBNull.Value; else this["hidden"]= value;}
	}
	public object hiddenValue { 
		get{ return this["hidden"];}
		set {if (value==null|| value==DBNull.Value) this["hidden"]= DBNull.Value; else this["hidden"]= value;}
	}
	public String hiddenOriginal { 
		get {if (this["hidden",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["hidden",DataRowVersion.Original];}
	}
	public Int32? idappfielddetail{ 
		get {if (this["idappfielddetail"]==DBNull.Value)return null; return  (Int32?)this["idappfielddetail"];}
		set {if (value==null) this["idappfielddetail"]= DBNull.Value; else this["idappfielddetail"]= value;}
	}
	public object idappfielddetailValue { 
		get{ return this["idappfielddetail"];}
		set {if (value==null|| value==DBNull.Value) this["idappfielddetail"]= DBNull.Value; else this["idappfielddetail"]= value;}
	}
	public Int32? idappfielddetailOriginal { 
		get {if (this["idappfielddetail",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idappfielddetail",DataRowVersion.Original];}
	}
	///<summary>
	///Interfaccia
	///</summary>
	public Int32? idapppages{ 
		get {if (this["idapppages"]==DBNull.Value)return null; return  (Int32?)this["idapppages"];}
		set {if (value==null) this["idapppages"]= DBNull.Value; else this["idapppages"]= value;}
	}
	public object idapppagesValue { 
		get{ return this["idapppages"];}
		set {if (value==null|| value==DBNull.Value) this["idapppages"]= DBNull.Value; else this["idapppages"]= value;}
	}
	public Int32? idapppagesOriginal { 
		get {if (this["idapppages",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idapppages",DataRowVersion.Original];}
	}
	///<summary>
	///Tab
	///</summary>
	public Int32? idapptab{ 
		get {if (this["idapptab"]==DBNull.Value)return null; return  (Int32?)this["idapptab"];}
		set {if (value==null) this["idapptab"]= DBNull.Value; else this["idapptab"]= value;}
	}
	public object idapptabValue { 
		get{ return this["idapptab"];}
		set {if (value==null|| value==DBNull.Value) this["idapptab"]= DBNull.Value; else this["idapptab"]= value;}
	}
	public Int32? idapptabOriginal { 
		get {if (this["idapptab",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idapptab",DataRowVersion.Original];}
	}
	///<summary>
	///Rappresentalo come checkbox (solo per char(1) S/N)
	///</summary>
	public String ischeckbox{ 
		get {if (this["ischeckbox"]==DBNull.Value)return null; return  (String)this["ischeckbox"];}
		set {if (value==null) this["ischeckbox"]= DBNull.Value; else this["ischeckbox"]= value;}
	}
	public object ischeckboxValue { 
		get{ return this["ischeckbox"];}
		set {if (value==null|| value==DBNull.Value) this["ischeckbox"]= DBNull.Value; else this["ischeckbox"]= value;}
	}
	public String ischeckboxOriginal { 
		get {if (this["ischeckbox",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ischeckbox",DataRowVersion.Original];}
	}
	///<summary>
	///foreign key di collegamento
	///</summary>
	public String islinkingobj{ 
		get {if (this["islinkingobj"]==DBNull.Value)return null; return  (String)this["islinkingobj"];}
		set {if (value==null) this["islinkingobj"]= DBNull.Value; else this["islinkingobj"]= value;}
	}
	public object islinkingobjValue { 
		get{ return this["islinkingobj"];}
		set {if (value==null|| value==DBNull.Value) this["islinkingobj"]= DBNull.Value; else this["islinkingobj"]= value;}
	}
	public String islinkingobjOriginal { 
		get {if (this["islinkingobj",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["islinkingobj",DataRowVersion.Original];}
	}
	///<summary>
	///Nullable
	///</summary>
	public String isnullable{ 
		get {if (this["isnullable"]==DBNull.Value)return null; return  (String)this["isnullable"];}
		set {if (value==null) this["isnullable"]= DBNull.Value; else this["isnullable"]= value;}
	}
	public object isnullableValue { 
		get{ return this["isnullable"];}
		set {if (value==null|| value==DBNull.Value) this["isnullable"]= DBNull.Value; else this["isnullable"]= value;}
	}
	public String isnullableOriginal { 
		get {if (this["isnullable",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["isnullable",DataRowVersion.Original];}
	}
	///<summary>
	///Listtype (autochoose e select)
	///</summary>
	public String listtype{ 
		get {if (this["listtype"]==DBNull.Value)return null; return  (String)this["listtype"];}
		set {if (value==null) this["listtype"]= DBNull.Value; else this["listtype"]= value;}
	}
	public object listtypeValue { 
		get{ return this["listtype"];}
		set {if (value==null|| value==DBNull.Value) this["listtype"]= DBNull.Value; else this["listtype"]= value;}
	}
	public String listtypeOriginal { 
		get {if (this["listtype",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["listtype",DataRowVersion.Original];}
	}
	///<summary>
	///Combo master
	///</summary>
	public String master{ 
		get {if (this["master"]==DBNull.Value)return null; return  (String)this["master"];}
		set {if (value==null) this["master"]= DBNull.Value; else this["master"]= value;}
	}
	public object masterValue { 
		get{ return this["master"];}
		set {if (value==null|| value==DBNull.Value) this["master"]= DBNull.Value; else this["master"]= value;}
	}
	public String masterOriginal { 
		get {if (this["master",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["master",DataRowVersion.Original];}
	}
	///<summary>
	///Posizione
	///</summary>
	public Int32? position{ 
		get {if (this["position"]==DBNull.Value)return null; return  (Int32?)this["position"];}
		set {if (value==null) this["position"]= DBNull.Value; else this["position"]= value;}
	}
	public object positionValue { 
		get{ return this["position"];}
		set {if (value==null|| value==DBNull.Value) this["position"]= DBNull.Value; else this["position"]= value;}
	}
	public Int32? positionOriginal { 
		get {if (this["position",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["position",DataRowVersion.Original];}
	}
	///<summary>
	///Valori (radio button)
	///</summary>
	public String radiovalues{ 
		get {if (this["radiovalues"]==DBNull.Value)return null; return  (String)this["radiovalues"];}
		set {if (value==null) this["radiovalues"]= DBNull.Value; else this["radiovalues"]= value;}
	}
	public object radiovaluesValue { 
		get{ return this["radiovalues"];}
		set {if (value==null|| value==DBNull.Value) this["radiovalues"]= DBNull.Value; else this["radiovalues"]= value;}
	}
	public String radiovaluesOriginal { 
		get {if (this["radiovalues",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["radiovalues",DataRowVersion.Original];}
	}
	///<summary>
	///Campo in sola lettura
	///</summary>
	public String readonlyfield{ 
		get {if (this["readonlyfield"]==DBNull.Value)return null; return  (String)this["readonlyfield"];}
		set {if (value==null) this["readonlyfield"]= DBNull.Value; else this["readonlyfield"]= value;}
	}
	public object readonlyfieldValue { 
		get{ return this["readonlyfield"];}
		set {if (value==null|| value==DBNull.Value) this["readonlyfield"]= DBNull.Value; else this["readonlyfield"]= value;}
	}
	public String readonlyfieldOriginal { 
		get {if (this["readonlyfield",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["readonlyfield",DataRowVersion.Original];}
	}
	///<summary>
	///Filtro sulla tabella collegata
	///</summary>
	public String tablefilter{ 
		get {if (this["tablefilter"]==DBNull.Value)return null; return  (String)this["tablefilter"];}
		set {if (value==null) this["tablefilter"]= DBNull.Value; else this["tablefilter"]= value;}
	}
	public object tablefilterValue { 
		get{ return this["tablefilter"];}
		set {if (value==null|| value==DBNull.Value) this["tablefilter"]= DBNull.Value; else this["tablefilter"]= value;}
	}
	public String tablefilterOriginal { 
		get {if (this["tablefilter",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tablefilter",DataRowVersion.Original];}
	}
	public String testvalue{ 
		get {if (this["testvalue"]==DBNull.Value)return null; return  (String)this["testvalue"];}
		set {if (value==null) this["testvalue"]= DBNull.Value; else this["testvalue"]= value;}
	}
	public object testvalueValue { 
		get{ return this["testvalue"];}
		set {if (value==null|| value==DBNull.Value) this["testvalue"]= DBNull.Value; else this["testvalue"]= value;}
	}
	public String testvalueOriginal { 
		get {if (this["testvalue",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["testvalue",DataRowVersion.Original];}
	}
	///<summary>
	///Intestazione
	///</summary>
	public String text{ 
		get {if (this["text"]==DBNull.Value)return null; return  (String)this["text"];}
		set {if (value==null) this["text"]= DBNull.Value; else this["text"]= value;}
	}
	public object textValue { 
		get{ return this["text"];}
		set {if (value==null|| value==DBNull.Value) this["text"]= DBNull.Value; else this["text"]= value;}
	}
	public String textOriginal { 
		get {if (this["text",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["text",DataRowVersion.Original];}
	}
	///<summary>
	///Rappresenta come textarea (solo per nvarchar nchar che non siano già max)
	///</summary>
	public String textarea{ 
		get {if (this["textarea"]==DBNull.Value)return null; return  (String)this["textarea"];}
		set {if (value==null) this["textarea"]= DBNull.Value; else this["textarea"]= value;}
	}
	public object textareaValue { 
		get{ return this["textarea"];}
		set {if (value==null|| value==DBNull.Value) this["textarea"]= DBNull.Value; else this["textarea"]= value;}
	}
	public String textareaOriginal { 
		get {if (this["textarea",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["textarea",DataRowVersion.Original];}
	}
	///<summary>
	///Nome alternativo
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
	///<summary>
	///Disponi da solo sulla riga
	///</summary>
	public String uniqueonrow{ 
		get {if (this["uniqueonrow"]==DBNull.Value)return null; return  (String)this["uniqueonrow"];}
		set {if (value==null) this["uniqueonrow"]= DBNull.Value; else this["uniqueonrow"]= value;}
	}
	public object uniqueonrowValue { 
		get{ return this["uniqueonrow"];}
		set {if (value==null|| value==DBNull.Value) this["uniqueonrow"]= DBNull.Value; else this["uniqueonrow"]= value;}
	}
	public String uniqueonrowOriginal { 
		get {if (this["uniqueonrow",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["uniqueonrow",DataRowVersion.Original];}
	}
	///<summary>
	///Inserito nella pagina di dettaglio
	///</summary>
	public String visible{ 
		get {if (this["visible"]==DBNull.Value)return null; return  (String)this["visible"];}
		set {if (value==null) this["visible"]= DBNull.Value; else this["visible"]= value;}
	}
	public object visibleValue { 
		get{ return this["visible"];}
		set {if (value==null|| value==DBNull.Value) this["visible"]= DBNull.Value; else this["visible"]= value;}
	}
	public String visibleOriginal { 
		get {if (this["visible",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["visible",DataRowVersion.Original];}
	}
	#endregion

}
public class appfielddetailTable : MetaTableBase<appfielddetailRow> {
	public appfielddetailTable() : base("appfielddetail"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"calculatedfieldfunction",createColumn("calculatedfieldfunction",typeof(string),true,false)},
			{"columnname",createColumn("columnname",typeof(string),true,false)},
			{"defaultvalue",createColumn("defaultvalue",typeof(string),true,false)},
			{"hidden",createColumn("hidden",typeof(string),true,false)},
			{"idappfielddetail",createColumn("idappfielddetail",typeof(int),false,false)},
			{"idapppages",createColumn("idapppages",typeof(int),false,false)},
			{"idapptab",createColumn("idapptab",typeof(int),true,false)},
			{"ischeckbox",createColumn("ischeckbox",typeof(string),false,false)},
			{"islinkingobj",createColumn("islinkingobj",typeof(string),true,false)},
			{"isnullable",createColumn("isnullable",typeof(string),true,false)},
			{"listtype",createColumn("listtype",typeof(string),true,false)},
			{"master",createColumn("master",typeof(string),true,false)},
			{"position",createColumn("position",typeof(int),true,false)},
			{"radiovalues",createColumn("radiovalues",typeof(string),true,false)},
			{"readonlyfield",createColumn("readonlyfield",typeof(string),true,false)},
			{"tablefilter",createColumn("tablefilter",typeof(string),true,false)},
			{"testvalue",createColumn("testvalue",typeof(string),true,false)},
			{"text",createColumn("text",typeof(string),true,false)},
			{"textarea",createColumn("textarea",typeof(string),false,false)},
			{"title",createColumn("title",typeof(string),true,false)},
			{"uniqueonrow",createColumn("uniqueonrow",typeof(string),false,false)},
			{"visible",createColumn("visible",typeof(string),true,false)},
		};
	}
}
}
