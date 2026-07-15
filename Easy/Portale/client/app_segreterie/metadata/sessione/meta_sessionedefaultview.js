(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sessionedefaultview() {
        MetaData.apply(this, ["sessionedefaultview"]);
        this.name = 'meta_sessionedefaultview';
    }

    meta_sessionedefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sessionedefaultview,
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
						this.describeAColumn(table, 'start', 'Data di inizio', null, 1000, null);
						this.describeAColumn(table, 'sessione_stop', 'Data di fine', null, 2000, null);
						this.describeAColumn(table, 'sessionekind_title', 'Tipologia', null, 3200, 50);
						this.describeAColumn(table, 'appellokind_title', 'Tipologia di appello', null, 4200, 50);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idsessione"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "start desc, sessionekind_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('sessionedefaultview', new meta_sessionedefaultview('sessionedefaultview'));

	}());
