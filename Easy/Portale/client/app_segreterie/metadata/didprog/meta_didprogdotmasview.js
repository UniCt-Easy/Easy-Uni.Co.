(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didprogdotmasview() {
        MetaData.apply(this, ["didprogdotmasview"]);
        this.name = 'meta_didprogdotmasview';
    }

    meta_didprogdotmasview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprogdotmasview,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 190, 1024);
						this.describeAColumn(table, 'geo_nationlang_lang', 'Lingua di erogazione', null, 200, 64);
//$objCalcFieldConfig_dotmas$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddidprog", "idcorsostudio"];
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

    window.appMeta.addMeta('didprogdotmasview', new meta_didprogdotmasview('didprogdotmasview'));

	}());
