
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


using System;
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using funzioni_configurazione;
using System.IO;


namespace no_table_unifydip {

    public class upb_translator : translator {
        Hashtable IDLev1;
        Hashtable H;
        int getnumber(object idupb, int level) {
            if (idupb == null || idupb == DBNull.Value) return 0;
            if (level * 4 >= idupb.ToString().Length) return 0;
            string S = idupb.ToString().Substring(level * 4, 4);
            S = S.TrimStart('0');
            if (S == "") return 0;
            return CfgFn.GetNoNullInt32(S);
        }
        public bool status_ok(){
            return true;
        }
        public object translate(object oldvalue){
            if (oldvalue == DBNull.Value || oldvalue == null) return DBNull.Value;
            if (oldvalue.ToString().Length == 4) return oldvalue;
            if (oldvalue.ToString().Length == 8) return IDLev1[oldvalue.ToString()].ToString();
            string Sleft = oldvalue.ToString().Substring(0, 8);
            string SLeftNew = IDLev1[Sleft].ToString();
            string S = oldvalue.ToString();
            string Sright = "";
            if (S.Length > 12) Sright = S.Substring(12);

            int max = CfgFn.GetNoNullInt32(H[SLeftNew]);
            int ncurr = getnumber(S, 2) + max + 1; //è necessario sommare 1 perché gli upb hanno base zero

            string Smain = ncurr.ToString().PadLeft(4, '0');
            return SLeftNew + Smain + Sright;
        }

        public bool Precheck(DataAccess Source, DataAccess Dest, string table){
            return true;
        }

        public upb_translator(Hashtable IDLev1, Hashtable MaxLev1){
            this.H= MaxLev1;
            this.IDLev1 = IDLev1;
        }
    }

    /// <summary>
    /// Copia il tree degli upb, non più usato perché siamo rimasti d'accordo che riempiamo PRIMA l'intera struttura delle UPB
    /// </summary>
    public class UpbCopyer : Copyer {
        Hashtable H1 = new Hashtable();//contiene i max per ogni voce di 2o livello. Se null allora non ci sono voci
        Hashtable HIDUPB = new Hashtable();
        bool emptytable = false;
        /// <summary>
        /// Takes the number in ther level(th) segment of the idupb string
        /// </summary>
        /// <param name="idupb"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        int getnumber(object idupb, int level) {
            if (idupb == null || idupb == DBNull.Value) return 0;
            if ((level + 1) * 4 > idupb.ToString().Length) throw new Exception("Errore nella decodifica dell'idupb: " + idupb.ToString()); ;
            string S = idupb.ToString().Substring(level * 4, 4);
            S = S.TrimStart('0');
            if (S == "") return 0;
            return CfgFn.GetNoNullInt32(S);
        }

        int ordine;


        public override bool CheckPreconditions(DataAccess Source, DataAccess Dest) {
            if (!base.CheckPreconditions(Source, Dest)) return false;
            QueryHelper QHS = Source.GetQueryHelper();
            CQueryHelper QHC = new CQueryHelper();

            if (emptytable) {
                DefinesPreTranslator("idupb", new IdentityTranslator());
                SetExternalCode("paridupb", "idupb");
                return true;
            }

            DataTable UPBSource = Source.RUN_SELECT("upb", "*", null, QHS.CmpLe("len(idupb)", 8), null, false);
            DataTable UPBDest = Dest.RUN_SELECT("upb", "*", null, QHS.CmpLe("len(idupb)", 8), null, false);



            foreach (DataRow RS in UPBSource.Rows) {
                if (RS["idupb"].ToString().Length == 4) {
                    HIDUPB["0001"] = "0001";
                    continue;
                }
                DataRow[] RDs = UPBDest.Select(QHC.AppAnd(QHC.CmpEq("codeupb", RS["codeupb"]), QHC.CmpEq("paridupb", "0001")));
                if (RDs.Length == 0) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("L'UPB di 2o livello avente  codice " + RS["codeupb"].ToString() +
                                    " non ha corrispondenza  nel db di destinazione");
                    return false;
                }
                HIDUPB[RS["idupb"].ToString()] = RDs[0]["idupb"].ToString();
            }


            string filter = QHS.CmpEq("len(idupb)", 8);
            DataTable S = Source.RUN_SELECT("upb", "*", null, filter, null, false);
            foreach (DataRow R in S.Rows) {
                //calcola il max child di R
                object max = Dest.DO_READ_VALUE("upb", QHS.CmpEq("paridupb", HIDUPB[R["idupb"].ToString()].ToString()),
                                "MAX(substring(idupb,9,4))");
                int nmax = getnumber(max, 0);
                string lev1 = HIDUPB[R["idupb"].ToString()].ToString();
                H1[lev1] = nmax;                               
            }

            DefinesPreTranslator("idupb", new upb_translator(HIDUPB, H1));
            SetExternalCode("paridupb", "idupb");
            return true;
        }


        protected override bool IsToCopy(DataRow R) {
            if (R["idupb"].ToString().Length > 8) return true;
            return emptytable;
        }

        public UpbCopyer(DataAccess Model, int ordine, bool FirstDepartment)
            : base("upb", Model) {
            this.ordine = ordine;
            this.emptytable = FirstDepartment;
        }

        //protected override void Translate(CopyContext Ctx, DataRow R) {
        //    //if (R["idupb"].ToString().Length == 12) {
        //    //    string S = R["title"].ToString();
        //    //    if (S.Length > 145) S = S.Substring(0,145); 
        //    //    R["title"] = S + "-" + ordine.ToString();
        //    //}
        //    base.Translate(Ctx, R);

        //}
        
    }


    /// <summary>
    /// Copia il bilancio solo se trova tabula rasa altrimenti mappa in base a E/S, codice, e anno. 
    /// </summary>
    public class FinCopyer : Copyer {
        bool istocopy = false;
        Hashtable H = new Hashtable();
        public FinCopyer(DataAccess Model)
            : base("fin", Model) {
        }
        public override bool CheckPreconditions(DataAccess Source, DataAccess Dest) {

            if (! base.CheckPreconditions(Source, Dest))return false;

            if (Dest.RUN_SELECT_COUNT("fin", null, false) == 0) {
                istocopy = true;
                DefinesPreTranslator("idfin", new IdentityTranslator());
                //non c'è bisogno di definire un traslator per idfin
                return true;
            }


            QueryHelper QHS = Source.GetQueryHelper();
            CQueryHelper QHC = new CQueryHelper();
            string filter = QHS.AppAnd(QHS.CmpGe("ayear", 2006), QHS.CmpLe("ayear", 2012), QHS.BitClear("flag", 0));
            DataTable S = Source.RUN_SELECT("fin", "*", null, filter, null, false);
            DataTable D = Dest.RUN_SELECT("fin", "*", null, filter, null, false);

            foreach (DataRow Rs in S.Rows) {
                filter = QHC.MCmp(Rs, "ayear", "codefin");
                DataRow[] found = D.Select(filter);
                if (found.Length == 0) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessuna riga di bilancio trovata nel dip. di destinazione sodisfante il filtro " + filter, "Errore");
                    return false;
                }
                H[Rs["idfin"]] = found[0]["idfin"];
            }

            filter = QHS.AppAnd(QHS.CmpGe("ayear", 2006), QHS.CmpLe("ayear",2012), QHS.BitSet("flag", 0));
            S = Source.RUN_SELECT("fin", "*", null, filter, null, false);
            D = Dest.RUN_SELECT("fin", "*", null, filter, null, false);

            foreach (DataRow Rs in S.Rows) {
                filter = QHC.MCmp(Rs, "ayear", "codefin");
                DataRow[] found = D.Select(filter);
                if (found.Length == 0) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessuna riga di bilancio trovata nel dip. di destinazione sodisfante il filtro " + filter, "Errore");
                    return false;
                }
                H[Rs["idfin"]] = found[0]["idfin"];
            }
            DefinesPreTranslator("idfin", new ManualTranslator(H));
            SetExternalCode("paridfin", "idfin");
            return true;
        }


        public override bool CopyTable(DataAccess Source, DataAccess Dest, CopyContext Ctx, CopyDisplay CD) {
            if (!istocopy) {
                applied = true;
                return true;
            }
            return base.CopyTable(Source, Dest, Ctx, CD);
        }

       
    }

    public class FinYearCopyer : Copyer {
        Hashtable H = new Hashtable();
        public FinYearCopyer(DataAccess Model)
            : base("finyear", Model) {
            QueryHelper QHS = Model.GetQueryHelper();
            //SetFilter( QHS.AppAnd(QHS.CmpGe("ayear", 2006), QHS.CmpGe("len(idupb)", 12)) );
            SetFilter(QHS.CmpGe("ayear", 2006));
        }


        protected override bool IsToCopy(DataRow R) {
            return true;
            //if (R["idupb"].ToString().Length > 8) return true;
            //return false;
        }

        public override bool CopyTable(DataAccess Source, DataAccess Dest, CopyContext Ctx, CopyDisplay CD) {
            //if (!base.CopyTable(Source, Dest, Ctx, CD)) return false;
            applied = false;
            int count = 0;
            QueryHelper QHS = Dest.GetQueryHelper();

            try {
                DataTable Cols = Dest.SQLRunner("sp_columns " + table + ",'" + Dest.GetSys("userdb").ToString() + "'");
                if (Cols.Rows.Count == 0)
                    Cols = Dest.SQLRunner("sp_columns " + table + ",'dbo'");


                int nrows = Source.RUN_SELECT_COUNT(table, filter, false);
                CD.Start(filter == null ? table : table + " where " + filter, "copy", nrows);



                string insert = "INSERT INTO FINYEAR VALUES(";//(
                string s = "";
                string err;
                DataTable T = Dest.CreateTableByName(table, "*");
                string col = QueryCreator.ColumnNameList(T);


                DataAccess.DataRowReader DRR = new DataAccess.DataRowReader(Source, "finyear", col, null, filter);

                foreach (DataRow row in DRR) {
                    CD.Update(1);
                    //if (IsToCopy(row)) continue;  // copia quelle che NON sono da inserire
                    Translate(Ctx, row);

                    string delete = "";
                    DataTable T2 = Dest.RUN_SELECT("finyear", "*", null, QHS.MCmp(row, "idfin", "idupb"), null, false);

                    if (T2.Rows.Count > 0) {
                        DataRow RR = T2.Rows[0];
                        foreach (string field in new string[]{"prevision","secondaryprev",
                                    "prevision2","prevision3","prevision4","prevision5",
                                    "currentarrears","previousarrears","previousprevision",
                                    "previoussecondaryprev"
                        
                                    }) {
                            if (RR[field] == DBNull.Value) continue;
                            if (row[field] == DBNull.Value) {
                                row[field] = RR[field];
                            }
                            else {
                                row[field] = CfgFn.GetNoNullDecimal(row[field]) + CfgFn.GetNoNullDecimal(RR[field]);
                            }
                        }
                        delete = "delete from finyear where " + QHS.MCmp(row, "idfin", "idupb") + "\n\r";
                    }

                    count++;
                    string values = GetSQLDataValues(row, Cols);
                    s += delete + insert + values;
                    if (count == 1) {  //è necessario farlo una riga alla volta
                        Dest.SQLRunner(s, 0, out err); 

                        if (err != null) {
                            QueryCreator.ShowError(null, "Errore", err);
                            StreamWriter fsw = new StreamWriter("temp.sql", false, Encoding.Default);
                            fsw.Write(s.ToString());
                            fsw.Close();
                            MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore durante la copia della tabella " + table + "\r\nLo script lanciato si trova nel file 'temp.sql'");
                            CD.Stop(false);
                            return false;
                        }
                        s = "";
                        count = 0;
                    }
                }
                if (s != "") {
                    Dest.SQLRunner(s, 0, out err);
                    count = 0;
                    if (err != null) {
                        QueryCreator.ShowError(null, "Errore", err);
                        StreamWriter fsw = new StreamWriter("temp.sql", false, Encoding.Default);
                        fsw.Write(s.ToString());
                        fsw.Close();
                        MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore durante la copia di " + table + "\r\nLo script lanciato si trova nel file 'temp.sql'");
                        CD.Stop(false);
                        return false;
                    }

                    s = "";
                }
                CD.Stop(true);
                applied = true;
                return true;
            }
            catch (Exception E) {
                QueryCreator.ShowException(E);
                CD.Stop(false);
                return false;
            }

        }

    }


    public class SurplusCopyer : Copyer {
        public SurplusCopyer(DataAccess Model)
            : base("surplus", Model) {
            QueryHelper QHS = Model.GetQueryHelper();
            SetFilter(QHS.CmpGe("ayear", 2006));   
        }

        public override bool CopyTable(DataAccess Source, DataAccess Dest, CopyContext Ctx, CopyDisplay CD) {
            applied = false;
            int count = 0;
            QueryHelper QHS = Dest.GetQueryHelper();

            try {
                DataTable Cols = Dest.SQLRunner("sp_columns " + table + ",'" + Dest.GetSys("userdb").ToString() + "'");
                if (Cols.Rows.Count == 0)
                    Cols = Dest.SQLRunner("sp_columns " + table + ",'dbo'");
                Comment(Dest, Ctx, CD);


                int nrows = Source.RUN_SELECT_COUNT(table, filter, false);
                CD.Start(filter == null ? table : table + " where " + filter, "copy", nrows);



                string insert = "INSERT INTO surplus VALUES(";//(
                string s = "";
                string err;
                DataTable T = Dest.CreateTableByName(table, "*");
                string col = QueryCreator.ColumnNameList(T);


                DataAccess.DataRowReader DRR = new DataAccess.DataRowReader(Source, "surplus", col, null, filter);

                foreach (DataRow row in DRR) {
                    CD.Update(1);
                    if (!IsToCopy(row)) continue;  // copia quelle che NON sono da inserire
                    Translate(Ctx, row);

                    string delete = "";
                    DataTable T2 = Dest.RUN_SELECT("surplus", "*", null, QHS.CmpEq("ayear",row["ayear"]), null, false);

                    if (T2.Rows.Count > 0) {
                        DataRow RR = T2.Rows[0];
                        foreach (DataColumn CR in T2.Columns) {
                            string field = CR.ColumnName;
                            if (CR.DataType == typeof(decimal)) {
                                if (RR[field] == DBNull.Value) continue;
                                if (row[field] == DBNull.Value) {
                                    row[field] = RR[field];
                                }
                                else {
                                    row[field] = CfgFn.GetNoNullDecimal(row[field]) + CfgFn.GetNoNullDecimal(RR[field]);
                                }
                            }
                        }
                        delete = "delete from surplus where " + QHS.CmpEq("ayear", row["ayear"]) + "\n\r";
                    }
                    row["locked"] = "S";
                    count++;
                    string values = GetSQLDataValues(row, Cols);
                    s += delete + insert + values;
                    if (count == 1) {  //è necessario farlo una riga alla volta
                        Dest.SQLRunner(s, 0, out err);

                        if (err != null) {
                            QueryCreator.ShowError(null, "Errore", err);
                            StreamWriter fsw = new StreamWriter("temp.sql", false, Encoding.Default);
                            fsw.Write(s.ToString());
                            fsw.Close();
                            MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore durante la copia della tabella " + table + "\r\nLo script lanciato si trova nel file 'temp.sql'");
                            CD.Stop(false);
                            return false;
                        }
                        s = "";
                        count = 0;
                    }
                }
                if (s != "") {
                    Dest.SQLRunner(s, 0, out err);
                    count = 0;
                    if (err != null) {
                        QueryCreator.ShowError(null, "Errore", err);
                        StreamWriter fsw = new StreamWriter("temp.sql", false, Encoding.Default);
                        fsw.Write(s.ToString());
                        fsw.Close();
                        MetaFactory.factory.getSingleton<IMessageShower>().Show("Errore durante la copia di " + table + "\r\nLo script lanciato si trova nel file 'temp.sql'");
                        CD.Stop(false);
                        return false;
                    }

                    s = "";
                }
                CD.Stop(true);
                applied = true;
                return true;
            }
            catch (Exception E){
                QueryCreator.ShowException(E);
                CD.Stop(false);
                return false;
            }
        }

    }

    public class SortingCopyer : Copyer {

        translator MyTR;
        Hashtable IDSorToCopy = new Hashtable();
        public SortingCopyer(DataAccess Model)
            : base("sorting", Model) {
        }

        public override bool CheckPreconditions(DataAccess Source, DataAccess Dest) {
            if (!base.CheckPreconditions(Source, Dest)) return false;
            return CheckPreconditions(Source, Dest, false);
        }
        bool MustTranslateCodeSorKind(string codesorkind) {
            codesorkind = codesorkind.ToUpper();
            if (codesorkind == "O7E_SIOPE") return true;
            if (codesorkind == "WIFIN") return true;
            if (codesorkind == "WIFINRR") return true;
            if (codesorkind == "WIFINV") return true;
            if (codesorkind == "WIREG") return true;
            if (codesorkind == "WIREGR") return true;
            if (codesorkind == "WIREGV") return true;
            if (codesorkind == "WIUPB") return true;
            if (codesorkind == "07U_SIOPE") return true;
            if (codesorkind == "WIAM1") return true;
            if (codesorkind == "WIAM2") return true;
            return false;
        }

        protected bool CheckPreconditions(DataAccess Source, DataAccess Dest, bool forced) {
            //if (ClearDestAtStart) {
            //    MyTR = new IdentityTranslator();
            //    SetExternalCode("paridsor", "idsor");
            //    DefinesPreTranslator("idsor", MyTR);

            //    DefinesPreTranslator("idsor1", MyTR);
            //    DefinesPreTranslator("idsor2", MyTR);
            //    DefinesPreTranslator("idsor3", MyTR);

            //    DefinesPreTranslator("idsor01", MyTR);
            //    DefinesPreTranslator("idsor02", MyTR);
            //    DefinesPreTranslator("idsor03", MyTR);
            //    DefinesPreTranslator("idsor04", MyTR);
            //    DefinesPreTranslator("idsor05", MyTR);

            //    return true;
            //}


            DataTable S = Source.RUN_SELECT("sorting", "*", null, null, null, false);
            DataTable Sk = Source.RUN_SELECT("sortingkind", "*", null, null, null, false);
            DataTable D = Dest.RUN_SELECT("sorting", "*", null, null, null, false);
            DataTable Dk = Dest.RUN_SELECT("sortingkind", "*", null, null, null, false);
            CQueryHelper QHC = new CQueryHelper();

            int maxidsor = MetaData.MaxFromColumn(D, "idsor");
            maxidsor = maxidsor+1;

            foreach (DataRow Rs in S.Rows) {
                //proietta Rs[idsorkind] sul db di destinazione
                object idsork = Rs["idsorkind"];
                if (Sk.Select(QHC.CmpEq("idsorkind", idsork)).Length == 0) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Chiave esterna idsorkind ORFANA nella tabella sorting del dipartimento di origine", "Errore");
                    return false;
                }
            }

            bool errors = false;
            Hashtable H = new Hashtable();
            
            foreach (DataRow Rsk in Sk.Rows) {
                
                //il tipo class non va migrato se non rientra nell'elenco di elisabetta
                if (!MustTranslateCodeSorKind(Rsk["codesorkind"].ToString())) continue;

                string filter = QHC.CmpEq("codesorkind", Rsk["codesorkind"]);
                if (Dk.Select(filter).Length == 0) {
                    continue; //sarà creata da zero  ...>NO sarà saltato
                    //MessageBox.Show("Non c'è coerenza per le strutture di tipo classificazione", "Errore di programmazione");
                    //return false;
                }
                object oldidsorkind = Rsk["idsorkind"];
                object newidsorkind = Dk.Select(filter)[0]["idsorkind"];

                DataRow[] RSS = S.Select(QHC.CmpEq("idsorkind", oldidsorkind),"nlevel");//righe di origine
                DataRow[] RSD = D.Select(QHC.CmpEq("idsorkind", newidsorkind));//righe di destinazione
                if (RSD.Length == 0) {
                    //Si predispone a creare le righe
                    foreach (DataRow Rs in RSS) {
                        IDSorToCopy[Rs["idsor"].ToString()] = 1;
                        H[Rs["idsor"]] = maxidsor++;
                    }
                }
                else {
                    //Crea il lookup
                    foreach (DataRow Rs in RSS) {
                        string f = QHC.AppAnd(QHC.CmpEq("idsorkind", newidsorkind), QHC.CmpEq("sortcode", Rs["sortcode"])); 
                        DataRow[] found = D.Select(f);
                        if (found.Length == 0) {
                            H[Rs["idsor"]] = maxidsor++;
                            IDSorToCopy[Rs["idsor"].ToString()] = 1;
                            /* Comment("Avviso: \r\n"+
                                "La classificazione "+Rsk["codesorkind"].ToString()+ " nel dipartimento di destinazione "+
                                " non ha la voce con codice "+Rs["sortcode"].ToString()+" quindi sarà creata.\r\n"+
                                ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\r\n");
                            //errors = true;
                            */
                            continue;
                        }
                        if (found.Length == 1) {
                            if (Rs["nlevel"].ToString() != found[0]["nlevel"].ToString()) {
                                MetaFactory.factory.getSingleton<IMessageShower>().Show("La classificazione " + Rsk["codesorkind"].ToString() + " nel dipartimento di destinazione " +
                                       " con codice " + Rs["sortcode"].ToString()+
                                       " appartiene ad un livello diverso rispetto al dipartimento di origine.", "Errore");
                                errors = true;
                            }

                            H[Rs["idsor"]] = found[0]["idsor"];
                            continue;
                        }
                        MetaFactory.factory.getSingleton<IMessageShower>().Show("La classificazione " + Rsk["codesorkind"].ToString() + " nel dipartimento di destinazione " +
                               " ha PIU' VOCI con codice " + Rs["sortcode"].ToString(), "Errore");
                        errors = true;
                    }
                }

            }
            if (errors) return false;

            MyTR = new ManualTranslator(H);
            SetExternalCode("paridsor", "idsor");
            DefinesPreTranslator("idsor", MyTR);

            DefinesPreTranslator("idsor1", MyTR);
            DefinesPreTranslator("idsor2", MyTR);
            DefinesPreTranslator("idsor3", MyTR);

            DefinesPreTranslator("idsor01", MyTR);
            DefinesPreTranslator("idsor02", MyTR);
            DefinesPreTranslator("idsor03", MyTR);
            DefinesPreTranslator("idsor04", MyTR);
            DefinesPreTranslator("idsor05", MyTR);

            return true;
        }

        protected override bool IsToCopy(DataRow R) {
            //if (ClearDestAtStart) return true;
            if (!IDSorToCopy.ContainsKey(R["idsor"].ToString())) return false;
            return true;
        }
        


    }


    /// <summary>
    /// Non più usato
    /// Se ci sono livelli, verifica che siano nella stessa quantità. Se non ci sono allora si predisponde a copiarli così come stanno
    /// </summary>
    public class LocationLevelCopyer : Copyer {
        new bool DontCopy = false;
        public LocationLevelCopyer(DataAccess Model)
            : base("locationlevel", Model) {
            AddPrivateTranslator("codelen", new set_to_constant(3)); //tutte le lunghezze  a 3
        }

        public override bool CheckPreconditions(DataAccess Source, DataAccess Dest) {
            if (!base.CheckPreconditions(Source, Dest)) return false;
            int nlev_Source = Source.RUN_SELECT_COUNT("locationlevel", null, false);
            int nlev_Dest = Dest.RUN_SELECT_COUNT("locationlevel", null, false);
            if (nlev_Dest > 0) DontCopy = true;
            return (nlev_Dest==nlev_Source)||(nlev_Dest==0);
        }

        public override bool CopyTable(DataAccess Source, DataAccess Dest, CopyContext Ctx, CopyDisplay CD) {
            if (DontCopy) {
                applied = true;
                return true;
            }
            return base.CopyTable(Source, Dest, Ctx, CD);

        }     
    }

    /// <summary>
    /// Non più usato
    /// </summary>
    public class LocationCopyer : Copyer {
        public LocationCopyer(DataAccess Model) :base("location",Model){
        }

        void CalcNewCodesForChilds(Hashtable HLocationCode, DataTable TLocation, object idparentnode, string parentcode, int startnumber) {
            
            CQueryHelper QHC = new CQueryHelper();
            DataRow[] childs = TLocation.Select(QHC.CmpEq("paridlocation", idparentnode));
            for (int i = 0; i < childs.Length;i++ ) {
                DataRow Child = childs[i];
                int num = i + startnumber;
                string newcodechild = parentcode + num.ToString().PadLeft(3, '0');
                string oldcodechild = Child["locationcode"].ToString();
                HLocationCode[oldcodechild] = newcodechild;
                object idchild = Child["idlocation"];
                CalcNewCodesForChilds(HLocationCode, TLocation, idchild, newcodechild, 1);
            }
        }

        public override bool CheckPreconditions(DataAccess Source, DataAccess Dest) {
           
            if (!base.CheckPreconditions(Source, Dest)) return false;
            QueryHelper QHS = Dest.GetQueryHelper();
            DataTable S = Source.RUN_SELECT("location", "*", null, null, null, false);
            int nlevel1 = Dest.RUN_SELECT_COUNT("location", QHS.CmpEq("nlevel", 1), false);

            Hashtable H = new Hashtable();
            CalcNewCodesForChilds(H, S, DBNull.Value, "", nlevel1 + 1);
            translator T = new ManualTranslator(H);
            this.AddPrivateTranslator("locationcode", T);

            offset_applier OA = new offset_applier("location", "idlocation");
            OA.initialize(Source,Dest,0);
            DefinesPreTranslator("idlocation", OA);
            SetExternalCode("paridlocation", "idlocation");

            return true;
        }
    }

    
}
