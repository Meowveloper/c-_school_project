using ZweFitnessTrackingAPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ZweFitnessTrackingAPP
{
    internal class WalkingClass:FitnessClass
    {
        public WalkingClass(float m1, float m2, float m3) 
        {
            Matric1Value = m1;   
            Matric2Value = m2;  
            Matric3Value = m3; 
         
        }
        public float WalkingActivity()
        {

            //get targetClaroie
            int tarCal = GlobalData._targetCalorie;
            int uid = GlobalData._UserId;

            //get current calories

            float curcals =(float) CurrentTotalCalories(uid);

          // calculate using matric values and formula
            
                //Ref:https://www.omnicalculator.com/sports/steps-to-calories
                // (METs x 3.5 x weight in kg) / 200 x duration in minutes
                float stride = (Matric1Value/100) * 0.414f; //height * 0.414
                float distance = stride * Matric3Value; //stride * steps
                float time = distance / 1.34f;
                float calories = 3.5f*3.5f* Matric2Value / 200*(time/60); //Matric2Value=>weight

                        
                return calories;
            
        
            
        }
       public void InsertWalkingActivity(int uid, int aid,float m1, float m2, float m3, float curcal )
        {
            DBClass db = new DBClass();
            db.Insert(uid, aid, m1, m2, m3, curcal);

        }
        public void DeleteWalkingActivity(int mid,int uid, int aid)
        {
            DBClass db = new DBClass();
            db.Delete(mid,uid, aid);

        }
        public void UpdateWalkingActivity(int mid,int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DBClass db = new DBClass();
            db.Update(mid,uid, aid, m1, m2, m3, curcal);

        }

    }
}
