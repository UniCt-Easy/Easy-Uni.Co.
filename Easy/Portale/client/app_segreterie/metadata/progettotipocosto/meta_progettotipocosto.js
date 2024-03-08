(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettotipocosto() {
        MetaData.apply(this, ["progettotipocosto"]);
        this.name = 'meta_progettotipocosto';
    }

    meta_progettotipocosto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotipocosto,
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
						this.describeAColumn(table, 'title', 'Voce', null, 10, 2048);
						this.describeAColumn(table, 'ammissibilita', 'Ammissibilità (%)', 'fixed.2', 20, null);
						this.describeAColumn(table, 'budgetrichiesto', 'Budget richiesto', 'fixed.2', 70, null);
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
						table.columns["ammissibilita"].caption = "Ammissibilità (%)";
						table.columns["budgetrichiesto"].caption = "Budget richiesto";
						table.columns["idprogettotipocostokind"].caption = "Voce di costo";
						table.columns["sortcode"].caption = "Ordinamento";
						table.columns["title"].caption = "Voce";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettotipocosto");

				//$getNewRowInside$

				dt.autoIncrement('idprogettotipocosto', { minimum: 99990001 });

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
						return "sortcode";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettotipocosto', new meta_progettotipocosto('progettotipocosto'));

	}());
