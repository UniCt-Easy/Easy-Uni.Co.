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
