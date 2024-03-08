(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_bandomobilitaintkinddefaultview() {
        MetaData.apply(this, ["bandomobilitaintkinddefaultview"]);
        this.name = 'meta_bandomobilitaintkinddefaultview';
    }

    meta_bandomobilitaintkinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandomobilitaintkinddefaultview,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 200);
						this.describeAColumn(table, 'bandomobilitaintkind_active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'bandomobilitaintkind_sortcode', 'Sortcode', null, 40, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idbandomobilitaintkind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "bandomobilitaintkind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('bandomobilitaintkinddefaultview', new meta_bandomobilitaintkinddefaultview('bandomobilitaintkinddefaultview'));

	}());
