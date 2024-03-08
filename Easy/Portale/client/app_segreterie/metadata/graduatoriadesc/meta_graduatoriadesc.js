(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_graduatoriadesc() {
        MetaData.apply(this, ["graduatoriadesc"]);
        this.name = 'meta_graduatoriadesc';
    }

    meta_graduatoriadesc.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_graduatoriadesc,
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
						this.describeAColumn(table, 'gradmax', 'Punteggio assegnato fino al valore', 'fixed.2', 20, null);
						this.describeAColumn(table, 'gradmin', 'Punteggio assegnato a partire dal valore', 'fixed.2', 30, null);
						this.describeAColumn(table, 'gradval', 'Punteggio', 'fixed.2', 40, null);
						this.describeAColumn(table, 'molt', 'Moltiplicatore', 'fixed.2', 70, null);
						this.describeAColumn(table, 'prefer', 'Preferenza a pari merito (crescente o decrescente)', null, 80, null);
						this.describeAColumn(table, '!idgraduatoriavar_graduatoriavar_title', 'Variabile del calcolo', null, 61, null);
						objCalcFieldConfig['!idgraduatoriavar_graduatoriavar_title'] = { tableNameLookup:'graduatoriavar', columnNameLookup:'title', columnNamekey:'idgraduatoriavar' };
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
				var def = appMeta.Deferred("getNewRow-meta_graduatoriadesc");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$

				dt.autoIncrement('idgraduatoriadesc', { minimum: 99990001 });

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

    window.appMeta.addMeta('graduatoriadesc', new meta_graduatoriadesc('graduatoriadesc'));

	}());
