using System;
using Sheridan.Core.Models;

namespace Sheridan.Flyball.Core.Entities
{
    public class RaceYear: BaseEntityInt
    {
        public RaceYear()
        {
            
        }
        public RaceYear(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public RaceYear(int startYear, int endYear)
        {
            StartDate = new DateTime(startYear,11,1);
            EndDate = new DateTime(endYear,10,31);
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string GetRaceYearByDate(DateTime date)
        {
            throw new System.NotImplementedException();
        }


        public DateTime? GetStartDate(string raceYear)
        {
            if (!raceYear.Contains("-")) return null;

            string[] splitYear = raceYear.Split('-');

            return new DateTime(Convert.ToInt16(splitYear[0]),11,1);
        }

        public DateTime? GetEndDate(string raceYear)
        {
            if (!raceYear.Contains("-")) return null;

            string[] splitYear = raceYear.Split('-');

            return new DateTime(Convert.ToInt16(splitYear[1]), 10, 31);
        }

        public string GetYears()
        {
            return $"{StartDate.Year}-{EndDate.Year}";
        }
    }
}