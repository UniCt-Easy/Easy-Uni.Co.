
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
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_creditproceedsview {
    class Meta_creditproceedsview: Meta_easydata {
        public Meta_creditproceedsview(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "creditproceedsview") {		
			Name= "Crediti e cassa assegnati ";
			ListingTypes.Add("lista");
		}
        private string[] mykey = new string[] { "ayear", "idinc", "idupb", "idfin" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="lista") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");

				DescribeAColumn(T, "phase", "Fase");
				DescribeAColumn(T, "ymov", "Eserc. mov.");
				DescribeAColumn(T, "nmov", "Num. mov.");
				DescribeAColumn(T, "codefin", "Bil. Spesa");
				DescribeAColumn(T, "finance", "Denom. bil");
                DescribeAColumn(T, "codeupb", "Cod. UPB");
                DescribeAColumn(T, "upb", "UPB");
                DescribeAColumn(T, "credit", "Crediti assegnati");
                DescribeAColumn(T, "proceeds", "Cassa assegnata");
			}
		}
    }
}
