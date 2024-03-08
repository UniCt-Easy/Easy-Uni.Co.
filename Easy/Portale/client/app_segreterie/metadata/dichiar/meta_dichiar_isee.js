(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiar_isee() {
        MetaData.apply(this, ["dichiar_isee"]);
        this.name = 'meta_dichiar_isee';
    }

    meta_dichiar_isee.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiar_isee,
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
					case 'isee_seg':
						this.describeAColumn(table, 'anno', 'Anno', null, 510, null);
						this.describeAColumn(table, 'conforme', 'Conformità', null, 520, null);
						this.describeAColumn(table, 'dataauthdiff', 'Data autorizzazione', null, 530, null);
						this.describeAColumn(table, 'datasottoscriz', 'Data di sottoscrizione', null, 540, null);
						this.describeAColumn(table, 'enterilascio', 'Ente del rilascio', null, 550, 50);
						this.describeAColumn(table, 'isee', 'Valore ISEE', 'fixed.2', 580, null);
						this.describeAColumn(table, 'numeroprot', 'Numero protocollo dell\'ente di rilascio', null, 590, 50);
//$objCalcFieldConfig_isee_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_dichiar_isee");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$


				// metto i default
				var objRow = dt.newRow({
					idreg : 0,
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('dichiar_isee', new meta_dichiar_isee('dichiar_isee'));

	}());
