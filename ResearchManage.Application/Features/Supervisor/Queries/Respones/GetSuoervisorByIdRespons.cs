namespace ResearchManage.Application.Features.Supervisor.Queries.Respones
{
    public class GetSuoervisorByIdRespons
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}
