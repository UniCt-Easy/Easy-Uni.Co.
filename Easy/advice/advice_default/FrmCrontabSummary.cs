
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cronos;

namespace advice_default {
    public partial class FrmCrontabSummary : Form {

        private DateTimeOffset start;
        private DateTimeOffset stop;
        private CronExpression crontab;

        public FrmCrontabSummary() {
            InitializeComponent();
        }

        public FrmCrontabSummary(DateTimeOffset start, DateTimeOffset stop, string crontab) {
            InitializeComponent();

            this.start = start;
            this.stop = stop;
            this.crontab = CronExpression.Parse(crontab);
        }

        private void FrmCrontabSummary_Load(object sender, EventArgs e) {
            foreach(var occurrence in crontab.GetOccurrences(start, stop, TimeZoneInfo.Local)) {
                monthCalendar.AddBoldedDate(occurrence.LocalDateTime);
                listBox.Items.Add(occurrence.LocalDateTime.ToString("R", CultureInfo.GetCultureInfo("it-IT")));
            }
            monthCalendar.UpdateBoldedDates();
        }
    }
}
