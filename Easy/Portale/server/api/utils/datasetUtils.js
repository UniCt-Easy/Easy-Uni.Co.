
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


const fs = require('fs');
/**
 * Read json dataset form keys tableName and edittype and a filter. It populates the rows based on that main row
 * @type {path.PlatformPath | path}
 */
const path = require('path');

/**
 *
 * @param {string} tableName
 * @param {string} editType
 * @returns {*}
 */
createAndGetEmptyDataSet = (tableName, editType) => {
    const dsMetaPrefix = 'dsmeta_';
    // read the static json of dataset,
    var jsonPath = path.join(__dirname, '../../', 'data', dsMetaPrefix + tableName + '_' + editType + '.json');
    let jsonDataSet = fs.readFileSync(jsonPath);
    // return an empty dataset
    return appMeta.getDataUtils.getJsDataSetFromJson(jsonDataSet);
};

/**
 * Clean the input DataSet based on dsSafe
 * @param {DataSet} dsInput
 * @param {DataSet} dsSafe
 */
makeSafeDataSet = (dsInput, dsSafe) => {
    _.forEach(dsInput.tables, (t) => {
        // if not exist in safe dataset, remove the table from the input dataset
        const dtSafe = dsSafe.tables[t.name];
        if (!dtSafe) {
            delete t;
            return true;
        }
        _.forEach(t.columns, (c) => {
            // if not exist in safe dattable, remove the column from the input columns
            const cSafe = dtSafe.columns[c.name];
            if (!cSafe) {
                delete c;
            }
        });
    });
};

module.exports.createAndGetEmptyDataSet = createAndGetEmptyDataSet;
module.exports.makeSafeDataSet = makeSafeDataSet;
