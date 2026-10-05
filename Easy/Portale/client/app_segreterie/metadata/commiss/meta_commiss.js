(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_commiss() {
        MetaData.apply(this, ["commiss"]);
        this.name = 'meta_commiss';
    }

    meta_commiss.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_commiss,
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
						this.describeAColumn(table, 'idreg_docenti', 'Verbalizzante', null, 50, null);
//$objCalcFieldConfig_default$
						break;
					case 'ingresso':
						this.describeAColumn(table, 'idreg_docenti', 'Verbalizzante', null, 50, null);
//$objCalcFieldConfig_ingresso$
						break;
					case 'doc':
						this.describeAColumn(table, 'idreg_docenti', 'Verbalizzante', null, 50, null);
//$objCalcFieldConfig_doc$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'ingresso':
						table.columns["idreg_docenti"].caption = "Verbalizzante";
//$innerSetCaptionConfig_ingresso$
						break;
					case 'default':
//$innerSetCaptionConfig_default$
						break;
					case 'doc':
//$innerSetCaptionConfig_doc$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_commiss");

				//$getNewRowInside$

				dt.autoIncrement('idcommiss', { minimum: 99990001 });

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
					case "ingresso": {
						return "idcommiss asc ";
					}
					case "default": {
						return "idcommiss asc ";
					}
					case "doc": {
						return "idcommiss asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('commiss', new meta_commiss('commiss'));

	}());
