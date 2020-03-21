﻿using Covid19.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Extenstions
{
    public static class StringExtensions
    {
        public static CaseModel MapCase(this string data)
        {
            var items = data.Split(",");

            if (items.Count() < 8)
                return default;

            return new CaseModel
            {
                CaseId = items.Count() > 0 && int.TryParse(items[0], out int id) ? id : 0,
                Date = items.Count() > 1 ? DateTime.ParseExact(items[1], "dd-MM-yyyy", CultureInfo.InvariantCulture) : DateTime.MinValue,
                DatePlain = items.Count() > 2 ? items[2] : string.Empty,
                Country = items.Count() > 3 ? items[3] : string.Empty,
                Province = items.Count() > 4 ? items[4] : string.Empty,
                GeoSubdivisions = items.Count() > 5 ? items[5] : string.Empty,
                Age = items.Count() > 6 && int.TryParse(items[6], out int age) ? age : 0,
                Gender = items.Count() > 7 ? items[7] : string.Empty,
                TransmissionType = items.Count() > 8 ? items[8] : string.Empty,
            };
        }

        public static List<CaseModel> MapCaseList(this string data)
        {
            var lines = data.Split("\n");

            if (lines.Count() == 0)
                return default;

            var models = new List<CaseModel>();

            var index = 0;
            foreach (var line in lines)
            {
                // Skip the First one as it's the headings
                if (index != 0)
                {
                    var item = line.MapCase();
                    if (item != null)
                        models.Add(item);
                }

                index++;
            }   

            return models;
        }

        public static TestsModel MapTests(this string data)
        {
            var items = data.Split(",");

            if (items.Count() < 5)
                return default;

            return new TestsModel
            {
                Date = items.Count() > 0 ? DateTime.ParseExact(items[0], "dd-MM-yyyy", CultureInfo.InvariantCulture) : DateTime.MinValue,
                DatePlain = items.Count() > 1 ? items[1] : string.Empty,
                CmulativeTests = items.Count() > 2 && int.TryParse(items[2], out int c) ? c : 0,
                ScannedTravellers = items.Count() > 3 && int.TryParse(items[3], out int s) ? s : 0,
                PassengersElevatedTemperature = items.Count() > 4 && int.TryParse(items[4], out int p) ? p : 0,
                CovidSuspectedCriteria = items.Count() > 5 && int.TryParse(items[5], out int co) ? co : 0,
            };
        }

        public static List<TestsModel> MapTestsList(this string data)
        {
            var lines = data.Split("\n");

            if (lines.Count() == 0)
                return default;

            var models = new List<TestsModel>();

            var index = 0;
            foreach (var line in lines)
            {
                // Skip the First one as it's the headings
                if (index != 0)
                {
                    var item = line.MapTests();
                    if (item != null)
                        models.Add(item);
                }
                    

                index++;
            }

            return models;
        }
    }
}