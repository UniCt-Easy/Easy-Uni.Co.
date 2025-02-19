﻿(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tipoattform() {
        MetaData.apply(this, ["tipoattform"]);
        this.name = 'meta_tipoattform';
    }

    meta_tipoattform.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tipoattform,
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
					case 'solosigla':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 1);
//$objCalcFieldConfig_solosigla$
						break;
					case 'default':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 1);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, 256);
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
					case 'solosigla':
						table.columns["description"].caption = "Descrizione";
						table.columns["title"].caption = "Denominazione";
//$innerSetCaptionConfig_solosigla$
						break;
					case 'default':
						table.columns["description"].caption = "Descrizione";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_tipoattform");

				//$getNewRowInside$

				dt.autoIncrement('idtipoattform', { minimum: 99990001 });

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
					case "solosigla": {
						return "title asc ";
					}
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('tipoattform', new meta_tipoattform('tipoattform'));

	}());
