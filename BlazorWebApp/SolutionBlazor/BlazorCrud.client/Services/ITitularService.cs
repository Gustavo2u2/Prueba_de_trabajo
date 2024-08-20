using BlazorCrud.shared;

namespace BlazorCrud.client.Services
{
    public interface ITitularService
    {

        Task<List<TitularDTO>> list();
    }
}
