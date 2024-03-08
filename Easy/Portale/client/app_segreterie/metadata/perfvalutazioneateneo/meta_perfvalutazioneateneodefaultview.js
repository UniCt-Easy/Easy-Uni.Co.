(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfvalutazioneateneodefaultview() {
        MetaData.apply(this, ["perfvalutazioneateneodefaultview"]);
        this.name = 'meta_perfvalutazioneateneodefaultview';
    }

    meta_perfvalutazioneateneodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazioneateneodefaultview,
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
						this.describeAColumn(table, 'year', 'Anno', null, 2000, null);
						this.describeAColumn(table, 'perfvalutazioneateneo_performance', 'Performance', 'fixed.2', 7000, null);
						this.describeAColumn(table, 'calcoloautomatico', 'Risultato calcolato automaticamente', null, 8000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfvalutazioneateneo"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('perfvalutazioneateneodefaultview', new meta_perfvalutazioneateneodefaultview('perfvalutazioneateneodefaultview'));

	}());
