using System;

namespace jobbe_web.Models
{
    public class ResponseBase<T>
    {
        public T Data { get; set; }
        public bool Sucess { get; set; }
        public string ErrorMessage { get; set; }

        public ResponseBase()
        {
            Sucess = true;
        }

    }
}
