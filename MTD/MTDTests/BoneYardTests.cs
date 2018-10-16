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
    public class BoneYardTests
    {
        BoneYard boneYard;
        BoneYard boneYard2;
        BoneYard boneYard3;


        [SetUp]
        public void SetUpAllTests()
        {
            boneYard = new BoneYard(2);
            boneYard2 = new BoneYard(2);
            boneYard3 = new BoneYard(12);

        }

        [Test]
        public void TestBoneYardConstructor() 
        {
            //int count = boneYard.DominosRemaining;
            //Assert.AreEqual(9, count);

            //int expected = 9;
            //int actual = boneYard.DominosRemaining;
            //Assert.AreEqual(expected, actual);

            Assert.IsInstanceOf<BoneYard>(boneYard);
            Assert.AreEqual(91, boneYard3.DominosRemaining);

        }

        [Test]
        public void TestBoneYardIsEmpty()

        {
            bool expected = false;
            bool actual = boneYard.IsEmpty();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestBoneYardDraw()
        {
           
            Domino domino = boneYard.Draw();
            Assert.IsInstanceOf<Domino>(domino);
        }
        
        [Test]
        public void TestBoneYardDominosRemaining()
        {
            int expected = 5;
            boneYard2.Draw();
            int actual = boneYard2.DominosRemaining;
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void TestBoneYardThisGetter()
        {
            Domino domino = boneYard[0];
            Assert.IsInstanceOf<Domino>(domino);
        }

        [Test]
        public void TestBoneYardThisSetter()
        {
            int expected = 12;
            boneYard[1].Side1 = 12;
            int actual = boneYard[1].Side1;
            Assert.AreEqual(expected, actual);

        }
        [Test]
        public void TestBoneYardToString()
        {
            String boneYardStringList;
            boneYardStringList = boneYard.ToString();
            Assert.IsInstanceOf<String>(boneYardStringList);

        }

        [Test]
        public void TestBoneYardShuffle() //1 in 169 tests will fail
        {
            Domino expected = boneYard3[0];
            boneYard3.Shuffle();
            Domino actual = boneYard3[0];
            Assert.AreNotEqual(expected, actual);

            
        }
    }
}
