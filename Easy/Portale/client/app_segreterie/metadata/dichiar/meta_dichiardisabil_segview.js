(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiardisabil_segview() {
        MetaData.apply(this, ["dichiardisabil_segview"]);
        this.name = 'meta_dichiardisabil_segview';
    }

    meta_dichiardisabil_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiardisabil_segview,
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
					case 'disabil_seg':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'dichiar_date', 'Data', null, 30, null);
						this.describeAColumn(table, 'registry_title', 'Studente', null, 60, 101);
						this.describeAColumn(table, 'dichiardisabilkind_title', 'Titolo Topologia', null, 520, 50);
						this.describeAColumn(table, 'dichiardisabilkind_specification', 'Specifica Topologia', null, 520, 50);
						this.describeAColumn(table, 'dichiardisabilsuppkind_title', 'Supporto richiesto', null, 530, 50);
						this.describeAColumn(table, 'dichiar_disabil_percentuale', 'Percentuale', 'fixed.2', 550, null);
						this.describeAColumn(table, 'dichiar_disabil_permanente', 'Permanente (S/N)', null, 560, null);
						this.describeAColumn(table, 'dichiar_disabil_scadenza', 'Data scadenza', null, 570, null);
//$objCalcFieldConfig_disabil_seg$
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

    window.appMeta.addMeta('dichiardisabil_segview', new meta_dichiardisabil_segview('dichiardisabil_segview'));

	}());
