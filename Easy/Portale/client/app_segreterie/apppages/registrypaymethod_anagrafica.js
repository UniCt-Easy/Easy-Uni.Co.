(function() {
    var MetaPage = window.appMeta.MetaPage;

    function metaPage_registrypaymethod() {
        MetaPage.apply(this, arguments);
        this.name = 'Registrypaymethod - Anagrafica';
    }

    metaPage_registrypaymethod.prototype = _.extend(
        new MetaPage('registrypaymethod', 'anagrafica', true),
        {
            constructor: metaPage_registrypaymethod,

            superClass: MetaPage.prototype,

            /**
             * @method getName
             * @private
             * @description SYNC - Overriden
             * Sets the name of the page
             */
            getName:function () {
               return this.name;
            }
        });

    window.appMeta.addMetaPage('registrypaymethod', 'anagrafica', metaPage_registrypaymethod);
}());
