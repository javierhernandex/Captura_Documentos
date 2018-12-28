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
            ViewBag.showSuccessAlert = false;

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
                    VE_AUM = Convert.ToUInt32(tabla[nte].Rows[i]["VE_AUM"]),
                    VE_HFI = Convert.ToDateTime(tabla[nte].Rows[i]["VE_HFI"]),
                    VE_GCF =Convert.ToInt32(tabla[nte].Rows[i]["VE_GCF"]),
                    V_clvpro = tabla[nte].Rows[i]["V_clvpro"].ToString(),
                    V_clvsubpro = tabla[nte].Rows[i]["V_clvsubpro"].ToString(),
                    V_CocGas= tabla[nte].Rows[i]["V_CocGas"].ToString(),
                    V_GasEtn = tabla[nte].Rows[i]["V_GasEtn"].ToString(),
                    V_CetnGas= tabla[nte].Rows[i]["V_CetnGas"].ToString(),
                    V_Otros= tabla[nte].Rows[i]["V_Otros"].ToString(),
                    V_Marca = tabla[nte].Rows[i]["V_Marca"].ToString(),

                    VE_FOLR =Convert.ToInt32(tabla[nte].Rows[i]["VE_FOLR"]),

                DATO=Convert.ToInt32(tabla[nte].Rows[i]["DATO"])
             };
                
  
            }

           



            return View(carga);
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult index([Bind(Include = "VE_ID,VE_TANQ,VE_PROD,VE_LTRI,VE_LTRF,VE_AUM,VE_GCF,VE_TERM,VE_TDOC,VE_FDOC,VE_FOLD,VE_VDOC,VE_HFI,VE_VEHI,VE_TREG,VE_FOLR,VE_NPIP,VE_NDOC,VE_ENVIO,VE_IDC,VE_PRDO,VE_MONTO,VE_RFC,VE_NUMCSGN,VE_PC,VE_PAD,VE_PERTRA,VE_NOMPROV,VE_PERPROV,VE_TP,VE_PI,VE_CLVPRO,VE_CLVSUBPRO,VE_COCGAS,VE_GASETN,VE_CETNGAS,VE_OTROS,VE_MARCA,id_list,documen")] Send_Carga send_Carga)
        {
                               if (ModelState.IsValid)
                        {
                              Cc con = new Cc();
                              con.conectarbd.Open();

                if (send_Carga.documen == 1) {


                    String tregma = "MA";
                    DateTime fecha = DateTime.Now;
                    string sql = @"Insert into Send_Carga(VE_TANQ,VE_PROD,VE_TREG,VE_PRDO,VE_CLVPRO,VE_CLVSUBPRO,VE_COCGAS,VE_GASETN,VE_CETNGAS,VE_OTROS,VE_MARCA)
                        values(@TANQ,@PRODUCTO, @TREG,@VE_PRDO,@CLAVE,@SUBCLAVE,@COCGAS,@GASETN,@CETNGAS,@OTROS,@MARCA)";


                    SqlCommand cmd = new SqlCommand(sql, con.conectarbd);
                    cmd.Parameters.AddWithValue("@TANQ", 0);
                    cmd.Parameters.AddWithValue("@PRODUCTO", send_Carga.VE_PROD);
                    cmd.Parameters.AddWithValue("@TREG", tregma);
                    cmd.Parameters.AddWithValue("@VE_PRDO", fecha);
                    cmd.Parameters.AddWithValue("@CLAVE", send_Carga.VE_CLVPRO);
                    cmd.Parameters.AddWithValue("@SUBCLAVE", send_Carga.VE_CLVSUBPRO);
                    cmd.Parameters.AddWithValue("@COCGAS", send_Carga.VE_COCGAS);
                    cmd.Parameters.AddWithValue("@GASETN", send_Carga.VE_GASETN);
                    cmd.Parameters.AddWithValue("@CETNGAS", send_Carga.VE_CETNGAS);
                    cmd.Parameters.AddWithValue("@OTROS", send_Carga.VE_OTROS);
                    cmd.Parameters.AddWithValue("@MARCA", send_Carga.VE_MARCA);

                    cmd.ExecuteNonQuery();


                    String tregdr = "DR";
                   
                    string sqldr = @"Insert into Send_Carga(VE_TANQ,VE_LTRI,VE_LTRF,VE_AUM,VE_GCF,VE_HFI,VE_TREG,VE_IDC,VE_PRDO)
                        values(@TANQ,@LTRI,@LTRF,@AUM,@GCF,@HFI,@TREG,@IDC,@PRDO)";


                    SqlCommand cmdr = new SqlCommand(sqldr, con.conectarbd);
                    cmdr.Parameters.AddWithValue("@TANQ",send_Carga.VE_TANQ);
                    cmdr.Parameters.AddWithValue("@LTRI", send_Carga.VE_LTRI);
                    cmdr.Parameters.AddWithValue("@LTRF", send_Carga.VE_LTRF);
                    cmdr.Parameters.AddWithValue("@AUM", send_Carga.VE_AUM);
                    cmdr.Parameters.AddWithValue("@GCF", send_Carga.VE_GCF);
                    cmdr.Parameters.AddWithValue("@HFI", send_Carga.VE_HFI);
                    cmdr.Parameters.AddWithValue("@TREG", tregdr);
                    cmdr.Parameters.AddWithValue("@IDC", send_Carga.VE_IDC);
                    cmdr.Parameters.AddWithValue("@PRDO",fecha);


                    cmdr.ExecuteNonQuery();


                    String tregdD = "DD";

                    string sqldD = @"Insert into Send_Carga(VE_TANQ,VE_PROD,VE_LTRI,VE_LTRF,VE_AUM,VE_GCF,VE_TERM,VE_TDOC,VE_FDOC,VE_FOLD,VE_VDOC,VE_HFI,VE_VEHI,VE_TREG,VE_FOLR,VE_NPIP,VE_NDOC,VE_ENVIO,VE_IDC,VE_PRDO,VE_MONTO,VE_RFC,VE_NUMCSGN,VE_PC,VE_PAD,VE_PERTRA,VE_NOMPROV,VE_PERPROV,VE_TP)
                        values(@VE_TANQ,@VE_PROD,@VE_LTRI,@VE_LTRF,@VE_AUM,@VE_GCF,@VE_TERM,@VE_TDOC,@VE_FDOC,@VE_FOLD,@VE_VDOC,@VE_HFI,@VE_VEHI,@VE_TREG,@VE_FOLR,@VE_NPIP,@VE_NDOC,@VE_ENVIO,@VE_IDC,@VE_PRDO,@VE_MONTO,@VE_RFC,@VE_NUMCSGN,@VE_PC,@VE_PAD,@VE_PERTRA,@VE_NOMPROV,@VE_PERPROV,@VE_TP)";


                    SqlCommand cmdD = new SqlCommand(sqldD, con.conectarbd);
                    cmdD.Parameters.AddWithValue("@VE_TANQ", send_Carga.VE_TANQ);
                    cmdD.Parameters.AddWithValue("@VE_PROD", 0);
                    cmdD.Parameters.AddWithValue("@VE_LTRI", 0);
                    cmdD.Parameters.AddWithValue("@VE_LTRF", 0);
                    cmdD.Parameters.AddWithValue("@VE_AUM", 0);
                    cmdD.Parameters.AddWithValue("@VE_GCF", 0);
                    cmdD.Parameters.AddWithValue("@VE_TERM",send_Carga.VE_TERM);
                    cmdD.Parameters.AddWithValue("@VE_TDOC", send_Carga.VE_TDOC);
                    cmdD.Parameters.AddWithValue("@VE_FDOC", send_Carga.VE_FDOC);
                    cmdD.Parameters.AddWithValue("@VE_FOLD", send_Carga.VE_FOLD);
                    cmdD.Parameters.AddWithValue("@VE_VDOC", send_Carga.VE_VDOC);
                    cmdD.Parameters.AddWithValue("@VE_HFI", 0);
                    cmdD.Parameters.AddWithValue("@VE_VEHI",send_Carga.VE_VEHI);
                    cmdD.Parameters.AddWithValue("@VE_TREG", tregdD);
                    cmdD.Parameters.AddWithValue("@VE_FOLR", 0);
                    cmdD.Parameters.AddWithValue("@VE_NPIP", 0);  
                    cmdD.Parameters.AddWithValue("@VE_NDOC", 1);
                    cmdD.Parameters.AddWithValue("@VE_ENVIO", 0);
                    cmdD.Parameters.AddWithValue("@VE_IDC", 0);
                    cmdD.Parameters.AddWithValue("@VE_PRDO", fecha);
                    cmdD.Parameters.AddWithValue("@VE_MONTO", send_Carga.VE_MONTO);
                    cmdD.Parameters.AddWithValue("@VE_RFC", send_Carga.VE_RFC);
                    cmdD.Parameters.AddWithValue("@VE_NUMCSGN", 0);
                    cmdD.Parameters.AddWithValue("@VE_PC", send_Carga.VE_PC);
                    cmdD.Parameters.AddWithValue("@VE_PAD",send_Carga.VE_PAD);
                    cmdD.Parameters.AddWithValue("@VE_PERTRA", send_Carga.VE_PERTRA);
                    cmdD.Parameters.AddWithValue("@VE_NOMPROV", send_Carga.VE_NOMPROV);
                    cmdD.Parameters.AddWithValue("@VE_PERPROV", send_Carga.VE_PERPROV);
                    cmdD.Parameters.AddWithValue("@VE_TP", send_Carga.VE_TP);
                    cmdD.ExecuteNonQuery(); 










                } else {


           
                    bd.Send_Carga.Add(send_Carga);
                    bd.SaveChanges();

                }



                string cadena = "update Veeder_Carga set VE_FOLD='1' where VE_ID='" + send_Carga.id_list + "'";
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
