(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_affidamentosegview() {
        MetaData.apply(this, ["affidamentosegview"]);
        this.name = 'meta_affidamentosegview';
    }

    meta_affidamentosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_affidamentosegview,
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
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 1000, 9);
						this.describeAColumn(table, 'affidamento_jsonancestor', 'Didattica', null, 1000, -1);
						this.describeAColumn(table, 'affidamentokind_title', 'Tipologia', null, 2200, 50);
						this.describeAColumn(table, 'affidamento_riferimento', 'Docente di riferimento per il canale', null, 3000, null);
						this.describeAColumn(table, 'erogazkind_title', 'Tipo di erogazione', null, 4200, 50);
						this.describeAColumn(table, 'affidamento_freqobbl', 'Frequenza obbligatoria', null, 5000, null);
						this.describeAColumn(table, 'affidamento_gratuito', 'Gratuito', null, 6000, null);
						this.describeAColumn(table, 'affidamento_start', 'Inizio', null, 15000, null);
						this.describeAColumn(table, 'affidamento_stop', 'Fine', null, 16000, null);
						this.describeAColumn(table, 'XXaffidamentocaratteristica', 'Caratteristiche dell\'affidamento', null, 20000, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "idcanale", "iddidprog", "idattivform", "iddidprogori", "idaffidamento", "idcorsostudio", "iddidproganno", "iddidprogcurr", "idreg_docenti", "iddidprogporzanno"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "affidamento_riferimento asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('affidamentosegview', new meta_affidamentosegview('affidamentosegview'));

	}());
