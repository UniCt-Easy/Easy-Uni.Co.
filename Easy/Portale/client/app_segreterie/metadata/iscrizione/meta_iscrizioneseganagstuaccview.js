(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_iscrizioneseganagstuaccview() {
        MetaData.apply(this, ["iscrizioneseganagstuaccview"]);
        this.name = 'meta_iscrizioneseganagstuaccview';
    }

    meta_iscrizioneseganagstuaccview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_iscrizioneseganagstuaccview,
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
					case 'seganagstuacc':
						this.describeAColumn(table, 'annoaccademico_aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 190, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'iscrizione_data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Prova di accesso', null, 50, 1024);
						this.describeAColumn(table, 'iscrizione_matricola', 'Matricola', null, 70, 50);
//$objCalcFieldConfig_seganagstuacc$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddidprog", "idiscrizione", "idcorsostudio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seganagstuacc": {
						return "iscrizione_data desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('iscrizioneseganagstuaccview', new meta_iscrizioneseganagstuaccview('iscrizioneseganagstuaccview'));

	}());
