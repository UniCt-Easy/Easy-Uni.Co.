﻿(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettostatuskind() {
        MetaData.apply(this, ["progettostatuskind"]);
        this.name = 'meta_progettostatuskind';
    }

    meta_progettostatuskind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettostatuskind,
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
						this.describeAColumn(table, 'title', 'Stato', null, 20, 50);
						this.describeAColumn(table, 'sortcode', 'Ordinamento', null, 30, null);
						this.describeAColumn(table, 'contributo', 'Abilita il cofinanziamento ottenuto dall\'ateneo', null, 80, null);
						this.describeAColumn(table, 'contributoente', 'Abilita il contributo totale ottenuto per l\'ateneo dall’ente finanziatore', null, 90, null);
						this.describeAColumn(table, 'contributoenterichiesto', 'Abilita il contributo totale richiesto dall\'ateneo all’ente finanziatore', null, 100, null);
						this.describeAColumn(table, 'contributorichiesto', 'Abilita il cofinanziamento richiesto all\'ateneo', null, 110, null);
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
						table.columns["contributo"].caption = "Abilita il cofinanziamento ottenuto dall'ateneo";
						table.columns["contributoente"].caption = "Abilita il contributo totale ottenuto per l'ateneo dall’ente finanziatore";
						table.columns["contributoenterichiesto"].caption = "Abilita il contributo totale richiesto dall'ateneo all’ente finanziatore";
						table.columns["contributorichiesto"].caption = "Abilita il cofinanziamento richiesto all'ateneo";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettostatuskind");

				//$getNewRowInside$

				dt.autoIncrement('idprogettostatuskind', { minimum: 99990001 });

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
						return "sortcode";
					}
					case "default": {
						return "title desc, sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettostatuskind', new meta_progettostatuskind('progettostatuskind'));

	}());
