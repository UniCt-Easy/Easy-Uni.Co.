
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;

namespace meta_mainivapayincomeview
{
    public class Meta_mainivapayincomeview : Meta_easydata{
        public Meta_mainivapayincomeview(DataAccess Conn, MetaDataDispatcher Dispatcher):
                    base(Conn, Dispatcher, "mainivapayincomeview"){
            ListingTypes.Add("liquidazioneiva");
        }

        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);

            if (ListingType == "liquidazioneiva"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");

                DescribeAColumn(T, "phase", "Fase");
                DescribeAColumn(T, "ymov", "Esercizio");
                DescribeAColumn(T, "nmov", "Numero");
                DescribeAColumn(T, "registry", "Fornitore");
                DescribeAColumn(T, "codefin", "Cod. Bilancio");
                DescribeAColumn(T, "finance", "Bilancio");
                DescribeAColumn(T, "upb", "U.P.B.");
                DescribeAColumn(T, "description", "Descrizione");
                DescribeAColumn(T, "amount", "Importo");
            }
        }

    }
}



