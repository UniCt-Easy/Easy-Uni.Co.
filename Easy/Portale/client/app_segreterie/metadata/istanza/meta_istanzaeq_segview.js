(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanzaeq_segview() {
        MetaData.apply(this, ["istanzaeq_segview"]);
        this.name = 'meta_istanzaeq_segview';
    }

    meta_istanzaeq_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzaeq_segview,
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
					case 'eq_seg':
						this.describeAColumn(table, 'registrystudenti_title', 'Studente', null, 1300, 101);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 2000, 9);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 3000, null);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica equipollente', null, 6100, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica equipollente', null, 6200, 9);
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede Didattica equipollente', null, 6320, 1024);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 10200, 50);
						this.describeAColumn(table, 'istanza_protanno', 'Anno di protocollo', null, 12000, null);
						this.describeAColumn(table, 'istanza_protnumero', 'Numero di protocollo', null, 13000, null);
						this.describeAColumn(table, 'dichiartitolo_seg_aa', 'Dichiarazione del titolo di studio', null, 109100, 9);
						this.describeAColumn(table, 'dichiartitolo_seg_date', 'Dichiarazione del titolo di studio', null, 109300, null);
						this.describeAColumn(table, 'dichiartitolo_seg_iddichiarkind', 'Dichiarazione del titolo di studio', null, 109500, null);
						this.describeAColumn(table, 'dichiartitolo_seg_idreg', 'Dichiarazione del titolo di studio', null, 109600, null);
//$objCalcFieldConfig_eq_seg$
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

    window.appMeta.addMeta('istanzaeq_segview', new meta_istanzaeq_segview('istanzaeq_segview'));

	}());
