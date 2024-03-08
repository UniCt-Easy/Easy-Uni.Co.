(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiaraltre_segview() {
        MetaData.apply(this, ["dichiaraltre_segview"]);
        this.name = 'meta_dichiaraltre_segview';
    }

    meta_dichiaraltre_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiaraltre_segview,
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
					case 'altre_seg':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'dichiar_date', 'Data', null, 30, null);
						this.describeAColumn(table, 'registry_title', 'Studente', null, 60, 101);
						this.describeAColumn(table, 'dichiaraltrekind_title', 'Tipo di dichiarazione', null, 530, 256);
//$objCalcFieldConfig_altre_seg$
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

    window.appMeta.addMeta('dichiaraltre_segview', new meta_dichiaraltre_segview('dichiaraltre_segview'));

	}());
