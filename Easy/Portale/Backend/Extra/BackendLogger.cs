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
using System.Diagnostics;
using System.Reflection;

using eventLog;

using Backend.CommonBackend;


namespace Backend.Extra {
    /// <summary>
    /// Utilizza DBLogger per registrare i messaggi di log.
    /// </summary>
    public class BackendLogger : IPreserveLogger {

        // L'interfaccia unica per il logger dovrebbe essere spostata probabilmente da preserve (sdiftp) ad un namespace su Backend.

        // Non possiamo usare ILogger per implementarla in questa versione di .net senza installare pacchetti.
        // Questa è una copia dell'enum Microsoft.Extensions.Logging.LogLevel. 

        /// <summary>
        /// Defines logging severity levels.
        /// </summary>
        public enum LogLevel {
            /// <summary>
            /// Logs that contain the most detailed messages.
            /// These messages may contain sensitive application data.
            /// These messages are disabled by default and should never be enabled in a production environment.
            /// </summary>
            Trace = 0,

            /// <summary>
            /// Logs that are used for interactive investigation during development.
            /// These logs should primarily contain information useful for debugging and have no long-term value.
            /// </summary>
            Debug = 1,

            /// <summary>
            /// Logs that track the general flow of the application.
            /// These logs should have long-term value.
            /// </summary>
            Information = 2,

            /// <summary>
            /// Logs that highlight an abnormal or unexpected event in the application flow,
            /// but do not otherwise cause the application to stop.
            /// </summary>
            Warning = 3,

            /// <summary>
            /// Logs that highlight when the current flow of execution is stopped due to a failure.
            /// These should indicate a failure in the current activity, not an application-wide failure.
            /// </summary>
            Error = 4,

            /// <summary>
            /// Logs that describe an unrecoverable application or system crash,
            /// or a catastrophic failure that requires immediate attention.
            /// </summary>
            Critical = 5,

            /// <summary>
            /// Not used for writing log messages.
            /// Specifies that a logging category should not write any messages.
            /// </summary>
            None = 6
        }

        /// <summary>
        /// Contiene il Dispatcher da utilizzare per l'accesso a DB
        /// </summary>
        private readonly Dispatcher _dispatcher;

        /// <summary>
        /// Nome del logger.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Livello di logging per il logger: messaggi di livello minore non saranno loggati.
        /// </summary>
        public LogLevel Level { get; } = LogLevel.Error;

        /// <summary>
        /// Inizializza l'adapter per il logging.
        /// </summary>
        /// <param name="d">Dispatcher da utilizzare per l'accesso a DB.</param>
        /// <param name="name">Nome del logger.</param>
        /// <param name="level">Livello di logging minimo.</param>
        public BackendLogger(Dispatcher d, LogLevel level, string name = null) {

            _dispatcher = d ?? throw new ArgumentNullException(nameof(d));

            Level = level;
            Name = name ?? "BackendLogger";
        }

        /// <summary>
        /// Crea un messaggio di errore.
        /// </summary>
        /// <param name="msg">Testo del messaggio.</param>
        /// <param name="ll">Livello del messaggio.</param>
        /// <returns></returns>
        private DBLogger.BEError Create(string msg, LogLevel ll) {
            var stackTrace = new StackTrace();
            var callerFrame = stackTrace.GetFrame(2);
            var callerMethod = callerFrame.GetMethod();
            var declaringType = callerMethod.DeclaringType;
            var currentAssembly = Assembly.GetExecutingAssembly();

            // limiti sulla colonna su db
            var methodString = $"{declaringType?.Name}.{callerMethod.Name}";
            if (methodString.Length > 50)
                methodString = methodString.Substring(0, 50);

            string metadata = string.Join(" | ", new[] {
                $"Component={Name}",
                $"Assembly={currentAssembly.GetName().Name}",
                $"Version={currentAssembly.GetName().Version}",
                $"FullType={declaringType?.FullName}",
                $"Signature={callerMethod}"
            });

            string errorString = $"[{Name}] [{ll}] {msg}";

            var berr = new DBLogger.BEError() {
                conn = _dispatcher.conn,
                error = errorString,
                methodInfo = methodString,
                metadata = metadata
            };

            return berr;
        }

        /// <summary>
        /// Registra un messaggio di log.
        /// </summary>
        /// <param name="message">Messaggio da loggare.</param>
        /// <param name="msgLevel">Livello del messaggio</param>
        public void Log(string message, LogLevel msgLevel) {

            if (this.Level >= msgLevel) {
                return;
            }

            var berr = Create(message, msgLevel);

            DBLogger.log(berr);
        }

        /// <summary>
        /// Registra un errore su log.
        /// </summary>
        /// <param name="err">Testo dell'errore.</param>
        public void logErrorToRegistry(string err) {

            if (this.Level >= LogLevel.Error) {
                return;
            }

            var berr = Create(err, LogLevel.Error);

            DBLogger.log(berr);
        }

        /// <summary>
        /// Registra una eccezione su log, includendo tutti i messaggi delle eccezioni annidate.
        /// </summary>
        /// <param name="e">Eccezione da loggare.</param>
        public void logException(Exception e) {

            if (e == null) return;

            var messages = new List<string>();
            Exception current = e;
            while (current != null) {
                messages.Add(current.Message);
                current = current.InnerException;
            }

            string allMessages = string.Join(" -> ", messages);

            var berr = Create(allMessages, LogLevel.Error);
            DBLogger.log(berr);
        }


        /// <summary>
        /// Registra un warning su log.
        /// </summary>
        /// <param name="err">Testo dell'errore.</param>
        public void logWarnToRegistry(string err) {

            if (this.Level >= LogLevel.Warning) {

                return;
            }

            var berr = Create(err, LogLevel.Warning);

            DBLogger.log(berr);
        }
    }
}