(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_affidamentodocview() {
        MetaData.apply(this, ["affidamentodocview"]);
        this.name = 'meta_affidamentodocview';
    }

    meta_affidamentodocview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_affidamentodocview,
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
					case 'doc':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'affidamento_jsonancestor', 'Didattica', null, 10, -1);
						this.describeAColumn(table, 'affidamentokind_title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'affidamento_riferimento', 'Docente di riferimento per il canale', null, 30, null);
						this.describeAColumn(table, 'erogazkind_title', 'Tipo di erogazione', null, 40, 50);
						this.describeAColumn(table, 'affidamento_freqobbl', 'Frequenza obbligatoria', null, 50, null);
						this.describeAColumn(table, 'affidamento_gratuito', 'Gratuito', null, 60, null);
						this.describeAColumn(table, 'affidamento_start', 'Inizio', null, 150, null);
						this.describeAColumn(table, 'affidamento_stop', 'Fine', null, 160, null);
//$objCalcFieldConfig_doc$
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
					case "doc": {
						return "affidamento_riferimento asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('affidamentodocview', new meta_affidamentodocview('affidamentodocview'));

	}());
