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
namespace meta_asset {
public class assetRow: MetaRow  {
	public assetRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Id cespite (tabella asset)
	///</summary>
	public Int32? idasset{ 
		get {if (this["idasset"]==DBNull.Value)return null; return  (Int32?)this["idasset"];}
		set {if (value==null) this["idasset"]= DBNull.Value; else this["idasset"]= value;}
	}
	public object idassetValue { 
		get{ return this["idasset"];}
		set {if (value==null|| value==DBNull.Value) this["idasset"]= DBNull.Value; else this["idasset"]= value;}
	}
	public Int32? idassetOriginal { 
		get {if (this["idasset",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idasset",DataRowVersion.Original];}
	}
	///<summary>
	///idpiece
	///</summary>
	public Int32? idpiece{ 
		get {if (this["idpiece"]==DBNull.Value)return null; return  (Int32?)this["idpiece"];}
		set {if (value==null) this["idpiece"]= DBNull.Value; else this["idpiece"]= value;}
	}
	public object idpieceValue { 
		get{ return this["idpiece"];}
		set {if (value==null|| value==DBNull.Value) this["idpiece"]= DBNull.Value; else this["idpiece"]= value;}
	}
	public Int32? idpieceOriginal { 
		get {if (this["idpiece",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpiece",DataRowVersion.Original];}
	}
	///<summary>
	///Id asset precedente il trasferimento di inventario
	///</summary>
	public Int32? idasset_prev{ 
		get {if (this["idasset_prev"]==DBNull.Value)return null; return  (Int32?)this["idasset_prev"];}
		set {if (value==null) this["idasset_prev"]= DBNull.Value; else this["idasset_prev"]= value;}
	}
	public object idasset_prevValue { 
		get{ return this["idasset_prev"];}
		set {if (value==null|| value==DBNull.Value) this["idasset_prev"]= DBNull.Value; else this["idasset_prev"]= value;}
	}
	public Int32? idasset_prevOriginal { 
		get {if (this["idasset_prev",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idasset_prev",DataRowVersion.Original];}
	}
	///<summary>
	///Id piece precedente il trasferimento di inventario
	///</summary>
	public Int32? idpiece_prev{ 
		get {if (this["idpiece_prev"]==DBNull.Value)return null; return  (Int32?)this["idpiece_prev"];}
		set {if (value==null) this["idpiece_prev"]= DBNull.Value; else this["idpiece_prev"]= value;}
	}
	public object idpiece_prevValue { 
		get{ return this["idpiece_prev"];}
		set {if (value==null|| value==DBNull.Value) this["idpiece_prev"]= DBNull.Value; else this["idpiece_prev"]= value;}
	}
	public Int32? idpiece_prevOriginal { 
		get {if (this["idpiece_prev",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpiece_prev",DataRowVersion.Original];}
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
	///Data inizio esistenza. Nel caso di cespiti provenienti da altri dipartimenti questa viene preservata nel travaso. E'' la data usata per stabilire l''età di un cespite ai fini degli ammortamenti.
	///</summary>
	public DateTime? lifestart{ 
		get {if (this["lifestart"]==DBNull.Value)return null; return  (DateTime?)this["lifestart"];}
		set {if (value==null) this["lifestart"]= DBNull.Value; else this["lifestart"]= value;}
	}
	public object lifestartValue { 
		get{ return this["lifestart"];}
		set {if (value==null|| value==DBNull.Value) this["lifestart"]= DBNull.Value; else this["lifestart"]= value;}
	}
	public DateTime? lifestartOriginal { 
		get {if (this["lifestart",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["lifestart",DataRowVersion.Original];}
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
	///Num. carico
	///</summary>
	public Int32? nassetacquire{ 
		get {if (this["nassetacquire"]==DBNull.Value)return null; return  (Int32?)this["nassetacquire"];}
		set {if (value==null) this["nassetacquire"]= DBNull.Value; else this["nassetacquire"]= value;}
	}
	public object nassetacquireValue { 
		get{ return this["nassetacquire"];}
		set {if (value==null|| value==DBNull.Value) this["nassetacquire"]= DBNull.Value; else this["nassetacquire"]= value;}
	}
	public Int32? nassetacquireOriginal { 
		get {if (this["nassetacquire",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["nassetacquire",DataRowVersion.Original];}
	}
	///<summary>
	///Numero inv.
	///</summary>
	public Int32? ninventory{ 
		get {if (this["ninventory"]==DBNull.Value)return null; return  (Int32?)this["ninventory"];}
		set {if (value==null) this["ninventory"]= DBNull.Value; else this["ninventory"]= value;}
	}
	public object ninventoryValue { 
		get{ return this["ninventory"];}
		set {if (value==null|| value==DBNull.Value) this["ninventory"]= DBNull.Value; else this["ninventory"]= value;}
	}
	public Int32? ninventoryOriginal { 
		get {if (this["ninventory",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["ninventory",DataRowVersion.Original];}
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
	///Trasmesso (non più usato)
	///</summary>
	public String transmitted{ 
		get {if (this["transmitted"]==DBNull.Value)return null; return  (String)this["transmitted"];}
		set {if (value==null) this["transmitted"]= DBNull.Value; else this["transmitted"]= value;}
	}
	public object transmittedValue { 
		get{ return this["transmitted"];}
		set {if (value==null|| value==DBNull.Value) this["transmitted"]= DBNull.Value; else this["transmitted"]= value;}
	}
	public String transmittedOriginal { 
		get {if (this["transmitted",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["transmitted",DataRowVersion.Original];}
	}
	///<summary>
	///id buono di scarico (tabella assetunload)
	///</summary>
	public Int32? idassetunload{ 
		get {if (this["idassetunload"]==DBNull.Value)return null; return  (Int32?)this["idassetunload"];}
		set {if (value==null) this["idassetunload"]= DBNull.Value; else this["idassetunload"]= value;}
	}
	public object idassetunloadValue { 
		get{ return this["idassetunload"];}
		set {if (value==null|| value==DBNull.Value) this["idassetunload"]= DBNull.Value; else this["idassetunload"]= value;}
	}
	public Int32? idassetunloadOriginal { 
		get {if (this["idassetunload",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idassetunload",DataRowVersion.Original];}
	}
	///<summary>
	///flag su scarico
	///</summary>
	public Byte? flag{ 
		get {if (this["flag"]==DBNull.Value)return null; return  (Byte?)this["flag"];}
		set {if (value==null) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public object flagValue { 
		get{ return this["flag"];}
		set {if (value==null|| value==DBNull.Value) this["flag"]= DBNull.Value; else this["flag"]= value;}
	}
	public Byte? flagOriginal { 
		get {if (this["flag",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["flag",DataRowVersion.Original];}
	}
	///<summary>
	///campo contenente una codifica di n campi serializzati in un'unica stringa
	///</summary>
	public String multifield{ 
		get {if (this["multifield"]==DBNull.Value)return null; return  (String)this["multifield"];}
		set {if (value==null) this["multifield"]= DBNull.Value; else this["multifield"]= value;}
	}
	public object multifieldValue { 
		get{ return this["multifield"];}
		set {if (value==null|| value==DBNull.Value) this["multifield"]= DBNull.Value; else this["multifield"]= value;}
	}
	public String multifieldOriginal { 
		get {if (this["multifield",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["multifield",DataRowVersion.Original];}
	}
	///<summary>
	///Percentuale ammortamento
	///Indica la percentuale di ammortamento da applicare sul cespite, se valorizzata, l'ammortamento sarà calcolato sulla base di questa aliquota e NON sarà considerata quella configurata nella classificazione inventariale.
	///</summary>
	public Double? amortizationquota{ 
		get {if (this["amortizationquota"]==DBNull.Value)return null; return  (Double?)this["amortizationquota"];}
		set {if (value==null) this["amortizationquota"]= DBNull.Value; else this["amortizationquota"]= value;}
	}
	public object amortizationquotaValue { 
		get{ return this["amortizationquota"];}
		set {if (value==null|| value==DBNull.Value) this["amortizationquota"]= DBNull.Value; else this["amortizationquota"]= value;}
	}
	public Double? amortizationquotaOriginal { 
		get {if (this["amortizationquota",DataRowVersion.Original]==DBNull.Value)return null; return  (Double?)this["amortizationquota",DataRowVersion.Original];}
	}
	///<summary>
	///ID Tipo Ammortamento (tabella inventoryamortization)
	///</summary>
	public Int32? idinventoryamortization{ 
		get {if (this["idinventoryamortization"]==DBNull.Value)return null; return  (Int32?)this["idinventoryamortization"];}
		set {if (value==null) this["idinventoryamortization"]= DBNull.Value; else this["idinventoryamortization"]= value;}
	}
	public object idinventoryamortizationValue { 
		get{ return this["idinventoryamortization"];}
		set {if (value==null|| value==DBNull.Value) this["idinventoryamortization"]= DBNull.Value; else this["idinventoryamortization"]= value;}
	}
	public Int32? idinventoryamortizationOriginal { 
		get {if (this["idinventoryamortization",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinventoryamortization",DataRowVersion.Original];}
	}
	///<summary>
	///Consegnatario corrente (tabella manager)
	///</summary>
	public Int32? idcurrman{ 
		get {if (this["idcurrman"]==DBNull.Value)return null; return  (Int32?)this["idcurrman"];}
		set {if (value==null) this["idcurrman"]= DBNull.Value; else this["idcurrman"]= value;}
	}
	public object idcurrmanValue { 
		get{ return this["idcurrman"];}
		set {if (value==null|| value==DBNull.Value) this["idcurrman"]= DBNull.Value; else this["idcurrman"]= value;}
	}
	public Int32? idcurrmanOriginal { 
		get {if (this["idcurrman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcurrman",DataRowVersion.Original];}
	}
	///<summary>
	///Subconsegnatario corrente (tabella manager)
	///</summary>
	public Int32? idcurrsubman{ 
		get {if (this["idcurrsubman"]==DBNull.Value)return null; return  (Int32?)this["idcurrsubman"];}
		set {if (value==null) this["idcurrsubman"]= DBNull.Value; else this["idcurrsubman"]= value;}
	}
	public object idcurrsubmanValue { 
		get{ return this["idcurrsubman"];}
		set {if (value==null|| value==DBNull.Value) this["idcurrsubman"]= DBNull.Value; else this["idcurrsubman"]= value;}
	}
	public Int32? idcurrsubmanOriginal { 
		get {if (this["idcurrsubman",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcurrsubman",DataRowVersion.Original];}
	}
	///<summary>
	///ubicazione corrente (tabella location)
	///</summary>
	public Int32? idcurrlocation{ 
		get {if (this["idcurrlocation"]==DBNull.Value)return null; return  (Int32?)this["idcurrlocation"];}
		set {if (value==null) this["idcurrlocation"]= DBNull.Value; else this["idcurrlocation"]= value;}
	}
	public object idcurrlocationValue { 
		get{ return this["idcurrlocation"];}
		set {if (value==null|| value==DBNull.Value) this["idcurrlocation"]= DBNull.Value; else this["idcurrlocation"]= value;}
	}
	public Int32? idcurrlocationOriginal { 
		get {if (this["idcurrlocation",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idcurrlocation",DataRowVersion.Original];}
	}
	///<summary>
	///Id inventario (tabella inventory)
	///</summary>
	public Int32? idinventory{ 
		get {if (this["idinventory"]==DBNull.Value)return null; return  (Int32?)this["idinventory"];}
		set {if (value==null) this["idinventory"]= DBNull.Value; else this["idinventory"]= value;}
	}
	public object idinventoryValue { 
		get{ return this["idinventory"];}
		set {if (value==null|| value==DBNull.Value) this["idinventory"]= DBNull.Value; else this["idinventory"]= value;}
	}
	public Int32? idinventoryOriginal { 
		get {if (this["idinventory",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinventory",DataRowVersion.Original];}
	}
	public String rfid{ 
		get {if (this["rfid"]==DBNull.Value)return null; return  (String)this["rfid"];}
		set {if (value==null) this["rfid"]= DBNull.Value; else this["rfid"]= value;}
	}
	public object rfidValue { 
		get{ return this["rfid"];}
		set {if (value==null|| value==DBNull.Value) this["rfid"]= DBNull.Value; else this["rfid"]= value;}
	}
	public String rfidOriginal { 
		get {if (this["rfid",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["rfid",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Cespiti e accessori
///</summary>
public class assetTable : MetaTableBase<assetRow> {
	public assetTable() : base("asset"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idasset",createColumn("idasset",typeof(int),false,false)},
			{"idpiece",createColumn("idpiece",typeof(int),false,false)},
			{"idasset_prev",createColumn("idasset_prev",typeof(int),true,false)},
			{"idpiece_prev",createColumn("idpiece_prev",typeof(int),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"lifestart",createColumn("lifestart",typeof(DateTime),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"nassetacquire",createColumn("nassetacquire",typeof(int),true,false)},
			{"ninventory",createColumn("ninventory",typeof(int),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"transmitted",createColumn("transmitted",typeof(string),true,false)},
			{"idassetunload",createColumn("idassetunload",typeof(int),true,false)},
			{"flag",createColumn("flag",typeof(byte),false,false)},
			{"multifield",createColumn("multifield",typeof(string),true,false)},
			{"amortizationquota",createColumn("amortizationquota",typeof(double),true,false)},
			{"idinventoryamortization",createColumn("idinventoryamortization",typeof(int),true,false)},
			{"idcurrman",createColumn("idcurrman",typeof(int),true,false)},
			{"idcurrsubman",createColumn("idcurrsubman",typeof(int),true,false)},
			{"idcurrlocation",createColumn("idcurrlocation",typeof(int),true,false)},
			{"idinventory",createColumn("idinventory",typeof(int),true,false)},
			{"rfid",createColumn("rfid",typeof(string),true,false)},
		};
	}
}
}
