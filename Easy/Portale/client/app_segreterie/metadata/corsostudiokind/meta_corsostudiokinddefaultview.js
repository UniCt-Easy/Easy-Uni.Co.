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
						this.describeAColumn(table, 'idcorsostudiokind', 'Codice', null, 10, null);
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'corsostudiokind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'corsostudiokind_sortcode', 'Sortcode', null, 50, null);
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
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('corsostudiokinddefaultview', new meta_corsostudiokinddefaultview('corsostudiokinddefaultview'));

	}());
