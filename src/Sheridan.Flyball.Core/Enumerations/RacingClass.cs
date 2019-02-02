using System;
using System.Collections.Generic;
using System.Linq;

namespace Sheridan.Flyball.Core.Enumerations
{
    public class RacingClass : Enumeration
    {
        public static RacingClass Open = new RacingClass(1, nameof(Open).ToLowerInvariant());
        public static RacingClass Regular = new RacingClass(2, nameof(Regular).ToLowerInvariant());
        public static RacingClass Veteran = new RacingClass(3, nameof(Veteran).ToLowerInvariant());
       


        protected RacingClass()
        {
        }

        public RacingClass(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<RacingClass> List() =>
            new[] { Open,Regular,Veteran };

        public static RacingClass FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            //if (state == null)
            //{
            //    throw new OrderingDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            //}

            return state;
        }

        public static RacingClass From(int id)
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