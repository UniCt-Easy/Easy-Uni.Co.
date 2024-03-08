(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiarkinddefaultview() {
        MetaData.apply(this, ["dichiarkinddefaultview"]);
        this.name = 'meta_dichiarkinddefaultview';
    }

    meta_dichiarkinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiarkinddefaultview,
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
						this.describeAColumn(table, 'dichiarkind_description', 'Descrizione', null, 30, 256);
						this.describeAColumn(table, 'dichiarkind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'dichiarkind_sortcode', 'Sortcode', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddichiarkind"];
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

    window.appMeta.addMeta('dichiarkinddefaultview', new meta_dichiarkinddefaultview('dichiarkinddefaultview'));

	}());
