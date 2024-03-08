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
    // need to parse from readFileSync and the stringify to back to client
    let dsObj = JSON.parse(jsonDataSet);
    let json = JSON.stringify(dsObj);

    res.status(200).json(json);
});

module.exports = router;
