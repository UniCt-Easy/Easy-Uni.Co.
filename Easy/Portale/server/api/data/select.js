
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
