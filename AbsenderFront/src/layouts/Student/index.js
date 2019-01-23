import {
    StudentDashboard
} from "../../views/StudentViews/StudentDashboard";

export * from "./StudentLayout"
export const Student_Routes = [{
    path: "/dashboard",
    name: "Accueil",
    icon: "tim-icons icon-chart-pie-36",
    component: StudentDashboard,
    layout: "/student"
}]