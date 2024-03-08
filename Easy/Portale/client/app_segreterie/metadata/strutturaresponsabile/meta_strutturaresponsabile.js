(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_strutturaresponsabile() {
        MetaData.apply(this, ["strutturaresponsabile"]);
        this.name = 'meta_strutturaresponsabile';
    }

    meta_strutturaresponsabile.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_strutturaresponsabile,
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
						this.describeAColumn(table, 'idperfruolo', 'Ruolo ', null, 20, 50);
						this.describeAColumn(table, 'start', 'Data inizio validità', null, 50, null);
						this.describeAColumn(table, 'stop', 'Data fine validità', null, 60, null);
						this.describeAColumn(table, '!idreg_registry_title', 'Membro del personale', null, 31, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg' };
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
						table.columns["idperfruolo"].caption = "Ruolo ";
						table.columns["idreg"].caption = "Membro del personale";
						table.columns["start"].caption = "Data inizio validità";
						table.columns["stop"].caption = "Data fine validità";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_strutturaresponsabile");

				//$getNewRowInside$

				dt.autoIncrement('idstrutturaresponsabile', { minimum: 99990001 });

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

			//$describeTree$
        });

    window.appMeta.addMeta('strutturaresponsabile', new meta_strutturaresponsabile('strutturaresponsabile'));

	}());
