(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_strutturaperfelenchiview() {
        MetaData.apply(this, ["strutturaperfelenchiview"]);
        this.name = 'meta_strutturaperfelenchiview';
    }

    meta_strutturaperfelenchiview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_strutturaperfelenchiview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'perfelenchi':
						this.describeAColumn(table, 'title', 'Denominazione', null, 1000, 1024);
						this.describeAColumn(table, 'strutturaparent_title', 'U.O. madre', null, 9100, 1024);
						this.describeAColumn(table, 'struttura_active', 'Attivo', null, 16000, null);
//$objCalcFieldConfig_perfelenchi$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idstruttura"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "perfelenchi": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('strutturaperfelenchiview', new meta_strutturaperfelenchiview('strutturaperfelenchiview'));

	}());
