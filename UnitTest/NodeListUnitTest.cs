using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stack_implementation;
using Stack_implementation.src;

namespace UnitTest
{
    [TestClass]
    public class NodeListUnitTest
    {
        private IStos<char> stos;
        private Random rnd = new Random();
        //zwraca znak ASCII o kodzie z zakresu 33..126
        private char RandomElement => (char)rnd.Next(33, 126);

        // s.create ==> s.IsEmpty==true
        [TestMethod]
        public void IsEmpty_PoUtworzeniuStosJestPusty()
        {
            stos = new StosWLiscie<char>();
            Assert.IsTrue(stos.IsEmpty);
        }

        // s.create.Push(e) ==> s.IsEmpty==false
        [TestMethod]
        public void IsEmpty_PoUtworzeniuIDodaniuElementuStosNieJestPusty()
        {
            stos = new StosWLiscie<char>();
            stos.Push(RandomElement);
            Assert.IsFalse(stos.IsEmpty);
        }

        // s.Pop( s.Push(e) ) == s
        [TestMethod]
        public void PushPop_StosSieNieZmienia()
        {
            stos = new StosWLiscie<char>();
            stos.Push(RandomElement);
            stos.Push(RandomElement);

            char[] tabPrzed = stos.ToArray();
            char e = RandomElement;
            stos.Push(e);
            stos.Pop();
            char[] tabPo = stos.ToArray();

            CollectionAssert.AreEqual(tabPrzed, tabPo);
        }

        // s.Peek( s.Push(e) ) == e
        [TestMethod]
        public void Peek_ZwracaOstatnioWstawionyElement()
        {
            stos = new StosWLiscie<char>();
            char e = RandomElement;

            stos.Push(e);

            Assert.AreEqual(stos.Peek, e);
        }

        // s.create.Peek ==> throw StosEmptyException
        [TestMethod]
        [ExpectedException(typeof(StosEmptyException))]
        public void PeekDlaPustegoStosu_ZwracaWyjatek_StosEmptyException()
        {
            stos = new StosWLiscie<char>();
            Assert.IsTrue(stos.IsEmpty);

            char c = stos.Peek;
        }

        // s.create.Pop() ==> throw StosEmptyException
        [TestMethod]
        [ExpectedException(typeof(StosEmptyException))]
        public void PopDlaPustegoStosu_ZwracaWyjatek_StosEmptyException()
        {
            stos = new StosWLiscie<char>();
            Assert.IsTrue(stos.IsEmpty);

            char c = stos.Peek;
        }

        [TestMethod]
        public void Indexer_Test()
        {
            StosWLiscie<char> stos = new StosWLiscie<char>();
            stos.Push('a');
            stos.Push('b');

            Assert.AreEqual('a', stos[0]);
            Assert.AreEqual('b', stos[stos.Count - 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_Test_Exception_Less_Than_Zero()
        {
            StosWLiscie<char> stos = new StosWLiscie<char>();
            stos.Push('a');

            char x = stos[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer_Test_Exception_Greater_Than_Length()
        {
            StosWLiscie<char> stos = new StosWLiscie<char>();
            stos.Push('a');

            char x = stos[stos.Count + 2];
        }
    }
}
