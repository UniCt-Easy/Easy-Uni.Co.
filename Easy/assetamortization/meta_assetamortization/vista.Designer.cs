
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
namespace meta_assetamortization {
public class assetamortizationRow: MetaRow  {
	public assetamortizationRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Num. riv.
	///</summary>
	public Int32? namortization{ 
		get {if (this["namortization"]==DBNull.Value)return null; return  (Int32?)this["namortization"];}
		set {if (value==null) this["namortization"]= DBNull.Value; else this["namortization"]= value;}
	}
	public object namortizationValue { 
		get{ return this["namortization"];}
		set {if (value==null|| value==DBNull.Value) this["namortization"]= DBNull.Value; else this["namortization"]= value;}
	}
	public Int32? namortizationOriginal { 
		get {if (this["namortization",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["namortization",DataRowVersion.Original];}
	}
	///<summary>
	///data contabile
	///</summary>
	public DateTime? adate{ 
		get {if (this["adate"]==DBNull.Value)return null; return  (DateTime?)this["adate"];}
		set {if (value==null) this["adate"]= DBNull.Value; else this["adate"]= value;}
	}
	public object adateValue { 
		get{ return this["adate"];}
		set {if (value==null|| value==DBNull.Value) this["adate"]= DBNull.Value; else this["adate"]= value;}
	}
	public DateTime? adateOriginal { 
		get {if (this["adate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["adate",DataRowVersion.Original];}
	}
	///<summary>
	///Quota rival./sval.
	///</summary>
	public Double? amortizationquota{ 
		get {if (this["amortizationquota"]==DBNull.Value)return null; return  (Double?)this["amortizationquota"];}
		set {if (value==null) this["amortizationquota"]= DBNull.Value; else this["amortizationquota"]= value;}
	}
	public object amortizationquotaValue { 
		get{ return this["amortizationquota"];}
		set {if (value==null|| value==DBNull.Value) this["amortizationquota"]= DBNull.Value; else this["amortizationquota"]= value;}
	}
	public Double? amortizationquotaOriginal { 
		get {if (this["amortizationquota",DataRowVersion.Original]==DBNull.Value)return null; return  (Double?)this["amortizationquota",DataRowVersion.Original];}
	}
	///<summary>
	///Valore cespite su cui ? calcolato l'ammortamento, di solito pare al valore di acquisizione originale del cespite
	///</summary>
	public Decimal? assetvalue{ 
		get {if (this["assetvalue"]==DBNull.Value)return null; return  (Decimal?)this["assetvalue"];}
		set {if (value==null) this["assetvalue"]= DBNull.Value; else this["assetvalue"]= value;}
	}
	public object assetvalueValue { 
		get{ return this["assetvalue"];}
		set {if (value==null|| value==DBNull.Value) this["assetvalue"]= DBNull.Value; else this["assetvalue"]= value;}
	}
	public Decimal? assetvalueOriginal { 
		get {if (this["assetvalue",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["assetvalue",DataRowVersion.Original];}
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
	///Id cespite (tabella asset)
	///</summary>
	public Int32? idasset{ 
		get {if (this["idasset"]==DBNull.Value)return null; return  (Int32?)this["idasset"];}
		set {if (value==null) this["idasset"]= DBNull.Value; else this["idasset"]= value;}
	}
	public object idassetValue { 
		get{ return this["idasset"];}
		set {if (value==null|| value==DBNull.Value) this["idasset"]= DBNull.Value; else this["idasset"]= value;}
	}
	public Int32? idassetOriginal { 
		get {if (this["idasset",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idasset",DataRowVersion.Original];}
	}
	///<summary>
	///id dell'accessorio , 1 se cespite principale
	///</summary>
	public Int32? idpiece{ 
		get {if (this["idpiece"]==DBNull.Value)return null; return  (Int32?)this["idpiece"];}
		set {if (value==null) this["idpiece"]= DBNull.Value; else this["idpiece"]= value;}
	}
	public object idpieceValue { 
		get{ return this["idpiece"];}
		set {if (value==null|| value==DBNull.Value) this["idpiece"]= DBNull.Value; else this["idpiece"]= value;}
	}
	public Int32? idpieceOriginal { 
		get {if (this["idpiece",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpiece",DataRowVersion.Original];}
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
	///allegati
	///</summary>
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
	///<summary>
	///note testuali
	///</summary>
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
	///<summary>
	///Trasmesso (non pi? usato)
	///</summary>
	public String transmitted{ 
		get {if (this["transmitted"]==DBNull.Value)return null; return  (String)this["transmitted"];}
		set {if (value==null) this["transmitted"]= DBNull.Value; else this["transmitted"]= value;}
	}
	public object transmittedValue { 
		get{ return this["transmitted"];}
		set {if (value==null|| value==DBNull.Value) this["transmitted"]= DBNull.Value; else this["transmitted"]= value;}
	}
	public String transmittedOriginal { 
		get {if (this["transmitted",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["transmitted",DataRowVersion.Original];}
	}
	///<summary>
	///ID Tipo Ammortamento (tabella inventoryamortization)
	///</summary>
	public Int32? idinventoryamortization{ 
		get {if (this["idinventoryamortization"]==DBNull.Value)return null; return  (Int32?)this["idinventoryamortization"];}
		set {if (value==null) this["idinventoryamortization"]= DBNull.Value; else this["idinventoryamortization"]= value;}
	}
	public object idinventoryamortizationValue { 
		get{ return this["idinventoryamortization"];}
		set {if (value==null|| value==DBNull.Value) this["idinventoryamortization"]= DBNull.Value; else this["idinventoryamortization"]= value;}
	}
	public Int32? idinventoryamortizationOriginal { 
		get {if (this["idinventoryamortization",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinventoryamortization",DataRowVersion.Original];}
	}
	///<summary>
	///id buono di scarico (tabella assetunload)
	///</summary>
	public Int32? idassetunload{ 
		get {if (this["idassetunload"]==DBNull.Value)return null; return  (Int32?)this["idassetunload"];}
		set {if (value==null) this["idassetunload"]= DBNull.Value; else this["idassetunload"]= value;}
	}
	public object idassetunloadValue { 
		get{ return this["idassetunload"];}
		set {if (value==null|| value==DBNull.Value) this["idassetunload"]= DBNull.Value; else this["idassetunload"]= value;}
	}
	public Int32? idassetunloadOriginal { 
		get {if (this["idassetunload",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idassetunload",DataRowVersion.Original];}
	}
	///<summary>
	///flag su tipo scarico
	///</summary>
	public Byte? flag{ 
		get {if (this["flag"]==DBNull.Value)return null; return  (Byte?)this["flag"];}
		set {if (value==null) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {if (value==null|| value==DBNull.Value) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public Byte? flagOriginal { 
		get {if (this["flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["flag",DataRowVersion.Original];}
	}
	///<summary>
	///id buono carico (tabella assetload)
	///</summary>
	public Int32? idassetload{ 
		get {if (this["idassetload"]==DBNull.Value)return null; return  (Int32?)this["idassetload"];}
		set {if (value==null) this["idassetload"]= DBNull.Value; else this["idassetload"]= value;}
	}
	public object idassetloadValue { 
		get{ return this["idassetload"];}
		set {if (value==null|| value==DBNull.Value) this["idassetload"]= DBNull.Value; else this["idassetload"]= value;}
	}
	public Int32? idassetloadOriginal { 
		get {if (this["idassetload",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idassetload",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Rivalutazione/Svalutazione
///</summary>
public class assetamortizationTable : MetaTableBase<assetamortizationRow> {
	public assetamortizationTable() : base("assetamortization"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("namortization")){ 
			defineColumn("namortization", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("adate")){ 
			defineColumn("adate", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("amortizationquota")){ 
			defineColumn("amortizationquota", typeof(System.Double));
		}
		if (definedColums.ContainsKey("assetvalue")){ 
			defineColumn("assetvalue", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("description")){ 
			defineColumn("description", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("idasset")){ 
			defineColumn("idasset", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("idpiece")){ 
			defineColumn("idpiece", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("rtf")){ 
			defineColumn("rtf", typeof(System.Byte[]));
		}
		if (definedColums.ContainsKey("txt")){ 
			defineColumn("txt", typeof(System.String));
		}
		if (definedColums.ContainsKey("transmitted")){ 
			defineColumn("transmitted", typeof(System.String));
		}
		if (definedColums.ContainsKey("idinventoryamortization")){ 
			defineColumn("idinventoryamortization", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("idassetunload")){ 
			defineColumn("idassetunload", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("flag")){ 
			defineColumn("flag", typeof(System.Byte),false);
		}
		if (definedColums.ContainsKey("idassetload")){ 
			defineColumn("idassetload", typeof(System.Int32));
		}
		#endregion

	}
}
}
