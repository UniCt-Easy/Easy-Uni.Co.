(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didprogoridefaultview() {
        MetaData.apply(this, ["didprogoridefaultview"]);
        this.name = 'meta_didprogoridefaultview';
    }

    meta_didprogoridefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprogoridefaultview,
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
						this.describeAColumn(table, 'corsostudio_title', 'Denominazione Identificativo', null, 10, 1024);
						this.describeAColumn(table, 'corsostudio_annoistituz', 'Anno accademico di istituzione Identificativo', null, 10, null);
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 256);
						this.describeAColumn(table, 'didprogori_codice', 'Codice', null, 30, 50);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddidprog", "iddidprogori", "idcorsostudio", "iddidprogcurr"];
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

    window.appMeta.addMeta('didprogoridefaultview', new meta_didprogoridefaultview('didprogoridefaultview'));

	}());
