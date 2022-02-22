
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
