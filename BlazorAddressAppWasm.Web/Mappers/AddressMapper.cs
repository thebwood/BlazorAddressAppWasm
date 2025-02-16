using BlazorAddressAppWasm.ClassLibrary.DTOs;
using BlazorAddressAppWasm.ClassLibrary.Models;

namespace BlazorAddressAppWasm.Web.Mappers
{
    public static class AddressMapper
    {
        public static AddressModel MapToAddressModel(AddressDTO dto)
        {
            return new AddressModel
            {
                Id = dto.Id ?? Guid.Empty, // Handle nullable Guid
                StreetAddress = dto.StreetAddress,
                StreetAddress2 = dto.StreetAddress2,
                City = dto.City,
                State = dto.State,
                PostalCode = dto.PostalCode
            };
        }

    }
}
