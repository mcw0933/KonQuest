using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KonTwo.Models {
  public class SearchResults : IEnumerable<SearchResult> {
    private SearchResults(params SearchResult[] results) {
      innerList.AddRange(results);
    }

    private List<SearchResult> innerList = new List<SearchResult>();
    
    public static SearchResults DummyData {
      get {
        return new SearchResults(
          new SearchResult() { Title = "Bing", TitleLink = new Uri("http://bing.com"), Excerpt = "Maybe you should use a real search engine?" },
          new SearchResult() { Title = "Foo Bar", TitleLink = new Uri("http://foo.com"), Excerpt = "Foo is the bar of baz quux..." }
          );
      }
    }

    public IEnumerator<SearchResult> GetEnumerator() {
      return innerList.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
      return innerList.GetEnumerator();
    }
  }
}