(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_richitesi() {
        MetaData.apply(this, ["richitesi"]);
        this.name = 'meta_richitesi';
    }

    meta_richitesi.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_richitesi,
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
					case 'segistcons':
						this.describeAColumn(table, 'accettata', 'Accettata', null, 20, null);
						this.describeAColumn(table, '!idreg_docenti_registry_docenti_title', 'Relatore Principale', null, 11, null);
						objCalcFieldConfig['!idreg_docenti_registry_docenti_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
//$objCalcFieldConfig_segistcons$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'segistcons':
						table.columns["accettata"].caption = "Accettata";
						table.columns["idreg"].caption = "Studente";
						table.columns["idreg_docenti"].caption = "Relatore Principale";
//$innerSetCaptionConfig_segistcons$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_richitesi");

				//$getNewRowInside$

				dt.autoIncrement('idrichitesi', { minimum: 99990001 });

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

    window.appMeta.addMeta('richitesi', new meta_richitesi('richitesi'));

	}());
