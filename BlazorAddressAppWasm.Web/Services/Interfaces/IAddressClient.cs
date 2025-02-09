using BlazorAddressAppWasm.ClassLibrary.DTOs;
using BlazorAddressAppWasm.ClassLibrary.Models;

namespace BlazorAddressAppWasm.Web.ViewModels.Interfaces
{
    public interface IAddressClient
    {
        Task<GetAddressesResponseDTO> GetAddresses();
        Task<GetAddressResponseDTO> GetAddress(Guid id);

        Task<Result> AddAddress(GetAddressResponseDTO addressDTO);

        Task<Result> UpdateAddress(GetAddressResponseDTO addressDTO);
        Task<Result> DeleteAddress(Guid id);

    }
}
