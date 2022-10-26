using Atacado.Dominio.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.RH
{
    public class EnderecoFakeDB
    {
        private static List<Endereco> enderecos;

        public static List<Endereco> Enderecos
        {
            get
            {
                if (enderecos == null)
                {
                    enderecos = new List<Endereco>();
                    Carregar();
                }
                return enderecos;
            }
        }
        private static void Carregar()
        {
            enderecos.Add(new Endereco(1, "Rua Bela Cintra", 102, "Casa", "Tiradentes", "79041-090", "Campo Grande", "MS"));
            enderecos.Add(new Endereco(2, "Rua Claudio Abramo", 114, "Casa", "Aero Rancho", "79084-400.", "Campo Grande", "MS"));
            enderecos.Add(new Endereco(3, "Rua Da Saudade", 370, "Casa", "Tiradentes", "79041-210.", "Campo Grande", "MS"));
            enderecos.Add(new Endereco(4, "Rua San Martin", 310, "Casa", "Tiradentes", "79041-420", "Campo Grande", "MS"));
            enderecos.Add(new Endereco(5, "Rua Franklin Pael", 217, "Casa", "Tiradentes", "79041-501.", "Campo Grande", "MS"));
        }
    }
}
