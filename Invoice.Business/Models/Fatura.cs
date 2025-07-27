namespace Invoice.Business.Models
{
    public class Fatura : Entity
    {
        public int FaturaId { get; set; }
        public string Cliente { get; set; }
        public DateTime Data { get; set; }

        public IEnumerable<FaturaItem> FaturaItem { get; set; }

        public Fatura()
        {
        }
    }
}
