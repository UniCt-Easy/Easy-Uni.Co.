
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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

namespace funzioni_configurazione {
    public class CalcolaRitenute {
        public static DataTable scaglioni(DataAccess conn, object taxCode, DateTime dataDaConsiderare, 
                    decimal imponibileGiaPagato, decimal imponibile) {
            QueryHelper QHS = conn.GetQueryHelper();

            object maxIdTaxRateStart = conn.DO_READ_VALUE("taxratestart",
                QHS.AppAnd(QHS.CmpLe("start", dataDaConsiderare),
                QHS.CmpEq("taxcode", taxCode)), "max(idtaxratestart)");

            if (maxIdTaxRateStart == null || maxIdTaxRateStart == DBNull.Value) {
                maxIdTaxRateStart = conn.DO_READ_VALUE("taxratestart",
                QHS.AppAnd(QHS.CmpEq("taxcode", taxCode)), "min(idtaxratestart)");
            }

            object enforcement = conn.DO_READ_VALUE("taxratestart",
                QHS.AppAnd(QHS.CmpEq("idtaxratestart", maxIdTaxRateStart),
                    QHS.CmpEq("taxcode", taxCode)),"enforcement");
            string query;

            if (enforcement.ToString().ToUpper() == "F") {
                //Fascia fissa : una riga con min = massimo tra min e imponibileGiaPagato
                // di base il minimo va sempre sottratto dall'imponibile da considerare nello scaglione
                query = "SELECT CASE " +
                        " WHEN " + QHS.CmpLe("ISNULL(minamount,0)", imponibileGiaPagato) +
                        " THEN " + QHS.quote(imponibileGiaPagato) +
                        " ELSE minamount " +
                        " END AS minamount, " +
                        " CASE " +
                        " WHEN " + QHS.NullOrGt("maxamount", imponibile) +
                        " THEN " + QHS.quote(imponibile) +
                        " ELSE maxamount " +
                        " END AS maxamount, " +
                        " adminnumerator, admindenominator, adminrate, " +
                        " employnumerator, employdenominator, employrate, nbracket " +
                        " from taxratebracketview where " +
                        QHS.AppAnd(QHS.CmpEq("idtaxratestart", maxIdTaxRateStart),
                            QHS.CmpEq("taxcode", taxCode)) +
                        "and " + QHS.AppAnd(QHS.CmpLe("minamount", imponibileGiaPagato),
                            QHS.NullOrGe("maxamount", imponibileGiaPagato));                       
            }
            else {
                //Applicazione progressiva
                query = "SELECT CASE " +
                        " WHEN " + QHS.CmpLe("ISNULL(minamount,0)", imponibileGiaPagato) +
                        " THEN " + QHS.quote(imponibileGiaPagato) +
                        " ELSE minamount " +
                        " END AS minamount, " +
                        " CASE " +
                        " WHEN " + QHS.NullOrGt("maxamount", imponibile) +
                        " THEN " + QHS.quote(imponibile) +
                        " ELSE maxamount " +
                        " END AS maxamount, " +
                        " adminnumerator, admindenominator, adminrate, " +
                        " employnumerator, employdenominator, employrate, nbracket " +
                        " from taxratebracketview where " +
                        QHS.AppAnd(QHS.CmpEq("idtaxratestart", maxIdTaxRateStart),
                            QHS.CmpEq("taxcode", taxCode)) +
                        "and (" + QHS.DoPar(QHS.AppAnd(QHS.CmpLe("minamount", imponibileGiaPagato),
                            QHS.NullOrGe("maxamount", imponibileGiaPagato))) +
                        " or " + QHS.Between("minamount", imponibileGiaPagato, imponibile) + ")" +
                        " order by nbracket";
            }

            DataTable scaglioniDellaRitenuta = conn.SQLRunner(query);
            return scaglioniDellaRitenuta;
        }
    }
}
