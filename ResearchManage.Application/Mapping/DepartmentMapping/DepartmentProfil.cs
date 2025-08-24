using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchManage.Application.Mapping.DepartmentMapping
{
    public partial class DepartmentProfil :Profile
    {
        public DepartmentProfil() 
        {
            GetDepartmentByIdMapping();
        }
    }
}
