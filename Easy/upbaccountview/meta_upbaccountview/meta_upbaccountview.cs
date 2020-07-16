/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;

namespace meta_upbaccountview  {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_upbaccountview  : Meta_easydata {
        public Meta_upbaccountview (DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "upbaccountview") {
            Name = "UPB / Conto";
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "UPB/Conto";
                this.CanCancel = false;
                this.CanInsert = false;
                this.CanInsertCopy = false;
                this.CanSave = false;
                return MetaData.GetFormByDllName("upbaccountview_default");
            }
            return null;
        }

        private string[] mykey = new string[] { "idupb","idacc" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                int esercizioCurr = (int)GetSys("esercizio");
                /*
                 *    <xs:element name="epexp1" msdata:ReadOnly="true" type="xs:decimal" minOccurs="0" />
                      <xs:element name="epexp1_2" msdata:ReadOnly="true" type="xs:decimal" minOccurs="0" />
                      <xs:element name="epexp1_3" msdata:ReadOnly="true" type="xs:decimal" minOccurs="0" />
                      <xs:element name="epexp1_4" msdata:ReadOnly="true" type="xs:decimal" minOccurs="0" />
                      <xs:element name="epexp1_5" msdata:ReadOnly="true" type="xs:decimal" minOccurs="0" />
                      <xs:element name="epexp2" msdata:ReadOnly="true" type="xs:decimal" minOccurs="0" />
                      <xs:element name="epexp2_2" msdata:ReadOnly="true" type="xs:decimal" minOccurs="0" />
                      <xs:element name="epexp2_3" msdata:ReadOnly="true" type="xs:decimal" minOccurs="0" />
                      <xs:element name="epexp2_4" msdata:ReadOnly="true" type="xs:decimal" minOccurs="0" />
                      <xs:element name="epexp2_5" msdata:ReadOnly="true" type="xs:decimal" minOccurs="0" />
                 * */
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "codeacc", "Codice Conto", nPos++);
                DescribeAColumn(T, "account", "Conto", nPos++);
                DescribeAColumn(T, "codeupb", "Codice UPB", nPos++);
                DescribeAColumn(T, "upb", "UPB", nPos++);
                DescribeAColumn(T, "currentprev", "Prev.Corrente " + (esercizioCurr).ToString(), nPos++);
                DescribeAColumn(T, "epexp1", "Preimpegno di budget " + (esercizioCurr).ToString(), nPos++);
                DescribeAColumn(T, "available", "Disponibile ad impegnare " + (esercizioCurr).ToString(), nPos++);
                DescribeAColumn(T, "epexp2", "Impegno di budget " + (esercizioCurr).ToString(), nPos++);
                DescribeAColumn(T, "currentprev2", "Prev.Corrente " + (++esercizioCurr).ToString(), nPos++);
                DescribeAColumn(T, "epexp1_2", "Preimpegno di budget " + (esercizioCurr).ToString(), nPos++);
                DescribeAColumn(T, "epexp2_2", "Impegno di budget " + (esercizioCurr).ToString(), nPos++);
                DescribeAColumn(T, "currentprev3", "Prev.Corrente " + (++esercizioCurr).ToString(), nPos++);
                DescribeAColumn(T, "epexp1_3", "Preimpegno di budget " + (esercizioCurr).ToString(), nPos++);
                DescribeAColumn(T, "epexp2_3", "Impegno di budget " + (esercizioCurr).ToString(), nPos++);
                DescribeAColumn(T, "currentprev4", "Prev.Corrente " + (++esercizioCurr).ToString(), nPos++);
                DescribeAColumn(T, "epexp1_4", "Preimpegno di budget " + (esercizioCurr).ToString(), nPos++);
                DescribeAColumn(T, "epexp2_4", "Impegno di budget " + (esercizioCurr).ToString(), nPos++);
                DescribeAColumn(T, "currentprev5", "Prev.Corrente " + (++esercizioCurr).ToString(), nPos++);
                DescribeAColumn(T, "epexp1_5", "Preimpegno di budget " + (esercizioCurr).ToString(), nPos++);
                DescribeAColumn(T, "epexp2_5", "Impegno di budget " + (esercizioCurr).ToString(), nPos++);

                DescribeAColumn(T, "dare", "Tot.Dare", nPos++);
                DescribeAColumn(T, "avere", "Tot.Avere", nPos++);
                DescribeAColumn(T, "activity", "Attività", nPos++);
                DescribeAColumn(T, "kinddidattica", "Didattica", nPos++);
                DescribeAColumn(T, "kindricerca", "Ricerca", nPos++);
                DescribeAColumn(T, "contabilitaspeciale", "Contab.Speciale", nPos++);
                DescribeAColumn(T, "cigcode", "CIG", nPos++);
                DescribeAColumn(T, "cupcode", "CUP", nPos++);
                DescribeAColumn(T, "manager", "Responsabile", nPos++);
                DescribeAColumn(T, "epupbkind", "Tipo UPB", nPos++);
                DescribeAColumn(T, "isresource", "Risorsa", nPos++);
                DescribeAColumn(T, "flagprofit", "Utile", nPos++);
                DescribeAColumn(T, "flagloss", "Perdita", nPos++);
                DescribeAColumn(T, "rateiattivi", "Ratei Attivi", nPos++);
                DescribeAColumn(T, "rateipassivi", "Ratei Passivi", nPos++);
                DescribeAColumn(T, "riscontiattivi", "Risconti Attivi", nPos++);
                DescribeAColumn(T, "riscontipassivi", "Risconti Passivi", nPos++);
                DescribeAColumn(T, "credit", "Conto di Credito", nPos++);
                DescribeAColumn(T, "debit", "Conto di Debito", nPos++);
                DescribeAColumn(T, "cost", "Costi", nPos++);
                DescribeAColumn(T, "revenue", "Ricavi", nPos++);
                DescribeAColumn(T, "fixedassets", "Immobilizzazioni", nPos++);
                DescribeAColumn(T, "freeusesurplus", "Avanzo libero", nPos++);
                DescribeAColumn(T, "captiveusesurplus", "Avanzo Vincolato", nPos++);
                DescribeAColumn(T, "reserve", "Riserva", nPos++);
                DescribeAColumn(T, "provision", "Fondo Accantonamento", nPos++);
                DescribeAColumn(T, "flagenablebudgetprev", "Abilita Prev.Budget", nPos++);
                DescribeAColumn(T, "flagcompetency", "Competenza", nPos++);
                DescribeAColumn(T, "contoordine", "Conto Ordine", nPos++);
                DescribeAColumn(T, "sortcode_investimenti", "Cod. Budget Investimenti", nPos++);
                DescribeAColumn(T, "sortcode_economico", "Cod. Budget Economico", nPos++);
            }


        }
    }
}


