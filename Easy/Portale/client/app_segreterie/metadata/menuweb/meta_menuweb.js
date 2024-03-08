(function() {
    var MetaData = window.appMeta.MetaData;
    var getData = window.appMeta.getData;
    var getDataUtils = window.appMeta.getDataUtils;
    var Deferred = window.appMeta.Deferred;
    var q = window.jsDataQuery;
    function meta_menuweb() {
        MetaData.apply(this, ["menuweb"]);
        this.name = 'meta_menuweb';
    }

    meta_menuweb.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_menuweb,

            superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos = 1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'idmenuweb', 'Identificativo', null, 10, null);
						this.describeAColumn(table, 'editType', 'EditType', null, 20, 60);
						this.describeAColumn(table, 'label', 'Label', null, 40, 250);
						this.describeAColumn(table, 'link', 'Link', null, 50, 250);
						this.describeAColumn(table, 'sort', 'Sort', null, 60, null);
						this.describeAColumn(table, 'tableName', 'TableName', null, 70, 60);
						//$objCalcFieldConfig_default$
						break;
										case 'tree':
						this.describeAColumn(table, 'idmenuweb', 'Identificativo', null, 10, null);
						this.describeAColumn(table, 'editType', 'EditType', null, 20, 60);
						this.describeAColumn(table, 'label', 'Label', null, 40, 250);
						this.describeAColumn(table, 'link', 'Link', null, 50, 250);
						this.describeAColumn(table, 'sort', 'Sort', null, 60, null);
						this.describeAColumn(table, 'tableName', 'TableName', null, 70, 60);
//$objCalcFieldConfig_tree$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},

		


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_menuweb");

				//$getNewRowInside$

				dt.autoIncrement('idmenuweb', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "idmenuwebparent asc , label asc ";
					}
					case "tree": {
						return "idmenuwebparent asc , sort asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			},

			describeTree: function (table, listType) {
				var def = appMeta.Deferred("meta_describeTree");
				var nodedispatcher = new appMeta.SimpleUnLeveled_TreeNode_Dispatcher("label");
				var rootCondition = window.jsDataQuery.isNull("idmenuwebparent");
				return def.resolve({
					rootCondition: rootCondition,
					nodeDispatcher: nodedispatcher
				});
			}
		});

    window.appMeta.addMeta('menuweb', new meta_menuweb('menuweb'));
}());
