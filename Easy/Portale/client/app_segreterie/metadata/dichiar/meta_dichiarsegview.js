(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiarsegview() {
        MetaData.apply(this, ["dichiarsegview"]);
        this.name = 'meta_dichiarsegview';
    }

    meta_dichiarsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiarsegview,
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
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'dichiarkind_title', 'Tipologia', null, 10, 50);
						this.describeAColumn(table, 'dichiar_date', 'Data', null, 30, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddichiar"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('dichiarsegview', new meta_dichiarsegview('dichiarsegview'));

	}());
