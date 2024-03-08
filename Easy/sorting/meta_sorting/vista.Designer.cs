
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
using System.Runtime.Serialization;
using metadatalibrary;
#pragma warning disable 1591
namespace meta_sorting {
public class sortingRow: MetaRow  {
	public sortingRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
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
	///Default decimale 1
	///</summary>
	public Decimal? defaultN1{ 
		get {if (this["defaultN1"]==DBNull.Value)return null; return  (Decimal?)this["defaultN1"];}
		set {if (value==null) this["defaultN1"]= DBNull.Value; else this["defaultN1"]= value;}
	}
	public object defaultN1Value { 
		get{ return this["defaultN1"];}
		set {if (value==null|| value==DBNull.Value) this["defaultN1"]= DBNull.Value; else this["defaultN1"]= value;}
	}
	public Decimal? defaultN1Original { 
		get {if (this["defaultN1",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["defaultN1",DataRowVersion.Original];}
	}
	///<summary>
	///Default decimale 2
	///</summary>
	public Decimal? defaultN2{ 
		get {if (this["defaultN2"]==DBNull.Value)return null; return  (Decimal?)this["defaultN2"];}
		set {if (value==null) this["defaultN2"]= DBNull.Value; else this["defaultN2"]= value;}
	}
	public object defaultN2Value { 
		get{ return this["defaultN2"];}
		set {if (value==null|| value==DBNull.Value) this["defaultN2"]= DBNull.Value; else this["defaultN2"]= value;}
	}
	public Decimal? defaultN2Original { 
		get {if (this["defaultN2",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["defaultN2",DataRowVersion.Original];}
	}
	///<summary>
	///Default decimale 3
	///</summary>
	public Decimal? defaultN3{ 
		get {if (this["defaultN3"]==DBNull.Value)return null; return  (Decimal?)this["defaultN3"];}
		set {if (value==null) this["defaultN3"]= DBNull.Value; else this["defaultN3"]= value;}
	}
	public object defaultN3Value { 
		get{ return this["defaultN3"];}
		set {if (value==null|| value==DBNull.Value) this["defaultN3"]= DBNull.Value; else this["defaultN3"]= value;}
	}
	public Decimal? defaultN3Original { 
		get {if (this["defaultN3",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["defaultN3",DataRowVersion.Original];}
	}
	///<summary>
	///Default decimale 4
	///</summary>
	public Decimal? defaultN4{ 
		get {if (this["defaultN4"]==DBNull.Value)return null; return  (Decimal?)this["defaultN4"];}
		set {if (value==null) this["defaultN4"]= DBNull.Value; else this["defaultN4"]= value;}
	}
	public object defaultN4Value { 
		get{ return this["defaultN4"];}
		set {if (value==null|| value==DBNull.Value) this["defaultN4"]= DBNull.Value; else this["defaultN4"]= value;}
	}
	public Decimal? defaultN4Original { 
		get {if (this["defaultN4",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["defaultN4",DataRowVersion.Original];}
	}
	///<summary>
	///Default decimale 5
	///</summary>
	public Decimal? defaultN5{ 
		get {if (this["defaultN5"]==DBNull.Value)return null; return  (Decimal?)this["defaultN5"];}
		set {if (value==null) this["defaultN5"]= DBNull.Value; else this["defaultN5"]= value;}
	}
	public object defaultN5Value { 
		get{ return this["defaultN5"];}
		set {if (value==null|| value==DBNull.Value) this["defaultN5"]= DBNull.Value; else this["defaultN5"]= value;}
	}
	public Decimal? defaultN5Original { 
		get {if (this["defaultN5",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["defaultN5",DataRowVersion.Original];}
	}
	///<summary>
	///Default stringa 1
	///</summary>
	public String defaultS1{ 
		get {if (this["defaultS1"]==DBNull.Value)return null; return  (String)this["defaultS1"];}
		set {if (value==null) this["defaultS1"]= DBNull.Value; else this["defaultS1"]= value;}
	}
	public object defaultS1Value { 
		get{ return this["defaultS1"];}
		set {if (value==null|| value==DBNull.Value) this["defaultS1"]= DBNull.Value; else this["defaultS1"]= value;}
	}
	public String defaultS1Original { 
		get {if (this["defaultS1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["defaultS1",DataRowVersion.Original];}
	}
	///<summary>
	///Default stringa 2
	///</summary>
	public String defaultS2{ 
		get {if (this["defaultS2"]==DBNull.Value)return null; return  (String)this["defaultS2"];}
		set {if (value==null) this["defaultS2"]= DBNull.Value; else this["defaultS2"]= value;}
	}
	public object defaultS2Value { 
		get{ return this["defaultS2"];}
		set {if (value==null|| value==DBNull.Value) this["defaultS2"]= DBNull.Value; else this["defaultS2"]= value;}
	}
	public String defaultS2Original { 
		get {if (this["defaultS2",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["defaultS2",DataRowVersion.Original];}
	}
	///<summary>
	///Default stringa 3
	///</summary>
	public String defaultS3{ 
		get {if (this["defaultS3"]==DBNull.Value)return null; return  (String)this["defaultS3"];}
		set {if (value==null) this["defaultS3"]= DBNull.Value; else this["defaultS3"]= value;}
	}
	public object defaultS3Value { 
		get{ return this["defaultS3"];}
		set {if (value==null|| value==DBNull.Value) this["defaultS3"]= DBNull.Value; else this["defaultS3"]= value;}
	}
	public String defaultS3Original { 
		get {if (this["defaultS3",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["defaultS3",DataRowVersion.Original];}
	}
	///<summary>
	///Default stringa 4
	///</summary>
	public String defaultS4{ 
		get {if (this["defaultS4"]==DBNull.Value)return null; return  (String)this["defaultS4"];}
		set {if (value==null) this["defaultS4"]= DBNull.Value; else this["defaultS4"]= value;}
	}
	public object defaultS4Value { 
		get{ return this["defaultS4"];}
		set {if (value==null|| value==DBNull.Value) this["defaultS4"]= DBNull.Value; else this["defaultS4"]= value;}
	}
	public String defaultS4Original { 
		get {if (this["defaultS4",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["defaultS4",DataRowVersion.Original];}
	}
	///<summary>
	///Default stringa 5
	///</summary>
	public String defaultS5{ 
		get {if (this["defaultS5"]==DBNull.Value)return null; return  (String)this["defaultS5"];}
		set {if (value==null) this["defaultS5"]= DBNull.Value; else this["defaultS5"]= value;}
	}
	public object defaultS5Value { 
		get{ return this["defaultS5"];}
		set {if (value==null|| value==DBNull.Value) this["defaultS5"]= DBNull.Value; else this["defaultS5"]= value;}
	}
	public String defaultS5Original { 
		get {if (this["defaultS5",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["defaultS5",DataRowVersion.Original];}
	}
	///<summary>
	///Default numerico 1
	///</summary>
	public Decimal? defaultv1{ 
		get {if (this["defaultv1"]==DBNull.Value)return null; return  (Decimal?)this["defaultv1"];}
		set {if (value==null) this["defaultv1"]= DBNull.Value; else this["defaultv1"]= value;}
	}
	public object defaultv1Value { 
		get{ return this["defaultv1"];}
		set {if (value==null|| value==DBNull.Value) this["defaultv1"]= DBNull.Value; else this["defaultv1"]= value;}
	}
	public Decimal? defaultv1Original { 
		get {if (this["defaultv1",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["defaultv1",DataRowVersion.Original];}
	}
	///<summary>
	///Default numerico 2
	///</summary>
	public Decimal? defaultv2{ 
		get {if (this["defaultv2"]==DBNull.Value)return null; return  (Decimal?)this["defaultv2"];}
		set {if (value==null) this["defaultv2"]= DBNull.Value; else this["defaultv2"]= value;}
	}
	public object defaultv2Value { 
		get{ return this["defaultv2"];}
		set {if (value==null|| value==DBNull.Value) this["defaultv2"]= DBNull.Value; else this["defaultv2"]= value;}
	}
	public Decimal? defaultv2Original { 
		get {if (this["defaultv2",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["defaultv2",DataRowVersion.Original];}
	}
	///<summary>
	///Default numerico 3
	///</summary>
	public Decimal? defaultv3{ 
		get {if (this["defaultv3"]==DBNull.Value)return null; return  (Decimal?)this["defaultv3"];}
		set {if (value==null) this["defaultv3"]= DBNull.Value; else this["defaultv3"]= value;}
	}
	public object defaultv3Value { 
		get{ return this["defaultv3"];}
		set {if (value==null|| value==DBNull.Value) this["defaultv3"]= DBNull.Value; else this["defaultv3"]= value;}
	}
	public Decimal? defaultv3Original { 
		get {if (this["defaultv3",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["defaultv3",DataRowVersion.Original];}
	}
	///<summary>
	///Default numerico 4
	///</summary>
	public Decimal? defaultv4{ 
		get {if (this["defaultv4"]==DBNull.Value)return null; return  (Decimal?)this["defaultv4"];}
		set {if (value==null) this["defaultv4"]= DBNull.Value; else this["defaultv4"]= value;}
	}
	public object defaultv4Value { 
		get{ return this["defaultv4"];}
		set {if (value==null|| value==DBNull.Value) this["defaultv4"]= DBNull.Value; else this["defaultv4"]= value;}
	}
	public Decimal? defaultv4Original { 
		get {if (this["defaultv4",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["defaultv4",DataRowVersion.Original];}
	}
	///<summary>
	///Default numerico 5
	///</summary>
	public Decimal? defaultv5{ 
		get {if (this["defaultv5"]==DBNull.Value)return null; return  (Decimal?)this["defaultv5"];}
		set {if (value==null) this["defaultv5"]= DBNull.Value; else this["defaultv5"]= value;}
	}
	public object defaultv5Value { 
		get{ return this["defaultv5"];}
		set {if (value==null|| value==DBNull.Value) this["defaultv5"]= DBNull.Value; else this["defaultv5"]= value;}
	}
	public Decimal? defaultv5Original { 
		get {if (this["defaultv5",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["defaultv5",DataRowVersion.Original];}
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
	///Flag "non registrare le date"
	///	 N: Registra le date di competenza
	///	 S: Non registrare le date di competenza
	///</summary>
	public String flagnodate{ 
		get {if (this["flagnodate"]==DBNull.Value)return null; return  (String)this["flagnodate"];}
		set {if (value==null) this["flagnodate"]= DBNull.Value; else this["flagnodate"]= value;}
	}
	public object flagnodateValue { 
		get{ return this["flagnodate"];}
		set {if (value==null|| value==DBNull.Value) this["flagnodate"]= DBNull.Value; else this["flagnodate"]= value;}
	}
	public String flagnodateOriginal { 
		get {if (this["flagnodate",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagnodate",DataRowVersion.Original];}
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
	///Tipo movimento
	///</summary>
	public String movkind{ 
		get {if (this["movkind"]==DBNull.Value)return null; return  (String)this["movkind"];}
		set {if (value==null) this["movkind"]= DBNull.Value; else this["movkind"]= value;}
	}
	public object movkindValue { 
		get{ return this["movkind"];}
		set {if (value==null|| value==DBNull.Value) this["movkind"]= DBNull.Value; else this["movkind"]= value;}
	}
	public String movkindOriginal { 
		get {if (this["movkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["movkind",DataRowVersion.Original];}
	}
	///<summary>
	///Ordine di stampa
	///</summary>
	public String printingorder{ 
		get {if (this["printingorder"]==DBNull.Value)return null; return  (String)this["printingorder"];}
		set {if (value==null) this["printingorder"]= DBNull.Value; else this["printingorder"]= value;}
	}
	public object printingorderValue { 
		get{ return this["printingorder"];}
		set {if (value==null|| value==DBNull.Value) this["printingorder"]= DBNull.Value; else this["printingorder"]= value;}
	}
	public String printingorderOriginal { 
		get {if (this["printingorder",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["printingorder",DataRowVersion.Original];}
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
	///Codice classificazione
	///</summary>
	public String sortcode{ 
		get {if (this["sortcode"]==DBNull.Value)return null; return  (String)this["sortcode"];}
		set {if (value==null) this["sortcode"]= DBNull.Value; else this["sortcode"]= value;}
	}
	public object sortcodeValue { 
		get{ return this["sortcode"];}
		set {if (value==null|| value==DBNull.Value) this["sortcode"]= DBNull.Value; else this["sortcode"]= value;}
	}
	public String sortcodeOriginal { 
		get {if (this["sortcode",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["sortcode",DataRowVersion.Original];}
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
	///Id tipo classificazione (tabella sortingkind)
	///</summary>
	public Int32? idsorkind{ 
		get {if (this["idsorkind"]==DBNull.Value)return null; return  (Int32?)this["idsorkind"];}
		set {if (value==null) this["idsorkind"]= DBNull.Value; else this["idsorkind"]= value;}
	}
	public object idsorkindValue { 
		get{ return this["idsorkind"];}
		set {if (value==null|| value==DBNull.Value) this["idsorkind"]= DBNull.Value; else this["idsorkind"]= value;}
	}
	public Int32? idsorkindOriginal { 
		get {if (this["idsorkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsorkind",DataRowVersion.Original];}
	}
	///<summary>
	///id classificazione (tabella sorting)
	///</summary>
	public Int32? idsor{ 
		get {if (this["idsor"]==DBNull.Value)return null; return  (Int32?)this["idsor"];}
		set {if (value==null) this["idsor"]= DBNull.Value; else this["idsor"]= value;}
	}
	public object idsorValue { 
		get{ return this["idsor"];}
		set {if (value==null|| value==DBNull.Value) this["idsor"]= DBNull.Value; else this["idsor"]= value;}
	}
	public Int32? idsorOriginal { 
		get {if (this["idsor",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor",DataRowVersion.Original];}
	}
	///<summary>
	///Chiave parent classificazione (tabella sorting)
	///</summary>
	public Int32? paridsor{ 
		get {if (this["paridsor"]==DBNull.Value)return null; return  (Int32?)this["paridsor"];}
		set {if (value==null) this["paridsor"]= DBNull.Value; else this["paridsor"]= value;}
	}
	public object paridsorValue { 
		get{ return this["paridsor"];}
		set {if (value==null|| value==DBNull.Value) this["paridsor"]= DBNull.Value; else this["paridsor"]= value;}
	}
	public Int32? paridsorOriginal { 
		get {if (this["paridsor",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["paridsor",DataRowVersion.Original];}
	}
	///<summary>
	///N. livello
	///</summary>
	public Byte? nlevel{ 
		get {if (this["nlevel"]==DBNull.Value)return null; return  (Byte?)this["nlevel"];}
		set {if (value==null) this["nlevel"]= DBNull.Value; else this["nlevel"]= value;}
	}
	public object nlevelValue { 
		get{ return this["nlevel"];}
		set {if (value==null|| value==DBNull.Value) this["nlevel"]= DBNull.Value; else this["nlevel"]= value;}
	}
	public Byte? nlevelOriginal { 
		get {if (this["nlevel",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["nlevel",DataRowVersion.Original];}
	}
	///<summary>
	///data inizio
	///</summary>
	public Int16? start{ 
		get {if (this["start"]==DBNull.Value)return null; return  (Int16?)this["start"];}
		set {if (value==null) this["start"]= DBNull.Value; else this["start"]= value;}
	}
	public object startValue { 
		get{ return this["start"];}
		set {if (value==null|| value==DBNull.Value) this["start"]= DBNull.Value; else this["start"]= value;}
	}
	public Int16? startOriginal { 
		get {if (this["start",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["start",DataRowVersion.Original];}
	}
	///<summary>
	///data fine
	///</summary>
	public Int16? stop{ 
		get {if (this["stop"]==DBNull.Value)return null; return  (Int16?)this["stop"];}
		set {if (value==null) this["stop"]= DBNull.Value; else this["stop"]= value;}
	}
	public object stopValue { 
		get{ return this["stop"];}
		set {if (value==null|| value==DBNull.Value) this["stop"]= DBNull.Value; else this["stop"]= value;}
	}
	public Int16? stopOriginal { 
		get {if (this["stop",DataRowVersion.Original]==DBNull.Value)return null; return  (Int16?)this["stop",DataRowVersion.Original];}
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
	#endregion

}
///<summary>
///Classificazione Movimenti
///</summary>
public class sortingTable : MetaTableBase<sortingRow> {
	public sortingTable() : base("sorting"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(String),false,false)},
			{"defaultN1",createColumn("defaultN1",typeof(Decimal),true,false)},
			{"defaultN2",createColumn("defaultN2",typeof(Decimal),true,false)},
			{"defaultN3",createColumn("defaultN3",typeof(Decimal),true,false)},
			{"defaultN4",createColumn("defaultN4",typeof(Decimal),true,false)},
			{"defaultN5",createColumn("defaultN5",typeof(Decimal),true,false)},
			{"defaultS1",createColumn("defaultS1",typeof(String),true,false)},
			{"defaultS2",createColumn("defaultS2",typeof(String),true,false)},
			{"defaultS3",createColumn("defaultS3",typeof(String),true,false)},
			{"defaultS4",createColumn("defaultS4",typeof(String),true,false)},
			{"defaultS5",createColumn("defaultS5",typeof(String),true,false)},
			{"defaultv1",createColumn("defaultv1",typeof(Decimal),true,false)},
			{"defaultv2",createColumn("defaultv2",typeof(Decimal),true,false)},
			{"defaultv3",createColumn("defaultv3",typeof(Decimal),true,false)},
			{"defaultv4",createColumn("defaultv4",typeof(Decimal),true,false)},
			{"defaultv5",createColumn("defaultv5",typeof(Decimal),true,false)},
			{"description",createColumn("description",typeof(String),false,false)},
			{"flagnodate",createColumn("flagnodate",typeof(String),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(String),false,false)},
			{"movkind",createColumn("movkind",typeof(String),true,false)},
			{"printingorder",createColumn("printingorder",typeof(String),true,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"sortcode",createColumn("sortcode",typeof(String),false,false)},
			{"txt",createColumn("txt",typeof(String),true,false)},
			{"idsorkind",createColumn("idsorkind",typeof(Int32),false,false)},
			{"idsor",createColumn("idsor",typeof(Int32),false,false)},
			{"paridsor",createColumn("paridsor",typeof(Int32),true,false)},
			{"nlevel",createColumn("nlevel",typeof(Byte),false,false)},
			{"start",createColumn("start",typeof(Int16),true,false)},
			{"stop",createColumn("stop",typeof(Int16),true,false)},
			{"email",createColumn("email",typeof(String),true,false)},
			{"idsor01",createColumn("idsor01",typeof(Int32),true,false)},
			{"idsor02",createColumn("idsor02",typeof(Int32),true,false)},
			{"idsor03",createColumn("idsor03",typeof(Int32),true,false)},
			{"idsor04",createColumn("idsor04",typeof(Int32),true,false)},
			{"idsor05",createColumn("idsor05",typeof(Int32),true,false)},
		};
	}
}
}
