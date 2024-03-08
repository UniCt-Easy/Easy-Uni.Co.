
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
namespace meta_emisti_rec_03 {
public class emisti_rec_03Row: MetaRow  {
	public emisti_rec_03Row(DataRowBuilder rb) : base(rb) {} 

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
	public Int32 codiceassegno{ 
		get {return  (Int32)this["codiceassegno"];}
		set {this["codiceassegno"]= value;}
	}
	public object codiceassegnoValue { 
		get{ return this["codiceassegno"];}
		set {this["codiceassegno"]= value;}
	}
	public Int32 codiceassegnoOriginal { 
		get {return  (Int32)this["codiceassegno",DataRowVersion.Original];}
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
	public Decimal aliquotalavoratore{ 
		get {return  (Decimal)this["aliquotalavoratore"];}
		set {this["aliquotalavoratore"]= value;}
	}
	public object aliquotalavoratoreValue { 
		get{ return this["aliquotalavoratore"];}
		set {this["aliquotalavoratore"]= value;}
	}
	public Decimal aliquotalavoratoreOriginal { 
		get {return  (Decimal)this["aliquotalavoratore",DataRowVersion.Original];}
	}
	public Decimal percentualeapplicazione{ 
		get {return  (Decimal)this["percentualeapplicazione"];}
		set {this["percentualeapplicazione"]= value;}
	}
	public object percentualeapplicazioneValue { 
		get{ return this["percentualeapplicazione"];}
		set {this["percentualeapplicazione"]= value;}
	}
	public Decimal percentualeapplicazioneOriginal { 
		get {return  (Decimal)this["percentualeapplicazione",DataRowVersion.Original];}
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
	public Int32 importoritenuta{ 
		get {return  (Int32)this["importoritenuta"];}
		set {this["importoritenuta"]= value;}
	}
	public object importoritenutaValue { 
		get{ return this["importoritenuta"];}
		set {this["importoritenuta"]= value;}
	}
	public Int32 importoritenutaOriginal { 
		get {return  (Int32)this["importoritenuta",DataRowVersion.Original];}
	}
	public Decimal aliquotadatore{ 
		get {return  (Decimal)this["aliquotadatore"];}
		set {this["aliquotadatore"]= value;}
	}
	public object aliquotadatoreValue { 
		get{ return this["aliquotadatore"];}
		set {this["aliquotadatore"]= value;}
	}
	public Decimal aliquotadatoreOriginal { 
		get {return  (Decimal)this["aliquotadatore",DataRowVersion.Original];}
	}
	public Int32 importodatore{ 
		get {return  (Int32)this["importodatore"];}
		set {this["importodatore"]= value;}
	}
	public object importodatoreValue { 
		get{ return this["importodatore"];}
		set {this["importodatore"]= value;}
	}
	public Int32 importodatoreOriginal { 
		get {return  (Int32)this["importodatore",DataRowVersion.Original];}
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
public class emisti_rec_03Table : MetaTableBase<emisti_rec_03Row> {
	public emisti_rec_03Table() : base("emisti_rec_03"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nrec",createColumn("nrec",typeof(int),false,false)},
			{"rata",createColumn("rata",typeof(string),true,false)},
			{"dataemissione",createColumn("dataemissione",typeof(DateTime),false,false)},
			{"codiceassegno",createColumn("codiceassegno",typeof(int),false,false)},
			{"codritprevass",createColumn("codritprevass",typeof(string),true,false)},
			{"aliquotalavoratore",createColumn("aliquotalavoratore",typeof(decimal),false,false)},
			{"percentualeapplicazione",createColumn("percentualeapplicazione",typeof(decimal),false,false)},
			{"imponibile",createColumn("imponibile",typeof(int),false,false)},
			{"importoritenuta",createColumn("importoritenuta",typeof(int),false,false)},
			{"aliquotadatore",createColumn("aliquotadatore",typeof(decimal),false,false)},
			{"importodatore",createColumn("importodatore",typeof(int),false,false)},
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
