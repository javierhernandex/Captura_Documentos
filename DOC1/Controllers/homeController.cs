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
                    DateTime fecha1 = DateTime.Now;

                    string fecha= fecha1.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string sql = @"Insert into Send_Carga(VE_TANQ,VE_PROD,VE_LTRI,VE_LTRF,VE_AUM,VE_GCF,VE_TERM,VE_TDOC,VE_FDOC,VE_FOLD,VE_VDOC,VE_HFI,VE_VEHI,VE_TREG,VE_FOLR,VE_NPIP,VE_NDOC,VE_ENVIO,VE_IDC,VE_PRDO,VE_MONTO,VE_RFC,VE_NUMCSGN,VE_CLVPRO,VE_CLVSUBPRO,VE_COCGAS,VE_GASETN,VE_CETNGAS,VE_OTROS,VE_MARCA)
                        values(@VE_TANQ,@VE_PROD,@VE_LTRI,@VE_LTRF,@VE_AUM,@VE_GCF,@VE_TERM,@VE_TDOC,@VE_FDOC,@VE_FOLD,@VE_VDOC,@VE_HFI,@VE_VEHI,@VE_TREG,@VE_FOLR,@VE_NPIP,@VE_NDOC,@VE_ENVIO,@VE_IDC,@VE_PRDO,@VE_MONTO,@VE_RFC,@VE_NUMCSGN,@VE_CLVPRO,@VE_CLVSUBPRO,@VE_COCGAS,@VE_GASETN,@VE_CETNGAS,@VE_OTROS,@VE_MARCA)";


                    SqlCommand cmd = new SqlCommand(sql, con.conectarbd);
                    cmd.Parameters.AddWithValue("@VE_TANQ",0);
                    cmd.Parameters.AddWithValue("@VE_PROD", send_Carga.VE_PROD);
                    cmd.Parameters.AddWithValue("@VE_LTRI", 0);
                    cmd.Parameters.AddWithValue("@VE_LTRF", 0);
                    cmd.Parameters.AddWithValue("@VE_AUM", 0);
                    cmd.Parameters.AddWithValue("@VE_GCF", 0);
                    cmd.Parameters.AddWithValue("@VE_TERM", 0);
                    cmd.Parameters.AddWithValue("@VE_TDOC", 0);
                    cmd.Parameters.AddWithValue("@VE_FDOC",0);
                    cmd.Parameters.AddWithValue("@VE_FOLD", 0);
                    cmd.Parameters.AddWithValue("@VE_VDOC",0);
                    cmd.Parameters.AddWithValue("@VE_HFI", 0);
                    cmd.Parameters.AddWithValue("@VE_VEHI", 0);
                    cmd.Parameters.AddWithValue("@VE_TREG", tregma);
                    cmd.Parameters.AddWithValue("@VE_FOLR", 0);
                    cmd.Parameters.AddWithValue("@VE_NPIP", 1);
                    cmd.Parameters.AddWithValue("@VE_NDOC", 0);
                    cmd.Parameters.AddWithValue("@VE_ENVIO", 0);
                    cmd.Parameters.AddWithValue("@VE_IDC", 0);
                    cmd.Parameters.AddWithValue("@VE_PRDO", fecha);
                    cmd.Parameters.AddWithValue("@VE_MONTO", 0);
                    cmd.Parameters.AddWithValue("@VE_RFC", 0);
                    cmd.Parameters.AddWithValue("@VE_NUMCSGN", 0);
                    cmd.Parameters.AddWithValue("@VE_CLVPRO", send_Carga.VE_CLVPRO); 
                    cmd.Parameters.AddWithValue("@VE_CLVSUBPRO", send_Carga.VE_CLVSUBPRO);
                    cmd.Parameters.AddWithValue("@VE_COCGAS", send_Carga.VE_COCGAS);
                    cmd.Parameters.AddWithValue("@VE_GASETN", send_Carga.VE_GASETN);
                    cmd.Parameters.AddWithValue("@VE_CETNGAS", send_Carga.VE_CETNGAS);
                    cmd.Parameters.AddWithValue("@VE_OTROS", send_Carga.VE_OTROS);
                    cmd.Parameters.AddWithValue("@VE_MARCA", send_Carga.VE_MARCA);

                    cmd.ExecuteNonQuery();

                    string FOLR;

                    string sqlse = "select VE_ID FROM Send_Carga where VE_PRDO = '"+fecha+"' and VE_TREG = 'MA'";
                    SqlCommand cmdse = new SqlCommand();

                    cmdse.CommandText = sqlse;

                    cmdse.CommandType = CommandType.Text;
                    cmdse.Connection = con.conectarbd;

                    DataTable[] tabla1 = new DataTable[0];

                    using (SqlDataAdapter data1 = new SqlDataAdapter(cmdse))
                    {

                        using (DataSet set1 = new DataSet())
                        {
                            data1.Fill(set1);
                            tabla1 = set1.Tables.Cast<DataTable>().ToArray();

                        }
                    }


                   FOLR = tabla1[0].Rows[0]["VE_ID"].ToString();






                    string cadena1 = "update Send_Carga set VE_FOLR='"+FOLR+"' where VE_ID='" + FOLR + "'";
                    SqlCommand comando1 = new SqlCommand(cadena1, con.conectarbd);
                    int cant1;
                    cant1 = comando1.ExecuteNonQuery();





                    String tregdr = "DR";
                   
                    string sqldr = @"Insert into Send_Carga(VE_TANQ,VE_PROD,VE_LTRI,VE_LTRF,VE_AUM,VE_GCF,VE_TERM,VE_TDOC,VE_FDOC,VE_FOLD,VE_VDOC,VE_HFI,VE_VEHI,VE_TREG,VE_FOLR,VE_NPIP,VE_NDOC,VE_ENVIO,VE_IDC,VE_PRDO,VE_MONTO,VE_RFC,VE_NUMCSGN)
                        values(@VE_TANQ,@VE_PROD,@VE_LTRI,@VE_LTRF,@VE_AUM,@VE_GCF,@VE_TERM,@VE_TDOC,@VE_FDOC,@VE_FOLD,@VE_VDOC,@VE_HFI,@VE_VEHI,@VE_TREG,@VE_FOLR,@VE_NPIP,@VE_NDOC,@VE_ENVIO,@VE_IDC,@VE_PRDO,@VE_MONTO,@VE_RFC,@VE_NUMCSGN)";


                    SqlCommand cmdr = new SqlCommand(sqldr, con.conectarbd);
                    cmdr.Parameters.AddWithValue("@VE_TANQ", send_Carga.VE_TANQ);
                    cmdr.Parameters.AddWithValue("@VE_PROD", 0);
                    cmdr.Parameters.AddWithValue("@VE_LTRI", send_Carga.VE_LTRI);
                    cmdr.Parameters.AddWithValue("@VE_LTRF", send_Carga.VE_LTRF);
                    cmdr.Parameters.AddWithValue("@VE_AUM", send_Carga.VE_AUM);
                    cmdr.Parameters.AddWithValue("@VE_GCF", send_Carga.VE_GCF);
                    cmdr.Parameters.AddWithValue("@VE_TERM", 0);
                    cmdr.Parameters.AddWithValue("@VE_TDOC", 0);
                    cmdr.Parameters.AddWithValue("@VE_FDOC", 0);
                    cmdr.Parameters.AddWithValue("@VE_FOLD", 0);
                    cmdr.Parameters.AddWithValue("@VE_VDOC", 0);
                    cmdr.Parameters.AddWithValue("@VE_HFI", send_Carga.VE_HFI);
                    cmdr.Parameters.AddWithValue("@VE_VEHI", 0);
                    cmdr.Parameters.AddWithValue("@VE_TREG", tregdr);
                    cmdr.Parameters.AddWithValue("@VE_FOLR", FOLR);
                    cmdr.Parameters.AddWithValue("@VE_NPIP", 0);
                    cmdr.Parameters.AddWithValue("@VE_NDOC", 0);
                    cmdr.Parameters.AddWithValue("@VE_ENVIO", 0);
                    cmdr.Parameters.AddWithValue("@VE_IDC", send_Carga.VE_IDC);
                    cmdr.Parameters.AddWithValue("@VE_PRDO", fecha);
                    cmdr.Parameters.AddWithValue("@VE_MONTO", 0);
                    cmdr.Parameters.AddWithValue("@VE_RFC", 0);
                    cmdr.Parameters.AddWithValue("@VE_NUMCSGN", 0);
                    


                    cmdr.ExecuteNonQuery();


                    String tregdD = "DD";

                    string sqldD = @"Insert into Send_Carga(VE_TANQ,VE_PROD,VE_LTRI,VE_LTRF,VE_AUM,VE_GCF,VE_TERM,VE_TDOC,VE_FDOC,VE_FOLD,VE_VDOC,VE_HFI,VE_VEHI,VE_TREG,VE_FOLR,VE_NPIP,VE_NDOC,VE_ENVIO,VE_IDC,VE_PRDO,VE_MONTO,VE_RFC,VE_NUMCSGN,VE_PC,VE_PAD,VE_PERTRA,VE_NOMPROV,VE_PERPROV,VE_TP)
                        values(@VE_TANQ,@VE_PROD,@VE_LTRI,@VE_LTRF,@VE_AUM,@VE_GCF,@VE_TERM,@VE_TDOC,@VE_FDOC,@VE_FOLD,@VE_VDOC,@VE_HFI,@VE_VEHI,@VE_TREG,@VE_FOLR,@VE_NPIP,@VE_NDOC,@VE_ENVIO,@VE_IDC,@VE_PRDO,@VE_MONTO,@VE_RFC,@VE_NUMCSGN,@VE_PC,@VE_PAD,@VE_PERTRA,@VE_NOMPROV,@VE_PERPROV,@VE_TP)";


                    SqlCommand cmdD = new SqlCommand(sqldD, con.conectarbd);
                    cmdD.Parameters.AddWithValue("@VE_TANQ", 0);
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
                    cmdD.Parameters.AddWithValue("@VE_FOLR", FOLR);
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
                    DateTime fecha1 = DateTime.Now;

                    string fecha = fecha1.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    String tregdD = "DD";

                    string sqldD = @"Insert into Send_Carga(VE_TANQ,VE_PROD,VE_LTRI,VE_LTRF,VE_AUM,VE_GCF,VE_TERM,VE_TDOC,VE_FDOC,VE_FOLD,VE_VDOC,VE_HFI,VE_VEHI,VE_TREG,VE_FOLR,VE_NPIP,VE_NDOC,VE_ENVIO,VE_IDC,VE_PRDO,VE_MONTO,VE_RFC,VE_NUMCSGN,VE_PC,VE_PAD,VE_PERTRA,VE_NOMPROV,VE_PERPROV,VE_TP)
                        values(@VE_TANQ,@VE_PROD,@VE_LTRI,@VE_LTRF,@VE_AUM,@VE_GCF,@VE_TERM,@VE_TDOC,@VE_FDOC,@VE_FOLD,@VE_VDOC,@VE_HFI,@VE_VEHI,@VE_TREG,@VE_FOLR,@VE_NPIP,@VE_NDOC,@VE_ENVIO,@VE_IDC,@VE_PRDO,@VE_MONTO,@VE_RFC,@VE_NUMCSGN,@VE_PC,@VE_PAD,@VE_PERTRA,@VE_NOMPROV,@VE_PERPROV,@VE_TP)";


                    SqlCommand cmdD = new SqlCommand(sqldD, con.conectarbd);
                    cmdD.Parameters.AddWithValue("@VE_TANQ", 0);
                    cmdD.Parameters.AddWithValue("@VE_PROD", 0);
                    cmdD.Parameters.AddWithValue("@VE_LTRI", 0);
                    cmdD.Parameters.AddWithValue("@VE_LTRF", 0);
                    cmdD.Parameters.AddWithValue("@VE_AUM", 0);
                    cmdD.Parameters.AddWithValue("@VE_GCF", 0);
                    cmdD.Parameters.AddWithValue("@VE_TERM", send_Carga.VE_TERM);
                    cmdD.Parameters.AddWithValue("@VE_TDOC", send_Carga.VE_TDOC);
                    cmdD.Parameters.AddWithValue("@VE_FDOC", send_Carga.VE_FDOC);
                    cmdD.Parameters.AddWithValue("@VE_FOLD", send_Carga.VE_FOLD);
                    cmdD.Parameters.AddWithValue("@VE_VDOC", send_Carga.VE_VDOC);
                    cmdD.Parameters.AddWithValue("@VE_HFI", 0);
                    cmdD.Parameters.AddWithValue("@VE_VEHI", send_Carga.VE_VEHI);
                    cmdD.Parameters.AddWithValue("@VE_TREG", tregdD);
                    cmdD.Parameters.AddWithValue("@VE_FOLR", send_Carga.VE_FOLR);
                    cmdD.Parameters.AddWithValue("@VE_NPIP", 0);
                    cmdD.Parameters.AddWithValue("@VE_NDOC", 1);
                    cmdD.Parameters.AddWithValue("@VE_ENVIO", 0);
                    cmdD.Parameters.AddWithValue("@VE_IDC", 0);
                    cmdD.Parameters.AddWithValue("@VE_PRDO", fecha);
                    cmdD.Parameters.AddWithValue("@VE_MONTO", send_Carga.VE_MONTO);
                    cmdD.Parameters.AddWithValue("@VE_RFC", send_Carga.VE_RFC);
                    cmdD.Parameters.AddWithValue("@VE_NUMCSGN", 0);
                    cmdD.Parameters.AddWithValue("@VE_PC", send_Carga.VE_PC);
                    cmdD.Parameters.AddWithValue("@VE_PAD", send_Carga.VE_PAD);
                    cmdD.Parameters.AddWithValue("@VE_PERTRA", send_Carga.VE_PERTRA);
                    cmdD.Parameters.AddWithValue("@VE_NOMPROV", send_Carga.VE_NOMPROV);
                    cmdD.Parameters.AddWithValue("@VE_PERPROV", send_Carga.VE_PERPROV);
                    cmdD.Parameters.AddWithValue("@VE_TP", send_Carga.VE_TP);
                    cmdD.ExecuteNonQuery();



               //     bd.Send_Carga.Add(send_Carga);
                 //   bd.SaveChanges();

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
