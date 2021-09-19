namespace StarWarsManageShip.Models
{

    public class PilotoNaves
    {
        public int Id {get; set;}
        public int IdPiloto {get; set;}
        public int IdNave {get; set;}
        public int IdPlaneta {get; set;}
        public bool Autorizado {get; set;}
    }
}