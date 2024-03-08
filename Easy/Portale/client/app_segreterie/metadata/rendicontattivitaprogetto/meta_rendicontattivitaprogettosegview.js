(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_rendicontattivitaprogettosegview() {
        MetaData.apply(this, ["rendicontattivitaprogettosegview"]);
        this.name = 'meta_rendicontattivitaprogettosegview';
    }

    meta_rendicontattivitaprogettosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontattivitaprogettosegview,
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
						this.describeAColumn(table, 'registry_title', 'Partecipante', null, 1300, 101);
						this.describeAColumn(table, 'description', 'Descrizione', null, 3000, -1);
						this.describeAColumn(table, 'rendicontattivitaprogetto_orepreventivate', 'Numero di ore preventivate', null, 7000, null);
						this.describeAColumn(table, 'rendicontattivitaprogetto_datainizioprevista', 'Data inizio prevista', null, 11000, null);
						this.describeAColumn(table, 'rendicontattivitaprogetto_stop', 'Data fine prevista', null, 12000, null);
						this.describeAColumn(table, 'rendicontattivitaprogettokind_title', 'Tipo di attività', null, 13200, 255);
//$objCalcFieldConfig_seg$
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
					case "seg": {
						return "rendicontattivitaprogetto_datainizioprevista asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('rendicontattivitaprogettosegview', new meta_rendicontattivitaprogettosegview('rendicontattivitaprogettosegview'));

	}());
