namespace loja.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Cpf { get; set; }
        public bool? Ativo { get; set; }
    }
}
