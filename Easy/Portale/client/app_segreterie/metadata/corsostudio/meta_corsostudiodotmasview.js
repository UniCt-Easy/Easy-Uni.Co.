(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_corsostudiodotmasview() {
        MetaData.apply(this, ["corsostudiodotmasview"]);
        this.name = 'meta_corsostudiodotmasview';
    }

    meta_corsostudiodotmasview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_corsostudiodotmasview,
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
					case 'dotmas':
						this.describeAColumn(table, 'title', 'Denominazione', null, 1000, 1024);
						this.describeAColumn(table, 'corsostudio_title_en', 'Denominazione (EN)', null, 2000, 1024);
						this.describeAColumn(table, 'corsostudio_codice', 'Codice', null, 3000, 50);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Struttura di riferimento', null, 7100, 1024);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo Struttura di riferimento', null, 7220, 50);
//$objCalcFieldConfig_dotmas$
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
					case "dotmas": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('corsostudiodotmasview', new meta_corsostudiodotmasview('corsostudiodotmasview'));

	}());
