(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiaraltrititoli_segview() {
        MetaData.apply(this, ["dichiaraltrititoli_segview"]);
        this.name = 'meta_dichiaraltrititoli_segview';
    }

    meta_dichiaraltrititoli_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiaraltrititoli_segview,
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
					case 'altrititoli_seg':
						this.describeAColumn(table, 'registry_title', 'Studente', null, 520, 101);
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 580, 9);
						this.describeAColumn(table, 'dichiar_date', 'Data', null, 590, null);
						this.describeAColumn(table, 'dichiar_altrititoli_title', 'Titolo', null, 510, 1024);
						this.describeAColumn(table, 'dichiar_altrititoli_dataottenimento', 'Data ottenimento', null, 520, null);
						this.describeAColumn(table, 'dichiar_altrititoli_rilasciatoda', 'Rilasciato da', null, 550, 1024);
//$objCalcFieldConfig_altrititoli_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddichiar"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "altrititoli_seg": {
						return "dichiar_altrititoli_title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('dichiaraltrititoli_segview', new meta_dichiaraltrititoli_segview('dichiaraltrititoli_segview'));

	}());
