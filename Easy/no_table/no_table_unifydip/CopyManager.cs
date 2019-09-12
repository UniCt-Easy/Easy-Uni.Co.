/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Text;
using metadatalibrary;
using System.Data;
using System.IO;
using System.Windows.Forms;


namespace no_table_unifydip {

    /// <summary>
    /// Manages a context to decide what fields have to be translated and how
    /// </summary>
    public class CopyContext {
        Dictionary<string, translator> H;
        public CopyContext(Dictionary<string, translator> Translators) {
            this.H = Translators;
        }
        public CopyContext() {
            this.H = new Dictionary<string, translator>();
        }

        public bool IsDefined(string translatorCode) {
            return H.ContainsKey(translatorCode);
        }
        public CopyContext Add(string translatorCode, translator TR) {
            if (IsDefined(translatorCode) ) {
                MessageBox.Show("Errore: doppia definizione del translator di codice " + translatorCode, "Errore di progettazione");
            }
            H[translatorCode] = TR;
            return this;
        }

        /// <summary>
        /// Evaluates the traduction of a field value
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public object Translate(string field, object value) {
            if (H.ContainsKey(field)) return H[field].translate(value);
            return value;
        }


    }

    /// <summary>
    /// Copy manager manages the copy of a set of tables
    /// </summary>
    public class CopyManager {
        List<Copyer> AR = new List<Copyer>();
        DataAccess Source;
        DataAccess Dest;


        public CopyManager(DataAccess Source, DataAccess Dest) {
            this.Source = Source;
            this.Dest = Dest;
        }

        /// <summary>
        /// Adds a Copyer to the Copy Manager
        /// </summary>
        /// <param name="C"></param>
        /// <param name="depends"></param>
        public CopyManager Add(Copyer C) {
            AR.Add(C);
            return this;
        }

        /// <summary>
        /// Check all conditions necessary to do the copy. Does not write to db
        /// </summary>
        /// <param name="CD"></param>
        /// <returns></returns>
        public virtual bool CheckAll(CopyDisplay CD) {
            CD.Start("Checking");
            bool status_ok = true;
            List<string> CC = new List<string>();
            foreach (Copyer C in AR) {
                if (CC.Contains(C.table)) {
                    MessageBox.Show("Errore di programmazione: il Copyer di " + C.table + " è stato aggiunto due volte", "Errore");
                    continue;
                }
                CC.Add(C.table);
                CD.Start(C.table, "check", 1);
                if (C.CheckPreconditions(Source, Dest) == false) {
                    CD.Stop(false);
                    status_ok = false;
                }
                else {
                    CD.Stop(true);
                }
            }
            return status_ok;
        }

        /// <summary>
        /// Copy all tables respecting dependencies
        /// </summary>
        /// <param name="CD"></param>
        /// <returns></returns>
        public bool CopyAll(CopyDisplay CD) {



            CD.Start("Copying");
            CD.Comment("Disable Triggers");
            Dest.CallSP("enable_disable_triggers",
                                       new object[2]{Dest.GetSys("userdb").ToString(),
			                          'D'},
                                       false,
                                       500);


           




            List<string> FieldToLookup = new List<string>();
            foreach (Copyer C in AR) {
                foreach (string code in C.CodeDefined()) FieldToLookup.Add(code);
            }
            bool somethingcopied = true;
            Dictionary<string, translator> Trlist = new Dictionary<string, translator>();

            while (somethingcopied) {
                somethingcopied = false;
                foreach (Copyer C in AR) {
                    if (C.applied) continue;
                    CopyContext Ctx = new CopyContext(Trlist);

                    //verifica le dipendenze di C
                    if (!C.CheckDependencies(Ctx, FieldToLookup)) continue;//non può copiare ancora questa tabella, mancano dipendenze
                    C.MergePreTranslatorsTo(Ctx);

                    bool res = C.CopyTable(Source, Dest, Ctx, CD);
                    
                    if (!res) {
                        CD.Comment("Enable Triggers");
                        Dest.CallSP("enable_disable_triggers",
                                      new object[2]{Dest.GetSys("userdb").ToString(),
			                          'E'},
                                      false,
                                      500);

                        MessageBox.Show("La copia della tabella " + C.table + " non è stata effettuata", "Errore");
                        return false;
                    }
                    somethingcopied = true;
                    C.MergePostTranslatorsTo(Ctx);
                    if (!C.applied)
                        CD.Comment("\r\n>>>>>>>>>>>>>>>>>Table " + C.table + " did not set APPLIED flag <<<<<<<<<<<<<<<<<<<<<<<<\r\n");
                }


            }
            foreach (Copyer C in AR) {
                if (!C.applied) {
                    MessageBox.Show("La copia della tabella " + C.table + " non è stata effettuata per mancanza di dipendenze", "Errore");
                }
            }
            CD.Comment("Enable Triggers");
            Dest.CallSP("enable_disable_triggers",
                                      new object[2]{Dest.GetSys("userdb").ToString(),
			                          'E'},
                                      false,
                                      500);

            return true;

        }

    }


    public class CopyDisplay {
        TextBox T;
        ProgressBar B;
        public void Comment(string S) {
            T.AppendText(S + "\r\n");
        }


        public void Start(string StartAction) {
            T.AppendText( StartAction + "\r\n");
            B.Value = 0;
            B.Maximum = 0;
        }
        public void Start(string table, string action, int nrows) {
            T.AppendText( table +" "+ action + "("+nrows.ToString()+" rows) start...");
            B.Maximum = nrows;
            B.Value = 0;
        }
        public void Update(int nrows) {
            B.Increment(nrows);
            Application.DoEvents();
        }
        public void Stop(bool ok) {
            B.Value = 0;
            if (ok)
                T.AppendText( " done.\r\n");
            else
                T.AppendText( ">>>>>>> F A I L E D \r\n");
        }

        public CopyDisplay(ProgressBar B, TextBox T) {
            this.T = T;
            this.B = B;
            T.Text = "";
            B.Maximum = 0;
            B.Step = 1;
            B.Value = 0;
        }
    }

}
