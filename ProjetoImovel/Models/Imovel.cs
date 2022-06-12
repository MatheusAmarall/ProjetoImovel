namespace ProjetoImovel.Models {
    public class Imovel {
        public int Id { get; set; }
        public string TipoImovel { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorLocacao { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Cep { get; set; }
    }
}