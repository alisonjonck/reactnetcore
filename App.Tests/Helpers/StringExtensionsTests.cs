using NUnit.Framework;
using App.Domain.Helpers;

namespace App.Tests.Helpers
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void ReturnsSentenceReplacingPrepositions()
        {
            string sentence = "Bateram no meu carro e fugiram, o que eu devo fazer?",
                newSentence;

            newSentence = sentence.RemovePrepositions(" - ");

            Assert.AreEqual("Bateram - meu carro - fugiram, - - eu devo fazer?", newSentence);

            sentence = "Veja uma lista com 11 carros que saíram de linha em 2018";
            newSentence = sentence.RemovePrepositions(" ");

            Assert.AreEqual("Veja lista 11 carros saíram linha 2018", newSentence);
        }
    }
}
