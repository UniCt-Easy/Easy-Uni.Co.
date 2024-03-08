(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_insegndefaultview() {
        MetaData.apply(this, ["insegndefaultview"]);
        this.name = 'meta_insegndefaultview';
    }

    meta_insegndefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_insegndefaultview,
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
						this.describeAColumn(table, 'insegn_codice', 'Codice', null, 10, 50);
						this.describeAColumn(table, 'denominazione', 'Denominazione', null, 20, 256);
						this.describeAColumn(table, 'XXinsegncaratteristica', 'Caratteristiche dell\'insegnamento', null, 30, null);
						this.describeAColumn(table, 'XXinsegninteg', 'Insegnamenti integrandi', null, 40, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idinsegn"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "denominazione asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('insegndefaultview', new meta_insegndefaultview('insegndefaultview'));

	}());
