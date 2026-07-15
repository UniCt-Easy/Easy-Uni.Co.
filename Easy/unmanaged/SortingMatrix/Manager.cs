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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SortingMatrix {

    /// <summary>
    /// Direzione di accrescimento.
    /// </summary>
    public enum TGrowth {
        Vertical,
        Horizontal
    }

    /// <summary>
    /// Gestisce un set di controlli in base a un descrittore espresso in una DataRow e li posiziona in un GroupBox.
    /// </summary>
    /// <typeparam name="TControl">Tipo di controlli da gestire nella matrice.</typeparam>
    public class Manager<TControl> where TControl : Control, new() {

        /// <summary>
        /// Definizione degli elementi contenuti nella matrice.
        /// </summary>
        private readonly List<Element<TControl>> elements;

        /// <summary>
        /// GroupBox gestito.
        /// </summary>
        private readonly GroupBox groupBox;

        /// <summary>
        /// Nome dell'entità usato per la creazione dei tag.
        /// </summary>
        private readonly string entityName;

        /// <summary>
        /// Dimensioni massime della matrice di controlli.
        /// </summary>
        private Size limit = new Size(0, 0);

        /// <summary>
        /// Direzione di crescita della matrice di controlli.
        /// </summary>
        private TGrowth growth = TGrowth.Vertical;

        /// <summary>
        /// Default per il padding utilizzato tra i controlli.
        /// </summary>
        private Size padding = new Size(7, 7);

        /// <summary>
        /// Azione da eseguire sui controlli al momento della creazione.
        /// </summary>
        private Action<Control> controlAction;

        /// <summary>
        /// Textbox di debug.
        /// </summary>
        private TextBox debug;

        /// <summary>
        /// Istanzia un gestore del set di controlli in base a un descrittore espresso in una DataRow e li posiziona in un GroupBox.
        /// I tag dei controlli sono costruiti in base al nome dell'entità specificata.
        /// E' possibile configurare il gestore utilizzando i metodi statici OptionX.
        /// </summary>
        /// <param name="gb">GroupBox da gestire.</param>
        /// <param name="entity">nome dell'entità da utilizzare per la costruzione dei tag dei controlli.</param>
        /// <param name="sortingkind">DataRow che descrive i comportamenti dei controlli.</param>
        /// <param name="options">Opzioni da impostare sul gestore.</param>
        public Manager(GroupBox gb, string entity, DataRow sortingkind, params Action<Manager<TControl>>[] options) {

            entityName = entity;
            groupBox = gb;

            gb.Text = string.Empty;
            gb.Visible = false;
            gb.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            SortingKind<TField, Descriptor> definition = new SortingKind<TField, Descriptor>(sortingkind);

            elements = definition.AdditionalFields.Select(
                field => new Element<TControl>(
                    entityName,
                    field.Key,      // identificatore del campo
                    field.Value,    // descrittore del campo
                    Element<TControl>.OptionDescriptionAlignment(ContentAlignment.MiddleLeft),
                    Element<TControl>.OptionWidth(100)
                )
            ).Where(e => !string.IsNullOrWhiteSpace(e.DescriptionContainer.Text)).ToList();

            // esecuzione delle Action (opzioni funzionali) che vanno a modificare la configurazione del Manager
            foreach (Action<Manager<TControl>> option in options) {

                try {
                    option.Invoke(this);    // chiamata alla Invoke della Action che opera sul nostro oggetto (equivale a option(this), usiamo la Invoke per maggiore chiarezza)
                }
                catch (Exception e) {
                    throw new Exception($"can't initialize {GetType().Name}: {e.Message}", e);
                }
            }

            Reorganize();
        }

        /// <summary>
        /// Organizza i controlli nel GroupBox gestito ricostruendoli dalla definizione e ridimensiona il contenitore del GroupBox gestito.
        /// </summary>
        public void Reorganize() {

            groupBox.Parent.SuspendLayout();
            groupBox.SuspendLayout();

            groupBox.Controls.Clear();

            if (elements.Any()) {

                Size matrixSize;

                if (limit == default) {
                    var squareDimension = Convert.ToInt32(Math.Floor(Math.Sqrt(elements.Count())) + 1);
                    matrixSize = new Size(squareDimension, squareDimension);
                }
                else {
                    matrixSize = limit;
                }

                int constraint = growth == TGrowth.Vertical ? matrixSize.Height : matrixSize.Width;
                int n = 1;

                foreach (var element in elements) {

                    if (string.IsNullOrWhiteSpace(element.DescriptionContainer.Text)) {
                        continue;
                    }

                    int i = (n - 1) / constraint;
                    int j = (n - 1) % constraint;

                    Point newPosition = new Point(padding.Width * 2 + (i * (element.Size.Width + padding.Width)), padding.Height * 2 + (j * (element.Size.Height + padding.Height)));

                    groupBox.Controls.AddRange(new Control[] { element.ValueContainer, element.DescriptionContainer });

                    element.Relocate(newPosition);

                    try {
                        controlAction?.Invoke(element.ValueContainer);
                    }
                    catch (Exception e) {
                        throw new Exception($"could not execute Action on {element.ValueContainer.Name}: {e.Message}", e);
                    }

                    n++;
                }

                groupBox.Size = new Size(elements.Max(e => e.Location.X + e.Size.Width), elements.Max(e => e.Location.Y + e.Size.Height)) + new Size(padding.Height * 2, padding.Width * 2);
                groupBox.Visible = true;
            }

            groupBox.ResumeLayout(true);
            groupBox.Parent.ResumeLayout(true);

            // !!! DISABILITATO PER ORA !!!

            //var formVisibleControls = groupBox.Parent.Controls.Cast<Control>()/*.Where(control => control.Visible)*/;

            //int fittingWidth = formVisibleControls.Max(control => control.Location.X + control.Size.Width);
            //int fittingHeight = formVisibleControls.Max(control => control.Location.Y + control.Size.Height);

            //var oldSize = groupBox.Parent.Size;

            //groupBox.Parent.Size = new Size(fittingWidth + 2 * padding.Width, fittingHeight + 2 * padding.Height);

            //if (debug != null) {
            //    debug.Text = string.Join("\r\n", $"fittingWidth: {fittingWidth}", $"fittingHeight: {fittingHeight}", $"padding: {padding}", $"groupBox.Parent.Size: {groupBox.Parent.Size}", $"oldSize: {oldSize}");
            //}
        }

        /// <summary>
        /// Imposta sul Manager un limite di dimensioni in termini di dimensioni della matrice di controlli. Una dimensione (0, 0) rimuove il limite.
        /// </summary>
        /// <param name="s">Dimensione della matrice di controlli.</param>
        /// <returns>Action che modifica la configurazione del Manager.</returns>
        public static Action<Manager<TControl>> OptionLimit(Size s) {
            return (Manager<TControl> m) => {

                int numElements = m.elements.Count;
                int constraint = s.Width * s.Height;

                if (constraint != 0 && numElements > constraint) {
                    throw new InvalidConstraintException($"size of {s.Width} x {s.Height} ({constraint}) cannot contain {numElements} elements");
                }

                m.limit = s;
            };
        }

        /// <summary>
        /// Imposta sul Manager il tipo di crescita della matrice di controlli.
        /// </summary>
        /// <param name="g">Tipo di crescita della matrice di controlli.</param>
        /// <returns>Action che modifica la configurazione del Manager.</returns>
        public static Action<Manager<TControl>> OptionGrowth(TGrowth g) {
            return (Manager<TControl> m) => {
                m.growth = g;
            };
        }

        /// <summary>
        /// Imosta sul Manager il padding da utilizzare tra i controlli della matrice.
        /// </summary>
        /// <param name="s">Dimensione del padding.</param>
        /// <returns>Action che modifica la configurazione del Manager.</returns>
        public static Action<Manager<TControl>> OptionPadding(Size s) {
            return (Manager<TControl> m) => {
                m.padding = s;
            };
        }

        /// <summary>
        /// Imposta sul Manager l'operazione da eseguire su ogni controllo TControl gestito dal Manager.
        /// </summary>
        /// <param name="ca">Action da eseguire su ogni controllo TControl gestito dal Manager.</param>
        /// <returns>Action che modifica la configurazione del Manager.</returns>
        public static Action<Manager<TControl>> OptionControlAction(Action<Control> ca) {
            return (Manager<TControl> m) => {
                m.controlAction = ca;
            };
        }

        /// <summary>
        /// Imposta sul Manager un TextBox da utilizzare per visualizzare del testo di debug.
        /// </summary>
        /// <param name="t">TextBox da utilizzare per visualizzare del testo di debug.</param>
        /// <returns>Action che modifica la configurazione del Manager.</returns>
        public static Action<Manager<TControl>> OptionDebug(TextBox t) {
            return (Manager<TControl> m) => {
                m.debug = t;
            };
        }
    }
}
