(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tassaistanzaconfdefaultview() {
        MetaData.apply(this, ["tassaistanzaconfdefaultview"]);
        this.name = 'meta_tassaistanzaconfdefaultview';
    }

    meta_tassaistanzaconfdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tassaistanzaconfdefaultview,
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
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'costoscontodef_title', 'Costo', null, 30, 2024);
						this.describeAColumn(table, 'istanzakind_title', 'Tipo di istanza', null, 40, 50);
						this.describeAColumn(table, 'tassaistanzaconf_nullaosta', 'Nullaosta', null, 50, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idtassaistanzaconf"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('tassaistanzaconfdefaultview', new meta_tassaistanzaconfdefaultview('tassaistanzaconfdefaultview'));

	}());
