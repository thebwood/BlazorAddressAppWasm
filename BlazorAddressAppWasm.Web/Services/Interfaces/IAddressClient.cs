using BlazorAddressAppWasm.ClassLibrary.Common;
using BlazorAddressAppWasm.ClassLibrary.DTOs;

namespace BlazorAddressAppWasm.Web.ViewModels.Interfaces
{
    public interface IAddressClient
    {
        Task<Result<GetAddressesResponseDTO>> GetAddresses();
        Task<Result<GetAddressResponseDTO>> GetAddress(Guid id);

        Task<Result> AddAddress(GetAddressResponseDTO addressDTO);

        Task<Result> UpdateAddress(GetAddressResponseDTO addressDTO);
        Task<Result> DeleteAddress(Guid id);

    }
}
