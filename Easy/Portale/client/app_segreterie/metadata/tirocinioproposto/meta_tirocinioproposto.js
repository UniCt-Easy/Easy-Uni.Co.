(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tirocinioproposto() {
        MetaData.apply(this, ["tirocinioproposto"]);
        this.name = 'meta_tirocinioproposto';
    }

    meta_tirocinioproposto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tirocinioproposto,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 10, -1);
						this.describeAColumn(table, 'ore', 'Ore', null, 80, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seg':
						table.columns["description"].caption = "Descrizione";
						table.columns["description_en"].caption = "Descrizione in inglese";
						table.columns["idaoo"].caption = "Area organizzativa omogenea";
						table.columns["idreg_referente"].caption = "Referente";
						table.columns["idstruttura"].caption = "Struttura dell'istituto";
						table.columns["title"].caption = "Titolo";
						table.columns["title_en"].caption = "Titolo in inglese";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_tirocinioproposto");

				//$getNewRowInside$

				dt.autoIncrement('idtirocinioproposto', { minimum: 99990001 });

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
						return "title desc, description desc, description_en desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('tirocinioproposto', new meta_tirocinioproposto('tirocinioproposto'));

	}());
