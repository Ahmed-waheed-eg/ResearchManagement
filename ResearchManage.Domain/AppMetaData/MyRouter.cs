﻿namespace ResearchManage.Domain.AppMetaData
{
    public static class MyRouter
    {
        public const string Root = "Api/";
        public const string Version = "V1/";
        public const string Rule = Root + Version;

        public const string SingleRoute = "{id}";
        public static class ScholarRouting
        {
            public const string Prefix = Rule + "Scholar/";
            public const string list = Prefix + "List";
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edite = Prefix + "Edite";
            public const string Delete = Prefix + "{id}";
            public const string Paginated = Prefix + "Paginated";

        }

        public static class Supervisor
        {
            public const string Prefix = Rule + "Supervisor/";
            public const string list = Prefix + "List";
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edite = Prefix + "Edite";
            public const string Delete = Prefix + "{id}";
            public const string Paginated = Prefix + "Paginated";

        }
        public static class DepartmentRouting
        {
            public const string Prefix = Rule + "Department/";
            public const string list = Prefix + "List";
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edite = Prefix + "Edite";
            public const string Delete = Prefix + "{id}";
            public const string Paginated = Prefix + "Paginated";
            public const string Supervisor = Prefix + "Paginated/Subervisors";
            public const string Scholars = Prefix + "Paginated/Scholars";
            public const string Research = Prefix + "Paginated/Research";



        }


        public static class ResearchRouting
        {
            public const string Prefix = Rule + "Research/";
            public const string list = Prefix + "List";
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edite = Prefix + "Edite";
            public const string Delete = Prefix + "{id}";
            public const string Paginated = Prefix + "Paginated";

        }
    }
}
