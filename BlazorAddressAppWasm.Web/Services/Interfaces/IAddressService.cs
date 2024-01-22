using BlazorAddressAppWasm.ClassLibrary.Classes;
using BlazorAddressAppWasm.ClassLibrary.DTOs;

namespace BlazorAddressAppWasm.Web.Services.Interfaces
{
    public interface IAddressService
    {

        Task<List<AddressDTO>> GetAddresses();  
        Task<AddressDTO> GetAddress(Guid id);

        Task<Result> AddAddress(AddressDTO addressDTO);

        Task<Result> UpdateAddress(AddressDTO addressDTO);
        Task<Result> DeleteAddress(Guid id);
    }
}
