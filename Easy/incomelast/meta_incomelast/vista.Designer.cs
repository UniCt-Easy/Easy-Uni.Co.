/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace meta_incomelast {
public class incomelastRow: MetaRow  {
	public incomelastRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///id mov. entrata (tabella income)
	///</summary>
	public Int32? idinc{ 
		get {if (this["idinc"]==DBNull.Value)return null; return  (Int32?)this["idinc"];}
		set {if (value==null) this["idinc"]= DBNull.Value; else this["idinc"]= value;}
	}
	public object idincValue { 
		get{ return this["idinc"];}
		set {if (value==null|| value==DBNull.Value) this["idinc"]= DBNull.Value; else this["idinc"]= value;}
	}
	public Int32? idincOriginal { 
		get {if (this["idinc",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinc",DataRowVersion.Original];}
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
	///flag
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
	///n. sub per trasmissione in banca
	///</summary>
	public Int32? idpro{ 
		get {if (this["idpro"]==DBNull.Value)return null; return  (Int32?)this["idpro"];}
		set {if (value==null) this["idpro"]= DBNull.Value; else this["idpro"]= value;}
	}
	public object idproValue { 
		get{ return this["idpro"];}
		set {if (value==null|| value==DBNull.Value) this["idpro"]= DBNull.Value; else this["idpro"]= value;}
	}
	public Int32? idproOriginal { 
		get {if (this["idpro",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpro",DataRowVersion.Original];}
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
	///N.bolletta
	///</summary>
	public Int32? nbill{ 
		get {if (this["nbill"]==DBNull.Value)return null; return  (Int32?)this["nbill"];}
		set {if (value==null) this["nbill"]= DBNull.Value; else this["nbill"]= value;}
	}
	public object nbillValue { 
		get{ return this["nbill"];}
		set {if (value==null|| value==DBNull.Value) this["nbill"]= DBNull.Value; else this["nbill"]= value;}
	}
	public Int32? nbillOriginal { 
		get {if (this["nbill",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nbill",DataRowVersion.Original];}
	}
	///<summary>
	///chiave reversale (tabella proceeds)
	///</summary>
	public Int32? kpro{ 
		get {if (this["kpro"]==DBNull.Value)return null; return  (Int32?)this["kpro"];}
		set {if (value==null) this["kpro"]= DBNull.Value; else this["kpro"]= value;}
	}
	public object kproValue { 
		get{ return this["kpro"];}
		set {if (value==null|| value==DBNull.Value) this["kpro"]= DBNull.Value; else this["kpro"]= value;}
	}
	public Int32? kproOriginal { 
		get {if (this["kpro",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["kpro",DataRowVersion.Original];}
	}
	///<summary>
	///id conto credito (usato quando si trasmette la reversale)
	///</summary>
	public String idacccredit{ 
		get {if (this["idacccredit"]==DBNull.Value)return null; return  (String)this["idacccredit"];}
		set {if (value==null) this["idacccredit"]= DBNull.Value; else this["idacccredit"]= value;}
	}
	public object idacccreditValue { 
		get{ return this["idacccredit"];}
		set {if (value==null|| value==DBNull.Value) this["idacccredit"]= DBNull.Value; else this["idacccredit"]= value;}
	}
	public String idacccreditOriginal { 
		get {if (this["idacccredit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idacccredit",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Movimento di entrata - Dettaglio
///</summary>
public class incomelastTable : MetaTableBase<incomelastRow> {
	public incomelastTable() : base("incomelast"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("idinc")){ 
			defineColumn("idinc", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("flag")){ 
			defineColumn("flag", typeof(System.Byte),false);
		}
		if (definedColums.ContainsKey("idpro")){ 
			defineColumn("idpro", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("nbill")){ 
			defineColumn("nbill", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("kpro")){ 
			defineColumn("kpro", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idacccredit")){ 
			defineColumn("idacccredit", typeof(System.String));
		}
		#endregion

	}
}
}
