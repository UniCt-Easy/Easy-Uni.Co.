(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_afferenzastruview() {
        MetaData.apply(this, ["afferenzastruview"]);
        this.name = 'meta_afferenzastruview';
    }

    meta_afferenzastruview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_afferenzastruview,
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
					case 'stru':
						this.describeAColumn(table, 'registry_title', 'Membro del personale', null, 1300, 101);
						this.describeAColumn(table, 'mansionekind_title', 'Mansione', null, 2200, 2048);
						this.describeAColumn(table, 'afferenza_start', 'Dal ', 'g', 5000, null);
						this.describeAColumn(table, 'afferenza_stop', 'Al ', 'g', 6000, null);
//$objCalcFieldConfig_stru$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idafferenza", "idstruttura"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('afferenzastruview', new meta_afferenzastruview('afferenzastruview'));

	}());
