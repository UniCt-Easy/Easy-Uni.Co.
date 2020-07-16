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
namespace meta_instmprogetti {
public class instmprogettiRow: MetaRow  {
	public instmprogettiRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///Abstract
	///</summary>
	public String abstractprogetto{ 
		get {if (this["abstractprogetto"]==DBNull.Value)return null; return  (String)this["abstractprogetto"];}
		set {if (value==null) this["abstractprogetto"]= DBNull.Value; else this["abstractprogetto"]= value;}
	}
	public object abstractprogettoValue { 
		get{ return this["abstractprogetto"];}
		set {if (value==null|| value==DBNull.Value) this["abstractprogetto"]= DBNull.Value; else this["abstractprogetto"]= value;}
	}
	public String abstractprogettoOriginal { 
		get {if (this["abstractprogetto",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["abstractprogetto",DataRowVersion.Original];}
	}
	public String acronimo{ 
		get {if (this["acronimo"]==DBNull.Value)return null; return  (String)this["acronimo"];}
		set {if (value==null) this["acronimo"]= DBNull.Value; else this["acronimo"]= value;}
	}
	public object acronimoValue { 
		get{ return this["acronimo"];}
		set {if (value==null|| value==DBNull.Value) this["acronimo"]= DBNull.Value; else this["acronimo"]= value;}
	}
	public String acronimoOriginal { 
		get {if (this["acronimo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["acronimo",DataRowVersion.Original];}
	}
	///<summary>
	///Anno approvazione
	///</summary>
	public Int32? annoapprovazione{ 
		get {if (this["annoapprovazione"]==DBNull.Value)return null; return  (Int32?)this["annoapprovazione"];}
		set {if (value==null) this["annoapprovazione"]= DBNull.Value; else this["annoapprovazione"]= value;}
	}
	public object annoapprovazioneValue { 
		get{ return this["annoapprovazione"];}
		set {if (value==null|| value==DBNull.Value) this["annoapprovazione"]= DBNull.Value; else this["annoapprovazione"]= value;}
	}
	public Int32? annoapprovazioneOriginal { 
		get {if (this["annoapprovazione",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["annoapprovazione",DataRowVersion.Original];}
	}
	///<summary>
	///Anno bando
	///</summary>
	public Int32? annobando{ 
		get {if (this["annobando"]==DBNull.Value)return null; return  (Int32?)this["annobando"];}
		set {if (value==null) this["annobando"]= DBNull.Value; else this["annobando"]= value;}
	}
	public object annobandoValue { 
		get{ return this["annobando"];}
		set {if (value==null|| value==DBNull.Value) this["annobando"]= DBNull.Value; else this["annobando"]= value;}
	}
	public Int32? annobandoOriginal { 
		get {if (this["annobando",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["annobando",DataRowVersion.Original];}
	}
	///<summary>
	///Causale proroga
	///</summary>
	public String causaleproroga{ 
		get {if (this["causaleproroga"]==DBNull.Value)return null; return  (String)this["causaleproroga"];}
		set {if (value==null) this["causaleproroga"]= DBNull.Value; else this["causaleproroga"]= value;}
	}
	public object causaleprorogaValue { 
		get{ return this["causaleproroga"];}
		set {if (value==null|| value==DBNull.Value) this["causaleproroga"]= DBNull.Value; else this["causaleproroga"]= value;}
	}
	public String causaleprorogaOriginal { 
		get {if (this["causaleproroga",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["causaleproroga",DataRowVersion.Original];}
	}
	public String codice{ 
		get {if (this["codice"]==DBNull.Value)return null; return  (String)this["codice"];}
		set {if (value==null) this["codice"]= DBNull.Value; else this["codice"]= value;}
	}
	public object codiceValue { 
		get{ return this["codice"];}
		set {if (value==null|| value==DBNull.Value) this["codice"]= DBNull.Value; else this["codice"]= value;}
	}
	public String codiceOriginal { 
		get {if (this["codice",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codice",DataRowVersion.Original];}
	}
	///<summary>
	///Costi Cofinanziati Approvati
	///</summary>
	public Decimal? costicofinanziatiapprovati{ 
		get {if (this["costicofinanziatiapprovati"]==DBNull.Value)return null; return  (Decimal?)this["costicofinanziatiapprovati"];}
		set {if (value==null) this["costicofinanziatiapprovati"]= DBNull.Value; else this["costicofinanziatiapprovati"]= value;}
	}
	public object costicofinanziatiapprovatiValue { 
		get{ return this["costicofinanziatiapprovati"];}
		set {if (value==null|| value==DBNull.Value) this["costicofinanziatiapprovati"]= DBNull.Value; else this["costicofinanziatiapprovati"]= value;}
	}
	public Decimal? costicofinanziatiapprovatiOriginal { 
		get {if (this["costicofinanziatiapprovati",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["costicofinanziatiapprovati",DataRowVersion.Original];}
	}
	///<summary>
	///Costi Cofinanziati Presentati
	///</summary>
	public Decimal? costicofinanziatipresentati{ 
		get {if (this["costicofinanziatipresentati"]==DBNull.Value)return null; return  (Decimal?)this["costicofinanziatipresentati"];}
		set {if (value==null) this["costicofinanziatipresentati"]= DBNull.Value; else this["costicofinanziatipresentati"]= value;}
	}
	public object costicofinanziatipresentatiValue { 
		get{ return this["costicofinanziatipresentati"];}
		set {if (value==null|| value==DBNull.Value) this["costicofinanziatipresentati"]= DBNull.Value; else this["costicofinanziatipresentati"]= value;}
	}
	public Decimal? costicofinanziatipresentatiOriginal { 
		get {if (this["costicofinanziatipresentati",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["costicofinanziatipresentati",DataRowVersion.Original];}
	}
	///<summary>
	///Costi INSTM Approvati
	///</summary>
	public Decimal? costiinstmapprovati{ 
		get {if (this["costiinstmapprovati"]==DBNull.Value)return null; return  (Decimal?)this["costiinstmapprovati"];}
		set {if (value==null) this["costiinstmapprovati"]= DBNull.Value; else this["costiinstmapprovati"]= value;}
	}
	public object costiinstmapprovatiValue { 
		get{ return this["costiinstmapprovati"];}
		set {if (value==null|| value==DBNull.Value) this["costiinstmapprovati"]= DBNull.Value; else this["costiinstmapprovati"]= value;}
	}
	public Decimal? costiinstmapprovatiOriginal { 
		get {if (this["costiinstmapprovati",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["costiinstmapprovati",DataRowVersion.Original];}
	}
	///<summary>
	///Costi INSTM Presentati
	///</summary>
	public Decimal? costiinstmpresentati{ 
		get {if (this["costiinstmpresentati"]==DBNull.Value)return null; return  (Decimal?)this["costiinstmpresentati"];}
		set {if (value==null) this["costiinstmpresentati"]= DBNull.Value; else this["costiinstmpresentati"]= value;}
	}
	public object costiinstmpresentatiValue { 
		get{ return this["costiinstmpresentati"];}
		set {if (value==null|| value==DBNull.Value) this["costiinstmpresentati"]= DBNull.Value; else this["costiinstmpresentati"]= value;}
	}
	public Decimal? costiinstmpresentatiOriginal { 
		get {if (this["costiinstmpresentati",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["costiinstmpresentati",DataRowVersion.Original];}
	}
	///<summary>
	///Costi Totali Approvati
	///</summary>
	public Decimal? costitotaliapprovati{ 
		get {if (this["costitotaliapprovati"]==DBNull.Value)return null; return  (Decimal?)this["costitotaliapprovati"];}
		set {if (value==null) this["costitotaliapprovati"]= DBNull.Value; else this["costitotaliapprovati"]= value;}
	}
	public object costitotaliapprovatiValue { 
		get{ return this["costitotaliapprovati"];}
		set {if (value==null|| value==DBNull.Value) this["costitotaliapprovati"]= DBNull.Value; else this["costitotaliapprovati"]= value;}
	}
	public Decimal? costitotaliapprovatiOriginal { 
		get {if (this["costitotaliapprovati",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["costitotaliapprovati",DataRowVersion.Original];}
	}
	///<summary>
	///Costi Totali Presentati
	///</summary>
	public Decimal? costitotalipresentati{ 
		get {if (this["costitotalipresentati"]==DBNull.Value)return null; return  (Decimal?)this["costitotalipresentati"];}
		set {if (value==null) this["costitotalipresentati"]= DBNull.Value; else this["costitotalipresentati"]= value;}
	}
	public object costitotalipresentatiValue { 
		get{ return this["costitotalipresentati"];}
		set {if (value==null|| value==DBNull.Value) this["costitotalipresentati"]= DBNull.Value; else this["costitotalipresentati"]= value;}
	}
	public Decimal? costitotalipresentatiOriginal { 
		get {if (this["costitotalipresentati",DataRowVersion.Original]==DBNull.Value)return null; return  (Decimal?)this["costitotalipresentati",DataRowVersion.Original];}
	}
	///<summary>
	///Nuova Scadenza
	///</summary>
	public DateTime? datanuovascadenza{ 
		get {if (this["datanuovascadenza"]==DBNull.Value)return null; return  (DateTime?)this["datanuovascadenza"];}
		set {if (value==null) this["datanuovascadenza"]= DBNull.Value; else this["datanuovascadenza"]= value;}
	}
	public object datanuovascadenzaValue { 
		get{ return this["datanuovascadenza"];}
		set {if (value==null|| value==DBNull.Value) this["datanuovascadenza"]= DBNull.Value; else this["datanuovascadenza"]= value;}
	}
	public DateTime? datanuovascadenzaOriginal { 
		get {if (this["datanuovascadenza",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["datanuovascadenza",DataRowVersion.Original];}
	}
	///<summary>
	///Data Proroga
	///</summary>
	public DateTime? dataproroga{ 
		get {if (this["dataproroga"]==DBNull.Value)return null; return  (DateTime?)this["dataproroga"];}
		set {if (value==null) this["dataproroga"]= DBNull.Value; else this["dataproroga"]= value;}
	}
	public object dataprorogaValue { 
		get{ return this["dataproroga"];}
		set {if (value==null|| value==DBNull.Value) this["dataproroga"]= DBNull.Value; else this["dataproroga"]= value;}
	}
	public DateTime? dataprorogaOriginal { 
		get {if (this["dataproroga",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["dataproroga",DataRowVersion.Original];}
	}
	///<summary>
	///Data Scadenza
	///</summary>
	public DateTime? datascadenza{ 
		get {if (this["datascadenza"]==DBNull.Value)return null; return  (DateTime?)this["datascadenza"];}
		set {if (value==null) this["datascadenza"]= DBNull.Value; else this["datascadenza"]= value;}
	}
	public object datascadenzaValue { 
		get{ return this["datascadenza"];}
		set {if (value==null|| value==DBNull.Value) this["datascadenza"]= DBNull.Value; else this["datascadenza"]= value;}
	}
	public DateTime? datascadenzaOriginal { 
		get {if (this["datascadenza",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["datascadenza",DataRowVersion.Original];}
	}
	///<summary>
	///Data Stipula
	///</summary>
	public DateTime? datastipula{ 
		get {if (this["datastipula"]==DBNull.Value)return null; return  (DateTime?)this["datastipula"];}
		set {if (value==null) this["datastipula"]= DBNull.Value; else this["datastipula"]= value;}
	}
	public object datastipulaValue { 
		get{ return this["datastipula"];}
		set {if (value==null|| value==DBNull.Value) this["datastipula"]= DBNull.Value; else this["datastipula"]= value;}
	}
	public DateTime? datastipulaOriginal { 
		get {if (this["datastipula",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["datastipula",DataRowVersion.Original];}
	}
	///<summary>
	///Dati del Bando
	///</summary>
	public String datidelbando{ 
		get {if (this["datidelbando"]==DBNull.Value)return null; return  (String)this["datidelbando"];}
		set {if (value==null) this["datidelbando"]= DBNull.Value; else this["datidelbando"]= value;}
	}
	public object datidelbandoValue { 
		get{ return this["datidelbando"];}
		set {if (value==null|| value==DBNull.Value) this["datidelbando"]= DBNull.Value; else this["datidelbando"]= value;}
	}
	public String datidelbandoOriginal { 
		get {if (this["datidelbando",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["datidelbando",DataRowVersion.Original];}
	}
	///<summary>
	///Decreto e Protocollo
	///</summary>
	public String decretoprotocollo{ 
		get {if (this["decretoprotocollo"]==DBNull.Value)return null; return  (String)this["decretoprotocollo"];}
		set {if (value==null) this["decretoprotocollo"]= DBNull.Value; else this["decretoprotocollo"]= value;}
	}
	public object decretoprotocolloValue { 
		get{ return this["decretoprotocollo"];}
		set {if (value==null|| value==DBNull.Value) this["decretoprotocollo"]= DBNull.Value; else this["decretoprotocollo"]= value;}
	}
	public String decretoprotocolloOriginal { 
		get {if (this["decretoprotocollo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["decretoprotocollo",DataRowVersion.Original];}
	}
	///<summary>
	///Durata (mesi)
	///</summary>
	public Int32? duratamesi{ 
		get {if (this["duratamesi"]==DBNull.Value)return null; return  (Int32?)this["duratamesi"];}
		set {if (value==null) this["duratamesi"]= DBNull.Value; else this["duratamesi"]= value;}
	}
	public object duratamesiValue { 
		get{ return this["duratamesi"];}
		set {if (value==null|| value==DBNull.Value) this["duratamesi"]= DBNull.Value; else this["duratamesi"]= value;}
	}
	public Int32? duratamesiOriginal { 
		get {if (this["duratamesi",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["duratamesi",DataRowVersion.Original];}
	}
	///<summary>
	///Ente Erogante
	///</summary>
	public Int32? idinstmentieroganti{ 
		get {if (this["idinstmentieroganti"]==DBNull.Value)return null; return  (Int32?)this["idinstmentieroganti"];}
		set {if (value==null) this["idinstmentieroganti"]= DBNull.Value; else this["idinstmentieroganti"]= value;}
	}
	public object idinstmentierogantiValue { 
		get{ return this["idinstmentieroganti"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmentieroganti"]= DBNull.Value; else this["idinstmentieroganti"]= value;}
	}
	public Int32? idinstmentierogantiOriginal { 
		get {if (this["idinstmentieroganti",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmentieroganti",DataRowVersion.Original];}
	}
	public Int32? idinstmprogetti{ 
		get {if (this["idinstmprogetti"]==DBNull.Value)return null; return  (Int32?)this["idinstmprogetti"];}
		set {if (value==null) this["idinstmprogetti"]= DBNull.Value; else this["idinstmprogetti"]= value;}
	}
	public object idinstmprogettiValue { 
		get{ return this["idinstmprogetti"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmprogetti"]= DBNull.Value; else this["idinstmprogetti"]= value;}
	}
	public Int32? idinstmprogettiOriginal { 
		get {if (this["idinstmprogetti",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmprogetti",DataRowVersion.Original];}
	}
	///<summary>
	///Tipo del progetto
	///</summary>
	public Int32? idinstmprogettikind{ 
		get {if (this["idinstmprogettikind"]==DBNull.Value)return null; return  (Int32?)this["idinstmprogettikind"];}
		set {if (value==null) this["idinstmprogettikind"]= DBNull.Value; else this["idinstmprogettikind"]= value;}
	}
	public object idinstmprogettikindValue { 
		get{ return this["idinstmprogettikind"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmprogettikind"]= DBNull.Value; else this["idinstmprogettikind"]= value;}
	}
	public Int32? idinstmprogettikindOriginal { 
		get {if (this["idinstmprogettikind",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmprogettikind",DataRowVersion.Original];}
	}
	///<summary>
	///Stato del progetto
	///</summary>
	public Int32? idinstmprogettistatus{ 
		get {if (this["idinstmprogettistatus"]==DBNull.Value)return null; return  (Int32?)this["idinstmprogettistatus"];}
		set {if (value==null) this["idinstmprogettistatus"]= DBNull.Value; else this["idinstmprogettistatus"]= value;}
	}
	public object idinstmprogettistatusValue { 
		get{ return this["idinstmprogettistatus"];}
		set {if (value==null|| value==DBNull.Value) this["idinstmprogettistatus"]= DBNull.Value; else this["idinstmprogettistatus"]= value;}
	}
	public Int32? idinstmprogettistatusOriginal { 
		get {if (this["idinstmprogettistatus",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idinstmprogettistatus",DataRowVersion.Original];}
	}
	///<summary>
	///Area Tematica
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
	///Cliente
	///</summary>
	public Int32? idreg_cliente{ 
		get {if (this["idreg_cliente"]==DBNull.Value)return null; return  (Int32?)this["idreg_cliente"];}
		set {if (value==null) this["idreg_cliente"]= DBNull.Value; else this["idreg_cliente"]= value;}
	}
	public object idreg_clienteValue { 
		get{ return this["idreg_cliente"];}
		set {if (value==null|| value==DBNull.Value) this["idreg_cliente"]= DBNull.Value; else this["idreg_cliente"]= value;}
	}
	public Int32? idreg_clienteOriginal { 
		get {if (this["idreg_cliente",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg_cliente",DataRowVersion.Original];}
	}
	///<summary>
	///Responsabile
	///</summary>
	public Int32? idreg_instmuser{ 
		get {if (this["idreg_instmuser"]==DBNull.Value)return null; return  (Int32?)this["idreg_instmuser"];}
		set {if (value==null) this["idreg_instmuser"]= DBNull.Value; else this["idreg_instmuser"]= value;}
	}
	public object idreg_instmuserValue { 
		get{ return this["idreg_instmuser"];}
		set {if (value==null|| value==DBNull.Value) this["idreg_instmuser"]= DBNull.Value; else this["idreg_instmuser"]= value;}
	}
	public Int32? idreg_instmuserOriginal { 
		get {if (this["idreg_instmuser",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg_instmuser",DataRowVersion.Original];}
	}
	///<summary>
	///Co-responsabile
	///</summary>
	public Int32? idreg_instmuser_co{ 
		get {if (this["idreg_instmuser_co"]==DBNull.Value)return null; return  (Int32?)this["idreg_instmuser_co"];}
		set {if (value==null) this["idreg_instmuser_co"]= DBNull.Value; else this["idreg_instmuser_co"]= value;}
	}
	public object idreg_instmuser_coValue { 
		get{ return this["idreg_instmuser_co"];}
		set {if (value==null|| value==DBNull.Value) this["idreg_instmuser_co"]= DBNull.Value; else this["idreg_instmuser_co"]= value;}
	}
	public Int32? idreg_instmuser_coOriginal { 
		get {if (this["idreg_instmuser_co",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idreg_instmuser_co",DataRowVersion.Original];}
	}
	public String keywords{ 
		get {if (this["keywords"]==DBNull.Value)return null; return  (String)this["keywords"];}
		set {if (value==null) this["keywords"]= DBNull.Value; else this["keywords"]= value;}
	}
	public object keywordsValue { 
		get{ return this["keywords"];}
		set {if (value==null|| value==DBNull.Value) this["keywords"]= DBNull.Value; else this["keywords"]= value;}
	}
	public String keywordsOriginal { 
		get {if (this["keywords",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["keywords",DataRowVersion.Original];}
	}
	public String note{ 
		get {if (this["note"]==DBNull.Value)return null; return  (String)this["note"];}
		set {if (value==null) this["note"]= DBNull.Value; else this["note"]= value;}
	}
	public object noteValue { 
		get{ return this["note"];}
		set {if (value==null|| value==DBNull.Value) this["note"]= DBNull.Value; else this["note"]= value;}
	}
	public String noteOriginal { 
		get {if (this["note",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["note",DataRowVersion.Original];}
	}
	public String numero{ 
		get {if (this["numero"]==DBNull.Value)return null; return  (String)this["numero"];}
		set {if (value==null) this["numero"]= DBNull.Value; else this["numero"]= value;}
	}
	public object numeroValue { 
		get{ return this["numero"];}
		set {if (value==null|| value==DBNull.Value) this["numero"]= DBNull.Value; else this["numero"]= value;}
	}
	public String numeroOriginal { 
		get {if (this["numero",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["numero",DataRowVersion.Original];}
	}
	///<summary>
	///Numero del contratto
	///</summary>
	public String numerocontratto{ 
		get {if (this["numerocontratto"]==DBNull.Value)return null; return  (String)this["numerocontratto"];}
		set {if (value==null) this["numerocontratto"]= DBNull.Value; else this["numerocontratto"]= value;}
	}
	public object numerocontrattoValue { 
		get{ return this["numerocontratto"];}
		set {if (value==null|| value==DBNull.Value) this["numerocontratto"]= DBNull.Value; else this["numerocontratto"]= value;}
	}
	public String numerocontrattoOriginal { 
		get {if (this["numerocontratto",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["numerocontratto",DataRowVersion.Original];}
	}
	///<summary>
	///Altri riferimenti del bando
	///</summary>
	public String riferimentobando{ 
		get {if (this["riferimentobando"]==DBNull.Value)return null; return  (String)this["riferimentobando"];}
		set {if (value==null) this["riferimentobando"]= DBNull.Value; else this["riferimentobando"]= value;}
	}
	public object riferimentobandoValue { 
		get{ return this["riferimentobando"];}
		set {if (value==null|| value==DBNull.Value) this["riferimentobando"]= DBNull.Value; else this["riferimentobando"]= value;}
	}
	public String riferimentobandoOriginal { 
		get {if (this["riferimentobando",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["riferimentobando",DataRowVersion.Original];}
	}
	///<summary>
	///Ruolo del consorsio INSTM
	///</summary>
	public String ruoloinstm{ 
		get {if (this["ruoloinstm"]==DBNull.Value)return null; return  (String)this["ruoloinstm"];}
		set {if (value==null) this["ruoloinstm"]= DBNull.Value; else this["ruoloinstm"]= value;}
	}
	public object ruoloinstmValue { 
		get{ return this["ruoloinstm"];}
		set {if (value==null|| value==DBNull.Value) this["ruoloinstm"]= DBNull.Value; else this["ruoloinstm"]= value;}
	}
	public String ruoloinstmOriginal { 
		get {if (this["ruoloinstm",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ruoloinstm",DataRowVersion.Original];}
	}
	///<summary>
	///Scadenza del bando
	///</summary>
	public DateTime? scadenzabando{ 
		get {if (this["scadenzabando"]==DBNull.Value)return null; return  (DateTime?)this["scadenzabando"];}
		set {if (value==null) this["scadenzabando"]= DBNull.Value; else this["scadenzabando"]= value;}
	}
	public object scadenzabandoValue { 
		get{ return this["scadenzabando"];}
		set {if (value==null|| value==DBNull.Value) this["scadenzabando"]= DBNull.Value; else this["scadenzabando"]= value;}
	}
	public DateTime? scadenzabandoOriginal { 
		get {if (this["scadenzabando",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["scadenzabando",DataRowVersion.Original];}
	}
	///<summary>
	///Tematica del bando
	///</summary>
	public String tematicabando{ 
		get {if (this["tematicabando"]==DBNull.Value)return null; return  (String)this["tematicabando"];}
		set {if (value==null) this["tematicabando"]= DBNull.Value; else this["tematicabando"]= value;}
	}
	public object tematicabandoValue { 
		get{ return this["tematicabando"];}
		set {if (value==null|| value==DBNull.Value) this["tematicabando"]= DBNull.Value; else this["tematicabando"]= value;}
	}
	public String tematicabandoOriginal { 
		get {if (this["tematicabando",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["tematicabando",DataRowVersion.Original];}
	}
	public String titolo{ 
		get {if (this["titolo"]==DBNull.Value)return null; return  (String)this["titolo"];}
		set {if (value==null) this["titolo"]= DBNull.Value; else this["titolo"]= value;}
	}
	public object titoloValue { 
		get{ return this["titolo"];}
		set {if (value==null|| value==DBNull.Value) this["titolo"]= DBNull.Value; else this["titolo"]= value;}
	}
	public String titoloOriginal { 
		get {if (this["titolo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["titolo",DataRowVersion.Original];}
	}
	#endregion

}
public class instmprogettiTable : MetaTableBase<instmprogettiRow> {
	public instmprogettiTable() : base("instmprogetti"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"abstractprogetto",createColumn("abstractprogetto",typeof(string),true,false)},
			{"acronimo",createColumn("acronimo",typeof(string),true,false)},
			{"annoapprovazione",createColumn("annoapprovazione",typeof(int),true,false)},
			{"annobando",createColumn("annobando",typeof(int),true,false)},
			{"causaleproroga",createColumn("causaleproroga",typeof(string),true,false)},
			{"codice",createColumn("codice",typeof(string),true,false)},
			{"costicofinanziatiapprovati",createColumn("costicofinanziatiapprovati",typeof(decimal),true,false)},
			{"costicofinanziatipresentati",createColumn("costicofinanziatipresentati",typeof(decimal),true,false)},
			{"costiinstmapprovati",createColumn("costiinstmapprovati",typeof(decimal),true,false)},
			{"costiinstmpresentati",createColumn("costiinstmpresentati",typeof(decimal),true,false)},
			{"costitotaliapprovati",createColumn("costitotaliapprovati",typeof(decimal),true,false)},
			{"costitotalipresentati",createColumn("costitotalipresentati",typeof(decimal),true,false)},
			{"datanuovascadenza",createColumn("datanuovascadenza",typeof(DateTime),true,false)},
			{"dataproroga",createColumn("dataproroga",typeof(DateTime),true,false)},
			{"datascadenza",createColumn("datascadenza",typeof(DateTime),true,false)},
			{"datastipula",createColumn("datastipula",typeof(DateTime),true,false)},
			{"datidelbando",createColumn("datidelbando",typeof(string),true,false)},
			{"decretoprotocollo",createColumn("decretoprotocollo",typeof(string),true,false)},
			{"duratamesi",createColumn("duratamesi",typeof(int),true,false)},
			{"idinstmentieroganti",createColumn("idinstmentieroganti",typeof(int),true,false)},
			{"idinstmprogetti",createColumn("idinstmprogetti",typeof(int),false,false)},
			{"idinstmprogettikind",createColumn("idinstmprogettikind",typeof(int),false,false)},
			{"idinstmprogettistatus",createColumn("idinstmprogettistatus",typeof(int),true,false)},
			{"idinstmseztematichekind",createColumn("idinstmseztematichekind",typeof(int),true,false)},
			{"idreg_cliente",createColumn("idreg_cliente",typeof(int),true,false)},
			{"idreg_instmuser",createColumn("idreg_instmuser",typeof(int),true,false)},
			{"idreg_instmuser_co",createColumn("idreg_instmuser_co",typeof(int),true,false)},
			{"keywords",createColumn("keywords",typeof(string),true,false)},
			{"note",createColumn("note",typeof(string),true,false)},
			{"numero",createColumn("numero",typeof(string),false,false)},
			{"numerocontratto",createColumn("numerocontratto",typeof(string),true,false)},
			{"riferimentobando",createColumn("riferimentobando",typeof(string),true,false)},
			{"ruoloinstm",createColumn("ruoloinstm",typeof(string),true,false)},
			{"scadenzabando",createColumn("scadenzabando",typeof(DateTime),true,false)},
			{"tematicabando",createColumn("tematicabando",typeof(string),true,false)},
			{"titolo",createColumn("titolo",typeof(string),true,false)},
		};
	}
}
}
