(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_timesheettemplate() {
        MetaData.apply(this, ["timesheettemplate"]);
        this.name = 'meta_timesheettemplate';
    }

    meta_timesheettemplate.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_timesheettemplate,
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
						this.describeAColumn(table, 'title', 'Template', null, 20, 255);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, 1024);
//$objCalcFieldConfig_default$
						break;
					case 'configurazione':
						this.describeAColumn(table, 'idtimesheettemplate', 'Template', null, 10, 60);
						this.describeAColumn(table, 'leftsignaturelabel', 'Label firma sinistra', null, 20, 255);
						this.describeAColumn(table, 'middlesignaturelabel', 'Label firma centrale', null, 30, 255);
						this.describeAColumn(table, 'rightsignaturelabel', 'Label firma destra', null, 40, 255);
						this.describeAColumn(table, 'title', 'Titolo', null, 50, 255);
						this.describeAColumn(table, 'description', 'Descrizione', null, 60, 1024);
						this.describeAColumn(table, 'active', 'Attivo', null, 110, null);
//$objCalcFieldConfig_configurazione$
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
						table.columns["description"].caption = "Descrizione";
						table.columns["idtimesheettemplate"].caption = "Template";
						table.columns["title"].caption = "Template";
//$innerSetCaptionConfig_default$
						break;
					case 'configurazione':
						table.columns["active"].caption = "Attivo";
						table.columns["description"].caption = "Descrizione";
						table.columns["leftsignaturelabel"].caption = "Label firma sinistra";
						table.columns["middlesignaturelabel"].caption = "Label firma centrale";
						table.columns["rightsignaturelabel"].caption = "Label firma destra";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_configurazione$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_timesheettemplate");

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

			getSorting: function (listType) {
				switch (listType) {
					case "configurazione": {
						return "title desc";
					}
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('timesheettemplate', new meta_timesheettemplate('timesheettemplate'));

	}());
