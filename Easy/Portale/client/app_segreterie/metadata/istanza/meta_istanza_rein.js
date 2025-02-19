﻿(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanza_rein() {
        MetaData.apply(this, ["istanza_rein"]);
        this.name = 'meta_istanza_rein';
    }

    meta_istanza_rein.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanza_rein,
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
					case 'rein_seg':
						this.describeAColumn(table, 'darindec', 'Corso della rinuncia o decadenza ', null, 520, null);
						this.describeAColumn(table, 'datarindec', 'Data della rinuncia o decadenza ', null, 530, null);
						this.describeAColumn(table, 'aa_rindec', 'Anno accademico della rinuncia o decadenza', null, 1660, 9);
//$objCalcFieldConfig_rein_seg$
						break;
					case 'rein_seganagstu':
						this.describeAColumn(table, 'aarindec', 'Anno accademico della rinuncia o decadenza ', null, 510, 9);
						this.describeAColumn(table, 'darindec', 'Corso della rinuncia o decadenza ', null, 520, null);
						this.describeAColumn(table, 'datarindec', 'Data della rinuncia o decadenza ', null, 530, null);
//$objCalcFieldConfig_rein_seganagstu$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_istanza_rein");

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

    window.appMeta.addMeta('istanza_rein', new meta_istanza_rein('istanza_rein'));

	}());
