
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
namespace meta_instmprogettiregistry_instmuser {
public class instmprogettiregistry_instmuserRow: MetaRow  {
	public instmprogettiregistry_instmuserRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32? idinstmprogetti{ 
		get {if (this["idinstmprogetti"]==DBNull.Value)return null; return  (Int32?)this["idinstmprogetti"];}
		set {if (value==null) this["idinstmprogetti"]= DBNull.Value; else this["idinstmprogetti"]= value;}
	}
	public object idinstmprogettiValue { 
		get{ return this["idinstmprogetti"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmprogetti"]= DBNull.Value; else this["idinstmprogetti"]= value;}
	}
	public Int32? idinstmprogettiOriginal { 
		get {if (this["idinstmprogetti",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmprogetti",DataRowVersion.Original];}
	}
	public Int32? idreg_instmuser{ 
		get {if (this["idreg_instmuser"]==DBNull.Value)return null; return  (Int32?)this["idreg_instmuser"];}
		set {if (value==null) this["idreg_instmuser"]= DBNull.Value; else this["idreg_instmuser"]= value;}
	}
	public object idreg_instmuserValue { 
		get{ return this["idreg_instmuser"];}
		set {if (value==null|| value==DBNull.Value) this["idreg_instmuser"]= DBNull.Value; else this["idreg_instmuser"]= value;}
	}
	public Int32? idreg_instmuserOriginal { 
		get {if (this["idreg_instmuser",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg_instmuser",DataRowVersion.Original];}
	}
	#endregion

}
public class instmprogettiregistry_instmuserTable : MetaTableBase<instmprogettiregistry_instmuserRow> {
	public instmprogettiregistry_instmuserTable() : base("instmprogettiregistry_instmuser"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idinstmprogetti",createColumn("idinstmprogetti",typeof(int),false,false)},
			{"idreg_instmuser",createColumn("idreg_instmuser",typeof(int),false,false)},
		};
	}
}
}
