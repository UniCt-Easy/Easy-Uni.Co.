(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_corsostudiolivellodefaultview() {
        MetaData.apply(this, ["corsostudiolivellodefaultview"]);
        this.name = 'meta_corsostudiolivellodefaultview';
    }

    meta_corsostudiolivellodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_corsostudiolivellodefaultview,
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
						this.describeAColumn(table, 'title', 'Livello', null, 20, 50);
						this.describeAColumn(table, 'corsostudiokind_title', 'Tipologia del corso di studi', null, 30, 50);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcorsostudiolivello"];
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

    window.appMeta.addMeta('corsostudiolivellodefaultview', new meta_corsostudiolivellodefaultview('corsostudiolivellodefaultview'));

	}());
