(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_strutturaprincview() {
        MetaData.apply(this, ["strutturaprincview"]);
        this.name = 'meta_strutturaprincview';
    }

    meta_strutturaprincview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_strutturaprincview,
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
					case 'princ':
						this.describeAColumn(table, 'title', 'Denominazione', null, 2000, 1024);
						this.describeAColumn(table, 'struttura_codice', 'Codice', null, 3000, 50);
						this.describeAColumn(table, 'struttura_codiceipa', 'Codice IPA', null, 4000, null);
						this.describeAColumn(table, 'struttura_email', 'E-Mail', null, 5000, 200);
						this.describeAColumn(table, 'struttura_fax', 'Fax', null, 6000, 50);
						this.describeAColumn(table, 'aoo_title', 'AOO', null, 7200, 1024);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 8200, 1024);
						this.describeAColumn(table, 'strutturakind_title', 'Tipo', null, 9200, 50);
						this.describeAColumn(table, 'upb_title', 'UPB', null, 10200, 150);
						this.describeAColumn(table, 'struttura_telefono', 'Telefono', null, 11000, 50);
						this.describeAColumn(table, 'struttura_title_en', 'Denominazione (ENG)', null, 12000, 1024);
						this.describeAColumn(table, 'struttura_active', 'Attivo', null, 25000, null);
//$objCalcFieldConfig_princ$
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
					case "princ": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('strutturaprincview', new meta_strutturaprincview('strutturaprincview'));

	}());
