
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
namespace meta_emisti_rec_10 {
public class emisti_rec_10Row: MetaRow  {
	public emisti_rec_10Row(DataRowBuilder rb) : base(rb) {} 

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
	public Int32 emissione{ 
		get {return  (Int32)this["emissione"];}
		set {this["emissione"]= value;}
	}
	public object emissioneValue { 
		get{ return this["emissione"];}
		set {this["emissione"]= value;}
	}
	public Int32 emissioneOriginal { 
		get {return  (Int32)this["emissione",DataRowVersion.Original];}
	}
	public Int32 imponibileritenutaacconto{ 
		get {return  (Int32)this["imponibileritenutaacconto"];}
		set {this["imponibileritenutaacconto"]= value;}
	}
	public object imponibileritenutaaccontoValue { 
		get{ return this["imponibileritenutaacconto"];}
		set {this["imponibileritenutaacconto"]= value;}
	}
	public Int32 imponibileritenutaaccontoOriginal { 
		get {return  (Int32)this["imponibileritenutaacconto",DataRowVersion.Original];}
	}
	public Int32 imponibileritenutaaccontoiva{ 
		get {return  (Int32)this["imponibileritenutaaccontoiva"];}
		set {this["imponibileritenutaaccontoiva"]= value;}
	}
	public object imponibileritenutaaccontoivaValue { 
		get{ return this["imponibileritenutaaccontoiva"];}
		set {this["imponibileritenutaaccontoiva"]= value;}
	}
	public Int32 imponibileritenutaaccontoivaOriginal { 
		get {return  (Int32)this["imponibileritenutaaccontoiva",DataRowVersion.Original];}
	}
	public Int32 importoritenutaacconto{ 
		get {return  (Int32)this["importoritenutaacconto"];}
		set {this["importoritenutaacconto"]= value;}
	}
	public object importoritenutaaccontoValue { 
		get{ return this["importoritenutaacconto"];}
		set {this["importoritenutaacconto"]= value;}
	}
	public Int32 importoritenutaaccontoOriginal { 
		get {return  (Int32)this["importoritenutaacconto",DataRowVersion.Original];}
	}
	public Int32 impcontrintegrcat{ 
		get {return  (Int32)this["impcontrintegrcat"];}
		set {this["impcontrintegrcat"]= value;}
	}
	public object impcontrintegrcatValue { 
		get{ return this["impcontrintegrcat"];}
		set {this["impcontrintegrcat"]= value;}
	}
	public Int32 impcontrintegrcatOriginal { 
		get {return  (Int32)this["impcontrintegrcat",DataRowVersion.Original];}
	}
	public Int32 impcontrintegrinps{ 
		get {return  (Int32)this["impcontrintegrinps"];}
		set {this["impcontrintegrinps"]= value;}
	}
	public object impcontrintegrinpsValue { 
		get{ return this["impcontrintegrinps"];}
		set {this["impcontrintegrinps"]= value;}
	}
	public Int32 impcontrintegrinpsOriginal { 
		get {return  (Int32)this["impcontrintegrinps",DataRowVersion.Original];}
	}
	public Int32 importoiva{ 
		get {return  (Int32)this["importoiva"];}
		set {this["importoiva"]= value;}
	}
	public object importoivaValue { 
		get{ return this["importoiva"];}
		set {this["importoiva"]= value;}
	}
	public Int32 importoivaOriginal { 
		get {return  (Int32)this["importoiva",DataRowVersion.Original];}
	}
	public Decimal perccontrintegrcat{ 
		get {return  (Decimal)this["perccontrintegrcat"];}
		set {this["perccontrintegrcat"]= value;}
	}
	public object perccontrintegrcatValue { 
		get{ return this["perccontrintegrcat"];}
		set {this["perccontrintegrcat"]= value;}
	}
	public Decimal perccontrintegrcatOriginal { 
		get {return  (Decimal)this["perccontrintegrcat",DataRowVersion.Original];}
	}
	public Decimal perccontrintegrinps{ 
		get {return  (Decimal)this["perccontrintegrinps"];}
		set {this["perccontrintegrinps"]= value;}
	}
	public object perccontrintegrinpsValue { 
		get{ return this["perccontrintegrinps"];}
		set {this["perccontrintegrinps"]= value;}
	}
	public Decimal perccontrintegrinpsOriginal { 
		get {return  (Decimal)this["perccontrintegrinps",DataRowVersion.Original];}
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
	#endregion

}
public class emisti_rec_10Table : MetaTableBase<emisti_rec_10Row> {
	public emisti_rec_10Table() : base("emisti_rec_10"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nrec",createColumn("nrec",typeof(int),false,false)},
			{"rata",createColumn("rata",typeof(string),true,false)},
			{"emissione",createColumn("emissione",typeof(int),false,false)},
			{"imponibileritenutaacconto",createColumn("imponibileritenutaacconto",typeof(int),false,false)},
			{"imponibileritenutaaccontoiva",createColumn("imponibileritenutaaccontoiva",typeof(int),false,false)},
			{"importoritenutaacconto",createColumn("importoritenutaacconto",typeof(int),false,false)},
			{"impcontrintegrcat",createColumn("impcontrintegrcat",typeof(int),false,false)},
			{"impcontrintegrinps",createColumn("impcontrintegrinps",typeof(int),false,false)},
			{"importoiva",createColumn("importoiva",typeof(int),false,false)},
			{"perccontrintegrcat",createColumn("perccontrintegrcat",typeof(decimal),false,false)},
			{"perccontrintegrinps",createColumn("perccontrintegrinps",typeof(decimal),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"idemisti_import",createColumn("idemisti_import",typeof(int),false,false)},
			{"progressivo_rec_01",createColumn("progressivo_rec_01",typeof(int),true,false)},
		};
	}
}
}
