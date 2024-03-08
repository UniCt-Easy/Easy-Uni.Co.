(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettostatuskinddefaultview() {
        MetaData.apply(this, ["progettostatuskinddefaultview"]);
        this.name = 'meta_progettostatuskinddefaultview';
    }

    meta_progettostatuskinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettostatuskinddefaultview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'title', 'Stato', null, 2000, 50);
						this.describeAColumn(table, 'progettostatuskind_sortcode', 'Ordinamento', null, 3000, null);
						this.describeAColumn(table, 'progettostatuskind_contributo', 'Abilita il cofinanziamento ottenuto dall\'ateneo', null, 8000, null);
						this.describeAColumn(table, 'progettostatuskind_contributoente', 'Abilita il contributo totale ottenuto per l\'ateneo dall’ente finanziatore', null, 9000, null);
						this.describeAColumn(table, 'progettostatuskind_contributoenterichiesto', 'Abilita il contributo totale richiesto dall\'ateneo all’ente finanziatore', null, 10000, null);
						this.describeAColumn(table, 'progettostatuskind_contributorichiesto', 'Abilita il cofinanziamento richiesto all\'ateneo', null, 11000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idprogettostatuskind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc, progettostatuskind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('progettostatuskinddefaultview', new meta_progettostatuskinddefaultview('progettostatuskinddefaultview'));

	}());
