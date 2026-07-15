/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace no_table_imp_prontoperloscarico {
	public partial class Frm_imp_prontoperloscarico : MetaDataForm {
        MetaData Meta;
        string fileName;
        private IDataAccess _conn;
        private CQueryHelper _qhc;
        private QueryHelper _qhs;
        private IFormController _ctrl;
        private ISecurity _security;
        private IMetaDataDispatcher _dispatcher;
        private IMetaData _meta;
        private DataTable tAsset;
        public IOpenFileDialog openFileDialog1;
        private IMetaModel _model;
        private int esercizio;
        private DataAccess Conn;
        public Frm_imp_prontoperloscarico() {
            InitializeComponent();
            openFileDialog1 = createOpenFileDialog(_openInputFileDlg);
        }
        private IFormController controller;


		public void MetaData_AfterLink()  {
			Meta = MetaData.GetMetaData(this);
			_meta = this.getInstance<IMetaData>();
			_conn = this.getInstance<IDataAccess>();
            Conn = Meta.Conn;
            _dispatcher = this.getInstance<IMetaDataDispatcher>();
			_security = this.getInstance<ISecurity>();
			_ctrl = this.getInstance<IFormController>();
			_model = MetaFactory.factory.getSingleton<IMetaModel>();
			_qhc = new CQueryHelper();
			_qhs = _conn.GetQueryHelper();
			esercizio = _security.GetEsercizio();

			var filterEsercizio = _qhs.CmpEq("ayear", esercizio);

			_ctrl.CanCancel = false;
			_ctrl.CanInsert = false;
			_ctrl.CanInsertCopy = false;
			_ctrl.CanSave = false;
			_ctrl.SearchEnabled = false;
            btnApriFile.ContextMenu = CMenu;
		}

		private void addColumnDati(DataTable tExcel, bool ColumnsPlus) {
            if (!ColumnsPlus) {
                tExcel.Columns.Add("idasset", typeof(int));
                tExcel.Columns.Add("idpiece", typeof(int));
            }
            if (ColumnsPlus) {
                tExcel.Columns.Add("inventory", typeof(string));
                tExcel.Columns.Add("ninventory", typeof(int));
                tExcel.Columns.Add("inventoryagency", typeof(string));
                tExcel.Columns.Add("nassetacquire", typeof(int));
            }
        }
		void impostaCaption(DataTable dt, bool ColumnsPlus) {
            if (!ColumnsPlus) {
                dt.Columns["idasset"].Caption = "Num.Cespite";
                dt.Columns["idpiece"].Caption = "Num.Parte";
            }
            if (ColumnsPlus) {
                dt.Columns["inventory"].Caption = "Inventario";
                dt.Columns["ninventory"].Caption = "Num.inventario";
                dt.Columns["inventoryagency"].Caption = "Ente inventariale";
                dt.Columns["nassetacquire"].Caption = "Num.carico";
            }
        }

        /// <summary>
        /// Legge i dati dal foglio excel
        /// </summary>
        /// <param name="faseCrediti"></param>
        /// <returns></returns>
        private DataTable readCurrentSheet() {
			var dtToImport = new DataTable();

				addColumnDati(dtToImport, false);
				impostaCaption(dtToImport, false);

			// Lettura file excel
			if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx")) {
				dtToImport.Clear();
				var c = new ExcelImport();
				c.ImportTable(fileName, dtToImport, false, 2);// PREVEDE 1 RIGA DI INTESTAZIONE
			}

			bool ok;
			try {
					ok = verificaDati(dtToImport);
			}
			catch (Exception e) {
				QueryCreator.ShowException(this, "Errore nella elaborazione del file excel ", e);
				return null;
			}

			if (!ok) {
				show(this, $@"L'esame del file {fileName} ha fatto rilevare degli errori");
				return null;
			}

			return dtToImport;
		}
        bool verificaDati(DataTable dt) {
            foreach (DataColumn c in dt.Columns) {
                if (!dt.Columns.Contains(c.ColumnName)) {
                    show(this, "File non compatibile con il Tracciato");
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Legge un foglio excel crediti o incassi 
        /// </summary>
        /// <param name="faseCrediti"></param>
        /// <returns></returns>
        private DataTable leggiFile() {
            var dr = openFileDialog1.ShowDialog();
            if (dr != DialogResult.OK) {
                show("Non è stato scelto alcun file");
                txtFile.Text = "";
                return null;
            }

            fileName = openFileDialog1.FileName;
            DataTable t = null;
            if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx") || fileName.EndsWith("csv")) {
                try {
                    t = readCurrentSheet();
                    if (t == null) return null;
                    txtFile.Text = fileName;
                }
                catch (Exception ex) {
                    show(this, $"Errore nell\'apertura del file! Processo Terminato\n{ex.Message}");
                    return null;
                }
            }
            else {
                show("Il file deve avere formato xls, xlsx o csv", "Errore");
            }

            _ctrl.FreshForm(true, false);
            return t;
        }

        private void btnApriFile_Click(object sender, EventArgs e) {
            DS.asset.Clear();
            DS.assetview.Clear();

            tAsset = leggiFile();

            if (tAsset == null) {
                show(this, "Errore nell'apertua del file.");
                return;
            }
            addColumnDati(tAsset, true);
            impostaCaption(tAsset, true);

            AggiungiInfo(tAsset);
        }

        public void AggiungiInfo(DataTable tAsset) {
            string filter = "";
            var nodes = new List<string>();
            const int TRANCHE_SIZE = 100; // considero blocchi di 100 asset in lettura
            int count = 0;
            foreach (DataRow R in tAsset.Rows) {
                int idasset = CfgFn.GetNoNullInt32(R["idasset"]);
                int idpiece = CfgFn.GetNoNullInt32(R["idpiece"]);
                count += 1;

                if (count<= TRANCHE_SIZE) {
                    filter = qhs.AppOr(filter,
						qhs.DoPar(
							qhs.AppAnd(qhs.CmpEq("idasset", idasset), qhs.CmpEq("idpiece", idpiece))));
                }
                if (count == TRANCHE_SIZE) {
                    Conn.RUN_SELECT_INTO_TABLE(DS.asset, "idasset, idpiece", filter, null, false);
                    Conn.RUN_SELECT_INTO_TABLE(DS.assetview, "idasset, idpiece", filter, null, false);
                    filter = "";
                    count = 0;
                }
            }
            //parte residuale
            Conn.RUN_SELECT_INTO_TABLE(DS.asset, "idasset, idpiece", filter, null, false);
            Conn.RUN_SELECT_INTO_TABLE(DS.assetview, "idasset, idpiece", filter, null, false);
            count = 0;
            filter = "";

            foreach (DataRow Rimp in tAsset.Select()) {
                string filterkey = qhc.AppAnd(qhc.CmpEq("idasset", Rimp["idasset"]), qhc.CmpEq("idpiece", Rimp["idpiece"]));
                foreach (DataRow R in DS.assetview.Select(filterkey)) {
                      Rimp["inventory"] = R["inventory"];
                      Rimp["ninventory"] = R["ninventory"];
                      Rimp["inventoryagency"] = R["inventoryagency"];
                      Rimp["nassetacquire"] = R["nassetacquire"];
                }
            }

			DataSet ds1;
			if (tAsset.DataSet == null) {
				ds1 = new DataSet();
				ds1.Tables.Add(tAsset);
			}
			else {
				ds1 = tAsset.DataSet;
			}

			dgrCespiti.SetDataBinding(ds1, tAsset.TableName);

			HelpForm.SetDataGrid(dgrCespiti, tAsset);
			HelpForm.SetGridStyle(dgrCespiti, tAsset);
        }

        private void BtnImpostaScarico_Click(object sender, EventArgs e) {
            DataRow[] prontiPerScarico = DS.asset.Select(qhc.BitClear("flag", 1));
            if (prontiPerScarico.Length == 0) {
                show("Nessun Cespite/Accessorio in elenco è da impostare come 'pronto per lo scarico'.", "Avviso");
                btnApriFile.Enabled = false;
                BtnImpostaScarico.Enabled = false;
                return;
            }
            foreach (DataRow R in DS.asset.Select(qhc.BitClear("flag",1))) {
                R["flag"] = (byte)(CfgFn.GetNoNullByte(R["flag"]) | 2);// imposta il bit 1
                }

                PostData Post = Meta.Get_PostData();
            Post.InitClass(DS, Conn);
            bool res = Post.DO_POST();
            if (res) {
                show("Operazione eseguita con successo.", "Avviso");
            }
            else {
                show("Ci sono stati problemi nell'aggiornamento dei Cespiti.", "Errore");
            }
            btnApriFile.Enabled = false;
            BtnImpostaScarico.Enabled = false;
        }

        string[] tracciato_cespiti =
    new string[] {
                "idasset;Num.Cespite;Intero;8",
                "idpiece;Num.Parte;Intero;8"
    };
        private void MenuEnterPwd_Click(object sender, EventArgs e) {
            if (sender == null) return;
            if (!(typeof(MenuItem).IsAssignableFrom(sender.GetType()))) return;
            object mysender = ((MenuItem)sender).Parent.GetContextMenu().SourceControl;
            string tracciato = "";
            DataTable TableTracciato = null;
            //foreach (ImportButton IB in AllButton) {
            //    if (IB.Btn == mysender) {
                    tracciato = getTracciato(tracciato_cespiti);
                    TableTracciato = getTableTracciato(tracciato_cespiti);
            //        break;
            //    }
            //}

            FrmShowTracciato FT = new FrmShowTracciato(tracciato, TableTracciato, "struttura");
            createForm(FT, null);
            FT.ShowDialog();

        }

        public string getTracciato(string[] tracciato) {
            string res = "";
            int pos = 0;
            foreach (string t in tracciato) {
                string[] ss = t.Split(';');
                string field = ss[0].PadLeft(30) + ": Pos." + pos.ToString().PadLeft(5) + " lunghezza " +
                               ss[3].PadLeft(4) +
                               " Tipo: " + ss[2].PadLeft(15);
                if (ss[2].ToLower() == "codificato") {
                    field += " Codifica:" + ss[4];
                }

                field += " Descrizione: " + ss[1];
                field += "\r\n";
                pos += CfgFn.GetNoNullInt32(ss[3]);
                res += field;
            }

            return res;
        }

        public DataTable getTableTracciato(string[] tracciato) {
            int pos = 0;
            var T = new DataTable("t");
            T.Columns.Add("nome", typeof(string));
            T.Columns.Add("posizione", typeof(int));
            T.Columns.Add("lunghezza", typeof(string));
            T.Columns.Add("tipo", typeof(string));
            T.Columns.Add("codifica", typeof(string));
            T.Columns.Add("Descrizione", typeof(string));

            foreach (string t in tracciato) {
                var r = T.NewRow();
                string[] ss = t.Split(';');
                r["nome"] = ss[0];
                r["posizione"] = pos;
                r["lunghezza"] = CfgFn.GetNoNullInt32(ss[3]);
                r["tipo"] = ss[2];
                if (ss.Length == 5) r["codifica"] = ss[4];
                r["Descrizione"] = ss[1];
                pos += CfgFn.GetNoNullInt32(ss[3]);
                T.Rows.Add(r);
            }

            return T;
        }
        private void menuItem1_Click(object sender, EventArgs e) {
       }

    }
}
