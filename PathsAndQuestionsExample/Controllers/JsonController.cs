using Microsoft.AspNetCore.Mvc;

namespace UploadExample.Controllers
{
    public class JsonController : Controller
    {
        public JsonResult FetchData()
        {
            return Json(new { Name = "Chuck", Age = -1, Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:SS") });
        }
    }
}
