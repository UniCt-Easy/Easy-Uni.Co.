(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_publicazkind() {
        MetaData.apply(this, ["publicazkind"]);
        this.name = 'meta_publicazkind';
    }

    meta_publicazkind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_publicazkind,
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
						this.describeAColumn(table, 'idpublicazkind', 'Codice', null, 10, null);
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'subtitle', 'Sotto-tipologia', null, 30, 256);
						this.describeAColumn(table, 'sortcode', 'Sortcode', null, 40, null);
						this.describeAColumn(table, 'active', 'Attivo', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_publicazkind");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idpublicazkind', { minimum: 99990001 });

				// metto i default
				var objRow = dt.newRow({
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc, sortcode asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('publicazkind', new meta_publicazkind('publicazkind'));

	}());
