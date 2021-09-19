namespace StarWarsManageShip.Models
{
    public class PilotoNavesView
    {
        public int Id { get; set; }
        public int IdPiloto { get; set; }
        public string piloto { get; set; }
        public string planeta { get; set; }
        public string nave { get; set; }
        public bool Autorizado { get; set; }
    }
}