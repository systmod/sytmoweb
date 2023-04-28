namespace Common
{
    public interface IOptionEntity
    {
        string Accion { get; set; }
        string Codigo { get; set; }
        string Descripcion { get; set; }
        string Icono { get; set; }
        string Nombre { get; set; }
        string Operaciones { get; set; }
        int Orden { get; set; }
    }
}