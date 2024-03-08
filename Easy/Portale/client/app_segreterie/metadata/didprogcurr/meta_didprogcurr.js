(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didprogcurr() {
        MetaData.apply(this, ["didprogcurr"]);
        this.name = 'meta_didprogcurr';
    }

    meta_didprogcurr.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprogcurr,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 256);
						this.describeAColumn(table, 'codice', 'Codice', null, 30, 50);
						this.describeAColumn(table, 'codicemiur', 'Codice MIUR', null, 40, 50);
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
						table.columns["codicemiur"].caption = "Codice MIUR";
						table.columns["title"].caption = "Denominazione";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_didprogcurr");

				//$getNewRowInside$

				dt.autoIncrement('iddidprogcurr', { minimum: 99990001 });

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
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('didprogcurr', new meta_didprogcurr('didprogcurr'));

	}());
