
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


//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace meta_serviceregistrykind {
//    class meta_serviceregistrykind {
//    }
//}


using System;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using System.Text.RegularExpressions;

namespace meta_serviceregistrykind {
    /// <summary>
    /// Summary description for meta_serviceregistrykind.
    /// </summary>
    public class Meta_serviceregistrykind : Meta_easydata {
        public Meta_serviceregistrykind(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "serviceregistrykind") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            ListingTypes.Add("lista");
            Name = "Tipologia Incarico";
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Tipologia Incarico";
                return GetFormByDllName("serviceregistrykind_default");

            }
            return null;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idserviceregistrykind"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idserviceregistrykind");
            if (N < 9999000)
                R["idserviceregistrykind"] = 9999001;
            else
                R["idserviceregistrykind"] = N + 1;

            return R;
        }
        /*
         * Struttura conferente(conferringstructure)
         * Link al decreto di conferimento dell’incarico(ordinancelink)
         * Struttura che autorizza(authorizingstructure)
         * Link all’atto di autorizzazione(authorizinglink)
         * Riferimento dell’atto di conferimento(actreference)
         * Link al bando(announcementlink)
         * Curriculum Vitae(flagcvattachment)
         * Altri incarichi o cariche in enti di diritto privato finanziati da P.A.( otherservice)
         * Eventuali attività professionali(professionalservice)
         * Componenti variabili del compenso(componentsvariable)
         * */
        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "totransmit", "S");
            SetDefault(T, "topublish", "S");
            SetDefault(T, "active", "S");
            SetDefault(T, "flagconferringstructure", 3); // bit 0 =1, bit1= 2 => 1+2=3
            SetDefault(T, "flagordinancelink", 3);
            SetDefault(T, "flagauthorizingstructure", 3);
            SetDefault(T, "flagauthorizinglink", 3);
            SetDefault(T, "flagactreference", 3);
            SetDefault(T, "flagannouncementlink", 3);
            SetDefault(T, "flagcvattachment", 3);
            SetDefault(T, "flagotherservice", 3);
            SetDefault(T, "flagprofessionalservice", 3);
            SetDefault(T, "flagcomponentsvariable", 3);
            SetDefault(T, "flagemploytime", 3);
            SetDefault(T, "flagcertinterestconflicts", 3);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "title", "Denominazione", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
                DescribeAColumn(T, "totransmit", "Abilita trasmissione", nPos++);
                DescribeAColumn(T, "topublish", "Abilita pubblicazione", nPos++);
            }
            //if (ListingType == "lista") {
            //    foreach (DataColumn C in T.Columns) {
            //        DescribeAColumn(T, C.ColumnName, "", -1);
            //    }
            //    int nPos = 1;
            //    DescribeAColumn(T, "description", "Contratto Passivo", nPos++);
            //}

        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
          
            return true;
        }
    }
}
