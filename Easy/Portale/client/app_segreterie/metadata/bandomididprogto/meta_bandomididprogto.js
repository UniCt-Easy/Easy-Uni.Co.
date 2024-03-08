(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_bandomididprogto() {
        MetaData.apply(this, ["bandomididprogto"]);
        this.name = 'meta_bandomididprogto';
    }

    meta_bandomididprogto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandomididprogto,
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
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione', null, 21, null);
						this.describeAColumn(table, '!iddidprog_annoaccademico_alias1_aa', 'Anno accademico', null, 20, null);
						this.describeAColumn(table, '!iddidprog_sede_title', 'Sede', null, 21, null);
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_annoaccademico_alias1_aa'] = { tableNameLookup:'annoaccademico_alias1', columnNameLookup:'aa', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_sede_title'] = { tableNameLookup:'sede', columnNameLookup:'title', columnNamekey:'iddidprog' };
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione', null, 22, null);
						this.describeAColumn(table, '!iddidprog_annoaccademico_alias1_aa', 'Anno accademico', null, 22, null);
						this.describeAColumn(table, '!iddidprog_sede_title', 'Sede', null, 40, null);
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
               var def = appMeta.Deferred("getNewRow-meta_bandomididprogto");

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

    window.appMeta.addMeta('bandomididprogto', new meta_bandomididprogto('bandomididprogto'));

	}());
