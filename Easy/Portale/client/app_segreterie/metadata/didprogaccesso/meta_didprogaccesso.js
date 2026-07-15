(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didprogaccesso() {
        MetaData.apply(this, ["didprogaccesso"]);
        this.name = 'meta_didprogaccesso';
    }

    meta_didprogaccesso.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprogaccesso,
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
						this.describeAColumn(table, '!iddidprog_acc_didprog_alias2_title', 'Denominazione', null, 12, null);
						this.describeAColumn(table, '!iddidprog_acc_annoaccademico_alias2_aa', 'Anno accademico', null, 12, null);
						this.describeAColumn(table, '!iddidprog_acc_sede_title', 'Sede', null, 30, null);
						objCalcFieldConfig['!iddidprog_acc_didprog_alias2_title'] = { tableNameLookup:'didprog_alias2', columnNameLookup:'title', columnNamekey:'iddidprog_acc' };
						objCalcFieldConfig['!iddidprog_acc_annoaccademico_alias2_aa'] = { tableNameLookup:'annoaccademico_alias2', columnNameLookup:'aa', columnNamekey:'iddidprog_acc' };
						objCalcFieldConfig['!iddidprog_acc_sede_title'] = { tableNameLookup:'sede', columnNameLookup:'title', columnNamekey:'iddidprog_acc' };
						this.describeAColumn(table, '!iddidprog_acc_sede_title', 'Sede', null, 14, null);
						this.describeAColumn(table, '!iddidprog_acc_didprog_alias2_codicemiur', 'Codice MIUR', null, 18, null);
						this.describeAColumn(table, '!iddidprog_acc_corsostudiokind_title', 'Tipologia', null, 53, null);
						this.describeAColumn(table, '!iddidprog_acc_corsostudiolivello_title', 'Livello', null, 54, null);
						objCalcFieldConfig['!iddidprog_acc_didprog_alias2_codicemiur'] = { tableNameLookup:'didprog_alias2', columnNameLookup:'codicemiur', columnNamekey:'iddidprog_acc' };
						objCalcFieldConfig['!iddidprog_acc_corsostudiokind_title'] = { tableNameLookup:'corsostudiokind', columnNameLookup:'title', columnNamekey:'iddidprog_acc' };
						objCalcFieldConfig['!iddidprog_acc_corsostudiolivello_title'] = { tableNameLookup:'corsostudiolivello', columnNameLookup:'title', columnNamekey:'iddidprog_acc' };
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["iddidprog"].caption = "test di ingresso";
						table.columns["iddidprog_acc"].caption = "didattica programmata a cui il test di ingresso da l'accesso";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_didprogaccesso");

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

    window.appMeta.addMeta('didprogaccesso', new meta_didprogaccesso('didprogaccesso'));

	}());
