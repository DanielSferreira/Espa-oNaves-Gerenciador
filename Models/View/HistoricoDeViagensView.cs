namespace StarWarsManageShip.Models
{
    public class HistoricoDeViagensView
    {
        public int Id { get; set; }
        public string piloto { get; set; }
        public string planeta { get; set; }

        public string nave { get; set; }
        public string dtSaida { get; set; }
        public string dtChegada { get; set; }
    }
}