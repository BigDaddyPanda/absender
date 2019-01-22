import { StudentList, ProfessorDashboard } from "../../views/ProfessorViews";

export * from "./ProfessorLayout"
export const Professor_Routes = [{
        path: "/student_list",
        name: "Student List",
        icon: "tim-icons icon-chart-pie-36",
        component: StudentList,
        layout: "/professor"
    },
    {
        path: "/dashboard",
        name: "Dashboard",
        icon: "tim-icons icon-chart-pie-36",
        component: ProfessorDashboard,
        layout: "/professor"
    },
]