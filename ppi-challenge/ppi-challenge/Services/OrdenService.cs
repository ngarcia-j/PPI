using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ppi_challenge.Models.DTOs;
using ppi_challenge.Models.Entities;
using ppi_challenge.Repositories;
using ppi_challenge.Strategies;
using System.Runtime.CompilerServices;

namespace ppi_challenge.Services
{
    public class OrdenService : IOrdenService
    {
        private readonly IOrdenRepository _ordenRepository;
        private readonly IMapper _mapper;
        private readonly Dictionary<int, IActivosStrategy> _activoStrategy;

        public OrdenService(IOrdenRepository ordenRepository
                            , IMapper mapper)
        {
            _ordenRepository = ordenRepository;
            _mapper = mapper;
            _activoStrategy = new Dictionary<int, IActivosStrategy>
            {
                {1, new FCIStrategy() },                    //FCI
                {2, new AccionStrategy(_ordenRepository) }, //Accion
                {3, new BonoStrategy() },                   //Bono
            };
        }

        public async Task<IEnumerable<OrdenDto>> GetOrdenes()
        {
            try
            {
                var ordenes = await _ordenRepository.GetAll();
                return _mapper.Map<IEnumerable<OrdenDto>>(ordenes);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la socilitud.", ex);
            }
        }

        public async Task<OrdenDto> GetOrdenesById(int id)
        {
            try
            {
                var orden = await _ordenRepository.GetById(id);
                if (orden == null)
                {
                    throw new Exception($"La orden con ID {id} no fué encontrada.");
                }
                return _mapper.Map<OrdenDto>(orden);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la socilitud.", ex);
            }
            
        }

        public async Task<OrdenDto> CreateOrden(OrdenDto newOrden)
        {
            try
            {
                var orden = _mapper.Map<Orden>(newOrden);

                orden.MontoTotal = await CalcularMontoTotal(newOrden);

                await _ordenRepository.Create(orden);
                return _mapper.Map<OrdenDto>(orden);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la socilitud.", ex);
            }
        }

        private Task<decimal> CalcularMontoTotal(OrdenDto orden)
        {
            if (!_activoStrategy.TryGetValue(orden.IdActivo, out var strategy))
            {
                throw new ArgumentException("Tipo de activo no válido.");
            }
            return strategy.CalcularMontoTotal(orden);
        }


        public async Task<OrdenDto> UpdateOrden(int id, OrdenDto updateOrden)
        {
            try
            {
                await ValidarEstado(updateOrden.Estado);

                var orden = await _ordenRepository.GetById(id);
                if (orden == null)
                {
                    throw new Exception($"La orden con ID {id} no fué encontrada.");
                }

                orden.Estado = updateOrden.Estado;

                await _ordenRepository.Update(orden);
                return _mapper.Map<OrdenDto>(orden);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la socilitud.", ex);
            }
        }

        private async Task ValidarEstado(string estado)
        {
            var estadosValidos = await _ordenRepository.GetEstados();
            if (!estadosValidos.Any(e => e.descripcionEstado.Equals(estado)))
            {
                throw new BadHttpRequestException("El estado ingresado debe ser: 'En proceso', 'Ejecutada' o 'Cancelada'");
            }
        }

        public async Task DeleteOrden(int id)
        {
            try
            {
                var orden = await _ordenRepository.GetById(id);
                if (orden == null)
                {
                    throw new Exception($"La orden con ID {id} no fué encontrada.");
                }

                await _ordenRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la socilitud.", ex);
            }
        }

    }
}
