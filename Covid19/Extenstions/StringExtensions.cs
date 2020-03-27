using Covid19.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Extenstions
{
    public static class StringExtensions
    {
        public static CumulativeModel MapCumulative(this string data)
        {
            var items = data.Split(",");

            if (items.Count() < 11)
                return default;

            return new CumulativeModel
            {              
                Date = DateTime.ParseExact(items[0], "dd-MM-yyyy", CultureInfo.InvariantCulture),
                DatePlain = items[1],               
                EasternCape = int.TryParse(items[2], out int ec) ? ec : 0,
                FreeState = int.TryParse(items[3], out int fs) ? fs : 0,
                Gauteng = int.TryParse(items[4], out int gp) ? gp : 0,
                KwazuluNatal = int.TryParse(items[5], out int kzn) ? kzn : 0,
                Limpopo = int.TryParse(items[6], out int lp) ? lp : 0,
                Mpumalanga = int.TryParse(items[7], out int mp) ? mp : 0,
                NorthernCape = int.TryParse(items[8], out int nc) ? nc : 0,
                NorthWest = int.TryParse(items[9], out int nw) ? nw : 0,
                WesternCape = int.TryParse(items[10], out int wc) ? wc : 0,
                Unknown = int.TryParse(items[11], out int u) ? u : 0
            };
        }

        public static List<CumulativeModel> MapCumulativeList(this string data)
        {
            var lines = data.Split("\n");

            if (lines.Count() == 0)
                return default;

            var models = new List<CumulativeModel>();

            var index = 0;
            foreach (var line in lines)
            {
                // Skip the First one as it's the headings
                if (index != 0)
                {
                    var item = line.MapCumulative();
                    if (item != null)
                        models.Add(item);
                }

                index++;
            }

            return models;
        }

        public static CaseModel MapCase(this string data)
        {
            var items = data.Split(",");

            if (items.Count() < 8)
                return default;

            return new CaseModel
            {
                CaseId = int.TryParse(items[0], out int id) ? id : 0,
                Date = DateTime.ParseExact(items[1], "dd-MM-yyyy", CultureInfo.InvariantCulture),
                DatePlain = items[2],
                Country = items[3],
                Province = items[4],
                GeoSubdivisions = items[5],
                Age = int.TryParse(items[6], out int age) ? age : 0,
                Gender = items[7],
                TransmissionType = items[8],
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

        public static DeathsModel MapDeath(this string data)
        {
            var items = data.Split(",");

            if (items.Count() < 8)
                return default;

            return new DeathsModel
            {
                CaseId = int.TryParse(items[0], out int id) ? id : 0,
                Date = DateTime.ParseExact(items[1], "dd-MM-yyyy", CultureInfo.InvariantCulture),
                DatePlain = items[2]
            };
        }

        public static List<DeathsModel> MapDeathsList(this string data)
        {
            var lines = data.Split("\n");

            if (lines.Count() == 0)
                return default;

            var models = new List<DeathsModel>();

            var index = 0;
            foreach (var line in lines)
            {
                // Skip the First one as it's the headings
                if (index != 0)
                {
                    var item = line.MapDeath();
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
                Date = DateTime.ParseExact(items[0], "dd-MM-yyyy", CultureInfo.InvariantCulture),
                DatePlain = items[1],
                CmulativeTests = int.TryParse(items[2], out int c) ? c : 0,
                Recovered = int.TryParse(items[3], out int r) ? r : 0,
                Deaths = int.TryParse(items[4], out int d) ? d : 0,
                ScannedTravellers = int.TryParse(items[5], out int s) ? s : 0,
                PassengersElevatedTemperature = int.TryParse(items[6], out int p) ? p : 0,
                CovidSuspectedCriteria = int.TryParse(items[7], out int co) ? co : 0,
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

        public static HospitalsPublicModel MapHospitalsPublic(this string data)
        {
            var items = data.Split(",");

            if (items.Count() < 7)
                return default;

            return new HospitalsPublicModel
            {
                Name = items[0],
                Long = items[1],
                Lat = items[2],
                Category = items[3],
                Province = items[4], 
                District = items[5],
                SubDistrict = items[6]
            };
        }

        public static List<HospitalsPublicModel> MapHospitalsPublicList(this string data)
        {
            var lines = data.Split("\n");

            if (lines.Count() == 0)
                return default;

            var models = new List<HospitalsPublicModel>();

            var index = 0;
            foreach (var line in lines)
            {
                // Skip the First one as it's the headings
                if (index != 0)
                {
                    var item = line.MapHospitalsPublic();
                    if (item != null)
                        models.Add(item);
                }


                index++;
            }

            return models;
        }

        public static HospitalsPrivateModel MapHospitalsPrivate(this string data)
        {
            var items = data.Split(",");

            if (items.Count() < 4)
                return default;

            return new HospitalsPrivateModel
            {
                Id = int.TryParse(items[0], out int i) ? i : 0,
                HospitalName = items[1],
                Long = items[2],
                Lat = items[3],             
                Province = items[4]
            };
        }

        public static List<HospitalsPrivateModel> MapHospitalsPrivateList(this string data)
        {
            var lines = data.Split("\n");

            if (lines.Count() == 0)
                return default;

            var models = new List<HospitalsPrivateModel>();

            var index = 0;
            foreach (var line in lines)
            {
                // Skip the First one as it's the headings
                if (index != 0)
                {
                    var item = line.MapHospitalsPrivate();
                    if (item != null)
                        models.Add(item);
                }


                index++;
            }

            return models;
        }
    }
}
