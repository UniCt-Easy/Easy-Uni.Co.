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
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_registry_instmuser {
public class registry_instmuserRow: MetaRow  {
	public registry_instmuserRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public String maritalcf{ 
		get {if (this["maritalcf"]==DBNull.Value)return null; return  (String)this["maritalcf"];}
		set {if (value==null) this["maritalcf"]= DBNull.Value; else this["maritalcf"]= value;}
	}
	public object maritalcfValue { 
		get{ return this["maritalcf"];}
		set {if (value==null|| value==DBNull.Value) this["maritalcf"]= DBNull.Value; else this["maritalcf"]= value;}
	}
	public String maritalcfOriginal { 
		get {if (this["maritalcf",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["maritalcf",DataRowVersion.Original];}
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
	///<summary>
	///Documento di identità
	///</summary>
	public Int32? idattach{ 
		get {if (this["idattach"]==DBNull.Value)return null; return  (Int32?)this["idattach"];}
		set {if (value==null) this["idattach"]= DBNull.Value; else this["idattach"]= value;}
	}
	public object idattachValue { 
		get{ return this["idattach"];}
		set {if (value==null|| value==DBNull.Value) this["idattach"]= DBNull.Value; else this["idattach"]= value;}
	}
	public Int32? idattachOriginal { 
		get {if (this["idattach",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idattach",DataRowVersion.Original];}
	}
	///<summary>
	///Sezione tematica prescelta
	///</summary>
	public Int32? idinstmseztematichekind{ 
		get {if (this["idinstmseztematichekind"]==DBNull.Value)return null; return  (Int32?)this["idinstmseztematichekind"];}
		set {if (value==null) this["idinstmseztematichekind"]= DBNull.Value; else this["idinstmseztematichekind"]= value;}
	}
	public object idinstmseztematichekindValue { 
		get{ return this["idinstmseztematichekind"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmseztematichekind"]= DBNull.Value; else this["idinstmseztematichekind"]= value;}
	}
	public Int32? idinstmseztematichekindOriginal { 
		get {if (this["idinstmseztematichekind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmseztematichekind",DataRowVersion.Original];}
	}
	///<summary>
	///Seconda sezione tematica prescelta
	///</summary>
	public Int32? idinstmseztematichekind_2{ 
		get {if (this["idinstmseztematichekind_2"]==DBNull.Value)return null; return  (Int32?)this["idinstmseztematichekind_2"];}
		set {if (value==null) this["idinstmseztematichekind_2"]= DBNull.Value; else this["idinstmseztematichekind_2"]= value;}
	}
	public object idinstmseztematichekind_2Value { 
		get{ return this["idinstmseztematichekind_2"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmseztematichekind_2"]= DBNull.Value; else this["idinstmseztematichekind_2"]= value;}
	}
	public Int32? idinstmseztematichekind_2Original { 
		get {if (this["idinstmseztematichekind_2",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmseztematichekind_2",DataRowVersion.Original];}
	}
	///<summary>
	///Categoria di afferenza
	///</summary>
	public Int32? idinstmusercategorykind{ 
		get {if (this["idinstmusercategorykind"]==DBNull.Value)return null; return  (Int32?)this["idinstmusercategorykind"];}
		set {if (value==null) this["idinstmusercategorykind"]= DBNull.Value; else this["idinstmusercategorykind"]= value;}
	}
	public object idinstmusercategorykindValue { 
		get{ return this["idinstmusercategorykind"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmusercategorykind"]= DBNull.Value; else this["idinstmusercategorykind"]= value;}
	}
	public Int32? idinstmusercategorykindOriginal { 
		get {if (this["idinstmusercategorykind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmusercategorykind",DataRowVersion.Original];}
	}
	public Int32? idreg{ 
		get {if (this["idreg"]==DBNull.Value)return null; return  (Int32?)this["idreg"];}
		set {if (value==null) this["idreg"]= DBNull.Value; else this["idreg"]= value;}
	}
	public object idregValue { 
		get{ return this["idreg"];}
		set {if (value==null|| value==DBNull.Value) this["idreg"]= DBNull.Value; else this["idreg"]= value;}
	}
	public Int32? idregOriginal { 
		get {if (this["idreg",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg",DataRowVersion.Original];}
	}
	///<summary>
	///Interessi di Ricerca
	///</summary>
	public String interest{ 
		get {if (this["interest"]==DBNull.Value)return null; return  (String)this["interest"];}
		set {if (value==null) this["interest"]= DBNull.Value; else this["interest"]= value;}
	}
	public object interestValue { 
		get{ return this["interest"];}
		set {if (value==null|| value==DBNull.Value) this["interest"]= DBNull.Value; else this["interest"]= value;}
	}
	public String interestOriginal { 
		get {if (this["interest",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["interest",DataRowVersion.Original];}
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
	///Autorizzo l’invio della Newsletter istituzionale
	///</summary>
	public String newsletter{ 
		get {if (this["newsletter"]==DBNull.Value)return null; return  (String)this["newsletter"];}
		set {if (value==null) this["newsletter"]= DBNull.Value; else this["newsletter"]= value;}
	}
	public object newsletterValue { 
		get{ return this["newsletter"];}
		set {if (value==null|| value==DBNull.Value) this["newsletter"]= DBNull.Value; else this["newsletter"]= value;}
	}
	public String newsletterOriginal { 
		get {if (this["newsletter",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["newsletter",DataRowVersion.Original];}
	}
	///<summary>
	///Eventuale afferenza ad altri Consorzi (specificare quale/i, uno per riga):
	///</summary>
	public String otherbelonging{ 
		get {if (this["otherbelonging"]==DBNull.Value)return null; return  (String)this["otherbelonging"];}
		set {if (value==null) this["otherbelonging"]= DBNull.Value; else this["otherbelonging"]= value;}
	}
	public object otherbelongingValue { 
		get{ return this["otherbelonging"];}
		set {if (value==null|| value==DBNull.Value) this["otherbelonging"]= DBNull.Value; else this["otherbelonging"]= value;}
	}
	public String otherbelongingOriginal { 
		get {if (this["otherbelonging",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["otherbelonging",DataRowVersion.Original];}
	}
	///<summary>
	///Presa visione dell’informativa e consenso al trattamento dei dati
	///</summary>
	public String privacy{ 
		get {if (this["privacy"]==DBNull.Value)return null; return  (String)this["privacy"];}
		set {if (value==null) this["privacy"]= DBNull.Value; else this["privacy"]= value;}
	}
	public object privacyValue { 
		get{ return this["privacy"];}
		set {if (value==null|| value==DBNull.Value) this["privacy"]= DBNull.Value; else this["privacy"]= value;}
	}
	public String privacyOriginal { 
		get {if (this["privacy",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["privacy",DataRowVersion.Original];}
	}
	///<summary>
	///Do il consenso
	///</summary>
	public String regulationaccept{ 
		get {if (this["regulationaccept"]==DBNull.Value)return null; return  (String)this["regulationaccept"];}
		set {if (value==null) this["regulationaccept"]= DBNull.Value; else this["regulationaccept"]= value;}
	}
	public object regulationacceptValue { 
		get{ return this["regulationaccept"];}
		set {if (value==null|| value==DBNull.Value) this["regulationaccept"]= DBNull.Value; else this["regulationaccept"]= value;}
	}
	public String regulationacceptOriginal { 
		get {if (this["regulationaccept",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["regulationaccept",DataRowVersion.Original];}
	}
	#endregion

}
public class registry_instmuserTable : MetaTableBase<registry_instmuserRow> {
	public registry_instmuserTable() : base("registry_instmuser"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"maritalcf",createColumn("maritalcf",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"idattach",createColumn("idattach",typeof(int),false,false)},
			{"idinstmseztematichekind",createColumn("idinstmseztematichekind",typeof(int),false,false)},
			{"idinstmseztematichekind_2",createColumn("idinstmseztematichekind_2",typeof(int),true,false)},
			{"idinstmusercategorykind",createColumn("idinstmusercategorykind",typeof(int),true,false)},
			{"idreg",createColumn("idreg",typeof(int),false,false)},
			{"interest",createColumn("interest",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"newsletter",createColumn("newsletter",typeof(string),false,false)},
			{"otherbelonging",createColumn("otherbelonging",typeof(string),true,false)},
			{"privacy",createColumn("privacy",typeof(string),false,false)},
			{"regulationaccept",createColumn("regulationaccept",typeof(string),false,false)},
		};
	}
}
}
