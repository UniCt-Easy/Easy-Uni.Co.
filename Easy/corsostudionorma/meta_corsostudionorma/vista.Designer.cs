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
namespace meta_corsostudionorma {
public class corsostudionormaRow: MetaRow  {
	public corsostudionormaRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///<summary>
	///Tipologia di corsi
	///</summary>
	public Int32? idistitutokind{ 
		get {if (this["idistitutokind"]==DBNull.Value)return null; return  (Int32?)this["idistitutokind"];}
		set {if (value==null) this["idistitutokind"]= DBNull.Value; else this["idistitutokind"]= value;}
	}
	public object idistitutokindValue { 
		get{ return this["idistitutokind"];}
		set {if (value==null|| value==DBNull.Value) this["idistitutokind"]= DBNull.Value; else this["idistitutokind"]= value;}
	}
	public Int32? idistitutokindOriginal { 
		get {if (this["idistitutokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idistitutokind",DataRowVersion.Original];}
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
///VOCABOLARIO delle normative dei 2.4.2 Corso di studio 
///</summary>
public class corsostudionormaTable : MetaTableBase<corsostudionormaRow> {
	public corsostudionormaTable() : base("corsostudionorma"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idcorsostudionorma",createColumn("idcorsostudionorma",typeof(int),false,false)},
			{"idistitutokind",createColumn("idistitutokind",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"title",createColumn("title",typeof(string),false,false)},
		};
	}
}
}
