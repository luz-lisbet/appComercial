namespace appComercial.Models
{
    public class Docente
    {
        public int Id { get; set; }  // Se genera automáticamente debido al tipo IDENTITY en SQL
        public string Apellidos { get; set; }  // Columna NVARCHAR(100)
        public string Nombres { get; set; }  // Columna NVARCHAR(100)
        public string Profesion { get; set; }  // Columna NVARCHAR(100)
        public DateTime FechaNacimiento { get; set; }  // Columna DATE
        public string Correo { get; set; }  // Columna NVARCHAR(150)
    }

}
