(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_affidamentodefaultview() {
        MetaData.apply(this, ["affidamentodefaultview"]);
        this.name = 'meta_affidamentodefaultview';
    }

    meta_affidamentodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_affidamentodefaultview,
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
					case 'default':
						this.describeAColumn(table, 'registrydocenti_title', 'Docente', null, 1300, 101);
						this.describeAColumn(table, 'affidamentokind_title', 'Tipologia', null, 2200, 50);
						this.describeAColumn(table, 'affidamento_riferimento', 'Docente di riferimento per il canale', null, 3000, null);
						this.describeAColumn(table, 'erogazkind_title', 'Tipo di erogazione', null, 4200, 50);
						this.describeAColumn(table, 'affidamento_freqobbl', 'Frequenza obbligatoria', null, 5000, null);
						this.describeAColumn(table, 'affidamento_gratuito', 'Gratuito', null, 6000, null);
						this.describeAColumn(table, 'affidamento_start', 'Inizio', null, 7000, null);
						this.describeAColumn(table, 'affidamento_stop', 'Fine', null, 8000, null);
						this.describeAColumn(table, 'XXaffidamentocaratteristica', 'Caratteristiche dell\'affidamento', null, 9000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "idcanale", "iddidprog", "idattivform", "iddidprogori", "idaffidamento", "idcorsostudio", "iddidproganno", "iddidprogcurr", "iddidprogporzanno"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "affidamento_riferimento asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('affidamentodefaultview', new meta_affidamentodefaultview('affidamentodefaultview'));

	}());
