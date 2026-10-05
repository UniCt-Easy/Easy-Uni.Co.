(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pianostudiosegstudview() {
        MetaData.apply(this, ["pianostudiosegstudview"]);
        this.name = 'meta_pianostudiosegstudview';
    }

    meta_pianostudiosegstudview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pianostudiosegstudview,
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
					case 'segstud':
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 1100, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 1200, 9);
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede Didattica programmata', null, 1320, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 2000, 9);
						this.describeAColumn(table, 'registry_title', 'Studente', null, 3300, 101);
						this.describeAColumn(table, 'pianostudiostatus_title', 'Status', null, 4200, 50);
//$objCalcFieldConfig_segstud$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddidprog", "idiscrizione", "idcorsostudio", "idpianostudio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "segstud": {
						return "aa desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('pianostudiosegstudview', new meta_pianostudiosegstudview('pianostudiosegstudview'));

	}());
