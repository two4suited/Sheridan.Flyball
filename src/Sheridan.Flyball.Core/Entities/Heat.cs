using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Sheridan.Core.Models;
using Sheridan.Flyball.Core.Enumerations;

namespace Sheridan.Flyball.Core.Entities
{
    public class Heat : BaseEntityInt
    {

        public int HeatNumber { get; set; }
        private readonly List<DogPosition> _lineup = new List<DogPosition>();
        public IEnumerable<DogPosition> Lineup => new ReadOnlyCollection<DogPosition>(_lineup);

        private readonly List<DogRun> _dogRuns = new List<DogRun>();
        public IEnumerable<DogRun> DogRuns => new ReadOnlyCollection<DogRun>(_dogRuns);

        public double HeatTime { get; set; }
        public Outcome Outcome { get; set; }

 

        public DogRun AddStartTime(Dog dog, double time, Fault fault,Division division)
        {
            return AddTime(dog,Position.Start,time,fault,division);
        }

        public DogRun AddStartTimeReRun(Dog dog, double time, Fault fault,Division division)
        {
           return  AddTime(dog, Position.StartReRun, time, fault,division);
        }

        public DogRun AddTime(Dog dog, Position position, double time, Fault fault,Division division)
        {
            _dogRuns.Add(new DogRun(position, dog, time, fault));

            if ((position.Id == _lineup.Count) || (!division.ReRunStart()) && position.Id-1 == _lineup.Count)
            {
                return null;
            }
            else
            {
                DogRun nextDog = new DogRun();
                nextDog.Position = position.NextPosition(division.ReRunStart(), fault);
                
                nextDog.Dog = Lineup.Single(x => x.Position.Equals(nextDog.Position)).Dog;

                return nextDog;
            }

            

        }
    

        public void AddResult(double time, Outcome outcome)
        {
            HeatTime = time;
            Outcome = outcome;

        }


        public int Points()
        {
            if (HeatTime < 24)
                return 25;
            else if (HeatTime < 28)
                return 5;
            else if (HeatTime < 32)
                return 1;
            else
                return 0;

        }

        

        public void AddDogToLineup(Division division,params Dog[] dogs)
        {
            if (dogs.Length > 0)
            {
                _lineup.Add(new DogPosition(Position.Start, dogs[0]));
                if (division.ReRunStart())
                {
                    _lineup.Add(new DogPosition(Position.StartReRun, dogs[0]));

                }

                _lineup.Add(new DogPosition(Position.First,dogs[0]));
               
            }

            if (dogs.Length > 1)
            {
                _lineup.Add(new DogPosition(Position.Second, dogs[1]));
            }

            if (dogs.Length > 2)
            {
                _lineup.Add(new DogPosition(Position.Third, dogs[2]));
                _lineup.Add(new DogPosition(Position.Fourth, dogs[3]));
            }
        }

       
    }
}
