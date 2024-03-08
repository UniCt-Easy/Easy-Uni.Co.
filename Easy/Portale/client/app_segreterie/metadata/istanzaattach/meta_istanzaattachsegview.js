(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanzaattachsegview() {
        MetaData.apply(this, ["istanzaattachsegview"]);
        this.name = 'meta_istanzaattachsegview';
    }

    meta_istanzaattachsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzaattachsegview,
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
						this.describeAColumn(table, 'attach_filename', 'Nome del file', null, 30, 512);
						this.describeAColumn(table, 'attach_size', 'Dimensione', null, 50, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idattach", "idistanza", "idistanzakind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('istanzaattachsegview', new meta_istanzaattachsegview('istanzaattachsegview'));

	}());
