(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanzaimm_seganagstupreview() {
        MetaData.apply(this, ["istanzaimm_seganagstupreview"]);
        this.name = 'meta_istanzaimm_seganagstupreview';
    }

    meta_istanzaimm_seganagstupreview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzaimm_seganagstupreview,
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
					case 'imm_seganagstupre':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 1000, 9);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 2100, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 2200, 9);
						this.describeAColumn(table, 'didprogcurr_title', 'Curriculum', null, 2200, 256);
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede Didattica programmata', null, 2320, 1024);
						this.describeAColumn(table, 'data', 'Data', 'g', 3000, null);
						this.describeAColumn(table, 'didprogori_title', 'Corso e orientamento', null, 3200, 256);
						this.describeAColumn(table, 'istanza_imm_parttime', 'Iscrizione Part-Time', null, 5000, null);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 8200, 50);
						this.describeAColumn(table, 'istanza_protnumero', 'Numero di protocollo', null, 10000, null);
						this.describeAColumn(table, 'istanza_protanno', 'Anno di protocollo', null, 11000, null);
//$objCalcFieldConfig_imm_seganagstupre$
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

    window.appMeta.addMeta('istanzaimm_seganagstupreview', new meta_istanzaimm_seganagstupreview('istanzaimm_seganagstupreview'));

	}());
