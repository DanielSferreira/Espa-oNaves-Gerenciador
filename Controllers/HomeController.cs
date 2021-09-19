using Microsoft.AspNetCore.Mvc;
using StarWarsManageShip.Services;
using StarWarsManageShip.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace StarWarsManageShip.Controllers
{
    public class HomeController : Controller
    {
        SwApi fromApi;
        SqlManageService sqlManageService;
        public HomeController(SwApi b, SqlManageService manageService)
        {
            fromApi = b;
            sqlManageService = manageService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NavePilotoAssociacao()
        {
            List<NavePilotoRelacaoModel> p = new List<NavePilotoRelacaoModel>();
            sqlManageService.pilotos.Obter().ForEach(x => p.Add(new NavePilotoRelacaoModel() { id = x.Id, value = x.name }));

            List<NavePilotoRelacaoModel> n = new List<NavePilotoRelacaoModel>();
            sqlManageService.navesEspaciais.Obter().ForEach(x => n.Add(new NavePilotoRelacaoModel() { id = x.Id, value = x.Model }));
            
            List<NavePilotoRelacaoModel> t = new List<NavePilotoRelacaoModel>();
            sqlManageService.planetas.Obter().ForEach(x => t.Add(new NavePilotoRelacaoModel() { id = x.Id, value = x.Name }));

            return View(new NavePilotoView(p, n, t));
        }
        public IActionResult NavePilotoAssoacaoPost(int idPiloto, int idNave, int idPlaneta)
        {
            bool res = sqlManageService.pilotoNaves.insert(idPiloto, idNave, idPlaneta, true);
            if (res == true) sqlManageService.historicoViagens.insert(idPiloto, idNave, idPlaneta, DateTime.Now);
            else {
                return Redirect("NavePilotoAssociacao");    
            }
            return Redirect("NavesPilotoListagem");
        }
        public IActionResult NavesPilotoListagem()
        {
            var pn = sqlManageService.pilotoNaves.Obter().ToList();

            var pnv = new List<PilotoNavesView>();
            pn.ForEach(item =>
            {
                pnv.Add(new PilotoNavesView()
                {
                    Id = item.Id,
                    piloto = sqlManageService.pilotos.ObterNomePiloto(item.IdPiloto),
                    nave = sqlManageService.navesEspaciais.ObterNomeNave(item.IdNave),
                    Autorizado = item.Autorizado,
                    planeta = sqlManageService.planetas.ObterNomePlaneta(item.IdPlaneta)
                });
            });

            return View(pnv);
        }
        public IActionResult HistoricoViagensListagem()
        {
            var pn = sqlManageService.historicoViagens.Obter();

            var pnv = new List<HistoricoDeViagensView>();
            pn.ForEach(item =>
            {
                pnv.Add(new HistoricoDeViagensView()
                {
                    Id = item.Id,
                    piloto = sqlManageService.pilotos.ObterNomePiloto(item.IdPiloto),
                    nave = sqlManageService.navesEspaciais.ObterNomeNave(item.IdNave),
                    dtSaida = item.dtSaida.ToString("HH:mm - dd/MM"),
                    dtChegada = item.dtChegada.ToString("HH:mm - dd/MM") == "00:00 - 01/01" ? "em curso" : item.dtChegada.ToString("HH:mm - dd/MM"),
                    planeta = sqlManageService.planetas.ObterNomePlaneta(item.IdPlaneta)

                });
            });

            return View(pnv);
        }
        public IActionResult MarcarNavePilotoChegada()
        {
            var pn = sqlManageService.pilotoNaves.Obter();

            var pnv = new List<PilotoNavesView>();
            pn.ForEach(item =>
            {
                pnv.Add(new PilotoNavesView()
                {
                    Id = item.Id,
                    IdPiloto = item.IdPiloto,
                    piloto = sqlManageService.pilotos.ObterNomePiloto(item.IdPiloto),
                    nave = sqlManageService.navesEspaciais.ObterNomeNave(item.IdNave),
                    Autorizado = item.Autorizado
                });
            });

            return View(pnv);
        }
        public IActionResult MarcarNavePilotoChegadaPost(string IdNomeString)
        {
            var res = IdNomeString.Split("|");

            PilotoNaves pn;
            pn = sqlManageService.pilotoNaves.ObterPeloID(int.Parse(res[1]));

            sqlManageService.historicoViagens.update(int.Parse(res[0]), DateTime.Now);
            sqlManageService.pilotoNaves.delete(int.Parse(res[1]));

            return Redirect("HistoricoViagensListagem");
        }
        public IActionResult SincronizarDados()
        {
            var PlanetasModel = fromApi.ListarPlanetas();
            PlanetasModel.ForEach(planeta => sqlManageService.planetas.insert(planeta));
            
            var NavesEspaciaisModel = fromApi.ListarNaves();
            NavesEspaciaisModel.ForEach(nave => sqlManageService.navesEspaciais.insert(nave));
            
            var PilotosModel = fromApi.ListarPilotos();
            PilotosModel.ForEach(piloto => sqlManageService.pilotos.insert(piloto));
            
            return Redirect("Index");
        }
    }
}



