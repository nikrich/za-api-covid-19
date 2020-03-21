using Covid19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Extenstions
{
    public static class StringExtensions
    {
        public static CaseModel MapCase(this string data)
        {
            var items = data.Split(",");

            if (items.Count() == 0)
                return default;

            return new CaseModel
            {
                CaseId = items.Count() > 0 && int.TryParse(items[0], out int id) ? id : 0,
                Date = items.Count() > 1 && DateTime.TryParse(items[1], out DateTime date) ? date : DateTime.MinValue,
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

            foreach (var line in lines)
                models.Add(line.MapCase());

            // Pop the First one as it's the headings
            models.RemoveAt(0);

            return models;
        }
    }
}
