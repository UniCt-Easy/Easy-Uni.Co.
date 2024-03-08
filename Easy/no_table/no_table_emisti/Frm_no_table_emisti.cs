
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


using emistiParser;
using metadatalibrary;
using metaeasylibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace no_table_emisti {
    public partial class Frm_no_table_emisti : MetaDataForm {

        public dsmeta ds;

        MetaData Meta;
        DataAccess Conn;

        public Frm_no_table_emisti() {

            ds = new dsmeta();

            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
        }

        private void btnInput_Click(object sender, EventArgs e) {

            btnClear_Click(this, e);

            OpenFileDialog _input = new OpenFileDialog();
            IOpenFileDialog input = createOpenFileDialog(_input);

            DialogResult result = input.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(input.FileName))
                txtInput.Text = input.FileName;
        }

        private void btnImport_Click(object sender, EventArgs e) {

            if (!File.Exists(txtInput.Text))
                return;

            dgvErrors.DataSource = null;

            var errors = EmistiImporter.Load(Conn, txtInput.Text, ds, txtDescription.Text);

            DataTable dtErrors = new DataTable();
            dtErrors.Columns.Add("# Riga", typeof(string));
            dtErrors.Columns.Add("Tipo Record", typeof(string));
            dtErrors.Columns.Add("Errore", typeof(string));
            dtErrors.Columns.Add("Contenuto Riga", typeof(string));

            foreach (var error in errors) {
                DataRow row = dtErrors.NewRow();
                row["# Riga"] = error.LineNumber;
                row["Tipo Record"] = error.RecordType.ToString();
                row["Errore"] = error.Message;
                row["Contenuto Riga"] = error.Line.ToString();
                dtErrors.Rows.Add(row);
            }

            dgvErrors.DataSource = dtErrors;

            txtDescription.Text = ds.emisti_import.Rows[0].Field<string>("description").ToString();
            txtDescription.ReadOnly = true;

            btnImport.Enabled = false;
            btnSave.Enabled = dgvErrors.Rows.Count == 0;

        }

        private void btnSave_Click(object sender, EventArgs e) {

            foreach (var table in ds.Tables) {
                RowChange.SetOptimized((DataTable)table, true);
            }

            if (ds.emisti_import.Rows.Count > 0) {

                var postData = new Easy_PostData_NoBL();
                postData.initClass(ds, conn);

                ProcedureMessageCollection errors = postData.DO_POST_SERVICE();
                IEnumerable<string> messages = errors.ToArray().Cast<ProcedureMessage>().Select(pm => pm.LongMess);

                if (messages.Any()) {

                    MetaFactory.factory.getSingleton<IMessageShower>().Show(string.Format("Errori durante il salvataggio dei dati: \r\n{0}", string.Join("\r\n\r\n", messages)));

                    return;
                }

                MetaFactory.factory.getSingleton<IMessageShower>().Show("Salvataggio completato");
            }

        }

        private void btnClear_Click(object sender, EventArgs e) {

            ds.Clear();

            dgvErrors.DataSource = null;
            txtLog.Clear();

            btnSave.Enabled = false;
            txtDescription.ReadOnly = false;

            txtDescription.Clear();

            btnImport.Enabled = true;
        }

        private void btnExport_Click(object sender, EventArgs e) {



            //Conn.CallSP("compute_pccoperation_pagamenti", param, true, 900)
        }
    }
}
