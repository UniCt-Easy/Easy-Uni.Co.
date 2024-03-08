(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfrequestobbindividualedefaultview() {
        MetaData.apply(this, ["perfrequestobbindividualedefaultview"]);
        this.name = 'meta_perfrequestobbindividualedefaultview';
    }

    meta_perfrequestobbindividualedefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfrequestobbindividualedefaultview,
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
						this.describeAColumn(table, 'registry_title', 'Valutato', null, 1300, 101);
						this.describeAColumn(table, 'title', 'Titolo obiettivo', null, 2000, 1024);
						this.describeAColumn(table, 'year', 'Anno solare', null, 2000, null);
						this.describeAColumn(table, 'perfrequestobbindividuale_description', 'Descrizione', null, 3000, -1);
						this.describeAColumn(table, 'perfrequestobbindividuale_peso', 'Peso', 'fixed.2', 5000, null);
						this.describeAColumn(table, 'perfrequestobbindividuale_inserito', 'Inserito', null, 6000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idperfrequestobbindividuale"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfrequestobbindividualedefaultview', new meta_perfrequestobbindividualedefaultview('perfrequestobbindividualedefaultview'));

	}());
