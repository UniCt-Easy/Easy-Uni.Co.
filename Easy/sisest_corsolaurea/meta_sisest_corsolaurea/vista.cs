
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
namespace meta_sisest_corsolaurea {
public class sisest_corsolaureaRow: MetaRow  {
	public sisest_corsolaureaRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32? idcorsolaurea{ 
		get {if (this["idcorsolaurea"]==DBNull.Value)return null; return  (Int32?)this["idcorsolaurea"];}
		set {if (value==null) this["idcorsolaurea"]= DBNull.Value; else this["idcorsolaurea"]= value;}
	}
	public object idcorsolaureaValue { 
		get{ return this["idcorsolaurea"];}
		set {if (value==null|| value==DBNull.Value) this["idcorsolaurea"]= DBNull.Value; else this["idcorsolaurea"]= value;}
	}
	public Int32? idcorsolaureaOriginal { 
		get {if (this["idcorsolaurea",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcorsolaurea",DataRowVersion.Original];}
	}
	public String descrizione{ 
		get {if (this["descrizione"]==DBNull.Value)return null; return  (String)this["descrizione"];}
		set {if (value==null) this["descrizione"]= DBNull.Value; else this["descrizione"]= value;}
	}
	public object descrizioneValue { 
		get{ return this["descrizione"];}
		set {if (value==null|| value==DBNull.Value) this["descrizione"]= DBNull.Value; else this["descrizione"]= value;}
	}
	public String descrizioneOriginal { 
		get {if (this["descrizione",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["descrizione",DataRowVersion.Original];}
	}
	public String codicecorso{ 
		get {if (this["codicecorso"]==DBNull.Value)return null; return  (String)this["codicecorso"];}
		set {if (value==null) this["codicecorso"]= DBNull.Value; else this["codicecorso"]= value;}
	}
	public object codicecorsoValue { 
		get{ return this["codicecorso"];}
		set {if (value==null|| value==DBNull.Value) this["codicecorso"]= DBNull.Value; else this["codicecorso"]= value;}
	}
	public String codicecorsoOriginal { 
		get {if (this["codicecorso",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicecorso",DataRowVersion.Original];}
	}
	public Int32? idsor1{ 
		get {if (this["idsor1"]==DBNull.Value)return null; return  (Int32?)this["idsor1"];}
		set {if (value==null) this["idsor1"]= DBNull.Value; else this["idsor1"]= value;}
	}
	public object idsor1Value { 
		get{ return this["idsor1"];}
		set {if (value==null|| value==DBNull.Value) this["idsor1"]= DBNull.Value; else this["idsor1"]= value;}
	}
	public Int32? idsor1Original { 
		get {if (this["idsor1",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor1",DataRowVersion.Original];}
	}
	public Int32? idsor2{ 
		get {if (this["idsor2"]==DBNull.Value)return null; return  (Int32?)this["idsor2"];}
		set {if (value==null) this["idsor2"]= DBNull.Value; else this["idsor2"]= value;}
	}
	public object idsor2Value { 
		get{ return this["idsor2"];}
		set {if (value==null|| value==DBNull.Value) this["idsor2"]= DBNull.Value; else this["idsor2"]= value;}
	}
	public Int32? idsor2Original { 
		get {if (this["idsor2",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor2",DataRowVersion.Original];}
	}
	public Int32? idsor3{ 
		get {if (this["idsor3"]==DBNull.Value)return null; return  (Int32?)this["idsor3"];}
		set {if (value==null) this["idsor3"]= DBNull.Value; else this["idsor3"]= value;}
	}
	public object idsor3Value { 
		get{ return this["idsor3"];}
		set {if (value==null|| value==DBNull.Value) this["idsor3"]= DBNull.Value; else this["idsor3"]= value;}
	}
	public Int32? idsor3Original { 
		get {if (this["idsor3",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor3",DataRowVersion.Original];}
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
	#endregion

}
public class sisest_corsolaureaTable : MetaTableBase<sisest_corsolaureaRow> {
	public sisest_corsolaureaTable() : base("sisest_corsolaurea"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idcorsolaurea",createColumn("idcorsolaurea",typeof(Int32),false,false)},
			{"descrizione",createColumn("descrizione",typeof(String),false,false)},
			{"codicecorso",createColumn("codicecorso",typeof(String),false,false)},
			{"idsor1",createColumn("idsor1",typeof(Int32),true,false)},
			{"idsor2",createColumn("idsor2",typeof(Int32),true,false)},
			{"idsor3",createColumn("idsor3",typeof(Int32),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(String),true,false)},
		};
	}
}
}
