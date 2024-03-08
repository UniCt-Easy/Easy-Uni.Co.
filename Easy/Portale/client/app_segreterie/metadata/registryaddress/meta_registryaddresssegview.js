(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registryaddresssegview() {
        MetaData.apply(this, ["registryaddresssegview"]);
        this.name = 'meta_registryaddresssegview';
    }

    meta_registryaddresssegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryaddresssegview,
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
					case 'seg':
						this.describeAColumn(table, 'address_description', 'Tipologia', null, 10, 60);
						this.describeAColumn(table, 'start', 'Data inizio', null, 20, null);
						this.describeAColumn(table, 'registryaddress_stop', 'Data fine', null, 30, null);
						this.describeAColumn(table, 'registryaddress_active', 'Attivo', null, 60, null);
						this.describeAColumn(table, 'registryaddress_address', 'Indirizzo', null, 70, 100);
						this.describeAColumn(table, 'registryaddress_flagforeign', 'Estero', null, 80, null);
						this.describeAColumn(table, 'geo_city_title', 'Comune', null, 90, 65);
						this.describeAColumn(table, 'registryaddress_location', 'Località', null, 100, 50);
						this.describeAColumn(table, 'registryaddress_cap', 'CAP', null, 110, 20);
						this.describeAColumn(table, 'geo_nation_title', 'Nazione', null, 120, 65);
						this.describeAColumn(table, 'registryaddress_annotations', 'Annotazioni', null, 130, 400);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "start", "idaddresskind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('registryaddresssegview', new meta_registryaddresssegview('registryaddresssegview'));

	}());
