(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_iscrizioneanno() {
        MetaData.apply(this, ["iscrizioneanno"]);
        this.name = 'meta_iscrizioneanno';
    }

    meta_iscrizioneanno.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_iscrizioneanno,
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
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'anno', 'Anno', null, 30, null);
						this.describeAColumn(table, 'annofc', 'Anno fuori corso', null, 40, null);
						this.describeAColumn(table, 'data', 'Data', 'g', 50, null);
						this.describeAColumn(table, '!iddidprogori_didprogori_title', 'Orientamento', null, 61, null);
						objCalcFieldConfig['!iddidprogori_didprogori_title'] = { tableNameLookup:'didprogori', columnNameLookup:'title', columnNamekey:'iddidprogori' };
//$objCalcFieldConfig_didprog$
						break;
					case 'seganagstu':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'anno', 'Anno', null, 30, null);
						this.describeAColumn(table, 'annofc', 'Anno fuori corso', null, 40, null);
						this.describeAColumn(table, 'data', 'Data', 'g', 50, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 200, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 210, null);
						this.describeAColumn(table, '!iddidprogori_didprogori_title', 'Orientamento', null, 61, null);
						objCalcFieldConfig['!iddidprogori_didprogori_title'] = { tableNameLookup:'didprogori', columnNameLookup:'title', columnNamekey:'iddidprogori' };
//$objCalcFieldConfig_seganagstu$
						break;
					case 'seg':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'anno', 'Anno', null, 30, null);
						this.describeAColumn(table, 'annofc', 'Anno fuori corso', null, 40, null);
						this.describeAColumn(table, 'data', 'Data', 'g', 50, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 200, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 210, null);
						this.describeAColumn(table, '!iddidprogori_didprogori_title', 'Orientamento', null, 61, null);
						objCalcFieldConfig['!iddidprogori_didprogori_title'] = { tableNameLookup:'didprogori', columnNameLookup:'title', columnNamekey:'iddidprogori' };
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
				var def = appMeta.Deferred("getNewRow-meta_iscrizioneanno");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idiscrizioneanno', { minimum: 99990001 });

				// metto i default
				var objRow = dt.newRow({
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('iscrizioneanno', new meta_iscrizioneanno('iscrizioneanno'));

	}());
