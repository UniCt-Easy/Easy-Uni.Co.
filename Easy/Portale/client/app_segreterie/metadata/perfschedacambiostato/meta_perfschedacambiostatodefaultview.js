(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfschedacambiostatodefaultview() {
        MetaData.apply(this, ["perfschedacambiostatodefaultview"]);
        this.name = 'meta_perfschedacambiostatodefaultview';
    }

    meta_perfschedacambiostatodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfschedacambiostatodefaultview,
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
						this.describeAColumn(table, 'perfschedastatus_title', 'Da', null, 4200, 1024);
						this.describeAColumn(table, 'perfschedastatusto_title', 'A', null, 5200, 1024);
						this.describeAColumn(table, 'perfruolo_idperfruolo', 'Chi lo può cambiare', null, 6100, 50);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfschedacambiostato"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('perfschedacambiostatodefaultview', new meta_perfschedacambiostatodefaultview('perfschedacambiostatodefaultview'));

	}());
