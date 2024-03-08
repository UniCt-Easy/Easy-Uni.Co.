﻿(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfrequestobbunatantum() {
        MetaData.apply(this, ["perfrequestobbunatantum"]);
        this.name = 'meta_perfrequestobbunatantum';
    }

    meta_perfrequestobbunatantum.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfrequestobbunatantum,
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
						this.describeAColumn(table, 'title', 'Titolo obiettivo', null, 10, 1024);
						this.describeAColumn(table, 'year', 'Anno solare', null, 20, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 40, -1);
						this.describeAColumn(table, 'peso', 'Peso', 'fixed.2', 50, null);
						this.describeAColumn(table, 'inserito', 'Inserito', null, 60, null);
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
						table.columns["description"].caption = "Descrizione";
						table.columns["idstruttura"].caption = "Struttura";
						table.columns["inserito"].caption = "Inserito";
						table.columns["peso"].caption = "Peso";
						table.columns["title"].caption = "Titolo obiettivo";
						table.columns["year"].caption = "Anno solare";
						table.columns["idstruttura"].caption = "Unità organizzativa";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfrequestobbunatantum");

				//$getNewRowInside$

				dt.autoIncrement('idperfrequestobbunatantum', { minimum: 99990001 });

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
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfrequestobbunatantum', new meta_perfrequestobbunatantum('perfrequestobbunatantum'));

	}());
