
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
using System.Data;
using System.Linq;
using System.Windows.Forms;
using funzioni_configurazione;
using metadatalibrary;

namespace serviceregistry_default {

    enum EmployKind {
        employee,
        consultant,
    }

    enum State {
        active = 'S',
        inactive = 'N',
    }

    static class Extensions {

        private static EmployKind? GetEmployKind(this DataRow dr) {
            try {
                if (dr != null && dr.Table.Columns.Contains("employkind") && dr["employkind"] != DBNull.Value) {

                    var firstChar = dr["employkind"].ToString().ToUpper().ToCharArray()[0];

                    switch (firstChar) {
                        case 'D':
                            return EmployKind.employee;

                        case 'C':
                        case 'A':
                            return EmployKind.consultant;

                        default:
                            return null;
                    }
                }

                return null;
            }
            catch (Exception) {
                return null;
            }
        }

        private static State GetActiveState(this DataRow dr) {
            try {
                if (dr != null && dr["active"] != DBNull.Value && dr.Table.Columns.Contains("active")) {
                    var firstChar = dr["active"].ToString().ToUpper().ToCharArray()[0];
                    return (State)firstChar;
                }
                else {
                    return State.inactive;
                }
            }
            catch (Exception) {
                return State.inactive;
            }
        }

        /// <summary>
        /// Valorizza un campo destFieldName della tabella definitions in base ai valori di altre colonne della stessa tabella definitions.
        /// La scelta del modo in cui valorizzare destFieldName viene fatta in base al valore di kind, che rappresenta il tipo di entità per la quale
        /// filtrare ed elaborare le righe di definitions, e in base all'ordine degli elementi di mergeKinds.
        /// </summary>
        /// <param name="definitions">Tabella delle definizioni da elaborare.</param>
        /// <param name="kind">Tipo dell'entità per la quale elaborare la tabella delle definizioni.</param>
        /// <param name="destFieldName">Nome del campo destinazione dell'elaborazione.</param>
        /// <param name="mergeKinds">Tipi delle entità da utilizzare per la valorizzazione del campo destinazione qualora non sia conosciuto il tipo dell'entità.</param>
        /// <returns></returns>
        private static IEnumerable<DataRow> MergeFields(this DataTable definitions, EmployKind? kind, string destFieldName, params EmployKind[] mergeKinds) {

            var requiredFieldNames = mergeKinds.Select(fk => string.Join("_", destFieldName, fk.ToString())); // nomi dei campi ammessi sulla tabella di definizione

            if (!requiredFieldNames.All(rfn => definitions.Columns.Contains(rfn))) // se la tabella non contiene tutti i campi nel formato destFieldName_EmployKind
                throw new Exception("La tabella non contiene i campi da visualizzare: " + string.Join(", ", requiredFieldNames));

            if (!definitions.Columns.Contains(destFieldName))             // se la tabella non contiene il campo di destinazione
                definitions.Columns.Add(destFieldName, typeof(string));   // lo aggiungiamo

            DataRow fieldMerger(EmployKind? ek, DataRow dr) {

                var merged = definitions.NewRowAs(dr); // riga destinazione con lo stesso schema di dr

                if (ek != null) { // se l'EmployKind dell'entità corrente non è sconosciuto
                    merged[destFieldName] = dr[string.Join("_", destFieldName, kind.ToString())]; // mettiamo nel campo destinazione della riga destinazione il valore scelto in base all'EmployKind

                } else { // se l'EmployKind è sconosciuto

                    var oldValues = new[] { dr[destFieldName].ToString() }  // vecchi valori della riga di definizione
                        .Where(value => !string.IsNullOrEmpty(value))       // non vuoti
                        .Distinct();                                        // e unici

                    var newValues = requiredFieldNames
                        .Select(name => dr[name].ToString())            // nuovi valori della riga di definizione corrispondenti ai nomi dei campi ammessi
                        .Where(value => !string.IsNullOrEmpty(value))   // non vuoti
                        .Distinct();                                    // e unici

                    var differentOldValues = oldValues                      // vecchi valori della riga di definizione
                        .Where(ov => !newValues.Select(nv => nv.ToLower())  // proiettati nelle versioni ToLower()
                        .Any(value => value.Contains(ov.ToLower())));       // non contenuti nei nuovi valori proiettati a ToLower()

                    var finalValues = differentOldValues.Concat(newValues)  // uniamo i due insiemi e consideriamo solo gli elementi
                        .Distinct();                                        // unici

                    merged[destFieldName] = string.Join(" - ", finalValues); // mettiamo nel campo destinazione della riga destinazione la concatenazione dei valori
                }

                return merged;
            }

            List<DataRow> mergedRows = new List<DataRow>();
            definitions.AsEnumerable()._forEach(row => mergedRows.Add(fieldMerger(kind, row))); // per ogni riga della tabella aggiungiamo alla lista una riga elaborata dalla funzione letterale

            return mergedRows;
        }

        /// <summary>
        /// Indica se il DataSet che contiene la tabella dt contiene anche una backup di dt.
        /// </summary>
        /// <param name="dt">DataTable della quale verificare la presenza del backup</param>
        /// <returns>true se il backup è presente, false altrimenti</returns>
        private static bool HasBackup(this DataTable dt) {

            if (string.IsNullOrEmpty(dt.TableName))
                throw new Exception(string.Format("La tabella non ha un nome"));

            if (dt.DataSet == null)
                throw new Exception(string.Format("La tabella {0} non appartiene ad un dataset,", dt.TableName));

            return dt.DataSet.Tables.Contains(dt.TableName + "_backup");
        }

        /// <summary>
        /// Crea una tabella di backup copia della tabella dt e la aggiunge al DataSet che contiene dt.
        /// </summary>
        /// <param name="dt"></param>
        private static void Backup(this DataTable dt) {

            if (!dt.HasBackup()) {
                DataTable backup = dt.Copy();
                backup.TableName = dt.TableName + "_backup";

                dt.DataSet.Tables.Add(backup);
            }
        }

        /// <summary>
        /// Recupera dal DataSet che contiene la tabella dt una copia del backup della tabella.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>copia del backup della tabella dt</returns>
        private static DataTable GetBackupCopy(this DataTable dt) {

            if (dt.HasBackup()) {
                var copy = dt.DataSet.Tables[dt.TableName + "_backup"].Copy();
                copy.TableName = dt.TableName;

                return copy;
            }

            throw new Exception("La tabella non ha un backup.");
        }

        /// <summary>
        /// Aggiorna DataSource, DisplayMember e ValueMember di un ComboBox gestito da MDL filtrandone il DataSource e scegliendone
        /// DisplayMember e ValueMember. La scelta viene effettuata in base allo stato del MetaDato associato al form
        /// al quale il ComboBox appartiene.
        /// </summary>
        /// <param name="cmb">ComboBox del quale aggiornare il DataSource, DisplayMember e ValueMember</param>
        /// <param name="forcedKind">Parametro opzionale per guidare il modo in cui sarà filtrato il DataSource</param>
        public static void UpdateADP(this ComboBox cmb, EmployKind? forcedKind = null) {

            if (cmb == null)
                return;
            
            MetaDataForm mdf;
            MetaData meta;

            DataTable source;
            DataTable tmpTable;

            try {
                mdf = (MetaDataForm)cmb.FindForm();
                meta = MetaData.GetMetaData(mdf);

                //if (!meta.DrawStateIsDone)
                //    return;

                source = meta.DS.Tables[((DataTable)cmb.DataSource).TableName];

                source.Backup();                    // creiamo una copia di backup della tabella sorgente del controllo (se il backup esiste non sarà sovrascritto)
                source.Clear();                     // svuotiamo la tabella sorgente del controllo
                GetData.Add_Blank_Row(source);      // aggiungiamo la riga vuota

                tmpTable = source.GetBackupCopy();  // tabella temporanea creata dalla copia di backup
            }
            catch (Exception e) {
                throw e;
            }

            string displayMember = "description";
            string valueMember = "id" + source.TableName;

            if (!tmpTable.Columns.Contains(valueMember))
                return;

            if (!source.Columns.Contains(displayMember))
                source.Columns.Add(displayMember, typeof(string));

            if (!tmpTable.Columns.Contains(displayMember))
                tmpTable.Columns.Add(displayMember, typeof(string));

            mdf.getFormData();
            var currentRow = mdf.currentRow;
            
            var currentKind = forcedKind ?? currentRow.GetEmployKind();
            var esercizio = CfgFn.GetNoNullInt32(meta.GetSys("esercizio"));

            bool isForCurrentYear(DataRow r) => CfgFn.GetNoNullInt32(r["ayear"]) == esercizio;                  // definizioni valide per l'esercizio corrente
            bool isActive(DataRow r) => r.GetActiveState() == State.active;                                     // definizioni attive
            bool displayMemberHasValue(DataRow r) => !string.IsNullOrWhiteSpace(r[displayMember].ToString());   // definizioni che abbiano un campo displayMember valorizzato

            if (meta.IsEmpty) {

                tmpTable
                    .MergeFields(currentKind, displayMember, EmployKind.employee, EmployKind.consultant)
                    .Where(isForCurrentYear)
                    .Where(displayMemberHasValue)
                    .CopyToDataTable(source, LoadOption.OverwriteChanges); // aggiungiamo le righe filtrate della tabella temporanea alla tabella sorgente del controllo

                cmb.DataSource = source;

                cmb.ValueMember = valueMember;
                cmb.SelectedIndex = -1;
            }

            if (meta.InsertMode || meta.EditMode) {

                tmpTable
                    .MergeFields(currentKind, displayMember, EmployKind.employee, EmployKind.consultant)
                    .Where(isForCurrentYear)
                    .Where(isActive)
                    .Where(displayMemberHasValue)
                    .CopyToDataTable(source, LoadOption.OverwriteChanges); // aggiungiamo le righe filtrate della tabella temporanea alla tabella sorgente del controllo

                cmb.DataSource = source;

                cmb.ValueMember = valueMember;
                cmb.SelectedValue = currentRow[valueMember];
            }

            cmb.DisplayMember = displayMember;

            meta.myHelpForm.PreFillControlsTable(cmb, null);
        }
    }
}
