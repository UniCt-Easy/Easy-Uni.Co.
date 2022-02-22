(function () {

   // Deriva da MetaApp
    var MetaApp = BaseMetaApp;

   function Meta$template$App() {
      MetaApp.apply(this, arguments);
   }

   Meta$template$App.prototype = _.extend(
      new MetaApp(),
      {
         constructor: Meta$template$App,
         superClass: MetaApp.prototype,

         getMetaDataPath: function (tableName) {
            if (appMeta.config.env === appMeta.config.envEnum.PROD) {
               return this.basePathMetadata ? this.basePathMetadata : this.basePath;
            }
            return this.superClass.getMetaDataPath.call(this, tableName);
         }

      });

   window.appMeta = new Meta$template$App();
}());
