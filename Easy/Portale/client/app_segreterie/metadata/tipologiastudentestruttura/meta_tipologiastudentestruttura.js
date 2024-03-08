(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tipologiastudentestruttura() {
        MetaData.apply(this, ["tipologiastudentestruttura"]);
        this.name = 'meta_tipologiastudentestruttura';
    }

    meta_tipologiastudentestruttura.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tipologiastudentestruttura,
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
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione', null, 31, null);
						this.describeAColumn(table, '!idstruttura_strutturakind_title', 'Tipologia', null, 31, null);
						this.describeAColumn(table, '!idstruttura_struttura_codice', 'Codice', null, 30, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_codice'] = { tableNameLookup:'struttura', columnNameLookup:'codice', columnNamekey:'idstruttura' };
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seg':
						table.columns["idstruttura"].caption = "Struttura didattica";
						table.columns["idtipologiastudente"].caption = "Categoria di studenti";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_tipologiastudentestruttura");

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

			//$getSorting$

        });

    window.appMeta.addMeta('tipologiastudentestruttura', new meta_tipologiastudentestruttura('tipologiastudentestruttura'));

	}());
