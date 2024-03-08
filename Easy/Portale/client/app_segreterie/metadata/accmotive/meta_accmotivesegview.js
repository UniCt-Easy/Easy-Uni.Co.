(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_accmotivesegview() {
        MetaData.apply(this, ["accmotivesegview"]);
        this.name = 'meta_accmotivesegview';
    }

    meta_accmotivesegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_accmotivesegview,
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
						this.describeAColumn(table, 'title', 'Causale', null, 20, 150);
						this.describeAColumn(table, 'accmotive_codemotive', 'Codice', null, 40, 50);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idaccmotive"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('accmotivesegview', new meta_accmotivesegview('accmotivesegview'));

	}());
