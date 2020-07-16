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
namespace meta_apprelation {
public class apprelationRow: MetaRow  {
	public apprelationRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Abilita il tasto elimina
	///</summary>
	public String buttondelete{ 
		get {if (this["buttondelete"]==DBNull.Value)return null; return  (String)this["buttondelete"];}
		set {if (value==null) this["buttondelete"]= DBNull.Value; else this["buttondelete"]= value;}
	}
	public object buttondeleteValue { 
		get{ return this["buttondelete"];}
		set {if (value==null|| value==DBNull.Value) this["buttondelete"]= DBNull.Value; else this["buttondelete"]= value;}
	}
	public String buttondeleteOriginal { 
		get {if (this["buttondelete",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["buttondelete",DataRowVersion.Original];}
	}
	///<summary>
	///Abilita il tasto modifica
	///</summary>
	public String buttonedit{ 
		get {if (this["buttonedit"]==DBNull.Value)return null; return  (String)this["buttonedit"];}
		set {if (value==null) this["buttonedit"]= DBNull.Value; else this["buttonedit"]= value;}
	}
	public object buttoneditValue { 
		get{ return this["buttonedit"];}
		set {if (value==null|| value==DBNull.Value) this["buttonedit"]= DBNull.Value; else this["buttonedit"]= value;}
	}
	public String buttoneditOriginal { 
		get {if (this["buttonedit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["buttonedit",DataRowVersion.Original];}
	}
	///<summary>
	///Abilita il tasto nuovo
	///</summary>
	public String buttoninsert{ 
		get {if (this["buttoninsert"]==DBNull.Value)return null; return  (String)this["buttoninsert"];}
		set {if (value==null) this["buttoninsert"]= DBNull.Value; else this["buttoninsert"]= value;}
	}
	public object buttoninsertValue { 
		get{ return this["buttoninsert"];}
		set {if (value==null|| value==DBNull.Value) this["buttoninsert"]= DBNull.Value; else this["buttoninsert"]= value;}
	}
	public String buttoninsertOriginal { 
		get {if (this["buttoninsert",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["buttoninsert",DataRowVersion.Original];}
	}
	///<summary>
	///Colonna con data/ora inizio degli eventi
	///</summary>
	public String calendarstart{ 
		get {if (this["calendarstart"]==DBNull.Value)return null; return  (String)this["calendarstart"];}
		set {if (value==null) this["calendarstart"]= DBNull.Value; else this["calendarstart"]= value;}
	}
	public object calendarstartValue { 
		get{ return this["calendarstart"];}
		set {if (value==null|| value==DBNull.Value) this["calendarstart"]= DBNull.Value; else this["calendarstart"]= value;}
	}
	public String calendarstartOriginal { 
		get {if (this["calendarstart",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["calendarstart",DataRowVersion.Original];}
	}
	///<summary>
	///Colonna con data/ora fine degli eventi
	///</summary>
	public String calendarstop{ 
		get {if (this["calendarstop"]==DBNull.Value)return null; return  (String)this["calendarstop"];}
		set {if (value==null) this["calendarstop"]= DBNull.Value; else this["calendarstop"]= value;}
	}
	public object calendarstopValue { 
		get{ return this["calendarstop"];}
		set {if (value==null|| value==DBNull.Value) this["calendarstop"]= DBNull.Value; else this["calendarstop"]= value;}
	}
	public String calendarstopOriginal { 
		get {if (this["calendarstop",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["calendarstop",DataRowVersion.Original];}
	}
	///<summary>
	///Colonna con il titolo degli eventi
	///</summary>
	public String calendartitle{ 
		get {if (this["calendartitle"]==DBNull.Value)return null; return  (String)this["calendartitle"];}
		set {if (value==null) this["calendartitle"]= DBNull.Value; else this["calendartitle"]= value;}
	}
	public object calendartitleValue { 
		get{ return this["calendartitle"];}
		set {if (value==null|| value==DBNull.Value) this["calendartitle"]= DBNull.Value; else this["calendartitle"]= value;}
	}
	public String calendartitleOriginal { 
		get {if (this["calendartitle",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["calendartitle",DataRowVersion.Original];}
	}
	///<summary>
	///Titolo alternativo per il Tab
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
	///Edit listing type da usare ler l'interfaccia figlia
	///</summary>
	public String editlistingtype{ 
		get {if (this["editlistingtype"]==DBNull.Value)return null; return  (String)this["editlistingtype"];}
		set {if (value==null) this["editlistingtype"]= DBNull.Value; else this["editlistingtype"]= value;}
	}
	public object editlistingtypeValue { 
		get{ return this["editlistingtype"];}
		set {if (value==null|| value==DBNull.Value) this["editlistingtype"]= DBNull.Value; else this["editlistingtype"]= value;}
	}
	public String editlistingtypeOriginal { 
		get {if (this["editlistingtype",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["editlistingtype",DataRowVersion.Original];}
	}
	///<summary>
	///Interfaccia figlia della relazione
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
	///Interfaccia madre della relazione
	///</summary>
	public Int32? idapppages_parent{ 
		get {if (this["idapppages_parent"]==DBNull.Value)return null; return  (Int32?)this["idapppages_parent"];}
		set {if (value==null) this["idapppages_parent"]= DBNull.Value; else this["idapppages_parent"]= value;}
	}
	public object idapppages_parentValue { 
		get{ return this["idapppages_parent"];}
		set {if (value==null|| value==DBNull.Value) this["idapppages_parent"]= DBNull.Value; else this["idapppages_parent"]= value;}
	}
	public Int32? idapppages_parentOriginal { 
		get {if (this["idapppages_parent",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idapppages_parent",DataRowVersion.Original];}
	}
	public Int32? idapprelation{ 
		get {if (this["idapprelation"]==DBNull.Value)return null; return  (Int32?)this["idapprelation"];}
		set {if (value==null) this["idapprelation"]= DBNull.Value; else this["idapprelation"]= value;}
	}
	public object idapprelationValue { 
		get{ return this["idapprelation"];}
		set {if (value==null|| value==DBNull.Value) this["idapprelation"]= DBNull.Value; else this["idapprelation"]= value;}
	}
	public Int32? idapprelationOriginal { 
		get {if (this["idapprelation",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idapprelation",DataRowVersion.Original];}
	}
	///<summary>
	///Tab in cui inserire la griglia
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
	///Numero di righe minimo per la validazione
	///</summary>
	public Int32? numrowsmandatory{ 
		get {if (this["numrowsmandatory"]==DBNull.Value)return null; return  (Int32?)this["numrowsmandatory"];}
		set {if (value==null) this["numrowsmandatory"]= DBNull.Value; else this["numrowsmandatory"]= value;}
	}
	public object numrowsmandatoryValue { 
		get{ return this["numrowsmandatory"];}
		set {if (value==null|| value==DBNull.Value) this["numrowsmandatory"]= DBNull.Value; else this["numrowsmandatory"]= value;}
	}
	public Int32? numrowsmandatoryOriginal { 
		get {if (this["numrowsmandatory",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["numrowsmandatory",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo di relazione (cerca, calendario, ecc.)
	///</summary>
	public String type{ 
		get {if (this["type"]==DBNull.Value)return null; return  (String)this["type"];}
		set {if (value==null) this["type"]= DBNull.Value; else this["type"]= value;}
	}
	public object typeValue { 
		get{ return this["type"];}
		set {if (value==null|| value==DBNull.Value) this["type"]= DBNull.Value; else this["type"]= value;}
	}
	public String typeOriginal { 
		get {if (this["type",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["type",DataRowVersion.Original];}
	}
	#endregion

}
public class apprelationTable : MetaTableBase<apprelationRow> {
	public apprelationTable() : base("apprelation"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"buttondelete",createColumn("buttondelete",typeof(string),true,false)},
			{"buttonedit",createColumn("buttonedit",typeof(string),true,false)},
			{"buttoninsert",createColumn("buttoninsert",typeof(string),true,false)},
			{"calendarstart",createColumn("calendarstart",typeof(string),true,false)},
			{"calendarstop",createColumn("calendarstop",typeof(string),true,false)},
			{"calendartitle",createColumn("calendartitle",typeof(string),true,false)},
			{"description",createColumn("description",typeof(string),true,false)},
			{"editlistingtype",createColumn("editlistingtype",typeof(string),true,false)},
			{"idapppages",createColumn("idapppages",typeof(int),false,false)},
			{"idapppages_parent",createColumn("idapppages_parent",typeof(int),true,false)},
			{"idapprelation",createColumn("idapprelation",typeof(int),false,false)},
			{"idapptab",createColumn("idapptab",typeof(int),true,false)},
			{"numrowsmandatory",createColumn("numrowsmandatory",typeof(int),true,false)},
			{"type",createColumn("type",typeof(string),true,false)},
		};
	}
}
}
