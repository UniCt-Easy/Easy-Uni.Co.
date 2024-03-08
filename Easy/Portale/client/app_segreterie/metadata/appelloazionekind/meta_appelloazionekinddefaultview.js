(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_appelloazionekinddefaultview() {
        MetaData.apply(this, ["appelloazionekinddefaultview"]);
        this.name = 'meta_appelloazionekinddefaultview';
    }

    meta_appelloazionekinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_appelloazionekinddefaultview,
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
						this.describeAColumn(table, 'appelloazionekind_description', 'Descrizione', null, 30, 250);
						this.describeAColumn(table, 'appelloazionekind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'appelloazionekind_sortcode', 'Ordinamento', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idappelloazionekind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc ";
					}
					case "default": {
						return "title asc , appelloazionekind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('appelloazionekinddefaultview', new meta_appelloazionekinddefaultview('appelloazionekinddefaultview'));

	}());
