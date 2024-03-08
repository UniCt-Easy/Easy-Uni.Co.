(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tassacsingconfdefaultview() {
        MetaData.apply(this, ["tassacsingconfdefaultview"]);
        this.name = 'meta_tassacsingconfdefaultview';
    }

    meta_tassacsingconfdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tassacsingconfdefaultview,
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
						this.describeAColumn(table, 'tassacsingconf_costomax', 'Costo massimo', 'fixed.2', 30, null);
						this.describeAColumn(table, 'costoscontodef_title', 'Costo', null, 40, 2024);
						this.describeAColumn(table, 'costoscontodef_tassacsingconf_title', 'Costo corsi speciali', null, 50, 2024);
						this.describeAColumn(table, 'costoscontodef_tassacsingconf_title', 'Sconto', null, 60, 2024);
						this.describeAColumn(table, 'tassacsingconf_numerosconto', 'Numero di insegnamenti per cui si applica lo sconto', null, 70, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idtassacsingconf"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('tassacsingconfdefaultview', new meta_tassacsingconfdefaultview('tassacsingconfdefaultview'));

	}());
