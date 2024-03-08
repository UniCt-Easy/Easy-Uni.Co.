(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_studprenotkinddefaultview() {
        MetaData.apply(this, ["studprenotkinddefaultview"]);
        this.name = 'meta_studprenotkinddefaultview';
    }

    meta_studprenotkinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_studprenotkinddefaultview,
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
						this.describeAColumn(table, 'idstudprenotkind', 'Codice', null, 10, null);
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 50);
						this.describeAColumn(table, 'studprenotkind_description', 'Descrizione', null, 30, 512);
						this.describeAColumn(table, 'studprenotkind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'studprenotkind_sortorder', 'Ordine', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idstudprenotkind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc, studprenotkind_sortorder asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('studprenotkinddefaultview', new meta_studprenotkinddefaultview('studprenotkinddefaultview'));

	}());
