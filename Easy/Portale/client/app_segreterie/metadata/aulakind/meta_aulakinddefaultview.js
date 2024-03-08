(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_aulakinddefaultview() {
        MetaData.apply(this, ["aulakinddefaultview"]);
        this.name = 'meta_aulakinddefaultview';
    }

    meta_aulakinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_aulakinddefaultview,
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
						this.describeAColumn(table, 'aulakind_description', 'Descrizione', null, 30, 256);
						this.describeAColumn(table, 'aulakind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'aulakind_sortcode', 'Ordinamento', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idaulakind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title asc ";
					}
					case "default": {
						return "title asc , aulakind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('aulakinddefaultview', new meta_aulakinddefaultview('aulakinddefaultview'));

	}());
