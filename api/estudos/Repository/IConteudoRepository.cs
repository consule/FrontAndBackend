using estudos.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estudos.Repository
{
    public interface IConteudoRepository
    {
        List<Conteudo> Get();
        List<Conteudo> Get(string titulo);
        bool Post(Conteudo conteudo);
        bool Put(Conteudo conteudo, int codigo_unico);
        bool Delete(int codigo_unico);
        List<Conteudo> GetCodigoUnico(int codigo_unico);
    }
}
