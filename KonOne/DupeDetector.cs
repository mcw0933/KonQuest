using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KonOne {
  public static class DupeDetector {
    public static IEnumerable<char> GetDuplicatedCharsIn(string input) {

      if (string.IsNullOrWhiteSpace(input)) return new List<char>(0);

      var charCounts = new Dictionary<char, int>();

      foreach (var c in input) {
        if (!charCounts.ContainsKey(c)) {
          charCounts.Add(c, 1);
        } else {
          charCounts[c]++;
        }
      }

      var dupeChars = from c in charCounts.Keys where charCounts[c] > 1 select c;

      return dupeChars;
    }

    public static IEnumerable<string> GetDuplicatedWordsIn(string input) {
      if (string.IsNullOrWhiteSpace(input)) return new List<string>(0);

      var wordCounts = new Dictionary<string, int>();

      foreach (var w in GetWords(input.ToLowerInvariant())) {
        if (!string.IsNullOrWhiteSpace(w)) {
          if (!wordCounts.ContainsKey(w)) {
            wordCounts.Add(w, 1);
          } else {
            wordCounts[w]++;
          }
        }
      }

      if (wordCounts.Count <= 0) return new List<string>(0);

      var dupeWords = from w in wordCounts.Keys where wordCounts[w] > 1 select w;

      return dupeWords;
    }

    public static IEnumerable<string> GetWords(string input) {
      MatchCollection matches = Regex.Matches(input, @"[^\W\d](\w|[-']{0,1}(?=\w))*");

      foreach (Match match in matches) { yield return match.Value; }
    }
  }
}
