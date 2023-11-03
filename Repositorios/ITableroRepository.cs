namespace webApi.Repositorios{
    public interface ITableroRepository{
        public Tablero Create(Tablero Tablero);
        public void Update(int id, Tablero Tablero);
        public List<Tablero> GetAll();
        public Tablero Get(int id);
        public List<Tablero> GetByUser(int idUsuario);
        public void Remove(int id);
    }
}