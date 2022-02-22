
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;


namespace meta_upbepaccyearview
{
    /// <summary>
    /// Summary description for Meta_upbepaccyearview.
    /// </summary>
    public class Meta_upbepaccyearview : Meta_easydata
    {
        public Meta_upbepaccyearview(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "upbepaccyearview")
        {
            ListingTypes.Add("epexp");
        }
        public override string GetNoRowFoundMessage(string listingtype) {
            return "Non è stato trovato alcun UPB  con disponibilità sufficiente.";
        }

        public override string GetStaticFilter(string ListingType) {
            if (ListingType == "epacc") {
                return QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            }
            else {
                return base.GetStaticFilter(ListingType);
            }
        }
        private string[] mykey = new string[] { "idupb","ayear" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "epacc")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codeupb", "Codice", nPos++);
                DescribeAColumn(T, "upb", "Denominazione", nPos++);
                DescribeAColumn(T, "manager", "Responsabile", nPos++);
                DescribeAColumn(T, "codedivision", "Cod.Sezione", nPos++);
                DescribeAColumn(T, "division", "Sezione", nPos++);
                DescribeAColumn(T, "requested", "Finanziamento richiesto", nPos++);
                DescribeAColumn(T, "granted", "Finanziamento accordato", nPos++);
                DescribeAColumn(T, "assured", "Finanziamento certo", nPos++);
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "active", "U.P.B. Attivo", nPos++);
                DescribeAColumn(T, "cupcode", "Codice Unico di Progetto", nPos++);


                int esercizio = CfgFn.GetNoNullInt32(GetSys("esercizio"));
                
                DescribeAColumn(T, "currentprev", "Previsione Es. " + esercizio.ToString(), nPos++);
                DescribeAColumn(T, "previsionvariation", "Var. Prev Es. " + esercizio.ToString(), nPos++);
                DescribeAColumn(T, "appropriation", "Impegnato Es. " + esercizio.ToString(), nPos++);
                DescribeAColumn(T, "available", "Disponibile Es. " + esercizio.ToString(), nPos++);

                DescribeAColumn(T, "currentprev2", "Previsione Es. " + (esercizio + 1).ToString(), nPos++);
                DescribeAColumn(T, "previsionvariation2", "Var. Prev Es. " + (esercizio + 1).ToString(), nPos++);
                DescribeAColumn(T, "appropriation2", "Impegnato Es. " + (esercizio + 1).ToString(), nPos++);
                DescribeAColumn(T, "available2", "Disponibile Es. " + (esercizio + 1).ToString(), nPos++);

                DescribeAColumn(T, "currentprev3","Previsione Es. "+ (esercizio + 2).ToString(), nPos++);
                DescribeAColumn(T, "previsionvariation3", "Var. Prev Es. " + (esercizio + 2).ToString(), nPos++);
                DescribeAColumn(T, "appropriation3", "Impegnato Es. " + (esercizio + 2).ToString(), nPos++);
                DescribeAColumn(T, "available3", "Disponibile Es. " + (esercizio + 2).ToString(), nPos++);

                DescribeAColumn(T, "currentprev4", "Previsione Es. " + (esercizio + 3).ToString(), nPos++);
                DescribeAColumn(T, "previsionvariation4", "Var. Prev Es. " + (esercizio + 3).ToString(), nPos++);
                DescribeAColumn(T, "appropriation4", "Impegnato Es. " + (esercizio + 3).ToString(), nPos++);
                DescribeAColumn(T, "available4", "Disponibile Es. " + (esercizio + 3).ToString(), nPos++);

                DescribeAColumn(T, "currentprev5", "Previsione Es. " + (esercizio + 4).ToString(), nPos++);
                DescribeAColumn(T, "previsionvariation5", "Var. Prev Es. " + (esercizio + 4).ToString(), nPos++);
                DescribeAColumn(T, "appropriation5", "Impegnato Es. " + (esercizio + 4).ToString(), nPos++);
                DescribeAColumn(T, "available5", "Disponibile Es. " + (esercizio + 4).ToString(), nPos++);

                
                DescribeAColumn(T, "activity", "Tipo Attività", nPos++);
               	DescribeAColumn(T, "kindd", "Didattica", nPos++);
                DescribeAColumn(T, "kindr", "Ricerca", nPos++);
                DescribeAColumn(T, "treasurer", "Cassiere", nPos++);
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "stop", "Data fine", nPos++);
                DescribeAColumn(T, "cigcode", "CIG", nPos++);
            }
        }

    }
}
