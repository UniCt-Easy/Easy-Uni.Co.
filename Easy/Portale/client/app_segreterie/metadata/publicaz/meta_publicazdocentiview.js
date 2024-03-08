(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_publicazdocentiview() {
        MetaData.apply(this, ["publicazdocentiview"]);
        this.name = 'meta_publicazdocentiview';
    }

    meta_publicazdocentiview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_publicazdocentiview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 512);
						this.describeAColumn(table, 'publicaz_title2', 'Sottotitolo', null, 30, 512);
						this.describeAColumn(table, 'publicaz_annopub', 'Anno pubblicazione', null, 40, null);
						this.describeAColumn(table, 'publicaz_editore', 'Editore', null, 50, 150);
						this.describeAColumn(table, 'progetto_titolobreve', 'Idprogetto', null, 60, 2048);
//$objCalcFieldConfig_docenti$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idpublicaz"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "docenti": {
						return "title asc , publicaz_title2 asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('publicazdocentiview', new meta_publicazdocentiview('publicazdocentiview'));

	}());
