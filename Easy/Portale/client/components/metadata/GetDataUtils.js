/*globals ObjectRow,DataRelation,define,self,jsDataSet,jsDataQuery,metaModel,appMeta,sqlFun,_ */

/**
 * @module getDataUtils
 * @description
 * Collection of utility functions about used by GetData
 */

(function (q,logger,logType,jsDataSet,_) {


    /** Detect free variable `global` from Node.js. */
    let freeGlobal = typeof global === 'object' && global && global.Object === Object && global;
    /** Detect free variable `self`. */
    let freeSelf = typeof self === 'object' && self && self.Object === Object && self;
    /** Used as a reference to the global object. */
    let root = freeGlobal || freeSelf || Function('return this')();
    /** Detect free variable `exports`. */
    let freeExports = typeof exports === 'object' && exports && !exports.nodeType && exports;
    /** Detect free variable `module`. */
    let freeModule = freeExports && typeof module === 'object' && module && !module.nodeType && module;
    //noinspection JSUnresolvedVariable
    /** Detect free variable `global` from Node.js or Browserified code and use it as `root`. (thanks lodash)*/
    let moduleExports = freeModule && freeModule.exports === freeExports;


    let getDataUtils = {};
    let dataRowState = jsDataSet.dataRowState;

    const dateFormat =  /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}Z$/;
    // vecchio formato senza millisecondi /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}Z$/;

    function dataTransformFromJSON(key, value) {
        if (typeof value === "string" && dateFormat.test(value)) {
             // console.log("date found:"+value);
            return  new Date(value);
        }
        return value;
    }
    function dataTransformToJSON(key, value) {
         // console.log("executing  dataTransformToJSON BASE of " + value);
        return value;
    }

    getDataUtils.dataTransformFromJSON = dataTransformFromJSON;
    getDataUtils.dataTransformToJSON = dataTransformToJSON;

    const adjustInputJson = (obj) => {
        // console.log("adjustInputJson BASE calling adjustJson with obj of type ", typeof obj);

        if (obj && typeof obj === 'string') {
            console.log("converting string in object, should not happen");
            return getDataUtils.dataTransformFromJSON(null, obj);
        }

        for (let k in obj) {
            let val = obj[k];
            //console.log("converting property:", k);
            if (val && typeof val === 'string') {
                //console.log("converting string in property ",k,":",val);
                obj[k] = getDataUtils.dataTransformFromJSON(k, val);
                //console.log("new value: ", obj[k], " of type " + typeof (obj[k]));
                continue;
            }
            if (Array.isArray(val)) {
                //console.log("converting array: ",k);
                val.forEach((el, index) => {
                    if (el && typeof el === 'string') {
                        //console.log("converting string in array ",k,":",el);
                        val[index] = getDataUtils.dataTransformFromJSON(null, el);
                        //console.log("new value: ", val[index], " of type " + typeof (val[index]));
                    }
                    else {
                        adjustInputJson(el);
                    }
                });
                continue;
            }
            if (val && typeof val === 'object') {
                adjustInputJson(val)
            }
        }
    }

    /**
     * @function getJsObjectFromJson
     * @public
     * @description SYNC
     * Given a json representation of the DataSet/DataTable returns a javascript object
     *  this manages translation of date objects
     * @param {string} json
     * @returns {object} an object (DataTable or DataSet)
     */
    getDataUtils.getJsObjectFromJson = function (json) {
        // console.log("getDataUtils.getJsObjectFromJson BASE");
        // riconverto la stringa json proveniente dal server
        if (typeof json === 'string') {
            //console.log("json is a string");
            //console.log("getJsObjectFromJson:",json.substring(0,100));
            return JSON.parse(json, getDataUtils.dataTransformFromJSON);
        }
        //console.log("getJsObjectFromJson BASE: json is an object - adjusting from JSON");
        adjustInputJson(json);
        return json;
        //return JSON.parse(json);
    };

    /**
     * @function getJsDataTableFromJson
     * @public
     * @description SYNC
     * Given a json representation of the DataTable returns a Js DataTable
     * @param {string} jsonJsDataTable JSon string
     * @returns {DataTable} the datatable
     */
    getDataUtils.getJsDataTableFromJson = function (jsonJsDataTable) {

        // riconverto la stringa json proveniente dal server
        let objParsed =  getDataUtils.getJsObjectFromJson(jsonJsDataTable);

        // creo nuovo jsDataSet da popolare
        let dt = new jsDataSet.DataTable(objParsed.name);
        // deserializzo il json proveniente dal server e popolo ds
        dt.deSerialize(objParsed, true);

        return dt;
    };

    /**
     * @function getJsDataSetFromJson
     * @public
     * @description SYNC
     * Given a json representation of the DataSet returns a JsDataSet
     * @param {object} jsonJsDataSet JSon object
     * @returns {DataSet} the dataset
     */
    getDataUtils.getJsDataSetFromJson = function (jsonJsDataSet) {
        //console.log("getDataUtils.getJsDataSetFromJson BASE")
        // riconverto la stringa json proveniente dal server
        //console.log("getJsDataSetFromJson, typeof(jsonJsDataSet) is:", typeof (jsonJsDataSet));
        let objParsed = getDataUtils.getJsObjectFromJson(jsonJsDataSet);

        // creo nuovo jsDataSet da popolare
        let ds = new jsDataSet.DataSet(objParsed.name);
        // deserializzo il json proveniente dal server e popolo ds
        ds.deSerialize(objParsed, true);
        
        //ds.displayData();
        return ds;
    };

    /**
     * @function getJsonFromJsDataSet
     * @public
     * @description SYNC
     * Given a jsDataSet returns the json string. First it calls the methods serialize() of jsDataSet and then returns the json representation of the dataset object
     * @param {DataSet} ds
     * @param {boolean} serializeStructure. If true it serialize data and structure
     * @returns {object} the json 
     */
    getDataUtils.getJsonFromJsDataSet = function (ds, serializeStructure) {
        //return JSON.stringify(ds.serialize(serializeStructure));

        var objser = ds.serialize(serializeStructure);
        // _.forEach(objser.tables, function (objdt) {
        //     getDataUtils.convertDateTimeToUTC(objdt, false);
        // });
        //var jsonToSend = JSON.stringify(objser);
        return objser; // jsonToSend;

    };


    /**
     * @function getJsonFromJsDataSet
     * @public
     * @description SYNC
     * Serializes a DataTable with the data and structure
     * @param {DataTable} dt
     * @returns {object} the json string
     */
    getDataUtils.getJsonFromDataTable = function (dt) {
        let objser = dt.serialize(true);
        objser.name = dt.name;
        //return JSON.stringify(objser);
        return objser;
    };

    /**
     * @function getJsonFromMessages
     * @public
     * @description SYNC
     * Given an array of message object returns the json string
     * @param {string[]} messages
     * @return {object}
     */
    getDataUtils.getJsonFromMessages = function (messages) {
        if (!messages) return;
        if (messages.length === 0) return;
        return messages; // JSON.stringify(messages);
    };

    /**
     * @function getJsDataQueryFromJson
     * @description SYNC
     * Given a json representation of the JsDataQuery returns a JsDataQuery
     * @public
     * @param {string} jsonJsDataQuery Json string
     * @returns {sqlFun} the jsDataQuery representation of the json
     */
    getDataUtils.getJsDataQueryFromJson = function (jsonJsDataQuery) {
        // riconverto la stringa json proveniente dal server
        let objParsed = getDataUtils.getJsObjectFromJson(jsonJsDataQuery);        
        return q.fromObject(objParsed);
    };

    /**
     * @function getJsonFromJsDataQuery
     * @public
     * @description SYNC
     * Given jsDataQuery returns the json string. first it converts jsDataQuery into js object and to a json string
     * @param {jsDataQuery} dataQuery
     * @returns {object} the json object
     */
    getDataUtils.getJsonFromJsDataQuery = function (dataQuery) {
        return q.toObject(dataQuery);// JSON.stringify(q.toObject(dataQuery));
    };

    /**
     * @function getDataRelationSerialized
     * @public
     * @description SYNC
     * Serializes the DataRelation "rel"
     * @param {DataRelation} rel
     * @returns {string} the string of DataRelation serialized
     */
    getDataUtils.getDataRelationSerialized = function (rel) {
        if (!rel) return "";
        return rel.serialize(); // JSON.stringify(rel.serialize());
    };

    /**
     * @function cloneDataTable
     * @public
     * @description SYNC
     * Returns a cloned copy of "dt" input using the ser/der methods of the framework
     * @param {DataTable} dt
     * @returns {DataTable}
     */
    getDataUtils.cloneDataTable = function (dt) {
        let dsClone = getDataUtils.cloneDataSet(dt.dataset);
        return dsClone.tables[dt.name];
        //let t =  getDataUtils.getJsDataTableFromJson(getDataUtils.getJsonFromDataTable(dt));
        //dt.dataset = dsClone;
        //return t;
    };

    /**
     * @function cloneDataSet
     * @public
     * @description SYNC
     * Returns a cloned copy of "ds" input using the ser/der methods of the framework
     * @param {DataSet} ds
     * @returns {DataSet}
     */
    getDataUtils.cloneDataSet = function (ds) {
        return getDataUtils.getJsDataSetFromJson(getDataUtils.getJsonFromJsDataSet(ds, true));
    };

    /**
     * @function mergeDataSet
     * @public
     * @description SYNC
     * Merges the rows of dsSource into dsTarget
     * @param {DataSet} dsDest. DataSet target, where inject new rows, taken form dsSource
     * @param {DataSet} dsSource. The new DataSet, with modifies read from server. Need to merge these rows into dsTarget
     * @param {boolean} checkExistence
     */
    getDataUtils.mergeDataSet = function (dsDest, dsSource, checkExistence) {
        _.forEach(dsSource.tables, function (tSource) {
            // se il mio dsTarget contiene la tabella allora effettuo merge delle righe
            if (dsDest.tables[tSource.name]){
                // se non ci sono inutile fare il check esistenza
                if (!dsDest.tables[tSource.name].rows.length) {
                    getDataUtils.mergeRowsIntoTable(dsDest.tables[tSource.name], tSource.rows, false);
                } else {
                    getDataUtils.mergeRowsIntoTable(dsDest.tables[tSource.name], tSource.rows, checkExistence);
                }

            }else{
				//TODO: richiamare localresource per internazionalizzare il messaggio
                logger.log(logType.ERROR, "Table " + tSource.name + " does not exists in dataset " + dsDest.name);
            }
        });
    };

    /**
     * @function mergeDataSetChanges
     * @public
     * @description SYNC
     * Merges rows modified of dsSource into dsDest. Use "merge" method of DataTable of jsDataSet
     * @param {DataSet} dsDest
     * @param {DataSet} dsSource
     * @param {boolean} changesCommittedToDB
     */
    getDataUtils.mergeDataSetChanges = function (dsDest, dsSource, changesCommittedToDB) {
        _.forEach(dsSource.tables,
            function(tSource) {
                // se il mio dsTarget contiene la tabella allora effettuo merge delle righe
                if (dsDest.tables[tSource.name]) {
                    // Questo non basta, vedi righe successive. dsDest.tables[tSource.name].merge(tSource);
                    // ciclo sulle righe originali del dest attraverso un contatore. Ragiono a livello posizionale.
                    // 1. se riga è modified faccio merge. i 2 indici source e dest allineati
                    // 2. se riga è added inserisco riga corrispondente, aumento gli indici
                    // 3. deleted . faccio acceptChanges() così la riga viene detachata, rimango fermo sugli indici. solo se la transazione è ok

                    // recupero tabella di destinazione
                    let tDest = dsDest.tables[tSource.name];

                    // Indice delle righe del source, va con l'indice del dest cioè quello di partenza, ma se la riga del source è deleted non viene aumentato
                    // poiché il js nelle iterazioni successive deve copiare per le mod e add quella con lo stesso indice.
                    var rSourceIndex = 0; // NON SERVE, tengo solo l'indice della dest.
                        // Nino: serve, non stiamo inviando le righe unchanged
                    let rDestIndex = 0;

                    try {
                        for(rDestIndex; rDestIndex < tDest.rows.length;) {

                            // ottengo la i-esima riga dest. a seconda dello stato effettuo operazioni,
                            let rowDest = tDest.rows[rDestIndex];
                            let currState = rowDest.getRow().state;

                            if (currState === dataRowState.unchanged){
                                // sul db di origine non fai nulla se in destinazione è unchanged
                                rDestIndex++;
                                continue;
                            }
                            if (currState === dataRowState.modified){
                                // 1. se riga è modified faccio merge. I due indici source e dest allineati
                                rowDest.getRow().makeSameAs(tSource.rows[rSourceIndex].getRow());
                                rDestIndex++;
                                rSourceIndex++;
                                continue;
                            }
                            if (currState === dataRowState.added){
                                // 2. se riga è added inserisco riga corrispondente, aumento gli indici

                                rowDest.getRow().makeSameAs(tSource.rows[rSourceIndex].getRow());
                                // aumento contatore delle righe del source
                                rDestIndex++;
                                rSourceIndex++;

                                continue;
                            }
                            if (currState === dataRowState.deleted){
                                // potrei aver preso degli errori e quindi il commit non è stato fatto, dovrò aumentare il contatore senza cancellare la riga
                                if (changesCommittedToDB) {
                                    // NON aumento contatore delle righe del source! poiché era deleted, quindi sul source non la trovo
                                    // poiché il server avrà fatto acceptChanges()
                                    // qui io voglio che diventi detached e quindi a sua volta eseguo acceptChanges() sulla riga.
                                    // Verrà tolto il metodo getRow()
                                    rowDest.getRow().acceptChanges();
                                    continue;
                                } else{
                                    rDestIndex++;
                                    rSourceIndex++;
                                    continue;
                                }
                            }
                        }
                    } catch (e) {
                        console.log("Dataset disallineati dopo il salvataggio " + e.message);
                        logger.log(logType.ERROR, "Dataset disallineati dopo il salvataggio " + e.message);
                    }

                }
                else {
                    if (tSource.rows.length > 0) {
                        console.log("La tabella " + tSource.name + " non esiste sul dataset di destinazione " + dsDest.name);
                        logger.log(logType.ERROR, "La tabella " + tSource.name + " non esiste sul dataset di destinazione " + dsDest.name);
                    }
                }
            });
    };

    /**
     * @function mergeRowsIntoTable
     * @public
     * @description SYNC
     * Merges given "rows" in a specified table "tDest"
     * @param {DataTable} tDest
     * @param {ObjectRow[]} rows
     * @param {boolean} checkExistence
     */
    getDataUtils.mergeRowsIntoTable = function(tDest, rows, checkExistence) {
        _.forEach(rows,
            function(r) {
                if (!checkExistence) {
                    tDest.add({}).makeSameAs(r.getRow());
                    return true;
                }
                let oldRow = tDest.existingRow(r);
                if (oldRow) {
                    oldRow.getRow().makeSameAs(r.getRow());
                } else {
                    tDest.add({}).makeSameAs(r.getRow());
                }
                return true;
            });
    };

    /**
     * @method getAutoChildRelation
     * @private
     * @description SYNC
     * Gets a relation that connects a table with its self. Should be the same as AutoParent
     * @param {DataTable} dt
     * @returns {DataRelation} the auto child relation
     */
    getDataUtils.getAutoChildRelation = function (dt) {
        let autoChildRel = null;
        if (!dt) return null;
        _.forEach(dt.childRelations(), function (rel) {
            if (rel.parentTable === dt.name && rel.childTable === dt.name) {
                autoChildRel = rel;
                // ho trovato la rel esco dal ciclo for
                return false;
            }
        });

        return autoChildRel;
    };

    /**
     * @method getAutoParentRelation
     * @private
     * @description SYNC
     * Gets a relation that connects a table with its self
     * @param {DataTable} dt
     * @returns {DataRelation} the auto parent relation
     */
    getDataUtils.getAutoParentRelation = function (dt) {
        let autoParentRel = null;
        if (!dt) return null;
        _.forEach(dt.parentRelations(), function (rel) {
            if (rel.parentTable === dt.name) {
                autoParentRel = rel;
                // ho trovato la rel esco dal ciclo for
                return false;
            }
        });

        return autoParentRel;
    };


    /**
     * @method containsNull
     * @public
     * @description SYNC
     * Returns true if there is a null value or "", for some value in row on the columns cols
     * @param {ObjectRow} row
     * @param {DataColumn[]} cols
     * @returns {boolean} true or false depending if there are null values on row in cols
     */
    getDataUtils.containsNull = function (row, cols) {
        return _.some(cols, function (c) {
            return row[c.name] === null || row[c.name] === "";
        });
    };
    
    /**
     * @method compareRows
     * @private
     * @description SYNC
     * Returns true if it is the same row. It compares the columns field key
     * @param {DataTable} table
     * @param {ObjectRow} r1
     * @param {ObjectRow} r2
     * @returns {boolean} true if r1 and r2 are the same row
     */
    getDataUtils.isSameRow = function (table, r1, r2) {
        if (!r1 || !r2) return false;
        return _.every(table.key(), function (k) {
            return r1[k] === r2[k];
        }); // torno true se non trovo val differenti sulla chiave
    };



    // Some AMD build optimizers like r.js check for condition patterns like the following:
    //noinspection JSUnresolvedVariable
    if (typeof define === 'function' && typeof define.amd === 'object' && define.amd) {
        // Expose lodash to the global object when an AMD loader is present to avoid
        // errors in cases where lodash is loaded by a script tag and not intended
        // as an AMD module. See http://requirejs.org/docs/errors.html#mismatch for
        // more details.
        // Export for a browser or Rhino.
        if (root.appMeta) {
            root.appMeta.getDataUtils = getDataUtils;
        }
        else {
            root.getDataUtils = getDataUtils;
        }

        // Define as an anonymous module so, through path mapping, it can be
        // referenced as the "underscore" module.
        //noinspection JSUnresolvedFunction
        define(function () {
            return getDataUtils;
        });
    }
    // Check for `exports` after `define` in case a build optimizer adds an `exports` object.
    else if (freeExports && freeModule) {
        // Export for Node.js or RingoJS.
        if (moduleExports) {
            (freeModule.exports = getDataUtils).getDataUtils = getDataUtils;
        }
        // Export for Narwhal or Rhino -require.
        else {
            freeExports.getDataUtils = getDataUtils;
        }
    }
    else {
        // Export for a browser or Rhino.
        if (root.appMeta){
            root.appMeta.getDataUtils = getDataUtils;
        }
        else {
            root.getDataUtils=getDataUtils;
        }

    }

}((typeof jsDataQuery === 'undefined') ? require('./jsDataQuery') : jsDataQuery,
    (typeof appMeta === 'undefined') ? require('./Logger').logger : appMeta.logger,
    (typeof appMeta === 'undefined') ? require('./Logger').logTypeEnum : appMeta.logTypeEnum,
    (typeof appMeta === 'undefined') ? require('./jsDataSet') : jsDataSet,
    (typeof _ === 'undefined') ? require('lodash') : _
));

