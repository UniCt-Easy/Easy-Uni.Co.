(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfvalutazioneuodefaultview() {
        MetaData.apply(this, ["perfvalutazioneuodefaultview"]);
        this.name = 'meta_perfvalutazioneuodefaultview';
    }

    meta_perfvalutazioneuodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazioneuodefaultview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				var objCalcFieldConfig = {};
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'struttura_title', 'Denominazione Unità organizzativa', null, 1100, 1024);
						this.describeAColumn(table, 'strutturaparent_title', 'Denominazione U.O. madre Unità organizzativa', null, 1910, 1024);
						this.describeAColumn(table, 'year', 'Anno solare', null, 2000, null);
						this.describeAColumn(table, 'perfvalutazioneuo_risultato', 'Risultato %', 'fixed.2', 3000, null);
						this.describeAColumn(table, 'perfschedastatus_title', 'Stato', null, 4200, 1024);
						this.describeAColumn(table, 'perfvalutazioneuo_pesoproguo', 'Peso della valutazione della performance dei Progetti Strategici della UO', 'fixed.2', 7000, null);
						this.describeAColumn(table, 'perfvalutazioneuo_completamentopsuo', 'Percentuale di completamento per i progetti Strategici della UO', 'fixed.2', 8000, null);
						this.describeAColumn(table, 'XXperfprogettoobiettivouoview', 'Obiettivi dei progetti Strategici della UO', null, 9000, null);
						this.describeAColumn(table, 'perfvalutazioneuo_pesoprogaltreuo', 'Peso della valutazione della performance dei Progetti Strategici di altre UO ', 'fixed.2', 10000, null);
						this.describeAColumn(table, 'perfvalutazioneuo_completamentopsauo', 'Percentuale di completamento dei progetti Strategici di altre UO', 'fixed.2', 11000, null);
						this.describeAColumn(table, 'XXperfprogettoobiettivopersonaleview', 'Obiettivi dei progetti Strategici di altre UO', null, 12000, null);
						this.describeAColumn(table, 'perfvalutazioneuo_pesoindicatori', 'Peso della valutazione della performance degli indicatori', 'fixed.2', 13000, null);
						this.describeAColumn(table, 'perfvalutazioneuo_indicatori', 'Percentuale di completamento degli indicatori', 'fixed.2', 14000, null);
						this.describeAColumn(table, 'XXperfvalutazioneuoindicatori', 'Indicatori operativi', null, 15000, null);
						this.describeAColumn(table, 'perfvalutazioneuo_pesoobiettivi', 'Peso della valutazione della performance degli obiettivi una tantum', 'fixed.2', 16000, null);
						this.describeAColumn(table, 'perfvalutazioneuo_obiettiviindividuali', 'Percentuale di completamento degli obiettivi una tantum', 'fixed.2', 17000, null);
						this.describeAColumn(table, 'XXperfobiettiviuo', 'Obiettivi una tantum', null, 18000, null);
						this.describeAColumn(table, 'registrycreate_title', 'Inserisce obiettivi una tantum', null, 20300, 101);
						this.describeAColumn(table, 'registryappr_title', 'Approvatore', null, 21300, 101);
						this.describeAColumn(table, 'registrycompobborg_title', 'Compilatore indicatori', null, 22300, 101);
						this.describeAColumn(table, 'registrycomp_title', 'Compilatore obiettivi una tantum', null, 23300, 101);
						this.describeAColumn(table, 'registryvalobborg_title', 'Valutatore indicatori', null, 24300, 101);
						this.describeAColumn(table, 'registryval_title', 'Valutatore obiettivi una tantum', null, 25300, 101);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfprogettouo", "idperfvalutazioneuo"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('perfvalutazioneuodefaultview', new meta_perfvalutazioneuodefaultview('perfvalutazioneuodefaultview'));

	}());
