(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didprogannodefaultview() {
        MetaData.apply(this, ["didprogannodefaultview"]);
        this.name = 'meta_didprogannodefaultview';
    }

    meta_didprogannodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprogannodefaultview,
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
						this.describeAColumn(table, 'didproganno_anno', 'Anno', null, 10, null);
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 20, 9);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "iddidprog", "iddidprogori", "idcorsostudio", "iddidproganno", "iddidprogcurr"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "didproganno_anno desc, aa desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('didprogannodefaultview', new meta_didprogannodefaultview('didprogannodefaultview'));

	}());
