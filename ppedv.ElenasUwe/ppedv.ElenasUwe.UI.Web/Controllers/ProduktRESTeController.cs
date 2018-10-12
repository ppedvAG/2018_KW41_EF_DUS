using AutoMapper;
using ppedv.ElenasUwe.Logic;
using ppedv.ElenasUwe.Model;
using ppedv.ElenasUwe.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ppedv.ElenasUwe.UI.Web.Controllers
{
    public class ProduktRESTeController : ApiController
    {

        static ProduktRESTeController()
        {
            Mapper.Initialize(cfg =>
            cfg.CreateMap<Produkt, Uwe>()
               .ForMember(x => x.GebDatum, y => y.MapFrom(m => m.Created))
               .ReverseMap());

        }
        Core core = new Core();
        // GET: api/ProduktRESTe
        public IEnumerable<Uwe> Get()
        {
            foreach (var i in core.UnitOfWork.ProduktRepository.GetAll())
            {
                yield return Mapper.Map<Uwe>(i);
                //   yield return new Uwe() { Id = i.Id, Name = i.Name, GebDatum = i.Created, Preis = i.Preis };
            }
        }

        // GET: api/ProduktRESTe/5
        public Uwe Get(int id)
        {
            return Mapper.Map<Uwe>(core.UnitOfWork.ProduktRepository.GetById(id));
        }

        // POST: api/ProduktRESTe
        public void Post(Uwe value)
        {
            core.UnitOfWork.ProduktRepository.Add(Mapper.Map<Produkt>(value));
            core.UnitOfWork.Save();
        }

        // PUT: api/ProduktRESTe/5
        public void Put(int id, Uwe value)
        {
            core.UnitOfWork.ProduktRepository.Update(Mapper.Map<Produkt>(value));
            core.UnitOfWork.Save();
        }

        // DELETE: api/ProduktRESTe/5
        public void Delete(int id)
        {
        }
    }
}
