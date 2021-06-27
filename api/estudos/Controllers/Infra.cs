using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using estudos.Model;
using estudos.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;


namespace estudos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Infra : ControllerBase
    {

        private readonly IConteudoRepository _conteudoRepository;

        public Infra(IConteudoRepository conteudoRepository)
        {
            _conteudoRepository = conteudoRepository;
        }

        [HttpGet]
        [Route("conteudo")]
        public List<Conteudo> Get()
        {
            return _conteudoRepository.Get();
        }

        [HttpGet]
        [Route("conteudo/{titulo}")]
        public List<Conteudo> Get(string titulo)
        {
            return _conteudoRepository.Get(titulo);
        }

        [HttpPost]
        [Route("conteudo")]
        public async Task<ActionResult<Conteudo>> Post(Conteudo conteudo)
        {

            if (_conteudoRepository.Post(conteudo))
            {
                return Ok( new { mensagem ="Inserido" });
            }
            return Ok(new { mensagem = "Não inserido" });
        }

        [HttpPut]
        [Route("conteudo/{codigo_unico}")]
        public async Task<ActionResult<Conteudo>> Put(Conteudo conteudo, int codigo_unico)
        {

            if (_conteudoRepository.Put(conteudo, codigo_unico))
            {
                return Ok(new { mensagem = "Atualizado com sucesso!" });
            }
            return Ok(new { mensagem = "Não foi possível atualizar" });
        }

        [HttpDelete]
        [Route("conteudo/{codigo_unico}")]
        public async Task<ActionResult<Conteudo>> Delete(int codigo_unico)
        {
            if (_conteudoRepository.Delete(codigo_unico))
            {
                return Ok(new { mensagem = "Apagado com sucesso!" });
            }
            return Ok(new { mensagem = "Não foi possível apagar" });
        }

        [HttpGet]
        [Route("conteudo/codigo_unico/{codigo_unico}")]
        public List<Conteudo> GetCodigoUnico(int codigo_unico)
        {
            return _conteudoRepository.GetCodigoUnico(codigo_unico);
        }

    }
}
