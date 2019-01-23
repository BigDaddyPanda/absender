import { StudentList, ProfessorDashboard } from "../../views/ProfessorViews";

export * from "./ProfessorLayout"
export const Professor_Routes = [{
        path: "/student_list",
        name: "Seance Courante",
        icon: "tim-icons icon-chart-pie-36",
        component: StudentList,
        layout: "/professor"
    },
    {
        path: "/dashboard",
        name: "Emploie du Temps",
        icon: "tim-icons icon-chart-pie-36",
        component: ProfessorDashboard,
        layout: "/professor"
    },
]