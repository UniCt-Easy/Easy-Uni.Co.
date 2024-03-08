(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_bandods() {
        MetaData.apply(this, ["bandods"]);
        this.name = 'meta_bandods';
    }

    meta_bandods.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandods,
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
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'title', 'Titolo', null, 30, 1024);
						this.describeAColumn(table, 'description', 'Testo del bando', null, 40, -1);
						this.describeAColumn(table, 'fondo', 'Fondo', null, 50, 1024);
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
						table.columns["aa"].caption = "Anno accademico";
						table.columns["description"].caption = "Testo del bando";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_bandods");

				//$getNewRowInside$

				dt.autoIncrement('idbandods', { minimum: 99990001 });

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
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('bandods', new meta_bandods('bandods'));

	}());
