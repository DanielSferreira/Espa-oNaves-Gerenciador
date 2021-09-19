namespace StarWarsManageShip.Services
{
    public class SqlManageService : ISqlManageService
    {

        public PilotoNaveDao pilotoNaves { get; internal set; }
        public PilotosDao pilotos { get; internal set; }
        public PlanetasDao planetas { get; internal set; }
        public NavesEspaciaisDao navesEspaciais { get; internal set; }
        public HistoricoViagensDao historicoViagens { get; internal set; }
        public SqlManageService(string str) : base(str)
        {
            pilotoNaves = new PilotoNaveDao(str);
            pilotos = new PilotosDao(str);
            planetas = new PlanetasDao(str);
            navesEspaciais = new NavesEspaciaisDao(str);
            historicoViagens = new HistoricoViagensDao(str);
        }
    }
}