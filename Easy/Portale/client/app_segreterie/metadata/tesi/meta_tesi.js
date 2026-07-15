(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tesi() {
        MetaData.apply(this, ["tesi"]);
        this.name = 'meta_tesi';
    }

    meta_tesi.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tesi,
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
					case 'segistcons':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'title', 'Titolo', null, 30, -1);
						this.describeAColumn(table, 'abstract', 'Abstract', null, 40, -1);
						this.describeAColumn(table, 'abstract_en', 'Abstract in inglese', null, 50, -1);
						this.describeAColumn(table, 'filestatus', 'Stato del file allegato', null, 60, null);
						this.describeAColumn(table, 'idattach', 'file allegato', null, 70, null);
						this.describeAColumn(table, 'idinsegn', 'Insegnamento di riferimento', null, 90, null);
						this.describeAColumn(table, 'idtesikind', 'Tipologia', null, 100, null);
						this.describeAColumn(table, 'title_en', 'Titolo in inglese', null, 110, -1);
//$objCalcFieldConfig_segistcons$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'segistcons':
						table.columns["aa"].caption = "Anno accademico";
						table.columns["abstract_en"].caption = "Abstract in inglese";
						table.columns["filestatus"].caption = "Stato del file allegato";
						table.columns["idattach"].caption = "file allegato";
						table.columns["idinsegn"].caption = "Insegnamento di riferimento";
						table.columns["idreg"].caption = "Studente";
						table.columns["idtesikind"].caption = "Tipologia";
						table.columns["title"].caption = "Titolo";
						table.columns["title_en"].caption = "Titolo in inglese";
//$innerSetCaptionConfig_segistcons$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_tesi");

				//$getNewRowInside$

				dt.autoIncrement('idtesi', { minimum: 99990001 });

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
					case "segistcons": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('tesi', new meta_tesi('tesi'));

	}());
