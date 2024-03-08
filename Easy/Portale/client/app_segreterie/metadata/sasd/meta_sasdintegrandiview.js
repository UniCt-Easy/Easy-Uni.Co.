(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sasdintegrandiview() {
        MetaData.apply(this, ["sasdintegrandiview"]);
        this.name = 'meta_sasdintegrandiview';
    }

    meta_sasdintegrandiview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sasdintegrandiview,
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
					case 'integrandi':
						this.describeAColumn(table, 'idsasd', 'Codice Istituto', null, 10, null);
						this.describeAColumn(table, 'codice', 'Codice', null, 20, 50);
						this.describeAColumn(table, 'sasd_title', 'Denominazione', null, 30, 255);
						this.describeAColumn(table, 'areadidattica_title', 'Area o ambito disciplinare', null, 40, 100);
						this.describeAColumn(table, 'sasd_codice_old', 'Codice legge precedente', null, 50, 4);
//$objCalcFieldConfig_integrandi$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idsasd"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "integrandi": {
						return "codice asc , sasd_title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('sasdintegrandiview', new meta_sasdintegrandiview('sasdintegrandiview'));

	}());
