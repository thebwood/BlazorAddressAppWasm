using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAddressAppWasm.ClassLibrary.DTOs
{
    public class GetAddressesRequestDTO
    {
        public string SearchText { get; set; } = string.Empty;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
