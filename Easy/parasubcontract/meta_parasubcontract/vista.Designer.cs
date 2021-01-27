
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
namespace meta_parasubcontract {
public class parasubcontractRow: MetaRow  {
	public parasubcontractRow(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	///<summary>
	///ID contratto
	///</summary>
	public String idcon{ 
		get {return  (String)this["idcon"];}
		set {this["idcon"]= value;}
	}
	public object idconValue { 
		get{ return this["idcon"];}
		set {this["idcon"]= value;}
	}
	public String idconOriginal { 
		get {return  (String)this["idcon",DataRowVersion.Original];}
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
	///Mansione
	///</summary>
	public String duty{ 
		get {if (this["duty"]==DBNull.Value)return null; return  (String)this["duty"];}
		set {if (value==null) this["duty"]= DBNull.Value; else this["duty"]= value;}
	}
	public object dutyValue { 
		get{ return this["duty"];}
		set {if (value==null|| value==DBNull.Value) this["duty"]= DBNull.Value; else this["duty"]= value;}
	}
	public String dutyOriginal { 
		get {if (this["duty",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["duty",DataRowVersion.Original];}
	}
	///<summary>
	///In Forza
	///	 N: Non in forza
	///	 S: In Forza
	///</summary>
	public String employed{ 
		get {return  (String)this["employed"];}
		set {this["employed"]= value;}
	}
	public object employedValue { 
		get{ return this["employed"];}
		set {this["employed"]= value;}
	}
	public String employedOriginal { 
		get {return  (String)this["employed",DataRowVersion.Original];}
	}
	///<summary>
	///Non usato
	///</summary>
	public String flagroundedmonths{ 
		get {if (this["flagroundedmonths"]==DBNull.Value)return null; return  (String)this["flagroundedmonths"];}
		set {if (value==null) this["flagroundedmonths"]= DBNull.Value; else this["flagroundedmonths"]= value;}
	}
	public object flagroundedmonthsValue { 
		get{ return this["flagroundedmonths"];}
		set {if (value==null|| value==DBNull.Value) this["flagroundedmonths"]= DBNull.Value; else this["flagroundedmonths"]= value;}
	}
	public String flagroundedmonthsOriginal { 
		get {if (this["flagroundedmonths",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["flagroundedmonths",DataRowVersion.Original];}
	}
	///<summary>
	///Lordo al beneficiario 
	///</summary>
	public Decimal grossamount{ 
		get {return  (Decimal)this["grossamount"];}
		set {this["grossamount"]= value;}
	}
	public object grossamountValue { 
		get{ return this["grossamount"];}
		set {this["grossamount"]= value;}
	}
	public Decimal grossamountOriginal { 
		get {return  (Decimal)this["grossamount",DataRowVersion.Original];}
	}
	///<summary>
	///id causale (tabella acccmotive)
	///</summary>
	public String idaccmotive{ 
		get {if (this["idaccmotive"]==DBNull.Value)return null; return  (String)this["idaccmotive"];}
		set {if (value==null) this["idaccmotive"]= DBNull.Value; else this["idaccmotive"]= value;}
	}
	public object idaccmotiveValue { 
		get{ return this["idaccmotive"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotive"]= DBNull.Value; else this["idaccmotive"]= value;}
	}
	public String idaccmotiveOriginal { 
		get {if (this["idaccmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotive",DataRowVersion.Original];}
	}
	///<summary>
	///Cod. Tipo Libro
	///</summary>
	public String idmatriculabook{ 
		get {if (this["idmatriculabook"]==DBNull.Value)return null; return  (String)this["idmatriculabook"];}
		set {if (value==null) this["idmatriculabook"]= DBNull.Value; else this["idmatriculabook"]= value;}
	}
	public object idmatriculabookValue { 
		get{ return this["idmatriculabook"];}
		set {if (value==null|| value==DBNull.Value) this["idmatriculabook"]= DBNull.Value; else this["idmatriculabook"]= value;}
	}
	public String idmatriculabookOriginal { 
		get {if (this["idmatriculabook",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idmatriculabook",DataRowVersion.Original];}
	}
	///<summary>
	///ID Posizione Assicurativa Territoriale (tabella pat)
	///</summary>
	public Int32? idpat{ 
		get {if (this["idpat"]==DBNull.Value)return null; return  (Int32?)this["idpat"];}
		set {if (value==null) this["idpat"]= DBNull.Value; else this["idpat"]= value;}
	}
	public object idpatValue { 
		get{ return this["idpat"];}
		set {if (value==null|| value==DBNull.Value) this["idpat"]= DBNull.Value; else this["idpat"]= value;}
	}
	public Int32? idpatOriginal { 
		get {if (this["idpat",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idpat",DataRowVersion.Original];}
	}
	///<summary>
	///Cod. Descr. Cedolino
	///</summary>
	public String idpayrollkind{ 
		get {if (this["idpayrollkind"]==DBNull.Value)return null; return  (String)this["idpayrollkind"];}
		set {if (value==null) this["idpayrollkind"]= DBNull.Value; else this["idpayrollkind"]= value;}
	}
	public object idpayrollkindValue { 
		get{ return this["idpayrollkind"];}
		set {if (value==null|| value==DBNull.Value) this["idpayrollkind"]= DBNull.Value; else this["idpayrollkind"]= value;}
	}
	public String idpayrollkindOriginal { 
		get {if (this["idpayrollkind",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idpayrollkind",DataRowVersion.Original];}
	}
	///<summary>
	///id anagrafica (tabella registry)
	///</summary>
	public Int32 idreg{ 
		get {return  (Int32)this["idreg"];}
		set {this["idreg"]= value;}
	}
	public object idregValue { 
		get{ return this["idreg"];}
		set {this["idreg"]= value;}
	}
	public Int32 idregOriginal { 
		get {return  (Int32)this["idreg",DataRowVersion.Original];}
	}
	///<summary>
	///id voce upb (tabella upb)
	///</summary>
	public String idupb{ 
		get {if (this["idupb"]==DBNull.Value)return null; return  (String)this["idupb"];}
		set {if (value==null) this["idupb"]= DBNull.Value; else this["idupb"]= value;}
	}
	public object idupbValue { 
		get{ return this["idupb"];}
		set {if (value==null|| value==DBNull.Value) this["idupb"]= DBNull.Value; else this["idupb"]= value;}
	}
	public String idupbOriginal { 
		get {if (this["idupb",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idupb",DataRowVersion.Original];}
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
	///Matricola
	///</summary>
	public Int32? matricula{ 
		get {if (this["matricula"]==DBNull.Value)return null; return  (Int32?)this["matricula"];}
		set {if (value==null) this["matricula"]= DBNull.Value; else this["matricula"]= value;}
	}
	public object matriculaValue { 
		get{ return this["matricula"];}
		set {if (value==null|| value==DBNull.Value) this["matricula"]= DBNull.Value; else this["matricula"]= value;}
	}
	public Int32? matriculaOriginal { 
		get {if (this["matricula",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["matricula",DataRowVersion.Original];}
	}
	///<summary>
	///Durata (Mesi)
	///</summary>
	public Int32 monthlen{ 
		get {return  (Int32)this["monthlen"];}
		set {this["monthlen"]= value;}
	}
	public object monthlenValue { 
		get{ return this["monthlen"];}
		set {this["monthlen"]= value;}
	}
	public Int32 monthlenOriginal { 
		get {return  (Int32)this["monthlen",DataRowVersion.Original];}
	}
	///<summary>
	///N. contratto
	///</summary>
	public String ncon{ 
		get {return  (String)this["ncon"];}
		set {this["ncon"]= value;}
	}
	public object nconValue { 
		get{ return this["ncon"];}
		set {this["ncon"]= value;}
	}
	public String nconOriginal { 
		get {return  (String)this["ncon",DataRowVersion.Original];}
	}
	///<summary>
	///CC su Cedolino
	///</summary>
	public String payrollccinfo{ 
		get {return  (String)this["payrollccinfo"];}
		set {this["payrollccinfo"]= value;}
	}
	public object payrollccinfoValue { 
		get{ return this["payrollccinfo"];}
		set {this["payrollccinfo"]= value;}
	}
	public String payrollccinfoOriginal { 
		get {return  (String)this["payrollccinfo",DataRowVersion.Original];}
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
	///data inizio
	///</summary>
	public DateTime start{ 
		get {return  (DateTime)this["start"];}
		set {this["start"]= value;}
	}
	public object startValue { 
		get{ return this["start"];}
		set {this["start"]= value;}
	}
	public DateTime startOriginal { 
		get {return  (DateTime)this["start",DataRowVersion.Original];}
	}
	///<summary>
	///data fine
	///</summary>
	public DateTime stop{ 
		get {return  (DateTime)this["stop"];}
		set {this["stop"]= value;}
	}
	public object stopValue { 
		get{ return this["stop"];}
		set {this["stop"]= value;}
	}
	public DateTime stopOriginal { 
		get {return  (DateTime)this["stop",DataRowVersion.Original];}
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
	///Anno contratto
	///</summary>
	public Int32 ycon{ 
		get {return  (Int32)this["ycon"];}
		set {this["ycon"]= value;}
	}
	public object yconValue { 
		get{ return this["ycon"];}
		set {this["ycon"]= value;}
	}
	public Int32 yconOriginal { 
		get {return  (Int32)this["ycon",DataRowVersion.Original];}
	}
	///<summary>
	///chiave prestazione (tabella service)
	///</summary>
	public Int32 idser{ 
		get {return  (Int32)this["idser"];}
		set {this["idser"]= value;}
	}
	public object idserValue { 
		get{ return this["idser"];}
		set {this["idser"]= value;}
	}
	public Int32 idserOriginal { 
		get {return  (Int32)this["idser",DataRowVersion.Original];}
	}
	///<summary>
	///id voce analitica 1(tabella sorting)
	///</summary>
	public Int32? idsor1{ 
		get {if (this["idsor1"]==DBNull.Value)return null; return  (Int32?)this["idsor1"];}
		set {if (value==null) this["idsor1"]= DBNull.Value; else this["idsor1"]= value;}
	}
	public object idsor1Value { 
		get{ return this["idsor1"];}
		set {if (value==null|| value==DBNull.Value) this["idsor1"]= DBNull.Value; else this["idsor1"]= value;}
	}
	public Int32? idsor1Original { 
		get {if (this["idsor1",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor1",DataRowVersion.Original];}
	}
	///<summary>
	///id voce analitica 2(tabella sorting)
	///</summary>
	public Int32? idsor2{ 
		get {if (this["idsor2"]==DBNull.Value)return null; return  (Int32?)this["idsor2"];}
		set {if (value==null) this["idsor2"]= DBNull.Value; else this["idsor2"]= value;}
	}
	public object idsor2Value { 
		get{ return this["idsor2"];}
		set {if (value==null|| value==DBNull.Value) this["idsor2"]= DBNull.Value; else this["idsor2"]= value;}
	}
	public Int32? idsor2Original { 
		get {if (this["idsor2",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor2",DataRowVersion.Original];}
	}
	///<summary>
	///id voce analitica 3(tabella sorting)
	///</summary>
	public Int32? idsor3{ 
		get {if (this["idsor3"]==DBNull.Value)return null; return  (Int32?)this["idsor3"];}
		set {if (value==null) this["idsor3"]= DBNull.Value; else this["idsor3"]= value;}
	}
	public object idsor3Value { 
		get{ return this["idsor3"];}
		set {if (value==null|| value==DBNull.Value) this["idsor3"]= DBNull.Value; else this["idsor3"]= value;}
	}
	public Int32? idsor3Original { 
		get {if (this["idsor3",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor3",DataRowVersion.Original];}
	}
	///<summary>
	///Id della causale di debito (tabella accmotive) 
	///</summary>
	public String idaccmotivedebit{ 
		get {if (this["idaccmotivedebit"]==DBNull.Value)return null; return  (String)this["idaccmotivedebit"];}
		set {if (value==null) this["idaccmotivedebit"]= DBNull.Value; else this["idaccmotivedebit"]= value;}
	}
	public object idaccmotivedebitValue { 
		get{ return this["idaccmotivedebit"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotivedebit"]= DBNull.Value; else this["idaccmotivedebit"]= value;}
	}
	public String idaccmotivedebitOriginal { 
		get {if (this["idaccmotivedebit",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotivedebit",DataRowVersion.Original];}
	}
	///<summary>
	///Id causale di debito - correzione (tabella accmotive)
	///</summary>
	public String idaccmotivedebit_crg{ 
		get {if (this["idaccmotivedebit_crg"]==DBNull.Value)return null; return  (String)this["idaccmotivedebit_crg"];}
		set {if (value==null) this["idaccmotivedebit_crg"]= DBNull.Value; else this["idaccmotivedebit_crg"]= value;}
	}
	public object idaccmotivedebit_crgValue { 
		get{ return this["idaccmotivedebit_crg"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotivedebit_crg"]= DBNull.Value; else this["idaccmotivedebit_crg"]= value;}
	}
	public String idaccmotivedebit_crgOriginal { 
		get {if (this["idaccmotivedebit_crg",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["idaccmotivedebit_crg",DataRowVersion.Original];}
	}
	///<summary>
	///Data correzione causale di debito
	///</summary>
	public DateTime? idaccmotivedebit_datacrg{ 
		get {if (this["idaccmotivedebit_datacrg"]==DBNull.Value)return null; return  (DateTime?)this["idaccmotivedebit_datacrg"];}
		set {if (value==null) this["idaccmotivedebit_datacrg"]= DBNull.Value; else this["idaccmotivedebit_datacrg"]= value;}
	}
	public object idaccmotivedebit_datacrgValue { 
		get{ return this["idaccmotivedebit_datacrg"];}
		set {if (value==null|| value==DBNull.Value) this["idaccmotivedebit_datacrg"]= DBNull.Value; else this["idaccmotivedebit_datacrg"]= value;}
	}
	public DateTime? idaccmotivedebit_datacrgOriginal { 
		get {if (this["idaccmotivedebit_datacrg",DataRowVersion.Original]==DBNull.Value)return null; return  (DateTime?)this["idaccmotivedebit_datacrg",DataRowVersion.Original];}
	}
	///<summary>
	///id progressivo pos. giuridica
	///</summary>
	public Int32? idregistrylegalstatus{ 
		get {if (this["idregistrylegalstatus"]==DBNull.Value)return null; return  (Int32?)this["idregistrylegalstatus"];}
		set {if (value==null) this["idregistrylegalstatus"]= DBNull.Value; else this["idregistrylegalstatus"]= value;}
	}
	public object idregistrylegalstatusValue { 
		get{ return this["idregistrylegalstatus"];}
		set {if (value==null|| value==DBNull.Value) this["idregistrylegalstatus"]= DBNull.Value; else this["idregistrylegalstatus"]= value;}
	}
	public Int32? idregistrylegalstatusOriginal { 
		get {if (this["idregistrylegalstatus",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idregistrylegalstatus",DataRowVersion.Original];}
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
	///Posizione Dalia
	///</summary>
	public Int32? iddaliaposition{ 
		get {if (this["iddaliaposition"]==DBNull.Value)return null; return  (Int32?)this["iddaliaposition"];}
		set {if (value==null) this["iddaliaposition"]= DBNull.Value; else this["iddaliaposition"]= value;}
	}
	public object iddaliapositionValue { 
		get{ return this["iddaliaposition"];}
		set {if (value==null|| value==DBNull.Value) this["iddaliaposition"]= DBNull.Value; else this["iddaliaposition"]= value;}
	}
	public Int32? iddaliapositionOriginal { 
		get {if (this["iddaliaposition",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddaliaposition",DataRowVersion.Original];}
	}
	///<summary>
	///id della class. siope (idsor di sorting) per il costo 
	///</summary>
	public Int32? idsor_siope{ 
		get {if (this["idsor_siope"]==DBNull.Value)return null; return  (Int32?)this["idsor_siope"];}
		set {if (value==null) this["idsor_siope"]= DBNull.Value; else this["idsor_siope"]= value;}
	}
	public object idsor_siopeValue { 
		get{ return this["idsor_siope"];}
		set {if (value==null|| value==DBNull.Value) this["idsor_siope"]= DBNull.Value; else this["idsor_siope"]= value;}
	}
	public Int32? idsor_siopeOriginal { 
		get {if (this["idsor_siope",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["idsor_siope",DataRowVersion.Original];}
	}
	///<summary>
	///Documenti richiesti
	///</summary>
	public Int32? requested_doc{ 
		get {if (this["requested_doc"]==DBNull.Value)return null; return  (Int32?)this["requested_doc"];}
		set {if (value==null) this["requested_doc"]= DBNull.Value; else this["requested_doc"]= value;}
	}
	public object requested_docValue { 
		get{ return this["requested_doc"];}
		set {if (value==null|| value==DBNull.Value) this["requested_doc"]= DBNull.Value; else this["requested_doc"]= value;}
	}
	public Int32? requested_docOriginal { 
		get {if (this["requested_doc",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["requested_doc",DataRowVersion.Original];}
	}
	public Int32? iddaliarecruitmentmotive{ 
		get {if (this["iddaliarecruitmentmotive"]==DBNull.Value)return null; return  (Int32?)this["iddaliarecruitmentmotive"];}
		set {if (value==null) this["iddaliarecruitmentmotive"]= DBNull.Value; else this["iddaliarecruitmentmotive"]= value;}
	}
	public object iddaliarecruitmentmotiveValue { 
		get{ return this["iddaliarecruitmentmotive"];}
		set {if (value==null|| value==DBNull.Value) this["iddaliarecruitmentmotive"]= DBNull.Value; else this["iddaliarecruitmentmotive"]= value;}
	}
	public Int32? iddaliarecruitmentmotiveOriginal { 
		get {if (this["iddaliarecruitmentmotive",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddaliarecruitmentmotive",DataRowVersion.Original];}
	}
	public Int32? iddalia_funzionale{ 
		get {if (this["iddalia_funzionale"]==DBNull.Value)return null; return  (Int32?)this["iddalia_funzionale"];}
		set {if (value==null) this["iddalia_funzionale"]= DBNull.Value; else this["iddalia_funzionale"]= value;}
	}
	public object iddalia_funzionaleValue { 
		get{ return this["iddalia_funzionale"];}
		set {if (value==null|| value==DBNull.Value) this["iddalia_funzionale"]= DBNull.Value; else this["iddalia_funzionale"]= value;}
	}
	public Int32? iddalia_funzionaleOriginal { 
		get {if (this["iddalia_funzionale",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddalia_funzionale",DataRowVersion.Original];}
	}
	public Int32? iddalia_dipartimento{ 
		get {if (this["iddalia_dipartimento"]==DBNull.Value)return null; return  (Int32?)this["iddalia_dipartimento"];}
		set {if (value==null) this["iddalia_dipartimento"]= DBNull.Value; else this["iddalia_dipartimento"]= value;}
	}
	public object iddalia_dipartimentoValue { 
		get{ return this["iddalia_dipartimento"];}
		set {if (value==null|| value==DBNull.Value) this["iddalia_dipartimento"]= DBNull.Value; else this["iddalia_dipartimento"]= value;}
	}
	public Int32? iddalia_dipartimentoOriginal { 
		get {if (this["iddalia_dipartimento",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["iddalia_dipartimento",DataRowVersion.Original];}
	}
	#endregion

}
///<summary>
///Contratto
///</summary>
public class parasubcontractTable : MetaTableBase<parasubcontractRow> {
	public parasubcontractTable() : base("parasubcontract"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"idcon",createColumn("idcon",typeof(string),false,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"duty",createColumn("duty",typeof(string),true,false)},
			{"employed",createColumn("employed",typeof(string),false,false)},
			{"flagroundedmonths",createColumn("flagroundedmonths",typeof(string),true,false)},
			{"grossamount",createColumn("grossamount",typeof(decimal),false,false)},
			{"idaccmotive",createColumn("idaccmotive",typeof(string),true,false)},
			{"idmatriculabook",createColumn("idmatriculabook",typeof(string),true,false)},
			{"idpat",createColumn("idpat",typeof(int),true,false)},
			{"idpayrollkind",createColumn("idpayrollkind",typeof(string),true,false)},
			{"idreg",createColumn("idreg",typeof(int),false,false)},
			{"idupb",createColumn("idupb",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"matricula",createColumn("matricula",typeof(int),true,false)},
			{"monthlen",createColumn("monthlen",typeof(int),false,false)},
			{"ncon",createColumn("ncon",typeof(string),false,false)},
			{"payrollccinfo",createColumn("payrollccinfo",typeof(string),false,false)},
			{"rtf",createColumn("rtf",typeof(Byte[]),true,false)},
			{"start",createColumn("start",typeof(DateTime),false,false)},
			{"stop",createColumn("stop",typeof(DateTime),false,false)},
			{"txt",createColumn("txt",typeof(string),true,false)},
			{"ycon",createColumn("ycon",typeof(int),false,false)},
			{"idser",createColumn("idser",typeof(int),false,false)},
			{"idsor1",createColumn("idsor1",typeof(int),true,false)},
			{"idsor2",createColumn("idsor2",typeof(int),true,false)},
			{"idsor3",createColumn("idsor3",typeof(int),true,false)},
			{"idaccmotivedebit",createColumn("idaccmotivedebit",typeof(string),true,false)},
			{"idaccmotivedebit_crg",createColumn("idaccmotivedebit_crg",typeof(string),true,false)},
			{"idaccmotivedebit_datacrg",createColumn("idaccmotivedebit_datacrg",typeof(DateTime),true,false)},
			{"idregistrylegalstatus",createColumn("idregistrylegalstatus",typeof(int),true,false)},
			{"idsor01",createColumn("idsor01",typeof(int),true,false)},
			{"idsor02",createColumn("idsor02",typeof(int),true,false)},
			{"idsor03",createColumn("idsor03",typeof(int),true,false)},
			{"idsor04",createColumn("idsor04",typeof(int),true,false)},
			{"idsor05",createColumn("idsor05",typeof(int),true,false)},
			{"iddaliaposition",createColumn("iddaliaposition",typeof(int),true,false)},
			{"idsor_siope",createColumn("idsor_siope",typeof(int),true,false)},
			{"requested_doc",createColumn("requested_doc",typeof(int),true,false)},
			{"iddaliarecruitmentmotive",createColumn("iddaliarecruitmentmotive",typeof(int),true,false)},
			{"iddalia_funzionale",createColumn("iddalia_funzionale",typeof(int),true,false)},
			{"iddalia_dipartimento",createColumn("iddalia_dipartimento",typeof(int),true,false)},
		};
	}
}
}
