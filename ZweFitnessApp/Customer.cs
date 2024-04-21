
using ZweFitnessTrackingAPP;
using System;

namespace ZweFitnessTrackingAPP
{
	
	public class Customer:Person
	{
        int id;
		int targetCal;

		public Customer()
		{
		}

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public int TargetCal
        {
            get
            {
                return targetCal;
            }
            set
            {
                targetCal = value;
            }
        }

        public Boolean Register(Customer c)
		{
            //Insert into DB

              DBClass dbc = new DBClass();
            if (dbc.checkExistingUser(c.UserName) == 0)
            {
                dbc.CreateAccount(c);
                return true;
            }
            else
                return false;

		}
		
		public override Boolean Login(string uname, string upass)
		{
            //Check from DB
            DBClass db = new DBClass();
            Customer c = new Customer();
            c= db.checkRegCustomer(uname, upass);
            GlobalData._UserId = c.Id;
            GlobalData._TargetCalorie = c.targetCal;

            if (GlobalData._UserId != 0)
                  return true;
            else return false;
		}
	}
}
