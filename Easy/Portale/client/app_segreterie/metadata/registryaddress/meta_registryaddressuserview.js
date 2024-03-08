(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registryaddressuserview() {
        MetaData.apply(this, ["registryaddressuserview"]);
        this.name = 'meta_registryaddressuserview';
    }

    meta_registryaddressuserview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryaddressuserview,
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
					case 'user':
						this.describeAColumn(table, 'address', 'Indirizzo', null, 70, 100);
						this.describeAColumn(table, 'geo_city_title', 'Comune', null, 90, 65);
						this.describeAColumn(table, 'registryaddress_location', 'Località', null, 100, 50);
						this.describeAColumn(table, 'registryaddress_cap', 'CAP', null, 110, 20);
//$objCalcFieldConfig_user$
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

			getSorting: function (listType) {
				switch (listType) {
					case "user": {
						return "";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registryaddressuserview', new meta_registryaddressuserview('registryaddressuserview'));

	}());
