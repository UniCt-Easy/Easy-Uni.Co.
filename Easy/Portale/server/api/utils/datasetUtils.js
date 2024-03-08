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
