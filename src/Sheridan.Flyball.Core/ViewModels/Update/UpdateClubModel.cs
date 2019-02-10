using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.ViewModels.Update
{
    public class UpdateClubModel
    {
        public int Id { get; set; }
        public int NafaClubNumber { get; set; }
        public string Name { get; set; }

        public static Club ToClub(UpdateClubModel newClub)
        {
            return new Club() { NafaClubNumber = newClub.NafaClubNumber, Name = newClub.Name, Id = newClub.Id};
        }

    }
}
