using Sheridan.Flyball.Core.Entities;

namespace Sheridan.Flyball.Core.ViewModels.Update
{
    public class UpdateClubModel
    {
        public int Id { get; set; }
        public int NafaClubNumber { get; set; }
        public string Name { get; set; }

        public static Club ToClub(UpdateClubModel newClub,Club club)
        {
            club.NafaClubNumber = newClub.NafaClubNumber;
            club.Name = newClub.Name;

            return club;
        }

    }
}
