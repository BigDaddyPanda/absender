import PerfectScrollbar from "perfect-scrollbar";

export function getPerfectScrollBar(ps,mainPanel) {
    if (navigator.platform.indexOf("Win") > -1) {
        document.documentElement.className += " perfect-scrollbar-on";
        document.documentElement.classList.remove("perfect-scrollbar-off");
        ps = new PerfectScrollbar(mainPanel, {
            suppressScrollX: true
        });
        let tables = document.querySelectorAll(".table-responsive");
        for (let i = 0; i < tables.length; i++) {
            ps = new PerfectScrollbar(tables[i]);
        }
    }
    return ps;
}
/**
 * 
 * @param {PerfectScrollbar} ps 
 */
export function destroyPerfectScrollBar(ps) {
    if (navigator.platform.indexOf("Win") > -1) {
        ps.destroy();
        document.documentElement.className += " perfect-scrollbar-off";
        document.documentElement.classList.remove("perfect-scrollbar-on");
    }
    return ps;
}

export function updatePerfectScrollBar(ps,e,mainPanel) {
    if (e.history.action === "PUSH") {
        if (navigator.platform.indexOf("Win") > -1) {
            let tables = document.querySelectorAll(".table-responsive");
            for (let i = 0; i < tables.length; i++) {
                ps = new PerfectScrollbar(tables[i]);
            }
        }
        document.documentElement.scrollTop = 0;
        document.scrollingElement.scrollTop = 0;
        mainPanel.scrollTop = 0;
    }
    return ps;
}