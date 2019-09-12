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
using metadatalibrary;
#pragma warning disable 1591
namespace meta_customindirectrelcol {
public class customindirectrelcolRow: MetaRow  {
	public customindirectrelcolRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///ID Relazione indiretta tra tabelle (tabella customindirectrel)
	///</summary>
	public Int32? idcustomindirectrel{ 
		get {if (this["idcustomindirectrel"]==DBNull.Value)return null; return  (Int32?)this["idcustomindirectrel"];}
		set {if (value==null) this["idcustomindirectrel"]= DBNull.Value; else this["idcustomindirectrel"]= value;}
	}
	public object idcustomindirectrelValue { 
		get{ return this["idcustomindirectrel"];}
		set {if (value==null|| value==DBNull.Value) this["idcustomindirectrel"]= DBNull.Value; else this["idcustomindirectrel"]= value;}
	}
	public Int32? idcustomindirectrelOriginal { 
		get {if (this["idcustomindirectrel",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcustomindirectrel",DataRowVersion.Original];}
	}
	///<summary>
	///nome campo tabella parent
	///</summary>
	public String parentfield{ 
		get {if (this["parentfield"]==DBNull.Value)return null; return  (String)this["parentfield"];}
		set {if (value==null) this["parentfield"]= DBNull.Value; else this["parentfield"]= value;}
	}
	public object parentfieldValue { 
		get{ return this["parentfield"];}
		set {if (value==null|| value==DBNull.Value) this["parentfield"]= DBNull.Value; else this["parentfield"]= value;}
	}
	public String parentfieldOriginal { 
		get {if (this["parentfield",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["parentfield",DataRowVersion.Original];}
	}
	///<summary>
	///numero tabella parent (1 o 2)
	///</summary>
	public Int32? parentnumber{ 
		get {if (this["parentnumber"]==DBNull.Value)return null; return  (Int32?)this["parentnumber"];}
		set {if (value==null) this["parentnumber"]= DBNull.Value; else this["parentnumber"]= value;}
	}
	public object parentnumberValue { 
		get{ return this["parentnumber"];}
		set {if (value==null|| value==DBNull.Value) this["parentnumber"]= DBNull.Value; else this["parentnumber"]= value;}
	}
	public Int32? parentnumberOriginal { 
		get {if (this["parentnumber",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["parentnumber",DataRowVersion.Original];}
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
	///<summary>
	///nome campo tabella di mezzo
	///</summary>
	public String middlefield{ 
		get {if (this["middlefield"]==DBNull.Value)return null; return  (String)this["middlefield"];}
		set {if (value==null) this["middlefield"]= DBNull.Value; else this["middlefield"]= value;}
	}
	public object middlefieldValue { 
		get{ return this["middlefield"];}
		set {if (value==null|| value==DBNull.Value) this["middlefield"]= DBNull.Value; else this["middlefield"]= value;}
	}
	public String middlefieldOriginal { 
		get {if (this["middlefield",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["middlefield",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///colonne di Relazione di navigazione indiretta
///</summary>
public class customindirectrelcolTable : MetaTableBase<customindirectrelcolRow> {
	public customindirectrelcolTable() : base("customindirectrelcol"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idcustomindirectrel",createColumn("idcustomindirectrel",typeof(Int32),false,false)},
			{"parentfield",createColumn("parentfield",typeof(String),false,false)},
			{"parentnumber",createColumn("parentnumber",typeof(Int32),false,false)},
			{"lastmodtimestamp",createColumn("lastmodtimestamp",typeof(DateTime),true,false)},
			{"lastmoduser",createColumn("lastmoduser",typeof(String),true,false)},
			{"middlefield",createColumn("middlefield",typeof(String),false,false)},
		};
	}
}
}
