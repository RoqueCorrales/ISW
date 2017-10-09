using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appParqueDiversiones
{
    class Mayor : Visitor
    {
        public override float GetPayment()
        {
            return 1000;
        }

        public override string ToString()
        {
            StringBuilder msg = new StringBuilder("");
            msg.Append("\n");
            msg.Append("Tipo visitante: MAYOR");
            msg.Append("\n");
            msg.Append(base.ToString());
            msg.Append("\n");
            return msg.ToString();
        }
    }
}
