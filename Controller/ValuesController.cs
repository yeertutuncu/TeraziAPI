using TeraziAPI.Utility;
using System;
using System.IO;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Results;
using System.Windows.Forms;

namespace TeraziAPI.Controller
{
    public class ValuesController : ApiController
    {
        #region HttpMethods

        /// <summary>
        [HttpGet]
        public JsonResult<WeightData> Get()
        {
            try
            {
                WeightData data = new WeightData();
                return Json(data.GetData());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public JsonResult<WeightData> EmptyData()
        {
            return Json(new WeightData()
            {
                Header1 = "",
                Header2 = "",
                Sign = "",
                Weight = 0,
                Unit = ""
            });
        }
        #endregion
    }
}