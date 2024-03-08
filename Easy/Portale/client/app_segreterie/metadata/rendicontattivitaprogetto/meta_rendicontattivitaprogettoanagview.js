(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_rendicontattivitaprogettoanagview() {
        MetaData.apply(this, ["rendicontattivitaprogettoanagview"]);
        this.name = 'meta_rendicontattivitaprogettoanagview';
    }

    meta_rendicontattivitaprogettoanagview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontattivitaprogettoanagview,
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
					case 'anag':
						this.describeAColumn(table, 'progetto_titolobreve', 'Titolo breve o acronimo Progetto', null, 1100, 2048);
						this.describeAColumn(table, 'workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 2100, 2048);
						this.describeAColumn(table, 'workpackage_title', 'Titolo Workpackage', null, 2200, 2048);
						this.describeAColumn(table, 'workpackage_start', 'Data di inizio Workpackage', null, 3000, null);
						this.describeAColumn(table, 'rendicontattivitaprogetto_description', 'Descrizione', null, 3000, -1);
						this.describeAColumn(table, 'workpackage_stop', 'Data di fine Workpackage', null, 3100, null);
						this.describeAColumn(table, 'progetto_start', 'Data di inizio Progetto', null, 4000, null);
						this.describeAColumn(table, 'progetto_stop', 'Data di fine Progetto', null, 4100, null);
						this.describeAColumn(table, 'rendicontattivitaprogetto_orepreventivate', 'Numero di ore preventivate', null, 7000, null);
						this.describeAColumn(table, 'rendicontattivitaprogetto_datainizioprevista', 'Data inizio prevista', null, 11000, null);
						this.describeAColumn(table, 'rendicontattivitaprogetto_stop', 'Data fine prevista', null, 12000, null);
						this.describeAColumn(table, 'rendicontattivitaprogettokind_title', 'Tipo di attività', null, 13200, 255);
//$objCalcFieldConfig_anag$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idrendicontattivitaprogetto"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "anag": {
						return "rendicontattivitaprogetto_datainizioprevista asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('rendicontattivitaprogettoanagview', new meta_rendicontattivitaprogettoanagview('rendicontattivitaprogettoanagview'));

	}());
