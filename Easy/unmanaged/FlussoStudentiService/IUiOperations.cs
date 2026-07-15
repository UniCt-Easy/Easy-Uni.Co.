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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlussoStudentiService
{
    public interface IUiOperations
    {
        // Gestione visibilità generica
        void SetControlVisibility(string controlName, bool visible);
        bool GetControlVisibility(string controlName);

        // Gestione specifica per tipi di controllo
        void SetButtonEnabled(string buttonName, bool enabled);
        void SetText(string controlName, string text);
        string GetText(string controlName);
        bool GetChecked(string controlName);
        void SetDataGrid(string controlName, DataTable table);
        void DataGridSelectAllRows(string controlName, DataRowCollection rows);
        DataRow[] GetDataGridSelectedRow(string controlName);
        // Progresso operazioni
        void InitProgress(int max);
        void UpdateProgress(int value);

        // Altri metodi utility
        void DoEvents();
    }
}
