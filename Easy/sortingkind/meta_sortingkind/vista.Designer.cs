
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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
namespace meta_sortingkind {
public class sortingkindRow: MetaRow  {
	public sortingkindRow(DataRowBuilder rb) : base(rb) {} 

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
	///Usa campi data inizio e fine (finanziario)
	///	 N: Non usare campi data inizio e fine (finanziario)
	///	 S: Usa campi data inizio e fine (finanziario)
	///</summary>
	public String flagdate{ 
		get {if (this["flagdate"]==DBNull.Value)return null; return  (String)this["flagdate"];}
		set {if (value==null) this["flagdate"]= DBNull.Value; else this["flagdate"]= value;}
	}
	public object flagdateValue { 
		get{ return this["flagdate"];}
		set {if (value==null|| value==DBNull.Value) this["flagdate"]= DBNull.Value; else this["flagdate"]= value;}
	}
	public String flagdateOriginal { 
		get {if (this["flagdate",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagdate",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è obbligatorio
	///</summary>
	public String forcedN1{ 
		get {if (this["forcedN1"]==DBNull.Value)return null; return  (String)this["forcedN1"];}
		set {if (value==null) this["forcedN1"]= DBNull.Value; else this["forcedN1"]= value;}
	}
	public object forcedN1Value { 
		get{ return this["forcedN1"];}
		set {if (value==null|| value==DBNull.Value) this["forcedN1"]= DBNull.Value; else this["forcedN1"]= value;}
	}
	public String forcedN1Original { 
		get {if (this["forcedN1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forcedN1",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è obbligatorio
	///</summary>
	public String forcedN2{ 
		get {if (this["forcedN2"]==DBNull.Value)return null; return  (String)this["forcedN2"];}
		set {if (value==null) this["forcedN2"]= DBNull.Value; else this["forcedN2"]= value;}
	}
	public object forcedN2Value { 
		get{ return this["forcedN2"];}
		set {if (value==null|| value==DBNull.Value) this["forcedN2"]= DBNull.Value; else this["forcedN2"]= value;}
	}
	public String forcedN2Original { 
		get {if (this["forcedN2",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forcedN2",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è obbligatorio
	///</summary>
	public String forcedN3{ 
		get {if (this["forcedN3"]==DBNull.Value)return null; return  (String)this["forcedN3"];}
		set {if (value==null) this["forcedN3"]= DBNull.Value; else this["forcedN3"]= value;}
	}
	public object forcedN3Value { 
		get{ return this["forcedN3"];}
		set {if (value==null|| value==DBNull.Value) this["forcedN3"]= DBNull.Value; else this["forcedN3"]= value;}
	}
	public String forcedN3Original { 
		get {if (this["forcedN3",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forcedN3",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è obbligatorio
	///</summary>
	public String forcedN4{ 
		get {if (this["forcedN4"]==DBNull.Value)return null; return  (String)this["forcedN4"];}
		set {if (value==null) this["forcedN4"]= DBNull.Value; else this["forcedN4"]= value;}
	}
	public object forcedN4Value { 
		get{ return this["forcedN4"];}
		set {if (value==null|| value==DBNull.Value) this["forcedN4"]= DBNull.Value; else this["forcedN4"]= value;}
	}
	public String forcedN4Original { 
		get {if (this["forcedN4",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forcedN4",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è obbligatorio
	///</summary>
	public String forcedN5{ 
		get {if (this["forcedN5"]==DBNull.Value)return null; return  (String)this["forcedN5"];}
		set {if (value==null) this["forcedN5"]= DBNull.Value; else this["forcedN5"]= value;}
	}
	public object forcedN5Value { 
		get{ return this["forcedN5"];}
		set {if (value==null|| value==DBNull.Value) this["forcedN5"]= DBNull.Value; else this["forcedN5"]= value;}
	}
	public String forcedN5Original { 
		get {if (this["forcedN5",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forcedN5",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è obbligatorio
	///</summary>
	public String forcedS1{ 
		get {if (this["forcedS1"]==DBNull.Value)return null; return  (String)this["forcedS1"];}
		set {if (value==null) this["forcedS1"]= DBNull.Value; else this["forcedS1"]= value;}
	}
	public object forcedS1Value { 
		get{ return this["forcedS1"];}
		set {if (value==null|| value==DBNull.Value) this["forcedS1"]= DBNull.Value; else this["forcedS1"]= value;}
	}
	public String forcedS1Original { 
		get {if (this["forcedS1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forcedS1",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è obbligatorio
	///</summary>
	public String forcedS2{ 
		get {if (this["forcedS2"]==DBNull.Value)return null; return  (String)this["forcedS2"];}
		set {if (value==null) this["forcedS2"]= DBNull.Value; else this["forcedS2"]= value;}
	}
	public object forcedS2Value { 
		get{ return this["forcedS2"];}
		set {if (value==null|| value==DBNull.Value) this["forcedS2"]= DBNull.Value; else this["forcedS2"]= value;}
	}
	public String forcedS2Original { 
		get {if (this["forcedS2",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forcedS2",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è obbligatorio
	///</summary>
	public String forcedS3{ 
		get {if (this["forcedS3"]==DBNull.Value)return null; return  (String)this["forcedS3"];}
		set {if (value==null) this["forcedS3"]= DBNull.Value; else this["forcedS3"]= value;}
	}
	public object forcedS3Value { 
		get{ return this["forcedS3"];}
		set {if (value==null|| value==DBNull.Value) this["forcedS3"]= DBNull.Value; else this["forcedS3"]= value;}
	}
	public String forcedS3Original { 
		get {if (this["forcedS3",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forcedS3",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è obbligatorio
	///</summary>
	public String forcedS4{ 
		get {if (this["forcedS4"]==DBNull.Value)return null; return  (String)this["forcedS4"];}
		set {if (value==null) this["forcedS4"]= DBNull.Value; else this["forcedS4"]= value;}
	}
	public object forcedS4Value { 
		get{ return this["forcedS4"];}
		set {if (value==null|| value==DBNull.Value) this["forcedS4"]= DBNull.Value; else this["forcedS4"]= value;}
	}
	public String forcedS4Original { 
		get {if (this["forcedS4",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forcedS4",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è obbligatorio
	///</summary>
	public String forcedS5{ 
		get {if (this["forcedS5"]==DBNull.Value)return null; return  (String)this["forcedS5"];}
		set {if (value==null) this["forcedS5"]= DBNull.Value; else this["forcedS5"]= value;}
	}
	public object forcedS5Value { 
		get{ return this["forcedS5"];}
		set {if (value==null|| value==DBNull.Value) this["forcedS5"]= DBNull.Value; else this["forcedS5"]= value;}
	}
	public String forcedS5Original { 
		get {if (this["forcedS5",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forcedS5",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è obbligatorio
	///</summary>
	public String forcedv1{ 
		get {if (this["forcedv1"]==DBNull.Value)return null; return  (String)this["forcedv1"];}
		set {if (value==null) this["forcedv1"]= DBNull.Value; else this["forcedv1"]= value;}
	}
	public object forcedv1Value { 
		get{ return this["forcedv1"];}
		set {if (value==null|| value==DBNull.Value) this["forcedv1"]= DBNull.Value; else this["forcedv1"]= value;}
	}
	public String forcedv1Original { 
		get {if (this["forcedv1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forcedv1",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è obbligatorio
	///</summary>
	public String forcedv2{ 
		get {if (this["forcedv2"]==DBNull.Value)return null; return  (String)this["forcedv2"];}
		set {if (value==null) this["forcedv2"]= DBNull.Value; else this["forcedv2"]= value;}
	}
	public object forcedv2Value { 
		get{ return this["forcedv2"];}
		set {if (value==null|| value==DBNull.Value) this["forcedv2"]= DBNull.Value; else this["forcedv2"]= value;}
	}
	public String forcedv2Original { 
		get {if (this["forcedv2",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forcedv2",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è obbligatorio
	///</summary>
	public String forcedv3{ 
		get {if (this["forcedv3"]==DBNull.Value)return null; return  (String)this["forcedv3"];}
		set {if (value==null) this["forcedv3"]= DBNull.Value; else this["forcedv3"]= value;}
	}
	public object forcedv3Value { 
		get{ return this["forcedv3"];}
		set {if (value==null|| value==DBNull.Value) this["forcedv3"]= DBNull.Value; else this["forcedv3"]= value;}
	}
	public String forcedv3Original { 
		get {if (this["forcedv3",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forcedv3",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è obbligatorio
	///</summary>
	public String forcedv4{ 
		get {if (this["forcedv4"]==DBNull.Value)return null; return  (String)this["forcedv4"];}
		set {if (value==null) this["forcedv4"]= DBNull.Value; else this["forcedv4"]= value;}
	}
	public object forcedv4Value { 
		get{ return this["forcedv4"];}
		set {if (value==null|| value==DBNull.Value) this["forcedv4"]= DBNull.Value; else this["forcedv4"]= value;}
	}
	public String forcedv4Original { 
		get {if (this["forcedv4",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forcedv4",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è obbligatorio
	///</summary>
	public String forcedv5{ 
		get {if (this["forcedv5"]==DBNull.Value)return null; return  (String)this["forcedv5"];}
		set {if (value==null) this["forcedv5"]= DBNull.Value; else this["forcedv5"]= value;}
	}
	public object forcedv5Value { 
		get{ return this["forcedv5"];}
		set {if (value==null|| value==DBNull.Value) this["forcedv5"]= DBNull.Value; else this["forcedv5"]= value;}
	}
	public String forcedv5Original { 
		get {if (this["forcedv5",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["forcedv5",DataRowVersion.Original];}
	}
	///<summary>
	///etichetta per la data
	///</summary>
	public String labelfordate{ 
		get {if (this["labelfordate"]==DBNull.Value)return null; return  (String)this["labelfordate"];}
		set {if (value==null) this["labelfordate"]= DBNull.Value; else this["labelfordate"]= value;}
	}
	public object labelfordateValue { 
		get{ return this["labelfordate"];}
		set {if (value==null|| value==DBNull.Value) this["labelfordate"]= DBNull.Value; else this["labelfordate"]= value;}
	}
	public String labelfordateOriginal { 
		get {if (this["labelfordate",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["labelfordate",DataRowVersion.Original];}
	}
	///<summary>
	///etichetta per campo corrispondente
	///</summary>
	public String labeln1{ 
		get {if (this["labeln1"]==DBNull.Value)return null; return  (String)this["labeln1"];}
		set {if (value==null) this["labeln1"]= DBNull.Value; else this["labeln1"]= value;}
	}
	public object labeln1Value { 
		get{ return this["labeln1"];}
		set {if (value==null|| value==DBNull.Value) this["labeln1"]= DBNull.Value; else this["labeln1"]= value;}
	}
	public String labeln1Original { 
		get {if (this["labeln1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["labeln1",DataRowVersion.Original];}
	}
	///<summary>
	///etichetta per campo corrispondente
	///</summary>
	public String labeln2{ 
		get {if (this["labeln2"]==DBNull.Value)return null; return  (String)this["labeln2"];}
		set {if (value==null) this["labeln2"]= DBNull.Value; else this["labeln2"]= value;}
	}
	public object labeln2Value { 
		get{ return this["labeln2"];}
		set {if (value==null|| value==DBNull.Value) this["labeln2"]= DBNull.Value; else this["labeln2"]= value;}
	}
	public String labeln2Original { 
		get {if (this["labeln2",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["labeln2",DataRowVersion.Original];}
	}
	///<summary>
	///etichetta per campo corrispondente
	///</summary>
	public String labeln3{ 
		get {if (this["labeln3"]==DBNull.Value)return null; return  (String)this["labeln3"];}
		set {if (value==null) this["labeln3"]= DBNull.Value; else this["labeln3"]= value;}
	}
	public object labeln3Value { 
		get{ return this["labeln3"];}
		set {if (value==null|| value==DBNull.Value) this["labeln3"]= DBNull.Value; else this["labeln3"]= value;}
	}
	public String labeln3Original { 
		get {if (this["labeln3",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["labeln3",DataRowVersion.Original];}
	}
	///<summary>
	///etichetta per campo corrispondente
	///</summary>
	public String labeln4{ 
		get {if (this["labeln4"]==DBNull.Value)return null; return  (String)this["labeln4"];}
		set {if (value==null) this["labeln4"]= DBNull.Value; else this["labeln4"]= value;}
	}
	public object labeln4Value { 
		get{ return this["labeln4"];}
		set {if (value==null|| value==DBNull.Value) this["labeln4"]= DBNull.Value; else this["labeln4"]= value;}
	}
	public String labeln4Original { 
		get {if (this["labeln4",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["labeln4",DataRowVersion.Original];}
	}
	///<summary>
	///etichetta per campo corrispondente
	///</summary>
	public String labeln5{ 
		get {if (this["labeln5"]==DBNull.Value)return null; return  (String)this["labeln5"];}
		set {if (value==null) this["labeln5"]= DBNull.Value; else this["labeln5"]= value;}
	}
	public object labeln5Value { 
		get{ return this["labeln5"];}
		set {if (value==null|| value==DBNull.Value) this["labeln5"]= DBNull.Value; else this["labeln5"]= value;}
	}
	public String labeln5Original { 
		get {if (this["labeln5",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["labeln5",DataRowVersion.Original];}
	}
	///<summary>
	///etichetta per campo corrispondente
	///</summary>
	public String labels1{ 
		get {if (this["labels1"]==DBNull.Value)return null; return  (String)this["labels1"];}
		set {if (value==null) this["labels1"]= DBNull.Value; else this["labels1"]= value;}
	}
	public object labels1Value { 
		get{ return this["labels1"];}
		set {if (value==null|| value==DBNull.Value) this["labels1"]= DBNull.Value; else this["labels1"]= value;}
	}
	public String labels1Original { 
		get {if (this["labels1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["labels1",DataRowVersion.Original];}
	}
	///<summary>
	///etichetta per campo corrispondente
	///</summary>
	public String labels2{ 
		get {if (this["labels2"]==DBNull.Value)return null; return  (String)this["labels2"];}
		set {if (value==null) this["labels2"]= DBNull.Value; else this["labels2"]= value;}
	}
	public object labels2Value { 
		get{ return this["labels2"];}
		set {if (value==null|| value==DBNull.Value) this["labels2"]= DBNull.Value; else this["labels2"]= value;}
	}
	public String labels2Original { 
		get {if (this["labels2",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["labels2",DataRowVersion.Original];}
	}
	///<summary>
	///etichetta per campo corrispondente
	///</summary>
	public String labels3{ 
		get {if (this["labels3"]==DBNull.Value)return null; return  (String)this["labels3"];}
		set {if (value==null) this["labels3"]= DBNull.Value; else this["labels3"]= value;}
	}
	public object labels3Value { 
		get{ return this["labels3"];}
		set {if (value==null|| value==DBNull.Value) this["labels3"]= DBNull.Value; else this["labels3"]= value;}
	}
	public String labels3Original { 
		get {if (this["labels3",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["labels3",DataRowVersion.Original];}
	}
	///<summary>
	///etichetta per campo corrispondente
	///</summary>
	public String labels4{ 
		get {if (this["labels4"]==DBNull.Value)return null; return  (String)this["labels4"];}
		set {if (value==null) this["labels4"]= DBNull.Value; else this["labels4"]= value;}
	}
	public object labels4Value { 
		get{ return this["labels4"];}
		set {if (value==null|| value==DBNull.Value) this["labels4"]= DBNull.Value; else this["labels4"]= value;}
	}
	public String labels4Original { 
		get {if (this["labels4",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["labels4",DataRowVersion.Original];}
	}
	///<summary>
	///etichetta per campo corrispondente
	///</summary>
	public String labels5{ 
		get {if (this["labels5"]==DBNull.Value)return null; return  (String)this["labels5"];}
		set {if (value==null) this["labels5"]= DBNull.Value; else this["labels5"]= value;}
	}
	public object labels5Value { 
		get{ return this["labels5"];}
		set {if (value==null|| value==DBNull.Value) this["labels5"]= DBNull.Value; else this["labels5"]= value;}
	}
	public String labels5Original { 
		get {if (this["labels5",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["labels5",DataRowVersion.Original];}
	}
	///<summary>
	///etichetta per campo corrispondente
	///</summary>
	public String labelv1{ 
		get {if (this["labelv1"]==DBNull.Value)return null; return  (String)this["labelv1"];}
		set {if (value==null) this["labelv1"]= DBNull.Value; else this["labelv1"]= value;}
	}
	public object labelv1Value { 
		get{ return this["labelv1"];}
		set {if (value==null|| value==DBNull.Value) this["labelv1"]= DBNull.Value; else this["labelv1"]= value;}
	}
	public String labelv1Original { 
		get {if (this["labelv1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["labelv1",DataRowVersion.Original];}
	}
	///<summary>
	///etichetta per campo corrispondente
	///</summary>
	public String labelv2{ 
		get {if (this["labelv2"]==DBNull.Value)return null; return  (String)this["labelv2"];}
		set {if (value==null) this["labelv2"]= DBNull.Value; else this["labelv2"]= value;}
	}
	public object labelv2Value { 
		get{ return this["labelv2"];}
		set {if (value==null|| value==DBNull.Value) this["labelv2"]= DBNull.Value; else this["labelv2"]= value;}
	}
	public String labelv2Original { 
		get {if (this["labelv2",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["labelv2",DataRowVersion.Original];}
	}
	///<summary>
	///etichetta per campo corrispondente
	///</summary>
	public String labelv3{ 
		get {if (this["labelv3"]==DBNull.Value)return null; return  (String)this["labelv3"];}
		set {if (value==null) this["labelv3"]= DBNull.Value; else this["labelv3"]= value;}
	}
	public object labelv3Value { 
		get{ return this["labelv3"];}
		set {if (value==null|| value==DBNull.Value) this["labelv3"]= DBNull.Value; else this["labelv3"]= value;}
	}
	public String labelv3Original { 
		get {if (this["labelv3",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["labelv3",DataRowVersion.Original];}
	}
	///<summary>
	///etichetta per campo corrispondente
	///</summary>
	public String labelv4{ 
		get {if (this["labelv4"]==DBNull.Value)return null; return  (String)this["labelv4"];}
		set {if (value==null) this["labelv4"]= DBNull.Value; else this["labelv4"]= value;}
	}
	public object labelv4Value { 
		get{ return this["labelv4"];}
		set {if (value==null|| value==DBNull.Value) this["labelv4"]= DBNull.Value; else this["labelv4"]= value;}
	}
	public String labelv4Original { 
		get {if (this["labelv4",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["labelv4",DataRowVersion.Original];}
	}
	///<summary>
	///etichetta per campo corrispondente
	///</summary>
	public String labelv5{ 
		get {if (this["labelv5"]==DBNull.Value)return null; return  (String)this["labelv5"];}
		set {if (value==null) this["labelv5"]= DBNull.Value; else this["labelv5"]= value;}
	}
	public object labelv5Value { 
		get{ return this["labelv5"];}
		set {if (value==null|| value==DBNull.Value) this["labelv5"]= DBNull.Value; else this["labelv5"]= value;}
	}
	public String labelv5Original { 
		get {if (this["labelv5",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["labelv5",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è bloccato (non editabile) S/N
	///</summary>
	public String lockedN1{ 
		get {if (this["lockedN1"]==DBNull.Value)return null; return  (String)this["lockedN1"];}
		set {if (value==null) this["lockedN1"]= DBNull.Value; else this["lockedN1"]= value;}
	}
	public object lockedN1Value { 
		get{ return this["lockedN1"];}
		set {if (value==null|| value==DBNull.Value) this["lockedN1"]= DBNull.Value; else this["lockedN1"]= value;}
	}
	public String lockedN1Original { 
		get {if (this["lockedN1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lockedN1",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è bloccato (non editabile) S/N
	///</summary>
	public String lockedN2{ 
		get {if (this["lockedN2"]==DBNull.Value)return null; return  (String)this["lockedN2"];}
		set {if (value==null) this["lockedN2"]= DBNull.Value; else this["lockedN2"]= value;}
	}
	public object lockedN2Value { 
		get{ return this["lockedN2"];}
		set {if (value==null|| value==DBNull.Value) this["lockedN2"]= DBNull.Value; else this["lockedN2"]= value;}
	}
	public String lockedN2Original { 
		get {if (this["lockedN2",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lockedN2",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è bloccato (non editabile) S/N
	///</summary>
	public String lockedN3{ 
		get {if (this["lockedN3"]==DBNull.Value)return null; return  (String)this["lockedN3"];}
		set {if (value==null) this["lockedN3"]= DBNull.Value; else this["lockedN3"]= value;}
	}
	public object lockedN3Value { 
		get{ return this["lockedN3"];}
		set {if (value==null|| value==DBNull.Value) this["lockedN3"]= DBNull.Value; else this["lockedN3"]= value;}
	}
	public String lockedN3Original { 
		get {if (this["lockedN3",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lockedN3",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è bloccato (non editabile) S/N
	///</summary>
	public String lockedN4{ 
		get {if (this["lockedN4"]==DBNull.Value)return null; return  (String)this["lockedN4"];}
		set {if (value==null) this["lockedN4"]= DBNull.Value; else this["lockedN4"]= value;}
	}
	public object lockedN4Value { 
		get{ return this["lockedN4"];}
		set {if (value==null|| value==DBNull.Value) this["lockedN4"]= DBNull.Value; else this["lockedN4"]= value;}
	}
	public String lockedN4Original { 
		get {if (this["lockedN4",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lockedN4",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è bloccato (non editabile) S/N
	///</summary>
	public String lockedN5{ 
		get {if (this["lockedN5"]==DBNull.Value)return null; return  (String)this["lockedN5"];}
		set {if (value==null) this["lockedN5"]= DBNull.Value; else this["lockedN5"]= value;}
	}
	public object lockedN5Value { 
		get{ return this["lockedN5"];}
		set {if (value==null|| value==DBNull.Value) this["lockedN5"]= DBNull.Value; else this["lockedN5"]= value;}
	}
	public String lockedN5Original { 
		get {if (this["lockedN5",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lockedN5",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è bloccato (non editabile) S/N
	///</summary>
	public String lockedS1{ 
		get {if (this["lockedS1"]==DBNull.Value)return null; return  (String)this["lockedS1"];}
		set {if (value==null) this["lockedS1"]= DBNull.Value; else this["lockedS1"]= value;}
	}
	public object lockedS1Value { 
		get{ return this["lockedS1"];}
		set {if (value==null|| value==DBNull.Value) this["lockedS1"]= DBNull.Value; else this["lockedS1"]= value;}
	}
	public String lockedS1Original { 
		get {if (this["lockedS1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lockedS1",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è bloccato (non editabile) S/N
	///</summary>
	public String lockedS2{ 
		get {if (this["lockedS2"]==DBNull.Value)return null; return  (String)this["lockedS2"];}
		set {if (value==null) this["lockedS2"]= DBNull.Value; else this["lockedS2"]= value;}
	}
	public object lockedS2Value { 
		get{ return this["lockedS2"];}
		set {if (value==null|| value==DBNull.Value) this["lockedS2"]= DBNull.Value; else this["lockedS2"]= value;}
	}
	public String lockedS2Original { 
		get {if (this["lockedS2",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lockedS2",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è bloccato (non editabile) S/N
	///</summary>
	public String lockedS3{ 
		get {if (this["lockedS3"]==DBNull.Value)return null; return  (String)this["lockedS3"];}
		set {if (value==null) this["lockedS3"]= DBNull.Value; else this["lockedS3"]= value;}
	}
	public object lockedS3Value { 
		get{ return this["lockedS3"];}
		set {if (value==null|| value==DBNull.Value) this["lockedS3"]= DBNull.Value; else this["lockedS3"]= value;}
	}
	public String lockedS3Original { 
		get {if (this["lockedS3",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lockedS3",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è bloccato (non editabile) S/N
	///</summary>
	public String lockedS4{ 
		get {if (this["lockedS4"]==DBNull.Value)return null; return  (String)this["lockedS4"];}
		set {if (value==null) this["lockedS4"]= DBNull.Value; else this["lockedS4"]= value;}
	}
	public object lockedS4Value { 
		get{ return this["lockedS4"];}
		set {if (value==null|| value==DBNull.Value) this["lockedS4"]= DBNull.Value; else this["lockedS4"]= value;}
	}
	public String lockedS4Original { 
		get {if (this["lockedS4",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lockedS4",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è bloccato (non editabile) S/N
	///</summary>
	public String lockedS5{ 
		get {if (this["lockedS5"]==DBNull.Value)return null; return  (String)this["lockedS5"];}
		set {if (value==null) this["lockedS5"]= DBNull.Value; else this["lockedS5"]= value;}
	}
	public object lockedS5Value { 
		get{ return this["lockedS5"];}
		set {if (value==null|| value==DBNull.Value) this["lockedS5"]= DBNull.Value; else this["lockedS5"]= value;}
	}
	public String lockedS5Original { 
		get {if (this["lockedS5",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lockedS5",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è bloccato (non editabile) S/N
	///</summary>
	public String lockedv1{ 
		get {if (this["lockedv1"]==DBNull.Value)return null; return  (String)this["lockedv1"];}
		set {if (value==null) this["lockedv1"]= DBNull.Value; else this["lockedv1"]= value;}
	}
	public object lockedv1Value { 
		get{ return this["lockedv1"];}
		set {if (value==null|| value==DBNull.Value) this["lockedv1"]= DBNull.Value; else this["lockedv1"]= value;}
	}
	public String lockedv1Original { 
		get {if (this["lockedv1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lockedv1",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è bloccato (non editabile) S/N
	///</summary>
	public String lockedv2{ 
		get {if (this["lockedv2"]==DBNull.Value)return null; return  (String)this["lockedv2"];}
		set {if (value==null) this["lockedv2"]= DBNull.Value; else this["lockedv2"]= value;}
	}
	public object lockedv2Value { 
		get{ return this["lockedv2"];}
		set {if (value==null|| value==DBNull.Value) this["lockedv2"]= DBNull.Value; else this["lockedv2"]= value;}
	}
	public String lockedv2Original { 
		get {if (this["lockedv2",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lockedv2",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è bloccato (non editabile) S/N
	///</summary>
	public String lockedv3{ 
		get {if (this["lockedv3"]==DBNull.Value)return null; return  (String)this["lockedv3"];}
		set {if (value==null) this["lockedv3"]= DBNull.Value; else this["lockedv3"]= value;}
	}
	public object lockedv3Value { 
		get{ return this["lockedv3"];}
		set {if (value==null|| value==DBNull.Value) this["lockedv3"]= DBNull.Value; else this["lockedv3"]= value;}
	}
	public String lockedv3Original { 
		get {if (this["lockedv3",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lockedv3",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è bloccato (non editabile) S/N
	///</summary>
	public String lockedv4{ 
		get {if (this["lockedv4"]==DBNull.Value)return null; return  (String)this["lockedv4"];}
		set {if (value==null) this["lockedv4"]= DBNull.Value; else this["lockedv4"]= value;}
	}
	public object lockedv4Value { 
		get{ return this["lockedv4"];}
		set {if (value==null|| value==DBNull.Value) this["lockedv4"]= DBNull.Value; else this["lockedv4"]= value;}
	}
	public String lockedv4Original { 
		get {if (this["lockedv4",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lockedv4",DataRowVersion.Original];}
	}
	///<summary>
	///il campo corrispondente è bloccato (non editabile) S/N
	///</summary>
	public String lockedv5{ 
		get {if (this["lockedv5"]==DBNull.Value)return null; return  (String)this["lockedv5"];}
		set {if (value==null) this["lockedv5"]= DBNull.Value; else this["lockedv5"]= value;}
	}
	public object lockedv5Value { 
		get{ return this["lockedv5"];}
		set {if (value==null|| value==DBNull.Value) this["lockedv5"]= DBNull.Value; else this["lockedv5"]= value;}
	}
	public String lockedv5Original { 
		get {if (this["lockedv5",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["lockedv5",DataRowVersion.Original];}
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
	///Etichetta che indica l'assenza di date
	///</summary>
	public String nodatelabel{ 
		get {if (this["nodatelabel"]==DBNull.Value)return null; return  (String)this["nodatelabel"];}
		set {if (value==null) this["nodatelabel"]= DBNull.Value; else this["nodatelabel"]= value;}
	}
	public object nodatelabelValue { 
		get{ return this["nodatelabel"];}
		set {if (value==null|| value==DBNull.Value) this["nodatelabel"]= DBNull.Value; else this["nodatelabel"]= value;}
	}
	public String nodatelabelOriginal { 
		get {if (this["nodatelabel",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["nodatelabel",DataRowVersion.Original];}
	}
	///<summary>
	///espressione per il calcolo del totale
	///</summary>
	public String totalexpression{ 
		get {if (this["totalexpression"]==DBNull.Value)return null; return  (String)this["totalexpression"];}
		set {if (value==null) this["totalexpression"]= DBNull.Value; else this["totalexpression"]= value;}
	}
	public object totalexpressionValue { 
		get{ return this["totalexpression"];}
		set {if (value==null|| value==DBNull.Value) this["totalexpression"]= DBNull.Value; else this["totalexpression"]= value;}
	}
	public String totalexpressionOriginal { 
		get {if (this["totalexpression",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["totalexpression",DataRowVersion.Original];}
	}
	///<summary>
	///n. fase finanziaria di spesa collegata
	///</summary>
	public Byte? nphaseexpense{ 
		get {if (this["nphaseexpense"]==DBNull.Value)return null; return  (Byte?)this["nphaseexpense"];}
		set {if (value==null) this["nphaseexpense"]= DBNull.Value; else this["nphaseexpense"]= value;}
	}
	public object nphaseexpenseValue { 
		get{ return this["nphaseexpense"];}
		set {if (value==null|| value==DBNull.Value) this["nphaseexpense"]= DBNull.Value; else this["nphaseexpense"]= value;}
	}
	public Byte? nphaseexpenseOriginal { 
		get {if (this["nphaseexpense",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["nphaseexpense",DataRowVersion.Original];}
	}
	///<summary>
	///n. fase finanziaria di entrata collegata
	///</summary>
	public Byte? nphaseincome{ 
		get {if (this["nphaseincome"]==DBNull.Value)return null; return  (Byte?)this["nphaseincome"];}
		set {if (value==null) this["nphaseincome"]= DBNull.Value; else this["nphaseincome"]= value;}
	}
	public object nphaseincomeValue { 
		get{ return this["nphaseincome"];}
		set {if (value==null|| value==DBNull.Value) this["nphaseincome"]= DBNull.Value; else this["nphaseincome"]= value;}
	}
	public Byte? nphaseincomeOriginal { 
		get {if (this["nphaseincome",DataRowVersion.Original]==DBNull.Value)return null; return  (Byte?)this["nphaseincome",DataRowVersion.Original];}
	}
	///<summary>
	///Codice tipo classificazione (tabella sortingkind)
	///</summary>
	public String codesorkind{ 
		get {if (this["codesorkind"]==DBNull.Value)return null; return  (String)this["codesorkind"];}
		set {if (value==null) this["codesorkind"]= DBNull.Value; else this["codesorkind"]= value;}
	}
	public object codesorkindValue { 
		get{ return this["codesorkind"];}
		set {if (value==null|| value==DBNull.Value) this["codesorkind"]= DBNull.Value; else this["codesorkind"]= value;}
	}
	public String codesorkindOriginal { 
		get {if (this["codesorkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codesorkind",DataRowVersion.Original];}
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
	///flag per finanziario
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
	///id tipo class. parent
	///</summary>
	public Int32? idparentkind{ 
		get {if (this["idparentkind"]==DBNull.Value)return null; return  (Int32?)this["idparentkind"];}
		set {if (value==null) this["idparentkind"]= DBNull.Value; else this["idparentkind"]= value;}
	}
	public object idparentkindValue { 
		get{ return this["idparentkind"];}
		set {if (value==null|| value==DBNull.Value) this["idparentkind"]= DBNull.Value; else this["idparentkind"]= value;}
	}
	public Int32? idparentkindOriginal { 
		get {if (this["idparentkind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idparentkind",DataRowVersion.Original];}
	}
	public String allowedS1{ 
		get {if (this["allowedS1"]==DBNull.Value)return null; return  (String)this["allowedS1"];}
		set {if (value==null) this["allowedS1"]= DBNull.Value; else this["allowedS1"]= value;}
	}
	public object allowedS1Value { 
		get{ return this["allowedS1"];}
		set {if (value==null|| value==DBNull.Value) this["allowedS1"]= DBNull.Value; else this["allowedS1"]= value;}
	}
	public String allowedS1Original { 
		get {if (this["allowedS1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["allowedS1",DataRowVersion.Original];}
	}
	public String allowedS2{ 
		get {if (this["allowedS2"]==DBNull.Value)return null; return  (String)this["allowedS2"];}
		set {if (value==null) this["allowedS2"]= DBNull.Value; else this["allowedS2"]= value;}
	}
	public object allowedS2Value { 
		get{ return this["allowedS2"];}
		set {if (value==null|| value==DBNull.Value) this["allowedS2"]= DBNull.Value; else this["allowedS2"]= value;}
	}
	public String allowedS2Original { 
		get {if (this["allowedS2",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["allowedS2",DataRowVersion.Original];}
	}
	public String allowedS3{ 
		get {if (this["allowedS3"]==DBNull.Value)return null; return  (String)this["allowedS3"];}
		set {if (value==null) this["allowedS3"]= DBNull.Value; else this["allowedS3"]= value;}
	}
	public object allowedS3Value { 
		get{ return this["allowedS3"];}
		set {if (value==null|| value==DBNull.Value) this["allowedS3"]= DBNull.Value; else this["allowedS3"]= value;}
	}
	public String allowedS3Original { 
		get {if (this["allowedS3",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["allowedS3",DataRowVersion.Original];}
	}
	public String allowedS4{ 
		get {if (this["allowedS4"]==DBNull.Value)return null; return  (String)this["allowedS4"];}
		set {if (value==null) this["allowedS4"]= DBNull.Value; else this["allowedS4"]= value;}
	}
	public object allowedS4Value { 
		get{ return this["allowedS4"];}
		set {if (value==null|| value==DBNull.Value) this["allowedS4"]= DBNull.Value; else this["allowedS4"]= value;}
	}
	public String allowedS4Original { 
		get {if (this["allowedS4",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["allowedS4",DataRowVersion.Original];}
	}
	public String allowedS5{ 
		get {if (this["allowedS5"]==DBNull.Value)return null; return  (String)this["allowedS5"];}
		set {if (value==null) this["allowedS5"]= DBNull.Value; else this["allowedS5"]= value;}
	}
	public object allowedS5Value { 
		get{ return this["allowedS5"];}
		set {if (value==null|| value==DBNull.Value) this["allowedS5"]= DBNull.Value; else this["allowedS5"]= value;}
	}
	public String allowedS5Original { 
		get {if (this["allowedS5",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["allowedS5",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Tipo di Rilevanza analitica
///</summary>
public class sortingkindTable : MetaTableBase<sortingkindRow> {
	public sortingkindTable() : base("sortingkind"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"active",createColumn("active",typeof(string),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),false,false)},
			{"cu",createColumn("cu",typeof(string),false,false)},
			{"description",createColumn("description",typeof(string),false,false)},
			{"flagdate",createColumn("flagdate",typeof(string),true,false)},
			{"forcedN1",createColumn("forcedN1",typeof(string),true,false)},
			{"forcedN2",createColumn("forcedN2",typeof(string),true,false)},
			{"forcedN3",createColumn("forcedN3",typeof(string),true,false)},
			{"forcedN4",createColumn("forcedN4",typeof(string),true,false)},
			{"forcedN5",createColumn("forcedN5",typeof(string),true,false)},
			{"forcedS1",createColumn("forcedS1",typeof(string),true,false)},
			{"forcedS2",createColumn("forcedS2",typeof(string),true,false)},
			{"forcedS3",createColumn("forcedS3",typeof(string),true,false)},
			{"forcedS4",createColumn("forcedS4",typeof(string),true,false)},
			{"forcedS5",createColumn("forcedS5",typeof(string),true,false)},
			{"forcedv1",createColumn("forcedv1",typeof(string),true,false)},
			{"forcedv2",createColumn("forcedv2",typeof(string),true,false)},
			{"forcedv3",createColumn("forcedv3",typeof(string),true,false)},
			{"forcedv4",createColumn("forcedv4",typeof(string),true,false)},
			{"forcedv5",createColumn("forcedv5",typeof(string),true,false)},
			{"labelfordate",createColumn("labelfordate",typeof(string),true,false)},
			{"labeln1",createColumn("labeln1",typeof(string),true,false)},
			{"labeln2",createColumn("labeln2",typeof(string),true,false)},
			{"labeln3",createColumn("labeln3",typeof(string),true,false)},
			{"labeln4",createColumn("labeln4",typeof(string),true,false)},
			{"labeln5",createColumn("labeln5",typeof(string),true,false)},
			{"labels1",createColumn("labels1",typeof(string),true,false)},
			{"labels2",createColumn("labels2",typeof(string),true,false)},
			{"labels3",createColumn("labels3",typeof(string),true,false)},
			{"labels4",createColumn("labels4",typeof(string),true,false)},
			{"labels5",createColumn("labels5",typeof(string),true,false)},
			{"labelv1",createColumn("labelv1",typeof(string),true,false)},
			{"labelv2",createColumn("labelv2",typeof(string),true,false)},
			{"labelv3",createColumn("labelv3",typeof(string),true,false)},
			{"labelv4",createColumn("labelv4",typeof(string),true,false)},
			{"labelv5",createColumn("labelv5",typeof(string),true,false)},
			{"lockedN1",createColumn("lockedN1",typeof(string),true,false)},
			{"lockedN2",createColumn("lockedN2",typeof(string),true,false)},
			{"lockedN3",createColumn("lockedN3",typeof(string),true,false)},
			{"lockedN4",createColumn("lockedN4",typeof(string),true,false)},
			{"lockedN5",createColumn("lockedN5",typeof(string),true,false)},
			{"lockedS1",createColumn("lockedS1",typeof(string),true,false)},
			{"lockedS2",createColumn("lockedS2",typeof(string),true,false)},
			{"lockedS3",createColumn("lockedS3",typeof(string),true,false)},
			{"lockedS4",createColumn("lockedS4",typeof(string),true,false)},
			{"lockedS5",createColumn("lockedS5",typeof(string),true,false)},
			{"lockedv1",createColumn("lockedv1",typeof(string),true,false)},
			{"lockedv2",createColumn("lockedv2",typeof(string),true,false)},
			{"lockedv3",createColumn("lockedv3",typeof(string),true,false)},
			{"lockedv4",createColumn("lockedv4",typeof(string),true,false)},
			{"lockedv5",createColumn("lockedv5",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),false,false)},
			{"lu",createColumn("lu",typeof(string),false,false)},
			{"nodatelabel",createColumn("nodatelabel",typeof(string),true,false)},
			{"totalexpression",createColumn("totalexpression",typeof(string),true,false)},
			{"nphaseexpense",createColumn("nphaseexpense",typeof(byte),true,false)},
			{"nphaseincome",createColumn("nphaseincome",typeof(byte),true,false)},
			{"codesorkind",createColumn("codesorkind",typeof(string),false,false)},
			{"idsorkind",createColumn("idsorkind",typeof(int),false,false)},
			{"flag",createColumn("flag",typeof(byte),false,false)},
			{"start",createColumn("start",typeof(short),true,false)},
			{"stop",createColumn("stop",typeof(short),true,false)},
			{"idparentkind",createColumn("idparentkind",typeof(int),true,false)},
			{"allowedS1",createColumn("allowedS1",typeof(string),true,false)},
			{"allowedS2",createColumn("allowedS2",typeof(string),true,false)},
			{"allowedS3",createColumn("allowedS3",typeof(string),true,false)},
			{"allowedS4",createColumn("allowedS4",typeof(string),true,false)},
			{"allowedS5",createColumn("allowedS5",typeof(string),true,false)},
		};
	}
}
}
