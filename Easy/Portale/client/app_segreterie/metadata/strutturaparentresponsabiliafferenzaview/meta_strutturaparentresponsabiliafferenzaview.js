(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_strutturaparentresponsabiliafferenzaview() {
        MetaData.apply(this, ["strutturaparentresponsabiliafferenzaview"]);
        this.name = 'meta_strutturaparentresponsabiliafferenzaview';
    }

    meta_strutturaparentresponsabiliafferenzaview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_strutturaparentresponsabiliafferenzaview,
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
						this.describeAColumn(table, 'title', 'Title', null, 10, 1024);
						this.describeAColumn(table, 'idperfruolo', 'Identificativo', null, 40, 50);
						this.describeAColumn(table, 'idreg', 'idreg di chi ha il diritto', null, 50, null);
						this.describeAColumn(table, 'idstruttura', 'Identificativo', null, 60, null);
						this.describeAColumn(table, 'registry_title', 'Nome di chi ha il diritto', null, 80, 101);
						this.describeAColumn(table, 'start', 'Start', 'g', 90, null);
						this.describeAColumn(table, 'stop', 'Stop', 'g', 100, null);
						this.describeAColumn(table, 'afferenza_idreg', 'idreg su cui ha il diritto', null, 140, null);
						this.describeAColumn(table, 'afferenza_start', 'Afferenza_start', 'g', 150, null);
						this.describeAColumn(table, 'afferenza_stop', 'Afferenza_stop', 'g', 160, null);
						this.describeAColumn(table, 'aggiorna', 'Aggiorna', null, 170, null);
						this.describeAColumn(table, 'crea', 'Crea', null, 180, null);
						this.describeAColumn(table, 'leggi', 'Leggi', null, 190, null);
						this.describeAColumn(table, 'obiettivi_ateneo', 'Obiettivi_ateneo', null, 200, 1);
						this.describeAColumn(table, 'obiettivi_comportamentali', 'Obiettivi_comportamentali', null, 210, 1);
						this.describeAColumn(table, 'obiettivi_individuali', 'Obiettivi_individuali', null, 220, 1);
						this.describeAColumn(table, 'obiettivi_organizzativi', 'Obiettivi_organizzativi', null, 230, 1);
						this.describeAColumn(table, 'obiettivi_progetti', 'Obiettivi_progetti', null, 240, 1);
						this.describeAColumn(table, 'obiettivi_unatantum', 'Obiettivi_unatantum', null, 250, 1);
						this.describeAColumn(table, 'valuta', 'Valuta', null, 260, null);
						this.describeAColumn(table, 'year', 'Year', null, 270, null);
						this.describeAColumn(table, 'resplevel', 'Resplevel', null, 280, null);
						this.describeAColumn(table, 'idafferenza', 'Idafferenza', null, 290, null);
						this.describeAColumn(table, 'approva', 'Approva', null, 300, null);
						this.describeAColumn(table, 'idposition', 'Idposition', null, 310, null);
						this.describeAColumn(table, 'escluso', 'Escluso', null, 320, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["afferenza_idreg"].caption = "idreg su cui ha il diritto";
						table.columns["idreg"].caption = "idreg di chi ha il diritto";
						table.columns["registry_title"].caption = "Nome di chi ha il diritto";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			primaryKey: function () {
				return ["idreg", "idperfruolo", "idstruttura", "idstruttura_parent"];
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

    window.appMeta.addMeta('strutturaparentresponsabiliafferenzaview', new meta_strutturaparentresponsabiliafferenzaview('strutturaparentresponsabiliafferenzaview'));

	}());
