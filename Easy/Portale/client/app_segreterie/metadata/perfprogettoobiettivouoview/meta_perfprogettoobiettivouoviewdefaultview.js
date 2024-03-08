(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettoobiettivouoviewdefaultview() {
        MetaData.apply(this, ["perfprogettoobiettivouoviewdefaultview"]);
        this.name = 'meta_perfprogettoobiettivouoviewdefaultview';
    }

    meta_perfprogettoobiettivouoviewdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettoobiettivouoviewdefaultview,
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
						this.describeAColumn(table, 'progetto_title', 'Progetto', null, 1000, 1024);
						this.describeAColumn(table, 'perfprogettoobiettivouoview_title', 'Titolo', null, 3000, 1024);
						this.describeAColumn(table, 'perfprogettoobiettivouoview_description', 'Descrizione', null, 4000, -1);
						this.describeAColumn(table, 'perfprogettoobiettivouoview_peso', 'Peso per il progetto', 'fixed.2', 5000, null);
						this.describeAColumn(table, 'XXperfprogettoobiettivosoglia', 'Soglie dell\'obiettivo', null, 5000, null);
						this.describeAColumn(table, 'perfprogettoobiettivouoview_completamento', 'Percentuale di completamento', 'fixed.2', 6000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idstruttura", "idperfvalutazioneuo", "idperfprogettoobiettivo"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "perfprogettoobiettivouoview_title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettoobiettivouoviewdefaultview', new meta_perfprogettoobiettivouoviewdefaultview('perfprogettoobiettivouoviewdefaultview'));

	}());
