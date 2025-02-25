
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
		private string _logFileName = "__WindowsServiceLog.txt";

		// Costo Orario
		private int CostoOrario_hh = 0;
        private int CostoOrario_mm = 0;
		private Timer timerCostoOrario = new Timer();

        // Timbratura
		private int Timbrature_hh = 0;
        private int Timbrature_mm = 0;
        private Timer timerTimbrature = new Timer();

        public ServiceTimbratura()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
			logInfo("Service Started");

            // ====================================================================================================================
            // Read App Setting
            // ====================================================================================================================
            Timbratura.getInfo(out bool enableCostoOrario, out bool enableTimbratura, out string hourStartCostoOrario, out string hourStartTimbratura);

            //bool enableCostoOrario = true;
            //bool enableTimbratura = true;
            //string hourStartCostoOrario = "16:00";
            //string hourStartTimbratura = "16:20";


			logInfo($"{(enableCostoOrario ? $"CostoOrario Start at {hourStartCostoOrario}" : "CostoOrario Disabled")} - " +
                    $"{(enableTimbratura ? $"Timbratura Start at {hourStartTimbratura}" : "Timbratura Disabled")}");

			// ====================================================================================================================
			// CostoOrario
			// ====================================================================================================================
            if (enableCostoOrario)
			{
				// HH:mm
				CostoOrario_hh = int.Parse(hourStartCostoOrario.Split(':')[0]);
				CostoOrario_mm = int.Parse(hourStartCostoOrario.Split(':')[1]);

				// Intervallo
				double interval = CalcInterval(CostoOrario_hh, CostoOrario_mm, 0);
				// logInfo("Next Costo orario in " + FormatMilliseconds(interval));

				// Timbrature
				timerCostoOrario.Elapsed += new ElapsedEventHandler(OnTimerElapsedCostoOrario);
				timerCostoOrario.Interval = interval;
				timerCostoOrario.Enabled = enableCostoOrario;
            }

			// ====================================================================================================================
			// Timbrature
			// ====================================================================================================================
            if (enableTimbratura)
			{
				// HH:mm
				Timbrature_hh = int.Parse(hourStartTimbratura.Split(':')[0]);
				Timbrature_mm = int.Parse(hourStartTimbratura.Split(':')[1]);
				
				// Intervallo
				double interval = CalcInterval(Timbrature_hh, Timbrature_mm, 0);
				// logInfo("Next Timbratura in " + FormatMilliseconds(interval));

				// Timbrature
				timerTimbrature.Elapsed += new ElapsedEventHandler(OnTimerElapsedTimbrature);
				timerTimbrature.Interval = interval;
				timerTimbrature.Enabled = enableTimbratura;
            }
        }

        protected override void OnStop()
        {
			timerTimbrature.Enabled = false;
			timerCostoOrario.Enabled = false;
			timerTimbrature.Dispose();
            timerCostoOrario.Dispose();

			logInfo("Service Stopped");
        }

        private void OnTimerElapsedTimbrature(object sender, ElapsedEventArgs e)
        {
			// Prossimo Intervallo
			double interval = CalcInterval(Timbrature_hh, Timbrature_mm, 0);
			// logInfo("Next Timbratura in " + FormatMilliseconds(interval));

			// Timbrature
			timerTimbrature.Interval = interval;
			Timbratura timbratura = new Timbratura();
            timbratura.DoUpdateTimbrature();

		}

        private void OnTimerElapsedCostoOrario(object sender, ElapsedEventArgs e)
        {
			// Prossimo Intervallo
			double interval = CalcInterval(CostoOrario_hh, CostoOrario_mm, 0);
			// logInfo("Next Costo orario in " + FormatMilliseconds(interval));

			timerCostoOrario.Interval = interval;
			Timbratura timbratura = new Timbratura();
            timbratura.DoUpdateCostoOrario();
		}

		public static string FormatMilliseconds(double milliseconds)
		{
			TimeSpan timeSpan = TimeSpan.FromMilliseconds(milliseconds);

			// Extract individual components
			int days = timeSpan.Days;
			int hours = timeSpan.Hours;
			int minutes = timeSpan.Minutes;
			int seconds = timeSpan.Seconds;
			int millisecondsPart = timeSpan.Milliseconds;

			// Format into the desired string
			return $"{days:D2} {hours:D2}:{minutes:D2}:{seconds:D2}.{millisecondsPart:D3}";
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

		// =======================================================================================================================================
		// PRINT LOG
		// =======================================================================================================================================
		private void logInfo(string s)
		{
			try { System.IO.File.AppendAllText($"{AppDomain.CurrentDomain.BaseDirectory}{_logFileName}", DateTime.Now.ToString("yy-MM-dd HH:mm:ss") + " - " + s + "\r\n"); } catch { }
		}
	}
}
