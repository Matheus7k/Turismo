namespace Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nDescrição: {Descricao}\nData de cadastro: {DataCadastro}\n";
        }
    }
}