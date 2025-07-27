namespace Invoice.Business.Models
{
    public class FaturaItem : Entity
    {
        public int FaturaItemId { get; set; }
        public int FaturaId { get; set; }
        public int Ordem { get; set; }
        public double Valor { get; set; }

        public string Descricao { get; set; }

        public bool ValorAprovado { get; set; }

        public Fatura Fatura { get; set; }

        public FaturaItem()
        {
        }
    }
}
