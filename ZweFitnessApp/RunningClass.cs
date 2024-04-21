using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZweFitnessTrackingAPP
{
    internal class RunningClass:FitnessClass
    {
        
        public RunningClass(float m1 ,float m2, float m3)
        {
            Matric1Value = m1;
            Matric2Value = m2;
            Matric3Value = m3;

            
        }
        public float RunningActivity()
        {
            //MET * 3.5 * Weight(kg) / 200 * duration(minutes)
            float calories = (Matric1Value * 3.5f * Matric3Value) / 200f * Matric2Value;
            return calories;
        }

        public void InsertRunningActivity(int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DBClass db = new DBClass();
            db.Insert(uid, aid, m1, m2, m3, curcal);

        }
        public void DeleteRunningActivity(int mid, int uid, int aid)
        {
            DBClass db = new DBClass();
            db.Delete(mid, uid, aid);

        }
        public void UpdateRunningActivity(int mid, int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DBClass db = new DBClass();
            db.Update(mid, uid, aid, m1, m2, m3, curcal);

        }
    }

}
