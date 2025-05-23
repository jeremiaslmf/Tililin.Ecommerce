using Tililin.Domain.ValueObjects;

namespace Tililin.Domain.Entities
{
    public class Fornecedor : EntityBase
    {
        public string Cnpj { get; private set; }
        public string Fantasia { get; private set; }
        public string RazaoSocial { get; private set; }
        public Contato Contato { get; private set; }
        public Endereco Endereco { get; private set; }

        public static Fornecedor New(string razaoSocial, string fantasia, string cnpj, Contato contato, Endereco endereco) => new()
        {
            Cnpj = cnpj,
            Fantasia = fantasia,
            Endereco = endereco,
            RazaoSocial = razaoSocial,
        };

        public Fornecedor()
        {
        }
        public void AtualizarEndereco(Endereco novoEndereco)
        {
            Endereco = novoEndereco;
            SetUpdated();
        }

        public void AtualizarContato(Contato contato)
        {
            Contato = contato;
            SetUpdated();
        }
    }
}