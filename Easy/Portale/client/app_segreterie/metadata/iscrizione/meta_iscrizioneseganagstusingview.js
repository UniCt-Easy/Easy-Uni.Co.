(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_iscrizioneseganagstusingview() {
        MetaData.apply(this, ["iscrizioneseganagstusingview"]);
        this.name = 'meta_iscrizioneseganagstusingview';
    }

    meta_iscrizioneseganagstusingview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_iscrizioneseganagstusingview,
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
					case 'seganagstusing':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'iscrizione_data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'iscrizione_matricola', 'Matricola', null, 70, 50);
//$objCalcFieldConfig_seganagstusing$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idiscrizione"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seganagstusing": {
						return "iscrizione_data desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('iscrizioneseganagstusingview', new meta_iscrizioneseganagstusingview('iscrizioneseganagstusingview'));

	}());
