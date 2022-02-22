
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


const dbconn = require('./dbconn');
const Deferred = require("jsDeferred");
const cache = require('../cache/cache');


createTableByName = (tableName) => {
   const def = Deferred();
   let dbStructure = cache.getDbStructure();
   // se trovo in cache risolvo immediatamente
   if (dbStructure[tableName]) {
      return def.resolve(dbStructure[tableName]);
   }

   const connection = dbconn.getConnection();
   connection.tableDescriptor(tableName)
       .then((descr) => {
         dbStructure[tableName] = buildDataTableFromTableDescriptor(descr);
         // salvo in cache struttura aggiornata
         cache.setDbStructure(dbStructure);
         def.resolve(dbStructure[tableName]);
   });

   return def.promise();
};

buildDataTableFromTableDescriptor = (tableDescriptor) => {
   const dt = new jsDataSet.DataTable(tableDescriptor.tableName);
   const primaryKey = [];
   // a partire dal descrittore creo le colonne
   _.forEach(tableDescriptor.columns, (colDescr) => {
      const jsDataTableType = getjsDataTableType(colDescr.type);
      dt.setDataColumn(colDescr.name, jsDataTableType);
      const dtCol = dt.columns[colDescr.name];
      dtCol.allowDbNull = colDescr.is_nullable;
      dtCol.isPrimaryKey = colDescr.pk;
      if (dtCol.isPrimaryKey) {
         primaryKey.push(colDescr.name);
      }
      dtCol.length = colDescr.len;
   });
   dt.key(primaryKey);
   return dt;
};

getjsDataTableType = (sqlType) => {
   switch (sqlType) {
      case 'int':
         return 'Int32';
      case 'varchar':
      case 'nvarchar':
         return 'String';
      case 'date':
      case 'datetime':
         return 'DateTime';
      case 'image':
         return 'Byte';
      case 'char':
         return 'Char';
   }
};

runSelect = (tableName, columns, filter, top, orderby) => {
   const def = Deferred();
   const connection = dbconn.getConnection();
   const options = {tableName, columns, filter, top, orderby};
   const query = connection.getSelectCommand(options);
   connection.queryBatch(query)
       .then((result) => {
          def.resolve(result);
       }, () => {
          def.resolve({err: err});
       });
   return def.promise();
};

getSqlFilterFromJsDataQueryJson = (filter) => {
   let filterSql = '';
   if (filter && filter !== "{}") {
      // data la stringa serializzata ricostruisco jsDataQuery
      const filterPrm = appMeta.getDataUtils.getJsDataQueryFromJson(filter);
      filterSql = filterPrm.toSql(sqlFormatter);
   }
   return filterSql;
};

module.exports.createTableByName = createTableByName;
module.exports.runSelect = runSelect;
module.exports.getSqlFilterFromJsDataQueryJson = getSqlFilterFromJsDataQueryJson;
