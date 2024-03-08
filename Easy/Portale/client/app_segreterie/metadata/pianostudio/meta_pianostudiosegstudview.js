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
						this.describeAColumn(table, 'annoaccademico_aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 190, 1024);
						this.describeAColumn(table, 'annoaccademico_iscrizione_aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 10, 1024);
						this.describeAColumn(table, 'pianostudiostatus_title', 'Status', null, 50, 50);
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
