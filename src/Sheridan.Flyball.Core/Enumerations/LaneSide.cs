using System;
using System.Collections.Generic;
using System.Linq;
using Sheridan.Core.Enumerations;

namespace Sheridan.Flyball.Core.Enumerations
{
   
    public class LaneSide : Enumeration
    {
        public static LaneSide Right = new LaneSide(1, nameof(Right));
        public static LaneSide Left = new LaneSide(2, nameof(Left));

        protected LaneSide()
        {
        }

        public LaneSide(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<LaneSide> List() =>
            new[] {Right,Left};

        public static LaneSide FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            //if (state == null)
            //{
            //    throw new OrderingDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            //}

            return state;
        }

        public static LaneSide From(int id)
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