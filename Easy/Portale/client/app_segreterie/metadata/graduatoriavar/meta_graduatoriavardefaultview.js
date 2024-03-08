(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_graduatoriavardefaultview() {
        MetaData.apply(this, ["graduatoriavardefaultview"]);
        this.name = 'meta_graduatoriavardefaultview';
    }

    meta_graduatoriavardefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_graduatoriavardefaultview,
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
						this.describeAColumn(table, 'graduatoriavar_description', 'Descrizione', null, 30, 256);
						this.describeAColumn(table, 'graduatoriavar_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'graduatoriavar_sortcode', 'Sortcode', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idgraduatoriavar"];
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

    window.appMeta.addMeta('graduatoriavardefaultview', new meta_graduatoriavardefaultview('graduatoriavardefaultview'));

	}());
