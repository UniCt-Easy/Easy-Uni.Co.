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

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// struct cartitem
/// viene utilizzata per memorizzare gli items nel carrello.
/// ogni cartitem ha tre attributi: idlist, idstore e quantity
/// dove:
/// idlist � l'articolo del listino
/// idstore � l'id del magazzino
/// quantity � la quantit� dell'articolo
/// </summary>
namespace EasyWebReport
{
    public struct cartitem
    {
        public int idlist;
        public int idstore;
        public int quantity;
        public decimal price;
        public int idstock;
    }
}