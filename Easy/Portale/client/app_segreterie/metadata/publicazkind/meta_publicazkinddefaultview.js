(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_publicazkinddefaultview() {
        MetaData.apply(this, ["publicazkinddefaultview"]);
        this.name = 'meta_publicazkinddefaultview';
    }

    meta_publicazkinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_publicazkinddefaultview,
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
						this.describeAColumn(table, 'idpublicazkind', 'Codice', null, 10, null);
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'publicazkind_subtitle', 'Sotto-tipologia', null, 30, 256);
						this.describeAColumn(table, 'publicazkind_sortcode', 'Sortcode', null, 40, null);
						this.describeAColumn(table, 'publicazkind_active', 'Attivo', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idpublicazkind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc, publicazkind_sortcode asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('publicazkinddefaultview', new meta_publicazkinddefaultview('publicazkinddefaultview'));

	}());
