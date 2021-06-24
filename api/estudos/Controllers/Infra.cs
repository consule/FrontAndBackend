using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [Route("dataatual")]
        public  IActionResult GetDataAtual()
        {
            var stringConexao = new Conexao();

            var sql = "SELECT SYSDATE DATA FROM DUAL";

            OracleConnection _oracleConnection = new OracleConnection(stringConexao.sConexao);

            _oracleConnection.Open();

            OracleCommand cmd = new OracleCommand(sql, _oracleConnection);

            var dr =  cmd.ExecuteReader();
            string data = "";

            while (dr.Read())
            {
                data = dr["DATA"].ToString();
            }

            return Ok(data);
        }

    }
}
