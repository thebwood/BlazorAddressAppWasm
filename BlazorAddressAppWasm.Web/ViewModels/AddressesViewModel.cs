﻿using BlazorAddressAppWasm.ClassLibrary.Common;
using BlazorAddressAppWasm.ClassLibrary.DTOs;
using BlazorAddressAppWasm.ClassLibrary.Models;
using BlazorAddressAppWasm.Web.ViewModels.Interfaces;
using BlazorAddressAppWasm.Web.Mappers;
namespace BlazorAddressAppWasm.Web.ViewModels
{
    public class AddressesViewModel
    {
        private readonly IAddressClient _addressService;

        public AddressesViewModel(IAddressClient addressService)
        {
            _addressService = addressService;
        }

        public async Task GetAddresses()
        {
            Result<GetAddressesResponseDTO> result = await _addressService.GetAddresses();
            if (result.Success)
            {
                List<AddressModel> addressViewModels = result.Value.AddressList.Select(dto => AddressMapper.MapToAddressModel(dto)).ToList();
                OnAddressesLoaded(addressViewModels);
            }
            else
            {
                // Handle errors (e.g., log the error, show a message to the user, etc.)
                Console.WriteLine($"Error fetching addresses: {result.Message}");
            }
        }


        public Action<List<AddressModel>>? AddressesLoaded;

        protected virtual void OnAddressesLoaded(List<AddressModel> addresses)
        {
            AddressesLoaded?.Invoke(addresses);
        }
    }
}
