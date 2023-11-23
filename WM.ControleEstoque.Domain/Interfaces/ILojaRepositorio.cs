using WM.ControleEstoque.Dominio.Entidades;

namespace WM.ControleEstoque.Dominio.Interfaces
{
    public interface ILojaRepositorio
    {
        Task<Loja> GetLoja(Guid id);
        Task CadastroDeLoja(Loja loja);
    }
}
