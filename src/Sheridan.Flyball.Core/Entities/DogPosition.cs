using Sheridan.Core.Models;
using Sheridan.Flyball.Core.Enumerations;

namespace Sheridan.Flyball.Core.Entities
{
    public class DogPosition: BaseEntityInt
    {
        public DogPosition(Position position, Dog dog)
        {
            Position = position;
            Dog = dog;
        }

        public DogPosition()
        {
            
        }
        public Position Position { get; set; }
        public Dog Dog { get; set; }
        public int HeatId { get; set; }


    }
}