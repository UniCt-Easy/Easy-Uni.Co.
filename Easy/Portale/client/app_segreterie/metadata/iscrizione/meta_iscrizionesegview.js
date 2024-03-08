(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_iscrizionesegview() {
        MetaData.apply(this, ["iscrizionesegview"]);
        this.name = 'meta_iscrizionesegview';
    }

    meta_iscrizionesegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_iscrizionesegview,
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
					case 'seg':
						this.describeAColumn(table, 'annoaccademico_aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 190, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'iscrizione_data', 'Data', 'g', 40, null);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 50, 1024);
						this.describeAColumn(table, 'registry_title', 'Studente', null, 60, 101);
						this.describeAColumn(table, 'iscrizione_matricola', 'Matricola', null, 70, 50);
//$objCalcFieldConfig_seg$
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
					case "seg": {
						return "didprog_title desc, registry_title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('iscrizionesegview', new meta_iscrizionesegview('iscrizionesegview'));

	}());
