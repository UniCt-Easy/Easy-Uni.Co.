
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
namespace meta_emisti_rec_02 {
public class emisti_rec_02Row: MetaRow  {
	public emisti_rec_02Row(DataRowBuilder rb) : base(rb) {} 

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
	public String sottocodiceassegno{ 
		get {if (this["sottocodiceassegno"]==DBNull.Value)return null; return  (String)this["sottocodiceassegno"];}
		set {if (value==null) this["sottocodiceassegno"]= DBNull.Value; else this["sottocodiceassegno"]= value;}
	}
	public object sottocodiceassegnoValue { 
		get{ return this["sottocodiceassegno"];}
		set {if (value==null|| value==DBNull.Value) this["sottocodiceassegno"]= DBNull.Value; else this["sottocodiceassegno"]= value;}
	}
	public String sottocodiceassegnoOriginal { 
		get {if (this["sottocodiceassegno",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["sottocodiceassegno",DataRowVersion.Original];}
	}
	public Int32 importolordotabellare{ 
		get {return  (Int32)this["importolordotabellare"];}
		set {this["importolordotabellare"]= value;}
	}
	public object importolordotabellareValue { 
		get{ return this["importolordotabellare"];}
		set {this["importolordotabellare"]= value;}
	}
	public Int32 importolordotabellareOriginal { 
		get {return  (Int32)this["importolordotabellare",DataRowVersion.Original];}
	}
	public Int32 importolordorata{ 
		get {return  (Int32)this["importolordorata"];}
		set {this["importolordorata"]= value;}
	}
	public object importolordorataValue { 
		get{ return this["importolordorata"];}
		set {this["importolordorata"]= value;}
	}
	public Int32 importolordorataOriginal { 
		get {return  (Int32)this["importolordorata",DataRowVersion.Original];}
	}
	public Int32 importoriduzionept{ 
		get {return  (Int32)this["importoriduzionept"];}
		set {this["importoriduzionept"]= value;}
	}
	public object importoriduzioneptValue { 
		get{ return this["importoriduzionept"];}
		set {this["importoriduzionept"]= value;}
	}
	public Int32 importoriduzioneptOriginal { 
		get {return  (Int32)this["importoriduzionept",DataRowVersion.Original];}
	}
	public Int32 importoriduzionete{ 
		get {return  (Int32)this["importoriduzionete"];}
		set {this["importoriduzionete"]= value;}
	}
	public object importoriduzioneteValue { 
		get{ return this["importoriduzionete"];}
		set {this["importoriduzionete"]= value;}
	}
	public Int32 importoriduzioneteOriginal { 
		get {return  (Int32)this["importoriduzionete",DataRowVersion.Original];}
	}
	public Int32 importoritprev{ 
		get {return  (Int32)this["importoritprev"];}
		set {this["importoritprev"]= value;}
	}
	public object importoritprevValue { 
		get{ return this["importoritprev"];}
		set {this["importoritprev"]= value;}
	}
	public Int32 importoritprevOriginal { 
		get {return  (Int32)this["importoritprev",DataRowVersion.Original];}
	}
	public String datascadassegno{ 
		get {if (this["datascadassegno"]==DBNull.Value)return null; return  (String)this["datascadassegno"];}
		set {if (value==null) this["datascadassegno"]= DBNull.Value; else this["datascadassegno"]= value;}
	}
	public object datascadassegnoValue { 
		get{ return this["datascadassegno"];}
		set {if (value==null|| value==DBNull.Value) this["datascadassegno"]= DBNull.Value; else this["datascadassegno"]= value;}
	}
	public String datascadassegnoOriginal { 
		get {if (this["datascadassegno",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["datascadassegno",DataRowVersion.Original];}
	}
	public String flagimponfiscale{ 
		get {if (this["flagimponfiscale"]==DBNull.Value)return null; return  (String)this["flagimponfiscale"];}
		set {if (value==null) this["flagimponfiscale"]= DBNull.Value; else this["flagimponfiscale"]= value;}
	}
	public object flagimponfiscaleValue { 
		get{ return this["flagimponfiscale"];}
		set {if (value==null|| value==DBNull.Value) this["flagimponfiscale"]= DBNull.Value; else this["flagimponfiscale"]= value;}
	}
	public String flagimponfiscaleOriginal { 
		get {if (this["flagimponfiscale",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagimponfiscale",DataRowVersion.Original];}
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
public class emisti_rec_02Table : MetaTableBase<emisti_rec_02Row> {
	public emisti_rec_02Table() : base("emisti_rec_02"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nrec",createColumn("nrec",typeof(int),false,false)},
			{"rata",createColumn("rata",typeof(string),true,false)},
			{"dataemissione",createColumn("dataemissione",typeof(DateTime),false,false)},
			{"codiceassegno",createColumn("codiceassegno",typeof(int),false,false)},
			{"sottocodiceassegno",createColumn("sottocodiceassegno",typeof(string),true,false)},
			{"importolordotabellare",createColumn("importolordotabellare",typeof(int),false,false)},
			{"importolordorata",createColumn("importolordorata",typeof(int),false,false)},
			{"importoriduzionept",createColumn("importoriduzionept",typeof(int),false,false)},
			{"importoriduzionete",createColumn("importoriduzionete",typeof(int),false,false)},
			{"importoritprev",createColumn("importoritprev",typeof(int),false,false)},
			{"datascadassegno",createColumn("datascadassegno",typeof(string),true,false)},
			{"flagimponfiscale",createColumn("flagimponfiscale",typeof(string),true,false)},
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
