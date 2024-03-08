(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_upbdefaultview() {
        MetaData.apply(this, ["upbdefaultview"]);
        this.name = 'meta_upbdefaultview';
    }

    meta_upbdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_upbdefaultview,
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
						this.describeAColumn(table, 'idupb', 'id voce upb (tabella upb)', null, 10, 36);
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 150);
						this.describeAColumn(table, 'upb_active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'upb_assured', 'Finanziamento certo (Non gestire assegnazione crediti/incassi)', null, 40, null);
						this.describeAColumn(table, 'upb_cigcode', 'Codice CIG, Codice identificativo di gara', null, 50, 10);
						this.describeAColumn(table, 'upb_codeupb', 'Codice', null, 60, 50);
						this.describeAColumn(table, 'upb_cupcode', 'Codice CUP, Codice unico di progetto', null, 70, 15);
						this.describeAColumn(table, 'upb_expiration', 'scadenza', null, 80, null);
						this.describeAColumn(table, 'upb_flag', 'flag vari', null, 90, null);
						this.describeAColumn(table, 'upb_flagactivity', 'Tipo attività', null, 100, null);
						this.describeAColumn(table, 'upb_flagkind', 'Funzione', null, 110, null);
						this.describeAColumn(table, 'upb_granted', 'Finanziamento concesso', 'fixed.2', 120, null);
						this.describeAColumn(table, 'epupbkind_title', 'Denominazione ID Tipo UPB nell\'economico patrimoniale (tabella epupbkind)', null, 130, 50);
						this.describeAColumn(table, 'epupbkind_description', 'Descrizione ID Tipo UPB nell\'economico patrimoniale (tabella epupbkind)', null, 130, 500);
						this.describeAColumn(table, 'treasurer_description', 'Id cassiere (tabella treasurer)', null, 200, 150);
						this.describeAColumn(table, 'underwriter_description', 'ID Ente finanziatore (tabella underwriter)', null, 210, 50);
						this.describeAColumn(table, 'upb_newcodeupb', 'Codice di consolidamento', null, 220, 50);
						this.describeAColumn(table, 'upbparent_title', 'chiave parent U.P.B. (tabella upb) ', null, 230, 150);
						this.describeAColumn(table, 'upb_previousappropriation', 'Totale impegnato pregresso (previa informatizzazione)', 'fixed.2', 240, null);
						this.describeAColumn(table, 'upb_previousassessment', 'Totale accertato pregresso (previa informatizzazione)', 'fixed.2', 250, null);
						this.describeAColumn(table, 'upb_printingorder', 'Ordine di stampa', null, 260, 50);
						this.describeAColumn(table, 'upb_requested', 'Finanziamento richiesto', 'fixed.2', 270, null);
						this.describeAColumn(table, 'upb_rtf', 'allegati', null, 280, null);
						this.describeAColumn(table, 'upb_start', 'data inizio', null, 290, null);
						this.describeAColumn(table, 'upb_stop', 'data fine', null, 300, null);
						this.describeAColumn(table, 'upb_txt', 'note testuali', null, 310, null);
						this.describeAColumn(table, 'upb_cofogmpcode', 'Cofogmpcode', null, 400, 10);
						this.describeAColumn(table, 'upbcapofila_title', 'Idupb_capofila', null, 410, 150);
						this.describeAColumn(table, 'upb_ri_ra_quota', 'Ri_ra_quota', 'fixed.6', 420, null);
						this.describeAColumn(table, 'upb_ri_rb_quota', 'Ri_rb_quota', 'fixed.6', 430, null);
						this.describeAColumn(table, 'upb_ri_sa_quota', 'Ri_sa_quota', 'fixed.6', 440, null);
						this.describeAColumn(table, 'upb_uesiopecode', 'Uesiopecode', null, 450, 10);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idupb"];
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

    window.appMeta.addMeta('upbdefaultview', new meta_upbdefaultview('upbdefaultview'));

	}());
