
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
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HelpWeb;
using AllDataSet;
using metadatalibrary;
using funzioni_configurazione;
using EasyWebReport;

public partial class showcasedetail_single : MetaPage
{
    vistaForm_showcasedetail DS;

    public override DataSet GetDataSet()
    {
        return DS;
    }
    public override DataSet CreateNewDataSet()
    {
        return new vistaForm_showcasedetail();
    }
    public override void SetDataSet(DataSet D)
    {
        DS = (vistaForm_showcasedetail)D;
    }


}
