using BlazorAddressAppWasm.ClassLibrary.Classes;
using BlazorAddressAppWasm.ClassLibrary.DTOs;

namespace BlazorAddressAppWasm.Web.Services.Interfaces
{
    public interface IAddressService
    {

        Task<GetAddressesResponseDTO> GetAddresses();  
        Task<GetAddressResponseDTO> GetAddress(Guid id);

        Task<Result> AddAddress(GetAddressResponseDTO addressDTO);

        Task<Result> UpdateAddress(GetAddressResponseDTO addressDTO);
        Task<Result> DeleteAddress(Guid id);
    }
}
