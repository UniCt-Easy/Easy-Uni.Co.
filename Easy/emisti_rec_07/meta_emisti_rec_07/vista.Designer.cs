
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
namespace meta_emisti_rec_07 {
public class emisti_rec_07Row: MetaRow  {
	public emisti_rec_07Row(DataRowBuilder rb) : base(rb) {} 

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
	public String codicearretrato{ 
		get {if (this["codicearretrato"]==DBNull.Value)return null; return  (String)this["codicearretrato"];}
		set {if (value==null) this["codicearretrato"]= DBNull.Value; else this["codicearretrato"]= value;}
	}
	public object codicearretratoValue { 
		get{ return this["codicearretrato"];}
		set {if (value==null|| value==DBNull.Value) this["codicearretrato"]= DBNull.Value; else this["codicearretrato"]= value;}
	}
	public String codicearretratoOriginal { 
		get {if (this["codicearretrato",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicearretrato",DataRowVersion.Original];}
	}
	public DateTime datalotto{ 
		get {return  (DateTime)this["datalotto"];}
		set {this["datalotto"]= value;}
	}
	public object datalottoValue { 
		get{ return this["datalotto"];}
		set {this["datalotto"]= value;}
	}
	public DateTime datalottoOriginal { 
		get {return  (DateTime)this["datalotto",DataRowVersion.Original];}
	}
	public Int32 numlotto{ 
		get {return  (Int32)this["numlotto"];}
		set {this["numlotto"]= value;}
	}
	public object numlottoValue { 
		get{ return this["numlotto"];}
		set {this["numlotto"]= value;}
	}
	public Int32 numlottoOriginal { 
		get {return  (Int32)this["numlotto",DataRowVersion.Original];}
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
public class emisti_rec_07Table : MetaTableBase<emisti_rec_07Row> {
	public emisti_rec_07Table() : base("emisti_rec_07"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nrec",createColumn("nrec",typeof(int),false,false)},
			{"rata",createColumn("rata",typeof(string),true,false)},
			{"dataemissione",createColumn("dataemissione",typeof(DateTime),false,false)},
			{"codiceassegno",createColumn("codiceassegno",typeof(int),false,false)},
			{"codicearretrato",createColumn("codicearretrato",typeof(string),true,false)},
			{"datalotto",createColumn("datalotto",typeof(DateTime),false,false)},
			{"numlotto",createColumn("numlotto",typeof(int),false,false)},
			{"annoriferimento",createColumn("annoriferimento",typeof(int),false,false)},
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
