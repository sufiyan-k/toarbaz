namespace DAL.DisConnected;
using BOL;
using System.Data;
using MySql.Data.MySqlClient;



public class DBManager{

    public static string conString=@"server=localhost;port=3306;user=root; password=root123;database=transflower";       
    public  static List<Department> GetAllDepartments(){
        List<Department> allDepartments=new List<Department>();

        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;
        try{
            DataSet ds=new DataSet();  //empty data set
            MySqlCommand cmd=new MySqlCommand();
            cmd.Connection=con;
            string query="SELECT * FROM departments";
            cmd.CommandText=query;
            //disconnected Data Access logic
            MySqlDataAdapter da=new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);  // this method would fetch data from backend mysql and 
                          //fill results into dataset collection
                          //deal with data which has been fetched from back end
            
            DataTable dt=ds.Tables[0];
            DataRowCollection rows=dt.Rows;
            foreach( DataRow row in rows)
            {
                int id = int.Parse(row["id"].ToString());
                string name = row["name"].ToString();
                string location = row["location"].ToString();
                Department dept=new Department{
                                                Id = id,
                                                Name = name,
                                                Location = location
                };
                allDepartments.Add(dept);
            }
        }
        catch(Exception ee){
                Console.WriteLine(ee.Message);
        }
        return allDepartments;
    }
    public static List<Employee> GetAllEmployees(int id){
        List<Employee> allemps=new List<Employee>();
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;
        try{
            DataSet ds=new DataSet();
            MySqlCommand cmd=new MySqlCommand();
            cmd.Connection=con;
            
            string query="Select * from employees where deptid="+id;
            cmd.CommandText=query;

            MySqlDataAdapter da=new MySqlDataAdapter();
            da.SelectCommand=cmd;
            da.Fill(ds);

            DataTable dt=ds.Tables[0];
            DataRowCollection rows=dt.Rows;

            foreach(DataRow row in rows){
                int idd=int.Parse(row["id"].ToString());
                string fn=row["firstname"].ToString();
                string ln=row["lastname"].ToString();
                string e=row["email"].ToString();
                string add=row["address"].ToString();
                string pass=row["password"].ToString();
                int di=int.Parse(row["deptid"].ToString());
                int mi=int.Parse(row["managerid"].ToString());

                Employee emp=new Employee{
                    Id=idd,
                    FirstName=fn,
                    LastName=ln,
                    Address=add,
                    Email=e,
                    DeptId=di,
                    ManagerId=mi,
                    Password=pass
                
                };
                allemps.Add(emp);
            }
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        return allemps;
    }













    }
           

//

            //DisConnected Data Access Mode
             //MySqlConnection  : establishing connection
            //MySqlCommand      : query execution
            //MySqlDataApater
            //DataSet
            //DataTable
            //DataRow
            //DataColumn
            //DataRealtion
