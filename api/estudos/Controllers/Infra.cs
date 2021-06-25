using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using estudos.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;


namespace estudos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Infra : ControllerBase
    {
        [HttpGet]
        [Route("conteudo")]
        public List<Conteudo> Get()
        {
            var stringConexao = new Conexao();

            var sql = "SELECT * FROM CC_CONTEUDO";

            OracleConnection _oracleConnection = new OracleConnection(stringConexao.sConexao);

            _oracleConnection.Open();

            OracleCommand cmd = new OracleCommand(sql, _oracleConnection);

            var dr =  cmd.ExecuteReader();

            var list = new List<Conteudo>();

            while (dr.Read())
            {
                var conteudo = new Conteudo
                {
                    codigoUnico = Convert.ToInt32(dr.GetValue(0)),
                    titulo = dr.GetString(1),
                    subTitulo = dr.GetString(2),
                    dataPublicacao = dr.GetDateTime(3)
                };
                list.Add(conteudo);
            }

            return list;
        }

        [HttpGet]
        [Route("conteudo/{titulo}")]
        public List<Conteudo> Get(string titulo)
        {
            var stringConexao = new Conexao();

            var sql = "SELECT * FROM CC_CONTEUDO WHERE TITULO LIKE '%"+titulo+"%'";

            OracleConnection _oracleConnection = new OracleConnection(stringConexao.sConexao);

            _oracleConnection.Open();

            OracleCommand cmd = new OracleCommand(sql, _oracleConnection);

            var dr = cmd.ExecuteReader();

            var list = new List<Conteudo>();

            while (dr.Read())
            {
                var conteudo = new Conteudo
                {
                    codigoUnico = Convert.ToInt32(dr.GetValue(0)),
                    titulo = dr.GetString(1),
                    subTitulo = dr.GetString(2),
                    dataPublicacao = dr.GetDateTime(3)
                };
                list.Add(conteudo);
            }
            return list;
        }

        [HttpPost]
        [Route("conteudo")]
        public async Task<ActionResult<Conteudo>> Post(Conteudo conteudo)
        {
            var stringConexao = new Conexao();

            var sql = "INSERT INTO CC_CONTEUDO (TITULO, SUBTITULO, DATAPUBLICACAO) VALUES ('"+conteudo.titulo+"','"+conteudo.subTitulo+"',TO_DATE('"+conteudo.dataPublicacao+"', 'DD/MM/YYYY HH24:MI:SS'))";

            OracleConnection _oracleConnection = new OracleConnection(stringConexao.sConexao);

            _oracleConnection.Open();

            OracleCommand cmd = new OracleCommand(sql, _oracleConnection);

            var dr = cmd.ExecuteReader();

            if (dr.RecordsAffected == 1)
            {
                return Ok(new { mensagem = "Inserido com sucesso!" });
            }
            return Ok(new { mensagem = "Não foi inserido" });
        }

        [HttpPut]
        [Route("conteudo/{codigo_unico}")]
        public async Task<ActionResult<Conteudo>> Put(Conteudo conteudo, int codigo_unico)
        {
            var stringConexao = new Conexao();

            var sql = "UPDATE CC_CONTEUDO SET TITULO = '"+conteudo.titulo+"', SUBTITULO = '"+conteudo.subTitulo+"', DATAPUBLICACAO = TO_DATE('"+conteudo.dataPublicacao+"', 'DD/MM/YYYY HH24:MI:SS') WHERE CODIGO_UNICO = "+codigo_unico+"";

            OracleConnection _oracleConnection = new OracleConnection(stringConexao.sConexao);

            _oracleConnection.Open();

            OracleCommand cmd = new OracleCommand(sql, _oracleConnection);

            var dr = cmd.ExecuteReader();

            if (dr.RecordsAffected == 1)
            {
                return Ok(new { mensagem = "Atualizado com sucesso!" });
            }
            return Ok(new { mensagem = "Não foi possível atualizar" });
        }

        [HttpDelete]
        [Route("conteudo/{codigo_unico}")]
        public async Task<ActionResult<Conteudo>> Delete(int codigo_unico)
        {
            var stringConexao = new Conexao();

            var sql = "DELETE FROM CC_CONTEUDO WHERE codigo_unico = "+codigo_unico+"";

            OracleConnection _oracleConnection = new OracleConnection(stringConexao.sConexao);

            _oracleConnection.Open();

            OracleCommand cmd = new OracleCommand(sql, _oracleConnection);

            var dr = cmd.ExecuteReader();

            if (dr.RecordsAffected == 1)
            {
                return Ok(new { mensagem = "Apagado com sucesso!" });
            }
            return Ok(new { mensagem = "Não foi possível apagar" });
        }

        [HttpGet]
        [Route("conteudo/codigo_unico/{codigo_unico}")]
        public List<Conteudo> GetCodigoUnico(int codigo_unico)
        {
            var stringConexao = new Conexao();

            var sql = "SELECT * FROM CC_CONTEUDO WHERE codigo_unico = "+codigo_unico+"";

            OracleConnection _oracleConnection = new OracleConnection(stringConexao.sConexao);

            _oracleConnection.Open();

            OracleCommand cmd = new OracleCommand(sql, _oracleConnection);

            var dr = cmd.ExecuteReader();

            var list = new List<Conteudo>();

            while (dr.Read())
            {
                var conteudo = new Conteudo
                {
                    codigoUnico = Convert.ToInt32(dr.GetValue(0)),
                    titulo = dr.GetString(1),
                    subTitulo = dr.GetString(2),
                    dataPublicacao = dr.GetDateTime(3)
                };
                list.Add(conteudo);
            }
            return list;
        }

    }
}
