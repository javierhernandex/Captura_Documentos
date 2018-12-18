using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DOC1.Controllers
{
    public class registrar
    {
        public void Registrar(Send_Carga send)
        {
            Cc cc = new Cc();
            cc.conectarbd.Open();
            using (cc.conectarbd)
            {


                string sql = @"Insert into Send_caga (VE_TERM,VE_TDOC,VE_FDOC,VE_FOLD,VE_VDOC,VE_VEHI,VE_FOLR,VE_MONTO,VE_RFC,VE_PC,VE_PAD,VE_PERTRA,VE_NOMPROV,VE_PERPROV,VE_TP) 
                values(@VE_TERM, @VE_TDOC, @VE_FDOC,@VE_FOLD,@VE_VDOC,@VE_VEHI,@VE_FOLR,@VE_MONTO,@VE_RFC,@VE_PC,@VE_PAD,@VE_PERTRA,@VE_NOMPROV,@VE_PERPROV,@VE_TP)";

                SqlCommand cmd = new SqlCommand(sql, cc.conectarbd);
                cmd.Parameters.AddWithValue("@VE_TERM", send.VE_TERM);
                cmd.Parameters.AddWithValue("@VE_TDOC", send.VE_TDOC);
                cmd.Parameters.AddWithValue("@VE_FDOC", send.VE_FDOC);
                cmd.Parameters.AddWithValue("@VE_FOLD", send.VE_FOLD);
                cmd.Parameters.AddWithValue("@VE_VDOC", send.VE_VDOC);
                cmd.Parameters.AddWithValue("@VE_VEHI", send.VE_VEHI);
                cmd.Parameters.AddWithValue("@VE_FOLR", send.VE_FOLR);
                cmd.Parameters.AddWithValue("@VE_MONTO", send.VE_MONTO);
                cmd.Parameters.AddWithValue("@VE_RFC", send.VE_RFC);
                cmd.Parameters.AddWithValue("@VE_PC", send.VE_PC);
                cmd.Parameters.AddWithValue("@VE_PAD", send.VE_PAD);
                cmd.Parameters.AddWithValue("@VE_PERTRA", send.VE_PERTRA);
                cmd.Parameters.AddWithValue("@VE_NOMPROV", send.VE_NOMPROV);
                cmd.Parameters.AddWithValue("@VE_PERPROV", send.VE_PERPROV);
                cmd.Parameters.AddWithValue("@VE_TP", send.VE_TP);

                cmd.ExecuteNonQuery();

            }
        }
    }
}