(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettoudrmembrokind() {
        MetaData.apply(this, ["progettoudrmembrokind"]);
        this.name = 'meta_progettoudrmembrokind';
    }

    meta_progettoudrmembrokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettoudrmembrokind,
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
						this.describeAColumn(table, 'title', 'Tipo di membro', null, 20, 50);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, 2048);
						this.describeAColumn(table, 'active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'sortcode', 'Ordinamento', null, 50, null);
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
				var def = appMeta.Deferred("getNewRow-meta_progettoudrmembrokind");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idprogettoudrmembrokind', { minimum: 99990001 });

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
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettoudrmembrokind', new meta_progettoudrmembrokind('progettoudrmembrokind'));

	}());
