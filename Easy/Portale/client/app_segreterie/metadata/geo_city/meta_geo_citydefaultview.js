(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_geo_citydefaultview() {
        MetaData.apply(this, ["geo_citydefaultview"]);
        this.name = 'meta_geo_citydefaultview';
    }

    meta_geo_citydefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_geo_citydefaultview,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 65);
						this.describeAColumn(table, 'idcity', 'Codice', null, 20, null);
						this.describeAColumn(table, 'geo_country_title', 'id paese (tabella geo_country)', null, 30, 50);
						this.describeAColumn(table, 'geo_city_1_title', 'id nuovo comune in cui questo è eventualmente confluito, se valorizzato questo comune non è più valido', null, 40, 65);
						this.describeAColumn(table, 'geo_city_2_title', 'id comune da cui questo è confluito', null, 50, 65);
						this.describeAColumn(table, 'geo_city_start', 'data inizio', null, 60, null);
						this.describeAColumn(table, 'geo_city_stop', 'data fine', null, 70, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcity"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('geo_citydefaultview', new meta_geo_citydefaultview('geo_citydefaultview'));

	}());
