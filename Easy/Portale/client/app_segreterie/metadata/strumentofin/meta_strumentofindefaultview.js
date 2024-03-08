(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_strumentofindefaultview() {
        MetaData.apply(this, ["strumentofindefaultview"]);
        this.name = 'meta_strumentofindefaultview';
    }

    meta_strumentofindefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_strumentofindefaultview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2048);
						this.describeAColumn(table, 'strumentofin_description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'strumentofin_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'strumentofin_sortcode', 'Ordinamento', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idstrumentofin"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					case "default": {
						return "title desc, strumentofin_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('strumentofindefaultview', new meta_strumentofindefaultview('strumentofindefaultview'));

	}());
