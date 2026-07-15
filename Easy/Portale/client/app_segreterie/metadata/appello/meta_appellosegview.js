(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_appellosegview() {
        MetaData.apply(this, ["appellosegview"]);
        this.name = 'meta_appellosegview';
    }

    meta_appellosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_appellosegview,
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
						this.describeAColumn(table, 'description', 'Descrizione', null, 1000, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 2000, 9);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idappello"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('appellosegview', new meta_appellosegview('appellosegview'));

	}());
