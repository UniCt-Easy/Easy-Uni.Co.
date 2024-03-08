(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_settoreerc() {
        MetaData.apply(this, ["settoreerc"]);
        this.name = 'meta_settoreerc';
    }

    meta_settoreerc.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_settoreerc,
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
					case 'segprog':
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2048);
//$objCalcFieldConfig_segprog$
						break;
					case 'seg':
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2048);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, 2048);
						this.describeAColumn(table, 'active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'sortcode', 'Sortcode', null, 50, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_settoreerc");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idsettoreerc', { minimum: 99990001 });

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
					case "segprog": {
						return "sortcode";
					}
					case "seg": {
						return "sortcode desc";
					}
					case "segprog": {
						return "sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('settoreerc', new meta_settoreerc('settoreerc'));

	}());
