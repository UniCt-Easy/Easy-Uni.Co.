(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanzaimm_segrinview() {
        MetaData.apply(this, ["istanzaimm_segrinview"]);
        this.name = 'meta_istanzaimm_segrinview';
    }

    meta_istanzaimm_segrinview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzaimm_segrinview,
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
					case 'imm_segrin':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 1000, 9);
						this.describeAColumn(table, 'registrystudenti_title', 'Studente', null, 2300, 101);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 3000, null);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 8200, 50);
						this.describeAColumn(table, 'didprogcurr_title', 'Curriculum', null, 52200, 256);
						this.describeAColumn(table, 'didprogori_title', 'Corso e orientamento', null, 53200, 256);
						this.describeAColumn(table, 'iscrizione_aa', 'Anno accademico Iscrizione', null, 55100, 9);
						this.describeAColumn(table, 'iscrizione_anno', 'Anno di corso Iscrizione', null, 55300, null);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 55500, null);
						this.describeAColumn(table, 'istanza_imm_parttime', 'Iscrizione Part-Time', null, 57000, null);
						this.describeAColumn(table, 'istanza_protnumero', 'Numero di protocollo', null, 61000, null);
						this.describeAColumn(table, 'istanza_protanno', 'Anno di protocollo', null, 62000, null);
//$objCalcFieldConfig_imm_segrin$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddidprog", "idistanza", "idcorsostudio", "idistanzakind", "idreg_studenti"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('istanzaimm_segrinview', new meta_istanzaimm_segrinview('istanzaimm_segrinview'));

	}());
