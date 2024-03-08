(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettoobiettivouoview() {
        MetaData.apply(this, ["perfprogettoobiettivouoview"]);
        this.name = 'meta_perfprogettoobiettivouoview';
    }

    meta_perfprogettoobiettivouoview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettoobiettivouoview,
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
						this.describeAColumn(table, 'progetto_title', 'Progetto', null, 10, 1024);
						this.describeAColumn(table, 'title', 'Titolo', null, 30, 1024);
						this.describeAColumn(table, 'description', 'Descrizione', null, 40, -1);
						this.describeAColumn(table, 'peso', 'Peso per il progetto', 'fixed.2', 50, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 60, null);
						this.describeAColumn(table, '!perfprogettoobiettivosoglia', 'Soglie dell\'obiettivo', null, 50, null);
						this.describeAColumn(table, '!perfprogettosoglia', 'Soglie del progetto', null, 20, null);
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
						table.columns["peso"].caption = "Peso per il progetto";
						table.columns["progetto_title"].caption = "Progetto";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			primaryKey: function () {
				return ["idperfstrutturauo", "idperfvalutazioneuo", "idperfprogettoobiettivo"];
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

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettoobiettivouoview', new meta_perfprogettoobiettivouoview('perfprogettoobiettivouoview'));

	}());
