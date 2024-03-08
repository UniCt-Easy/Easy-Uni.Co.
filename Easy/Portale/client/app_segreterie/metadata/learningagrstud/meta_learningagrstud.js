(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_learningagrstud() {
        MetaData.apply(this, ["learningagrstud"]);
        this.name = 'meta_learningagrstud';
    }

    meta_learningagrstud.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_learningagrstud,
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
						this.describeAColumn(table, 'note', 'Note', null, 80, -1);
						this.describeAColumn(table, 'start', 'Data di inizio', null, 90, null);
						this.describeAColumn(table, 'stop', 'Data di fine', null, 100, null);
						this.describeAColumn(table, '!idlearningagrkind_learningagrkind_title', 'Tipologia Tipologia di learning agreement', null, 51, null);
						this.describeAColumn(table, '!idlearningagrkind_learningagrkind_description', 'Descrizione Tipologia di learning agreement', null, 52, null);
						objCalcFieldConfig['!idlearningagrkind_learningagrkind_title'] = { tableNameLookup:'learningagrkind', columnNameLookup:'title', columnNamekey:'idlearningagrkind' };
						objCalcFieldConfig['!idlearningagrkind_learningagrkind_description'] = { tableNameLookup:'learningagrkind', columnNameLookup:'description', columnNamekey:'idlearningagrkind' };
						this.describeAColumn(table, '!idreg_istitutiesteri_registry_istitutiesteri_title', 'Istituto', null, 71, null);
						objCalcFieldConfig['!idreg_istitutiesteri_registry_istitutiesteri_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_istitutiesteri' };
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
               var def = appMeta.Deferred("getNewRow-meta_learningagrstud");

				//$getNewRowInside$

				dt.autoIncrement('idlearningagrstud', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('learningagrstud', new meta_learningagrstud('learningagrstud'));

	}());
