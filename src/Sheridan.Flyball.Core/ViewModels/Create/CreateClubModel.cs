using System;
using System.Collections.Generic;
using System.Text;
using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.ViewModels.Create
{
    public class CreateClubModel
    {
        public int NafaClubNumber { get; set; }
        public string Name { get; set; }

        
        public static Club ToClub(CreateClubModel newClub)
        {
            return new Club() { NafaClubNumber = newClub.NafaClubNumber, Name = newClub.Name };
        }
    }
}
