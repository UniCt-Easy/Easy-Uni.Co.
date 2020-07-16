/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using System.Collections;
using funzioni_configurazione;

namespace no_table_unifydip {
    /// <summary>
    /// Classe base che applica una trasformazione sui valori in ingresso
    /// </summary>
    public interface translator {
        /// <summary>
        /// Checks correctness of class creation
        /// </summary>
        /// <returns></returns>
        bool status_ok();

        /// <summary>
        /// Applies the translation on an input value
        /// </summary>
        /// <param name="oldvalue"></param>
        /// <returns></returns>
        object translate(object oldvalue);

        /// <summary>
        /// verifies applicability of the transformation on a table
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Dest"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        bool Precheck(DataAccess Source, DataAccess Dest, string table);
    }

    /// <summary>
    /// Applies a translation basing on a hashtable
    /// </summary>
    public class ManualTranslator : translator {
        private Hashtable H;

        public ManualTranslator(Hashtable H) {
            this.H = H;
        }

        public bool status_ok() {
            return (H != null);
        }

        public bool Precheck(DataAccess Source, DataAccess Dest, string table) {
            return true;
        }

        public object translate(object oldvalue) {
            if (oldvalue == DBNull.Value) return DBNull.Value;
            return H[oldvalue];
        }
    }

    /// <summary>
    /// Leaves a field unchanged
    /// </summary>
    public class IdentityTranslator : translator {
        public IdentityTranslator() {}

        public bool status_ok() {
            return true;
        }

        public bool Precheck(DataAccess Source, DataAccess Dest, string table) {
            return true;
        }

        public object translate(object oldvalue) {
            return oldvalue;
        }
    }

    public class set_to_null : set_to_constant {
        public set_to_null() : base(DBNull.Value) {}
    }

    public class set_to_constant : translator {
        private object constant;

        public bool status_ok() {
            return true;
        }

        public object translate(object oldvalue) {
            return constant;
        }

        public set_to_constant(object constant) {
            this.constant = constant;
        }

        public bool Precheck(DataAccess Source, DataAccess Dest, string table) {
            return true;
        }
    }


    /// <summary>
    /// Appends a constant string to a field
    /// </summary>
    public class StringAppender : translator {
        private int maxlen;
        private int mylen;

        public bool status_ok() {
            return true;
        }

        public object translate(object oldvalue) {
            if (stringtoappend=="") return oldvalue;
            if (oldvalue == DBNull.Value) return DBNull.Value;
            string S = oldvalue.ToString();
            if (S.Length > maxlen - mylen) S = S.Substring(0, maxlen - mylen);
            return S + stringtoappend;
        }

        private string stringtoappend;

        public StringAppender(string stringtoappend, int maxlen) {
            this.stringtoappend = stringtoappend;
            this.maxlen = maxlen;
            this.mylen = stringtoappend.Length;
        }

        public bool Precheck(DataAccess Source, DataAccess Dest, string table) {
            return true;
        }

    }

    public class conditional_offset_applier : offset_applier {
        private int threeshold;
        int min_over_threeshold=0;
        int max_over_threshold=0;
        int num_conflict_over = 0;
        protected string filter_conflict_base = null;

        public conditional_offset_applier(string tablename, string field, int threeshold):base(tablename,field) {
            this.threeshold = threeshold;
        }
        public override object translate(object oldvalue) {
            if (oldvalue == DBNull.Value) return DBNull.Value;
            int val = CfgFn.GetNoNullInt32(oldvalue);
            if ((threeshold>0) &&  (val > threeshold)) return val;
            return base.translate(oldvalue);
            
        }
       
       
        public override offset_applier initialize(DataAccess Source, DataAccess Dest, int offset) {           
            max_dest = GetMax(Dest);

            if (offset == 0)
                this.offset = max_dest + 1;
            else
                this.offset = offset;

            status = (offset >= max_dest);
            return this;
        }

        public conditional_offset_applier SetFilterConflict(string filter) {
            this.filter_conflict_base = filter;
            return this;
        }


        public override bool Precheck(DataAccess Source, DataAccess Dest, string table) {
            //la base controlla che l'offset sia superiore al massimo nella destinazione
            if (!base.Precheck(Source, Dest, table)) return false;
            
            QueryHelper QHS= Source.GetQueryHelper();

            //over_threeshold  = ciÚ che Ë stato inserito PRIMA della prima unificazione 
            //  non deve essere ulteriormente traslato ma non deve neanche andare in conflitto con i dati esistenti

            //under_threeshold = ciÚ che Ë stato inserito DOPO la prima unificazione
            //  deve essere traslato oltre i dati esistenti


            if (threeshold > 0) {
                min_over_threeshold = CfgFn.GetNoNullInt32(Source.DO_READ_VALUE(tablename,
                                             QHS.AppAnd(QHS.CmpGt(field, threeshold),filter_conflict_base),
                                                                                "min(" + field + ")"));

                max_over_threshold = CfgFn.GetNoNullInt32(Source.DO_READ_VALUE(tablename,
                                             QHS.AppAnd(QHS.CmpGt(field, threeshold),filter_conflict_base),
                                                                               "max(" + field + ")"));


                string filter_conflict = QHS.Between(field, min_over_threeshold, max_over_threshold);
                if (filter_conflict_base != null) filter_conflict = QHS.AppAnd(filter_conflict, filter_conflict_base);
                num_conflict_over = CfgFn.GetNoNullInt32(Dest.RUN_SELECT_COUNT(tablename, filter_conflict, false));


                if (num_conflict_over > 0) {
                    MessageBox.Show(
                        "Nella tabella " + tablename + " del db di destinazione il campo " + field +
                        " assume gi‡ dei valori compresi tra " + min_over_threeshold.ToString() + " e " +
                        max_over_threshold.ToString() + ", facenti parte di quelli presenti nel db di origine " +
                        " che NON saranno soggetti a traslazione dato che superano la soglia di " +
                        threeshold.ToString(), "Errore");
                    return false;
                }



                int min_under_threeshold = CfgFn.GetNoNullInt32(Source.DO_READ_VALUE(tablename,
                                                        QHS.AppAnd(QHS.CmpLt(field, threeshold),filter_conflict_base),
                                                                                     "min(" + field + ")"));

                int max_under_threshold = CfgFn.GetNoNullInt32(Source.DO_READ_VALUE(tablename,
                                             QHS.AppAnd(QHS.CmpLt(field, threeshold),filter_conflict_base),
                                                                                    "max(" + field + ")"));
                string filter_conflict_under = QHS.Between(field, min_under_threeshold + offset,
                                                           max_under_threshold + offset);

                if (filter_conflict_base != null)
                    filter_conflict_under = QHS.AppAnd(filter_conflict_under, filter_conflict_base);
                int num_conflict_under =
                    CfgFn.GetNoNullInt32(Dest.RUN_SELECT_COUNT(tablename, filter_conflict_under, false));


                if (num_conflict_under > 0) {
                    MessageBox.Show(
                        "Nella tabella " + tablename + " del db di destinazione il campo " + field +
                        " assume gi‡ dei valori compresi tra " + min_under_threeshold.ToString() + "+" +
                        offset.ToString() + " e " +
                        max_under_threshold.ToString() + "+" + offset.ToString() +
                        ", facenti parte di quelli presenti nel db di origine " +
                        " che SARANNO soggetti a traslazione dato che NON superano la soglia di " +
                        threeshold.ToString(), "Errore");
                    return false;
                }

            }
            else {
                int min = CfgFn.GetNoNullInt32(Source.DO_READ_VALUE(tablename,filter_conflict_base
                                                                                    ,"min(" + field + ")"));

                int max = CfgFn.GetNoNullInt32(Source.DO_READ_VALUE(tablename, filter_conflict_base,
                                                                                    "max(" + field + ")"));
                string filter_conflict_0 = QHS.Between(field, min + offset,
                                                           max + offset);

                if (filter_conflict_base != null)
                    filter_conflict_0 = QHS.AppAnd(filter_conflict_0, filter_conflict_base);
                int num_conflict_0 =
                    CfgFn.GetNoNullInt32(Dest.RUN_SELECT_COUNT(tablename, filter_conflict_0, false));


                if (num_conflict_0 > 0) {
                    MessageBox.Show(
                        "Nella tabella " + tablename + " del db di destinazione il campo " + field +
                        " assume gi‡ dei valori compresi tra " + min.ToString() + "+" +
                        offset.ToString() + " e " +
                        max.ToString() + "+" + offset.ToString() +
                        ", facenti parte di quelli presenti nel db di origine " +
                        " che SARANNO soggetti a traslazione dato che NON Ë stata indicata una soglia", "Errore");
                    return false;
                }
            }

            return true;
        }


        public override string ToString() {
            if (offset < max_dest) {
                status = false;
                return "ATTENZIONE ERRORE nella traslazione della tabella " + tablename + " con offset " + offset;
            }
            if (num_conflict_over > 0) {
                return "ATTENZIONE :"+
                "Nella tabella " + tablename + " del db di destinazione il campo " + field +
                    " assume gi‡ dei valori compresi tra " + min_over_threeshold.ToString() + " e " +
                     max_over_threshold.ToString() + ", facenti parte di quelli presenti nel db di origine " +
                     " che NON saranno soggetti a traslazione dato che superano la soglia di " + threeshold.ToString();
            }

           

            string tabfield = tablename + "." + field;
            return tabfield.PadLeft(40) +
                   "    DestMax:" + max_dest.ToString("G6") + " Offset:" + offset.ToString("G6");
        }


    }

    /// <summary>
    /// Adds an offset to a field
    /// </summary>
    public class offset_applier : translator {
        public string tablename;
        public string field;
        public int max_dest;
        public int offset;
        private string filter;
        protected bool status = false;
      


        /// <summary>
        /// List of values to skip. For those value the translation will be null
        /// </summary>
        public List<int> ToSkip = new List<int>();


        public offset_applier(string tablename, string field) {
            this.tablename = tablename;
            this.field = field;
            max_dest = 0;
            offset = 0;
        }

        

        public virtual object translate(object oldvalue) {
            if (oldvalue == DBNull.Value) return DBNull.Value;
            int val = CfgFn.GetNoNullInt32(oldvalue);
            if (ToSkip.Contains(val)) return null;
            return val + offset;
        }

        public bool status_ok() {
            return status;
        }

        protected int GetMax(DataAccess Conn) {
            QueryHelper QHS = Conn.GetQueryHelper();
            Object O = Conn.DO_READ_VALUE(tablename, filter , "max(" + field + ")");
            if (O == null || O == DBNull.Value) return 0;
            return CfgFn.GetNoNullInt32(O);
        }

        public virtual offset_applier initialize(DataAccess Source, DataAccess Dest, int offset) {
            max_dest = GetMax(Dest);
            if (offset == 0)
                this.offset = max_dest + 1;
            else
                this.offset = offset;
            status = (offset >= max_dest);
            return this;
        }

        /// <summary>
        /// Translates only a subset of value, converting the remaining to null
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Dest"></param>
        /// <param name="offset"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public offset_applier initialize(DataAccess Source, DataAccess Dest, int offset, string filter) {
            if (filter != null && filter != "") {
                DataTable T = Source.RUN_SELECT(tablename, field, null, "NOT(" + filter + ")", null, false);
                foreach (DataRow R in T.Rows)
                    ToSkip.Add(CfgFn.GetNoNullInt32(R[field]));
            }

            this.filter = filter;
            max_dest = GetMax(Dest);
            if (offset == 0)
                this.offset = max_dest + 1;
            else
                this.offset = offset;
            status = (offset >= max_dest);
            return this;
        }


        public override string ToString() {
            if (offset < max_dest) {
                status = false;
                return "ATTENZIONE ERRORE nella traslazione della tabella " + tablename + " con offset " + offset;
            }
            string tabfield = tablename + "." + field;
            return tabfield.PadLeft(40) +
                   "    DestMax:" + max_dest.ToString("G6") + " Offset:" + offset.ToString("G6");
        }

        public virtual bool Precheck(DataAccess Source, DataAccess Dest, string table) {
            if (offset < max_dest) {
                MessageBox.Show("Nella tabella " + table + " l'offset impostato (" + offset.ToString() +
                                ") Ë minore del massimo valore presente nel campo " + field +
                                "(" + max_dest.ToString() + ").", "Errore");
                status = false;
                return false;
            }

            return true;
        }


    }




    /// <summary>
    /// Classe che si occupa di tradurre campi in base ad un lookup, ossia confrontando un campo non chiave
    /// </summary>
    public class base_lookup_translator : translator {
        private string table;
        private string source_codefield;
        private string dest_codefield;
        private string keyfield;
        private Hashtable H = new Hashtable();
        private string stato = "";
        private bool status = true;
        private bool AllowNoTranslation = false;

        public virtual object translate(object oldvalue) {
            if (AllowNoTranslation) {
                if (H[oldvalue] == null) return DBNull.Value;
            }
            return H[oldvalue];
        }

        public bool status_ok() {
            return status;
        }
        public translator SetAllowNoTranslation(bool allow) {
            AllowNoTranslation = allow;
            return this;
        }
        public base_lookup_translator(string table, string source_codefield, string dest_codefield, string keyfield) {
            this.table = table;
            this.source_codefield = source_codefield;
            this.dest_codefield = dest_codefield;
            this.keyfield = keyfield;
            stato = "Traduzione " + table.PadLeft(40) + " non ancora creata.";
        }
        private bool skipfound=false;
        
        /// <summary>
        /// Inizializza un lookup
        /// </summary>
        /// <param name="Source">Connessione da cui esportare</param>
        /// <param name="Dest">Connessione in cui importare</param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public translator initialize(DataAccess Source, DataAccess Dest, string filter) {
            DataTable TDest = null;
            if (dest_codefield != keyfield) {
                        TDest = Dest.RUN_SELECT(table, keyfield + "," + dest_codefield, null, filter, null, false);
                }
            else {
                    TDest = Dest.RUN_SELECT(table, keyfield , null, filter, null, false);
            }
            DataTable TSource = null;
            if (source_codefield != keyfield) {
                TSource =  Source.RUN_SELECT(table, keyfield + "," + source_codefield, null, filter, null, false);
            }
            else {
                TSource =  Source.RUN_SELECT(table, keyfield , null, filter, null, false);    
            }
            
            CQueryHelper QHC = new CQueryHelper();
            foreach (DataRow R in TSource.Rows) {
                if (R[source_codefield].ToString() == "") {
                    skipfound = true;
                    continue;
                }
                string filterDestC = QHC.CmpEq(dest_codefield, R[source_codefield]);
                if (TDest.Select(filterDestC).Length == 0) {
                    if (AllowNoTranslation) continue;
                    status = false;
                    stato = "ATTENZIONE ERRORE nella tabella " + table + ": " + dest_codefield + " = " + R[source_codefield] +
                            " non trovato nel dipartimento di destinazione";
                    MessageBox.Show(stato, "Errore");
                    return this;
                }
                H[R[keyfield]] = TDest.Select(filterDestC)[0][keyfield];
            }
            stato = "Traduzione " + table.PadLeft(40) + " creata.";
            return this;
        }



        public override string ToString() {
            return stato;
        }


        public bool Precheck(DataAccess Source, DataAccess Dest, string table) {
            if ((AllowNoTranslation == false) && skipfound) {
                status = false;
                stato = "ATTENZIONE ERRORE nella tabella " + table + " il campo " + source_codefield + 
                                " assume valori null per alcune righe e quindi non Ë possibile procedere con la traduzione";
                MessageBox.Show(stato, "Errore");
            }
            return status;
        }

    }

    public class lookup_translator : base_lookup_translator {

        public lookup_translator(string table, string codefield, string keyfield)
                :base(table,codefield,codefield,keyfield)
        { }
    }

}
