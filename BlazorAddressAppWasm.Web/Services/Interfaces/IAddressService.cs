using BlazorAddressAppWasm.ClassLibrary.DTOs;

namespace BlazorAddressAppWasm.Web.Services.Interfaces
{
    public interface IAddressService
    {

        Task<List<AddressDTO>> GetAddresses();  
        Task<AddressDTO> GetAddress(Guid id);

        Task<AddressDTO> AddAddress(AddressDTO addressDTO);

        Task UpdateAddress(AddressDTO addressDTO);
        Task DeleteAddress(Guid id);
    }
}
