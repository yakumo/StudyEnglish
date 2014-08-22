using System;

namespace DataStructures
{
	public class Constants
	{
		public enum WordPartType
		{
			Unknown = 0,        // わかりません
			Noun = 1,           // 名詞
			Verb = 2,           // 動詞
			Adverb = 3,         // 副詞
			Particle = 4,       // 助詞
			Auxiliary = 5,      // 助動詞
			Adjective = 6,		// 形容詞
			NaAdjective = 7,    // 形容動詞
		}

		public const string[] WordPartString = {
			"",
			"名詞",
			"動詞",
			"副詞",
			"助詞",
			"助動詞",
			"形容詞",
			"形容動詞",
		};
	}

	public class SEWord
	{
		public Guid _id { get; set; }
		public int WordLevel { get; set; }
		public string EnglishWord { get; set; }
		public string JapaneseWord { get; set; }
		public Constants.WordPartType PartType { get; set; }
		public string EnglishSample { get; set; }
		public string JapaneseSample { get; set; }
	}
}

