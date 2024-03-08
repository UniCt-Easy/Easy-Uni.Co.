(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_protocollodocelement() {
        MetaData.apply(this, ["protocollodocelement"]);
        this.name = 'meta_protocollodocelement';
    }

    meta_protocollodocelement.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_protocollodocelement,
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
					case 'segson':
						this.describeAColumn(table, 'protnumero', 'Identificativo', null, 10, null);
						this.describeAColumn(table, 'protanno', 'Identificativo', null, 20, null);
//$objCalcFieldConfig_segson$
						break;
					case 'seg':
						this.describeAColumn(table, 'oggetto', 'Oggetto', null, 50, 1024);
						this.describeAColumn(table, 'telematicocolloc', 'Collocazione telematica (URI)', null, 80, 1024);
						this.describeAColumn(table, '!idprotocollodocelement_primo_protocollodocelement_protnumero', 'Identificativo Prima protocollazione', null, 81, null);
						this.describeAColumn(table, '!idprotocollodocelement_primo_protocollodocelement_protanno', 'Identificativo Prima protocollazione', null, 82, null);
						objCalcFieldConfig['!idprotocollodocelement_primo_protocollodocelement_protnumero'] = { tableNameLookup:'protocollodocelement_alias1', columnNameLookup:'protnumero', columnNamekey:'idprotocollodocelement_primo' };
						objCalcFieldConfig['!idprotocollodocelement_primo_protocollodocelement_protanno'] = { tableNameLookup:'protocollodocelement_alias1', columnNameLookup:'protanno', columnNamekey:'idprotocollodocelement_primo' };
						this.describeAColumn(table, '!idprotocollodockind_protocollodockind_title', 'Tipologia di documento', null, 41, null);
						objCalcFieldConfig['!idprotocollodockind_protocollodockind_title'] = { tableNameLookup:'protocollodockind', columnNameLookup:'title', columnNamekey:'idprotocollodockind' };
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
               var def = appMeta.Deferred("getNewRow-meta_protocollodocelement");

				//$getNewRowInside$

				dt.autoIncrement('idprotocollodocelement', { minimum: 99990001 });

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

    window.appMeta.addMeta('protocollodocelement', new meta_protocollodocelement('protocollodocelement'));

	}());
