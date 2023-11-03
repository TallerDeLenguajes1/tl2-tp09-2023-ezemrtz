namespace webApi.Repositorios{
    public interface ITareaRepository{
        public Tarea Create(int idTablero, Tarea Tarea);
        public void Update(int id, Tarea Tarea);
        public Tarea Get(int id);
        public List<Tarea> GetByTablero(int idTablero);
        public List<Tarea> GetByUser(int idUsuario);
        public void Remove(int id);
        public void AsignarAUsuario(int idUsuario, int idTarea);
    }
}