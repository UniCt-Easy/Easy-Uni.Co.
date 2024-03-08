(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_affidamentoattachseganagview() {
        MetaData.apply(this, ["affidamentoattachseganagview"]);
        this.name = 'meta_affidamentoattachseganagview';
    }

    meta_affidamentoattachseganagview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_affidamentoattachseganagview,
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
					case 'seganag':
						this.describeAColumn(table, 'attach_filename', 'Allegato', null, 30, 512);
//$objCalcFieldConfig_seganag$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "idattach", "idcanale", "iddidprog", "idattivform", "iddidprogori", "idaffidamento", "idcorsostudio", "iddidproganno", "iddidprogcurr", "idreg_docenti", "iddidprogporzanno"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('affidamentoattachseganagview', new meta_affidamentoattachseganagview('affidamentoattachseganagview'));

	}());
