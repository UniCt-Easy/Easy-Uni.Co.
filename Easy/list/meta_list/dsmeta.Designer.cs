
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
namespace meta_list {
public class listRow: MetaRow  {
	public listRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///chiave listino (tabella list)
	///</summary>
	public Int32 idlist{ 
		get {return  (Int32)this["idlist"];}
		set {this["idlist"]= value;}
	}
	public object idlistValue { 
		get{ return this["idlist"];}
		set {this["idlist"]= value;}
	}
	public Int32 idlistOriginal { 
		get {return  (Int32)this["idlist",DataRowVersion.Original];}
	}
	///<summary>
	///Descrizione
	///</summary>
	public String description{ 
		get {return  (String)this["description"];}
		set {this["description"]= value;}
	}
	public object descriptionValue { 
		get{ return this["description"];}
		set {this["description"]= value;}
	}
	public String descriptionOriginal { 
		get {return  (String)this["description",DataRowVersion.Original];}
	}
	///<summary>
	///Codice
	///</summary>
	public String intcode{ 
		get {return  (String)this["intcode"];}
		set {this["intcode"]= value;}
	}
	public object intcodeValue { 
		get{ return this["intcode"];}
		set {this["intcode"]= value;}
	}
	public String intcodeOriginal { 
		get {return  (String)this["intcode",DataRowVersion.Original];}
	}
	///<summary>
	///Codice a barre per uso interno
	///</summary>
	public String intbarcode{ 
		get {if (this["intbarcode"]==DBNull.Value)return null; return  (String)this["intbarcode"];}
		set {if (value==null) this["intbarcode"]= DBNull.Value; else this["intbarcode"]= value;}
	}
	public object intbarcodeValue { 
		get{ return this["intbarcode"];}
		set {if (value==null|| value==DBNull.Value) this["intbarcode"]= DBNull.Value; else this["intbarcode"]= value;}
	}
	public String intbarcodeOriginal { 
		get {if (this["intbarcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["intbarcode",DataRowVersion.Original];}
	}
	///<summary>
	///Codice produttore
	///</summary>
	public String extcode{ 
		get {if (this["extcode"]==DBNull.Value)return null; return  (String)this["extcode"];}
		set {if (value==null) this["extcode"]= DBNull.Value; else this["extcode"]= value;}
	}
	public object extcodeValue { 
		get{ return this["extcode"];}
		set {if (value==null|| value==DBNull.Value) this["extcode"]= DBNull.Value; else this["extcode"]= value;}
	}
	public String extcodeOriginal { 
		get {if (this["extcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["extcode",DataRowVersion.Original];}
	}
	///<summary>
	///Codice a Barre Produttore
	///</summary>
	public String extbarcode{ 
		get {if (this["extbarcode"]==DBNull.Value)return null; return  (String)this["extbarcode"];}
		set {if (value==null) this["extbarcode"]= DBNull.Value; else this["extbarcode"]= value;}
	}
	public object extbarcodeValue { 
		get{ return this["extbarcode"];}
		set {if (value==null|| value==DBNull.Value) this["extbarcode"]= DBNull.Value; else this["extbarcode"]= value;}
	}
	public String extbarcodeOriginal { 
		get {if (this["extbarcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["extbarcode",DataRowVersion.Original];}
	}
	///<summary>
	///Data scadenza  (dopo la quale il codice non sarà più operativo)
	///</summary>
	public DateTime? validitystop{ 
		get {if (this["validitystop"]==DBNull.Value)return null; return  (DateTime?)this["validitystop"];}
		set {if (value==null) this["validitystop"]= DBNull.Value; else this["validitystop"]= value;}
	}
	public object validitystopValue { 
		get{ return this["validitystop"];}
		set {if (value==null|| value==DBNull.Value) this["validitystop"]= DBNull.Value; else this["validitystop"]= value;}
	}
	public DateTime? validitystopOriginal { 
		get {if (this["validitystop",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["validitystop",DataRowVersion.Original];}
	}
	///<summary>
	///attivo
	///</summary>
	public String active{ 
		get {return  (String)this["active"];}
		set {this["active"]= value;}
	}
	public object activeValue { 
		get{ return this["active"];}
		set {this["active"]= value;}
	}
	public String activeOriginal { 
		get {return  (String)this["active",DataRowVersion.Original];}
	}
	///<summary>
	///Id confezione (tabella package)
	///</summary>
	public Int32? idpackage{ 
		get {if (this["idpackage"]==DBNull.Value)return null; return  (Int32?)this["idpackage"];}
		set {if (value==null) this["idpackage"]= DBNull.Value; else this["idpackage"]= value;}
	}
	public object idpackageValue { 
		get{ return this["idpackage"];}
		set {if (value==null|| value==DBNull.Value) this["idpackage"]= DBNull.Value; else this["idpackage"]= value;}
	}
	public Int32? idpackageOriginal { 
		get {if (this["idpackage",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpackage",DataRowVersion.Original];}
	}
	///<summary>
	///id unità di misura (tabella unit)
	///</summary>
	public Int32? idunit{ 
		get {if (this["idunit"]==DBNull.Value)return null; return  (Int32?)this["idunit"];}
		set {if (value==null) this["idunit"]= DBNull.Value; else this["idunit"]= value;}
	}
	public object idunitValue { 
		get{ return this["idunit"];}
		set {if (value==null|| value==DBNull.Value) this["idunit"]= DBNull.Value; else this["idunit"]= value;}
	}
	public Int32? idunitOriginal { 
		get {if (this["idunit",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idunit",DataRowVersion.Original];}
	}
	///<summary>
	///N. unità per confezione, Coeff. di conversione
	///</summary>
	public Int32? unitsforpackage{ 
		get {if (this["unitsforpackage"]==DBNull.Value)return null; return  (Int32?)this["unitsforpackage"];}
		set {if (value==null) this["unitsforpackage"]= DBNull.Value; else this["unitsforpackage"]= value;}
	}
	public object unitsforpackageValue { 
		get{ return this["unitsforpackage"];}
		set {if (value==null|| value==DBNull.Value) this["unitsforpackage"]= DBNull.Value; else this["unitsforpackage"]= value;}
	}
	public Int32? unitsforpackageOriginal { 
		get {if (this["unitsforpackage",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["unitsforpackage",DataRowVersion.Original];}
	}
	///<summary>
	///Ha data scadenza
	///</summary>
	public String has_expiry{ 
		get {return  (String)this["has_expiry"];}
		set {this["has_expiry"]= value;}
	}
	public object has_expiryValue { 
		get{ return this["has_expiry"];}
		set {this["has_expiry"]= value;}
	}
	public String has_expiryOriginal { 
		get {return  (String)this["has_expiry",DataRowVersion.Original];}
	}
	///<summary>
	///nome utente creazione
	///</summary>
	public String cu{ 
		get {return  (String)this["cu"];}
		set {this["cu"]= value;}
	}
	public object cuValue { 
		get{ return this["cu"];}
		set {this["cu"]= value;}
	}
	public String cuOriginal { 
		get {return  (String)this["cu",DataRowVersion.Original];}
	}
	///<summary>
	///data creazione
	///</summary>
	public DateTime ct{ 
		get {return  (DateTime)this["ct"];}
		set {this["ct"]= value;}
	}
	public object ctValue { 
		get{ return this["ct"];}
		set {this["ct"]= value;}
	}
	public DateTime ctOriginal { 
		get {return  (DateTime)this["ct",DataRowVersion.Original];}
	}
	///<summary>
	///nome ultimo utente modifica
	///</summary>
	public String lu{ 
		get {return  (String)this["lu"];}
		set {this["lu"]= value;}
	}
	public object luValue { 
		get{ return this["lu"];}
		set {this["lu"]= value;}
	}
	public String luOriginal { 
		get {return  (String)this["lu",DataRowVersion.Original];}
	}
	///<summary>
	///data ultima modifica
	///</summary>
	public DateTime lt{ 
		get {return  (DateTime)this["lt"];}
		set {this["lt"]= value;}
	}
	public object ltValue { 
		get{ return this["lt"];}
		set {this["lt"]= value;}
	}
	public DateTime ltOriginal { 
		get {return  (DateTime)this["lt",DataRowVersion.Original];}
	}
	///<summary>
	///Id class. merceologica (tabella listclass)
	///</summary>
	public String idlistclass{ 
		get {return  (String)this["idlistclass"];}
		set {this["idlistclass"]= value;}
	}
	public object idlistclassValue { 
		get{ return this["idlistclass"];}
		set {this["idlistclass"]= value;}
	}
	public String idlistclassOriginal { 
		get {return  (String)this["idlistclass",DataRowVersion.Original];}
	}
	///<summary>
	///immagine
	///</summary>
	public Byte[] pic{ 
		get {if (this["pic"]==DBNull.Value)return null; return  (Byte[])this["pic"];}
		set {if (value==null) this["pic"]= DBNull.Value; else this["pic"]= value;}
	}
	public object picValue { 
		get{ return this["pic"];}
		set {if (value==null|| value==DBNull.Value) this["pic"]= DBNull.Value; else this["pic"]= value;}
	}
	public Byte[] picOriginal { 
		get {if (this["pic",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte[])this["pic",DataRowVersion.Original];}
	}
	///<summary>
	///tipo file immagine
	///</summary>
	public String picext{ 
		get {if (this["picext"]==DBNull.Value)return null; return  (String)this["picext"];}
		set {if (value==null) this["picext"]= DBNull.Value; else this["picext"]= value;}
	}
	public object picextValue { 
		get{ return this["picext"];}
		set {if (value==null|| value==DBNull.Value) this["picext"]= DBNull.Value; else this["picext"]= value;}
	}
	public String picextOriginal { 
		get {if (this["picext",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["picext",DataRowVersion.Original];}
	}
	///<summary>
	///Scorta minima
	///</summary>
	public Decimal? nmin{ 
		get {if (this["nmin"]==DBNull.Value)return null; return  (Decimal?)this["nmin"];}
		set {if (value==null) this["nmin"]= DBNull.Value; else this["nmin"]= value;}
	}
	public object nminValue { 
		get{ return this["nmin"];}
		set {if (value==null|| value==DBNull.Value) this["nmin"]= DBNull.Value; else this["nmin"]= value;}
	}
	public Decimal? nminOriginal { 
		get {if (this["nmin",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["nmin",DataRowVersion.Original];}
	}
	///<summary>
	///Quantità per il riordino
	///</summary>
	public Decimal? ntoreorder{ 
		get {if (this["ntoreorder"]==DBNull.Value)return null; return  (Decimal?)this["ntoreorder"];}
		set {if (value==null) this["ntoreorder"]= DBNull.Value; else this["ntoreorder"]= value;}
	}
	public object ntoreorderValue { 
		get{ return this["ntoreorder"];}
		set {if (value==null|| value==DBNull.Value) this["ntoreorder"]= DBNull.Value; else this["ntoreorder"]= value;}
	}
	public Decimal? ntoreorderOriginal { 
		get {if (this["ntoreorder",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["ntoreorder",DataRowVersion.Original];}
	}
	///<summary>
	///campo non usato
	///</summary>
	public String tounload{ 
		get {if (this["tounload"]==DBNull.Value)return null; return  (String)this["tounload"];}
		set {if (value==null) this["tounload"]= DBNull.Value; else this["tounload"]= value;}
	}
	public object tounloadValue { 
		get{ return this["tounload"];}
		set {if (value==null|| value==DBNull.Value) this["tounload"]= DBNull.Value; else this["tounload"]= value;}
	}
	public String tounloadOriginal { 
		get {if (this["tounload",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tounload",DataRowVersion.Original];}
	}
	///<summary>
	///Tempo di approvigionamento
	///</summary>
	public Int32? timesupply{ 
		get {if (this["timesupply"]==DBNull.Value)return null; return  (Int32?)this["timesupply"];}
		set {if (value==null) this["timesupply"]= DBNull.Value; else this["timesupply"]= value;}
	}
	public object timesupplyValue { 
		get{ return this["timesupply"];}
		set {if (value==null|| value==DBNull.Value) this["timesupply"]= DBNull.Value; else this["timesupply"]= value;}
	}
	public Int32? timesupplyOriginal { 
		get {if (this["timesupply",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["timesupply",DataRowVersion.Original];}
	}
	///<summary>
	///Quantità massima prenotabile
	///</summary>
	public Decimal? nmaxorder{ 
		get {if (this["nmaxorder"]==DBNull.Value)return null; return  (Decimal?)this["nmaxorder"];}
		set {if (value==null) this["nmaxorder"]= DBNull.Value; else this["nmaxorder"]= value;}
	}
	public object nmaxorderValue { 
		get{ return this["nmaxorder"];}
		set {if (value==null|| value==DBNull.Value) this["nmaxorder"]= DBNull.Value; else this["nmaxorder"]= value;}
	}
	public Decimal? nmaxorderOriginal { 
		get {if (this["nmaxorder",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["nmaxorder",DataRowVersion.Original];}
	}
	///<summary>
	///Prezzo di vendita
	///</summary>
	public Decimal? price{ 
		get {if (this["price"]==DBNull.Value)return null; return  (Decimal?)this["price"];}
		set {if (value==null) this["price"]= DBNull.Value; else this["price"]= value;}
	}
	public object priceValue { 
		get{ return this["price"];}
		set {if (value==null|| value==DBNull.Value) this["price"]= DBNull.Value; else this["price"]= value;}
	}
	public Decimal? priceOriginal { 
		get {if (this["price",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["price",DataRowVersion.Original];}
	}
	public String insinfo{ 
		get {if (this["insinfo"]==DBNull.Value)return null; return  (String)this["insinfo"];}
		set {if (value==null) this["insinfo"]= DBNull.Value; else this["insinfo"]= value;}
	}
	public object insinfoValue { 
		get{ return this["insinfo"];}
		set {if (value==null|| value==DBNull.Value) this["insinfo"]= DBNull.Value; else this["insinfo"]= value;}
	}
	public String insinfoOriginal { 
		get {if (this["insinfo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["insinfo",DataRowVersion.Original];}
	}
	public String descrforuser{ 
		get {if (this["descrforuser"]==DBNull.Value)return null; return  (String)this["descrforuser"];}
		set {if (value==null) this["descrforuser"]= DBNull.Value; else this["descrforuser"]= value;}
	}
	public object descrforuserValue { 
		get{ return this["descrforuser"];}
		set {if (value==null|| value==DBNull.Value) this["descrforuser"]= DBNull.Value; else this["descrforuser"]= value;}
	}
	public String descrforuserOriginal { 
		get {if (this["descrforuser",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["descrforuser",DataRowVersion.Original];}
	}
	public Int32? idtassonomia{ 
		get {if (this["idtassonomia"]==DBNull.Value)return null; return  (Int32?)this["idtassonomia"];}
		set {if (value==null) this["idtassonomia"]= DBNull.Value; else this["idtassonomia"]= value;}
	}
	public object idtassonomiaValue { 
		get{ return this["idtassonomia"];}
		set {if (value==null|| value==DBNull.Value) this["idtassonomia"]= DBNull.Value; else this["idtassonomia"]= value;}
	}
	public Int32? idtassonomiaOriginal { 
		get {if (this["idtassonomia",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idtassonomia",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Listino
///</summary>
public class listTable : MetaTableBase<listRow> {
	public listTable() : base("list"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idlist",createColumn("idlist",typeof(int),false,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"intcode",createColumn("intcode",typeof(string),false,false)},
			{"intbarcode",createColumn("intbarcode",typeof(string),true,false)},
			{"extcode",createColumn("extcode",typeof(string),true,false)},
			{"extbarcode",createColumn("extbarcode",typeof(string),true,false)},
			{"validitystop",createColumn("validitystop",typeof(DateTime),true,false)},
			{"active",createColumn("active",typeof(string),false,false)},
			{"idpackage",createColumn("idpackage",typeof(int),true,false)},
			{"idunit",createColumn("idunit",typeof(int),true,false)},
			{"unitsforpackage",createColumn("unitsforpackage",typeof(int),true,false)},
			{"has_expiry",createColumn("has_expiry",typeof(string),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"idlistclass",createColumn("idlistclass",typeof(string),false,false)},
			{"pic",createColumn("pic",typeof(Byte[]),true,false)},
			{"picext",createColumn("picext",typeof(string),true,false)},
			{"nmin",createColumn("nmin",typeof(decimal),true,false)},
			{"ntoreorder",createColumn("ntoreorder",typeof(decimal),true,false)},
			{"tounload",createColumn("tounload",typeof(string),true,false)},
			{"timesupply",createColumn("timesupply",typeof(int),true,false)},
			{"nmaxorder",createColumn("nmaxorder",typeof(decimal),true,false)},
			{"price",createColumn("price",typeof(decimal),true,false)},
			{"insinfo",createColumn("insinfo",typeof(string),true,false)},
			{"descrforuser",createColumn("descrforuser",typeof(string),true,false)},
			{"idtassonomia",createColumn("idtassonomia",typeof(int),true,false)},
		};
	}
}
}
