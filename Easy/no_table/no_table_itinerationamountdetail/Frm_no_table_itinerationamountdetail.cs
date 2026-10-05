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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using itinerationFunctions;
using funzioni_configurazione;

namespace no_table_itinerationamountdetail {
	public partial class Frm_no_table_itinerationamountdetail : MetaDataForm {
		MetaData Meta;
		DataAccess Conn;
		public Frm_no_table_itinerationamountdetail() {
			InitializeComponent();
		}
        QueryHelper QHS;
        CQueryHelper QHC;
        DateTime DateSys;
        CfgItineration MyCfg = new CfgItineration();
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            txtEsercizioMissione.Text = Meta.GetSys("esercizio").ToString();
            DataAccess.SetTableForReading(DS.itinerationrefund_advance, "itinerationrefund");
            DataAccess.SetTableForReading(DS.itinerationrefund_balance, "itinerationrefund");
            DataAccess.SetTableForReading(DS.itinerationrefundkind_advance, "itinerationrefundkind");
            DataAccess.SetTableForReading(DS.itinerationrefundkind_balance, "itinerationrefundkind");
            GetData.SetStaticFilter(DS.itinerationrefund_advance, QHS.CmpEq("flagadvancebalance", "A"));
            GetData.SetStaticFilter(DS.itinerationrefund_balance, QHS.CmpEq("flagadvancebalance", "S"));
            string filteresercizio = QHS.CmpEq("ayear", security.GetSys("esercizio"));
            GetData.CacheTable(DS.config, filteresercizio, null, false);
            object oggi = Conn.DO_SYS_CMD("select getdate()");
            DateSys = (DateTime)oggi;

        }

        private bool ValidaInput(out int esercizio, out int nstart, out int nstop) {
            esercizio = nstart = nstop = 0;

            if (!int.TryParse(txtEsercizioMissione.Text, out esercizio)) {
                show("Specificare un Esercizio valido", "Errore");
                return false;
            }

            //if (esercizio < 2025) {
            //    show("Specificare un Esercizio >= 2025", "Errore");
            //    return false;
            //}

            if (!int.TryParse(txtNumInizio.Text, out nstart)) {
                show("Specificare un Numero iniziale valido", "Errore");
                return false;
            }

            if (!int.TryParse(txtNumFine.Text, out nstop)) {
                show("Specificare un Numero finale valido", "Errore");
                return false;
            }

            return true;
        }



        private void btnEseguiInsert_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.None;
            btnEseguiInsert.DialogResult = DialogResult.None;

            if (!ValidaInput(out int esercizio, out int nstart, out int nstop))
                return;

            string errors = "";
            btnEseguiInsert.Text = "Operazione in corso...";
            CalcolaTotaliMissione(esercizio, nstart, nstop);
            if ((errors == null) || (errors == "")) {
                btnEseguiInsert.Enabled = false;
                show("Operazione eseguita", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
            else {
                show(errors);
            }
        }


        /// <summary>
        /// Calcola i txtImpesenteItalia/estero in base alla datainizio della riga corrente
        /// </summary>
        private void ImpostaImpEsente(DataRow Curr) {

            controller.GetFormData(true);
            //DataRow Curr = DS.itineration.Rows[0];
            string filter, sorting;
            object datainizio = Curr[MissFun.CampoDataPerGeneralita];
            //if ((datainizio == DBNull.Value) || (((DateTime)datainizio) == QueryCreator.EmptyDate())) {
            //    ClearImpEsente(false);
            //    return;
            //}

            filter = QHS.CmpLe("start", datainizio);
            //if (filter == LastImpEsenteFilter) return;
            //LastImpEsenteFilter = filter;

            sorting = "start DESC";
            DataTable Generalita = Conn.RUN_SELECT("itinerationparameter",
                "start, italianexemption,foreignexemption",
                sorting, filter, "1", false);
            if (Generalita.Rows.Count == 0) {
                show("In Generalità Missioni non è stata trovata alcuna informazione", "Avviso");
                return;
            }
            DataRow RowGen = Generalita.Rows[0];

            MyCfg.italianexemption = CfgFn.GetNoNullDecimal(RowGen["italianexemption"]);
            //if (AzzeraImportoEsente) MyCfg.italianexemption = 0;
            //txtImpEsenteItalia.Text = HelpForm.StringValue(
            //    MyCfg.italianexemption, txtImpEsenteItalia.Tag.ToString());

            MyCfg.foreignexemption = CfgFn.GetNoNullDecimal(RowGen["foreignexemption"]);
            //if (AzzeraImportoEsente) MyCfg.foreignexemption = 0;
            //txtImpEsenteEstero.Text = HelpForm.StringValue(
            //    MyCfg.foreignexemption, txtImpEsenteEstero.Tag.ToString()
            //    );

            if (DS.config.Rows.Count > 0) {
                DataRow CurrSetup = DS.config.Rows[0];
                MyCfg.foreignhours = CfgFn.GetNoNullDecimal(CurrSetup["foreignhours"]);
            }

        }
        private void CalcolaTotaliMissione(object yitineration, object nstart, object nstop) {

            string filterMiss = QHS.AppAnd(QHS.CmpEq("yitineration", yitineration), QHS.Between("nitineration", nstart, nstop));
            //Prende le missioni in base all'intervallo indicato
            DataTable itineration = Conn.RUN_SELECT("itineration", "*", null, filterMiss, null, false);
            foreach (DataRow Curr in itineration.Select()) {
                azzeraTutto();
                decimal totalrefund = 0;
                decimal totalrefundadv = 0;
                decimal totalrefundbal = 0;
                decimal kmrefund = 0;
                decimal extraallowance = 0;
                decimal italiangrossallowance = 0;
                decimal foreigngrossallowance = 0;
                object iditineration = Curr["iditineration"];
                string filter_itineration = qhs.CmpEq(("iditineration"), iditineration);
                Conn.RUN_SELECT_INTO_TABLE(DS.itineration, null, filter_itineration, null, true);
                Conn.RUN_SELECT_INTO_TABLE(DS.itinerationrefund_advance, null, qhs.AppAnd(filter_itineration, QHS.CmpEq("flagadvancebalance", "A")), null, true);
                Conn.RUN_SELECT_INTO_TABLE(DS.itinerationrefundkind_advance, null, QHS.CmpEq("flagadvance", "A"), null, true);
                Conn.RUN_SELECT_INTO_TABLE(DS.itinerationrefund_balance, null, qhs.AppAnd(filter_itineration, QHS.CmpEq("flagadvancebalance", "S")), null, true);
                Conn.RUN_SELECT_INTO_TABLE(DS.itinerationrefundkind_balance, null, QHS.CmpEq("flagbalance", "S"), null, true);
                Conn.RUN_SELECT_INTO_TABLE(DS.itinerationlap, null, filter_itineration, null, true);
                Conn.RUN_SELECT_INTO_TABLE(DS.tax, null, null, null, true);
                Conn.RUN_SELECT_INTO_TABLE(DS.itinerationtax, null, filter_itineration, null, true);
                ImpostaImpEsente(Curr);
                DataRow Ramountdetail;
                Conn.RUN_SELECT_INTO_TABLE(DS.itinerationamountdetail, null, filter_itineration, null, true);
                if (DS.itinerationamountdetail == null || DS.itinerationamountdetail.Rows.Count == 0) {
                    //se non c'è, la crea
                    MetaData Meta_itinerationamountdetail = MetaData.GetMetaData(this, "itinerationamountdetail");
                    Meta_itinerationamountdetail.SetDefaults(DS.itinerationamountdetail);
                    Ramountdetail = Meta_itinerationamountdetail.Get_New_Row(Curr, DS.itinerationamountdetail);
                }
                else {
                    //se c'è, l'aggiorna
                    Ramountdetail = DS.itinerationamountdetail.Rows[0];
                }


                totalrefund = CfgFn.RoundValuta(CalcolaSpeseSostenute(Curr));
                totalrefundadv = CfgFn.RoundValuta(CalcolaSpeseAnticipo());
                totalrefundbal = CfgFn.RoundValuta(CalcolaSpeseSaldo());

                extraallowance = CfgFn.RoundValuta(CalcolaIndennitaSupplementari(Curr));
                kmrefund = CfgFn.RoundValuta(CalcolaIndennitaChilometrica());
                italiangrossallowance = CfgFn.RoundValuta(CalcolaIndLordaTrafertaItalia());
                foreigngrossallowance = CfgFn.RoundValuta(CalcolaIndLordaTrafertaEstero());


                //totindennitalia = SOMMA DELLE INDENNITA TOTALE EURO ITALIA
                //totindennlord manca
                //totesenteitalia
                //totesenteestero
                //if (DS.HasChanges()) {
                    decimal totalgross = CfgFn.RoundValuta(CalcolaImportoLordoMissione(Curr));
                    Curr["totalgross"] = totalgross;
                    //decimal total = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Curr["totalgross"]) +
                    //                                  CfgFn.GetNoNullDecimal(AdminTax()));
                    //Curr["total"] = total;

                    decimal nuovototanticipo = CfgFn.GetNoNullDecimal(Curr["totadvance"]);
                    //if (!AnticipoIsReadOnly) {
                    //    nuovototanticipo = CfgFn.RoundValuta(MissFun.GetTotAnticipoMissione(DS.itinerationlap,
                    //        DS.itinerationrefund_advance));
                    //    Curr["totadvance"] = nuovototanticipo;
                    //}

                Ramountdetail["importoanticipo"] = nuovototanticipo; //txtImportoAnticipo.Text = nuovototanticipo.ToString("c");
                Ramountdetail["importolordo"] = totalgross;//txtLordo.Text = totalgross.ToString("c");
                //txtComplessivo.Text = total.ToString("c");

                //}
                DataTable Spese = getFaseAnticipoMissione(Curr["start"]) ? DS.itinerationrefund_advance : DS.itinerationrefund_balance;
                DataTable TipoSpese = getFaseAnticipoMissione(Curr["start"])
                    ? DS.itinerationrefundkind_advance
                    : DS.itinerationrefundkind_balance;

                decimal quotaesente = MissFun.TotQuoteEsentiTappe(Curr, DS.itinerationlap, MyCfg) +
                                      MissFun.IF_TotQuoteEsentiSpese(Spese, TipoSpese, MyCfg);
                Ramountdetail["quotaesente"] = quotaesente;//txtQuotaEsenteMissione.Text = quotaesente.ToString("c");

                decimal totimponibile = MissFun.TotQuoteImponibiliTappe(Curr, DS.itinerationlap, MyCfg) +
                                        MissFun.IF_TotQuoteImponibiliSpese(Spese, TipoSpese, MyCfg);
                Ramountdetail["imponibile"] = totimponibile; //txtQuotaImponibileTappa.Text = totimponibile.ToString("c");


                Ramountdetail["totspesepreventivateanticipo"] = totalrefundadv;//txtSpeseAnticipo.Text = totalrefundadv.ToString("c");
                Ramountdetail["totspesesostenute"] = totalrefundbal;// txtSpeseSaldo.Text = totalrefundbal.ToString("c");

                Ramountdetail["totspesedaconsiderare"] = totalrefund;//txtSpeseSostenute.Text = totalrefund.ToString("c");

                //if (getFaseAnticipoMissione()) {
                //    labelSpeseSost.Text = "Totale spese da considerare (preventivate):";
                //}
                //else {
                //    labelSpeseSost.Text = "Totale spese da considerare (sostenute):";
                //}

                Ramountdetail["indennsupplementare"] = extraallowance;//txtIndSupplementare.Text = extraallowance.ToString("c");
                Ramountdetail["indennkm"] = kmrefund; //txtTotIndennKm.Text = kmrefund.ToString("c");
                Ramountdetail["indennlordatrasfertait"]= italiangrossallowance; //txtTotLordIt.Text = italiangrossallowance.ToString("c");
                Ramountdetail["indennlordatrasfertaestero"] = foreigngrossallowance; //txtTotLordEst.Text = foreigngrossallowance.ToString("c");

                //R["totspesepreventivateanticipo"] = txtSpeseAnticipo.Text;
                //R["totspesesostenute"] = txtSpeseSaldo;
                //R["totspesedaconsiderare"] = txtSpeseSostenute.Text;
                //R["indennsupplementare"] = txtIndSupplementare.Text;
                //R["indennkm"] = txtTotIndennKm.Text;
                //R["indennlordatrasfertait"] = txtTotLordIt.Text;
                //R["indennlordatrasfertaestero"] = txtTotLordEst.Text;
                //R["importolordo"] = txtLordo.Text;
                decimal contributiassicurativi;
                decimal contributiprevidenziali;
                CalcolaContributi(Curr, out contributiassicurativi, out contributiprevidenziali);
                Ramountdetail["contributiassicurativi"] = contributiassicurativi;//R["contributiassicurativi"] = txtAssAmministrazione.Text;
                Ramountdetail["contributiprevidenziali"] = contributiprevidenziali;//R["contributiprevidenziali"] = txtPrevAmministrazione.Text;
                //R["importoanticipo"] = txtImportoAnticipo.Text;
                //R["quotaesente"] = txtQuotaEsenteMissione.Text;
                //R["imponibile"] = txtQuotaImponibileTappa.Text;

                //  ===================================  Salvataggio ==========================================
                var myPostData = new Easy_PostData();
                myPostData.initClass(DS, Conn);
                var resSave = myPostData.DO_POST();

                if (!resSave) {
                    show(this, "Errore nel salvataggio: "
                        + "Missione Eserc."+ Curr["yitineration"].ToString()+" N."+ Curr["nitineration"].ToString()
                        + "("+ resSave + ")");
                    return;
                }
            }
        }
        decimal CalcolaImportoLordoMissione(DataRow Ritineration) {
            return CalcolaSpeseSostenute(Ritineration) +
                   CalcolaIndennitaSupplementari(Ritineration) +
                   CalcolaIndennitaChilometrica() +
                   CalcolaIndLordaTrafertaItalia() + //lordo 
                   CalcolaIndLordaTrafertaEstero(); //lordo

        }

        bool getFaseAnticipoMissione(object Date) {
            if (Date == DBNull.Value || Date == null) return false;
            bool phase = false;
            DateTime datainizio = (DateTime)Date;

            if (DateSys < datainizio) phase = true;

            return phase;
        }

        decimal CalcolaSpeseSostenute(DataRow Ritineration) {
            decimal SUM = 0;
            //if (controller.IsEmpty) return SUM;

            if (getFaseAnticipoMissione(Ritineration["start"])) {
                foreach (DataRow R in DS.itinerationrefund_advance.Rows) {
                    //if (R.RowState == DataRowState.Deleted) continue;
                    SUM += MissFun.SpesaSostenuta(R);
                }
            }
            else {
                foreach (DataRow R in DS.itinerationrefund_balance.Rows) {
                    //if (R.RowState == DataRowState.Deleted) continue;
                    SUM += MissFun.SpesaSostenuta(R);
                }
            }
            return SUM;
        }
        /// <summary>
        /// Ind. suppl. EURO
        /// </summary>
        /// <returns></returns>
        decimal CalcolaIndennitaSupplementari(DataRow Ritineration) {
            decimal SUM = 0;
            if (getFaseAnticipoMissione(Ritineration["start"])) {
                foreach (DataRow R in DS.itinerationrefund_advance.Rows) {
                    //if (R.RowState == DataRowState.Deleted) continue;
                    SUM += MissFun.IndennitaSupplementare(R);
                }
            }
            else {
                foreach (DataRow R in DS.itinerationrefund_balance.Rows) {
                    //if (R.RowState == DataRowState.Deleted) continue;
                    SUM += MissFun.IndennitaSupplementare(R);
                }
            }
            return CfgFn.RoundValuta(SUM);
        }

        /// <summary>
        /// Ind.Km. EURO
        /// </summary>
        /// <returns></returns>
        decimal CalcolaIndennitaChilometrica() {
            DataRow Curr = DS.itineration.Rows[0];
            return MissFun.IndennitaChilometrica(Curr);
        }

        decimal CalcolaSpeseSaldo() {
            decimal SUM = 0;
            //if (controller.IsEmpty) return SUM;

            foreach (DataRow R in DS.itinerationrefund_balance.Rows) {
                //if (R.RowState == DataRowState.Deleted) continue;
                SUM += MissFun.SpesaSostenuta(R);
            }

            return SUM;
        }
        decimal CalcolaSpeseAnticipo() {
            decimal SUM = 0;
            //if (controller.IsEmpty) return SUM;

            foreach (DataRow R in DS.itinerationrefund_advance.Rows) {
                //if (R.RowState == DataRowState.Deleted) continue;
                SUM += MissFun.SpesaSostenuta(R);
            }

            return SUM;
        }

        /// <summary>
        /// Ind.lorda trasf.italia EURO
        /// </summary>
        /// <returns></returns>
        decimal CalcolaIndLordaTrafertaItalia() {
            decimal SUM = 0;
            DataRow Missione = DS.itineration.Rows[0];
            foreach (DataRow Tappa in DS.itinerationlap.Select(QHC.CmpEq("flagitalian", "S"))) {
                //if (Tappa.RowState == DataRowState.Deleted) continue;
                SUM += MissFun.IndennitaLordaTappa(Missione, Tappa, MyCfg);
            }
            return SUM;
        }

        /// <summary>
        /// Ind.lorda trasf.estero EURO
        /// </summary>
        /// <returns></returns>
        decimal CalcolaIndLordaTrafertaEstero() {
            decimal SUM = 0;
            DataRow Missione = DS.itineration.Rows[0];
            foreach (DataRow Tappa in DS.itinerationlap.Select(QHC.CmpEq("flagitalian", "N"))) {
                //if (Tappa.RowState == DataRowState.Deleted) continue;
                SUM += MissFun.IndennitaLordaTappa(Missione, Tappa, MyCfg);
            }
            return SUM;
        }
        public void CalcolaContributi(DataRow Ritineration, out decimal contributiassicurativi, out decimal contributiprevidenziali) {
            decimal PrevidenzialiEnte = 0;
            decimal AssistenzialiEnte = 0;
            foreach (DataRow DR in DS.itinerationtax.Select(qhc.CmpEq("iditineration",Ritineration["iditineration"]))) {

                decimal DecDip = CfgFn.GetNoNullDecimal(DR["employtax"]);
                decimal DecAmm = CfgFn.GetNoNullDecimal(DR["admintax"]);
                string MyFilter = QHC.CmpEq("taxcode", DR["taxcode"]);
                DataRow[] DRTipo = DS.Tables["tax"].Select(MyFilter);

                //In base al tipo di ritenuta:
                switch (DRTipo[0]["taxkind"].ToString()) {
                    case "2":
                        AssistenzialiEnte += DecAmm;
                        break;
                    case "3":
                        PrevidenzialiEnte += DecAmm;
                        break;
                }
            } //fine foreach

            contributiassicurativi = CfgFn.RoundValuta(AssistenzialiEnte);
            contributiprevidenziali = CfgFn.RoundValuta(PrevidenzialiEnte);
        }
        private void azzeraTutto() {
            DS.itinerationamountdetail.Clear();
            DS.itinerationrefund_advance.Clear();
            DS.itinerationrefund_balance.Clear();
            DS.itinerationtax.Clear();
            DS.itinerationlap.Clear();
            DS.itineration.Clear();
		}

		private void txtNumFine_TextChanged(object sender, EventArgs e) {

		}

		private void label3_Click(object sender, EventArgs e) {

		}

		private void txtEsercizioMissione_TextChanged(object sender, EventArgs e) {

		}
	}
}
