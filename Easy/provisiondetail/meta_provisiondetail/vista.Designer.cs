
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_provisiondetail {
public class provisiondetailRow: MetaRow  {
	public provisiondetailRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///id accantonamento
	///</summary>
	public Int32? idprovision{ 
		get {if (this["idprovision"]==DBNull.Value)return null; return  (Int32?)this["idprovision"];}
		set {if (value==null) this["idprovision"]= DBNull.Value; else this["idprovision"]= value;}
	}
	public object idprovisionValue { 
		get{ return this["idprovision"];}
		set {if (value==null|| value==DBNull.Value) this["idprovision"]= DBNull.Value; else this["idprovision"]= value;}
	}
	public Int32? idprovisionOriginal { 
		get {if (this["idprovision",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idprovision",DataRowVersion.Original];}
	}
	///<summary>
	///N. riga
	///</summary>
	public Int32? rownum{ 
		get {if (this["rownum"]==DBNull.Value)return null; return  (Int32?)this["rownum"];}
		set {if (value==null) this["rownum"]= DBNull.Value; else this["rownum"]= value;}
	}
	public object rownumValue { 
		get{ return this["rownum"];}
		set {if (value==null|| value==DBNull.Value) this["rownum"]= DBNull.Value; else this["rownum"]= value;}
	}
	public Int32? rownumOriginal { 
		get {if (this["rownum",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["rownum",DataRowVersion.Original];}
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
	///id causale (tabella acccmotive)
	///</summary>
	public String idaccmotive{ 
		get {if (this["idaccmotive"]==DBNull.Value)return null; return  (String)this["idaccmotive"];}
		set {if (value==null) this["idaccmotive"]= DBNull.Value; else this["idaccmotive"]= value;}
	}
	public object idaccmotiveValue { 
		get{ return this["idaccmotive"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive"]= DBNull.Value; else this["idaccmotive"]= value;}
	}
	public String idaccmotiveOriginal { 
		get {if (this["idaccmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive",DataRowVersion.Original];}
	}
	///<summary>
	///Anno creazione dettaglio
	///</summary>
	public Int16? ydetail{ 
		get {if (this["ydetail"]==DBNull.Value)return null; return  (Int16?)this["ydetail"];}
		set {if (value==null) this["ydetail"]= DBNull.Value; else this["ydetail"]= value;}
	}
	public object ydetailValue { 
		get{ return this["ydetail"];}
		set {if (value==null|| value==DBNull.Value) this["ydetail"]= DBNull.Value; else this["ydetail"]= value;}
	}
	public Int16? ydetailOriginal { 
		get {if (this["ydetail",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["ydetail",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Dettaglio accantonamento
///</summary>
public class provisiondetailTable : MetaTableBase<provisiondetailRow> {
	public provisiondetailTable() : base("provisiondetail"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idprovision",createColumn("idprovision",typeof(int),false,false)},
			{"rownum",createColumn("rownum",typeof(int),false,false)},
			{"description",createColumn("description",typeof(string),true,false)},
			{"amount",createColumn("amount",typeof(decimal),true,false)},
			{"adate",createColumn("adate",typeof(DateTime),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"idaccmotive",createColumn("idaccmotive",typeof(string),true,false)},
			{"ydetail",createColumn("ydetail",typeof(short),true,false)},
		};
	}
}
}
