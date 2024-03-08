(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_appellosegview() {
        MetaData.apply(this, ["appellosegview"]);
        this.name = 'meta_appellosegview';
    }

    meta_appellosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_appellosegview,
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
						this.describeAColumn(table, 'description', 'Descrizione', null, 10, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'appelloazionekind_title', 'Ordinario/Correttivo/Integrativo', null, 80, 50);
						this.describeAColumn(table, 'appellokind_title', 'Tipologia', null, 90, 50);
						this.describeAColumn(table, 'sessione_start', 'Data di inizio Sessione', null, 100, null);
						this.describeAColumn(table, 'sessione_stop', 'Data di fine Sessione', null, 100, null);
						this.describeAColumn(table, 'sessionekind_title', 'Tipologia Tipologia', null, 30, 50);
						this.describeAColumn(table, 'sessionekind_idsessionekind', 'Tipologia Tipologia', null, 30, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idappello"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('appellosegview', new meta_appellosegview('appellosegview'));

	}());
