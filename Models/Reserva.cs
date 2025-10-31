namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a suíte foi cadastrada
            if (Suite == null)
                throw new InvalidOperationException("A suíte deve ser cadastrada antes de adicionar hóspedes.");

            // Verifica se a capacidade é suficiente
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
                Console.WriteLine("Reserva realizada com sucesso!");
            }
            else
            {
                // Lança exceção se exceder a capacidade
                throw new Exception("A quantidade de hóspedes excede a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
                throw new InvalidOperationException("A suíte deve ser cadastrada antes de calcular o valor da diária.");

            // Calcula o valor total
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Aplica desconto de 10% para 10 dias ou mais
            if (DiasReservados >= 10)
            {
                valor *= 0.9M;
            }

            return valor;
        }
    }
}
