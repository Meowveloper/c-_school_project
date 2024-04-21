using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using ZweFitnessTrackingAPP;
using System.Reflection;

namespace ZweFitnessTrackingAPP
{

    public class DBClass
    {
        OleDbCommand mycmd;
        OleDbDataReader myreader;
        OleDbConnection conn;
        String constr;

        public DBClass() //constructor
        {

            constr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + Application.StartupPath + @"\FitnessDB.mdb";
            conn = new OleDbConnection();
            conn.ConnectionString = constr;
        }

        public void CreateAccount(Customer c)  //carry input from BCCustomer
        {

            int id = getMaxUserId();   //Get last user ID from DB
            string query = "INSERT INTO [User] VALUES " + "(" + id + ",'" + c.UserName + "','" + c.Password + "','" + c.Email + "','" + c.TargetCal + "')";

            conn.Open();
            mycmd = new OleDbCommand(query, conn);

            mycmd.ExecuteScalar();
            conn.Close();

        }
        private int getMaxUserId() //type (Data type) function 
        {
            mycmd = new OleDbCommand();
            mycmd.Connection = conn;

            int id = 0;
            string query = "Select MAX(uid) from [User]";
            mycmd.CommandText = query;
            try
            {
                conn.Open();
                if (mycmd.ExecuteScalar() != DBNull.Value)
                    id = Convert.ToInt32(mycmd.ExecuteScalar().ToString());
                else id = 0;

                return id + 1;
            }
            catch (OleDbException oex) { throw oex; }
            finally
            {
                conn.Close();
            }
        }
        private int getMaxActivityId() //type (Data type) function 
        {
            mycmd = new OleDbCommand();
            mycmd.Connection = conn;

            int id = 0;
            string query = "Select MAX(mid) from [UserActMatric]";
            mycmd.CommandText = query;
            try
            {
                conn.Open();
                if (mycmd.ExecuteScalar() != DBNull.Value)
                    id = Convert.ToInt32(mycmd.ExecuteScalar().ToString());
                else id = 0;

                return id + 1;
            }
            catch (OleDbException oex) { throw oex; }
            finally
            {
                conn.Close();
            }
        }
        public int checkExistingUser(string inputUserName)
        {
            int id = 0;
            string query = "Select uid from [User] where name='" + inputUserName + "'";

            mycmd = new OleDbCommand();
            mycmd.Connection = conn;
            mycmd.CommandText = query;
            try
            {

                conn.Open();

                OleDbDataReader reader = mycmd.ExecuteReader();
                while (reader.Read())
                {
                    id = Int32.Parse(reader.GetValue(0).ToString());    //array position "0" value - "cid"
                }

            }
            catch (OleDbException oe) { }
            conn.Close();
            return id;
        }

        public Customer checkRegCustomer(string username, string password)
        {
            Customer c = new Customer();
            int id = 0, tarCal = 0;
            //for MSAccess case sensitive StrComp(Table1.Field1, Table2.Field2, 0) = 0
            string query = "Select * from [User] where name='" + username + "' and StrComp(password,'" + password + "',0)=0";
            mycmd = new OleDbCommand();
            mycmd.Connection = conn;
            mycmd.CommandText = query;
            try
            {
                conn.Open();
                OleDbDataReader reader = mycmd.ExecuteReader();
                while (reader.Read())
                {
                    id = Int32.Parse(reader.GetValue(0).ToString());    //array position "0" value - "id"
                    tarCal = Int32.Parse(reader.GetValue(4).ToString());                                                  //string name = reader.GetValue(1).ToString();

                }
                c.Id = id;
                c.TargetCal = tarCal;

            }
            catch (OleDbException oe) { }
            conn.Close();
            return c;
        }


        public DataSet getTable(int uid, int aid)
        {
            string sql = "SELECT * FROM [UserActMatric] where uid=" + uid + " AND aid=" + aid;
            OleDbConnection connection = new OleDbConnection(constr);
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "UserActivityMatricTable");
            connection.Close();
            return ds;

        }

        public DataSet getUserAndActivityTable(int uid)
        {
            
            string sql = "SELECT Activity.aname, UserActMatric.curCal" +
                " FROM Activity INNER JOIN UserActMatric ON Activity.aid = UserActMatric.aid" +
                " WHERE UserActMatric.uid =" + uid;
            ;
            OleDbConnection connection = new OleDbConnection(constr);
            OleDbDataAdapter dataadapter = new OleDbDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "GetUserAndActivityTable");
            connection.Close();
            return ds;

        }



        public List<string> getActivities()
        {
            var items = new List<string>();
            items.Add("none");

            string query = "Select aname from [Activity] order by aid asc";
            mycmd = new OleDbCommand();
            mycmd.Connection = conn;
            mycmd.CommandText = query;
            try
            {
                conn.Open();

                OleDbDataReader myreader = mycmd.ExecuteReader();
                items.Clear();

                while (myreader.HasRows)
                {
                    myreader.GetName(0);
                    while (myreader.Read())
                    {

                        items.Add(Convert.ToString(myreader.GetValue(0).ToString()));
                    }

                    myreader.NextResult();
                }
            }
            catch (OleDbException oex) { throw oex; }
            finally
            {
                conn.Close();
            }

            return items;
        }


        public decimal CurrentTotalCalories(int uid)
        {

            mycmd = new OleDbCommand();
            mycmd.Connection = conn;
            decimal totalcal = 0;

            string query = "Select SUM(curcal) from [UserActMatric] WHERE uid=" + uid + " GROUP BY uid";
            mycmd.CommandText = query;
            try
            {
                conn.Open();
                myreader = mycmd.ExecuteReader();
               while (myreader.Read())
                {
                    totalcal = Convert.ToDecimal(myreader.GetValue(0).ToString());
                }
            }
            catch (Exception oex) { throw oex; }
            
            myreader.Close();
            conn.Close();
            return totalcal;
        }

        public void Insert(int uid, int aid, float m1, float m2, float m3, float curcal)
        {
            int mid = getMaxActivityId();  //Get max activity ID from DB
            string query = "INSERT INTO [UserActMatric] VALUES " + "(" + mid + "," + uid + "," + aid + "," + m1 + "," + m2 + "," + m3 + "," + curcal + ")";

            conn.Open();
            mycmd = new OleDbCommand(query, conn);

            mycmd.ExecuteScalar();
            conn.Close();
        }
        public void Update(int mid, int uid, int aid, float m1, float m2, float m3, float curcal)
        {

            string query = "UPDATE [UserActMatric] SET matric1=" + m1 + ", matric2=" + m2 + ", matric3=" + m3 + ", curCal=" + curcal + " WHERE mid=" + mid + " AND uid=" + uid + " AND aid=" + aid;

            conn.Open();
            mycmd = new OleDbCommand(query, conn);

            mycmd.ExecuteScalar();
            conn.Close();
        }

        public void Delete(int mid, int uid, int aid)
        {
            string query = "DELETE FROM [UserActMatric] WHERE mid=" + mid + " AND uid=" + uid + " AND aid=" + aid;
            conn.Open();
            mycmd = new OleDbCommand(query, conn);

            mycmd.ExecuteScalar();
            conn.Close();
        }
    }
}
