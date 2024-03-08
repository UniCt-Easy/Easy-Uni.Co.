(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sasdgruppodefaultview() {
        MetaData.apply(this, ["sasdgruppodefaultview"]);
        this.name = 'meta_sasdgruppodefaultview';
    }

    meta_sasdgruppodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sasdgruppodefaultview,
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
						this.describeAColumn(table, 'title', 'Gruppo', null, 20, 50);
						this.describeAColumn(table, 'tipoattform_title', 'Denominazione Codice', null, 30, 1);
						this.describeAColumn(table, 'tipoattform_description', 'Descrizione Codice', null, 30, 256);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idsasdgruppo", "idtipoattform"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('sasdgruppodefaultview', new meta_sasdgruppodefaultview('sasdgruppodefaultview'));

	}());
