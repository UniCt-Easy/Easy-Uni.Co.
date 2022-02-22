
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
namespace meta_bill {
public class billRow: MetaRow  {
	public billRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Esercizio
	///</summary>
	public Int16? ybill{ 
		get {if (this["ybill"]==DBNull.Value)return null; return  (Int16?)this["ybill"];}
		set {if (value==null) this["ybill"]= DBNull.Value; else this["ybill"]= value;}
	}
	public object ybillValue { 
		get{ return this["ybill"];}
		set {if (value==null|| value==DBNull.Value) this["ybill"]= DBNull.Value; else this["ybill"]= value;}
	}
	public Int16? ybillOriginal { 
		get {if (this["ybill",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["ybill",DataRowVersion.Original];}
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
	///Tipo
	///	 C: Credito
	///	 D: Debito
	///</summary>
	public String billkind{ 
		get {if (this["billkind"]==DBNull.Value)return null; return  (String)this["billkind"];}
		set {if (value==null) this["billkind"]= DBNull.Value; else this["billkind"]= value;}
	}
	public object billkindValue { 
		get{ return this["billkind"];}
		set {if (value==null|| value==DBNull.Value) this["billkind"]= DBNull.Value; else this["billkind"]= value;}
	}
	public String billkindOriginal { 
		get {if (this["billkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["billkind",DataRowVersion.Original];}
	}
	///<summary>
	///anagrafica
	///</summary>
	public String registry{ 
		get {if (this["registry"]==DBNull.Value)return null; return  (String)this["registry"];}
		set {if (value==null) this["registry"]= DBNull.Value; else this["registry"]= value;}
	}
	public object registryValue { 
		get{ return this["registry"];}
		set {if (value==null|| value==DBNull.Value) this["registry"]= DBNull.Value; else this["registry"]= value;}
	}
	public String registryOriginal { 
		get {if (this["registry",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["registry",DataRowVersion.Original];}
	}
	///<summary>
	///Importo Coperto
	///</summary>
	public Decimal? covered{ 
		get {if (this["covered"]==DBNull.Value)return null; return  (Decimal?)this["covered"];}
		set {if (value==null) this["covered"]= DBNull.Value; else this["covered"]= value;}
	}
	public object coveredValue { 
		get{ return this["covered"];}
		set {if (value==null|| value==DBNull.Value) this["covered"]= DBNull.Value; else this["covered"]= value;}
	}
	public Decimal? coveredOriginal { 
		get {if (this["covered",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["covered",DataRowVersion.Original];}
	}
	///<summary>
	///Totale
	///</summary>
	public Decimal? total{ 
		get {if (this["total"]==DBNull.Value)return null; return  (Decimal?)this["total"];}
		set {if (value==null) this["total"]= DBNull.Value; else this["total"]= value;}
	}
	public object totalValue { 
		get{ return this["total"];}
		set {if (value==null|| value==DBNull.Value) this["total"]= DBNull.Value; else this["total"]= value;}
	}
	public Decimal? totalOriginal { 
		get {if (this["total",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["total",DataRowVersion.Original];}
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
	///attivo
	///</summary>
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
	///<summary>
	///Causale (descrizione)
	///</summary>
	public String motive{ 
		get {if (this["motive"]==DBNull.Value)return null; return  (String)this["motive"];}
		set {if (value==null) this["motive"]= DBNull.Value; else this["motive"]= value;}
	}
	public object motiveValue { 
		get{ return this["motive"];}
		set {if (value==null|| value==DBNull.Value) this["motive"]= DBNull.Value; else this["motive"]= value;}
	}
	public String motiveOriginal { 
		get {if (this["motive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["motive",DataRowVersion.Original];}
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
	///Id cassiere (tabella treasurer)
	///</summary>
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
	///<summary>
	///Note
	///</summary>
	public String regularizationnote{ 
		get {if (this["regularizationnote"]==DBNull.Value)return null; return  (String)this["regularizationnote"];}
		set {if (value==null) this["regularizationnote"]= DBNull.Value; else this["regularizationnote"]= value;}
	}
	public object regularizationnoteValue { 
		get{ return this["regularizationnote"];}
		set {if (value==null|| value==DBNull.Value) this["regularizationnote"]= DBNull.Value; else this["regularizationnote"]= value;}
	}
	public String regularizationnoteOriginal { 
		get {if (this["regularizationnote",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["regularizationnote",DataRowVersion.Original];}
	}
	///<summary>
	///Storni
	///</summary>
	public Decimal? reduction{ 
		get {if (this["reduction"]==DBNull.Value)return null; return  (Decimal?)this["reduction"];}
		set {if (value==null) this["reduction"]= DBNull.Value; else this["reduction"]= value;}
	}
	public object reductionValue { 
		get{ return this["reduction"];}
		set {if (value==null|| value==DBNull.Value) this["reduction"]= DBNull.Value; else this["reduction"]= value;}
	}
	public Decimal? reductionOriginal { 
		get {if (this["reduction",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["reduction",DataRowVersion.Original];}
	}
	///<summary>
	///non usato
	///</summary>
	public Int32? banknum{ 
		get {if (this["banknum"]==DBNull.Value)return null; return  (Int32?)this["banknum"];}
		set {if (value==null) this["banknum"]= DBNull.Value; else this["banknum"]= value;}
	}
	public object banknumValue { 
		get{ return this["banknum"];}
		set {if (value==null|| value==DBNull.Value) this["banknum"]= DBNull.Value; else this["banknum"]= value;}
	}
	public Int32? banknumOriginal { 
		get {if (this["banknum",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["banknum",DataRowVersion.Original];}
	}
	///<summary>
	///ABI
	///</summary>
	public String idbank{ 
		get {if (this["idbank"]==DBNull.Value)return null; return  (String)this["idbank"];}
		set {if (value==null) this["idbank"]= DBNull.Value; else this["idbank"]= value;}
	}
	public object idbankValue { 
		get{ return this["idbank"];}
		set {if (value==null|| value==DBNull.Value) this["idbank"]= DBNull.Value; else this["idbank"]= value;}
	}
	public String idbankOriginal { 
		get {if (this["idbank",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idbank",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Partita pendente
///</summary>
public class billTable : MetaTableBase<billRow> {
	public billTable() : base("bill"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("ybill")){ 
			defineColumn("ybill", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("nbill")){ 
			defineColumn("nbill", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("billkind")){ 
			defineColumn("billkind", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("registry")){ 
			defineColumn("registry", typeof(System.String));
		}
		if (definedColums.ContainsKey("covered")){ 
			defineColumn("covered", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("total")){ 
			defineColumn("total", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("adate")){ 
			defineColumn("adate", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("active")){ 
			defineColumn("active", typeof(System.String));
		}
		if (definedColums.ContainsKey("motive")){ 
			defineColumn("motive", typeof(System.String));
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("idtreasurer")){ 
			defineColumn("idtreasurer", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("regularizationnote")){ 
			defineColumn("regularizationnote", typeof(System.String));
		}
		if (definedColums.ContainsKey("reduction")){ 
			defineColumn("reduction", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("banknum")){ 
			defineColumn("banknum", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idbank")){ 
			defineColumn("idbank", typeof(System.String));
		}
		#endregion

	}
}
}
