
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
using metadatalibrary;
using metaeasylibrary;


namespace meta_sisest_causaleview {
    /// <summary>
    /// Summary description for contattoview.
    /// </summary>
    public class Meta_sisest_causaleview :Meta_easydata {
        public Meta_sisest_causaleview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
        base(Conn, Dispatcher, "sisest_causaleview") {
            ListingTypes.Add("default");

        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "codicecausale", "Cod.Causale", nPos++);
                DescribeAColumn(T, "descrizione", "Descrizione", nPos++);
                DescribeAColumn(T, "tipocompetenza", "Tipo Competenza", nPos++);
                DescribeAColumn(T, "codefinmotive", "Cod.Causale finanziaria", nPos++);
                DescribeAColumn(T, "finmotive", "Causale finanziaria", nPos++);
                DescribeAColumn(T, "codefinmotive_bollo", "Cod.Causale finanziaria bollo", nPos++);
                DescribeAColumn(T, "finmotive_bollo", "Causale finanziaria bollo", nPos++);
                DescribeAColumn(T, "codefinmotive_regionale", "Cod.Causale finanziaria regionale", nPos++);
                DescribeAColumn(T, "finmotive_regionale", "Causale finanziaria regionale", nPos++);

                DescribeAColumn(T, "codemotive", "Cod.Causale EP", nPos++);
                DescribeAColumn(T, "accmotive", "Causale EP", nPos++);
                DescribeAColumn(T, "codeaccmotive_credit", "Cod.Causale credito", nPos++);
                DescribeAColumn(T, "accmotive_credit", "Causale credito", nPos++);
                DescribeAColumn(T, "codeaccmotive_bollo", "Cod.Causale bollo", nPos++);
                DescribeAColumn(T, "accmotive_bollo", "Causale bollo", nPos++);
                DescribeAColumn(T, "codeaccmotive_bollo_credit", "Cod.Causale credito bollo", nPos++);
                DescribeAColumn(T, "accmotive_bollo_credit", "Causale credito bollo", nPos++);
                DescribeAColumn(T, "codeaccmotive_regionale", "Cod.Causale regionale", nPos++);
                DescribeAColumn(T, "accmotive_regionale", "Causale regionale", nPos++);
                DescribeAColumn(T, "codeaccmotive_regionale_credit", "Cod.Causale credito regionale", nPos++);
                DescribeAColumn(T, "accmotive_regionale_credit", "Causale credito regionale", nPos++);
                DescribeAColumn(T, "codesor_siope", "Cod.Siope", nPos++);
                DescribeAColumn(T, "siope", "Siope", nPos++);

                DescribeAColumn(T, "codesor_siope_bollo", "Cod.Siope bollo", nPos++);
                DescribeAColumn(T, "siope_bollo", "Siope bollo", nPos++);
                DescribeAColumn(T, "codesor_siope_regionale", "Cod.Siope regionale", nPos++);
                DescribeAColumn(T, "siope_regionale", "Siope regionale", nPos++);
                DescribeAColumn(T, "tiporiga", "Tipo riga", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
                DescribeAColumn(T, "note", "Note", nPos++);


            }
        }
    }
}

