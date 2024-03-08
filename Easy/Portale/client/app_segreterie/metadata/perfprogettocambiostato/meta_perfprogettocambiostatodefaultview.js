(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettocambiostatodefaultview() {
        MetaData.apply(this, ["perfprogettocambiostatodefaultview"]);
        this.name = 'meta_perfprogettocambiostatodefaultview';
    }

    meta_perfprogettocambiostatodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettocambiostatodefaultview,
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
						this.describeAColumn(table, 'perfprogettostatus_title', 'Da', null, 3200, 1024);
						this.describeAColumn(table, 'perfprogettostatusto_title', 'A', null, 4200, 1024);
						this.describeAColumn(table, 'perfruolo_idperfruolo', 'Chi lo può cambiare', null, 11100, 50);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfprogettocambiostato"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettocambiostatodefaultview', new meta_perfprogettocambiostatodefaultview('perfprogettocambiostatodefaultview'));

	}());
