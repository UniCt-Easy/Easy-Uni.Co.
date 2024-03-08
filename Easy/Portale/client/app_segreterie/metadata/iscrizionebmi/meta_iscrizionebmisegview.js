(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_iscrizionebmisegview() {
        MetaData.apply(this, ["iscrizionebmisegview"]);
        this.name = 'meta_iscrizionebmisegview';
    }

    meta_iscrizionebmisegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_iscrizionebmisegview,
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
						this.describeAColumn(table, 'iscrizionebmi_data', 'Data', 'g', 2000, null);
						this.describeAColumn(table, 'registry_title', 'Identificativo', null, 3300, 101);
						this.describeAColumn(table, 'iscrizione_aa', 'Anno accademico Iscrizione', null, 5100, 9);
						this.describeAColumn(table, 'iscrizione_anno', 'Anno di corso Iscrizione', null, 5300, null);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 5500, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idbandomi", "idiscrizionebmi"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "registry_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('iscrizionebmisegview', new meta_iscrizionebmisegview('iscrizionebmisegview'));

	}());
