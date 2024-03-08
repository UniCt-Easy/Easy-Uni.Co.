
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


using ServizioRendicontazione;

namespace DailyUpdateServiceRendicontazione
{
	public class ServiceRendicontazione : BackgroundService
	{
		private string _logFileName = "__WindowsServiceLog.txt";

		private string settingsFile = "appsettings.json";

		int now_hh = 7;
		int now_mm = 30;
		private bool enableRendicontazione = false;

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			try
			{
				while (!stoppingToken.IsCancellationRequested)
				{
					// Read Config
					ReadConfig();

					// Set the time for 7:00 am
					DateTime now = DateTime.Now;
					DateTime nextRunTime = new DateTime(now.Year, now.Month, now.Day, now_hh, now_mm, 0);

					// If it's already past 7:00 am, schedule it for the next day
					if (now > nextRunTime)
						nextRunTime = nextRunTime.AddDays(1);

					logInfo(enableRendicontazione ? $"Next Rendicontazione Will Start at {nextRunTime}" : "Rendicontazione Disabled");

					// Calculate the time until the next run
					TimeSpan initialDelay = nextRunTime - now;

					// Keep the worker running until it's canceled
					await Task.Delay(initialDelay, stoppingToken);

					if (enableRendicontazione)
						new Rendicontazione().InsLezioni();
					
				}
			}
			catch (Exception Ex)
			{
				logInfo(Ex.Message + Ex.InnerException?.Message);
			}
		}

		private void ReadConfig()
		{
			try
			{
				string settingsFileFullName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, settingsFile);
				var configuration = new ConfigurationBuilder().AddJsonFile(settingsFileFullName);
				var config = configuration.Build();
				var appSettings = config.GetSection("AppSettings");

				enableRendicontazione = appSettings.GetChildren().FirstOrDefault(w => w.Key == "enableRendicontazione")?.Value == "Y";

				string hourStartRendicontazione = appSettings.GetChildren().FirstOrDefault(w => w.Key == "hourStartRendicontazione")?.Value ?? "7:30";
				now_hh = int.Parse(hourStartRendicontazione.Split(':')[0]);
				now_mm = int.Parse(hourStartRendicontazione.Split(':')[1]);
			}
			catch (Exception Ex)
			{
				logInfo(Ex.Message + Ex.InnerException?.Message);
			}
		}

		// =======================================================================================================================================
		// PRINT LOG
		// =======================================================================================================================================
		private void logInfo(string s)
		{
			try { System.IO.File.AppendAllText($"{AppDomain.CurrentDomain.BaseDirectory}{_logFileName}", DateTime.Now.ToString("yy-MM-dd hh:mm:ss") + " - " + s + "\r\n"); } catch { }
		}
	}
}
