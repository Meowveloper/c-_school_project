using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZweFitnessTrackingAPP
{
    internal class SwimmingClass : FitnessClass
    {
        //https://www.stylecraze.com/tools/calories-burned-swimming-calculator/

        public SwimmingClass(float m1, float m2, float m3)
        {
            Matric1Value = m1;
            Matric2Value = m2;
            Matric3Value = m3;

        }

        public float SwimmingActivity()
        {
            
            int uid = GlobalData._UserId;

            //get current calories

            float curcals = (float)CurrentTotalCalories(uid);

            // https://calculator-online.net/swimming-calorie-calculator/
            //m1=MET, m2=time, m3=weight
            // Calories burned per minute = (MET x body weight in Kg x 3.5) ÷ 200
            // Calories Burned  per minute = (6.0 x 81.65 x 3.5) ÷ 200 = 8.573
            float calpermin =(float) (Matric1Value * Matric3Value * 3.5) / 200;
            float calories = calpermin * Matric2Value;

            
            return calories;
        }
        public void InsertSwimmingActivity(int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DBClass db = new DBClass();
            db.Insert(uid, aid, m1, m2, m3, curcal);

        }
        public void UpdateSwimmingActivity(int mid,int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DBClass db = new DBClass();
            db.Update(mid,uid, aid, m1, m2, m3, curcal);

        }
        public void DeleteSwimmingActivity(int mid,int uid, int aid)
        {
            DBClass db = new DBClass();
            db.Delete(mid,uid, aid);

        }
    }
}
