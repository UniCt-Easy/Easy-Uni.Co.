(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_getcostididatticadefaultview() {
        MetaData.apply(this, ["getcostididatticadefaultview"]);
        this.name = 'meta_getcostididatticadefaultview';
    }

    meta_getcostididatticadefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getcostididatticadefaultview,
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
						this.describeAColumn(table, 'getcostididattica_corsostudio', 'Corso di studio', null, 1000, 1024);
						this.describeAColumn(table, 'getcostididattica_sede', 'Sede', null, 2000, 1024);
						this.describeAColumn(table, 'aa', 'AA erogata', null, 3000, 9);
						this.describeAColumn(table, 'aaprogrammata', 'AA programmata', null, 4000, 9);
						this.describeAColumn(table, 'getcostididattica_curriculum', 'Curriculum', null, 5000, 256);
						this.describeAColumn(table, 'getcostididattica_insegnamento', 'Insegnamento', null, 6000, 256);
						this.describeAColumn(table, 'getcostididattica_modulo', 'Modulo', null, 7000, 256);
						this.describeAColumn(table, 'getcostididattica_affidamento', 'Affidamento', null, 8000, 1075);
						this.describeAColumn(table, 'getcostididattica_docente', 'Docente', null, 9000, 101);
						this.describeAColumn(table, 'getcostididattica_ruolo', 'Ruolo', null, 10000, 50);
						this.describeAColumn(table, 'getcostididattica_costoorariodacontratto', 'Costo orario da ruolo', null, 11000, 2);
						this.describeAColumn(table, 'getcostididattica_costo', 'Costo', 'fixed.2', 12000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "idsede", "iddidprog", "idaffidamento", "idcorsostudio", "iddidprogcurr", "idposition"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "getcostididattica_corsostudio asc , getcostididattica_sede asc , aa asc , aaprogrammata asc , getcostididattica_curriculum asc , getcostididattica_insegnamento asc , getcostididattica_modulo asc , getcostididattica_affidamento asc , getcostididattica_docente asc , getcostididattica_ruolo asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('getcostididatticadefaultview', new meta_getcostididatticadefaultview('getcostididatticadefaultview'));

	}());
