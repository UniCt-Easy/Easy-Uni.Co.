
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
namespace meta_ivakind {
public class ivakindRow: MetaRow  {
	public ivakindRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	public Decimal rate{ 
		get {return  (Decimal)this["rate"];}
		set {this["rate"]= value;}
	}
	public object rateValue { 
		get{ return this["rate"];}
		set {this["rate"]= value;}
	}
	public Decimal rateOriginal { 
		get {return  (Decimal)this["rate",DataRowVersion.Original];}
	}
	public Decimal unabatabilitypercentage{ 
		get {return  (Decimal)this["unabatabilitypercentage"];}
		set {this["unabatabilitypercentage"]= value;}
	}
	public object unabatabilitypercentageValue { 
		get{ return this["unabatabilitypercentage"];}
		set {this["unabatabilitypercentage"]= value;}
	}
	public Decimal unabatabilitypercentageOriginal { 
		get {return  (Decimal)this["unabatabilitypercentage",DataRowVersion.Original];}
	}
	public String active{ 
		get {if (this["active"]==DBNull.Value)return null; return  (String)this["active"];}
		set {if (value==null) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public object activeValue { 
		get{ return this["active"];}
		set {if (value==null|| value==DBNull.Value) this["active"]= DBNull.Value; else this["active"]= value;}
	}
	public String activeOriginal { 
		get {if (this["active",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["active",DataRowVersion.Original];}
	}
	public Int32? idivataxablekind{ 
		get {if (this["idivataxablekind"]==DBNull.Value)return null; return  (Int32?)this["idivataxablekind"];}
		set {if (value==null) this["idivataxablekind"]= DBNull.Value; else this["idivataxablekind"]= value;}
	}
	public object idivataxablekindValue { 
		get{ return this["idivataxablekind"];}
		set {if (value==null|| value==DBNull.Value) this["idivataxablekind"]= DBNull.Value; else this["idivataxablekind"]= value;}
	}
	public Int32? idivataxablekindOriginal { 
		get {if (this["idivataxablekind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idivataxablekind",DataRowVersion.Original];}
	}
	public Int32 idivakind{ 
		get {return  (Int32)this["idivakind"];}
		set {this["idivakind"]= value;}
	}
	public object idivakindValue { 
		get{ return this["idivakind"];}
		set {this["idivakind"]= value;}
	}
	public Int32 idivakindOriginal { 
		get {return  (Int32)this["idivakind",DataRowVersion.Original];}
	}
	public String codeivakind{ 
		get {if (this["codeivakind"]==DBNull.Value)return null; return  (String)this["codeivakind"];}
		set {if (value==null) this["codeivakind"]= DBNull.Value; else this["codeivakind"]= value;}
	}
	public object codeivakindValue { 
		get{ return this["codeivakind"];}
		set {if (value==null|| value==DBNull.Value) this["codeivakind"]= DBNull.Value; else this["codeivakind"]= value;}
	}
	public String codeivakindOriginal { 
		get {if (this["codeivakind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codeivakind",DataRowVersion.Original];}
	}
	public Int32? flag{ 
		get {if (this["flag"]==DBNull.Value)return null; return  (Int32?)this["flag"];}
		set {if (value==null) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {if (value==null|| value==DBNull.Value) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public Int32? flagOriginal { 
		get {if (this["flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["flag",DataRowVersion.Original];}
	}
	public String annotations{ 
		get {if (this["annotations"]==DBNull.Value)return null; return  (String)this["annotations"];}
		set {if (value==null) this["annotations"]= DBNull.Value; else this["annotations"]= value;}
	}
	public object annotationsValue { 
		get{ return this["annotations"];}
		set {if (value==null|| value==DBNull.Value) this["annotations"]= DBNull.Value; else this["annotations"]= value;}
	}
	public String annotationsOriginal { 
		get {if (this["annotations",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["annotations",DataRowVersion.Original];}
	}
	public String idfenature{ 
		get {if (this["idfenature"]==DBNull.Value)return null; return  (String)this["idfenature"];}
		set {if (value==null) this["idfenature"]= DBNull.Value; else this["idfenature"]= value;}
	}
	public object idfenatureValue { 
		get{ return this["idfenature"];}
		set {if (value==null|| value==DBNull.Value) this["idfenature"]= DBNull.Value; else this["idfenature"]= value;}
	}
	public String idfenatureOriginal { 
		get {if (this["idfenature",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idfenature",DataRowVersion.Original];}
	}
	#endregion

}
public class ivakindTable : MetaTableBase<ivakindRow> {
	public ivakindTable() : base("ivakind"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"rate",createColumn("rate",typeof(decimal),false,false)},
			{"unabatabilitypercentage",createColumn("unabatabilitypercentage",typeof(decimal),false,false)},
			{"active",createColumn("active",typeof(string),true,false)},
			{"idivataxablekind",createColumn("idivataxablekind",typeof(int),true,false)},
			{"idivakind",createColumn("idivakind",typeof(int),false,false)},
			{"codeivakind",createColumn("codeivakind",typeof(string),true,false)},
			{"flag",createColumn("flag",typeof(int),true,false)},
			{"annotations",createColumn("annotations",typeof(string),true,false)},
			{"idfenature",createColumn("idfenature",typeof(string),true,false)},
		};
	}
}
}
