using estudos.Model;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using estudos.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;


namespace estudos.Repository
{
    public class ConteudoRepository : IConteudoRepository
    {
        public List<Conteudo> Get()
        {
            var stringConexao = new Conexao();

            var sql = "SELECT * FROM CC_CONTEUDO";

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

        public List<Conteudo> Get(string titulo)
        {
            var stringConexao = new Conexao();

            var sql = "SELECT * FROM CC_CONTEUDO WHERE TITULO LIKE '%" + titulo.ToUpper() + "%'";

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

        public bool Post(Conteudo conteudo)
        {
            var stringConexao = new Conexao();

            var sql = "INSERT INTO CC_CONTEUDO (TITULO, SUBTITULO, DATAPUBLICACAO) VALUES ('"+conteudo.titulo.ToUpper()+"','"+conteudo.subTitulo.ToUpper()+"',TO_DATE('"+conteudo.dataPublicacao+"', 'DD/MM/YYYY HH24:MI:SS'))";

            OracleConnection _oracleConnection = new OracleConnection(stringConexao.sConexao);

            _oracleConnection.Open();

            OracleCommand cmd = new OracleCommand(sql, _oracleConnection);

            var dr = cmd.ExecuteReader();

            string data = "teste".ToString();

            if (dr.RecordsAffected == 1)
            {
                return true;
            }
            return false;
        }

        public bool Put(Conteudo conteudo, int codigo_unico)
        {
            var stringConexao = new Conexao();

            var sql = "UPDATE CC_CONTEUDO SET TITULO = '" + conteudo.titulo.ToUpper() + "', SUBTITULO = '" + conteudo.subTitulo.ToUpper() + "', DATAPUBLICACAO = TO_DATE('" + conteudo.dataPublicacao + "', 'DD/MM/YYYY HH24:MI:SS') WHERE CODIGO_UNICO = " + codigo_unico + "";

            OracleConnection _oracleConnection = new OracleConnection(stringConexao.sConexao);

            _oracleConnection.Open();

            OracleCommand cmd = new OracleCommand(sql, _oracleConnection);

            var dr = cmd.ExecuteReader();

            if (dr.RecordsAffected == 1)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int codigo_unico)
        {
            var stringConexao = new Conexao();

            var sql = "DELETE FROM CC_CONTEUDO WHERE codigo_unico = " + codigo_unico + "";

            OracleConnection _oracleConnection = new OracleConnection(stringConexao.sConexao);

            _oracleConnection.Open();

            OracleCommand cmd = new OracleCommand(sql, _oracleConnection);

            var dr = cmd.ExecuteReader();

            if (dr.RecordsAffected == 1)
            {
                return true;
            }
            return false;
        }

        public List<Conteudo> GetCodigoUnico(int codigo_unico)
        {
            var stringConexao = new Conexao();

            var sql = "SELECT * FROM CC_CONTEUDO WHERE codigo_unico = " + codigo_unico + "";

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
