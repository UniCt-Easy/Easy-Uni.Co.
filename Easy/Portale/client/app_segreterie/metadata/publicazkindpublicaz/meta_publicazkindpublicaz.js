(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_publicazkindpublicaz() {
        MetaData.apply(this, ["publicazkindpublicaz"]);
        this.name = 'meta_publicazkindpublicaz';
    }

    meta_publicazkindpublicaz.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_publicazkindpublicaz,
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
						this.describeAColumn(table, '!idpublicazkind_publicazkind_title', 'Tipologia', null, 21, null);
						this.describeAColumn(table, '!idpublicazkind_publicazkind_subtitle', 'Sotto-tipologia', null, 22, null);
						this.describeAColumn(table, '!idpublicazkind_publicazkind_sortcode', 'Ordinamento', null, 20, null);
						this.describeAColumn(table, '!idpublicazkind_publicazkind_active', 'Attivo', null, 20, null);
						objCalcFieldConfig['!idpublicazkind_publicazkind_title'] = { tableNameLookup:'publicazkind', columnNameLookup:'title', columnNamekey:'idpublicazkind' };
						objCalcFieldConfig['!idpublicazkind_publicazkind_subtitle'] = { tableNameLookup:'publicazkind', columnNameLookup:'subtitle', columnNamekey:'idpublicazkind' };
						objCalcFieldConfig['!idpublicazkind_publicazkind_sortcode'] = { tableNameLookup:'publicazkind', columnNameLookup:'sortcode', columnNamekey:'idpublicazkind' };
						objCalcFieldConfig['!idpublicazkind_publicazkind_active'] = { tableNameLookup:'publicazkind', columnNameLookup:'active', columnNamekey:'idpublicazkind' };
						this.describeAColumn(table, '!idpublicazkind_publicazkind_title', 'Tipologia', null, 23, null);
						this.describeAColumn(table, '!idpublicazkind_publicazkind_subtitle', 'Sotto-tipologia', null, 25, null);
						this.describeAColumn(table, '!idpublicazkind_publicazkind_sortcode', 'Ordinamento', null, 24, null);
						this.describeAColumn(table, '!idpublicazkind_publicazkind_active', 'Attivo', null, 25, null);
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
               var def = appMeta.Deferred("getNewRow-meta_publicazkindpublicaz");

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

    window.appMeta.addMeta('publicazkindpublicaz', new meta_publicazkindpublicaz('publicazkindpublicaz'));

	}());
