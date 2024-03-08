(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_iscrizionebmirequisito() {
        MetaData.apply(this, ["iscrizionebmirequisito"]);
        this.name = 'meta_iscrizionebmirequisito';
    }

    meta_iscrizionebmirequisito.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_iscrizionebmirequisito,
			superClass: MetaData.prototype,

			//$describeColumns$

			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_iscrizionebmirequisito");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$


				// metto i default
				var objRow = dt.newRow({
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('iscrizionebmirequisito', new meta_iscrizionebmirequisito('iscrizionebmirequisito'));

	}());
