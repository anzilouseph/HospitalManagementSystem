using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace HMS.Utility
{
    public class ApiHelper<T> 
    {
        public ApiHelper(T data, string message, bool status)
        {
            this.data = data;
            this.message = message;
            this.status = status;
        }

        public T data { get; set; }
        public string message { get; set; }
        public bool status { get; set; }

        public static ApiHelper<T> Error(string message)
        {
            return new ApiHelper<T>(default,message,false);
        }
        public static ApiHelper<T> Success(T data, string message)
        {
            return new ApiHelper<T>(data,message,true);
        }
    }
}
