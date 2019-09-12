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
namespace meta_caratteristicaora {
public class caratteristicaoraRow: MetaRow  {
	public caratteristicaoraRow(DataRowBuilder rb) : base(rb) {} 

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
	public Int32? idattivformcaratteristica{ 
		get {if (this["idattivformcaratteristica"]==DBNull.Value)return null; return  (Int32?)this["idattivformcaratteristica"];}
		set {if (value==null) this["idattivformcaratteristica"]= DBNull.Value; else this["idattivformcaratteristica"]= value;}
	}
	public object idattivformcaratteristicaValue { 
		get{ return this["idattivformcaratteristica"];}
		set {if (value==null|| value==DBNull.Value) this["idattivformcaratteristica"]= DBNull.Value; else this["idattivformcaratteristica"]= value;}
	}
	public Int32? idattivformcaratteristicaOriginal { 
		get {if (this["idattivformcaratteristica",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idattivformcaratteristica",DataRowVersion.Original];}
	}
	public Int32? idcaratteristicaora{ 
		get {if (this["idcaratteristicaora"]==DBNull.Value)return null; return  (Int32?)this["idcaratteristicaora"];}
		set {if (value==null) this["idcaratteristicaora"]= DBNull.Value; else this["idcaratteristicaora"]= value;}
	}
	public object idcaratteristicaoraValue { 
		get{ return this["idcaratteristicaora"];}
		set {if (value==null|| value==DBNull.Value) this["idcaratteristicaora"]= DBNull.Value; else this["idcaratteristicaora"]= value;}
	}
	public Int32? idcaratteristicaoraOriginal { 
		get {if (this["idcaratteristicaora",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcaratteristicaora",DataRowVersion.Original];}
	}
	public Int32? idorakind{ 
		get {if (this["idorakind"]==DBNull.Value)return null; return  (Int32?)this["idorakind"];}
		set {if (value==null) this["idorakind"]= DBNull.Value; else this["idorakind"]= value;}
	}
	public object idorakindValue { 
		get{ return this["idorakind"];}
		set {if (value==null|| value==DBNull.Value) this["idorakind"]= DBNull.Value; else this["idorakind"]= value;}
	}
	public Int32? idorakindOriginal { 
		get {if (this["idorakind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idorakind",DataRowVersion.Original];}
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
	public Int32? ora{ 
		get {if (this["ora"]==DBNull.Value)return null; return  (Int32?)this["ora"];}
		set {if (value==null) this["ora"]= DBNull.Value; else this["ora"]= value;}
	}
	public object oraValue { 
		get{ return this["ora"];}
		set {if (value==null|| value==DBNull.Value) this["ora"]= DBNull.Value; else this["ora"]= value;}
	}
	public Int32? oraOriginal { 
		get {if (this["ora",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ora",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Numero e tipo di ore di una 2.4.9 Caratteristica
///</summary>
public class caratteristicaoraTable : MetaTableBase<caratteristicaoraRow> {
	public caratteristicaoraTable() : base("caratteristicaora"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idattivformcaratteristica",createColumn("idattivformcaratteristica",typeof(int),false,false)},
			{"idcaratteristicaora",createColumn("idcaratteristicaora",typeof(int),false,false)},
			{"idorakind",createColumn("idorakind",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"ora",createColumn("ora",typeof(int),true,false)},
		};
	}
}
}
