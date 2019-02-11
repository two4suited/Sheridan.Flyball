using System;
using System.Collections.Generic;
using System.Linq;
using Sheridan.Core.Enumerations;

namespace Sheridan.Flyball.Core.Enumerations
{
    
    public class Fault : Enumeration
    {
        public static Fault SpitBall = new Fault(1, nameof(SpitBall));
        public static Fault BadPass = new Fault(2, nameof(BadPass));
        public static Fault Interference = new Fault(3, nameof(Interference));
        public static Fault BadStart = new Fault(4,nameof(BadStart));


        protected Fault()
        {
        }

        public Fault(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<Fault> List() =>
            new[] { SpitBall,BadPass,Interference };

        public static Fault FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            //if (state == null)
            //{
            //    throw new OrderingDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            //}

            return state;
        }

        public static Fault From(int id)
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