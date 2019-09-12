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

ï»¿using System;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_flussocrediti {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_flussocrediti :Meta_easydata {
        public Meta_flussocrediti(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "flussocrediti") {
            EditTypes.Add("default");
            EditTypes.Add("visualizza");
            ListingTypes.Add("default");
            }
        protected override Form GetForm(string FormName) {
            switch (FormName) {
            case "default": {
                        DefaultListType = "default";
                        Name = "Contratti Attivi e Fatture Attive da trasmettere";
                        return MetaData.GetFormByDllName("flussocrediti_default");
                    }
                case "visualizza": {
                        DefaultListType = "default";
                        Name = "Crediti";
                        return MetaData.GetFormByDllName("flussocrediti_default");
                    }

            }
            return null;
            }

        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "default") {
                sorting = "idflusso desc";
                return sorting;
                }
            return base.GetSorting(ListingType);
            }
        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "istransmitted", "N");
            SetDefault(PrimaryTable, "datacreazioneflusso", Conn.GetDataContabile());
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idflusso"], null, null,0);
            RowChange.setMinimumTempValue(T.Columns["idflusso"], 99990000);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
            }


        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
            }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "idflusso", "Num.Flusso");
                DescribeAColumn(T, "istransmitted", "Trasmesso");
                DescribeAColumn(T, "filename", "Nome File");
                DescribeAColumn(T, "datacreazioneflusso", "Data creazione flusso");
                DescribeAColumn(T, "progday", "Progressivo invio giornaliero");
                }
            }
        }
    }