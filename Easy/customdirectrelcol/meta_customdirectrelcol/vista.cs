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
using metadatalibrary;
#pragma warning disable 1591
namespace meta_customdirectrelcol {
public class customdirectrelcolRow: MetaRow  {
	public customdirectrelcolRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///campo tabella origine relazione
	///</summary>
	public String fromfield{ 
		get {if (this["fromfield"]==DBNull.Value)return null; return  (String)this["fromfield"];}
		set {if (value==null) this["fromfield"]= DBNull.Value; else this["fromfield"]= value;}
	}
	public object fromfieldValue { 
		get{ return this["fromfield"];}
		set {if (value==null|| value==DBNull.Value) this["fromfield"]= DBNull.Value; else this["fromfield"]= value;}
	}
	public String fromfieldOriginal { 
		get {if (this["fromfield",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["fromfield",DataRowVersion.Original];}
	}
	///<summary>
	///ID Relazione diretta tra tabelle (tabella customdirectrel)
	///</summary>
	public Int32? idcustomdirectrel{ 
		get {if (this["idcustomdirectrel"]==DBNull.Value)return null; return  (Int32?)this["idcustomdirectrel"];}
		set {if (value==null) this["idcustomdirectrel"]= DBNull.Value; else this["idcustomdirectrel"]= value;}
	}
	public object idcustomdirectrelValue { 
		get{ return this["idcustomdirectrel"];}
		set {if (value==null|| value==DBNull.Value) this["idcustomdirectrel"]= DBNull.Value; else this["idcustomdirectrel"]= value;}
	}
	public Int32? idcustomdirectrelOriginal { 
		get {if (this["idcustomdirectrel",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcustomdirectrel",DataRowVersion.Original];}
	}
	///<summary>
	///campo tabella destinazione relazione
	///</summary>
	public String tofield{ 
		get {if (this["tofield"]==DBNull.Value)return null; return  (String)this["tofield"];}
		set {if (value==null) this["tofield"]= DBNull.Value; else this["tofield"]= value;}
	}
	public object tofieldValue { 
		get{ return this["tofield"];}
		set {if (value==null|| value==DBNull.Value) this["tofield"]= DBNull.Value; else this["tofield"]= value;}
	}
	public String tofieldOriginal { 
		get {if (this["tofield",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tofield",DataRowVersion.Original];}
	}
	///<summary>
	///data ultima modifica
	///</summary>
	public DateTime? lastmodtimestamp{ 
		get {if (this["lastmodtimestamp"]==DBNull.Value)return null; return  (DateTime?)this["lastmodtimestamp"];}
		set {if (value==null) this["lastmodtimestamp"]= DBNull.Value; else this["lastmodtimestamp"]= value;}
	}
	public object lastmodtimestampValue { 
		get{ return this["lastmodtimestamp"];}
		set {if (value==null|| value==DBNull.Value) this["lastmodtimestamp"]= DBNull.Value; else this["lastmodtimestamp"]= value;}
	}
	public DateTime? lastmodtimestampOriginal { 
		get {if (this["lastmodtimestamp",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["lastmodtimestamp",DataRowVersion.Original];}
	}
	///<summary>
	///Utente ultima modifica
	///</summary>
	public String lastmoduser{ 
		get {if (this["lastmoduser"]==DBNull.Value)return null; return  (String)this["lastmoduser"];}
		set {if (value==null) this["lastmoduser"]= DBNull.Value; else this["lastmoduser"]= value;}
	}
	public object lastmoduserValue { 
		get{ return this["lastmoduser"];}
		set {if (value==null|| value==DBNull.Value) this["lastmoduser"]= DBNull.Value; else this["lastmoduser"]= value;}
	}
	public String lastmoduserOriginal { 
		get {if (this["lastmoduser",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lastmoduser",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Colonne di relazione diretta
///</summary>
public class customdirectrelcolTable : MetaTableBase<customdirectrelcolRow> {
	public customdirectrelcolTable() : base("customdirectrelcol"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"fromfield",createColumn("fromfield",typeof(String),false,false)},
			{"idcustomdirectrel",createColumn("idcustomdirectrel",typeof(Int32),false,false)},
			{"tofield",createColumn("tofield",typeof(String),false,false)},
			{"lastmodtimestamp",createColumn("lastmodtimestamp",typeof(DateTime),true,false)},
			{"lastmoduser",createColumn("lastmoduser",typeof(String),true,false)},
		};
	}
}
}
