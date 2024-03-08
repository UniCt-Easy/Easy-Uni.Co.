
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace meta_emisti_rec_01 {
public class emisti_rec_01Row: MetaRow  {
	public emisti_rec_01Row(DataRowBuilder rb) : base(rb) {} 

	#region Field Definition
	public Int32 nrec{ 
		get {return  (Int32)this["nrec"];}
		set {this["nrec"]= value;}
	}
	public object nrecValue { 
		get{ return this["nrec"];}
		set {this["nrec"]= value;}
	}
	public Int32 nrecOriginal { 
		get {return  (Int32)this["nrec",DataRowVersion.Original];}
	}
	public String rata{ 
		get {if (this["rata"]==DBNull.Value)return null; return  (String)this["rata"];}
		set {if (value==null) this["rata"]= DBNull.Value; else this["rata"]= value;}
	}
	public object rataValue { 
		get{ return this["rata"];}
		set {if (value==null|| value==DBNull.Value) this["rata"]= DBNull.Value; else this["rata"]= value;}
	}
	public String rataOriginal { 
		get {if (this["rata",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["rata",DataRowVersion.Original];}
	}
	public DateTime dataemissione{ 
		get {return  (DateTime)this["dataemissione"];}
		set {this["dataemissione"]= value;}
	}
	public object dataemissioneValue { 
		get{ return this["dataemissione"];}
		set {this["dataemissione"]= value;}
	}
	public DateTime dataemissioneOriginal { 
		get {return  (DateTime)this["dataemissione",DataRowVersion.Original];}
	}
	public String dpt{ 
		get {if (this["dpt"]==DBNull.Value)return null; return  (String)this["dpt"];}
		set {if (value==null) this["dpt"]= DBNull.Value; else this["dpt"]= value;}
	}
	public object dptValue { 
		get{ return this["dpt"];}
		set {if (value==null|| value==DBNull.Value) this["dpt"]= DBNull.Value; else this["dpt"]= value;}
	}
	public String dptOriginal { 
		get {if (this["dpt",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["dpt",DataRowVersion.Original];}
	}
	public String codicefiscale{ 
		get {if (this["codicefiscale"]==DBNull.Value)return null; return  (String)this["codicefiscale"];}
		set {if (value==null) this["codicefiscale"]= DBNull.Value; else this["codicefiscale"]= value;}
	}
	public object codicefiscaleValue { 
		get{ return this["codicefiscale"];}
		set {if (value==null|| value==DBNull.Value) this["codicefiscale"]= DBNull.Value; else this["codicefiscale"]= value;}
	}
	public String codicefiscaleOriginal { 
		get {if (this["codicefiscale",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicefiscale",DataRowVersion.Original];}
	}
	public String cognome1{ 
		get {if (this["cognome1"]==DBNull.Value)return null; return  (String)this["cognome1"];}
		set {if (value==null) this["cognome1"]= DBNull.Value; else this["cognome1"]= value;}
	}
	public object cognome1Value { 
		get{ return this["cognome1"];}
		set {if (value==null|| value==DBNull.Value) this["cognome1"]= DBNull.Value; else this["cognome1"]= value;}
	}
	public String cognome1Original { 
		get {if (this["cognome1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cognome1",DataRowVersion.Original];}
	}
	public String nome1{ 
		get {if (this["nome1"]==DBNull.Value)return null; return  (String)this["nome1"];}
		set {if (value==null) this["nome1"]= DBNull.Value; else this["nome1"]= value;}
	}
	public object nome1Value { 
		get{ return this["nome1"];}
		set {if (value==null|| value==DBNull.Value) this["nome1"]= DBNull.Value; else this["nome1"]= value;}
	}
	public String nome1Original { 
		get {if (this["nome1",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["nome1",DataRowVersion.Original];}
	}
	public Int32 modalpagamento{ 
		get {return  (Int32)this["modalpagamento"];}
		set {this["modalpagamento"]= value;}
	}
	public object modalpagamentoValue { 
		get{ return this["modalpagamento"];}
		set {this["modalpagamento"]= value;}
	}
	public Int32 modalpagamentoOriginal { 
		get {return  (Int32)this["modalpagamento",DataRowVersion.Original];}
	}
	public Int32 tiposervizio{ 
		get {return  (Int32)this["tiposervizio"];}
		set {this["tiposervizio"]= value;}
	}
	public object tiposervizioValue { 
		get{ return this["tiposervizio"];}
		set {this["tiposervizio"]= value;}
	}
	public Int32 tiposervizioOriginal { 
		get {return  (Int32)this["tiposervizio",DataRowVersion.Original];}
	}
	public String iban{ 
		get {if (this["iban"]==DBNull.Value)return null; return  (String)this["iban"];}
		set {if (value==null) this["iban"]= DBNull.Value; else this["iban"]= value;}
	}
	public object ibanValue { 
		get{ return this["iban"];}
		set {if (value==null|| value==DBNull.Value) this["iban"]= DBNull.Value; else this["iban"]= value;}
	}
	public String ibanOriginal { 
		get {if (this["iban",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["iban",DataRowVersion.Original];}
	}
	public String cin{ 
		get {if (this["cin"]==DBNull.Value)return null; return  (String)this["cin"];}
		set {if (value==null) this["cin"]= DBNull.Value; else this["cin"]= value;}
	}
	public object cinValue { 
		get{ return this["cin"];}
		set {if (value==null|| value==DBNull.Value) this["cin"]= DBNull.Value; else this["cin"]= value;}
	}
	public String cinOriginal { 
		get {if (this["cin",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cin",DataRowVersion.Original];}
	}
	public String abi{ 
		get {if (this["abi"]==DBNull.Value)return null; return  (String)this["abi"];}
		set {if (value==null) this["abi"]= DBNull.Value; else this["abi"]= value;}
	}
	public object abiValue { 
		get{ return this["abi"];}
		set {if (value==null|| value==DBNull.Value) this["abi"]= DBNull.Value; else this["abi"]= value;}
	}
	public String abiOriginal { 
		get {if (this["abi",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["abi",DataRowVersion.Original];}
	}
	public String cab{ 
		get {if (this["cab"]==DBNull.Value)return null; return  (String)this["cab"];}
		set {if (value==null) this["cab"]= DBNull.Value; else this["cab"]= value;}
	}
	public object cabValue { 
		get{ return this["cab"];}
		set {if (value==null|| value==DBNull.Value) this["cab"]= DBNull.Value; else this["cab"]= value;}
	}
	public String cabOriginal { 
		get {if (this["cab",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["cab",DataRowVersion.Original];}
	}
	public String contocorrente{ 
		get {if (this["contocorrente"]==DBNull.Value)return null; return  (String)this["contocorrente"];}
		set {if (value==null) this["contocorrente"]= DBNull.Value; else this["contocorrente"]= value;}
	}
	public object contocorrenteValue { 
		get{ return this["contocorrente"];}
		set {if (value==null|| value==DBNull.Value) this["contocorrente"]= DBNull.Value; else this["contocorrente"]= value;}
	}
	public String contocorrenteOriginal { 
		get {if (this["contocorrente",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["contocorrente",DataRowVersion.Original];}
	}
	public String ufficioservizio{ 
		get {if (this["ufficioservizio"]==DBNull.Value)return null; return  (String)this["ufficioservizio"];}
		set {if (value==null) this["ufficioservizio"]= DBNull.Value; else this["ufficioservizio"]= value;}
	}
	public object ufficioservizioValue { 
		get{ return this["ufficioservizio"];}
		set {if (value==null|| value==DBNull.Value) this["ufficioservizio"]= DBNull.Value; else this["ufficioservizio"]= value;}
	}
	public String ufficioservizioOriginal { 
		get {if (this["ufficioservizio",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["ufficioservizio",DataRowVersion.Original];}
	}
	public Int32? capitolospesa{ 
		get {if (this["capitolospesa"]==DBNull.Value)return null; return  (Int32?)this["capitolospesa"];}
		set {if (value==null) this["capitolospesa"]= DBNull.Value; else this["capitolospesa"]= value;}
	}
	public object capitolospesaValue { 
		get{ return this["capitolospesa"];}
		set {if (value==null|| value==DBNull.Value) this["capitolospesa"]= DBNull.Value; else this["capitolospesa"]= value;}
	}
	public Int32? capitolospesaOriginal { 
		get {if (this["capitolospesa",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["capitolospesa",DataRowVersion.Original];}
	}
	public Int32? capitolobilancio{ 
		get {if (this["capitolobilancio"]==DBNull.Value)return null; return  (Int32?)this["capitolobilancio"];}
		set {if (value==null) this["capitolobilancio"]= DBNull.Value; else this["capitolobilancio"]= value;}
	}
	public object capitolobilancioValue { 
		get{ return this["capitolobilancio"];}
		set {if (value==null|| value==DBNull.Value) this["capitolobilancio"]= DBNull.Value; else this["capitolobilancio"]= value;}
	}
	public Int32? capitolobilancioOriginal { 
		get {if (this["capitolobilancio",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["capitolobilancio",DataRowVersion.Original];}
	}
	public String qualifica{ 
		get {if (this["qualifica"]==DBNull.Value)return null; return  (String)this["qualifica"];}
		set {if (value==null) this["qualifica"]= DBNull.Value; else this["qualifica"]= value;}
	}
	public object qualificaValue { 
		get{ return this["qualifica"];}
		set {if (value==null|| value==DBNull.Value) this["qualifica"]= DBNull.Value; else this["qualifica"]= value;}
	}
	public String qualificaOriginal { 
		get {if (this["qualifica",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["qualifica",DataRowVersion.Original];}
	}
	public Int32 livello{ 
		get {return  (Int32)this["livello"];}
		set {this["livello"]= value;}
	}
	public object livelloValue { 
		get{ return this["livello"];}
		set {this["livello"]= value;}
	}
	public Int32 livelloOriginal { 
		get {return  (Int32)this["livello",DataRowVersion.Original];}
	}
	public Int32 classe{ 
		get {return  (Int32)this["classe"];}
		set {this["classe"]= value;}
	}
	public object classeValue { 
		get{ return this["classe"];}
		set {this["classe"]= value;}
	}
	public Int32 classeOriginal { 
		get {return  (Int32)this["classe",DataRowVersion.Original];}
	}
	public Int32 scatti{ 
		get {return  (Int32)this["scatti"];}
		set {this["scatti"]= value;}
	}
	public object scattiValue { 
		get{ return this["scatti"];}
		set {this["scatti"]= value;}
	}
	public Int32 scattiOriginal { 
		get {return  (Int32)this["scatti",DataRowVersion.Original];}
	}
	public Int32 imponibilerataannocorrente{ 
		get {return  (Int32)this["imponibilerataannocorrente"];}
		set {this["imponibilerataannocorrente"]= value;}
	}
	public object imponibilerataannocorrenteValue { 
		get{ return this["imponibilerataannocorrente"];}
		set {this["imponibilerataannocorrente"]= value;}
	}
	public Int32 imponibilerataannocorrenteOriginal { 
		get {return  (Int32)this["imponibilerataannocorrente",DataRowVersion.Original];}
	}
	public Int32 irpefrataannocorrente{ 
		get {return  (Int32)this["irpefrataannocorrente"];}
		set {this["irpefrataannocorrente"]= value;}
	}
	public object irpefrataannocorrenteValue { 
		get{ return this["irpefrataannocorrente"];}
		set {this["irpefrataannocorrente"]= value;}
	}
	public Int32 irpefrataannocorrenteOriginal { 
		get {return  (Int32)this["irpefrataannocorrente",DataRowVersion.Original];}
	}
	public Int32 irpefarretratiannocorrente{ 
		get {return  (Int32)this["irpefarretratiannocorrente"];}
		set {this["irpefarretratiannocorrente"]= value;}
	}
	public object irpefarretratiannocorrenteValue { 
		get{ return this["irpefarretratiannocorrente"];}
		set {this["irpefarretratiannocorrente"]= value;}
	}
	public Int32 irpefarretratiannocorrenteOriginal { 
		get {return  (Int32)this["irpefarretratiannocorrente",DataRowVersion.Original];}
	}
	public Int32 irpefarretratiannoprecedente{ 
		get {return  (Int32)this["irpefarretratiannoprecedente"];}
		set {this["irpefarretratiannoprecedente"]= value;}
	}
	public object irpefarretratiannoprecedenteValue { 
		get{ return this["irpefarretratiannoprecedente"];}
		set {this["irpefarretratiannoprecedente"]= value;}
	}
	public Int32 irpefarretratiannoprecedenteOriginal { 
		get {return  (Int32)this["irpefarretratiannoprecedente",DataRowVersion.Original];}
	}
	public Int32 irpeftotalenetta{ 
		get {return  (Int32)this["irpeftotalenetta"];}
		set {this["irpeftotalenetta"]= value;}
	}
	public object irpeftotalenettaValue { 
		get{ return this["irpeftotalenetta"];}
		set {this["irpeftotalenetta"]= value;}
	}
	public Int32 irpeftotalenettaOriginal { 
		get {return  (Int32)this["irpeftotalenetta",DataRowVersion.Original];}
	}
	public Int32 importoannuolordo{ 
		get {return  (Int32)this["importoannuolordo"];}
		set {this["importoannuolordo"]= value;}
	}
	public object importoannuolordoValue { 
		get{ return this["importoannuolordo"];}
		set {this["importoannuolordo"]= value;}
	}
	public Int32 importoannuolordoOriginal { 
		get {return  (Int32)this["importoannuolordo",DataRowVersion.Original];}
	}
	public Int32 importomensilelordo{ 
		get {return  (Int32)this["importomensilelordo"];}
		set {this["importomensilelordo"]= value;}
	}
	public object importomensilelordoValue { 
		get{ return this["importomensilelordo"];}
		set {this["importomensilelordo"]= value;}
	}
	public Int32 importomensilelordoOriginal { 
		get {return  (Int32)this["importomensilelordo",DataRowVersion.Original];}
	}
	public Int32 importomensilenetto{ 
		get {return  (Int32)this["importomensilenetto"];}
		set {this["importomensilenetto"]= value;}
	}
	public object importomensilenettoValue { 
		get{ return this["importomensilenetto"];}
		set {this["importomensilenetto"]= value;}
	}
	public Int32 importomensilenettoOriginal { 
		get {return  (Int32)this["importomensilenetto",DataRowVersion.Original];}
	}
	public Int32 importonetto13ma{ 
		get {return  (Int32)this["importonetto13ma"];}
		set {this["importonetto13ma"]= value;}
	}
	public object importonetto13maValue { 
		get{ return this["importonetto13ma"];}
		set {this["importonetto13ma"]= value;}
	}
	public Int32 importonetto13maOriginal { 
		get {return  (Int32)this["importonetto13ma",DataRowVersion.Original];}
	}
	public Int32 importoprev13ma{ 
		get {return  (Int32)this["importoprev13ma"];}
		set {this["importoprev13ma"]= value;}
	}
	public object importoprev13maValue { 
		get{ return this["importoprev13ma"];}
		set {this["importoprev13ma"]= value;}
	}
	public Int32 importoprev13maOriginal { 
		get {return  (Int32)this["importoprev13ma",DataRowVersion.Original];}
	}
	public Int32 importoirpef13ma{ 
		get {return  (Int32)this["importoirpef13ma"];}
		set {this["importoirpef13ma"]= value;}
	}
	public object importoirpef13maValue { 
		get{ return this["importoirpef13ma"];}
		set {this["importoirpef13ma"]= value;}
	}
	public Int32 importoirpef13maOriginal { 
		get {return  (Int32)this["importoirpef13ma",DataRowVersion.Original];}
	}
	public Int32 detrazionibase{ 
		get {return  (Int32)this["detrazionibase"];}
		set {this["detrazionibase"]= value;}
	}
	public object detrazionibaseValue { 
		get{ return this["detrazionibase"];}
		set {this["detrazionibase"]= value;}
	}
	public Int32 detrazionibaseOriginal { 
		get {return  (Int32)this["detrazionibase",DataRowVersion.Original];}
	}
	public Int32 detrazioniconiuge{ 
		get {return  (Int32)this["detrazioniconiuge"];}
		set {this["detrazioniconiuge"]= value;}
	}
	public object detrazioniconiugeValue { 
		get{ return this["detrazioniconiuge"];}
		set {this["detrazioniconiuge"]= value;}
	}
	public Int32 detrazioniconiugeOriginal { 
		get {return  (Int32)this["detrazioniconiuge",DataRowVersion.Original];}
	}
	public Int32 detrazionifigli{ 
		get {return  (Int32)this["detrazionifigli"];}
		set {this["detrazionifigli"]= value;}
	}
	public object detrazionifigliValue { 
		get{ return this["detrazionifigli"];}
		set {this["detrazionifigli"]= value;}
	}
	public Int32 detrazionifigliOriginal { 
		get {return  (Int32)this["detrazionifigli",DataRowVersion.Original];}
	}
	public Int32 detrazionialtrifam{ 
		get {return  (Int32)this["detrazionialtrifam"];}
		set {this["detrazionialtrifam"]= value;}
	}
	public object detrazionialtrifamValue { 
		get{ return this["detrazionialtrifam"];}
		set {this["detrazionialtrifam"]= value;}
	}
	public Int32 detrazionialtrifamOriginal { 
		get {return  (Int32)this["detrazionialtrifam",DataRowVersion.Original];}
	}
	public Int32 totaledetrazioni{ 
		get {return  (Int32)this["totaledetrazioni"];}
		set {this["totaledetrazioni"]= value;}
	}
	public object totaledetrazioniValue { 
		get{ return this["totaledetrazioni"];}
		set {this["totaledetrazioni"]= value;}
	}
	public Int32 totaledetrazioniOriginal { 
		get {return  (Int32)this["totaledetrazioni",DataRowVersion.Original];}
	}
	public String codiceregimecontributivo{ 
		get {if (this["codiceregimecontributivo"]==DBNull.Value)return null; return  (String)this["codiceregimecontributivo"];}
		set {if (value==null) this["codiceregimecontributivo"]= DBNull.Value; else this["codiceregimecontributivo"]= value;}
	}
	public object codiceregimecontributivoValue { 
		get{ return this["codiceregimecontributivo"];}
		set {if (value==null|| value==DBNull.Value) this["codiceregimecontributivo"]= DBNull.Value; else this["codiceregimecontributivo"]= value;}
	}
	public String codiceregimecontributivoOriginal { 
		get {if (this["codiceregimecontributivo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codiceregimecontributivo",DataRowVersion.Original];}
	}
	public String codregioneirap{ 
		get {if (this["codregioneirap"]==DBNull.Value)return null; return  (String)this["codregioneirap"];}
		set {if (value==null) this["codregioneirap"]= DBNull.Value; else this["codregioneirap"]= value;}
	}
	public object codregioneirapValue { 
		get{ return this["codregioneirap"];}
		set {if (value==null|| value==DBNull.Value) this["codregioneirap"]= DBNull.Value; else this["codregioneirap"]= value;}
	}
	public String codregioneirapOriginal { 
		get {if (this["codregioneirap",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codregioneirap",DataRowVersion.Original];}
	}
	public String codicecomuneaccon{ 
		get {if (this["codicecomuneaccon"]==DBNull.Value)return null; return  (String)this["codicecomuneaccon"];}
		set {if (value==null) this["codicecomuneaccon"]= DBNull.Value; else this["codicecomuneaccon"]= value;}
	}
	public object codicecomuneacconValue { 
		get{ return this["codicecomuneaccon"];}
		set {if (value==null|| value==DBNull.Value) this["codicecomuneaccon"]= DBNull.Value; else this["codicecomuneaccon"]= value;}
	}
	public String codicecomuneacconOriginal { 
		get {if (this["codicecomuneaccon",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicecomuneaccon",DataRowVersion.Original];}
	}
	public String codicecomunesaldo{ 
		get {if (this["codicecomunesaldo"]==DBNull.Value)return null; return  (String)this["codicecomunesaldo"];}
		set {if (value==null) this["codicecomunesaldo"]= DBNull.Value; else this["codicecomunesaldo"]= value;}
	}
	public object codicecomunesaldoValue { 
		get{ return this["codicecomunesaldo"];}
		set {if (value==null|| value==DBNull.Value) this["codicecomunesaldo"]= DBNull.Value; else this["codicecomunesaldo"]= value;}
	}
	public String codicecomunesaldoOriginal { 
		get {if (this["codicecomunesaldo",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["codicecomunesaldo",DataRowVersion.Original];}
	}
	public Int32? irpefaccessorieac{ 
		get {if (this["irpefaccessorieac"]==DBNull.Value)return null; return  (Int32?)this["irpefaccessorieac"];}
		set {if (value==null) this["irpefaccessorieac"]= DBNull.Value; else this["irpefaccessorieac"]= value;}
	}
	public object irpefaccessorieacValue { 
		get{ return this["irpefaccessorieac"];}
		set {if (value==null|| value==DBNull.Value) this["irpefaccessorieac"]= DBNull.Value; else this["irpefaccessorieac"]= value;}
	}
	public Int32? irpefaccessorieacOriginal { 
		get {if (this["irpefaccessorieac",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["irpefaccessorieac",DataRowVersion.Original];}
	}
	public Int32? irpefaccessorieap{ 
		get {if (this["irpefaccessorieap"]==DBNull.Value)return null; return  (Int32?)this["irpefaccessorieap"];}
		set {if (value==null) this["irpefaccessorieap"]= DBNull.Value; else this["irpefaccessorieap"]= value;}
	}
	public object irpefaccessorieapValue { 
		get{ return this["irpefaccessorieap"];}
		set {if (value==null|| value==DBNull.Value) this["irpefaccessorieap"]= DBNull.Value; else this["irpefaccessorieap"]= value;}
	}
	public Int32? irpefaccessorieapOriginal { 
		get {if (this["irpefaccessorieap",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["irpefaccessorieap",DataRowVersion.Original];}
	}
	public String regimecontributivocud{ 
		get {if (this["regimecontributivocud"]==DBNull.Value)return null; return  (String)this["regimecontributivocud"];}
		set {if (value==null) this["regimecontributivocud"]= DBNull.Value; else this["regimecontributivocud"]= value;}
	}
	public object regimecontributivocudValue { 
		get{ return this["regimecontributivocud"];}
		set {if (value==null|| value==DBNull.Value) this["regimecontributivocud"]= DBNull.Value; else this["regimecontributivocud"]= value;}
	}
	public String regimecontributivocudOriginal { 
		get {if (this["regimecontributivocud",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["regimecontributivocud",DataRowVersion.Original];}
	}
	public Int32? creditoirpef{ 
		get {if (this["creditoirpef"]==DBNull.Value)return null; return  (Int32?)this["creditoirpef"];}
		set {if (value==null) this["creditoirpef"]= DBNull.Value; else this["creditoirpef"]= value;}
	}
	public object creditoirpefValue { 
		get{ return this["creditoirpef"];}
		set {if (value==null|| value==DBNull.Value) this["creditoirpef"]= DBNull.Value; else this["creditoirpef"]= value;}
	}
	public Int32? creditoirpefOriginal { 
		get {if (this["creditoirpef",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["creditoirpef",DataRowVersion.Original];}
	}
	public Int32? aliquotamedia{ 
		get {if (this["aliquotamedia"]==DBNull.Value)return null; return  (Int32?)this["aliquotamedia"];}
		set {if (value==null) this["aliquotamedia"]= DBNull.Value; else this["aliquotamedia"]= value;}
	}
	public object aliquotamediaValue { 
		get{ return this["aliquotamedia"];}
		set {if (value==null|| value==DBNull.Value) this["aliquotamedia"]= DBNull.Value; else this["aliquotamedia"]= value;}
	}
	public Int32? aliquotamediaOriginal { 
		get {if (this["aliquotamedia",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["aliquotamedia",DataRowVersion.Original];}
	}
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
	public String iscrizione{ 
		get {if (this["iscrizione"]==DBNull.Value)return null; return  (String)this["iscrizione"];}
		set {if (value==null) this["iscrizione"]= DBNull.Value; else this["iscrizione"]= value;}
	}
	public object iscrizioneValue { 
		get{ return this["iscrizione"];}
		set {if (value==null|| value==DBNull.Value) this["iscrizione"]= DBNull.Value; else this["iscrizione"]= value;}
	}
	public String iscrizioneOriginal { 
		get {if (this["iscrizione",DataRowVersion.Original]==DBNull.Value)return null; return  (String)this["iscrizione",DataRowVersion.Original];}
	}
	public Int32 idemisti_import{ 
		get {return  (Int32)this["idemisti_import"];}
		set {this["idemisti_import"]= value;}
	}
	public object idemisti_importValue { 
		get{ return this["idemisti_import"];}
		set {this["idemisti_import"]= value;}
	}
	public Int32 idemisti_importOriginal { 
		get {return  (Int32)this["idemisti_import",DataRowVersion.Original];}
	}
	public Int32? progressivo_rec_01{ 
		get {if (this["progressivo_rec_01"]==DBNull.Value)return null; return  (Int32?)this["progressivo_rec_01"];}
		set {if (value==null) this["progressivo_rec_01"]= DBNull.Value; else this["progressivo_rec_01"]= value;}
	}
	public object progressivo_rec_01Value { 
		get{ return this["progressivo_rec_01"];}
		set {if (value==null|| value==DBNull.Value) this["progressivo_rec_01"]= DBNull.Value; else this["progressivo_rec_01"]= value;}
	}
	public Int32? progressivo_rec_01Original { 
		get {if (this["progressivo_rec_01",DataRowVersion.Original]==DBNull.Value)return null; return  (Int32?)this["progressivo_rec_01",DataRowVersion.Original];}
	}
	#endregion

}
public class emisti_rec_01Table : MetaTableBase<emisti_rec_01Row> {
	public emisti_rec_01Table() : base("emisti_rec_01"){
		baseColumns = new Dictionary<string, DataColumn>(){
			{"nrec",createColumn("nrec",typeof(int),false,false)},
			{"rata",createColumn("rata",typeof(string),true,false)},
			{"dataemissione",createColumn("dataemissione",typeof(DateTime),false,false)},
			{"dpt",createColumn("dpt",typeof(string),true,false)},
			{"codicefiscale",createColumn("codicefiscale",typeof(string),true,false)},
			{"cognome1",createColumn("cognome1",typeof(string),true,false)},
			{"nome1",createColumn("nome1",typeof(string),true,false)},
			{"modalpagamento",createColumn("modalpagamento",typeof(int),false,false)},
			{"tiposervizio",createColumn("tiposervizio",typeof(int),false,false)},
			{"iban",createColumn("iban",typeof(string),true,false)},
			{"cin",createColumn("cin",typeof(string),true,false)},
			{"abi",createColumn("abi",typeof(string),true,false)},
			{"cab",createColumn("cab",typeof(string),true,false)},
			{"contocorrente",createColumn("contocorrente",typeof(string),true,false)},
			{"ufficioservizio",createColumn("ufficioservizio",typeof(string),true,false)},
			{"capitolospesa",createColumn("capitolospesa",typeof(int),true,false)},
			{"capitolobilancio",createColumn("capitolobilancio",typeof(int),true,false)},
			{"qualifica",createColumn("qualifica",typeof(string),true,false)},
			{"livello",createColumn("livello",typeof(int),false,false)},
			{"classe",createColumn("classe",typeof(int),false,false)},
			{"scatti",createColumn("scatti",typeof(int),false,false)},
			{"imponibilerataannocorrente",createColumn("imponibilerataannocorrente",typeof(int),false,false)},
			{"irpefrataannocorrente",createColumn("irpefrataannocorrente",typeof(int),false,false)},
			{"irpefarretratiannocorrente",createColumn("irpefarretratiannocorrente",typeof(int),false,false)},
			{"irpefarretratiannoprecedente",createColumn("irpefarretratiannoprecedente",typeof(int),false,false)},
			{"irpeftotalenetta",createColumn("irpeftotalenetta",typeof(int),false,false)},
			{"importoannuolordo",createColumn("importoannuolordo",typeof(int),false,false)},
			{"importomensilelordo",createColumn("importomensilelordo",typeof(int),false,false)},
			{"importomensilenetto",createColumn("importomensilenetto",typeof(int),false,false)},
			{"importonetto13ma",createColumn("importonetto13ma",typeof(int),false,false)},
			{"importoprev13ma",createColumn("importoprev13ma",typeof(int),false,false)},
			{"importoirpef13ma",createColumn("importoirpef13ma",typeof(int),false,false)},
			{"detrazionibase",createColumn("detrazionibase",typeof(int),false,false)},
			{"detrazioniconiuge",createColumn("detrazioniconiuge",typeof(int),false,false)},
			{"detrazionifigli",createColumn("detrazionifigli",typeof(int),false,false)},
			{"detrazionialtrifam",createColumn("detrazionialtrifam",typeof(int),false,false)},
			{"totaledetrazioni",createColumn("totaledetrazioni",typeof(int),false,false)},
			{"codiceregimecontributivo",createColumn("codiceregimecontributivo",typeof(string),true,false)},
			{"codregioneirap",createColumn("codregioneirap",typeof(string),true,false)},
			{"codicecomuneaccon",createColumn("codicecomuneaccon",typeof(string),true,false)},
			{"codicecomunesaldo",createColumn("codicecomunesaldo",typeof(string),true,false)},
			{"irpefaccessorieac",createColumn("irpefaccessorieac",typeof(int),true,false)},
			{"irpefaccessorieap",createColumn("irpefaccessorieap",typeof(int),true,false)},
			{"regimecontributivocud",createColumn("regimecontributivocud",typeof(string),true,false)},
			{"creditoirpef",createColumn("creditoirpef",typeof(int),true,false)},
			{"aliquotamedia",createColumn("aliquotamedia",typeof(int),true,false)},
			{"ct",createColumn("ct",typeof(DateTime),true,false)},
			{"cu",createColumn("cu",typeof(string),true,false)},
			{"lt",createColumn("lt",typeof(DateTime),true,false)},
			{"lu",createColumn("lu",typeof(string),true,false)},
			{"iscrizione",createColumn("iscrizione",typeof(string),true,false)},
			{"idemisti_import",createColumn("idemisti_import",typeof(int),false,false)},
			{"progressivo_rec_01",createColumn("progressivo_rec_01",typeof(int),true,false)},
		};
	}
}
}
