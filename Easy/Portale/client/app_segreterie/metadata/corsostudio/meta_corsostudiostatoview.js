(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_corsostudiostatoview() {
        MetaData.apply(this, ["corsostudiostatoview"]);
        this.name = 'meta_corsostudiostatoview';
    }

    meta_corsostudiostatoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_corsostudiostatoview,
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
					case 'stato':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'corsostudio_title_en', 'Denominazione (EN)', null, 20, 1024);
						this.describeAColumn(table, 'corsostudio_codice', 'Codice', null, 30, 50);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Struttura di riferimento', null, 70, 1024);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo', null, 20, 50);
						this.describeAColumn(table, 'struttura_idstrutturakind', 'Tipo Tipo', null, 20, null);
//$objCalcFieldConfig_stato$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcorsostudio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "stato": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('corsostudiostatoview', new meta_corsostudiostatoview('corsostudiostatoview'));

	}());
