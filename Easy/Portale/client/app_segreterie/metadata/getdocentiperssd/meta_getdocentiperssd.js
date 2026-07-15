(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_getdocentiperssd() {
        MetaData.apply(this, ["getdocentiperssd"]);
        this.name = 'meta_getdocentiperssd';
    }

    meta_getdocentiperssd.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getdocentiperssd,
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
						this.describeAColumn(table, 'costoorario', 'Costo orario', 'fixed.2', 10, null);
						this.describeAColumn(table, 'oreperaacontratto', 'Ore già impegnate nell\'AA per contratto', null, 20, null);
						this.describeAColumn(table, 'oreperaaaffidamento', 'Ore già impegnate nell\'AA per affidamenti', null, 30, null);
						this.describeAColumn(table, 'oremindida', 'Ore minime di didattica', null, 40, null);
						this.describeAColumn(table, 'oremaxdida', 'Ore massime di didattica', null, 50, null);
						this.describeAColumn(table, 'cognome', 'Cognome', null, 60, 50);
						this.describeAColumn(table, 'nome', 'Nome', null, 70, 50);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 80, 40);
						this.describeAColumn(table, 'ssd', 'Ssd', null, 90, 50);
						this.describeAColumn(table, 'contratto', 'Contratto', null, 100, 50);
						this.describeAColumn(table, 'iniziocontratto', 'Data di inizio del contratto', null, 110, null);
						this.describeAColumn(table, 'terminecontratto', 'Data di fine del contratto', null, 120, null);
						this.describeAColumn(table, 'parttime', 'Part-time', 'fixed.2', 130, null);
						this.describeAColumn(table, 'tempodefinito', 'Tempo definito', null, 140, 1);
						this.describeAColumn(table, 'struttura', 'Struttura', null, 150, 1024);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["aa"].caption = "Anno accademico";
						table.columns["costoorario"].caption = "Costo orario";
						table.columns["iniziocontratto"].caption = "Data di inizio del contratto";
						table.columns["oremaxdida"].caption = "Ore massime di didattica";
						table.columns["oremindida"].caption = "Ore minime di didattica";
						table.columns["oreperaaaffidamento"].caption = "Ore già impegnate nell'AA per affidamenti";
						table.columns["oreperaacontratto"].caption = "Ore già impegnate nell'AA per contratto";
						table.columns["parttime"].caption = "Part-time";
						table.columns["tempodefinito"].caption = "Tempo definito";
						table.columns["terminecontratto"].caption = "Data di fine del contratto";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			primaryKey: function () {
				return ["aa", "idreg"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "costoorario asc , oreperaacontratto asc , oreperaaaffidamento asc , ssd desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('getdocentiperssd', new meta_getdocentiperssd('getdocentiperssd'));

	}());
