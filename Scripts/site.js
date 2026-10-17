/*!
 * site.js - JavaScript propio del Sistema de Facturación.
 *
 * Responsabilidades (todas opcionales y tolerantes a fallos):
 *   1. Desplazamiento suave hacia las secciones de MaintenancePage.aspx (#empresa, #cajas, ...).
 *   2. Resaltar la opción activa del menú contextual y de la barra superior.
 *
 * Sin dependencias: no requiere jQuery. Se carga al final del <body>.
 */
(function () {
    "use strict";

    var MENU_CONTEXTUAL = "#menuContextual a";
    var BARRA_SUPERIOR = "#barraHorizontal a";
    var SECCIONES = "section[id]";
    var CLASE_ACTIVA = "activo";

    function rutaActual() {
        return (window.location.pathname.split("/").pop() || "").toLowerCase();
    }

    function hashActual() {
        return window.location.hash.replace("#", "");
    }

    // Indica si un href apunta a la página que se está viendo.
    function esMismaPagina(href) {
        var partes = href.split("#");
        var ruta = partes[0];
        if (!ruta) {
            return true; // ancla dentro de la misma página
        }
        var archivo = ruta.split("/").pop().toLowerCase();
        return archivo === rutaActual();
    }

    function quitarClasesActivas(selector) {
        var enlaces = document.querySelectorAll(selector);
        for (var i = 0; i < enlaces.length; i++) {
            enlaces[i].classList.remove(CLASE_ACTIVA);
        }
    }

    function resaltarSeccionActiva() {
        var hash = hashActual() || primeraSeccion();
        var enlaces = document.querySelectorAll(MENU_CONTEXTUAL);
        for (var i = 0; i < enlaces.length; i++) {
            var destino = (enlaces[i].getAttribute("href") || "").split("#")[1];
            if (destino === hash) {
                enlaces[i].classList.add(CLASE_ACTIVA);
            }
        }
    }

    function primeraSeccion() {
        var seccion = document.querySelector(SECCIONES);
        return seccion ? seccion.id : "";
    }

    function resaltarPaginaActiva() {
        var actual = rutaActual();
        var enlaces = document.querySelectorAll(BARRA_SUPERIOR);
        for (var i = 0; i < enlaces.length; i++) {
            var href = (enlaces[i].getAttribute("href") || "").split("#")[0];
            if (href && href.toLowerCase().split("/").pop() === actual) {
                enlaces[i].classList.add(CLASE_ACTIVA);
            }
        }
    }

    // Intercepta los clics en anclas de la misma página para animar el desplazamiento.
    function habilitarScrollSuave() {
        document.addEventListener("click", function (evento) {
            var enlace = evento.target.closest ? evento.target.closest("a[href*='#']") : null;
            if (!enlace || !esMismaPagina(enlace.getAttribute("href") || "")) {
                return;
            }

            var id = (enlace.getAttribute("href") || "").split("#")[1];
            var destino = id ? document.getElementById(id) : null;
            if (!destino) {
                return;
            }

            evento.preventDefault();
            destino.scrollIntoView({ behavior: "smooth", block: "start" });

            // Actualiza la URL y el resaltado sin recargar.
            if (history.pushState) {
                history.pushState(null, "", "#" + id);
            } else {
                window.location.hash = id;
            }
            quitarClasesActivas(MENU_CONTEXTUAL);
            resaltarSeccionActiva();
        });
    }

    function iniciar() {
        resaltarPaginaActiva();
        resaltarSeccionActiva();
        habilitarScrollSuave();
        window.addEventListener("hashchange", function () {
            quitarClasesActivas(MENU_CONTEXTUAL);
            resaltarSeccionActiva();
        });
    }

    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", iniciar);
    } else {
        iniciar();
    }
})();
