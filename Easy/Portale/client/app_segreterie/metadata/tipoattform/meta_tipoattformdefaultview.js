(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tipoattformdefaultview() {
        MetaData.apply(this, ["tipoattformdefaultview"]);
        this.name = 'meta_tipoattformdefaultview';
    }

    meta_tipoattformdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tipoattformdefaultview,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 1);
						this.describeAColumn(table, 'tipoattform_description', 'Descrizione', null, 30, 256);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idtipoattform"];
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

    window.appMeta.addMeta('tipoattformdefaultview', new meta_tipoattformdefaultview('tipoattformdefaultview'));

	}());
