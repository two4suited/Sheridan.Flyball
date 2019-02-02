using System;
using System.Collections.Generic;
using System.Linq;

namespace Sheridan.Flyball.Core.Enumerations
{
   
    public class Position : Enumeration
    {
        public static Position Start = new Position(1, nameof(Start).ToLowerInvariant());
        public static Position StartReRun = new Position(2, nameof(StartReRun).ToLowerInvariant());
        public static Position First = new Position(3, nameof(First).ToLowerInvariant());
        public static Position Second = new Position(4, nameof(Second).ToLowerInvariant());
        public static Position Third = new Position(5, nameof(Third).ToLowerInvariant());
        public static Position Fourth = new Position(6, nameof(Fourth).ToLowerInvariant());


        protected Position()
        {
        }

        public Position(int id, string name)
            : base(id, name)
        {
        }

        public Position NextPosition( bool startReRun,Fault fault)
        {
            Position p = null;
            
            if (this.Equals(Position.Start) && startReRun && fault != null &&  fault.Equals(Fault.BadStart))
            {
                p = Position.StartReRun;
            }
            else if (this.Equals(Position.Start) || this.Equals(Position.StartReRun))
            {
                p = Position.First;
            }
            else if (this.Equals(Position.First))
            {
                p = Position.Second;
            }
            else if (this.Equals(Position.Second))
            {
                p = Position.Third;
            }
            else if (this.Equals(Position.Third))
            {
                p = Position.Fourth;
            }

            return p;
        }

        public static IList<Position> GetFullRunPositions() =>
            new[] {First, Second, Third, Fourth};

        public static IEnumerable<Position> List() =>
            new[] { Start,StartReRun,First,Second,Third,Fourth };

        public static Position FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            //if (state == null)
            //{
            //    throw new OrderingDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            //}

            return state;
        }

        public static Position From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            //if (state == null)
            //{
            //    throw new OrderingDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            //}

            return state;
        }
    }
}