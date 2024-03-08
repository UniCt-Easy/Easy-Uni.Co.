(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_relatorekinddefaultview() {
        MetaData.apply(this, ["relatorekinddefaultview"]);
        this.name = 'meta_relatorekinddefaultview';
    }

    meta_relatorekinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_relatorekinddefaultview,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'relatorekind_description', 'Descrizione', null, 30, 256);
						this.describeAColumn(table, 'relatorekind_active', 'Attivo', null, 40, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idrelatorekind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('relatorekinddefaultview', new meta_relatorekinddefaultview('relatorekinddefaultview'));

	}());
