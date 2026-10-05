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
using System.IO;

namespace Backend.CommonBackend {

    /// <summary>
    /// Classe per la gestione di file temporanei.
    /// </summary>
    public sealed class TempFile : IDisposable {

        /// <summary>
        /// Modalità di creazione del file temporaneo.
        /// </summary>
        public enum CreationMode {
            /// <summary>
            /// Crea un nome di file temporaneo senza allocare il file fisico.
            /// </summary>
            OnlyFilename,
            /// <summary>
            /// Alloca un file temporaneo e restituisce il percorso completo.
            /// </summary>
            AllocateFile
        }

        /// <summary>
        /// Modalità di creazione del file temporaneo impostata per l'istanza corrente.
        /// </summary>
        public CreationMode Mode { get; }
        /// <summary>
        /// Percorso del file temporaneo.
        /// </summary>
        public string FilePath { get; }


        /// <summary>
        /// Inizializza un nuovo file temporaneo.
        /// </summary>
        /// <param name="mode">Modalità di creazione del file temporaneo da utilizzare.</param>
        public TempFile(CreationMode mode = CreationMode.OnlyFilename) {

            Mode = mode;

            switch (Mode) {
                case CreationMode.AllocateFile:
                    FilePath = Path.GetTempFileName(); // creiamo un file temporaneo e restutuiamo il percorso
                    break;
                case CreationMode.OnlyFilename:
                default:
                    FilePath = Path.GetTempPath() + Guid.NewGuid().ToString("N") + ".tmp"; // generiamo un nome unico per il file temporaneo
                    break;
            }
        }

        /// <summary>
        /// Rilascia le risorse dell'istanza corrente e cancella il file temporaneo.
        /// </summary>
        /// <remarks>Questo metodo tenta di eliminare il file specificato da <see cref="FilePath"/>. Se il
        /// file non esiste non viene intrapresa alcuna azione. Se il file non puo essere eliminato, sarà lanciata
        /// una <see cref="IOException"/>.</remarks>
        /// <exception cref="IOException">Thrown if the temporary file specified by <see cref="FilePath"/> cannot be deleted.</exception>
        public void Dispose() {
            try {

                if (File.Exists(FilePath)) {
                    File.Delete(FilePath);
                }
            }
            catch {

                throw new IOException($"Unable to delete temporary file: {FilePath}");
            }
        }
    }
}
