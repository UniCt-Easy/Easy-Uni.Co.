(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_contrattokinddefaultview() {
        MetaData.apply(this, ["contrattokinddefaultview"]);
        this.name = 'meta_contrattokinddefaultview';
    }

    meta_contrattokinddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_contrattokinddefaultview,
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
						this.describeAColumn(table, 'contrattokind_active', 'Attivo', null, 1000, null);
						this.describeAColumn(table, 'title', 'Tipologia', null, 2000, 50);
						this.describeAColumn(table, 'contrattokind_oremaxgg', 'Ore di lavoro al giorno massime', null, 3000, null);
						this.describeAColumn(table, 'contrattokind_costolordoannuo', 'Costo lordo annuo', 'fixed.2', 20000, null);
						this.describeAColumn(table, 'contrattokind_costolordoannuooneri', 'Costo lordo annuo e oneri', 'fixed.2', 21000, null);
						this.describeAColumn(table, 'contrattokind_puntiorganico', 'Punti organico', 'fixed.2', 23000, null);
						this.describeAColumn(table, 'contrattokind_tipopersonale', 'Categoria di personale', null, 26000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcontrattokind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "contrattokind_active desc, title asc ";
					}
					case "default": {
						return "contrattokind_active desc, title asc , contrattokind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('contrattokinddefaultview', new meta_contrattokinddefaultview('contrattokinddefaultview'));

	}());
