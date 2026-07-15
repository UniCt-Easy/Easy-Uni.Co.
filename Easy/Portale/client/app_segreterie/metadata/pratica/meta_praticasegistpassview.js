(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_praticasegistpassview() {
        MetaData.apply(this, ["praticasegistpassview"]);
        this.name = 'meta_praticasegistpassview';
    }

    meta_praticasegistpassview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_praticasegistpassview,
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
					case 'segistpass':
						this.describeAColumn(table, 'iscrizionefrom_aa', 'Anno accademico Iscrizione da cui si vogliono convalidare i sostenimenti', null, 6100, 9);
						this.describeAColumn(table, 'iscrizionefrom_anno', 'Anno di corso Iscrizione da cui si vogliono convalidare i sostenimenti', null, 6300, null);
						this.describeAColumn(table, 'iscrizionefrom_iddidprog', 'Didattica programmata Iscrizione da cui si vogliono convalidare i sostenimenti', null, 6500, null);
						this.describeAColumn(table, 'statuskind_title', 'Stato', null, 10200, 50);
						this.describeAColumn(table, 'pratica_protanno', 'Anno di protocollo', null, 12000, null);
						this.describeAColumn(table, 'pratica_protnumero', 'Numero di protocollo', null, 13000, null);
//$objCalcFieldConfig_segistpass$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddidprog", "idistanza", "idpratica", "idiscrizione", "idcorsostudio", "idistanzakind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('praticasegistpassview', new meta_praticasegistpassview('praticasegistpassview'));

	}());
