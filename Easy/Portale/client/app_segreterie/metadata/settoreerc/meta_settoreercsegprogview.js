(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_settoreercsegprogview() {
        MetaData.apply(this, ["settoreercsegprogview"]);
        this.name = 'meta_settoreercsegprogview';
    }

    meta_settoreercsegprogview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_settoreercsegprogview,
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
					case 'segprog':
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2048);
//$objCalcFieldConfig_segprog$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idsettoreerc"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "segprog": {
						return "";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('settoreercsegprogview', new meta_settoreercsegprogview('settoreercsegprogview'));

	}());
