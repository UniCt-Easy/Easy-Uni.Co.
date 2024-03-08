(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didprogporzannodefaultview() {
        MetaData.apply(this, ["didprogporzannodefaultview"]);
        this.name = 'meta_didprogporzannodefaultview';
    }

    meta_didprogporzannodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprogporzannodefaultview,
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
						this.describeAColumn(table, 'didprogporzanno_indice', 'Indice', null, 10, null);
						this.describeAColumn(table, 'didprogporzannokind_title', 'Durata', null, 20, 50);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "iddidprog", "iddidprogori", "idcorsostudio", "iddidproganno", "iddidprogcurr", "iddidprogporzanno"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "didprogporzanno_indice desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('didprogporzannodefaultview', new meta_didprogporzannodefaultview('didprogporzannodefaultview'));

	}());
