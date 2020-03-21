using Covid19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Interfaces
{
    public interface ITestsService
    {
        Task<List<TestsModel>> GetAll();
    }
}
