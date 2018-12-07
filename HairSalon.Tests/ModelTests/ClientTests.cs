using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTest : IDisposable
    { 
        public void Dispose()
        {
            Client.ClearAll();
        }

        public ClientTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=daniel_lira_test;";
        }

        [TestMethod]
        public void Type_ReturnsTypesofClientClass_Type()
        {
            Client newClient = new Client("Mark", 1);
            Assert.AreEqual(typeof(Client), newClient.GetType());
        }

        [TestMethod]
        public void Saves_SavestoClientsTables_Method()
        {
            string name = "Lola";
            Client newClient = new Client(name,1);
            newClient.Save();
            List<Client> resultList = Client.GetAll();
            Client result = resultList[0];
            string resultName = result.GetName();

            Assert.AreEqual(name, resultName);
        }
        
        [TestMethod]
        public void GetAll_ReturnsEmptyListFromDatabase_ClientList()
        {
            List<Client> newList = new List<Client> {};
            List<Client> result = Client.GetAll();
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void GetAll_ReturnsListOfClients_List()
        {
            Client clientOne = new Client("Mark", 3);
            Client clientTwo = new Client("Jennifer", 2);
            List<Client> allClients = new List<Client>{clientOne, clientTwo};
            clientOne.Save();
            clientTwo.Save();
            List<Client> resultList = Client.GetAll();
            CollectionAssert.AreEqual(allClients, resultList);
        }

        [TestMethod]
        public void FindById_ReturnsTrueIfIdsAreTheSame_Int()
        {
            //Arrange
            Client client1 = new Client("David",1);
            client1.Save();
            int resultId = client1.GetId();
            Client result = Client.FindById(resultId);
            Assert.AreEqual(result, client1);
        }

        [TestMethod]
        public void FindClientsByStylistId_ReturnsListOfClientsWithSameStylist_List()
        {
            //Arrange
            Client client1 = new Client("Mark", 1);
            client1.Save();
            
            List <Client> result1 = Client.FindByStylistId(1);

            Assert.AreEqual(result1, client1);
        }
    }
}        