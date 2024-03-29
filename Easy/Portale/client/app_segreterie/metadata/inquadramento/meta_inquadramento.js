﻿(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_inquadramento() {
        MetaData.apply(this, ["inquadramento"]);
        this.name = 'meta_inquadramento';
    }

    meta_inquadramento.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_inquadramento,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 2048);
						this.describeAColumn(table, 'tempdef', 'Tempo definito', null, 30, null);
						this.describeAColumn(table, 'start', 'Inizio validità', 'g', 80, null);
						this.describeAColumn(table, 'stop', 'Fine validità', 'g', 90, null);
						this.describeAColumn(table, 'costolordoannuo', 'Costo lordo annuo massimo', 'fixed.2', 100, null);
						this.describeAColumn(table, 'costolordoannuooneri', 'Costo lordo e oneri annuo massimo', 'fixed.2', 110, null);
//$objCalcFieldConfig_default$
						break;
					case 'elenco':
						this.describeAColumn(table, 'title', 'Inquadramento', null, 20, 2048);
						this.describeAColumn(table, 'tempdef', 'Tempo definito', null, 30, null);
						this.describeAColumn(table, 'start', 'Inizio validità', 'g', 80, null);
						this.describeAColumn(table, 'stop', 'Fine validità', 'g', 90, null);
						this.describeAColumn(table, 'costolordoannuo', 'Costo lordo annuo massimo', 'fixed.2', 100, null);
						this.describeAColumn(table, 'costolordoannuooneri', 'Costo lordo e oneri annuo massimo', 'fixed.2', 110, null);
//$objCalcFieldConfig_elenco$
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
						table.columns["costolordoannuo"].caption = "Costo lordo annuo massimo";
						table.columns["costolordoannuooneri"].caption = "Costo lordo e oneri annuo massimo";
						table.columns["siglaimportazione"].caption = "Sigla importazione";
						table.columns["start"].caption = "Inizio validità";
						table.columns["stop"].caption = "Fine validità";
						table.columns["tempdef"].caption = "Tempo definito";
						table.columns["title"].caption = "Denominazione";
//$innerSetCaptionConfig_default$
						break;
					case 'elenco':
						table.columns["idposition"].caption = "Tipologia contrattuale";
						table.columns["title"].caption = "Inquadramento";
//$innerSetCaptionConfig_elenco$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_inquadramento");

				//$getNewRowInside$

				dt.autoIncrement('idinquadramento', { minimum: 99990001 });

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
					case "elenco": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('inquadramento', new meta_inquadramento('inquadramento'));

	}());
