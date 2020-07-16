/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
namespace meta_ivakind {
public class ivakindRow: MetaRow  {
	public ivakindRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///aliquota
	///</summary>
	public Decimal? rate{ 
		get {if (this["rate"]==DBNull.Value)return null; return  (Decimal?)this["rate"];}
		set {if (value==null) this["rate"]= DBNull.Value; else this["rate"]= value;}
	}
	public object rateValue { 
		get{ return this["rate"];}
		set {if (value==null|| value==DBNull.Value) this["rate"]= DBNull.Value; else this["rate"]= value;}
	}
	public Decimal? rateOriginal { 
		get {if (this["rate",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["rate",DataRowVersion.Original];}
	}
	///<summary>
	///Indetraibilità
	///</summary>
	public Decimal? unabatabilitypercentage{ 
		get {if (this["unabatabilitypercentage"]==DBNull.Value)return null; return  (Decimal?)this["unabatabilitypercentage"];}
		set {if (value==null) this["unabatabilitypercentage"]= DBNull.Value; else this["unabatabilitypercentage"]= value;}
	}
	public object unabatabilitypercentageValue { 
		get{ return this["unabatabilitypercentage"];}
		set {if (value==null|| value==DBNull.Value) this["unabatabilitypercentage"]= DBNull.Value; else this["unabatabilitypercentage"]= value;}
	}
	public Decimal? unabatabilitypercentageOriginal { 
		get {if (this["unabatabilitypercentage",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["unabatabilitypercentage",DataRowVersion.Original];}
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
	///ID Tipo imponibile iva (tabella ivataxablekind)
	///</summary>
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
	///<summary>
	///id tipo iva (tabella ivakind)
	///</summary>
	public Int32? idivakind{ 
		get {if (this["idivakind"]==DBNull.Value)return null; return  (Int32?)this["idivakind"];}
		set {if (value==null) this["idivakind"]= DBNull.Value; else this["idivakind"]= value;}
	}
	public object idivakindValue { 
		get{ return this["idivakind"];}
		set {if (value==null|| value==DBNull.Value) this["idivakind"]= DBNull.Value; else this["idivakind"]= value;}
	}
	public Int32? idivakindOriginal { 
		get {if (this["idivakind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idivakind",DataRowVersion.Original];}
	}
	///<summary>
	///Codice
	///</summary>
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
	///<summary>
	///flag
	///</summary>
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
	///<summary>
	///Annotazioni
	///</summary>
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
	///<summary>
	///ID Natura Fattura elettronica (tabella fenature)
	///</summary>
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
///<summary>
///Elenco aliquote
///</summary>
public class ivakindTable : MetaTableBase<ivakindRow> {
	public ivakindTable() : base("ivakind"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("description")){ 
			defineColumn("description", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("rate")){ 
			defineColumn("rate", typeof(System.Decimal),false);
		}
		if (definedColums.ContainsKey("unabatabilitypercentage")){ 
			defineColumn("unabatabilitypercentage", typeof(System.Decimal),false);
		}
		if (definedColums.ContainsKey("active")){ 
			defineColumn("active", typeof(System.String));
		}
		if (definedColums.ContainsKey("idivataxablekind")){ 
			defineColumn("idivataxablekind", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idivakind")){ 
			defineColumn("idivakind", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("codeivakind")){ 
			defineColumn("codeivakind", typeof(System.String));
		}
		if (definedColums.ContainsKey("flag")){ 
			defineColumn("flag", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("annotations")){ 
			defineColumn("annotations", typeof(System.String));
		}
		if (definedColums.ContainsKey("idfenature")){ 
			defineColumn("idfenature", typeof(System.String));
		}
		#endregion

	}
}
}
