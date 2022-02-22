
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


// meta_pettycashopunderwritingview
using System;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_pettycashopunderwritingview
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_pettycashopunderwritingview : Meta_easydata
    {
        public Meta_pettycashopunderwritingview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "pettycashopunderwritingview"){
            ListingTypes.Add("default");
        }


        public override void DescribeColumns(DataTable T, string listtype){
            base.DescribeColumns(T, listtype);
            if (listtype == "default"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "pettycode", "Cod. fondo", nPos++);
                DescribeAColumn(T, "yoperation", "Eserc. op.", nPos++);
                DescribeAColumn(T, "noperation", "Num. op.", nPos++);
                DescribeAColumn(T, "codeunderwriting", "Cod.finanziamento", nPos++);
                DescribeAColumn(T, "underwriting", "Finanziamento", nPos++);
                DescribeAColumn(T, "codefin", "Voce bil.", nPos++);
                DescribeAColumn(T, "finance", "Denom. bil.", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
                DescribeAColumn(T, "upb", "U.P.B.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "idinvkind", ".#Tipo Fattura", nPos++);
                DescribeAColumn(T, "codeinvkind", "Tipo Fattura", nPos++);
                DescribeAColumn(T, "yinv", "Eserc. Fattura", nPos++);
                DescribeAColumn(T, "ninv", "Num. Fattura", nPos++);
                DescribeAColumn(T, "registry", "Cliente/Fornitore", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data doc.", nPos++);
                DescribeAColumn(T, "manager", "Responsabile", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "adate", "Data contabile", nPos++);
                DescribeAColumn(T, "nrestore", "Num.Reintegro", nPos++);
            }
        }
    }
}
