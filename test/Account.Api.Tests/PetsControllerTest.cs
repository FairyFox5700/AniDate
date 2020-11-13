using System;
using System.Collections.Generic;
using Account.API.Controllers;
using Account.API.Entities;
using Xunit;

namespace Account.Api.Tests
{
    public class PetsControllerTest
    {
        private PetsController controller = new PetsController();
        [Fact]
        public void QueryPetsListReturnsCorrectPets()
        {
            List<Pet> pets = new List<Pet>(controller.GetAllPets().Data);
            Assert.Equal(pets.Count, 2);
        }
    }
}