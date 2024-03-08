(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_afferenzaammview() {
        MetaData.apply(this, ["afferenzaammview"]);
        this.name = 'meta_afferenzaammview';
    }

    meta_afferenzaammview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_afferenzaammview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'amm':
						this.describeAColumn(table, 'struttura_title', 'Denominazione U.O.', null, 1100, 1024);
						this.describeAColumn(table, 'strutturaparent_title', 'Denominazione U.O. madre U.O.', null, 1910, 1024);
						this.describeAColumn(table, 'afferenza_start', 'Dal', 'g', 4000, null);
						this.describeAColumn(table, 'afferenza_stop', 'Al', 'g', 5000, null);
						this.describeAColumn(table, 'mansionekind_title', 'Mansione', null, 10200, 2048);
//$objCalcFieldConfig_amm$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idafferenza"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('afferenzaammview', new meta_afferenzaammview('afferenzaammview'));

	}());
