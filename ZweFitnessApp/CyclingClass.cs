using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZweFitnessTrackingAPP
{
    internal class CyclingClass:FitnessClass
    {
        bool hillornot;
        public CyclingClass(float m1, float m2, float m3, string m4)
        {
            Matric1Value = m1;
            Matric2Value = m2;
            Matric3Value = m3;

            hillornot = m4 == "hill" ? true : false;

        }

        //calculating MET according to cycling speed
        private float calculatingCyclingMET(float mph)
        {
            float a = 0f;
            if (mph <= 12)
            {
                a = 4f;

            }
            else if (mph >= 13 && mph <= 15)
            {
                a = 6f;
            }
            else if (mph > 15)
            {
                a = 8f;
            }

            a = hillornot ? a + 4 : a + 0;//increasing met if the terrain is hill

            return a;
        }
        public float CyclingActivity()
        {

            // (METs x 3.5 x weight in kg) / 200 x duration in minutes
            float milesPerHour = Matric1Value / (Matric2Value / 60f);
            float metCycling = calculatingCyclingMET(milesPerHour);
            float calories = (metCycling * 3.5f * Matric3Value) / 200 * Matric2Value;
            return calories;



        }
        public void InsertCyclingActivity(int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DBClass db = new DBClass();
            db.Insert(uid, aid, m1, m2, m3, curcal);

        }
        public void DeleteCyclingActivity(int mid, int uid, int aid)
        {
            DBClass db = new DBClass();
            db.Delete(mid, uid, aid);

        }
        public void UpdateCyclingActivity(int mid, int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DBClass db = new DBClass();
            db.Update(mid, uid, aid, m1, m2, m3, curcal);

        }
    }
}
