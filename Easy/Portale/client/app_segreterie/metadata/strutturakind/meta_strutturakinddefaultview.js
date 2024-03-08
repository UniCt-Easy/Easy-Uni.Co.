(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_strutturakinddefaultview() {
        MetaData.apply(this, ["strutturakinddefaultview"]);
        this.name = 'meta_strutturakinddefaultview';
    }

    meta_strutturakinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_strutturakinddefaultview,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'strutturakind_description', 'Descrizione', null, 30, 256);
						this.describeAColumn(table, 'strutturakind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'strutturakind_sortCode', 'SortCode', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idstrutturakind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('strutturakinddefaultview', new meta_strutturakinddefaultview('strutturakinddefaultview'));

	}());
