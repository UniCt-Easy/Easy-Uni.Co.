(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_graduatoriaesiti() {
        MetaData.apply(this, ["graduatoriaesiti"]);
        this.name = 'meta_graduatoriaesiti';
    }

    meta_graduatoriaesiti.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_graduatoriaesiti,
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
						this.describeAColumn(table, 'datachiusura', 'Data di chiusura', 'g', 20, null);
						this.describeAColumn(table, 'provvisoria', 'Provvisoria', null, 60, null);
//$objCalcFieldConfig_seg$
						break;
					case 'stato':
						this.describeAColumn(table, 'datachiusura', 'Data di chiusura', 'g', 20, null);
						this.describeAColumn(table, 'provvisoria', 'Provvisoria', null, 40, null);
//$objCalcFieldConfig_stato$
						break;
					case 'default':
						this.describeAColumn(table, 'datachiusura', 'Data di chiusura', 'g', 20, null);
						this.describeAColumn(table, 'provvisoria', 'Provvisoria', null, 40, null);
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
						table.columns["datachiusura"].caption = "Data di chiusura";
						table.columns["idgraduatoria"].caption = "Calcolo su cui è basata";
//$innerSetCaptionConfig_default$
						break;
					case 'seg':
//$innerSetCaptionConfig_seg$
						break;
					case 'stato':
						table.columns["datachiusura"].caption = "Data di chiusura";
//$innerSetCaptionConfig_stato$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_graduatoriaesiti");

				//$getNewRowInside$

				dt.autoIncrement('idgraduatoriaesiti', { minimum: 99990001 });

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
					case "seg": {
						return "idgraduatoria desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('graduatoriaesiti', new meta_graduatoriaesiti('graduatoriaesiti'));

	}());
