const mCache = require('memory-cache');
const constants = require('../constants');

module.exports = {

    /**
     * Save the cache of dataset with the info on metadata, managed by fmw
     * @param {DataSet} ds {tables: metadatamanagedtable, metadataprimarykey, metadatastaticfilter, metadatasorting}
     */
    initMetaDataCache: (ds) => {
        mCache.put(constants.METADATADATASET, ds);
    },

    getMetaDataCache: () => {
        return mCache.get(constants.METADATADATASET);
    },

    getDbStructure: () => {
        let dbStructure = mCache.get(constants.DBSTRUCTURE);
        if (!dbStructure) {
            dbStructure = {};
        }
        return dbStructure;
    },

    setDbStructure: (dbStructure) => {
        mCache.put(constants.DBSTRUCTURE, dbStructure);
    }
};

