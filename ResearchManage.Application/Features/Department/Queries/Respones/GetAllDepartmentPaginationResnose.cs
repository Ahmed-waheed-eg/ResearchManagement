namespace ResearchManage.Application.Features.Department.Queries.Respones
{
    public class GetAllDepartmentPaginationResnose
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public GetAllDepartmentPaginationResnose(int iD, string name, string description)
        {
            ID = iD;
            Name = name;
            Description = description;
        }
    }
}
