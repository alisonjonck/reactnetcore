using NUnit.Framework;
using App.Domain.Helpers;
using System.Collections.Generic;
using System.Linq;

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

        [Test]
        public void ReturnsMostUsedWords()
        {
            IList<string> sentences = new string[]
            {
                "Bateram no meu carro e fugiram, o que eu devo fazer?",
                "Veja uma lista com 11 carros que saíram de linha em 2018",
                "Bater em excesso de velocidade gera perda de cobertura do seguro auto?",
                "Viagem para Ibiza: dicas para planejar o seu roteiro",
                "Veja quais são os 8 carros zero quilômetro mais baratos do Brasil",
                "Dirigir com a mão no câmbio é um problema?",
                "Veja como funciona a cobertura de seguro nos países do Mercosul",
                "Por que carros antigos tem o seguro mais caro? Descubra!",
                "A importância de renovar o seguro! Não fique sem proteção",
                "Sabe a diferença entre reboque e semi-reboque? Veja aqui"
            }, cleanSentences = new List<string>();

            foreach (var sentence in sentences)
            {
                cleanSentences.Add(sentence.RemovePrepositions(" "));
            }

            IList<StringCount> expected = new List<StringCount>()
            {
                new StringCount("veja", 4),
                new StringCount("carros", 3),
                new StringCount("seguro", 3),
                new StringCount("cobertura", 2),
                new StringCount("bateram", 1),
                new StringCount("meu", 1),
                new StringCount("carro", 1),
                new StringCount("fugiram", 1),
                new StringCount("eu", 1),
                new StringCount("devo", 1),
            };

            IList<StringCount> mostUsed10 = cleanSentences.MostUsed(10);

            Assert.AreEqual(mostUsed10.ElementAt(0).Value, expected.ElementAt(0).Value);
            Assert.AreEqual(mostUsed10.ElementAt(0).Count, expected.ElementAt(0).Count);

            Assert.AreEqual(mostUsed10.ElementAt(1).Value, expected.ElementAt(1).Value);
            Assert.AreEqual(mostUsed10.ElementAt(1).Count, expected.ElementAt(1).Count);

            Assert.AreEqual(mostUsed10.ElementAt(2).Value, expected.ElementAt(2).Value);
            Assert.AreEqual(mostUsed10.ElementAt(2).Count, expected.ElementAt(2).Count);

            Assert.AreEqual(mostUsed10.ElementAt(3).Value, expected.ElementAt(3).Value);
            Assert.AreEqual(mostUsed10.ElementAt(3).Count, expected.ElementAt(3).Count);

            Assert.AreEqual(mostUsed10.ElementAt(4).Value, expected.ElementAt(4).Value);
            Assert.AreEqual(mostUsed10.ElementAt(4).Count, expected.ElementAt(4).Count);

            Assert.AreEqual(mostUsed10.ElementAt(5).Value, expected.ElementAt(5).Value);
            Assert.AreEqual(mostUsed10.ElementAt(5).Count, expected.ElementAt(5).Count);

            Assert.AreEqual(mostUsed10.ElementAt(6).Value, expected.ElementAt(6).Value);
            Assert.AreEqual(mostUsed10.ElementAt(6).Count, expected.ElementAt(6).Count);

            Assert.AreEqual(mostUsed10.ElementAt(7).Value, expected.ElementAt(7).Value);
            Assert.AreEqual(mostUsed10.ElementAt(7).Count, expected.ElementAt(7).Count);

            Assert.AreEqual(mostUsed10.ElementAt(8).Value, expected.ElementAt(8).Value);
            Assert.AreEqual(mostUsed10.ElementAt(8).Count, expected.ElementAt(8).Count);

            Assert.AreEqual(mostUsed10.ElementAt(9).Value, expected.ElementAt(9).Value);
            Assert.AreEqual(mostUsed10.ElementAt(9).Count, expected.ElementAt(9).Count);
        }
    }
}
