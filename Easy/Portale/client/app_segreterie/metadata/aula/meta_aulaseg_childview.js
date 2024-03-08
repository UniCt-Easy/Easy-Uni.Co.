(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_aulaseg_childview() {
        MetaData.apply(this, ["aulaseg_childview"]);
        this.name = 'meta_aulaseg_childview';
    }

    meta_aulaseg_childview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_aulaseg_childview,
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
					case 'seg_child':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'aula_code', 'Codice', null, 20, 128);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Struttura didattica di afferenza', null, 40, 1024);
						this.describeAColumn(table, 'aula_capienza', 'Capienza', null, 50, null);
						this.describeAColumn(table, 'aula_capienzadis', 'Capienza disabili', null, 60, null);
						this.describeAColumn(table, 'aulakind_title', 'Tipologia', null, 70, 50);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo', null, 20, 50);
						this.describeAColumn(table, 'struttura_idstrutturakind', 'Tipo Tipo', null, 20, null);
//$objCalcFieldConfig_seg_child$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idaula", "idsede", "idedificio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg_child": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('aulaseg_childview', new meta_aulaseg_childview('aulaseg_childview'));

	}());
