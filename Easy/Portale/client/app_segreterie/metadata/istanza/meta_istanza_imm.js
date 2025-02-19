﻿(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanza_imm() {
        MetaData.apply(this, ["istanza_imm"]);
        this.name = 'meta_istanza_imm';
    }

    meta_istanza_imm.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanza_imm,
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
					case 'imm_seganagsturin':
						this.describeAColumn(table, 'parttime', 'Iscrizione Part-Time', null, 50, null);
//$objCalcFieldConfig_imm_seganagsturin$
						break;
					case 'imm_segrin':
						this.describeAColumn(table, 'parttime', 'Iscrizione Part-Time', null, 570, null);
//$objCalcFieldConfig_imm_segrin$
						break;
					case 'imm_seg':
						this.describeAColumn(table, 'parttime', 'Iscrizione Part-Time', null, 570, null);
//$objCalcFieldConfig_imm_seg$
						break;
					case 'imm_seganagstu':
						this.describeAColumn(table, 'parttime', 'Iscrizione Part-Time', null, 50, null);
//$objCalcFieldConfig_imm_seganagstu$
						break;
					case 'imm_segpre':
						this.describeAColumn(table, 'parttime', 'Iscrizione Part-Time', null, 570, null);
//$objCalcFieldConfig_imm_segpre$
						break;
					case 'imm_seganagstupre':
						this.describeAColumn(table, 'parttime', 'Iscrizione Part-Time', null, 50, null);
//$objCalcFieldConfig_imm_seganagstupre$
						break;
					case 'seganagstupre':
						this.describeAColumn(table, '!iddidprogcurr_didprogcurr_title', 'Curriculum', null, 21, null);
						objCalcFieldConfig['!iddidprogcurr_didprogcurr_title'] = { tableNameLookup:'didprogcurr', columnNameLookup:'title', columnNamekey:'iddidprogcurr' };
						this.describeAColumn(table, '!iddidprogori_didprogori_title', 'Corso e orientamento', null, 31, null);
						objCalcFieldConfig['!iddidprogori_didprogori_title'] = { tableNameLookup:'didprogori', columnNameLookup:'title', columnNamekey:'iddidprogori' };
//$objCalcFieldConfig_seganagstupre$
						break;
					case 'seganagstu':
						this.describeAColumn(table, '!iddidprogcurr_didprogcurr_title', 'Curriculum', null, 21, null);
						objCalcFieldConfig['!iddidprogcurr_didprogcurr_title'] = { tableNameLookup:'didprogcurr', columnNameLookup:'title', columnNamekey:'iddidprogcurr' };
						this.describeAColumn(table, '!iddidprogori_didprogori_title', 'Corso e orientamento', null, 31, null);
						objCalcFieldConfig['!iddidprogori_didprogori_title'] = { tableNameLookup:'didprogori', columnNameLookup:'title', columnNamekey:'iddidprogori' };
						objCalcFieldConfig['!iddidprogcurr_didprogcurr_title'] = { tableNameLookup:'didprogcurr_alias1', columnNameLookup:'title', columnNamekey:'iddidprogcurr' };
						objCalcFieldConfig['!iddidprogori_didprogori_title'] = { tableNameLookup:'didprogori_alias1', columnNameLookup:'title', columnNamekey:'iddidprogori' };
//$objCalcFieldConfig_seganagstu$
						break;
					case 'seganagsturin':
						this.describeAColumn(table, '!iddidprogcurr_didprogcurr_title', 'Curriculum', null, 21, null);
						objCalcFieldConfig['!iddidprogcurr_didprogcurr_title'] = { tableNameLookup:'didprogcurr', columnNameLookup:'title', columnNamekey:'iddidprogcurr' };
						this.describeAColumn(table, '!iddidprogori_didprogori_title', 'Corso e orientamento', null, 31, null);
						objCalcFieldConfig['!iddidprogori_didprogori_title'] = { tableNameLookup:'didprogori', columnNameLookup:'title', columnNamekey:'iddidprogori' };
						objCalcFieldConfig['!iddidprogcurr_didprogcurr_title'] = { tableNameLookup:'didprogcurr_alias2', columnNameLookup:'title', columnNamekey:'iddidprogcurr' };
						objCalcFieldConfig['!iddidprogori_didprogori_title'] = { tableNameLookup:'didprogori_alias2', columnNameLookup:'title', columnNamekey:'iddidprogori' };
//$objCalcFieldConfig_seganagsturin$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_istanza_imm");

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

    window.appMeta.addMeta('istanza_imm', new meta_istanza_imm('istanza_imm'));

	}());
