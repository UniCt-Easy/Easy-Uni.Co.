(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettokindsegview() {
        MetaData.apply(this, ["progettokindsegview"]);
        this.name = 'meta_progettokindsegview';
    }

    meta_progettokindsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettokindsegview,
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
						this.describeAColumn(table, 'progettoactivitykind_title', 'Tipologia', null, 1200, 2048);
						this.describeAColumn(table, 'title', 'Titolo', null, 2000, 2048);
						this.describeAColumn(table, 'progettokind_oredivisionecostostipendio', 'Numero ore lavorate in un anno dal personale', null, 3000, null);
						this.describeAColumn(table, 'progettokind_stipendioannoprec', 'Usa stipendi anno precedente', null, 8000, null);
						this.describeAColumn(table, 'progettokind_stipendiocomericavo', 'Usa stipendi come ricavi', null, 9000, null);
						this.describeAColumn(table, 'progettokind_active', 'Attivo', null, 10000, null);
						this.describeAColumn(table, 'progettokind_irap', 'Includi l\'IRAP nei costi del personale', null, 11000, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idprogettokind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "progettoactivitykind_title asc , title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettokindsegview', new meta_progettokindsegview('progettokindsegview'));

	}());
