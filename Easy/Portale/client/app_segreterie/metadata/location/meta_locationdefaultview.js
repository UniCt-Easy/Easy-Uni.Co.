(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_locationdefaultview() {
        MetaData.apply(this, ["locationdefaultview"]);
        this.name = 'meta_locationdefaultview';
    }

    meta_locationdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_locationdefaultview,
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
					case 'default':
						this.describeAColumn(table, 'location_address', 'Indirizzo', null, 10, 100);
						this.describeAColumn(table, 'idlocation', 'id ubicazione (tabella location)', null, 10, null);
						this.describeAColumn(table, 'location_annotations', 'Note', null, 20, 400);
						this.describeAColumn(table, 'locationparent_description', 'chiave parent Piano delle Ubicazioni (tabella location) ', null, 20, 150);
						this.describeAColumn(table, 'location_cap', 'CAP', null, 30, 20);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, 150);
						this.describeAColumn(table, 'location_active', 'attivo', null, 40, null);
						this.describeAColumn(table, 'geo_city_title', 'Comune', null, 50, 65);
						this.describeAColumn(table, 'location_locationcode', 'Codice', null, 50, 50);
						this.describeAColumn(table, 'geo_nation_title', 'Nazione', null, 60, 65);
						this.describeAColumn(table, 'location_latitude', 'Latitudine', 'fixed.7', 70, null);
						this.describeAColumn(table, 'location_location', 'Localit?', null, 80, 20);
						this.describeAColumn(table, 'location_longitude', 'Longitudine', 'fixed.7', 90, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idlocation"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "locationparent_description asc , description asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('locationdefaultview', new meta_locationdefaultview('locationdefaultview'));

	}());
