using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using MTDClasses;

namespace MTDTests
{
    [TestFixture]
    public class HandTests
    {
        
        Hand hand1;
        Hand hand2;
        Hand hand3;
        Hand hand4;

        BoneYard b;
        BoneYard b2;
        Domino d11;
        Domino d12;
        Domino d23;
        Domino d55;
        Domino d33;
        MexicanTrain mt;



        [SetUp]
        public void SetUpAllHandTests()
        {
            b = new BoneYard(12);
            b2 = new BoneYard(12);
            hand1 = new Hand();

            hand2 = new Hand(b, 2);
            hand3 = new Hand(b, 6);
            hand4 = new Hand();

            d11 = new Domino(1, 1);
            d12 = new Domino(1, 2);
            d23 = new Domino(2, 3);
            d55 = new Domino(5, 5);
            d33 = new Domino(3, 3);

            hand1.Add(d11);
            hand1.Add(d12);
            hand1.Add(d23);
            mt = new MexicanTrain();
            mt.Add(d33);

                

        }

        [Test]
        public void TestHandConstructors()
        {
            Assert.AreEqual(10, hand2.Count);
            Assert.AreEqual(9, hand3.Count);
        }

        [Test]
        public void TestHandAdd()
        {
            Assert.AreEqual(3, hand1.Count);

        }

        [Test]
        public void TestHandHasDomino()
        {
            Assert.IsTrue(hand1.HasDomino(1));
            Assert.IsFalse(hand1.HasDomino(12));
        }

        [Test]
        public void TestHandHasDouble()
        {
            Assert.IsTrue(hand1.HasDoubleDomino(1));
            Assert.IsFalse(hand1.HasDoubleDomino(3));
        }

        [Test]
        public void TestHandIndexOfDomino()
        {
            Assert.AreEqual(2, hand1.IndexOfDomino(3));
            Assert.AreEqual(-1, hand1.IndexOfDomino(5));
        }

        [Test]
        public void TestHandIndexOfDoubleDomino()
        {
            Assert.AreEqual(0, hand1.IndexOfDoubleDomino(1));
            Assert.AreEqual(-1, hand1.IndexOfDoubleDomino(6));
            Assert.AreEqual(-1, hand1.IndexOfDoubleDomino(3));
        }

        [Test]
        public void TestHandIndexOfHighDouble()
        {
            hand1.Add(d55);
            Assert.AreEqual(3, hand1.IndexOfHighDouble());

            hand4.Add(d12);
            hand4.Add(d23);
            Assert.AreEqual(-1, hand4.IndexOfHighDouble());
            
        }

        [Test]
        public void TestHandRemoveAt()
        {
            hand1.RemoveAt(0);
            Assert.AreEqual(2, hand1.Count);
            Assert.AreEqual(-1, hand1.IndexOfHighDouble());//test the double 1 at index 0 is removed
        }

        [Test]
        public void TestHandGetDomino()
        {
            Domino d = hand1.GetDomino(3); //copies the domino to compare
            Assert.AreEqual(2, hand1.Count);
            Assert.AreEqual(d23, d);
        }

        [Test]
        public void TestHandGetDoubleDomino()
        {
            Domino d = hand1.GetDoubleDomino(1);
            Assert.AreEqual(2, hand1.Count);
            Assert.AreEqual(d11, d);
        }

        [Test]
        public void TestHandDraw() //91 dominoes in a set
        {
            hand1.Draw(b2);
            Assert.AreEqual(90, b2.DominosRemaining);
            Assert.AreEqual(4, hand1.Count);

        }
        
        [Test]
        public void TestHandPlay_DominoTrain()
        {
            hand1.Play(d23, mt);
            Assert.AreEqual(2, mt.Count);
            Assert.AreEqual(2, hand1.Count);
            Assert.AreEqual(2, mt.PlayableValue);
        }
        
        [Test]
        public void TestHandPlay_Train()
        {
            Domino d = hand1.Play(mt);
            Assert.AreEqual(2, mt.Count);
            Assert.AreEqual(2, hand1.Count);
            Assert.AreEqual(2, mt.PlayableValue);
            Assert.AreEqual(d23, d);
        }

        [Test]
        public void TestHandToString()
        {
            String handOfDominosStringList;
            handOfDominosStringList = hand1.ToString();
            Assert.IsInstanceOf<String>(handOfDominosStringList);
        }
    }
}
