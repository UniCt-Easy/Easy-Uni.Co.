
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
namespace meta_assetacquire {
public class assetacquireRow: MetaRow  {
	public assetacquireRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 nassetacquire{ 
		get {return  (Int32)this["nassetacquire"];}
		set {this["nassetacquire"]= value;}
	}
	public object nassetacquireValue { 
		get{ return this["nassetacquire"];}
		set {this["nassetacquire"]= value;}
	}
	public Int32 nassetacquireOriginal { 
		get {return  (Int32)this["nassetacquire",DataRowVersion.Original];}
	}
	public Decimal? abatable{ 
		get {if (this["abatable"]==DBNull.Value)return null; return  (Decimal?)this["abatable"];}
		set {if (value==null) this["abatable"]= DBNull.Value; else this["abatable"]= value;}
	}
	public object abatableValue { 
		get{ return this["abatable"];}
		set {if (value==null|| value==DBNull.Value) this["abatable"]= DBNull.Value; else this["abatable"]= value;}
	}
	public Decimal? abatableOriginal { 
		get {if (this["abatable",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["abatable",DataRowVersion.Original];}
	}
	public DateTime adate{ 
		get {return  (DateTime)this["adate"];}
		set {this["adate"]= value;}
	}
	public object adateValue { 
		get{ return this["adate"];}
		set {this["adate"]= value;}
	}
	public DateTime adateOriginal { 
		get {return  (DateTime)this["adate",DataRowVersion.Original];}
	}
	public DateTime ct{ 
		get {return  (DateTime)this["ct"];}
		set {this["ct"]= value;}
	}
	public object ctValue { 
		get{ return this["ct"];}
		set {this["ct"]= value;}
	}
	public DateTime ctOriginal { 
		get {return  (DateTime)this["ct",DataRowVersion.Original];}
	}
	public String cu{ 
		get {return  (String)this["cu"];}
		set {this["cu"]= value;}
	}
	public object cuValue { 
		get{ return this["cu"];}
		set {this["cu"]= value;}
	}
	public String cuOriginal { 
		get {return  (String)this["cu",DataRowVersion.Original];}
	}
	public String description{ 
		get {return  (String)this["description"];}
		set {this["description"]= value;}
	}
	public object descriptionValue { 
		get{ return this["description"];}
		set {this["description"]= value;}
	}
	public String descriptionOriginal { 
		get {return  (String)this["description",DataRowVersion.Original];}
	}
	public Double? discount{ 
		get {if (this["discount"]==DBNull.Value)return null; return  (Double?)this["discount"];}
		set {if (value==null) this["discount"]= DBNull.Value; else this["discount"]= value;}
	}
	public object discountValue { 
		get{ return this["discount"];}
		set {if (value==null|| value==DBNull.Value) this["discount"]= DBNull.Value; else this["discount"]= value;}
	}
	public Double? discountOriginal { 
		get {if (this["discount",DataRowVersion.Original]==DBNull.Value)return null; return  (Double?)this["discount",DataRowVersion.Original];}
	}
	public String idmankind{ 
		get {if (this["idmankind"]==DBNull.Value)return null; return  (String)this["idmankind"];}
		set {if (value==null) this["idmankind"]= DBNull.Value; else this["idmankind"]= value;}
	}
	public object idmankindValue { 
		get{ return this["idmankind"];}
		set {if (value==null|| value==DBNull.Value) this["idmankind"]= DBNull.Value; else this["idmankind"]= value;}
	}
	public String idmankindOriginal { 
		get {if (this["idmankind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idmankind",DataRowVersion.Original];}
	}
	public Int32? idreg{ 
		get {if (this["idreg"]==DBNull.Value)return null; return  (Int32?)this["idreg"];}
		set {if (value==null) this["idreg"]= DBNull.Value; else this["idreg"]= value;}
	}
	public object idregValue { 
		get{ return this["idreg"];}
		set {if (value==null|| value==DBNull.Value) this["idreg"]= DBNull.Value; else this["idreg"]= value;}
	}
	public Int32? idregOriginal { 
		get {if (this["idreg",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg",DataRowVersion.Original];}
	}
	public DateTime lt{ 
		get {return  (DateTime)this["lt"];}
		set {this["lt"]= value;}
	}
	public object ltValue { 
		get{ return this["lt"];}
		set {this["lt"]= value;}
	}
	public DateTime ltOriginal { 
		get {return  (DateTime)this["lt",DataRowVersion.Original];}
	}
	public String lu{ 
		get {return  (String)this["lu"];}
		set {this["lu"]= value;}
	}
	public object luValue { 
		get{ return this["lu"];}
		set {this["lu"]= value;}
	}
	public String luOriginal { 
		get {return  (String)this["lu",DataRowVersion.Original];}
	}
	public Int32? nman{ 
		get {if (this["nman"]==DBNull.Value)return null; return  (Int32?)this["nman"];}
		set {if (value==null) this["nman"]= DBNull.Value; else this["nman"]= value;}
	}
	public object nmanValue { 
		get{ return this["nman"];}
		set {if (value==null|| value==DBNull.Value) this["nman"]= DBNull.Value; else this["nman"]= value;}
	}
	public Int32? nmanOriginal { 
		get {if (this["nman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nman",DataRowVersion.Original];}
	}
	public Int32 number{ 
		get {return  (Int32)this["number"];}
		set {this["number"]= value;}
	}
	public object numberValue { 
		get{ return this["number"];}
		set {this["number"]= value;}
	}
	public Int32 numberOriginal { 
		get {return  (Int32)this["number",DataRowVersion.Original];}
	}
	public Int32? rownum{ 
		get {if (this["rownum"]==DBNull.Value)return null; return  (Int32?)this["rownum"];}
		set {if (value==null) this["rownum"]= DBNull.Value; else this["rownum"]= value;}
	}
	public object rownumValue { 
		get{ return this["rownum"];}
		set {if (value==null|| value==DBNull.Value) this["rownum"]= DBNull.Value; else this["rownum"]= value;}
	}
	public Int32? rownumOriginal { 
		get {if (this["rownum",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["rownum",DataRowVersion.Original];}
	}
	public Byte[] rtf{ 
		get {if (this["rtf"]==DBNull.Value)return null; return  (Byte[])this["rtf"];}
		set {if (value==null) this["rtf"]= DBNull.Value; else this["rtf"]= value;}
	}
	public object rtfValue { 
		get{ return this["rtf"];}
		set {if (value==null|| value==DBNull.Value) this["rtf"]= DBNull.Value; else this["rtf"]= value;}
	}
	public Byte[] rtfOriginal { 
		get {if (this["rtf",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte[])this["rtf",DataRowVersion.Original];}
	}
	public Int32? startnumber{ 
		get {if (this["startnumber"]==DBNull.Value)return null; return  (Int32?)this["startnumber"];}
		set {if (value==null) this["startnumber"]= DBNull.Value; else this["startnumber"]= value;}
	}
	public object startnumberValue { 
		get{ return this["startnumber"];}
		set {if (value==null|| value==DBNull.Value) this["startnumber"]= DBNull.Value; else this["startnumber"]= value;}
	}
	public Int32? startnumberOriginal { 
		get {if (this["startnumber",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["startnumber",DataRowVersion.Original];}
	}
	public Decimal? tax{ 
		get {if (this["tax"]==DBNull.Value)return null; return  (Decimal?)this["tax"];}
		set {if (value==null) this["tax"]= DBNull.Value; else this["tax"]= value;}
	}
	public object taxValue { 
		get{ return this["tax"];}
		set {if (value==null|| value==DBNull.Value) this["tax"]= DBNull.Value; else this["tax"]= value;}
	}
	public Decimal? taxOriginal { 
		get {if (this["tax",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["tax",DataRowVersion.Original];}
	}
	public Decimal? taxable{ 
		get {if (this["taxable"]==DBNull.Value)return null; return  (Decimal?)this["taxable"];}
		set {if (value==null) this["taxable"]= DBNull.Value; else this["taxable"]= value;}
	}
	public object taxableValue { 
		get{ return this["taxable"];}
		set {if (value==null|| value==DBNull.Value) this["taxable"]= DBNull.Value; else this["taxable"]= value;}
	}
	public Decimal? taxableOriginal { 
		get {if (this["taxable",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["taxable",DataRowVersion.Original];}
	}
	public Double? taxrate{ 
		get {if (this["taxrate"]==DBNull.Value)return null; return  (Double?)this["taxrate"];}
		set {if (value==null) this["taxrate"]= DBNull.Value; else this["taxrate"]= value;}
	}
	public object taxrateValue { 
		get{ return this["taxrate"];}
		set {if (value==null|| value==DBNull.Value) this["taxrate"]= DBNull.Value; else this["taxrate"]= value;}
	}
	public Double? taxrateOriginal { 
		get {if (this["taxrate",DataRowVersion.Original]==DBNull.Value)return null; return  (Double?)this["taxrate",DataRowVersion.Original];}
	}
	public String txt{ 
		get {if (this["txt"]==DBNull.Value)return null; return  (String)this["txt"];}
		set {if (value==null) this["txt"]= DBNull.Value; else this["txt"]= value;}
	}
	public object txtValue { 
		get{ return this["txt"];}
		set {if (value==null|| value==DBNull.Value) this["txt"]= DBNull.Value; else this["txt"]= value;}
	}
	public String txtOriginal { 
		get {if (this["txt",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["txt",DataRowVersion.Original];}
	}
	public Int16? yman{ 
		get {if (this["yman"]==DBNull.Value)return null; return  (Int16?)this["yman"];}
		set {if (value==null) this["yman"]= DBNull.Value; else this["yman"]= value;}
	}
	public object ymanValue { 
		get{ return this["yman"];}
		set {if (value==null|| value==DBNull.Value) this["yman"]= DBNull.Value; else this["yman"]= value;}
	}
	public Int16? ymanOriginal { 
		get {if (this["yman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yman",DataRowVersion.Original];}
	}
	public String transmitted{ 
		get {if (this["transmitted"]==DBNull.Value)return null; return  (String)this["transmitted"];}
		set {if (value==null) this["transmitted"]= DBNull.Value; else this["transmitted"]= value;}
	}
	public object transmittedValue { 
		get{ return this["transmitted"];}
		set {if (value==null|| value==DBNull.Value) this["transmitted"]= DBNull.Value; else this["transmitted"]= value;}
	}
	public String transmittedOriginal { 
		get {if (this["transmitted",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["transmitted",DataRowVersion.Original];}
	}
	public String idupb{ 
		get {if (this["idupb"]==DBNull.Value)return null; return  (String)this["idupb"];}
		set {if (value==null) this["idupb"]= DBNull.Value; else this["idupb"]= value;}
	}
	public object idupbValue { 
		get{ return this["idupb"];}
		set {if (value==null|| value==DBNull.Value) this["idupb"]= DBNull.Value; else this["idupb"]= value;}
	}
	public String idupbOriginal { 
		get {if (this["idupb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idupb",DataRowVersion.Original];}
	}
	public Int32 idinventory{ 
		get {return  (Int32)this["idinventory"];}
		set {this["idinventory"]= value;}
	}
	public object idinventoryValue { 
		get{ return this["idinventory"];}
		set {this["idinventory"]= value;}
	}
	public Int32 idinventoryOriginal { 
		get {return  (Int32)this["idinventory",DataRowVersion.Original];}
	}
	public Int32 idmot{ 
		get {return  (Int32)this["idmot"];}
		set {this["idmot"]= value;}
	}
	public object idmotValue { 
		get{ return this["idmot"];}
		set {this["idmot"]= value;}
	}
	public Int32 idmotOriginal { 
		get {return  (Int32)this["idmot",DataRowVersion.Original];}
	}
	public Int32 idinv{ 
		get {return  (Int32)this["idinv"];}
		set {this["idinv"]= value;}
	}
	public object idinvValue { 
		get{ return this["idinv"];}
		set {this["idinv"]= value;}
	}
	public Int32 idinvOriginal { 
		get {return  (Int32)this["idinv",DataRowVersion.Original];}
	}
	public Int32? idassetload{ 
		get {if (this["idassetload"]==DBNull.Value)return null; return  (Int32?)this["idassetload"];}
		set {if (value==null) this["idassetload"]= DBNull.Value; else this["idassetload"]= value;}
	}
	public object idassetloadValue { 
		get{ return this["idassetload"];}
		set {if (value==null|| value==DBNull.Value) this["idassetload"]= DBNull.Value; else this["idassetload"]= value;}
	}
	public Int32? idassetloadOriginal { 
		get {if (this["idassetload",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idassetload",DataRowVersion.Original];}
	}
	public Byte flag{ 
		get {return  (Byte)this["flag"];}
		set {this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {this["flag"]= value;}
	}
	public Byte flagOriginal { 
		get {return  (Byte)this["flag",DataRowVersion.Original];}
	}
	public Int32? idsor1{ 
		get {if (this["idsor1"]==DBNull.Value)return null; return  (Int32?)this["idsor1"];}
		set {if (value==null) this["idsor1"]= DBNull.Value; else this["idsor1"]= value;}
	}
	public object idsor1Value { 
		get{ return this["idsor1"];}
		set {if (value==null|| value==DBNull.Value) this["idsor1"]= DBNull.Value; else this["idsor1"]= value;}
	}
	public Int32? idsor1Original { 
		get {if (this["idsor1",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor1",DataRowVersion.Original];}
	}
	public Int32? idsor2{ 
		get {if (this["idsor2"]==DBNull.Value)return null; return  (Int32?)this["idsor2"];}
		set {if (value==null) this["idsor2"]= DBNull.Value; else this["idsor2"]= value;}
	}
	public object idsor2Value { 
		get{ return this["idsor2"];}
		set {if (value==null|| value==DBNull.Value) this["idsor2"]= DBNull.Value; else this["idsor2"]= value;}
	}
	public Int32? idsor2Original { 
		get {if (this["idsor2",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor2",DataRowVersion.Original];}
	}
	public Int32? idsor3{ 
		get {if (this["idsor3"]==DBNull.Value)return null; return  (Int32?)this["idsor3"];}
		set {if (value==null) this["idsor3"]= DBNull.Value; else this["idsor3"]= value;}
	}
	public object idsor3Value { 
		get{ return this["idsor3"];}
		set {if (value==null|| value==DBNull.Value) this["idsor3"]= DBNull.Value; else this["idsor3"]= value;}
	}
	public Int32? idsor3Original { 
		get {if (this["idsor3",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor3",DataRowVersion.Original];}
	}
	public Decimal? historicalvalue{ 
		get {if (this["historicalvalue"]==DBNull.Value)return null; return  (Decimal?)this["historicalvalue"];}
		set {if (value==null) this["historicalvalue"]= DBNull.Value; else this["historicalvalue"]= value;}
	}
	public object historicalvalueValue { 
		get{ return this["historicalvalue"];}
		set {if (value==null|| value==DBNull.Value) this["historicalvalue"]= DBNull.Value; else this["historicalvalue"]= value;}
	}
	public Decimal? historicalvalueOriginal { 
		get {if (this["historicalvalue",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["historicalvalue",DataRowVersion.Original];}
	}
	public Int32? idlist{ 
		get {if (this["idlist"]==DBNull.Value)return null; return  (Int32?)this["idlist"];}
		set {if (value==null) this["idlist"]= DBNull.Value; else this["idlist"]= value;}
	}
	public object idlistValue { 
		get{ return this["idlist"];}
		set {if (value==null|| value==DBNull.Value) this["idlist"]= DBNull.Value; else this["idlist"]= value;}
	}
	public Int32? idlistOriginal { 
		get {if (this["idlist",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idlist",DataRowVersion.Original];}
	}
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
	public Int32? invrownum{ 
		get {if (this["invrownum"]==DBNull.Value)return null; return  (Int32?)this["invrownum"];}
		set {if (value==null) this["invrownum"]= DBNull.Value; else this["invrownum"]= value;}
	}
	public object invrownumValue { 
		get{ return this["invrownum"];}
		set {if (value==null|| value==DBNull.Value) this["invrownum"]= DBNull.Value; else this["invrownum"]= value;}
	}
	public Int32? invrownumOriginal { 
		get {if (this["invrownum",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["invrownum",DataRowVersion.Original];}
	}
	public Int32? idcostpartition{ 
		get {if (this["idcostpartition"]==DBNull.Value)return null; return  (Int32?)this["idcostpartition"];}
		set {if (value==null) this["idcostpartition"]= DBNull.Value; else this["idcostpartition"]= value;}
	}
	public object idcostpartitionValue { 
		get{ return this["idcostpartition"];}
		set {if (value==null|| value==DBNull.Value) this["idcostpartition"]= DBNull.Value; else this["idcostpartition"]= value;}
	}
	public Int32? idcostpartitionOriginal { 
		get {if (this["idcostpartition",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcostpartition",DataRowVersion.Original];}
	}
	#endregion

}
public class assetacquireTable : MetaTableBase<assetacquireRow> {
	public assetacquireTable() : base("assetacquire"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nassetacquire",createColumn("nassetacquire",typeof(int),false,false)},
			{"abatable",createColumn("abatable",typeof(decimal),true,false)},
			{"adate",createColumn("adate",typeof(DateTime),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"discount",createColumn("discount",typeof(double),true,false)},
			{"idmankind",createColumn("idmankind",typeof(string),true,false)},
			{"idreg",createColumn("idreg",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"nman",createColumn("nman",typeof(int),true,false)},
			{"number",createColumn("number",typeof(int),false,false)},
			{"rownum",createColumn("rownum",typeof(int),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"startnumber",createColumn("startnumber",typeof(int),true,false)},
			{"tax",createColumn("tax",typeof(decimal),true,false)},
			{"taxable",createColumn("taxable",typeof(decimal),true,false)},
			{"taxrate",createColumn("taxrate",typeof(double),true,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"yman",createColumn("yman",typeof(short),true,false)},
			{"transmitted",createColumn("transmitted",typeof(string),true,false)},
			{"idupb",createColumn("idupb",typeof(string),true,false)},
			{"idinventory",createColumn("idinventory",typeof(int),false,false)},
			{"idmot",createColumn("idmot",typeof(int),false,false)},
			{"idinv",createColumn("idinv",typeof(int),false,false)},
			{"idassetload",createColumn("idassetload",typeof(int),true,false)},
			{"flag",createColumn("flag",typeof(byte),false,false)},
			{"idsor1",createColumn("idsor1",typeof(int),true,false)},
			{"idsor2",createColumn("idsor2",typeof(int),true,false)},
			{"idsor3",createColumn("idsor3",typeof(int),true,false)},
			{"historicalvalue",createColumn("historicalvalue",typeof(decimal),true,false)},
			{"idlist",createColumn("idlist",typeof(int),true,false)},
			{"yinv",createColumn("yinv",typeof(short),true,false)},
			{"ninv",createColumn("ninv",typeof(int),true,false)},
			{"idinvkind",createColumn("idinvkind",typeof(int),true,false)},
			{"invrownum",createColumn("invrownum",typeof(int),true,false)},
			{"idcostpartition",createColumn("idcostpartition",typeof(int),true,false)},
		};
	}
}
}
