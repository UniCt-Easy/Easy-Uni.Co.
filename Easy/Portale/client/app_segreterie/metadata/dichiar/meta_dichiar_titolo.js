(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiar_titolo() {
        MetaData.apply(this, ["dichiar_titolo"]);
        this.name = 'meta_dichiar_titolo';
    }

    meta_dichiar_titolo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiar_titolo,
			superClass: MetaData.prototype,

			//$describeColumns$

			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_dichiar_titolo");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$


				// metto i default
				var objRow = dt.newRow({
					idreg : 0,
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('dichiar_titolo', new meta_dichiar_titolo('dichiar_titolo'));

	}());
