/**
 * @module getDataUtilsDotNet
 * @description
 * Collection of utility functions for GetData
 */
(function () {

    var getDataUtils = appMeta.getDataUtils;
    const dateFormat = /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}Z$/;

    function getDataFormat(){
        return /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}Z$/;
        // vecchio formato senza millisecondi /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}Z$/;
    }

    //function dataTransform(key, value) {
    //    if (typeof value === "string" && dateFormat.test(value)) {
    //        return new Date(value);
    //    }
    //    return value;
    //}
    function dataTransformToJSON(key, value) {
        //console.log("dataTransformToJSON key:"+key+",value:"+value+" of type "+typeof value+" - "+JSON.stringify(value));
        //if (Object.prototype.toString.call(value) === '[object Date]') {
        //if (value instanceof Date) {
        if (typeof value === "string" && dateFormat.test(value)) {
            let d = getDataUtils.normalizeDataWithoutOffsetTimezone(new Date(value), true);
            //value = getDataUtils.normalizeDataWithoutOffsetTimezone(value, true)
            //let date = new Date(value);
            //let jsonDate = new Date(value.getTime() - (value.getTimezoneOffset() * 60000)).toISOString();

            //console.log(value + " Date serialized as " + d.toISOString());

            return d.toISOString();
            //let d = new Date(value);
            //d = getDataUtils.normalizeDataWithoutOffsetTimezone(value, true); //) new Date(new Date(value).getTime() + (new Date().getTimezoneOffset() * 60000));
            //return d;
            //commenting this
            //value = new Date(date.getTime() - (date.getTimezoneOffset() * 60000)).toISOString();
        }


        return value;
    }

    
    function dataTransformFromJSON(key, value) {
        if (typeof value === "string" && dateFormat.test(value)) {
            //console.log("dot net fromJSON client old value time is " + value);

            //12:37:46.269Z as 14:37:46 GMT+0200 (Ora legale dell’Europa centrale)'
            //let d = new Date(value);

            //12:35:51.956Z as 12:35:51 GMT+0200 (Ora legale dell’Europa centrale)' >> this is the right one
            let d = getDataUtils.normalizeDataWithoutOffsetTimezone(new Date(value), false);

            //12:40:17.947Z as 16:40:17 GMT+0200 (Ora legale dell’Europa centrale)'
            //let d = getDataUtils.normalizeDataWithoutOffsetTimezone(new Date(value), true);

            //IN NODE:
            //10:17:40.380Z as 12:17:40 GMT+0200 (Ora legale dell’Europa centrale)

            //console.log("dataTransformFromJSON revived date " + value + " as " + d);
            return d;
        }
        return value;
    }
    getDataUtils.dataTransformToJSON = dataTransformToJSON;
    getDataUtils.dataTransformFromJSON = dataTransformFromJSON;

    /**
     * @function getJsObjectFromJson
     * @public
     * @description SYNC
     * Given a json representation of the DataSet/DataTable returns a javascript object
     * Converts string to dates
     * @param {string} json
     * @returns {object} an object (DataTable or DataSet)
     */
    getDataUtils.getJsObjectFromJson = function (json) {
        //console.log("the method getJsObjectFromJson is .NET")
        // formato data aspettato
        if (typeof json === "string") {
            //console.log("getJsObjectFromJson .NET converting string");
            return JSON.parse(json, dataTransformFromJSON);
        }
        //console.log("getJsObjectFromJson .NET: adjusting json ");
        adjustInputJson(json);
        return json;
    };

    

    /**
     * @function getJsonFromJsDataSet
     * @public
     * @description SYNC
     * Given a jsDataSet returns the json string. First it calls the methods serialize() of jsDataSet and then returns the json representation of the dataset object
     * @param {DataSet} ds
     * @param {boolean} serializeStructure. If true it serialize data and structure
     * @returns {string] the json string
     */
    getDataUtils.getJsonFromJsDataSet = function (ds, serializeStructure) {
        //console.log("doing .NET  getJsonFromJsDataSet");
        var objser = ds.serialize(serializeStructure);
        //_.forEach(objser.tables, function (objdt) {
        //    getDataUtils.beforeDataTableStringifyJson(objdt, true);
        //});

        //var jsonToSend = JSON.stringify(objser, dataTransformToJSON);
        //return jsonToSend;
        return objser;
    };

    /**
     * @function getJsonFromDataTable
     * @public
     * @description SYNC
     * Serializes a DataTable with the data and structure
     * @param {DataTable} dt
     * @returns {string} the json string
     */
    getDataUtils.getJsonFromDataTable = function (dt) {
        var objser = dt.serialize(true);
        objser.name = dt.name;
        //getDataUtils.beforeDataTableStringifyJson(objser, true);
        //var jsonToSend = JSON.stringify(objser, dataTransformToJSON);
        //return jsonToSend;
        return objser;
    };

    ///**
    // * Used on serialized datatable to modify the date timesoffset to avoid the JSON.stringify convert date in utc
    // * @param {DataTable} objdt
    // * @param {boolean} normalize
    // */
    //getDataUtils.beforeDataTableStringifyJson = function (objdt, normalize) {
    //    // Da applicare ogni volta che serializzo il dt verso server, prima della JSON.stringify
    //    _.forEach(objdt.columns, function (c) {
    //        if (c.ctype==="DateTime"){
    //            _.forEach(objdt.rows, function (row){

    //                if (row.curr){
    //                    row.curr[c.name] = row.curr[c.name] ? getDataUtils.normalizeDataWithoutOffsetTimezone(row.curr[c.name], normalize) : row.curr[c.name];
    //                }
    //                if (row.old){
    //                    row.old[c.name] = row.old[c.name] ? getDataUtils.normalizeDataWithoutOffsetTimezone(row.old[c.name], normalize) : row.old[c.name];
    //                }
    //                if (row[c.name]){
    //                    row[c.name] = getDataUtils.normalizeDataWithoutOffsetTimezone(row[c.name], normalize);
    //                }
    //            });
    //        }
    //    })
    //};

    /**
    * @method normalizeDataWithoutOffsetTimezone
    * @public
    * @description SYNC
    * When js convert to JSON, JSON uses Date.prototype.toISOString that doesn't represent local hour but the UTC +offset.
    * So the string will be modified with a new date.
     * In this function we avoid this behaviour, it adds the offset to the date. succesive stringfy() doesn't change the date
    * @param {Date} date
    * @param normalize set true when sending JSON to .NET, set to false when receiving denormalized data (should not happen)
    */
    getDataUtils.normalizeDataWithoutOffsetTimezone = function (date, normalize) {
        // soluzione su https://code.i-harness.com/en/q/16ae8c
        if (normalize){
            return new Date(date.getTime() - (date.getTimezoneOffset() * 60000));
        } else{
            return new Date(date.getTime() + (date.getTimezoneOffset() * 60000));
        }
    };


    const adjustInputJson = (obj,inner) => {
        //if (!inner) console.log("calling adjustInputJson DOTNET with obj of type ", typeof obj);

        if (obj && typeof obj === 'string') {
            console.log("converting string in object, should not happen");
            return dataTransformFromJSON(null, obj);
        }

        for (let k in obj) {
            let val = obj[k];
            //console.log("converting property:", k);
            if (val && typeof val === 'string') {
                //console.log("converting string in property ",k,":",val);
                obj[k] = dataTransformFromJSON(k, val);
                //console.log("new value: ", obj[k], " of type " + typeof (obj[k]));
                continue;
            }
            if (Array.isArray(val)) {
                //console.log("converting array: ",k);
                val.forEach((el, index) => {
                    if (el && typeof el === 'string') {
                        //console.log("converting string in array ",k,":",el);
                        val[index] = dataTransformFromJSON(null, el);
                        //console.log("new value: ", val[index], " of type " + typeof (val[index]));
                    }
                    else {
                        adjustInputJson(el,true);
                    }
                });
                continue;
            } 
            if (val && typeof val === 'object') {
                adjustInputJson(val,true)
            } 
        }
    }




    appMeta.getDataUtils = getDataUtils;
}());

