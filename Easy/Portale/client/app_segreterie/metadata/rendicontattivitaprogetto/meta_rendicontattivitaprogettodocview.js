(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_rendicontattivitaprogettodocview() {
        MetaData.apply(this, ["rendicontattivitaprogettodocview"]);
        this.name = 'meta_rendicontattivitaprogettodocview';
    }

    meta_rendicontattivitaprogettodocview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontattivitaprogettodocview,
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
						this.describeAColumn(table, 'progetto_titolobreve', 'Progetto', null, 10, 2048);
						this.describeAColumn(table, 'workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 20, 2048);
						this.describeAColumn(table, 'workpackage_title', 'Titolo Workpackage', null, 20, 2048);
						this.describeAColumn(table, 'rendicontattivitaprogetto_description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'rendicontattivitaprogetto_orepreventivate', 'Numero di ore preventivate', null, 70, null);
						this.describeAColumn(table, 'rendicontattivitaprogetto_datainizioprevista', 'Data inizio prevista', null, 110, null);
						this.describeAColumn(table, 'rendicontattivitaprogetto_stop', 'Data fine prevista', null, 120, null);
//$objCalcFieldConfig_doc$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idrendicontattivitaprogetto"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "doc": {
						return "rendicontattivitaprogetto_datainizioprevista asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('rendicontattivitaprogettodocview', new meta_rendicontattivitaprogettodocview('rendicontattivitaprogettodocview'));

	}());
