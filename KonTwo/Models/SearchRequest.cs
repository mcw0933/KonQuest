using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonTwo.Models {
  public class SearchRequest {
    public string SearchText { get; set; }
    public SearchScopes Scope { get; set; }
  }

  public enum SearchScopes {
    Web,
    Images,
    News
  }
}