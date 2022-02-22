
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
namespace meta_expenselastmandatedetail {
public class expenselastmandatedetailRow: MetaRow  {
	public expenselastmandatedetailRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 idexp{ 
		get {return  (Int32)this["idexp"];}
		set {this["idexp"]= value;}
	}
	public object idexpValue { 
		get{ return this["idexp"];}
		set {this["idexp"]= value;}
	}
	public Int32 idexpOriginal { 
		get {return  (Int32)this["idexp",DataRowVersion.Original];}
	}
	public String idmankind{ 
		get {return  (String)this["idmankind"];}
		set {this["idmankind"]= value;}
	}
	public object idmankindValue { 
		get{ return this["idmankind"];}
		set {this["idmankind"]= value;}
	}
	public String idmankindOriginal { 
		get {return  (String)this["idmankind",DataRowVersion.Original];}
	}
	public Int16 yman{ 
		get {return  (Int16)this["yman"];}
		set {this["yman"]= value;}
	}
	public object ymanValue { 
		get{ return this["yman"];}
		set {this["yman"]= value;}
	}
	public Int16 ymanOriginal { 
		get {return  (Int16)this["yman",DataRowVersion.Original];}
	}
	public Int32 nman{ 
		get {return  (Int32)this["nman"];}
		set {this["nman"]= value;}
	}
	public object nmanValue { 
		get{ return this["nman"];}
		set {this["nman"]= value;}
	}
	public Int32 nmanOriginal { 
		get {return  (Int32)this["nman",DataRowVersion.Original];}
	}
	public Int32 rownum{ 
		get {return  (Int32)this["rownum"];}
		set {this["rownum"]= value;}
	}
	public object rownumValue { 
		get{ return this["rownum"];}
		set {this["rownum"]= value;}
	}
	public Int32 rownumOriginal { 
		get {return  (Int32)this["rownum",DataRowVersion.Original];}
	}
	public Decimal amount{ 
		get {return  (Decimal)this["amount"];}
		set {this["amount"]= value;}
	}
	public object amountValue { 
		get{ return this["amount"];}
		set {this["amount"]= value;}
	}
	public Decimal amountOriginal { 
		get {return  (Decimal)this["amount",DataRowVersion.Original];}
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
	#endregion

}
public class expenselastmandatedetailTable : MetaTableBase<expenselastmandatedetailRow> {
	public expenselastmandatedetailTable() : base("expenselastmandatedetail"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idexp",createColumn("idexp",typeof(int),false,false)},
			{"idmankind",createColumn("idmankind",typeof(string),false,false)},
			{"yman",createColumn("yman",typeof(short),false,false)},
			{"nman",createColumn("nman",typeof(int),false,false)},
			{"rownum",createColumn("rownum",typeof(int),false,false)},
			{"amount",createColumn("amount",typeof(decimal),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
		};
	}
}
}
