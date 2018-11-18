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
    public class MexicanTrainTests
    {
        Domino d11;
        Domino d12;
        Domino d23;
        Domino d31;
        Hand h;
        Train t;

        [SetUp]
        public void SetUpAllTests()
        {
            d11 = new Domino(1, 1);
            d12 = new Domino(1, 2);
            d23 = new Domino(2, 3);
            d31 = new Domino(3, 1);
            h = new Hand();
            t = new MexicanTrain();
            t.Add(d11);
            h.Add(d12);
            h.Add(d23);
            h.Add(d31);
        }


        [Test]
        public void TestIsPlayable()
        {
            bool mustFlip;
            bool isPlayable = t.IsPlayable(h, d12, out mustFlip);
            Assert.AreEqual(true, isPlayable);
            Assert.AreEqual(false, mustFlip);
        }

        [Test]
        public void TestIsPlayable2()
        {
            bool mustFlip;
            bool isPlayable = t.IsPlayable(h, d31, out mustFlip);
            Assert.AreEqual(true, isPlayable);
            Assert.AreEqual(true, mustFlip);
        }


        [Test]
        public void TestIsPlayable3()
        {

            bool mustFlip;
            bool isPlayable = t.IsPlayable(h, d23, out mustFlip);
            Assert.AreEqual(false, isPlayable);
            Assert.AreEqual(false, mustFlip);
            Assert.Throws<ArgumentException>(() => d23.Side1 = -1);

        }

        [Test]
        public void TestFOREACH()
        {
            foreach (Domino d in t)
                Assert.AreEqual(d, d11);
        }

        [Test]
        public void TestPlay1()
        {
            t.Play(h, d12);
            Assert.AreEqual(2, t.PlayableValue);
            Assert.AreEqual(2, t.Count);
        }

        [Test]
        public void TestPlay2()
        {
            

            t.Play(h, d31);
            Assert.AreEqual(3, t.PlayableValue);
            Assert.AreEqual(2, t.Count);
        }

        [Test]
        public void TestPlay3()
        {
            Assert.Throws<ArgumentException>(() => t.Play(h, d23));
            Assert.AreEqual(t.PlayableValue, 1);
            Assert.AreEqual(t.Count, 1);
        }

        
    }
}
