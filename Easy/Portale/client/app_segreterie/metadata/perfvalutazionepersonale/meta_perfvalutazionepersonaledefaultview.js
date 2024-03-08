(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfvalutazionepersonaledefaultview() {
        MetaData.apply(this, ["perfvalutazionepersonaledefaultview"]);
        this.name = 'meta_perfvalutazionepersonaledefaultview';
    }

    meta_perfvalutazionepersonaledefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazionepersonaledefaultview,
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
						this.describeAColumn(table, 'registry_title', 'Valutato', null, 1300, 101);
						this.describeAColumn(table, 'struttura_title', 'Denominazione U.O. Afferenza', null, 2110, 1024);
						this.describeAColumn(table, 'afferenza_start', 'Dal Afferenza', 'g', 2400, null);
						this.describeAColumn(table, 'afferenza_stop', 'Al Afferenza', 'g', 2500, null);
						this.describeAColumn(table, 'year', 'Anno solare', null, 3000, null);
						this.describeAColumn(table, 'mansionekind_title', 'Titolo Mansione Afferenza', null, 3020, 2048);
						this.describeAColumn(table, 'perfvalutazionepersonale_risultato', 'Percentuale risultato', 'fixed.2', 4000, null);
						this.describeAColumn(table, 'perfschedastatus_title', 'Stato', null, 5200, 1024);
						this.describeAColumn(table, 'XXperfvalutazionepersonaleateneo', 'Performance organizzativa di ateneo', null, 7000, null);
						this.describeAColumn(table, 'XXperfvalutazionepersonaleuo', 'Performance dell’unità organizzativa', null, 8000, null);
						this.describeAColumn(table, 'perfvalutazionepersonale_pesoperfuo', 'Peso della valutazione della performance dell’unità organizzativa', 'fixed.2', 9000, null);
						this.describeAColumn(table, 'perfvalutazionepersonale_percperfuo', 'Percentuale di completamento dell’unità organizzativa', 'fixed.2', 10000, null);
						this.describeAColumn(table, 'XXperfvalutazionepersonalecomportamento', 'Comportamenti Attesi ', null, 11000, null);
						this.describeAColumn(table, 'perfvalutazionepersonale_pesocomportamenti', 'Peso della valutazione della performance dei comportamenti attesi', 'fixed.2', 12000, null);
						this.describeAColumn(table, 'perfvalutazionepersonale_perccomportamenti', 'Percentuale di completamento dei comportamenti attesi', 'fixed.2', 13000, null);
						this.describeAColumn(table, 'registrycompcomp_title', 'Rilevatore comportamenti', null, 14300, 101);
						this.describeAColumn(table, 'registryvalcomp_title', 'Valutatore comportamenti', null, 15300, 101);
						this.describeAColumn(table, 'XXperfvalutazionepersonaleobiettivo', 'Obiettivi Individuali', null, 16000, null);
						this.describeAColumn(table, 'perfvalutazionepersonale_pesoobiettivi', 'Peso della valutazione della performance degli obiettivi individuali', 'fixed.2', 17000, null);
						this.describeAColumn(table, 'perfvalutazionepersonale_percobiettivi', 'Percentuale di completamento degli obiettivi individuali', 'fixed.2', 18000, null);
						this.describeAColumn(table, 'registrycreate_title', 'Inserisce obiettivi individuali', null, 19300, 101);
						this.describeAColumn(table, 'registrycomp_title', 'Rilevatore obiettivi individuali', null, 20300, 101);
						this.describeAColumn(table, 'registryval_title', 'Valutatore obiettivi individuali', null, 21300, 101);
						this.describeAColumn(table, 'registryappr_title', 'Approvatore', null, 22300, 101);
						this.describeAColumn(table, 'perfvalutazionepersonale_percateneo', 'Percentuale performance strategica', 'fixed.2', 23000, null);
						this.describeAColumn(table, 'perfvalutazionepersonale_pesoateneo', 'Peso performance strategica', 'fixed.2', 24000, null);
						this.describeAColumn(table, 'perfvalutazionepersonale_motivazione', 'Motivazione Valutazione', null, 25000, -1);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfvalutazionepersonale"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('perfvalutazionepersonaledefaultview', new meta_perfvalutazionepersonaledefaultview('perfvalutazionepersonaledefaultview'));

	}());
