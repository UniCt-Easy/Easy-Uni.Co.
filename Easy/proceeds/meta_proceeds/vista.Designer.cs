
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
namespace meta_proceeds {
public class proceedsRow: MetaRow  {
	public proceedsRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 npro{ 
		get {return  (Int32)this["npro"];}
		set {this["npro"]= value;}
	}
	public object nproValue { 
		get{ return this["npro"];}
		set {this["npro"]= value;}
	}
	public Int32 nproOriginal { 
		get {return  (Int32)this["npro",DataRowVersion.Original];}
	}
	public Int16 ypro{ 
		get {return  (Int16)this["ypro"];}
		set {this["ypro"]= value;}
	}
	public object yproValue { 
		get{ return this["ypro"];}
		set {this["ypro"]= value;}
	}
	public Int16 yproOriginal { 
		get {return  (Int16)this["ypro",DataRowVersion.Original];}
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
	public DateTime? annulmentdate{ 
		get {if (this["annulmentdate"]==DBNull.Value)return null; return  (DateTime?)this["annulmentdate"];}
		set {if (value==null) this["annulmentdate"]= DBNull.Value; else this["annulmentdate"]= value;}
	}
	public object annulmentdateValue { 
		get{ return this["annulmentdate"];}
		set {if (value==null|| value==DBNull.Value) this["annulmentdate"]= DBNull.Value; else this["annulmentdate"]= value;}
	}
	public DateTime? annulmentdateOriginal { 
		get {if (this["annulmentdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["annulmentdate",DataRowVersion.Original];}
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
	public DateTime? printdate{ 
		get {if (this["printdate"]==DBNull.Value)return null; return  (DateTime?)this["printdate"];}
		set {if (value==null) this["printdate"]= DBNull.Value; else this["printdate"]= value;}
	}
	public object printdateValue { 
		get{ return this["printdate"];}
		set {if (value==null|| value==DBNull.Value) this["printdate"]= DBNull.Value; else this["printdate"]= value;}
	}
	public DateTime? printdateOriginal { 
		get {if (this["printdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["printdate",DataRowVersion.Original];}
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
	public Int32? idfin{ 
		get {if (this["idfin"]==DBNull.Value)return null; return  (Int32?)this["idfin"];}
		set {if (value==null) this["idfin"]= DBNull.Value; else this["idfin"]= value;}
	}
	public object idfinValue { 
		get{ return this["idfin"];}
		set {if (value==null|| value==DBNull.Value) this["idfin"]= DBNull.Value; else this["idfin"]= value;}
	}
	public Int32? idfinOriginal { 
		get {if (this["idfin",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idfin",DataRowVersion.Original];}
	}
	public Int32? idman{ 
		get {if (this["idman"]==DBNull.Value)return null; return  (Int32?)this["idman"];}
		set {if (value==null) this["idman"]= DBNull.Value; else this["idman"]= value;}
	}
	public object idmanValue { 
		get{ return this["idman"];}
		set {if (value==null|| value==DBNull.Value) this["idman"]= DBNull.Value; else this["idman"]= value;}
	}
	public Int32? idmanOriginal { 
		get {if (this["idman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idman",DataRowVersion.Original];}
	}
	public Int32? idtreasurer{ 
		get {if (this["idtreasurer"]==DBNull.Value)return null; return  (Int32?)this["idtreasurer"];}
		set {if (value==null) this["idtreasurer"]= DBNull.Value; else this["idtreasurer"]= value;}
	}
	public object idtreasurerValue { 
		get{ return this["idtreasurer"];}
		set {if (value==null|| value==DBNull.Value) this["idtreasurer"]= DBNull.Value; else this["idtreasurer"]= value;}
	}
	public Int32? idtreasurerOriginal { 
		get {if (this["idtreasurer",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idtreasurer",DataRowVersion.Original];}
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
	public Int32 kpro{ 
		get {return  (Int32)this["kpro"];}
		set {this["kpro"]= value;}
	}
	public object kproValue { 
		get{ return this["kpro"];}
		set {this["kpro"]= value;}
	}
	public Int32 kproOriginal { 
		get {return  (Int32)this["kpro",DataRowVersion.Original];}
	}
	public Int32? kproceedstransmission{ 
		get {if (this["kproceedstransmission"]==DBNull.Value)return null; return  (Int32?)this["kproceedstransmission"];}
		set {if (value==null) this["kproceedstransmission"]= DBNull.Value; else this["kproceedstransmission"]= value;}
	}
	public object kproceedstransmissionValue { 
		get{ return this["kproceedstransmission"];}
		set {if (value==null|| value==DBNull.Value) this["kproceedstransmission"]= DBNull.Value; else this["kproceedstransmission"]= value;}
	}
	public Int32? kproceedstransmissionOriginal { 
		get {if (this["kproceedstransmission",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["kproceedstransmission",DataRowVersion.Original];}
	}
	public Int32? idstamphandling{ 
		get {if (this["idstamphandling"]==DBNull.Value)return null; return  (Int32?)this["idstamphandling"];}
		set {if (value==null) this["idstamphandling"]= DBNull.Value; else this["idstamphandling"]= value;}
	}
	public object idstamphandlingValue { 
		get{ return this["idstamphandling"];}
		set {if (value==null|| value==DBNull.Value) this["idstamphandling"]= DBNull.Value; else this["idstamphandling"]= value;}
	}
	public Int32? idstamphandlingOriginal { 
		get {if (this["idstamphandling",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idstamphandling",DataRowVersion.Original];}
	}
	public Int32? idsor01{ 
		get {if (this["idsor01"]==DBNull.Value)return null; return  (Int32?)this["idsor01"];}
		set {if (value==null) this["idsor01"]= DBNull.Value; else this["idsor01"]= value;}
	}
	public object idsor01Value { 
		get{ return this["idsor01"];}
		set {if (value==null|| value==DBNull.Value) this["idsor01"]= DBNull.Value; else this["idsor01"]= value;}
	}
	public Int32? idsor01Original { 
		get {if (this["idsor01",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor01",DataRowVersion.Original];}
	}
	public Int32? idsor02{ 
		get {if (this["idsor02"]==DBNull.Value)return null; return  (Int32?)this["idsor02"];}
		set {if (value==null) this["idsor02"]= DBNull.Value; else this["idsor02"]= value;}
	}
	public object idsor02Value { 
		get{ return this["idsor02"];}
		set {if (value==null|| value==DBNull.Value) this["idsor02"]= DBNull.Value; else this["idsor02"]= value;}
	}
	public Int32? idsor02Original { 
		get {if (this["idsor02",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor02",DataRowVersion.Original];}
	}
	public Int32? idsor03{ 
		get {if (this["idsor03"]==DBNull.Value)return null; return  (Int32?)this["idsor03"];}
		set {if (value==null) this["idsor03"]= DBNull.Value; else this["idsor03"]= value;}
	}
	public object idsor03Value { 
		get{ return this["idsor03"];}
		set {if (value==null|| value==DBNull.Value) this["idsor03"]= DBNull.Value; else this["idsor03"]= value;}
	}
	public Int32? idsor03Original { 
		get {if (this["idsor03",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor03",DataRowVersion.Original];}
	}
	public Int32? idsor04{ 
		get {if (this["idsor04"]==DBNull.Value)return null; return  (Int32?)this["idsor04"];}
		set {if (value==null) this["idsor04"]= DBNull.Value; else this["idsor04"]= value;}
	}
	public object idsor04Value { 
		get{ return this["idsor04"];}
		set {if (value==null|| value==DBNull.Value) this["idsor04"]= DBNull.Value; else this["idsor04"]= value;}
	}
	public Int32? idsor04Original { 
		get {if (this["idsor04",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor04",DataRowVersion.Original];}
	}
	public Int32? idsor05{ 
		get {if (this["idsor05"]==DBNull.Value)return null; return  (Int32?)this["idsor05"];}
		set {if (value==null) this["idsor05"]= DBNull.Value; else this["idsor05"]= value;}
	}
	public object idsor05Value { 
		get{ return this["idsor05"];}
		set {if (value==null|| value==DBNull.Value) this["idsor05"]= DBNull.Value; else this["idsor05"]= value;}
	}
	public Int32? idsor05Original { 
		get {if (this["idsor05",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor05",DataRowVersion.Original];}
	}
	public String external_reference{ 
		get {if (this["external_reference"]==DBNull.Value)return null; return  (String)this["external_reference"];}
		set {if (value==null) this["external_reference"]= DBNull.Value; else this["external_reference"]= value;}
	}
	public object external_referenceValue { 
		get{ return this["external_reference"];}
		set {if (value==null|| value==DBNull.Value) this["external_reference"]= DBNull.Value; else this["external_reference"]= value;}
	}
	public String external_referenceOriginal { 
		get {if (this["external_reference",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["external_reference",DataRowVersion.Original];}
	}
	public Int32? npro_treasurer{ 
		get {if (this["npro_treasurer"]==DBNull.Value)return null; return  (Int32?)this["npro_treasurer"];}
		set {if (value==null) this["npro_treasurer"]= DBNull.Value; else this["npro_treasurer"]= value;}
	}
	public object npro_treasurerValue { 
		get{ return this["npro_treasurer"];}
		set {if (value==null|| value==DBNull.Value) this["npro_treasurer"]= DBNull.Value; else this["npro_treasurer"]= value;}
	}
	public Int32? npro_treasurerOriginal { 
		get {if (this["npro_treasurer",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["npro_treasurer",DataRowVersion.Original];}
	}
	#endregion

}
public class proceedsTable : MetaTableBase<proceedsRow> {
	public proceedsTable() : base("proceeds"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"npro",createColumn("npro",typeof(int),false,false)},
			{"ypro",createColumn("ypro",typeof(short),false,false)},
			{"adate",createColumn("adate",typeof(DateTime),false,false)},
			{"annulmentdate",createColumn("annulmentdate",typeof(DateTime),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idreg",createColumn("idreg",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"printdate",createColumn("printdate",typeof(DateTime),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"idfin",createColumn("idfin",typeof(int),true,false)},
			{"idman",createColumn("idman",typeof(int),true,false)},
			{"idtreasurer",createColumn("idtreasurer",typeof(int),true,false)},
			{"flag",createColumn("flag",typeof(byte),false,false)},
			{"kpro",createColumn("kpro",typeof(int),false,false)},
			{"kproceedstransmission",createColumn("kproceedstransmission",typeof(int),true,false)},
			{"idstamphandling",createColumn("idstamphandling",typeof(int),true,false)},
			{"idsor01",createColumn("idsor01",typeof(int),true,false)},
			{"idsor02",createColumn("idsor02",typeof(int),true,false)},
			{"idsor03",createColumn("idsor03",typeof(int),true,false)},
			{"idsor04",createColumn("idsor04",typeof(int),true,false)},
			{"idsor05",createColumn("idsor05",typeof(int),true,false)},
			{"external_reference",createColumn("external_reference",typeof(string),true,false)},
			{"npro_treasurer",createColumn("npro_treasurer",typeof(int),true,false)},
		};
	}
}
}
