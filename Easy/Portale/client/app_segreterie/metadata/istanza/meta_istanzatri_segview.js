(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanzatri_segview() {
        MetaData.apply(this, ["istanzatri_segview"]);
        this.name = 'meta_istanzatri_segview';
    }

    meta_istanzatri_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzatri_segview,
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
					case 'tri_seg':
						this.describeAColumn(table, 'registrystudenti_title', 'Studente', null, 1300, 101);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 2000, 9);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 3000, null);
						this.describeAColumn(table, 'iscrizione_aa', 'Anno accademico Iscrizione', null, 7100, 9);
						this.describeAColumn(table, 'iscrizione_anno', 'Anno di corso Iscrizione', null, 7300, null);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 7500, null);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 10200, 50);
						this.describeAColumn(table, 'istanzaparent_aa', 'Anno accademico Istanza collegata', null, 11100, 9);
						this.describeAColumn(table, 'istanzaparent_data', 'Data Istanza collegata', 'g', 11300, null);
						this.describeAColumn(table, 'istanzaparent_idistanzakind', 'Tipologia Istanza collegata', null, 11800, null);
						this.describeAColumn(table, 'istanzaparent_idreg_studenti', 'Studente Istanza collegata', null, 11900, null);
						this.describeAColumn(table, 'aaprimaiscr', 'Anno accademico di prima iscrizione', null, 51000, 9);
						this.describeAColumn(table, 'registryistituti_title', 'Istituto di provenienza', null, 58300, 101);
						this.describeAColumn(table, 'dichiartitolo_aa', 'Dichiarazione di titolo di studio in corso', null, 215100, 9);
						this.describeAColumn(table, 'dichiartitolo_date', 'Dichiarazione di titolo di studio in corso', null, 215300, null);
						this.describeAColumn(table, 'dichiartitolo_idreg', 'Dichiarazione di titolo di studio in corso', null, 215400, null);
//$objCalcFieldConfig_tri_seg$
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

    window.appMeta.addMeta('istanzatri_segview', new meta_istanzatri_segview('istanzatri_segview'));

	}());
