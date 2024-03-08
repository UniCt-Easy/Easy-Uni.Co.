(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_iscrizionedidprogview() {
        MetaData.apply(this, ["iscrizionedidprogview"]);
        this.name = 'meta_iscrizionedidprogview';
    }

    meta_iscrizionedidprogview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_iscrizionedidprogview,
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
					case 'didprog':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'iscrizione_data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'registry_title', 'Studente', null, 60, 101);
						this.describeAColumn(table, 'iscrizione_matricola', 'Matricola', null, 70, 50);
//$objCalcFieldConfig_didprog$
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
					case "didprog": {
						return "registry_title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('iscrizionedidprogview', new meta_iscrizionedidprogview('iscrizionedidprogview'));

	}());
