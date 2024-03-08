const express = require('express');
const router = express.Router();
const dbconnutils = require('../../dbconn/dbconnutils');

/**
 * Read a datatable filtering result, based on passed prms.
 * @type {path.PlatformPath | path}
 */
const path = require('path');
router.post('/', (req, res, next) => {

    const tableName = req.body.tableName;
    const columns = req.body.columnList;
    const filter = req.body.filter;
    const top = req.body.top;
    let filterSql = dbconnutils.getSqlFilterFromJsDataQueryJson(filter);
    dbconnutils.runSelect(tableName, columns, filterSql, top)
        .then((result) => {
            const dt = new DataTable(tableName);
            dt.loadArray(result);
            const dtSer = appMeta.getDataUtils.getJsonFromDataTable(dt);
            res.status(200).json(dtSer);
        }, (err) => {
            res.status(404).send(err);
        });


});

module.exports = router;
