(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registrystudentiview() {
        MetaData.apply(this, ["registrystudentiview"]);
        this.name = 'meta_registrystudentiview';
    }

    meta_registrystudentiview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registrystudentiview,
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
					case 'studenti':
						this.describeAColumn(table, 'registry_surname', 'Cognome', null, 1000, 50);
						this.describeAColumn(table, 'registry_forename', 'Nome', null, 2000, 50);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 4000, 16);
						this.describeAColumn(table, 'registry_extmatricula', 'Matricola', null, 5000, 40);
						this.describeAColumn(table, 'registry_active', 'attivo', null, 6000, null);
//$objCalcFieldConfig_studenti$
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
					case "studenti": {
						return "registry_surname asc, registry_forename asc";
					}
					case "studenti": {
						return "registry_surname asc , registry_forename asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registrystudentiview', new meta_registrystudentiview('registrystudentiview'));

	}());
