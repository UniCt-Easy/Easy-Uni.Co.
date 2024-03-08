
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
namespace meta_emisti_rec_09 {
public class emisti_rec_09Row: MetaRow  {
	public emisti_rec_09Row(DataRowBuilder rb) : base(rb) {} 

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
	public Int32 idelenco{ 
		get {return  (Int32)this["idelenco"];}
		set {this["idelenco"]= value;}
	}
	public object idelencoValue { 
		get{ return this["idelenco"];}
		set {this["idelenco"]= value;}
	}
	public Int32 idelencoOriginal { 
		get {return  (Int32)this["idelenco",DataRowVersion.Original];}
	}
	public Int32 capbilstato{ 
		get {return  (Int32)this["capbilstato"];}
		set {this["capbilstato"]= value;}
	}
	public object capbilstatoValue { 
		get{ return this["capbilstato"];}
		set {this["capbilstato"]= value;}
	}
	public Int32 capbilstatoOriginal { 
		get {return  (Int32)this["capbilstato",DataRowVersion.Original];}
	}
	public Int32 numpg{ 
		get {return  (Int32)this["numpg"];}
		set {this["numpg"]= value;}
	}
	public object numpgValue { 
		get{ return this["numpg"];}
		set {this["numpg"]= value;}
	}
	public Int32 numpgOriginal { 
		get {return  (Int32)this["numpg",DataRowVersion.Original];}
	}
	public Int32 annoriferimento{ 
		get {return  (Int32)this["annoriferimento"];}
		set {this["annoriferimento"]= value;}
	}
	public object annoriferimentoValue { 
		get{ return this["annoriferimento"];}
		set {this["annoriferimento"]= value;}
	}
	public Int32 annoriferimentoOriginal { 
		get {return  (Int32)this["annoriferimento",DataRowVersion.Original];}
	}
	public String compenso{ 
		get {if (this["compenso"]==DBNull.Value)return null; return  (String)this["compenso"];}
		set {if (value==null) this["compenso"]= DBNull.Value; else this["compenso"]= value;}
	}
	public object compensoValue { 
		get{ return this["compenso"];}
		set {if (value==null|| value==DBNull.Value) this["compenso"]= DBNull.Value; else this["compenso"]= value;}
	}
	public String compensoOriginal { 
		get {if (this["compenso",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["compenso",DataRowVersion.Original];}
	}
	public String sottocompenso{ 
		get {if (this["sottocompenso"]==DBNull.Value)return null; return  (String)this["sottocompenso"];}
		set {if (value==null) this["sottocompenso"]= DBNull.Value; else this["sottocompenso"]= value;}
	}
	public object sottocompensoValue { 
		get{ return this["sottocompenso"];}
		set {if (value==null|| value==DBNull.Value) this["sottocompenso"]= DBNull.Value; else this["sottocompenso"]= value;}
	}
	public String sottocompensoOriginal { 
		get {if (this["sottocompenso",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["sottocompenso",DataRowVersion.Original];}
	}
	public Int32 tipolcompenso{ 
		get {return  (Int32)this["tipolcompenso"];}
		set {this["tipolcompenso"]= value;}
	}
	public object tipolcompensoValue { 
		get{ return this["tipolcompenso"];}
		set {this["tipolcompenso"]= value;}
	}
	public Int32 tipolcompensoOriginal { 
		get {return  (Int32)this["tipolcompenso",DataRowVersion.Original];}
	}
	public String codritprevass{ 
		get {if (this["codritprevass"]==DBNull.Value)return null; return  (String)this["codritprevass"];}
		set {if (value==null) this["codritprevass"]= DBNull.Value; else this["codritprevass"]= value;}
	}
	public object codritprevassValue { 
		get{ return this["codritprevass"];}
		set {if (value==null|| value==DBNull.Value) this["codritprevass"]= DBNull.Value; else this["codritprevass"]= value;}
	}
	public String codritprevassOriginal { 
		get {if (this["codritprevass",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codritprevass",DataRowVersion.Original];}
	}
	public Int32 imponibile{ 
		get {return  (Int32)this["imponibile"];}
		set {this["imponibile"]= value;}
	}
	public object imponibileValue { 
		get{ return this["imponibile"];}
		set {this["imponibile"]= value;}
	}
	public Int32 imponibileOriginal { 
		get {return  (Int32)this["imponibile",DataRowVersion.Original];}
	}
	public Int32 importoritlavoratore{ 
		get {return  (Int32)this["importoritlavoratore"];}
		set {this["importoritlavoratore"]= value;}
	}
	public object importoritlavoratoreValue { 
		get{ return this["importoritlavoratore"];}
		set {this["importoritlavoratore"]= value;}
	}
	public Int32 importoritlavoratoreOriginal { 
		get {return  (Int32)this["importoritlavoratore",DataRowVersion.Original];}
	}
	public Int32 importoritdatore{ 
		get {return  (Int32)this["importoritdatore"];}
		set {this["importoritdatore"]= value;}
	}
	public object importoritdatoreValue { 
		get{ return this["importoritdatore"];}
		set {this["importoritdatore"]= value;}
	}
	public Int32 importoritdatoreOriginal { 
		get {return  (Int32)this["importoritdatore",DataRowVersion.Original];}
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
public class emisti_rec_09Table : MetaTableBase<emisti_rec_09Row> {
	public emisti_rec_09Table() : base("emisti_rec_09"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nrec",createColumn("nrec",typeof(int),false,false)},
			{"rata",createColumn("rata",typeof(string),true,false)},
			{"dataemissione",createColumn("dataemissione",typeof(DateTime),false,false)},
			{"idelenco",createColumn("idelenco",typeof(int),false,false)},
			{"capbilstato",createColumn("capbilstato",typeof(int),false,false)},
			{"numpg",createColumn("numpg",typeof(int),false,false)},
			{"annoriferimento",createColumn("annoriferimento",typeof(int),false,false)},
			{"compenso",createColumn("compenso",typeof(string),true,false)},
			{"sottocompenso",createColumn("sottocompenso",typeof(string),true,false)},
			{"tipolcompenso",createColumn("tipolcompenso",typeof(int),false,false)},
			{"codritprevass",createColumn("codritprevass",typeof(string),true,false)},
			{"imponibile",createColumn("imponibile",typeof(int),false,false)},
			{"importoritlavoratore",createColumn("importoritlavoratore",typeof(int),false,false)},
			{"importoritdatore",createColumn("importoritdatore",typeof(int),false,false)},
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
