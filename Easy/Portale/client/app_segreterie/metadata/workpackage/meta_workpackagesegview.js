(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_workpackagesegview() {
        MetaData.apply(this, ["workpackagesegview"]);
        this.name = 'meta_workpackagesegview';
    }

    meta_workpackagesegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_workpackagesegview,
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
						this.describeAColumn(table, 'raggruppamento', 'Raggruppamento', null, 1000, 2048);
						this.describeAColumn(table, 'workpackage_title', 'Titolo', null, 2000, 2048);
						this.describeAColumn(table, 'workpackage_acronimo', 'Acronimo', null, 3000, 2048);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Dipartimento', null, 5100, 1024);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo Dipartimento', null, 5220, 50);
						this.describeAColumn(table, 'workpackage_start', 'Data di inizio', null, 10000, null);
						this.describeAColumn(table, 'workpackage_stop', 'Data di fine', null, 11000, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idprogetto", "idworkpackage"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "raggruppamento asc , workpackage_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('workpackagesegview', new meta_workpackagesegview('workpackagesegview'));

	}());
