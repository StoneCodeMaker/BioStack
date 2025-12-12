// Custom JavaScript helpers for BioStack
window.bioStackInterop = {
    triggerClick: function (elementId) {
        const element = document.getElementById(elementId);
        if (element) {
            element.click();
        }
    },

    initializeMudBlazor: function () {
        if (typeof MudBlazor !== 'undefined') {
            console.debug("MudBlazor detected – components ready");
        } else {
            console.warn("MudBlazor global not found; charts/buttons may misbehave");
        }
    },

    ensureChartsRendered: function () {
        const charts = document.querySelectorAll('.mud-chart');
        if (!charts.length) {
            return;
        }

        // Trigger a resize shortly after navigation to force chart redraws.
        setTimeout(() => {
            window.dispatchEvent(new Event('resize'));
        }, 150);
    },

    saveAsFile: function (filename, bytesBase64) {
        var link = document.createElement('a');
        link.download = filename;
        link.href = "data:application/octet-stream;base64," + bytesBase64;
        document.body.appendChild(link); // Needed for Firefox
        link.click();
        document.body.removeChild(link);
    }
};

// Kick off helpers once DOM is ready
window.addEventListener('DOMContentLoaded', () => {
    if (window.bioStackInterop) {
        window.bioStackInterop.initializeMudBlazor();
        window.bioStackInterop.ensureChartsRendered();
    }
});

// When Blazor switches pages in interactive mode, re-run helpers
window.addEventListener('blazor:interactive', () => {
    if (window.bioStackInterop) {
        window.bioStackInterop.initializeMudBlazor();
        window.bioStackInterop.ensureChartsRendered();
    }
});
