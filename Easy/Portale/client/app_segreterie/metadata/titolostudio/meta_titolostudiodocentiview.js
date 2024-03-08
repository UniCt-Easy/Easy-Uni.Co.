(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_titolostudiodocentiview() {
        MetaData.apply(this, ["titolostudiodocentiview"]);
        this.name = 'meta_titolostudiodocentiview';
    }

    meta_titolostudiodocentiview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_titolostudiodocentiview,
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
					case 'docenti':
						this.describeAColumn(table, 'istattitolistudio_titolo', 'Titolo ISTAT', null, 1200, 1024);
						this.describeAColumn(table, 'registryistituti_title', 'Istituto', null, 2100, 101);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 3000, 9);
						this.describeAColumn(table, 'titolostudio_data', 'Data del conseguimento', null, 5000, null);
						this.describeAColumn(table, 'titolostudio_giudizio', 'Giudizio', null, 6000, 50);
						this.describeAColumn(table, 'titolostudio_voto', 'Voto', null, 7000, null);
						this.describeAColumn(table, 'titolostudio_votosu', 'Su', null, 8000, null);
						this.describeAColumn(table, 'titolostudio_votolode', 'Lode', null, 9000, null);
//$objCalcFieldConfig_docenti$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idtitolostudio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('titolostudiodocentiview', new meta_titolostudiodocentiview('titolostudiodocentiview'));

	}());
