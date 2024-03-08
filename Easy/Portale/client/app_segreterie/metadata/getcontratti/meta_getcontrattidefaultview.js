(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_getcontrattidefaultview() {
        MetaData.apply(this, ["getcontrattidefaultview"]);
        this.name = 'meta_getcontrattidefaultview';
    }

    meta_getcontrattidefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getcontrattidefaultview,
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
						this.describeAColumn(table, 'title', 'Ruolo/Figura contrattuale', null, 1000, 50);
						this.describeAColumn(table, 'getcontratti_costolordoannuo', 'Costo lordo annuo', 'fixed.2', 2000, null);
						this.describeAColumn(table, 'getcontratti_costomese', 'Costo mensile', 'fixed.2', 3000, null);
						this.describeAColumn(table, 'getcontratti_costoora', 'Costo orario', 'fixed.2', 4000, null);
						this.describeAColumn(table, 'position_title', 'Title Tipologia di contratto Contratto', null, 5120, 50);
						this.describeAColumn(table, 'inquadramento_title', 'Denominazione Inquadramento Contratto', null, 5220, 2048);
						this.describeAColumn(table, 'inquadramento_tempdef', 'Tempo definito Inquadramento Contratto', null, 5230, null);
						this.describeAColumn(table, 'registrylegalstatus_start', 'Inizio Contratto', null, 5300, null);
						this.describeAColumn(table, 'registrylegalstatus_stop', 'Fine Contratto', null, 5400, null);
						this.describeAColumn(table, 'registrylegalstatus_tempdef', 'Tempo definito Contratto', null, 5700, null);
						this.describeAColumn(table, 'position_getcontratti_title', 'id Ruolo/Figura contrattuale', null, 6200, 50);
						this.describeAColumn(table, 'registrylegalstatus_percentualesufondiateneo', 'Percentuale su fondi interni Contratto', 'fixed.2', 6400, null);
						this.describeAColumn(table, 'inquadramento_getcontratti_title', 'Denominazione Inquadramento', null, 7200, 2048);
						this.describeAColumn(table, 'inquadramento_getcontratti_tempdef', 'Tempo definito Inquadramento', null, 7300, null);
						this.describeAColumn(table, 'registry_title', 'Dipendente', null, 8300, 101);
						this.describeAColumn(table, 'getcontratti_oremax', 'Oremax', null, 9000, null);
						this.describeAColumn(table, 'getcontratti_livello', 'Livello', null, 10000, null);
						this.describeAColumn(table, 'getcontratti_oremaxdida', 'Oremaxdida', null, 10000, null);
						this.describeAColumn(table, 'getcontratti_oremaxgg', 'Oremaxgg', null, 11000, null);
						this.describeAColumn(table, 'getcontratti_oremindida', 'Oremindida', null, 12000, null);
						this.describeAColumn(table, 'getcontratti_parttime', 'Percentuale part-time', 'fixed.2', 13000, null);
						this.describeAColumn(table, 'getcontratti_start', 'Inizio', null, 15000, null);
						this.describeAColumn(table, 'getcontratti_stop', 'Fine', null, 16000, null);
						this.describeAColumn(table, 'getcontratti_tempdef', 'Tempo definito', null, 17000, null);
						this.describeAColumn(table, 'getcontratti_totale_inquadramento', 'Totale_inquadramento', 'fixed.2', 18000, null);
						this.describeAColumn(table, 'getcontratti_totale_stipendioannuo', 'Totale_stipendioannuo', 'fixed.2', 19000, null);
						this.describeAColumn(table, 'getcontratti_totale_tabellastipendiale', 'Totale_tabellastipendiale', 'fixed.2', 20000, null);
						this.describeAColumn(table, 'getcontratti_totale_tipologiacontrattuale', 'Totale_tipologiacontrattuale', 'fixed.2', 21000, null);
						this.describeAColumn(table, 'stipendio_classe', 'Classe Identificativo', null, 22100, null);
						this.describeAColumn(table, 'stipendio_scatto', 'Scatto Identificativo', null, 22200, null);
						this.describeAColumn(table, 'stipendio_totale', 'Totale costo annuo Identificativo', 'fixed.2', 24100, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcontratto"];
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

    window.appMeta.addMeta('getcontrattidefaultview', new meta_getcontrattidefaultview('getcontrattidefaultview'));

	}());
