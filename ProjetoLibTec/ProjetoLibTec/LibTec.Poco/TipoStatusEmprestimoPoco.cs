
namespace LibTec.Poco
{
    public class TipoStatusEmprestimoPoco
    {     
        public int Codigo { get; set; }       
        public string Descricao { get; set; } = null!;      
        public bool? Ativo { get; set; }       
        public DateTime? DataInclusao { get; set; }       
        public DateTime? DataAlteracao { get; set; }       
        public DateTime? DataExclusao { get; set; }
    }
}
