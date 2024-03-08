(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_allegatirichiestidefaultview() {
        MetaData.apply(this, ["allegatirichiestidefaultview"]);
        this.name = 'meta_allegatirichiestidefaultview';
    }

    meta_allegatirichiestidefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_allegatirichiestidefaultview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, -1);
						this.describeAColumn(table, 'allegatirichiesti_active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'allegatirichiesti_sortcode', 'Codice identificativo', null, 40, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idallegatirichiesti"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('allegatirichiestidefaultview', new meta_allegatirichiestidefaultview('allegatirichiestidefaultview'));

	}());
