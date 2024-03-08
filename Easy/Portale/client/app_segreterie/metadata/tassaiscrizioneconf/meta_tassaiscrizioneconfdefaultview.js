(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tassaiscrizioneconfdefaultview() {
        MetaData.apply(this, ["tassaiscrizioneconfdefaultview"]);
        this.name = 'meta_tassaiscrizioneconfdefaultview';
    }

    meta_tassaiscrizioneconfdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tassaiscrizioneconfdefaultview,
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
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'title', 'Title', null, 30, 2024);
						this.describeAColumn(table, 'aamax', 'Anno accademico massimo', null, 40, 9);
						this.describeAColumn(table, 'aamin', 'Anno accademico minimo', null, 50, 9);
						this.describeAColumn(table, 'tassaiscrizioneconf_annofcmax', 'Anno di iscrizione fuori corso massimo', null, 60, null);
						this.describeAColumn(table, 'tassaiscrizioneconf_annofcmin', 'Anno di iscrizione fuori corso minimo', null, 70, null);
						this.describeAColumn(table, 'tassaiscrizioneconf_annomax', 'Anno di iscrizione massimo', null, 80, null);
						this.describeAColumn(table, 'tassaiscrizioneconf_annomin', 'Anno di iscrizione minimo', null, 90, null);
						this.describeAColumn(table, 'tassaiscrizioneconf_codice_corsostudio', 'Codice del corso di studio', null, 100, 50);
						this.describeAColumn(table, 'tassaiscrizioneconf_codice_didprog', 'Codice della didattica programmata', null, 110, 50);
						this.describeAColumn(table, 'tassaiscrizioneconf_codice_didprogcurr', 'Codice del curriculum', null, 120, 50);
						this.describeAColumn(table, 'tassaiscrizioneconf_codice_didprogori', 'Codice dell\'orientamento', null, 130, 50);
						this.describeAColumn(table, 'tassaiscrizioneconf_corsisingoli', 'Corsi singoli', null, 140, null);
						this.describeAColumn(table, 'costoscontodef_title', 'Costo', null, 150, 2024);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idtassaiscrizioneconf"];
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

    window.appMeta.addMeta('tassaiscrizioneconfdefaultview', new meta_tassaiscrizioneconfdefaultview('tassaiscrizioneconfdefaultview'));

	}());
