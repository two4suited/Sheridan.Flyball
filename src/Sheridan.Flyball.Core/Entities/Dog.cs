using Sheridan.Core.Models;

namespace Sheridan.Flyball.Core.Entities
{
    public class Dog : BaseEntityInt
    {
        public string NafaCrn { get; set; }
        public int PersonId { get; set; }
    }
}
