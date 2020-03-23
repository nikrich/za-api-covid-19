using Covid19.Contants;
using Covid19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Utilities
{
    public static class CumulativeUtility
    {
        public static int GetTotal(List<CumulativeModel> model)
        {
            var final = model.Last();

            if (final == null)
                return Int32.MinValue;

            return final.EasternCape +
                final.FreeState +
                final.Gauteng +
                final.KwazuluNatal +
                final.Limpopo +
                final.Mpumalanga +
                final.NorthernCape +
                final.NorthWest +
                final.WesternCape;
        }

        public static int GetTotalForProvince(List<CumulativeModel> model, string province)
        {
            var final = model.Last();

            if (final == null)
                return Int32.MinValue;

            switch(province.ToUpper())
            {
                case Constants.EasternCape: return final.EasternCape;
                case Constants.FreeState: return final.FreeState;
                case Constants.Gauteng: return final.Gauteng;
                case Constants.KwazuluNatal: return final.KwazuluNatal;
                case Constants.Limpopo: return final.Limpopo;
                case Constants.Mpumalanga: return final.Mpumalanga;
                case Constants.NorthernCape: return final.EasternCape;
                case Constants.NorthWest: return final.NorthernCape;
                case Constants.WesternCape: return final.WesternCape;
                default: return Int32.MinValue;
            }            
        }

        public static List<CountModel> GetCumulative(List<CumulativeModel> model)
        {
            var final = model.Last();

            if (final == null)
                return default;

            return model.GroupBy(x => x.Date)
                 .Select(x => new CountModel
                 {
                     CasesTotal = x.Sum(e => e.GetCountTotal()),
                     Date = x.Key
                 }).ToList();
        }

        public static List<CountModel> GetCumulativeForProvince(List<CumulativeModel> model, string province)
        {
            return model.GroupBy(x => x.Date)
                .Select(x => new CountModel
                {
                    CasesTotal = x.Sum(e => e.GetCountForProvince(province)),
                    Date = x.Key
                }).ToList();
        }

        private static int GetCountForProvince(this CumulativeModel model, string province)
        {
            switch (province.ToUpper())
            {                
                case Constants.EasternCape: return model.EasternCape;
                case Constants.FreeState: return model.FreeState;
                case Constants.Gauteng: return model.Gauteng;
                case Constants.KwazuluNatal: return model.KwazuluNatal;
                case Constants.Limpopo: return model.Limpopo;
                case Constants.Mpumalanga: return model.Mpumalanga;
                case Constants.NorthernCape: return model.EasternCape;
                case Constants.NorthWest: return model.NorthernCape;
                case Constants.WesternCape: return model.WesternCape;
                default: return Int32.MinValue;
            }
        }

        private static int GetCountTotal(this CumulativeModel model)
        {
            return model.EasternCape +
                model.FreeState +
                model.Gauteng +
                model.KwazuluNatal +
                model.Limpopo +
                model.Mpumalanga +
                model.NorthernCape +
                model.NorthWest +
                model.WesternCape;
        }
    }
}
