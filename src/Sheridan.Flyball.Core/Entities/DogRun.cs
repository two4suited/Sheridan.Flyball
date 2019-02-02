using Sheridan.Core.Models;
using Sheridan.Flyball.Core.Enumerations;

namespace Sheridan.Flyball.Core.Entities
{
    public class DogRun : BaseEntityInt
    {
        public DogRun()
        {
            
        }
        public DogRun(Position position, Dog dog, double time, Fault fault) 
        {
            Time = time;
            Fault = fault;
            Position = position;
            Dog = dog;
        }

        public Dog Dog { get; set; }
        public Position Position { get; set; }
        public double Time { get; set; }
        public Fault Fault { get; set; }
      


    }
}