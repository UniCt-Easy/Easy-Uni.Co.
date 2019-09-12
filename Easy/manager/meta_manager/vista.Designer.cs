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
namespace meta_manager {
public class managerRow: MetaRow  {
	public managerRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///Email
	///</summary>
	public String email{ 
		get {if (this["email"]==DBNull.Value)return null; return  (String)this["email"];}
		set {if (value==null) this["email"]= DBNull.Value; else this["email"]= value;}
	}
	public object emailValue { 
		get{ return this["email"];}
		set {if (value==null|| value==DBNull.Value) this["email"]= DBNull.Value; else this["email"]= value;}
	}
	public String emailOriginal { 
		get {if (this["email",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["email",DataRowVersion.Original];}
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
	///password per accesso web
	///</summary>
	public String passwordweb{ 
		get {if (this["passwordweb"]==DBNull.Value)return null; return  (String)this["passwordweb"];}
		set {if (value==null) this["passwordweb"]= DBNull.Value; else this["passwordweb"]= value;}
	}
	public object passwordwebValue { 
		get{ return this["passwordweb"];}
		set {if (value==null|| value==DBNull.Value) this["passwordweb"]= DBNull.Value; else this["passwordweb"]= value;}
	}
	public String passwordwebOriginal { 
		get {if (this["passwordweb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["passwordweb",DataRowVersion.Original];}
	}
	///<summary>
	///Numero telefono
	///</summary>
	public String phonenumber{ 
		get {if (this["phonenumber"]==DBNull.Value)return null; return  (String)this["phonenumber"];}
		set {if (value==null) this["phonenumber"]= DBNull.Value; else this["phonenumber"]= value;}
	}
	public object phonenumberValue { 
		get{ return this["phonenumber"];}
		set {if (value==null|| value==DBNull.Value) this["phonenumber"]= DBNull.Value; else this["phonenumber"]= value;}
	}
	public String phonenumberOriginal { 
		get {if (this["phonenumber",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["phonenumber",DataRowVersion.Original];}
	}
	///<summary>
	///allegati
	///</summary>
	public Byte[] rtf{ 
		get {if (this["rtf"]==DBNull.Value)return null; return  (Byte[])this["rtf"];}
		set {if (value==null) this["rtf"]= DBNull.Value; else this["rtf"]= value;}
	}
	public object rtfValue { 
		get{ return this["rtf"];}
		set {if (value==null|| value==DBNull.Value) this["rtf"]= DBNull.Value; else this["rtf"]= value;}
	}
	public Byte[] rtfOriginal { 
		get {if (this["rtf",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte[])this["rtf",DataRowVersion.Original];}
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
	///note testuali
	///</summary>
	public String txt{ 
		get {if (this["txt"]==DBNull.Value)return null; return  (String)this["txt"];}
		set {if (value==null) this["txt"]= DBNull.Value; else this["txt"]= value;}
	}
	public object txtValue { 
		get{ return this["txt"];}
		set {if (value==null|| value==DBNull.Value) this["txt"]= DBNull.Value; else this["txt"]= value;}
	}
	public String txtOriginal { 
		get {if (this["txt",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["txt",DataRowVersion.Original];}
	}
	///<summary>
	///Login web
	///</summary>
	public String userweb{ 
		get {if (this["userweb"]==DBNull.Value)return null; return  (String)this["userweb"];}
		set {if (value==null) this["userweb"]= DBNull.Value; else this["userweb"]= value;}
	}
	public object userwebValue { 
		get{ return this["userweb"];}
		set {if (value==null|| value==DBNull.Value) this["userweb"]= DBNull.Value; else this["userweb"]= value;}
	}
	public String userwebOriginal { 
		get {if (this["userweb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["userweb",DataRowVersion.Original];}
	}
	///<summary>
	///id responsabile (tabella manager)
	///</summary>
	public Int32? idman{ 
		get {if (this["idman"]==DBNull.Value)return null; return  (Int32?)this["idman"];}
		set {if (value==null) this["idman"]= DBNull.Value; else this["idman"]= value;}
	}
	public object idmanValue { 
		get{ return this["idman"];}
		set {if (value==null|| value==DBNull.Value) this["idman"]= DBNull.Value; else this["idman"]= value;}
	}
	public Int32? idmanOriginal { 
		get {if (this["idman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idman",DataRowVersion.Original];}
	}
	///<summary>
	///ID Sezione (tabella division)
	///</summary>
	public Int32? iddivision{ 
		get {if (this["iddivision"]==DBNull.Value)return null; return  (Int32?)this["iddivision"];}
		set {if (value==null) this["iddivision"]= DBNull.Value; else this["iddivision"]= value;}
	}
	public object iddivisionValue { 
		get{ return this["iddivision"];}
		set {if (value==null|| value==DBNull.Value) this["iddivision"]= DBNull.Value; else this["iddivision"]= value;}
	}
	public Int32? iddivisionOriginal { 
		get {if (this["iddivision",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddivision",DataRowVersion.Original];}
	}
	///<summary>
	///se S Desidera notifiche per il cambio di stato documenti
	///</summary>
	public String wantswarn{ 
		get {if (this["wantswarn"]==DBNull.Value)return null; return  (String)this["wantswarn"];}
		set {if (value==null) this["wantswarn"]= DBNull.Value; else this["wantswarn"]= value;}
	}
	public object wantswarnValue { 
		get{ return this["wantswarn"];}
		set {if (value==null|| value==DBNull.Value) this["wantswarn"]= DBNull.Value; else this["wantswarn"]= value;}
	}
	public String wantswarnOriginal { 
		get {if (this["wantswarn",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["wantswarn",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 1(tabella sorting)
	///</summary>
	public Int32? idsor01{ 
		get {if (this["idsor01"]==DBNull.Value)return null; return  (Int32?)this["idsor01"];}
		set {if (value==null) this["idsor01"]= DBNull.Value; else this["idsor01"]= value;}
	}
	public object idsor01Value { 
		get{ return this["idsor01"];}
		set {if (value==null|| value==DBNull.Value) this["idsor01"]= DBNull.Value; else this["idsor01"]= value;}
	}
	public Int32? idsor01Original { 
		get {if (this["idsor01",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor01",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 2(tabella sorting)
	///</summary>
	public Int32? idsor02{ 
		get {if (this["idsor02"]==DBNull.Value)return null; return  (Int32?)this["idsor02"];}
		set {if (value==null) this["idsor02"]= DBNull.Value; else this["idsor02"]= value;}
	}
	public object idsor02Value { 
		get{ return this["idsor02"];}
		set {if (value==null|| value==DBNull.Value) this["idsor02"]= DBNull.Value; else this["idsor02"]= value;}
	}
	public Int32? idsor02Original { 
		get {if (this["idsor02",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor02",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 3(tabella sorting)
	///</summary>
	public Int32? idsor03{ 
		get {if (this["idsor03"]==DBNull.Value)return null; return  (Int32?)this["idsor03"];}
		set {if (value==null) this["idsor03"]= DBNull.Value; else this["idsor03"]= value;}
	}
	public object idsor03Value { 
		get{ return this["idsor03"];}
		set {if (value==null|| value==DBNull.Value) this["idsor03"]= DBNull.Value; else this["idsor03"]= value;}
	}
	public Int32? idsor03Original { 
		get {if (this["idsor03",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor03",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 4(tabella sorting)
	///</summary>
	public Int32? idsor04{ 
		get {if (this["idsor04"]==DBNull.Value)return null; return  (Int32?)this["idsor04"];}
		set {if (value==null) this["idsor04"]= DBNull.Value; else this["idsor04"]= value;}
	}
	public object idsor04Value { 
		get{ return this["idsor04"];}
		set {if (value==null|| value==DBNull.Value) this["idsor04"]= DBNull.Value; else this["idsor04"]= value;}
	}
	public Int32? idsor04Original { 
		get {if (this["idsor04",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor04",DataRowVersion.Original];}
	}
	///<summary>
	///id voce class.sicurezza 5(tabella sorting)
	///</summary>
	public Int32? idsor05{ 
		get {if (this["idsor05"]==DBNull.Value)return null; return  (Int32?)this["idsor05"];}
		set {if (value==null) this["idsor05"]= DBNull.Value; else this["idsor05"]= value;}
	}
	public object idsor05Value { 
		get{ return this["idsor05"];}
		set {if (value==null|| value==DBNull.Value) this["idsor05"]= DBNull.Value; else this["idsor05"]= value;}
	}
	public Int32? idsor05Original { 
		get {if (this["idsor05",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor05",DataRowVersion.Original];}
	}
	///<summary>
	///id nuovo responsabile, usato a volte in migrazioni
	///</summary>
	public Int32? newidman{ 
		get {if (this["newidman"]==DBNull.Value)return null; return  (Int32?)this["newidman"];}
		set {if (value==null) this["newidman"]= DBNull.Value; else this["newidman"]= value;}
	}
	public object newidmanValue { 
		get{ return this["newidman"];}
		set {if (value==null|| value==DBNull.Value) this["newidman"]= DBNull.Value; else this["newidman"]= value;}
	}
	public Int32? newidmanOriginal { 
		get {if (this["newidman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["newidman",DataRowVersion.Original];}
	}
	///<summary>
	///Attivo nel modulo finanziario
	///</summary>
	public String financeactive{ 
		get {if (this["financeactive"]==DBNull.Value)return null; return  (String)this["financeactive"];}
		set {if (value==null) this["financeactive"]= DBNull.Value; else this["financeactive"]= value;}
	}
	public object financeactiveValue { 
		get{ return this["financeactive"];}
		set {if (value==null|| value==DBNull.Value) this["financeactive"]= DBNull.Value; else this["financeactive"]= value;}
	}
	public String financeactiveOriginal { 
		get {if (this["financeactive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["financeactive",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Responsabile
///</summary>
public class managerTable : MetaTableBase<managerRow> {
	public managerTable() : base("manager"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("active")){ 
			defineColumn("active", typeof(System.String));
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("email")){ 
			defineColumn("email", typeof(System.String));
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("passwordweb")){ 
			defineColumn("passwordweb", typeof(System.String));
		}
		if (definedColums.ContainsKey("phonenumber")){ 
			defineColumn("phonenumber", typeof(System.String));
		}
		if (definedColums.ContainsKey("rtf")){ 
			defineColumn("rtf", typeof(System.Byte[]));
		}
		if (definedColums.ContainsKey("title")){ 
			defineColumn("title", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("txt")){ 
			defineColumn("txt", typeof(System.String));
		}
		if (definedColums.ContainsKey("userweb")){ 
			defineColumn("userweb", typeof(System.String));
		}
		if (definedColums.ContainsKey("idman")){ 
			defineColumn("idman", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("iddivision")){ 
			defineColumn("iddivision", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("wantswarn")){ 
			defineColumn("wantswarn", typeof(System.String));
		}
		if (definedColums.ContainsKey("idsor01")){ 
			defineColumn("idsor01", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor02")){ 
			defineColumn("idsor02", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor03")){ 
			defineColumn("idsor03", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor04")){ 
			defineColumn("idsor04", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idsor05")){ 
			defineColumn("idsor05", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("newidman")){ 
			defineColumn("newidman", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("financeactive")){ 
			defineColumn("financeactive", typeof(System.String));
		}
		#endregion

	}
}
}
