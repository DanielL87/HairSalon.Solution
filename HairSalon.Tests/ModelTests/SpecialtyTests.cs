using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtyTest : IDisposable
    { 
        public void Dispose()
        {
            Specialty.ClearAll();
        }

        public SpecialtyTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=daniel_lira_test;";
        }

         [TestMethod]
        public void Type_ReturnsTypesofSpecialtyClass_Type()
        {
            Specialty newSpecialty = new Specialty("Nails", 1);
            Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
        }

        [TestMethod]
        public void Saves_SavestoSpecialtysTables_Method()
        {
            string description = "Nails";
            Specialty newSpecialty = new Specialty(description);
            newSpecialty.Save();
            List<Specialty> resultList = Specialty.GetAll();
            Specialty result = resultList[0];
            string resultDescription = result.GetDescription();
            Assert.AreEqual(description, resultDescription);
        }

        [TestMethod]
        public void GetAll_ReturnsEmptyListFromDatabase_SpecialtyList()
        {
            List<Specialty> newList = new List<Specialty> {};
            List<Specialty> result = Specialty.GetAll();
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void FindById_ReturnsTrueIfIdsAreTheSame_Int()
        {
            //Arrange
            Specialty specialty1 = new Specialty("nails", 1);
            specialty1.Save();
            int resultId = specialty1.GetId();
            Specialty result = Specialty.FindById(resultId);
            Assert.AreEqual(result, specialty1);
        }
    }
}    