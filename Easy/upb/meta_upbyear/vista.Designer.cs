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
namespace meta_upbyear {
public class upbyearRow: MetaRow  {
	public upbyearRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///id voce upb (tabella upb)
	///</summary>
	public String idupb{ 
		get {if (this["idupb"]==DBNull.Value)return null; return  (String)this["idupb"];}
		set {if (value==null) this["idupb"]= DBNull.Value; else this["idupb"]= value;}
	}
	public object idupbValue { 
		get{ return this["idupb"];}
		set {if (value==null|| value==DBNull.Value) this["idupb"]= DBNull.Value; else this["idupb"]= value;}
	}
	public String idupbOriginal { 
		get {if (this["idupb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idupb",DataRowVersion.Original];}
	}
	///<summary>
	///esercizio
	///</summary>
	public Int16? ayear{ 
		get {if (this["ayear"]==DBNull.Value)return null; return  (Int16?)this["ayear"];}
		set {if (value==null) this["ayear"]= DBNull.Value; else this["ayear"]= value;}
	}
	public object ayearValue { 
		get{ return this["ayear"];}
		set {if (value==null|| value==DBNull.Value) this["ayear"]= DBNull.Value; else this["ayear"]= value;}
	}
	public Int16? ayearOriginal { 
		get {if (this["ayear",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["ayear",DataRowVersion.Original];}
	}
	///<summary>
	///Ricavi Presunti
	///</summary>
	public Decimal? revenueprevision{ 
		get {if (this["revenueprevision"]==DBNull.Value)return null; return  (Decimal?)this["revenueprevision"];}
		set {if (value==null) this["revenueprevision"]= DBNull.Value; else this["revenueprevision"]= value;}
	}
	public object revenueprevisionValue { 
		get{ return this["revenueprevision"];}
		set {if (value==null|| value==DBNull.Value) this["revenueprevision"]= DBNull.Value; else this["revenueprevision"]= value;}
	}
	public Decimal? revenueprevisionOriginal { 
		get {if (this["revenueprevision",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["revenueprevision",DataRowVersion.Original];}
	}
	///<summary>
	///Costi Presunti
	///</summary>
	public Decimal? costprevision{ 
		get {if (this["costprevision"]==DBNull.Value)return null; return  (Decimal?)this["costprevision"];}
		set {if (value==null) this["costprevision"]= DBNull.Value; else this["costprevision"]= value;}
	}
	public object costprevisionValue { 
		get{ return this["costprevision"];}
		set {if (value==null|| value==DBNull.Value) this["costprevision"]= DBNull.Value; else this["costprevision"]= value;}
	}
	public Decimal? costprevisionOriginal { 
		get {if (this["costprevision",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["costprevision",DataRowVersion.Original];}
	}
	///<summary>
	///Blocco selettivo delle operazioni contabili sull'UPB
	///</summary>
	public Int32? locked{ 
		get {if (this["locked"]==DBNull.Value)return null; return  (Int32?)this["locked"];}
		set {if (value==null) this["locked"]= DBNull.Value; else this["locked"]= value;}
	}
	public object lockedValue { 
		get{ return this["locked"];}
		set {if (value==null|| value==DBNull.Value) this["locked"]= DBNull.Value; else this["locked"]= value;}
	}
	public Int32? lockedOriginal { 
		get {if (this["locked",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["locked",DataRowVersion.Original];}
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
	#endregion

}
public class upbyearTable : MetaTableBase<upbyearRow> {
	public upbyearTable() : base("upbyear"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("idupb")){ 
			defineColumn("idupb", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("ayear")){ 
			defineColumn("ayear", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("revenueprevision")){ 
			defineColumn("revenueprevision", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("costprevision")){ 
			defineColumn("costprevision", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("locked")){ 
			defineColumn("locked", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String));
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String));
		}
		#endregion

	}
}
}
