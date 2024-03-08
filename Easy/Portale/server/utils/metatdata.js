const cache = require('../cache/cache');
const constant = require('../constants');
module.exports = {

    /**
     *
     * @param {string} tableName
     * @returns {MetaData}
     */
    getMeta: (tableName) => {
        // check if is a metadata managed by portale.
        if (isMetaDataPortale(tableName)) {
            return new appMeta.meta_portale(tableName);
        }
        return appMeta.getMeta(tableName);
    },

};

/**
 *
 * @param {string} tableName
 * @returns {boolean}
 */
isMetaDataPortale = (tableName) => {
    const ds = cache.getMetaDataCache();
    const filter = qh.eq('tablename', tableName);
    const rows = ds.tables[constant.METADATAMANAGEDTABLE].select(filter);
    return rows.length > 0;
};
