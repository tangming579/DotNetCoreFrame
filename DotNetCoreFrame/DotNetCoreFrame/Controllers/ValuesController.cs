using DotNetCoreFrame.Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreFrame.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost, Route("POST")]
        public ActionResult Post([FromBody]JObject value)
        {
            ActionResult jRst = new ContentResult();
            JToken oRst = GetJsonData(value);
            jRst = Content((oRst) + "", "application/json; charset=utf-8");
            return jRst;
        }

        public static JToken GetJsonData(JObject value)
        {
            JToken oRst = new JObject();
            try
            {
                var iParam = value.ToObject<iSagyParameter>();
                var strCriteria = iParam.Criteria + "";
                var criteria = value["Criteria"];

                oRst[Constants.Result] = Constants.Failed;
                if (RestmethodManager.dic.ContainsKey(iParam.Method))
                {
                    var instance = RestmethodManager.dic[iParam.Method];

                    oRst = instance(criteria);
                }
                else
                    oRst[Constants.Reason] = "无此名称接口！";
            }
            catch (Exception exp)
            {
                oRst[Constants.Reason] = exp.Message;
                //LogHelper.Error("请求错误：", exp);
            }
            return oRst;
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public class iSagyParameter
        {
            private string method;
            public string Method
            {
                get { return method?.Trim(); }
                set { method = value; }
            }
            public JObject Criteria { get; set; }
        }
    }
}
