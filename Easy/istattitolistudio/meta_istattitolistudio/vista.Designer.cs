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
namespace meta_istattitolistudio {
public class istattitolistudioRow: MetaRow  {
	public istattitolistudioRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Codice tipo di scuola/istituto, gruppo di corsi accademici
	///</summary>
	public String codiceistitutogruppo{ 
		get {if (this["codiceistitutogruppo"]==DBNull.Value)return null; return  (String)this["codiceistitutogruppo"];}
		set {if (value==null) this["codiceistitutogruppo"]= DBNull.Value; else this["codiceistitutogruppo"]= value;}
	}
	public object codiceistitutogruppoValue { 
		get{ return this["codiceistitutogruppo"];}
		set {if (value==null|| value==DBNull.Value) this["codiceistitutogruppo"]= DBNull.Value; else this["codiceistitutogruppo"]= value;}
	}
	public String codiceistitutogruppoOriginal { 
		get {if (this["codiceistitutogruppo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codiceistitutogruppo",DataRowVersion.Original];}
	}
	///<summary>
	///Codice livello
	///</summary>
	public Int32? codicelivello{ 
		get {if (this["codicelivello"]==DBNull.Value)return null; return  (Int32?)this["codicelivello"];}
		set {if (value==null) this["codicelivello"]= DBNull.Value; else this["codicelivello"]= value;}
	}
	public object codicelivelloValue { 
		get{ return this["codicelivello"];}
		set {if (value==null|| value==DBNull.Value) this["codicelivello"]= DBNull.Value; else this["codicelivello"]= value;}
	}
	public Int32? codicelivelloOriginal { 
		get {if (this["codicelivello",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["codicelivello",DataRowVersion.Original];}
	}
	///<summary>
	///Codice specializzazione scolastica/post-scolastica, corso accademico
	///</summary>
	public String codicespecializcorso{ 
		get {if (this["codicespecializcorso"]==DBNull.Value)return null; return  (String)this["codicespecializcorso"];}
		set {if (value==null) this["codicespecializcorso"]= DBNull.Value; else this["codicespecializcorso"]= value;}
	}
	public object codicespecializcorsoValue { 
		get{ return this["codicespecializcorso"];}
		set {if (value==null|| value==DBNull.Value) this["codicespecializcorso"]= DBNull.Value; else this["codicespecializcorso"]= value;}
	}
	public String codicespecializcorsoOriginal { 
		get {if (this["codicespecializcorso",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicespecializcorso",DataRowVersion.Original];}
	}
	///<summary>
	///Codice
	///</summary>
	public Int32? idistattitolistudio{ 
		get {if (this["idistattitolistudio"]==DBNull.Value)return null; return  (Int32?)this["idistattitolistudio"];}
		set {if (value==null) this["idistattitolistudio"]= DBNull.Value; else this["idistattitolistudio"]= value;}
	}
	public object idistattitolistudioValue { 
		get{ return this["idistattitolistudio"];}
		set {if (value==null|| value==DBNull.Value) this["idistattitolistudio"]= DBNull.Value; else this["idistattitolistudio"]= value;}
	}
	public Int32? idistattitolistudioOriginal { 
		get {if (this["idistattitolistudio",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idistattitolistudio",DataRowVersion.Original];}
	}
	///<summary>
	///ISCED 97 - Field of study
	///</summary>
	public String isced97field{ 
		get {if (this["isced97field"]==DBNull.Value)return null; return  (String)this["isced97field"];}
		set {if (value==null) this["isced97field"]= DBNull.Value; else this["isced97field"]= value;}
	}
	public object isced97fieldValue { 
		get{ return this["isced97field"];}
		set {if (value==null|| value==DBNull.Value) this["isced97field"]= DBNull.Value; else this["isced97field"]= value;}
	}
	public String isced97fieldOriginal { 
		get {if (this["isced97field",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["isced97field",DataRowVersion.Original];}
	}
	///<summary>
	///ISCED 97 - Level and program destination
	///</summary>
	public String isced97level{ 
		get {if (this["isced97level"]==DBNull.Value)return null; return  (String)this["isced97level"];}
		set {if (value==null) this["isced97level"]= DBNull.Value; else this["isced97level"]= value;}
	}
	public object isced97levelValue { 
		get{ return this["isced97level"];}
		set {if (value==null|| value==DBNull.Value) this["isced97level"]= DBNull.Value; else this["isced97level"]= value;}
	}
	public String isced97levelOriginal { 
		get {if (this["isced97level",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["isced97level",DataRowVersion.Original];}
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
	public String sinonimi{ 
		get {if (this["sinonimi"]==DBNull.Value)return null; return  (String)this["sinonimi"];}
		set {if (value==null) this["sinonimi"]= DBNull.Value; else this["sinonimi"]= value;}
	}
	public object sinonimiValue { 
		get{ return this["sinonimi"];}
		set {if (value==null|| value==DBNull.Value) this["sinonimi"]= DBNull.Value; else this["sinonimi"]= value;}
	}
	public String sinonimiOriginal { 
		get {if (this["sinonimi",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["sinonimi",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo di scuola/istituto, Corso/classe di corsi accademici
	///</summary>
	public String tipo{ 
		get {if (this["tipo"]==DBNull.Value)return null; return  (String)this["tipo"];}
		set {if (value==null) this["tipo"]= DBNull.Value; else this["tipo"]= value;}
	}
	public object tipoValue { 
		get{ return this["tipo"];}
		set {if (value==null|| value==DBNull.Value) this["tipo"]= DBNull.Value; else this["tipo"]= value;}
	}
	public String tipoOriginal { 
		get {if (this["tipo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tipo",DataRowVersion.Original];}
	}
	///<summary>
	///Titolo di studio
	///</summary>
	public String titolo{ 
		get {if (this["titolo"]==DBNull.Value)return null; return  (String)this["titolo"];}
		set {if (value==null) this["titolo"]= DBNull.Value; else this["titolo"]= value;}
	}
	public object titoloValue { 
		get{ return this["titolo"];}
		set {if (value==null|| value==DBNull.Value) this["titolo"]= DBNull.Value; else this["titolo"]= value;}
	}
	public String titoloOriginal { 
		get {if (this["titolo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["titolo",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///VOCABOLARIO classificazione ISTAT dei 2.6.5 titoli di studio
///</summary>
public class istattitolistudioTable : MetaTableBase<istattitolistudioRow> {
	public istattitolistudioTable() : base("istattitolistudio"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"codiceistitutogruppo",createColumn("codiceistitutogruppo",typeof(string),false,false)},
			{"codicelivello",createColumn("codicelivello",typeof(int),false,false)},
			{"codicespecializcorso",createColumn("codicespecializcorso",typeof(string),false,false)},
			{"idistattitolistudio",createColumn("idistattitolistudio",typeof(int),false,false)},
			{"isced97field",createColumn("isced97field",typeof(string),false,false)},
			{"isced97level",createColumn("isced97level",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"sinonimi",createColumn("sinonimi",typeof(string),false,false)},
			{"tipo",createColumn("tipo",typeof(string),false,false)},
			{"titolo",createColumn("titolo",typeof(string),false,false)},
		};
	}
}
}
