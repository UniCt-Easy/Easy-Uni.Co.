
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


namespace meta_taxratecitystart
{
    public class Meta_taxratecitystart : Meta_easydata
    {
        public Meta_taxratecitystart(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "taxratecitystart")
        {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName)
        {

            if (FormName == "default")
            {
                DefaultListType = "default";
                Name = "Struttura Imposta Comunale";
                return MetaData.GetFormByDllName("taxratecitystart_default");
            }
            return null;
        }
        public override void DescribeColumns(DataTable T, string ListingType)
        {
            if (ListingType == "default")
            {
                base.DescribeColumns(T, ListingType);
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                int nPos = 1;
                DescribeAColumn(T, "taxcode", "Cod. Imposta",nPos++);
                DescribeAColumn(T, "start", "Data decorrenza",nPos++);
                DescribeAColumn(T, "enforcement", "Tipo applicazione", nPos++);
            }
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
        {
            RowChange.SetSelector(T, "taxcode");
            RowChange.SetSelector(T, "idcity");
            RowChange.MarkAsAutoincrement(T.Columns["idtaxratecitystart"], null,
                null, 7);
            return base.Get_New_Row(ParentRow, T);
        }

       public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge)
        {
            if (ListingType == "default")
            return base.SelectOne(ListingType, filter, "taxratecitystartview", ToMerge);
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }
    }
}
