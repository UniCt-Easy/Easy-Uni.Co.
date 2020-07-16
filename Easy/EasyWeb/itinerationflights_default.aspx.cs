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
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HelpWeb;
using metadatalibrary;
using metaeasylibrary;
using AllDataSet;
using funzioni_configurazione;

public partial class itinerationflights_default :MetaPage {
    vistaForm_itinerationflights DS;

    public override DataSet GetDataSet() {
        return DS;
    }

    public override DataSet CreateNewDataSet() {
        return new vistaForm_itinerationflights();
    }

    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_itinerationflights)D;
    }

    protected override void OnInit(EventArgs e) {
        IsTree = false;
        IsList = false;

        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e) {

    }

    public override void AfterLink(bool firsttime, bool formToLink) {
        Meta.Name = "Tratte";
    }


}
