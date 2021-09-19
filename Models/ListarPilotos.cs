using System.Collections.Generic;
using StarWarsManageShip.Models;

namespace StarWarsManageShip.Models
{
    public class ListarPilotos
    {
        public string Count { get; set; }
        public string Next { get; set; }
        public string Previus { get; set; }
        public IEnumerable<Pilotos> Results { get; set; }
    }
}
