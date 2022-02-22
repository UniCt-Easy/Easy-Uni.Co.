
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
using metadatalibrary;
namespace meta_assetvardetail {
public class assetvardetailRow: MetaRow  {
	public assetvardetailRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///importo
	///</summary>
	public Decimal? amount{ 
		get {if (this["amount"]==DBNull.Value)return null; return  (Decimal?)this["amount"];}
		set {if (value==null) this["amount"]= DBNull.Value; else this["amount"]= value;}
	}
	public object amountValue { 
		get{ return this["amount"];}
		set {if (value==null|| value==DBNull.Value) this["amount"]= DBNull.Value; else this["amount"]= value;}
	}
	public Decimal? amountOriginal { 
		get {if (this["amount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["amount",DataRowVersion.Original];}
	}
	///<summary>
	///data creazione
	///</summary>
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
	///<summary>
	///nome utente creazione
	///</summary>
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
	///<summary>
	///Descrizione
	///</summary>
	public String description{ 
		get {if (this["description"]==DBNull.Value)return null; return  (String)this["description"];}
		set {if (value==null) this["description"]= DBNull.Value; else this["description"]= value;}
	}
	public object descriptionValue { 
		get{ return this["description"];}
		set {if (value==null|| value==DBNull.Value) this["description"]= DBNull.Value; else this["description"]= value;}
	}
	public String descriptionOriginal { 
		get {if (this["description",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["description",DataRowVersion.Original];}
	}
	///<summary>
	///data ultima modifica
	///</summary>
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
	///<summary>
	///nome ultimo utente modifica
	///</summary>
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
	///<summary>
	///Id inventario (tabella inventory)
	///</summary>
	public Int32? idinventory{ 
		get {if (this["idinventory"]==DBNull.Value)return null; return  (Int32?)this["idinventory"];}
		set {if (value==null) this["idinventory"]= DBNull.Value; else this["idinventory"]= value;}
	}
	public object idinventoryValue { 
		get{ return this["idinventory"];}
		set {if (value==null|| value==DBNull.Value) this["idinventory"]= DBNull.Value; else this["idinventory"]= value;}
	}
	public Int32? idinventoryOriginal { 
		get {if (this["idinventory",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinventory",DataRowVersion.Original];}
	}
	///<summary>
	///ID class. inventariale (tabella inventorytree)
	///</summary>
	public Int32? idinv{ 
		get {if (this["idinv"]==DBNull.Value)return null; return  (Int32?)this["idinv"];}
		set {if (value==null) this["idinv"]= DBNull.Value; else this["idinv"]= value;}
	}
	public object idinvValue { 
		get{ return this["idinv"];}
		set {if (value==null|| value==DBNull.Value) this["idinv"]= DBNull.Value; else this["idinv"]= value;}
	}
	public Int32? idinvOriginal { 
		get {if (this["idinv",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinv",DataRowVersion.Original];}
	}
	///<summary>
	///ID Variazione Patrimoniale (tabella assetvar)
	///</summary>
	public Int32? idassetvar{ 
		get {if (this["idassetvar"]==DBNull.Value)return null; return  (Int32?)this["idassetvar"];}
		set {if (value==null) this["idassetvar"]= DBNull.Value; else this["idassetvar"]= value;}
	}
	public object idassetvarValue { 
		get{ return this["idassetvar"];}
		set {if (value==null|| value==DBNull.Value) this["idassetvar"]= DBNull.Value; else this["idassetvar"]= value;}
	}
	public Int32? idassetvarOriginal { 
		get {if (this["idassetvar",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idassetvar",DataRowVersion.Original];}
	}
	///<summary>
	///#
	///</summary>
	public Int32? idassetvardetail{ 
		get {if (this["idassetvardetail"]==DBNull.Value)return null; return  (Int32?)this["idassetvardetail"];}
		set {if (value==null) this["idassetvardetail"]= DBNull.Value; else this["idassetvardetail"]= value;}
	}
	public object idassetvardetailValue { 
		get{ return this["idassetvardetail"];}
		set {if (value==null|| value==DBNull.Value) this["idassetvardetail"]= DBNull.Value; else this["idassetvardetail"]= value;}
	}
	public Int32? idassetvardetailOriginal { 
		get {if (this["idassetvardetail",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idassetvardetail",DataRowVersion.Original];}
	}
	///<summary>
	///Id causale (tabella motive)
	///</summary>
	public Int32? idmot{ 
		get {if (this["idmot"]==DBNull.Value)return null; return  (Int32?)this["idmot"];}
		set {if (value==null) this["idmot"]= DBNull.Value; else this["idmot"]= value;}
	}
	public object idmotValue { 
		get{ return this["idmot"];}
		set {if (value==null|| value==DBNull.Value) this["idmot"]= DBNull.Value; else this["idmot"]= value;}
	}
	public Int32? idmotOriginal { 
		get {if (this["idmot",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idmot",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Dettaglio variazione
///</summary>
public class assetvardetailTable : MetaTableBase<assetvardetailRow> {
	public assetvardetailTable() : base("assetvardetail"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("amount")){ 
			defineColumn("amount", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("description")){ 
			defineColumn("description", typeof(System.String));
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("idinventory")){ 
			defineColumn("idinventory", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idinv")){ 
			defineColumn("idinv", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("idassetvar")){ 
			defineColumn("idassetvar", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("idassetvardetail")){ 
			defineColumn("idassetvardetail", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("idmot")){ 
			defineColumn("idmot", typeof(System.Int32));
		}
		#endregion

	}
}
}
