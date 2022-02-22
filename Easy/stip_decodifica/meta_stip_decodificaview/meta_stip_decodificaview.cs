
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

namespace meta_stip_decodificaview {
    public class Meta_stip_decodificaview : Meta_easydata {
        public Meta_stip_decodificaview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "stip_decodificaview") {
            ListingTypes.Add("default");
        }
       
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codicetassa", "Codice Tassa", nPos++);
                DescribeAColumn(T, "tassa", "Tassa", nPos++);
                DescribeAColumn(T, "codicevoce", "Codice Voce", nPos++);
                DescribeAColumn(T, "voce", "Voce", nPos++);
				DescribeAColumn(T, "codicecorsolaurea", "Codice Corso Laurea", nPos++);
				DescribeAColumn(T, "corsolaurea", "Corso Laurea", nPos++);
				DescribeAColumn(T, "voce", "Voce", nPos++);
				DescribeAColumn(T, "codemotiverevenue", "Cod. Causale ricavo", nPos++);
                DescribeAColumn(T, "accmotiverevenue", "Causale Ricavo", nPos++);
                DescribeAColumn(T, "codemotivecredit", "Cod. Causale credito", nPos++);
                DescribeAColumn(T, "accmotivecredit", "Causale Credito", nPos++);
                DescribeAColumn(T, "codefinmotive", "Cod. Causale finanziaria", nPos++);
                DescribeAColumn(T, "finmotive", "Causale finanziaria", nPos++);
                DescribeAColumn(T, "codemotiveundotax", "Cod. Causale Annullo Tasse", nPos++);
                DescribeAColumn(T, "accmotiveundotax", "Causale Annullo Tasse", nPos++);
                DescribeAColumn(T, "codemotiveundotaxpost", "Cod. Causale Annullo Tasse oltre Anno Emissione", nPos++);
                DescribeAColumn(T, "accmotiveundotaxpost", "Causale Annullo Tasse oltre Anno Emissione", nPos++);
                DescribeAColumn(T, "idestimkind", "Codice Tipo Contratto attivo", nPos++);
                DescribeAColumn(T, "estimatekind", "Tipo Contratto attivo", nPos++);
            }
        }

    }
}
 
 
 
 
 
