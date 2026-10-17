/*!
 * site.js - JavaScript del Sistema de Facturación.
 *
 * Responsabilidades (todas opcionales y tolerantes a fallos):
 *   1. Desplazamiento suave hacia las secciones de MaintenancePage.aspx.
 *   2. Resaltar la opción activa del menú contextual y de la barra superior.
 *
 * Sin dependencias: no requiere jQuery. Se carga al final del <body>.
 */

(function () {
    "use strict";

    // Selectores CSS de los elementos que el script manipula.
    var CONTEXT_MENU_SELECTOR = "#contextMenu a";
    var TOP_BAR_SELECTOR = "#topBar a";
    var SECTIONS_SELECTOR = "section[id]";
    var ACTIVE_CLASS = "active";

    // Devuelve la ruta de la página actual (nombre de archivo en minúsculas).
    function getCurrentPagePath() {
        return (window.location.pathname.split("/").pop() || "").toLowerCase();
    }

    // Devuelve el hash actual de la URL sin el símbolo #.
    function getCurrentHash() {
        return window.location.hash.replace("#", "");
    }

    // Indica si un href apunta a la página que se está viendo.
    function isSamePage(href) {
        var parts = href.split("#");
        var path = parts[0];

        // Si no hay ruta, es un ancla dentro de la misma página.
        if (!path) {
            return true;
        }

        var fileName = path.split("/").pop().toLowerCase();
        return fileName === getCurrentPagePath();
    }

    // Elimina la clase activa de todos los enlaces que coincidan con el selector.
    function removeActiveClasses(selector) {
        var links = document.querySelectorAll(selector);
        for (var i = 0; i < links.length; i++) {
            links[i].classList.remove(ACTIVE_CLASS);
        }
    }

    // Resalta el enlace del menú contextual que corresponde a la sección actual.
    function highlightActiveSection() {
        var hash = getCurrentHash() || getFirstSectionId();
        var links = document.querySelectorAll(CONTEXT_MENU_SELECTOR);

        for (var i = 0; i < links.length; i++) {
            var target = (links[i].getAttribute("href") || "").split("#")[1];
            if (target === hash) {
                links[i].classList.add(ACTIVE_CLASS);
            }
        }
    }

    // Devuelve el id de la primera sección de la página.
    function getFirstSectionId() {
        var section = document.querySelector(SECTIONS_SELECTOR);
        return section ? section.id : "";
    }

    // Resalta el enlace de la barra superior que corresponde a la página actual.
    function highlightCurrentPage() {
        var current = getCurrentPagePath();
        var links = document.querySelectorAll(TOP_BAR_SELECTOR);

        for (var i = 0; i < links.length; i++) {
            var href = (links[i].getAttribute("href") || "").split("#")[0];

            if (href && href.toLowerCase().split("/").pop() === current) {
                links[i].classList.add(ACTIVE_CLASS);
            }
        }
    }

    // Habilita el desplazamiento suave al hacer clic en anclas de la misma página.
    function enableSmoothScroll() {
        document.addEventListener("click", function (event) {
            var link = event.target.closest ? event.target.closest("a[href*='#']") : null;

            // Ignorar clics que no sean en anclas de la misma página.
            if (!link || !isSamePage(link.getAttribute("href") || "")) {
                return;
            }

            var id = (link.getAttribute("href") || "").split("#")[1];
            var target = id ? document.getElementById(id) : null;

            if (!target) {
                return;
            }

            event.preventDefault();
            target.scrollIntoView({ behavior: "smooth", block: "start" });

            // Actualiza la URL y el resaltado sin recargar la página.
            if (history.pushState) {
                history.pushState(null, "", "#" + id);
            } else {
                window.location.hash = id;
            }

            removeActiveClasses(CONTEXT_MENU_SELECTOR);
            highlightActiveSection();
        });
    }

    // Inicializa el script cuando el DOM está listo.
    function initialize() {
        highlightCurrentPage();
        highlightActiveSection();
        enableSmoothScroll();

        // Volver a resaltar cuando cambie el hash (navegación por anclas).
        window.addEventListener("hashchange", function () {
            removeActiveClasses(CONTEXT_MENU_SELECTOR);
            highlightActiveSection();
        });
    }

    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", initialize);
    } else {
        initialize();
    }
})();
