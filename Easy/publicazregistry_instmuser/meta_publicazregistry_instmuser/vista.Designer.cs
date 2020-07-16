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
namespace meta_publicazregistry_instmuser {
public class publicazregistry_instmuserRow: MetaRow  {
	public publicazregistry_instmuserRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Anno
	///</summary>
	public Int32? annopub{ 
		get {if (this["annopub"]==DBNull.Value)return null; return  (Int32?)this["annopub"];}
		set {if (value==null) this["annopub"]= DBNull.Value; else this["annopub"]= value;}
	}
	public object annopubValue { 
		get{ return this["annopub"];}
		set {if (value==null|| value==DBNull.Value) this["annopub"]= DBNull.Value; else this["annopub"]= value;}
	}
	public Int32? annopubOriginal { 
		get {if (this["annopub",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["annopub",DataRowVersion.Original];}
	}
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
	///<summary>
	///Sezione tematica
	///</summary>
	public Int32? idinstmseztematichekind{ 
		get {if (this["idinstmseztematichekind"]==DBNull.Value)return null; return  (Int32?)this["idinstmseztematichekind"];}
		set {if (value==null) this["idinstmseztematichekind"]= DBNull.Value; else this["idinstmseztematichekind"]= value;}
	}
	public object idinstmseztematichekindValue { 
		get{ return this["idinstmseztematichekind"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmseztematichekind"]= DBNull.Value; else this["idinstmseztematichekind"]= value;}
	}
	public Int32? idinstmseztematichekindOriginal { 
		get {if (this["idinstmseztematichekind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmseztematichekind",DataRowVersion.Original];}
	}
	public Int32? idpublicazregistry_instmuser{ 
		get {if (this["idpublicazregistry_instmuser"]==DBNull.Value)return null; return  (Int32?)this["idpublicazregistry_instmuser"];}
		set {if (value==null) this["idpublicazregistry_instmuser"]= DBNull.Value; else this["idpublicazregistry_instmuser"]= value;}
	}
	public object idpublicazregistry_instmuserValue { 
		get{ return this["idpublicazregistry_instmuser"];}
		set {if (value==null|| value==DBNull.Value) this["idpublicazregistry_instmuser"]= DBNull.Value; else this["idpublicazregistry_instmuser"]= value;}
	}
	public Int32? idpublicazregistry_instmuserOriginal { 
		get {if (this["idpublicazregistry_instmuser",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpublicazregistry_instmuser",DataRowVersion.Original];}
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
	///Titolo
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
public class publicazregistry_instmuserTable : MetaTableBase<publicazregistry_instmuserRow> {
	public publicazregistry_instmuserTable() : base("publicazregistry_instmuser"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"annopub",createColumn("annopub",typeof(int),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idinstmseztematichekind",createColumn("idinstmseztematichekind",typeof(int),false,false)},
			{"idpublicazregistry_instmuser",createColumn("idpublicazregistry_instmuser",typeof(int),false,false)},
			{"idreg_instmuser",createColumn("idreg_instmuser",typeof(int),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"title",createColumn("title",typeof(string),false,false)},
		};
	}
}
}
