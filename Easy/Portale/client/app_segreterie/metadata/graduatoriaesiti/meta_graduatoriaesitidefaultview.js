(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_graduatoriaesitidefaultview() {
        MetaData.apply(this, ["graduatoriaesitidefaultview"]);
        this.name = 'meta_graduatoriaesitidefaultview';
    }

    meta_graduatoriaesitidefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_graduatoriaesitidefaultview,
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
						this.describeAColumn(table, 'datachiusura', 'Data di chiusura', 'g', 20, null);
						this.describeAColumn(table, 'graduatoriaesiti_provvisoria', 'Provvisoria', null, 40, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcorsostudio", "idgraduatoriaesiti"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('graduatoriaesitidefaultview', new meta_graduatoriaesitidefaultview('graduatoriaesitidefaultview'));

	}());
