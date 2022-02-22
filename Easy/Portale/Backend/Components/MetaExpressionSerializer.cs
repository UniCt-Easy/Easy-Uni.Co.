
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using q= metadatalibrary.MetaExpression;
using System.Data;
using metadatalibrary;

namespace Backend.Components {

    /// <summary>
    /// Transform MetaExpressions into JSon and viceversa
    /// </summary>
    public class MetaExpressionSerializer {

        private static readonly string c_data_format = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'";


        private static JObject serializeConstant(object o) {
            if (o == null) {
                return new JObject {{"value", null}};
            }

            var res = new JObject {{"value", JToken.FromObject(o)}};

            // gestisco il caso l'oggetto sia una data, lo formatto nel formato deciso
            if (o is DateTime) {
                var objDate = ((DateTime) o).ToString(c_data_format);
                res = new JObject {{"value", JToken.FromObject(objDate)}};
            }

            return res;
        }

        /// <summary>
        /// Create a MetaExpression / value / array from a serialized version
        /// </summary>
        /// <param name="jObj"></param>
        /// <returns></returns>
        public static object deserialize(JToken jObj) {
            if (jObj == null) return null;

            // se arrivo al value torno il value
            if (jObj["value"] != null) {
                if (jObj["value"].GetType() == typeof(JValue)) {
                    return ((JValue) jObj["value"]).Value; //Nino: perchè non semplicemente jObj.value?
                }

                // caso mcmp, in cui il 2o prm è un JObject altrimenti andrebbe in errore
                if (jObj["value"].GetType() == typeof(JObject)) {
                    Dictionary<string, object> dictFromJObject = new Dictionary<string, object>();
                    // costrusice la dict con le chiavi valori del JObject
                    var obj = (JObject) JsonConvert.DeserializeObject(jObj["value"].ToString());
                    obj.Properties()._forEach(cond => dictFromJObject.Add(cond.Name, ((JValue) cond.Value).Value));
                    // torno la dictionary ben popolata
                    return dictFromJObject;
                }
            }

            //Manca gestione array di costanti
            // va gestito semplicemente come un array di metaexpressions
            if (jObj["array"] != null) {
                return jObj["array"].Select(deserialize).ToArray();
            }

            // altrimenti  itero sulla nuova MetaExpression
            if (jObj["args"] != null && jObj["name"] != null) {
                q m = deserialize((string) jObj["name"], jObj["args"]);
                if (jObj["alias"] != null) {
                    m.Alias = (string) jObj["alias"];
                }

                return m;
            }

            if (jObj.Root != null) {
                throw new ArgumentException("Bad expression: " + jObj.Root.ToString());
            }
            else {
                throw new ArgumentException("Bad expression, unable to deserialize MetaExpression");
            }

        }

        /// <summary>
        /// Delegate used to transform an array of parameters
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public delegate q DeserializeExpression(JArray args);

        private static readonly Dictionary<string, DeserializeExpression> LookupDeserialize =
            new Dictionary<string, DeserializeExpression>() {
                {"constant", getMetaExpressionConst},
                {"eq", getMetaExpressionEq},
                {"field", getMetaExpressionField},
                {"like", getMetaExpressionLike},
                {"add", getMetaExpressionAdd},
                {"sub", getMetaExpressionSub},
                {"div", getMetaExpressionDiv},
                {"mul", getMetaExpressionMul},
                {"not", getMetaExpressionNot},
                {"minus", getMetaExpressionMinus},
                {"bitSet", getMetaExpressionbitSet},
                {"bitClear", getMetaExpressionbitClear},
                {"or", getMetaExpressionOr},
                {"and", getMetaExpressionAnd},
                {"bitwiseAnd", getMetaExpressionbitAnd},
                {"bitwiseOr", getMetaExpressionbitOr},
                {"bitwiseXor", getMetaExpressionbitXor},
                {"ne", getMetaExpressionNe},
                {"gt", getMetaExpressionGt},
                {"ge", getMetaExpressionGe},
                {"lt", getMetaExpressionLt},
                {"le", getMetaExpressionLe},
                {"cmpAs", getMetaExpressioncmpAs},
                {"mcmp", getMetaExpressionmCmp},
                {"isNull", getMetaExpressionisNull},
                {"isNotNull", getMetaExpressionisNotNull},
                {"isNullFn", getMetaExpressionisNullFn},
                {"doPar", getMetaExpressiondoPar},
                {"isIn", getMetaExpressionfieldIn},
                {"isNotIn", getMetaExpressionfieldNotIn},
                {"context", getMetaExpressionContext},
                {"context.sys", getMetaExpressionSys},
                {"context.usr", getMetaExpressionUsr},
            };

        /// <summary>
        /// Deserialize a function- MetaExpression from name and args. 
        /// </summary>
        /// <param name="name">string  name of MetaExpression</param>
        /// <param name="args">JToken with the parameters of the MetaExpression to build</param>
        /// <returns>MetaExpression</returns>
        static q deserialize(string name, JToken args) {
            if (LookupDeserialize.ContainsKey(name)) return LookupDeserialize[name]((JArray) args);
            return null;
        }

        /// <summary>
        /// Build the "Eq" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for Eq MetaExpresion</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionEq(JArray args) {
            var obj = getNParams("eq", args, 2);
            return q.eq(obj[0], obj[1]);
        }

        /// <summary>
        /// Deserialize parameters for a function
        /// </summary>
        /// <param name="name">Name of the function to which the parameters are applid</param>
        /// <param name="par">Array of parameters</param>
        /// <param name="expected">Expected number of parameters in the array</param>
        /// <returns></returns>
        static object[] getNParams(string name, JArray par, int expected) {
            if (par.Count != expected) {
                throw new ArgumentException($"Function {name} must have {expected} parameters");
            }

            return par.Select(deserialize).ToArray();
        }


        /// <summary>
        /// Deserialize parameters for a function
        /// </summary>
        /// <param name="name">Name of the function to which the parameters are applid</param>
        /// <param name="par">Array of parameters</param>
        /// <param name="expected">Expected minimum number of parameters in the array</param>
        /// <returns></returns>
        static object[] getAtLeastNParams(string name, JArray par, int expected) {
            if (par.Count < expected) {
                throw new ArgumentException($"Function {name} must have at least {expected} parameters");
            }

            return par.Select(deserialize).ToArray();
        }


        /// <summary>
        /// Build the "Like" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for Like MetaExpresion</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionLike(JArray args) {
            var obj = getNParams("like", args, 2);
            return q.like(obj[0], obj[1]);
        }

        /// <summary>
        /// Build the "Field" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for Filed MetaExpresion</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionField(JArray args) {
            var obj = getNParams("field", args, 1);
            return q.field(obj[0].ToString());
        }

        /// <summary>
        /// Build the "Field" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for Filed MetaExpresion</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionConst(JArray args) {
            var obj = getNParams("constant", args, 1);
            return q.constant(obj[0]);
        }


        /// <summary>
        /// Build the "Add" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for Add MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionAdd(JArray args) {
            var pars = getAtLeastNParams("add", args, 2);
            return q.add(pars);
        }

        /// <summary>
        /// Build the "sub" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for sub MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionSub(JArray args) {
            var pars = getNParams("sub", args, 2);
            return q.sub(pars[0], pars[1]);
        }

        /// <summary>
        /// Build the "div" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for div MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionDiv(JArray args) {
            var pars = getNParams("div", args, 2);
            return q.div(pars[0], pars[1]);
        }

        /// <summary>
        /// Build the "mul" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for mul MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionMul(JArray args) {
            var pars = getAtLeastNParams("mul", args, 2);
            return q.mul(pars);
        }

        /// <summary>
        /// Build the "not" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for not MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionNot(JArray args) {
            var pars = getNParams("not", args, 1);
            return q.not(pars[0]);
        }

        /// <summary>
        /// Build the "minus" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for not MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionMinus(JArray args) {
            var pars = getNParams("minus", args, 1);
            return q.minus(pars[0]);
        }

        /// <summary>
        /// Build the "isNull" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for isNull MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionisNull(JArray args) {
            var pars = getNParams("isnull", args, 1);
            return q.isNull(pars[0]);
        }

        /// <summary>
        /// Build the "isNotNull" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for isNotNull MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionisNotNull(JArray args) {
            var pars = getNParams("isNotNull", args, 1);
            return q.isNotNull(pars[0]);
        }

        /// <summary>
        /// Build the "bitSet" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for bitSet MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionbitSet(JArray args) {
            var pars = getNParams("bitSet", args, 2);
            object v = pars[1];
            if (pars[1].GetType().Name == "MetaExpressionConst") {
                q m = (q) pars[1];
                v = m.apply();
                if (v.GetType() != typeof(long) && v.GetType() != typeof(int)) {
                    throw new ArgumentException("Func bitClear() second parameter must be an int");
                }
            }
            else if (pars[1].GetType() != typeof(long) && pars[1].GetType() != typeof(int)) {
                throw new ArgumentException("Func bitSet() second parameter must be an int");
            }

            return q.bitSet(pars[0], Convert.ToInt32(v));
        }

        /// <summary>
        /// Build the "bitClear" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for bitClear MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionbitClear(JArray args) {
            var pars = getNParams("bitClear", args, 2);
            object v = pars[1];
            if (pars[1].GetType().Name == "MetaExpressionConst") {
                q m = (q) pars[1];
                v = m.apply();
                if (v.GetType() != typeof(long) && v.GetType() != typeof(int)) {
                    throw new ArgumentException("Func bitClear() second parameter must be an int");
                }
            }
            else if (pars[1].GetType() != typeof(long) && pars[1].GetType() != typeof(int)) {
                throw new ArgumentException("Func bitClear() second parameter must be an int");
            }

            return q.bitClear(pars[0], Convert.ToInt32(v));
        }

        /// <summary>
        /// Build the "Or" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for Or MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionOr(JArray args) {
            var pars = getAtLeastNParams("or", args, 1);
            if (pars.Length == 1) {
                if (pars[0] is Array) {
                    var arrClause = (object[]) pars[0];
                    return q.or(arrClause);
                }
            }

            return q.or(pars);
        }

        /// <summary>
        /// Build the "And" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for And MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionAnd(JArray args) {

            var pars = getAtLeastNParams("and", args, 1);
            if (pars.Length == 1) {

                if (pars[0] is Array) {
                    var arrClause = (object[]) pars[0];
                    return q.and(arrClause);
                }

            }

            return q.and(pars);
        }

        /// <summary>
        /// Build the "bitAnd" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for bitAnd MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionbitAnd(JArray args) {
            var pars = getAtLeastNParams("bitAnd", args, 2);
            return q.bitAnd(pars);
        }

        /// <summary>
        /// Build the "bitOr" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for bitOr MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionbitOr(JArray args) {
            var pars = getAtLeastNParams("bitOr", args, 2);
            return q.bitOr(pars);
        }

        /// <summary>
        /// Build the "bitXor" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for bitOr MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionbitXor(JArray args) {
            var pars = getAtLeastNParams("bitXor", args, 2);
            return q.bitXor(pars);
        }

        /// <summary>
        /// Build the "ne" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for ne MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionNe(JArray args) {
            var pars = getNParams("ne", args, 2);
            return q.ne(pars[0], pars[1]);
        }

        /// <summary>
        /// Build the "gt" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for gt MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionGt(JArray args) {
            var pars = getNParams("gt", args, 2);
            return q.gt(pars[0], pars[1]);
        }

        /// <summary>
        /// Build the "ge" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for ge MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionGe(JArray args) {
            var pars = getNParams("ge", args, 2);
            return q.ge(pars[0], pars[1]);
        }

        /// <summary>
        /// Build the "lt" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for lt MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionLt(JArray args) {
            var pars = getNParams("lt", args, 2);
            return q.lt(pars[0], pars[1]);
        }

        /// <summary>
        /// Build the "le" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for le MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionLe(JArray args) {
            var pars = getNParams("le", args, 2);
            return q.le(pars[0], pars[1]);
        }



        /// <summary>
        /// Build the "cmpAs" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for cmpAs MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressioncmpAs(JArray args) {
            var pars = getNParams("cmpAs", args, 3);

            if (pars[1].GetType().Name != "String") {
                throw new ArgumentException("Func cmpAs() second parameter must be a string");
            }

            if (pars[2].GetType().Name != "String") {
                throw new ArgumentException("Func cmpAs() third parameter must be a string");
            }

            return q.cmpAs(pars[0], (string) pars[1], (string) pars[2]);
        }

        /// <summary>
        /// Build the "mCmp" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for mCmp MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionmCmp(JArray args) {
            var pars = getAtLeastNParams("mCmp", args, 2);
            var dict = new Dictionary<string, object>();
            var keys = pars[0] as object[];
            if (keys == null) {
                throw new ArgumentException("Func mCmp() first parameter must be an array");
            }

            // è il caso lato js passi un plain object con coppie "key:val" --> la des mi trasforma quel jObject in un dict
            if (pars[1] is Dictionary<string, object>) {
                dict = (Dictionary<string, object>) pars[1];
            }
            else {
                // altrimenti array di object
                var values = pars[1] as object[];

                if (values == null) {
                    throw new ArgumentException("Func mCmp() second parameter must be an array");
                }

                var valuesDict = new Dictionary<string, object>();
                for (int i = 0; i < keys.Length; i++) {
                    dict[keys[i].ToString()] = values[i];
                }
            }

            var res = q.mCmp(dict, (from k in keys select k.ToString()).ToArray());
            if (pars.Length == 3) res.Alias = pars[2].ToString();
            return res;
        }

        /// <summary>
        /// Build the "isNullFn" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for isNullFn MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionisNullFn(JArray args) {
            object[] pars = getNParams("isNullFn", args, 2);
            return q.isNullFn(pars[0], pars[1]);
        }

        /// <summary>
        /// Build the "fieldIn" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for fieldIn MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionfieldIn(JArray args) {
            object[] pars = getAtLeastNParams("fieldIn", args, 2);
            return q.fieldIn(pars[0].ToString(), (Object[]) pars[1]);

        }

        /// <summary>
        /// Build the "fieldNotIn" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for fieldNotIn MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionfieldNotIn(JArray args) {
            object[] pars = getAtLeastNParams("fieldNotIn", args, 2);
            return q.fieldNotIn(pars[0].ToString(), (Object[]) pars[1]);

        }

        /// <summary>
        /// Build the "doPar" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for doPar MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressiondoPar(JArray args) {
            var obj = getNParams("doPar", args, 1)[0] as q;
            return q.doPar(obj);
        }

        /// <summary>
        /// Build the "sys" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for lt MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionSys(JArray args) {
            var pars = getNParams("sys", args, 1);
            return q.sys(pars[0].ToString());
        }

        /// <summary>
        /// Build the "usr" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for lt MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionUsr(JArray args) {
            var pars = getNParams("usr", args, 1);
            return q.usr(pars[0].ToString());
        }

        /// <summary>
        /// Build the "lt" MetaExpression with the parameter in args. 
        /// </summary>
        /// <param name="args">Array of parameters for lt MetaExpression</param>
        /// <returns>MetaExpression</returns>
        private static q getMetaExpressionContext(JArray args) {
            var pars = getNParams("context", args, 1);
            return q.context(pars[0].ToString());
        }

        /// <summary>
        /// Serializes a MetaExpression
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static JObject serialize(object o) {
            JObject root = new JObject();

            if (o is q) {
                q m = o as q;
                switch (m.Name) {
                    case "field":
                        root.Add("name", m.Name);
                        addAlias(m, root);
                        var fieldArgArray = new JArray(serializeConstant(m.FieldName));
                        root.Add("args", fieldArgArray);
                        break;
                    case "like":
                        root.Add("name", m.Name);
                        addAlias(m, root);
                        root.Add("args", getArgs(m));
                        break;
                    case "const":
                        root.Add("name", "constant");
                        addAlias(m, root);
                        root.Add("args", new JArray(serializeConstant(m.apply())));
                        break;
                    case "mcmp":
                        string[] fields = (string[]) q.getField("fields", m);
                        object sample = q.getField("sample", m);
                        var cmpArray = (from field in fields select (object) q.eq(field, q.getField(field, sample)))
                            .ToArray();
                        return serialize(q.and(cmpArray));
                    case "cmpAs":
                        object sourceVal = q.getField("sourceVal", m);
                        string dest = (string) q.getField("dest", m);
                        return serialize(q.eq(dest, sourceVal));
                    case "fieldIn":
                        root.Add("name", "isIn");
                        addAlias(m, root);
                        root.Add("args", getArgsfieldIn(m));
                        break;
                    case "fieldNotIn":
                        root.Add("name", "isNotIn");
                        addAlias(m, root);
                        root.Add("args", getArgsfieldIn(m));
                        break;
                    case "context.sys":
                        root.Add("name", m.Name);
                        addAlias(m, root);
                        root.Add("args", getArgsByEnvName(m));
                        break;
                    case "context.usr":
                        root.Add("name", m.Name);
                        addAlias(m, root);
                        root.Add("args", getArgsByEnvName(m));
                        break;
                    case "context":
                        root.Add("name", m.Name);
                        addAlias(m, root);
                        root.Add("args", getArgsByEnvName(m));
                        break;
                    case "&":
                        root.Add("name", "bitwiseAnd");
                        addAlias(m, root);
                        root.Add("args", getArgs(m));
                        break;
                    case "|":
                        root.Add("name", "bitwiseOr");
                        addAlias(m, root);
                        root.Add("args", getArgs(m));
                        break;
                    case "^":
                        root.Add("name", "bitwiseXor");
                        addAlias(m, root);
                        root.Add("args", getArgs(m));
                        break;
                    case "eq":
                    case "add":
                    case "sub":
                    case "div":
                    case "mul":
                    case "not":
                    case "minus":
                    case "bitSet":
                    case "bitClear":
                    case "or":
                    case "and":
                    case "ne":
                    case "gt":
                    case "ge":
                    case "lt":
                    case "le":
                    case "fromObject":
                    case "isNull":
                    case "isNotNull":
                    case "isNullFn":
                    case "doPar":
                        root.Add("name", m.Name);
                        addAlias(m, root);
                        root.Add("args", getArgs(m));
                        break;
                    case "null":
                        root.Add("value", null);
                        addAlias(m, root);
                        break;
                }

                return root;
            }

            var a = o as Array;
            if (a != null) {
                var arr = new JArray(from object item in a select serialize(item));
                root.Add("array", arr);
                return root;
            }

            root.Add("value", JObject.FromObject(o));
            return root;
        }

        private static void addAlias(q m, JObject root) {
            if (m.Alias != null)
                root.Add("alias", m.Alias);
        }

        private static JArray getArgs(q mExp) {
            var arrayArgs = new JArray();
            foreach (q m in mExp.Parameters) {
                arrayArgs.Add(serialize(m));
            }

            return arrayArgs;
        }

        private static JArray getArgsByEnvName(q mExp) {
            var arrayArgs = new JArray {serializeConstant(q.getField("EnvName", mExp))};

            return arrayArgs;
        }

        private static JArray getArgsfieldIn(q mExp) {
            var arrayArgs = new JArray {serializeConstant(q.getField("sourceColumn", mExp))};
            object[] parObject = (object[]) q.getField("parObject", mExp);
            foreach (var el in parObject) {
                arrayArgs.Add(serializeConstant(el));
            }

            return arrayArgs;
        }

    }

}
