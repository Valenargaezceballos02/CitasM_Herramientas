using AccesoDatos.DataBase;
using Entidades;
using System.Data;

namespace LogicaNegocio
{
    public class ClsPacienteLn
    {
        #region Variables Privadas
        private ClsDataBase ObjDataBase = null;
        #endregion

        #region Metodo Index
        public void Index(ref Entidades.ClsPacienteLn objPaciente)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "tbl_pacientes",
                NombreSP = "[dbo].[SP_Pacientes_Index]",
                Scalar = false,
            };
            Ejecutar(ref objPaciente);
        }

        private void Ejecutar(ref Entidades.ClsPacienteLn objPaciente)
        {
            ObjDataBase.CRUD(ref ObjDataBase);
            if(ObjDataBase.MensajeErrorOS == null) //Si es null no hay error
            {
                if(ObjDataBase.Scalar)
                {
                    objPaciente.ValorScalar = ObjDataBase.ValorScalar; //Tipo valor escalar
                }
                else
                {
                    objPaciente.DtResultado = ObjDataBase.DsResultados.Tables[0];
                    //Validar si la tabla tiene un solo registro
                    if(objPaciente.DtResultado.Rows.Count == 1 ) 
                    { 
                        foreach (DataRow item in objPaciente.DtResultado.Rows)
                        {
                            objPaciente.CedulaP = item["cedulaP"].ToString();
                            objPaciente.NombreP = item["nombreP"].ToString();
                            objPaciente.Email = item["email"].ToString();
                            objPaciente.Eps = item["eps"].ToString();

                        }
                    }
                }
            }
            else
            {
                objPaciente.MensajeError = ObjDataBase.MensajeErrorOS;
            }
        }
        #endregion

        #region CRUD Paciente

        public void Create(ref Entidades.ClsPacienteLn objPaciente)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "tbl_pacientes",
                NombreSP = "[dbo].[SP_Pacientes_Create]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@CedulaP", "15", objPaciente.CedulaP);
            ObjDataBase.DtParametros.Rows.Add(@"@NombreP", "15", objPaciente.NombreP);
            ObjDataBase.DtParametros.Rows.Add(@"@Email", "15", objPaciente.Email);
            ObjDataBase.DtParametros.Rows.Add(@"@Eps", "15", objPaciente.Eps);
            Ejecutar(ref objPaciente);
        }

        public void Update(ref Entidades.ClsPacienteLn objPaciente)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "tbl_pacientes",
                NombreSP = "[dbo].[SP_Pacientes_Update]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@CedulaP", "15", objPaciente.CedulaP);
            ObjDataBase.DtParametros.Rows.Add(@"@NombreP", "15", objPaciente.NombreP);
            ObjDataBase.DtParametros.Rows.Add(@"@Email", "15", objPaciente.Email);
            ObjDataBase.DtParametros.Rows.Add(@"@Eps", "15", objPaciente.Eps);
            Ejecutar(ref objPaciente);
        }

        public void Delete(ref Entidades.ClsPacienteLn objPaciente)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "tbl_pacientes",
                NombreSP = "[dbo].[SP_Pacientes_Delete]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@CedulaP", "15", objPaciente.CedulaP);
            Ejecutar(ref objPaciente);
        }

        public void Read(ref Entidades.ClsPacienteLn objPaciente)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "tbl_pacientes",
                NombreSP = "[dbo].[SP_Pacientes_Read]",
                Scalar = false,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@CedulaP", "15", objPaciente.CedulaP);
            Ejecutar(ref objPaciente);
        }

        #endregion

        #region Metodos Privados

        #endregion
    }
}
