using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTest : IDisposable
    { 
        public void Dispose()
        {
            Stylist.ClearAll();
        }

        public StylistTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=daniel_lira_test;";
        }

        [TestMethod]
        public void Type_ReturnsTypesofStylistClass_Type()
        {
            Stylist newStylist = new Stylist("test");
            Assert.AreEqual(typeof(Stylist), newStylist.GetType());
        }

        [TestMethod]
        public void Saves_SavestoStylistTabels_Method()
        {
            string name = "test";
            Stylist newStylist = new Stylist(name);
            newStylist.Save();
            List<Stylist> resultList = Stylist.GetAll();
            Stylist result = resultList[0];
            string resultName = result.GetName();

            Assert.AreEqual(name, resultName);
        }

        [TestMethod]
        public void GetAll_ReturnsEmptyListFromDatabase_ItemList()
        {
            List<Stylist> newList = new List<Stylist> {};
            List<Stylist> result = Stylist.GetAll();
            CollectionAssert.AreEqual(newList, result);
        }

          [TestMethod]
        public void GetAll_ReturnsListOfStylist_List()
        {
            Stylist StylistOne = new Stylist("Laura");
            Stylist StylistTwo = new Stylist("Frank");
            List<Stylist> allStylists = new List<Stylist>{StylistOne, StylistTwo};
            StylistOne.Save();
            StylistTwo.Save();
            List<Stylist> resultList = Stylist.GetAll();
            CollectionAssert.AreEqual(allStylists, resultList);
        }

         [TestMethod]
        public void FindId_ReturnsTrueIfIdsAreTheSame_Int()
        {
            //Arrange
            Stylist stylist1 = new Stylist("Laura");
            stylist1.Save();
            int resultId = stylist1.GetId();
            Stylist result = Stylist.FindById(resultId);
            Assert.AreEqual(result, stylist1);
        }
    }
}    