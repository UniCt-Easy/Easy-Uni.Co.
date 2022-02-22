
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


(function() {

    var MetaData = window.appMeta.MetaData;

    function meta_portale(tableName) {
        MetaData.apply(this, [tableName]);
        this.name = tableName;
        this.cache = require("../cache/cache");
        this.constant = require('../constants');
    }

    meta_portale.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_portale,
            superClass: MetaData.prototype,

            getSorting: function (listType) {
                const ds = this.cache.getMetaDataCache();
                const filter = qh.and(
                        qh.eq('tablename', this.name),
                        qh.eq('listtype', listType)
                );
                const rows = ds.tables[this.constant.METADATASORTING].select(filter);
                if (rows.length) {
                    let sorting = rows[0].sorting;
                    sorting = sorting.replaceAll('"');
                    return sorting;
                }
                return this.superClass.getSorting(listType);
            },

            primaryKey: function () {
                const ds = this.cache.getMetaDataCache();
                const filter = qh.eq('tablename', this.name);
                const rows = ds.tables[this.constant.METADATAPRIMARYKEY].select(filter);
                if (rows.length) {
                    let primarykey = rows[0].primarykey;
                    primarykey = primarykey.split(',');
                    return primarykey;
                }
                return [];
            },

            getStaticFilter: function (listType) {
                const ds = this.cache.getMetaDataCache();
                const filter = qh.and(
                    qh.eq('tablename', this.name),
                    qh.eq('listtype', listType)
                );
                const rows = ds.tables[this.constant.METADATASTATICFILTER].select(filter);
                if (rows.length) {
                    let staticfilterDB = rows[0].staticfilter;
                    const regex = /{(?:.:)?(.*?)}/;
                    const array = regex.exec(staticfilterDB);
                    let staticfilter = "";
                    _.forEach(array, (match) => {
                        const elements = match.split('$');
                        let replaced = "";
                        if (elements[0] === "usr") {
                            // replaced = security.GetUsr(elements[1]).ToString();
                        }
                        if (elements[0] === "sys") {
                            // replaced = security.GetSys(elements[1]).ToString();
                        }

                        staticfilter = staticfilter.replace(staticfilterDB, replaced);
                    });
                    return staticfilter;
                }

                return this.superClass.getStaticFilter(listType);
            }

        });

    appMeta.meta_portale = meta_portale;

}());
