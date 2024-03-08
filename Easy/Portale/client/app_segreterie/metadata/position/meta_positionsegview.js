(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_positionsegview() {
        MetaData.apply(this, ["positionsegview"]);
        this.name = 'meta_positionsegview';
    }

    meta_positionsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_positionsegview,
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
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, 50);
						this.describeAColumn(table, 'position_active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'position_codeposition', 'Codice', null, 40, 20);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idposition"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('positionsegview', new meta_positionsegview('positionsegview'));

	}());
