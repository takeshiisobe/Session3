using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Session3._1.DataModels;

namespace Session3.Tests.TestData
{

    public class GeneratePet
    {
        public static PetModel petModel()
        {
            return new PetModel
            {
                Id = 1998,
                Name = "Takeshi session 3",
                Status = "Available",
                PhotoUrls = new string[] { "facebook.com" },
                Category = new Category()
                {
                    Id = 1111,
                    Name = "Category Takeshi"
                },

                Tags = new Category[] { new Category { Id = 9999, Name = "Takeshi" } },

            };

         }


    }
        
    
}
