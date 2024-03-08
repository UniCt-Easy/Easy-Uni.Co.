
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



namespace advice_default {
    partial class FrmCrontabGen {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.periodicNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.periodicComboBox = new System.Windows.Forms.ComboBox();
            this.setDayComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.multiDayCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.monthlyDayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.monthlyMonthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.setDayMonthlyNumericUpDownOrdinal = new System.Windows.Forms.NumericUpDown();
            this.setDayMonthlyComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.setDayMonthlyNumericUpDownPeriod = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.yearlyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.yearlyComboBox = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.timeMinuteNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.timeHourNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.periodicButton = new System.Windows.Forms.Button();
            this.dailyButton = new System.Windows.Forms.Button();
            this.setDayButton = new System.Windows.Forms.Button();
            this.multiDayButton = new System.Windows.Forms.Button();
            this.monthlyButton = new System.Windows.Forms.Button();
            this.setDayMonthlyButton = new System.Windows.Forms.Button();
            this.yearlyButton = new System.Windows.Forms.Button();
            this.timeGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.periodicGroupBox = new System.Windows.Forms.GroupBox();
            this.dailyGroupBox = new System.Windows.Forms.GroupBox();
            this.setDayGroupBox = new System.Windows.Forms.GroupBox();
            this.multiDayGroupBox = new System.Windows.Forms.GroupBox();
            this.monthlyGroupBox = new System.Windows.Forms.GroupBox();
            this.setDayMonthlyGroupBox = new System.Windows.Forms.GroupBox();
            this.yearlyGroupBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.noSchedulingGroupBox = new System.Windows.Forms.GroupBox();
            this.noSchedulingButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.periodicNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyDayNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyMonthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setDayMonthlyNumericUpDownOrdinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setDayMonthlyNumericUpDownPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearlyNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeMinuteNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeHourNumericUpDown)).BeginInit();
            this.timeGroupBox.SuspendLayout();
            this.periodicGroupBox.SuspendLayout();
            this.dailyGroupBox.SuspendLayout();
            this.setDayGroupBox.SuspendLayout();
            this.multiDayGroupBox.SuspendLayout();
            this.monthlyGroupBox.SuspendLayout();
            this.setDayMonthlyGroupBox.SuspendLayout();
            this.yearlyGroupBox.SuspendLayout();
            this.noSchedulingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // periodicNumericUpDown
            // 
            this.periodicNumericUpDown.Location = new System.Drawing.Point(122, 22);
            this.periodicNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.periodicNumericUpDown.Name = "periodicNumericUpDown";
            this.periodicNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.periodicNumericUpDown.TabIndex = 0;
            this.periodicNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // periodicComboBox
            // 
            this.periodicComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.periodicComboBox.FormattingEnabled = true;
            this.periodicComboBox.Location = new System.Drawing.Point(183, 21);
            this.periodicComboBox.Name = "periodicComboBox";
            this.periodicComboBox.Size = new System.Drawing.Size(121, 21);
            this.periodicComboBox.TabIndex = 1;
            this.periodicComboBox.SelectedIndexChanged += new System.EventHandler(this.periodicComboBox_SelectedIndexChanged);
            // 
            // setDayComboBox
            // 
            this.setDayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setDayComboBox.FormattingEnabled = true;
            this.setDayComboBox.Location = new System.Drawing.Point(122, 21);
            this.setDayComboBox.Name = "setDayComboBox";
            this.setDayComboBox.Size = new System.Drawing.Size(121, 21);
            this.setDayComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ogni";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ogni";
            // 
            // multiDayCheckedListBox
            // 
            this.multiDayCheckedListBox.FormattingEnabled = true;
            this.multiDayCheckedListBox.Location = new System.Drawing.Point(123, 19);
            this.multiDayCheckedListBox.Name = "multiDayCheckedListBox";
            this.multiDayCheckedListBox.Size = new System.Drawing.Size(120, 109);
            this.multiDayCheckedListBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ogni";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ogni giorno";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(87, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Ogni";
            // 
            // monthlyDayNumericUpDown
            // 
            this.monthlyDayNumericUpDown.Location = new System.Drawing.Point(122, 22);
            this.monthlyDayNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.monthlyDayNumericUpDown.Name = "monthlyDayNumericUpDown";
            this.monthlyDayNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.monthlyDayNumericUpDown.TabIndex = 18;
            this.monthlyDayNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(180, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "del mese";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(235, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "ogni";
            // 
            // monthlyMonthNumericUpDown
            // 
            this.monthlyMonthNumericUpDown.Location = new System.Drawing.Point(268, 22);
            this.monthlyMonthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.monthlyMonthNumericUpDown.Name = "monthlyMonthNumericUpDown";
            this.monthlyMonthNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.monthlyMonthNumericUpDown.TabIndex = 21;
            this.monthlyMonthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(329, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "mesi";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(87, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Ogni";
            // 
            // setDayMonthlyNumericUpDownOrdinal
            // 
            this.setDayMonthlyNumericUpDownOrdinal.Location = new System.Drawing.Point(122, 22);
            this.setDayMonthlyNumericUpDownOrdinal.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.setDayMonthlyNumericUpDownOrdinal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.setDayMonthlyNumericUpDownOrdinal.Name = "setDayMonthlyNumericUpDownOrdinal";
            this.setDayMonthlyNumericUpDownOrdinal.Size = new System.Drawing.Size(55, 20);
            this.setDayMonthlyNumericUpDownOrdinal.TabIndex = 24;
            this.setDayMonthlyNumericUpDownOrdinal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // setDayMonthlyComboBox
            // 
            this.setDayMonthlyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setDayMonthlyComboBox.FormattingEnabled = true;
            this.setDayMonthlyComboBox.Location = new System.Drawing.Point(183, 21);
            this.setDayMonthlyComboBox.Name = "setDayMonthlyComboBox";
            this.setDayMonthlyComboBox.Size = new System.Drawing.Size(121, 21);
            this.setDayMonthlyComboBox.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(490, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "mesi";
            // 
            // setDayMonthlyNumericUpDownPeriod
            // 
            this.setDayMonthlyNumericUpDownPeriod.Location = new System.Drawing.Point(429, 22);
            this.setDayMonthlyNumericUpDownPeriod.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.setDayMonthlyNumericUpDownPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.setDayMonthlyNumericUpDownPeriod.Name = "setDayMonthlyNumericUpDownPeriod";
            this.setDayMonthlyNumericUpDownPeriod.Size = new System.Drawing.Size(55, 20);
            this.setDayMonthlyNumericUpDownPeriod.TabIndex = 27;
            this.setDayMonthlyNumericUpDownPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(396, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "ogni";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(310, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "del mese";
            // 
            // yearlyNumericUpDown
            // 
            this.yearlyNumericUpDown.Location = new System.Drawing.Point(122, 22);
            this.yearlyNumericUpDown.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.yearlyNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.yearlyNumericUpDown.Name = "yearlyNumericUpDown";
            this.yearlyNumericUpDown.Size = new System.Drawing.Size(55, 20);
            this.yearlyNumericUpDown.TabIndex = 31;
            this.yearlyNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(87, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "Ogni";
            // 
            // yearlyComboBox
            // 
            this.yearlyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearlyComboBox.FormattingEnabled = true;
            this.yearlyComboBox.Location = new System.Drawing.Point(183, 22);
            this.yearlyComboBox.Name = "yearlyComboBox";
            this.yearlyComboBox.Size = new System.Drawing.Size(121, 21);
            this.yearlyComboBox.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 218);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 13);
            this.label18.TabIndex = 36;
            this.label18.Text = "alle";
            // 
            // timeMinuteNumericUpDown
            // 
            this.timeMinuteNumericUpDown.Location = new System.Drawing.Point(127, 216);
            this.timeMinuteNumericUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.timeMinuteNumericUpDown.Name = "timeMinuteNumericUpDown";
            this.timeMinuteNumericUpDown.Size = new System.Drawing.Size(45, 20);
            this.timeMinuteNumericUpDown.TabIndex = 35;
            // 
            // timeHourNumericUpDown
            // 
            this.timeHourNumericUpDown.Location = new System.Drawing.Point(52, 216);
            this.timeHourNumericUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.timeHourNumericUpDown.Name = "timeHourNumericUpDown";
            this.timeHourNumericUpDown.Size = new System.Drawing.Size(54, 20);
            this.timeHourNumericUpDown.TabIndex = 34;
            // 
            // periodicButton
            // 
            this.periodicButton.Location = new System.Drawing.Point(6, 19);
            this.periodicButton.Name = "periodicButton";
            this.periodicButton.Size = new System.Drawing.Size(75, 23);
            this.periodicButton.TabIndex = 45;
            this.periodicButton.Text = "Ripeti";
            this.periodicButton.UseVisualStyleBackColor = true;
            this.periodicButton.Click += new System.EventHandler(this.periodicButton_Click);
            // 
            // dailyButton
            // 
            this.dailyButton.Location = new System.Drawing.Point(6, 19);
            this.dailyButton.Name = "dailyButton";
            this.dailyButton.Size = new System.Drawing.Size(75, 23);
            this.dailyButton.TabIndex = 46;
            this.dailyButton.Text = "Ripeti";
            this.dailyButton.UseVisualStyleBackColor = true;
            this.dailyButton.Click += new System.EventHandler(this.dailyButton_Click);
            // 
            // setDayButton
            // 
            this.setDayButton.Location = new System.Drawing.Point(6, 19);
            this.setDayButton.Name = "setDayButton";
            this.setDayButton.Size = new System.Drawing.Size(75, 23);
            this.setDayButton.TabIndex = 47;
            this.setDayButton.Text = "Ripeti";
            this.setDayButton.UseVisualStyleBackColor = true;
            this.setDayButton.Click += new System.EventHandler(this.setDayButton_Click);
            // 
            // multiDayButton
            // 
            this.multiDayButton.Location = new System.Drawing.Point(6, 19);
            this.multiDayButton.Name = "multiDayButton";
            this.multiDayButton.Size = new System.Drawing.Size(75, 23);
            this.multiDayButton.TabIndex = 48;
            this.multiDayButton.Text = "Ripeti";
            this.multiDayButton.UseVisualStyleBackColor = true;
            this.multiDayButton.Click += new System.EventHandler(this.multiDayButton_Click);
            // 
            // monthlyButton
            // 
            this.monthlyButton.Location = new System.Drawing.Point(6, 19);
            this.monthlyButton.Name = "monthlyButton";
            this.monthlyButton.Size = new System.Drawing.Size(75, 23);
            this.monthlyButton.TabIndex = 49;
            this.monthlyButton.Text = "Ripeti";
            this.monthlyButton.UseVisualStyleBackColor = true;
            this.monthlyButton.Click += new System.EventHandler(this.monthlyButton_Click);
            // 
            // setDayMonthlyButton
            // 
            this.setDayMonthlyButton.Location = new System.Drawing.Point(6, 19);
            this.setDayMonthlyButton.Name = "setDayMonthlyButton";
            this.setDayMonthlyButton.Size = new System.Drawing.Size(75, 23);
            this.setDayMonthlyButton.TabIndex = 50;
            this.setDayMonthlyButton.Text = "Ripeti";
            this.setDayMonthlyButton.UseVisualStyleBackColor = true;
            this.setDayMonthlyButton.Click += new System.EventHandler(this.setDayMonthlyButton_Click);
            // 
            // yearlyButton
            // 
            this.yearlyButton.Location = new System.Drawing.Point(6, 19);
            this.yearlyButton.Name = "yearlyButton";
            this.yearlyButton.Size = new System.Drawing.Size(75, 23);
            this.yearlyButton.TabIndex = 51;
            this.yearlyButton.Text = "Ripeti";
            this.yearlyButton.UseVisualStyleBackColor = true;
            this.yearlyButton.Click += new System.EventHandler(this.yearlyButton_Click);
            // 
            // timeGroupBox
            // 
            this.timeGroupBox.Controls.Add(this.label3);
            this.timeGroupBox.Controls.Add(this.timeHourNumericUpDown);
            this.timeGroupBox.Controls.Add(this.label18);
            this.timeGroupBox.Controls.Add(this.timeMinuteNumericUpDown);
            this.timeGroupBox.Location = new System.Drawing.Point(570, 249);
            this.timeGroupBox.Name = "timeGroupBox";
            this.timeGroupBox.Size = new System.Drawing.Size(198, 475);
            this.timeGroupBox.TabIndex = 52;
            this.timeGroupBox.TabStop = false;
            this.timeGroupBox.Text = "Orario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = ":";
            // 
            // periodicGroupBox
            // 
            this.periodicGroupBox.Controls.Add(this.periodicButton);
            this.periodicGroupBox.Controls.Add(this.label1);
            this.periodicGroupBox.Controls.Add(this.periodicNumericUpDown);
            this.periodicGroupBox.Controls.Add(this.periodicComboBox);
            this.periodicGroupBox.Location = new System.Drawing.Point(19, 183);
            this.periodicGroupBox.Name = "periodicGroupBox";
            this.periodicGroupBox.Size = new System.Drawing.Size(749, 61);
            this.periodicGroupBox.TabIndex = 53;
            this.periodicGroupBox.TabStop = false;
            this.periodicGroupBox.Text = "Periodica";
            // 
            // dailyGroupBox
            // 
            this.dailyGroupBox.Controls.Add(this.dailyButton);
            this.dailyGroupBox.Controls.Add(this.label6);
            this.dailyGroupBox.Location = new System.Drawing.Point(19, 249);
            this.dailyGroupBox.Name = "dailyGroupBox";
            this.dailyGroupBox.Size = new System.Drawing.Size(545, 61);
            this.dailyGroupBox.TabIndex = 54;
            this.dailyGroupBox.TabStop = false;
            this.dailyGroupBox.Text = "Giornaliera";
            // 
            // setDayGroupBox
            // 
            this.setDayGroupBox.Controls.Add(this.setDayButton);
            this.setDayGroupBox.Controls.Add(this.setDayComboBox);
            this.setDayGroupBox.Controls.Add(this.label2);
            this.setDayGroupBox.Location = new System.Drawing.Point(19, 315);
            this.setDayGroupBox.Name = "setDayGroupBox";
            this.setDayGroupBox.Size = new System.Drawing.Size(545, 61);
            this.setDayGroupBox.TabIndex = 55;
            this.setDayGroupBox.TabStop = false;
            this.setDayGroupBox.Text = "Giorno specifico";
            // 
            // multiDayGroupBox
            // 
            this.multiDayGroupBox.Controls.Add(this.multiDayButton);
            this.multiDayGroupBox.Controls.Add(this.label4);
            this.multiDayGroupBox.Controls.Add(this.multiDayCheckedListBox);
            this.multiDayGroupBox.Location = new System.Drawing.Point(19, 381);
            this.multiDayGroupBox.Name = "multiDayGroupBox";
            this.multiDayGroupBox.Size = new System.Drawing.Size(545, 145);
            this.multiDayGroupBox.TabIndex = 56;
            this.multiDayGroupBox.TabStop = false;
            this.multiDayGroupBox.Text = "Giorno specifico multiplo";
            // 
            // monthlyGroupBox
            // 
            this.monthlyGroupBox.Controls.Add(this.monthlyButton);
            this.monthlyGroupBox.Controls.Add(this.label8);
            this.monthlyGroupBox.Controls.Add(this.monthlyDayNumericUpDown);
            this.monthlyGroupBox.Controls.Add(this.label9);
            this.monthlyGroupBox.Controls.Add(this.label10);
            this.monthlyGroupBox.Controls.Add(this.monthlyMonthNumericUpDown);
            this.monthlyGroupBox.Controls.Add(this.label11);
            this.monthlyGroupBox.Location = new System.Drawing.Point(19, 531);
            this.monthlyGroupBox.Name = "monthlyGroupBox";
            this.monthlyGroupBox.Size = new System.Drawing.Size(545, 61);
            this.monthlyGroupBox.TabIndex = 57;
            this.monthlyGroupBox.TabStop = false;
            this.monthlyGroupBox.Text = "Mensile";
            // 
            // setDayMonthlyGroupBox
            // 
            this.setDayMonthlyGroupBox.Controls.Add(this.setDayMonthlyButton);
            this.setDayMonthlyGroupBox.Controls.Add(this.label12);
            this.setDayMonthlyGroupBox.Controls.Add(this.setDayMonthlyNumericUpDownOrdinal);
            this.setDayMonthlyGroupBox.Controls.Add(this.setDayMonthlyComboBox);
            this.setDayMonthlyGroupBox.Controls.Add(this.label14);
            this.setDayMonthlyGroupBox.Controls.Add(this.setDayMonthlyNumericUpDownPeriod);
            this.setDayMonthlyGroupBox.Controls.Add(this.label13);
            this.setDayMonthlyGroupBox.Controls.Add(this.label15);
            this.setDayMonthlyGroupBox.Location = new System.Drawing.Point(19, 597);
            this.setDayMonthlyGroupBox.Name = "setDayMonthlyGroupBox";
            this.setDayMonthlyGroupBox.Size = new System.Drawing.Size(545, 61);
            this.setDayMonthlyGroupBox.TabIndex = 58;
            this.setDayMonthlyGroupBox.TabStop = false;
            this.setDayMonthlyGroupBox.Text = "Mensile con giorno specifico";
            // 
            // yearlyGroupBox
            // 
            this.yearlyGroupBox.Controls.Add(this.yearlyButton);
            this.yearlyGroupBox.Controls.Add(this.label16);
            this.yearlyGroupBox.Controls.Add(this.yearlyNumericUpDown);
            this.yearlyGroupBox.Controls.Add(this.yearlyComboBox);
            this.yearlyGroupBox.Location = new System.Drawing.Point(19, 663);
            this.yearlyGroupBox.Name = "yearlyGroupBox";
            this.yearlyGroupBox.Size = new System.Drawing.Size(545, 61);
            this.yearlyGroupBox.TabIndex = 59;
            this.yearlyGroupBox.TabStop = false;
            this.yearlyGroupBox.Text = "Annuale";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 157);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(749, 20);
            this.textBox1.TabIndex = 60;
            this.textBox1.Text = "Usare il tasto \"Ripeti\" per impostare la schedulazione desiderata";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // noSchedulingGroupBox
            // 
            this.noSchedulingGroupBox.Controls.Add(this.noSchedulingButton);
            this.noSchedulingGroupBox.Location = new System.Drawing.Point(19, 13);
            this.noSchedulingGroupBox.Name = "noSchedulingGroupBox";
            this.noSchedulingGroupBox.Size = new System.Drawing.Size(749, 122);
            this.noSchedulingGroupBox.TabIndex = 61;
            this.noSchedulingGroupBox.TabStop = false;
            this.noSchedulingGroupBox.Text = "Nessuna schedulazione";
            // 
            // noSchedulingButton
            // 
            this.noSchedulingButton.Location = new System.Drawing.Point(70, 29);
            this.noSchedulingButton.Name = "noSchedulingButton";
            this.noSchedulingButton.Size = new System.Drawing.Size(611, 69);
            this.noSchedulingButton.TabIndex = 0;
            this.noSchedulingButton.Text = "Annulla schedulazione";
            this.noSchedulingButton.UseVisualStyleBackColor = true;
            this.noSchedulingButton.Click += new System.EventHandler(this.noSchedulingButton_Click);
            // 
            // FrmCrontabGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 741);
            this.Controls.Add(this.noSchedulingGroupBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.yearlyGroupBox);
            this.Controls.Add(this.setDayMonthlyGroupBox);
            this.Controls.Add(this.monthlyGroupBox);
            this.Controls.Add(this.multiDayGroupBox);
            this.Controls.Add(this.setDayGroupBox);
            this.Controls.Add(this.dailyGroupBox);
            this.Controls.Add(this.periodicGroupBox);
            this.Controls.Add(this.timeGroupBox);
            this.Name = "FrmCrontabGen";
            this.Text = "Schedulazione";
            this.Load += new System.EventHandler(this.FrmCrontabGen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.periodicNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyDayNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyMonthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setDayMonthlyNumericUpDownOrdinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setDayMonthlyNumericUpDownPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearlyNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeMinuteNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeHourNumericUpDown)).EndInit();
            this.timeGroupBox.ResumeLayout(false);
            this.timeGroupBox.PerformLayout();
            this.periodicGroupBox.ResumeLayout(false);
            this.periodicGroupBox.PerformLayout();
            this.dailyGroupBox.ResumeLayout(false);
            this.dailyGroupBox.PerformLayout();
            this.setDayGroupBox.ResumeLayout(false);
            this.setDayGroupBox.PerformLayout();
            this.multiDayGroupBox.ResumeLayout(false);
            this.multiDayGroupBox.PerformLayout();
            this.monthlyGroupBox.ResumeLayout(false);
            this.monthlyGroupBox.PerformLayout();
            this.setDayMonthlyGroupBox.ResumeLayout(false);
            this.setDayMonthlyGroupBox.PerformLayout();
            this.yearlyGroupBox.ResumeLayout(false);
            this.yearlyGroupBox.PerformLayout();
            this.noSchedulingGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown periodicNumericUpDown;
        private System.Windows.Forms.ComboBox periodicComboBox;
        private System.Windows.Forms.ComboBox setDayComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox multiDayCheckedListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown monthlyDayNumericUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown monthlyMonthNumericUpDown;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown setDayMonthlyNumericUpDownOrdinal;
        private System.Windows.Forms.ComboBox setDayMonthlyComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown setDayMonthlyNumericUpDownPeriod;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown yearlyNumericUpDown;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox yearlyComboBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown timeMinuteNumericUpDown;
        private System.Windows.Forms.NumericUpDown timeHourNumericUpDown;
        private System.Windows.Forms.Button periodicButton;
        private System.Windows.Forms.Button dailyButton;
        private System.Windows.Forms.Button setDayButton;
        private System.Windows.Forms.Button multiDayButton;
        private System.Windows.Forms.Button monthlyButton;
        private System.Windows.Forms.Button setDayMonthlyButton;
        private System.Windows.Forms.Button yearlyButton;
        private System.Windows.Forms.GroupBox timeGroupBox;
        private System.Windows.Forms.GroupBox periodicGroupBox;
        private System.Windows.Forms.GroupBox dailyGroupBox;
        private System.Windows.Forms.GroupBox setDayGroupBox;
        private System.Windows.Forms.GroupBox multiDayGroupBox;
        private System.Windows.Forms.GroupBox monthlyGroupBox;
        private System.Windows.Forms.GroupBox setDayMonthlyGroupBox;
        private System.Windows.Forms.GroupBox yearlyGroupBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox noSchedulingGroupBox;
        private System.Windows.Forms.Button noSchedulingButton;
        private System.Windows.Forms.Label label3;
    }
}
