(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfschedacambiostatoperfruolo() {
        MetaData.apply(this, ["perfschedacambiostatoperfruolo"]);
        this.name = 'meta_perfschedacambiostatoperfruolo';
    }

    meta_perfschedacambiostatoperfruolo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfschedacambiostatoperfruolo,
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
					case 'maildest':
						this.describeAColumn(table, 'idperfruolo', 'Codice', null, 10, 50);
//$objCalcFieldConfig_maildest$
						break;
					case 'default':
						this.describeAColumn(table, 'idperfruolo', 'Codice', null, 10, 50);
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
					case 'maildest':
						table.columns["idperfruolo"].caption = "Codice";
//$innerSetCaptionConfig_maildest$
						break;
					case 'default':
						table.columns["idperfruolo"].caption = "Codice";
						table.columns["idperfruolo"].caption = "Ruolo";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfschedacambiostatoperfruolo");

				//$getNewRowInside$


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
					case "maildest": {
						return "idperfruolo desc";
					}
					case "default": {
						return "idperfruolo desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfschedacambiostatoperfruolo', new meta_perfschedacambiostatoperfruolo('perfschedacambiostatoperfruolo'));

	}());
