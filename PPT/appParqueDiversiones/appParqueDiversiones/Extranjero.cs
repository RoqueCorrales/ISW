using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appParqueDiversiones
{
    class Extranjero : Visitor
    {

        public float ImpuestoExtranjero()
        {
            return 100;
        }

        public override float GetPayment()
        {
            return 5000;
        }

        public override float TotalToPay()
        {
            return base.TotalToPay() + this.ImpuestoExtranjero();
        }

        public override string ToString()
        {
            StringBuilder msg = new StringBuilder("");
            msg.Append("\n");
            msg.Append("Tipo visitante: EXTRANJERO");
            msg.Append("\n");
            msg.Append(base.ToString());
            msg.Append("\n");
            msg.Append("Impuesto extranjeros: " + this.ImpuestoExtranjero());
            msg.Append("\n");
            return msg.ToString();
        }
    }
}
