(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_strutturadefaultview() {
        MetaData.apply(this, ["strutturadefaultview"]);
        this.name = 'meta_strutturadefaultview';
    }

    meta_strutturadefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_strutturadefaultview,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 1000, 1024);
						this.describeAColumn(table, 'strutturakind_title', 'Tipo', null, 2200, 50);
						this.describeAColumn(table, 'struttura_codice', 'Codice', null, 3000, 50);
						this.describeAColumn(table, 'strutturaparent_title', 'Denominazione Struttura madre', null, 9100, 1024);
						this.describeAColumn(table, 'strutturakind_struttura_title', 'Tipologia Tipo Struttura madre', null, 9220, 50);
						this.describeAColumn(table, 'struttura_active', 'Attivo', null, 16000, null);
//$objCalcFieldConfig_default$
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
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('strutturadefaultview', new meta_strutturadefaultview('strutturadefaultview'));

	}());
