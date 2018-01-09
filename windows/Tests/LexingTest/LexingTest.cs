using Microsoft.VisualStudio.TestTools.UnitTesting;
using StemInterpretter.Lexing;

namespace LexingTest
{
	[TestClass]
	public class LexingTest
	{
		[TestMethod]
		public void EmptyLexTest()
		{
			ILexRule nullRule = new FunctionalLexRule(
				LexMatchType.Null,
				target => {
					if (string.IsNullOrEmpty(target))
						return new LexNode(LexMatchType.Null, 0, "");
					else
						return LexNode.NoMatch;
				}
			);

			string source = "";
			string expected = "";

			ILexResult result = nullRule.Match(source);

			Assert.AreEqual(result.Text, expected);
		}

		[TestMethod]
		public void IntegerLexTest()
		{
			ILexRule intRule = new SimpleLexRule(LexMatchType.LitInt, "[0-9]+");

			string source = "834";
			string expected = "834";

			ILexResult result = intRule.Match(source);

			Assert.AreEqual(result.Text, expected);
		}

		[TestMethod]
		public void WhitespeceLexTest() {
			ILexRule whitespaceRule = new SimpleLexRule(LexMatchType.LitInt, "\\s+");

			string source = "     834   ";
			string expected = "     ";

			ILexResult result = whitespaceRule.Match(source);

			Assert.AreEqual(result.Text, expected);
		}

		
	}
}