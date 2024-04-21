﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZweFitnessTrackingAPP
{
    internal class AerobicClass:FitnessClass
    {
        public AerobicClass(float m1, float m2, float m3) {
            Matric1Value = m1;
            Matric2Value = m2;
            Matric3Value = m3;
        }

        public float AerobicActivity()
        {
            //MET * 3.5 * Weight(kg) / 200 * duration(minutes)
            return (float)(Matric1Value * 3.5f * Matric3Value) / 200f * Matric2Value;
        }

        public void InsertAerobicActivity(int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DBClass db = new DBClass();
            db.Insert(uid, aid, m1, m2, m3, curcal);
        }

        public void DeleteAerobicActivity(int mid, int uid, int aid)
        {
            DBClass db = new DBClass();
            db.Delete(mid, uid, aid);  
        }

        public void UpdateAerobicActivity(int mid, int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            DBClass db = new DBClass();
            db.Update(mid, uid, aid, m1, m2, m3, curcal);
        }
    }
}
