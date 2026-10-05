namespace preserve.Storage {

    /// <summary>
    /// Riferimento ad un file.
    /// </summary>
    public interface IFileReference {

        /// <summary>
        /// Nome del riferimento al file.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Nome completo del riferimento al file.
        /// </summary>
        string FullName { get; }
        /// <summary>
        /// Container del riferimento al file.
        /// </summary>
        IFileReferenceContainer Container { get; }

        /// <summary>
        /// Sposta il riferimento ad un file su un altro riferimento.
        /// </summary>
        /// <param name="destFileName">Nome completo del riferimento al file destinazione.</param>
        void MoveTo(string destFileName);
    }
}
