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
namespace meta_istitutokind {
public class istitutokindRow: MetaRow  {
	public istitutokindRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///Tipologia
	///</summary>
	public String tipoistituto{ 
		get {if (this["tipoistituto"]==DBNull.Value)return null; return  (String)this["tipoistituto"];}
		set {if (value==null) this["tipoistituto"]= DBNull.Value; else this["tipoistituto"]= value;}
	}
	public object tipoistitutoValue { 
		get{ return this["tipoistituto"];}
		set {if (value==null|| value==DBNull.Value) this["tipoistituto"]= DBNull.Value; else this["tipoistituto"]= value;}
	}
	public String tipoistitutoOriginal { 
		get {if (this["tipoistituto",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tipoistituto",DataRowVersion.Original];}
	}
	///<summary>
	///Tipologia (EN)
	///</summary>
	public String tipoistitutoen{ 
		get {if (this["tipoistitutoen"]==DBNull.Value)return null; return  (String)this["tipoistitutoen"];}
		set {if (value==null) this["tipoistitutoen"]= DBNull.Value; else this["tipoistitutoen"]= value;}
	}
	public object tipoistitutoenValue { 
		get{ return this["tipoistitutoen"];}
		set {if (value==null|| value==DBNull.Value) this["tipoistitutoen"]= DBNull.Value; else this["tipoistitutoen"]= value;}
	}
	public String tipoistitutoenOriginal { 
		get {if (this["tipoistitutoen",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tipoistitutoen",DataRowVersion.Original];}
	}
	///<summary>
	///Sigla
	///</summary>
	public String tipoistitutosigla{ 
		get {if (this["tipoistitutosigla"]==DBNull.Value)return null; return  (String)this["tipoistitutosigla"];}
		set {if (value==null) this["tipoistitutosigla"]= DBNull.Value; else this["tipoistitutosigla"]= value;}
	}
	public object tipoistitutosiglaValue { 
		get{ return this["tipoistitutosigla"];}
		set {if (value==null|| value==DBNull.Value) this["tipoistitutosigla"]= DBNull.Value; else this["tipoistitutosigla"]= value;}
	}
	public String tipoistitutosiglaOriginal { 
		get {if (this["tipoistitutosigla",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tipoistitutosigla",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///VOCABOLARIO MIUR delle tipologie degli istituti di istruzione
///</summary>
public class istitutokindTable : MetaTableBase<istitutokindRow> {
	public istitutokindTable() : base("istitutokind"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idistitutokind",createColumn("idistitutokind",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"tipoistituto",createColumn("tipoistituto",typeof(string),false,false)},
			{"tipoistitutoen",createColumn("tipoistitutoen",typeof(string),false,false)},
			{"tipoistitutosigla",createColumn("tipoistitutosigla",typeof(string),false,false)},
		};
	}
}
}
