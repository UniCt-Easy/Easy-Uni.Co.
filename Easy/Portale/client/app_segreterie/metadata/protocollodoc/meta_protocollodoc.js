(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_protocollodoc() {
        MetaData.apply(this, ["protocollodoc"]);
        this.name = 'meta_protocollodoc';
    }

    meta_protocollodoc.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_protocollodoc,
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
						this.describeAColumn(table, 'filename', 'Nome del file', null, 20, 1024);
						this.describeAColumn(table, 'datadoc', 'Data documento', null, 120, null);
						this.describeAColumn(table, '!idmimetype_mimetype_title', 'MIME type', null, 41, null);
						objCalcFieldConfig['!idmimetype_mimetype_title'] = { tableNameLookup:'mimetype', columnNameLookup:'title', columnNamekey:'idmimetype' };
						this.describeAColumn(table, '!idprotocollorifkind_protocollorifkind_title', 'Tipo del documento di riferimento', null, 11, null);
						objCalcFieldConfig['!idprotocollorifkind_protocollorifkind_title'] = { tableNameLookup:'protocollorifkind', columnNameLookup:'title', columnNamekey:'idprotocollorifkind' };
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
						table.columns["datadoc"].caption = "Data documento";
						table.columns["filename"].caption = "Nome del file";
						table.columns["fincaturamargin"].caption = "Distanza dal margine fincatura";
						table.columns["idattach"].caption = "Allegato";
						table.columns["idfincaturaposition"].caption = "Posizione fincatura";
						table.columns["idmimetype"].caption = "MIME type";
						table.columns["idprotocollorifkind"].caption = "Tipo del documento di riferimento";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_protocollodoc");

				//$getNewRowInside$

				dt.autoIncrement('idprotocollodoc', { minimum: 99990001 });

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

    window.appMeta.addMeta('protocollodoc', new meta_protocollodoc('protocollodoc'));

	}());
