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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

using metadatalibrary;

namespace no_table_reportpowerbi {
	public partial class Frm_reportpowerbi : MetaDataForm {
		public Frm_reportpowerbi() {
			InitializeComponent();
			this.Size = new Size(1280, 900);

			reportpbi.Dock = DockStyle.Fill;
			reportpbi.Location = new Point(0, 0);
			reportpbi.Size = ClientSize;
			reportpbi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

			InitializeAsync();
		}
		public Uri EmbeddedTarget => new Uri("https://app.powerbi.com/view?r=eyJrIjoiYzEzNDNkYzItNTk2YS00NTY3LWE4YTYtN2EwNjI2ZmMxM2Y1IiwidCI6ImFkZTk4MDdhLTA0NGUtNDdlMy05ZDUyLTU0MWU0MjQ1ODJiYyIsImMiOjl9");

		async void InitializeAsync() {

			CoreWebView2Environment env = await CoreWebView2Environment.CreateAsync(null, AppDomain.CurrentDomain.BaseDirectory);
			
			await reportpbi.EnsureCoreWebView2Async(env);

			this.Size = new Size(1280, 900);// faccio questa assegnazione dopo la EnsureCoreWebView2Async, la Size risulta  136 x 156

			reportpbi.NavigationCompleted += MyLinkWebView2_NavigationCompleted;


			reportpbi.CoreWebView2.Navigate(EmbeddedTarget.ToString());
		}

		private void MyLinkWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e) {
			MetaFactory.factory.getSingleton<IFormCreationListener>().refresh();
		}
	}
}
