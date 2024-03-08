(function() {
    var MetaPage = window.appMeta.MetaPage;

    function metaPage_registry() {
        MetaPage.apply(this, arguments);
        this.name = 'Anagrafica';
    }

    metaPage_registry.prototype = _.extend(
        new MetaPage('registry', 'anagrafica', false),
        {
            constructor: metaPage_registry,

            superClass: MetaPage.prototype,

            /**
             * @method getName
             * @private
             * @description SYNC - Overriden
             * Sets the name of the page
             */
            getName:function () {
               return this.name;
            },

            /**
             * @method afterLink
             * @private
             * @description SYNC - Overriden
             */
            afterLink:function () {
                // mette le dipendenze tra controlli
                this.configureDependencies();
            },

            /**
             *
             */
            configureDependencies:function () {
                // N.B i controlli padre e figlio con dipendenze devono aver settato un id su html
                // poichè MDWL usa id al suo interno. Capire se e come ovviare a questa cosa.
                var p1 = $("input[data-tag='registry.surname']");
                var p2 = $("input[data-tag='registry.forename']");
                var f1 = $("input[data-tag='registry.title']");

                // funz di trasformazione
                var modifiesDenominazione = function (row) {
                    if (!row) return;
                    var vSurname = (row['surname'] === null || row['surname'] === undefined)  ? "" : row['surname']  ;
                    var vForename = (row['forename'] === null || row['forename'] === undefined)  ? "" : row['forename'] ;
                    return vSurname + " " + vForename;
                };
                this.registerFormula(f1, modifiesDenominazione);

                this.addDependencies(p1, f1); 
                this.addDependencies(p2, f1);
            }
        });

	window.appMeta.addMetaPage('registry', 'anagrafica', metaPage_registry);

}());
