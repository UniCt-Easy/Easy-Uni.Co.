(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_cefrdefaultview() {
        MetaData.apply(this, ["cefrdefaultview"]);
        this.name = 'meta_cefrdefaultview';
    }

    meta_cefrdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_cefrdefaultview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 50);
						this.describeAColumn(table, 'cefr_active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'cefr_sortcode', 'Ordine', null, 90, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcefr"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "cefr_sortcode asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('cefrdefaultview', new meta_cefrdefaultview('cefrdefaultview'));

	}());
