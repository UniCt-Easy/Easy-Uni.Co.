(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanzapas_seganagstuview() {
        MetaData.apply(this, ["istanzapas_seganagstuview"]);
        this.name = 'meta_istanzapas_seganagstuview';
    }

    meta_istanzapas_seganagstuview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzapas_seganagstuview,
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
					case 'pas_seganagstu':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 80, 50);
						this.describeAColumn(table, 'istanza_protnumero', 'Numero di protocollo', null, 100, null);
						this.describeAColumn(table, 'istanza_protanno', 'Anno di protocollo', null, 110, null);
						this.describeAColumn(table, 'iscrizionefrom_anno', 'Anno di corso Iscrizione di partenza', null, 510, null);
						this.describeAColumn(table, 'iscrizionefrom_iddidprog', 'Didattica programmata Iscrizione di partenza', null, 510, null);
						this.describeAColumn(table, 'iscrizionefrom_aa', 'Anno accademico Iscrizione di partenza', null, 510, 9);
//$objCalcFieldConfig_pas_seganagstu$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddidprog", "idistanza", "idiscrizione", "idcorsostudio", "idistanzakind", "idreg_studenti"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('istanzapas_seganagstuview', new meta_istanzapas_seganagstuview('istanzapas_seganagstuview'));

	}());
