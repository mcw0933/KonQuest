using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonTwo.Models {
  public class SearchResult {
    public string Title { get; set; }
    public Uri TitleLink { get; set; }
    public string Excerpt { get; set; }
  }
}