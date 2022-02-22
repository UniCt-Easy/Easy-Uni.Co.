
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
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections;
using System.Xml.Schema;
using System.ComponentModel;
using System.Xml;
using funzioni_configurazione;
namespace IntesaSanPaolo
{
    public class import_RicevutaTelematica
	{

        public static string ImportaFile_RT(string filename, out RendicontaPlus RT) {
            RT = new RendicontaPlus();
            if (!(File.Exists(filename))) {
                return "Il file selezionato non esiste o non è accessibile.";
            }
            XmlDocument X = new XmlDocument();
            try {
                X.Load(filename);
            }
            catch (Exception e2) {
                return e2.Message + " " + e2.ToString();
            }
            try {
                RT = ElaboraXml_RT(X);
            }
            catch (Exception e) {
                return e.Message + " " + e.ToString();
                //QueryCreator.ShowException(null, "Errore!", e);
            }
            return null;

        }


        static string getXmlText(XmlNode x, string xpath) {
            try {
                XmlNode n = x.SelectSingleNode(xpath);
                if (n != null) {
                    return n.InnerText;
                }
            }
            catch (Exception e) {
                string errore = e.Message + " " + e.ToString();
            }
            return null;
        }

        static string getXmlText(XmlNode x, string xpath, XmlNamespaceManager ns) {
            if (ns == null) {
                try {
                    XmlNode n = x.SelectSingleNode(xpath);
                    if (n != null) {
                        return n.InnerText;
                    }
                }
                catch {
                }

                return null;
            }

            try {
                XmlNode n = x.SelectSingleNode(xpath, ns);
                if (n != null) {
                    return n.InnerText;
                }
            }
            catch {
            }

            return null;
        }
        public static object LeggiDecimale(string sImportoTotale) {
            object importoTotale;
            if (sImportoTotale != "" && sImportoTotale != null) {
                importoTotale =
                    XmlConvert.ToDecimal(
                        sImportoTotale);
            }
            else {
                importoTotale = DBNull.Value;
            }
            return importoTotale;
        }

        public static RendicontaPlus ElaboraXml_RT(XmlDocument Xdoc) {
            RendicontaPlus M = new RendicontaPlus();

            if (Xdoc.GetElementsByTagName("RendicontaPlus").Count >0) { 
                XmlNode nodoRP = Xdoc.GetElementsByTagName("RendicontaPlus")[0];
                string PreRoot = "";    
                // gestione dei nomi in caso di prefisso, commento al momnto dato che non ne trovo negli esempi disponibili
                // if (nodoRT == null) {
                //    nodoRT = Xdoc.GetElementsByTagName("pay_i:RendicontaPlus")[0];
                //    PreRoot = "pay_i:";
                //}

                M.DenominazioneUB = nodoRP[PreRoot + "denominazioneUB"].InnerText;
                M.IdentificativoUB = nodoRP[PreRoot + "identificativoUB"].InnerText;
                M.IdentificativoDominio = nodoRP[PreRoot + "identificativoDominio"].InnerText;
 
            //Scorre l'elenco delle ricevute telematiche contenute nel file di rendicontazione
                foreach (XmlNode CurrNode in nodoRP.ChildNodes) {
                    //XmlNodeList listOfsoggettoPagatore = singleRT.ChildNodes;// ["soggettoPagatore"];
                    if (CurrNode.Name == PreRoot + "ricevutaTelematica") {
                        RendicontaPlusRicevutaTelematica RT = new RendicontaPlusRicevutaTelematica();
                        if (CurrNode[PreRoot + "anagraficaPagatore"] != null) {
                            RT.AnagraficaPagatore = CurrNode[PreRoot + "anagraficaPagatore"].InnerText;
                        }
                        if (CurrNode[PreRoot + "capPagatore"] != null) {
                            RT.CapPagatore = CurrNode[PreRoot + "capPagatore"].InnerText;
                        }
                        if (CurrNode[PreRoot + "civicoPagatore"] != null) {
                            RT.CivicoPagatore = CurrNode[PreRoot + "civicoPagatore"].InnerText;
                        }
                        if (CurrNode[PreRoot + "emailPagatore"] != null) {
                            RT.EmailPagatore = CurrNode[PreRoot + "emailPagatore"].InnerText;
                        }

                        if (CurrNode[PreRoot + "indirizzoPagatore"] != null) {
                            RT.IndirizzoPagatore = CurrNode[PreRoot + "indirizzoPagatore"].InnerText;
                        }
                        if (CurrNode[PreRoot + "localitaPagatore"] != null) {
                            RT.LocalitaPagatore = CurrNode[PreRoot + "localitaPagatore"].InnerText;
                        }
                        if (CurrNode[PreRoot + "nazionePagatore"] != null) {
                            RT.NazionePagatore = CurrNode[PreRoot + "nazionePagatore"].InnerText;
                        }

                        if (CurrNode[PreRoot + "provinciaPagatore"] != null) {
                            RT.ProvinciaPagatore = CurrNode[PreRoot + "provinciaPagatore"].InnerText;
                        }


                        if (CurrNode[PreRoot + "identificativoUnivocoVersamento"] != null) {
                            RT.IdentificativoUnivocoVersamento = CurrNode[PreRoot + "identificativoUnivocoVersamento"].InnerText;
                        }

                        if (CurrNode[PreRoot + "idTenant"] != null) {
                            RT.IdTenant = CurrNode[PreRoot + "idTenant"].InnerText;
                        }

                        if (CurrNode[PreRoot + "dataEsecuzionePagamento"] != null) {
                            RT.DataEsecuzionePagamento = (DateTime)XmlHelper.AsOptionalDate(CurrNode, PreRoot + "dataEsecuzionePagamento");
                        }

                        if (CurrNode[PreRoot + "dataInvioRt"] != null) {
                            RT.DataInvioRt = (DateTime)XmlHelper.AsOptionalDate(CurrNode, PreRoot + "dataInvioRt");
                        }
 
                    
                        if (CurrNode[PreRoot + "codiceContestoPagamento"] != null) {
                            RT.CodiceContestoPagamento = CurrNode[PreRoot + "codiceContestoPagamento"].InnerText;
                        }

                        if (CurrNode[PreRoot + "codiceEsitoPagamento"] != null) {
                            RT.CodiceEsitoPagamento = CurrNode[PreRoot + "codiceEsitoPagamento"].InnerText;
                        }

                        if (CurrNode[PreRoot + "tipoIdentificativoUnivocoAttestante"] != null) {
                            RT.TipoIdentificativoUnivocoAttestante = CurrNode[PreRoot + "tipoIdentificativoUnivocoAttestante"].InnerText;
                        }

                        if (CurrNode[PreRoot + "denominazioneAttestante"] != null) {
                            RT.DenominazioneAttestante = CurrNode[PreRoot + "denominazioneAttestante"].InnerText;
                        }
                        if (CurrNode[PreRoot + "tipoIdentificativoUnivocoPagatore"] != null) {
                            RT.TipoIdentificativoUnivocoPagatore = CurrNode[PreRoot + "tipoIdentificativoUnivocoPagatore"].InnerText;
                        }
                        if (CurrNode[PreRoot + "codiceIdentificativoUnivocoPagatore"] != null) {
                            RT.CodiceIdentificativoUnivocoPagatore = CurrNode[PreRoot + "codiceIdentificativoUnivocoPagatore"].InnerText;
                        }
                        if (CurrNode[PreRoot + "codiceIdentificativoUnivocoBeneficiario"] != null) {
                            RT.CodiceIdentificativoUnivocoBeneficiario = CurrNode[PreRoot + "codiceIdentificativoUnivocoBeneficiario"].InnerText;
                        }
                        if (CurrNode[PreRoot + "tipoIdentificativoUnivocoBeneficiario"] != null) {
                            RT.TipoIdentificativoUnivocoBeneficiario = CurrNode[PreRoot + "tipoIdentificativoUnivocoBeneficiario"].InnerText;
                        }
                        if (CurrNode[PreRoot + "denominazioneBeneficiario"] != null) {
                            RT.DenominazioneBeneficiario = CurrNode[PreRoot + "denominazioneBeneficiario"].InnerText;
                        }

                        if (CurrNode[PreRoot + "importoTotaleDaVersare"] != null) {
                            RT.ImportoTotaleDaVersare = XmlHelper.AsDecimal(CurrNode, PreRoot + "importoTotaleDaVersare");
                        }

                 
                        //cred.UserName.UserName = user ?? Username;
                        foreach (XmlNode datiSingoloPagamento in CurrNode.ChildNodes) {
                            // mi leggo i dati del soggetto pagatore
                        
                            if (datiSingoloPagamento.Name == PreRoot + "datiSingoloPagamento") {
                                RendicontaPlusRicevutaTelematicaDatiSingoloPagamento SP = new RendicontaPlusRicevutaTelematicaDatiSingoloPagamento();
                                // XmlNodeList nodeList = datiSingoloPagamento.ChildNodes;
                                if (datiSingoloPagamento[PreRoot + "capitoloDiBilancio"] != null) {
                                    SP.CapitoloDiBilancio =   datiSingoloPagamento[PreRoot + "capitoloDiBilancio"].InnerText;
                                }
                                if (datiSingoloPagamento[PreRoot + "codiceTributo"] != null) {
                                    SP.CapitoloDiBilancio = datiSingoloPagamento[PreRoot + "codiceTributo"].InnerText;
                                }
 
                                SP.DataRegolamento = (DateTime)XmlHelper.AsOptionalDate(datiSingoloPagamento, PreRoot + "dataRegolamento");

                                if (datiSingoloPagamento[PreRoot + "causaleVersamento"] != null) {
                                    SP.CausaleVersamento = datiSingoloPagamento[PreRoot + "causaleVersamento"].InnerText;
                                }

                                if (datiSingoloPagamento[PreRoot + "datiSpecificiRiscossione"] != null) {
                                    SP.CausaleVersamento = datiSingoloPagamento[PreRoot + "datiSpecificiRiscossione"].InnerText;
                                }
                                if (datiSingoloPagamento[PreRoot + "ibanAccredito"] != null) {
                                    SP.IbanAccredito = datiSingoloPagamento[PreRoot + "ibanAccredito"].InnerText;
                                }
                                if (datiSingoloPagamento[PreRoot + "identificativoUnivocoRegolamento"] != null) {
                                    SP.IdentificativoUnivocoRegolamento = datiSingoloPagamento[PreRoot + "identificativoUnivocoRegolamento"].InnerText;
                                }
                                if (datiSingoloPagamento[PreRoot + "identUnivocoRiscossione"] != null) {
                                    SP.IdentUnivocoRiscossione = datiSingoloPagamento[PreRoot + "identUnivocoRiscossione"].InnerText;
                                }
                                if (datiSingoloPagamento[PreRoot + "idFlusso"] != null) {
                                    SP.IdFlusso = datiSingoloPagamento[PreRoot + "idFlusso"].InnerText;
                                }
                                SP.ImportoSingoloVersamento = XmlHelper.AsDecimal(datiSingoloPagamento,PreRoot +"importoSingoloVersamento");
                                if (datiSingoloPagamento[PreRoot + "provvisorioEntrata"] != null) {
                                    SP.ProvvisorioEntrata = datiSingoloPagamento[PreRoot + "provvisorioEntrata"].InnerText;
                                }
                                if (datiSingoloPagamento[PreRoot + "tipoVersamento"] != null) {
                                    SP.TipoVersamento = datiSingoloPagamento[PreRoot + "tipoVersamento"].InnerText;
                                }
                            
                                RT.DatiSingoloPagamento.Add(SP);
                            }
                        }

                        M.RicevutaTelematica.Add(RT);
                    }
                   
                 
                }
            }
            return M;
        }




    }

	}

