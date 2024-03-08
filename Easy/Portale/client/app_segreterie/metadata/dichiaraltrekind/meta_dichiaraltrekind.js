(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiaraltrekind() {
        MetaData.apply(this, ["dichiaraltrekind"]);
        this.name = 'meta_dichiaraltrekind';
    }

    meta_dichiaraltrekind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiaraltrekind,
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
					case 'elenchi':
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 256);
//$objCalcFieldConfig_elenchi$
						break;
					case 'default':
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 256);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, 2048);
						this.describeAColumn(table, 'active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'sortcode', 'Sortcode', null, 50, null);
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
				var def = appMeta.Deferred("getNewRow-meta_dichiaraltrekind");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('iddichiaraltrekind', { minimum: 99990001 });

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
					case "elenchi": {
						return "sortcode";
					}
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('dichiaraltrekind', new meta_dichiaraltrekind('dichiaraltrekind'));

	}());
