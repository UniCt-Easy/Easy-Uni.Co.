
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


const express = require('express');
const router = express.Router();
const fs = require('fs');
const postData = require('jsPostData');
const dbconn = require('../../dbconn/dbconn');
const Environment = require('../fake/fakeEnvironment');
const Deferred = require("jsDeferred");
const getDataUtils = appMeta.getDataUtils;
const datasetUtils = require('../utils/datasetUtils');
/**
 * Read json dataset form keys tableName and edittype and a filter. It populates the rows based on that main row
 * @type {path.PlatformPath | path}
 */
const path = require('path');
router.post('/', (req, res, next) => {

    const tableName = req.body.tableName;
    const editType = req.body.editType;
    const dsPrm = req.body.ds;
    const messagesPrm = req.body.messages;
    // deserialize messages
    let messages = !!messagesPrm ? JSON.parse(messagesPrm) : [];
    // deserialize
    const ds = getDataUtils.getJsDataSetFromJson(dsPrm);

    //1. leggo ds originale backend e metto in sicurezza il ds client a partire dal be
    const dsSafe = datasetUtils.createAndGetEmptyDataSet(tableName, editType);
    datasetUtils.makeSafeDataSet(ds, dsSafe);

    // 2. calculates the isValid. They are deferred
    var allDeferredIsValid = getIsValidDeferred(ds);

    // 3. resolve the async isValid
    Deferred.when.apply(Deferred, allDeferredIsValid)
        .then(function() {

            // calculates the error message . TODO enable and test following tcode
          /*  var mandatoryMsgs = _.reduce(arguments,
                function(acc, defObj) {
                    // se è null significa che la isValid era ok quindi non è un defObj Mandatorio
                    if (defObj) {
                        const message = new appMeta.DbProcedureMessage(1, defObj.errMsg, 'audit', 'BL server validation', defObj.tableName, true);
                        acc.push(message);
                    }
                    return acc;
                }, []);

            // returns error message to the client
            if (mandatoryMsgs.length) {
                // concat with other errors already present
                messages = messages.concat(mandatoryMsgs);
                return sendResponseToClient(res, ds, messages, false, false);
            }*/

            // calls access data layer to save dataset. It does pre and post check.
            dbconn.getDataAccess()
                .then((DAC) => {
                    const ctx = {dataAccess: DAC};
                    const pd = new postData.PostData(DAC, new Environment());
                    const changes = pd.changeList(ds);
                    const opt = {
                        getChecks: function () {
                            var def = Deferred(),
                                res = {checks: [], shouldContinue: true};
                            def.resolve(res);
                            return def.promise();
                        },
                        optimisticLocking: new jsDataSet.OptimisticLocking(['lt', 'lu'], ['ct', 'cu', 'lt', 'lu'])
                    };
                    // per vedere la query -> riga 743 di jsPostData
                    pd.doPost(changes, opt)
                        .always(() => {
                            sendResponseToClient(res, ds, messages, true, true);
                        });
                }, err =>  res.status(500).json("conn to DataAccess failed: " + err));

        });
});

/**
 * Send the saveDataset response to the client
 * @param res
 * @param {jsDataSet} ds
 * @param {Array} messages
 * @param {boolean} success
 * @param {boolean} canignore
 */
sendResponseToClient = (res, ds, messages, success, canignore) => {
    // 1. serialize dataset
    let dsSer = getDataUtils.getJsonFromJsDataSet(ds, true);
    // 3. serialize the response object to the client with the al infos
    const obj = JSON.stringify({
        dataset : dsSer,
        messages : messages,
        success : success,
        canignore: canignore
    });
    res.status(200).json(obj);
};

/**
 * Return an array of Deferred
 * @param {object} dsPrm, json of dataset
 */
getIsValidDeferred = (ds) => {
    const allDeferredIsValid = [];
    _.forEach(ds.tables, (dt) => {
        const currMeta = appMeta.getMeta(dt.name);
        _.forEach(dt.rows,  (r) => {
            if (r.getRow().state !== global.dataRowState.unchanged &&
                r.getRow().state !== global.dataRowState.delete) {
                // invoke the isValid of current table. attach the tableName to result
                const defIsValid = currMeta.isValid(r.getRow())
                    .then((defObj) => {
                        if (defObj) {
                            defObj.tableName = dt.name;
                        }
                        return defObj;
                    });

                allDeferredIsValid.push(defIsValid);
            }
        });
    });
    return allDeferredIsValid;
};

module.exports = router;
