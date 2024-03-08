(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiartitolo_segview() {
        MetaData.apply(this, ["dichiartitolo_segview"]);
        this.name = 'meta_dichiartitolo_segview';
    }

    meta_dichiartitolo_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiartitolo_segview,
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
					case 'titolo_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico della dichiarazione', null, 10, 9);
						this.describeAColumn(table, 'dichiar_date', 'Data', null, 30, null);
						this.describeAColumn(table, 'registry_title', 'Studente', null, 40, 101);
						this.describeAColumn(table, 'titolostudio_voto', 'Voto Titolo di studio', null, 50, null);
						this.describeAColumn(table, 'titolostudio_votosu', 'Su Titolo di studio', null, 50, null);
						this.describeAColumn(table, 'titolostudio_votolode', 'Lode Titolo di studio', null, 50, null);
//$objCalcFieldConfig_titolo_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddichiar"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('dichiartitolo_segview', new meta_dichiartitolo_segview('dichiartitolo_segview'));

	}());
