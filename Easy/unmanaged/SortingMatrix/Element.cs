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
using System.Drawing;
using System.Windows.Forms;

namespace SortingMatrix {

    /// <summary>
    /// Rappresenta una coppia di controlli che esprimono la descrizione e il valore di una entità.
    /// La descrizione è espressa tramite una Label.
    /// </summary>
    /// <typeparam name="TControl">Tipo di controllo contenente il valore dell'entità.</typeparam>
    public class Element<TControl> where TControl : Control, new() {

        /// <summary>
        /// Identificatore della coppia di controlli.
        /// </summary>
        private readonly Key identifier;

        /// <summary>
        /// Default per l'allineamento della Label contenente la descrizione.
        /// </summary>
        private ContentAlignment descriptionContainerTextAlign = ContentAlignment.BottomLeft;

        /// <summary>
        /// Default per lo stile del bordo della Label contenente la descrizione.
        /// </summary>
        private BorderStyle descriptionBorderStyle = BorderStyle.None;

        /// <summary>
        /// Default per la larghezza dei controlli.
        /// </summary>
        private int width = new TControl().Width;

        /// <summary>
        /// Label contenente la descrizione dell'entità.
        /// </summary>
        public Label DescriptionContainer { get; }

        /// <summary>
        /// Controllo contenente il valore dell'entità.
        /// </summary>
        public TControl ValueContainer { get; }

        /// <summary>
        /// Posizione della coppia di controlli. La Label è posta sul controllo che contiene il valore, e determina questa posizione.
        /// </summary>
        public Point Location => DescriptionContainer.Location;
        
        /// <summary>
        /// Dimensione della coppia di controlli.
        /// </summary>
        public Size Size => new Size(Math.Max(DescriptionContainer.Size.Width, ValueContainer.Size.Width), DescriptionContainer.Size.Height + ValueContainer.Size.Height);

        /// <summary>
        /// Inizializza una coppia di controlli vuota.
        /// </summary>
        public Element() {

            DescriptionContainer = new Label();
            ValueContainer = new TControl();
        }

        /// <summary>
        /// Inizializza una coppia di controlli e ne imposta le proprietà in base ad un nome entità, un descrittore delle caratteristiche ed una serie di opzioni.
        /// </summary>
        /// <param name="entityName">Nome dell'entità, utilizzato per la creazione del tag del controllo che gestisce il valore.</param>
        /// <param name="id">Identificatore della coppia di controlli.</param>
        /// <param name="features">Descrittore delle caratteristiche della coppia di controlli.</param>
        /// <param name="options">Opzioni per la creazione della coppia di controlli.</param>
        public Element(string entityName, Key id, Descriptor features, params Action<Element<TControl>>[] options) {

            identifier = id;

            // esecuzione delle Action (opzioni funzionali) che vanno a modificare la configurazione dell'Element
            foreach (Action<Element<TControl>> option in options) {

                try {
                    option.Invoke(this);    // chiamata alla Invoke della Action che opera sul nostro oggetto (equivale a option(this), usiamo la Invoke per maggiore chiarezza)
                }
                catch (Exception e) {
                    throw new Exception($"can't initialize {GetType().Name}: {e.Message}", e);
                }
            }

            DescriptionContainer = new Label {
                Text = features.label,
                TextAlign = descriptionContainerTextAlign,
                BorderStyle = descriptionBorderStyle,
                Width = width,
            };

            ValueContainer = new TControl {
                Location = new Point(0, 0),
                Name = (typeof(TControl).Name + identifier.ToString()).ToLowerInvariant(),
                //valueContainer.Text = string.Empty;
                //valueContainer.TabIndex = 0;
                Tag = string.Join(".", entityName, "value" + identifier.ToString()).ToLowerInvariant(),
                Enabled = !features.locked,
                Width = width,
            };
        }

        /// <summary>
        /// Sposta la coppia di controlli alla destinazione indicata.
        /// </summary>
        /// <param name="p">Destinazione.</param>
        public void Relocate(Point p) {
            DescriptionContainer.Location = p;
            ValueContainer.Location = new Point(p.X, p.Y + DescriptionContainer.Size.Height);
        }

        /// <summary>
        /// Imposta l'allineamento del testo della Label della coppia di controlli.
        /// </summary>
        /// <param name="c">Allineamento da impostare</param>
        /// <returns>Action che modifica la configurazione della coppia di controlli</returns>
        public static Action<Element<TControl>> OptionDescriptionAlignment(ContentAlignment c) {
            return (Element<TControl> e) => {
                e.descriptionContainerTextAlign = c;
            };
        }

        /// <summary>
        /// Imposta lo stile del bordo sulla Label della coppia di controlli.
        /// </summary>
        /// <param name="b">Stile del bordo da impostare</param>
        /// <returns>Action che modifica la configurazione della coppia di controlli</returns>
        public static Action<Element<TControl>> OptionDescriptionBorderStyle(BorderStyle b) {
            return (Element<TControl> e) => {
                e.descriptionBorderStyle = b;
            };
        }

        /// <summary>
        /// Imposta la posizione della coppia di controlli.
        /// </summary>
        /// <param name="p">Posizione della coppia di controlli</param>
        /// <returns>Action che modifica la configurazione della coppia di controlli</returns>
        public static Action<Element<TControl>> OptionLocation(Point p) {
            return (Element<TControl> e) => e.Relocate(p);
        }

        /// <summary>
        /// Imposta la larghezza della coppia di controlli.
        /// </summary>
        /// <param name="p">Larghezza della coppia di controlli</param>
        /// <returns>Action che modifica la configurazione della coppia di controlli</returns>
        public static Action<Element<TControl>> OptionWidth(int w) {
            return (Element<TControl> e) => e.width = w;
        }
    }
}
