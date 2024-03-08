(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_areadidatticadefaultview() {
        MetaData.apply(this, ["areadidatticadefaultview"]);
        this.name = 'meta_areadidatticadefaultview';
    }

    meta_areadidatticadefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_areadidatticadefaultview,
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
						this.describeAColumn(table, 'idareadidattica', 'Codice', null, 1000, null);
						this.describeAColumn(table, 'title', 'Titolo', null, 2000, 100);
						this.describeAColumn(table, 'areadidattica_active', 'Attivo', null, 3000, null);
						this.describeAColumn(table, 'corsostudiokind_title', 'Tipo di corso', null, 4200, 50);
						this.describeAColumn(table, 'areadidattica_sortcode', 'Ordinamento', null, 5000, null);
						this.describeAColumn(table, 'areadidattica_subtitle', 'Sotto-titolo', null, 6000, 100);
						this.describeAColumn(table, 'macroareadidattica_title', 'Macroarea didattica', null, 11200, 1024);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idareadidattica"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc ";
					}
					case "default": {
						return "title asc , areadidattica_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('areadidatticadefaultview', new meta_areadidatticadefaultview('areadidatticadefaultview'));

	}());
