using ZweFitnessTrackingAPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZweFitnessTrackingAPP
{
    public class FitnessClass
    {
        
        float matric1Value;
        float matric2Value;
        float matric3Value;
      

        public float Matric1Value
        {
            get { return matric1Value; }
            set { matric1Value = value; }
        }

        public float Matric2Value
        {
            get { return matric2Value; }
            set { matric2Value = value; }
        }

        public float Matric3Value
        {
            get { return matric3Value; }
            set { matric3Value = value; }
        }

       
        
        public decimal CurrentTotalCalories(int uid)
        {
            DBClass db = new DBClass();
          
            return db.CurrentTotalCalories(uid);
           
        }
    }
}
