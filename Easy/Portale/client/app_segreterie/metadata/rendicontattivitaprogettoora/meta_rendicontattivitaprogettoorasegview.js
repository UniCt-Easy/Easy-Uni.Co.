(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_rendicontattivitaprogettoorasegview() {
        MetaData.apply(this, ["rendicontattivitaprogettoorasegview"]);
        this.name = 'meta_rendicontattivitaprogettoorasegview';
    }

    meta_rendicontattivitaprogettoorasegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontattivitaprogettoorasegview,
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
					case 'seg':
						this.describeAColumn(table, 'rendicontattivitaprogettoora_data', 'Data', null, 3000, null);
						this.describeAColumn(table, 'rendicontattivitaprogettoora_ore', 'Numero di ore', null, 7000, null);
						this.describeAColumn(table, 'sal_start', 'Data di inizio Stato di avanzamento lavori', null, 13100, null);
						this.describeAColumn(table, 'sal_stop', 'Data di fine Stato di avanzamento lavori', null, 13400, null);
//$objCalcFieldConfig_seg$
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
					case "seg": {
						return "rendicontattivitaprogettoora_data asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('rendicontattivitaprogettoorasegview', new meta_rendicontattivitaprogettoorasegview('rendicontattivitaprogettoorasegview'));

	}());
