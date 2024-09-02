namespace ProjetoFinal.Dao.Domain
{
    public class Vendedor
    {
        public int IdVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public decimal Comissao { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public string CPF { get; set; }
    }
}