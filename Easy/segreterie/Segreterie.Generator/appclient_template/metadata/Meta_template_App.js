(function () {

    // Deriva da MetaApp
    var MetaApp = appMeta.MetaApp;

   function Meta$template$App() {
        MetaApp.apply(this, arguments);
    }

   Meta$template$App.prototype = _.extend(
        new MetaApp(),
        {
            constructor: Meta$template$App,
            superClass: MetaApp.prototype,
        });

    appMeta.currApp = new Meta$template$App();

    //We save the original getMetaDataPath function
    let baseGetPageDataPath = appMeta.getMetaPagePath;

    appMeta.getMetaPagePath = function (tableName) {
        if (appMeta.config.env === appMeta.config.envEnum.PROD) {
            return this.basePathMetadata ? this.basePathMetadata : this.basePath;
        }
        //We invoke the original function
        return baseGetPageDataPath.call(this, tableName);
    }

    appMeta.callWebService = function (method, prms) {
        return appMeta.currApp.callWebService(method,prms);
    }


}());
