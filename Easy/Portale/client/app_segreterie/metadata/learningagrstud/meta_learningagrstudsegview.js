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
						this.describeAColumn(table, 'learningagrkind_title', 'Tipologia Tipologia di learning agreement', null, 50, 50);
						this.describeAColumn(table, 'learningagrkind_description', 'Descrizione Tipologia di learning agreement', null, 50, 256);
						this.describeAColumn(table, 'registryistitutiesteri_title', 'Istituto', null, 70, 101);
						this.describeAColumn(table, 'learningagrstud_note', 'Note', null, 80, -1);
						this.describeAColumn(table, 'learningagrstud_start', 'Data di inizio', null, 90, null);
						this.describeAColumn(table, 'learningagrstud_stop', 'Data di fine', null, 100, null);
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
