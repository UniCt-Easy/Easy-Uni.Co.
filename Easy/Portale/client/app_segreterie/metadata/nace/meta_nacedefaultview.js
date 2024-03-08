(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_nacedefaultview() {
        MetaData.apply(this, ["nacedefaultview"]);
        this.name = 'meta_nacedefaultview';
    }

    meta_nacedefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_nacedefaultview,
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
						this.describeAColumn(table, 'idnace', 'Codice', null, 10, 50);
						this.describeAColumn(table, 'nace_activity', 'Activity', null, 20, -1);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idnace"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('nacedefaultview', new meta_nacedefaultview('nacedefaultview'));

	}());
