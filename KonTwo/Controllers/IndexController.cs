using KonTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KonTwo.Controllers {
  public class IndexController : Controller {
    public IndexController() : base() {
      ViewBag.SearchScopes = Enum.GetNames(typeof(SearchScopes));
    }

    public ActionResult Index() {
      return View();
    }

    [HttpPost]
    public JsonResult Search(SearchRequest request) {

      // TODO: implement search.  :)
      var results = SearchResults.DummyData;

      return Json(results);
    }

  }
}
