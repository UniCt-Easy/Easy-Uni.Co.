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
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede', null, 190, 1024);
						this.describeAColumn(table, 'sede_idsede', 'Sede Sede', null, 190, null);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'corsostudio_title', 'Denominazione Corso di studi', null, 50, 1024);
						this.describeAColumn(table, 'corsostudio_annoistituz', 'Anno accademico di istituzione Corso di studi', null, 50, null);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 60, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 60, 9);
						this.describeAColumn(table, 'iscrizione_anno', 'Anno di corso Iscrizione', null, 70, null);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 70, null);
						this.describeAColumn(table, 'iscrizione_aa', 'Anno accademico Iscrizione', null, 70, 9);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 100, 50);
						this.describeAColumn(table, 'istanzaparent_idistanzakind', 'Tipologia Istanza collegata', null, 110, null);
						this.describeAColumn(table, 'istanzaparent_idreg_studenti', 'Studente Istanza collegata', null, 110, null);
						this.describeAColumn(table, 'istanzaparent_aa', 'Anno accademico Istanza collegata', null, 110, 9);
						this.describeAColumn(table, 'istanzaparent_data', 'Data Istanza collegata', 'g', 110, null);
						this.describeAColumn(table, 'iscrizione_istanza_pas_anno', 'Anno di corso Iscrizione di partenza', null, 540, null);
						this.describeAColumn(table, 'iscrizione_istanza_pas_iddidprog', 'Didattica programmata Iscrizione di partenza', null, 540, null);
						this.describeAColumn(table, 'iscrizione_istanza_pas_aa', 'Anno accademico Iscrizione di partenza', null, 540, 9);
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
