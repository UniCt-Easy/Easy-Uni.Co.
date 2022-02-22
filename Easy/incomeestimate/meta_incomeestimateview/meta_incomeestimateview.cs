
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
	using System.Windows.Forms;
	using System.Data;
	using metadatalibrary;
	using metaeasylibrary;

	namespace meta_incomeestimateview{
		/// <summary>
		/// Summary description for ivamoventrataview.
		/// </summary>
		public class Meta_incomeestimateview : Meta_easydata {
			public Meta_incomeestimateview(DataAccess Conn, 
				MetaDataDispatcher Dispatcher):
				base(Conn,Dispatcher, "incomeestimateview") {
			}

			public override string GetStaticFilter(string ListingType) {
				string filteresercizio;
				if (ListingType=="default") {
					filteresercizio = "(ayear='"+GetSys("esercizio").ToString()+"')";
					return filteresercizio;
				}
				return base.GetStaticFilter (ListingType);
			}
        private string[] mykey = new string[] { "idestimkind", "yestim", "nestim","idinc","ayear" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype) {
				base.DescribeColumns(T, listtype);
				if (listtype=="default") {
					foreach (DataColumn C in T.Columns)
						DescribeAColumn(T, C.ColumnName, "",-1);
					DescribeAColumn(T, "idestimkind", "Codice tipo contr.",1);
					DescribeAColumn(T, "estimkind", "Tipo Contratto",2);
					DescribeAColumn(T, "yestim", "Esercizio",3);
					DescribeAColumn(T, "nestim", "Numero",4);
					DescribeAColumn(T, "movkind", "Tipo Movimento",5);
					DescribeAColumn(T, "phase", "Fase",6);
					DescribeAColumn(T, "ymov", "Eserc.Mov.",7);
					DescribeAColumn(T, "nmov", "Num.Mov.",8);
					DescribeAColumn(T, "codefin", "Voce Bil.",9);
					DescribeAColumn(T, "finance", "Denom.Bil.",10);
					DescribeAColumn(T, "registry", "Percipiente",11);
					DescribeAColumn(T, "codeupb", "Cod. UPB",12);
					DescribeAColumn(T, "upb", "Denom. UPB",13);
					DescribeAColumn(T, "manager", "Responsabile",14);
					DescribeAColumn(T, "ypro", "Eserc.Rev.",15);
					DescribeAColumn(T, "npro", "Num.Rev.",16);
					DescribeAColumn(T, "doc", "Documento",17);
					DescribeAColumn(T, "docdate", "Data Doc.",18);
					DescribeAColumn(T, "description", "Descrizione",19);
					DescribeAColumn(T, "amount", "Imp.Originale",20);
					DescribeAColumn(T, "ayearstartamount", "Imp.Esercizio",21);
					DescribeAColumn(T, "curramount", "Imp.Corrente",22);
					DescribeAColumn(T, "available", "Disponibile",23);
					DescribeAColumn(T, "adate", "Data Contabile",24);
				}
			
			}   
	



		}

	} 

