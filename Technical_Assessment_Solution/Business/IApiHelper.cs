using System.Threading.Tasks;
using Technical_Assessment_Solution.Models;

namespace Technical_Assessment_Solution.Business
{
    public interface IApiHelper
    {
        Task<AssessmentViewModel> GetJsonData();
    }
}
