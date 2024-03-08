(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfobiettivokinddefaultview() {
        MetaData.apply(this, ["perfobiettivokinddefaultview"]);
        this.name = 'meta_perfobiettivokinddefaultview';
    }

    meta_perfobiettivokinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfobiettivokinddefaultview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'title', 'Obiettivo', null, 2000, 1024);
						this.describeAColumn(table, 'perfobiettivokind_description', 'Descrizione', null, 7000, -1);
						this.describeAColumn(table, 'perfobiettivokind_active', 'Attivo', null, 8000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfobiettivokind"];
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

			//$describeTree$
        });

    window.appMeta.addMeta('perfobiettivokinddefaultview', new meta_perfobiettivokinddefaultview('perfobiettivokinddefaultview'));

	}());
