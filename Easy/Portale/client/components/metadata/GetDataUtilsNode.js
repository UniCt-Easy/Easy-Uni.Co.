/**
 * @module getDataUtilsNode. overrides getDataUtils methods for node backend
 * @description
 * Collection of utility functions for GetData
 */

(function () {
    let getDataUtils = appMeta.getDataUtils;

    //2017-12-11T13:21:38.890Z
    const dateFormat =  /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}Z$/;
    // vecchio formato senza millisecondi /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}Z$/;

    function dataTransform(key, value) {
        if (typeof value === "string" && dateFormat.test(value)) {
            //console.log("date found:"+value);
            //console.log("date found:"+value);
            return  new Date(value);
            //value =  getDataUtils.normalizeDataWithoutOffsetTimezone(new Date(value), false); //) new Date(new Date(value).getTime() + (new Date().getTimezoneOffset() * 60000));
        }
        return value;
    }

}());

