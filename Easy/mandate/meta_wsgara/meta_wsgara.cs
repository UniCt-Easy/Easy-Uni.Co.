
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_wsgara {
    /// <summary>
    /// 
    /// </summary>
    public class Meta_wsgara : Meta_easydata {
        public Meta_wsgara(DataAccess Conn, MetaDataDispatcher Dispatcher) : base(Conn, Dispatcher, "wsgara") {
            ListingTypes.Add("default");
            Name = "gare";
        }
        private string[] mykey = new string[] { "idGara" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "default") {
                sorting = "idGara asc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }

        public void CompletaCaption(DataTable T) {

            foreach (DataColumn C in T.Columns) {
                if ((C.ColumnName == "idGara") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".#Id Gara");
                    continue;
                }
                if ((C.ColumnName == "idGaraTraspare") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".#Id Gara Traspare");
                    continue;
                }
                if ((C.ColumnName == "titoloGara") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Titolo Gara");
                    continue;
                }
                if ((C.ColumnName == "abstractGara") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Abstract");
                    continue;
                }
                if ((C.ColumnName == "idStrutturaTraspare") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Id Struttura Traspare");
                    continue;
                }
                if ((C.ColumnName == "annoAggiudicazioneGara") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Anno Aggiudicazione");
                    continue;
                }
                if ((C.ColumnName == "esitoGara") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Esito");
                    continue;
                }
                if ((C.ColumnName == "tipoGara") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Tipo");
                    continue;
                }
                if ((C.ColumnName == "rupNome") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Rup Nome");
                    continue;
                }
                if ((C.ColumnName == "rupCognome") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Rup Cognome");
                    continue;
                }
                if ((C.ColumnName == "rupCodiceFiscale") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Rup Codice Fiscale");
                    continue;
                }
                if ((C.ColumnName == "dataPubblicazione") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Data Pubblicazione");
                    continue;
                }
                if ((C.ColumnName == "tipoPubblicazione") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Tipo Pubblicazione");
                    continue;
                }
                if ((C.ColumnName == "motivazioneAffidamento") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Motivazione Affidamento");
                    continue;
                }
                if ((C.ColumnName == "ribasso") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Ribasso");
                    continue;
                }
            }
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idGara", "Id Gara", nPos++);
                DescribeAColumn(T, "idGaraTraspare", "Id Gara Traspare", nPos++);
                DescribeAColumn(T, "titoloGara", "CIG", nPos++);
                DescribeAColumn(T, "abstractGara", "Abstract", nPos++);
                DescribeAColumn(T, "idStrutturaTraspare", "Id Struttura Traspare", nPos++);
                DescribeAColumn(T, "annoAggiudicazioneGara", "Anno Aggiudicazione", nPos++);
                DescribeAColumn(T, "esitoGara", "Esito", nPos++);
                DescribeAColumn(T, "tipoGara", "Tipo", nPos++);
                DescribeAColumn(T, "rupNome", "Rup Nome", nPos++);
                DescribeAColumn(T, "rupCognome", "Rup Cognome", nPos++);
                DescribeAColumn(T, "rupCodiceFiscale", "Rup Codice Fiscale", nPos++);
                DescribeAColumn(T, "dataPubblicazione", "Data Pubblicazione", nPos++);
                DescribeAColumn(T, "tipoPubblicazione", "Tipo Pubblicazione", nPos++);
                DescribeAColumn(T, "motivazioneAffidamento", "Motivazione Affidamento", nPos++);
                DescribeAColumn(T, "ribasso", "Ribasso", nPos++);
            }
        }
    }
}
