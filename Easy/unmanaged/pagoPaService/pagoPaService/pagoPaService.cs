
/*
Easy
Copyright (C) 2022 UniversitÃƒÆ’Ã‚Â  degli Studi di Catania (www.unict.it)
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
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using funzioni_configurazione;
using System.IO;
using System.Net;           //Needs to be added
using q = metadatalibrary.MetaExpression;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Serialization;
using GovPayCrediti=pagoPaService.govPayReference;
using InfoGroup;
using meta_flussoincassi;
using auth = pagoPaService.AuthPASoap;
using pay = pagoPaService.PayPA;
using bSondrio = pagoPaService.bsondrio1_1;
using Valtellinese;
using SiopePlus;
using System.ServiceModel;
using System.ServiceModel.Channels;
using GovPay;

namespace pagoPaService
{




	public class InformazioniEnteGenerico
	{
		public byte[] Logo;
		public string Denominazione;
		public string CodiceFiscale;
		public string Indirizzo1;
		public string Indirizzo2;
		public string CAP;
		public string LocalitÃƒÆ’Ã‚Â ;
		public string Provincia;
	}

	public class AvvisoPagamento
	{
		public byte[] pdf;
		public string iuv;
		public string ente;
		public string debitore;
		public string email;

	}

	public class PagoPaService
	{
		public const string BSONDRIO = "bsondrio";
		public const string INTESASP = "intesasp";
		public const string VALTELLINESE = "valtellinese";
		public const string UNICREDIT = "unicredit";
		public const string UBIBANCA = "ubibanca";
		public const string GOMP = "gomp";
		public const string CINECA_CREDITI = "cineca_crediti";




		public static InformazioniEnteGenerico getInformazioniEnte(DataAccess conn, out string error)
		{
			error = null;
			InformazioniEnteGenerico info = new InformazioniEnteGenerico();
			QueryHelper qhs = conn.GetQueryHelper();
			var filterLogo = qhs.CmpEq("idlogo", "UNIV");
			var logo = conn.DO_READ_VALUE("logo", filterLogo, "logo");
			if (logo == null || DBNull.Value.Equals(logo))
			{
				error = "Manca il Logo";
				return null;
			}

			info.Logo = (byte[])logo;
			DateTime dataContabile = conn.GetDataContabile();
			var filterParams = qhs.AppAnd(qhs.NullOrLe("start", dataContabile), qhs.NullOrGt("stop", dataContabile));
			var tParametriStampe = conn.RUN_SELECT("generalreportparameter", "*", null, filterParams, null, false);
			if (tParametriStampe == null)
			{
				error = "Mancano le informazioni sull'ente in generalreportparameter";
				return null;
			}

			foreach (DataRow r in tParametriStampe.Rows)
			{
				if (DBNull.Value.Equals(r["paramvalue"]))
				{
					continue;
				}

				var value = r["paramvalue"].ToString();
				switch (r["idparam"].ToString())
				{
					case "DenominazioneUniversita":
						info.Denominazione = value;
						break;
					case "License_f":
						info.CodiceFiscale = value;
						break;
					case "License_Address1":
						info.Indirizzo1 = value;
						break;
					case "License_Address2":
						info.Indirizzo2 = value;
						break;
					case "License_Cap":
						info.CAP = value;
						break;
					case "License_Location":
						info.LocalitÃƒÆ’Ã‚Â  = value;
						break;
					case "License_Country":
						info.Provincia = value;
						break;
				}
			}

			return info;
		}


		/// <summary>
		/// ottiene l'avviso di pagamento
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="iuv"></param>
		/// <param name="pConf"></param>
		/// <param name="error"></param>
		/// <returns></returns>
		public static AvvisoPagamento ottieniAvvisoPagamento(DataAccess conn, string iuv,
			out string error)
		{
			var pConf = getPartnerConfigForIuv(conn, iuv);
			if (pConf == null)
			{
				error = "Partner tecnologico non configurato";
				return null;
			}

			try
			{
				switch (pConf.Code)
				{
					case BSONDRIO: return ottieniAvvisoBancaSondrio(conn, iuv, out error); //prevede l'invio indipendente della tassonomia
																							 //Nota: manca questa parte, cmq l'avviso dovrebbe averlo giÃƒÆ’Ã‚Â  mandato govPay quindi non serve
																							 //case "cineca": ottieniCertificatoGovPay(conn,iuv,pConf); break;
					case INTESASP: return ottieniAvvisoIntesaSanPaolo(conn, iuv, pConf, out error);//distingue per servizio
																									 //distingue per servizio MA non c'ÃƒÆ’Ã‚Â¨ una funzione per scaricare l'avviso, quindi da questo punto di vista ÃƒÆ’Ã‚Â¨ come se non distinguesse
					case UNICREDIT: return ottieniAvvisoUnicredit(conn, iuv, pConf, out error);
					
					case UBIBANCA: return ottieniAvvisoUnicredit(conn, iuv, pConf, out error);
					
					case VALTELLINESE: return ottieniAvvisoUnicredit(conn, iuv, pConf, out error);
					
					case GOMP:
						{
							error = "Partner tecnologico non supporta lo scarico dell'avviso di pagamento:" + pConf.Code;
							return null;
						}
					
					case CINECA_CREDITI: return ottieniAvvisoUnicredit(conn, iuv, pConf, out error);//prevede l'invio indipendente della tassonomia
				}

				error = "Partner tecnologico sconosciuto:" + pConf.Code;
			}
			catch (Exception ee)
			{
				error = ee.ToString();
			}

			return null;
		}

		/// <summary>
		/// Restituisce la stringa formattata per il campo "Destinatario".
		/// </summary>
		/// <param name="debitore">Informazioni sul debitore.</param>
		private static string getDestinatario(DataRow debitore)
		{
			var infoDestinatario = string.Empty;
			if (debitore["anagrafica"] != DBNull.Value) infoDestinatario = debitore["anagrafica"].ToString();
			if (debitore["indirizzo"] != DBNull.Value) infoDestinatario += "\n" + debitore["indirizzo"];
			if (debitore["cap"] != DBNull.Value) infoDestinatario += "\n" + debitore["cap"];
			if (debitore["citta"] != DBNull.Value) infoDestinatario += " " + debitore["citta"];
			if (debitore["provincia"] != DBNull.Value) infoDestinatario += "(" + debitore["provincia"] + ")";
			return infoDestinatario;
		}


		/// <summary>
		/// Restituisce la stringa formattata per il campo "Ente".
		/// </summary>
		/// <param name="ente">Informazioni sull'ente.</param>
		public static string getEnteCreditore(InformazioniEnteGenerico ente)
		{
			var indirizzo = string.Empty;
			if (!string.IsNullOrEmpty(ente.Indirizzo1)) indirizzo = ente.Indirizzo1;
			if (!string.IsNullOrEmpty(ente.Indirizzo2)) indirizzo += "\n" + ente.Indirizzo2;

			var stringaEnte = string.Empty;
			if (!string.IsNullOrEmpty(ente.Denominazione)) stringaEnte = ente.Denominazione;
			if (!string.IsNullOrEmpty(indirizzo)) stringaEnte += "\n" + indirizzo;
			if (!string.IsNullOrEmpty(ente.CAP)) stringaEnte += "\n" + ente.CAP;
			if (!string.IsNullOrEmpty(ente.LocalitÃƒÆ’Ã‚Â )) stringaEnte += " - " + ente.LocalitÃƒÆ’Ã‚Â ;
			if (!string.IsNullOrEmpty(ente.Provincia)) stringaEnte += "(" + ente.Provincia + ")";
			if (!string.IsNullOrEmpty(ente.CodiceFiscale)) stringaEnte += "\n" + "CF:" + ente.CodiceFiscale;

			return stringaEnte;

		}

		/// <summary>
		/// Restituisce la stringa formattata per il campo "Debitore".
		/// </summary>
		/// <param name="debitore">Informazioni sul debitore.</param>
		public static string GetDebitore(DataRow debitore)
		{
			// ReSharper disable once UseStringInterpolation   for increased readability
			return string.Format("{0}\n{1}\n{2}  {3} {4}\nC.F. {5}",
				debitore["anagrafica"],
				debitore["indirizzo"],
				debitore["cap"],
				debitore["citta"],
				debitore["provincia"],
				debitore["codice"]);
		}


		private static string getInfoDebitore(DataRow debitore)
		{
			var infoDebitore = string.Empty;
			if (debitore["anagrafica"] != DBNull.Value) infoDebitore = debitore["anagrafica"].ToString();
			if (debitore["indirizzo"] != DBNull.Value) infoDebitore += "\n" + debitore["indirizzo"];
			if (debitore["cap"] != DBNull.Value) infoDebitore += "\n" + debitore["cap"];
			if (debitore["citta"] != DBNull.Value) infoDebitore += " " + debitore["citta"];
			if (debitore["provincia"] != DBNull.Value) infoDebitore += "(" + debitore["provincia"] + ")";
			if (debitore["codice"] != DBNull.Value) infoDebitore += "\n" + "CF:" + debitore["codice"];
			return infoDebitore;
		}

		private static string getTipologiaServizio(DataAccess conn)
		{
			var tipologiaServizio = string.Empty;
			object tipologiaServizioObj = conn.DO_READ_VALUE("config_pagopa", null, "tipologiaservizio");

			if ((tipologiaServizioObj != DBNull.Value) && (tipologiaServizioObj != null))
			{
				tipologiaServizio = tipologiaServizioObj.ToString();
			}

			return tipologiaServizio;
		}

		private static string getCodiceSia(DataAccess conn)
		{
			string codiceSia = string.Empty;
			object codiceSiaObj = conn.DO_READ_VALUE("config_pagopa", null, "codicesia");

			if ((codiceSiaObj != DBNull.Value) && (codiceSiaObj != null))
			{

				codiceSia = codiceSiaObj.ToString();
			}

			return codiceSia;
		}

		private static string getNomeDebitore(DataAccess conn, object idreg)
		{
			var qhs = conn.GetQueryHelper();
			var qhc = new CQueryHelper();
			string nome = string.Empty;
			object nomeObj = conn.DO_READ_VALUE("registry", qhs.CmpEq("idreg", idreg), "forename");

			if ((nomeObj != DBNull.Value) && (nomeObj != null))
			{
				nome = nomeObj.ToString();
			}

			return nome;
		}

		private static string getCognomeDebitore(DataAccess conn, object idreg)
		{
			var qhs = conn.GetQueryHelper();
			var qhc = new CQueryHelper();
			string cognome = string.Empty;
			object cognomeObj = conn.DO_READ_VALUE("registry", qhs.CmpEq("idreg", idreg), "surname");

			if ((cognomeObj != DBNull.Value) && (cognomeObj != null))
			{
				cognome = cognomeObj.ToString();
			}

			return cognome;
		}

		private static string getCodiceFiscaleDebitore(DataAccess conn, object idreg)
		{
			// Connessione al DB
			var qhs = conn.GetQueryHelper();
			var qhc = new CQueryHelper();
			string cf = string.Empty;
			object cfObj = conn.DO_READ_VALUE("registry", qhs.CmpEq("idreg", idreg), "cf");

			if ((cfObj != DBNull.Value) && (cfObj != null))
			{
				cf = cfObj.ToString();
			}

			return cf;
		}

		public static string getUrlSitoIstituzionale(DataAccess conn)
		{
			var urlSitoIstituzionale = string.Empty;
			var urlSitoIstituzionaleObj = conn.DO_READ_VALUE("config_pagopa", null, "urlsitoistituzionale");

			if ((urlSitoIstituzionaleObj != DBNull.Value) && (urlSitoIstituzionaleObj != null))
			{
				urlSitoIstituzionale = urlSitoIstituzionaleObj.ToString();
			}

			return urlSitoIstituzionale;
		}

		private static string getUrlServizioPagamento(DataAccess conn)
		{
			var urlServizioPagamento = string.Empty;
			var urlServizioPagamentoObj = conn.DO_READ_VALUE("config_pagopa", null, "urlserviziopagamento");

			if ((urlServizioPagamentoObj != DBNull.Value) && (urlServizioPagamentoObj != null))
			{
				urlServizioPagamento = urlServizioPagamentoObj.ToString();
			}

			return urlServizioPagamento;
		}

		private static string GetInfoDettCredito(DataAccess conn, string iuv)
		{
			string defvalue = "AVVISO DI PAGAMENTO";
			QueryHelper qhs = conn.GetQueryHelper();
			var filter = qhs.CmpEq("iuv", iuv);
			var detCrediti = conn.RUN_SELECT("flussocreditidetail", "description", null, filter, null, false);
			if (detCrediti == null)
			{
				return defvalue;
			}

			char[] blank = { ' ' };
			string val = "";
			foreach (DataRow dr in detCrediti.Rows)
			{
				val += dr["description"].ToString().TrimEnd(blank) + ";";
			}

			if (detCrediti.Rows.Count == 1)
			{
				val = val.Substring(0, val.Length - 1);
			}

			if (val.Length > 55)
				val = val.Substring(0, 55);

			return val;
		}

		private static AvvisoPagamento ottieniAvvisoUnicredit(DataAccess conn, string iuv, PartnerConfig pConf,
			out string error)
		{
			if (string.IsNullOrEmpty(iuv))
			{
				error = "IUV non presente";
				return null;
			}

			var d = conn.CallSP("exp_posizionidebitorie_iuv", new object[] { iuv });
			if (d == null || d.Tables.Count == 0 || d.Tables[0].Rows.Count == 0)
			{
				error = "IUV non trovato";
				return null;
			}

			// per ogni IUV accorpo le eventuali disposizioni singole in un'unica disposizione avente importo totale

			DataTable t_ungrouped = d.Tables[0];
			DataTable t_grouped = CalcRowGrouped(t_ungrouped);

			var r = t_grouped.Rows[0];
			var idDisposizione = r["iduniqueformcode"].ToString();
			var codiceAvviso = r["codiceavviso"].ToString();
			//Legge il doc
			string modelloPdf = "Layout Avviso AGID 140717 - A.pdf";

			DateTime dt1 = DateTime.Parse("01/12/2018");
			DateTime dt2 = DateTime.Now;

			if (dt2.Date >= dt1.Date)
			{
				modelloPdf = "AvvisoPagamentoAGID_Dic2018wf.pdf";
			}

			var enteGen = getInformazioniEnte(conn, out error);

			var modello =
				new UnicreditService.Bollettino(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, modelloPdf));

			if (error != null) return null;
			var ente = getEnteCreditore(enteGen);
			var destinatario = getDestinatario(r); //GetDestinatario(debitore)

			var tipologiaServizio = getTipologiaServizio(conn);
			var codiceSia = getCodiceSia(conn);
			var urlSitoIstituzionale = getUrlSitoIstituzionale(conn);
			var urlServizioPagamento = getUrlServizioPagamento(conn);
			var debitore = getInfoDebitore(r);

			string Cf_Destinatario = (r["codice"] != DBNull.Value) ? r["codice"].ToString() : "";
			string Nome_Cognome_Destinatario = (r["anagrafica"] != DBNull.Value) ? r["anagrafica"].ToString() : "";
			string Indirizzo_Destinatario = (r["indirizzo"] != DBNull.Value) ? r["indirizzo"].ToString() : "";
			string Settore_Ente = ""; //TODO vedere da dove prendere. Dipartimento ? -> da flussocrediti nuovo campo

			byte[] pdfBytes = null;

			if (modelloPdf == "Layout Avviso AGID 140717 - A.pdf")
			{
				pdfBytes = modello.Genera(ente,
					enteGen.Denominazione, enteGen.Indirizzo1, enteGen.CAP, enteGen.LocalitÃƒÆ’Ã‚Â , enteGen.Provincia,
					enteGen.CodiceFiscale,
					debitore,
					codiceAvviso, codiceSia, tipologiaServizio, urlSitoIstituzionale, urlServizioPagamento,
					idDisposizione,
					(decimal)r["importo"], noNullDate(r["scadenza"], DateTime.MaxValue), iuv, r["causale"].ToString(),
					enteGen.Logo, r["barcodevalue"].ToString(), r["qrcodevalue"].ToString(),
					out error);
			}
			else
			{
				string oggPag = GetInfoDettCredito(conn, iuv);
				pdfBytes = modello.generaBollettino_versione_2018(maxLen(oggPag, 60), enteGen.CodiceFiscale,
					Cf_Destinatario, enteGen.Denominazione, Settore_Ente, ente, Nome_Cognome_Destinatario,
					Indirizzo_Destinatario,
					"unica soluzione", noNullDate(r["scadenza"], DateTime.MaxValue), (decimal)r["importo"],
					"del tuo Ente Creditore", maxLen(oggPag, 50), codiceSia, codiceAvviso,
					enteGen.Logo, r["qrcodevalue"].ToString(), out error
				);
			}



			return new AvvisoPagamento()
			{
				pdf = pdfBytes,
				debitore = r["anagrafica"].ToString(),
				email = firstEmail(r["email"].ToString()),
				ente = enteGen.Denominazione,
				iuv = iuv
			};
		}

		public static string firstEmail(string email)
		{
			if (email == "") return null;
			if (string.IsNullOrEmpty(email)) return email;
			if (!email.Contains((";"))) return email.Trim();
			return email.Split(';')[0].Trim();
		}

		//Mai usato 
		private static AvvisoPagamento ottieniAvvisoUbiBanca(DataAccess conn, string iuv, PartnerConfig pConf,
			out string error)
		{
			if (string.IsNullOrEmpty(iuv))
			{
				error = "IUV non presente";
				return null;
			}

			DataSet d = conn.CallSP("exp_posizionidebitorie_iuv", new object[] { iuv });
			if (d == null || d.Tables.Count == 0 || d.Tables[0].Rows.Count == 0)
			{
				error = "IUV non trovato";
				return null;
			}

			DataRow r = d.Tables[0].Rows[0];
			string idDisposizione = r["iduniqueformcode"].ToString();
			string codiceAvviso = r["codiceavviso"].ToString();
			//Legge il doc
			string modelloPdf = "Layout Avviso AGID 140717 - A.pdf";
			DateTime dt1 = DateTime.Parse("01/12/2018");
			DateTime dt2 = DateTime.Now;

			if (dt2.Date >= dt1.Date)
			{
				modelloPdf = "AvvisoPagamentoAGID_Dic2018wf.pdf";
			}

			var enteGen = getInformazioniEnte(conn, out error);
			var modello =
				new UnicreditService.Bollettino(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, modelloPdf));

			if (error != null) return null;
			string ente = getEnteCreditore(enteGen);

			string tipologiaServizio = getTipologiaServizio(conn);
			string codiceSia = getCodiceSia(conn);
			string urlSitoIstituzionale = getUrlSitoIstituzionale(conn);
			string urlServizioPagamento = getUrlServizioPagamento(conn);
			string debitore = getInfoDebitore(r);

			string Cf_Destinatario = (r["codice"] != DBNull.Value) ? r["codice"].ToString() : "";
			string Nome_Cognome_Destinatario = (r["anagrafica"] != DBNull.Value) ? r["anagrafica"].ToString() : "";
			string Indirizzo_Destinatario = (r["indirizzo"] != DBNull.Value) ? r["indirizzo"].ToString() : "";
			string Settore_Ente = ""; //TODO vedere da dove prendere. Dipartimento ? -> da flussocrediti nuovo campo

			byte[] pdfBytes = null;

			if (modelloPdf == "Layout Avviso AGID 140717 - A.pdf")
			{
				pdfBytes = modello.Genera(ente,
					enteGen.Denominazione, enteGen.Indirizzo1, enteGen.CAP, enteGen.LocalitÃƒÆ’Ã‚Â , enteGen.Provincia,
					enteGen.CodiceFiscale,
					debitore,
					codiceAvviso, codiceSia, tipologiaServizio, urlSitoIstituzionale, urlServizioPagamento,
					idDisposizione,
					(decimal)r["importo"], noNullDate(r["scadenza"], DateTime.MaxValue), iuv, r["causale"].ToString(),
					enteGen.Logo, r["barcodevalue"].ToString(), r["qrcodevalue"].ToString(),
					out error);
			}
			else
			{
				pdfBytes = modello.generaBollettino_versione_2018("AVVISO DI PAGAMENTO", enteGen.CodiceFiscale,
					Cf_Destinatario, enteGen.Denominazione, Settore_Ente, ente, Nome_Cognome_Destinatario,
					Indirizzo_Destinatario,
					"unica soluzione", noNullDate(r["scadenza"], DateTime.MaxValue), (decimal)r["importo"],
					enteGen.Denominazione, "Avviso di Pagamento", codiceSia, codiceAvviso,
					enteGen.Logo, r["qrcodevalue"].ToString(), out error
				);
			}

			if (error != null)
			{
				return null;
			}

			return new AvvisoPagamento()
			{
				pdf = pdfBytes,
				debitore = r["anagrafica"].ToString(),
				email = firstEmail(r["email"].ToString()),
				ente = enteGen.Denominazione,
				iuv = iuv
			};
		}

		private static AvvisoPagamento ottieniAvvisoIntesaSanPaolo(DataAccess conn, string iuv, PartnerConfig pConf,
			out string error)
		{
			if (string.IsNullOrEmpty(iuv))
			{
				error = "IUV non presente";
				return null;
			}

			var d = conn.CallSP("exp_posizionidebitorie_iuv", new object[] { iuv });
			if (d == null || d.Tables.Count == 0 || d.Tables[0].Rows.Count == 0)
			{
				error = "IUV non trovato";
				return null;
			}

			var r = d.Tables[0].Rows[0];
			var enteGen = getInformazioniEnte(conn, out error);
			if (error != null) return null;
			var ente = getEnteCreditore(enteGen);
			var destinatario = getDestinatario(r); //GetDestinatario(debitore)

			var identificativoDominio = pConf.Config[0]; // Parametro fornito da Intesa:     80005570561
			var identificativoBu = pConf.Config[1]; // Parametro fornito da Intesa:     RE0009
			var identificativoServizio =
				pConf.Config[2]; // Parametro fornito da Intesa (per ambiente di test utilizzare DEPOSITOCAUZIONALE)

			var user = pConf.Config.Length > 3 ? pConf.Config[3] : null;
			var password = pConf.Config.Length > 4 ? pConf.Config[4] : null;
			string url = null;
			if (pConf.Config.Length > 5)
			{
				url = pConf.Config[5];
			}
			//In Intesa S. Paolo non serve il codice avviso perchÃƒÆ’Ã‚Â¨ l'avviso ÃƒÆ’Ã‚Â¨ fornito giÃƒÆ’Ã‚Â  compilato dalla banca
			//  e comunque non ÃƒÆ’Ã‚Â¨ fornito da Intesa S.Paolo
			//string codiceAvviso = r["codiceavviso"].ToString();
			//Se il credito ÃƒÆ’Ã‚Â¨ di altro servizio restituisce null
			if (d.Tables[0].Columns.Contains("codice_servizio"))
			{
				if (r["codice_servizio"] != DBNull.Value)
				{
					if (pConf.codice_servizio.ToLowerInvariant() != r["codice_servizio"].ToString().ToLowerInvariant()) return null;
				}
				else
				{
					if (pConf.codice_servizio != null) return null;
				}
			}

			if (!checkCertificatiBancaIntesa(identificativoServizio == "DEPOSITOCAUZIONALE"))
			{
				error = "Impossibile installare i certificati di banca intesa";
				return null;
			}

			var servizio =
				new IntesaSanPaolo.EServizio().Create(user, password, url,
					identificativoServizio == "DEPOSITOCAUZIONALE");

			var body = new IntesaSanPaolo.pdpRichiediAvvisoBody(identificativoDominio, identificativoBu, iuv);
			var request = new IntesaSanPaolo.pdpRichiediAvviso(body);

			var response = servizio.pdpRichiediAvviso(request);
			if (response?.Body == null)
			{
				error = "Il server ha restituito una risposta non valida.";
				return null;
			}

			var result = response.Body.Result;
			if (!result.esitoOperazione.Equals("OK"))
			{
				// ReSharper disable once UseStringInterpolation  for increased readability
				error = string.Format("Il server ha restituito il codice di errore '{0}'\n\r{1}",
					result.codiceErrore
					, Encoding.ASCII.GetString(response.Body.pdpRichiediAvvisoResult.param));
				return null;
			}


			// Attiva la Richiesta di Pagamento Telematico RPT solo se si ÃƒÆ’Ã‚Â¨ in possesso dello IUV
			if (!string.IsNullOrEmpty(iuv))
			{
				var datiPagamentoInAttesa =
					new ct0000000027_datiPagamentoInAttesa { identificativoUnivocoVersamento = iuv };
				var datiAttivaRpt = new ct0000000027_pdpAttivaRpt()
				{
					datiPagamentoInAttesa = datiPagamentoInAttesa,
					callbackURL = "http://www.temposrl.com"
				};

				var bodyAttivazione =
					new IntesaSanPaolo.pdpAttivaRptBody(identificativoDominio, identificativoBu, datiAttivaRpt);
				var requestAttivazione = new IntesaSanPaolo.pdpAttivaRpt(bodyAttivazione);

				var responseAttivazione = servizio.pdpAttivaRpt(requestAttivazione); // Chiamata
				if (responseAttivazione?.Body == null)
				{
					error = "IntesaSanPaolo.pdpAttivaRptBody: Il server ha restituito una risposta non valida.";
				}
				else
				{
					var resultAttivazione = responseAttivazione.Body.Result;
					if (resultAttivazione.esitoOperazione.Equals("OK"))
					{
						System.Diagnostics.Process.Start(resultAttivazione.datiRestituiti.redirectURL);

					}
					else
					{
						error =
							$"Il server ha restituito il codice di errore '{resultAttivazione.codiceErrore}'\n\r {Encoding.ASCII.GetString(responseAttivazione.Body.pdpAttivaRptResult.param)}";
					}
				}
			}

			return new AvvisoPagamento()
			{
				pdf = Convert.FromBase64String(result.datiRestituiti.pdfFile),
				debitore = destinatario,
				email = firstEmail(r["email"].ToString()),
				ente = enteGen.Denominazione,
				iuv = iuv
			};

		}



		private static AvvisoPagamento ottieniAvvisoBancaSondrio(DataAccess conn, string iuv, out string error)
		{

			var d = conn.CallSP("exp_posizionidebitorie_iuv", new object[] { iuv });
			if (d == null || d.Tables.Count == 0 || d.Tables[0].Rows.Count == 0)
			{
				error = "IUV non trovato";
				return null;
			}

			var r = d.Tables[0].Rows[0];
			if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BPS_pagoPA.pdf")))
			{
				error = "Il file BPS_pagoPA.pdf non ÃƒÆ’Ã‚Â¨ presente nella cartella di esecuzione del programma.";
				return null;
			}

			var modello =
				new BancaSondrio.Bollettino(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BPS_pagoPA.pdf"));

			var enteGen = getInformazioniEnte(conn, out error);
			if (error != null)
			{
				error = "(getInformazioniEnte) - " + error;
				return null;
			}

			var ente = getEnteCreditore(enteGen);
			var destinatario = getDestinatario(r); //GetDestinatario(debitore)

			var codiceAvviso = r["codiceavviso"].ToString();

			// Genera l'avviso di pagamento analogico
			string codiceSia = getCodiceSia(conn);
			var debitore = getInfoDebitore(r); // GetDebitore(debitore);
			var pdfBytes = modello.Genera(ente, destinatario, iuv, r["causale"].ToString(), r["note"].ToString(),
				codiceAvviso, codiceSia,
				enteGen.CodiceFiscale, (decimal)r["importo"], noNullDate(r["scadenza"], DateTime.MaxValue),
				enteGen.Denominazione, enteGen.Logo, r["barcodevalue"].ToString(), r["qrcodevalue"].ToString(),
				debitore, r["idreg"].ToString(),
				out error);
			if (error != null)
			{
				return null;
			}

			return new AvvisoPagamento()
			{
				pdf = pdfBytes,
				debitore = destinatario,
				email = firstEmail(r["email"].ToString()),
				ente = enteGen.Denominazione,
				iuv = iuv
			};
		}

		public class PartnerConfig
		{
			public string Code;
			public string[] Config;
			public string codice_servizio;
			public bool crediti;
			public bool incassi;
			public bool attivo;
			public string codicetassonomia;
		}

		public static List<PartnerConfig> getListaPartnerConfig(DataAccess conn)
		{
			List<PartnerConfig> res = new List<PartnerConfig>();
			var qhs = conn.GetQueryHelper();
			var tPartnerConfig = conn.RUN_SELECT("partner_config", "*", null, qhs.CmpEq("attivo", "S"), null, false);
			if (tPartnerConfig == null || tPartnerConfig.Rows.Count == 0)
			{
				return null;
			}

			foreach (DataRow r in tPartnerConfig.Rows)
			{
				string code = r["code"] as string;
				code = code.Split('|')[0];
				var partner = new PartnerConfig();
				partner.Code = code;
				partner.Config = r["config"].ToString().Split('|');
				if (tPartnerConfig.Columns.Contains("codice_servizio"))
				{
					partner.codice_servizio = r["codice_servizio"] == DBNull.Value ? null : r["codice_servizio"].ToString();
				}
				if (tPartnerConfig.Columns.Contains("crediti"))
				{
					partner.crediti = r["crediti"] == DBNull.Value || r["crediti"].ToString().ToUpperInvariant() == "S";
				}
				if (tPartnerConfig.Columns.Contains("incassi"))
				{
					partner.incassi = r["incassi"] == DBNull.Value || r["incassi"].ToString().ToUpperInvariant() == "S";
				}
				if (tPartnerConfig.Columns.Contains("attivo"))
				{
					partner.attivo = r["attivo"] == DBNull.Value || r["attivo"].ToString().ToUpperInvariant() == "S";
				}
				if (tPartnerConfig.Columns.Contains("codicetassonomia") && (r["codicetassonomia"] != DBNull.Value))
				{
					partner.codicetassonomia = r["codicetassonomia"] == DBNull.Value ? null : r["codicetassonomia"].ToString();
				}
				res.Add(partner);
			}

			return res;
		}

		public static PartnerConfig getPartnerConfig(DataAccess conn)
		{
			List<PartnerConfig> res = new List<PartnerConfig>();
			var tPartnerConfig = conn.RUN_SELECT("partner_config", "*", null, null, "1", false);
			if (tPartnerConfig == null || tPartnerConfig.Rows.Count == 0)
			{
				return null;
			}

			DataRow r = tPartnerConfig.Rows[0];
			return new PartnerConfig { Code = r["code"] as string, Config = r["config"].ToString().Split('|') };

		}

		public class OpiSiopeplusConfig
		{
			public string Code;
			public string[] Config;
			public string cert_filename;
			public string cert_pwd;
			public string cert_thumbprint;
		}

		public static OpiSiopeplusConfig getOPISiopePlusConfig(DataAccess conn)
		{
			var tOpiSiopeplusConfig = conn.RUN_SELECT("opisiopeplus_config", "*", null, null, "1", false);
			if (tOpiSiopeplusConfig == null || tOpiSiopeplusConfig.Rows.Count == 0)
			{
				return null;
			}

			var r = tOpiSiopeplusConfig.Rows[0];
			return new OpiSiopeplusConfig
			{
				Code = r["code"] as string,
				Config = r["config"].ToString().Split('|'),
				cert_filename = r["cert_filename"].ToString(),
				cert_pwd = r["cert_password"].ToString(),
				cert_thumbprint = r["cert_thumbprint"].ToString()
			};
		}

		/// <summary>
		/// Stabilisce se ÃƒÆ’Ã‚Â¨ possibile attivare un credito e procedere direttamente al pagamento (modello 1)
		/// </summary>
		/// <param name="conn"></param>
		/// <returns>null o elenco errori</returns>
		public static bool isAttivaCreditoSupported(DataAccess conn)
		{
			var partners = getListaPartnerConfig(conn);
			foreach (var partner in partners)
			{
				switch (partner.Code)
				{
					case BSONDRIO: return true; //errori = AttivaCreditoBancaSondrio(partner,iuv,out url); break; 
												  //case "cineca": errori = AttivaCreditoGovPay(partner,iuv,out url); break;
					case INTESASP: return true;

					//case UNICREDIT: errori = AttivaCreditoUnicredit(partner,iuv,out url); break;
					//
					case VALTELLINESE: return true;

					//case CINECA_CREDITI: return true

					case UBIBANCA: return true;
				}
			}

			return false;
		}

		private static string FromListToString(List<string> errorList)
		{
			string errori = null;
			if (errorList != null && errorList.Count > 0)
			{
				var sb = new StringBuilder();
				errorList.ForEach(e => sb.AppendLine(e));
				errori = sb.ToString();
			}

			return errori;
		}

		/// <summary>
		/// Attiva il credito associato allo IUV 
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="iuv"></param>
		/// <param name="callBack">Url a cui passare il controllo alla fine dell'operazione di pagamento</param>
		/// <param name="url">url a cui effettuare la redirect</param>
		/// <returns>null o elenco errori</returns>
		public static string AttivaCredito(DataAccess conn, string iuv, string callBack, out string url)
		{
			url = null;

			if (string.IsNullOrEmpty(iuv))
			{
				return "IUV non specificato";
			}
			//TODO:  filtrare per partner tecnologico, che dovrebbe essere lo stesso a cui ÃƒÆ’Ã‚Â¨ stato inviato il credito

			var partner = getPartnerConfigForIuv(conn, iuv);
			
			string errori = null;
			
			switch (partner.Code)
			{
				case BSONDRIO:
					{
						var errorList = attivaCreditoBancaSondrio(conn, partner, iuv, callBack, out url);
						errori = FromListToString(errorList);
						return errori;
					}

				//case CINECA: errori = AttivaCreditoGovPay(partner,iuv,out url); break;
				
				case INTESASP:
					errori = attivaCreditoIntesaSanPaolo(partner, iuv, callBack, out url);
					return errori;
				
				case VALTELLINESE:
					{
						var errorList = attivaCreditoVatellinese(conn, partner, iuv, callBack, out url);
						errori = FromListToString(errorList);
						return errori;
					}
				
				case UBIBANCA:
					errori = attivaCreditoIntesaSanPaolo(partner, iuv, callBack, out url);
					return errori;
				
				case UNICREDIT:
					{
						var errorList = attivaCreditoUnicredit(conn, partner, iuv, callBack, out url);
						errori = FromListToString(errorList);
						break;
					}

			}


			return "Banca non supportata";

		}

		private static string attivaCreditoIntesaSanPaolo(PartnerConfig pConf,
			string iuv, string callBack, out string url)
		{
			url = null;
			var identificativoDominio = pConf.Config[0]; // Parametro fornito da Intesa:     80005570561
			var identificativoBu = pConf.Config[1]; // Parametro fornito da Intesa:     RE0009
			var user = pConf.Config.Length > 3 ? pConf.Config[3] : null;
			var password = pConf.Config.Length > 4 ? pConf.Config[4] : null;
			// Attiva la Richiesta di Pagamento Telematico RPT solo se si ÃƒÆ’Ã‚Â¨ in possesso dello IUV
			string urlServizio = null;
			if (pConf.Config.Length > 5)
			{
				urlServizio = pConf.Config[5];
			}

			var datiPagamentoInAttesa =
				new InfoGroup.ct0000000027_datiPagamentoInAttesa
				{
					identificativoUnivocoVersamento = iuv
				};
			var datiAttivaRpt = new InfoGroup.ct0000000027_pdpAttivaRpt
			{
				datiPagamentoInAttesa = datiPagamentoInAttesa,
				callbackURL = callBack ?? "http://www.temposrl.com"
			};

			var bodyAttivazione =
				new IntesaSanPaolo.pdpAttivaRptBody(identificativoDominio, identificativoBu, datiAttivaRpt);
			var requestAttivazione = new IntesaSanPaolo.pdpAttivaRpt(bodyAttivazione);

			var servizio = new IntesaSanPaolo.EServizio().Create(user, password, urlServizio);

			var responseAttivazione = servizio.pdpAttivaRpt(requestAttivazione); // Chiamata
			if (responseAttivazione?.Body == null)
			{
				return "IntesaSanPaolo.pdpAttivaRptBody: Il server ha restituito una risposta non valida.";
			}
			else
			{
				var resultAttivazione = responseAttivazione.Body.Result;
				if (resultAttivazione.esitoOperazione.Equals("OK"))
				{
					url = resultAttivazione.datiRestituiti.redirectURL;
				}
				else
				{
					return
						$"Il server ha restituito il codice di errore '{resultAttivazione.codiceErrore}'\n\r {Encoding.ASCII.GetString(responseAttivazione.Body.pdpAttivaRptResult.param)}";
				}
			}

			return null;
		}


		private static List<string> attivaCreditoVatellinese(DataAccess conn, PartnerConfig pConf,
			string iuv, string callBack, out string url)
		{

			var Errors = new List<string>();

			var esercizio = conn.GetEsercizio();
			var dataContabile = conn.GetDataContabile();
			var utente = pConf.Config[0]; // utente ambiente SOAP pc
			var password = pConf.Config[1]; // password ambiente SOAP
			string codiceAzienda = pConf.Config[2]; // codice azienda
			string urlSoap = pConf.Config[3]; // url ambiente SOAP
			string userRest = pConf.Config[4]; // utente ambiente REST
			string pwdRest = pConf.Config[5]; //password ambiente REST
			string urlRest = pConf.Config[6]; // url ambiente REST
			string codicepartitarioRest = pConf.Config[7]; // codice partitario ambiente REST

			// Parametri del servizio            (partnerconfig ha come   token il codice del partner ossia valyellinese in questo caso
			var identificativoDominio = ""; // Parametro fornito da Banca Credito Valtellinese: 
			if (pConf.Config.Length > 8) identificativoDominio = pConf.Config[8];
			// similmente a quanto avviene per attivaCreditEsistenteoValtellinese che non li valorizza evito errore se non presente   
			var identificativoBu = ""; // Parametro fornito da Banca Credito Valtellinese:      
			var identificativoServizio = ""; // Parametro fornito da Banca Credito Valtellinese  
			if (pConf.Config.Length > 9) identificativoBu = pConf.Config[9];
			if (pConf.Config.Length > 10) identificativoServizio = pConf.Config[10];


			url = "";

			var d = conn.CallSP("exp_posizionidebitorie_iuv", new object[] { iuv });
			if (d == null || d.Tables.Count == 0 || d.Tables[0].Rows.Count == 0)
			{
				Errors.Add($"IUV non trovato");
				return Errors;
			}

			string idRichiesta = new Guid().ToString();
			//Si logga al servizio di autenticazione AuthPA
			var autenticazioneService = Valtellinese.Servizio.CreateAuthPaSoap(utente, password, urlSoap);
			var ticketReq = new Valtellinese.WSLOGIN_REQUEST()
			{
				CODICE_AZIENDA =
					codiceAzienda, //codice assegnato alla Azienda Esercente da PmPay, fornito in fase di registrazione
				DATA_RICHIESTA = DateTime.Now.Date, //data e ora della data di richiesta
				ID_CLIENT = utente, //identificativo fornito in fase di registrazione Azienda Esercente da PmPay
				PWD_CLIENT = password, //password di accesso fornita in fase di registrazione Azienda Esercente da PmPay
				ID_RICHIESTA = idRichiesta //identificato univoco assegnato dal client alla specifica richiesta
			};

			var res = Valtellinese.Servizio.authGetTicket(autenticazioneService, ticketReq);
			if (!string.IsNullOrEmpty(res.CODICE_ERRORE))
			{ // WSLOGIN_RESPONSE
				Errors.Add($"Errore {res.CODICE_ERRORE}:{res.DESCRIZIONE_ERRORE} nell'ottenimento del token");
				return Errors;
			}

			string token = res.TOKEN;
			if (!string.IsNullOrEmpty(res.CODICE_ERRORE))
			{
				Errors.Add($"Errore generico nell'ottenimento del token di collegamento");
				return Errors;
			}

			var r = d.Tables[0].Rows[0];
			object idreg = r["idreg"];
			// Dopo aver ottenuto il token di sessione attiva il pagamento immediato per lo IUV in ingresso
			var headReq = new headerPagamento()
			{
				ID_CLIENT = ticketReq.ID_CLIENT,
				TOKEN = token,
				DATA_RICHIESTA = ticketReq.DATA_RICHIESTA,
				ID_RICHIESTA = ticketReq.ID_RICHIESTA,
				CODICE_AZIENDA = ticketReq.CODICE_AZIENDA,
				CODICE_FISCALE = getCodiceFiscaleDebitore(conn, idreg),
				TIPO_CLIENT =
					"PC", // PC, TABLET, SMARTPHONE, metto PC per ora,  da testare comunque sui vari dispositivi
				URL_OK = callBack ?? "http://www.temposrl.com",
				URL_KO = callBack ?? "http://www.temposrl.com",
				URL_CANCEL = callBack ?? "http://www.temposrl.com",
				URL_S2S = callBack ?? "http://www.temposrl.com",
			};



			var destinatario = getDestinatario(r); //GetDestinatario(debitore)


			var anagraficaPagamento = new anagraficaPagamento()
			{
				CAP = r["cap"].ToString(),
				CITTA = r["citta"].ToString(),
				ItemsElementName = r["tipo"].ToString() == "F" ? new ItemsChoiceType[] { ItemsChoiceType.COGNOME, ItemsChoiceType.NOME } :
							new ItemsChoiceType[] { ItemsChoiceType.DENOMINAZIONE },
				Items = r["tipo"].ToString() == "F" ? new string[] {maxLen(getCognomeDebitore(conn, idreg),70),
																	maxLen(getNomeDebitore(conn, idreg),70)} :
						new string[] { maxLen(r["anagrafica"].ToString(), 70) }
				,
				INDIRIZZO = r["indirizzo"].ToString(),
				PROVINCIA = r["provincia"].ToString(),
				MAIL = firstEmail(r["email"].ToString()),
			};
			string causale = cleanLineFeed(r["causale"].ToString());

			//string note = cleanHtmlFeed(r["note"].ToString());

			var pagamentoSingolo = new pagamento()
			{
				CAUSALE_PAGAMENTO = causale.ToString(),
				DATA_PAGAMENTO = noNullDate(dataContabile, DateTime.MaxValue),
				DATI_BOLLO = null,
				DIVISA = "EUR",
				IMPORTO_TOTALE = CfgFn.GetNoNullDecimal(r["importo"]),
				RIF_PRATICA = iuv,
				SERVIZIO_PAGAMENTO =
					identificativoServizio, // configurazione, occorre chiedere i dati alla banca di credito valtellinese
			};

			List<pagamento> elencopagamenti = new List<pagamento>();
			elencopagamenti.Add(pagamentoSingolo);
			var PagamentoRequest = new PAGAMENTO_REQUEST()
			{
				headerPagamento = headReq,
				anagraficaPagamento = anagraficaPagamento,
				pagamento = elencopagamenti,
			};
			string message = "";
			var pagamentoImmediatoService = Valtellinese.Servizio.CreatePayPa(utente, password, urlSoap);

			var result = Valtellinese.Servizio.PayPAPagamento(pagamentoImmediatoService, PagamentoRequest, out message);

			if (result == null)
			{

				Errors.Add($"{message}, attendere qualche istante e riprovare");
				return Errors;
			}

			url = result.URL_TO_CALL; // pagina del servizio di cassa con i dati per completare il pagamento
			return null;
		}

		private static List<string> attivaCreditEsistenteoValtellinese(DataAccess conn, PartnerConfig pConf,
			string iuv, string callBack, out string url)
		{

			var Errors = new List<string>();

			var esercizio = conn.GetEsercizio();
			var dataContabile = conn.GetDataContabile();

			var identificativoDominio = pConf.Config[0];
			var identificativoBu = pConf.Config[1];
			var identificativoServizio = "";

			string urlSoap = "https://service.pmpay.it/"; // url ambiente SOAP

			string codicepartitarioRest = "COD_SERV_STUDENTE"; // codice partitario ambiente REST
															   //// Parametri del servizio (utente/password/CODICE_AZIENDA/URL)
			var utente = pConf.Config[0];
			var password = pConf.Config[1];
			string codiceAzienda = pConf.Config[2];
			url = pConf.Config[3];
			url = "";

			var d = conn.CallSP("exp_posizionidebitorie_iuv", new object[] { iuv });
			if (d == null || d.Tables.Count == 0 || d.Tables[0].Rows.Count == 0)
			{
				Errors.Add($"IUV non trovato");
				return Errors;
			}

			string idRichiesta = new Guid().ToString();
			//Si logga al servizio di autenticazione AuthPA
			var autenticazioneService = Valtellinese.Servizio.CreateAuthPaSoap(utente, password, urlSoap);
			var ticketReq = new Valtellinese.WSLOGIN_REQUEST()
			{
				CODICE_AZIENDA =
					codiceAzienda, //codice assegnato alla Azienda Esercente da PmPay, fornito in fase di registrazione
				DATA_RICHIESTA = DateTime.Now.Date, //data e ora della data di richiesta
				ID_CLIENT = utente, //identificativo fornito in fase di registrazione Azienda Esercente da PmPay
				PWD_CLIENT = password, //password di accesso fornita in fase di registrazione Azienda Esercente da PmPay
				ID_RICHIESTA = idRichiesta //identificato univoco assegnato dal client alla specifica richiesta
			};

			var res = Valtellinese.Servizio.authGetTicket(autenticazioneService, ticketReq);
			if (!string.IsNullOrEmpty(res.CODICE_ERRORE))
			{ // WSLOGIN_RESPONSE
				Errors.Add($"Errore {res.CODICE_ERRORE}:{res.DESCRIZIONE_ERRORE} nell'ottenimento del token");
				return Errors;
			}

			string token = res.TOKEN;
			if (!string.IsNullOrEmpty(res.CODICE_ERRORE))
			{
				Errors.Add($"Errore generico nell'ottenimento del token di collegamento");
				return Errors;
			}

			var r = d.Tables[0].Rows[0];
			// Dopo aver ottenuto il token di sessione attiva il pagamento immediato per lo IUV in ingresso
			var headReq = new headerPagamentoEsistente()
			{
				ID_CLIENT = ticketReq.ID_CLIENT,
				TOKEN = token,
				DATA_RICHIESTA = ticketReq.DATA_RICHIESTA,
				ID_RICHIESTA = ticketReq.ID_RICHIESTA,
				CODICE_AZIENDA = ticketReq.CODICE_AZIENDA,
				CODICE_FISCALE = getCodiceFiscaleDebitore(conn, r["idreg"]),
				TIPO_CLIENT =
					"PC", // PC, TABLET, SMARTPHONE, metto PC per ora,  da testare comunque sui vari dispositivi
				URL_OK = callBack ?? "http://www.temposrl.com",
				URL_KO = callBack ?? "http://www.temposrl.com",
				URL_CANCEL = callBack ?? "http://www.temposrl.com",
				URL_S2S = callBack ?? "http://www.temposrl.com",
			};




			var destinatario = getDestinatario(r); //GetDestinatario(debitore)

			object idreg = r["idreg"];
			//var anagraficaPagamento = new anagraficaPagamento() {
			//    CAP = r["cap"].ToString(),
			//    CITTA = r["citta"].ToString(),
			//    COGNOME = getCognomeDebitore(conn, r["idreg"]),
			//    NOME = getNomeDebitore(conn, r["idreg"]),
			//    INDIRIZZO = r["indirizzo"].ToString(),
			//    PROVINCIA = r["provincia"].ToString(),
			//    MAIL = r["email"].ToString(),
			//};

			//var pagamentoSingolo = new pagamento() {
			//    CAUSALE_PAGAMENTO = r["causale"].ToString(),
			//    DATA_PAGAMENTO = noNullDate(dataContabile, DateTime.MaxValue),
			//    DATI_BOLLO = null,
			//    DIVISA = "EUR",
			//    IMPORTO_TOTALE = CfgFn.GetNoNullDecimal(r["importo"]),
			//    RIF_PRATICA = iuv,
			//    SERVIZIO_PAGAMENTO = identificativoServizio, // configurazione, occorre chiedere i dati alla banca di credito valtellinese
			//};
			//  identificativo della pratica gestito dal portale dellÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢Azienda Ente oppure IUV messo a disposizione dal servizio PMPay
			List<pagamentoEsistente> elencopagamenti = new List<pagamentoEsistente>();
			var pagamentoEsistente = new pagamentoEsistente()
			{
				ItemElementName = ItemChoiceType.RIF_PRATICA,
				Item = iuv
			};

			elencopagamenti.Add(pagamentoEsistente);
			var PagamentoRequest = new PAGAMENTOESISTENTE_REQUEST()
			{
				headerPagamento = headReq,
				pagamentoEsistente = new List<pagamentoEsistente>() { pagamentoEsistente }
			};

			string message = "";
			var pagamentoImmediatoService = Valtellinese.Servizio.CreatePayPa(utente, password, urlSoap);

			var result =
				Valtellinese.Servizio.PayPAPagamentoEsistente(pagamentoImmediatoService, PagamentoRequest, out message);

			if (result == null)
			{
				Errors.Add($"{message}, attendere qualche istante e riprovare");
				return Errors;
			}

			url = result.URL_TO_CALL; // pagina del servizio di cassa con i dati per completare il pagamento
			return null;
		}


		private static List<string> attivaCreditoUnicredit(DataAccess conn, PartnerConfig pConf,
			string iuv, string callBack, out string url)
		{
			url = "";
			var Errors = new List<string>();
			//utente soap/password soap/codice del servizio/aux digit/app code/url/gln/isfortest/urlSoap/userRest/pwdRest/urlRest/idEnte/idDominio

			if (pConf.Config.Length < 14)
			{
				Errors.Add(
					"Configurazione partner insufficiente  (utente soap/password soap/codice del servizio/aux digit/app code/url/gln/isfortest/urlSoap/userRest/pwdRest/urlRest/idEnte/idDominio)");
				return Errors;
			}

			var esercizio = conn.GetEsercizio();
			var dataContabile = conn.GetDataContabile();
			var utente = "**********"; // pConf.Config[0];   // utente ambiente SOAP pc
			var password = "**********"; //pConf.Config[1]; // password ambiente SOAP
											  //string codiceAzienda = "02008"; //pConf.Config[2]; // codice azienda
			string urlSoap = pConf.Config[8]; // url ambiente SOAP  "0000709"; 
			string userRest = pConf.Config[9];// "unicredit_consumer";// pConf.Config[4];  utente ambiente REST
			string pwdRest = pConf.Config[10]; //"a55ffcfa708cde6";// password ambiente REST
			string urlRest = pConf.Config[11]; // url ambiente REST

			var idEnte = pConf.Config[12]; //"4AAFDBCE9F2BC99A";
			var idDominio = pConf.Config[13]; // "02044190615";
											  // Parametri del servizio            (partnerconfig ha come   token il codice del partner ossia unicredit in questo caso
											  //var identificativoDominio = ""; // Parametro fornito da Banca Credito Unicredit: 
											  //if (pConf.Config.Length > 8) identificativoDominio = pConf.Config[8];

			//Ente	UNIVERSITA STUDI DELLA CAMPANIA L.VANVITELLI
			//Codice Fiscale (ID Nodo)	02044190615
			//Codice Ente BT	9004000
			//WebPayPA (paInviaCarrelloPosizioni)
			//User	**********
			//Password	**********




			var d = conn.CallSP("exp_posizionidebitorie_iuv", new object[] { iuv });
			if (d == null || d.Tables.Count == 0 || d.Tables[0].Rows.Count == 0)
			{
				Errors.Add($"IUV non trovato");
				return Errors;
			}

			var r = d.Tables[0].Rows[0];
			var destinatario = getDestinatario(r); //GetDestinatario(debitore)
			object idreg = r["idreg"];
			//Si logga al servizio REST  di autenticazione  ottenendo un TOKEN di sessione
			//string grant_type, string codiceIstituto, 
			//string codiceEnte, string idEnte, string idDominio, out string error, out string esito

			var grant_type = "password";
			var codiceIstituto = "02008";

			var codiceEnte = "9004000"; //codiceAzienda;
			string errore;
			var enteGen = getInformazioniEnte(conn, out errore);



			if (errore != null) return null;
			var ente = getEnteCreditore(enteGen);
			string error = "";
			string esito = "";
			UnicreditREST rClientRest = new UnicreditREST(urlRest, userRest, pwdRest);

			var access_token = rClientRest.GetToken(grant_type, codiceIstituto, codiceEnte, idEnte, idDominio,
				out error, out esito);
			if (access_token == null)
			{
				Errors.Add($"Errore nella ricezione token: {error}");
				return Errors;
			}
			var pagamentoImmediatoService = unicredit_b.Servizio.Create(utente, password, urlSoap);





			string causale = cleanLineFeed(r["causale"].ToString());


			var pagamentoSingolo = new unicredit_b.datiSingoloVersamentoListaType()
			{
				importoSingoloVersamento = CfgFn.GetNoNullDecimal(r["importo"]),
				causaleVersamento = causale.ToString(),
				commissioniCaricoPa = 0
			};

			unicredit_b.datiSingoloVersamentoListaType[] elencopagamenti =
				new unicredit_b.datiSingoloVersamentoListaType[1];
			elencopagamenti[0] = pagamentoSingolo;

			unicredit_b.paInviaCarrelloPosizioniListaType Posizione =
				new unicredit_b.paInviaCarrelloPosizioniListaType()
				{
					spontaneo = "N", // ? se ne parla nel documento ma non trovo il campo nella descrizione Ãƒâ€šÃ‚Â§WSDL
					identificativoBeneficiario = "02044190615", //enteGen.CodiceFiscale , // codice fiscale ente
					ccp = null, //alternativo a codice PA / codice Servizio
					codicePa = codiceEnte, //alternativo a ccp / codice Servizio
					codiceServizio = null, // alternativo a ccp / codicePa
					tipoIdPagatore = r["tipo"].ToString(),
					identificativoPagatore = r["codice"].ToString(),
					anagraficaPagatore = r["anagrafica"].ToString(),
					indirizzoPagatore = r["indirizzo"].ToString(),
					civicoPagatore = null,
					capPagatore = r["cap"].ToString(),
					localitaPagatore = r["citta"].ToString(),
					provinciaPagatore = r["provincia"].ToString(),
					codiceNazionePagatore = r["nazione"].ToString(),
					emailPagatore = firstEmail(r["email"].ToString()),
					dataScadenzaPagamento = r["scadenza"].ToString(),
					importoPagamento = CfgFn.GetNoNullDecimal(r["importo"]),
					tipoFirmaRicevuta =
						"0", /* Codice del tipo firma digitale a cui deve essere sottoposta la ricevuta di pagamento telematica.
                                            0 = Firma non richiesta
                                            1 = CaDes
                                            3 = XaDes
                                            4 = Elettronica avanzata
                                            */

					tipoRiferimentoCreditore = null,
					codiceRiferimentoCreditore = null,
					identificativoUnivocoVersamento = iuv,
					datiSingoloVersamento = elencopagamenti
				};
			unicredit_b.paInviaCarrelloPosizioniListaType[] CarrelloPosizioni =
				new unicredit_b.paInviaCarrelloPosizioniListaType[1];

			CarrelloPosizioni[0] = Posizione;

			var headReq = new unicredit_b.paInviaCarrelloPosizioniHeader()
			{
				user = utente, // SOAP
				password = password, //
				abiCode = codiceIstituto
			};
			
			unicredit_b.paInviaCarrelloPosizioniRequest request = new unicredit_b.paInviaCarrelloPosizioniRequest();
			request.paInviaCarrelloPosizioniHeader = headReq;
			request.paInviaCarrelloPosizioniRequest1 = CarrelloPosizioni;
			var response = pagamentoImmediatoService.paInviaCarrelloPosizioni(request);
			unicredit_b.paInviaCarrelloPosizioniOutputType
				output = new unicredit_b.paInviaCarrelloPosizioniOutputType();
			if (response.paInviaCarrelloPosizioniResponse != null)
			{
				output = response.paInviaCarrelloPosizioniResponse.paInviaCarrelloPosizioniOutput;
				if (output.esito == "OK")
					url = output.url; // pagina del servizio di cassa con i dati per completare il pagamento

				else
				{
					Errors.Add($"{output.descrizione}, attendere qualche istante e riprovare");
					return Errors;
				}
			}
			else
			{
				Errors.Add($"Non ÃƒÆ’Ã‚Â¨ possibile contattare la banca, attendere qualche istante e riprovare");
				return Errors;
			}

			return null;
		}

		public static List<PartnerConfig> getPartnerConfigForCrediti(DataAccess conn)
		{
			var partners = getListaPartnerConfig(conn).Where(x => x.attivo && x.crediti).ToList();
			return partners;
		}

		/// <summary>
		/// Ottiene il partner config da usare per un particolare iuv
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="iuv"></param>
		/// <returns></returns>
		public static PartnerConfig getPartnerConfigForIuv(DataAccess conn, string iuv)
		{
			var partners = getListaPartnerConfig(conn).Where(x => x.attivo && x.crediti).ToList();
			if (partners.Any(x => x.codicetassonomia != null))
			{//ÃƒÆ’Ã‚Â¨ necessario filtrare la tassonomia
				var crediti = conn.readTable("flussocreditidetail", q.eq("iuv", iuv) & q.isNotNull("codicetassonomia"),
					"codicetassonomia");
				if (crediti == null || crediti.Rows.Count == 0) return null;
				string codicetassonomia = crediti.Rows[0]["codicetassonomia"].ToString();
				return partners.Where(x => x.codicetassonomia == codicetassonomia).FirstOrDefault();
			}
			//Se i partner non vogliono la tassonomia non c'ÃƒÆ’Ã‚Â¨ bisogno di filtrarla
			return partners?.FirstOrDefault();
		}

		/// <summary>
		/// Ottiene il partner config da usare per una particolare tassonomia
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="codicetassonomia"></param>
		/// <returns></returns>
		public static PartnerConfig getPartnerConfigForTassonomia(DataAccess conn, string codicetassonomia)
		{
			var partners = getListaPartnerConfig(conn).Where(x => x.attivo && x.crediti).ToList();
			if (partners.Any(x => x.codicetassonomia != null))
			{
				var partner = partners.Where(x => x.codicetassonomia == codicetassonomia).FirstOrDefault();
				return partner;
			}
			if (codicetassonomia == null) return partners?.FirstOrDefault();
			return null;
		}

		/// <summary>
		/// Prende il primo codice tassonomia che trova nei dettagli flusso crediti
		/// </summary>
		/// <param name="d"></param>
		/// <returns></returns>
		public static string firstCodiceTassonomia(DataSet d)
		{
			return d.Tables["flussocreditidetail"].f_isNotNull("codicetassonomia").FirstOrDefault()?["codicetassonomia"].ToString();
		}


		/// <summary>
		/// Invia i crediti prendendo le tabella DS.flussocrediti e DS.flussocrediti_detail
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="DS"></param>
		/// <returns></returns>
		public static List<string> InviaCrediti(DataAccess conn, DataSet DS)
		{
			var partners = getPartnerConfigForCrediti(conn);
			if (partners == null) return new List<string>() { "Nessuna banca configurata supporta l'invio del credito" };

			bool filterTassonomia = partners.Any(x => x.codicetassonomia != null);
			string codicetassonomia = null;
			PartnerConfig partner = getPartnerConfigForTassonomia(conn, firstCodiceTassonomia(DS));
			if (filterTassonomia)
			{
				codicetassonomia = firstCodiceTassonomia(DS);
				partner = partners.Where(x => x.codicetassonomia == codicetassonomia).FirstOrDefault();
				if (partner == null)
				{
					return new List<string>() { $"Nessuna banca configurata supporta l'invio della tassonomia {codicetassonomia}" };
				}
			}
			else
			{
				partner = partners.FirstOrDefault();
				if (partner == null) return new List<string>() { "Nessuna banca configurata supporta l'invio del credito" };
			}


			List<string> errori = null;
			//partner.Code = "valtellinese";

			try
			{
				switch (partner.Code)
				{
					case BSONDRIO:
						return caricaPosizioniDebitorieBancaSondrio1_1(conn, DS, partner); //prevede l'invio indipendente della tassonomia
					case CINECA_CREDITI:
						return caricaPosizioniDebitorieGovPay(conn, DS, partner); //prevede l'invio indipendente della tassonomia
					case INTESASP:
						return caricaPosizioniDebitorieIntesaSanPaolo(conn, DS, partner);//distingue per servizio
					case UNICREDIT:
						return caricaPosizioniDebitorieUnicredit(conn, DS, partner);//distingue per servizio
					case UBIBANCA:
						return caricaPosizioniDebitorieUbiBanca(conn, DS, partner);
					case VALTELLINESE:
						return caricaPosizioniDebitorieValtellinese(conn, DS, partner); //prevede l'invio indipendente della tassonomia
				}
			}
			catch (Exception e)
			{
				errori = new List<string>() { QueryCreator.GetErrorString(e) };
			}

			return errori;
		}


		public static Stream[]
			LeggiGiornaledicassa(DataAccess conn, DateTime inizio, DateTime fine, out string errore)
		{
			return LeggiGiornaledicassa(conn, inizio, fine, false, out errore);
		}

		public static Stream[] LeggiGiornaledicassa(DataAccess conn, DateTime inizio, DateTime fine, bool salvaFile,
			out string errore)
		{
			errore = null;
			var rSiopeConfig = getOPISiopePlusConfig(conn);
			var esercizio = conn.GetEsercizio();
			var dataContabile = conn.GetDataContabile();
			// Parametri del servizio 
			string userRest = rSiopeConfig.Config[0]; // utente ambiente REST
			string pwdRest = rSiopeConfig.Config[1]; //password ambiente REST
			string codiceIpa = rSiopeConfig.Config[3]; //tIPA.Rows[0]["ipa_fe"].ToString();
			string urlRestJournal = rSiopeConfig.Config[4]; // url ambiente REST

			// Connessione al DB

			var qhs = conn.GetQueryHelper();
			var qhc = new CQueryHelper();

			SiopePlusREST rClient = new SiopePlusREST(urlRestJournal, rSiopeConfig, userRest, pwdRest, codiceIpa);
			Stream[] doc = rClient.GetGiornaledicassa(inizio, fine, salvaFile, out errore);
			if (!string.IsNullOrEmpty(errore))
			{
				return null;
			}
			else
				return doc;
		}

		public static List<string> InviaOPI(DataAccess conn, string fname)
		{
			var rSiopeConfig = getOPISiopePlusConfig(conn);
			List<string> errori = null;
			try
			{
				switch (rSiopeConfig.Code)
				{
					case "opi_siopeplus":
						errori = caricaOPIsuSiopePlus(conn, rSiopeConfig, fname);
						break;
					default:
						errori = new List<string>() { "Banca non supportata" };
						break;
				}
			}
			catch (Exception e)
			{
				errori = new List<string>() { QueryCreator.GetErrorString(e) };
			}

			return errori;
		}

		private static List<string> caricaOPIsuSiopePlus(DataAccess conn, OpiSiopeplusConfig pConf, string fname)
		{
			var errors = new List<string>();
			var esercizio = conn.GetEsercizio();
			var dataContabile = conn.GetDataContabile();

			//var tIPA = conn.RUN_SELECT("ipa", "*", null, "ipa_fe like 'uf%' ", null, false);
			//if ((tIPA == null)||(tIPA.Rows.Count==0)) {
			//    return null;
			//}

			// Parametri del servizio 

			string userRest = pConf.Config[0]; // utente ambiente REST
			string pwdRest = pConf.Config[1]; //password ambiente REST
			string urlRest = pConf.Config[2]; // url ambiente REST
			string codiceIpa = pConf.Config[3]; //tIPA.Rows[0]["ipa_fe"].ToString();

			//https://siopeplus-tst.vaservices.eu:444/te/easysiopeente/ext-rest/flussi-opi/{codiceIpa}
			SiopePlusREST rClient = new SiopePlusREST(urlRest, pConf, userRest, pwdRest, codiceIpa);

			try
			{
				var esito = rClient.inviaOrdinativi(fname);


				if (esito != null)
				{
					errors.Add($"Nell'invio del file {fname}  errore:\r\n\r\n {esito})");
					return errors;
				}
			}
			catch (Exception ex)
			{
				errors.Add(QueryCreator.GetErrorString(ex));
				return errors;

			}

			// Imposta il flusso come trasmesso solo se non ci sono stati errori
			if (errors.Count != 0) return errors;


			//DataRow curr = ds.Tables["flussocrediti"]._First();
			//curr["istransmitted"] = "S";
			//salvaDati(ds, errors, conn);


			return errors;
		}

		public static string getHashSha256(string text)
		{

			byte[] bytes = Encoding.Unicode.GetBytes(text);
			SHA256Managed hashstring = new SHA256Managed();
			byte[] hash = hashstring.ComputeHash(bytes);
			string hashString = string.Empty;
			foreach (byte x in hash)
			{
				hashString += $"{x:x2}";
			}

			return hashString;
		}

		public static string SecurityCode(string logparamCript, string codice)
		{
			codice = codice + logparamCript;
			return getHashSha256(codice);
		}

		static string maxLen(string s, int len)
		{
			if (s == null) return null;
			if (s.Length < len) return s;
			return s.Substring(0, len);
		}
		//CN=solutionpa-coll.intesasanpaolo.com, O=Intesa Sanpaolo S.p.A. - Test SSL, S=Italia, C=IT
		//CN=solutionpa-coll.intesasanpaolo.com, O=Intesa Sanpaolo S.p.A. - Test SSL, S=Italia, C=IT
		//CN=System Test ISP - CA Servizi Esterni enhanced, DC=syssede, DC=systest, DC=sanpaoloimi, DC=com
		//CN=System Test Intesa Sanpaolo S.p.A. - CA Root Interna 02, O=Intesa Sanpaolo S.p.A., C=IT



		public static bool checkCertificatiBancaSondrio(string thumbCert, string fileCert)
		{

			//if (checkCertificato(StoreName.AuthRoot,StoreLocation.CurrentUser,"popsocert_root.cer","CN=PopsoRootCA01, DC=popso, DC=root, DC=dom")==null) return false;
			/*
			     factory.Credentials.ServiceCertificate.DefaultCertificate = pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, "d34e1f8c01a911110145142dbb8fb32358b8a725");
			    factory.Credentials.ClientCertificate.Certificate = pagoPaService.PagoPaService.getCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser,
			        "C36663D47D8C70B2B9D40BA9174529DDD23A952A");
			 */
			if (DateTime.Now.CompareTo(new DateTime(2019, 1, 14, 11, 0, 0)) >= 0)
			{
				removeCertificateByThumbPrint(StoreName.AuthRoot, StoreLocation.CurrentUser,
					"f158cb0b33b0ea1d219d192862086ff6730b2c9b".ToUpperInvariant());
				if (checkCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser,
						"po2019_intermedio_bsondrio.cer",
						"f158cb0b33b0ea1d219d192862086ff6730b2c9b".ToUpperInvariant()) == null) return false;

			}
			else
			{
				removeCertificateByThumbPrint(StoreName.AuthRoot, StoreLocation.CurrentUser,
					"1FB86B1168EC743154062E8C9CC5B171A4B7CCB4");
				if (checkCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser,
						"po2018_intermedio_bsondrio.cer", "1FB86B1168EC743154062E8C9CC5B171A4B7CCB4") ==
					null) return false;

			}

			if (DateTime.Now.CompareTo(new DateTime(2019, 1, 14, 11, 0, 0)) >= 0)
			{
				removeCertificateByThumbPrint(StoreName.AuthRoot, StoreLocation.CurrentUser,
					"1fb86b1168ec743154062e8c9cc5b171a4b7ccb4".ToUpperInvariant());
				if (checkCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, "po2019_bsondrio.cer",
						"1fb86b1168ec743154062e8c9cc5b171a4b7ccb4".ToUpperInvariant()) == null) return false;
			}
			else
			{
				removeCertificateByThumbPrint(StoreName.AuthRoot, StoreLocation.CurrentUser,
					"A433B73E1854B0A8615CD32C6D36A658F2905724");
				if (checkCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, "po2018_bsondrio.cer",
						"A433B73E1854B0A8615CD32C6D36A658F2905724") == null) return false;
			}




			if (checkPfxByThumbPrint(StoreName.AuthRoot, StoreLocation.CurrentUser, "UNIPO_3001600_0000252.pfx",
					"3EB5D4157096C386F9F9EBB90F0B166EE38849D6", null) == null) return false;


			//Questa ÃƒÆ’Ã‚Â¨ la root
			if (checkCertificateByThumbPrint(StoreName.AuthRoot, StoreLocation.CurrentUser, "po2018_root_bsondrio.cer",
					"67BC2F778867F73D887A69018FF3CC108AD5C465") == null) return false;

			//if (checkCertificato(StoreName.AuthRoot,StoreLocation.CurrentUser,"popsocert_root.cer","CN=PopsoRootCA01, DC=popso, DC=root, DC=dom")==null) return false;
			//if (checkPfxByThumbPrint(StoreName.My,StoreLocation.CurrentUser,"popso2018.pfx")
			//questo ci deve essere sempre

			removeCertificateByThumbPrint(StoreName.AuthRoot, StoreLocation.CurrentUser,
				"C36663D47D8C70B2B9D40BA9174529DDD23A952A");

			if (checkPfxByThumbPrint(StoreName.My, StoreLocation.CurrentUser, "popso_chain.pfx",
					"C36663D47D8C70B2B9D40BA9174529DDD23A952A", "sviluppo") == null) return false;

			//"C36663D47D8C70B2B9D40BA9174529DDD23A952A"



			if (checkCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, fileCert, thumbCert) ==
				null) return false;


			return true;


		}


		public static bool checkCertificatiGovPayCrediti(bool test)
		{
			//removeCertificateByThumbPrint(StoreName.AuthRoot, StoreLocation.CurrentUser, "3e92d9b2dc6d2afaad4c52bd6aa24b76d63c44ab");


			if (test)
			{
				removeCertificateByThumbPrint(StoreName.AuthRoot, StoreLocation.CurrentUser,
					"8a653ab1eb3f30341baa7e442a81d22e42751e46");
				if (checkCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser,
						"pppagoateneicinecait_cert_out.cer", "8a653ab1eb3f30341baa7e442a81d22e42751e46") ==
					null) return false;
			}
			else
			{
				removeCertificateByThumbPrint(StoreName.AuthRoot, StoreLocation.CurrentUser,
					"3e92d9b2dc6d2afaad4c52bd6aa24b76d63c44ab");
				if (checkCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, "govpaycinecait_cert_out.cer",
						"3e92d9b2dc6d2afaad4c52bd6aa24b76d63c44ab") == null) return false;
			}


			removeCertificateByThumbPrint(StoreName.AuthRoot, StoreLocation.CurrentUser,
				"218fff5ce170503dae33fde182d2b22f5457f391");
			if (checkPfxByThumbPrint(StoreName.My, StoreLocation.CurrentUser, "unisalento.p12",
					"218fff5ce170503dae33fde182d2b22f5457f391", "ebdf1bd86872cc62") == null) return false;



			//if (checkCertificato(StoreName.AuthRoot,StoreLocation.CurrentUser,"intesa1.cer","CN=solutionpa-coll.intesasanpaolo.com, O=Intesa Sanpaolo S.p.A. - Test SSL, S=Italia, C=IT")==null) return false;
			//if (checkCertificato(StoreName.My,StoreLocation.CurrentUser,"intesa2.cer","CN=System Test Intesa Sanpaolo S.p.A. - CA Root Interna 02, O=Intesa Sanpaolo S.p.A., C=IT")==null) return false;
			//if (test) {
			//    if (checkCertificato(StoreName.CertificateAuthority,StoreLocation.CurrentUser,"intesa3.cer","CN=System Test ISP - CA Servizi Esterni enhanced")==null) return false;
			//}


			return true;

		}



		public static bool checkCertificatiBancaIntesa(bool test)
		{
			removeCertificateByThumbPrint(StoreName.AuthRoot, StoreLocation.CurrentUser,
				"3ed8765d55f336bc43f08e0decd9573c64866049");
			if (checkCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, "intesa1.cer",
					"3ed8765d55f336bc43f08e0decd9573c64866049") == null) return false;
			if (checkCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, "intesa2.cer",
					"a32787f1f3d287c96030cd2ad17492344af5c575") == null) return false;
			if (test)
			{
				if (checkCertificateByThumbPrint(StoreName.My, StoreLocation.CurrentUser, "intesa3.cer",
						"6b9233c509e2d2a4d0dafa6207bc5c07720716a7") == null) return false;
			}


			//if (checkCertificato(StoreName.AuthRoot,StoreLocation.CurrentUser,"intesa1.cer","CN=solutionpa-coll.intesasanpaolo.com, O=Intesa Sanpaolo S.p.A. - Test SSL, S=Italia, C=IT")==null) return false;
			//if (checkCertificato(StoreName.My,StoreLocation.CurrentUser,"intesa2.cer","CN=System Test Intesa Sanpaolo S.p.A. - CA Root Interna 02, O=Intesa Sanpaolo S.p.A., C=IT")==null) return false;
			//if (test) {
			//    if (checkCertificato(StoreName.CertificateAuthority,StoreLocation.CurrentUser,"intesa3.cer","CN=System Test ISP - CA Servizi Esterni enhanced")==null) return false;
			//}


			return true;

		}

		public static X509Certificate2 checkPfxByThumbPrint(StoreName storeName, StoreLocation storeLocation,
			string certFileName, string thumbPrint, string password)
		{
			var cert = getCertificateByThumbPrint(storeName, storeLocation, thumbPrint);
			if (cert != null) return cert;

			installaPfx(storeName, storeLocation, certFileName, password);
			return getCertificateByThumbPrint(storeName, storeLocation, thumbPrint);
		}

		static X509Certificate2 checkPfx(StoreName storeName, StoreLocation storeLocation, string certFileName,
			string subjectName, string password)
		{
			var cert = getCertificateBySubjectName(storeName, storeLocation, subjectName);
			if (cert != null) return cert;
			installaPfx(storeName, storeLocation, certFileName, password);
			return getCertificateBySubjectName(storeName, storeLocation, subjectName);
		}

		static void installaPfx(StoreName storeName, StoreLocation storeLocation, string certFileName,
			string password)
		{
			var col = new X509Certificate2Collection();
			col.Import(certFileName, password, X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.PersistKeySet);
			foreach (X509Certificate2 certFile in col)
			{
				X509Store store = new X509Store(storeName, storeLocation);
				store.Open(OpenFlags.ReadWrite);
				store.Add(certFile);
				store.Close();
			}

			return;

			//string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, certFileName);
			//X509Store store = new X509Store(storeName, storeLocation);
			//store.Open(OpenFlags.ReadWrite);
			//var cert = new X509Certificate2(fileName, password, X509KeyStorageFlags.);
			//X509Chain chain = new X509Chain();
			//chain.Build(cert);
			//for (int i = 0; i < chain.ChainElements.Count; i++) {
			//    store.Add(chain.ChainElements[i].Certificate);
			//}

			//store.Close();
			//return cert;
		}



		/*
		 *
		 X509Certificate2 nonPersistentCert = CreateACertSomehow();

// this is only required since there's no constructor for X509Certificate2 that uses X509KeyStorageFlags but a password
// so we create a tmp password, which is not reqired to be secure since it's only used in memory
// and the private key will be included (plain) in the final cert anyway
const string TMP_PFX_PASSWORD = "password";

// create a pfx in memory ...
byte[] nonPersistentCertPfxBytes = nonPersistentCert.Export(X509ContentType.Pfx, TMP_PFX_PASSWORD);

// ... to get an X509Certificate2 object with the X509KeyStorageFlags.PersistKeySet flag set
X509Certificate2 serverCert = new X509Certificate2(nonPersistentCertPfxBytes, TMP_PFX_PASSWORD,
	X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable); // use X509KeyStorageFlags.Exportable only if you want the private key to tbe exportable

// get the private key, which currently only the SYSTEM-User has access to
RSACryptoServiceProvider systemUserOnlyReadablePrivateKey = serverCert.PrivateKey as RSACryptoServiceProvider;

// create cspParameters
CspParameters cspParameters = new CspParameters(systemUserOnlyReadablePrivateKey.CspKeyContainerInfo.ProviderType, 
	systemUserOnlyReadablePrivateKey.CspKeyContainerInfo.ProviderName, 
	systemUserOnlyReadablePrivateKey.CspKeyContainerInfo.KeyContainerName)
{
	// CspProviderFlags.UseArchivableKey means the key is exportable, if you don't want that use CspProviderFlags.UseExistingKey instead
	Flags = CspProviderFlags.UseMachineKeyStore | CspProviderFlags.UseArchivableKey,
	CryptoKeySecurity = systemUserOnlyReadablePrivateKey.CspKeyContainerInfo.CryptoKeySecurity
};

// add the access rules
cspParameters.CryptoKeySecurity.AddAccessRule(new CryptoKeyAccessRule(new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null), CryptoKeyRights.GenericRead, AccessControlType.Allow));

// create a new RSACryptoServiceProvider from the cspParameters and assign that as the private key
RSACryptoServiceProvider allUsersReadablePrivateKey = new RSACryptoServiceProvider(cspParameters);
serverCert.PrivateKey = allUsersReadablePrivateKey;

// finally place it into the cert store
X509Store rootStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
rootStore.Open(OpenFlags.ReadWrite);
rootStore.Add(serverCert);
rootStore.Close();



		 */
		static X509Certificate2 getCertificateBySubjectName(StoreName storeName, StoreLocation storeLocation,
			string subjectName)
		{
			X509Store store = new X509Store(storeName, storeLocation);
			store.Open(OpenFlags.ReadOnly);

			var certificates = store.Certificates.Find(
				X509FindType.FindBySubjectDistinguishedName, //
				subjectName,
				false);
			store.Close();


			if (certificates.Count > 1)
			{
				X509Store store2 = new X509Store(storeName, storeLocation);
				store2.Open(OpenFlags.ReadWrite);

				certificates = store2.Certificates.Find(
					X509FindType.FindBySubjectDistinguishedName,
					subjectName,
					false);

				foreach (var c in certificates) store2.Remove(c);
				store2.Close();
				return null;
			}

			if (certificates.Count == 0) return null;
			return certificates[0];
		}



		public static X509Certificate2 checkCertificato(StoreName storeName, StoreLocation storeLocation,
			string certFileName, string subjectName)
		{
			var cert = getCertificateBySubjectName(storeName, storeLocation, subjectName);
			if (cert != null) return cert;

			return installaCertificato(storeName, storeLocation, certFileName);
		}

		public static X509Certificate2 getCertificateByThumbPrint(StoreName storeName, StoreLocation storeLocation,
			string thumbPrint)
		{
			X509Store store = new X509Store(storeName, storeLocation);
			store.Open(OpenFlags.ReadOnly);

			var certificates = store.Certificates.Find(
				X509FindType.FindByThumbprint, //
				thumbPrint,
				false);
			store.Close();


			if (certificates.Count > 1)
			{
				X509Store store2 = new X509Store(storeName, storeLocation);
				store2.Open(OpenFlags.ReadWrite);

				certificates = store2.Certificates.Find(
					X509FindType.FindByThumbprint,
					thumbPrint,
					false);

				foreach (var c in certificates) store2.Remove(c);
				store2.Close();
				return null;
			}

			if (certificates.Count == 0) return null;
			return certificates[0];
		}



		public static X509Certificate2 checkCertificateByThumbPrint(StoreName storeName, StoreLocation storeLocation,
			string certFileName, string thumb)
		{
			var cert = getCertificateByThumbPrint(storeName, storeLocation, thumb);
			if (cert != null) return cert;
			return installaCertificato(storeName, storeLocation, certFileName);
		}

		public static void removeCertificateByThumbPrint(StoreName storeName, StoreLocation storeLocation,
			string thumbPrint)
		{
			X509Store store = new X509Store(storeName, storeLocation);
			store.Open(OpenFlags.ReadWrite);

			var certificates = store.Certificates.Find(
				X509FindType.FindByThumbprint, //
				thumbPrint,
				false);
			foreach (var c in certificates) store.Remove(c);
			store.Close();

		}

		static X509Certificate2 installaCertificato(StoreName storeName, StoreLocation storeLocation,
			string certFileName)
		{
			string fileName = "";
			try
			{
				fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, certFileName);
				X509Store store = new X509Store(storeName, storeLocation);
				store.Open(OpenFlags.ReadWrite);
				var cert = new X509Certificate2(X509Certificate.CreateFromCertFile(fileName));
				store.Add(cert);
				store.Close();
				return cert;
			}
			catch (Exception e)
			{
				throw new Exception("File " + fileName + " non ÃƒÆ’Ã‚Â¨ un valido certificato.", e);

			}
		}

		private static List<string> caricaPosizioniDebitorieIntesaSanPaolo(DataAccess Conn, DataSet DS,
			PartnerConfig pConf)
		{
			object idflusso = DS.Tables["flussocrediti"].Rows[0]["idflusso"].ToString();
			var qhs = Conn.GetQueryHelper();
			var errors = new List<string>();
			try
			{

				var curr = DS.Tables["flussocrediti"]._First();

				// Fa selezionare la cartella per gli avvisi di pagamento analogici all'utente
				//txtCartellaEsportazione.Text = FaiScegliereCartella();
				//if (string.IsNullOrEmpty(txtCartellaEsportazione.Text)) {
				//    MetaFactory.factory.getSingleton<IMessageShower>().Show("Devi selezionare una cartella dove memorizzare gli avvisi di pagamento analogici.");
				//    return;
				//}
				//if (string.IsNullOrEmpty(nomeCartella)) {
				//    Errors.Add("Manca il nome della cartella dove memorizzare gli avvisi di pagamento analogici.");
				//    return Errors;
				//}


				//Application.DoEvents();

				var esercizio = Conn.GetEsercizio();
				var dataContabile = Conn.GetDataContabile();

				// Costruisce l'elenco dei dettagli da esportare
				var tPosizioniDebitorieTuttiServizi =
					Conn.CallSP("exp_posizionidebitoriebsondrio", new object[] { curr["idflusso"], esercizio }).Tables[0];

				q filter = null;
				//if (tPosizioniDebitorieTuttiServizi.Columns.Contains("codice_servizio")) {
				//	if (pConf.codice_servizio == null) {
				//		filter = q.isNull("codice_servizio");
				//	}
				//	else {
				//		filter = q.eq("codice_servizio",pConf.codice_servizio);
				//	}
				//}

				var righeDaConsiderare = tPosizioniDebitorieTuttiServizi._Filter(filter);

				if (righeDaConsiderare.Length == 0)
				{
					if (pConf.codice_servizio == null) errors.Add("Non vi sono posizioni debitorie da inviare.");
					return errors;
				}


				// Parametri del servizio            (partnerconfig ha come primo token il codice del partner ossia intesasp in questo caso
				var identificativoDominio = pConf.Config[0]; // Parametro fornito da Intesa:     80005570561
				var identificativoBu = pConf.Config[1]; // Parametro fornito da Intesa:     RE0009
				var identificativoServizio =
					pConf.Config[2]; // Parametro fornito da Intesa (per ambiente di test utilizzare DEPOSITOCAUZIONALE)

				var user = pConf.Config.Length > 3 ? pConf.Config[3] : null;
				var password = pConf.Config.Length > 4 ? pConf.Config[4] : null;
				string url = null;
				if (pConf.Config.Length > 5)
				{
					url = pConf.Config[5];
				}

				//var identificativoProprietario = "";                    // Parametro che identifica il id_tenant

				// Estrae dal DB la denominazione dell'ente
				var filterParams = qhs.AppAnd(
					qhs.CmpEq("idparam", "DenominazioneUniversita"),
					qhs.NullOrLe("start", dataContabile),
					qhs.NullOrGt("stop", dataContabile)
				);
				var denominazioneEnte = Conn.DO_READ_VALUE("generalreportparameter", filterParams, "paramvalue", null);

				// if (denominazioneEnte == null || denominazioneEnte != DBNull.Value) return;
				if (denominazioneEnte == DBNull.Value)
				{
					errors.Add("Manca la denominazione Ente in Parametri per tutte le stampe.");
					return errors;
				}



				var qhc = new CQueryHelper();
				if (righeDaConsiderare._Filter(q.isNull("scadenza")).ToArray().Length > 0)
				{
					errors.Add("Ci sono posizioni debitorie senza scadenza");
					return errors;
				}
				if (righeDaConsiderare._Filter(q.isNull("codice")).ToArray().Length > 0)
				{
					errors.Add("Ci sono posizioni debitorie aventi sia P.iva che CF non valorizzati");
					return errors;
				}
				// Costruisce un dizionario di riferimento per i dettagli
				// Ogni entry di reference contiene una riga di flussocreditidetail associata al codice
				//var reference = new Dictionary<string, DataRow>();

				var tFlussocreditidetail = DS.Tables["flussocreditidetail"];
				if (DS.Tables["flussocreditidetail"].Rows.Count == 0)
				{
					errors.Add("Non vi sono posizioni righe in Flussocreditidetail con n. " + idflusso + ".");
					return errors;
				}

				var reference = new Dictionary<string, List<DataRow>>();
				foreach (DataRow r in tFlussocreditidetail.Rows)
				{
					var codice = r["iduniqueformcode"].ToString(); //getID_Tenant(r["idflusso"], r["iddetail"]); ;
					if (!reference.ContainsKey(codice))
					{
						reference.Add(codice, new List<DataRow>());
					}

					reference[codice].Add(r);
				}

				if (!checkCertificatiBancaIntesa(identificativoServizio == "DEPOSITOCAUZIONALE"))
				{
					errors.Add("Impossibile installare i certificati di banca intesa");
					return errors;
				}

				var servizio = new IntesaSanPaolo.EServizio().Create(user, password, url,
					identificativoServizio == "DEPOSITOCAUZIONALE");
				var trasmesso = "N";

				foreach (DataRow r in righeDaConsiderare)
				{

					#region Caricamento dati per pagamento

					var importo = Convert.ToDecimal(r["importo"]);
					var idDisposizione = r["iduniqueformcode"].ToString();
					if (!reference.ContainsKey(idDisposizione)) continue; //Non ÃƒÆ’Ã‚Â¨ oggetto di questo invio
					string email = DBNull.Value.Equals(r["email"]) ? null : firstEmail(r["email"].ToString());
					var pagatore = new InfoGroup.ct0000000003_soggettoPagatore()
					{
						anagraficaPagatore = DBNull.Value.Equals(r["anagrafica"])
							? null
							: maxLen(r["anagrafica"].ToString(), 70),
						// tipoIdentificativoUnivocoPagatore = DBNull.Value.Equals(r["tipo"]) ? null : r["tipo"].ToString(),
						tipoIdentificativoUnivocoPagatore =
							r["tipo"].ToString(), //F persona fisica   G persona  giuridica
						codiceIdentificativoUnivocoPagatore =
							DBNull.Value.Equals(r["codice"]) ? null : r["codice"].ToString(), //
						indirizzoPagatore = DBNull.Value.Equals(r["indirizzo"])
							? null
							: maxLen(r["indirizzo"].ToString(), 70),
						civicoPagatore = null, // civico non disponibile (incluso nell'indirizzo)
						capPagatore = DBNull.Value.Equals(r["cap"]) ? null : maxLen(r["cap"].ToString(), 16),
						localitaPagatore = DBNull.Value.Equals(r["citta"]) ? null : maxLen(r["citta"].ToString(), 35),
						provinciaPagatore = DBNull.Value.Equals(r["provincia"])
							? null
							: maxLen(r["provincia"].ToString(), 35),
						nazionePagatore = null, // codice ISO 3166 non disponibile
						emailPagatore = string.IsNullOrEmpty(email) ? null : maxLen(email, 256)
					};
					string causale = cleanLineFeed(r["causale"].ToString());

					//string note = cleanHtmlFeed(r["note"].ToString());

					var datiVersamento = new InfoGroup.ct0000000003_datiSingoloVersamento()
					{
						credenzialiPagatore = null, // non richiesto
						datiMarcaBolloDigitale = null, // no marca da bollo
						descrizioneTestualeCausaleVersamento = maxLen(causale, 140),
						identificativoServizio = identificativoServizio,
						importoSingoloVersamento = importo
					};

					var datiPagamento = new InfoGroup.ct0000000003_datiPagamentoInAttesa()
					{
						id_tenant = idDisposizione,
						soggettoPagatore = pagatore,
						//Come da schema XSD fornito, ÃƒÆ’Ã‚Â¨ un dato OBBLIGATORIO.Come attualmente per il MAV,
						// la data scadenza non comporta nessun annullo e nessuna impagabilitÃƒÆ’Ã‚Â .Come da ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œregolamentoÃƒÂ¢Ã¢â€šÂ¬Ã‚Â ateneo,
						// se lo studente pagherÃƒÆ’Ã‚Â  oltre la scadenza, si troverÃƒÆ’Ã‚Â  una MORA.
						dataScadenzaPagamento = noNullDate(r["scadenza"], DateTime.MaxValue),
						importoTotaleDaVersare = importo,
						causaleVersamentoEsplicitaPSP = maxLen(causale, 140),
						identificativoUnivocoVersamento = null, // lasciarlo a null per farlo generare alla banca
						notificaCallback = null, // serve? in attesa di risposta...
						pagabileSeScaduto = 0, // 0 -> no, 1 -> sÃƒÆ’Ã‚Â¬
						datiSingoloVersamento = datiVersamento
					};

					var pagamento = new InfoGroup.ct0000000003_pdpCaricaPagamentoInAttesa()
					{
						//modalita ="INS",
						modalita = InfoGroup.ct0000000003_pdpCaricaPagamentoInAttesaModalita.INS,
						datiPagamentoInAttesa = datiPagamento
					};

					#endregion


					string iuv;
					try
					{
						// Carica il pagamento
						{
							var body = new IntesaSanPaolo.pdpCaricaPagamentoInAttesaBody(identificativoDominio,
								identificativoBu, pagamento);
							var request = new IntesaSanPaolo.pdpCaricaPagamentoInAttesa(body);
							var response = servizio.pdpCaricaPagamentoInAttesa(request);
							if (response?.Body == null)
							{
								errors.Add(
									$"Nell'invio di flusso {idflusso} anagrafica {pagatore.codiceIdentificativoUnivocoPagatore}  Il server ha restituito una risposta non valida");
								continue;
							}

							var result = response.Body.Result;
							if (result.esitoOperazione.Equals("OK"))
							{
								iuv = result.datiRestituiti.identificativoUnivocoVersamento;
								trasmesso = "S";
							}
							else
							{
								errors.Add(
									$"Nell'invio di flusso {idflusso} anagrafica {pagatore.codiceIdentificativoUnivocoPagatore} {result.codiceErrore}");
								errors.Add(Encoding.ASCII.GetString(
									response.Body.pdpCaricaPagamentoInAttesaResult.param));
								continue;
							}
						}
					}
					catch (Exception ex)
					{
						errors.Add(QueryCreator.GetErrorString(ex));
						continue;
					}

					foreach (var rDs in reference[idDisposizione])
					{
						rDs["iuv"] = iuv;
					}

				}

				// Imposta il flusso come trasmesso solo se non ci sono stati errori          NO, altrimenti non considera trasmessi nemmeno quelli con lo iuv
				//if (errors.Count == 0 ) {
				curr["istransmitted"] = trasmesso;
				//}

				var dispatcher = new Meta_EasyDispatcher(Conn);
				var metaFlussoCreditiDeatil = dispatcher.Get("flussocreditidetail");
				metaFlussoCreditiDeatil.ComputeRowsAs(tFlussocreditidetail, "posting");

				//Meta.SaveFormData();
				var post = new Easy_PostData_NoBL();
				post.initClass(DS, Conn);
				if (!post.DO_POST())
				{
					errors.Add("Errore nel salvataggio dei dati");
					return errors;
				}
			}
			catch (Exception ex)
			{
				errors.Add(QueryCreator.GetErrorString(ex));
				return errors;
			}

			return errors;
		}


		/// <summary>
		/// Invia i crediti al webservice di govpay. Lasciamo generare a govpay lo IUV. Non gestiamo al momento l'invio della mail
		///  al percipiente.
		/// </summary>
		/// 
		private static DataTable CalcRowGrouped(DataTable Auto)
		{
			//1) Scorro le righe dettagliate restituite dalla stored procedure exp_posizionidebitoriebsondrio
			DataTable AutoGrouped = Auto.Clone();

			Dictionary<int, List<DataRow>> groupedRows = new Dictionary<int, List<DataRow>>();
			//Crea le righe di spesa raggruppate
			for (int i = 0; i < Auto.Rows.Count; i++)
			{
				DataRow R = Auto.Rows[i];

				//Facciamo il raggruppamento per i seguenti campi,         
				var qhc = new CQueryHelper();
				string filter = qhc.MCmp(R, "iduniqueformcode", "scadenza", "idreg", "tipo",
											 "codice", "forename", "surname", "anagrafica", "indirizzo",
											 "cap", "citta", "provincia", "nazione", "email",
											 "pec", "codicetassonomia", "iduniqueformcode", "causale", "note");

				//cerca nelle righe raggruppata una riga in cui inserire R, aumentandone l'importo
				DataRow[] RGrouped = AutoGrouped.Select(filter);
				if (RGrouped.Length == 0)
				{
					DataRow NewR = AddRowToTableGrouped(R, AutoGrouped);
				}
				else
				{
					RGrouped[0]["importo"] = CfgFn.GetNoNullDecimal(RGrouped[0]["importo"]) + CfgFn.GetNoNullDecimal(R["importo"]);
				}
			}

			return AutoGrouped;
		}


		private static DataRow AddRowToTableGrouped(DataRow R, DataTable T)
		{
			DataRow NewR = T.NewRow();
			foreach (DataColumn C in T.Columns)
			{
				if (C.ColumnName == "iddisposition")
					NewR[C.ColumnName] = R["iduniqueformcode"];
				else
					NewR[C.ColumnName] = R[C.ColumnName];
			}

			T.Rows.Add(NewR);
			return NewR;
		}

		private static List<string> caricaPosizioniDebitorieGovPay(DataAccess conn, DataSet ds, PartnerConfig pConf)
		{
			object idflusso = ds.Tables["flussocrediti"].Rows[0]["idflusso"].ToString();
			var errors = new List<string>();
			var curr = ds.Tables["flussocrediti"]._First();

			var esercizio = conn.GetEsercizio();

			// Parametri del servizio
			// codiceApplicazione|codiceDominio|codiceUnitÃƒÆ’Ã‚Â Operativa|user|pwd|url|iban
			var codiceApplicazione = pConf.Config[0];
			var codiceDominio = pConf.Config[1];
			var codiceUnitÃƒÆ’Ã‚Â Operativa = pConf.Config[2];

			var user = pConf.Config[3];
			var pwd = pConf.Config[4];
			var url = pConf.Config[5];
			// "https://gateway.pp.pagoatenei.cineca.it/portalepagamenti.server.gateway/api/private/soap/GPAppPort"; // pConf.Config[5];

			var iban = pConf.Config.Length > 6 ? pConf.Config[6] : null;

			//if (!url.EndsWith("PagamentiTelematiciGPAppService")) url += "PagamentiTelematiciGPAppService";

			// Costruisce l'elenco dei dettagli da esportare
			DataTable tPosizioniDebitorie_ungrouped = conn.CallSP("exp_posizionidebitoriebsondrio", new[] { curr["idflusso"], esercizio })
				.Tables[0];
			DataTable tPosizioniDebitorie = CalcRowGrouped(tPosizioniDebitorie_ungrouped);
			if (tPosizioniDebitorie.Rows.Count == 0)
			{
				errors.Add("Non vi sono posizioni debitorie da inviare.");
				return errors;
			}

			// Costruisce un dizionario di riferimento per i dettagli
			// Ogni entry di reference contiene una riga di flussocreditidetail associata al codice
			var reference = new Dictionary<string, List<DataRow>>();
			var tFlussocreditidetail = ds.Tables["flussocreditidetail"];
			foreach (DataRow r in tFlussocreditidetail.Rows)
			{
				string codice = r["iduniqueformcode"].ToString(); //getID_Tenant(r["idflusso"], r["iddetail"]); ;
				if (!reference.ContainsKey(codice))
				{
					reference[codice] = new List<DataRow>();
				}

				reference[codice].Add(r);
			}


			var qhc = new CQueryHelper();
			if (tPosizioniDebitorie.Select(qhc.IsNull("scadenza")).Length > 0)
			{
				errors.Add("Ci sono posizioni debitorie senza scadenza");
				return errors;
			}

			checkCertificatiGovPayCrediti(url.Contains("gateway.pp.pagoatenei"));
			var servizio = GovPayCrediti.InvioCreditiGPAppService.Create(user, pwd, url, url.Contains("gateway.pp.pagoatenei"));

			foreach (DataRow r in tPosizioniDebitorie.Rows)
			{
				var idDisposizione = r["iduniqueformcode"].ToString();
				if (!reference.ContainsKey(idDisposizione)) continue; //Non ÃƒÆ’Ã‚Â¨ oggetto di questo invio

				var importo = Convert.ToDecimal(r["importo"]);
				string email = DBNull.Value.Equals(r["email"]) ? null : firstEmail(r["email"].ToString());
				var debitore = new GovPayCrediti.anagrafica()
				{
					codUnivoco = DBNull.Value.Equals(r["codice"]) ? null : r["codice"].ToString(),
					ragioneSociale = DBNull.Value.Equals(r["anagrafica"])
						? null
						: maxLen(r["anagrafica"].ToString(), 70),
					indirizzo = DBNull.Value.Equals(r["indirizzo"]) ? null : r["indirizzo"].ToString(),
					civico = null, // civico non disponibile (incluso nell'indirizzo)
					cap = DBNull.Value.Equals(r["cap"]) ? null : maxLen(r["cap"].ToString(), 16),
					localita = DBNull.Value.Equals(r["citta"]) ? null : maxLen(r["citta"].ToString(), 35),
					provincia = DBNull.Value.Equals(r["provincia"]) ? null : maxLen(r["provincia"].ToString(), 35),
					nazione = null, // codice ISO 3166 non disponibile
					email = string.IsNullOrEmpty(email) ? null : email,
					telefono = null, // telefono non disponibile
					cellulare = null, // cellulare non disponibile
					fax = null // fax non disponibile
				};
				object itemToSet = "TRIBUTO";
				if (r.Table.Columns.Contains("codicetassonomia") && (r["codicetassonomia"] != DBNull.Value))
				{
					GovPayCrediti.tipoContabilita tipoCont = GovPayCrediti.tipoContabilita.ALTRO;
					string tassonomia = r["codicetassonomia"].ToString();
					if (tassonomia.Length >= 2)
					{
						switch (tassonomia.Substring(0, 2))
						{
							case "9/":
								tipoCont = GovPayCrediti.tipoContabilita.ALTRO;
								break;
							case "0/":
								tipoCont = GovPayCrediti.tipoContabilita.CAPITOLO;
								break;
							case "1/":
								tipoCont = GovPayCrediti.tipoContabilita.SPECIALE;
								break;
							case "2/":
								tipoCont = GovPayCrediti.tipoContabilita.SIOPE;
								break;
						}
					}

					if (tassonomia.Length >= 2)
					{
						itemToSet = new GovPayCrediti.versamentoSingoloVersamentoTributo()
						{
							tipoContabilita = tipoCont,
							codContabilita = r["codicetassonomia"].ToString().Substring(2),
							ibanAccredito = iban
						};
					}
					else
					{
						itemToSet = new GovPayCrediti.versamentoSingoloVersamentoTributo()
						{
							tipoContabilita = GovPayCrediti.tipoContabilita.ALTRO,
							codContabilita = "GENERICO",
							ibanAccredito = iban
						};
					}

				}

				var singoloVersamento = new GovPayCrediti.versamentoSingoloVersamento()
				{
					codSingoloVersamentoEnte = idDisposizione,
					importo = importo,
					Item = itemToSet,
					//codTributo = "TRIBUTO", // TODO: specificare il codice tributo
					//tributo = null, // solo codTributo
					//bolloTelematico = null, // no marca da bollo

					note = null // nessuna nota,
				};
				string causale = cleanLineFeed(r["causale"].ToString());

				//string note = cleanHtmlFeed(r["note"].ToString());

				var versamento = new GovPayCrediti.versamento
				{
					codApplicazione = codiceApplicazione,
					codDominio = codiceDominio,
					codUnitaOperativa = codiceUnitÃƒÆ’Ã‚Â Operativa,
					codVersamentoEnte = idDisposizione,
					debitore = debitore,
					importoTotale = importo,
					//Dato OBBLIGATORIO.Come attualmente per il MAV,la data scadenza non comporta nessun annullo e nessuna impagabilitÃƒÆ’Ã‚Â .
					//Come da ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œregolamentoÃƒÂ¢Ã¢â€šÂ¬Ã‚Â ateneo, se lo studente pagherÃƒÆ’Ã‚Â  oltre la scadenza, si troverÃƒÆ’Ã‚Â  una MORA.
					dataScadenza = noNullDate(r["scadenza"], DateTime.MaxValue),
					aggiornabile = false, // non supportiamo l'aggiornamento del versamento
					ItemsElementName = new GovPayCrediti.ItemsChoiceType[] { GovPayCrediti.ItemsChoiceType.causale },
					Items = new object[] { maxLen(causale, 140) },
					//spezzoneCausale = null, // solo causale semplice
					//spezzoneCausaleStrutturata = null, // solo causale semplice
					singoloVersamento = new[] { singoloVersamento },
					// TODO: controllare i seguenti campi nel codice di GovPay
					iuv = null, // non in documentazione
					annoTributario = (int)esercizio, // non in documentazione
					bundlekey = null, // non in documentazione
					codDebito = null // non in documentazione
				};

				var body = new GovPayCrediti.gpCaricaVersamento()
				{
					generaIuv = true, // lascia generare al servizio IUV, codice a barre e codice QR
					aggiornaSeEsiste = false, // non supportiamo l'aggiornamento del versamento
					versamento = versamento
				};

				GovPayCrediti.iuvGenerato iuvGenerato;
				try
				{
					var request = new GovPayCrediti.gpCaricaVersamentoRequest(body);
					var response = servizio.gpCaricaVersamento(request);

					if (response?.gpCaricaVersamentoResponse != null &&
						response.gpCaricaVersamentoResponse.codEsitoOperazione == GovPayCrediti.esitoOperazione.OK)
					{
						iuvGenerato = response.gpCaricaVersamentoResponse.iuvGenerato;
					}
					else
					{
						errors.Add(
							$"Nell'invio di flusso {idflusso} anagrafica {versamento.debitore.codUnivoco} {response?.gpCaricaVersamentoResponse?.descrizioneEsitoOperazione}");
						continue;
					}
				}
				catch (Exception ex)
				{
					errors.Add(QueryCreator.GetErrorString(ex));
					continue;
				}

				foreach (var rDs in reference[idDisposizione])
				{
					rDs["iuv"] = iuvGenerato.iuv;
					rDs["barcodevalue"] = Encoding.UTF8.GetString(iuvGenerato.barCode);

					rDs["qrcodevalue"] = Encoding.UTF8.GetString(iuvGenerato.qrCode);
					rDs["codiceavviso"] = Encoding.UTF8.GetString(iuvGenerato.qrCode).Split('|')[2];    //GovPay non fornisce un codice avviso
				}

				//GovPay non fornisce un codice avviso
				//rDs["codiceavviso"] = ;
			}

			// Imposta il flusso come trasmesso solo se non ci sono stati errori
			if (errors.Count == 0)
			{
				curr["istransmitted"] = "S";
			}

			Meta_EasyDispatcher dispatcher = new Meta_EasyDispatcher(conn);
			var metaFlussoCreditiDeatil = dispatcher.Get("flussocreditidetail");
			metaFlussoCreditiDeatil.ComputeRowsAs(tFlussocreditidetail, "posting");

			//Meta.SaveFormData();
			PostData Post = new Easy_PostData_NoBL();
			Post.initClass(ds, conn);
			if (!Post.DO_POST())
			{
				errors.Add("Errore nel salvataggio dei dati");
				return errors;
			}

			//if (errori.Count > 0) {
			//    FrmErrori.MostraErrori(this, errori);
			//}
			//else {
			//    MetaFactory.factory.getSingleton<IMessageShower>().Show("Il flusso ÃƒÆ’Ã‚Â¨ stato inviato correttamente", "Avviso");
			//}
			return errors;
		}

		static string cleanHtmlFeed(string s)
		{
			return s.Replace("&#x0D;", "\r")
				.Replace("&#x0A;", "\n");
		}

		static string cleanLineFeed(string s)
		{
			return s.Replace("&#x0D;", "\r")
				.Replace("&#x0A;", "\n")
				.Replace("\r\n", "\n")
				.Replace("\r", ";")
				.Replace("\n", ";");
		}

		public static string InviaAvvisoPagamento(string mittente, string debitore, string email, byte[] avviso,
			DataAccess Conn)
		{
			string messaggio = string.Format(@"Gent.mo {0},
                    Le inviamo la presente per notificarle una richiesta di pagamento emessa a suo nome da {1}.
                    Alleghiamo l'avviso di pagamento analogico con il quale potrÃƒÆ’Ã‚Â  pagare, secondo Sua preferenza,
                    presso le banche e altri prestatori di servizio di pagamento aderenti allÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢iniziativa tramite 
                    i canali da questi messi a disposizione (come ad esempio: home banking, ATM, APP da smartphone,
					sportello, ecc). LÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢elenco dei punti abilitati a ricevere pagamenti
                    tramite pagoPAÃƒâ€šÃ‚Â® ÃƒÆ’Ã‚Â¨ disponibile alla pagina https://www.agid.gov.it/it/piattaforme/pagopa/dove-pagare .

                    Per poter effettuare il pagamento occorre utilizzare il Codice Avviso di Pagamento
                    oppure il codice QR o il codice a barre, presenti sulla stampa dell'avviso.

                    Distinti saluti.",
				debitore,
				mittente);


			var sendmail = new SendMail()
			{
				Conn = Conn,
				UseSMTPLoginAsFromField = true,
				To = email,
				Subject = "Avviso di pagamento",
				MessageBody = messaggio
			};

			sendmail.addAttachment(avviso, "avvisoPagoPA.pdf");

			if (!sendmail.Send())
			{
				return sendmail.ErrorMessage;
			}


			return null;
		}

		public static string InviaAvvisoPagamento(string mittente, string debitore, string email, byte[] avviso, string cc,
			DataAccess Conn)
		{
			string messaggio = string.Format(@"Gent.mo {0},
                    Le inviamo la presente per notificarle una richiesta di pagamento emessa a suo nome da {1}.
                    Alleghiamo l'avviso di pagamento analogico con il quale potrÃƒÆ’Ã‚Â  pagare, secondo Sua preferenza,
                    presso le banche e altri prestatori di servizio di pagamento aderenti allÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢iniziativa tramite 
                    i canali da questi messi a disposizione (come ad esempio: home banking, ATM, APP da smartphone,
					sportello, ecc). LÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢elenco dei punti abilitati a ricevere pagamenti
                    tramite pagoPAÃƒâ€šÃ‚Â® ÃƒÆ’Ã‚Â¨ disponibile alla pagina https://www.agid.gov.it/it/piattaforme/pagopa/dove-pagare .

                    Per poter effettuare il pagamento occorre utilizzare il Codice Avviso di Pagamento
                    oppure il codice QR o il codice a barre, presenti sulla stampa dell'avviso.

                    Distinti saluti.",
				debitore,
				mittente);


			var sendmail = new SendMail()
			{
				Conn = Conn,
				UseSMTPLoginAsFromField = true,
				To = email,
				Subject = "Avviso di pagamento",
				MessageBody = messaggio,
				Cc = cc
			};

			sendmail.addAttachment(avviso, "avvisoPagoPA.pdf");

			if (!sendmail.Send())
			{
				return sendmail.ErrorMessage;
			}

			return null;
		}

		/// <summary>
		/// Invia le posizioni creditorie tramite il web Service di banca sondrio  e poi le mail ai singoli percipienti
		/// Lo IUV ÃƒÆ’Ã‚Â¨ immediatamente restituito e valorizzato
		/// </summary>
		private static List<string> caricaPosizioniDebitorieBancaSondrio(DataAccess conn, DataSet ds,
			PartnerConfig pConf)
		{
			var errors = new List<string>();
			var Curr = ds.Tables["flussocrediti"]._First();
			object idflusso = Curr["idflusso"];

			//// Fa selezionare la cartella per gli avvisi di pagamento analogici all'utente
			////            txtCartellaEsportazione.Text = FaiScegliereCartella();
			//if (string.IsNullOrEmpty(nomeCartella)) {
			//    Errors.Add("Manca il nome della cartella dove memorizzare gli avvisi di pagamento analogici.");
			//    return Errors;
			//}
			//Curr["filename"] = nomeCartella;

			//Application.DoEvents();

			var esercizio = conn.GetEsercizio();
			var dataContabile = conn.GetDataContabile();

			// Parametri del servizio
			var codiceServizio = pConf.Config[0];
			var codiceSottoservizio = pConf.Config[1];
			var url = pConf.Config.Length > 2 ? pConf.Config[2] : null;
			var thumb = pConf.Config.Length > 3 ? pConf.Config[3] : null;

			string errEnte;
			InformazioniEnteGenerico enteGen = getInformazioniEnte(conn, out errEnte);
			if (errEnte != null)
			{
				errors.Add(errEnte);
				return errors;
			}

			// Genera le informazioni sull'ente creditore
			//var ente = new BancaSondrio.InformazioniEnte();
			//ente.Logo = enteGen.Logo;
			//ente.Denominazione = enteGen.Denominazione;
			//ente.CodiceFiscale = enteGen.CodiceFiscale;
			//ente.Indirizzo1 = enteGen.Indirizzo1;
			//ente.Indirizzo2 = enteGen.Indirizzo2;
			//ente.CAP = enteGen.CAP;
			//ente.LocalitÃƒÆ’Ã‚Â  = enteGen.LocalitÃƒÆ’Ã‚Â ;
			//ente.Provincia = enteGen.Provincia;



			// Imposta i dati del partner tecnologica
			var banca = new BancaSondrio.InformazioniBanca()
			{
				CodiceServizio = codiceServizio,
				CodiceSottoservizio = codiceSottoservizio,
				NumeroLista = DateTime.Now.Year.ToString("D13")
			};

			// Costruisce un dizionario di riferimento per i dettagli
			// Ogni entry di reference contiene una riga di flussocreditidetail associata al codice
			//var reference = new Dictionary<string, DataRow>();
			var reference = new Dictionary<string, List<DataRow>>();
			var tFlussocreditidetail = ds.Tables["flussocreditidetail"];
			if (ds.Tables["flussocreditidetail"].Rows.Count == 0)
			{
				errors.Add("Non vi sono posizioni righe in Flussocreditidetail con n. " + idflusso + ".");
				return errors;
			}

			foreach (DataRow r in tFlussocreditidetail.Rows)
			{
				string codice = r["iduniqueformcode"].ToString();
				//string codice = getID_Tenant(r["idflusso"], r["idflusoo"]);
				if (!reference.ContainsKey(codice))
				{
					reference[codice] = new List<DataRow>();
				}

				reference[codice].Add(r);
			}


			// Costruisce l'elenco dei dettagli da esportare
			var tPosizioniDebitorie = conn.CallSP("exp_posizionidebitoriebsondrio", new[] { Curr["idflusso"], esercizio })
				.Tables[0];
			if (tPosizioniDebitorie.Rows.Count == 0)
			{
				errors.Add("Non vi sono posizioni debitorie da inviare.");
				return errors;
			}

			CQueryHelper qhc = new CQueryHelper();
			if (tPosizioniDebitorie.Select(qhc.IsNull("scadenza")).Length > 0)
			{
				errors.Add("Ci sono posizioni debitorie senza scadenza");
				return errors;
			}

			// Costruisce gli avvisi da inviare al WebService
			var avvisi = new Dictionary<int, BancaSondrio.AcquisizioneAvviso>();
			foreach (DataRow r in tPosizioniDebitorie.Rows)
			{
				var idreg = Convert.ToInt32(r["idreg"]);
				string causale = cleanLineFeed(r["causale"].ToString());

				//string note = cleanLineFeed(r["note"].ToString());

				var pagamento = new BancaSondrio.InformazioniPagamento
				{
					IdDisposizione = r["iduniqueformcode"].ToString(),
					//IdDisposizione = getID_Tenant(r["idflusso"], r["idflusso"]),
					CausaleBollettino = causale,
					Importo = Convert.ToDecimal(r["importo"]),
					AnnoRiferimento = esercizio.ToString(),
					//Dato OBBLIGATORIO.Come attualmente per il MAV,la data scadenza non comporta nessun annullo e nessuna impagabilitÃƒÆ’Ã‚Â .
					//Come da ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œregolamentoÃƒÂ¢Ã¢â€šÂ¬Ã‚Â ateneo, se lo studente pagherÃƒÆ’Ã‚Â  oltre la scadenza, si troverÃƒÆ’Ã‚Â  una MORA.
					Scadenza = noNullDate(r["scadenza"], DateTime.MaxValue),
					CausaleRPT = new BancaSondrio.Causale
					{
						CausaleVersamento = maxLen(causale, 140)
					}
				};



				//var note = r["note"].ToString().Replace("&#x0D;", "\r");
				// Il webservice della Banca di Sondrio richiede o i dati di riscossione oppure
				// la causale per la richiesta di pagamento telematico (RPT).
				//var spezzoni = note.Split('\r');
				//if (spezzoni.Length == 1) {
				//    pagamento.CausaleRPT = new BancaSondrio.Causale() {
				//        CausaleVersamento = maxLen(r["causale"].ToString(), 140)
				//    };
				//}
				//else {
				//    pagamento.CausaleRPT = new Causale();
				//    pagamento.CausaleRPT.SpezzoniCausaleVersamento = new List<SpezzoneCausale>();
				//    foreach (string s in spezzoni)
				//        pagamento.CausaleRPT.SpezzoniCausaleVersamento.Add(
				//            new SpezzoneCausale() {CausaleVersamento = s});                                
				//}

				BancaSondrio.AcquisizioneAvviso avviso;
				if (!avvisi.TryGetValue(idreg, out avviso))
				{
					string email = DBNull.Value.Equals(r["email"]) ? null : firstEmail(r["email"].ToString());
					var debitore = new BancaSondrio.InformazioniDebitore()
					{
						CodiceDebitore = idreg.ToString(),
						RagioneSociale = DBNull.Value.Equals(r["anagrafica"]) ? null : r["anagrafica"].ToString(),
						CodiceFiscale = DBNull.Value.Equals(r["codice"]) ? null : r["codice"].ToString(),
						Indirizzo = DBNull.Value.Equals(r["indirizzo"]) ? null : r["indirizzo"].ToString(),
						CAP = DBNull.Value.Equals(r["cap"]) ? null : r["cap"].ToString(),
						LocalitÃƒÆ’Ã‚Â  = DBNull.Value.Equals(r["citta"]) ? null : r["citta"].ToString(),
						Provincia = DBNull.Value.Equals(r["provincia"]) ? null : r["provincia"].ToString(),
						Email = string.IsNullOrEmpty(email) ? null : email,
						PEC = DBNull.Value.Equals(r["pec"]) ? null : r["pec"].ToString()
					};

					avviso = new BancaSondrio.AcquisizioneAvviso()
					{
						Banca = banca,
						Debitore = debitore,
						Pagamenti = new List<BancaSondrio.InformazioniPagamento>()
					};

					avvisi.Add(idreg, avviso);
				}

				pagamento.Progressivo = (avviso.Pagamenti.Count + 1).ToString();

				avviso.Pagamenti.Add(pagamento);
			}

			var servizio = BancaSondrio.Servizio.Create(url, thumb);

			var dataInvio = DateTime.Now;
			var bollettini = new List<string>();

			// Invia gli avvisi al WebService e genera i bollettini
			foreach (var idreg in avvisi.Keys)
			{
				var avviso = avvisi[idreg];
				//Serve per identificare UNIVOCAMENTE la richiesta di generazione per evitare generazioni improprie
				// (multiple dovute a reload, click dallÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢utente, ecc). A paritÃƒÆ’Ã‚Â  di Id Transazione, le richieste successive alla prima verranno 
				// RIFIUTATE (esito KO)
				var idTransazione = string.Format("{0:yyMMdd}-{0:HHmmss}-{1:D11}", dataInvio, idreg);

				// Prepara il corpo del messaggio (pagamento) da inviare al WebSerevice
				var body = new BancaSondrio.InviaPagamentoRequestBody()
				{
					IdTransazione = idTransazione,
					CodiceServizio = banca.CodiceServizio,
					CodiceSottoservizio = banca.CodiceSottoservizio,
					Avviso = avviso
				};

				// Tenta l'invio del messaggio utilizzando il WebService
				BancaSondrio.RicevutaAcquisizioneAvviso ricevuta;
				try
				{
					var request = new BancaSondrio.InviaPagamentoRequest(body);

					var response = servizio.InviaPagamento(request);
					if (response?.body != null && response.body.Messaggio.Equals("OK"))
					{
						ricevuta = response.body.Ricevuta;
					}
					else
					{
						errors.Add(
							$"Nell'invio di flusso {idflusso} anagrafica {avviso.Debitore.CodiceFiscale} {response?.body?.Messaggio}");
						continue;
					}
				}
				catch (Exception ex)
				{
					errors.Add(QueryCreator.GetErrorString(ex));

					continue;
				}

				foreach (var esito in ricevuta.Esito)
				{
					if (esito.NonAcquisito != null)
					{
						var errore = string.IsNullOrEmpty(esito.NonAcquisito.DescrizioneErrore)
							? $"Errore di trasmissione (codice errore {esito.NonAcquisito.CodiceErrore})."
							: esito.NonAcquisito.DescrizioneErrore;

						errors.Add(errore);
						continue;
					}

					var pagamento = ricevuta.Pagamenti.Find(item => item.Progressivo == esito.Acquisito.Progressivo);

					//var r = reference[pagamento.IdDisposizione];
					//r["iuv"] = esito.Acquisito.IUV;
					//r["barcodevalue"] = esito.Acquisito.ValoreCodiceBarre;
					//r["barcodeimage"] = esito.Acquisito.CodiceBarre;
					//r["qrcodevalue"] = esito.Acquisito.ValoreCodiceQR;
					//r["qrcodeimage"] = esito.Acquisito.CodiceQR;
					//r["codiceavviso"] = esito.Acquisito.CodiceBollettino;
					foreach (var rDs in reference[pagamento.IdDisposizione])
					{
						rDs["iuv"] = esito.Acquisito.IUV;
						rDs["barcodevalue"] = esito.Acquisito.ValoreCodiceBarre;
						rDs["barcodeimage"] = esito.Acquisito.CodiceBarre;
						rDs["qrcodevalue"] = esito.Acquisito.ValoreCodiceQR;
						rDs["qrcodeimage"] = esito.Acquisito.CodiceQR;
						rDs["codiceavviso"] = esito.Acquisito.CodiceBollettino;
					}

				}
			}

			// Imposta il flusso come trasmesso solo se non ci sono stati errori
			if (errors.Count == 0)
			{
				Curr["istransmitted"] = "S";
			}

			var dispatcher = new Meta_EasyDispatcher(conn);
			var metaFlussoCreditiDeatil = dispatcher.Get("flussocreditidetail");
			metaFlussoCreditiDeatil.ComputeRowsAs(tFlussocreditidetail, "posting");

			//Meta.SaveFormData();
			PostData post = new Easy_PostData_NoBL();
			post.initClass(ds, conn);
			if (!post.DO_POST())
			{
				errors.Add("Errore nel salvataggio dei dati");
				return errors;
			}

			return errors;
			//MetaData metaFlussoCreditiDetail = MetaData.GetMetaData(this, "flussocreditidetail");
			//metaFlussoCreditiDetail.ComputeRowsAs(DS.flussocreditidetail_ca, "posting");
			//metaFlussoCreditiDetail.ComputeRowsAs(DS.flussocreditidetail_fatt, "posting");

			//Meta.SaveFormData();

			//if (errori.Count > 0) {
			//    FrmErrori.MostraErrori(this, errori);
			//}
			//else {
			//    MetaFactory.factory.getSingleton<IMessageShower>().Show("Il flusso ÃƒÆ’Ã‚Â¨ stato inviato correttamente", "Avviso");
			//}
		}

		static bSondrio.InformazioniPagamento[] appendArray(bSondrio.InformazioniPagamento[] input,
			bSondrio.InformazioniPagamento nuovo)
		{
			if (input == null)
			{
				return new[] { nuovo };
			}

			var r = new bSondrio.InformazioniPagamento[input.Length + 1];
			Array.Copy(input, r, input.Length);
			r[input.Length - 1] = nuovo;
			return r;
		}

		/// <summary>
		/// Invia le posizioni creditorie tramite il web Service di banca sondrio  e poi le mail ai singoli percipienti
		/// Lo IUV ÃƒÆ’Ã‚Â¨ immediatamente restituito e valorizzato
		/// </summary>
		private static List<string> caricaPosizioniDebitorieBancaSondrio1_1(DataAccess conn, DataSet ds,
			PartnerConfig pConf)
		{
			var errors = new List<string>();
			var Curr = ds.Tables["flussocrediti"]._First();
			object idflusso = Curr["idflusso"];

			//// Fa selezionare la cartella per gli avvisi di pagamento analogici all'utente
			////            txtCartellaEsportazione.Text = FaiScegliereCartella();
			//if (string.IsNullOrEmpty(nomeCartella)) {
			//    Errors.Add("Manca il nome della cartella dove memorizzare gli avvisi di pagamento analogici.");
			//    return Errors;
			//}
			//Curr["filename"] = nomeCartella;

			//Application.DoEvents();

			var esercizio = conn.GetEsercizio();
			var dataContabile = conn.GetDataContabile();

			// Parametri del servizio
			var codiceServizio = pConf.Config[0];
			var codiceSottoservizio = pConf.Config[1];
			var url = pConf.Config.Length > 2 ? pConf.Config[2] : null;
			var thumb = pConf.Config.Length > 3 ? pConf.Config[3] : null;
			var certName = pConf.Config.Length > 4 ? pConf.Config[4] : null;

			string errEnte;
			InformazioniEnteGenerico enteGen = getInformazioniEnte(conn, out errEnte);
			if (errEnte != null)
			{
				errors.Add(errEnte);
				return errors;
			}


			// Imposta i dati del partner tecnologica
			var banca = new bSondrio.InformazioniBanca()
			{
				codice_servizio = codiceServizio,
				codice_sottoservizio = codiceSottoservizio,
				numero_lista = DateTime.Now.Year.ToString("D13")
			};

			// Costruisce un dizionario di riferimento per i dettagli
			// Ogni entry di reference contiene una riga di flussocreditidetail associata al codice
			//var reference = new Dictionary<string, DataRow>();
			var reference = new Dictionary<string, List<DataRow>>();
			var tFlussocreditidetail = ds.Tables["flussocreditidetail"];
			if (ds.Tables["flussocreditidetail"].Rows.Count == 0)
			{
				errors.Add("Non vi sono posizioni righe in Flussocreditidetail con n. " + idflusso + ".");
				return errors;
			}

			foreach (DataRow r in tFlussocreditidetail.Rows)
			{
				string codice = r["iduniqueformcode"].ToString();
				//string codice = getID_Tenant(r["idflusso"], r["idflusoo"]);
				if (!reference.ContainsKey(codice))
				{
					reference[codice] = new List<DataRow>();
				}

				reference[codice].Add(r);
			}

			// Costruisce l'elenco dei dettagli da esportare
			var tPosizioniDebitorie = conn.CallSP("exp_posizionidebitoriebsondrio", new[] { Curr["idflusso"], esercizio })
				.Tables[0];
			if (tPosizioniDebitorie.Rows.Count == 0)
			{
				errors.Add("Non vi sono posizioni debitorie da inviare.");
				return errors;
			}

			CQueryHelper qhc = new CQueryHelper();
			if (tPosizioniDebitorie.Select(qhc.IsNull("scadenza")).Length > 0)
			{
				errors.Add("Ci sono posizioni debitorie senza scadenza");
				return errors;
			}

			// Costruisce gli avvisi da inviare al WebService
			var avvisi = new Dictionary<int, bSondrio.IUVOnlineCreateRequestData>();

			foreach (DataRow r in tPosizioniDebitorie.Rows)
			{
				var idreg = Convert.ToInt32(r["idreg"]);

				string causale = cleanLineFeed(r["causale"].ToString());

				//string note = cleanLineFeed(r["note"].ToString());

				//                            
				var causaleRpt = new bSondrio.CausaleRPT();
				//Essendo l'invio del rendiconto a l.fissa                 
				causaleRpt.Items = new[] { maxLen(causale, 140) };

				var pagamento = new bSondrio.InformazioniPagamento
				{
					identificativo_disposizione = r["iduniqueformcode"].ToString(),
					//IdDisposizione = getID_Tenant(r["idflusso"], r["idflusso"]),
					causale_bollettino = causale,
					importo = Convert.ToDecimal(r["importo"]),
					anno_riferimento = esercizio.ToString(),
					//Dato OBBLIGATORIO.Come attualmente per il MAV,la data scadenza non comporta nessun annullo e nessuna impagabilitÃƒÆ’Ã‚Â .
					//Come da ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œregolamentoÃƒÂ¢Ã¢â€šÂ¬Ã‚Â ateneo, se lo studente pagherÃƒÆ’Ã‚Â  oltre la scadenza, si troverÃƒÆ’Ã‚Â  una MORA.
					scadenza = noNullDate(r["scadenza"], DateTime.MaxValue),
					causale_RPT = causaleRpt
				};
				if (r.Table.Columns.Contains("codicetassonomia") && (r["codicetassonomia"] != DBNull.Value))
				{
					bSondrio.DatiSpecificiRiscossioneTipo_contabilita tipoCont =
						bSondrio.DatiSpecificiRiscossioneTipo_contabilita.Item9;
					switch (r["codicetassonomia"].ToString().Substring(0, 2))
					{
						case "9/":
							tipoCont = bSondrio.DatiSpecificiRiscossioneTipo_contabilita.Item9;
							break;
						case "0/":
							tipoCont = bSondrio.DatiSpecificiRiscossioneTipo_contabilita.Item0;
							break;
						case "1/":
							tipoCont = bSondrio.DatiSpecificiRiscossioneTipo_contabilita.Item1;
							break;
						case "2/":
							tipoCont = bSondrio.DatiSpecificiRiscossioneTipo_contabilita.Item2;
							break;
					}

					pagamento.dati_specifici_riscossione = new bSondrio.DatiSpecificiRiscossione()
					{
						// 0 Capitolo e articolo di Entrata del Bilancio dello Stato 1 Numero della contabilitÃƒÆ’Ã‚Â  speciale 2 Codice SIOPE 9 Altro codice ad uso dellÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢Ente Creditore
						tipo_contabilita = tipoCont,
						codice_contabilita = r["codicetassonomia"].ToString().Substring(2) //salta 9/
					};
				}



				bSondrio.IUVOnlineCreateRequestData avviso;
				if (!avvisi.TryGetValue(idreg, out avviso))
				{
					string email = DBNull.Value.Equals(r["email"]) ? null : firstEmail(r["email"].ToString());
					var debitore = new bSondrio.InformazioniDebitore()
					{
						codice_debitore = idreg.ToString(),
						anagrafica_debitore = DBNull.Value.Equals(r["anagrafica"])
							? null
							: maxLen(r["anagrafica"].ToString(), 70),
						codice_fiscale_debitore = DBNull.Value.Equals(r["codice"]) ? null : r["codice"].ToString(),
						indirizzo_debitore = DBNull.Value.Equals(r["indirizzo"])
							? null
							: maxLen(r["indirizzo"].ToString(), 70),
						cap_debitore = DBNull.Value.Equals(r["cap"]) ? null : maxLen(r["cap"].ToString(), 16),
						localita_debitore = DBNull.Value.Equals(r["citta"]) ? null : maxLen(r["citta"].ToString(), 35),
						provincia_debitore = DBNull.Value.Equals(r["provincia"])
							? null
							: maxLen(r["provincia"].ToString(), 35),
						email_debitore = string.IsNullOrEmpty(email) ? null : maxLen(email, 256),
						pec_debitore = DBNull.Value.Equals(r["pec"]) ? null : maxLen(r["pec"].ToString(), 256)
					};

					avviso = new bSondrio.IUVOnlineCreateRequestData()
					{
						informazioni_banca = banca,
						informazioni_debitore = debitore
					};

					avvisi.Add(idreg, avviso);
				}

				avviso.informazioni_pagamento = appendArray(avviso.informazioni_pagamento, pagamento);
				pagamento.progressivo = (avviso.informazioni_pagamento.Length).ToString();
				avviso.numero_disposizioni = avviso.informazioni_pagamento.Count().ToString();


			}

			bool test = url.Contains("wsdev");
			string fileCert = test ? "popso_wsdev.cer" : certName;
			if (test) thumb = "d34e1f8c01a911110145142dbb8fb32358b8a725";
			if (!checkCertificatiBancaSondrio(thumb, fileCert))
			{
				errors.Add("Impossibile installare i certificati di banca sondrio");
				return errors;
			}

			var servizio = BancaSondrio.Servizio1_1.Create(url, thumb);

			var dataInvio = DateTime.Now;
			var bollettini = new List<string>();

			// Invia gli avvisi al WebService e genera i bollettini
			foreach (var idreg in avvisi.Keys)
			{
				var avviso = avvisi[idreg];
				//Serve per identificare UNIVOCAMENTE la richiesta di generazione per evitare generazioni improprie
				// (multiple dovute a reload, click dallÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢utente, ecc). A paritÃƒÆ’Ã‚Â  di Id Transazione, le richieste successive alla prima verranno 
				// RIFIUTATE (esito KO)
				var idTransazione = string.Format("{0:yyMMdd}-{0:HHmmss}-{1:D11}", dataInvio, idreg);

				var reqData = new bSondrio.IUVOnlineCreateRequest()
				{
					testata = new bSondrio.Testata()
					{
						id_transazione = idTransazione,
						codice_servizio = banca.codice_servizio,
						codice_sottoservizio = banca.codice_sottoservizio,
					},
					IUVOnlineCreateRequestData = avviso
				};
				// Prepara il corpo del messaggio (pagamento) da inviare al WebSerevice
				var body = new bSondrio.IUVOnlineCreateRequest1()
				{
					IUVOnlineCreateRequest = reqData
				};

				// Tenta l'invio del messaggio utilizzando il WebService
				bSondrio.IUVOnlineCreateResponseData ricevuta = null;
				try
				{
					var response = servizio.IUVOnlineCreate(body);

					ricevuta = response.IUVOnlineCreateResponse.IUVOnlineCreateResponseData;

				}
				catch (FaultException<bSondrio.ApplicationFault> aF)
				{
					errors.Add(
						$"Nell'invio di flusso {idflusso} anagrafica {avviso.informazioni_debitore.codice_fiscale_debitore} {aF.Detail} {aF.Message}");
					continue;
				}
				catch (FaultException<bSondrio.SystemFault> b)
				{
					errors.Add(
						$"Nell'invio di flusso {idflusso} anagrafica {avviso.informazioni_debitore.codice_fiscale_debitore} {b.ToString()}");
					continue;
				}
				// Catch unrecognized faults. This handler receives exceptions thrown by WCF services when ServiceDebugBehavior.IncludeExceptionDetailInFaults 
				// is set to true.
				catch (FaultException faultEx)
				{
					errors.Add(
						$"Nell'invio di flusso {idflusso} anagrafica {avviso.informazioni_debitore.codice_fiscale_debitore}\nC'ÃƒÆ’Ã‚Â¨ stato un  problema ignoto:\n {faultEx.Message}");
					continue;
				}
				// Standard communication fault handler.
				catch (CommunicationException commProblem)
				{
					errors.Add(
						$"Nell'invio di flusso {idflusso} anagrafica {avviso.informazioni_debitore.codice_fiscale_debitore}\nC'ÃƒÆ’Ã‚Â¨ stato un  problema di comunicazione:\n {commProblem}");
					continue;
				}

				catch (Exception ex)
				{
					errors.Add(
						$"Nell'invio di flusso {idflusso} anagrafica {avviso.informazioni_debitore.codice_fiscale_debitore} {ex.ToString()}");
					continue;
				}

				foreach (var esito in ricevuta.esito)
				{
					if (esito.acquisito == null)
					{

						//errors.Add(errore);
						continue;
					}

					var pagamento = ricevuta.informazioni_pagamento.ToList()
						.Find(item => item.progressivo == esito.acquisito.progressivo_richiesta);

					//var r = reference[pagamento.IdDisposizione];
					//r["iuv"] = esito.Acquisito.IUV;
					//r["barcodevalue"] = esito.Acquisito.ValoreCodiceBarre;
					//r["barcodeimage"] = esito.Acquisito.CodiceBarre;
					//r["qrcodevalue"] = esito.Acquisito.ValoreCodiceQR;
					//r["qrcodeimage"] = esito.Acquisito.CodiceQR;
					//r["codiceavviso"] = esito.Acquisito.CodiceBollettino;
					foreach (var rDs in reference[pagamento.identificativo_disposizione])
					{
						rDs["iuv"] = esito.acquisito.codice_identificativo_bollettino.Substring(3); //servirebbe lo iuv
						rDs["barcodevalue"] = esito.acquisito.valore_codice_barre;
						rDs["barcodeimage"] = esito.acquisito.immagine_codice_barre;
						rDs["qrcodevalue"] = esito.acquisito.valore_QR_code;
						rDs["qrcodeimage"] = esito.acquisito.immagine_QR_code;
						rDs["codiceavviso"] = esito.acquisito.codice_identificativo_bollettino;
					}

				}
			}

			// Imposta il flusso come trasmesso solo se non ci sono stati errori
			if (errors.Count == 0)
			{
				Curr["istransmitted"] = "S";
			}

			var dispatcher = new Meta_EasyDispatcher(conn);
			var metaFlussoCreditiDeatil = dispatcher.Get("flussocreditidetail");
			metaFlussoCreditiDeatil.ComputeRowsAs(tFlussocreditidetail, "posting");

			//Meta.SaveFormData();
			PostData post = new Easy_PostData_NoBL();
			post.initClass(ds, conn);
			if (!post.DO_POST())
			{
				errors.Add("Errore nel salvataggio dei dati");
				return errors;
			}

			return errors;
			//MetaData metaFlussoCreditiDetail = MetaData.GetMetaData(this, "flussocreditidetail");
			//metaFlussoCreditiDetail.ComputeRowsAs(DS.flussocreditidetail_ca, "posting");
			//metaFlussoCreditiDetail.ComputeRowsAs(DS.flussocreditidetail_fatt, "posting");

			//Meta.SaveFormData();

			//if (errori.Count > 0) {
			//    FrmErrori.MostraErrori(this, errori);
			//}
			//else {
			//    MetaFactory.factory.getSingleton<IMessageShower>().Show("Il flusso ÃƒÆ’Ã‚Â¨ stato inviato correttamente", "Avviso");
			//}
		}

		private static List<string> attivaCreditoBancaSondrio(DataAccess conn, PartnerConfig pConf,
			string iuv, string callBack, out string url)
		{
			//errore = null;

			//https://pagopadev.popso.it/paytas-popso-gateway/PaymentMediatorSer

			string
				endpoint = getUrlServizioPagamento(
					conn); // "https://pagopadev.popso.it/paytas-popso-gateway/PaymentMediatorServlet";

			var Errors = new List<string>();

			var esercizio = conn.GetEsercizio();
			var dataContabile = conn.GetDataContabile();

			// Parametri del servizio
			var codiceServizio = pConf.Config[0];
			var codiceSottoservizio = pConf.Config[1];
			var urlbps = pConf.Config.Length > 2 ? pConf.Config[2] : null;
			var thumb = pConf.Config.Length > 3 ? pConf.Config[3] : null;


			url = null;

			var d = conn.CallSP("exp_posizionidebitorie_iuv", new object[] { iuv });
			if (d == null || d.Tables.Count == 0 || d.Tables[0].Rows.Count == 0)
			{
				Errors.Add($"IUV non trovato");
				return Errors;
			}

			var r = d.Tables[0].Rows[0];

			var destinatario = getDestinatario(r); //GetDestinatario(debitore)

			var codiceAvviso = r["codiceavviso"].ToString();

			// Imposta i dati del partner tecnologic0
			object idreg = r["idreg"];
			// Attiva il pagamento immediato per lo IUV in ingresso
			/*
			https://pagopadev.popso.it/paytas-popso-gateway/PaymentMediatorServlet?
			id_transazione =1234567890
			  &servizio=3000200
			  &numero_avviso=001901000000001666
			  &autenticazione=OTH
			  &urlReturn=http://www.popso.it
			  &urlBack=http://www.google.it
			  &mac=b55121e43b2cc4b2f34f9ed6fa95c5d9
			*/
			/*
			    * 3	Reindirizzamento da portale Ente Creditore a Banca Popolare di Sondrio
			   3.1	Parametri di input

			   La tabella riportata sotto elenca tutti i campi necessari per realizzare il messaggio per invocare il sistema di pagamento secondo il modello 1.

			   Parametro	Descrizione	O/F	Formato	Vincoli
			   id_transazione	codice di identificazione della transazione composto da caratteri alfanumerici. Il codice devÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢essere univoco per ogni richiesta di pagamento; id_transazione riferiti a IUV ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œduplicatiÃƒÂ¢Ã¢â€šÂ¬Ã‚Â (giÃƒÆ’Ã‚Â  utilizzati per operazioni precedenti) comporteranno un rifiuto dellÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢operazione	O	Alfanumerico	Min 2 Max 30 caratteri.  
			   Solo caratteri ASCII (A-Z,a-z,0-9) 
			   servizio	Codice univoco assegnato allÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ente da BPS	O	Numerico	7 Cifre con ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œ0ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â di riempimento a sinistra
			   numero_avviso	Rappresenta il codice avviso definito da AgID (18 cifre), non solo lo IUV	O	Numerico	18 cifre
			   autenticazione	ModalitÃƒÆ’Ã‚Â  di autenticazione sul portale dellÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢Ente, da parte dellÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢Utente. EÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ un parametro che va indicata nella RPT (richiesta di pagamento telematico) da inviare al PSP prescelto per il pagamento. Nel caso di N/A non vengono mostrati i dati relativi allÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢avviso	O	Alfanumerico	Valori utilizzabili
			   ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â¢	CNS= CIE/CNS utilizzata per autenticazione portale ente
			   ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â¢	USR= accesso tramite utenza e password
			   ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â¢	OTH= Altro modalitÃƒÆ’Ã‚Â  di autenticazione
			   ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â¢	N/A= Nessuna modalitÃƒÆ’Ã‚Â  di autenticazione
			   urlReturn	URL dellÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢Ente verso il quale il partner tecnologico BPS indirizza lÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢utente al completamento della transazione passando, in POST, i parametri di risposta con il risultato della transazione effettuata dallÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢utente sul PSP prescelto (esito OK, KO, PO e DIFFERITO)	F	Alfanumerico	Max 200 caratteri
			   urlBack	URL dellÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ente verso il quale il partner tecnologico BPS indirizza lÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢utente nel caso in cui lo stesso annulli lÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢operazione	F	Alfanumerico	Max 200 caratteri
			   mac	Message Code Authentication. Campo di firma della transazione. Per il calcolo si vedano le indicazioni in calce a questo capitolo: CALCOLO MAC (paragrafo 3.1.1)	O	Alfanumerico 	Lunghezza fissa a 32 caratteri
		   */
			// Composizione  del messaggio (pagamento) da inviare al WebService
			//Il campo idTransazione serve per identificare UNIVOCAMENTE la richiesta di generazione per evitare generazioni improprie
			//(<valore id_transazione><valore servizio><valore autenticazione><valore stringa_segreta>)

			//Per quanto riguarda le costanti, sempre riferite allÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ambiente di test, indichiamo le seguenti informazioni
			//URL al quale passare i parametri in POST: https://pagopadev.popso.it/paytas-popso-gateway/PaymentMediatorServlet
			//servizio->ÃƒÆ’Ã‚Â¨ lo stesso valore passato al WS per la generazione dello IUV
			//bollettino->ÃƒÆ’Ã‚Â¨ il codice avviso(es. 0010000000000123) precedentemente generato
			//chiave segreta per calcolo MAC-> ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œsecretÃƒÂ¢Ã¢â€šÂ¬Ã‚Â

			var idTransazione = string.Format("{0:yyMMdd}-{0:HHmmss}-{1:D11}", dataContabile, idreg);
			string stringa_segreta = "secret";
			string mac = GetMessageCodeAuthentication(idTransazione, codiceServizio, "OTH", stringa_segreta); //
																											  //string mac = "d7e5446663bc02ac72c0f09749b523e5";

			string addr = endpoint + "?id_transazione=" + idTransazione + "&servizio=" + codiceServizio +
						  "&numero_avviso=" + codiceAvviso + "&autenticazione=" + "OTH" +
						  "&urlReturn=" + "http://www.popso.it" + "&urlBack=" + "http://www.temposrl.it" +
						  "&mac=" + mac;
			//Parametri per Ambiente di test
			string macTest = GetMessageCodeAuthentication(idTransazione, "1234567", "N/A", stringa_segreta);
			string addrTest = endpoint + "?id_transazione=" + idTransazione + "&servizio=" + "1234567" +
							  "&numero_avviso=" + "001000000000053517" + "&autenticazione=" + "N/A" +
							  "&urlReturn=" + "http://www.popso.it" + "&urlBack=" + "http://www.temposrl.it" +
							  "&mac=" + macTest;

			//Errors.Add(addr);
			url = addr;
			//System.Diagnostics.Process.Start(addr);      
			return Errors;
		}

		private static DateTime noNullDate(object o, DateTime defaultDate)
		{
			if (o == null || o == DBNull.Value)
				return defaultDate.Date;
			try
			{
				var d = Convert.ToDateTime(o).Date;
				if (d.CompareTo(DateTime.Now.Date) < 0) d = DateTime.Now;
				return d.Date;
			}
			catch
			{
				return defaultDate.Date;
			}
		}

		private static string GetMessageCodeAuthentication(string id_transazione, string valore_servizio,
			string valore_autenticazione, string stringa_segreta)
		{
			/*
			 * 4.1.1	Calcolo MAC per parametri in output
			Il mac sarÃƒÆ’Ã‚Â  calcolato applicando HASH MD5 alla stringa ottenuta dalla concatenazione dei valori dei seguenti campi in input, senza nessun separatore o terminatore di stringa:
			ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â¢	id_transazione
			ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â¢	esito
			ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â¢	stringa_segreta (Campo comunicato allÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ente creditore da parte di Banca Popolare di Sondrio)

			mac = HASH MD5(<valore id_transazione><valore servizio><valore autenticazione><valore stringa_segreta>

			Esempio calcolo mac:
			stringa = ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œ123123132131321OKstringasegretaÃƒÂ¢Ã¢â€šÂ¬Ã‚Â
			calcolo = HASH MD5(123123132131321OKstringasegreta)
			mac ottenuto = da8b8b3f0e3495abd986e7ba7336b7cc
			 * */
			return CreateMD5(id_transazione + valore_servizio + valore_autenticazione + stringa_segreta);
		}

		private static string CreateMD5(string input)
		{
			// Use input string to calculate MD5 hash
			using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
			{
				byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
				byte[] hashBytes = md5.ComputeHash(inputBytes);

				// Convert the byte array to hexadecimal string
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					sb.Append(hashBytes[i].ToString("x2"));
				}

				return sb.ToString();
			}
		}


		//static string GetMd5Hash(MD5 md5Hash, string input) {

		//    // Convert the input string to a byte array and compute the hash.
		//    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

		//    // Create a new Stringbuilder to collect the bytes
		//    // and create a string.
		//    StringBuilder sBuilder = new StringBuilder();

		//    // Loop through each byte of the hashed data 
		//    // and format each one as a hexadecimal string.
		//    for (int i = 0; i < data.Length; i++) {
		//        sBuilder.Append(data[i].ToString("x2"));
		//    }

		//    // Return the hexadecimal string.
		//    return sBuilder.ToString();
		//}

		private static List<string>
			caricaPosizioniDebitorieUnicredit(DataAccess conn, DataSet ds, PartnerConfig pConf)
		{
			object idflusso = ds.Tables["flussocrediti"].Rows[0]["idflusso"].ToString();
			var errors = new List<string>();
			var esercizio = conn.GetEsercizio();
			var dataContabile = conn.GetDataContabile();

			// Parametri del servizio (utente soap/password soap/codice del servizio/aux digit/app code/url/gln/isfortest/urlSoap)

			var utente = pConf.Config[0];
			var password = pConf.Config[1];
			string url = null;
			int codiceServizio;

			if (!int.TryParse(pConf.Config[2], out codiceServizio))
			{
				errors.Add("CodiceServizio di partner_config non valido.");
				return errors;
			}

			int auxdigit; //puÃƒÆ’Ã‚Â² valere 0 (IUV da 15 cifre) o 3 (IUV da 17 cifre, include anche l'app.code)
			if (!int.TryParse(pConf.Config[3], out auxdigit))
			{
				errors.Add("auxdigit di partner_config non valido.");
				return errors;
			}

			int appcode; //2 cifre, entra in gioco nella composizione del codice_identificativo_presentazione
			if (!int.TryParse(pConf.Config[4], out appcode))
			{
				errors.Add("appcode di partner_config non valido.");
				return errors;
			}

			if (pConf.Config.Length > 5)
			{
				url = pConf.Config[5];
			}

			var gln = "0000000000000"; //13 cifre
			if (pConf.Config.Length > 6)
			{
				gln = pConf.Config[6];
			}

			var isfortest = false;
			if (pConf.Config.Length > 7)
			{
				if (pConf.Config[7].ToUpperInvariant() == "S") isfortest = true;
				//parametro aggiuntivo che consente di "auto generare" gli iuv per gli ambienti di test 
			}

			QueryHelper qhc = conn.GetQueryHelper();

			// Estrae dal DB il codice fiscale dell'ente            
			//var identificativoEnte = Conn.readValue("generalreportparameter",
			//        q.eq("idparam", "License_f") & q.nullOrLe("start", dataContabile) & q.nullOrGe("stop", dataContabile),
			//        "paramvalue");
			var identificativoEnte = conn.DO_READ_VALUE("generalreportparameter", qhc.AppAnd(
				qhc.CmpEq("idparam", "License_f"), qhc.NullOrLe("start", dataContabile), qhc.NullOrGe("stop", dataContabile)
			), "paramvalue");



			if (identificativoEnte == null || identificativoEnte == DBNull.Value)
			{
				errors.Add("identificativoEnte di Generalreportparameter non valido.");
				return errors;
			}

			// Costruisce l'elenco dei dettagli da esportare
			var tPosizioniDebitorieTuttiServizi = conn.CallSP("exp_posizionidebitoriebsondrio", new object[] { idflusso, esercizio })
				.Tables[0];

			q filter = null;
			//if (tPosizioniDebitorieTuttiServizi.Columns.Contains("codice_servizio")) {
			//	if (pConf.codice_servizio == null) {
			//		filter = q.isNull("codice_servizio");
			//	}
			//	else {
			//		filter = q.eq("codice_servizio",pConf.codice_servizio);
			//	}
			//}

			var righeDaConsiderare = tPosizioniDebitorieTuttiServizi._Filter(filter);

			if (righeDaConsiderare.Length == 0)
			{
				if (pConf.codice_servizio == null) errors.Add("Non vi sono posizioni debitorie da inviare.");
				return errors;
			}

			if (righeDaConsiderare._Filter(q.isNull("scadenza")).ToArray().Length > 0)
			{
				errors.Add("Ci sono posizioni debitorie senza scadenza");
				return errors;
			}


			var servizio = UnicreditService.Servizio.Create(utente, password, url);
			var header = new UnicreditService.gestorePosizioniHeader()
			{
				user = utente,
				password = password
			};

			// Costruisce un dizionario di riferimento per i dettagli
			// Ogni entry di reference contiene una riga di flussocreditidetail associata al codice
			var reference = new Dictionary<string, List<DataRow>>();
			DataTable
				tFlussocreditidetail =
					ds.Tables[
						"flussocreditidetail"]; // Conn.RUN_SELECT("flussocreditidetail", "*", null, QHS.CmpEq("idflusso", idflusso), null, false);
			if (ds.Tables["flussocreditidetail"].Rows.Count == 0)
			{
				errors.Add("Non vi sono posizioni righe in Flussocreditidetail con n. " + idflusso + ".");
				return errors;
			}

			foreach (DataRow r in tFlussocreditidetail.Rows)
			{
				string codice = r["iduniqueformcode"].ToString(); //getID_Tenant(r["idflusso"], r["iddetail"]); ;
				if (!reference.ContainsKey(codice))
				{
					reference[codice] = new List<DataRow>();
				}

				reference[codice].Add(r);
			}


			foreach (DataRow r in righeDaConsiderare)
			{
				//string progressivo = r["idflusso"].ToString().PadLeft(6, '0') + r["iddetail"].ToString().PadLeft(7, '0');
				string progressivo = $"{r["iddisposizione"],13:D13}"; // piÃƒÆ’Ã‚Â¹ preciso di quello commentato
																	  //string.Format("{0,6:D6}{1,7:D7}",CfgFn.GetNoNullInt32(r["idflusso"]), CfgFn.GetNoNullInt32(r["iddetail"]));

				//Serve solo per accedere alla riga in flussocreditidetail, non ÃƒÆ’Ã‚Â¨ trasmesso all'ente
				var idDisposizione = r["iduniqueformcode"].ToString();


				string iuvWithCheck = Utils.IUV.Genera(progressivo, auxdigit, appcode);
				string email = DBNull.Value.Equals(r["email"]) ? null : firstEmail(r["email"].ToString());
				string causale = cleanLineFeed(r["causale"].ToString());

				//errors.Add(
				//		$"progressivo: {progressivo}  + auxdigit: {auxdigit}  + appcode: {auxdigit} restituisce {iuvWithCheck} ");


				//string note = cleanHtmlFeed(r["note"].ToString());

				var input = new UnicreditService.inserimentoPosizioneInputType()
				{
					identificativo_beneficiario = identificativoEnte.ToString(),
					codice_servizio = codiceServizio,

					tipo_riferimento_creditore =
						"G", // Il campo puÃƒÆ’Ã‚Â² assumere i valori G (persona giuridica) ed F (persona fisica). 
							 // ... nella stesura originale il valore del campo imposto ÃƒÆ’Ã‚Â¨ G
							 //tipo_riferimento_creditore = r["tipo"].ToString(), //F persona fisica   G persona  giuridica


					//Codice Riferimento Creditore (codice/identificativo che si riferisce al campo precedente), rappresenta, 
					// in abbinamento con il campo Tipo Riferimento Creditore/PA , la chiave/identificativo univoco 
					// della posizione debitoria sul repository della Piattaforma Incassi 
					// (es Tipo Riferimento Creditore/PA  Fattura 123  - Codice Riferimento Creditore 12358 2017  
					// - Campo univoco ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œFattura 123  12358 2017 ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œ). 
					// La combinazione di questi dati devono essere univoci nellÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ambito di tutti i servizi dellÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ente 
					// presenti su UnicreditGate.
					codice_riferimento_creditore = idDisposizione,

					//Codice IUV della posizione inserita
					// ----------------------------------------------------------------------------------------------
					//identificativo_univoco_versamento = null,                    
					identificativo_univoco_versamento = null,
					// ----------------------------------------------------------------------------------------------
					//RiferimentoCredito1 = string.Format("{0:D35}", r["idflusso"]), // per riferimento in fase d'incasso
					//RiferimentoCredito2 = string.Format("{0:D35}", r["iddetail"]), // per riferimento in fase d'incasso

					// Dato OBBLIGATORIO.Come attualmente per il MAV,
					// la data scadenza non comporta nessun annullo e nessuna impagabilitÃƒÆ’Ã‚Â .Come da ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œregolamentoÃƒÂ¢Ã¢â€šÂ¬Ã‚Â ateneo,
					// se lo studente pagherÃƒÆ’Ã‚Â  oltre la scadenza, si troverÃƒÆ’Ã‚Â  una MORA.
					data_scadenza_pagamento = noNullDate(r["scadenza"], DateTime.Now.Date.AddDays(30)),
					data_scadenza_pagamentoSpecified = true, //se non la imposto a true non viene passato il parametro
					importo = Convert.ToDecimal(r["importo"]),
					causale = causale,

					//Numero Avviso
					//Nel caso in cui la generazione dello IUV avviene ad opera di UniCredit Gate,
					//questo campo ne conterrÃƒÆ’Ã‚Â  il valore generato in automatico.
					// ----------------------------------------------------------------------------------------------
					// codice_identificativo_presentazione = null,
					//La composizione ÃƒÆ’Ã‚Â¨: aux digit (1 carattere ÃƒÂ¢Ã¢â€šÂ¬Ã¢â‚¬Å“ 0/3) + application code (2 caratteri) + numero riferimento (13 caratteri) + check digit (2 caratteri)
					// Le ultime 15 cifre(se aux digit = 0) o 17(se aux digit = 3) sono lo IUV
					codice_identificativo_presentazione = null,
					// ----------------------------------------------------------------------------------------------
					savv = null,

					tipo_id_debitore = DBNull.Value.Equals(r["tipo"]) ? null : r["tipo"].ToString(),
					identificativo_debitore = DBNull.Value.Equals(r["codice"]) ? null : r["codice"].ToString(),
					anagrafica_debitore = DBNull.Value.Equals(r["anagrafica"])
						? null
						: maxLen(r["anagrafica"].ToString(), 50),
					indirizzo_debitore = DBNull.Value.Equals(r["indirizzo"]) ? null : r["indirizzo"].ToString(),
					civico_debitore = null, // civico non disponibile (incluso nell'indirizzo)
					cap_debitore = DBNull.Value.Equals(r["cap"]) ? null : r["cap"].ToString(),
					localita_debitore = DBNull.Value.Equals(r["citta"]) ? null : maxLen(r["citta"].ToString(), 35),
					provincia_debitore = DBNull.Value.Equals(r["provincia"]) ? null : r["provincia"].ToString(),
					nazione_debitore = null, // codice ISO 3166 non disponibile
					email_debitore = string.IsNullOrEmpty(email) ? null : email
				};
				//errors.Add(
				//			$"Nell'invio di flusso {idflusso} anagrafica {r["codice"]}  " +
				//			"input.cap_debitore +" + input.cap_debitore +
				//			"input.anagrafica_debitore +" + input.anagrafica_debitore +
				//			"input.causale +" + input.causale +
				//			"input.civico_debitore +" + input.civico_debitore +
				//			"input.ckey_5 +" + input.ckey_5 +
				//			"input.ckey_6 +" + input.ckey_6 +
				//			"input.codice_identificativo_presentazione +" + input.codice_identificativo_presentazione +
				//			"input.codice_riferimento_creditore +" + input.codice_riferimento_creditore +
				//			"input.codice_servizio +" + input.codice_servizio +
				//			"input.data_scadenza_pagamento +" + input.data_scadenza_pagamento +
				//			"input.email_debitore +" + input.email_debitore +
				//			"input.identificativo_beneficiario +" + input.identificativo_beneficiario +
				//			"input.identificativo_debitore +" + input.identificativo_debitore +
				//			"input.identificativo_univoco_versamento +" + input.identificativo_univoco_versamento +
				//			"input.importo +" + input.importo +
				//			"input.indirizzo_debitore +" + input.indirizzo_debitore +
				//			"input.localita_debitore +" + input.localita_debitore +
				//			"input.nazione_debitore +" + input.nazione_debitore +
				//			"input.provincia_debitore +" + input.provincia_debitore +
				//			"input.savv +" + input.savv +
				//			"input.tipo_id_debitore +" + input.tipo_id_debitore +
				//			"input.tipo_riferimento_creditore +" + input.tipo_riferimento_creditore
				//			);

				UnicreditService.inserimentoPosizioneOutputType output;
				try
				{
					var req = new UnicreditService.inserimentoPosizione()
					{
						gestorePosizioniHeader = header,
						inserimentoPosizioneRequest = new UnicreditService.inserimentoPosizioneRequest()
						{
							inserimentoPosizioneInput = input
						}
					};

					var response = servizio.inserimentoPosizione(req);
					if (response?.inserimentoPosizioneResponse?.inserimentoPosizioneOutput != null)
					{
						output = response.inserimentoPosizioneResponse.inserimentoPosizioneOutput;
					}
					else
					{
						errors.Add(
							$"Nell'invio di flusso {idflusso} anagrafica {r["codice"]}  Il server ha restituito una risposta non valida");
						continue;
					}

				}
				catch (Exception ex)
				{
					errors.Add(QueryCreator.GetErrorString(ex));
					continue;
				}

				if (!output.esito.Equals("OK"))
				{
					errors.Add(
						$"Nell'invio di flusso {idflusso} anagrafica {r["codice"]}  errore: {output.descrizione} (codice errore {output.codiceErrore})");
					continue;
				}




				foreach (var rFlusso in reference[idDisposizione])
				{
					// Galfione Dario (UniCredit):
					// codice_identificativo_presentazione: 
					//     Il valore che verrÃƒÆ’Ã‚Â  restituito(18 caratteri ÃƒÂ¢Ã¢â€šÂ¬Ã¢â‚¬Å“ aux digit 0 ÃƒÂ¢Ã¢â€šÂ¬Ã¢â‚¬Å“ application code 01 ÃƒÂ¢Ã¢â€šÂ¬Ã¢â‚¬Å“ 
					// riferimento operazione 0000001271826 ÃƒÂ¢Ã¢â€šÂ¬Ã¢â‚¬Å“ check digit 91) ÃƒÆ’Ã‚Â¨ quello che deve essere utilizzato 
					// nei barcode e QR.
					// identificativo_univoco_versamento: ÃƒÆ’Ã‚Â¨ lo IUV 
					//   (15 caratteri del precedente partendo da destra in quanto aux digit = 0)


					rFlusso["iuv"] = output.identificativo_univoco_versamento;
					rFlusso["codiceavviso"] = output.codice_identificativo_presentazione;

					rFlusso["barcodevalue"] = Utils.IUV.getCodiceBarre(
						gln,
						output.codice_identificativo_presentazione,
						input.importo);
					rFlusso["qrcodevalue"] = Utils.IUV.getCodiceQR(input.identificativo_beneficiario,
						output.codice_identificativo_presentazione, input.importo);
				}
			}

			// Imposta il flusso come trasmesso solo se non ci sono stati errori
			if (errors.Count == 0)
			{
				//Curr["istransmitted"] = "S";
				DataRow curr = ds.Tables["flussocrediti"]._First();
				curr["istransmitted"] = "S";
			}

			Meta_EasyDispatcher dispatcher = new Meta_EasyDispatcher(conn);
			var metaFlussoCreditiDetail = dispatcher.Get("flussocreditidetail");
			metaFlussoCreditiDetail.ComputeRowsAs(tFlussocreditidetail, "posting");

			//Meta.SaveFormData();
			PostData post = new Easy_PostData_NoBL();
			post.initClass(ds, conn);
			if (post.DO_POST()) return errors;
			errors.Add("Errore nel salvataggio dei dati");
			return errors;
			// Questa interrogazione verrÃƒÆ’Ã‚Â  fatta nel chiamante, in cui se Errors = 0 allora OK, altrimenti visualizza l'errore.
			//if (errori.Count > 0) {
			//    FrmErrori.MostraErrori(this, errori);
			//}
			//else {
			//  MetaFactory.factory.getSingleton<IMessageShower>().Show("Il flusso ÃƒÆ’Ã‚Â¨ stato inviato correttamente", "Avviso");
			//}
		}

		private static List<string> caricaPosizioniDebitorieValtellinese(DataAccess conn, DataSet ds,
			PartnerConfig pConf)
		{
			object idflusso = ds.Tables["flussocrediti"].Rows[0]["idflusso"].ToString();
			//object idflusso = 21;
			var errors = new List<string>();
			var esercizio = conn.GetEsercizio();
			var dataContabile = conn.GetDataContabile();

			// Parametri del servizio (utente/password/CODICE_AZIENDA/URLSoap/userRest/pwdRest/URLRest/codicepartitarioRest)
			// WS_COM_CREV|**********|CRE14|https://service.pmpay.it/|unicatuser|**********|https://service.pmpay.it/Rest/|COD_SERV_STUDENTE
			var utente = pConf.Config[0]; // utente ambiente SOAP

			var password = pConf.Config[1]; // password ambiente SOAP
			string codiceAzienda = pConf.Config[2]; // codice azienda
			string urlSoap = pConf.Config[3]; // url ambiente SOAP
			string userRest = pConf.Config[4]; // utente ambiente REST
			string pwdRest = pConf.Config[5]; //password ambiente REST
			string urlRest = pConf.Config[6]; // url ambiente REST
			string codicepartitarioRest = pConf.Config[7]; // codice partitario ambiente REST

			//var utente = "WS_COM_CREV";  // utente ambiente SOAP
			//var password = "**********"; // password ambiente SOAP
			//string codiceAzienda = "CRE14"; // codice azienda
			//string urlSoap = "https://service.pmpay.it/"; // url ambiente SOAP
			//string userRest = "unicatuser"; // utente ambiente REST
			//string pwdRest = "**********"; //password ambiente REST
			//string urlRest = "https://service.pmpay.it/Rest";   // url ambiente REST
			//string codicepartitarioRest = "COD_SERV_STUDENTE"; // codice partitario ambiente REST

			//string utente = "WS_COM_CREV";
			//string password = "**********";
			//string urlRest = "https://service.pmpay.it/Rest";


			// Parametri del servizio (utente/password/codice del servizio/aux digit/app code)

			//var codiceServizio = 1;
			//if (pConf.Config.Length > 8) {//demo 0000001
			//    codiceServizio = CfgFn.GetNoNullInt32(pConf.Config[8]);
			//}
			string RIF_CONTABILE = null;
			if (pConf.Config.Length > 8) RIF_CONTABILE = pConf.Config[8]; // codice partitario ambiente REST




			//var auxdigit = 0;   //puÃƒÆ’Ã‚Â² valere 0 (IUV da 15 cifre) o 3 (IUV da 17 cifre, include anche l'app.code)
			//if (pConf.Config.Length > 9) {
			//    if (!int.TryParse(pConf.Config[9], out auxdigit)) {
			//        errors.Add("auxdigit di partner_config non valido.");
			//        return errors;
			//    }
			//}

			//var appcode = 0;        //2 cifre, entra in gioco nella composizione del codice_identificativo_presentazione
			//if (pConf.Config.Length > 10) {
			//    if (!int.TryParse(pConf.Config[10], out appcode)) {
			//        errors.Add("appcode di partner_config non valido.");
			//        return errors;
			//    }
			//}


			var gln = "0000000000000"; //13 cifre
			if (pConf.Config.Length > 11)
			{
				gln = pConf.Config[11];
			}

			var qh = conn.GetQueryHelper();

			// Estrae dal DB il codice fiscale dell'ente            
			//var identificativoEnte = Conn.readValue("generalreportparameter",
			//        q.eq("idparam", "License_f") & q.nullOrLe("start", dataContabile) & q.nullOrGe("stop", dataContabile),
			//        "paramvalue");
			var identificativoEnte = conn.DO_READ_VALUE("generalreportparameter", qh.AppAnd(
				qh.CmpEq("idparam", "License_f"), qh.NullOrLe("start", dataContabile),
				qh.NullOrGe("stop", dataContabile)
			), "paramvalue");



			if (identificativoEnte == null || identificativoEnte == DBNull.Value)
			{
				errors.Add("identificativoEnte di Generalreportparameter non valido.");
				return errors;
			}


			string[] captionAllineamentoPendenze = new string[] {
				"CREDITORE",
				"CODICE_PARTITARIO",
				"DEBITORE",
				"ID_DEBITO",
				"ID_PAGAMENTO(IUV)",
				"DATA_SCADENZA",
				"DATA_INIZIO_VALIDITA",
				"DATA_FINE_VALIDITA",
				"CAUSALE_PAGAMENTO",
				"STATO_PAGAMENTO",
				"IMPORTO_PAGAMENTO",
				"VOCI_PAGAMENTO",
				"ANNO_RIFERIMENTO",
				"NOTE_DEBITO",
				"CAUSALE_DEBITO",
				"IMPORTO_PAGATO",
				"DATA_VALUTA_ACCREDITO",
				"CANALE_PAGAMENTO",
				"DATA_PAGAMENTO",
				"NOTE_PAGAMENTO",
				"PAGATO_PIATTAFORMA",
				"ID_DEBITO_RATA_UNICA",
				"DATI_AGGIUNTIVI"
			};


			DataTable
				tFlussocreditidetail =
					ds.Tables[
						"flussocreditidetail"]; // Conn.RUN_SELECT("flussocreditidetail", "*", null, QHS.CmpEq("idflusso", idflusso), null, false);

			var qhc = new CQueryHelper();
			if (tFlussocreditidetail.Select(qhc.IsNull("expirationdate")).Length > 0)
			{
				errors.Add("Ci sono posizioni debitorie senza scadenza");
				return errors;
			}


			if (ds.Tables["flussocreditidetail"].Rows.Count == 0)
			{
				errors.Add("Non vi sono posizioni righe in Flussocreditidetail con n. " + idflusso + ".");
				return errors;
			}

			string idRichiesta = "XARTYUIO"; // new Guid().ToString();
											 //Si logga al servizio 
			var iuvService = Valtellinese.Servizio.CreateAuthPaSoap(utente, password, urlSoap);


			var ticketReq = new Valtellinese.WSLOGIN_REQUEST
			{
				ID_CLIENT = utente, //identificativo fornito in fase di registrazione Azienda Esercente da PmPay
				PWD_CLIENT = password, //password di accesso fornita in fase di registrazione Azienda Esercente da PmPay
				DATA_RICHIESTA = DateTime.Now.Date, //data e ora della data di richiesta
				ID_RICHIESTA = idRichiesta, //identificato univoco assegnato dal client alla specifica richiesta
				CODICE_AZIENDA =
					codiceAzienda //-,           //codice assegnato alla Azienda Esercente da PmPay, fornito in fase di registrazione
								  //CHECK_STRING = null,
								  //TIMESTAMP = DateTime.Now.Date.ToString()
			};
			// Errors.Add(ticketReq.toXml()); return Errors;
			var res = Valtellinese.Servizio.authGetTicket(iuvService, ticketReq);

			//var resBodyGetTicket = serializerValtellinese.fromXml<GetTicketResponse>(resString);
			//var res =   serializerValtellinese.fromXml<WSLOGIN_RESPONSE>(resString.Body);// .result();                        
			//var res = iuvService.GetTicket(new GetTicketRequest(ticketReq));


			if (!string.IsNullOrEmpty(res.CODICE_ERRORE))
			{
				errors.Add($"Errore {res.CODICE_ERRORE}:{res.DESCRIZIONE_ERRORE} nell'ottenimento del ticket");
				return errors;
			}

			string token = res.TOKEN;
			if (!string.IsNullOrEmpty(res.CODICE_ERRORE))
			{
				errors.Add($"Errore generico nell'ottenimento del token di collegamento");
				return errors;
			}



			var iuvOttenuti = false;
			Dictionary<string, string> iuvFrom_iduniqueformcode = new Dictionary<string, string>();
			List<DataRow> crediti = new List<DataRow>();
			foreach (DataRow rDeb in tFlussocreditidetail.Rows)
			{
				//Ottiene lo IUV  per la posizione debitoria ove necessario
				if (rDeb["annulment"] != DBNull.Value) continue;
				if (rDeb["iuv"] != DBNull.Value)
				{
					iuvFrom_iduniqueformcode[rDeb["iduniqueformcode"].ToString()] = rDeb["iuv"].ToString();
					continue;
				}
				crediti.Add(rDeb);
			}

			if (crediti.Count == 0) return errors;

			richiestaIUV reqIuv;
			if (RIF_CONTABILE == null)
			{
				reqIuv = new richiestaIUV
				{
					// RIF_INTERNO = iduniqueformcode,//identificativo  della pratica gestito dal portale dellÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢Azienda Ente 
					TIPO_REFERENCE = "A",
					//Tipologia di contatore da generare per impostare la componente reference dello IUV standard(A - B - C - D - E) e IUV non standard Z(vedi paragrafo 5.1.4)
					STANDARD_ISO = false
					//RIF_CONTABILE = idDisposizione, //Indica il codice contabile su cui incrementare il contatore per la modalitÃƒÆ’Ã‚Â  TIPO_REFERENCE = D-Z
					//RIF_COD_UTENTE = 0, //Indica il codice utente su cui incrementare il contatore per la modalitÃƒÆ’Ã‚Â  TIPO_REFERENCE = E
					//RIF_ALFANUMERICO = 0 //Determina la parte alfanumerica su cui incrementare il contatore per la modalitÃƒÆ’Ã‚Â  TIPO_REFERENCE = B                    
				};
			}
			else
			{
				reqIuv = new richiestaIUV
				{
					// RIF_INTERNO = iduniqueformcode,//identificativo  della pratica gestito dal portale dellÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢Azienda Ente 
					TIPO_REFERENCE = "Z",
					//Tipologia di contatore da generare per impostare la componente reference dello IUV standard(A - B - C - D - E) e IUV non standard Z(vedi paragrafo 5.1.4)
					RIF_CONTABILE = RIF_CONTABILE,
					//RIF_CONTABILE = idDisposizione, //Indica il codice contabile su cui incrementare il contatore per la modalitÃƒÆ’Ã‚Â  TIPO_REFERENCE = D-Z
					//RIF_COD_UTENTE = 0, //Indica il codice utente su cui incrementare il contatore per la modalitÃƒÆ’Ã‚Â  TIPO_REFERENCE = E
					//RIF_ALFANUMERICO = 0 //Determina la parte alfanumerica su cui incrementare il contatore per la modalitÃƒÆ’Ã‚Â  TIPO_REFERENCE = B                    
				};
			}
			var headIuvReq = new headerRichiestaIUV()
			{
				ID_CLIENT = ticketReq.ID_CLIENT,
				TOKEN = token,
				DATA_RICHIESTA = ticketReq.DATA_RICHIESTA,
				ID_RICHIESTA = ticketReq.ID_RICHIESTA,
				CODICE_AZIENDA = ticketReq.CODICE_AZIENDA,
				IUV_RICHIESTI = crediti.Count,
				IUV_RICHIESTISpecified = true
			};

			var result = Valtellinese.Servizio.authGetIuv(iuvService, reqIuv, headIuvReq);

			if (result.IUV == null || result.IUV.Count == 0)
			{
				errors.Add(
					$"Errore {result.CODICE_ERRORE} {result.DESCRIZIONE_ERRORE} nell'ottenimento di {crediti.Count} iuv");
				return errors;
			}
			if (result.IUV.Count != crediti.Count)
			{
				errors.Add(
					$"Errore : richiesti {crediti.Count} iuv ed ottenuti {result.IUV.Count}");
				return errors;
			}


			salvaDati(ds, errors, conn, "Salvataggio IUV ottenuti");
			if (errors.Count > 0) return errors;


			for (int i = 0; i < crediti.Count; i++)
			{
				DataRow rDeb = crediti[i];
				string iuvOttenuto = result.IUV[i];

				//Ottiene lo IUV  per la posizione debitoria ove necessario
				var iduniqueformcode = rDeb["iduniqueformcode"].ToString();
				var idDisposizione = CfgFn.GetNoNullDecimal(rDeb["iduniqueformcode"]);
				string iuv = null;

				string codiceAvviso = "3" + iuvOttenuto;

				if (codiceAvviso.ToUpper().StartsWith("RF")) iuv = codiceAvviso.Substring(4);
				if (codiceAvviso.StartsWith("0")) iuv = codiceAvviso.Substring(3);
				if (codiceAvviso.StartsWith("2")) iuv = codiceAvviso.Substring(1);
				if (codiceAvviso.StartsWith("3")) iuv = codiceAvviso.Substring(1);

				rDeb["iuv"] = iuv; //result.IUV;
				int flag = CfgFn.GetNoNullInt32(rDeb["flag"]);
				flag = flag | 2; //non trasmesso
				rDeb["flag"] = flag;

				iuvFrom_iduniqueformcode[rDeb["iduniqueformcode"].ToString()] = rDeb["iuv"].ToString();
				iuvOttenuti = true;
				rDeb["codiceavviso"] =
					codiceAvviso; //Probabilmente non sarÃƒÆ’Ã‚Â  corretto ma al momento ÃƒÆ’Ã‚Â¨ tutto ciÃƒÆ’Ã‚Â² che abbiamo
				rDeb["barcodevalue"] = Utils.IUV.getCodiceBarre(
					gln,
					codiceAvviso,
					CfgFn.GetNoNullDecimal(rDeb["importoversamento"]));
				rDeb["qrcodevalue"] = Utils.IUV.getCodiceQR(identificativoEnte.ToString(),
					codiceAvviso,
					CfgFn.GetNoNullDecimal(rDeb["importoversamento"]));
			}




			// Costruisce l'elenco dei dettagli da esportare
			var tPosizioniDebitorie =
				conn.CallSP("exp_posizionidebitoriebsondrio", new[] { idflusso, esercizio }).Tables[0];
			if (tPosizioniDebitorie.Rows.Count == 0)
			{
				errors.Add("Non vi sono posizioni debitorie da inviare.");
				return errors;
			}

			if (tPosizioniDebitorie.Select(qhc.IsNull("scadenza")).Length > 0)
			{
				errors.Add("Ci sono posizioni debitorie senza scadenza");
				return errors;
			}


			var servizio = Valtellinese.Servizio.CreatePayPa(utente, password, urlSoap);
			var header = new UnicreditService.gestorePosizioniHeader()
			{
				user = utente,
				password = password
			};
			// per il caricamento massivo usiamo il web service REST effettuando l'upload del file
			//https://service.pmpay.it/Rest/allineamentopendenze/send con upload del file
			ValtellineseREST rClient = new ValtellineseREST(urlRest, userRest, pwdRest);

			var fileCSV = "";
			// Creazione del file allineamento pendenze da allegare alla chiamata mediante upload

			// La prima riga ÃƒÆ’Ã‚Â¨ di intestazione 
			foreach (string caption in captionAllineamentoPendenze)
			{
				if (caption != "DATI_AGGIUNTIVI")
					fileCSV += caption + "|";
				else
					fileCSV += caption; // alla fine della riga non ci va il PIPE
			}

			StringBuilder sb = new StringBuilder();
			sb.AppendLine(fileCSV);

			foreach (DataRow r in tPosizioniDebitorie.Rows)
			{

				//StringBuilder buffer = new StringBuilder();

				//Id_Trasmissione che identificherÃƒÆ’Ã‚Â  nei due sistemi (Applicazione Client e PMPAY) il flusso della trasmissione avvenuta.
				//Il FilePendenze ÃƒÆ’Ã‚Â¨ un file in formato CSV  con codifica UTF - 8.
				//Ogni linea ÃƒÆ’Ã‚Â¨ costituita da 21 campi delimitati dal carattere '|'(pipe).
				//La prima riga ÃƒÆ’Ã‚Â¨ di intestazione e contiene i nomi dei campi.
				//Le linee successive descrivono i pagamenti con la seguente sintassi:
				/*
				CREDITORE * (es. ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œPA999ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â
				CODICE_PARTITARIO*
				DEBITORE * (codice fiscale del debitore)Stringa
				ID_DEBITO*
				ID_PAGAMENTO(IUV) *
				DATA_SCADENZA(della bolletta / fattura)
				DATA_INIZIO_VALIDITA
				DATA_FINE_VALIDITA
				CAUSALE_PAGAMENTO(in caso di pagamento spontaneo: identificativo del servizio pagato(es: nro tessera / identificativo multa, etc..)), altrimenti vuoto
				STATO_PAGAMENTO*
				IMPORTO_PAGAMENTO*
				VOCI_PAGAMENTO
				ANNO_RIFERIMENTO
				NOTE_DEBITO
				CAUSALE_DEBITO(Descrizione della posizione debitoria costituita)
				IMPORTO_PAGATO
				DATA_VALUTA_ACCREDITO
				CANALE_PAGAMENTO
				DATA_PAGAMENTO
				NOTE_PAGAMENTO
				PAGATO_PIATTAFORMA
				ID_DEBITO_RATA_UNICA Stringa 
				DATI_AGGIUNTIVI  {"TASSONOMIA":"0801100AP"}
				*/
				string iuv = null;
				if (iuvFrom_iduniqueformcode.ContainsKey(r["iduniqueformcode"].ToString()))
				{
					iuv = iuvFrom_iduniqueformcode[r["iduniqueformcode"].ToString()];
				}
				else
				{
					iuv = conn.readValue("flussocreditidetail",
						q.eq("iduniqueformcode", r["iduniqueformcode"].ToString()), "iuv")?.ToString();
				}

				if (string.IsNullOrEmpty(iuv)) continue;

				// Compone la stringa coi dati della posizione debitoria
				string creditore = codiceAzienda; //CREDITORE * (es. ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œPA999ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â   
				string codice_partitario = codicepartitarioRest; //CODICE_PARTITARIO*    
				string debitore = DBNull.Value.Equals(r["codice"]) ? "" : r["codice"].ToString(); //DEBITORE*
				string id_debito = r["iduniqueformcode"].ToString();
				string id_pagamento_iuv = iuv;
				DateTime data_scadenza = noNullDate(r["scadenza"], DateTime.Now.Date.AddDays(30));
				string sDataScadenza = data_scadenza.Year.ToString() + "-" +
									   data_scadenza.Month.ToString().PadLeft(2, '0') + "-" +
									   data_scadenza.Day.ToString().PadLeft(2, '0');
				string data_iniziovalidita = "";
				string data_finevalidita = "";
				string causalepagamento = "";
				string stato_pagamento = "DA_PAGARE";
				string importo_pagamento = Convert.ToInt64(CfgFn.GetNoNullDecimal(r["importo"]) * 1000).ToString();
				string voci_pagamento = "";
				string anno_riferimento = DateTime.Now.Date.Year.ToString();

				string nomeCognome = "";
				if (r["forename"].ToString() != "" && r["surname"].ToString() != "")
					nomeCognome = $"\"nome\":\"{r["forename"]}\",\"cognome\":\"{r["surname"]}\" ";
				string denominazione = "";
				if (nomeCognome == "") denominazione = $"\"nome\":\"{r["anagrafica"]}\"";
				string email = "";
				//if (r["email"].ToString() != "") email = $",\"email\":{r["email"]}";

				string note_debito = "{" + nomeCognome + denominazione + email + "}";

				string causale = cleanLineFeed(r["causale"].ToString());

				//string note = cleanHtmlFeed(r["note"].ToString());
				string tassonomia = "";
				if (tPosizioniDebitorie.Columns.Contains("codicetassonomia") && (r["codicetassonomia"] != DBNull.Value))
				{
					string code = r["codicetassonomia"].ToString();
					tassonomia = "{\"TASSONOMIA\":\"" + code.Substring(2, code.Length - 3) + "\"}";
				}

				string causale_debito = causale;
				string importo_pagato = "";
				string data_valuta_accredito = "";
				string canale_pagamento = "";
				string data_pagamento = "";
				string note_pagamento = "";
				string pagato_piattaforma = "";
				string id_debito_rata_unica = "";
				string rigaFile = creditore + "|" +
								  codice_partitario + "|" +
								  debitore + "|" +
								  id_debito + "|" +
								  id_pagamento_iuv + "|" +
								  sDataScadenza + "|" +
								  data_iniziovalidita + "|" +
								  data_finevalidita + "|" +
								  causalepagamento + "|" +
								  stato_pagamento + "|" +
								  importo_pagamento + "|" +
								  voci_pagamento + "|" +
								  anno_riferimento + "|" +
								  note_debito + "|" +
								  causale_debito + "|" +
								  importo_pagato + "|" +
								  data_valuta_accredito + "|" +
								  canale_pagamento + "|" +
								  data_pagamento + "|" +
								  note_pagamento + "|" +
								  pagato_piattaforma + "|" +
								  id_debito_rata_unica + "|" +
								  tassonomia
					;

				sb.AppendLine(rigaFile);

			}

			string idtrasmissione;
			try
			{
				QueryCreator.MarkEvent("Invio file:");
				QueryCreator.MarkEvent(sb.ToString());
				var esito = rClient.inviaCrediti(sb.ToString(), out idtrasmissione);

				if (esito != null)
				{
					errors.Add($"Nell'invio di flusso {idflusso}  errore:\n\r {esito})");
					return errors;
				}
			}
			catch (Exception ex)
			{
				errors.Add(QueryCreator.GetErrorString(ex));
				return errors;
			}
			//Esamina lo stato delle pendenze


			// Imposta il flusso come trasmesso solo se non ci sono stati errori
			if (errors.Count != 0) return errors;


			/*
			     ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â¢	CSV Esito elaborato correttamente (omessa l'intestazione):
			 Elaborato correttamente|||
			     ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â¢	CSV Esito flusso non valido (omessa l'intestazione): 
			 Non valido||${codErrore}|${descrizione}
			 Tutto il flusso (tutte le pendenze che costituiscono la trasmissione) vengono segnate come non valide.
			     ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â¢	CSV Esito flusso con alcuni errori di elaborazione delle pendenze (omessa l'intestazione):
			 Elaborato con Errore|${idDebito1}|${codErrore1}|${descrizione1}

			 */
			Dictionary<string, bool> creditiErrati = new Dictionary<string, bool>();
			bool toRepeat = true;
			while (toRepeat)
			{
				string errore = null;
				string esitoAllineamento = rClient.GetEsitoAllineamentoPendenze(idtrasmissione, out errore);
				if (errore != null)
				{
					errors.Add(errore);
					return errors;
				}


				StringReader sr = new StringReader(esitoAllineamento);
				string line = sr.ReadLine();
				//salto intestazione ESITO|ID_DEBITO|CODICE_ERRORE|DESCRIZIONE_ERRORE
				if (line != null && line.ToUpperInvariant().Trim() == "ESITO|ID_DEBITO|CODICE_ERRORE|DESCRIZIONE_ERRORE"
				) line = sr.ReadLine();

				while (line != null)
				{
					line = line.Trim();
					if (line == "")
					{
						line = sr.ReadLine();
						continue;
					}

					var parts = line.Split('|');
					if (parts.Length == 0)
					{
						line = sr.ReadLine();
						continue;
					}

					string head = parts[0].ToLowerInvariant();
					if ((head == "elaborato correttamente") || (head == "ok"))
					{
						foreach (DataRow credDet in ds.Tables["flussocreditidetail"].Rows)
						{
							//Imposta tutti i crediti come trasmessi
							int flag = CfgFn.GetNoNullInt32(credDet["flag"]);
							flag = flag & (~2); //non trasmesso
							credDet["flag"] = flag;
						}

						toRepeat = false;
						break;
					}

					if (parts.Length == 1 && parts[0].ToString().Trim() == "")
					{
						line = sr.ReadLine();
						continue;
					}

					if (head.ToLowerInvariant() == "trasmissione richiesta non ancora elaborata")
					{
						System.Threading.Thread.Sleep(10000);
						break;
					}

					if (parts.Length < 4)
					{
						errore = "Ricevuto riga risposta indecifrabile:" + line;
						errors.Add(errore);
						line = sr.ReadLine();
						continue;
					}



					string idDebito = parts[1];
					string codiceErrore = parts[2];
					string Errore = parts[3];
					if ((head == "non valido|") || (head == "ko"))
					{
						toRepeat = false;
						errors.Add(codiceErrore + ":" + Errore);
						return errors; //tutti i crediti rimanono marcati come non trasmessi
					}

					//Rimane il caso dell'errore sulla singola riga
					// Elaborato con Errore|${idDebito1}|${codErrore1}|${descrizione1}
					errors.Add($"Su posizione creditoria: {idDebito} errore {codiceErrore} {Errore}");
					creditiErrati[idDebito] = true;
					line = sr.ReadLine();
					toRepeat = false;
				}

			}


			foreach (DataRow credDet in ds.Tables["flussocreditidetail"].Rows)
			{
				string idDebito = credDet["iduniqueformcode"].ToString();
				if (creditiErrati.ContainsKey(idDebito)) continue;

				//Imposta tutti i crediti non errati come trasmessi
				int flag = CfgFn.GetNoNullInt32(credDet["flag"]);
				flag = flag & (~2); //non trasmesso
				credDet["flag"] = flag;
			}


			DataRow curr = ds.Tables["flussocrediti"]._First();
			if (creditiErrati.Keys.Count == 0) curr["istransmitted"] = "S";
			salvaDati(ds, errors, conn, "Salvataggio dei crediti");

			return errors;
		}

		static void salvaDati(DataSet d, List<string> errors, DataAccess conn, string action)
		{
			var dispatcher = new Meta_EasyDispatcher(conn);
			var metaFlussoCreditiDetail = dispatcher.Get("flussocreditidetail");
			metaFlussoCreditiDetail.ComputeRowsAs(d.Tables["flussocreditidetail"], "posting");

			//Meta.SaveFormData();
			PostData post = new Easy_PostData_NoBL();
			post.initClass(d, conn);
			if (!post.DO_POST())
			{
				errors.Add($"Errore nel salvataggio dei dati ({action})");
			}
		}

		private static List<string> caricaPosizioniDebitorieUbiBanca(DataAccess conn, DataSet ds, PartnerConfig pConf)
		{
			object idflusso = ds.Tables["flussocrediti"].Rows[0]["idflusso"].ToString();
			var errors = new List<string>();
			var esercizio = conn.GetEsercizio();
			var dataContabile = conn.GetDataContabile();

			// Parametri del servizio (utente/password/codice del servizio/aux digit/app code)
			var utente = pConf.Config[0];
			var password = pConf.Config[1];
			string url = null;
			var codiceServizio = 1;
			if (pConf.Config.Length > 2)
			{ //demo 0000001
				codiceServizio = CfgFn.GetNoNullInt32(pConf.Config[2]);
			}

			//var auxdigit = 0;   //puÃƒÆ’Ã‚Â² valere 0 (IUV da 15 cifre) o 3 (IUV da 17 cifre, include anche l'app.code)
			//if (pConf.Config.Length > 3) {
			//    if (!int.TryParse(pConf.Config[3], out auxdigit)) {
			//        errors.Add("auxdigit di partner_config non valido.");
			//        return errors;
			//    }
			//}

			//var appcode = 0;        //2 cifre, entra in gioco nella composizione del codice_identificativo_presentazione
			//if (pConf.Config.Length > 4) {
			//    if (!int.TryParse(pConf.Config[4], out appcode)) {
			//        errors.Add("appcode di partner_config non valido.");
			//        return errors;
			//    }
			//}

			if (pConf.Config.Length > 5)
			{
				url = pConf.Config[5];
			}

			var gln = "0000000000000"; //13 cifre
			if (pConf.Config.Length > 6)
			{
				gln = pConf.Config[6];
			}

			var qhc = conn.GetQueryHelper();

			// Estrae dal DB il codice fiscale dell'ente            
			//var identificativoEnte = Conn.readValue("generalreportparameter",
			//        q.eq("idparam", "License_f") & q.nullOrLe("start", dataContabile) & q.nullOrGe("stop", dataContabile),
			//        "paramvalue");
			var identificativoEnte = conn.DO_READ_VALUE("generalreportparameter", qhc.AppAnd(
				qhc.CmpEq("idparam", "License_f"), qhc.NullOrLe("start", dataContabile), qhc.NullOrGe("stop", dataContabile)
			), "paramvalue");



			if (identificativoEnte == null || identificativoEnte == DBNull.Value)
			{
				errors.Add("identificativoEnte di Generalreportparameter non valido.");
				return errors;
			}

			// Costruisce l'elenco dei dettagli da esportare
			var tPosizioniDebitorieTuttiServizi = conn.CallSP("exp_posizionidebitoriebsondrio", new object[] { idflusso, esercizio })
				.Tables[0];

			q filter = null;
			//if (tPosizioniDebitorieTuttiServizi.Columns.Contains("codice_servizio")) {
			//	if (pConf.codice_servizio == null) {
			//		filter = q.isNull("codice_servizio");
			//	}
			//	else {
			//		filter = q.eq("codice_servizio",pConf.codice_servizio);
			//	}
			//}

			var righeDaConsiderare = tPosizioniDebitorieTuttiServizi._Filter(filter);

			if (righeDaConsiderare.Length == 0)
			{
				if (pConf.codice_servizio == null) errors.Add("Non vi sono posizioni debitorie da inviare.");
				return errors;
			}

			if (righeDaConsiderare._Filter(q.isNull("scadenza")).ToArray().Length > 0)
			{
				errors.Add("Ci sono posizioni debitorie senza scadenza");
				return errors;
			}

			if (!checkCertificatiBancaIntesa(utente == "nodoInfogroup"))
			{
				errors.Add("Impossibile installare i certificati di banca intesa");
				return errors;
			}
			var servizio = UbiBancaService.Servizio.Create(utente, password, url,
				utente == "nodoInfogroup");
			var header = new UbiBancaService.gestorePosizioniHeader()
			{
				user = utente,
				password = password
			};
			// Costruisce un dizionario di riferimento per i dettagli
			// Ogni entry di reference contiene una riga di flussocreditidetail associata al codice
			var reference = new Dictionary<string, List<DataRow>>();
			var tFlussocreditidetail =
				ds.Tables["flussocreditidetail"]; // Conn.RUN_SELECT("flussocreditidetail", "*", null, QHS.CmpEq("idflusso", idflusso), null, false);
			if (ds.Tables["flussocreditidetail"].Rows.Count == 0)
			{
				errors.Add("Non vi sono posizioni righe in Flussocreditidetail con n. " + idflusso + ".");
				return errors;
			}

			foreach (DataRow r in tFlussocreditidetail.Rows)
			{
				var codice = r["iduniqueformcode"].ToString(); //getID_Tenant(r["idflusso"], r["iddetail"]); ;
				if (!reference.ContainsKey(codice))
				{
					reference[codice] = new List<DataRow>();
				}

				reference[codice].Add(r);
			}

			bool test = (utente == "nodoInfogroup");
			string srtIdentificativo_beneficiario = "";
			if (test)
			{
				srtIdentificativo_beneficiario = "80005570561";
			}
			else
			{
				srtIdentificativo_beneficiario = identificativoEnte.ToString(); // System.Diagnostics.Debugger.IsAttached ? "80002170720" :
			}

			foreach (DataRow r in righeDaConsiderare)
			{
				//string progressivo = r["idflusso"].ToString().PadLeft(6, '0') + r["iddetail"].ToString().PadLeft(7, '0');
				var progressivo = $"{r["iddisposizione"],13:D13}"; // piÃƒÆ’Ã‚Â¹ preciso di quello commentato
																   //string.Format("{0,6:D6}{1,7:D7}",CfgFn.GetNoNullInt32(r["idflusso"]), CfgFn.GetNoNullInt32(r["iddetail"]));

				//Serve solo per accedere alla riga in flussocreditidetail, non ÃƒÆ’Ã‚Â¨ trasmesso all'ente
				var idDisposizione = r["iduniqueformcode"].ToString();

				string email = DBNull.Value.Equals(r["email"]) ? null : firstEmail(r["email"].ToString());
				//string iuvWithCheck = Utils.IUV.Genera(progressivo, auxdigit, appcode);

				string causale = cleanLineFeed(r["causale"].ToString());

				//string note = cleanHtmlFeed(r["note"].ToString());

				var input = new UbiBancaService.inserimentoPosizioneInputType()
				{
					identificativo_beneficiario = srtIdentificativo_beneficiario,
					codice_servizio = codiceServizio,

					//tipo_riferimento_creditore = r["tipo"].ToString(), //F persona fisica   G persona  giuridica
					tipo_riferimento_creditore =
						"G", // Il campo puÃƒÆ’Ã‚Â² assumere i valori G (persona giuridica) ed F (persona fisica). 
							 // ... nella stesura originale il valore del campo imposto ÃƒÆ’Ã‚Â¨ G


					//Codice Riferimento Creditore (codice/identificativo che si riferisce al campo precedente), rappresenta, 
					// in abbinamento con il campo Tipo Riferimento Creditore/PA , la chiave/identificativo univoco 
					// della posizione debitoria sul repository della Piattaforma Incassi 
					// (es Tipo Riferimento Creditore/PA  Fattura 123  - Codice Riferimento Creditore 12358 2017  
					// - Campo univoco ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œFattura 123  12358 2017 ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œ). 
					// La combinazione di questi dati devono essere univoci nellÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ambito di tutti i servizi dellÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ente 
					// presenti su UnicreditGate.
					codice_riferimento_creditore = idDisposizione,

					//Codice IUV della posizione inserita
					// ----------------------------------------------------------------------------------------------
					//identificativo_univoco_versamento = null,                    
					identificativo_univoco_versamento =
						null, //System.Diagnostics.Debugger.IsAttached ? iuvWithCheck : null,
							  // ----------------------------------------------------------------------------------------------
							  //RiferimentoCredito1 = string.Format("{0:D35}", r["idflusso"]), // per riferimento in fase d'incasso
							  //RiferimentoCredito2 = string.Format("{0:D35}", r["iddetail"]), // per riferimento in fase d'incasso

					// Dato OBBLIGATORIO.Come attualmente per il MAV,
					// la data scadenza non comporta nessun annullo e nessuna impagabilitÃƒÆ’Ã‚Â .Come da ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œregolamentoÃƒÂ¢Ã¢â€šÂ¬Ã‚Â ateneo,
					// se lo studente pagherÃƒÆ’Ã‚Â  oltre la scadenza, si troverÃƒÆ’Ã‚Â  una MORA.
					data_scadenza_pagamento = noNullDate(r["scadenza"], DateTime.Now.Date.AddDays(30)),
					data_scadenza_pagamentoSpecified = true, //se non la imposto a true non viene passato il parametro
					importo = Convert.ToDecimal(r["importo"]),
					causale = causale,

					//Numero Avviso
					//Nel caso in cui la generazione dello IUV avviene ad opera di UniCredit Gate,
					//questo campo ne conterrÃƒÆ’Ã‚Â  il valore generato in automatico.
					// ----------------------------------------------------------------------------------------------
					// codice_identificativo_presentazione = null,
					//La composizione ÃƒÆ’Ã‚Â¨: aux digit (1 carattere ÃƒÂ¢Ã¢â€šÂ¬Ã¢â‚¬Å“ 0/3) + application code (2 caratteri) + numero riferimento (13 caratteri) + check digit (2 caratteri)
					// Le ultime 15 cifre(se aux digit = 0) o 17(se aux digit = 3) sono lo IUV
					codice_identificativo_presentazione = null,
					//System.Diagnostics.Debugger.IsAttached ?String.Format("{0,1:D1}{1,2:D2}{2}", auxdigit, appcode, iuvWithCheck) : null,
					// ----------------------------------------------------------------------------------------------
					savv = null,

					tipo_id_debitore = DBNull.Value.Equals(r["tipo"]) ? null : r["tipo"].ToString(),
					identificativo_debitore = DBNull.Value.Equals(r["codice"]) ? null : r["codice"].ToString(),
					anagrafica_debitore = DBNull.Value.Equals(r["anagrafica"])
						? null
						: maxLen(r["anagrafica"].ToString(), 50),
					indirizzo_debitore = DBNull.Value.Equals(r["indirizzo"]) ? null : r["indirizzo"].ToString(),
					civico_debitore = null, // civico non disponibile (incluso nell'indirizzo)
					cap_debitore = DBNull.Value.Equals(r["cap"]) ? null : r["cap"].ToString(),
					localita_debitore = DBNull.Value.Equals(r["citta"]) ? null : r["citta"].ToString(),
					provincia_debitore = DBNull.Value.Equals(r["provincia"]) ? null : r["provincia"].ToString(),
					nazione_debitore = null, // codice ISO 3166 non disponibile
					email_debitore = string.IsNullOrEmpty(email) ? null : email,
				};

				UbiBancaService.inserimentoPosizioneOutputType output;
				try
				{
					var req = new UbiBancaService.inserimentoPosizione()
					{
						gestorePosizioniHeader = header,
						inserimentoPosizioneRequest = new UbiBancaService.inserimentoPosizioneRequest()
						{
							inserimentoPosizioneInput = input
						}
					};

					var response = servizio.inserimentoPosizione(req);
					if (response?.inserimentoPosizioneResponse?.inserimentoPosizioneOutput != null)
					{
						output = response.inserimentoPosizioneResponse.inserimentoPosizioneOutput;
					}
					else
					{
						errors.Add(
							$"Nell'invio di flusso {idflusso} anagrafica {r["codice"]}  Il server ha restituito una risposta non valida");
						continue;
					}

				}
				catch (Exception ex)
				{
					errors.Add(QueryCreator.GetErrorString(ex));
					continue;
				}

				if (!output.esito.Equals("OK"))
				{
					errors.Add(
						$"Nell'invio di flusso {idflusso} anagrafica {r["codice"]}  errore: {output.descrizione} (codice errore {output.codiceErrore})");
					continue;
				}




				foreach (var rFlusso in reference[idDisposizione])
				{
					// Galfione Dario (UniCredit):
					// codice_identificativo_presentazione: 
					//     Il valore che verrÃƒÆ’Ã‚Â  restituito(18 caratteri ÃƒÂ¢Ã¢â€šÂ¬Ã¢â‚¬Å“ aux digit 0 ÃƒÂ¢Ã¢â€šÂ¬Ã¢â‚¬Å“ application code 01 ÃƒÂ¢Ã¢â€šÂ¬Ã¢â‚¬Å“ 
					// riferimento operazione 0000001271826 ÃƒÂ¢Ã¢â€šÂ¬Ã¢â‚¬Å“ check digit 91) ÃƒÆ’Ã‚Â¨ quello che deve essere utilizzato 
					// nei barcode e QR.
					// identificativo_univoco_versamento: ÃƒÆ’Ã‚Â¨ lo IUV 
					//   (15 caratteri del precedente partendo da destra in quanto aux digit = 0)


					rFlusso["iuv"] = output.identificativo_univoco_versamento;
					rFlusso["codiceavviso"] = output.codice_identificativo_presentazione;

					rFlusso["barcodevalue"] = Utils.IUV.getCodiceBarre(
						gln,
						output.codice_identificativo_presentazione,
						input.importo);
					rFlusso["qrcodevalue"] = Utils.IUV.getCodiceQR(input.identificativo_beneficiario,
						output.codice_identificativo_presentazione,
						input.importo);

				}
			}

			// Imposta il flusso come trasmesso solo se non ci sono stati errori
			if (errors.Count == 0)
			{
				//Curr["istransmitted"] = "S";
				var curr = ds.Tables["flussocrediti"]._First();
				curr["istransmitted"] = "S";
			}

			var dispatcher = new Meta_EasyDispatcher(conn);
			var metaFlussoCreditiDetail = dispatcher.Get("flussocreditidetail");
			metaFlussoCreditiDetail.ComputeRowsAs(tFlussocreditidetail, "posting");

			//Meta.SaveFormData();
			PostData post = new Easy_PostData_NoBL();
			post.initClass(ds, conn);
			if (post.DO_POST()) return errors;
			errors.Add("Errore nel salvataggio dei dati");
			return errors;
			// Questa interrogazione verrÃƒÆ’Ã‚Â  fatta nel chiamante, in cui se Errors = 0 allora OK, altrimenti visualizza l'errore.
			//if (errori.Count > 0) {
			//    FrmErrori.MostraErrori(this, errori);
			//}
			//else {
			//    MetaFactory.factory.getSingleton<IMessageShower>().Show("Il flusso ÃƒÆ’Ã‚Â¨ stato inviato correttamente", "Avviso");
			//}
		}

		private static readonly string ERRORE_CONFIG = "Errata configurazione del partner tecnologico";

		public static string AggiornaIuv(DataAccess conn, string iuv)
		{
			string errore = null;
			StringBuilder ErroriOttenuti = new StringBuilder();

			var pconf = getPartnerConfigForIuv(conn, iuv);
			if (pconf == null)
			{
				return ERRORE_CONFIG;
			}
			switch (pconf.Code)
			{
				case CINECA_CREDITI:
					errore = aggiornaGovPay(pconf.Config, conn, iuv);
					break;
				case INTESASP:
					errore = aggiornaIntesaSanPaolo(pconf.Config, conn, iuv);
					break;
				case VALTELLINESE:
					errore = aggiornaValtellinese(pconf.Config, conn, iuv);
					break;
				default:
					errore = "Funzione non prevista con l'attuale partner tecnologico";
					break;
			}

			if (errore != null)
			{
				ErroriOttenuti.AppendLine($"Partner tecnologico:{pconf.Code} {pconf.codice_servizio}, messaggio:{errore}");
				errore = ErroriOttenuti.ToString();
			}

			return errore;
		}




		private static string aggiornaIntesaSanPaolo(string[] config, DataAccess conn, string iuvToSearch)
		{
			string errore = null;

			//const string INTESA_FORMAT_DATE = "yyyy-MM-dd";
			var esercizio = conn.GetEsercizio();
			// Parametri del servizio
			var identificativoDominio = config[0];
			var identificativoBu = config[1];
			var identificativoServizio = config[2];

			var user = config.Length > 3 ? config[3] : null;
			var password = config.Length > 4 ? config[4] : null;
			string url = null;
			if (config.Length > 5)
			{
				url = config[5];
			}

			// Connessione al DB
			var qhs = conn.GetQueryHelper();
			var qhc = new CQueryHelper();

			// DataSet
			var ds = new dsmeta();
			ds.flussoincassi.setDefault("ayear", esercizio);
			ds.flussoincassi.setDefault("to_complete", "N");
			ds.flussoincassi.setDefault("elaborato", "N");
			ds.flussoincassi.setDefault("active", "S");

			// Imposta autoincremento e selettori
			ds.flussoincassi.setAutoincrement("idflusso", null, null, 0);
			ds.flussoincassidetail.setSelector("idflusso");
			ds.flussoincassidetail.setAutoincrement("iddetail", null, null, 0);


			if (!checkCertificatiBancaIntesa(identificativoServizio == "DEPOSITOCAUZIONALE"))
			{
				return "Impossibile installare i certificati di banca intesa";
			}

			// Servizio Web
			var servizio =
				new IntesaSanPaolo.EServizio().Create(user, password, url,
					identificativoServizio == "DEPOSITOCAUZIONALE");
			//Dictionary<string, DataRow> iuvCompiled = new Dictionary<string, DataRow>();

			try
			{
				var dataFine = DateTime.Now;
				//RTPOSITIVE = solo ricevute positive;
				//RTPOSITIVENOFLUSSO = ancora non rendicontate
				//      RICHIESTERT = tutte le RT (sia positive che negative)

				var body = new IntesaSanPaolo.pdpEsitiRTBody(identificativoDominio, identificativoBu,
					identificativoServizio, new DateTime(esercizio, 1, 1).Date, DateTime.Now.Date, "RTPOSITIVE",
					iuvToSearch);

				var request = new IntesaSanPaolo.pdpEsitiRT(body);
				var response = servizio.pdpEsitiRT(request);
				InfoGroup.ct0000000007_pdpEsitiRTResultType result;
				if (response?.Body != null)
				{
					result = response.Body.Result;
				}
				else
				{
					errore = "Il server ha restituito una risposta non valida.";
					return errore;
				}

				Console.WriteLine(Encoding.ASCII.GetString(response.Body.pdpEsitiRTResult.param));


				if (!result.esitoOperazione.Equals(InfoGroup.ct0000000007_pdpEsitiRTResultTypeEsitoOperazione.OK))
				{
					if (result.codiceErrore == InfoGroup.ct0000000007_pdpEsitiRTResultTypeCodiceErrore
							.WS_ESITI_RT_NESSUN_RISULTATO)
					{
						return null;
					}

					errore = $"Il server ha restituito il codice di errore '{result.codiceErrore}'.";
					//Console.WriteLine(errore); //usato nel progetto TestServizioIntesaSanPaolo per verificare funzionamento
					return errore;
				}



				foreach (var ricevutaTelematica in result.listaRicevutaTelematica)
				{
					var singoloPagamento = ricevutaTelematica.datiSingoloPagamento;
					//var ricevutaTelematica = result.ricevutaTelematica;
					var iuv = ricevutaTelematica.identificativoUnivocoVersamento.ToUpper();
					var codiceBollettino = ricevutaTelematica.idTenant;
					var dataIncasso = ricevutaTelematica.dataInvioRt;
					if (iuv != iuvToSearch) continue;

					//Cerca incassi giÃƒÆ’Ã‚Â  presenti sia tramite iuv che tramite codice bollettino (iduniqueformcode) ove possibile
					var incassiDetail = ds.flussoincassidetail.getFromDb(conn, q.eq("iuv", iuv));
					if (incassiDetail.Length == 0 && !string.IsNullOrEmpty(codiceBollettino))
					{
						incassiDetail = ds.flussoincassidetail.get(conn,
							q.eq("iduniqueformcode", codiceBollettino) & q.isNull("iuv"));
					}

					if (incassiDetail.Length > 0)
					{
						//Lo IUV ÃƒÆ’Ã‚Â¨ stato giÃƒÆ’Ã‚Â  associato ad un flusso incassi. Potrebbero anche esserci piÃƒÆ’Ã‚Â¹ righe di dett. flusso incassi
						//Se lo iuv ÃƒÆ’Ã‚Â¨ presente sicuramente anche ove ci siano altre righe con pari iuv saranno nello stesso sospeso
						//Se tali righe sono presenti ed inserite dal prog. di segreteria, avranno certamente il codice bollettino
						//  giÃƒÆ’Ã‚Â  valorizzato, tuttavia la riga di incasso potrebbe mancare di informazioni importanti che la banca invece fornisce

						//se l'incasso collegato non ha il n. di sospeso, lo valorizza                        
						foreach (var incassoDetail in incassiDetail)
						{
							if (incassoDetail.iuv == null) incassoDetail.iuv = iuv;
							//per tutti i dettagli incassi trovati, che dovrebbe essere uno solo, 
							//  valorizza i dati eventualmente mancanti:N. di provvisorio, codice flusso, TRN, causale
							var incasso = ds.flussoincassi.get(conn, q.eq("idflusso", incassoDetail.idflusso))[0];
							if (incasso.nbill == null && !string.IsNullOrEmpty(singoloPagamento.provvisorioEntrata))
							{
								incasso.nbill = Convert.ToInt32(singoloPagamento.provvisorioEntrata);
							}

							if (string.IsNullOrEmpty(incasso.codiceflusso) &&
								!string.IsNullOrEmpty(singoloPagamento.idFlusso))
							{
								//Codice identificativo flusso rendicontazione standard PagoPA 
								incasso.codiceflusso = singoloPagamento.idFlusso;
							}

							if (string.IsNullOrEmpty(incasso.trn) &&
								!string.IsNullOrEmpty(singoloPagamento.identificativoUnivocoRegolamento))
							{
								//Identificativo Bonifico Sepa (Transaction Reference NumberÃƒÂ¢Ã¢â€šÂ¬Ã‚Â (TRN) ) del Bonifico cumulative
								//  effettuato dal PSP, presente nel flusso di rendicontazione standard AgID 
								incasso.trn = singoloPagamento.identificativoUnivocoRegolamento;
							}

							if (string.IsNullOrEmpty(incasso.causale) &&
								!string.IsNullOrEmpty(singoloPagamento.idFlusso))
							{
								incasso.causale = "/PUR/LGPE-RIVERSAMENTO/URI/" + singoloPagamento.idFlusso;
							}

						}

						continue; //non deve fare altro per questa riga, se era presente evidentemente ha giÃƒÆ’Ã‚Â  i valori del bollettino valorizzati
					}


					flussoincassiRow rFlussoIncassi = null;
					if (!string.IsNullOrEmpty(singoloPagamento.idFlusso))
					{
						rFlussoIncassi = ds.flussoincassi.get(conn, q.eq("codiceflusso", singoloPagamento.idFlusso))
							.FirstOrDefault();
					}
					else
					{
						if (!string.IsNullOrEmpty(singoloPagamento.identificativoUnivocoRegolamento))
						{
							rFlussoIncassi = ds.flussoincassi
								.get(conn, q.eq("trn", singoloPagamento.identificativoUnivocoRegolamento))
								.FirstOrDefault();
						}
					}

					if (rFlussoIncassi == null)
					{
						var idflusso = MetaData.MaxFromColumn(ds.flussoincassi, "idflusso") + 1;
						if (idflusso < 99990000) idflusso = 99990000;

						rFlussoIncassi = ds.flussoincassi.newRow();
						rFlussoIncassi.idflusso = idflusso;

						//Codice identificativo flusso rendicontazione standard PagoPA 
						rFlussoIncassi.codiceflusso = singoloPagamento.idFlusso;

						//Identificativo Bonifico Sepa (Transaction Reference NumberÃƒÂ¢Ã¢â€šÂ¬Ã‚Â (TRN) ) del Bonifico cumulative
						//  effettuato dal PSP, presente nel flusso di rendicontazione standard AgID 
						rFlussoIncassi.trn = singoloPagamento.identificativoUnivocoRegolamento;
						rFlussoIncassi.importo = 0;
						rFlussoIncassi.to_complete = "N";
						rFlussoIncassi.elaborato = "N";
						rFlussoIncassi.active = "S";
						rFlussoIncassi["idsor01"] = DBNull.Value;
						rFlussoIncassi["idsor02"] = DBNull.Value;
						rFlussoIncassi["idsor03"] = DBNull.Value;
						rFlussoIncassi["idsor04"] = DBNull.Value;
						rFlussoIncassi["idsor05"] = DBNull.Value;
						rFlussoIncassi["ct"] = DateTime.Now;
						rFlussoIncassi["cu"] = "import_esiti_intesa";

						ds.flussoincassi.Rows.Add(rFlussoIncassi);
					}
					else
					{
						ds.flussoincassidetail.get(conn, q.eq("idflusso", rFlussoIncassi.idflusso));
					}

					rFlussoIncassi.ayear = (short)conn.GetEsercizio();
					if (!string.IsNullOrEmpty(singoloPagamento.idFlusso))
					{
						rFlussoIncassi.causale = "/PUR/LGPE-RIVERSAMENTO/URI/" + singoloPagamento.idFlusso;
					}

					rFlussoIncassi.dataincasso = dataIncasso;
					if (dataIncasso != null)
					{
						rFlussoIncassi.ayear = (short)dataIncasso.Year;
					}

					//Informazione reperita sul Giornale di Cassa di Tesoreria, presente solo nel caso di attivazione 
					//  del modulo di Riconciliazione e se rispettati i tempi tecnici necessari. 
					if (!string.IsNullOrEmpty(singoloPagamento.provvisorioEntrata))
					{
						rFlussoIncassi.nbill = Convert.ToInt32(singoloPagamento.provvisorioEntrata);
					}


					//Esamina il caso in cui lo IUV non risulta ancora tra gli incassi registrati
					//Cerchiamo di creare un flussoincassi per ogni TRN o IDFLUSSO
					//if (string.IsNullOrEmpty(singoloPagamento.provvisorioEntrata) && string.IsNullOrEmpty(singoloPagamento.idFlusso)) continue; 


					//vede se ci sono giÃƒÆ’Ã‚Â  crediti collegati allo iuv (per esempio quelli che trasmettiamo noi)
					var crediti = ds.flussocreditidetail.get(conn, q.eq("iuv", iuv) & q.isNull("annulment"));

					if (crediti.Length == 0 && !string.IsNullOrEmpty(codiceBollettino))
					{
						//cerca di collegare i crediti tramite codice bollettino ove presente nella ricevuta telematica
						crediti = ds.flussocreditidetail.get(conn,
							q.eq("iduniqueformcode", codiceBollettino) & q.isNull("iuv") & q.isNull("annulment"));
					}

					//A questo bisogna creare il flusso incassi legandolo eventualmente ai crediti esistenti



					var importoFlusso = rFlussoIncassi.importo ?? 0;

					importoFlusso += singoloPagamento.importoSingoloVersamento;
					string iduniqueformcode = null;

					var iddetail = MetaData.MaxFromColumn(ds.flussoincassidetail, "iddetail") + 1;
					if (iddetail < 99990000) iddetail = 99990000;
					decimal importoCreditiAssegnati = 0;
					foreach (var credito in crediti)
					{
						credito.iuv = iuv;

						if (iduniqueformcode == null)
							iduniqueformcode =
								credito.iduniqueformcode ??
								codiceBollettino; //TODO: verificare che la banca ci invii il nostro iduniqueformcode

						//var rFlussoIncassiDetail = ds.flussoincassidetail.newRow();
						//rFlussoIncassiDetail.idflusso = rFlussoIncassi.idflusso;
						//rFlussoIncassiDetail.iddetail = iddetail;
						//iddetail++;
						//rFlussoIncassiDetail.importo = credito.importoversamento ??0;
						//if (credito.tax.HasValue) rFlussoIncassiDetail.importo += credito.tax;

						//importoCreditiAssegnati += credito.importoversamento ?? 0;
						//rFlussoIncassiDetail.iduniqueformcode = credito.iduniqueformcode ?? codiceBollettino;
						//rFlussoIncassiDetail.iuv = iuv;
						//rFlussoIncassiDetail.ct = DateTime.Now;
						//rFlussoIncassiDetail.cu = "import_esiti_intesa";
						//rFlussoIncassiDetail.lt = DateTime.Now;
						//rFlussoIncassiDetail.lu = "import_esiti_intesa";
						//rFlussoIncassiDetail["cf"] =
						//    (ricevutaTelematica.tipoIdentificativoUnivocoPagatore ==
						//     ct0000000008_ricevutaTelematicaTypeTipoIdentificativoUnivocoPagatore.F)
						//        ? (object) ricevutaTelematica.codiceIdentificativoUnivocoPagatore
						//        : DBNull.Value;
						//rFlussoIncassiDetail["p_iva"] =
						//    (ricevutaTelematica.tipoIdentificativoUnivocoPagatore ==
						//     ct0000000008_ricevutaTelematicaTypeTipoIdentificativoUnivocoPagatore.G)
						//        ? (object) ricevutaTelematica.codiceIdentificativoUnivocoPagatore
						//        : DBNull.Value;
						//ds.flussoincassidetail.Rows.Add(rFlussoIncassiDetail);
					}

					if (singoloPagamento.importoSingoloVersamento > importoCreditiAssegnati)
					{
						//Non ci sono crediti associati, crea una sola riga con il codice bollettino dato, sperando sia il nostro
						var rFlussoIncassiDetail = ds.flussoincassidetail.newRow();
						rFlussoIncassiDetail.idflusso = rFlussoIncassi.idflusso;
						rFlussoIncassiDetail.iddetail = iddetail;
						rFlussoIncassiDetail.importo =
							singoloPagamento.importoSingoloVersamento - importoCreditiAssegnati;
						rFlussoIncassiDetail.iduniqueformcode =
							codiceBollettino; //TODO: verificare che la banca ci invii il nostro iduniqueformcode
						rFlussoIncassiDetail.iuv = iuv;
						rFlussoIncassiDetail.ct = DateTime.Now;
						rFlussoIncassiDetail.cu = "import_esiti_intesa";
						rFlussoIncassiDetail.lt = DateTime.Now;
						rFlussoIncassiDetail.lu = "import_esiti_intesa";
						rFlussoIncassiDetail["cf"] =
							(ricevutaTelematica.tipoIdentificativoUnivocoPagatore ==
							 ct0000000008_ricevutaTelematicaTypeTipoIdentificativoUnivocoPagatore.F)
								? (object)ricevutaTelematica.codiceIdentificativoUnivocoPagatore
								: DBNull.Value;
						rFlussoIncassiDetail["p_iva"] =
							(ricevutaTelematica.tipoIdentificativoUnivocoPagatore ==
							 ct0000000008_ricevutaTelematicaTypeTipoIdentificativoUnivocoPagatore.G)
								? (object)ricevutaTelematica.codiceIdentificativoUnivocoPagatore
								: DBNull.Value;
						ds.flussoincassidetail.Rows.Add(rFlussoIncassiDetail);

					}


					rFlussoIncassi.importo = importoFlusso;
					rFlussoIncassi.lt = DateTime.Now;
					rFlussoIncassi.lu = "import_esiti_intesa";
				}



			}
			catch (Exception ex)
			{
				errore = ex.Message;
			}
			finally
			{
				if (string.IsNullOrEmpty(errore))
				{
					var p = new Easy_PostData_NoBL();
					p.initClass(ds, conn);

					var pc = p.DO_POST_SERVICE();
					if (pc.Count > 0)
					{
						if (errore == null)
						{
							errore += "\n\rErrore nel salvataggio";
						}
						else
						{
							errore += "Errore nel salvataggio";
						}

						for (var i = 0; i < pc.Count; i++)
						{
							errore += "\n\r" + pc.GetMessage(i).LongMess;
						}
					}
				}
			}

			return errore;
		}


		private static string aggiornaValtellineseRT(string[] config, DataAccess conn, string iuvToSearch)
		{
			string errore = null;

			var esercizio = conn.GetEsercizio();
			var dataContabile = conn.GetDataContabile();
			// Parametri del servizio (utente/password/CODICE_AZIENDA/URLSoap/userRest/pwdRest/URLRest/codicepartitarioRest)
			// WS_COM_CREV|**********|CRE14|https://service.pmpay.it/|unicatuser|**********|https://service.pmpay.it/Rest/|COD_SERV_STUDENTE
			//var utente = config[0];  // utente ambiente SOAP
			//var password = config[1]; // password ambiente SOAP
			//string codiceAzienda = config[2]; // codice azienda
			//string urlSoap = config[3]; // url ambiente SOAP
			//string userRest = config[4]; // utente ambiente REST
			//string pwdRest = config[5]; //password ambiente REST
			//string urlRest = config[6];   // url ambiente REST
			//string codicepartitarioRest = config[7]; // codice partitario ambiente REST

			//// Parametri del servizio            (partnerconfig ha come   token il codice del partner ossia valyellinese in questo caso
			//var identificativoDominio = config[8];       // Parametro fornito da Banca Credito Valtellinese:    
			//var identificativoBu = config[9];            // Parametro fornito da Banca Credito Valtellinese:      
			//var identificativoServizio = config[10];     // Parametro fornito da Banca Credito Valtellinese  

			//// Parametri del servizio (utente/password/CODICE_AZIENDA/URL)
			//var utente = config[0];
			//var password = config[1];
			//string codiceAzienda = config[2];
			//var url = config[3];


			//var utente = "WS_COM_CREV"; // utente ambiente SOAP
			//var password = "**********"; // password ambiente SOAP
			string codiceAzienda = "CRE14"; // codice azienda
											//string urlSoap = "https://service.pmpay.it/"; // url ambiente SOAP
			string userRest = "unicatuser"; // utente ambiente REST
			string pwdRest = "**********"; //password ambiente REST
			string urlRest = "https://service.pmpay.it/Rest"; // url ambiente REST
															  //string codicepartitarioRest = "COD_SERV_STUDENTE"; // codice partitario ambiente REST


			// Connessione al DB
			var qhs = conn.GetQueryHelper();
			var qhc = new CQueryHelper();

			// DataSet
			var ds = new dsmeta();
			ds.flussoincassi.setDefault("ayear", esercizio);
			ds.flussoincassi.setDefault("to_complete", "N");
			ds.flussoincassi.setDefault("elaborato", "N");
			ds.flussoincassi.setDefault("active", "S");

			// Imposta autoincremento e selettori
			ds.flussoincassi.setAutoincrement("idflusso", null, null, 0);
			ds.flussoincassidetail.setSelector("idflusso");
			ds.flussoincassidetail.setAutoincrement("iddetail", null, null, 0);

			// Servizio Autenticazione REST
			// per le elaborazioni massive usiamo il web service REST effettuando la richiesta di aggiornamento degli IUV non ancora elaborati
			// https://service.pmpay.it/Rest/ricevutetelematiche / get ? creditore =< CODICE_ENTE_CREDITORE >| FileRisposta   ricerca parametrica per Ente
			ValtellineseREST rClient = new ValtellineseREST(urlRest, userRest, pwdRest);


			//8.GetRicevuteTelematiche
			//Consente di  recuperare lÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢elenco delle ricevute telematiche disponibili dall'ultima richiesta.
			//Le singole RT andranno poi recuperate mediante metodo getRicevutaTelematica

			//La chiamata REST (con basic authentication) ÃƒÆ’Ã‚Â¨:
			//< url_end_point_PMPAY >/ ricevutetelematiche / get ? creditore =< CODICE_ENTE_CREDITORE >| FileRisposta

			//LÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢operazione restituisce un file CSV composto dai campi
			//CREDITORE | IDENTIFICATIVO_PAGAMENTO(IUV),
			List<string> elencoIUV = new List<string>();
			// Ottengo l'elenco delle ricevute telematiche se non ho specificato un valore particolare;
			if (iuvToSearch == null)
			{
				elencoIUV = rClient.GetRicevuteTelematiche(codiceAzienda, out errore);
				if (errore != "") return errore;
			}
			else
			{
				elencoIUV.Add(iuvToSearch);
			}
			// Ciclo su Elenco IUV da acquisire per ottenere le singole Ricevute Telematiche da elaborare

			try
			{
				foreach (var iuvRT in elencoIUV)
				{
					RT ricevutaTelematica =
						rClient.GetRicevutaTelematica(codiceAzienda, iuvRT,
							out errore); // Chiamata Metodo REST di acquisizione della Ricevuta Telematica
					if (errore != "") return errore;
					if (ricevutaTelematica == null)
					{
						errore = $" Errore nell'acquisizione della ricevuta telematica per lo IUV:  {iuvRT} ";
						continue;
					}

					var singoloPagamento = ricevutaTelematica.datiPagamento.datiSingoloPagamento;
					//var ricevutaTelematica = result.ricevutaTelematica;
					var iuv = ricevutaTelematica.datiPagamento.identificativoUnivocoVersamento;
					// questo non va bene come codice bollettino univoco
					var codiceBollettino = ricevutaTelematica.datiPagamento.datiSingoloPagamento
						.identificativoUnivocoRiscossione;
					var dataIncasso = ricevutaTelematica.datiPagamento.datiSingoloPagamento.dataEsitoSingoloPagamento;


					//Cerca incassi giÃƒÆ’Ã‚Â  presenti sia tramite iuv che tramite codice bollettino (iduniqueformcode) ove possibile
					var incassiDetail = ds.flussoincassidetail.getFromDb(conn, q.eq("iuv", iuv));
					if (incassiDetail.Length == 0 && !string.IsNullOrEmpty(codiceBollettino))
					{
						incassiDetail = ds.flussoincassidetail.get(conn,
							q.eq("iduniqueformcode", codiceBollettino) & q.isNull("iuv"));
					}

					if (incassiDetail.Length > 0)
					{
						//Lo IUV ÃƒÆ’Ã‚Â¨ stato giÃƒÆ’Ã‚Â  associato ad un flusso incassi. Potrebbero anche esserci piÃƒÆ’Ã‚Â¹ righe di dett. flusso incassi
						//Se lo iuv ÃƒÆ’Ã‚Â¨ presente sicuramente anche ove ci siano altre righe con pari iuv saranno nello stesso sospeso
						//Se tali righe sono presenti ed inserite dal prog. di segreteria, avranno certamente il codice bollettino
						//  giÃƒÆ’Ã‚Â  valorizzato, tuttavia la riga di incasso potrebbe mancare di informazioni importanti che la banca invece fornisce

						//se l'incasso collegato non ha il n. di sospeso, lo valorizza                        
						foreach (var incassoDetail in incassiDetail)
						{
							if (incassoDetail.iuv == null) incassoDetail.iuv = iuv;
							//per tutti i dettagli incassi trovati, che dovrebbe essere uno solo, 
							//  valorizza i dati eventualmente mancanti:N. di provvisorio, codice flusso, TRN, causale
							var incasso = ds.flussoincassi.get(conn, q.eq("idflusso", incassoDetail.idflusso))[0];

							// c'ÃƒÆ’Ã‚Â¨ bisogno di sapere dove troviamo il riferimento al provvisorio di entrata 
							//if (incasso.nbill == null && !string.IsNullOrEmpty(singoloPagamento.provvisorioEntrata)) {
							//    incasso.nbill = Convert.ToInt32(singoloPagamento.provvisorioEntrata);
							//}
							// non troviamo un campo che contenga idflusso
							//if (string.IsNullOrEmpty(incasso.codiceflusso) && !string.IsNullOrEmpty(singoloPagamento.idFlusso)) {
							//    //Codice identificativo flusso rendicontazione standard PagoPA 
							//    incasso.codiceflusso = singoloPagamento.idFlusso;
							//}

							if (string.IsNullOrEmpty(incasso.trn) &&
								!string.IsNullOrEmpty(singoloPagamento.identificativoUnivocoRiscossione))
							{
								//Identificativo Bonifico Sepa (Transaction Reference NumberÃƒÂ¢Ã¢â€šÂ¬Ã‚Â (TRN) ) del Bonifico cumulative
								//  effettuato dal PSP, presente nel flusso di rendicontazione standard AgID 
								incasso.trn = singoloPagamento.identificativoUnivocoRiscossione;
							}

							//if (string.IsNullOrEmpty(incasso.causale) && !string.IsNullOrEmpty(singoloPagamento.idFlusso)) {
							//    incasso.causale = "/PUR/LGPE-RIVERSAMENTO/URI/" + singoloPagamento.idFlusso;
							//}

						}

						continue; //non deve fare altro per questa riga, se era presente evidentemente ha giÃƒÆ’Ã‚Â  i valori del bollettino valorizzati
					}


					flussoincassiRow rFlussoIncassi = null;

					if (!string.IsNullOrEmpty(singoloPagamento.identificativoUnivocoRiscossione))
					{
						rFlussoIncassi = ds.flussoincassi
							.get(conn, q.eq("trn", singoloPagamento.identificativoUnivocoRiscossione))
							.FirstOrDefault();
					}


					if (rFlussoIncassi == null)
					{
						var idflusso = MetaData.MaxFromColumn(ds.flussoincassi, "idflusso") + 1;
						if (idflusso < 99990000) idflusso = 99990000;

						rFlussoIncassi = ds.flussoincassi.newRow();
						rFlussoIncassi.idflusso = idflusso;

						//Codice identificativo flusso rendicontazione standard PagoPA 
						// rFlussoIncassi.codiceflusso = singoloPagamento.idFlusso;

						//Identificativo Bonifico Sepa (Transaction Reference NumberÃƒÂ¢Ã¢â€šÂ¬Ã‚Â (TRN) ) del Bonifico cumulative
						//  effettuato dal PSP, presente nel flusso di rendicontazione standard AgID 
						rFlussoIncassi.trn = singoloPagamento.identificativoUnivocoRiscossione;
						rFlussoIncassi.importo = 0;
						rFlussoIncassi.to_complete = "N";
						rFlussoIncassi.elaborato = "N";
						rFlussoIncassi.active = "S";
						rFlussoIncassi["idsor01"] = DBNull.Value;
						rFlussoIncassi["idsor02"] = DBNull.Value;
						rFlussoIncassi["idsor03"] = DBNull.Value;
						rFlussoIncassi["idsor04"] = DBNull.Value;
						rFlussoIncassi["idsor05"] = DBNull.Value;
						rFlussoIncassi["ct"] = DateTime.Now;
						rFlussoIncassi["cu"] = "import_esiti_intesa";

						ds.flussoincassi.Rows.Add(rFlussoIncassi);
					}
					else
					{
						ds.flussoincassidetail.get(conn, q.eq("idflusso", rFlussoIncassi.idflusso));
					}

					rFlussoIncassi.ayear = (short)conn.GetEsercizio();
					//if (!string.IsNullOrEmpty(singoloPagamento.idFlusso)) {
					//    rFlussoIncassi.causale = "/PUR/LGPE-RIVERSAMENTO/URI/" + singoloPagamento.idFlusso;
					//}

					rFlussoIncassi.dataincasso = dataIncasso;
					if (dataIncasso != null) rFlussoIncassi.ayear = (short)dataIncasso.Year;

					//Informazione reperita sul Giornale di Cassa di Tesoreria, presente solo nel caso di attivazione 
					//  del modulo di Riconciliazione e se rispettati i tempi tecnici necessari. 
					//if (!string.IsNullOrEmpty(singoloPagamento.provvisorioEntrata)) {
					//    rFlussoIncassi.nbill = Convert.ToInt32(singoloPagamento.provvisorioEntrata);
					//}


					//Esamina il caso in cui lo IUV non risulta ancora tra gli incassi registrati
					//Cerchiamo di creare un flussoincassi per ogni TRN o IDFLUSSO
					//if (string.IsNullOrEmpty(singoloPagamento.provvisorioEntrata) && string.IsNullOrEmpty(singoloPagamento.idFlusso)) continue; 


					//vede se ci sono giÃƒÆ’Ã‚Â  crediti collegati allo iuv (per esempio quelli che trasmettiamo noi)
					var crediti = ds.flussocreditidetail.get(conn, q.eq("iuv", iuv) & q.isNull("annulment"));

					if (crediti.Length == 0 && !string.IsNullOrEmpty(codiceBollettino))
					{
						//cerca di collegare i crediti tramite codice bollettino ove presente nella ricevuta telematica
						crediti = ds.flussocreditidetail.get(conn,
							q.eq("iduniqueformcode", codiceBollettino) & q.isNull("iuv") & q.isNull("annulment"));
					}

					//A questo bisogna creare il flusso incassi legandolo eventualmente ai crediti esistenti



					var importoFlusso = rFlussoIncassi.importo ?? 0;

					importoFlusso += singoloPagamento.singoloImportoPagato;

					var iddetail = MetaData.MaxFromColumn(ds.flussoincassidetail, "iddetail") + 1;
					if (iddetail < 99990000) iddetail = 99990000;
					decimal importoCreditiAssegnati = 0;
					string iduniqueformcode = null;

					foreach (var credito in crediti)
					{
						credito.iuv = iuv;
						if (iduniqueformcode == null)
							iduniqueformcode =
								credito.iduniqueformcode ??
								codiceBollettino; //TODO: verificare che la banca ci invii il nostro iduniqueformcode

						//var rFlussoIncassiDetail = ds.flussoincassidetail.newRow();
						//rFlussoIncassiDetail.idflusso = rFlussoIncassi.idflusso;
						//rFlussoIncassiDetail.iddetail = iddetail;
						//iddetail++;
						//decimal importoCredito = credito.importoversamento??0;
						//if (credito.tax.HasValue) importoCredito += credito.tax??0;

						//rFlussoIncassiDetail.importo = importoCredito;
						//importoCreditiAssegnati += importoCredito;


						//rFlussoIncassiDetail.iduniqueformcode = credito.iduniqueformcode ?? codiceBollettino;
						//rFlussoIncassiDetail.iuv = iuv;
						//rFlussoIncassiDetail.ct = DateTime.Now;
						//rFlussoIncassiDetail.cu = "import_esiti_intesa";
						//rFlussoIncassiDetail.lt = DateTime.Now;
						//rFlussoIncassiDetail.lu = "import_esiti_intesa";
						//rFlussoIncassiDetail["cf"] =
						//    (ricevutaTelematica.soggettoPagatore.identificativoUnivocoPagatore.tipoIdentificativoUnivoco ==
						//     "F")
						//        ? (object)ricevutaTelematica.soggettoPagatore.identificativoUnivocoPagatore.codiceIdentificativoUnivoco
						//        : DBNull.Value;
						//rFlussoIncassiDetail["p_iva"] =
						//    (ricevutaTelematica.soggettoPagatore.identificativoUnivocoPagatore.tipoIdentificativoUnivoco ==
						//     "G")
						//     ? (object)ricevutaTelematica.soggettoPagatore.identificativoUnivocoPagatore.codiceIdentificativoUnivoco
						//        : DBNull.Value;
						//ds.flussoincassidetail.Rows.Add(rFlussoIncassiDetail);
					}

					if (singoloPagamento.singoloImportoPagato > importoCreditiAssegnati)
					{
						//Non ci sono crediti associati, crea una sola riga con il codice bollettino dato, sperando sia il nostro
						var rFlussoIncassiDetail = ds.flussoincassidetail.newRow();
						rFlussoIncassiDetail.idflusso = rFlussoIncassi.idflusso;
						rFlussoIncassiDetail.iddetail = iddetail;
						rFlussoIncassiDetail.importo = singoloPagamento.singoloImportoPagato - importoCreditiAssegnati;
						rFlussoIncassiDetail.iduniqueformcode =
							codiceBollettino; //TODO: verificare che la banca ci invii il nostro iduniqueformcode
						rFlussoIncassiDetail.iuv = iuv;
						rFlussoIncassiDetail.ct = DateTime.Now;
						rFlussoIncassiDetail.cu = "import_esiti_valtellinese";
						rFlussoIncassiDetail.lt = DateTime.Now;
						rFlussoIncassiDetail.lu = "import_esiti_valtellinese";
						rFlussoIncassiDetail["cf"] =
							(ricevutaTelematica.soggettoPagatore.identificativoUnivocoPagatore
								 .tipoIdentificativoUnivoco ==
							 "F")
								? (object)ricevutaTelematica.soggettoPagatore.identificativoUnivocoPagatore
									.codiceIdentificativoUnivoco
								: DBNull.Value;
						rFlussoIncassiDetail["p_iva"] =
							(ricevutaTelematica.soggettoPagatore.identificativoUnivocoPagatore
								 .tipoIdentificativoUnivoco ==
							 "G")
								? (object)ricevutaTelematica.soggettoPagatore.identificativoUnivocoPagatore
									.codiceIdentificativoUnivoco
								: DBNull.Value;
						ds.flussoincassidetail.Rows.Add(rFlussoIncassiDetail);
					}


					rFlussoIncassi.importo = importoFlusso;
					rFlussoIncassi.lt = DateTime.Now;
					rFlussoIncassi.lu = "import_esiti_valtellinese";
				}



			}
			catch (Exception ex)
			{
				errore = ex.Message;
			}
			finally
			{
				if (string.IsNullOrEmpty(errore))
				{
					var p = new Easy_PostData_NoBL();
					p.initClass(ds, conn);

					var pc = p.DO_POST_SERVICE();
					if (pc.Count > 0)
					{
						if (errore == null)
						{
							errore += "\n\rErrore nel salvataggio";
						}
						else
						{
							errore += "Errore nel salvataggio";
						}

						for (var i = 0; i < pc.Count; i++)
						{
							errore += "\n\r" + pc.GetMessage(i).LongMess;
						}
					}
				}
			}

			return errore;
		}
		private static bool elaboraFlussoRiversamentoGovPay(GovPay.EstremiFlussoRendicontazione flusso,
				GovPay.gpChiediFlussoRendicontazioneResponse rendicontoResp,
				DataAccess conn,
			string iuvToSearch, out string errore)
		{
			dsmeta ds = new dsmeta();
			var rendiconto = rendicontoResp.body.flussoRendicontazione;


			errore = null;
			ds.flussoincassi.setDefault("ayear", conn.GetEsercizio());
			ds.flussoincassi.setDefault("to_complete", "N");
			ds.flussoincassi.setDefault("elaborato", "N");
			ds.flussoincassi.setDefault("active", "S");

			// Imposta autoincremento e selettori
			ds.flussoincassi.setAutoincrement("idflusso", null, null, 0);
			ds.flussoincassidetail.setSelector("idflusso");
			ds.flussoincassidetail.setAutoincrement("iddetail", null, null, 0);

			ClearDataSet.RemoveConstraints(ds);

			try
			{
				var codiceFlusso = rendiconto.codFlusso; //2018-08-27ABI03111-4Q02500000002424
														 // questo non va bene come codice bollettino univoco

				var dataRegolamento = rendiconto.dataRegolamento;
				//var codiceBicBancaDiRiversamento = rendiconto.codiceBicBancaDiRiversamento;
				//var dataOraFlusso = rendiconto.dataOraFlusso;
				var identificativoUnivocoRegolamento =
					rendiconto.iur; //Bonifico SEPA-03111-4Q025
				string codicePSP = flusso.codPsp;

				var singoliPagamenti = rendiconto.pagamento.ToList();

				if (iuvToSearch != null)
				{
					var result = singoliPagamenti.Find(x =>
						x.iuv == iuvToSearch &&
						(x.esitoRendicontazione != FlussoRendicontazione.DatiPagamento.EsitoRendicontazione.REVOCATO));
					if (result == null) return false; // salta elaborazione di questo rendiconto
				}

				// elaborazione dei singoli pagamento
				foreach (var singoloPagamento in singoliPagamenti)
				{
					var codiceEsitoSingoloPagamento = singoloPagamento.esitoRendicontazione;
					if (codiceEsitoSingoloPagamento == FlussoRendicontazione.DatiPagamento.EsitoRendicontazione.REVOCATO) continue; // solo esito positivo
					string iuv = singoloPagamento.iuv; //918213010000181
					string identificativoUnivocoRiscossione =
						singoloPagamento.iur; //1830311100326023976

					DateTime dataEsitoSingoloPagamento = singoloPagamento.dataRendicontazione;
					//var indiceDatiSingoloPagamento = singoloPagamento.indiceDatiSingoloPagamento;
					decimal singoloImportoPagato = singoloPagamento.importoRendicontato;

					//Cerca incassi giÃƒÆ’Ã‚Â  presenti   tramite iuv 
					var incassiDetail = ds.flussoincassidetail.getFromDb(conn, q.eq("iuv", iuv));

					if (incassiDetail.Length > 0)
					{
						//Lo IUV ÃƒÆ’Ã‚Â¨ stato giÃƒÆ’Ã‚Â  associato ad un flusso incassi. Potrebbero anche esserci piÃƒÆ’Ã‚Â¹ righe di dett. flusso incassi
						//Se lo iuv ÃƒÆ’Ã‚Â¨ presente sicuramente anche ove ci siano altre righe con pari iuv saranno nello stesso sospeso
						//Se tali righe sono presenti ed inserite dal prog. di segreteria, avranno certamente il codice bollettino
						//  giÃƒÆ’Ã‚Â  valorizzato, tuttavia la riga di incasso potrebbe mancare di informazioni importanti che la banca invece fornisce

						//se l'incasso collegato non ha il n. di sospeso, lo valorizza                        
						foreach (var incassoDetail in incassiDetail)
						{
							if (string.IsNullOrEmpty(incassoDetail.iuv)) incassoDetail.iuv = iuv;
							//per tutti i dettagli incassi trovati, che dovrebbe essere uno solo, 
							//  valorizza i dati eventualmente mancanti:N. di provvisorio, codice flusso, TRN, causale
							var incasso = ds.flussoincassi.get(conn, q.eq("idflusso", incassoDetail.idflusso))[0];


							if (string.IsNullOrEmpty(incasso.codiceflusso))
							{
								//Codice identificativo flusso rendicontazione standard PagoPA 
								incasso.codiceflusso = codiceFlusso;
							}

							if (string.IsNullOrEmpty(incasso.trn) &&
								!string.IsNullOrEmpty(identificativoUnivocoRegolamento))
							{
								//Identificativo Bonifico Sepa (Transaction Reference NumberÃƒÂ¢Ã¢â€šÂ¬Ã‚Â (TRN) ) del Bonifico cumulative
								//  effettuato dal PSP, presente nel flusso di rendicontazione standard AgID 
								incasso.trn = identificativoUnivocoRegolamento;
							}

							//il PSP del
							//pagatore ha facoltÃƒÆ’Ã‚Â  di effettuare il riversamento delle somme incassate in modalitÃƒÆ’Ã‚Â  cumulativa per
							//Ente Creditore beneficiario.
							//Il relativo accredito(SCT) deve riportare nel dato ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œUnstructured Remittance InformationÃƒÂ¢Ã¢â€šÂ¬Ã‚Â
							//(attributo AT - 05, cfr.SEPA Credit Transfert Scheme Rulebook) le seguenti informazioni, articolate
							// secondo la giÃƒÆ’Ã‚Â  utilizzata strutturazione raccomandata dalla EACT:
							/// PUR /< purpose >/ URI /< identificativoFlusso >
							//Dove:
							//ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œ/ PUR /ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â e ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œ/ URI /ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â sono costanti (tag)definite dallo standard EACT,
							//    < purpose > rappresenta la codifica dello ÃƒÂ¢Ã¢â€šÂ¬Ã‹Å“scopoÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ (PURpose)del SCT, e deve riportare il valore
							//    prefissato LGPE - RIVERSAMENTO
							//    < idFlusso > specifica il dato relativo allÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢informazione identificativoFlusso presente nel flusso di
							//    rendicontazione descritto nel successivo capitolo 7.
							if (string.IsNullOrEmpty(incasso.causale) && !string.IsNullOrEmpty(codiceFlusso))
							{
								incasso.causale =
									"/PUR/LGPE-RIVERSAMENTO/URI/" + codiceFlusso; //2018-08-27ABI03111-4Q02500000002424
							}

						}

						continue; //non deve fare altro per questa riga, se era presente evidentemente ha giÃƒÆ’Ã‚Â  i valori del bollettino valorizzati
					}

					flussoincassiRow rFlussoIncassi = null;
					if (!string.IsNullOrEmpty(codiceFlusso))
					{ //2018-08-27ABI03111-4Q02500000002424
						rFlussoIncassi = ds.flussoincassi.get(conn, q.eq("codiceflusso", codiceFlusso))
							.FirstOrDefault();
					}
					else
					{
						if (!string.IsNullOrEmpty(identificativoUnivocoRegolamento))
						{ //Bonifico SEPA-03111-4Q025
							rFlussoIncassi = ds.flussoincassi
								.get(conn, q.eq("trn", identificativoUnivocoRegolamento))
								.FirstOrDefault();
						}
					}

					if (rFlussoIncassi == null)
					{
						var idflusso = MetaData.MaxFromColumn(ds.flussoincassi, "idflusso") + 1;
						if (idflusso < 99990000) idflusso = 99990000;

						rFlussoIncassi = ds.flussoincassi.newRow();
						rFlussoIncassi.idflusso = idflusso;

						//Codice identificativo flusso rendicontazione standard PagoPA 
						rFlussoIncassi["codiceflusso"] = codiceFlusso;

						//Identificativo Bonifico Sepa (Transaction Reference NumberÃƒÂ¢Ã¢â€šÂ¬Ã‚Â (TRN) ) del Bonifico cumulative
						//  effettuato dal PSP, presente nel flusso di rendicontazione standard AgID 
						rFlussoIncassi.trn = identificativoUnivocoRegolamento;
						rFlussoIncassi.importo = 0;
						rFlussoIncassi.to_complete = "N";
						rFlussoIncassi.elaborato = "N";
						rFlussoIncassi.active = "S";
						rFlussoIncassi["idsor01"] = DBNull.Value;
						rFlussoIncassi["idsor02"] = DBNull.Value;
						rFlussoIncassi["idsor03"] = DBNull.Value;
						rFlussoIncassi["idsor04"] = DBNull.Value;
						rFlussoIncassi["idsor05"] = DBNull.Value;
						rFlussoIncassi["ct"] = DateTime.Now;
						rFlussoIncassi["cu"] = "import_esiti_valtellinese";

						ds.flussoincassi.Rows.Add(rFlussoIncassi);
					}
					else
					{
						ds.flussoincassidetail.get(conn, q.eq("idflusso", rFlussoIncassi["idflusso"]));
					}

					rFlussoIncassi["ayear"] = (short)conn.GetEsercizio();
					if (!string.IsNullOrEmpty(codiceFlusso))
					{
						rFlussoIncassi["causale"] = "/PUR/LGPE-RIVERSAMENTO/URI/" + codiceFlusso;
					}

					rFlussoIncassi.dataincasso = dataRegolamento;
					if (dataRegolamento != null) rFlussoIncassi.ayear = (short)dataRegolamento.Year;

					//Esamina il caso in cui lo IUV non risulta ancora tra gli incassi registrati
					//Cerchiamo di creare un flussoincassi per ogni TRN o IDFLUSSO
					//if (string.IsNullOrEmpty(singoloPagamento.provvisorioEntrata) && string.IsNullOrEmpty(singoloPagamento.idFlusso)) continue; 


					//vede se ci sono giÃƒÆ’Ã‚Â  crediti collegati allo iuv (per esempio quelli che trasmettiamo noi)
					var crediti = ds.flussocreditidetail.get(conn, q.eq("iuv", iuv) & q.isNull("annulment"));

					//if (crediti.Length == 0 && !string.IsNullOrEmpty(codiceBollettino)) {
					//    //cerca di collegare i crediti tramite codice bollettino ove presente nella ricevuta telematica
					//    crediti = ds.flussocreditidetail.get(conn, q.eq("iduniqueformcode", codiceBollettino) & q.isNull("iuv") & q.isNull("annulment"));
					//}

					//A questo bisogna creare il flusso incassi legandolo eventualmente ai crediti esistenti



					var importoFlusso = rFlussoIncassi.importo ?? 0;

					importoFlusso += singoloImportoPagato;

					var iddetail = MetaData.MaxFromColumn(ds.flussoincassidetail, "iddetail") + 1;
					if (iddetail < 99990000) iddetail = 99990000;
					decimal importoCreditiAssegnati = 0;
					foreach (var credito in crediti)
					{
						credito.iuv = iuv;
						var rFlussoIncassiDetail = ds.flussoincassidetail.newRow();
						rFlussoIncassiDetail.idflusso = rFlussoIncassi.idflusso;
						rFlussoIncassiDetail.iddetail = iddetail;
						iddetail++;
						rFlussoIncassiDetail.importo = CfgFn.GetNoNullDecimal(credito["importoversamento"]);
						importoCreditiAssegnati += CfgFn.GetNoNullDecimal(credito["importoversamento"]);
						rFlussoIncassiDetail["iduniqueformcode"] = credito["iduniqueformcode"];
						rFlussoIncassiDetail.iuv = iuv;
						rFlussoIncassiDetail["dataesitopagamento"] = dataEsitoSingoloPagamento;
						rFlussoIncassiDetail["codicepsp"] = codicePSP;
						rFlussoIncassiDetail["identificativounivocoriscossione"] = identificativoUnivocoRiscossione;
						rFlussoIncassiDetail["ct"] = DateTime.Now;
						rFlussoIncassiDetail["cu"] = "flusso_riversamento";
						rFlussoIncassiDetail["lt"] = DateTime.Now;
						rFlussoIncassiDetail["lu"] = "flusso_riversamento";
						rFlussoIncassiDetail.cf = credito.cf;
						rFlussoIncassiDetail.p_iva = credito.p_iva;
						ds.flussoincassidetail.Rows.Add(rFlussoIncassiDetail);
					}

					if (singoloPagamento.importoRendicontato > importoCreditiAssegnati)
					{
						//Non ci sono crediti associati, crea una sola riga con il codice bollettino dato, sperando sia il nostro
						var rFlussoIncassiDetail = ds.flussoincassidetail.newRow();
						rFlussoIncassiDetail.idflusso = rFlussoIncassi.idflusso;
						rFlussoIncassiDetail.iddetail = iddetail;
						iddetail++;
						rFlussoIncassiDetail.importo = singoloPagamento.importoRendicontato - importoCreditiAssegnati;
						// non sembra sia possibile valorizzare codice bollettino
						//rFlussoIncassiDetail.iduniqueformcode = codiceBollettino;//TODO: verificare che la banca ci invii il nostro iduniqueformcode
						rFlussoIncassiDetail.iuv = iuv;
						rFlussoIncassiDetail["ct"] = DateTime.Now;
						rFlussoIncassiDetail["cu"] = "flusso_riversamento";
						rFlussoIncassiDetail["lt"] = DateTime.Now;
						rFlussoIncassiDetail["lu"] = "flusso_riversamento";
						// con i dati del rendiconto non riesco a valorizzare il codice fiscale /la partita iva del pagatore, 
						// sono dati eventualmente contenuti nella ricevita telematica RT che dovrei recuperare
						// rFlussoIncassiDetail["cf"] =DBNull.Value

						// rFlussoIncassiDetail["p_iva"] =DBNull.Value;

						ds.flussoincassidetail.Rows.Add(rFlussoIncassiDetail);

					}


					rFlussoIncassi["importo"] = importoFlusso;
					rFlussoIncassi["lt"] = DateTime.Now;
					rFlussoIncassi["lu"] = "flusso_riversamento";
				}
			}
			catch (Exception ex)
			{
				errore = ex.ToString();
			}

			if (string.IsNullOrEmpty(errore))
			{
				var p = new Easy_PostData_NoBL();
				p.initClass(ds, conn);

				var pc = p.DO_POST_SERVICE();
				if (pc.Count > 0)
				{
					if (errore == null)
					{
						errore += "\n\rErrore nel salvataggio";
					}
					else
					{
						errore += "Errore nel salvataggio";
					}

					for (var i = 0; i < pc.Count; i++)
					{
						errore += "\n\r" + pc.GetMessage(i).LongMess;
					}

					return false;
				}

			}

			return true;
		}



		private static bool elaboraFlussoRiversamento(FlussoRiversamento rendiconto, DataAccess conn,
			string iuvToSearch, out string errore)
		{
			dsmeta ds = new dsmeta();


			errore = null;
			ds.flussoincassi.setDefault("ayear", conn.GetEsercizio());
			ds.flussoincassi.setDefault("to_complete", "N");
			ds.flussoincassi.setDefault("elaborato", "N");
			ds.flussoincassi.setDefault("active", "S");

			// Imposta autoincremento e selettori
			ds.flussoincassi.setAutoincrement("idflusso", null, null, 0);
			ds.flussoincassidetail.setSelector("idflusso");
			ds.flussoincassidetail.setAutoincrement("iddetail", null, null, 0);

			ClearDataSet.RemoveConstraints(ds);

			try
			{
				var codiceFlusso = rendiconto.identificativoFlusso; //2018-08-27ABI03111-4Q02500000002424
																	// questo non va bene come codice bollettino univoco

				var dataRegolamento = rendiconto.dataRegolamento;
				//var codiceBicBancaDiRiversamento = rendiconto.codiceBicBancaDiRiversamento;
				//var dataOraFlusso = rendiconto.dataOraFlusso;
				var identificativoUnivocoRegolamento =
					rendiconto.identificativoUnivocoRegolamento; //Bonifico SEPA-03111-4Q025
				var istitutoMittente = rendiconto.istitutoMittente;
				var istitutoRicevente = rendiconto.istitutoRicevente;
				var versioneOggetto = rendiconto.versioneOggetto;
				var tipoIdentificativoUnivoco =
					rendiconto.istitutoMittente.identificativoUnivocoMittente.tipoIdentificativoUnivoco;
				string codiceIdentificativoUnivoco = rendiconto.istitutoMittente.identificativoUnivocoMittente
					.codiceIdentificativoUnivoco;

				List<ctDatiSingoliPagamenti> singoliPagamenti = rendiconto.datiSingoliPagamenti;

				if (iuvToSearch != null)
				{
					var result = singoliPagamenti.Find(x =>
						x.identificativoUnivocoVersamento == iuvToSearch &&
						(x.codiceEsitoSingoloPagamento != stCodiceEsitoPagamento.Item3));
					if (result == null) return true; // salta elaborazione di questo rendiconto
				}

				// elaborazione dei singoli pagamento
				foreach (var singoloPagamento in singoliPagamenti)
				{
					var codiceEsitoSingoloPagamento = singoloPagamento.codiceEsitoSingoloPagamento;
					if (codiceEsitoSingoloPagamento == stCodiceEsitoPagamento.Item3) continue; // solo esito positivo
					string iuv = singoloPagamento.identificativoUnivocoVersamento; //918213010000181
					string identificativoUnivocoRiscossione =
						singoloPagamento.identificativoUnivocoRiscossione; //1830311100326023976

					DateTime dataEsitoSingoloPagamento = singoloPagamento.dataEsitoSingoloPagamento;
					var indiceDatiSingoloPagamento = singoloPagamento.indiceDatiSingoloPagamento;
					decimal singoloImportoPagato = singoloPagamento.singoloImportoPagato;

					//Cerca incassi giÃƒÆ’Ã‚Â  presenti   tramite iuv 
					var incassiDetail = ds.flussoincassidetail.getFromDb(conn, q.eq("iuv", iuv));

					if (incassiDetail.Length > 0)
					{
						//Lo IUV ÃƒÆ’Ã‚Â¨ stato giÃƒÆ’Ã‚Â  associato ad un flusso incassi. Potrebbero anche esserci piÃƒÆ’Ã‚Â¹ righe di dett. flusso incassi
						//Se lo iuv ÃƒÆ’Ã‚Â¨ presente sicuramente anche ove ci siano altre righe con pari iuv saranno nello stesso sospeso
						//Se tali righe sono presenti ed inserite dal prog. di segreteria, avranno certamente il codice bollettino
						//  giÃƒÆ’Ã‚Â  valorizzato, tuttavia la riga di incasso potrebbe mancare di informazioni importanti che la banca invece fornisce

						//se l'incasso collegato non ha il n. di sospeso, lo valorizza                        
						foreach (var incassoDetail in incassiDetail)
						{
							if (string.IsNullOrEmpty(incassoDetail.iuv)) incassoDetail.iuv = iuv;
							//per tutti i dettagli incassi trovati, che dovrebbe essere uno solo, 
							//  valorizza i dati eventualmente mancanti:N. di provvisorio, codice flusso, TRN, causale
							var incasso = ds.flussoincassi.get(conn, q.eq("idflusso", incassoDetail.idflusso))[0];


							if (string.IsNullOrEmpty(incasso.codiceflusso))
							{
								//Codice identificativo flusso rendicontazione standard PagoPA 
								incasso.codiceflusso = codiceFlusso;
							}

							if (string.IsNullOrEmpty(incasso.trn) &&
								!string.IsNullOrEmpty(identificativoUnivocoRegolamento))
							{
								//Identificativo Bonifico Sepa (Transaction Reference NumberÃƒÂ¢Ã¢â€šÂ¬Ã‚Â (TRN) ) del Bonifico cumulative
								//  effettuato dal PSP, presente nel flusso di rendicontazione standard AgID 
								incasso.trn = identificativoUnivocoRegolamento;
							}

							//il PSP del
							//pagatore ha facoltÃƒÆ’Ã‚Â  di effettuare il riversamento delle somme incassate in modalitÃƒÆ’Ã‚Â  cumulativa per
							//Ente Creditore beneficiario.
							//Il relativo accredito(SCT) deve riportare nel dato ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œUnstructured Remittance InformationÃƒÂ¢Ã¢â€šÂ¬Ã‚Â
							//(attributo AT - 05, cfr.SEPA Credit Transfert Scheme Rulebook) le seguenti informazioni, articolate
							// secondo la giÃƒÆ’Ã‚Â  utilizzata strutturazione raccomandata dalla EACT:
							/// PUR /< purpose >/ URI /< identificativoFlusso >
							//Dove:
							//ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œ/ PUR /ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â e ÃƒÂ¢Ã¢â€šÂ¬Ã…â€œ/ URI /ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â sono costanti (tag)definite dallo standard EACT,
							//    < purpose > rappresenta la codifica dello ÃƒÂ¢Ã¢â€šÂ¬Ã‹Å“scopoÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢ (PURpose)del SCT, e deve riportare il valore
							//    prefissato LGPE - RIVERSAMENTO
							//    < idFlusso > specifica il dato relativo allÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢informazione identificativoFlusso presente nel flusso di
							//    rendicontazione descritto nel successivo capitolo 7.
							if (string.IsNullOrEmpty(incasso.causale) && !string.IsNullOrEmpty(codiceFlusso))
							{
								incasso.causale =
									"/PUR/LGPE-RIVERSAMENTO/URI/" + codiceFlusso; //2018-08-27ABI03111-4Q02500000002424
							}

						}

						continue; //non deve fare altro per questa riga, se era presente evidentemente ha giÃƒÆ’Ã‚Â  i valori del bollettino valorizzati
					}

					flussoincassiRow rFlussoIncassi = null;
					if (!string.IsNullOrEmpty(codiceFlusso))
					{ //2018-08-27ABI03111-4Q02500000002424
						rFlussoIncassi = ds.flussoincassi.get(conn, q.eq("codiceflusso", codiceFlusso))
							.FirstOrDefault();
					}
					else
					{
						if (!string.IsNullOrEmpty(identificativoUnivocoRegolamento))
						{ //Bonifico SEPA-03111-4Q025
							rFlussoIncassi = ds.flussoincassi
								.get(conn, q.eq("trn", identificativoUnivocoRegolamento))
								.FirstOrDefault();
						}
					}

					if (rFlussoIncassi == null)
					{
						var idflusso = MetaData.MaxFromColumn(ds.flussoincassi, "idflusso") + 1;
						if (idflusso < 99990000) idflusso = 99990000;

						rFlussoIncassi = ds.flussoincassi.newRow();
						rFlussoIncassi.idflusso = idflusso;

						//Codice identificativo flusso rendicontazione standard PagoPA 
						rFlussoIncassi["codiceflusso"] = codiceFlusso;

						//Identificativo Bonifico Sepa (Transaction Reference NumberÃƒÂ¢Ã¢â€šÂ¬Ã‚Â (TRN) ) del Bonifico cumulative
						//  effettuato dal PSP, presente nel flusso di rendicontazione standard AgID 
						rFlussoIncassi.trn = identificativoUnivocoRegolamento;
						rFlussoIncassi.importo = 0;
						rFlussoIncassi.to_complete = "N";
						rFlussoIncassi.elaborato = "N";
						rFlussoIncassi.active = "S";
						rFlussoIncassi["idsor01"] = DBNull.Value;
						rFlussoIncassi["idsor02"] = DBNull.Value;
						rFlussoIncassi["idsor03"] = DBNull.Value;
						rFlussoIncassi["idsor04"] = DBNull.Value;
						rFlussoIncassi["idsor05"] = DBNull.Value;
						rFlussoIncassi["ct"] = DateTime.Now;
						rFlussoIncassi["cu"] = "import_esiti_valtellinese";

						ds.flussoincassi.Rows.Add(rFlussoIncassi);
					}
					else
					{
						ds.flussoincassidetail.get(conn, q.eq("idflusso", rFlussoIncassi["idflusso"]));
					}

					rFlussoIncassi["ayear"] = (short)conn.GetEsercizio();
					if (!string.IsNullOrEmpty(codiceFlusso))
					{
						rFlussoIncassi["causale"] = "/PUR/LGPE-RIVERSAMENTO/URI/" + codiceFlusso;
					}

					rFlussoIncassi.dataincasso = dataRegolamento;
					if (dataRegolamento != null) rFlussoIncassi.ayear = (short)dataRegolamento.Year;

					//Esamina il caso in cui lo IUV non risulta ancora tra gli incassi registrati
					//Cerchiamo di creare un flussoincassi per ogni TRN o IDFLUSSO
					//if (string.IsNullOrEmpty(singoloPagamento.provvisorioEntrata) && string.IsNullOrEmpty(singoloPagamento.idFlusso)) continue; 


					//vede se ci sono giÃƒÆ’Ã‚Â  crediti collegati allo iuv (per esempio quelli che trasmettiamo noi)
					var crediti = ds.flussocreditidetail.get(conn, q.eq("iuv", iuv) & q.isNull("annulment"));

					//if (crediti.Length == 0 && !string.IsNullOrEmpty(codiceBollettino)) {
					//    //cerca di collegare i crediti tramite codice bollettino ove presente nella ricevuta telematica
					//    crediti = ds.flussocreditidetail.get(conn, q.eq("iduniqueformcode", codiceBollettino) & q.isNull("iuv") & q.isNull("annulment"));
					//}

					//A questo bisogna creare il flusso incassi legandolo eventualmente ai crediti esistenti



					var importoFlusso = rFlussoIncassi.importo ?? 0;

					importoFlusso += singoloImportoPagato;

					var iddetail = MetaData.MaxFromColumn(ds.flussoincassidetail, "iddetail") + 1;
					if (iddetail < 99990000) iddetail = 99990000;
					decimal importoCreditiAssegnati = 0;
					foreach (var credito in crediti)
					{
						credito.iuv = iuv;
						var rFlussoIncassiDetail = ds.flussoincassidetail.newRow();
						rFlussoIncassiDetail.idflusso = rFlussoIncassi.idflusso;
						rFlussoIncassiDetail.iddetail = iddetail;
						iddetail++;
						rFlussoIncassiDetail.importo = CfgFn.GetNoNullDecimal(credito["importoversamento"]);
						importoCreditiAssegnati += CfgFn.GetNoNullDecimal(credito["importoversamento"]);
						rFlussoIncassiDetail["iduniqueformcode"] = credito["iduniqueformcode"];
						rFlussoIncassiDetail.iuv = iuv;
						rFlussoIncassiDetail["dataesitopagamento"] = dataEsitoSingoloPagamento;
						rFlussoIncassiDetail["codicepsp"] = codiceIdentificativoUnivoco;
						rFlussoIncassiDetail["identificativounivocoriscossione"] = identificativoUnivocoRiscossione;
						rFlussoIncassiDetail["ct"] = DateTime.Now;
						rFlussoIncassiDetail["cu"] = "flusso_riversamento";
						rFlussoIncassiDetail["lt"] = DateTime.Now;
						rFlussoIncassiDetail["lu"] = "flusso_riversamento";
						rFlussoIncassiDetail.cf = credito.cf;
						rFlussoIncassiDetail.p_iva = credito.p_iva;
						ds.flussoincassidetail.Rows.Add(rFlussoIncassiDetail);
					}

					if (singoloPagamento.singoloImportoPagato > importoCreditiAssegnati)
					{
						//Non ci sono crediti associati, crea una sola riga con il codice bollettino dato, sperando sia il nostro
						var rFlussoIncassiDetail = ds.flussoincassidetail.newRow();
						rFlussoIncassiDetail.idflusso = rFlussoIncassi.idflusso;
						rFlussoIncassiDetail.iddetail = iddetail;
						iddetail++;
						rFlussoIncassiDetail.importo = singoloPagamento.singoloImportoPagato - importoCreditiAssegnati;
						// non sembra sia possibile valorizzare codice bollettino
						//rFlussoIncassiDetail.iduniqueformcode = codiceBollettino;//TODO: verificare che la banca ci invii il nostro iduniqueformcode
						rFlussoIncassiDetail.iuv = iuv;
						rFlussoIncassiDetail["ct"] = DateTime.Now;
						rFlussoIncassiDetail["cu"] = "flusso_riversamento";
						rFlussoIncassiDetail["lt"] = DateTime.Now;
						rFlussoIncassiDetail["lu"] = "flusso_riversamento";
						// con i dati del rendiconto non riesco a valorizzare il codice fiscale /la partita iva del pagatore, 
						// sono dati eventualmente contenuti nella ricevita telematica RT che dovrei recuperare
						// rFlussoIncassiDetail["cf"] =DBNull.Value

						// rFlussoIncassiDetail["p_iva"] =DBNull.Value;

						ds.flussoincassidetail.Rows.Add(rFlussoIncassiDetail);

					}


					rFlussoIncassi["importo"] = importoFlusso;
					rFlussoIncassi["lt"] = DateTime.Now;
					rFlussoIncassi["lu"] = "flusso_riversamento";
				}
			}
			catch (Exception ex)
			{
				errore = ex.ToString();
			}

			if (string.IsNullOrEmpty(errore))
			{
				var p = new Easy_PostData_NoBL();
				p.initClass(ds, conn);

				var pc = p.DO_POST_SERVICE();
				if (pc.Count > 0)
				{
					if (errore == null)
					{
						errore += "\n\rErrore nel salvataggio";
					}
					else
					{
						errore += "Errore nel salvataggio";
					}

					for (var i = 0; i < pc.Count; i++)
					{
						errore += "\n\r" + pc.GetMessage(i).LongMess;
					}

					return false;
				}

			}

			return true;
		}

		public static string elaboraRendicontoPagoPA(DataAccess conn, string iuvToSearch, string filename)
		{
			var response = File.ReadAllBytes(filename);
			var memStream = new MemoryStream(response);
			var esercizio = conn.GetEsercizio();
			var dataContabile = conn.GetDataContabile();


			// Controllare se XML oppure generica stringa errore
			string errore = null;
			try
			{
				var xmlDoc = new XmlDocument();
				xmlDoc.Load(memStream);
				//XmlElement xmlDoc = xmlDoc.GetElementById("identificativoFlusso");
				if (xmlDoc.InnerXml.ToString().Contains("identificativoFlusso"))
				{
					memStream.Position = 0;

					var serializer = new XmlSerializer(typeof(FlussoRiversamento));
					var reader = XmlReader.Create(memStream);
					try
					{
						var rendiconto = (FlussoRiversamento)serializer.Deserialize(reader);
						if (!elaboraFlussoRiversamento(rendiconto, conn, iuvToSearch, out errore))
						{
							if (errore != null) return errore;
						}
					}
					catch (Exception ex)
					{
						//var ricevuta = new FlussoRiversamento();
						//errore = ex.ToString();
						//rendiconto.codiceBicBancaDiRiversamento = "123";
						//rendiconto.dataOraFlusso = DateTime.Now;
						//rendiconto.identificativoFlusso = "12345";
						//rendiconto = GenericSerializer.toXml<FlussoRiversamento>(ricevuta);
						errore = ex.ToString();
					}
				}
				else
				{
					errore = xmlDoc.ToString();
				}
			}
			catch (Exception ex)
			{
				// Lettura della stringa di errore
				StreamReader sr = new StreamReader(memStream);
				long pos = memStream.Position;
				memStream.Position = 0;

				string data = sr.ReadToEnd();
				errore = data;

			}

			return errore;
		}
		private static string aggiornaGovPay(string[] config, DataAccess conn, string iuvToSearch)
		{
			string errore = null;
			if (config.Length < 6)
			{
				return "Il servizio non ÃƒÆ’Ã‚Â¨ stato correttamente configurato (codiceApplicazione/codiceDominio/codiceUnitÃƒÆ’Ã‚Â Operativa/user/pwd/url)";
			}

			var esercizio = conn.GetEsercizio();
			var dataContabile = conn.GetDataContabile();

			// Parametri del servizio
			var codiceApplicazione = config[0];
			var codiceDominio = config[1];
			var codiceUnitÃƒÆ’Ã‚Â Operativa = config[2];
			string url = config[5];
			if (!url.EndsWith("PagamentiTelematiciGPRndService")) url += "PagamentiTelematiciGPRndService";

			// Connessione al DB
			var qhs = conn.GetQueryHelper();
			var qhc = new CQueryHelper();

			//checkCertificatiGovPayCrediti(url.Contains("gateway.pp.pagoatenei"));
			var servizio = GovPay.Servizio.Create(config[3], config[4], url);


			// Ottengo l'elenco dei rendiconti
			GovPay.gpChiediListaFlussiRendicontazioneResponse elencoRendiconti = null;
			try
			{
				elencoRendiconti = servizio.gpChiediListaFlussiRendicontazione(
					new GovPay.gpChiediListaFlussiRendicontazioneRequest()
					{
						body = new GovPay.gpChiediListaFlussiRendicontazioneRequestBody()
						{
							//codApplicazione = codiceApplicazione,
							codDominio = codiceDominio,
							dataInizio = new DateTime(esercizio, 1, 1),
							dataFine = DateTime.Now.Date
						}
					});
			}
			catch (Exception e)
			{
				errore = e.Message;
				return errore;
			}

			if (elencoRendiconti.body.codEsitoOperazione != gpResponseBody.EsitoOperazione.Eseguita)
			{
				return
					$"Errore nella ricezione dei flussi di rendicontazione: {elencoRendiconti.body.descrizioneEsitoOperazione}";
			}
			try
			{
				foreach (var flusso in elencoRendiconti.body.flussoRendicontazione)
				{
					var rendicontoReq = new GovPay.gpChiediFlussoRendicontazioneRequest(
						new GovPay.gpChiediFlussoRendicontazioneRequestBody()
						{
							//codApplicazione = codiceApplicazione,
							annoRiferimento = flusso.annoRiferimento,
							codFlusso = flusso.codFlusso
						});

					var rendicontoResp = servizio.gpChiediFlussoRendicontazione(rendicontoReq);
					if (rendicontoResp.body.codEsitoOperazione != gpResponseBody.EsitoOperazione.Eseguita)
					{
						continue;
					}

					var rendiconto = rendicontoResp;
					if (!elaboraFlussoRiversamentoGovPay(flusso, rendiconto, conn, iuvToSearch, out errore))
					{
						if (errore != null) return errore;
					}
					else
					{
						break;
					}
				}
			}
			catch (Exception ex)
			{
				errore = ex.Message;
			}

			return errore;
		}


		private static string aggiornaValtellinese(string[] config, DataAccess conn, string iuvToSearch)
		{
			string errore = null;
			if (config.Length < 11)
			{
				return "Il servizio non ÃƒÆ’Ã‚Â¨ stato correttamente configurato";
			}

			var esercizio = conn.GetEsercizio();
			var dataContabile = conn.GetDataContabile();
			// Parametri del servizio (utente/password/CODICE_AZIENDA/URLSoap/userRest/pwdRest/URLRest/codicepartitarioRest)
			// WS_COM_CREV|**********|CRE14|https://service.pmpay.it/|unicatuser|**********|https://service.pmpay.it/Rest/|COD_SERV_STUDENTE
			var utente = config[0]; // utente ambiente SOAP
			var password = config[1]; // password ambiente SOAP
			string codiceAzienda = config[2]; // codice azienda
			string urlSoap = config[3]; // url ambiente SOAP
			string userRest = config[4]; // utente ambiente REST
			string pwdRest = config[5]; //password ambiente REST
			string urlRest = config[6]; // url ambiente REST
			string codicepartitarioRest = config[7]; // codice partitario ambiente REST

			//// Parametri del servizio            (partnerconfig ha come   token il codice del partner ossia valyellinese in questo caso
			var identificativoDominio = config[8]; // Parametro fornito da Banca Credito Valtellinese:    
			var identificativoBu = config[9]; // Parametro fornito da Banca Credito Valtellinese:      
			var identificativoServizio = config[10]; // Parametro fornito da Banca Credito Valtellinese  

			//// Parametri del servizio (utente/password/CODICE_AZIENDA/URL)
			//var utente = config[0];
			//var password = config[1];
			//string codiceAzienda = config[2];
			//var url = config[3];


			//var utente = "WS_COM_CREV";  // utente ambiente SOAP
			//var password = "**********"; // password ambiente SOAP
			//string codiceAzienda = "CRE14"; // codice azienda
			//string urlSoap = "https://service.pmpay.it/"; // url ambiente SOAP
			//string userRest = "unicatuser"; // utente ambiente REST
			//string pwdRest = "**********"; //password ambiente REST
			//string urlRest = "https://service.pmpay.it/Rest";   // url ambiente REST
			//string codicepartitarioRest = "COD_SERV_STUDENTE"; // codice partitario ambiente REST


			// Connessione al DB
			var qhs = conn.GetQueryHelper();
			var qhc = new CQueryHelper();


			// Servizio Autenticazione REST
			// per le elaborazioni massive usiamo il web service REST effettuando la richiesta di aggiornamento degli IUV non ancora elaborati
			// https://service.pmpay.it/Rest/rendicontazioni/list ?list?dataDa = &dataA= &creditore =  !FileRisposta   
			ValtellineseREST rClient = new ValtellineseREST(urlRest, userRest, pwdRest);


			//8.GetRicevuteTelematiche
			//Consente di  recuperare lÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢elenco delle ricevute telematiche disponibili dall'ultima richiesta.
			//Le singole RT andranno poi recuperate mediante metodo getRicevutaTelematica

			//La chiamata REST (con basic authentication) ÃƒÆ’Ã‚Â¨:
			//< url_end_point_PMPAY >/ ricevutetelematiche / get ? creditore =< CODICE_ENTE_CREDITORE >| FileRisposta


			List<string> elencoRendiconti = new List<string>();
			// Ottengo l'elenco dei rendiconti

			elencoRendiconti = rClient.GetElencoRendicontazioni(new DateTime(esercizio, 1, 1).Date, DateTime.Now.Date,
				codiceAzienda, out errore);

			try
			{
				foreach (var idtrasmissione in elencoRendiconti)
				{
					var rendicontoResp =
						rClient.GetRendicontazione(codiceAzienda, idtrasmissione,
							out errore); // Chiamata Metodo REST di acquisizione della Ricevuta Telematica


					if (!string.IsNullOrEmpty(errore)) return errore;
					if (rendicontoResp == null)
					{
						errore =
							$" Errore nell'acquisizione del flusso di rendicontazione per l'idt_Trasmissione:  {idtrasmissione} ";
						continue;
					}

					var rendiconto = rendicontoResp;
					if (!elaboraFlussoRiversamento(rendiconto, conn, iuvToSearch, out errore))
					{
						return errore;
					}
				}
			}
			catch (Exception ex)
			{
				errore = ex.Message;
			}

			return errore;
		}
	}
}