(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tirociniorelazione() {
        MetaData.apply(this, ["tirociniorelazione"]);
        this.name = 'meta_tirociniorelazione';
    }

    meta_tirociniorelazione.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tirociniorelazione,
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
						this.describeAColumn(table, 'attivitasvolta', 'Attività svolta', null, 20, -1);
						this.describeAColumn(table, 'autovalutazione', 'Autovalutazione', null, 30, -1);
						this.describeAColumn(table, 'competenze', 'Competenze', null, 40, -1);
						this.describeAColumn(table, 'conclusioni', 'Conclusioni', null, 50, -1);
						this.describeAColumn(table, 'considerazioni', 'Considerazioni', null, 60, -1);
						this.describeAColumn(table, 'descrazienda', 'Descrizione dell\'azienda', null, 70, -1);
						this.describeAColumn(table, 'introduzione', 'Introduzione', null, 130, -1);
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
				var def = appMeta.Deferred("getNewRow-meta_tirociniorelazione");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idtirociniorelazione', { minimum: 99990001 });

				// metto i default
				var objRow = dt.newRow({
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "attivitasvolta asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('tirociniorelazione', new meta_tirociniorelazione('tirociniorelazione'));

	}());
