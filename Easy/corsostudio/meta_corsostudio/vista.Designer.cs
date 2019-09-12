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
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_corsostudio {
public class corsostudioRow: MetaRow  {
	public corsostudioRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Questionario Almalaurea
	///</summary>
	public String almalaureasurvey{ 
		get {if (this["almalaureasurvey"]==DBNull.Value)return null; return  (String)this["almalaureasurvey"];}
		set {if (value==null) this["almalaureasurvey"]= DBNull.Value; else this["almalaureasurvey"]= value;}
	}
	public object almalaureasurveyValue { 
		get{ return this["almalaureasurvey"];}
		set {if (value==null|| value==DBNull.Value) this["almalaureasurvey"]= DBNull.Value; else this["almalaureasurvey"]= value;}
	}
	public String almalaureasurveyOriginal { 
		get {if (this["almalaureasurvey",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["almalaureasurvey",DataRowVersion.Original];}
	}
	///<summary>
	///Anno accademico di istituzione
	///</summary>
	public Int32? annoistituz{ 
		get {if (this["annoistituz"]==DBNull.Value)return null; return  (Int32?)this["annoistituz"];}
		set {if (value==null) this["annoistituz"]= DBNull.Value; else this["annoistituz"]= value;}
	}
	public object annoistituzValue { 
		get{ return this["annoistituz"];}
		set {if (value==null|| value==DBNull.Value) this["annoistituz"]= DBNull.Value; else this["annoistituz"]= value;}
	}
	public Int32? annoistituzOriginal { 
		get {if (this["annoistituz",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["annoistituz",DataRowVersion.Original];}
	}
	///<summary>
	///Base del voto di conseguimento
	///</summary>
	public Int32? basevoto{ 
		get {if (this["basevoto"]==DBNull.Value)return null; return  (Int32?)this["basevoto"];}
		set {if (value==null) this["basevoto"]= DBNull.Value; else this["basevoto"]= value;}
	}
	public object basevotoValue { 
		get{ return this["basevoto"];}
		set {if (value==null|| value==DBNull.Value) this["basevoto"]= DBNull.Value; else this["basevoto"]= value;}
	}
	public Int32? basevotoOriginal { 
		get {if (this["basevoto",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["basevoto",DataRowVersion.Original];}
	}
	public String codice{ 
		get {if (this["codice"]==DBNull.Value)return null; return  (String)this["codice"];}
		set {if (value==null) this["codice"]= DBNull.Value; else this["codice"]= value;}
	}
	public object codiceValue { 
		get{ return this["codice"];}
		set {if (value==null|| value==DBNull.Value) this["codice"]= DBNull.Value; else this["codice"]= value;}
	}
	public String codiceOriginal { 
		get {if (this["codice",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codice",DataRowVersion.Original];}
	}
	///<summary>
	///Codice MIUR
	///</summary>
	public String codicemiur{ 
		get {if (this["codicemiur"]==DBNull.Value)return null; return  (String)this["codicemiur"];}
		set {if (value==null) this["codicemiur"]= DBNull.Value; else this["codicemiur"]= value;}
	}
	public object codicemiurValue { 
		get{ return this["codicemiur"];}
		set {if (value==null|| value==DBNull.Value) this["codicemiur"]= DBNull.Value; else this["codicemiur"]= value;}
	}
	public String codicemiurOriginal { 
		get {if (this["codicemiur",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicemiur",DataRowVersion.Original];}
	}
	///<summary>
	///Codice MIUR lungo
	///</summary>
	public String codicemiurlungo{ 
		get {if (this["codicemiurlungo"]==DBNull.Value)return null; return  (String)this["codicemiurlungo"];}
		set {if (value==null) this["codicemiurlungo"]= DBNull.Value; else this["codicemiurlungo"]= value;}
	}
	public object codicemiurlungoValue { 
		get{ return this["codicemiurlungo"];}
		set {if (value==null|| value==DBNull.Value) this["codicemiurlungo"]= DBNull.Value; else this["codicemiurlungo"]= value;}
	}
	public String codicemiurlungoOriginal { 
		get {if (this["codicemiurlungo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicemiurlungo",DataRowVersion.Original];}
	}
	public Int32? crediti{ 
		get {if (this["crediti"]==DBNull.Value)return null; return  (Int32?)this["crediti"];}
		set {if (value==null) this["crediti"]= DBNull.Value; else this["crediti"]= value;}
	}
	public object creditiValue { 
		get{ return this["crediti"];}
		set {if (value==null|| value==DBNull.Value) this["crediti"]= DBNull.Value; else this["crediti"]= value;}
	}
	public Int32? creditiOriginal { 
		get {if (this["crediti",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["crediti",DataRowVersion.Original];}
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
	public Int32? durata{ 
		get {if (this["durata"]==DBNull.Value)return null; return  (Int32?)this["durata"];}
		set {if (value==null) this["durata"]= DBNull.Value; else this["durata"]= value;}
	}
	public object durataValue { 
		get{ return this["durata"];}
		set {if (value==null|| value==DBNull.Value) this["durata"]= DBNull.Value; else this["durata"]= value;}
	}
	public Int32? durataOriginal { 
		get {if (this["durata",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["durata",DataRowVersion.Original];}
	}
	public Int32? idcorsostudio{ 
		get {if (this["idcorsostudio"]==DBNull.Value)return null; return  (Int32?)this["idcorsostudio"];}
		set {if (value==null) this["idcorsostudio"]= DBNull.Value; else this["idcorsostudio"]= value;}
	}
	public object idcorsostudioValue { 
		get{ return this["idcorsostudio"];}
		set {if (value==null|| value==DBNull.Value) this["idcorsostudio"]= DBNull.Value; else this["idcorsostudio"]= value;}
	}
	public Int32? idcorsostudioOriginal { 
		get {if (this["idcorsostudio",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcorsostudio",DataRowVersion.Original];}
	}
	///<summary>
	///Tipologia
	///</summary>
	public Int32? idcorsostudiokind{ 
		get {if (this["idcorsostudiokind"]==DBNull.Value)return null; return  (Int32?)this["idcorsostudiokind"];}
		set {if (value==null) this["idcorsostudiokind"]= DBNull.Value; else this["idcorsostudiokind"]= value;}
	}
	public object idcorsostudiokindValue { 
		get{ return this["idcorsostudiokind"];}
		set {if (value==null|| value==DBNull.Value) this["idcorsostudiokind"]= DBNull.Value; else this["idcorsostudiokind"]= value;}
	}
	public Int32? idcorsostudiokindOriginal { 
		get {if (this["idcorsostudiokind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcorsostudiokind",DataRowVersion.Original];}
	}
	///<summary>
	///Livello
	///</summary>
	public Int32? idcorsostudiolivello{ 
		get {if (this["idcorsostudiolivello"]==DBNull.Value)return null; return  (Int32?)this["idcorsostudiolivello"];}
		set {if (value==null) this["idcorsostudiolivello"]= DBNull.Value; else this["idcorsostudiolivello"]= value;}
	}
	public object idcorsostudiolivelloValue { 
		get{ return this["idcorsostudiolivello"];}
		set {if (value==null|| value==DBNull.Value) this["idcorsostudiolivello"]= DBNull.Value; else this["idcorsostudiolivello"]= value;}
	}
	public Int32? idcorsostudiolivelloOriginal { 
		get {if (this["idcorsostudiolivello",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcorsostudiolivello",DataRowVersion.Original];}
	}
	///<summary>
	///Normativa di riferimento
	///</summary>
	public Int32? idcorsostudionorma{ 
		get {if (this["idcorsostudionorma"]==DBNull.Value)return null; return  (Int32?)this["idcorsostudionorma"];}
		set {if (value==null) this["idcorsostudionorma"]= DBNull.Value; else this["idcorsostudionorma"]= value;}
	}
	public object idcorsostudionormaValue { 
		get{ return this["idcorsostudionorma"];}
		set {if (value==null|| value==DBNull.Value) this["idcorsostudionorma"]= DBNull.Value; else this["idcorsostudionorma"]= value;}
	}
	public Int32? idcorsostudionormaOriginal { 
		get {if (this["idcorsostudionorma",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcorsostudionorma",DataRowVersion.Original];}
	}
	///<summary>
	///Tipologia della durata
	///</summary>
	public Int32? idduratakind{ 
		get {if (this["idduratakind"]==DBNull.Value)return null; return  (Int32?)this["idduratakind"];}
		set {if (value==null) this["idduratakind"]= DBNull.Value; else this["idduratakind"]= value;}
	}
	public object idduratakindValue { 
		get{ return this["idduratakind"];}
		set {if (value==null|| value==DBNull.Value) this["idduratakind"]= DBNull.Value; else this["idduratakind"]= value;}
	}
	public Int32? idduratakindOriginal { 
		get {if (this["idduratakind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idduratakind",DataRowVersion.Original];}
	}
	///<summary>
	///Struttura di riferimento
	///</summary>
	public Int32? idlocation_struttura{ 
		get {if (this["idlocation_struttura"]==DBNull.Value)return null; return  (Int32?)this["idlocation_struttura"];}
		set {if (value==null) this["idlocation_struttura"]= DBNull.Value; else this["idlocation_struttura"]= value;}
	}
	public object idlocation_strutturaValue { 
		get{ return this["idlocation_struttura"];}
		set {if (value==null|| value==DBNull.Value) this["idlocation_struttura"]= DBNull.Value; else this["idlocation_struttura"]= value;}
	}
	public Int32? idlocation_strutturaOriginal { 
		get {if (this["idlocation_struttura",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idlocation_struttura",DataRowVersion.Original];}
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
	///<summary>
	///Obiettivi formativi
	///</summary>
	public String obbform{ 
		get {if (this["obbform"]==DBNull.Value)return null; return  (String)this["obbform"];}
		set {if (value==null) this["obbform"]= DBNull.Value; else this["obbform"]= value;}
	}
	public object obbformValue { 
		get{ return this["obbform"];}
		set {if (value==null|| value==DBNull.Value) this["obbform"]= DBNull.Value; else this["obbform"]= value;}
	}
	public String obbformOriginal { 
		get {if (this["obbform",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["obbform",DataRowVersion.Original];}
	}
	///<summary>
	///Sbocchi occupazionali
	///</summary>
	public String sboccocc{ 
		get {if (this["sboccocc"]==DBNull.Value)return null; return  (String)this["sboccocc"];}
		set {if (value==null) this["sboccocc"]= DBNull.Value; else this["sboccocc"]= value;}
	}
	public object sboccoccValue { 
		get{ return this["sboccocc"];}
		set {if (value==null|| value==DBNull.Value) this["sboccocc"]= DBNull.Value; else this["sboccocc"]= value;}
	}
	public String sboccoccOriginal { 
		get {if (this["sboccocc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["sboccocc",DataRowVersion.Original];}
	}
	///<summary>
	///Denominazione
	///</summary>
	public String title{ 
		get {if (this["title"]==DBNull.Value)return null; return  (String)this["title"];}
		set {if (value==null) this["title"]= DBNull.Value; else this["title"]= value;}
	}
	public object titleValue { 
		get{ return this["title"];}
		set {if (value==null|| value==DBNull.Value) this["title"]= DBNull.Value; else this["title"]= value;}
	}
	public String titleOriginal { 
		get {if (this["title",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["title",DataRowVersion.Original];}
	}
	///<summary>
	///Denominazione (EN)
	///</summary>
	public String title_en{ 
		get {if (this["title_en"]==DBNull.Value)return null; return  (String)this["title_en"];}
		set {if (value==null) this["title_en"]= DBNull.Value; else this["title_en"]= value;}
	}
	public object title_enValue { 
		get{ return this["title_en"];}
		set {if (value==null|| value==DBNull.Value) this["title_en"]= DBNull.Value; else this["title_en"]= value;}
	}
	public String title_enOriginal { 
		get {if (this["title_en",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["title_en",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///2.4.2 Corso di studio
///</summary>
public class corsostudioTable : MetaTableBase<corsostudioRow> {
	public corsostudioTable() : base("corsostudio"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"almalaureasurvey",createColumn("almalaureasurvey",typeof(string),true,false)},
			{"annoistituz",createColumn("annoistituz",typeof(int),true,false)},
			{"basevoto",createColumn("basevoto",typeof(int),true,false)},
			{"codice",createColumn("codice",typeof(string),true,false)},
			{"codicemiur",createColumn("codicemiur",typeof(string),true,false)},
			{"codicemiurlungo",createColumn("codicemiurlungo",typeof(string),true,false)},
			{"crediti",createColumn("crediti",typeof(int),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"durata",createColumn("durata",typeof(int),true,false)},
			{"idcorsostudio",createColumn("idcorsostudio",typeof(int),false,false)},
			{"idcorsostudiokind",createColumn("idcorsostudiokind",typeof(int),false,false)},
			{"idcorsostudiolivello",createColumn("idcorsostudiolivello",typeof(int),true,false)},
			{"idcorsostudionorma",createColumn("idcorsostudionorma",typeof(int),true,false)},
			{"idduratakind",createColumn("idduratakind",typeof(int),true,false)},
			{"idlocation_struttura",createColumn("idlocation_struttura",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"obbform",createColumn("obbform",typeof(string),true,false)},
			{"sboccocc",createColumn("sboccocc",typeof(string),true,false)},
			{"title",createColumn("title",typeof(string),true,false)},
			{"title_en",createColumn("title_en",typeof(string),true,false)},
		};
	}
}
}
