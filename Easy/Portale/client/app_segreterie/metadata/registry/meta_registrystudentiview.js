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
						this.describeAColumn(table, 'title', 'Denominazione', null, 3000, 101);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 4000, 16);
						this.describeAColumn(table, 'registry_p_iva', 'Partita iva', null, 5000, 15);
						this.describeAColumn(table, 'registry_active', 'attivo', null, 6000, null);
						this.describeAColumn(table, 'registry_studenti_authinps', 'Autorizzazione all\'istituto di accedere ai propri dati INPS', null, 30000, null);
						this.describeAColumn(table, 'studdirittokind_title', 'Tipologia per il diritto allo studio', null, 31200, 50);
						this.describeAColumn(table, 'studprenotkind_title', 'Tipologia per la prenotazione degli appelli', null, 32200, 50);
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
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registrystudentiview', new meta_registrystudentiview('registrystudentiview'));

	}());
