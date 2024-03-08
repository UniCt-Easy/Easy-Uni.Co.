const express = require('express');
const router = express.Router();
const dbconn = require('../../dbconn/dbconn');
const dbconnutils = require('../../dbconn/dbconnutils');
const Deferred = require("jsDeferred");
const mSel = require('jsMultiSelect');
const Select = mSel.Select;

/**
 * Read an array with info o n queries, and return a dataset
 * @type {path.PlatformPath | path}
 */
const path = require('path');
router.post('/', (req, res, next) => {
    const selBuilderArr = req.body.selBuilderArr;
    let selObjArray = JSON.parse(selBuilderArr);
    // crea dataset di ritorno
    const dsTemp = jsDataSet.DataSet("temp");
    const chain = multiRunSelect(selObjArray.arr, dsTemp);
    chain.then(function () {
        let json = appMeta.getDataUtils.getJsonFromJsDataSet(dsTemp, true);
        res.status(200).json(json);
    });

    // ----> DAC.multiSelect non funziona. fatta come sopra con la chain si
  /*    _.forEach(arr, (sel) => {
        const filterJsDataQuery = appMeta.getDataUtils.getJsDataQueryFromJson(sel.filter);
        const s = new Select('*').from(sel.tableName).where(filterJsDataQuery).intoTable(sel.tableName);
        multiSel.push(s);
    });

    const dsTemp = jsDataSet.DataSet("temp");

    // prendo connessione
    dbconn.getDataAccess().done((DAC) => {
              const mSel = DAC.multiSelect({selectList: multiSel, raw:true});
              mSel.progress(function (result) {
                    const t = dsTemp.newTable(result.tableName);
                    t.rows = result.rows;
                });

                mSel.done(function (result) {
                    let json = appMeta.getJsonFromJsDataSet(dsTemp, true);
                    res.status(200).json(json);
                });

                mSel.fail(function (err) {
                    res.status(500).json(err);
                });

        }).fail(function (err) {
            res.status(500).json("coon to DataAccess failed: " + err);
        });*/

});

/**
 *
 * @param {Object} selObjArray { filter: string, top: number, tableName: string, table: DataTable }
 * @param {DataSet} dsTemp
 * @returns {Promise.Deferred} return DataSet
 */
multiRunSelect = (selObjArray, dsTemp) => {
    let arr = selObjArray;
    const $ = Deferred;
    const connection = dbconn.getConnection();
    let chain = $.when();
    // esegue loop, costruisce query, lancia e popola dataTable con le righe tornate
    _.forEach(arr, (sel) => {
        let filter = dbconnutils.getSqlFilterFromJsDataQueryJson(sel.filter);
        const options = {tableName: sel.tableName, columns:'*', filter, top: sel.top};
        const query = connection.getSelectCommand(options);
        const t = dsTemp.newTable(sel.tableName);
        chain = chain.then(function () {
            return connection.queryBatch(query).then((res) => {
                t.loadArray(res);
            });
        })
    });
    return chain;
};

module.exports = router;
module.exports.multiRunSelect = multiRunSelect;
