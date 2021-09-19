using System.Collections.Generic;

namespace StarWarsManageShip.Models
{

    public class NavePilotoRelacaoModel
    {
        public int id { get; set; }
        public string value { get; set; }
    }
    public class NavePilotoView
    {
        public List<NavePilotoRelacaoModel> Pilotos;
        public List<NavePilotoRelacaoModel> Naves;
        public List<NavePilotoRelacaoModel> Planetas;

        public NavePilotoView() { }
        public NavePilotoView(List<NavePilotoRelacaoModel> _piloto, List<NavePilotoRelacaoModel> _naves, List<NavePilotoRelacaoModel> _planeta)
        {
            Pilotos = _piloto;
            Naves = _naves;
            Planetas = _planeta;
        }
    }
}