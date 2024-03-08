(function () {

	var MetaData = window.appMeta.MetaSegreterieData;

	function meta_tesikeyword() {
		MetaData.apply(this, ["tesikeyword"]);
		this.name = 'meta_tesikeyword';
	}

	meta_tesikeyword.prototype = _.extend(
		new MetaData(),
		{
			constructor: meta_tesikeyword,
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
					case 'segistcons':
						this.describeAColumn(table, 'keyword', 'Keyword', null, 40, null);
						this.describeAColumn(table, 'lang', 'Lingua', null, 50, null);
						//$objCalcFieldConfig_segistcons$
						break;
					//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_tesikeyword");

				var realParentObjectRow = parentRow;
				if (editType === "segistcons") {
					var realParentTableName = "tesi";
					var realParentTable = dt.dataset.tables["tesi"];
					if (!realParentTable) {
						console.log("ERROR: la tabella " + realParentTableName + "  non esiste nel dataset");
						return def.resolve(null);
					}
					if (!realParentTable.rows.length) {
						console.log("ERROR: la tabella " + realParentTableName + "  non ha righe");
						return def.resolve(null);
					}
					realParentObjectRow = realParentTable.rows[0].getRow();
				}
				//$getNewRowInside$

				dt.autoIncrement('idtesikeyword', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(realParentObjectRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},







			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

		});

	window.appMeta.addMeta('tesikeyword', new meta_tesikeyword('tesikeyword'));

}());
