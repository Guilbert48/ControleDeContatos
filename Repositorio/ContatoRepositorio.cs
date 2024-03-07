using ControleDeContatos.Data;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contato.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contato.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contato.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel Contatodb = ListarPorId(contato.Id);
            if (Contatodb == null) throw new System.Exception("Houve um erro na atualização do contato!");
            Contatodb.Nome = contato.Nome;
            Contatodb.Email = contato.Email;
            Contatodb.Celular = contato.Celular;

            _bancoContext.Contato.Update(Contatodb);
            _bancoContext.SaveChanges();
            return Contatodb;
        }
    }
}
