(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfinterazioni() {
        MetaData.apply(this, ["perfinterazioni"]);
        this.name = 'meta_perfinterazioni';
    }

    meta_perfinterazioni.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfinterazioni,
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
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'commenti', 'Commenti', null, 40, -1);
						this.describeAColumn(table, 'utente', 'Utente', null, 120, 1024);
						this.describeAColumn(table, '!idperfinterazionekind_perfinterazionekind_title', 'Tipo di interazione', null, 11, null);
						objCalcFieldConfig['!idperfinterazionekind_perfinterazionekind_title'] = { tableNameLookup:'perfinterazionekind', columnNameLookup:'title', columnNamekey:'idperfinterazionekind' };
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
						table.columns["commenti"].caption = "Commenti";
						table.columns["commentival"].caption = "Commenti valutatore";
						table.columns["data"].caption = "Data";
						table.columns["idperfinterazionekind"].caption = "Tipo di interazione";
						table.columns["utente"].caption = "Utente";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfinterazioni");

				//$getNewRowInside$

				dt.autoIncrement('idperfinterazioni', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "data asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfinterazioni', new meta_perfinterazioni('perfinterazioni'));

	}());
