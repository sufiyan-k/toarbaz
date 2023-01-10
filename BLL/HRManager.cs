namespace BLL;
using BOL;
using DAL.DisConnected;
public class HRManager
{
    public List<Department> GetAllDepartments(){
        List<Department> allDepartments = new List<Department>();
        allDepartments=DBManager.GetAllDepartments();
        return allDepartments;
    }
    
    public List<Employee> GetAllEmployees(int id){
        List<Employee> allemps=new List<Employee>();
        allemps=DBManager.GetAllEmployees(id);
        return allemps;
    }

}