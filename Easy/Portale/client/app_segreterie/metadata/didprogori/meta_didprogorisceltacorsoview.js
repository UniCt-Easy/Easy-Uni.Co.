(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didprogorisceltacorsoview() {
        MetaData.apply(this, ["didprogorisceltacorsoview"]);
        this.name = 'meta_didprogorisceltacorsoview';
    }

    meta_didprogorisceltacorsoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprogorisceltacorsoview,
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
					case 'sceltacorso':
						this.describeAColumn(table, 'corsostudio_title', 'Denominazione Identificativo', null, 10, 1024);
						this.describeAColumn(table, 'corsostudio_annoistituz', 'Anno accademico di istituzione Identificativo', null, 10, null);
						this.describeAColumn(table, 'didprogori_title', 'Denominazione', null, 20, 256);
						this.describeAColumn(table, 'didprogori_codice', 'Codice', null, 30, 50);
//$objCalcFieldConfig_sceltacorso$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddidprog", "iddidprogori", "idcorsostudio", "iddidprogcurr"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "sceltacorso": {
						return "didprogori_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('didprogorisceltacorsoview', new meta_didprogorisceltacorsoview('didprogorisceltacorsoview'));

	}());
