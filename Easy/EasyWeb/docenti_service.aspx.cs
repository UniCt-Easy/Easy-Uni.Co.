/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

namespace EasyWebReport {

    public partial class docenti_service : BaseProcedurePage {

        protected override string Schema => "amministrazione";
        protected override string ProcName => "rpt_web_docenti";
        protected override string[] ProcParamNames => new string[] { "aa" };
        protected override bool UseParametersForm => false;
        protected override string OutputContainerID => "data";

        protected void Page_Load(object sender, EventArgs e) {

            RenderOutput();
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {

            RenderOutput();
        }
    }
}
