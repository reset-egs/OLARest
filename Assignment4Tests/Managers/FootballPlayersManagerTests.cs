using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment4.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLAClassLibrary;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace Assignment4.Managers.Tests
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {
        internal FootballPlayer existingPlayer = new FootballPlayer() { Id = 4, Name = "Tea Koscina", Age = 27, ShirtNumber = 1 };
        internal FootballPlayersManager _manager = new FootballPlayersManager();

        [TestMethod()]
        public void GetById_ValidId_Test()
        {
            FootballPlayer? foundPlayer = _manager.GetById(4);
            Assert.AreEqual(existingPlayer.Name, foundPlayer.Name);

        }

        [TestMethod()]
        public void GetById_InvalidId_Test()
        {
            FootballPlayer? foundPlayer = _manager.GetById(0);
            Assert.AreEqual(foundPlayer, null);

        }

        [TestMethod()]
        public void Add_ValidObject_Test()
        {
            FootballPlayer player = new FootballPlayer() { Id = 5, Name = "Test Guy", Age = 99, ShirtNumber = 12 };
            List<FootballPlayer> list = _manager.GetAll();

            _manager.Add(player);
            Assert.AreEqual(5, list.Count);
        }

        [TestMethod()]
        public void Add_Null_Test()
        {
            List<FootballPlayer> list = _manager.GetAll();

            Assert.ThrowsException<NullReferenceException>(() => _manager.Add(null));
        }
    }
}