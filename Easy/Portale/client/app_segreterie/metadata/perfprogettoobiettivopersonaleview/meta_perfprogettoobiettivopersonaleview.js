(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettoobiettivopersonaleview() {
        MetaData.apply(this, ["perfprogettoobiettivopersonaleview"]);
        this.name = 'meta_perfprogettoobiettivopersonaleview';
    }

    meta_perfprogettoobiettivopersonaleview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettoobiettivopersonaleview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'progetto_title', 'Progetto', null, 10, 1024);
						this.describeAColumn(table, 'perfprogetto_struttura_title', 'Struttura del progetto', null, 20, 1024);
						this.describeAColumn(table, 'title', 'Titolo', null, 40, 1024);
						this.describeAColumn(table, 'description', 'Descrizione', null, 50, -1);
						this.describeAColumn(table, 'peso', 'Peso per il progetto', 'fixed.2', 60, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 80, null);
						this.describeAColumn(table, '!perfprogettoobiettivosoglia_alias1', 'Soglie dell\'obiettivo', null, 70, null);
						this.describeAColumn(table, '!perfprogettosoglia_alias1', 'Soglie del progetto', null, 30, null);
						this.describeAColumn(table, '!perfprogettoobiettivosoglia', 'Soglie dell\'obiettivo', null, 70, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["description"].caption = "Descrizione";
						table.columns["idperfvalutazioneuo"].caption = "Valutazione";
						table.columns["idstruttura"].caption = "Struttura della valutazione";
						table.columns["idstruttura_perfprogetto"].caption = "Struttura del progetto";
						table.columns["peso"].caption = "Peso per il progetto";
						table.columns["progetto_title"].caption = "Progetto";
						table.columns["title"].caption = "Titolo";
						table.columns["perfprogetto_struttura_title"].caption = "Struttura del progetto";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			primaryKey: function () {
				return ["idstruttura", "idperfprogetto", "idperfvalutazioneuo", "idperfprogettoobiettivo"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					case "default": {
						return "idstruttura_perfprogetto desc, title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettoobiettivopersonaleview', new meta_perfprogettoobiettivopersonaleview('perfprogettoobiettivopersonaleview'));

	}());
