using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    
    public class ClsPacienteLn
    {

        #region Atributos Privados

        private string _cedulaP, _nombreP;
        private string _email, _eps;

        //Atributos para conexión BD
        private string _mensajeError, _valorScalar;
        private DataTable _dtResultado;

        #endregion

        #region Atributos Publicos
            public string CedulaP { get => _cedulaP; set => _cedulaP = value; }
            public string NombreP { get => _nombreP; set => _nombreP = value; }
            public string Email { get => _email; set => _email = value; }
            public string Eps { get => _eps; set => _eps = value; }
            public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
            public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
            public DataTable DtResultado { get => _dtResultado; set => _dtResultado = value; }
        #endregion

    }
}
