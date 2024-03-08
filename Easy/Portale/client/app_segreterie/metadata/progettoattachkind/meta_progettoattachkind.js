(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettoattachkind() {
        MetaData.apply(this, ["progettoattachkind"]);
        this.name = 'meta_progettoattachkind';
    }

    meta_progettoattachkind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettoattachkind,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 2048);
						this.describeAColumn(table, 'linktemplate', 'Link al modello dell\'allegato', null, 50, 1024);
						this.describeAColumn(table, '!idattach_template_attach_filename', 'Modello dell\'allegato', null, 30, null);
						objCalcFieldConfig['!idattach_template_attach_filename'] = { tableNameLookup:'attach', columnNameLookup:'filename', columnNamekey:'idattach_template' };
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
               var def = appMeta.Deferred("getNewRow-meta_progettoattachkind");

				//$getNewRowInside$

				dt.autoIncrement('idprogettoattachkind', { minimum: 99990001 });

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
					case "seg": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettoattachkind', new meta_progettoattachkind('progettoattachkind'));

	}());
