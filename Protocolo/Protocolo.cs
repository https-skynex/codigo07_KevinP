/* ************************************************************************
                                Practica 07
Integrantes: Kevin Perez  
Fecha de realización: 11/06/2025  
Fecha de entrega: 18/06/2025  

RESULTADOS:  
Se implementaron las clases correspondientes para el correcto funcionamiento del protocolo de comunicación


CONCLUSIONES:  
1. La comunicación punto a punto con "Send" y "Receive" en MPI.NET permite verificar el estado y conectividad de 
procesos distribuidos de forma eficiente.  
2. El control del flujo centralizado en el proceso "Rank 0" es útil para orquestar tareas distribuidas o realizar 
pruebas de latencia.

RECOMENDACIONES:  
1. Usar este tipo de práctica para validar la instalación y funcionamiento de entornos MPI antes de realizar tareas 
paralelas complejas.  
2. Se recomienda ejecutar el programa en sistemas con múltiples núcleos o equipos distribuidos para evaluar su 
desempeño en entornos sreales.

************************************************************************ */

using System;
using System.Linq;

namespace Protocolo
{
    public enum Comando { INGRESO, CALCULO, CONTADOR }
    public class Pedido
    {
        public Comando Comando { get; set; } // En lugar de string
        public string[] Parametros { get; set; }
        public Guid Id { get; } = Guid.NewGuid();

        public static Pedido Procesar(string mensaje)
        {
            var partes = mensaje.Split(' ');
            return new Pedido
            {
                Comando = partes[0].ToUpper(),
                Parametros = partes.Skip(1).ToArray()
            };
        }

        public override string ToString()
        {
            return $"{Comando} {string.Join(" ", Parametros)}";
        }
    }

    public class Respuesta
    {
        public string Estado { get; set; }
        public string Mensaje { get; set; }

        public override string ToString()
        {
            return $"{Estado} {Mensaje}";
        }
    }

}
