(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_classconsorsualedefaultview() {
        MetaData.apply(this, ["classconsorsualedefaultview"]);
        this.name = 'meta_classconsorsualedefaultview';
    }

    meta_classconsorsualedefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_classconsorsualedefaultview,
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
						this.describeAColumn(table, 'title', 'Codice', null, 1000, 50);
						this.describeAColumn(table, 'classconsorsuale_description', 'Descrizione', null, 2000, 512);
						this.describeAColumn(table, 'classconsorsuale_active', 'Attivo', null, 3000, null);
						this.describeAColumn(table, 'classconsorsuale_ambitodisci', 'Ambito Disciplinare', null, 4000, 50);
						this.describeAColumn(table, 'classconsorsuale_normativa', 'Normativa', null, 5000, 50);
						this.describeAColumn(table, 'classconsorsuale_corr2592017', 'Corrispondenza', null, 6000, 50);
						this.describeAColumn(table, 'classconsorsuale_tipoente', 'Tipologia di ente', null, 10000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idclassconsorsuale"];
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

    window.appMeta.addMeta('classconsorsualedefaultview', new meta_classconsorsualedefaultview('classconsorsualedefaultview'));

	}());
