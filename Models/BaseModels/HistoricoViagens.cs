namespace StarWarsManageShip.Models
{
    public class HistoricoViagens
    {
        public int Id { get; set; }
        public int IdPiloto { get; set; }
        public int IdNave { get; set; }
        public int IdPlaneta { get; set; }
        public System.DateTime dtSaida { get; set; }
        public System.DateTime dtChegada { get; set; }
    }
}