
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


/**
 * @module DbProcedureMessage
 * @description
 * Contains a model for a database message object.
 */
(function () {

    /**
     * @constructor DbProcedureMessage
     * @description
     * Accepts all the parameters to build a model for a database message object.
     * @param {String} id
     * @param {String} description
     * @param {String} audit
     * @param {String} severity
     * @param {String} table
     * @param {Boolean} canIgnore
     */
    function DbProcedureMessage(id, description, audit, severity, table, canIgnore) {
        if (this.constructor !== DbProcedureMessage) {
            return new DbProcedureMessage(id, description, audit, severity, table, canIgnore);
        }
        this.id = id; // pre_post + "/" + pm.TableName + "/" + pm.Operation.Substring(0, 1) + "/" + pm.EnforcementNumber.ToString() || dberror
        this.description = description;
        this.audit = audit;
        this.severity = severity; // "Errore" || "Avvertimento" || "Disabilitata"
        this.table = table;
        this.canIgnore = canIgnore; // true/false
        return this;

    }

    DbProcedureMessage.prototype = {
        constructor: DbProcedureMessage
    };

    appMeta.DbProcedureMessage = DbProcedureMessage;

}());
