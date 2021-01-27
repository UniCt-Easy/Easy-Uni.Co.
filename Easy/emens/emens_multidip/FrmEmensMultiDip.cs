
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace emens_multidip {
    public partial class FrmEmensMultiDip : Form {
        public FrmEmensMultiDip() {
            InitializeComponent();
            // Caption per tabella EMENS
            dsEmens.Emens.Columns["AnnoMeseDenuncia"].Caption = "Mese denuncia";
            dsEmens.Emens.Columns["CFAzienda"].Caption = "C.F. Azienda";
            dsEmens.Emens.Columns["CFCollaboratore"].Caption = "C.F. Collaboratore";
            dsEmens.Emens.Columns["Cognome"].Caption = "Cognome";
            dsEmens.Emens.Columns["Nome"].Caption = "Nome";
            dsEmens.Emens.Columns["CodiceComune"].Caption = "Codice Comune";
            dsEmens.Emens.Columns["TipoRapporto"].Caption = "Tipo rapporto";
            dsEmens.Emens.Columns["CodiceAttivita"].Caption = "Codice attività";
            dsEmens.Emens.Columns["Imponibile"].Caption = "Imponibile";
            dsEmens.Emens.Columns["Aliquota"].Caption = "Aliquota";
            dsEmens.Emens.Columns["AltraAss"].Caption = "Altra ass.";
            dsEmens.Emens.Columns["Dal"].Caption = "Dal";
            dsEmens.Emens.Columns["Al"].Caption = "Al";
            dsEmens.Emens.Columns["CodCalamita"].Caption = "";
            dsEmens.Emens.Columns["CodCertificazione"].Caption = "";

        }

        private void scriviXml(DataRow row, string[] col, string[] sourcecol) {
            for (int i = 0; i < col.Length; i++) {
                string c = col[i];
                string source = sourcecol[i];
                if (!(row[source] is DBNull)) {
                    if (row[source] is DateTime) {
                        DateTime d = (DateTime)row[source];
                        writer.WriteElementString(c, d.ToString("yyyy-MM-dd"));
                    }
                    else {
                        writer.WriteElementString(c, row[source].ToString().ToUpper());
                    }
                }
            }
        }


        private void Esegui() {
            string filter_auto = "";
            DateTime Datainizio, Datafine;

            int taxkind = 0;
            foreach (DataRow R in DS.tax.Rows) {
                taxkind = CfgFn.GetNoNullInt32(R["taxkind"]);
                switch (taxkind) {
                    case 1: R["!taxcategory"] = "Fiscale"; break;
                    case 2: R["!taxcategory"] = "Assistenziale"; break;
                    case 3: R["!taxcategory"] = "Previdenziale"; break;
                    case 4: R["!taxcategory"] = "Assicurativa"; break;
                    case 5: R["!taxcategory"] = "Arretrati"; break;
                    case 6: R["!taxcategory"] = "Altro"; break;
                }
            }

            foreach (DataRow R in DS.tax.Rows) {
                filter_auto = "(taxcode = " + QueryCreator.quotedstrvalue(R["taxcode"], false) + ") AND " + filter_eserc;
                DataTable Ttaxsetup = meta.Conn.RUN_SELECT("taxsetup", "*", null, filter_auto, null, true);
                DataRow[] Rauto = Ttaxsetup.Select(filter_auto, null);

                if (Rauto.Length == 0) continue;
                if (!ControllaConfRitenuta(Rauto[0])) continue;
                Datainizio = new DateTime(1, 1, 1);
                Datafine = new DateTime(1, 1, 1);
                CalcolaDateDaPeriodo(Rauto[0], out Datainizio, out Datafine);
                if (!CallStoredProcedure(R["taxcode"], Datainizio, Datafine)) continue;
                else {
                    MessageBox.Show("Ci sono ritenute da pagare", "Informazioni", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MetaData Metataxpay = MetaData.GetMetaData(this, "taxpay");
                    Metataxpay.Edit(meta.LinkedForm.ParentForm, "ritenutedapagare", true);

                    return;
                }
            }
        }

        private bool ControllaConfRitenuta(DataRow RigaAutRiten) {
            if (RigaAutRiten["expiringday"].ToString() == "") return false;
            if (Convert.ToInt32(RigaAutRiten["expiringday"]) < 1) return false;
            if (RigaAutRiten["idexpirationkind"].ToString() == "") return false;
            int mesiperiodicita = Convert.ToInt32(RigaAutRiten["idexpirationkind"]);
            if ((mesiperiodicita < 1) || (mesiperiodicita > 12) || (mesiperiodicita == 5) ||
                (mesiperiodicita == 7) || (mesiperiodicita == 8) || (mesiperiodicita == 9) ||
                (mesiperiodicita == 10) || (mesiperiodicita == 11))
                return false;
            return true;
        }


		private int CalcolaPeriodo (int mese, int mesiperiodicita, DataRow RigaAutRiten) 
		{
			if (
                  ((CfgFn.GetNoNullInt32(RigaAutRiten["flag"]) & 0x08) == 0) && 
				mese <= mesiperiodicita) return 1;
			int periodo = mese / mesiperiodicita;
			if (mese % mesiperiodicita > 0) periodo++;
            if ((CfgFn.GetNoNullInt32(RigaAutRiten["flag"]) & 0x08) != 0)
			{
				int day=((DateTime)meta.GetSys("datacontabile")).Day;
				if (day <= Convert.ToInt16(RigaAutRiten["expiringday"])) periodo--;
			}
			return periodo;
		}

		private bool CalcolaDateDaPeriodo (DataRow RigaAutRiten, out DateTime DataInizio,
			out DateTime DataFine) 
		{
			int mesiperiodicita = Convert.ToInt32(RigaAutRiten["idexpirationkind"]);
			DataInizio = new DateTime(1,1,1);
			DataFine = new DateTime(1,1,1);
			if (12 % mesiperiodicita > 0) 
			{
				// periodo non ammesso!
				return false;
			}
			int annocorrente = (int)meta.GetSys("esercizio");//(int)Conn.sys["esercizio"];
			int mesecorrente = ((DateTime)meta.GetSys("datacontabile")).Month;
			int periodocorrente = CalcolaPeriodo(mesecorrente, mesiperiodicita, RigaAutRiten);
			if (periodocorrente < 1) 
			{ // vero se tipoperiodo=P e se il periodo è il primo dell'anno
				// si posiziona sull'ultimo periodo dell'anno precedente
				periodocorrente=12/mesiperiodicita;
				annocorrente--;
			}

			int meseinizioperiodo = mesiperiodicita*(periodocorrente-1)+1;
			int mesefineperiodo = mesiperiodicita*periodocorrente;
			DataInizio = new DateTime(annocorrente, meseinizioperiodo, 1);
			DataFine = new DateTime(annocorrente, mesefineperiodo, 
			DateTime.DaysInMonth(annocorrente, mesefineperiodo));
			return true;
		}


        private bool CallStoredProcedure(
            string codicedip,
            object codiceritenuta, DateTime datainizio, DateTime datafine) {
            DataSet Out = meta.Conn.CallSP("compute_taxpay",
                new object[] { datainizio.Year, codiceritenuta, datafine }, true, -1);

            if (Out == null) return false;
            if (Out.Tables.Count == 0) return false;
            return (Out.Tables[0].Rows.Count > 0);

        }
        void impostaCaption(DataTable dt) {
            dt.Columns["severity"].Caption = "Gravità";
            dt.Columns["errore"].Caption = "Errore";
            dt.Columns["soluzione"].Caption = "Soluzione";
            dt.Columns["department"].Caption = "Dipartimento";

        }

        bool checkEmens(object adate, object yearnumber, object startmonth, object stopmonth) {
            // Chiamata della S.P. di controllo            
            string errMsg;

            DataSet dsCheck = meta.Conn.CallSP("check_emens_unified",
                new object[] { adate, yearnumber, startmonth, stopmonth }, -1, out errMsg);
            if (errMsg != null) {
                MessageBox.Show(this, errMsg);
                return false;
            }

            if (dsCheck.Tables != null && dsCheck.Tables.Count > 0 && dsCheck.Tables[0].Rows.Count > 0) {
                impostaCaption(dsCheck.Tables[0]);
                new FrmDettaglioRisultati(dsCheck.Tables[0]).ShowDialog(this);

                DataRow[] R = dsCheck.Tables[0].Select("severity = 'S'");
                if (R.Length > 0) {
                    MessageBox.Show(this, "Sono stati riscontrati degli errori bloccanti, l'E-Mens non verrà generato!\nCorreggere prima tali errori");
                    return false;
                }
                else {
                    MessageBox.Show(this, "Sono stati riscontrati degli errori non bloccanti, l'E-Mens verrà comunque generato ma potrebbe essere comunicati dati non corretti");
                }
            }
            return true;
        }

        private void btnGeneraEmens_Click(object sender, EventArgs e) {
            meta.GetFormData(true);
            DataRow Curr = DS.emens.Rows[0];

            // Controllo che siano presenti i dati editabili nel form
            string messaggio1 = "";
            if (Curr["adate"] == DBNull.Value) messaggio1 += ", 'Data contabile'";
            if (Curr["startmonth"] == DBNull.Value) messaggio1 += ", 'Mese inizio'";
            if (Curr["stopmonth"] == DBNull.Value) messaggio1 += ", 'Mese fine'";
            if (Curr["yearnumber"] == DBNull.Value) messaggio1 += ", 'Anno'";
            if (Curr["inpscenter"] == DBNull.Value) messaggio1 += ", 'Sede inps'";

            bool eseguiGenerazione = messaggio1 == "";
            if (!eseguiGenerazione) {
                MessageBox.Show(this, "Inserire " + messaggio1.Substring(1));
                return;
            }
            // Controllo che siano presenti i dati non editabili nel form
            string messaggio2 = "";
            if (Curr["cfhumansender"].ToString() == "") messaggio2 += ", Codice Fiscale del Responsabile";
            if (Curr["sendercompanyname"].ToString() == "") messaggio2 += ", Ragione Sociale del Mittente";
            if (Curr["cfsender"].ToString() == "") messaggio2 += ", Codice Fiscale del Mittente";
            if (Curr["cfsoftwarehouse"].ToString() == "") messaggio2 += ", Codice Fiscale Software House";

            eseguiGenerazione = messaggio2 == "";
            if (!eseguiGenerazione) {
                MessageBox.Show(this, "Inserire una nuova denuncia, l'attuale non può essere utilizzata in quanto mancano i seguenti dati:\n" + messaggio2.Substring(1));
                return;
            }

            bool res = checkEmens(DS.emens.Rows[0]["adate"],
                                 DS.emens.Rows[0]["yearnumber"],
                                 DS.emens.Rows[0]["startmonth"],
                                 DS.emens.Rows[0]["stopmonth"]);
            if (!res) return;

            string errMsg;
            DataSet dsAziende = meta.Conn.CallSP("emens_getAziende_unified",
                new object[] {DS.emens.Rows[0]["adate"],
								 DS.emens.Rows[0]["yearnumber"],
								 DS.emens.Rows[0]["startmonth"],
								 DS.emens.Rows[0]["stopmonth"]},
                -1, out errMsg);
            if (errMsg != null) {
                MessageBox.Show(this, errMsg);
                return;
            }
            StringWriter sw = new StringWriter();
            writer = new XmlTextWriter(sw);
            writer.Formatting = Formatting.Indented;

            writer.WriteStartElement("DenunceRetributiveMensili");

            writer.WriteStartElement("DatiMittente");
            scriviXml(DS.emens.Rows[0],
                new string[] { "CFPersonaMittente", "RagSocMittente", "CFMittente", "CFSoftwarehouse", "SedeINPS" },
                new string[] { "cfhumansender", "sendercompanyname", "cfsender", "cfsoftwarehouse", "inpscenter" });
            writer.WriteEndElement();//"DatiMittente"

            int numCollaboratori = 0;
            foreach (DataRow rAzienda in dsAziende.Tables[0].Rows) {

                int meseDenuncia = (int)rAzienda["mesedenuncia"];
                string annoMeseDenuncia = rAzienda["annodenuncia"] + "-" + meseDenuncia.ToString("00");


                object[] paramValues = new object[5] { rAzienda["annodenuncia"], rAzienda["mesedenuncia"], rAzienda["cfazienda"], null, null };
                DataSet dsListaCollaboratori = meta.Conn.CallSPParameterDataSet("emens_getListaCollaboratori_unified",
                    new string[] { "@ycommunication", "@mcommunication", "@cf_enterprise", "@cap", "@istat" },
                    new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar },
                    new int[] { 0, 0, 0, 5, 5 },
                    new ParameterDirection[] { ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Output, ParameterDirection.Output },
                    ref paramValues, -1, out errMsg);

                if (errMsg != null) {
                    MessageBox.Show(this, errMsg);
                    writer.Close();
                    return;
                }
                numCollaboratori += dsListaCollaboratori.Tables[0].Rows.Count;

                if (dsListaCollaboratori.Tables[0].Rows.Count == 0) {
                    continue;
                }
                writer.WriteStartElement("Azienda");
                writer.WriteElementString("AnnoMeseDenuncia", annoMeseDenuncia);
                scriviXml(rAzienda, new string[] { "CFAzienda", "RagSocAzienda" },
                                    new string[] { "CFAzienda", "RagSocAzienda" });

                writer.WriteStartElement("ListaCollaboratori");
                writer.WriteElementString("CAP", paramValues[3].ToString());
                writer.WriteElementString("ISTAT", paramValues[4].ToString());

                foreach (DataRow rCollaboratore in dsListaCollaboratori.Tables[0].Rows) {
                    writer.WriteStartElement("Collaboratore");
                    scriviXml(rCollaboratore, new string[] {"CFCollaboratore", "Cognome", "Nome", "CodiceComune",
                        "TipoRapporto", "CodiceAttivita"},
                        new string[] {"CFCollaboratore", "Cognome", "Nome", "CodiceComune", "TipoRapporto", 
										 "CodiceAttivita"}
                        );
                    decimal epsilon = 0.5M;
                    int imponibile = (int)(CfgFn.GetNoNullDecimal(rCollaboratore["imponibile"]) + epsilon);
                    writer.WriteElementString("Imponibile", imponibile.ToString());
                    int moltiplicatore = 10000;
                    int aliquota = (int)(CfgFn.GetNoNullDecimal(rCollaboratore["aliquota"]) * moltiplicatore + epsilon);

                    writer.WriteElementString("Aliquota", aliquota.ToString());
                    scriviXml(rCollaboratore,
                        new string[] { "AltraAss", "Dal", "Al", "CodCalamita", "CodCertificazione" },
                        new string[] { "AltraAss", "Dal", "Al", "CodCalamita", "CodCertificazione" }
                        );
                    writer.WriteEndElement();//"Collaboratore"
                }
                writer.WriteEndElement();//"ListaCollaboratori"
                writer.WriteEndElement();//"Azienda"
            }
            writer.WriteEndElement();//"DenunceRetributiveMensili"
            writer.Close();

            if (numCollaboratori == 0) {
                MessageBox.Show(this, "Nel periodo indicato non ci sono ritenute INPS, pertanto l'E-Mens generato non sarà valido."
                    + "\nAnno: " + DS.emens.Rows[0]["yearnumber"]
                    + "\nMese inizio: " + DS.emens.Rows[0]["startmonth"]
                    + "\nMese fine: " + DS.emens.Rows[0]["stopmonth"]);
            }
            string xmlString = sw.ToString();

            byte[] xml = new UTF8Encoding().GetBytes(xmlString);

            DS.emens.Rows[0]["rtf"] = xml;

            DialogResult dialogResult = saveFileDialog1.ShowDialog(this);
            if (dialogResult == DialogResult.Cancel) return;
            txtNomeFile.Text = saveFileDialog1.FileName;

            StreamWriter stw = new StreamWriter(saveFileDialog1.OpenFile());
            stw.Write(sw.ToString());
            stw.Close();

            btnApriFile.Enabled = true;
            btnSalvaFile.Enabled = true;
        }



    }
}
