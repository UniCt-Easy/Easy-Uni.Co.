(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_naturagiurdefaultview() {
        MetaData.apply(this, ["naturagiurdefaultview"]);
        this.name = 'meta_naturagiurdefaultview';
    }

    meta_naturagiurdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_naturagiurdefaultview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 200);
						this.describeAColumn(table, 'naturagiur_active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'naturagiur_flagforeign', 'Flagforeign', null, 40, null);
						this.describeAColumn(table, 'naturagiur_sortcode', 'Ordinamento', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idnaturagiur"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					case "default": {
						return "title desc, naturagiur_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('naturagiurdefaultview', new meta_naturagiurdefaultview('naturagiurdefaultview'));

	}());
