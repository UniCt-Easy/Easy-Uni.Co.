(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_classconsorsuale() {
        MetaData.apply(this, ["classconsorsuale"]);
        this.name = 'meta_classconsorsuale';
    }

    meta_classconsorsuale.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_classconsorsuale,
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
						this.describeAColumn(table, 'title', 'Codice', null, 10, 50);
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, 512);
						this.describeAColumn(table, 'active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'ambitodisci', 'Ambito Disciplinare', null, 40, 50);
						this.describeAColumn(table, 'normativa', 'Normativa', null, 50, 50);
						this.describeAColumn(table, 'corr2592017', 'Corrispondenza', null, 60, 50);
						this.describeAColumn(table, 'tipoente', 'Tipologia di ente', null, 100, null);
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
						table.columns["active"].caption = "Attivo";
						table.columns["ambitodisci"].caption = "Ambito Disciplinare";
						table.columns["corr2592017"].caption = "Corrispondenza";
						table.columns["description"].caption = "Descrizione";
						table.columns["normativa"].caption = "Normativa";
						table.columns["tipoente"].caption = "Tipologia di ente";
						table.columns["title"].caption = "Codice";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_classconsorsuale");

				//$getNewRowInside$

				dt.autoIncrement('idclassconsorsuale', { minimum: 99990001 });

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

    window.appMeta.addMeta('classconsorsuale', new meta_classconsorsuale('classconsorsuale'));

	}());
