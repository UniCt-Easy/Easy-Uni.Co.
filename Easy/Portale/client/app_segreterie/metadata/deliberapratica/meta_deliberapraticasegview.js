(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_deliberapraticasegview() {
        MetaData.apply(this, ["deliberapraticasegview"]);
        this.name = 'meta_deliberapraticasegview';
    }

    meta_deliberapraticasegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_deliberapraticasegview,
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
					case 'seg':
						this.describeAColumn(table, 'pratica_idreg', 'Studente', null, 7100, null);
						this.describeAColumn(table, 'pratica_idiscrizione', 'Iscrizione', null, 7200, null);
						this.describeAColumn(table, 'pratica_idistanzakind', 'Tipologia di istanza', null, 8800, null);
						this.describeAColumn(table, 'pratica_idstatuskind', 'Stato', null, 8900, null);
						this.describeAColumn(table, 'pratica_protnumero', 'Numero di protocollo', null, 9000, null);
						this.describeAColumn(table, 'pratica_protanno', 'Anno di protocollo', null, 9100, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddidprog", "idistanza", "idpratica", "iddelibera", "idiscrizione", "idcorsostudio", "idistanzakind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('deliberapraticasegview', new meta_deliberapraticasegview('deliberapraticasegview'));

	}());
