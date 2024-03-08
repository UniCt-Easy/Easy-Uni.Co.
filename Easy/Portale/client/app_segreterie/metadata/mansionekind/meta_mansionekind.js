(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_mansionekind() {
        MetaData.apply(this, ["mansionekind"]);
        this.name = 'meta_mansionekind';
    }

    meta_mansionekind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_mansionekind,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2048);
						this.describeAColumn(table, 'pesoateneo', 'Peso della valutazione della performance organizzativa di ateneo', 'fixed.2', 70, null);
						this.describeAColumn(table, 'pesouo', 'Peso della valutazione della performance dell’unità organizzativa', 'fixed.2', 80, null);
						this.describeAColumn(table, 'pesocomp', 'Peso della valutazione della performance dei comportamenti', 'fixed.2', 90, null);
						this.describeAColumn(table, 'pesoindividuale', 'Peso della valutazione della performance individuale', 'fixed.2', 100, null);
						this.describeAColumn(table, 'generascheda', 'Ha la scheda di valutazione', null, 110, null);
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
						table.columns["generascheda"].caption = "Ha la scheda di valutazione";
						table.columns["pesoateneo"].caption = "Peso della valutazione della performance organizzativa di ateneo";
						table.columns["pesocomp"].caption = "Peso della valutazione della performance dei comportamenti";
						table.columns["pesoindividuale"].caption = "Peso della valutazione della performance individuale";
						table.columns["pesouo"].caption = "Peso della valutazione della performance dell’unità organizzativa";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_mansionekind");

				//$getNewRowInside$

				dt.autoIncrement('idmansionekind', { minimum: 99990001 });

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

    window.appMeta.addMeta('mansionekind', new meta_mansionekind('mansionekind'));

	}());
