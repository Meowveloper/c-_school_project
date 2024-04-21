
using System;

namespace ZweFitnessTrackingAPP
{
	/// <summary>
	/// Description of Person.
	/// </summary>
	public class Person
	{


		String username;
		String password;
		String email;


		public Person()
		{
		}







		public String UserName
		{
			get
			{
				return username;
			}

			set
			{
				username = value;
			}
		}

		public String Password
		{
			get
			{
				return password;
			}
			set
			{
				password = value;
			}
		}

        public String Email
        {

            get
            {
                return email;
            }
            set
            {
                email = value;

            }
        }

        public virtual Boolean Login(string uname, string upass)
		{
			if (uname==this.username && upass==this.password) return true;
			else return false;
		}
	}
}
