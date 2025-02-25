(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_iscrizioneseganagstuview() {
        MetaData.apply(this, ["iscrizioneseganagstuview"]);
        this.name = 'meta_iscrizioneseganagstuview';
    }

    meta_iscrizioneseganagstuview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_iscrizioneseganagstuview,
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
					case 'seganagstu':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 1000, 9);
						this.describeAColumn(table, 'iscrizione_data', 'Data', 'g', 4000, null);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 5100, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 5200, 9);
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede Didattica programmata', null, 6920, 1024);
						this.describeAColumn(table, 'iscrizione_matricola', 'Matricola', null, 7000, 50);
//$objCalcFieldConfig_seganagstu$
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
					case "seganagstu": {
						return "iscrizione_data desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('iscrizioneseganagstuview', new meta_iscrizioneseganagstuview('iscrizioneseganagstuview'));

	}());
