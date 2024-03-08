(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registryaziendeview() {
        MetaData.apply(this, ["registryaziendeview"]);
        this.name = 'meta_registryaziendeview';
    }

    meta_registryaziendeview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryaziendeview,
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
					case 'aziende':
						this.describeAColumn(table, 'title', 'Denominazione', null, 1000, 101);
						this.describeAColumn(table, 'registryclass_description', 'Tipologia', null, 2200, 150);
						this.describeAColumn(table, 'registry_cf', 'Codice fiscale', null, 4000, 16);
						this.describeAColumn(table, 'registry_p_iva', 'Partita iva', null, 5000, 15);
						this.describeAColumn(table, 'registry_active', 'attivo', null, 6000, null);
						this.describeAColumn(table, 'ateco_codice', 'Codice Classificazione Ateco', null, 7200, 50);
						this.describeAColumn(table, 'ateco_title', 'Titolo Classificazione Ateco', null, 7300, 255);
						this.describeAColumn(table, 'naturagiur_title', 'Natura Giuridica', null, 8200, 200);
						this.describeAColumn(table, 'numerodip_title', 'Numero di dipendenti', null, 9200, 50);
						this.describeAColumn(table, 'nace_idnace', 'Identificativo NACE', null, 10100, 50);
						this.describeAColumn(table, 'nace_activity', 'Activity NACE', null, 10200, -1);
						this.describeAColumn(table, 'geo_nation_title', 'Nazionalità', null, 11300, 65);
						this.describeAColumn(table, 'registry_pic', 'Participant Identification Code (PIC)', null, 12000, 10);
						this.describeAColumn(table, 'registry_flag_pa', 'Ente pubblico', null, 100000, null);
//$objCalcFieldConfig_aziende$
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
					case "aziende": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registryaziendeview', new meta_registryaziendeview('registryaziendeview'));

	}());
