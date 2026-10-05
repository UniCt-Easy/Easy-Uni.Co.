using System.Xml;
using System.Collections.Generic;
using System.Linq;

namespace preserve {

    /// <summary>
    /// Estensioni per facilitare l'utilizzo di LINQ su XML.
    /// </summary>
    public static class XmlExtensions {

        /// <summary>
        /// Estrae un'enumerazione di nodi a partire da un nodo radice e un XPath opzionale.
        /// </summary>
        /// <param name="n">Nodo radice.</param>
        /// <param name="path">XPath opzionale dei nodi da estrarre.</param>
        /// <returns>Nodi estratti.</returns>
        public static IEnumerable<XmlNode> Nodes(this XmlNode n, string path = null) => path != null ? n.SelectNodes(path)?.Cast<XmlNode>() : n.ChildNodes.Cast<XmlNode>();
    }
}
