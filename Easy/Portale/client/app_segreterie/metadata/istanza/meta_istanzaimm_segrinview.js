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
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede', null, 190, 1024);
						this.describeAColumn(table, 'sede_idsede', 'Sede Sede', null, 190, null);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'registrystudenti_title', 'Studente', null, 20, 101);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 80, 50);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 510, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 510, 9);
						this.describeAColumn(table, 'istanza_protnumero', 'Numero di protocollo', null, 610, null);
						this.describeAColumn(table, 'istanza_protanno', 'Anno di protocollo', null, 620, null);
						this.describeAColumn(table, 'didprogcurr_title', 'Curriculum', null, 520, 256);
						this.describeAColumn(table, 'didprogori_title', 'Corso e orientamento', null, 530, 256);
						this.describeAColumn(table, 'istanza_imm_parttime', 'Iscrizione Part-Time', null, 570, null);
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
