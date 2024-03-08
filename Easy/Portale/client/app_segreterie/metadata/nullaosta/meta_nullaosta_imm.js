(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_nullaosta_imm() {
        MetaData.apply(this, ["nullaosta_imm"]);
        this.name = 'meta_nullaosta_imm';
    }

    meta_nullaosta_imm.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_nullaosta_imm,
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
					case 'imm_seganagstupre':
						this.describeAColumn(table, 'annoimm', 'anno di corso di immatricolazione', null, 10, null);
						this.describeAColumn(table, 'parttime', 'Parttime', null, 70, null);
//$objCalcFieldConfig_imm_seganagstupre$
						break;
					case 'imm_seganagsturin':
						this.describeAColumn(table, 'annoimm', 'anno di corso di immatricolazione', null, 10, null);
						this.describeAColumn(table, 'parttime', 'Parttime', null, 70, null);
//$objCalcFieldConfig_imm_seganagsturin$
						break;
					case 'imm_seganagstu':
						this.describeAColumn(table, 'annoimm', 'anno di corso di immatricolazione', null, 10, null);
						this.describeAColumn(table, 'parttime', 'Parttime', null, 70, null);
//$objCalcFieldConfig_imm_seganagstu$
						break;
					case 'seganagsturin':
						this.describeAColumn(table, '!iddidprogcurr_didprogcurr_title', 'Curriculum', null, 11, null);
						objCalcFieldConfig['!iddidprogcurr_didprogcurr_title'] = { tableNameLookup:'didprogcurr_alias1', columnNameLookup:'title', columnNamekey:'iddidprogcurr' };
						this.describeAColumn(table, '!iddidprogori_didprogori_title', 'Corso e orientamento', null, 21, null);
						objCalcFieldConfig['!iddidprogori_didprogori_title'] = { tableNameLookup:'didprogori', columnNameLookup:'title', columnNamekey:'iddidprogori' };
//$objCalcFieldConfig_seganagsturin$
						break;
					case 'seganagstupre':
						this.describeAColumn(table, '!iddidprogcurr_didprogcurr_title', 'Curriculum', null, 11, null);
						objCalcFieldConfig['!iddidprogcurr_didprogcurr_title'] = { tableNameLookup:'didprogcurr_alias1', columnNameLookup:'title', columnNamekey:'iddidprogcurr' };
						this.describeAColumn(table, '!iddidprogori_didprogori_title', 'Corso e orientamento', null, 21, null);
						objCalcFieldConfig['!iddidprogori_didprogori_title'] = { tableNameLookup:'didprogori', columnNameLookup:'title', columnNamekey:'iddidprogori' };
//$objCalcFieldConfig_seganagstupre$
						break;
					case 'seganagstu':
						this.describeAColumn(table, '!iddidprogcurr_didprogcurr_title', 'Curriculum', null, 11, null);
						objCalcFieldConfig['!iddidprogcurr_didprogcurr_title'] = { tableNameLookup:'didprogcurr_alias1', columnNameLookup:'title', columnNamekey:'iddidprogcurr' };
						this.describeAColumn(table, '!iddidprogori_didprogori_title', 'Corso e orientamento', null, 21, null);
						objCalcFieldConfig['!iddidprogori_didprogori_title'] = { tableNameLookup:'didprogori', columnNameLookup:'title', columnNamekey:'iddidprogori' };
//$objCalcFieldConfig_seganagstu$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_nullaosta_imm");

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

    window.appMeta.addMeta('nullaosta_imm', new meta_nullaosta_imm('nullaosta_imm'));

	}());
