
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
namespace meta_paymenttransmission {
public class paymenttransmissionRow: MetaRow  {
	public paymenttransmissionRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Num. distinta
	///</summary>
	public Int32? npaymenttransmission{ 
		get {if (this["npaymenttransmission"]==DBNull.Value)return null; return  (Int32?)this["npaymenttransmission"];}
		set {if (value==null) this["npaymenttransmission"]= DBNull.Value; else this["npaymenttransmission"]= value;}
	}
	public object npaymenttransmissionValue { 
		get{ return this["npaymenttransmission"];}
		set {if (value==null|| value==DBNull.Value) this["npaymenttransmission"]= DBNull.Value; else this["npaymenttransmission"]= value;}
	}
	public Int32? npaymenttransmissionOriginal { 
		get {if (this["npaymenttransmission",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["npaymenttransmission",DataRowVersion.Original];}
	}
	///<summary>
	///Eserc. distinta
	///</summary>
	public Int16? ypaymenttransmission{ 
		get {if (this["ypaymenttransmission"]==DBNull.Value)return null; return  (Int16?)this["ypaymenttransmission"];}
		set {if (value==null) this["ypaymenttransmission"]= DBNull.Value; else this["ypaymenttransmission"]= value;}
	}
	public object ypaymenttransmissionValue { 
		get{ return this["ypaymenttransmission"];}
		set {if (value==null|| value==DBNull.Value) this["ypaymenttransmission"]= DBNull.Value; else this["ypaymenttransmission"]= value;}
	}
	public Int16? ypaymenttransmissionOriginal { 
		get {if (this["ypaymenttransmission",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["ypaymenttransmission",DataRowVersion.Original];}
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
	///Data trasm.
	///</summary>
	public DateTime? transmissiondate{ 
		get {if (this["transmissiondate"]==DBNull.Value)return null; return  (DateTime?)this["transmissiondate"];}
		set {if (value==null) this["transmissiondate"]= DBNull.Value; else this["transmissiondate"]= value;}
	}
	public object transmissiondateValue { 
		get{ return this["transmissiondate"];}
		set {if (value==null|| value==DBNull.Value) this["transmissiondate"]= DBNull.Value; else this["transmissiondate"]= value;}
	}
	public DateTime? transmissiondateOriginal { 
		get {if (this["transmissiondate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["transmissiondate",DataRowVersion.Original];}
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
	///Id cassiere (tabella treasurer)
	///</summary>
	public Int32? idtreasurer{ 
		get {if (this["idtreasurer"]==DBNull.Value)return null; return  (Int32?)this["idtreasurer"];}
		set {if (value==null) this["idtreasurer"]= DBNull.Value; else this["idtreasurer"]= value;}
	}
	public object idtreasurerValue { 
		get{ return this["idtreasurer"];}
		set {if (value==null|| value==DBNull.Value) this["idtreasurer"]= DBNull.Value; else this["idtreasurer"]= value;}
	}
	public Int32? idtreasurerOriginal { 
		get {if (this["idtreasurer",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idtreasurer",DataRowVersion.Original];}
	}
	///<summary>
	///#
	///</summary>
	public Int32? kpaymenttransmission{ 
		get {if (this["kpaymenttransmission"]==DBNull.Value)return null; return  (Int32?)this["kpaymenttransmission"];}
		set {if (value==null) this["kpaymenttransmission"]= DBNull.Value; else this["kpaymenttransmission"]= value;}
	}
	public object kpaymenttransmissionValue { 
		get{ return this["kpaymenttransmission"];}
		set {if (value==null|| value==DBNull.Value) this["kpaymenttransmission"]= DBNull.Value; else this["kpaymenttransmission"]= value;}
	}
	public Int32? kpaymenttransmissionOriginal { 
		get {if (this["kpaymenttransmission",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["kpaymenttransmission",DataRowVersion.Original];}
	}
	///<summary>
	///Mail gi? inviata
	///	 N: Mail non inviata
	///	 S: Mail gi? inviata
	///</summary>
	public String flagmailsent{ 
		get {if (this["flagmailsent"]==DBNull.Value)return null; return  (String)this["flagmailsent"];}
		set {if (value==null) this["flagmailsent"]= DBNull.Value; else this["flagmailsent"]= value;}
	}
	public object flagmailsentValue { 
		get{ return this["flagmailsent"];}
		set {if (value==null|| value==DBNull.Value) this["flagmailsent"]= DBNull.Value; else this["flagmailsent"]= value;}
	}
	public String flagmailsentOriginal { 
		get {if (this["flagmailsent",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagmailsent",DataRowVersion.Original];}
	}
	///<summary>
	///tipo trasmissione
	///	 I: normale
	///	 V: Elenco di Variazioni e Annullamenti
	///</summary>
	public String transmissionkind{ 
		get {if (this["transmissionkind"]==DBNull.Value)return null; return  (String)this["transmissionkind"];}
		set {if (value==null) this["transmissionkind"]= DBNull.Value; else this["transmissionkind"]= value;}
	}
	public object transmissionkindValue { 
		get{ return this["transmissionkind"];}
		set {if (value==null|| value==DBNull.Value) this["transmissionkind"]= DBNull.Value; else this["transmissionkind"]= value;}
	}
	public String transmissionkindOriginal { 
		get {if (this["transmissionkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["transmissionkind",DataRowVersion.Original];}
	}
	///<summary>
	///Data creazione flusso
	///</summary>
	public DateTime? streamdate{ 
		get {if (this["streamdate"]==DBNull.Value)return null; return  (DateTime?)this["streamdate"];}
		set {if (value==null) this["streamdate"]= DBNull.Value; else this["streamdate"]= value;}
	}
	public object streamdateValue { 
		get{ return this["streamdate"];}
		set {if (value==null|| value==DBNull.Value) this["streamdate"]= DBNull.Value; else this["streamdate"]= value;}
	}
	public DateTime? streamdateOriginal { 
		get {if (this["streamdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["streamdate",DataRowVersion.Original];}
	}
	///<summary>
	///Data acquisizione banca
	///</summary>
	public DateTime? bankdate{ 
		get {if (this["bankdate"]==DBNull.Value)return null; return  (DateTime?)this["bankdate"];}
		set {if (value==null) this["bankdate"]= DBNull.Value; else this["bankdate"]= value;}
	}
	public object bankdateValue { 
		get{ return this["bankdate"];}
		set {if (value==null|| value==DBNull.Value) this["bankdate"]= DBNull.Value; else this["bankdate"]= value;}
	}
	public DateTime? bankdateOriginal { 
		get {if (this["bankdate",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["bankdate",DataRowVersion.Original];}
	}
	///<summary>
	///Verificato, si autorizza la trasmissione
	///	 N: Notifiche non inviate
	///	 S: Notifiche inviate
	///</summary>
	public String flagtransmissionenabled{ 
		get {if (this["flagtransmissionenabled"]==DBNull.Value)return null; return  (String)this["flagtransmissionenabled"];}
		set {if (value==null) this["flagtransmissionenabled"]= DBNull.Value; else this["flagtransmissionenabled"]= value;}
	}
	public object flagtransmissionenabledValue { 
		get{ return this["flagtransmissionenabled"];}
		set {if (value==null|| value==DBNull.Value) this["flagtransmissionenabled"]= DBNull.Value; else this["flagtransmissionenabled"]= value;}
	}
	public String flagtransmissionenabledOriginal { 
		get {if (this["flagtransmissionenabled",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagtransmissionenabled",DataRowVersion.Original];}
	}
	///<summary>
	///non generare scritture in partita doppia per questo elenco
	///	 N: Genera scritture in partita doppia per questo elenco
	///	 S: non generare scritture in partita doppia per questo elenco
	///</summary>
	public String noep{ 
		get {if (this["noep"]==DBNull.Value)return null; return  (String)this["noep"];}
		set {if (value==null) this["noep"]= DBNull.Value; else this["noep"]= value;}
	}
	public object noepValue { 
		get{ return this["noep"];}
		set {if (value==null|| value==DBNull.Value) this["noep"]= DBNull.Value; else this["noep"]= value;}
	}
	public String noepOriginal { 
		get {if (this["noep",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["noep",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Distinta di trasmissione
///</summary>
public class paymenttransmissionTable : MetaTableBase<paymenttransmissionRow> {
	public paymenttransmissionTable() : base("paymenttransmission"){}
	public override void addBaseColumns(params string [] cols){
		Dictionary<string,bool> definedColums=new Dictionary<string, bool>();
		foreach(string col in cols) definedColums[col] = true;

		#region add DataColumns
		if (definedColums.ContainsKey("npaymenttransmission")){ 
			defineColumn("npaymenttransmission", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("ypaymenttransmission")){ 
			defineColumn("ypaymenttransmission", typeof(System.Int16),false);
		}
		if (definedColums.ContainsKey("ct")){ 
			defineColumn("ct", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("cu")){ 
			defineColumn("cu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("lt")){ 
			defineColumn("lt", typeof(System.DateTime),false);
		}
		if (definedColums.ContainsKey("lu")){ 
			defineColumn("lu", typeof(System.String),false);
		}
		if (definedColums.ContainsKey("transmissiondate")){ 
			defineColumn("transmissiondate", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("idman")){ 
			defineColumn("idman", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("idtreasurer")){ 
			defineColumn("idtreasurer", typeof(System.Int32));
		}
		if (definedColums.ContainsKey("kpaymenttransmission")){ 
			defineColumn("kpaymenttransmission", typeof(System.Int32),false);
		}
		if (definedColums.ContainsKey("flagmailsent")){ 
			defineColumn("flagmailsent", typeof(System.String));
		}
		if (definedColums.ContainsKey("transmissionkind")){ 
			defineColumn("transmissionkind", typeof(System.String));
		}
		if (definedColums.ContainsKey("streamdate")){ 
			defineColumn("streamdate", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("bankdate")){ 
			defineColumn("bankdate", typeof(System.DateTime));
		}
		if (definedColums.ContainsKey("flagtransmissionenabled")){ 
			defineColumn("flagtransmissionenabled", typeof(System.String));
		}
		if (definedColums.ContainsKey("noep")){ 
			defineColumn("noep", typeof(System.String));
		}
		#endregion

	}
}
}
