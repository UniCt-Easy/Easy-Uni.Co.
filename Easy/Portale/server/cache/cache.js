
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

