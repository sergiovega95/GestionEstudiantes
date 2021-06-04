using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesCore.Exceptions
{
    [Serializable]
    public class CustomExcepcion: Exception
    {
        public CustomExcepcion()
        {

        }

        public CustomExcepcion (string message)
            : base(String.Format($"Ocurrio el siguiente error: {message}"))
        {

        }
    }
}
