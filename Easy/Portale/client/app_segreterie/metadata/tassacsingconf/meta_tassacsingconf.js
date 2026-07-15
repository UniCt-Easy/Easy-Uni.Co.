(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tassacsingconf() {
        MetaData.apply(this, ["tassacsingconf"]);
        this.name = 'meta_tassacsingconf';
    }

    meta_tassacsingconf.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tassacsingconf,
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
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'costomax', 'Costo massimo', 'fixed.2', 30, null);
						this.describeAColumn(table, 'numerosconto', 'Numero di insegnamenti per cui si applica lo sconto', null, 70, null);
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
						table.columns["aa"].caption = "Anno accademico";
						table.columns["costomax"].caption = "Costo massimo";
						table.columns["idcostoscontodef"].caption = "Costo";
						table.columns["idcostoscontodef_2"].caption = "Costo corsi speciali";
						table.columns["idcostoscontodef_sconto"].caption = "Sconto";
						table.columns["numerosconto"].caption = "Numero di insegnamenti per cui si applica lo sconto";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_tassacsingconf");

				//$getNewRowInside$

				dt.autoIncrement('idtassacsingconf', { minimum: 99990001 });

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

        });

    window.appMeta.addMeta('tassacsingconf', new meta_tassacsingconf('tassacsingconf'));

	}());
