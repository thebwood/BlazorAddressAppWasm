

using BlazorAddressAppWasm.ClassLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAddressAppWasm.ClassLibrary.DTOs
{
    public class GetAddressesResponseDTO
    {
        public List<AddressViewModel> AddressList { get; set; }

    }
}
