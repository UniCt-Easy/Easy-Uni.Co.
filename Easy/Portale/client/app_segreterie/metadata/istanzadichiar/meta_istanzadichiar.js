(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanzadichiar() {
        MetaData.apply(this, ["istanzadichiar"]);
        this.name = 'meta_istanzadichiar';
    }

    meta_istanzadichiar.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzadichiar,
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
						this.describeAColumn(table, 'iddichiar', 'Dichiarazione', null, 10, null);
						this.describeAColumn(table, '!iddichiar_annoaccademico_alias2_aa', 'Anno Accademico', null, 11, null);
						this.describeAColumn(table, '!iddichiar_dichiarkind_title', 'Tipologia', null, 12, null);
						this.describeAColumn(table, '!iddichiar_dichiar_date', 'Data', null, 16, null);
						objCalcFieldConfig['!iddichiar_annoaccademico_alias2_aa'] = { tableNameLookup:'annoaccademico_alias2', columnNameLookup:'aa', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiarkind_title'] = { tableNameLookup:'dichiarkind', columnNameLookup:'title', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiar_date'] = { tableNameLookup:'dichiar', columnNameLookup:'date', columnNamekey:'iddichiar' };
//$objCalcFieldConfig_seg$
						break;
					case 'seganagstu':
						this.describeAColumn(table, 'iddichiar', 'Dichiarazione', null, 10, null);
						this.describeAColumn(table, '!iddichiar_annoaccademico_alias2_aa', 'Anno Accademico', null, 11, null);
						this.describeAColumn(table, '!iddichiar_dichiarkind_title', 'Tipologia', null, 12, null);
						this.describeAColumn(table, '!iddichiar_dichiar_date', 'Data', null, 16, null);
						objCalcFieldConfig['!iddichiar_annoaccademico_alias2_aa'] = { tableNameLookup:'annoaccademico_alias2', columnNameLookup:'aa', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiarkind_title'] = { tableNameLookup:'dichiarkind', columnNameLookup:'title', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiar_date'] = { tableNameLookup:'dichiar', columnNameLookup:'date', columnNamekey:'iddichiar' };
//$objCalcFieldConfig_seganagstu$
						break;
					case 'seganagsturin':
						this.describeAColumn(table, '!iddichiar_annoaccademico_alias2_aa', 'Anno Accademico', null, 11, null);
						this.describeAColumn(table, '!iddichiar_dichiarkind_title', 'Tipologia', null, 12, null);
						this.describeAColumn(table, '!iddichiar_dichiar_date', 'Data', null, 16, null);
						objCalcFieldConfig['!iddichiar_annoaccademico_alias2_aa'] = { tableNameLookup:'annoaccademico_alias2', columnNameLookup:'aa', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiarkind_title'] = { tableNameLookup:'dichiarkind', columnNameLookup:'title', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiar_date'] = { tableNameLookup:'dichiar', columnNameLookup:'date', columnNamekey:'iddichiar' };
//$objCalcFieldConfig_seganagsturin$
						break;
					case 'seganagstupre':
						this.describeAColumn(table, '!iddichiar_annoaccademico_alias2_aa', 'Anno Accademico', null, 11, null);
						this.describeAColumn(table, '!iddichiar_dichiarkind_title', 'Tipologia', null, 12, null);
						this.describeAColumn(table, '!iddichiar_dichiar_date', 'Data', null, 16, null);
						objCalcFieldConfig['!iddichiar_annoaccademico_alias2_aa'] = { tableNameLookup:'annoaccademico_alias2', columnNameLookup:'aa', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiarkind_title'] = { tableNameLookup:'dichiarkind', columnNameLookup:'title', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiar_date'] = { tableNameLookup:'dichiar', columnNameLookup:'date', columnNamekey:'iddichiar' };
//$objCalcFieldConfig_seganagstupre$
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
						table.columns["iddichiar"].caption = "Dichiarazione";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idreg"].caption = "Studente";
//$innerSetCaptionConfig_seg$
						break;
					case 'seganagstu':
//$innerSetCaptionConfig_seganagstu$
						break;
					case 'seganagsturin':
//$innerSetCaptionConfig_seganagsturin$
						break;
					case 'seganagstupre':
//$innerSetCaptionConfig_seganagstupre$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_istanzadichiar");

				//$getNewRowInside$


				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			getStaticFilter: function (listType) {
				switch (listType) {
					case "seganagstu": {
						return "idistanzakind = 14";
						break;
					}
				case "seganagsturin": {
						return "idistanzakind = 15";
						break;
					}
				case "seganagstupre": {
						return "idistanzakind = 13";
						break;
					}
				//$GetStaticFilterInner$
				}
				return this.superClass.getStaticFilter(listType);
			},


			//$getSorting$

        });

    window.appMeta.addMeta('istanzadichiar', new meta_istanzadichiar('istanzadichiar'));

	}());
