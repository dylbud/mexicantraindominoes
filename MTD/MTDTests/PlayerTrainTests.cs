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

        [SetUp]
        public void SetUpAllTests()
        {
            Hand hand = new Hand();
            playerTrain = new PlayerTrain(hand, 4);
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
    }
}
