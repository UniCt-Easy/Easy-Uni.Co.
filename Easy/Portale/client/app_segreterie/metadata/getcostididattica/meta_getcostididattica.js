(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_getcostididattica() {
        MetaData.apply(this, ["getcostididattica"]);
        this.name = 'meta_getcostididattica';
    }

    meta_getcostididattica.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getcostididattica,
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
					case 'erogata':
						this.describeAColumn(table, 'aaprogrammata', 'AA programmata', null, 40, 9);
						this.describeAColumn(table, 'curriculum', 'Curriculum', null, 50, 256);
						this.describeAColumn(table, 'insegnamento', 'Insegnamento', null, 60, 256);
						this.describeAColumn(table, 'modulo', 'Modulo', null, 70, 256);
						this.describeAColumn(table, 'affidamento', 'Affidamento', null, 80, 1075);
						this.describeAColumn(table, 'docente', 'Docente', null, 90, 101);
						this.describeAColumn(table, 'ruolo', 'Ruolo', null, 100, 50);
						this.describeAColumn(table, 'costoorariodacontratto', 'Costo orario da ruolo', null, 110, 2);
						this.describeAColumn(table, 'costo', 'Costo', 'fixed.2', 120, null);
//$objCalcFieldConfig_erogata$
						break;
					case 'default':
						this.describeAColumn(table, 'corsostudio', 'Corso di studio', null, 10, 1024);
						this.describeAColumn(table, 'sede', 'Sede', null, 20, 1024);
						this.describeAColumn(table, 'aa', 'AA erogata', null, 30, 9);
						this.describeAColumn(table, 'aaprogrammata', 'AA programmata', null, 40, 9);
						this.describeAColumn(table, 'curriculum', 'Curriculum', null, 50, 256);
						this.describeAColumn(table, 'insegnamento', 'Insegnamento', null, 60, 256);
						this.describeAColumn(table, 'modulo', 'Modulo', null, 70, 256);
						this.describeAColumn(table, 'affidamento', 'Affidamento', null, 80, 1075);
						this.describeAColumn(table, 'docente', 'Docente', null, 90, 101);
						this.describeAColumn(table, 'ruolo', 'Ruolo', null, 100, 50);
						this.describeAColumn(table, 'costoorariodacontratto', 'Costo orario da ruolo', null, 110, 2);
						this.describeAColumn(table, 'costo', 'Costo', 'fixed.2', 120, null);
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
					case 'erogata':
						table.columns["aa"].caption = "AA erogata";
						table.columns["aaprogrammata"].caption = "AA programmata";
						table.columns["corsostudio"].caption = "Corso di studio";
						table.columns["costoorariodacontratto"].caption = "Costo orario da ruolo";
						table.columns["idaffidamento"].caption = "Affidamento";
						table.columns["idaffidamentokind"].caption = "Affidamento";
						table.columns["idcorsostudio"].caption = "Corso di studio";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["iddidprogcurr"].caption = "Curriculum";
						table.columns["idinsegn"].caption = "Insegnamento";
						table.columns["idinsegninteg"].caption = "Modulo";
						table.columns["idposition"].caption = "Ruolo";
						table.columns["idreg_docenti"].caption = "Docente";
						table.columns["idsede"].caption = "Sede";
//$innerSetCaptionConfig_erogata$
						break;
					case 'default':
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_getcostididattica");

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
					case "erogata": {
						return "corsostudio asc , sede asc , aa asc , aaprogrammata asc , curriculum asc , insegnamento asc , modulo asc , affidamento asc , docente asc , ruolo asc ";
					}
					case "default": {
						return "corsostudio asc , sede asc , aa asc , aaprogrammata asc , curriculum asc , insegnamento asc , modulo asc , affidamento asc , docente asc , ruolo asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('getcostididattica', new meta_getcostididattica('getcostididattica'));

	}());
