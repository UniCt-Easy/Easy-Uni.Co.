(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_workpackageupb() {
        MetaData.apply(this, ["workpackageupb"]);
        this.name = 'meta_workpackageupb';
    }

    meta_workpackageupb.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_workpackageupb,
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
						this.describeAColumn(table, 'idupb', 'Unità previsionale di base', null, 20, 36);
						this.describeAColumn(table, '!idupb_upbelenchiview_codeupb', 'Codice', null, 22, null);
						this.describeAColumn(table, '!idupb_upbelenchiview_title', 'Denominazione', null, 24, null);
						this.describeAColumn(table, '!idupb_upbelenchiview_active', 'attivo', null, 23, null);
						objCalcFieldConfig['!idupb_upbelenchiview_codeupb'] = { tableNameLookup:'upbelenchiview', columnNameLookup:'codeupb', columnNamekey:'idupb' };
						objCalcFieldConfig['!idupb_upbelenchiview_title'] = { tableNameLookup:'upbelenchiview', columnNameLookup:'title', columnNamekey:'idupb' };
						objCalcFieldConfig['!idupb_upbelenchiview_active'] = { tableNameLookup:'upbelenchiview', columnNameLookup:'active', columnNamekey:'idupb' };
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
						table.columns["idupb"].caption = "Unità previsionale di base";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_workpackageupb");

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

    window.appMeta.addMeta('workpackageupb', new meta_workpackageupb('workpackageupb'));

	}());
