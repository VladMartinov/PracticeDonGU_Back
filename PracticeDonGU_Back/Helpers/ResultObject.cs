using Microsoft.AspNetCore.Mvc;

namespace PracticeDonGU_Back.Helpers
{
    public class ResultObject
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public IActionResult? Result { get; set; }
        public object? Object { get; set; }

        public ResultObject() { }

        public ResultObject(bool Success, string Message, IActionResult? Result, object? Object)
        {
            this.Success = Success;
            this.Message = Message;
            if (Result != null) this.Result = Result;
            if (Object != null) this.Object = Object;
        }
    }
}
