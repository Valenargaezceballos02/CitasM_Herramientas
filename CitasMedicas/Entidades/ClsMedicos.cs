using AccesoDatos.DataBase;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    internal class ClsMedicosLn
    {
        #region Variables Privadas
        private ClsDataBase ObjDataBase = null;
        #endregion

        #region Metodo Index
        public void Index(ref Entidades.ClsMedicosLn objMedicos)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "tbl_medicos",
                NombreSP = "[dbo].[SP_Medicos_Index]",
                Scalar = false,
            };
            Ejecutar(ref objMedicos);
        }
        private void Ejecutar(ref Entidades.ClsMedicosLn objMedicos)
        {
            ObjDataBase.CRUD(ref ObjDataBase);
            if (ObjDataBase.MensajeErrorOS == null) //Si es null no hay error
            {
                if (ObjDataBase.Scalar)
                {
                    objMedicos.ValorScalar = ObjDataBase.ValorScalar; //Tipo valor escalar
                }
                else
                {
                    objMedicos.DtResultado = ObjDataBase.DsResultados.Tables[0];
                    //Validar si la tabla tiene un solo registro
                    if (objMedicos.DtResultado.Rows.Count == 1)
                    {
                        foreach (DataRow item in objMedicos.DtResultado.Rows)
                        {
                            objMedicos.CedulaM = item["cedulaM"].ToString();
                            objMedicos.NombreM = item["nombreM"].ToString();
                            objMedicos.Email = item["email"].ToString();
                            objMedicos.Especializacion = item["especializacion"].ToString();

                        }
                    }
                }
            }
            else
            {
                objMedicos.MensajeError = ObjDataBase.MensajeErrorOS;
            }
        }
        #region CRUD Medico

        public void Create(ref Entidades.ClsMedicosLn objMedicos)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "tbl_medicos",
                NombreSP = "[dbo].[SP_Medicos_Create]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@CedulaM", "15", objMedicos.CedulaM);
            ObjDataBase.DtParametros.Rows.Add(@"@NombreM", "15", objMedicos.NombreM);
            ObjDataBase.DtParametros.Rows.Add(@"@Email", "15", objMedicos.Email);
            ObjDataBase.DtParametros.Rows.Add(@"@Especializacion", "15", objMedicos.Especializacion);
            Ejecutar(ref objMedicos);
        }
        public void Update(ref Entidades.ClsMedicosLn objMedicos)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "tbl_medicos",
                NombreSP = "[dbo].[SP_Medicos_Update]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@CedulaM", "15", objMedicos.CedulaP);
            ObjDataBase.DtParametros.Rows.Add(@"@NombreM", "15", objMedicos.NombreP);
            ObjDataBase.DtParametros.Rows.Add(@"@Email", "15", objMedicos.Email);
            ObjDataBase.DtParametros.Rows.Add(@"@Especializacion", "15", objMedicos.Especializacion);
            Ejecutar(ref objMedicos);
        }
        public void Delete(ref Entidades.ClsMedicosLn objMedicos)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "tbl_medicos",
                NombreSP = "[dbo].[SP_Medicos_Delete]",
                Scalar = true,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@CedulaM", "15", objMedicos.CedulaM);
            Ejecutar(ref objMedicos);
        }
        public void Read(ref Entidades.ClsMedicosLn objMedicos)
        {
            ObjDataBase = new ClsDataBase()
            {
                NombreTabla = "tbl_medicos",
                NombreSP = "[dbo].[SP_Medicos_Read]",
                Scalar = false,
            };
            ObjDataBase.DtParametros.Rows.Add(@"@CedulaM", "15", objMedicos.CedulaM);
            Ejecutar(ref objMedicos);
        }

        #endregion

        #region Metodos Privados

        #endregion
    }
}
