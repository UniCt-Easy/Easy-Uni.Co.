(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registryclassaziendeview() {
        MetaData.apply(this, ["registryclassaziendeview"]);
        this.name = 'meta_registryclassaziendeview';
    }

    meta_registryclassaziendeview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryclassaziendeview,
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
					case 'aziende':
						this.describeAColumn(table, 'idregistryclass', 'Codice', null, 10, 2);
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, 150);
						this.describeAColumn(table, 'registryclass_active', 'Attivo', null, 30, null);
//$objCalcFieldConfig_aziende$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idregistryclass"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('registryclassaziendeview', new meta_registryclassaziendeview('registryclassaziendeview'));

	}());
