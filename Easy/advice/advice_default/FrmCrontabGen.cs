
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CronEspresso;
using metadatalibrary;

namespace advice_default {
    public partial class FrmCrontabGen : Form {

        private string crontab;
        private TimeSpan time { get { return new TimeSpan((int)timeHourNumericUpDown.Value, (int)timeMinuteNumericUpDown.Value, 0); } }

        private enum timeUnits {
            minuti,
            ore
        }

        private enum months {
            Gennaio,
            Febbraio,
            Marzo,
            Aprile,
            Maggio,
            Giugno,
            Luglio,
            Agosto,
            Settembre,
            Ottobre,
            Novembre,
            Dicembre
        }

        private enum weekdays {
            Domenica,
            Lunedì,
            Martedì,
            Mercoledì,
            Giovedì,
            Venerdì,
            Sabato
        }

        public string Crontab { get { return string.Join(" ", crontab.Split(' ').Reverse().Take(6).Reverse().Take(5)); } }

        public FrmCrontabGen() {
            InitializeComponent();
        }

        private void setSchedule(string warning) {
            if (MetaFactory.factory.getSingleton<IMessageShower>().Show(warning, "Richiesta conferma", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void FrmCrontabGen_Load(object sender, EventArgs e) {

            foreach(var tu in Enum.GetValues(typeof(timeUnits))) {
                periodicComboBox.Items.Add(tu.ToString());
            }
            periodicComboBox.SelectedIndex = 0;

            foreach (var wd in Enum.GetValues(typeof(weekdays))) {
                setDayComboBox.Items.Add(wd.ToString());
                multiDayCheckedListBox.Items.Add(wd.ToString());
                setDayMonthlyComboBox.Items.Add(wd.ToString());
            }
            setDayComboBox.SelectedIndex = 0;
            multiDayCheckedListBox.SelectedIndex = 0;
            setDayMonthlyComboBox.SelectedIndex = 0;

            foreach(var m in Enum.GetValues(typeof(months))) {
                yearlyComboBox.Items.Add(m.ToString());
            }
            yearlyComboBox.SelectedIndex = 0;
        }

        private void periodicComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            switch (periodicComboBox.SelectedIndex) {
                case (int)timeUnits.minuti:
                    periodicNumericUpDown.Maximum = 59;
                    break;
                case (int)timeUnits.ore:
                    periodicNumericUpDown.Maximum = 23;
                    break;
                default:
                    break;
            }
        }

        private void periodicButton_Click(object sender, EventArgs e) {
            switch (periodicComboBox.SelectedIndex) {
                case (int)timeUnits.minuti:
                    crontab = CronGenerator.GenerateMinutesCronExpression((int)periodicNumericUpDown.Value);
                    break;
                case (int)timeUnits.ore:
                    crontab = CronGenerator.GenerateHourlyCronExpression((int)periodicNumericUpDown.Value);
                    break;
                default:
                    break;
            }

            setSchedule(string.Format("Si sta per impostare una schedulazione periodica ogni {0} {1}", (int)periodicNumericUpDown.Value, periodicComboBox.SelectedItem));
        }

        private void dailyButton_Click(object sender, EventArgs e) {
            crontab = CronGenerator.GenerateDailyCronExpression(time);
            setSchedule(string.Format("Si sta per impostare una schedulazione giornaliera alle {0}", time.ToString(@"hh\:mm")));
        }

        private void setDayButton_Click(object sender, EventArgs e) {
            crontab = CronGenerator.GenerateSetDayCronExpression(time, setDayComboBox.SelectedIndex);
            setSchedule(string.Format("Si stano per impostare una schedulazione ogni {0} alle {1}", setDayComboBox.SelectedItem, time.ToString(@"hh\:mm")));
        }

        private void multiDayButton_Click(object sender, EventArgs e) {

            if (multiDayCheckedListBox.CheckedItems.Count == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Selezionare almeno un giorno della settimana", "Attenzione");
                return;
            }

            var checkedIndexes = new List<int>();
            var checkedNames = new List<string>();

            foreach (var item in multiDayCheckedListBox.CheckedItems) {
                checkedIndexes.Add(multiDayCheckedListBox.Items.IndexOf(item));
                checkedNames.Add(item.ToString());
            }

            string messageDays = string.Join(", ", checkedNames);

            crontab = CronGenerator.GenerateMultiDayCronExpression(time, checkedIndexes);
            setSchedule(string.Format("Si sta per impostare una schedulazione ogni {0} alle {1}", messageDays, time.ToString(@"hh\:mm")));
        }

        private void monthlyButton_Click(object sender, EventArgs e) {
            crontab = CronGenerator.GenerateMonthlyCronExpression(time, (int)monthlyDayNumericUpDown.Value, (int)monthlyMonthNumericUpDown.Value);
            setSchedule(string.Format("Si sta per impostare una schedulazione mensile ogni {0} del mese, ogni {1} mesi, alle {2}",
                (int)monthlyDayNumericUpDown.Value,
                (int)monthlyMonthNumericUpDown.Value,
                time.ToString(@"hh\:mm"))
            );
        }

        private void setDayMonthlyButton_Click(object sender, EventArgs e) {

            CronEspresso.Enums.TimeOfMonthToRun tmr;
            string ordinal;
            
            switch ((int)setDayMonthlyNumericUpDownOrdinal.Value) {
                case 1:
                    tmr = CronEspresso.Enums.TimeOfMonthToRun.First;
                    ordinal = "primo/a";
                    break;
                case 2:
                    tmr = CronEspresso.Enums.TimeOfMonthToRun.Second;
                    ordinal = "secondo/a";
                    break;
                case 3:
                    tmr = CronEspresso.Enums.TimeOfMonthToRun.Third;
                    ordinal = "terzo/a";
                    break;
                case 4:
                    tmr = CronEspresso.Enums.TimeOfMonthToRun.Fourth;
                    ordinal = "quarto/a";
                    break;
                default:
                    tmr = CronEspresso.Enums.TimeOfMonthToRun.First;
                    ordinal = "primo/a";
                    break;
            }

            crontab = CronGenerator.GenerateSetDayMonthlyCronExpression(time, tmr, setDayMonthlyComboBox.SelectedIndex, (int)setDayMonthlyNumericUpDownPeriod.Value);
            setSchedule(string.Format("Si sta per impostare una schedulazione mensile ogni {0} {1} del mese, ogni {2} mesi, alle {3}",
                ordinal,
                setDayMonthlyComboBox.SelectedItem,
                (int)setDayMonthlyNumericUpDownPeriod.Value,
                time.ToString(@"hh\:mm"))
            );
        }

        private void yearlyButton_Click(object sender, EventArgs e) {
            crontab = CronGenerator.GenerateYearlyCronExpression(time, (int)yearlyNumericUpDown.Value, yearlyComboBox.SelectedIndex + 1);
            setSchedule(string.Format("Si sta per impostare una schedulazione annuale ogni {0} {1}, alle {2}", 
                (int)yearlyNumericUpDown.Value, 
                yearlyComboBox.SelectedItem,
                time.ToString(@"hh\:mm"))
            );
        }

        private void noSchedulingButton_Click(object sender, EventArgs e) {
            crontab = string.Empty;
            setSchedule("Non si sta impostando alcuna schedulazione");
        }
    }
}
