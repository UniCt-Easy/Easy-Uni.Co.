
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


using System.Data;
using metadatalibrary;

namespace flussocreditidetail_esse3_default {
    public partial class Frm_flussocreditidetail_esse3_default : MetaDataForm {
        MetaData Meta;
        public Frm_flussocreditidetail_esse3_default() {
            InitializeComponent();
        }
        DataAccess Conn;
        QueryHelper QHS;

        public void MetaData_AfterFill() {
            enableControls(false);
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();

			Meta.CanInsert = false;
			Meta.CanInsertCopy = false;
			Meta.CanCancel = false;
			Meta.CanSave = false;

            DataTable tConfig = Conn.RUN_SELECT("config", "*", null, QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, null, true);

			if (tConfig == null || tConfig.Rows.Count == 0) {
				show("Configurazione annuale non trovata.", "Errore");
				Meta.ErroreIrrecuperabile = true;
				return;
			}
		}

        public void MetaData_AfterClear() {
            enableControls(true);
        }

        private void enableControls(bool abilita) {
            bool ReadOnly = !abilita;

            txtIdflusso.ReadOnly = ReadOnly;
            txtIdDettaglio.ReadOnly = ReadOnly;
            txtIuv.ReadOnly = ReadOnly;
            txtIdUniqueFormCode.ReadOnly = ReadOnly;

            txtCodiceCausale.ReadOnly = ReadOnly;

            txtForename.ReadOnly = ReadOnly;
            txtSurname.ReadOnly = ReadOnly;
            txtEmail.ReadOnly = ReadOnly;
            txtCF.ReadOnly = ReadOnly;

            txtDataInizioCompetenza.ReadOnly = ReadOnly;
            txtDataFineCompetenza.ReadOnly = ReadOnly;
            txtDataContabile.ReadOnly = ReadOnly;
            txtScadenza.ReadOnly = ReadOnly;

            txtAnnoEdizione.ReadOnly = ReadOnly;
            txtCodCorsoLaurea.ReadOnly = ReadOnly;
            txtCodDipart.ReadOnly = ReadOnly;
            txtCodPercStudi.ReadOnly = ReadOnly;
            txtCodSede.ReadOnly = ReadOnly;

            txtCodTassa.ReadOnly = ReadOnly;
            txtCodVoce.ReadOnly = ReadOnly;
            txtImporto.ReadOnly = ReadOnly;
            txtRata.ReadOnly = ReadOnly;
        }
    }
}
