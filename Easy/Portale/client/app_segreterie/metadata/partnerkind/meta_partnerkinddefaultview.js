(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_partnerkinddefaultview() {
        MetaData.apply(this, ["partnerkinddefaultview"]);
        this.name = 'meta_partnerkinddefaultview';
    }

    meta_partnerkinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_partnerkinddefaultview,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 2048);
						this.describeAColumn(table, 'partnerkind_description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'partnerkind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'partnerkind_sortcode', 'Ordinamento', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idpartnerkind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc, partnerkind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('partnerkinddefaultview', new meta_partnerkinddefaultview('partnerkinddefaultview'));

	}());
