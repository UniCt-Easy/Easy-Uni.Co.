(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_convalidakinddefaultview() {
        MetaData.apply(this, ["convalidakinddefaultview"]);
        this.name = 'meta_convalidakinddefaultview';
    }

    meta_convalidakinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_convalidakinddefaultview,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 2000, 128);
						this.describeAColumn(table, 'convalidakind_description', 'Descrizione', null, 3000, 256);
						this.describeAColumn(table, 'convalidakind_active', 'Attivo', null, 4000, null);
						this.describeAColumn(table, 'convalidakind_sortcode', 'Ordinamento', null, 5000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idconvalidakind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					case "default": {
						return "title desc, convalidakind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('convalidakinddefaultview', new meta_convalidakinddefaultview('convalidakinddefaultview'));

	}());
