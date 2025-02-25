(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_learningagrstudsegview() {
        MetaData.apply(this, ["learningagrstudsegview"]);
        this.name = 'meta_learningagrstudsegview';
    }

    meta_learningagrstudsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_learningagrstudsegview,
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
						this.describeAColumn(table, 'learningagrkind_title', 'Tipologia di learning agreement', null, 5200, 50);
						this.describeAColumn(table, 'registryistitutiesteri_title', 'Istituto', null, 7300, 101);
						this.describeAColumn(table, 'learningagrstud_note', 'Note', null, 8000, -1);
						this.describeAColumn(table, 'learningagrstud_start', 'Data di inizio', null, 9000, null);
						this.describeAColumn(table, 'learningagrstud_stop', 'Data di fine', null, 10000, null);
						this.describeAColumn(table, 'department', 'Dipartimento estero', null, 15000, 2048);
						this.describeAColumn(table, 'eqf_level', 'Livello EQF', null, 16100, null);
						this.describeAColumn(table, 'struttura_title', 'Denominazione Dipartimento locale', null, 17100, 1024);
						this.describeAColumn(table, 'strutturakind_title', 'Tipologia Tipo Dipartimento locale', null, 17220, 50);
						this.describeAColumn(table, 'mobilityperiodtype_title', 'Periodo', null, 18200, 2048);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idbandomi", "idiscrizionebmi", "idlearningagrstud"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('learningagrstudsegview', new meta_learningagrstudsegview('learningagrstudsegview'));

	}());
