/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;//funzioni_configurazione
using q = metadatalibrary.MetaExpression;

namespace meta_registryaddress //meta_cdindirizzo//
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_registryaddress : Meta_easydata {
        public Meta_registryaddress(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "registryaddress") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
			EditTypes.Add("anagraficasingle");
            ListingTypes.Add("anagraficasingle");
            ListingTypes.Add("unione");
            Name = "Indirizzo";
			EditTypes.Add("anagrafica");
			ListingTypes.Add("anagrafica");
			EditTypes.Add("seg");
			ListingTypes.Add("seg");
			EditTypes.Add("user");
			ListingTypes.Add("user");
			//$EditTypes$
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                return MetaData.GetFormByDllName("registryaddress_default");
            }

            if (FormName == "anagraficasingle") {
                DefaultListType = "anagraficasingle";
                return MetaData.GetFormByDllName("registryaddress_anagraficasingle");
            }

            return null;
        }


        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "registryaddressview", ToMerge);
            }

            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }


        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "active", "S");
            SetDefault(T, "flagforeign", "N");
            SetDefault(T, "start", new DateTime(CfgFn.GetNoNullInt32(GetSys("esercizio")), 1, 1));
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);


            foreach (DataColumn C in T.Columns) {
                DescribeAColumn(T, C.ColumnName, "", -1);
            }

            int nPos = 1;

			switch (ListingType) {
				case "default": {
						DescribeAColumn(T, "stop", "data fine", nPos++);
						DescribeAColumn(T, "recipientagency", "Ente di provenienza (per anagrafe prestazioni)", nPos++);
						DescribeAColumn(T, "officename", "Nome ufficio", nPos++);
						DescribeAColumn(T, "active", "attivo", nPos++);
						DescribeAColumn(T, "address", "n. operazione", nPos++);
						DescribeAColumn(T, "flagforeign", "Estero", nPos++);
						DescribeAColumn(T, "!idcity_geo_city_title", "Comune", nPos++);
						DescribeAColumn(T, "location", "ubicazione", nPos++);
						DescribeAColumn(T, "cap", "Codice avv. postale", nPos++);
						DescribeAColumn(T, "!idnation_geo_nation_title", "Nazione", nPos++);
						DescribeAColumn(T, "annotations", "Annotazioni", nPos++);
						break;
					}
				case "anagrafica": {
						DescribeAColumn(T, "address", "Indirizzo", nPos++);
						DescribeAColumn(T, "!idcity_geo_city_title", "Comune", nPos++);
						DescribeAColumn(T, "location", "Località", nPos++);
						DescribeAColumn(T, "cap", "CAP", nPos++);
						break;
					}
				case "seg": {
						DescribeAColumn(T, "!idaddresskind_address_description", "Tipologia", nPos++);
						DescribeAColumn(T, "start", "Data inizio", nPos++);
						DescribeAColumn(T, "stop", "Data fine", nPos++);
						DescribeAColumn(T, "active", "Attivo", nPos++);
						DescribeAColumn(T, "address", "Indirizzo", nPos++);
						DescribeAColumn(T, "flagforeign", "Estero", nPos++);
						DescribeAColumn(T, "!idcity_geo_city_title", "Comune", nPos++);
						DescribeAColumn(T, "location", "Località", nPos++);
						DescribeAColumn(T, "cap", "CAP", nPos++);
						DescribeAColumn(T, "!idnation_geo_nation_title", "Nazione", nPos++);
						DescribeAColumn(T, "annotations", "Annotazioni", nPos++);
						break;
					}
				case "user": {
						DescribeAColumn(T, "address", "Indirizzo", nPos++);
						DescribeAColumn(T, "!idcity_geo_city_title", "Comune", nPos++);
						DescribeAColumn(T, "location", "Località", nPos++);
						DescribeAColumn(T, "cap", "CAP", nPos++);
						break;
					}
					//$DescribeAColumn$
			}

			if (ListingType == "anagraficasingle") {

                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "stop", "Data fine", nPos++);
                DescribeAColumn(T, "!descrtipoindirizzo", "Tipo", "address.description", nPos++);
                DescribeAColumn(T, "officename", "Nome ufficio", nPos++);
                DescribeAColumn(T, "address", "Indirizzo", nPos++);
                DescribeAColumn(T, "cap", "CAP", nPos++);
                //in questo campo memorizzo il valore di geo_comune.denominazione
                DescribeAColumn(T, "!comune", "", "geo_city.title", nPos++);
                //mentre il campoi !localita viene utilizzato a video tra comune nazionale/estero
                DescribeAColumn(T, "!localita", "Località", nPos++);
                DescribeAColumn(T, "!nazione", "Stato estero", "geo_nation.title", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
                ComputeRowsAs(T, ListingType);
            }

            if (ListingType == "unione") {

                DescribeAColumn(T, "!kk", ".aaaa", nPos++);
                DescribeAColumn(T, "idreg", "#", nPos++);
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "stop", "Data fine", nPos++);
                DescribeAColumn(T, "!descrtipoindirizzo", "Tipo", "address.description", nPos++);
                DescribeAColumn(T, "officename", "Nome ufficio", nPos++);
                DescribeAColumn(T, "address", "Indirizzo", nPos++);
                DescribeAColumn(T, "cap", "CAP", nPos++);
                //in questo campo memorizzo il valore di geo_comune.denominazione
                DescribeAColumn(T, "!comune", "Comune", "geo_city.title", nPos++);
                //mentre il campoi !localita viene utilizzato a video tra comune nazionale/estero
                DescribeAColumn(T, "!nazione", "Stato estero", "geo_nation.title", nPos++);
                DescribeAColumn(T, "location", "Località", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
                DescribeAColumn(T, "lt", "Data ultima mod.", nPos++);
            }



        }

        public override void CalculateFields(DataRow R, string list_type) {
            if (list_type == "anagraficasingle") {
                if (R["flagforeign"].ToString() != "S")
                    R["!localita"] = R["!comune"];
                else
                    R["!localita"] = R["location"];
            }
        }

        private bool controllaData(DateTime data, out string errmess) {
            if (data < new DateTime(1900, 1, 1)) {
                errmess = "Non è possibile immettere una data precedente all'1/1/1900";
                return false;
            }

            if (data > new DateTime(2079, 6, 6)) {
                errmess = "Non è possibile immettere una data successiva al 6/6/2079";
                return false;
            }

            errmess = null;
            return true;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;


            DateTime datainizio = (DateTime) R["start"];
            if (!controllaData(datainizio, out errmess)) {
                errfield = "start";
                return false;
            }

            object df = R["stop"];
            if (df != DBNull.Value) {
                DateTime datafine = (DateTime) df;
                if (!controllaData(datafine, out errmess)) {
                    errfield = "stop";
                    return false;
                }

                if ((datafine != QueryCreator.EmptyDate()) && (datafine < datainizio)) {
                    errmess = "'Data fine validità' non può precedere 'Data inizio validità'";
                    errfield = "stop";
                    return false;
                }
            }

            int codicecreddeb = CfgFn.GetNoNullInt32(R["idreg"]);
            if (codicecreddeb <= 0) {
                errmess = "Inserire il codice dell'anagrafica";
                errfield = "idreg";
                return false;
            }

            if ((R["address"].ToString() == "") || (R["address"].ToString().Trim() == ".")) {
                errmess = "Attenzione! Inserire l'indirizzo.";
                errfield = "address";
                return false;
            }

            object codeAddressKind =
                Conn.DO_READ_VALUE("address", QHS.CmpEq("idaddress", R["idaddresskind"]), "codeaddress");
            if (codeAddressKind != null) {
                if ((codeAddressKind.ToString() == "07_SW_DOM") && (R["idcity"] is DBNull)) {
                    errmess = "Il domicilio fiscale non può essere estero! Inserire un comune italiano.";
                    errfield = "idcity";
                    return false;
                }
            }

            if (codeAddressKind != null) {
                if ((codeAddressKind.ToString() != "07_SW_ANP") && (R["recipientagency"] != DBNull.Value)) {
                    errmess = "L'Ente di provenienza deve essere specificato solo per l'indirizzo di tipo " +
                              "Anagrafe delle Prestazioni";
                    errfield = "recipientagency";
                    return false;
                }
            }

            //indirizzo estero o nazionale
            if (R["flagforeign"].ToString().ToUpper() == "S") {
                if (R["idnation"].ToString() == "") {
                    errmess = "Attenzione! Inserire lo stato estero.";
                    errfield = "idnation";
                    return false;
                }
                if (R["location"].ToString() == "") {
	                errmess = "Attenzione! Inserire il comune estero.";
	                errfield = "location";
	                return false;
                }
            }
            else {
                if (R["idcity"].ToString() == "") {
                    errmess = "Attenzione! Inserire il Comune.";
                    errfield = "idcity";
                    return false;
                }

                if (Conn.RUN_SELECT_COUNT("geo_city_agency",
                        QHS.AppAnd(QHS.CmpEq("idagency", 3), QHS.CmpEq("idcity", R["idcity"]), QHS.IsNull("stop")),
                        false) > 0) {
                    object cap = R["cap"];
                    string query = "select value from geo_city_agency where " +
                                   QHS.AppAnd(QHS.CmpEq("idagency", 3), QHS.CmpEq("idcity", R["idcity"]),
                                       QHS.IsNull("stop"));
                    DataTable t = Conn.SQLRunner(query);
                    DataRow[] r1 = t.Select("value=" + QueryCreator.quotedstrvalue(cap, false));
                    if (r1.Length == 0) {

                        //DialogResult dr = MessageBox. Show(LinkedForm, "Il C.A.P. non è coerente o non è più valido per il comune inserito. Salvare ugualmente?", "Avviso", MessageBoxButtons.YesNo);
                        //if (dr==DialogResult.No) 
                        //{
                        object comune = Conn.readValue("geo_city", q.eq("idcity", R["idcity"]), "title") ?? "(Comune non trovato)";
                        //R.GetParentRow("geo_cityregistryaddress")["title"];
                        if (t.Rows.Count == 1) {
                            errmess = $"Il codice postale del comune di '{comune}' è '{t.Rows[0]["value"].ToString()}'";
                        }
                        else {
                            errmess = $"Il comune di '{comune}' ha i seguenti codici postali:\n{QueryCreator.ColumnValues(t, null, "value", false)}";
                        }

                        errfield = "cap";
                        return false;
                        //}
                    }
                }
            }

            return true;
        }
    }
}
