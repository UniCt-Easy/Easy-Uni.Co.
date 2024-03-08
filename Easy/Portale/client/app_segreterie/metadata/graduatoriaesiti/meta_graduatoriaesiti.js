(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_graduatoriaesiti() {
        MetaData.apply(this, ["graduatoriaesiti"]);
        this.name = 'meta_graduatoriaesiti';
    }

    meta_graduatoriaesiti.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_graduatoriaesiti,
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
					case 'seg':
						this.describeAColumn(table, 'datachiusura', 'Data di chiusura', 'g', 20, null);
						this.describeAColumn(table, 'provvisoria', 'Provvisoria', null, 60, null);
//$objCalcFieldConfig_seg$
						break;
					case 'stato':
						this.describeAColumn(table, 'datachiusura', 'Data di chiusura', 'g', 20, null);
						this.describeAColumn(table, 'provvisoria', 'Provvisoria', null, 40, null);
//$objCalcFieldConfig_stato$
						break;
					case 'default':
						this.describeAColumn(table, 'datachiusura', 'Data di chiusura', 'g', 20, null);
						this.describeAColumn(table, 'provvisoria', 'Provvisoria', null, 40, null);
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
				var def = appMeta.Deferred("getNewRow-meta_graduatoriaesiti");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idgraduatoriaesiti', { minimum: 99990001 });

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
					case "seg": {
						return "idgraduatoria desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('graduatoriaesiti', new meta_graduatoriaesiti('graduatoriaesiti'));

	}());
