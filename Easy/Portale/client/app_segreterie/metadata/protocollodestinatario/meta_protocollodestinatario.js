(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_protocollodestinatario() {
        MetaData.apply(this, ["protocollodestinatario"]);
        this.name = 'meta_protocollodestinatario';
    }

    meta_protocollodestinatario.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_protocollodestinatario,
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
						this.describeAColumn(table, 'destmail', 'E-mail', null, 20, 512);
						this.describeAColumn(table, 'destidamm', 'Amministrazione pubblica destinataria - Codice IPA', null, 30, 50);
						this.describeAColumn(table, 'destcodiceaoo', 'Amministrazione pubblica destinataria - Codice IPA area organizzativa omogenea', null, 40, 50);
						this.describeAColumn(table, '!idreg_dest_registry_title', 'Destinatario', null, 11, null);
						objCalcFieldConfig['!idreg_dest_registry_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_dest' };
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
               var def = appMeta.Deferred("getNewRow-meta_protocollodestinatario");

				//$getNewRowInside$

				dt.autoIncrement('idprotocollodestinatario', { minimum: 99990001 });

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

    window.appMeta.addMeta('protocollodestinatario', new meta_protocollodestinatario('protocollodestinatario'));

	}());
