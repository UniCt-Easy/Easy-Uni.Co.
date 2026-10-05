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

namespace Backend.Extra {

    /// <summary>
    /// Gestisce il logger a livello di applicazione per il backend. 
    /// </summary>
    public class BackendLoggerService {

        /// <summary>
        /// Logger.
        /// </summary>
        private static BackendLogger _logger;

        /// <summary>
        /// Accede all'istanza.
        /// </summary>
        private static readonly Lazy<BackendLoggerService> _instance =

            new Lazy<BackendLoggerService>(() => {

                if (_logger == null)
                    throw new InvalidOperationException("Il logger deve essere impostato prima di accedere all'istanza.");

                try {

                    return new BackendLoggerService(_logger);
                }
                catch (Exception e) {

                    _logger.logException(e);
                    return null;
                }
            });

        /// <summary>
        /// Istanzia il singleton.
        /// </summary>
        /// <param name="bl">Logger.</param>
        private BackendLoggerService(BackendLogger bl) {

            _logger = bl ?? throw new ArgumentException("Logger non valido.");
        }

        /// <summary>
        /// Valore dell'istanza.
        /// </summary>
        public static BackendLoggerService Instance => _instance.Value;

        /// <summary>
        /// Logger esposto. 
        /// </summary>
        public static BackendLogger Logger => _logger;

        /// <summary>
        /// Imposta il logger sul servizio.
        /// </summary>
        /// <param name="logger">Logger utilizzato sul servizio.</param>
        public static void Initialize(BackendLogger logger) {

            if (_logger != null)
                throw new InvalidOperationException($"'{nameof(BackendLogger)}' già inizializzato.");

            _logger = logger;
        }
    }
}