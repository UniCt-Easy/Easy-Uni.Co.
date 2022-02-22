
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


using Creport.Report.Rdl;

namespace Creport {
    public class ElementCell {
        //    public static ReportItem Create(string dataSetName) {
        //         return new Tablix(CreateTablixColumnHierarchy(), CreateTablixRowHierarchy(), CreateTablixBody(), dataSetName) {
        //            Top = new Inch(0.025),
        //            Left = new Inch(0.025),
        //            Style =  TablixStyle.CreateTablixStyle(RdlColor.Black.ToString(), BorderStyle.Dashed.ToString(), 2, System.Drawing.Color.AliceBlue.Name)
        //        };
        //    }

        //    private static TablixColumnHierarchy CreateTablixColumnHierarchy() {
        //        return new TablixColumnHierarchy(new TablixMembers(new TablixMember()));
        //    }

        //    private static TablixRowHierarchy CreateTablixRowHierarchy() {
        //        var tablixRowMembers = new TablixMembers();
        //        tablixRowMembers.Add(new TablixMember());
        //        tablixRowMembers.Add(new TablixMember());
        //        return new TablixRowHierarchy(tablixRowMembers);
        //    }

        //    private static TablixBody CreateTablixBody() {
        //        var tablixRows = new TablixRows();
        //        tablixRows.Add(TablixRow.CreateTablixRow(ElementProperty.Tipo, false,System.Drawing.FontFamily.GenericSerif.Name, 10,FontWeight.Bold, RdlColor.DarkBlue.ToString(), Format.Default,TextAlign.Center,0.4));
        //        tablixRows.Add(TablixRow.CreateTablixRow(ElementProperty.Name,true,null,9, FontWeight.Default, RdlColor.Black.ToString(), "n", TextAlign.Center));
        //        var tablixColumns = new TablixColumns(new TablixColumn(new Width(new Inch(1))));
        //        return new TablixBody(tablixColumns, tablixRows);
        //    }
    }
}
