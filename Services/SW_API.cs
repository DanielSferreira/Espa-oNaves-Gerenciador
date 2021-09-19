using System;
using System.Collections.Generic;
using RestSharp;
using StarWarsManageShip.Models;

namespace StarWarsManageShip.Services
{
    public class SwApi
    {
        private IRestClient client;

        public SwApi()
        {
            client = new RestClient("https://swapi.dev/api/");
        }
        public T Execute<T>(RestRequest req) where T : new()
        {
            var res = client.Execute<T>(req);
            if (res.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var twilioException = new Exception(message, res.ErrorException);
                throw twilioException;
            }
            return res.Data;
        }

        public ListaPlanetas PlanetasPage(int i)
        {
            var request = new RestRequest("planets/?page=" + i);
            return Execute<ListaPlanetas>(request);
        }
        public ListarPilotos PilotosPage(int i)
        {
            var request = new RestRequest("people/?page=" + i);
            return Execute<ListarPilotos>(request);
        }
        public ListarNaves NavesPage(int i)
        {
            var request = new RestRequest("starships/?page=" + i);
            return Execute<ListarNaves>(request);
        }

        public List<Planetas> ListarPlanetas()
        {
            List<Planetas> _list = new List<Planetas>();
            int cont = 0;
            do
            {
                var page = PlanetasPage(++cont);
                if (page.Next == null)
                    break;
                else
                    _list.AddRange(page.Results);
            } while (true);
            return _list;
        }
        public List<Pilotos> ListarPilotos()
        {
            List<Pilotos> _list = new List<Pilotos>();
            int cont = 0;
            do
            {
                var page = PilotosPage(++cont);
                if (page.Next == null)
                    break;
                else
                    _list.AddRange(page.Results);
            } while (true);
            return _list;
        }
        public List<NavesEspaciais> ListarNaves()
        {
            List<NavesEspaciais> _list = new List<NavesEspaciais>();
            int cont = 0;
            do
            {
                var page = NavesPage(++cont);
                if (page.Next == null)
                    break;
                else
                    _list.AddRange(page.Results);
            } while (true);
            return _list;
        }
    }
}