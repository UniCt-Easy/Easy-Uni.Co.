(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_atecodefaultview() {
        MetaData.apply(this, ["atecodefaultview"]);
        this.name = 'meta_atecodefaultview';
    }

    meta_atecodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_atecodefaultview,
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
						this.describeAColumn(table, 'codice', 'Codice', null, 20, 50);
						this.describeAColumn(table, 'ateco_title', 'Titolo', null, 30, 255);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idateco"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "codice asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('atecodefaultview', new meta_atecodefaultview('atecodefaultview'));

	}());
