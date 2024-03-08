(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_titolostudio() {
        MetaData.apply(this, ["titolostudio"]);
        this.name = 'meta_titolostudio';
    }

    meta_titolostudio.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_titolostudio,
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
					case 'docenti':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 30, 9);
						this.describeAColumn(table, 'data', 'Data del conseguimento', null, 50, null);
						this.describeAColumn(table, 'giudizio', 'Giudizio', null, 60, 50);
						this.describeAColumn(table, 'voto', 'Voto', null, 70, null);
						this.describeAColumn(table, 'votosu', 'Su', null, 80, null);
						this.describeAColumn(table, 'votolode', 'Lode', null, 90, null);
						this.describeAColumn(table, '!idistattitolistudio_istattitolistudio_titolo', 'Titolo ISTAT', null, 11, null);
						objCalcFieldConfig['!idistattitolistudio_istattitolistudio_titolo'] = { tableNameLookup:'istattitolistudio', columnNameLookup:'titolo', columnNamekey:'idistattitolistudio' };
						this.describeAColumn(table, '!idreg_istituti_registry_istituti_title', 'Istituto', null, 21, null);
						objCalcFieldConfig['!idreg_istituti_registry_istituti_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg_istituti' };
//$objCalcFieldConfig_docenti$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'docenti':
						table.columns["aa"].caption = "Anno accademico";
						table.columns["data"].caption = "Data del conseguimento";
						table.columns["idattach"].caption = "Allegato";
						table.columns["idistattitolistudio"].caption = "Titolo ISTAT";
						table.columns["idreg"].caption = "Studente";
						table.columns["idreg_istituti"].caption = "Istituto";
						table.columns["votolode"].caption = "Lode";
						table.columns["votosu"].caption = "Su";
//$innerSetCaptionConfig_docenti$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_titolostudio");

				//$getNewRowInside$

				dt.autoIncrement('idtitolostudio', { minimum: 99990001 });

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

    window.appMeta.addMeta('titolostudio', new meta_titolostudio('titolostudio'));

	}());
