(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_studdirittokinddefaultview() {
        MetaData.apply(this, ["studdirittokinddefaultview"]);
        this.name = 'meta_studdirittokinddefaultview';
    }

    meta_studdirittokinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_studdirittokinddefaultview,
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
						this.describeAColumn(table, 'idstuddirittokind', 'Codice', null, 10, null);
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'studdirittokind_description', 'Descrizione', null, 30, 512);
						this.describeAColumn(table, 'studdirittokind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'studdirittokind_sortorder', 'Ordine', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idstuddirittokind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "studdirittokind_sortorder asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('studdirittokinddefaultview', new meta_studdirittokinddefaultview('studdirittokinddefaultview'));

	}());
