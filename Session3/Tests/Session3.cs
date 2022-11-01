using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Session3._1.DataModels;
using Session3.Helpers;
using Session3.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Session3.Tests
{
    [TestClass]
    public class RestSharpTests : ApiBaseTest
    {
        private static List<PetModel> petCleanUpList = new List<PetModel>();

        [TestInitialize]
        public async Task TestInitialize()
        {
            PetDetails = await PetHelper.AddNewPet(RestClient);
        }
        [TestMethod]
        public async Task DemoGetPetById()
        {
            //Arange
            var getRequest = new RestRequest(Endpoints.GetPetById(PetDetails.Id));
            petCleanUpList.Add(PetDetails);

            //Act
            var restResponse = await RestClient.ExecuteGetAsync<PetModel>(getRequest);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode, "Status code is not equal to 200 ");
            Assert.AreEqual(PetDetails.Name, restResponse.Data.Name, "Pet Name did not matched.");
            Assert.AreEqual(PetDetails.PhotoUrls[0], restResponse.Data.PhotoUrls[0], "PhotoUrls did not match.");
            Assert.AreEqual(PetDetails.Tags[0].Name, restResponse.Data.Tags[0].Name, "Tags did not match.");
            Assert.AreEqual(PetDetails.Status, restResponse.Data.Status, "Status did not match.");
        }
        [TestCleanup]
        public async Task TestCleanUp()
        {
            foreach (var data in petCleanUpList)
            {
                var deletePetIdRequest = new RestRequest(Endpoints.GetPetById(data.Id));
                var deletePetIdResponse = await RestClient.DeleteAsync(deletePetIdRequest);
            }
        }
    }
}
