(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didprogdefaultview() {
        MetaData.apply(this, ["didprogdefaultview"]);
        this.name = 'meta_didprogdefaultview';
    }

    meta_didprogdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprogdefaultview,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 1000, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 2000, 9);
						this.describeAColumn(table, 'sede_title', 'Sede', null, 19200, 1024);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddidprog", "idcorsostudio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc, aa desc, sede_title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('didprogdefaultview', new meta_didprogdefaultview('didprogdefaultview'));

	}());
