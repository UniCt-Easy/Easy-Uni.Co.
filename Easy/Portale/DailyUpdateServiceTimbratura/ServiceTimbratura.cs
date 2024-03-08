
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
using System.ServiceProcess;
using System.Timers;
using ServizioTimbratura;

namespace DailyUpdateServiceTimbratura
{
    public partial class ServiceTimbratura : ServiceBase
	{
        // Costo Orario
		private int CostoOrario_hh = 0;
        private int CostoOrario_mm = 0;
		private Timer timerCostoOrario;

        // Timbratura
		private int Timbrature_hh = 0;
        private int Timbrature_mm = 0;
        private Timer timerTimbrature;

        public ServiceTimbratura()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            inf("Service Started");

			// ====================================================================================================================
			// Read App Setting
			// ====================================================================================================================
			Timbratura.getInfo(out bool enableCostoOrario, out bool enableTimbratura, out string hourStartCostoOrario, out string hourStartTimbratura);

			inf($"{(enableCostoOrario ? $"CostoOrario Start at {hourStartCostoOrario}" : "CostoOrario Disabled")}\r\n" +
                $"{(enableTimbratura ? $"Timbratura Start at {hourStartTimbratura}" : "Timbratura Disabled")}\r\n");

			// ====================================================================================================================
			// CostoOrario
			// ====================================================================================================================
            if (enableCostoOrario)
			{
				CostoOrario_hh = int.Parse(hourStartCostoOrario.Split(':')[0]);
				CostoOrario_mm = int.Parse(hourStartCostoOrario.Split(':')[1]);

				double interval = CalcInterval(CostoOrario_hh, CostoOrario_mm, 0);
                timerCostoOrario = new Timer(interval);
                timerCostoOrario.Elapsed += new ElapsedEventHandler(OnTimerElapsedCostoOrario);
                timerCostoOrario.Enabled = enableCostoOrario;
            }

			// ====================================================================================================================
			// Timbrature
			// ====================================================================================================================
            if (enableTimbratura)
			{
				Timbrature_hh = int.Parse(hourStartTimbratura.Split(':')[0]);
				Timbrature_mm = int.Parse(hourStartTimbratura.Split(':')[1]);

				// Timbrature
				double interval = CalcInterval(Timbrature_hh, Timbrature_mm, 0);
                timerTimbrature = new Timer(interval);
                timerTimbrature.Elapsed += new ElapsedEventHandler(OnTimerElapsedTimbrature);
                timerTimbrature.Enabled = enableTimbratura;
            }
        }

        protected override void OnStop()
        {
            timerTimbrature.Dispose();
            timerCostoOrario.Dispose();

            inf("Service Stopped");
        }

        private void OnTimerElapsedTimbrature(object sender, ElapsedEventArgs e)
        {
            Timbratura timbratura = new Timbratura();
            timbratura.DoUpdateTimbrature();
            timerTimbrature.Interval = CalcInterval(Timbrature_hh, Timbrature_mm, 0);
        }

        private void OnTimerElapsedCostoOrario(object sender, ElapsedEventArgs e)
        {
            Timbratura timbratura = new Timbratura();
            timbratura.DoUpdateCostoOrario();
            timerCostoOrario.Interval = CalcInterval(CostoOrario_hh, CostoOrario_mm, 0);
        }

        private double CalcInterval(int hh, int mm, int ss)
        {
            DateTime now = DateTime.Now;
            DateTime scheduledTime = new DateTime(now.Year, now.Month, now.Day, hh, mm, ss);
            if (now > scheduledTime)
            {
                scheduledTime = scheduledTime.AddDays(1);
            }
            return (scheduledTime - now).TotalMilliseconds;
        }

        private void inf(string s)
        {
            try { System.IO.File.AppendAllText($"{AppDomain.CurrentDomain.BaseDirectory}__log.txt", DateTime.Now.ToString("yy-MM-dd HH:mm:ss") + " - " + s + "\r\n"); } catch { }
        }
    }
}
