
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
using metadatalibrary;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;

namespace f24ordinariodetail_single{
	public partial class Frm_f24ordinariodetail_single : MetaDataForm
    {
        private const string SEZIONE_ERARIO =		"F";
        private const string SEZIONE_INPS =			"I";
        private const string SEZIONE_REGIONI =		"R";
        private const string SEZIONE_IMU =			"S";
        private const string SEZIONE_INAIL =		"N";
        private const string SEZIONE_ALTRIENTI =	"A";

        MetaData Meta;
		QueryHelper QHS;

		public Frm_f24ordinariodetail_single()	{
			InitializeComponent();
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName == "f24sezione") {
				if (!Meta.DrawStateIsDone)
					return;
				if (Meta.IsEmpty)
					return;
				if (R == null) {
					return;
				}

				if (R.RowState == DataRowState.Detached) return;

				azzeraCampi();
				if (R["idf24sezione"].ToString() == "I") {
					ValorizzacampiINPS();
				}
			}
		}
		public void ValorizzacampiINPS() {
			//valorizza Sede e Matricola INPS
			string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			DataTable tConfig = Meta.Conn.RUN_SELECT("config", "matricolainpsf24, idinpscenter", null, filterEsercizio, null, null, true);
			DataRow[] rConfig = tConfig.Select();
			object matricolainpsf24 = rConfig[0]["matricolainpsf24"];
			object inpscenter = rConfig[0]["idinpscenter"];
			txtInpsCodiceSede.Text = inpscenter.ToString();
			txtInpsMatricola.Text = matricolainpsf24.ToString();
		}
	public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();

			GetData.CacheTable(DS.f24sezione, null, "printingorder", true);

			//azzeraCampi();

			// GetData.SetSorting(DS.f24sezione, "printingorder");

			// esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			//string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			//GetData.SetStaticFilter(DS.f24ordinariodetail, filterEsercizio);
			//GetData.CacheTable(DS.license);
			//GetData.CacheTable(DS.config, filterEsercizio, null, false);
			//GetData.MarkToAddBlankRow(DS.monthname);
			//GetData.Add_Blank_Row(DS.monthname);
			//GetData.CacheTable(DS.monthname);
			//GetData.SetSorting(DS.monthname, "code");
		}

        public void MetaData_AfterClear() {
        }

        public void MetaData_AfterFill() {
			// txtCodiceFiscale.Text = DS.license.Rows[0]["cf"].ToString();
			DataRow curr = DS.f24ordinariodetail.Rows[0];
			if (curr["idf24sezione"].ToString() == "I") {
				ValorizzacampiINPS();
			}

			calcolaSaldo();
        }

        //public void MetaData_AfterRowSelect()
        //{
        //    // abilita disabilita groupbox
        //}

        private void azzeraCampi() {
			DataRow Curr = DS.f24ordinariodetail.Rows[0];
            // Codice Tributo
            txtCodiceTributo.Text = "";

			// Date A & B
			txtRif_A.Text = "";
			Curr["riferimentoa"] = DBNull.Value;
			txtRif_B.Text = "";
			Curr["riferimentob"] = DBNull.Value;
			labelRef_A.Text = "";
			labelRef_B.Text = "";

			// ERARIO
			txtCodiceUfficio.Text = "";
			Curr["codiceufficio"] = DBNull.Value;

			txtCodiceAtto.Text = "";
			Curr["codiceatto"] = DBNull.Value;
			// INPS
			txtInpsCodiceSede.Text = "";
            txtInpsMatricola.Text = "";

            // REGIONI
            txtRegioniCodice.Text = "";

            // IMU
            //txtImuCodice.Text = "";
            txtImuRavv.Text = "";
            txtImuImmob.Text = "";
            txtImuAcc.Text = "";
            txtImuSaldo.Text = "";
            txtImuNumero.Text = "";

            // ALTRI ENTI
            txtInailCodiceSede.Text = "";
            txtInailDitta.Text = "";
			Curr["codiceditta"] = DBNull.Value;

			txtInailCc.Text = "";
			Curr["cc_codiceditta"] = DBNull.Value;

			txtInailNumero.Text = "";

            // IMPORTI
            txtImportoADebito.Text = "";
			Curr["importoadebito"] = DBNull.Value;
			txtImportoACredito.Text = "";
			Curr["importoacredito"] = DBNull.Value;
			txtImportoSaldo.Text = "";
			Curr["accontosaldo"] = DBNull.Value;
			Curr["catastalecomune"] = DBNull.Value;
			Curr["causaleinail"] = DBNull.Value;
			Curr["codiceposizione"] = DBNull.Value;
			Curr["codicesedeinail"] = DBNull.Value;
			Curr["detrazioneabitazione"] = DBNull.Value;
			Curr["idaltrienti"] = DBNull.Value;
			Curr["idcodicesedealtrienti"] = DBNull.Value;
			Curr["identelocale"] = DBNull.Value;
			Curr["identificativooperazione"] = DBNull.Value;
			Curr["idfiscaltaxregion"] = DBNull.Value;
			Curr["idprovincia"] = DBNull.Value;
			Curr["immobilivariati"] = DBNull.Value;
			Curr["numerodiriferimento"] = DBNull.Value;
			Curr["numeroimmobili"] = DBNull.Value;
			Curr["ravvedimentooperoso"] = DBNull.Value;
			meta.FreshForm();
		}

        // =========================================================================================
        // Calcola Saldo
        // =========================================================================================
        private void calcolaSaldo()
        {
			float debito = 0;
			float credito = 0;

			if (!string.IsNullOrEmpty(txtImportoADebito.Text))
            {
				float.TryParse(txtImportoADebito.Text.Replace(" €", ""), out debito);
            }

            if (!string.IsNullOrEmpty(txtImportoACredito.Text))
            {
				float.TryParse(txtImportoACredito.Text.Replace(" €", ""), out credito);
            }

			txtImportoSaldo.Text = (debito - credito).ToString() + " €";
		}


        // =========================================================================================
        // Combo Sezione
        // =========================================================================================
        private void SistemaCampi()
        {
			string sezione = txtIdSezione.Text;

            if (sezione != "")
            {
                string filterSezione = QHS.AppAnd(QHS.CmpEq("attivo", "S"), QHS.CmpEq("idf24sezione", sezione));
                GetData.SetStaticFilter(DS.f24tributi, filterSezione);
            }

            txtCodiceTributo.Text = "";

            grpCodiceTributo.Enabled = sezione != "";
            txtRif_A.Enabled = sezione != "";
            txtRif_B.Enabled = sezione != "";
            txtImportoADebito.Enabled = sezione != "";
            txtImportoACredito.Enabled = sezione != "";

			txtRif_A.Text = "";
			txtRif_B.Text = "";

			grpErario.Enabled = sezione == SEZIONE_ERARIO;
            grpInps.Enabled = sezione == SEZIONE_INPS;
            grpRegioni.Enabled = sezione == SEZIONE_REGIONI;
            grpImu.Enabled = sezione == SEZIONE_IMU;
            grpInail.Enabled = sezione == SEZIONE_INAIL;
            grpAltriEnti.Enabled = sezione == SEZIONE_ALTRIENTI;

			foreach (Control item in this.Controls)
			{
				if (item.GetType().Name == "GroupBox")
				{
					if (!item.Enabled)
					{
						foreach (Control childitem in item.Controls)
						{
							if (childitem.GetType().Name == "TextBox")
							{
								childitem.Text = "";
							}
						}
					}
				}
			}
		}

		// =========================================================================================
		// IMPORTO, Credito, format
		// =========================================================================================
		private void txtImportoADebito_Leave(object sender, EventArgs e)
		{
			calcolaSaldo();
		}

		private void txtImportoACredito_Leave(object sender, EventArgs e)
		{
			calcolaSaldo();
		}


		// =========================================================================================
		// ERARIO, Codice Atto, format 11
		// =========================================================================================
		private void txtErarioCodiceAtto_Enter(object sender, EventArgs e)
		{
			//lineErarioAtto01.Visible = false;
			//lineErarioAtto02.Visible = false;
			//lineErarioAtto03.Visible = false;
			//lineErarioAtto04.Visible = false;
			//lineErarioAtto05.Visible = false;
			//lineErarioAtto06.Visible = false;
			//lineErarioAtto07.Visible = false;
			//lineErarioAtto08.Visible = false;
			//lineErarioAtto09.Visible = false;
			//lineErarioAtto10.Visible = false;
			//txtErarioCodiceAtto.Text = pulisciCodice(txtErarioCodiceAtto.Text);
			//txtErarioCodiceAtto.MaxLength = 11;
		}

		private void txtErarioCodiceAtto_Leave(object sender, EventArgs e)
		{
			//txtCodiceAtto.Text = txtErarioCodiceAtto.Text.Replace(" ", "");
			//txtErarioCodiceAtto.MaxLength = 21;
			//txtErarioCodiceAtto.Text = formattaCodice(txtErarioCodiceAtto.Text, 21);
			//lineErarioAtto01.Visible = true;
			//lineErarioAtto02.Visible = true;
			//lineErarioAtto03.Visible = true;
			//lineErarioAtto04.Visible = true;
			//lineErarioAtto05.Visible = true;
			//lineErarioAtto06.Visible = true;
			//lineErarioAtto07.Visible = true;
			//lineErarioAtto08.Visible = true;
			//lineErarioAtto09.Visible = true;
			//lineErarioAtto10.Visible = true;
		}


		// =========================================================================================
		// ERARIO, Codice Ufficio, format 3
		// =========================================================================================
		private void txtErarioCodiceUfficio_Enter(object sender, EventArgs e)
		{
			//lineErarioCodice1.Visible = false;
			//lineErarioCodice2.Visible = false;
			//txtErarioCodiceUfficio.Text = pulisciCodice(txtErarioCodiceUfficio.Text);
			//txtErarioCodiceUfficio.MaxLength = 3;
		}

		private void txtErarioCodiceUfficio_Leave(object sender, EventArgs e)
		{
			//txtCodiceUfficio.Text = txtErarioCodiceUfficio.Text.Replace(" ", "");
			//txtErarioCodiceUfficio.MaxLength = 5;
			//txtErarioCodiceUfficio.Text = formattaCodice(txtErarioCodiceUfficio.Text, 5);
			//lineErarioCodice1.Visible = true;
			//lineErarioCodice2.Visible = true;
		}


		// =========================================================================================
		// IMU, Codice Ente, format 4
		// =========================================================================================
		private void txtImuCodice_Enter(object sender, EventArgs e)
		{
			//lineAltriCodice2.Visible = false;
			//lineAltriCodice3.Visible = false;
			//lineAltriCodice1.Visible = false;
			//txtImuCodice.Text = pulisciCodice(txtImuCodice.Text);
			//txtImuCodice.MaxLength = 4;
		}

		private void txtImuCodice_Leave(object sender, EventArgs e)
		{
			//txtImuCodiceEnte.Text = txtImuCodice.Text.Replace(" ", "");

			//txtImuCodice.MaxLength = 7;
			//txtImuCodice.Text = formattaCodice(txtImuCodice.Text, 7);
			//lineAltriCodice2.Visible = true;
			//lineAltriCodice3.Visible = true;
			//lineAltriCodice1.Visible = true;
		}


		// =========================================================================================
		// ALTRI ENTI, Codice Ente, format 4
		// =========================================================================================
		private void txtAltriCodiceEnte_Enter(object sender, EventArgs e)
		{
			//lineAltriCodice1.Visible = false;
			//lineAltriCodice2.Visible = false;
			//lineAltriCodice3.Visible = false;
			//txtAltriCodiceEnte.Text = pulisciCodice(txtAltriCodiceEnte.Text);
			//txtAltriCodiceEnte.MaxLength = 4;
		}

		private void txtAltriCodiceEnte_Leave(object sender, EventArgs e)
		{
			//txtAltriEntiCodiceEnte.Text = txtAltriCodiceEnte.Text.Replace(" ", "");

			//txtAltriCodiceEnte.MaxLength = 7;
			//txtAltriCodiceEnte.Text = formattaCodice(txtAltriCodiceEnte.Text, 7);
			//lineAltriCodice1.Visible = true;
			//lineAltriCodice2.Visible = true;
			//lineAltriCodice3.Visible = true;
		}


		// =========================================================================================
		// formatto il codice con gli spazi [1 2 3]
		// =========================================================================================
		private string pulisciCodice(string codice)
		{
			return codice.Replace(" ", "");
		}

		private string formattaCodice(string codice, int size)
		{
			string txt = "";

			int l = codice.Length;

			if (l > 0)
			{
				for (int i = 0; i < l; i++)
				{
					txt += codice.Substring(i, 1) + " ";
				}

				txt = txt.TrimEnd();

				if (size > 0)
					txt = txt.PadLeft(size);
			}

			return txt;
		}


		// =========================================================================================
		// formatto il mumero con punti e virgola [1.234.567,89]
		// =========================================================================================
		private string pulisciImporto(string importo)
		{
			if (importo.StartsWith("0,0"))
				importo = importo.Substring(3);
			else if (importo.StartsWith("0,"))
				importo = importo.Substring(2);

			importo = importo.Replace(".", "").Replace(",", "");

			long imp = 0;
			long.TryParse(importo, out imp);

			if (imp != 0)
				return imp.ToString();

			return "";
		}

		private void txtIdSezione_TextChanged(object sender, EventArgs e)
		{
			SistemaCampi();
		}
	}
}
