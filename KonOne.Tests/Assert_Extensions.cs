using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonOne.Tests {
  public static class AssertEx {

    public static void HaveSameContents<T>(T[] expected, IEnumerable<T> actual) {
      Assert.IsNotNull(actual);
      var actualList = new List<T>(actual);
      Assert.AreEqual(expected.Length, actualList.Count);

      actualList.Sort();
      for (int ix = 0; ix < expected.Length; ix++) {
        Assert.AreEqual(expected[ix], actualList[ix]);
      }
    }
  }
}
