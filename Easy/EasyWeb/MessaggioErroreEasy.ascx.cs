
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using metadatalibrary;
using metaeasylibrary;

public partial class MessaggioErroreEasy : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ProcedureMessageCollection myProcedureCollection = Session["myProcedureMessageCollection"] as ProcedureMessageCollection;

        if (myProcedureCollection == null) return;

        foreach (EasyProcedureMessage myProcedureMessage in myProcedureCollection)
        {
            if (myProcedureMessage.LongMess == "") continue;
            AddTableRow("Message: ", myProcedureMessage.LongMess.Replace(",",", "), 70);

            if (!myProcedureMessage.CanIgnore)
            {
                btnIgnora.Visible = false;
                //btnOK.Visible = false;
            }
            AddTableRow("CanIgnore: ", myProcedureMessage.CanIgnore.ToString(), 20);

            AddTableRow("AuditID: ", myProcedureMessage.AuditID, 20);

            //AddTableRow("EnforcementNumber ", myProcedureMessage.EnforcementNumber, 20);

            //AddTableRow("ErrorType: ", myProcedureMessage.ErrorType, 20);

            //AddTableRow("TableName: ", myProcedureMessage.TableName, 20);

            //AddTableRow("ShortMess: ", myProcedureMessage.ShortMess, 20);

            //AddTableRow("Operation: ", myProcedureMessage.Operation, 20);

            //AddTableRow("Enable: ", myProcedureMessage.Enabled.ToString(), 20);
        }
    }

    private void AddTableRow(string Testo1, string Testo2, int Altezza)
    {
        //Nuova Riga
        TableRow TR1 = new TableRow();
        TR1.Height = Altezza;
        Table1.Rows.Add(TR1);
        //Nuova Cella 1
        TableCell TC1 = new TableCell();
        TC1.Text = Testo1;
        TC1.Width = 150;
        TC1.VerticalAlign = VerticalAlign.Top;
        TR1.Cells.Add(TC1);
        //Nuova Cella 2
        TableCell TC2 = new TableCell();
        TC2.Text = Testo2;
        TC2.Width = 600;
        TR1.Cells.Add(TC2);
    }
}
