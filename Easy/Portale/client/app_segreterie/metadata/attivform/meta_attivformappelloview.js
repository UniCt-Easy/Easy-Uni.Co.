(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_attivformappelloview() {
        MetaData.apply(this, ["attivformappelloview"]);
        this.name = 'meta_attivformappelloview';
    }

    meta_attivformappelloview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_attivformappelloview,
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
					case 'appello':
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 50, 1024);
						this.describeAColumn(table, 'insegn_denominazione', 'Denominazione Insegnamento', null, 110, 256);
						this.describeAColumn(table, 'insegn_codice', 'Codice Insegnamento', null, 110, 50);
						this.describeAColumn(table, 'insegninteg_denominazione', 'Denominazione Integrando', null, 120, 256);
						this.describeAColumn(table, 'insegninteg_codice', 'Codice Integrando', null, 120, 50);
						this.describeAColumn(table, 'attivform_tipovalutaz', 'Profitto o Idoneità', null, 180, null);
						this.describeAColumn(table, 'sede_attivform_title', 'Sede', null, 230, 1024);
						this.describeAColumn(table, 'annoaccademico_aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 190, 1024);
//$objCalcFieldConfig_appello$
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
					case "appello": {
						return "";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('attivformappelloview', new meta_attivformappelloview('attivformappelloview'));

	}());
