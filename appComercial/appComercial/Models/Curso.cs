namespace appComercial.Models
{
    public class Curso
    {
        public int Id { get; set; }  // Se genera automáticamente debido al tipo IDENTITY en SQL
        public string CursoNombre { get; set; }  // Columna NVARCHAR(150), hemos renombrado a "CursoNombre" para mejor semántica
        public int Creditos { get; set; }  // Columna INT
        public int HorasSemanal { get; set; }  // Columna INT
        public string Ciclo { get; set; }  // Columna NVARCHAR(10)

        // Relación con la tabla Docente
        public int? IdDocente { get; set; }  // Columna INT que puede ser nula
        public Docente Docente { get; set; }  // Relación de navegación con la entidad Docente
    }


}
