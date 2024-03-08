(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_canaleerogataview() {
        MetaData.apply(this, ["canaleerogataview"]);
        this.name = 'meta_canaleerogataview';
    }

    meta_canaleerogataview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_canaleerogataview,
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
					case 'erogata':
						this.describeAColumn(table, 'didprogcurr_title', 'Curriculum', null, 1200, 256);
						this.describeAColumn(table, 'didprogori_title', 'Orientamento', null, 2200, 256);
						this.describeAColumn(table, 'didproganno_title', 'Anno', null, 3100, 2048);
						this.describeAColumn(table, 'didprogporzanno_title', 'Porzione d\'anno', null, 4100, 2048);
						this.describeAColumn(table, 'attivform_title', 'Attività formativa', null, 5100, -1);
						this.describeAColumn(table, 'title', 'Denominazione', null, 6000, 256);
						this.describeAColumn(table, 'canale_CUIN', 'CUIN', null, 7000, 9);
						this.describeAColumn(table, 'XXaffidamento', 'Affidamento', null, 15000, null);
						this.describeAColumn(table, 'XXmutuazione', 'Mutuazione o fruizione', null, 16000, null);
//$objCalcFieldConfig_erogata$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "idcanale", "iddidprog", "idattivform", "iddidprogori", "idcorsostudio", "iddidproganno", "iddidprogcurr", "iddidprogporzanno"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "erogata": {
						return "didprogcurr_title asc , didprogori_title asc , didproganno_title asc , didprogporzanno_title asc , attivform_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('canaleerogataview', new meta_canaleerogataview('canaleerogataview'));

	}());
