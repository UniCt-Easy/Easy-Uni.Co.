(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_iscrizionedotmasview() {
        MetaData.apply(this, ["iscrizionedotmasview"]);
        this.name = 'meta_iscrizionedotmasview';
    }

    meta_iscrizionedotmasview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_iscrizionedotmasview,
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
					case 'dotmas':
						this.describeAColumn(table, 'iscrizione_data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'registry_title', 'Studente', null, 60, 101);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 70, 50);
//$objCalcFieldConfig_dotmas$
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
					case "dotmas": {
						return "registry_title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('iscrizionedotmasview', new meta_iscrizionedotmasview('iscrizionedotmasview'));

	}());
