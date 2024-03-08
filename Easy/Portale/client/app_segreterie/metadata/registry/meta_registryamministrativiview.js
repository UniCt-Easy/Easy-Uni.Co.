(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registryamministrativiview() {
        MetaData.apply(this, ["registryamministrativiview"]);
        this.name = 'meta_registryamministrativiview';
    }

    meta_registryamministrativiview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryamministrativiview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'amministrativi':
						this.describeAColumn(table, 'title_description', 'Titolo', null, 1200, 50);
						this.describeAColumn(table, 'registry_surname', 'Cognome', null, 2000, 50);
						this.describeAColumn(table, 'registry_forename', 'Nome', null, 3000, 50);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 4000, 16);
						this.describeAColumn(table, 'registry_badgecode', 'Codice badge', null, 5000, 20);
						this.describeAColumn(table, 'registry_active', 'Attivo', null, 10000, null);
						this.describeAColumn(table, 'XXregistrylegalstatus', 'Servizi di ruolo - Contratti', null, 52000, null);
//$objCalcFieldConfig_amministrativi$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "amministrativi": {
						return "title asc ";
					}
					case "amministrativi": {
						return "registry_surname asc , registry_forename asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registryamministrativiview', new meta_registryamministrativiview('registryamministrativiview'));

	}());
