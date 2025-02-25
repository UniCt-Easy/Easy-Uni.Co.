(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiarisee_segview() {
        MetaData.apply(this, ["dichiarisee_segview"]);
        this.name = 'meta_dichiarisee_segview';
    }

    meta_dichiarisee_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiarisee_segview,
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
					case 'isee_seg':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 1000, 9);
						this.describeAColumn(table, 'dichiar_date', 'Data', null, 3000, null);
						this.describeAColumn(table, 'registry_title', 'Studente', null, 6300, 101);
						this.describeAColumn(table, 'dichiar_isee_anno', 'Anno', null, 51000, null);
						this.describeAColumn(table, 'dichiar_isee_conforme', 'Conformità', null, 52000, null);
						this.describeAColumn(table, 'dichiar_isee_dataauthdiff', 'Data autorizzazione', null, 53000, null);
						this.describeAColumn(table, 'dichiar_isee_datasottoscriz', 'Data di sottoscrizione', null, 54000, null);
						this.describeAColumn(table, 'dichiar_isee_enterilascio', 'Ente del rilascio', null, 55000, 50);
						this.describeAColumn(table, 'dichiar_isee_isee', 'Valore ISEE', 'fixed.2', 58000, null);
						this.describeAColumn(table, 'dichiar_isee_numeroprot', 'Numero protocollo dell\'ente di rilascio', null, 59000, 50);
//$objCalcFieldConfig_isee_seg$
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

    window.appMeta.addMeta('dichiarisee_segview', new meta_dichiarisee_segview('dichiarisee_segview'));

	}());
