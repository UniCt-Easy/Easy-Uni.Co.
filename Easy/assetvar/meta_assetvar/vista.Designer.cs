
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
using metadatalibrary;
namespace meta_assetvar {
public class assetvarRow: MetaRow  {
	public assetvarRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///N. variazione
	///</summary>
	public Int32? nvar{ 
		get {if (this["nvar"]==DBNull.Value)return null; return  (Int32?)this["nvar"];}
		set {if (value==null) this["nvar"]= DBNull.Value; else this["nvar"]= value;}
	}
	public object nvarValue { 
		get{ return this["nvar"];}
		set {if (value==null|| value==DBNull.Value) this["nvar"]= DBNull.Value; else this["nvar"]= value;}
	}
	public Int32? nvarOriginal { 
		get {if (this["nvar",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nvar",DataRowVersion.Original];}
	}
	///<summary>
	///Anno variazione
	///</summary>
	public Int16? yvar{ 
		get {if (this["yvar"]==DBNull.Value)return null; return  (Int16?)this["yvar"];}
		set {if (value==null) this["yvar"]= DBNull.Value; else this["yvar"]= value;}
	}
	public object yvarValue { 
		get{ return this["yvar"];}
		set {if (value==null|| value==DBNull.Value) this["yvar"]= DBNull.Value; else this["yvar"]= value;}
	}
	public Int16? yvarOriginal { 
		get {if (this["yvar",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["yvar",DataRowVersion.Original];}
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
	///Provvedimento
	///</summary>
	public String enactment{ 
		get {if (this["enactment"]==DBNull.Value)return null; return  (String)this["enactment"];}
		set {if (value==null) this["enactment"]= DBNull.Value; else this["enactment"]= value;}
	}
	public object enactmentValue { 
		get{ return this["enactment"];}
		set {if (value==null|| value==DBNull.Value) this["enactment"]= DBNull.Value; else this["enactment"]= value;}
	}
	public String enactmentOriginal { 
		get {if (this["enactment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["enactment",DataRowVersion.Original];}
	}
	///<summary>
	///Data provv.
	///</summary>
	public DateTime? enactmentdate{ 
		get {if (this["enactmentdate"]==DBNull.Value)return null; return  (DateTime?)this["enactmentdate"];}
		set {if (value==null) this["enactmentdate"]= DBNull.Value; else this["enactmentdate"]= value;}
	}
	public object enactmentdateValue { 
		get{ return this["enactmentdate"];}
		set {if (value==null|| value==DBNull.Value) this["enactmentdate"]= DBNull.Value; else this["enactmentdate"]= value;}
	}
	public DateTime? enactmentdateOriginal { 
		get {if (this["enactmentdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["enactmentdate",DataRowVersion.Original];}
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
	///Num. provv.
	///</summary>
	public String nenactment{ 
		get {if (this["nenactment"]==DBNull.Value)return null; return  (String)this["nenactment"];}
		set {if (value==null) this["nenactment"]= DBNull.Value; else this["nenactment"]= value;}
	}
	public object nenactmentValue { 
		get{ return this["nenactment"];}
		set {if (value==null|| value==DBNull.Value) this["nenactment"]= DBNull.Value; else this["nenactment"]= value;}
	}
	public String nenactmentOriginal { 
		get {if (this["nenactment",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["nenactment",DataRowVersion.Original];}
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
	///id ente inventariale (tabella inventoryagency)
	///</summary>
	public Int32? idinventoryagency{ 
		get {if (this["idinventoryagency"]==DBNull.Value)return null; return  (Int32?)this["idinventoryagency"];}
		set {if (value==null) this["idinventoryagency"]= DBNull.Value; else this["idinventoryagency"]= value;}
	}
	public object idinventoryagencyValue { 
		get{ return this["idinventoryagency"];}
		set {if (value==null|| value==DBNull.Value) this["idinventoryagency"]= DBNull.Value; else this["idinventoryagency"]= value;}
	}
	public Int32? idinventoryagencyOriginal { 
		get {if (this["idinventoryagency",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinventoryagency",DataRowVersion.Original];}
	}
	///<summary>
	///#
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
	///flag (Variazione normale)
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
	#endregion

}
///<summary>
///Variazione Patrimoniale
///</summary>
public class assetvarTable : MetaTableBase<assetvarRow> {
	public assetvarTable() : base("assetvar"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("nvar")){ 
			defineColumn("nvar", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("yvar")){ 
			defineColumn("yvar", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("adate")){ 
			defineColumn("adate", typeof(System.DateTime),false);
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
		if (definedColums.ContainsKey("enactment")){ 
			defineColumn("enactment", typeof(System.String));
		}
		if (definedColums.ContainsKey("enactmentdate")){ 
			defineColumn("enactmentdate", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("nenactment")){ 
			defineColumn("nenactment", typeof(System.String));
		}
		if (definedColums.ContainsKey("rtf")){ 
			defineColumn("rtf", typeof(System.Byte[]));
		}
		if (definedColums.ContainsKey("txt")){ 
			defineColumn("txt", typeof(System.String));
		}
		if (definedColums.ContainsKey("idinventoryagency")){ 
			defineColumn("idinventoryagency", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("idassetvar")){ 
			defineColumn("idassetvar", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("flag")){ 
			defineColumn("flag", typeof(System.Byte),false);
		}
		#endregion

	}
}
}
