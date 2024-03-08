(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_insegninteg() {
        MetaData.apply(this, ["insegninteg"]);
        this.name = 'meta_insegninteg';
    }

    meta_insegninteg.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_insegninteg,
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
						this.describeAColumn(table, 'codice', 'Codice', null, 20, 50);
						this.describeAColumn(table, 'denominazione', 'Denominazione', null, 30, 256);
						this.describeAColumn(table, '!insegnintegcaratteristica', 'Caratteristiche degli insegnamenti integrandi', null, 30, null);
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
						table.columns["denominazione_en"].caption = "Denominazione in inglese";
						table.columns["idinsegn"].caption = "Insegnamento padre";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_insegninteg");

				//$getNewRowInside$

				dt.autoIncrement('idinsegninteg', { minimum: 99990001 });

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
						return "denominazione asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('insegninteg', new meta_insegninteg('insegninteg'));

	}());
