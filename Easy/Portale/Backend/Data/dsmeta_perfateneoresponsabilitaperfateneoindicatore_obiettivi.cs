
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
#pragma warning disable 1591
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data
{
    [Serializable, DesignerCategory("code"), System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
    [System.Xml.Serialization.XmlRoot("dsmeta_perfateneoresponsabilitaperfateneoindicatore_obiettivi"), System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
    public class dsmeta_perfateneoresponsabilitaperfateneoindicatore_obiettivi : DataSet
    {

        #region Table members declaration
        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public MetaTable perfateneoresponsabilita => (MetaTable)Tables["perfateneoresponsabilita"];

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public MetaTable perfateneoresponsabilitaperfateneoindicatore => (MetaTable)Tables["perfateneoresponsabilitaperfateneoindicatore"];

        #endregion


        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables => base.Tables;

        [DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        // ReSharper disable once MemberCanBePrivate.Global
        public new DataRelationCollection Relations => base.Relations;

        [DebuggerNonUserCode]
        public dsmeta_perfateneoresponsabilitaperfateneoindicatore_obiettivi()
        {
            BeginInit();
            initClass();
            EndInit();
        }
        [DebuggerNonUserCode]
        protected dsmeta_perfateneoresponsabilitaperfateneoindicatore_obiettivi(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }
        [DebuggerNonUserCode]
        private void initClass()
        {
            DataSetName = "dsmeta_perfateneoresponsabilitaperfateneoindicatore_obiettivi";
            Prefix = "";
            Namespace = "http://tempuri.org/dsmeta_perfateneoresponsabilitaperfateneoindicatore_obiettivi.xsd";

            #region create DataTables
            //////////////////// PERFATENEORESPONSABILITA /////////////////////////////////
            var tperfateneoresponsabilita = new MetaTable("perfateneoresponsabilita");
            tperfateneoresponsabilita.defineColumn("ct", typeof(DateTime), false);
            tperfateneoresponsabilita.defineColumn("cu", typeof(string), false);
            tperfateneoresponsabilita.defineColumn("idperfateneoresponsabilita", typeof(int), false);
            tperfateneoresponsabilita.defineColumn("lt", typeof(DateTime), false);
            tperfateneoresponsabilita.defineColumn("lu", typeof(string), false);
            tperfateneoresponsabilita.defineColumn("title", typeof(string));
            Tables.Add(tperfateneoresponsabilita);
            tperfateneoresponsabilita.defineKey("idperfateneoresponsabilita");

            //////////////////// PERFATENEORESPONSABILITAPERFATENEOINDICATORE /////////////////////////////////
            var tperfateneoresponsabilitaperfateneoindicatore = new MetaTable("perfateneoresponsabilitaperfateneoindicatore");
            tperfateneoresponsabilitaperfateneoindicatore.defineColumn("ct", typeof(DateTime), false);
            tperfateneoresponsabilitaperfateneoindicatore.defineColumn("cu", typeof(string), false);
            tperfateneoresponsabilitaperfateneoindicatore.defineColumn("idperfateneoindicatore", typeof(int), false);
            tperfateneoresponsabilitaperfateneoindicatore.defineColumn("idperfateneoobiettivo", typeof(int), false);
            tperfateneoresponsabilitaperfateneoindicatore.defineColumn("idperfateneoresponsabilita", typeof(int), false);
            tperfateneoresponsabilitaperfateneoindicatore.defineColumn("idperfvalutazioneateneo", typeof(int), false);
            tperfateneoresponsabilitaperfateneoindicatore.defineColumn("lt", typeof(DateTime), false);
            tperfateneoresponsabilitaperfateneoindicatore.defineColumn("lu", typeof(string), false);
            Tables.Add(tperfateneoresponsabilitaperfateneoindicatore);
            tperfateneoresponsabilitaperfateneoindicatore.defineKey("idperfateneoindicatore", "idperfateneoobiettivo", "idperfateneoresponsabilita", "idperfvalutazioneateneo");

            #endregion


            #region DataRelation creation
            var cPar = new[] { perfateneoresponsabilita.Columns["idperfateneoresponsabilita"] };
            var cChild = new[] { perfateneoresponsabilitaperfateneoindicatore.Columns["idperfateneoresponsabilita"] };
            Relations.Add(new DataRelation("FK_perfateneoresponsabilitaperfateneoindicatore_perfateneoresponsabilita_idperfateneoresponsabilita", cPar, cChild, false));

            #endregion

        }
    }
}
