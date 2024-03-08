(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_rendicontattivitaprogettoorasegsalview() {
        MetaData.apply(this, ["rendicontattivitaprogettoorasegsalview"]);
        this.name = 'meta_rendicontattivitaprogettoorasegsalview';
    }

    meta_rendicontattivitaprogettoorasegsalview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontattivitaprogettoorasegsalview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'segsal':
						this.describeAColumn(table, 'workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 1100, 2048);
						this.describeAColumn(table, 'workpackage_title', 'Titolo Workpackage', null, 1200, 2048);
						this.describeAColumn(table, 'rendicontattivitaprogettoora_data', 'Data', null, 3000, null);
						this.describeAColumn(table, 'registry_title', 'Denominazione Partecipante Attività', null, 6230, 101);
						this.describeAColumn(table, 'rendicontattivitaprogetto_description', 'Descrizione Attività', null, 6300, -1);
						this.describeAColumn(table, 'rendicontattivitaprogettoora_ore', 'Numero di ore', null, 7000, null);
						this.describeAColumn(table, 'sal_start', 'Data di inizio Stato di avanzamento lavori', null, 13100, null);
						this.describeAColumn(table, 'sal_stop', 'Data di fine Stato di avanzamento lavori', null, 13400, null);
//$objCalcFieldConfig_segsal$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idworkpackage", "idrendicontattivitaprogetto", "idrendicontattivitaprogettoora"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "segsal": {
						return "rendicontattivitaprogettoora_data asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('rendicontattivitaprogettoorasegsalview', new meta_rendicontattivitaprogettoorasegsalview('rendicontattivitaprogettoorasegsalview'));

	}());
