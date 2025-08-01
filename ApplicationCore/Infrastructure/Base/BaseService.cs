using AGL.Api.ApplicationCore.Interfaces;
using AGL.Api.ApplicationCore.Models;

namespace AGL.Api.ApplicationCore.Infrastructure.Base
{
    public class BaseService
    {
        public BaseService()
        {


        }
        protected IDataResult Successed(object data)
        {
            var result = new Success<dynamic>
            {
                Data = data
            };

            return result;
        }

        protected IDataResult Successed()
        {
            var result = new Success<dynamic>();

            return result;
        }


    }
}
