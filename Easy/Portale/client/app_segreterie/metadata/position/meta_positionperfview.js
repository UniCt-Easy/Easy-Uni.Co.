(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_positionperfview() {
        MetaData.apply(this, ["positionperfview"]);
        this.name = 'meta_positionperfview';
    }

    meta_positionperfview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_positionperfview,
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
					case 'perf':
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, 50);
						this.describeAColumn(table, 'position_active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'position_codeposition', 'Codice', null, 40, 20);
						this.describeAColumn(table, 'position_perf_pesoateneo', 'Peso della valutazione della performance organizzativa di ateneo', 'fixed.2', 520, null);
						this.describeAColumn(table, 'position_perf_pesoindividuale', 'Peso della valutazione della performance individuale', 'fixed.2', 530, null);
						this.describeAColumn(table, 'position_perf_pesouo', 'Peso della valutazione della performance dell’unità organizzativa', 'fixed.2', 540, null);
//$objCalcFieldConfig_perf$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idposition"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('positionperfview', new meta_positionperfview('positionperfview'));

	}());
