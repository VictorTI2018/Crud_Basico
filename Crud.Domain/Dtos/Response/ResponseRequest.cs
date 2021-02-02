using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Domain.Dtos
{
    public class ResponseRequest
    {
        public object Resource { get; set; }

        public List<string> Messages { get; set; } = new List<string>();

        public bool Status { get; set; }
    }
}
