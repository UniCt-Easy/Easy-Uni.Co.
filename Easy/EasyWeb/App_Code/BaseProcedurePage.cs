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
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Newtonsoft.Json;

using metadatalibrary;
using EasyWebReport;

/// <summary>
/// Summary description for BaseProcedurePage
/// </summary>
public abstract class BaseProcedurePage : Page {
    /// <summary>
    /// Database schema.
    /// </summary>
    protected abstract string Schema { get; }
    /// <summary>
    /// Stored Procedure name.
    /// </summary>
    protected abstract string ProcName { get; }
    /// <summary>
    /// Parameter names (keys).
    /// </summary>
    protected abstract string[] ProcParamNames { get; }
    /// <summary>
    /// Whether or not to show the parameters values input form.
    /// </summary>
    protected abstract bool UseParametersForm { get; }
    /// <summary>
    /// ID of the container in which to render the HTML.
    /// </summary>
    protected abstract string OutputContainerID { get; }

    /// <summary>
    /// Container in which to render the HTML
    /// </summary>
    private HtmlGenericControl _outputContainer;

    /// <summary>
    /// Function used to retrieve param values given their keys.
    /// </summary>
    private Func<string[], object[]> _procParamsExtractor => (paramNames) => {

        var paramValues = new List<object>();

        foreach (var paramName in paramNames) {

            try {

                var value = Request[paramName];

                if (value == null) {

                    var control = FindControl(paramName) as TextBox;
                    value = control?.Text;
                }

                paramValues.Add(value);
            }
            catch (Exception ex) {

                throw new InvalidOperationException($"Error extracting parameter '{paramName}'", ex);
            }
        }

        return paramValues.ToArray();
    };

    /// <summary>
    /// Rendering formats.
    /// </summary>
    public enum TRenderingFormat {
        datatableshtml,
        html,
        json,
        xml
    }

    /// <summary>
    /// Mappings between rendering formats and rendering methods.
    /// </summary>
    private static Dictionary<TRenderingFormat, Action<List<DataTable>>> _renderingMethods = new Dictionary<TRenderingFormat, Action<List<DataTable>>>();

    /// <summary>
    /// Prefixes for column names of columns which should not be rendered.
    /// </summary>
    public static readonly string[] ExcludedColPrefixes = { "id" };

    /// <summary>
    /// Names of columns which should not be rendered.
    /// </summary>
    public static readonly string[] ExcludedColNames = { "ct", "cu", "lt", "lu" };

    /// <summary>
    /// Decides whether or not a DataColumn should be rendered.
    /// </summary>
    /// <param name="col">Column that should be rendered or not.</param>
    /// <returns></returns>
    public static bool ShouldRender(DataColumn col) =>
        !ExcludedColPrefixes.Any(prefix =>
            col.ColumnName.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) &&
        !ExcludedColNames.Any(name =>
            string.Equals(name, col.ColumnName, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Initializes an instance of the page.
    /// </summary>
    public BaseProcedurePage() {

        _renderingMethods = new Dictionary<TRenderingFormat, Action<List<DataTable>>>() {
            { TRenderingFormat.html, ToHtml },
            { TRenderingFormat.json, ToJsons },
            { TRenderingFormat.xml, ToXmls }
        };
    }

    /// <summary>
    /// Responds with an error message.
    /// </summary>
    /// <param name="message"></param>
    new void Error(string message) {

        Page.Response.ContentType = "text/plain";
        Page.Response.ClearContent();
        Page.Response.Write(message);
        Page.Response.End();
    }

    /// <summary>
    /// Opens a connection to the intermediate database.
    /// </summary>
    /// <returns></returns>
    DataAccess GetDepartmentConn() {

        DataSet Cfg = GetVars.GetConfigDataSet(this);
        if (Cfg.Tables[0].Rows.Count == 0) {
            Error("Servizio non installato correttamente. Manca il file di configurazione.");
            return null;
        }
        string error;
        DataAccess Conn = GetVars.GetSystemDataAccess(this, out error);
        if (Conn == null) {
            Error("Connessione al db di sistema non riuscita.");
            return null;
        }
        var res = GetDepAccess(Conn);
        Conn.Destroy();
        return res;
    }

    /// <summary>
    /// Opens a connection to the final database. 
    /// </summary>
    /// <param name="Conn"></param>
    /// <returns></returns>
    DataAccess GetDepAccess(DataAccess Conn) {

        QueryHelper QHS = Conn.GetQueryHelper();

        string filterdip = QHS.CmpEq("codicedipartimento", Schema);
        DataTable CodDip = Conn.RUN_SELECT("codicidipartimenti", "*", null, filterdip, null, true);

        if ((CodDip == null) || (CodDip.Rows.Count == 0)) {
            //Dati non corretti
            Error($"'{Schema}': Codice non corretto");
            return null;
        }
        if (CodDip.Rows.Count > 1) {
            //Attenzione nel DB non è garantita l'unicità dei dati.
            Error($"Attenzione !!! Duplicazione di codici per '{Schema}'");
            return null;
        }

        string err;
        DataRow myDr = CodDip.Rows[0];
        //Session["Dipartimento"] = myDr["Dipartimento"].ToString();


        //Creo la connessione.
        DataAccess UsrConn = GetVars.CreateUserConn(this, myDr, null, null, DateTime.Now, out err);
        if (UsrConn == null) {
            Error($"Connessione al db del dipartimento '{Schema}' non riuscita. ");
            return null;
        }

        return UsrConn;
    }

    /// <summary>
    /// Retrieves the output tables from the stored procedure.
    /// </summary>
    /// <returns>Tables with SP output data.</returns>
    private List<DataTable> GetTables() {

        DataSet ds = new DataSet();

        object[] procParameterValues = new object[] { };

        try {

            procParameterValues = _procParamsExtractor.Invoke(ProcParamNames);
        }
        catch (Exception e) {

            throw new Exception("Errore durante la valutazione dei parametri.", e);
        }

        //var sql = $"select * from corsostudiodefaultview cs;";

        string error = string.Empty;

        using (var Conn = GetDepartmentConn()) {

            //ds = Conn.CallSP("sp_executesqlwrapper", new object[] { sql }, 3000, out error);

            ds = Conn.CallSP(ProcName, procParameterValues, 3000, out error);
        }

        if (!string.IsNullOrWhiteSpace(error)) {

            throw new Exception("Errore durante l'accesso ai dati.", new Exception(error));
        }

        if (ds == null || ds.Tables.Count < 1) {

            throw new Exception("Nessun dato presente.");
        }

        return ds.Tables.Cast<DataTable>().ToList();
    }

    /// <summary>
    /// Renders the data.
    /// </summary>
    protected void RenderOutput() {

        _outputContainer = FindControl(OutputContainerID) as HtmlGenericControl;

        if (_outputContainer == null) {

            throw new Exception($"Invalid output control ID specified '{OutputContainerID}'");
        }

        TRenderingFormat format = Enum.TryParse(Request["format"], true, out format) ? format : TRenderingFormat.html; // default tabella

        try {
            var tables = GetTables();
            _renderingMethods[format].Invoke(tables); // renderizziamo
        }
        catch (Exception e) {

            Error(e.Message);
            return;
        }
    }

    /// <summary>
    /// Renders the data as HTML.
    /// </summary>
    /// <param name="dts"></param>
    private void ToHtml(List<DataTable> dts) {

        if (dts.Count == 0) return;

        var mainTable = dts.First();
        var detailTables = dts.Skip(1).ToList();

        _outputContainer.Controls.Clear();

        // Main Table Wrapper
        var mainTableWrapper = new HtmlGenericControl("div");
        mainTableWrapper.Attributes["class"] = "table-responsive mb-4";

        var htmlMainTable = new Table {
            ID = "main",
            CssClass = "datatable table table-bordered table-hover"
        };

        var htmlMainTableHeader = new TableHeaderRow();
        foreach (DataColumn col in mainTable.Columns) {
            if (!ShouldRender(col)) continue;

            var headerCell = new TableHeaderCell {
                Text = col.ColumnName
            };
            htmlMainTableHeader.Cells.Add(headerCell);
        }
        htmlMainTable.Rows.Add(htmlMainTableHeader);

        foreach (DataRow row in mainTable.Rows) {
            string idgroup = row["idgroup"].ToString();

            var htmlMainTableRow = new TableRow {
                Attributes = {
                    ["style"] = "cursor:pointer",
                    ["onclick"] = $"toggleDetail('detail_group_{idgroup}', this)",
                    ["class"] = "table-row"
                }
            };

            foreach (DataColumn col in mainTable.Columns) {
                if (!ShouldRender(col)) continue;

                var cell = new TableCell {
                    Text = row[col].ToString()
                };
                htmlMainTableRow.Cells.Add(cell);
            }

            htmlMainTable.Rows.Add(htmlMainTableRow);
        }

        mainTableWrapper.Controls.Add(htmlMainTable);
        _outputContainer.Controls.Add(mainTableWrapper);

        // Detail Tables
        foreach (var detailTable in detailTables) {
            if (!detailTable.Columns.Contains("idgroup")) continue;

            var groupedRows = detailTable.AsEnumerable()
                .GroupBy(row => row["idgroup"].ToString());

            foreach (var group in groupedRows) {
                var groupId = group.Key;

                var detailDiv = new HtmlGenericControl("div") {
                    ID = $"detail_group_{groupId}"
                };
                detailDiv.Attributes["class"] = "card mb-4";
                detailDiv.Attributes["style"] = "display:none";

                var cardBody = new HtmlGenericControl("div");
                cardBody.Attributes["class"] = "card-body";

                var groupLabel = new HtmlGenericControl("h5") {
                    InnerText = $"Gruppo {groupId}"
                };
                groupLabel.Attributes["class"] = "text-primary mb-3";
                cardBody.Controls.Add(groupLabel);

                var tableWrapper = new HtmlGenericControl("div");
                tableWrapper.Attributes["class"] = "table-responsive";

                var htmlGroupTable = new Table {
                    ID = $"detail_{groupId}",
                    CssClass = "datatable-lib table table-bordered table-striped"
                };

                var htmlGroupTableHeader = new TableHeaderRow();
                foreach (DataColumn col in detailTable.Columns) {
                    if (!ShouldRender(col)) continue;

                    var headerCell = new TableHeaderCell {
                        Text = col.ColumnName
                    };
                    htmlGroupTableHeader.Cells.Add(headerCell);
                }
                htmlGroupTable.Rows.Add(htmlGroupTableHeader);

                foreach (var row in group) {
                    var htmlGroupTableRow = new TableRow();
                    foreach (DataColumn col in detailTable.Columns) {
                        if (!ShouldRender(col)) continue;

                        var cell = new TableCell {
                            Text = row[col].ToString()
                        };
                        htmlGroupTableRow.Cells.Add(cell);
                    }
                    htmlGroupTable.Rows.Add(htmlGroupTableRow);
                }

                tableWrapper.Controls.Add(htmlGroupTable);
                cardBody.Controls.Add(tableWrapper);
                detailDiv.Controls.Add(cardBody);
                _outputContainer.Controls.Add(detailDiv);
            }
        }
    }

    /// <summary>
    /// Renders the data as JSON.
    /// </summary>
    /// <param name="dts"></param>
    private void ToJsons(List<DataTable> dts) {

        Response.Clear();
        Response.ContentType = "application/json";
        Response.Write(JsonConvert.SerializeObject(dts));

        Response.Flush();
        Response.End();
    }

    /// <summary>
    /// Renders the data as XML.
    /// </summary>
    /// <param name="dts"></param>
    private void ToXmls(List<DataTable> dts) {

        throw new NotImplementedException();

        //Response.Clear();
        //Response.ContentType = "application/xml";

        //foreach (var dt in dts) {
        //    dt.WriteXml(Response.OutputStream, XmlWriteMode.WriteSchema, false);
        //}

        //Response.Flush();
        //Response.End();
    }

    protected override void OnInitComplete(EventArgs e) {

        base.OnInitComplete(e);

        var parametersForm = FindControl("parameters") as HtmlForm;

        if (parametersForm != null)
            parametersForm.Visible = UseParametersForm;
    }

    protected override void OnUnload(EventArgs e) {

        GetVars.clearSystemDataAccess(this);
        base.OnUnload(e);
    }

    protected override void SavePageStateToPersistenceMedium(object state) {

        Session["VSTATE"] = state;
    }

    protected override object LoadPageStateFromPersistenceMedium() {

        return Session["VSTATE"];
    }
}
