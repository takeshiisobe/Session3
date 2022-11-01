using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Session3._1.DataModels;
using Session3.Tests.TestData;
using Session3.Resources;
using RestSharp;

namespace Session3.Helpers
{
    public class PetHelper
    {
      /// <summary>
      /// Post New Pet
      /// </summary>
      /// <param name="client"></param>
      /// <returns>Pet Data</returns>

        public static async Task<PetModel> AddNewPet(RestClient client)
        {
            var NewPet = GeneratePet.petModel();
            var postRequest = new RestRequest(Endpoints.PostPet());

            //Send Post Request to add new pet
            postRequest.AddJsonBody(NewPet);
            var postResponse = await client.ExecutePostAsync<PetModel>(postRequest);

            var createdPetData = NewPet;
            return createdPetData;
        }
    }
}
