using BlazorAddressAppWasm.ClassLibrary.Models;

namespace BlazorAddressAppWasm.ClassLibrary.DTOs
{
    public class GetAddressResponseDTO
    {
        public GetAddressResponseDTO()
        {
            Address = new AddressDTO();
        }

        public AddressDTO Address { get; set; }

    }
}
