using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.IO;

using System.Configuration;


namespace DOC1.Controllers
{ 
    public class homeController : Controller
    {
        private hermes bd = new hermes();
        // GET: home





        public ActionResult Index()
        {
            
            Cc cocc = new Cc();
           
            cocc.conectarbd.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "REC";

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cocc.conectarbd;
        
            DataTable[] tabla = new DataTable[0];

            using (SqlDataAdapter data = new SqlDataAdapter(cmd))
            {

                using (DataSet set = new DataSet())
                {
                    data.Fill(set);
                    tabla = set.Tables.Cast<DataTable>().ToArray();

                }
            }

         
         
            int nte = 0;
            int fexi = tabla[nte].Rows.Count;
            var  carga = new Veeder_Carga[fexi];

            
            
            for (int i = 0; i < fexi; i++)
            {

                carga[i] = new Veeder_Carga() {
                    VE_ID =Convert.ToInt32( tabla[nte].Rows[i]["VE_ID"]),
                   VE_NOM = tabla[nte].Rows[i]["VE_NOM"].ToString(),
                VE_TANQ = Convert.ToInt32(tabla[nte].Rows[i]["VE_TANQ"]),
                VE_LTRI= Convert.ToInt32(tabla[nte].Rows[i]["VE_LTRI"]),
                VE_LTRF=Convert.ToInt32(tabla[nte].Rows[i]["VE_LTRF"]),
                VE_GCF=Convert.ToInt32(tabla[nte].Rows[i]["VE_GCF"]),
                VE_AUM = Convert.ToUInt32( tabla[nte].Rows[i]["VE_AUM"]),
                VE_HFI= Convert.ToDateTime(tabla[nte].Rows[i]["VE_HFI"]),
               DATO= Convert.ToInt32(tabla[1].Rows[0]["DATO"]),
               

            };
                
  
            }

           

            int nt = 2;
            int x = tabla[nt].Rows.Count;
            Send_Carga[] send = new Send_Carga[x];

            for (int ii = 0; ii < x; ii++)
            {
                send[ii] = new Send_Carga()
                {
                    VE_ID = Convert.ToInt32(tabla[nt].Rows[ii]["VE_FOLR"]),
                    VE_TREG = tabla[nt].Rows[ii]["VE_TREG"].ToString(),
                    VE_PRDO = Convert.ToDateTime(tabla[nt].Rows[ii]["VE_PRDO"])
                };
            }




            return View(carga);
        }
   


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "VE_ID,VE_TANQ,VE_PROD,VE_LTRI,VE_LTRF,VE_AUM,VE_GCF,VE_TERM,VE_TDOC,VE_FDOC,VE_FOLD,VE_VDOC,VE_HFI,VE_VEHI,VE_TREG,VE_FOLR,VE_NPIP,VE_NDOC,VE_ENVIO,VE_IDC,VE_PRDO,VE_MONTO,VE_RFC,VE_NUMCSGN,VE_PC,VE_PAD,VE_PERTRA,VE_NOMPROV,VE_PERPROV,VE_TP,VE_PI,VE_CLVPRO,VE_CLVSUBPRO,VE_COCGAS,VE_GASETN,VE_CETNGAS,VE_OTROS,VE_MARCA,id_list")] Send_Carga send_Carga)
        {
            if (ModelState.IsValid)
            {
                bd.Send_Carga.Add(send_Carga);
                bd.SaveChanges();

          
                Cc con = new Cc();
                con.conectarbd.Open();
                string cadena = "update Veeder_Carga set VE_FOLD='1' where VE_ID='"+send_Carga.id_list+"'";
                SqlCommand comando = new SqlCommand(cadena, con.conectarbd);
                int cant;
                cant = comando.ExecuteNonQuery();


                return RedirectToAction("Index");
            }
        return View(send_Carga);
        }

    

        public ActionResult modal()
        {
            return  View();
        }
       
      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bd.Dispose();
            }
            base.Dispose(disposing);
        }

    }

    }
