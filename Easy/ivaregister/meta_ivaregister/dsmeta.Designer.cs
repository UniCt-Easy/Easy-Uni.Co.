
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
namespace meta_ivaregister {
public class ivaregisterRow: MetaRow  {
	public ivaregisterRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Numero reg.
	///</summary>
	public Int32? nivaregister{ 
		get {if (this["nivaregister"]==DBNull.Value)return null; return  (Int32?)this["nivaregister"];}
		set {if (value==null) this["nivaregister"]= DBNull.Value; else this["nivaregister"]= value;}
	}
	public object nivaregisterValue { 
		get{ return this["nivaregister"];}
		set {if (value==null|| value==DBNull.Value) this["nivaregister"]= DBNull.Value; else this["nivaregister"]= value;}
	}
	public Int32? nivaregisterOriginal { 
		get {if (this["nivaregister",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nivaregister",DataRowVersion.Original];}
	}
	///<summary>
	///Eserc. reg.
	///</summary>
	public Int16? yivaregister{ 
		get {if (this["yivaregister"]==DBNull.Value)return null; return  (Int16?)this["yivaregister"];}
		set {if (value==null) this["yivaregister"]= DBNull.Value; else this["yivaregister"]= value;}
	}
	public object yivaregisterValue { 
		get{ return this["yivaregister"];}
		set {if (value==null|| value==DBNull.Value) this["yivaregister"]= DBNull.Value; else this["yivaregister"]= value;}
	}
	public Int16? yivaregisterOriginal { 
		get {if (this["yivaregister",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yivaregister",DataRowVersion.Original];}
	}
	///<summary>
	///data creazione
	///</summary>
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
	///<summary>
	///nome utente creazione
	///</summary>
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
	///data ultima modifica
	///</summary>
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
	///<summary>
	///nome ultimo utente modifica
	///</summary>
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
	///n.fattura
	///</summary>
	public Int32? ninv{ 
		get {if (this["ninv"]==DBNull.Value)return null; return  (Int32?)this["ninv"];}
		set {if (value==null) this["ninv"]= DBNull.Value; else this["ninv"]= value;}
	}
	public object ninvValue { 
		get{ return this["ninv"];}
		set {if (value==null|| value==DBNull.Value) this["ninv"]= DBNull.Value; else this["ninv"]= value;}
	}
	public Int32? ninvOriginal { 
		get {if (this["ninv",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ninv",DataRowVersion.Original];}
	}
	///<summary>
	///Numero prot.
	///</summary>
	public Int32? protocolnum{ 
		get {if (this["protocolnum"]==DBNull.Value)return null; return  (Int32?)this["protocolnum"];}
		set {if (value==null) this["protocolnum"]= DBNull.Value; else this["protocolnum"]= value;}
	}
	public object protocolnumValue { 
		get{ return this["protocolnum"];}
		set {if (value==null|| value==DBNull.Value) this["protocolnum"]= DBNull.Value; else this["protocolnum"]= value;}
	}
	public Int32? protocolnumOriginal { 
		get {if (this["protocolnum",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["protocolnum",DataRowVersion.Original];}
	}
	///<summary>
	///anno fattura
	///</summary>
	public Int16? yinv{ 
		get {if (this["yinv"]==DBNull.Value)return null; return  (Int16?)this["yinv"];}
		set {if (value==null) this["yinv"]= DBNull.Value; else this["yinv"]= value;}
	}
	public object yinvValue { 
		get{ return this["yinv"];}
		set {if (value==null|| value==DBNull.Value) this["yinv"]= DBNull.Value; else this["yinv"]= value;}
	}
	public Int16? yinvOriginal { 
		get {if (this["yinv",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yinv",DataRowVersion.Original];}
	}
	///<summary>
	///id tipo documento (tabella invoicekind)
	///</summary>
	public Int32? idinvkind{ 
		get {if (this["idinvkind"]==DBNull.Value)return null; return  (Int32?)this["idinvkind"];}
		set {if (value==null) this["idinvkind"]= DBNull.Value; else this["idinvkind"]= value;}
	}
	public object idinvkindValue { 
		get{ return this["idinvkind"];}
		set {if (value==null|| value==DBNull.Value) this["idinvkind"]= DBNull.Value; else this["idinvkind"]= value;}
	}
	public Int32? idinvkindOriginal { 
		get {if (this["idinvkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinvkind",DataRowVersion.Original];}
	}
	///<summary>
	///id tipo registro iva (tabella ivaregisterkind) 
	///</summary>
	public Int32? idivaregisterkind{ 
		get {if (this["idivaregisterkind"]==DBNull.Value)return null; return  (Int32?)this["idivaregisterkind"];}
		set {if (value==null) this["idivaregisterkind"]= DBNull.Value; else this["idivaregisterkind"]= value;}
	}
	public object idivaregisterkindValue { 
		get{ return this["idivaregisterkind"];}
		set {if (value==null|| value==DBNull.Value) this["idivaregisterkind"]= DBNull.Value; else this["idivaregisterkind"]= value;}
	}
	public Int32? idivaregisterkindOriginal { 
		get {if (this["idivaregisterkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idivaregisterkind",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Registro iva
///</summary>
public class ivaregisterTable : MetaTableBase<ivaregisterRow> {
	public ivaregisterTable() : base("ivaregister"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nivaregister",createColumn("nivaregister",typeof(Int32),false,false)},
			{"yivaregister",createColumn("yivaregister",typeof(Int16),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(String),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(String),false,false)},
			{"ninv",createColumn("ninv",typeof(Int32),false,false)},
			{"protocolnum",createColumn("protocolnum",typeof(Int32),true,false)},
			{"yinv",createColumn("yinv",typeof(Int16),false,false)},
			{"idinvkind",createColumn("idinvkind",typeof(Int32),false,false)},
			{"idivaregisterkind",createColumn("idivaregisterkind",typeof(Int32),false,false)},
		};
	}
}
}
