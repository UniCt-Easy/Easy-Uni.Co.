(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_provadefaultview() {
        MetaData.apply(this, ["provadefaultview"]);
        this.name = 'meta_provadefaultview';
    }

    meta_provadefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_provadefaultview,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 1000, 50);
						this.describeAColumn(table, 'prova_start', 'Data e ora inizio', 'g', 2000, null);
						this.describeAColumn(table, 'prova_stop', 'Data e ora fine', 'g', 3000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idprova", "idappello"];
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

    window.appMeta.addMeta('provadefaultview', new meta_provadefaultview('provadefaultview'));

	}());
