
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


const express = require('express');
const router = express.Router();
const getData = require('jsGetData');
const dbconn = require('../../dbconn/dbconn');
const datasetUtils = require('../utils/datasetUtils');
/**
 * Read json dataset form keys tableName and edittype and a filter. It populates the rows based on that main row
 * @type {path.PlatformPath | path}
 */
const path = require('path');
router.post('/', (req, res, next) => {
    var dsPrm = req.body.ds;
    var primaryTableName = req.body.primaryTableName;
    var filterPrm = req.body.filter;
    var tableNameFilter = req.body.tableNameFilter;
    var refreshPeripherals = req.body.refreshPeripherals;
    const ds = appMeta.getDataUtils.getJsDataSetFromJson(dsPrm);
    var table = ds.tables[primaryTableName];
    dbconn.getDataAccess()
        .then((DAC) => {
            // preparo i prm di inpout per "fillDataSetByFilter"
            const ctx = {dataAccess: DAC};
            // trasforma il filtro passato in input in jsDataQuery
            const filter = appMeta.getDataUtils.getJsDataQueryFromJson(filterPrm);

            getData.fillDataSetByFilter(ctx, ds, table, filter)
                .then(() => {
                    let json = appMeta.getDataUtils.getJsonFromJsDataSet(ds, true);
                    res.status(200).json(json);
                }, err => {
                    res.status(500).json("fillDataSetByFilter failed: " + err);
                })

        }, err =>   res.status(500).json("conn to DataAccess failed: " + err));

});

module.exports = router;
