using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appParqueDiversiones
{
    abstract class Visitor
    {
        private string mName;
        private DateTime mDate;

        public string Name
        {
            set { mName = value; }
            get { return mName; }
        } 

        public DateTime Date
        {
            set { mDate = value; }
            get { return mDate; }
        }

        public Visitor(string pName, DateTime pDate)
        {
            this.mName = pName;
            this.mDate = pDate;
        }

        public Visitor()
        {
        }

        public float Impuesto()
        {
            return this.GetPayment() * 0.13f;
        }

        public abstract float GetPayment();

        public virtual float TotalToPay()
        {
            return this.GetPayment() + this.Impuesto();
        }

        public virtual string ToString()
        {
            StringBuilder msg = new StringBuilder("");
            msg.Append("\n");
            msg.Append("Nombre       : " + this.Name);
            msg.Append("\n");
            msg.Append("Fecha        : " + this.Date);
            msg.Append("\n");
            msg.Append("Cobro        : " + this.GetPayment());
            msg.Append("\n");
            msg.Append("Impuesto     : " + this.Impuesto());
            msg.Append("\n");
            msg.Append("Total a pagar: " + this.TotalToPay());
            msg.Append("\n");
            return msg.ToString();
        }
    }
}
