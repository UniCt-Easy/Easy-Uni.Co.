(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didprogclassconsorsuale() {
        MetaData.apply(this, ["didprogclassconsorsuale"]);
        this.name = 'meta_didprogclassconsorsuale';
    }

    meta_didprogclassconsorsuale.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprogclassconsorsuale,
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
					case 'didprog':
						this.describeAColumn(table, '!idclassconsorsuale_classconsorsuale_title', 'Denominazione', null, 11, null);
						this.describeAColumn(table, '!idclassconsorsuale_classconsorsuale_description', 'Descrizione', null, 10, null);
						this.describeAColumn(table, '!idclassconsorsuale_classconsorsuale_active', 'Attivo', null, 10, null);
						this.describeAColumn(table, '!idclassconsorsuale_classconsorsuale_ambitodisci', 'Ambito Disciplinare', null, 10, null);
						this.describeAColumn(table, '!idclassconsorsuale_classconsorsuale_corr2592017', 'Corrispondenza', null, 10, null);
						this.describeAColumn(table, '!idclassconsorsuale_classconsorsuale_normativa', 'Normativa', null, 10, null);
						objCalcFieldConfig['!idclassconsorsuale_classconsorsuale_title'] = { tableNameLookup:'classconsorsuale', columnNameLookup:'title', columnNamekey:'idclassconsorsuale' };
						objCalcFieldConfig['!idclassconsorsuale_classconsorsuale_description'] = { tableNameLookup:'classconsorsuale', columnNameLookup:'description', columnNamekey:'idclassconsorsuale' };
						objCalcFieldConfig['!idclassconsorsuale_classconsorsuale_active'] = { tableNameLookup:'classconsorsuale', columnNameLookup:'active', columnNamekey:'idclassconsorsuale' };
						objCalcFieldConfig['!idclassconsorsuale_classconsorsuale_ambitodisci'] = { tableNameLookup:'classconsorsuale', columnNameLookup:'ambitodisci', columnNamekey:'idclassconsorsuale' };
						objCalcFieldConfig['!idclassconsorsuale_classconsorsuale_corr2592017'] = { tableNameLookup:'classconsorsuale', columnNameLookup:'corr2592017', columnNamekey:'idclassconsorsuale' };
						objCalcFieldConfig['!idclassconsorsuale_classconsorsuale_normativa'] = { tableNameLookup:'classconsorsuale', columnNameLookup:'normativa', columnNamekey:'idclassconsorsuale' };
						this.describeAColumn(table, '!idclassconsorsuale_classconsorsuale_title', 'Denominazione', null, 12, null);
						this.describeAColumn(table, '!idclassconsorsuale_classconsorsuale_description', 'Descrizione', null, 12, null);
						this.describeAColumn(table, '!idclassconsorsuale_classconsorsuale_active', 'Attivo', null, 14, null);
						this.describeAColumn(table, '!idclassconsorsuale_classconsorsuale_ambitodisci', 'Ambito Disciplinare', null, 15, null);
						this.describeAColumn(table, '!idclassconsorsuale_classconsorsuale_corr2592017', 'Corrispondenza', null, 16, null);
						this.describeAColumn(table, '!idclassconsorsuale_classconsorsuale_normativa', 'Normativa', null, 17, null);
//$objCalcFieldConfig_didprog$
						break;
					case 'default':
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione', null, 22, null);
						this.describeAColumn(table, '!iddidprog_annoaccademico_aa', 'Anno accademico', null, 22, null);
						this.describeAColumn(table, '!iddidprog_sede_title', 'Sede', null, 40, null);
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_annoaccademico_aa'] = { tableNameLookup:'annoaccademico', columnNameLookup:'aa', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_sede_title'] = { tableNameLookup:'sede', columnNameLookup:'title', columnNamekey:'iddidprog' };
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
               var def = appMeta.Deferred("getNewRow-meta_didprogclassconsorsuale");

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

    window.appMeta.addMeta('didprogclassconsorsuale', new meta_didprogclassconsorsuale('didprogclassconsorsuale'));

	}());
