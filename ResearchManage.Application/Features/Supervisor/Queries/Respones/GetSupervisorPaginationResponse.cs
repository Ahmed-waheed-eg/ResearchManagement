namespace ResearchManage.Application.Features.Supervisor.Queries.Respones
{
    public class GetSupervisorPaginationResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }


        public GetSupervisorPaginationResponse(int id, string name)
        {
            ID = id;
            Name = name;

        }
    }
}
