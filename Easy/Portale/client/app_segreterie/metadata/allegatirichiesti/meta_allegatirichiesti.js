(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_allegatirichiesti() {
        MetaData.apply(this, ["allegatirichiesti"]);
        this.name = 'meta_allegatirichiesti';
    }

    meta_allegatirichiesti.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_allegatirichiesti,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, -1);
						this.describeAColumn(table, 'active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'sortcode', 'Codice identificativo', null, 40, null);
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
               var def = appMeta.Deferred("getNewRow-meta_allegatirichiesti");

				//$getNewRowInside$

				dt.autoIncrement('idallegatirichiesti', { minimum: 99990001 });

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
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('allegatirichiesti', new meta_allegatirichiesti('allegatirichiesti'));

	}());
