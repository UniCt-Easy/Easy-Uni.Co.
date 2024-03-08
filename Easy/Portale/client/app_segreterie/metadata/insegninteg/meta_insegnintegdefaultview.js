(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_insegnintegdefaultview() {
        MetaData.apply(this, ["insegnintegdefaultview"]);
        this.name = 'meta_insegnintegdefaultview';
    }

    meta_insegnintegdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_insegnintegdefaultview,
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
						this.describeAColumn(table, 'insegninteg_codice', 'Codice', null, 20, 50);
						this.describeAColumn(table, 'denominazione', 'Denominazione', null, 30, 256);
						this.describeAColumn(table, 'XXinsegnintegcaratteristica', 'Caratteristiche degli insegnamenti integrandi', null, 30, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idinsegn", "idinsegninteg"];
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

    window.appMeta.addMeta('insegnintegdefaultview', new meta_insegnintegdefaultview('insegnintegdefaultview'));

	}());
