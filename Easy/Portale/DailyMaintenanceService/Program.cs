
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
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DailyMaintenanceService
{
    internal static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        static void Main()
        {
            // Verifica se l'applicazione è in modalità interattiva (console)
            if (Environment.UserInteractive)
            {
                // Esegui il servizio in modalità console per il debug ==> andare prima in prorietà>applicazione e impostare il tipo di output "Applicazione console" poi, finito il debug rimetterlo a "Applicazione windows"
                ServiceMaintenance service = new ServiceMaintenance();
                service.StartDebug();
                Console.WriteLine("Servizio avviato in modalità console. Premi un tasto per terminare...");
                Console.ReadLine();
                service.StopDebug();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new ServiceMaintenance()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }


    }
}
