(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_aooprincview() {
        MetaData.apply(this, ["aooprincview"]);
        this.name = 'meta_aooprincview';
    }

    meta_aooprincview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_aooprincview,
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
					case 'princ':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 1024);
						this.describeAColumn(table, 'aoo_codiceaooipa', 'Codice IPA', null, 30, 50);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 40, 1024);
//$objCalcFieldConfig_princ$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idaoo"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "princ": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('aooprincview', new meta_aooprincview('aooprincview'));

	}());
