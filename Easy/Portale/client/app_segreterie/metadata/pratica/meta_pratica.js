(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pratica() {
        MetaData.apply(this, ["pratica"]);
        this.name = 'meta_pratica';
    }

    meta_pratica.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pratica,
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
					case 'segstud':
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 200, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 210, null);
//$objCalcFieldConfig_segstud$
						break;
					case 'seganagstu':
						this.describeAColumn(table, '!iddichiar_dichiar_aa', 'Anno Accademico Dichiarazione da convalidare', null, 12, null);
						this.describeAColumn(table, '!iddichiar_dichiar_date', 'Data Dichiarazione da convalidare', null, 13, null);
						this.describeAColumn(table, '!iddichiar_dichiar_iddichiarkind_title', 'Tipologia Dichiarazione da convalidare', null, 11, null);
						this.describeAColumn(table, '!iddichiar_dichiar_idreg_title', 'Denominazione Dichiarazione da convalidare', null, 11, null);
						objCalcFieldConfig['!iddichiar_dichiar_aa'] = { tableNameLookup:'dichiar', columnNameLookup:'aa', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiar_date'] = { tableNameLookup:'dichiar', columnNameLookup:'date', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiar_iddichiarkind_title'] = { tableNameLookup:'dichiarkind', columnNameLookup:'title', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiar_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'iddichiar' };
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_anno', 'Anno di corso Iscrizione da cui si vogliono convalidare i sostenimenti', null, 41, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 43, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_title', 'Denominazione Iscrizione da cui si vogliono convalidare i sostenimenti', null, 41, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 42, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_idsede', 'Sede Iscrizione da cui si vogliono convalidare i sostenimenti', null, 43, null);
						objCalcFieldConfig['!idiscrizione_from_iscrizione_anno'] = { tableNameLookup:'iscrizione', columnNameLookup:'anno', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_aa'] = { tableNameLookup:'iscrizione', columnNameLookup:'aa', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_idsede'] = { tableNameLookup:'didprog', columnNameLookup:'idsede', columnNamekey:'idiscrizione_from' };
						this.describeAColumn(table, '!idstatuskind_statuskind_title', 'Stato', null, 51, null);
						objCalcFieldConfig['!idstatuskind_statuskind_title'] = { tableNameLookup:'statuskind_alias1', columnNameLookup:'title', columnNamekey:'idstatuskind' };
						this.describeAColumn(table, '!idtitolostudio_titolostudio_voto', 'Voto Titolo studio da cui si vogliono convalidare i sostenimenti', null, 52, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_votosu', 'Su Titolo studio da cui si vogliono convalidare i sostenimenti', null, 53, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_votolode', 'Lode Titolo studio da cui si vogliono convalidare i sostenimenti', null, 54, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_aa', 'Anno accademco Titolo studio da cui si vogliono convalidare i sostenimenti', null, 55, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_idistattitolistudio_titolo', 'Titolo di studio Titolo studio da cui si vogliono convalidare i sostenimenti', null, 51, null);
						objCalcFieldConfig['!idtitolostudio_titolostudio_voto'] = { tableNameLookup:'titolostudio', columnNameLookup:'voto', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_votosu'] = { tableNameLookup:'titolostudio', columnNameLookup:'votosu', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_votolode'] = { tableNameLookup:'titolostudio', columnNameLookup:'votolode', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_aa'] = { tableNameLookup:'titolostudio', columnNameLookup:'aa', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_idistattitolistudio_titolo'] = { tableNameLookup:'istattitolistudio', columnNameLookup:'titolo', columnNamekey:'idtitolostudio' };
						this.describeAColumn(table, '!iddichiar_dichiar_aa', 'Anno Accademico Dichiarazione da convalidare', null, 10, null);
						this.describeAColumn(table, '!iddichiar_dichiar_extension', 'Tabella che estende il record Dichiarazione da convalidare', null, 10, null);
						objCalcFieldConfig['!iddichiar_dichiar_extension'] = { tableNameLookup:'dichiar', columnNameLookup:'extension', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!idstatuskind_statuskind_title'] = { tableNameLookup:'statuskind', columnNameLookup:'title', columnNamekey:'idstatuskind' };
						this.describeAColumn(table, '!idtitolostudio_titolostudio_aa', 'Anno accademico Titolo studio da cui si vogliono convalidare i sostenimenti', null, 55, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_idistattitolistudio_titolo', 'Titolo ISTAT Titolo studio da cui si vogliono convalidare i sostenimenti', null, 50, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 42, null);
						this.describeAColumn(table, '!idstatuskind_statuskind_title', 'Stato', null, 61, null);
//$objCalcFieldConfig_seganagstu$
						break;
					case 'seganagstuistrein':
						this.describeAColumn(table, '!iddichiar_dichiar_aa', 'Anno Accademico Dichiarazione da convalidare', null, 32, null);
						this.describeAColumn(table, '!iddichiar_dichiar_date', 'Data Dichiarazione da convalidare', null, 33, null);
						this.describeAColumn(table, '!iddichiar_dichiar_iddichiarkind_title', 'Tipologia Dichiarazione da convalidare', null, 31, null);
						this.describeAColumn(table, '!iddichiar_dichiar_idreg_title', 'Denominazione Dichiarazione da convalidare', null, 31, null);
						objCalcFieldConfig['!iddichiar_dichiar_aa'] = { tableNameLookup:'dichiar', columnNameLookup:'aa', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiar_date'] = { tableNameLookup:'dichiar', columnNameLookup:'date', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiar_iddichiarkind_title'] = { tableNameLookup:'dichiarkind', columnNameLookup:'title', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiar_idreg_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'iddichiar' };
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_anno', 'Anno di corso Iscrizione da cui si vogliono convalidare i sostenimenti', null, 61, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 63, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_title', 'Denominazione Iscrizione da cui si vogliono convalidare i sostenimenti', null, 61, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 62, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_idsede', 'Sede Iscrizione da cui si vogliono convalidare i sostenimenti', null, 63, null);
						objCalcFieldConfig['!idiscrizione_from_iscrizione_anno'] = { tableNameLookup:'iscrizione', columnNameLookup:'anno', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_aa'] = { tableNameLookup:'iscrizione', columnNameLookup:'aa', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_idsede'] = { tableNameLookup:'didprog', columnNameLookup:'idsede', columnNamekey:'idiscrizione_from' };
						this.describeAColumn(table, '!idstatuskind_statuskind_title', 'Stato', null, 101, null);
						objCalcFieldConfig['!idstatuskind_statuskind_title'] = { tableNameLookup:'statuskind_alias1', columnNameLookup:'title', columnNamekey:'idstatuskind' };
						this.describeAColumn(table, '!idtitolostudio_titolostudio_voto', 'Voto Titolo studio da cui si vogliono convalidare i sostenimenti', null, 112, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_votosu', 'Su Titolo studio da cui si vogliono convalidare i sostenimenti', null, 113, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_votolode', 'Lode Titolo studio da cui si vogliono convalidare i sostenimenti', null, 114, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_aa', 'Anno accademco Titolo studio da cui si vogliono convalidare i sostenimenti', null, 115, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_idistattitolistudio_titolo', 'Titolo di studio Titolo studio da cui si vogliono convalidare i sostenimenti', null, 111, null);
						objCalcFieldConfig['!idtitolostudio_titolostudio_voto'] = { tableNameLookup:'titolostudio', columnNameLookup:'voto', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_votosu'] = { tableNameLookup:'titolostudio', columnNameLookup:'votosu', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_votolode'] = { tableNameLookup:'titolostudio', columnNameLookup:'votolode', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_aa'] = { tableNameLookup:'titolostudio', columnNameLookup:'aa', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_idistattitolistudio_titolo'] = { tableNameLookup:'istattitolistudio', columnNameLookup:'titolo', columnNamekey:'idtitolostudio' };
//$objCalcFieldConfig_seganagstuistrein$
						break;
					case 'segistrein':
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 120, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 130, null);
						this.describeAColumn(table, '!iddichiar_dichiar_aa', 'Anno Accademico Dichiarazione da convalidare', null, 32, null);
						this.describeAColumn(table, '!iddichiar_dichiar_date', 'Data Dichiarazione da convalidare', null, 33, null);
						this.describeAColumn(table, '!iddichiar_dichiar_iddichiarkind_title', 'Tipologia Dichiarazione da convalidare', null, 30, null);
						objCalcFieldConfig['!iddichiar_dichiar_aa'] = { tableNameLookup:'dichiar', columnNameLookup:'aa', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiar_date'] = { tableNameLookup:'dichiar', columnNameLookup:'date', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiar_iddichiarkind_title'] = { tableNameLookup:'dichiarkind', columnNameLookup:'title', columnNamekey:'iddichiar' };
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_anno', 'Anno di corso Iscrizione da cui si vogliono convalidare i sostenimenti', null, 61, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 62, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_title', 'Denominazione Iscrizione da cui si vogliono convalidare i sostenimenti', null, 61, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 62, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_idsede', 'Sede Iscrizione da cui si vogliono convalidare i sostenimenti', null, 63, null);
						objCalcFieldConfig['!idiscrizione_from_iscrizione_anno'] = { tableNameLookup:'iscrizione', columnNameLookup:'anno', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_aa'] = { tableNameLookup:'iscrizione', columnNameLookup:'aa', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_idsede'] = { tableNameLookup:'didprog', columnNameLookup:'idsede', columnNamekey:'idiscrizione_from' };
						this.describeAColumn(table, '!idstatuskind_statuskind_title', 'Stato', null, 101, null);
						objCalcFieldConfig['!idstatuskind_statuskind_title'] = { tableNameLookup:'statuskind', columnNameLookup:'title', columnNamekey:'idstatuskind' };
						this.describeAColumn(table, '!idtitolostudio_titolostudio_voto', 'Voto Titolo studio da cui si vogliono convalidare i sostenimenti', null, 92, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_votosu', 'Su Titolo studio da cui si vogliono convalidare i sostenimenti', null, 93, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_votolode', 'Lode Titolo studio da cui si vogliono convalidare i sostenimenti', null, 94, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_aa', 'Anno accademico Titolo studio da cui si vogliono convalidare i sostenimenti', null, 95, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_idistattitolistudio_titolo', 'Titolo ISTAT Titolo studio da cui si vogliono convalidare i sostenimenti', null, 90, null);
						objCalcFieldConfig['!idtitolostudio_titolostudio_voto'] = { tableNameLookup:'titolostudio', columnNameLookup:'voto', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_votosu'] = { tableNameLookup:'titolostudio', columnNameLookup:'votosu', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_votolode'] = { tableNameLookup:'titolostudio', columnNameLookup:'votolode', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_aa'] = { tableNameLookup:'titolostudio', columnNameLookup:'aa', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_idistattitolistudio_titolo'] = { tableNameLookup:'istattitolistudio', columnNameLookup:'titolo', columnNamekey:'idtitolostudio' };
//$objCalcFieldConfig_segistrein$
						break;
					case 'segstudelenco':
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 200, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 210, null);
//$objCalcFieldConfig_segstudelenco$
						break;
					case 'segstuelenco':
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 200, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 210, null);
//$objCalcFieldConfig_segstuelenco$
						break;
					case 'segistpass':
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 120, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 130, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_anno', 'Anno di corso Iscrizione da cui si vogliono convalidare i sostenimenti', null, 61, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 62, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_title', 'Denominazione Iscrizione da cui si vogliono convalidare i sostenimenti', null, 61, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 62, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_idsede', 'Sede Iscrizione da cui si vogliono convalidare i sostenimenti', null, 63, null);
						objCalcFieldConfig['!idiscrizione_from_iscrizione_anno'] = { tableNameLookup:'iscrizione', columnNameLookup:'anno', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_aa'] = { tableNameLookup:'iscrizione', columnNameLookup:'aa', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_idsede'] = { tableNameLookup:'didprog', columnNameLookup:'idsede', columnNamekey:'idiscrizione_from' };
						this.describeAColumn(table, '!idstatuskind_statuskind_title', 'Stato', null, 101, null);
						objCalcFieldConfig['!idstatuskind_statuskind_title'] = { tableNameLookup:'statuskind', columnNameLookup:'title', columnNamekey:'idstatuskind' };
//$objCalcFieldConfig_segistpass$
						break;
					case 'segistabbr':
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 120, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 130, null);
						this.describeAColumn(table, '!iddichiar_dichiar_aa', 'Anno Accademico Dichiarazione da convalidare', null, 32, null);
						this.describeAColumn(table, '!iddichiar_dichiar_date', 'Data Dichiarazione da convalidare', null, 33, null);
						this.describeAColumn(table, '!iddichiar_dichiar_iddichiarkind_title', 'Tipologia Dichiarazione da convalidare', null, 30, null);
						objCalcFieldConfig['!iddichiar_dichiar_aa'] = { tableNameLookup:'dichiar', columnNameLookup:'aa', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiar_date'] = { tableNameLookup:'dichiar', columnNameLookup:'date', columnNamekey:'iddichiar' };
						objCalcFieldConfig['!iddichiar_dichiar_iddichiarkind_title'] = { tableNameLookup:'dichiarkind', columnNameLookup:'title', columnNamekey:'iddichiar' };
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_anno', 'Anno di corso Iscrizione da cui si vogliono convalidare i sostenimenti', null, 61, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 62, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_title', 'Denominazione Iscrizione da cui si vogliono convalidare i sostenimenti', null, 61, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 62, null);
						this.describeAColumn(table, '!idiscrizione_from_iscrizione_iddidprog_idsede', 'Sede Iscrizione da cui si vogliono convalidare i sostenimenti', null, 63, null);
						objCalcFieldConfig['!idiscrizione_from_iscrizione_anno'] = { tableNameLookup:'iscrizione', columnNameLookup:'anno', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_aa'] = { tableNameLookup:'iscrizione', columnNameLookup:'aa', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'idiscrizione_from' };
						objCalcFieldConfig['!idiscrizione_from_iscrizione_iddidprog_idsede'] = { tableNameLookup:'didprog', columnNameLookup:'idsede', columnNamekey:'idiscrizione_from' };
						this.describeAColumn(table, '!idstatuskind_statuskind_title', 'Stato', null, 101, null);
						objCalcFieldConfig['!idstatuskind_statuskind_title'] = { tableNameLookup:'statuskind', columnNameLookup:'title', columnNamekey:'idstatuskind' };
						this.describeAColumn(table, '!idtitolostudio_titolostudio_voto', 'Voto Titolo studio da cui si vogliono convalidare i sostenimenti', null, 92, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_votosu', 'Su Titolo studio da cui si vogliono convalidare i sostenimenti', null, 93, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_votolode', 'Lode Titolo studio da cui si vogliono convalidare i sostenimenti', null, 94, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_aa', 'Anno accademico Titolo studio da cui si vogliono convalidare i sostenimenti', null, 95, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_idistattitolistudio_titolo', 'Titolo ISTAT Titolo studio da cui si vogliono convalidare i sostenimenti', null, 90, null);
						objCalcFieldConfig['!idtitolostudio_titolostudio_voto'] = { tableNameLookup:'titolostudio', columnNameLookup:'voto', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_votosu'] = { tableNameLookup:'titolostudio', columnNameLookup:'votosu', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_votolode'] = { tableNameLookup:'titolostudio', columnNameLookup:'votolode', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_aa'] = { tableNameLookup:'titolostudio', columnNameLookup:'aa', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_idistattitolistudio_titolo'] = { tableNameLookup:'istattitolistudio', columnNameLookup:'titolo', columnNamekey:'idtitolostudio' };
//$objCalcFieldConfig_segistabbr$
						break;
					case 'segisttri':
						this.describeAColumn(table, '!idstatuskind_statuskind_title', 'Stato', null, 101, null);
						objCalcFieldConfig['!idstatuskind_statuskind_title'] = { tableNameLookup:'statuskind', columnNameLookup:'title', columnNamekey:'idstatuskind' };
						this.describeAColumn(table, '!idtitolostudio_titolostudio_voto', 'Voto Titolo studio da cui si vogliono convalidare i sostenimenti', null, 12, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_votosu', 'Su Titolo studio da cui si vogliono convalidare i sostenimenti', null, 13, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_votolode', 'Lode Titolo studio da cui si vogliono convalidare i sostenimenti', null, 14, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_aa', 'Anno accademico Titolo studio da cui si vogliono convalidare i sostenimenti', null, 15, null);
						this.describeAColumn(table, '!idtitolostudio_titolostudio_idistattitolistudio_titolo', 'Titolo ISTAT Titolo studio da cui si vogliono convalidare i sostenimenti', null, 10, null);
						objCalcFieldConfig['!idtitolostudio_titolostudio_voto'] = { tableNameLookup:'titolostudio', columnNameLookup:'voto', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_votosu'] = { tableNameLookup:'titolostudio', columnNameLookup:'votosu', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_votolode'] = { tableNameLookup:'titolostudio', columnNameLookup:'votolode', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_aa'] = { tableNameLookup:'titolostudio', columnNameLookup:'aa', columnNamekey:'idtitolostudio' };
						objCalcFieldConfig['!idtitolostudio_titolostudio_idistattitolistudio_titolo'] = { tableNameLookup:'istattitolistudio', columnNameLookup:'titolo', columnNamekey:'idtitolostudio' };
//$objCalcFieldConfig_segisttri$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'segstud':
						table.columns["idcorsostudio"].caption = "Corso di studio";
						table.columns["iddichiar"].caption = "Dichiarazione da convalidare";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idiscrizione_from"].caption = "Iscrizione da cui si vogliono convalidare i sostenimenti";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idistanzakind"].caption = "Tipologia di istanza";
						table.columns["idreg"].caption = "Studente";
						table.columns["idstatuskind"].caption = "Stato";
						table.columns["idtitolostudio"].caption = "Titolo studio da cui si vogliono convalidare i sostenimenti";
						table.columns["protanno"].caption = "Anno di protocollo";
						table.columns["protnumero"].caption = "Numero di protocollo";
//$innerSetCaptionConfig_segstud$
						break;
					case 'segistpass':
//$innerSetCaptionConfig_segistpass$
						break;
					case 'segistabbr':
//$innerSetCaptionConfig_segistabbr$
						break;
					case 'segisttri':
//$innerSetCaptionConfig_segisttri$
						break;
					case 'segistrein':
//$innerSetCaptionConfig_segistrein$
						break;
					case 'seganagstu':
//$innerSetCaptionConfig_seganagstu$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_pratica");

				//$getNewRowInside$

				dt.autoIncrement('idpratica', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "segstud": {
						return "idreg desc, iddidprog desc";
					}
					case "segstudelenco": {
						return "idreg desc, iddidprog desc";
					}
					case "segstuelenco": {
						return "idreg desc, iddidprog desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('pratica', new meta_pratica('pratica'));

	}());
