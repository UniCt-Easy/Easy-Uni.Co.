
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
namespace meta_authpayment {
public class authpaymentRow: MetaRow  {
	public authpaymentRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///#
	///</summary>
	public Int32? idauthpayment{ 
		get {if (this["idauthpayment"]==DBNull.Value)return null; return  (Int32?)this["idauthpayment"];}
		set {if (value==null) this["idauthpayment"]= DBNull.Value; else this["idauthpayment"]= value;}
	}
	public object idauthpaymentValue { 
		get{ return this["idauthpayment"];}
		set {if (value==null|| value==DBNull.Value) this["idauthpayment"]= DBNull.Value; else this["idauthpayment"]= value;}
	}
	public Int32? idauthpaymentOriginal { 
		get {if (this["idauthpayment",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idauthpayment",DataRowVersion.Original];}
	}
	///<summary>
	///Data Invio Richiesta
	///</summary>
	public DateTime? sent_date{ 
		get {if (this["sent_date"]==DBNull.Value)return null; return  (DateTime?)this["sent_date"];}
		set {if (value==null) this["sent_date"]= DBNull.Value; else this["sent_date"]= value;}
	}
	public object sent_dateValue { 
		get{ return this["sent_date"];}
		set {if (value==null|| value==DBNull.Value) this["sent_date"]= DBNull.Value; else this["sent_date"]= value;}
	}
	public DateTime? sent_dateOriginal { 
		get {if (this["sent_date",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["sent_date",DataRowVersion.Original];}
	}
	///<summary>
	///Data Tacita Autorizzazione
	///</summary>
	public DateTime? authorize_date{ 
		get {if (this["authorize_date"]==DBNull.Value)return null; return  (DateTime?)this["authorize_date"];}
		set {if (value==null) this["authorize_date"]= DBNull.Value; else this["authorize_date"]= value;}
	}
	public object authorize_dateValue { 
		get{ return this["authorize_date"];}
		set {if (value==null|| value==DBNull.Value) this["authorize_date"]= DBNull.Value; else this["authorize_date"]= value;}
	}
	public DateTime? authorize_dateOriginal { 
		get {if (this["authorize_date",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["authorize_date",DataRowVersion.Original];}
	}
	///<summary>
	///Importo da pignorare
	///</summary>
	public Decimal? attach_amount{ 
		get {if (this["attach_amount"]==DBNull.Value)return null; return  (Decimal?)this["attach_amount"];}
		set {if (value==null) this["attach_amount"]= DBNull.Value; else this["attach_amount"]= value;}
	}
	public object attach_amountValue { 
		get{ return this["attach_amount"];}
		set {if (value==null|| value==DBNull.Value) this["attach_amount"]= DBNull.Value; else this["attach_amount"]= value;}
	}
	public Decimal? attach_amountOriginal { 
		get {if (this["attach_amount",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["attach_amount",DataRowVersion.Original];}
	}
	///<summary>
	///ID Stato autorizzazione (tabella authstatus)
	///</summary>
	public Int32? idauthstatus{ 
		get {if (this["idauthstatus"]==DBNull.Value)return null; return  (Int32?)this["idauthstatus"];}
		set {if (value==null) this["idauthstatus"]= DBNull.Value; else this["idauthstatus"]= value;}
	}
	public object idauthstatusValue { 
		get{ return this["idauthstatus"];}
		set {if (value==null|| value==DBNull.Value) this["idauthstatus"]= DBNull.Value; else this["idauthstatus"]= value;}
	}
	public Int32? idauthstatusOriginal { 
		get {if (this["idauthstatus",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idauthstatus",DataRowVersion.Original];}
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
	///<summary>
	///Esercizio
	///</summary>
	public Int32? yauthpayment{ 
		get {if (this["yauthpayment"]==DBNull.Value)return null; return  (Int32?)this["yauthpayment"];}
		set {if (value==null) this["yauthpayment"]= DBNull.Value; else this["yauthpayment"]= value;}
	}
	public object yauthpaymentValue { 
		get{ return this["yauthpayment"];}
		set {if (value==null|| value==DBNull.Value) this["yauthpayment"]= DBNull.Value; else this["yauthpayment"]= value;}
	}
	public Int32? yauthpaymentOriginal { 
		get {if (this["yauthpayment",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["yauthpayment",DataRowVersion.Original];}
	}
	///<summary>
	///Num.
	///</summary>
	public Int16? nauthpayment{ 
		get {if (this["nauthpayment"]==DBNull.Value)return null; return  (Int16?)this["nauthpayment"];}
		set {if (value==null) this["nauthpayment"]= DBNull.Value; else this["nauthpayment"]= value;}
	}
	public object nauthpaymentValue { 
		get{ return this["nauthpayment"];}
		set {if (value==null|| value==DBNull.Value) this["nauthpayment"]= DBNull.Value; else this["nauthpayment"]= value;}
	}
	public Int16? nauthpaymentOriginal { 
		get {if (this["nauthpayment",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["nauthpayment",DataRowVersion.Original];}
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
	///documento
	///</summary>
	public String doc{ 
		get {if (this["doc"]==DBNull.Value)return null; return  (String)this["doc"];}
		set {if (value==null) this["doc"]= DBNull.Value; else this["doc"]= value;}
	}
	public object docValue { 
		get{ return this["doc"];}
		set {if (value==null|| value==DBNull.Value) this["doc"]= DBNull.Value; else this["doc"]= value;}
	}
	public String docOriginal { 
		get {if (this["doc",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["doc",DataRowVersion.Original];}
	}
	///<summary>
	///data documento
	///</summary>
	public DateTime? docdate{ 
		get {if (this["docdate"]==DBNull.Value)return null; return  (DateTime?)this["docdate"];}
		set {if (value==null) this["docdate"]= DBNull.Value; else this["docdate"]= value;}
	}
	public object docdateValue { 
		get{ return this["docdate"];}
		set {if (value==null|| value==DBNull.Value) this["docdate"]= DBNull.Value; else this["docdate"]= value;}
	}
	public DateTime? docdateOriginal { 
		get {if (this["docdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["docdate",DataRowVersion.Original];}
	}
	///<summary>
	///id anagrafica (tabella registry)
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
	#endregion

}
///<summary>
///Autorizzazione al pagamento Pubblica Amministrazone
///</summary>
public class authpaymentTable : MetaTableBase<authpaymentRow> {
	public authpaymentTable() : base("authpayment"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("idauthpayment")){ 
			defineColumn("idauthpayment", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("sent_date")){ 
			defineColumn("sent_date", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("authorize_date")){ 
			defineColumn("authorize_date", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("attach_amount")){ 
			defineColumn("attach_amount", typeof(System.Decimal));
		}
		if (definedColums.ContainsKey("idauthstatus")){ 
			defineColumn("idauthstatus", typeof(System.Int32),false);
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
		if (definedColums.ContainsKey("yauthpayment")){ 
			defineColumn("yauthpayment", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("nauthpayment")){ 
			defineColumn("nauthpayment", typeof(System.Int16));
		}
		if (definedColums.ContainsKey("description")){ 
			defineColumn("description", typeof(System.String));
		}
		if (definedColums.ContainsKey("doc")){ 
			defineColumn("doc", typeof(System.String));
		}
		if (definedColums.ContainsKey("docdate")){ 
			defineColumn("docdate", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("idreg")){ 
			defineColumn("idreg", typeof(System.Int32));
		}
		#endregion

	}
}
}
