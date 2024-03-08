(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_strutturaseg_childview() {
        MetaData.apply(this, ["strutturaseg_childview"]);
        this.name = 'meta_strutturaseg_childview';
    }

    meta_strutturaseg_childview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_strutturaseg_childview,
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
						this.describeAColumn(table, 'strutturakind_title', 'Tipo', null, 1200, 50);
						this.describeAColumn(table, 'struttura_title', 'Denominazione', null, 2000, 1024);
						this.describeAColumn(table, 'struttura_title_en', 'Denominazione (ENG)', null, 3000, 1024);
						this.describeAColumn(table, 'struttura_codice', 'Codice', null, 4000, 50);
						this.describeAColumn(table, 'struttura_email', 'E-Mail', null, 5000, 200);
						this.describeAColumn(table, 'struttura_fax', 'Fax', null, 6000, 50);
						this.describeAColumn(table, 'struttura_telefono', 'Telefono', null, 7000, 50);
						this.describeAColumn(table, 'strutturaparent_title', 'Denominazione Struttura madre', null, 9100, 1024);
						this.describeAColumn(table, 'strutturakind_struttura_title', 'Tipologia Tipo Struttura madre', null, 9220, 50);
						this.describeAColumn(table, 'struttura_active', 'Attivo', null, 16000, null);
//$objCalcFieldConfig_seg_child$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idstruttura"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg_child": {
						return "struttura_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('strutturaseg_childview', new meta_strutturaseg_childview('strutturaseg_childview'));

	}());
