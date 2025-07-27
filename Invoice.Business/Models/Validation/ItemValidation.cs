namespace Invoice.Business.Models.Validation
{
    public class ItemValidation
    {
        public static bool ValidarItem(int order)
        {
            if (order % 10 == 0)
            {
                return true;
            }

            return false;
        }

        public static bool ValidarSeTemOrdem(int order, IEnumerable<FaturaItem> itens)
        {
            var orderExists = itens.Any(i => i.Ordem == order);

            if (orderExists)
            {
                return false; // Ordem já existe
            }
            return true;
        }

        public static bool ValidarSequenciaOrdem(IEnumerable<FaturaItem> itens)
        {
            if(itens == null || !itens.Any())
            {
                return false; // Lista de itens vazia ou nula
            }

            var itensOrdenados = itens.OrderBy(i => i.Ordem).ToList();

            for (int i = 0; i < itensOrdenados.Count - 1; i++)
            {
                if (itensOrdenados[i].Ordem + 10 != itensOrdenados[i + 1].Ordem)
                {
                    return false; // Sequência de ordem inválida
                }
            }

            return true; // Sequência de ordem válida
        }
    }
}
