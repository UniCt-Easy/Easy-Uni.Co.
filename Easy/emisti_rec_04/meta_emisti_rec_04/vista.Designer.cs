
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
namespace meta_emisti_rec_04 {
public class emisti_rec_04Row: MetaRow  {
	public emisti_rec_04Row(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 nrec{ 
		get {return  (Int32)this["nrec"];}
		set {this["nrec"]= value;}
	}
	public object nrecValue { 
		get{ return this["nrec"];}
		set {this["nrec"]= value;}
	}
	public Int32 nrecOriginal { 
		get {return  (Int32)this["nrec",DataRowVersion.Original];}
	}
	public String rata{ 
		get {if (this["rata"]==DBNull.Value)return null; return  (String)this["rata"];}
		set {if (value==null) this["rata"]= DBNull.Value; else this["rata"]= value;}
	}
	public object rataValue { 
		get{ return this["rata"];}
		set {if (value==null|| value==DBNull.Value) this["rata"]= DBNull.Value; else this["rata"]= value;}
	}
	public String rataOriginal { 
		get {if (this["rata",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["rata",DataRowVersion.Original];}
	}
	public DateTime dataemissione{ 
		get {return  (DateTime)this["dataemissione"];}
		set {this["dataemissione"]= value;}
	}
	public object dataemissioneValue { 
		get{ return this["dataemissione"];}
		set {this["dataemissione"]= value;}
	}
	public DateTime dataemissioneOriginal { 
		get {return  (DateTime)this["dataemissione",DataRowVersion.Original];}
	}
	public String codiceritenuta{ 
		get {if (this["codiceritenuta"]==DBNull.Value)return null; return  (String)this["codiceritenuta"];}
		set {if (value==null) this["codiceritenuta"]= DBNull.Value; else this["codiceritenuta"]= value;}
	}
	public object codiceritenutaValue { 
		get{ return this["codiceritenuta"];}
		set {if (value==null|| value==DBNull.Value) this["codiceritenuta"]= DBNull.Value; else this["codiceritenuta"]= value;}
	}
	public String codiceritenutaOriginal { 
		get {if (this["codiceritenuta",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codiceritenuta",DataRowVersion.Original];}
	}
	public String tiporitenuta{ 
		get {if (this["tiporitenuta"]==DBNull.Value)return null; return  (String)this["tiporitenuta"];}
		set {if (value==null) this["tiporitenuta"]= DBNull.Value; else this["tiporitenuta"]= value;}
	}
	public object tiporitenutaValue { 
		get{ return this["tiporitenuta"];}
		set {if (value==null|| value==DBNull.Value) this["tiporitenuta"]= DBNull.Value; else this["tiporitenuta"]= value;}
	}
	public String tiporitenutaOriginal { 
		get {if (this["tiporitenuta",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tiporitenuta",DataRowVersion.Original];}
	}
	public Int32? importoritenuta{ 
		get {if (this["importoritenuta"]==DBNull.Value)return null; return  (Int32?)this["importoritenuta"];}
		set {if (value==null) this["importoritenuta"]= DBNull.Value; else this["importoritenuta"]= value;}
	}
	public object importoritenutaValue { 
		get{ return this["importoritenuta"];}
		set {if (value==null|| value==DBNull.Value) this["importoritenuta"]= DBNull.Value; else this["importoritenuta"]= value;}
	}
	public Int32? importoritenutaOriginal { 
		get {if (this["importoritenuta",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["importoritenuta",DataRowVersion.Original];}
	}
	public Int32 importoritnetto{ 
		get {return  (Int32)this["importoritnetto"];}
		set {this["importoritnetto"]= value;}
	}
	public object importoritnettoValue { 
		get{ return this["importoritnetto"];}
		set {this["importoritnetto"]= value;}
	}
	public Int32 importoritnettoOriginal { 
		get {return  (Int32)this["importoritnetto",DataRowVersion.Original];}
	}
	public String codritoneremens{ 
		get {if (this["codritoneremens"]==DBNull.Value)return null; return  (String)this["codritoneremens"];}
		set {if (value==null) this["codritoneremens"]= DBNull.Value; else this["codritoneremens"]= value;}
	}
	public object codritoneremensValue { 
		get{ return this["codritoneremens"];}
		set {if (value==null|| value==DBNull.Value) this["codritoneremens"]= DBNull.Value; else this["codritoneremens"]= value;}
	}
	public String codritoneremensOriginal { 
		get {if (this["codritoneremens",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codritoneremens",DataRowVersion.Original];}
	}
	public Int32 importooneremens{ 
		get {return  (Int32)this["importooneremens"];}
		set {this["importooneremens"]= value;}
	}
	public object importooneremensValue { 
		get{ return this["importooneremens"];}
		set {this["importooneremens"]= value;}
	}
	public Int32 importooneremensOriginal { 
		get {return  (Int32)this["importooneremens",DataRowVersion.Original];}
	}
	public String codrit1tantum{ 
		get {if (this["codrit1tantum"]==DBNull.Value)return null; return  (String)this["codrit1tantum"];}
		set {if (value==null) this["codrit1tantum"]= DBNull.Value; else this["codrit1tantum"]= value;}
	}
	public object codrit1tantumValue { 
		get{ return this["codrit1tantum"];}
		set {if (value==null|| value==DBNull.Value) this["codrit1tantum"]= DBNull.Value; else this["codrit1tantum"]= value;}
	}
	public String codrit1tantumOriginal { 
		get {if (this["codrit1tantum",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codrit1tantum",DataRowVersion.Original];}
	}
	public Int32 importorit1tantum{ 
		get {return  (Int32)this["importorit1tantum"];}
		set {this["importorit1tantum"]= value;}
	}
	public object importorit1tantumValue { 
		get{ return this["importorit1tantum"];}
		set {this["importorit1tantum"]= value;}
	}
	public Int32 importorit1tantumOriginal { 
		get {return  (Int32)this["importorit1tantum",DataRowVersion.Original];}
	}
	public String codcontratto{ 
		get {if (this["codcontratto"]==DBNull.Value)return null; return  (String)this["codcontratto"];}
		set {if (value==null) this["codcontratto"]= DBNull.Value; else this["codcontratto"]= value;}
	}
	public object codcontrattoValue { 
		get{ return this["codcontratto"];}
		set {if (value==null|| value==DBNull.Value) this["codcontratto"]= DBNull.Value; else this["codcontratto"]= value;}
	}
	public String codcontrattoOriginal { 
		get {if (this["codcontratto",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codcontratto",DataRowVersion.Original];}
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
	public Int32 idemisti_import{ 
		get {return  (Int32)this["idemisti_import"];}
		set {this["idemisti_import"]= value;}
	}
	public object idemisti_importValue { 
		get{ return this["idemisti_import"];}
		set {this["idemisti_import"]= value;}
	}
	public Int32 idemisti_importOriginal { 
		get {return  (Int32)this["idemisti_import",DataRowVersion.Original];}
	}
	public Int32? progressivo_rec_01{ 
		get {if (this["progressivo_rec_01"]==DBNull.Value)return null; return  (Int32?)this["progressivo_rec_01"];}
		set {if (value==null) this["progressivo_rec_01"]= DBNull.Value; else this["progressivo_rec_01"]= value;}
	}
	public object progressivo_rec_01Value { 
		get{ return this["progressivo_rec_01"];}
		set {if (value==null|| value==DBNull.Value) this["progressivo_rec_01"]= DBNull.Value; else this["progressivo_rec_01"]= value;}
	}
	public Int32? progressivo_rec_01Original { 
		get {if (this["progressivo_rec_01",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["progressivo_rec_01",DataRowVersion.Original];}
	}
	public String flagriduzimpon{ 
		get {if (this["flagriduzimpon"]==DBNull.Value)return null; return  (String)this["flagriduzimpon"];}
		set {if (value==null) this["flagriduzimpon"]= DBNull.Value; else this["flagriduzimpon"]= value;}
	}
	public object flagriduzimponValue { 
		get{ return this["flagriduzimpon"];}
		set {if (value==null|| value==DBNull.Value) this["flagriduzimpon"]= DBNull.Value; else this["flagriduzimpon"]= value;}
	}
	public String flagriduzimponOriginal { 
		get {if (this["flagriduzimpon",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagriduzimpon",DataRowVersion.Original];}
	}
	public Int32? progressivodebito{ 
		get {if (this["progressivodebito"]==DBNull.Value)return null; return  (Int32?)this["progressivodebito"];}
		set {if (value==null) this["progressivodebito"]= DBNull.Value; else this["progressivodebito"]= value;}
	}
	public object progressivodebitoValue { 
		get{ return this["progressivodebito"];}
		set {if (value==null|| value==DBNull.Value) this["progressivodebito"]= DBNull.Value; else this["progressivodebito"]= value;}
	}
	public Int32? progressivodebitoOriginal { 
		get {if (this["progressivodebito",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["progressivodebito",DataRowVersion.Original];}
	}
	#endregion

}
public class emisti_rec_04Table : MetaTableBase<emisti_rec_04Row> {
	public emisti_rec_04Table() : base("emisti_rec_04"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nrec",createColumn("nrec",typeof(int),false,false)},
			{"rata",createColumn("rata",typeof(string),true,false)},
			{"dataemissione",createColumn("dataemissione",typeof(DateTime),false,false)},
			{"codiceritenuta",createColumn("codiceritenuta",typeof(string),true,false)},
			{"tiporitenuta",createColumn("tiporitenuta",typeof(string),true,false)},
			{"importoritenuta",createColumn("importoritenuta",typeof(int),true,false)},
			{"importoritnetto",createColumn("importoritnetto",typeof(int),false,false)},
			{"codritoneremens",createColumn("codritoneremens",typeof(string),true,false)},
			{"importooneremens",createColumn("importooneremens",typeof(int),false,false)},
			{"codrit1tantum",createColumn("codrit1tantum",typeof(string),true,false)},
			{"importorit1tantum",createColumn("importorit1tantum",typeof(int),false,false)},
			{"codcontratto",createColumn("codcontratto",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"idemisti_import",createColumn("idemisti_import",typeof(int),false,false)},
			{"progressivo_rec_01",createColumn("progressivo_rec_01",typeof(int),true,false)},
			{"flagriduzimpon",createColumn("flagriduzimpon",typeof(string),true,false)},
			{"progressivodebito",createColumn("progressivodebito",typeof(int),true,false)},
		};
	}
}
}
