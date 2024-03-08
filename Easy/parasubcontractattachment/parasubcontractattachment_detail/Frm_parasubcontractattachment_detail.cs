
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using System.IO;
using funzioni_configurazione;

namespace parasubcontractattachment_detail
{
	public partial class Frm_parasubcontractattachment_detail : MetaDataForm
    {
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        public IOpenFileDialog openFileDialog1;
        public Frm_parasubcontractattachment_detail()
		{
			InitializeComponent();
            openFileDialog1 = createOpenFileDialog(_openFileDialog1);
        }
        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            string filter_tipoallegato = qhs.AppAnd(qhs.CmpEq("active", "S"), qhs.BitSet("flag", 0));
            DataRow Dparasubcontract = Meta.SourceRow.GetParentRow("parasubcontract_parasubcontractattachment");
            if ((Dparasubcontract != null)){
                object idser = Dparasubcontract["idser"];
                if ((idser != DBNull.Value) && (CfgFn.GetNoNullInt32(idser) != 0)){
                    filter_tipoallegato = qhs.AppAnd(filter_tipoallegato,
                        qhs.DoPar(qhs.AppOr(qhs.IsNull("idser"), qhs.CmpEq("idser", Dparasubcontract["idser"])))
                    );
                }
            }

            GetData.SetStaticFilter(DS.serviceattachmentkind, filter_tipoallegato);
        }

        public void MetaData_AfterFill()
        {
            DataRow R = DS.parasubcontractattachment.Rows[0];
            btnVisualizza.Visible = true;
            if (R["attachment"] == DBNull.Value)
            {
                btnVisualizza.Visible = false;
            }

        }
        void ScriviFile(string sw, byte[] documento, int offset)
        {
            // Legge il documento memorizzato nel DB e lo scrive nel file temp.
            if (Meta.IsEmpty) return;
            if (!Meta.GetFormData(true)) return;

            FileStream FS = new FileStream(sw, FileMode.Create, FileAccess.Write);

            int n = documento.Length - offset;
            if (n == 0) return;
            try
            {
                FS.Write(documento, offset, n);//<<<<<<<<<
                FS.Flush();
                FS.Close();
            }
            catch { }
        }
        private void btnAllega_Click(object sender, EventArgs e)
		{
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.parasubcontractattachment.Rows[0];
            openFileDialog1.Title = "Seleziona l'allegato";
            try
            {
                if (openFileDialog1.ShowDialog(this) != DialogResult.OK) return;
            }
            catch (Exception E)
            {
                QueryCreator.ShowException(E);
                return;
            }
            FileStream FS;
            try
            {
                FS = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
            }
            catch (Exception E)
            {
                QueryCreator.ShowException("Errore nell'apertura del file " + openFileDialog1.FileName, E);
                return;
            }

            int n = (int)FS.Length;
            if (n == 0)
            {
                Curr["attachment"] = DBNull.Value;
                return;
            }
            byte[] ByteArray = new byte[n];
            FS.Read(ByteArray, 0, n);
            if (FS.Length == 0)
            {
                Curr["attachment"] = DBNull.Value;
            }
            FS.Close();
            Curr["attachment"] = ByteArray;
            string fname = Path.GetFileName(openFileDialog1.FileName);
            labAutocertFileName.Text = fname;
            Curr["filename"] = fname;
        }

		private void btnVisualizza_Click(object sender, EventArgs e)
		{
            string FilePath = AppDomain.CurrentDomain.BaseDirectory;
            string prefix = "SWATTACHMENT";
            string filenametodelete = FilePath + prefix + "*.*";
            string[] existingreports = System.IO.Directory.GetFiles(FilePath, prefix + "*.*");
            foreach (string filename in existingreports)
            {
                try
                {
                    System.IO.File.Delete(filename);
                }
                catch { }
            }

            //sw è il nome del file temporaneo che hai creato
            DateTime oggi_dt = DateTime.Now;
            string oggi = oggi_dt.Ticks.ToString();
            DataRow Curr = DS.parasubcontractattachment.Rows[0];
            if (Curr["attachment"] == DBNull.Value) return;

            byte[] ByteArray = (byte[])Curr["attachment"];
            int offset = 0;
            string fname = Curr["filename"].ToString();
            string estensione = Path.GetExtension(fname).Trim();

            string sw = Path.Combine(FilePath, prefix + oggi.ToString() + estensione);
            try
            {
                ScriviFile(sw, ByteArray, offset);
                runProcess(sw, true);
            }
            catch (Exception E)
            {
                QueryCreator.ShowException(E);
            }
        }
	}
}
