using KonOne;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KonOne.Tests {
  [TestClass()]
  public class DupeDetectorTest {

    #region Boilerplate
    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext {
      get {
        return testContextInstance;
      }
      set {
        testContextInstance = value;
      }
    }

    // 
    //You can use the following additional attributes as you write your tests:
    //
    //Use ClassInitialize to run code before running the first test in the class
    //[ClassInitialize()]
    //public static void MyClassInitialize(TestContext testContext)
    //{
    //}
    //
    //Use ClassCleanup to run code after all tests in a class have run
    //[ClassCleanup()]
    //public static void MyClassCleanup()
    //{
    //}
    //
    //Use TestInitialize to run code before running each test
    //[TestInitialize()]
    //public void MyTestInitialize()
    //{
    //}
    //
    //Use TestCleanup to run code after each test has run
    //[TestCleanup()]
    //public void MyTestCleanup()
    //{
    //}
    //
    #endregion

    #region Soliloquy
    public static readonly string HAMLET = @"To be, or not to be--that is the question:
Whether 'tis nobler in the mind to suffer
The slings and arrows of outrageous fortune
Or to take arms against a sea of troubles
And by opposing end them. To die, to sleep--
No more--and by a sleep to say we end
The heartache, and the thousand natural shocks
That flesh is heir to. 'Tis a consummation
Devoutly to be wished. To die, to sleep--
To sleep--perchance to dream: ay, there's the rub,
For in that sleep of death what dreams may come
When we have shuffled off this mortal coil,
Must give us pause. There's the respect
That makes calamity of so long life.
For who would bear the whips and scorns of time,
Th' oppressor's wrong, the proud man's contumely
The pangs of despised love, the law's delay,
The insolence of office, and the spurns
That patient merit of th' unworthy takes,
When he himself might his quietus make
With a bare bodkin? Who would fardels bear,
To grunt and sweat under a weary life,
But that the dread of something after death,
The undiscovered country, from whose bourn
No traveller returns, puzzles the will,
And makes us rather bear those ills we have
Than fly to others that we know not of?
Thus conscience does make cowards of us all,
And thus the native hue of resolution
Is sicklied o'er with the pale cast of thought,
And enterprise of great pitch and moment
With this regard their currents turn awry
And lose the name of action. -- Soft you now,
The fair Ophelia! -- Nymph, in thy orisons
Be all my sins remembered.";
    #endregion

    #region GetDuplicatedCharsIn

    [TestMethod()]
    public void EmptyString_GetDuplicatedCharsInTest() {
      string input = string.Empty;
      var expected = new char[] { };
      var actual = DupeDetector.GetDuplicatedCharsIn(input);

      AssertEx.HaveSameContents<char>(expected, actual);
    }

    [TestMethod()]
    public void NullString_GetDuplicatedCharsInTest() {
      string input = null;
      var expected = new char[] { };
      var actual = DupeDetector.GetDuplicatedCharsIn(input);

      AssertEx.HaveSameContents<char>(expected, actual);
    }

    [TestMethod()]
    public void Whitespace_GetDuplicatedCharsInTest() {
      string input = @" 		
            ";
      var expected = new char[] { };
      var actual = DupeDetector.GetDuplicatedCharsIn(input);

      AssertEx.HaveSameContents<char>(expected, actual);
    }

    [TestMethod()]
    public void Alphabet_GetDuplicatedCharsInTest() {
      string input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      var expected = new char[] { };
      var actual = DupeDetector.GetDuplicatedCharsIn(input);

      AssertEx.HaveSameContents<char>(expected, actual);
    }

    [TestMethod()]
    public void SamplePassage_GetDuplicatedCharsInTest() {
      string input = "The quick brown fox jumped over the lazy dogs.";
      var expected = new char[] { ' ', 'd', 'e', 'h', 'o', 'r', 'u' }; // NOT 't' or 'T'
      var actual = DupeDetector.GetDuplicatedCharsIn(input);

      AssertEx.HaveSameContents<char>(expected, actual);
    }

    #endregion

    #region GetDuplicatedWordsIn - default delimiters

    [TestMethod()]
    public void EmptyString_GetDuplicatedWordsInTest() {
      string input = string.Empty;
      var expected = new string[] { };
      var actual = DupeDetector.GetDuplicatedWordsIn(input);

      AssertEx.HaveSameContents<string>(expected, actual);
    }

    [TestMethod()]
    public void NullString_GetDuplicatedWordsInTest() {
      string input = null;
      var expected = new string[] { };
      var actual = DupeDetector.GetDuplicatedWordsIn(input);

      AssertEx.HaveSameContents<string>(expected, actual);
    }

    [TestMethod()]
    public void Whitespace_GetDuplicatedWordsInTest() {
      string input = @" 		
            ";
      var expected = new string[] { };
      var actual = DupeDetector.GetDuplicatedWordsIn(input);

      AssertEx.HaveSameContents<string>(expected, actual);
    }

    [TestMethod()]
    public void SamplePassage_GetDuplicatedWordsInTest() {
      string input = "The quick brown fox jumped over the lazy dogs.";
      var expected = new string[] { "the" }; 
      var actual = DupeDetector.GetDuplicatedWordsIn(input);

      AssertEx.HaveSameContents<string>(expected, actual);
    }

    [TestMethod()]
    public void NoDupePassage_GetDuplicatedWordsInTest() {
      string input = "Now is the time for all good men...";
      var expected = new string[] { };
      var actual = DupeDetector.GetDuplicatedWordsIn(input);

      AssertEx.HaveSameContents<string>(expected, actual);
    }

    [TestMethod()]
    public void HamletPassage_GetDuplicatedWordsInTest() {
      string input = HAMLET;
      var expected = new string[] { "a", "all", "and", "be", 
        "bear", "by", "death", "die", "end", 
        "for", "have", "in", "is", "life", 
        "make", "makes", "no", "not", "of", 
        "or", "sleep", "th", "that", "the", 
        "there's", "this", "thus", "tis", "to", "us", 
        "we", "when", "who", "with", "would" };
      var actual = DupeDetector.GetDuplicatedWordsIn(input);

      AssertEx.HaveSameContents<string>(expected, actual);
    }

    #endregion

    #region GetDuplicatedWordsIn - different delimiters


    #endregion
  }
}
