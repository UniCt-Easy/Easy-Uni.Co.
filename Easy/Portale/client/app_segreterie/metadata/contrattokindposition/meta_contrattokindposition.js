(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_contrattokindposition() {
        MetaData.apply(this, ["contrattokindposition"]);
        this.name = 'meta_contrattokindposition';
    }

    meta_contrattokindposition.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_contrattokindposition,
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
						this.describeAColumn(table, '!idposition_position_description', 'Descrizione', null, 22, null);
						this.describeAColumn(table, '!idposition_position_active', 'attivo', null, 20, null);
						this.describeAColumn(table, '!idposition_position_codeposition', '#', null, 20, null);
						this.describeAColumn(table, '!idposition_position_foreignclass', 'Classe di appartenenza per Miss.all\'estero', null, 20, null);
						this.describeAColumn(table, '!idposition_position_maxincomeclass', 'Classe Stip. Max', null, 20, null);
						objCalcFieldConfig['!idposition_position_description'] = { tableNameLookup:'position', columnNameLookup:'description', columnNamekey:'idposition' };
						objCalcFieldConfig['!idposition_position_active'] = { tableNameLookup:'position', columnNameLookup:'active', columnNamekey:'idposition' };
						objCalcFieldConfig['!idposition_position_codeposition'] = { tableNameLookup:'position', columnNameLookup:'codeposition', columnNamekey:'idposition' };
						objCalcFieldConfig['!idposition_position_foreignclass'] = { tableNameLookup:'position', columnNameLookup:'foreignclass', columnNamekey:'idposition' };
						objCalcFieldConfig['!idposition_position_maxincomeclass'] = { tableNameLookup:'position', columnNameLookup:'maxincomeclass', columnNamekey:'idposition' };
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["idcontrattokind"].caption = "Codice";
						table.columns["idposition"].caption = "Codice";
						table.columns["idcontrattokind"].caption = "Tipologia di contratto";
						table.columns["idposition"].caption = "Ruolo";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_contrattokindposition");

				//$getNewRowInside$


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
						return "idposition asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('contrattokindposition', new meta_contrattokindposition('contrattokindposition'));

	}());
