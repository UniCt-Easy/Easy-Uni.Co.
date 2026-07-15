(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_corsostudiokinddefaultview() {
        MetaData.apply(this, ["corsostudiokinddefaultview"]);
        this.name = 'meta_corsostudiokinddefaultview';
    }

    meta_corsostudiokinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_corsostudiokinddefaultview,
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
						this.describeAColumn(table, 'idcorsostudiokind', 'Identificativo', null, 1000, null);
						this.describeAColumn(table, 'title', 'Tipologia', null, 2000, 50);
						this.describeAColumn(table, 'corsostudiokind_active', 'Attivo', null, 4000, null);
						this.describeAColumn(table, 'corsostudiokind_sortcode', 'Ordinamento', null, 5000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcorsostudiokind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc , corsostudiokind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('corsostudiokinddefaultview', new meta_corsostudiokinddefaultview('corsostudiokinddefaultview'));

	}());
