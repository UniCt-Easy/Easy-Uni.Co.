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
namespace meta_instmkwsettoreindustriale {
public class instmkwsettoreindustrialeRow: MetaRow  {
	public instmkwsettoreindustrialeRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	public Int32? idinstmkwsettoreindustriale{ 
		get {if (this["idinstmkwsettoreindustriale"]==DBNull.Value)return null; return  (Int32?)this["idinstmkwsettoreindustriale"];}
		set {if (value==null) this["idinstmkwsettoreindustriale"]= DBNull.Value; else this["idinstmkwsettoreindustriale"]= value;}
	}
	public object idinstmkwsettoreindustrialeValue { 
		get{ return this["idinstmkwsettoreindustriale"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmkwsettoreindustriale"]= DBNull.Value; else this["idinstmkwsettoreindustriale"]= value;}
	}
	public Int32? idinstmkwsettoreindustrialeOriginal { 
		get {if (this["idinstmkwsettoreindustriale",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmkwsettoreindustriale",DataRowVersion.Original];}
	}
	///<summary>
	///Keyword
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
public class instmkwsettoreindustrialeTable : MetaTableBase<instmkwsettoreindustrialeRow> {
	public instmkwsettoreindustrialeTable() : base("instmkwsettoreindustriale"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idinstmkwsettoreindustriale",createColumn("idinstmkwsettoreindustriale",typeof(int),false,false)},
			{"title",createColumn("title",typeof(string),false,false)},
		};
	}
}
}