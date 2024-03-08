(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_corsostudionormadefaultview() {
        MetaData.apply(this, ["corsostudionormadefaultview"]);
        this.name = 'meta_corsostudionormadefaultview';
    }

    meta_corsostudionormadefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_corsostudionormadefaultview,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 50);
						this.describeAColumn(table, 'istitutokind_tipoistituto', 'Tipologia di corsi', null, 30, 256);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcorsostudionorma"];
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

    window.appMeta.addMeta('corsostudionormadefaultview', new meta_corsostudionormadefaultview('corsostudionormadefaultview'));

	}());
