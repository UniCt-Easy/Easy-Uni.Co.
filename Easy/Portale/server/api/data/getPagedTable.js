
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
const dbconn = require('../../dbconn/dbconn');
const dbconnutils = require('../../dbconn/dbconnutils');
const Deferred = require("jsDeferred");
const metadata  = require("../../utils/metatdata");
/**
 * Return a paginated datatable
 * @type {path.PlatformPath | path}
 */
router.post('/', (req, res, next) => {
    const connection = dbconn.getConnection();

    // leggo prm in post
    const tableName = req.body.tableName;
    const nPage = parseInt(req.body.nPage);
    const nRowPerPage = parseInt(req.body.nRowPerPage);
    const filter = req.body.filter;
    const listType = req.body.listType;
    const sort = req.body.sortby;

    let dtOriginal, meta, sortMeta, newtablename, newlisttype, sort_by, totrows, objQuery;
    let filterSql = '';

    // 1. Mappatura con tabella web_listredir
  getMappingWebListRedir(tableName, listType)
      .then((tname, ltype) => {

          newtablename = tname;
          newlisttype = ltype;

          // recupero informazioni dal meta
          meta = metadata.getMeta(newtablename);
          sortMeta = meta.getSorting(newlisttype);

          return dbconnutils.createTableByName(tableName);

      }).then((resDt) => {
            dtOriginal = resDt;
          // se è impostato sul emta prendo quello, altrimenti vedo se è passato da fuori.
          // se non è configurato, allora per convenzione noto se c'è una colonna title, altrimenti ordino sulla prima colonna
          sort_by = sortMeta ? sortMeta : (sort ? sort : dtOriginal.columns["title"] ? "title" : Object.keys(dtOriginal.columns)[0]);

         // leggo e trasformo il filtro
         filterSql = dbconnutils.getSqlFilterFromJsDataQueryJson(filter);

          // il filtro da passare alla run_select_count è senza where, solo con le clausole
          const optionsCount = {
              tableName,
              filter: filterSql,
              listType,
              columns: "*",
              orderBy: sort_by
          };
          const queryCount = connection.getSelectCount(optionsCount);
          return connection.queryBatch(queryCount)
      }).then( (resCount) => {
          totrows = resCount.length ? resCount[0][''] : 0;
          objQuery = calcQueryPaginated(totrows, nPage, nRowPerPage, sort_by, newtablename, filterSql);
          const query = objQuery.query;
          // TODO capire come gestire connection. per ora lo passo da fuori
          return executePaginatedQuery(query, dtOriginal, connection)
     /*}).then((dtPaged) => {
            // descrivo colonne in abse al meta
          return meta.describeColumns(dtPaged, newlisttype);*/
      }).then((dtPaged) => {
           // serializzo in json
           const dtSer = appMeta.getDataUtils.getJsonFromDataTable(dtPaged);
           res.status(200).json({
               dt : dtSer,
               totpage : objQuery.totPages,
               totrows : totrows
           });
      });
});

/**
 *
 * @param {number} totrows
 * @param {number} nPage
 * @param {number} nRowPerPage
 * @param {string} sort_by
 * @param {string} tablename
 * @param {string} filterSql
 * @returns {Object} {string, number} => query,totPages
 */
calcQueryPaginated = (totrows, nPage, nRowPerPage, sort_by, tablename, filterSql) => {
    let totPages;
    if (totrows % nRowPerPage === 0) {
        totPages = totrows / nRowPerPage;
    } else {
        totPages = Math.round((totrows / nRowPerPage)) + 1;
    }

    let orderByClause = '';
    if (sort_by) {
        orderByClause = " ORDER BY " + sort_by + " ";
    }

    let query = "";
    if (totPages < 2 || !sort_by) {
        query = "SELECT " + " * " + "  from " + tablename +  ' where ' + filterSql + orderByClause;
    } else {
        const firstrow = (nPage - 1) * nRowPerPage + 1;
        query = "select top " + nRowPerPage + " * from ( SELECT ROW_NUMBER() OVER (ORDER BY " + sort_by + ") row_num, * FROM " + tablename + filterSql + " ) x where row_num >= " + firstrow;
    }

    return {query, totPages};
};

/**
 *
 * @param {string} query
 * @param {DataTable} dtOriginal
 * @param {Connection} connection
 * @returns {DataTable}
 */
executePaginatedQuery = (query, dtOriginal, connection) => {
    const def = Deferred();
    connection.queryBatch(query)
        .done((result) => {
            dtOriginal.loadArray(result, false);
            def.resolve(dtOriginal);
        })
        .fail((err) => def.resolve({err: err}));

    return def.promise();
};

/**
 *
 * @param {string} tableName
 * @param {string} listType
 * @returns  {Deferred} {string, string} => newtablename, newlisttype
 */
getMappingWebListRedir = (tableName, listType) => {
    const def = Deferred();

    const filter = qh.and(
        qh.eq("tablename", tableName),
        qh.eq("listtype", listType)
    );
    const connection = dbconn.getConnection();
    const options = {tableName: "web_listredir", filter, columns: "newtablename,newlisttype"};
    const query = connection.getSelectCommand(options);
    let newtablename = tableName;
    let newlisttype = listType;

    connection.queryBatch(query)
        .then((result) => {
            if (result && result.length) {
                newtablename = result[0]["newtablename"];
                newlisttype = result[0]["newlisttype"];
            }
            def.resolve(newtablename, newlisttype);
        }, () => def.resolve({err: err}));

    return def.promise();
};

module.exports = router;
