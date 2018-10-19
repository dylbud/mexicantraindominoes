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
    public class PlayerTrainTests
    {
        PlayerTrain playerTrain;
        Hand hand;
        Domino d11;
        Domino d12;
        Domino d23;
        Domino d31;

        [SetUp]
        public void SetUpAllTests()
        {
            hand = new Hand();
            d11 = new Domino(1, 1);
            d12 = new Domino(1, 2);
            d23 = new Domino(2, 3);
            d31 = new Domino(3, 1);
            hand.Add(d12);
            hand.Add(d23);
            hand.Add(d31);
            playerTrain = new PlayerTrain(hand);
            playerTrain.Add(d11);
        }

        [Test]
        public void TestPlayerTrainConstructor()
        {
            Assert.IsInstanceOf<PlayerTrain>(playerTrain);
        }

        [Test]
        public void TestPlayerTrainOpen()
        {
            playerTrain.Open();
            bool expected = true;
            bool actual = playerTrain.IsOpen;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPlayerTrainClose()
        {
            playerTrain.Close();
            bool expected = false;
            bool actual = playerTrain.IsOpen;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void TestIsPlayable()
        {
            bool mustFlip;
            bool isPlayable = playerTrain.IsPlayable(hand, d12, out mustFlip);
            Assert.AreEqual(true, isPlayable);
            Assert.AreEqual(false, mustFlip);
        }

        [Test]
        public void TestIsPlayable2()
        {

            bool mustFlip;
            bool isPlayable = playerTrain.IsPlayable(hand, d23, out mustFlip);
            Assert.AreEqual(false, isPlayable);
            Assert.AreEqual(false, mustFlip);
        }

        [Test]
        public void TestIsPlayable3()
        {
            bool mustFlip;
            bool isPlayable = playerTrain.IsPlayable(hand, d31, out mustFlip);
            Assert.AreEqual(true, isPlayable);
            Assert.AreEqual(true, mustFlip);
        }
    }
}
