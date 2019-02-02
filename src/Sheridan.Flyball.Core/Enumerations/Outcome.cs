﻿//namespace FlyballStatTracker.Core.Enums
//{
//    public enum Outcome
//    {
//        Win,
//        Lose,
//        Tie,
//        NF
//    }

//}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Sheridan.Flyball.Core.Enumerations
{

    public class Outcome : Enumeration
    {
        public static Outcome Win = new Outcome(1, nameof(Win).ToLowerInvariant());
        public static Outcome Lose = new Outcome(2, nameof(Lose).ToLowerInvariant());
        public static Outcome Tie = new Outcome(3, nameof(Tie).ToLowerInvariant());
        public static Outcome NF = new Outcome(4, nameof(NF).ToLowerInvariant());


        protected Outcome()
        {
        }

        public Outcome(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<Outcome> List() =>
            new[] { Win };

        public static Outcome FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            //if (state == null)
            //{
            //    throw new OrderingDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            //}

            return state;
        }

        public static Outcome From(int id)
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