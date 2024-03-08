(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registryamministrativi_personaleview() {
        MetaData.apply(this, ["registryamministrativi_personaleview"]);
        this.name = 'meta_registryamministrativi_personaleview';
    }

    meta_registryamministrativi_personaleview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryamministrativi_personaleview,
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
					case 'amministrativi_personale':
						this.describeAColumn(table, 'title_description', 'Titolo', null, 1200, 50);
						this.describeAColumn(table, 'registry_surname', 'Cognome', null, 2000, 50);
						this.describeAColumn(table, 'registry_forename', 'Nome', null, 3000, 50);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 4000, 16);
						this.describeAColumn(table, 'registry_badgecode', 'Codice bedge', null, 5000, 20);
						this.describeAColumn(table, 'registry_active', 'Attivo', null, 10000, null);
//$objCalcFieldConfig_amministrativi_personale$
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

			//$getSorting$

        });

    window.appMeta.addMeta('registryamministrativi_personaleview', new meta_registryamministrativi_personaleview('registryamministrativi_personaleview'));

	}());
