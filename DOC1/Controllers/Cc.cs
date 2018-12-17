using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DOC1.Controllers
{
    public class Cc
    {

        private SqlConnection m_cnn;    
        String conn = ("Data Source=fcfdi.cjsgnbio4rra.us-east-1.rds.amazonaws.com;Persist Security Info=True;User ID=hermes;Password=12345678");
        public SqlConnection conectarbd = new SqlConnection();
        
        public Cc()
        {
           
            m_cnn = new SqlConnection(conectarbd.ConnectionString = conn);

      }

       
        }

    }



