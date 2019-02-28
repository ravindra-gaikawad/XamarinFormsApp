using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinFormsApp.Core.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
        }

        public ResponseModel(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

    }
}
