
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
const fs = require('fs');
const _ = require("lodash");

/**
 * Read json dataset form keys tableName and edittype
 * @type {path.PlatformPath | path}
 */
const path = require('path');
    router.post('/', (req, res, next) => {

    const tableName = req.body.tableName;
    const editType = req.body.editType;
    const dsMetaPrefix = 'dsmeta_';

    // read the static json of dataset,
    var jsonPath = path.join(__dirname, '../../', 'data', dsMetaPrefix + tableName + '_' + editType + '.json');
    let jsonDataSet = fs.readFileSync(jsonPath);
    // need to parse from readFileSync and the stringyfy to back to client
    let dsObj = JSON.parse(jsonDataSet);
    let json = JSON.stringify(dsObj);

    res.status(200).json(json);
});

module.exports = router;
