using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CombatReader.Tests
{
    [TestClass]
    public class ParserTest
    {
        private Parser parser;
        private StringReader sr;

        [TestInitialize]
        public void Setup()
        {
            parser = new Parser();
            sr = new StringReader("[03/01/2012 15:00:01] [@Khantni] [@Twos] [Crushed {807754499359094}] [ApplyEffect {836045448945477}: Damage {836045448945501}] (478 kinetic {836045448940873} (478 absorbed {836045448945511})) <478>");
    
        }
        [TestMethod]
        public void Parse_One_Line_And_Return_Correct_Timestamp()
        {
            //Arrange

            //Act
            var list = parser.Parse(sr);

            //Assert
            var el = list[0];
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(new DateTime(2012, 3, 1, 15, 00, 1, 0, DateTimeKind.Unspecified), el.TimeStamp);
        }
        [TestMethod]
        public void Parse_One_Line_And_Return_Correct_Source()
        {
            //Arrange

            //Act
            var list = parser.Parse(sr);

            //Assert
            var el = list[0];
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Khantni" , el.Source.Name);
            Assert.AreEqual(true, el.Source.IsPlayer);
        }
        [TestMethod]
        public void Parse_One_Line_And_Return_Correct_Target()
        {
            //Arrange

            //Act
            var list = parser.Parse(sr);

            //Assert
            var el = list[0];
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Twos", el.Target.Name);
            Assert.AreEqual(true, el.Target.IsPlayer);
        }
        [TestMethod]
        public void Parse_One_Line_And_Return_Correct_AbilityName()
        {
            //Arrange

            //Act
            var list = parser.Parse(sr);

            //Assert
            var el = list[0];
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Crushed", el.AbilityName.Name);
            Assert.AreEqual(807754499359094, el.AbilityName.ID);
        }
        [TestMethod]
        public void Parse_One_Line_And_Return_Correct_Event()
        {
            //Arrange

            //Act
            var list = parser.Parse(sr);

            //Assert
            var el = list[0];
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("ApplyEffect", el.Event.Name);
            Assert.AreEqual(836045448945477, el.Event.ID);
        }
        [TestMethod]
        public void Parse_One_Line_And_Return_Correct_Effect()
        {
            //Arrange

            //Act
            var list = parser.Parse(sr);

            //Assert
            var el = list[0];
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Damage", el.Effect.Name);
            Assert.AreEqual(836045448945501, el.Effect.ID);
        }
        [TestMethod]
        public void Parse_One_Line_And_Return_Correct_Value()
        {
            //Arrange

            //Act
            var list = parser.Parse(sr);

            //Assert
            var el = list[0];
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("kinetic", el.Value.Name);
            Assert.AreEqual(false, el.Value.IsCrit);
            Assert.AreEqual(478, el.Value.Amount);
            Assert.AreEqual(836045448940873, el.Value.ID);
        }
        [TestMethod]
        public void Parse_One_Line_And_Return_Correct_Mitigation()
        {
            //Arrange

            //Act
            var list = parser.Parse(sr);

            //Assert
            var el = list[0];
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("absorbed", el.Mitigation.Name);
            Assert.AreEqual(478, el.Mitigation.Value);
            Assert.AreEqual(836045448945511, el.Mitigation.ID);
        }
        [TestMethod]
        public void Parse_One_Line_And_Return_Correct_Threat()
        {
            //Arrange

            //Act
            var list = parser.Parse(sr);

            //Assert
            var el = list[0];
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(478, el.Threat);
        }
    }
}
