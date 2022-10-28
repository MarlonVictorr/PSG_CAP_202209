using Atacado.Dominio.FrotaVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.FrotaVeiculo
{
    public class FrotaContexto
    {
        public List<Frota> Frotas
        {
            get => FrotaFakeDB.Frotas;
        }

        public List<EventoFrota> Eventos
        {
            get => EventoFrotaFakeDB.Eventos;
        }

        public List<Caminhao> Caminhaos
        {
            get => CaminhaoFakeDB.Caminhaos;
        }
        public List<Carro> Carros
        {
            get => CarroFakeDB.Carros;
        }
        public List<Motocicleta> Motocicletas
        {
            get => MotocicletaFakeDB.Motocicletas;
        }
        public List<Utilitario> Utilitarios
        {
            get => UtilitarioFakeDB.Utilitarios;
        }

        public FrotaContexto()
        {
        }

        public Frota AddFrota(Frota instancia)
        {
            int novaChave = this.Frotas.Count + 1;
            instancia.Codigo = novaChave;
            this.Frotas.Add(instancia);
            return instancia;
        }

        public EventoFrota AddEventoFrota(EventoFrota instancia)
        {
            int novaChave = this.Eventos.Count + 1;
            instancia.Codigo = novaChave;
            this.Eventos.Add(instancia);
            return instancia;
        }

        public Caminhao AddCaminhao(Caminhao instancia)
        {
            int novaChave = this.Caminhaos.Count + 1;
            instancia.Codigo = novaChave;
            this.Caminhaos.Add(instancia);
            return instancia;
        }
        public Carro AddCarro(Carro instancia)
        {
            int novaChave = this.Carros.Count + 1;
            instancia.Codigo = novaChave;
            this.Carros.Add(instancia);
            return instancia;
        }
        public Motocicleta AddMotocicleta(Motocicleta instancia)
        {
            int novaChave = this.Motocicletas.Count + 1;
            instancia.Codigo = novaChave;
            this.Motocicletas.Add(instancia);
            return instancia;
        }
        public Utilitario AddUtilitario(Utilitario instancia)
        {
            int novaChave = this.Utilitarios.Count + 1;
            instancia.Codigo = novaChave;
            this.Utilitarios.Add(instancia);
            return instancia;
        }
    }
}
