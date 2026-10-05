(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanzaabbr_segview() {
        MetaData.apply(this, ["istanzaabbr_segview"]);
        this.name = 'meta_istanzaabbr_segview';
    }

    meta_istanzaabbr_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzaabbr_segview,
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
					case 'abbr_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 1000, 9);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 3000, null);
						this.describeAColumn(table, 'corsostudio_title', 'Denominazione Corso di studi', null, 5100, 1024);
						this.describeAColumn(table, 'corsostudio_annoistituz', 'Anno accademico di istituzione Corso di studi', null, 5600, null);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 6100, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 6200, 9);
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede Didattica programmata', null, 6320, 1024);
						this.describeAColumn(table, 'iscrizione_aa', 'Anno accademico Iscrizione', null, 7100, 9);
						this.describeAColumn(table, 'iscrizione_anno', 'Anno di corso Iscrizione', null, 7300, null);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 7500, null);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 10200, 50);
						this.describeAColumn(table, 'istanzaparent_aa', 'Anno accademico Istanza collegata', null, 11100, 9);
						this.describeAColumn(table, 'istanzaparent_data', 'Data Istanza collegata', 'g', 11300, null);
						this.describeAColumn(table, 'istanzaparent_idistanzakind', 'Tipologia Istanza collegata', null, 11800, null);
						this.describeAColumn(table, 'istanzaparent_idreg_studenti', 'Studente Istanza collegata', null, 11900, null);
						this.describeAColumn(table, 'dichiar_aa', 'Anno Accademico Dichiarazione per la quale esonerare una o più attività', null, 51100, 9);
						this.describeAColumn(table, 'dichiarkind_title', 'Tipologia Tipologia Dichiarazione per la quale esonerare una o più attività', null, 51120, 50);
						this.describeAColumn(table, 'dichiar_date', 'Data Dichiarazione per la quale esonerare una o più attività', null, 51300, null);
						this.describeAColumn(table, 'iscrizionefrom_aa', 'Anno accademico Iscrizione da cui convalidare i sostenimenti', null, 54100, 9);
						this.describeAColumn(table, 'iscrizionefrom_anno', 'Anno di corso Iscrizione da cui convalidare i sostenimenti', null, 54300, null);
						this.describeAColumn(table, 'iscrizionefrom_iddidprog', 'Didattica programmata Iscrizione da cui convalidare i sostenimenti', null, 54500, null);
						this.describeAColumn(table, 'istattitolistudio_titolo', 'Titolo di studio Titolo ISTAT Titolo di studio da cui convalidare i sostenimenti', null, 58120, 1024);
						this.describeAColumn(table, 'titolostudio_aa', 'Anno accademico Titolo di studio da cui convalidare i sostenimenti', null, 58300, 9);
						this.describeAColumn(table, 'titolostudio_voto', 'Voto Titolo di studio da cui convalidare i sostenimenti', null, 58700, null);
						this.describeAColumn(table, 'titolostudio_votosu', 'Su Titolo di studio da cui convalidare i sostenimenti', null, 58800, null);
						this.describeAColumn(table, 'titolostudio_votolode', 'Lode Titolo di studio da cui convalidare i sostenimenti', null, 58900, null);
//$objCalcFieldConfig_abbr_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idistanza", "idistanzakind", "idreg_studenti"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('istanzaabbr_segview', new meta_istanzaabbr_segview('istanzaabbr_segview'));

	}());
