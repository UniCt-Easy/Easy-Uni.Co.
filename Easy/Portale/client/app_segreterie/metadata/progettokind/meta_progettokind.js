(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettokind() {
        MetaData.apply(this, ["progettokind"]);
        this.name = 'meta_progettokind';
    }

    meta_progettokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettokind,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2048);
						this.describeAColumn(table, 'oredivisionecostostipendio', 'Numero ore lavorate in un anno dal personale', null, 30, null);
						this.describeAColumn(table, 'stipendioannoprec', 'Usa stipendi anno precedente', null, 80, null);
						this.describeAColumn(table, 'stipendiocomericavo', 'Usa stipendi come ricavi', null, 90, null);
						this.describeAColumn(table, 'active', 'Attivo', null, 100, null);
						this.describeAColumn(table, 'irap', 'Includi l\'IRAP nei costi del personale', null, 110, null);
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
						table.columns["active"].caption = "Attivo";
						table.columns["description"].caption = "Descrizione";
						table.columns["idcorsostudio"].caption = "Abilita il corso di studio";
						table.columns["idprogettoactivitykind"].caption = "Tipologia";
						table.columns["irap"].caption = "Includi l'IRAP nei costi del personale";
						table.columns["oredivisionecostostipendio"].caption = "Numero ore lavorate in un anno dal personale";
						table.columns["stipendioannoprec"].caption = "Usa stipendi anno precedente";
						table.columns["stipendiocomericavo"].caption = "Usa stipendi come ricavi";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettokind");

				//$getNewRowInside$

				dt.autoIncrement('idprogettokind', { minimum: 99990001 });

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
						return "idprogettoactivitykind asc , title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettokind', new meta_progettokind('progettokind'));

	}());
