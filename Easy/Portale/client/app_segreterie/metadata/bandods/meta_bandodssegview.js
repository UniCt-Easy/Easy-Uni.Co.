(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_bandodssegview() {
        MetaData.apply(this, ["bandodssegview"]);
        this.name = 'meta_bandodssegview';
    }

    meta_bandodssegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandodssegview,
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
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'title', 'Titolo', null, 30, 1024);
						this.describeAColumn(table, 'bandods_description', 'Testo del bando', null, 40, -1);
						this.describeAColumn(table, 'bandods_fondo', 'Fondo', null, 50, 1024);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idbandods"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('bandodssegview', new meta_bandodssegview('bandodssegview'));

	}());
