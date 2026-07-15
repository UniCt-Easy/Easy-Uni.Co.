(function () {

	var MetaData = window.appMeta.MetaSegreterieData;

	function meta_prova() {
		MetaData.apply(this, ["prova"]);
		this.name = 'meta_prova';
	}

	meta_prova.prototype = _.extend(
		new MetaData(),
		{
			constructor: meta_prova,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos = 1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'dotmas':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 50);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 20, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 30, null);
//$objCalcFieldConfig_dotmas$
						break;
					case 'stato':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 50);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 20, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 30, null);
						//$objCalcFieldConfig_stato$
						break;
					case 'default':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 20, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 30, null);
//$objCalcFieldConfig_default$
						break;
					case 'ingresso':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 50);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 20, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 30, null);
//$objCalcFieldConfig_ingresso$
						break;
					case 'aula':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 50);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 20, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 30, null);
						//$objCalcFieldConfig_aula$
						break;
										case 'doc':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 20, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 30, null);
//$objCalcFieldConfig_doc$
						break;
					case 'stuaccesso':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 50);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 20, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 30, null);
						this.describeAColumn(table, '!sostenimento', 'Sostenimenti', null, 40, null);
//$objCalcFieldConfig_stuaccesso$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'ingresso':
						table.columns["idappello"].caption = "Appello";
						table.columns["idattivform"].caption = "Attività formativa";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idprova"].caption = "Codice";
						table.columns["idquestionario"].caption = "Questionario";
						table.columns["idvalutazionekind"].caption = "Tipologia di valutazione";
						table.columns["start"].caption = "Data e ora inizio";
						table.columns["stop"].caption = "Data e ora fine";
						table.columns["title"].caption = "Denominazione";
//$innerSetCaptionConfig_ingresso$
						break;
					case 'default':
//$innerSetCaptionConfig_default$
						break;
					case 'dotmas':
						table.columns["idappello"].caption = "Appello";
//$innerSetCaptionConfig_dotmas$
						break;
					case 'doc':
//$innerSetCaptionConfig_doc$
						break;
					case 'stuaccesso':
//$innerSetCaptionConfig_stuaccesso$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_prova");

				//$getNewRowInside$

				dt.autoIncrement('idprova', { minimum: 99990001 });

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
					case "dotmas": {
						return "title asc ";
					}
					case "stato": {
						return "title asc ";
					}
					case "default": {
						return "title asc ";
					}
					case "ingresso": {
						return "title asc ";
					}
					case "aula": {
						return "title asc ";
					}
					case "doc": {
						return "title asc ";
					}
					case "stuaccesso": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

		});

	window.appMeta.addMeta('prova', new meta_prova('prova'));

}());
