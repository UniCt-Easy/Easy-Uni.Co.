(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanzaseganagstusonpreview() {
        MetaData.apply(this, ["istanzaseganagstusonpreview"]);
        this.name = 'meta_istanzaseganagstusonpreview';
    }

    meta_istanzaseganagstusonpreview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzaseganagstusonpreview,
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
					case 'seganagstusonpre':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 30, null);
						this.describeAColumn(table, 'istanzakind_title', 'Tipologia', null, 60, 50);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 80, 50);
						this.describeAColumn(table, 'istanza_protanno', 'Anno di protocollo', null, 100, null);
						this.describeAColumn(table, 'istanza_protnumero', 'Numero di protocollo', null, 110, null);
//$objCalcFieldConfig_seganagstusonpre$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddidprog", "idistanza", "paridistanza", "idcorsostudio", "idistanzakind", "idreg_studenti"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('istanzaseganagstusonpreview', new meta_istanzaseganagstusonpreview('istanzaseganagstusonpreview'));

	}());
