using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrud.shared
{
    public class ResponseAPI<T>
    {
        public bool Success { get; set; }

        public T? Value { get; set; }

        public string? Mesaje { get; set; }
    }
}
