(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_diderogdefaultview() {
        MetaData.apply(this, ["diderogdefaultview"]);
        this.name = 'meta_diderogdefaultview';
    }

    meta_diderogdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_diderogdefaultview,
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
					case 'default':
						this.describeAColumn(table, 'corsostudio_title', 'Denominazione Corso di studio', null, 1100, 1024);
						this.describeAColumn(table, 'corsostudio_annoistituz', 'Anno accademico di istituzione Corso di studio', null, 1600, null);
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 2000, 9);
						this.describeAColumn(table, 'sede_title', 'Identificativo', null, 3200, 1024);
						this.describeAColumn(table, 'diderog_inesaurimento', 'Inesaurimento', null, 4000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "idsede", "idcorsostudio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('diderogdefaultview', new meta_diderogdefaultview('diderogdefaultview'));

	}());
