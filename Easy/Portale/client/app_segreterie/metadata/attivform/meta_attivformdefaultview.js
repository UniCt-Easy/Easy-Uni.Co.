(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_attivformdefaultview() {
        MetaData.apply(this, ["attivformdefaultview"]);
        this.name = 'meta_attivformdefaultview';
    }

    meta_attivformdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_attivformdefaultview,
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
						this.describeAColumn(table, 'didprogcurr_title', 'Curriculum', null, 10, 256);
						this.describeAColumn(table, 'didprogori_title', 'Orientamento', null, 20, 256);
						this.describeAColumn(table, 'didproganno_title', 'Anno di corso', null, 30, 2048);
						this.describeAColumn(table, 'didprogporzanno_title', 'Porzione d\'anno', null, 40, 2048);
						this.describeAColumn(table, 'didproggrupp_title', 'Gruppo opzionale', null, 50, 256);
						this.describeAColumn(table, 'insegn_denominazione', 'Denominazione Insegnamento', null, 60, 256);
						this.describeAColumn(table, 'insegn_codice', 'Codice Insegnamento', null, 60, 50);
						this.describeAColumn(table, 'insegninteg_denominazione', 'Denominazione Integrando', null, 70, 256);
						this.describeAColumn(table, 'insegninteg_codice', 'Codice Integrando', null, 70, 50);
						this.describeAColumn(table, 'attivform_start', 'Dal', null, 80, null);
						this.describeAColumn(table, 'attivform_stop', 'Al', null, 90, null);
						this.describeAColumn(table, 'attivform_tipovalutaz', 'Profitto o Idoneità', null, 100, null);
						this.describeAColumn(table, 'XXcanale', 'Canali', null, 140, null);
						this.describeAColumn(table, 'XXattivformcaratteristica', 'Caratteristiche dell\'attività formativa', null, 150, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "idsede", "iddidprog", "idattivform", "iddidprogori", "idcorsostudio", "iddidproganno", "iddidprogcurr", "iddidprogporzanno"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "didprogcurr_title asc , didprogori_title asc , didproganno_title asc , didprogporzanno_title asc , didproggrupp_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('attivformdefaultview', new meta_attivformdefaultview('attivformdefaultview'));

	}());
