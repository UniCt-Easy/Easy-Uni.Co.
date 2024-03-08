(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_ambitoareadiscdefaultview() {
        MetaData.apply(this, ["ambitoareadiscdefaultview"]);
        this.name = 'meta_ambitoareadiscdefaultview';
    }

    meta_ambitoareadiscdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_ambitoareadiscdefaultview,
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
						this.describeAColumn(table, 'title', 'Ambito', null, 20, 256);
						this.describeAColumn(table, 'classescuola_sigla', 'Sigla Scuola / Classe di laurea', null, 30, 50);
						this.describeAColumn(table, 'classescuola_title', 'Denominazione Scuola / Classe di laurea', null, 30, 256);
						this.describeAColumn(table, 'tipoattform_title', 'Denominazione Tipo attività formativa', null, 40, 1);
						this.describeAColumn(table, 'tipoattform_description', 'Descrizione Tipo attività formativa', null, 40, 256);
						this.describeAColumn(table, 'ambitoareadisc_sortcode', 'Ordinamento', null, 60, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idambitoareadisc"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "classescuola_sigla desc, classescuola_title desc, tipoattform_title desc, tipoattform_description desc, ambitoareadisc_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('ambitoareadiscdefaultview', new meta_ambitoareadiscdefaultview('ambitoareadiscdefaultview'));

	}());
