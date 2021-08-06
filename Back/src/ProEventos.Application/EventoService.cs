using System;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Application.Contratos;
using ProEventos.Application.Dtos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        private readonly IMapper _mapper;
        public EventoService(IGeralPersist geralPersist, 
                            IEventoPersist eventoPersist,
                            IMapper mapper)
        {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;
            _mapper = mapper;
        }
        public async Task<EventoDto> AddEventos(EventoDto model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);

                _geralPersist.Add<Evento>(evento);
                
                if(await _geralPersist.SaveChangesAsync())
                {
                    var eventoRetorno = await _eventoPersist.GetAllEventoByIdAsync(evento.Id, false);
                    return _mapper.Map<EventoDto>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
        {
            try
            {
                var evento = await _eventoPersist.GetAllEventoByIdAsync(eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _mapper.Map(model, evento);

                _geralPersist.Update<Evento>(evento);

                if(await _geralPersist.SaveChangesAsync())
                {
                    var eventoRetorno = await _eventoPersist.GetAllEventoByIdAsync(evento.Id, false);
                    return _mapper.Map<EventoDto>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetAllEventoByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("Evento para delete não encontrado.");

                _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosByAsync(bool includePalestrantes = false)
        {
            try
            {
               var eventos = await _eventoPersist.GetAllEventosByAsync(includePalestrantes);
               if(eventos == null) return null;

               var resultado = _mapper.Map<EventoDto[]>(eventos);

               return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<EventoDto> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
               var eventos = await _eventoPersist.GetAllEventoByIdAsync(eventoId,includePalestrantes);
               if(eventos == null) return null;

               var resultado = _mapper.Map<EventoDto>(eventos);

               return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
               var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
               if(eventos == null) return null;

               var resultado = _mapper.Map<EventoDto[]>(eventos);

               return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}