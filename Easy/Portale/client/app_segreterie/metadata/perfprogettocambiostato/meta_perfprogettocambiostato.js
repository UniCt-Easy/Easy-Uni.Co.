(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettocambiostato() {
        MetaData.apply(this, ["perfprogettocambiostato"]);
        this.name = 'meta_perfprogettocambiostato';
    }

    meta_perfprogettocambiostato.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettocambiostato,
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
						this.describeAColumn(table, 'idperfruolo', 'Chi lo può cambiare', null, 110, 50);
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
						table.columns["idperfprogettostatus"].caption = "Da";
						table.columns["idperfprogettostatus_to"].caption = "A";
						table.columns["idperfruolo"].caption = "Chi lo può cambiare";
						table.columns["idperfruolo_mail"].caption = "Chi viene avvisato via e-mail";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfprogettocambiostato");

				//$getNewRowInside$

				dt.autoIncrement('idperfprogettocambiostato', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettocambiostato', new meta_perfprogettocambiostato('perfprogettocambiostato'));

	}());
