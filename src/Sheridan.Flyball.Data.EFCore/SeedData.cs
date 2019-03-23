﻿using System.Linq;
using FlyballStatTracker.Data.EfCore;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Enumerations;

namespace Sheridan.Flyball.Data.EFCore
{
    public class SeedData
    {
        public static void PopulateData(FlyballDbContext context,bool IsDevelopment)
        {
            RacingClassPopulate(context);
            FaultPopulate(context);
            LaneSidePopulate(context);
            PositionPopulate(context);
            OutcomePopulate(context);

            if(IsDevelopment)
            {
                DevelopmentData(context);
            }
            
            context.SaveChanges();
        }

        private static void DevelopmentData(FlyballDbContext context)
        {
            Club RipItUp=  new Club()
            {
                NafaClubNumber = 987,
                Name = "Rip It Up",
            };
            context.Clubs.Add(RipItUp);
        }

        private static void RacingClassPopulate(FlyballDbContext context)
        {
            foreach (var racingClass in RacingClass.List())
            {
                var val = context.RacingClasses.FirstOrDefault(x => x.Name == racingClass.Name);
                if (val == null)
                {
                    context.RacingClasses.Add(racingClass);
                }
            }
        }

      

        private static void FaultPopulate(FlyballDbContext context)
        {
            foreach (var fault in Fault.List())
            {
                var val = context.Faults.FirstOrDefault(x => x.Name == fault.Name);
                if (val == null)
                {
                    context.Faults.Add(fault);
                }
            }
        }

        private static void LaneSidePopulate(FlyballDbContext context)
        {
            foreach (var lane in LaneSide.List())
            {
                var val = context.Lane.FirstOrDefault(x => x.Name == lane.Name);
                if (val == null)
                {
                    context.Lane.Add(lane);
                }
            }
        }

        private static void PositionPopulate(FlyballDbContext context)
        {
            foreach (var position in Position.List())
            {
                var val = context.Positions.FirstOrDefault(x => x.Name == position.Name);
                if (val == null)
                {
                    context.Positions.Add(position);
                }
            }
        }

        private static void OutcomePopulate(FlyballDbContext context)
        {
            foreach (var outcome in Outcome.List())
            {
                var val = context.Outcomes.FirstOrDefault(x => x.Name == outcome.Name);
                if (val == null)
                {
                    context.Outcomes.Add(outcome);
                }
            }
        }

    }
}