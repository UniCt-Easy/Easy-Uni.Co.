(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_classescuola() {
        MetaData.apply(this, ["classescuola"]);
        this.name = 'meta_classescuola';
    }

    meta_classescuola.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_classescuola,
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
						this.describeAColumn(table, 'sigla', 'Sigla', null, 10, 50);
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 256);
						this.describeAColumn(table, 'indicecineca', 'Identificativo CINECA', null, 30, null);
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
						table.columns["idclassescuola"].caption = "Identificativo";
						table.columns["idclassescuolaarea"].caption = "Area";
						table.columns["idclassescuolakind"].caption = "Tipologia";
						table.columns["idcorsostudionorma"].caption = "Normativa";
						table.columns["indicecineca"].caption = "Identificativo CINECA";
						table.columns["obbform"].caption = "Obiettivi formativi";
						table.columns["prospocc"].caption = "Prospettive occupazionali";
						table.columns["title"].caption = "Denominazione";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_classescuola");

				//$getNewRowInside$

				dt.autoIncrement('idclassescuola', { minimum: 99990001 });

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
						return "sigla asc , title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('classescuola', new meta_classescuola('classescuola'));

	}());
