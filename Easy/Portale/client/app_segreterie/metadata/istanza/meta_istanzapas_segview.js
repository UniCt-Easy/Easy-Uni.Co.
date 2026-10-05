(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanzapas_segview() {
        MetaData.apply(this, ["istanzapas_segview"]);
        this.name = 'meta_istanzapas_segview';
    }

    meta_istanzapas_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzapas_segview,
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
					case 'pas_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 1000, 9);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 2000, null);
						this.describeAColumn(table, 'registrystudenti_title', 'Studente', null, 3300, 101);
						this.describeAColumn(table, 'iscrizionefrom_aa', 'Anno accademico Iscrizione di partenza', null, 4100, 9);
						this.describeAColumn(table, 'iscrizionefrom_iddidprog', 'Didattica programmata Iscrizione di partenza', null, 4500, null);
						this.describeAColumn(table, 'iscrizione_aa', 'Anno accademico Iscrizione', null, 5100, 9);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 5500, null);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 10200, 50);
						this.describeAColumn(table, 'istanzaparent_idreg_studenti', 'Studente Istanza collegata', null, 11200, null);
						this.describeAColumn(table, 'istanzaparent_data', 'Data Istanza collegata', 'g', 11300, null);
						this.describeAColumn(table, 'statuskind_istanza_title', 'Stato Status Istanza collegata', null, 11820, 50);
//$objCalcFieldConfig_pas_seg$
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

    window.appMeta.addMeta('istanzapas_segview', new meta_istanzapas_segview('istanzapas_segview'));

	}());
