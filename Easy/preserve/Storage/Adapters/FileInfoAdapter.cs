using System;
using System.IO;

namespace preserve.Storage.Adapters {

    /// <summary>
    /// Adapter per il tipo builtin di riferimento a file su filesystem.
    /// </summary>
    public class FileInfoAdapter : IFileReference {

        /// <summary>
        /// Istanza di tipo builtin del riferimento a file su filesystem.
        /// </summary>
        private readonly FileInfo F;

        /// <summary>
        /// Indica se sovrascrivere il file di destinazione allo spostamento.
        /// </summary>
        private bool _overwriteOnMove = true;

        /// <summary>
        /// Indica se sovrascrivere il file di destinazione allo spostamento.
        /// </summary>
        //public bool OverwriteOnMove => _overwriteOnMove;

        /// <summary>
        /// Nome del riferimento al file.
        /// </summary>
        public string Name => F.Name;
        /// <summary>
        /// Nome completo del riferimento al file.
        /// </summary>
        public string FullName => F.FullName;
        /// <summary>
        /// Container del riferimento al file.
        /// </summary>
        public IFileReferenceContainer Container => new DirectoryInfoAdapter(F.Directory);
        /// <summary>
        /// Indica se il container esista.
        /// </summary>
        public bool Exists => F.Exists;

        /// <summary>
        /// Sposta il riferimento ad un file su un altro riferimento.
        /// </summary>
        /// <param name="destFileName">Nome completo del riferimento al file destinazione.</param>
        public void MoveTo(string destFileName) {

            if (_overwriteOnMove) {

                if (File.Exists(destFileName))
                    File.Delete(destFileName);

                F.MoveTo(destFileName);
            }
            else {

                F.MoveTo(destFileName);
            }
        }

        [Obsolete("Use FileInfoAdapter(FileInfo f, params Action<FileInfoAdapter>[] options) instead")]
        /// <summary>
        /// Crea un'istanza dell'adapter per il riferimento a file su filesystem da un'istanza del tipo builtin.
        /// </summary>
        /// <param name="f">Istanza del riferimento a file su filesystem.</param>
        public FileInfoAdapter(FileInfo f) {

            F = f ?? throw new ArgumentException("Invalid parameter", "f"); ;
        }

        /// <summary>
        /// Crea un'istanza dell'adapter per il riferimento a file su filesystem da un'istanza del tipo builtin.
        /// </summary>
        /// <param name="f">Istanza del riferimento a file su filesystem.</param>
        /// <param name="options">Opzioni.</param>
        //public FileInfoAdapter(FileInfo f, params Action<FileInfoAdapter>[] options) {

        //    F = f ?? throw new ArgumentException("Invalid parameter", "f"); ;

        //    foreach (var option in options) {

        //        try {
        //            option.Invoke(this);
        //        }
        //        catch (Exception e) {

        //            throw new ArgumentException($"Could not initialize \"{GetType().Name}\": {e.Message}", e);
        //        }
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public static Action<FileInfoAdapter> OptionOverwriteOnMove() {

        //    return adapter => { adapter._overwriteOnMove = true; };
        //}
    }
}
