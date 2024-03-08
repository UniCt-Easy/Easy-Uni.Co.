(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_positiondefaultview() {
        MetaData.apply(this, ["positiondefaultview"]);
        this.name = 'meta_positiondefaultview';
    }

    meta_positiondefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_positiondefaultview,
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
						this.describeAColumn(table, 'position_active', 'Attivo', null, 1000, null);
						this.describeAColumn(table, 'title', 'Titolo', null, 2000, 50);
						this.describeAColumn(table, 'position_oremaxgg', 'Ore di lavoro al giorno massime', null, 3000, null);
						this.describeAColumn(table, 'position_costolordoannuo', 'Costo lordo annuo', 'fixed.2', 20000, null);
						this.describeAColumn(table, 'position_costolordoannuooneri', 'Costo lordo annuo e oneri', 'fixed.2', 21000, null);
						this.describeAColumn(table, 'position_puntiorganico', 'Punti organico', 'fixed.2', 23000, null);
						this.describeAColumn(table, 'position_tipopersonale', 'Categoria di personale', null, 26000, null);
						this.describeAColumn(table, 'position_codeposition', 'Codice qualifica', null, 27000, 20);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idposition"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "position_active desc, title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('positiondefaultview', new meta_positiondefaultview('positiondefaultview'));

	}());
