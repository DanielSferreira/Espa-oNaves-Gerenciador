using System.Collections.Generic;
using StarWarsManageShip.Models;

namespace StarWarsManageShip.Models
{
    public class ListarNaves
    {
        public string Count { get; set; }
        public string Next { get; set; }
        public string Previus { get; set; }
        public IEnumerable<NavesEspaciais> Results { get; set; }
    }
}
