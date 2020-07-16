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
namespace meta_registry_docenti {
public class registry_docentiRow: MetaRow  {
	public registry_docentiRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///Curriculum Vitae
	///</summary>
	public String cv{ 
		get {if (this["cv"]==DBNull.Value)return null; return  (String)this["cv"];}
		set {if (value==null) this["cv"]= DBNull.Value; else this["cv"]= value;}
	}
	public object cvValue { 
		get{ return this["cv"];}
		set {if (value==null|| value==DBNull.Value) this["cv"]= DBNull.Value; else this["cv"]= value;}
	}
	public String cvOriginal { 
		get {if (this["cv",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cv",DataRowVersion.Original];}
	}
	///<summary>
	///Classe consorsuale
	///</summary>
	public Int32? idclassconsorsuale{ 
		get {if (this["idclassconsorsuale"]==DBNull.Value)return null; return  (Int32?)this["idclassconsorsuale"];}
		set {if (value==null) this["idclassconsorsuale"]= DBNull.Value; else this["idclassconsorsuale"]= value;}
	}
	public object idclassconsorsualeValue { 
		get{ return this["idclassconsorsuale"];}
		set {if (value==null|| value==DBNull.Value) this["idclassconsorsuale"]= DBNull.Value; else this["idclassconsorsuale"]= value;}
	}
	public Int32? idclassconsorsualeOriginal { 
		get {if (this["idclassconsorsuale",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idclassconsorsuale",DataRowVersion.Original];}
	}
	///<summary>
	///Codice Istituto
	///</summary>
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
	///Istituto, Ente o Azienda
	///</summary>
	public Int32? idreg_istituti{ 
		get {if (this["idreg_istituti"]==DBNull.Value)return null; return  (Int32?)this["idreg_istituti"];}
		set {if (value==null) this["idreg_istituti"]= DBNull.Value; else this["idreg_istituti"]= value;}
	}
	public object idreg_istitutiValue { 
		get{ return this["idreg_istituti"];}
		set {if (value==null|| value==DBNull.Value) this["idreg_istituti"]= DBNull.Value; else this["idreg_istituti"]= value;}
	}
	public Int32? idreg_istitutiOriginal { 
		get {if (this["idreg_istituti",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg_istituti",DataRowVersion.Original];}
	}
	///<summary>
	///SASD
	///</summary>
	public Int32? idsasd{ 
		get {if (this["idsasd"]==DBNull.Value)return null; return  (Int32?)this["idsasd"];}
		set {if (value==null) this["idsasd"]= DBNull.Value; else this["idsasd"]= value;}
	}
	public object idsasdValue { 
		get{ return this["idsasd"];}
		set {if (value==null|| value==DBNull.Value) this["idsasd"]= DBNull.Value; else this["idsasd"]= value;}
	}
	public Int32? idsasdOriginal { 
		get {if (this["idsasd",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsasd",DataRowVersion.Original];}
	}
	///<summary>
	///Struttura di afferenza
	///</summary>
	public Int32? idstruttura{ 
		get {if (this["idstruttura"]==DBNull.Value)return null; return  (Int32?)this["idstruttura"];}
		set {if (value==null) this["idstruttura"]= DBNull.Value; else this["idstruttura"]= value;}
	}
	public object idstrutturaValue { 
		get{ return this["idstruttura"];}
		set {if (value==null|| value==DBNull.Value) this["idstruttura"]= DBNull.Value; else this["idstruttura"]= value;}
	}
	public Int32? idstrutturaOriginal { 
		get {if (this["idstruttura",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idstruttura",DataRowVersion.Original];}
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
	///Matricola
	///</summary>
	public String matricola{ 
		get {if (this["matricola"]==DBNull.Value)return null; return  (String)this["matricola"];}
		set {if (value==null) this["matricola"]= DBNull.Value; else this["matricola"]= value;}
	}
	public object matricolaValue { 
		get{ return this["matricola"];}
		set {if (value==null|| value==DBNull.Value) this["matricola"]= DBNull.Value; else this["matricola"]= value;}
	}
	public String matricolaOriginal { 
		get {if (this["matricola",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["matricola",DataRowVersion.Original];}
	}
	///<summary>
	///Orari di ricevimento
	///</summary>
	public String ricevimento{ 
		get {if (this["ricevimento"]==DBNull.Value)return null; return  (String)this["ricevimento"];}
		set {if (value==null) this["ricevimento"]= DBNull.Value; else this["ricevimento"]= value;}
	}
	public object ricevimentoValue { 
		get{ return this["ricevimento"];}
		set {if (value==null|| value==DBNull.Value) this["ricevimento"]= DBNull.Value; else this["ricevimento"]= value;}
	}
	public String ricevimentoOriginal { 
		get {if (this["ricevimento",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ricevimento",DataRowVersion.Original];}
	}
	///<summary>
	///Permesso di soggiorno
	///</summary>
	public String soggiorno{ 
		get {if (this["soggiorno"]==DBNull.Value)return null; return  (String)this["soggiorno"];}
		set {if (value==null) this["soggiorno"]= DBNull.Value; else this["soggiorno"]= value;}
	}
	public object soggiornoValue { 
		get{ return this["soggiorno"];}
		set {if (value==null|| value==DBNull.Value) this["soggiorno"]= DBNull.Value; else this["soggiorno"]= value;}
	}
	public String soggiornoOriginal { 
		get {if (this["soggiorno",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["soggiorno",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///2.4.20 docenti
///</summary>
public class registry_docentiTable : MetaTableBase<registry_docentiRow> {
	public registry_docentiTable() : base("registry_docenti"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"cv",createColumn("cv",typeof(string),true,false)},
			{"idclassconsorsuale",createColumn("idclassconsorsuale",typeof(int),true,false)},
			{"idreg",createColumn("idreg",typeof(int),false,false)},
			{"idreg_istituti",createColumn("idreg_istituti",typeof(int),true,false)},
			{"idsasd",createColumn("idsasd",typeof(int),true,false)},
			{"idstruttura",createColumn("idstruttura",typeof(int),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"matricola",createColumn("matricola",typeof(string),true,false)},
			{"ricevimento",createColumn("ricevimento",typeof(string),true,false)},
			{"soggiorno",createColumn("soggiorno",typeof(string),true,false)},
		};
	}
}
}
