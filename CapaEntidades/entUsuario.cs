namespace CapaEntidades
{
    public class entUsuario
    {
        public int idUsuario { get; set; }
        public String nombres { get; set; }
        public String apellidos { get; set; }
        public String tipoUsuario { get; set; } //(Empleado, Estudiante, Visitante)
        public int dni { get; set; }
        public int celular { get; set; }
        public Boolean estado { get; set; } //Habilitado o Inhabilitado

    }
}
